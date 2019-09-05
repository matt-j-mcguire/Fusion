

''' <summary>
''' always has a constant output value (floating point number)
''' </summary>
''' <remarks></remarks>
Public Class B_ConstantAnalog
    Inherits Block

    Public Value As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        XHelper.Get(node, "Value", 0.0)
        m_outputs.Add(New Connector("o_0", False, False, Me))
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
            Return Fusion.BlockType.ConstantA
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "C=" & Value
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_ConstantDigital_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
