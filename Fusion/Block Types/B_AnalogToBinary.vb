
''' <summary>
''' converts a integer to a 4,8,16,32,64 bit conversion
''' </summary>
''' <remarks></remarks>
Public Class B_AnalogToBinary
    Inherits Block

    Public Enum AB
        Bits_4 = 4
        Bits_8 = 8
        Bits_16 = 16
        Bits_24 = 24
        Bits_32 = 32
        Bits_48 = 48
        Bits_64 = 64
    End Enum

    Public Bits As AB

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Bits = XHelper.Get(node, "OutCount", 8)

        m_Inputs.Add(New Connector("i_0", True, False, Me))
        For xloop As Integer = 0 To CInt(Bits) - 1
            m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
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
            For xloop As Integer = m_outputs.Count - 1 To cnt Step -1
                If m_outputs(xloop).isUsed Then m_outputs(xloop).Disconnect()
                m_outputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "OutCount", CInt(Bits))
    End Sub

    Public Overrides Sub Update()
        Dim v As Long = CLng(m_Inputs(0).Value)
        For xloop As Integer = 0 To CInt(Bits)
            m_outputs(xloop).DigValue = (v And (1 << xloop))
        Next
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.AnalogToBinary
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_AnalogToBinary_Props
        ex.LoadItem(Me.GetUI)
        Return ex
    End Function

End Class
