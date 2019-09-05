

Public Class B_Not
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        m_Inputs.Add(New Connector("i_0", True, True, Me))
        m_outputs.Add(New Connector("o_1", False, True, Me))
    End Sub

    Public Overrides Sub Update()
        m_outputs(0).DigValue = Not m_Inputs(0).DigValue
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Not
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Not"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Not_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
