
''' <summary>
''' Ramps up between to levels
''' </summary>
''' <remarks></remarks>
Public Class B_Ramp
    Inherits Block

    ''' <summary>
    ''' the last incomming call
    ''' </summary>
    ''' <remarks></remarks>
    Private _lastIn As Boolean = False
    ''' <summary>
    ''' where to start the ramp
    ''' </summary>
    ''' <remarks></remarks>
    Public Min As Double
    ''' <summary>
    ''' where to end the ramp
    ''' </summary>
    ''' <remarks></remarks>
    Public Max As Double
    ''' <summary>
    ''' how much to step up each time
    ''' </summary>
    ''' <remarks></remarks>
    Public [Step] As Double
    ''' <summary>
    ''' if to reset back to min if max is reached automatically
    ''' </summary>
    ''' <remarks></remarks>
    Public ResetsOnMax As Boolean


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Min = XHelper.Get(node, "Min", 0.0)
        Max = XHelper.Get(node, "Max", 100.0)
        [Step] = XHelper.Get(node, "Step", 1)
        ResetsOnMax = XHelper.Get(node, "ResetOnMax", False)

        m_Inputs.Add(New Connector("Trigger", True, True, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Min", Min)
        XHelper.Set(node, "Max", Max)
        XHelper.Set(node, "Step", [Step])
        XHelper.Set(node, "ResetOnMax", ResetsOnMax)
    End Sub

    Public Overrides Sub Update()
        'check for a change in the input ("trigger")
        Dim v As Double = m_outputs(0).Value
        If _lastIn <> m_Inputs(0).DigValue Then
            _lastIn = m_Inputs(0).DigValue
            'index up one if we are on an "on" value
            If _lastIn Then
                v += [Step]
                If ResetsOnMax Then
                    If [Step] > 0 Then
                        'this is a positive ramp
                        If v >= Max Then v = Min
                    Else
                        'this is a negative ramp
                        If v <= Max Then v = Min
                    End If
                End If
            End If
        End If

        'check the reset input for setting back to 0
        If m_Inputs(1).DigValue Then v = Min

        'update the output
        m_outputs(0).Value = v

    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Ramp
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Ramp"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Ramp_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
