
''' <summary>
''' user defined truth setup
''' </summary>
''' <remarks>
''' undefined cases will be left from the last step
''' </remarks>
Public Class B_TruthTable
    Inherits Block

    Public Class TruthTableStep
        Public Io As Integer
        Public Oo As Integer
    End Class

    Public steps As List(Of TruthTableStep)

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Dim cnt As Integer = XHelper.Get(node, "InCount", 2)
        For xloop As Integer = 0 To cnt - 1
            m_Inputs.Add(New Connector("i_" & xloop, True, True, Me))
        Next
        cnt = XHelper.Get(node, "OutCount", 2)
        For xloop As Integer = 0 To cnt - 1
            m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
        Next

        steps = New List(Of TruthTableStep)
        cnt = XHelper.Get(node, "StpCount", 4)
        For xloop As Integer = 0 To cnt - 1
            Dim s As New TruthTableStep
            s.Io = XHelper.Get(node, "StpIn" & xloop, 0)
            s.Oo = XHelper.Get(node, "StpOut" & xloop, 0)
            steps.Add(s)
        Next
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "InCount", m_Inputs.Count)
        XHelper.Set(node, "OutCount", m_outputs.Count)
        XHelper.Set(node, "StpCount", steps.Count)
        For xloop As Integer = 0 To steps.Count - 1
            XHelper.Set(node, "StpIn" & xloop, steps(0).Io)
            XHelper.Set(node, "StpOut" & xloop, steps(0).Oo)
        Next
    End Sub

    Public Overrides Sub Update()
        'get the incomming value for all the inputs
        Dim inval As Integer
        For xloop As Integer = 0 To m_Inputs.Count - 1
            If m_Inputs(xloop).DigValue Then inval += (1 << xloop)
        Next

        'check all the steps for matching inputs
        For xloop As Integer = 0 To steps.Count - 1
            If steps(xloop).Io = inval Then
                For yloop As Integer = 0 To m_outputs.Count - 1
                    If steps(xloop).Oo And (1 << yloop) Then
                        m_outputs(yloop).DigValue = True
                    Else
                        m_outputs(yloop).DigValue = False
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' changes the ammount of input connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeInputConnectorCount(cnt As Integer)
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

    ''' <summary>
    ''' changes the ammount of output connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeOutputConnectorCount(cnt As Integer)
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

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.TruthTable
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Truth"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_TruthTable_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
