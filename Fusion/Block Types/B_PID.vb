
''' <summary>
''' for pid control of an output
''' </summary>
''' <remarks></remarks>
Public Class B_PID
    Inherits Block

    Public Reset As Double                  'helps caculate the quicknes of change
    Public Gain As Double                   'Gain, negative if controller is reverse acting /Proportional Band
    Public DerivativeGain As Double         'alows for influance on the Derivative
    Public Minimum As Double                'the minimum and maximum values the pid can achieve
    Public Maximum As Double
    Public MaxChange As Double              'maximum change allow in one calculation
    Public WaitTime As Double               'the time to wait between calcs, default 3 seconds

    Private _LastPV As Double               'save the last ProcessVariable
    Private _Bias As Double                 'private, read-only from outside this object
    Private _LastCalc As Long               'last time calculation was done - use system time ticks assuming 1 ms resolution
    Private _Devs(2) As Double              '3 overtime devations
    Private _Index As Integer               'what to put the latest dev into

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        _LastCalc = Now.Ticks

        Reset = XHelper.Get(node, "Reset", 30.0)
        Gain = XHelper.Get(node, "Gain", 20.0)
        DerivativeGain = XHelper.Get(node, "DGain", 15.0)
        Minimum = XHelper.Get(node, "Min", 0.0)
        Maximum = XHelper.Get(node, "Max", 100.0)
        MaxChange = XHelper.Get(node, "MaxChange", 5.0)
        WaitTime = XHelper.Get(node, "WaitTime", 1.0)

        m_Inputs.Add(New Connector("Value", True, False, Me))
        m_Inputs.Add(New Connector("SP", True, False, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Reset", Reset)
        XHelper.Set(node, "Gain", Gain)
        XHelper.Set(node, "DGain", DerivativeGain)
        XHelper.Set(node, "Min", Minimum)
        XHelper.Set(node, "Max", Maximum)
        XHelper.Set(node, "MaxChange", MaxChange)
        XHelper.Set(node, "WaitTime", WaitTime)
    End Sub

    Public Overrides Sub Update()
        Dim v As Double = Minimum

        If m_Inputs(2).DigValue Then
            'clear/reset the PID internals
            _LastCalc = 0
            _Devs(0) = 0
            _Devs(1) = 0
            _Devs(2) = 0
            _Bias = 0
            _LastPV = 0
        Else

            ' how long since last calculation - convert it to
            ' seconds with decimals (nano seconds to seconds)
            Dim cT As Long = Now.Ticks
            Dim tD As Double = (cT - _LastCalc) / 10000000

            If tD >= WaitTime Then
                _LastCalc = cT
                Dim pV As Double = m_Inputs(0).Value
                Dim sP As Double = m_Inputs(1).Value

                ' get deviation from setpoint
                'and average the 3 reads
                _Devs(_Index) = pV - sP
                _Index += 1 : If _Index > 2 Then _Index = 0
                Dim dv As Double = (_Devs(0) + _Devs(1) + _Devs(2)) / 3

                'caculate the quickness of change
                _Bias += ((tD / Reset) * dv)

                ' set limits on bias
                If _Bias < Minimum Then
                    _Bias = Minimum
                ElseIf _Bias > Maximum Then
                    _Bias = Maximum
                End If

                'caculate the derivative for this loop
                Dim d As Double = ((_LastPV - pV) / tD) * DerivativeGain
                _LastPV = pV

                Dim lo As Double = m_outputs(0).Value
                Dim o As Double = (Gain * (dv - d)) + _Bias

                ' limit change for max changes per calc
                If ((Math.Abs(lo - o)) > MaxChange) Then
                    If (o > lo) Then
                        o = lo + MaxChange
                    Else
                        o = lo - MaxChange
                    End If
                End If

                ' enforce limits on the final output value
                If o < Minimum Then
                    o = Minimum
                ElseIf o > Maximum Then
                    o = Maximum
                End If
                v = o
            Else
                v = m_outputs(0).Value
            End If
        End If

        m_outputs(0).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.PID
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_PID_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
