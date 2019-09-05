
''' <summary>
''' digital input block
''' </summary>
''' <remarks></remarks>
Public Class B_DigitalInput
    Inherits Block

    Public IOConnection As String
    Public IOp As IOPoint

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        IOConnection = XHelper.Get(node, "IOpoint", "")
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Sub ChangeExistingIOPoint(newConnetion As String)
        IOConnection = newConnetion
        IOp = Nothing
        'next call to update will re-establish the connecton
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "IOpoint", IOConnection)
    End Sub

    Public Overrides Sub Update()
        If IOp Is Nothing AndAlso Not String.IsNullOrEmpty(IOConnection) Then
            IOp = myProject.IO.GetIOPoint(IOConnection)
        End If

        If IOp IsNot Nothing AndAlso myProject.RunType = RunStyle.Run Then
            m_outputs(0).DigValue = IOp.Digital
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.DigitalInput
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_DigitalInput_Prop
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
