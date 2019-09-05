
''' <summary>
''' Digital Output Block
''' </summary>
''' <remarks></remarks>
Public Class B_DigitalOutput
    Inherits Block
    Implements iBlockIOoutput


    Public IOConnection As String
    Public IOp As IOPoint

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        IOConnection = XHelper.Get(node, "IOpoint", "")
        m_Inputs.Add(New Connector("o_i", True, True, Me))
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
    End Sub

    Public Sub SyncOutput() Implements iBlockIOoutput.SyncOutput
        If IOp IsNot Nothing AndAlso myProject.RunType = RunStyle.Run Then
            IOp.Digital = m_Inputs(0).DigValue
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.DigitalOutput
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_DigitalOutput_Prop
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
