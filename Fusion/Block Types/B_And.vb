
''' <summary>
''' And Gate
''' </summary>
''' <remarks>
''' 
'''  A │ B │ C
''' ┌──┼───┼──┐
''' │0 │ 0 │ 0│
''' │1 │ 0 │ 0│
''' │0 │ 1 │ 0│
''' │1 │ 1 │ 1│
''' └──┴───┴──┘
''' ─│┌ ┐└ ┘├ ┤┬ ┴ ┼
''' </remarks>
Public Class B_And
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Dim cnt As Integer = XHelper.Get(node, "Count", 2)

        For xloop As Integer = 0 To cnt - 1
            m_Inputs.Add(New Connector("i_" & xloop, True, True, Me))
        Next
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Count", m_Inputs.Count)
    End Sub

    ''' <summary>
    ''' changes the ammount of input connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        If cnt > m_Inputs.Count Then
            For xloop As Integer = m_Inputs.Count To cnt - 1
                m_Inputs.Add(New Connector("i_" & xloop, True, True, Me))
            Next
        Else
            For xloop As Integer = cnt To m_Inputs.Count - 1 Step -1
                If m_Inputs(xloop).isUsed Then m_Inputs(xloop).Disconnect()
                m_Inputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Update()
        Dim b As Boolean = True
        For xloop As Integer = 0 To m_Inputs.Count - 1
            If m_Inputs(xloop).isUsed AndAlso m_Inputs(xloop).DigValue = False Then b = False
        Next
        m_outputs(0).DigValue = b
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.And
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "And"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_And_Props
        ex.LoadItem(Me.GetUI)
        Return ex
    End Function

End Class
