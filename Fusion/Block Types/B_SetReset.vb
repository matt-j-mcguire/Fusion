
''' <summary>
''' once set, holds the value until reset is applied
''' </summary>
''' <remarks></remarks>
Public Class B_SetReset
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Set", True, True, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Update()
        If m_Inputs(0).DigValue Then m_outputs(0).DigValue = True
        If m_Inputs(1).DigValue Then m_outputs(0).DigValue = False
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.SetReset
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Latch"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SetReset_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
