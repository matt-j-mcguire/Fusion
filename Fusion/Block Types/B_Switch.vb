
''' <summary>
''' works like a select case. what ever first digital evals true, it will use that output
''' </summary>
''' <remarks>the last output value holds true</remarks>
Public Class B_Switch
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Dim cnt As Integer = XHelper.Get(node, "Count", 2)

        For xloop As Integer = 0 To cnt - 1
            m_Inputs.Add(New Connector("i_" & xloop, True, True, Me))
            m_Inputs.Add(New Connector("ia_" & xloop, True, False, Me))
        Next
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Count", m_Inputs.Count / 2)
    End Sub

    ''' <summary>
    ''' changes the ammount of input connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        If cnt > m_Inputs.Count / 2 Then
            For xloop As Integer = m_Inputs.Count To cnt - 1
                m_Inputs.Add(New Connector("i_" & xloop, False, True, Me))
                m_Inputs.Add(New Connector("ia_" & xloop, True, False, Me))
            Next
        Else
            For xloop As Integer = cnt To m_Inputs.Count - 1 Step -1
                If m_Inputs(xloop).isUsed Then m_Inputs(xloop).Disconnect()
                m_Inputs.RemoveAt(xloop)
                If m_Inputs(xloop - 1).isUsed Then m_Inputs(xloop - 1).Disconnect()
                m_Inputs.RemoveAt(xloop - 1)
            Next
        End If
    End Sub

    Public Overrides Sub Update()
        Dim v As Double = m_outputs(0).Value

        For xloop As Integer = 0 To m_Inputs.Count - 1 Step 2
            If m_Inputs(xloop).isUsed AndAlso m_Inputs(xloop).DigValue = True Then v = m_Inputs(xloop).Value
        Next

        m_outputs(0).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Switch
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Switch"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SWitch_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
