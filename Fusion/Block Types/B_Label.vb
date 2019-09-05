
''' <summary>
''' only used for notes on the design screen, has no other function
''' </summary>
''' <remarks></remarks>
Public Class B_Label
    Inherits Block

    Public notes As String

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        notes = XHelper.Get(nd, "Value", "")
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Value", notes)
    End Sub

    ''' <summary>
    ''' does nothing
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Update()

    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Label
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Label_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
