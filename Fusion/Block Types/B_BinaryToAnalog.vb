

Public Class B_BinaryToAnalog
    Inherits Block

    Public Bits As B_AnalogToBinary.AB

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Bits = XHelper.Get(node, "InCount", 8)

        For xloop As Integer = 0 To CInt(Bits) - 1
            m_Inputs.Add(New Connector("i_" & xloop, True, True, Me))
        Next
        m_outputs.Add(New Connector("o_0", False, False, Me))

    End Sub

    ''' <summary>
    ''' changes the ammount of output connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
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
        XHelper.Set(node, "InCount", CInt(Bits))
    End Sub

    Public Overrides Sub Update()
        Dim v As Long = 0

        For xloop As Integer = 0 To CInt(Bits)
            If m_Inputs(xloop).DigValue Then
                v += (1 << xloop)
            End If
        Next

        m_outputs(0).Value = v
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.BinaryToAnalog
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_BinaryToAnalog_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
