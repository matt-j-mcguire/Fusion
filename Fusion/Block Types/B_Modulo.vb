
''' <summary>
''' returns the remainder of a division
''' </summary>
''' <remarks></remarks>
Public Class B_Modulo
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Value", True, False, Me))
        m_Inputs.Add(New Connector("Modulo", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Update()
        Dim v As Double = m_Inputs(0).Value
        Dim o As Integer = v Mod CInt(m_Inputs(1).Value)

        m_outputs(0).Value = o
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Modulo
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Modulo"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Modulo_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
