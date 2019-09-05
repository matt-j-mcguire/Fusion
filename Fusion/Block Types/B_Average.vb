
''' <summary>
''' caculates an average of 2 or more analog inputs
''' </summary>
''' <remarks></remarks>
Public Class B_Average
    Inherits Block

    Public UseWeights As Boolean
    Public Weights() As Integer
    Public HighInputError As Double
    Public LowInputError As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        UseWeights = XHelper.Get(node, "UseWeights", False)
        HighInputError = XHelper.Get(node, "HighInputError", 150)
        LowInputError = XHelper.Get(node, "LowInputError", -1)
        Dim cnt As Integer = XHelper.Get(node, "Count", 3)

        ReDim Weights(cnt - 1)
        For xloop As Integer = 0 To cnt - 1
            Weights(xloop) = XHelper.Get(node, "Weight" & xloop, 0)
            m_Inputs.Add(New Connector("i_" & xloop, True, False, Me))
        Next

        m_outputs.Add(New Connector("o_0", False, False, Me))
        m_outputs.Add(New Connector("Error", False, True, Me))
    End Sub

    ''' <summary>
    ''' changes the ammount of input connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        ReDim Preserve Weights(cnt - 1)
        If cnt > m_Inputs.Count Then
            For xloop As Integer = m_Inputs.Count To cnt - 1
                m_Inputs.Add(New Connector("o_" & xloop, False, True, Me))
            Next
        Else
            For xloop As Integer = cnt To m_Inputs.Count - 1 Step -1
                If m_Inputs(xloop).isUsed Then m_Inputs(xloop).Disconnect()
                m_Inputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "UseWeights", UseWeights)
        XHelper.Set(node, "HighInputError", HighInputError)
        XHelper.Set(node, "LowInputError", LowInputError)
        For xloop As Integer = 0 To m_Inputs.Count - 1
            XHelper.Set(node, "Weight" & xloop, Weights(xloop))
        Next
    End Sub

    Public Overrides Sub Update()
        Dim v As Double = 0.0

        Dim inerror As Boolean = False
        Dim vals(m_Inputs.Count - 1) As Double
        For xloop As Integer = 0 To m_Inputs.Count - 1
            vals(xloop) = m_Inputs(xloop).Value
            If vals(xloop) >= HighInputError Or vals(xloop) <= LowInputError Then inerror = True
        Next

        If UseWeights Then
            Dim t As Double = 0.0
            Dim w As Integer = 0
            For xloop As Integer = 0 To m_Inputs.Count - 1
                If Weights(xloop) > 0 Then
                    t += (vals(xloop) * Weights(xloop))
                    w += Weights(xloop)
                End If
            Next
            If w > 0 Then
                v = t / w
            Else
                inerror = True
                v = 0
            End If
        Else
            Dim t As Double = 0.0
            For xloop As Integer = 0 To m_Inputs.Count - 1
                t += vals(xloop)
            Next
            v = t / m_Inputs.Count
        End If

        'update the outputs
        m_outputs(0).Value = v
        m_outputs(1).DigValue = inerror
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Average
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Avg"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Average_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
