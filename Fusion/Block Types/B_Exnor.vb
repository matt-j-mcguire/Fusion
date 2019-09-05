
''' <summary>
''' Exnor Gate
''' </summary>
''' <remarks>
''' A | B | C
''' 0 | 0 | 1
''' 1 | 0 | 0
''' 0 | 1 | 0
''' 1 | 1 | 1
''' </remarks>
Public Class B_Exnor
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("i_0", True, True, Me))
        m_Inputs.Add(New Connector("i_1", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub


    Public Overrides Sub Update()
        Dim b As Boolean = False
        If m_Inputs(0).DigValue = m_Inputs(1).DigValue Then b = True
        m_outputs(0).DigValue = b
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Exnor
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Exnor"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Exnor_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
