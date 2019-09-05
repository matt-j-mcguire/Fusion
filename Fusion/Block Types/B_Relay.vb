
''' <summary>
''' Relay
''' </summary>
''' <remarks>
''' A | B | C
''' 0 | 1 | 0
''' 1 | 0 | 1
''' </remarks>
Public Class B_Relay
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("i_0", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, True, Me))
        m_outputs.Add(New Connector("o_1", False, True, Me))
    End Sub

    Public Overrides Sub Update()
        Dim b As Boolean = m_Inputs(0).DigValue
        m_outputs(0).DigValue = b
        m_outputs(0).DigValue = Not b
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Relay
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Relay"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Relay_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
