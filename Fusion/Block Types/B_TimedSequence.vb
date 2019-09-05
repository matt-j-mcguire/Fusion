
''' <summary>
''' provides Steps to sequence different outputs
''' </summary>
''' <remarks></remarks>
Public Class B_TimedSequence
    Inherits Block

    Public Class TimedSequenceStep
        Public Len As Integer
        Public Oo As Integer
    End Class

    ''' <summary>
    ''' current output index
    ''' </summary>
    ''' <remarks></remarks>
    Private _Index As Integer = -1
    ''' <summary>
    ''' steps to follow
    ''' </summary>
    ''' <remarks></remarks>
    Public steps As List(Of TimedSequenceStep)
    ''' <summary>
    ''' when the current step will be over
    ''' </summary>
    ''' <remarks></remarks>
    Private _NextStep As DateTime

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Trigger", True, True, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))

        Dim cnt As Integer = XHelper.Get(node, "OutCount", 2)
        For xloop As Integer = 0 To cnt - 1
            m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
        Next

        steps = New List(Of TimedSequenceStep)
        cnt = XHelper.Get(node, "StpCount", 1)
        For xloop As Integer = 0 To cnt - 1
            Dim s As New TimedSequenceStep
            s.Len = XHelper.Get(node, "StpLen" & xloop, 1)
            s.Oo = XHelper.Get(node, "StpOut" & xloop, 0)
            steps.Add(s)
        Next

    End Sub

    ''' <summary>
    ''' changes the ammount of output connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        If cnt > m_outputs.Count Then
            For xloop As Integer = m_outputs.Count To cnt - 1
                m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
            Next
        Else
            For xloop As Integer = cnt To m_outputs.Count - 1 Step -1
                If m_outputs(xloop).isUsed Then m_outputs(xloop).Disconnect()
                m_outputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "OutCount", m_outputs.Count)
        XHelper.Set(node, "StpCount", steps.Count)
        For xloop As Integer = 0 To steps.Count - 1
            XHelper.Set(node, "StpLen" & xloop, steps(0).Len)
            XHelper.Set(node, "StpOut" & xloop, steps(0).Oo)
        Next
    End Sub

    Public Overrides Sub Update()

        'only check for the "Trigger" event if not started yet
        If _Index = -1 Then
            If m_Inputs(0).DigValue Then
                _Index = 0
                _NextStep = Now.AddSeconds(steps(0).Len)
            End If
        End If

        'check for the "Reset" event to clear the start event
        If m_Inputs(1).DigValue Then _Index = -1

        If _Index > -1 Then
            If Now >= _NextStep Then
                'current step is over move to the next one
                _Index += 1
                If _Index > steps.Count - 1 Then
                    _Index = -1
                Else
                    _NextStep = Now.AddSeconds(steps(_Index).Len)
                End If
            Else
                'make sure all outputs that should be on are on.
                For xloop As Integer = 0 To m_outputs.Count - 1
                    m_outputs(xloop).DigValue = steps(_Index).Oo And (1 << xloop)
                Next
            End If
        Else
            'no step, shut off all outputs
            For xloop As Integer = 0 To m_outputs.Count - 1
                m_outputs(xloop).DigValue = False
            Next
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.TimedSequence
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "T. Seq."
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_TimedSequence_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class

