
''' <summary>
''' shows a temporary push to do something
''' </summary>
''' <remarks></remarks>
Public Class B_SettingCommand
    Inherits Block

    Public Value As Boolean
    Public SettingText As String


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        SettingText = XHelper.Get(node, "Text", Me.UserLabel)
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub save()
        XHelper.Set(node, "Text", SettingText)
    End Sub

    Public Overrides Sub Update()
        If Value Then
            If m_outputs(0).DigValue Then
                Value = False
                m_outputs(0).DigValue = False
            Else
                m_outputs(0).DigValue = True
            End If
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.SettingC
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Sett #"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SettingCommand_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
