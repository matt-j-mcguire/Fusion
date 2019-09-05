
''' <summary>
''' simple numeric setting
''' </summary>
''' <remarks></remarks>
Public Class B_SettingAnalog
    Inherits Block

    Public Value As Double
    Public isFloat As Boolean
    Public SettingText As String
    Public SettingMax As Double
    Public SettingMin As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        Value = XHelper.Get(node, "Value", 0.0)
        isFloat = XHelper.Get(node, "isFloat", False)
        SettingText = XHelper.Get(node, "Text", Me.UserLabel)
        SettingMax = XHelper.Get(node, "Max", 100.0)
        SettingMin = XHelper.Get(node, "Min", 0.0)
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Value", Value)
        XHelper.Set(node, "isFloat", isFloat)
        XHelper.Set(node, "Text", SettingText)
        XHelper.Set(node, "Max", SettingMax)
        XHelper.Set(node, "Min", SettingMin)
    End Sub

    Public Overrides Sub Update()
        m_outputs(0).Value = Value
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.SettingA
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Sett ~"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SettingAnalog_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
