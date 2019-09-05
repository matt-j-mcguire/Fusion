

''' <summary>
''' always has a constant output value (on or off)
''' </summary>
''' <remarks></remarks>
Public Class B_ConstantDigital
    Inherits Block

    Public Value As Boolean

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        XHelper.Get(node, "Value", False)
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Value", Value)
    End Sub

    Public Overrides Sub Update()
        m_outputs(0).DigValue = Value
    End Sub


    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.ConstantD
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "C=" & If(Value, "1", "0")
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_ConstantDigital_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
