
''' <summary>
''' adds or multiplies the input
''' </summary>
''' <remarks></remarks>
Public Class B_MultiDiv
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Value", True, False, Me))
        m_Inputs.Add(New Connector("Muliply", True, False, Me))
        m_Inputs.Add(New Connector("Div_Dec", True, False, Me))
        m_Inputs.Add(New Connector("Div_Int", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Update()
        Dim v As Double = m_Inputs(0).Value
        If m_Inputs(1).isUsed Then v *= m_Inputs(1).Value
        If m_Inputs(2).isUsed Then v /= m_Inputs(2).Value
        If m_Inputs(3).isUsed Then v \= m_Inputs(3).Value

        m_outputs(0).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.MultiDivisor
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Math"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_MultiDiv_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
