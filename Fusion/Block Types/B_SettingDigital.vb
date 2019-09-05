
''' <summary>
''' Simple on/off setting
''' </summary>
''' <remarks></remarks>
Public Class B_SettingDigital
    Inherits Block

    Public Value As Boolean
    Public SettingText As String

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        Value = XHelper.Get(node, "Value", False)
        SettingText = XHelper.Get(node, "Text", Me.UserLabel)
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Value", Value)
        XHelper.Set(node, "Text", SettingText)
    End Sub

    Public Overrides Sub Update()
        m_outputs(0).DigValue = Value
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.SettingD
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Sett D"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SettingDigital_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
