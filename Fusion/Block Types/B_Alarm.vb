
Public Class B_Alarm
    Inherits Block
    Implements iBlockIOoutput


    ''' <summary>
    ''' jump address of the remote "AlarmManager" block
    ''' </summary>
    ''' <remarks></remarks>
    Public JumpAM As String
    ''' <summary>
    ''' the jump pointer
    ''' </summary>
    ''' <remarks></remarks>
    Public _AM As B_AlarmManager
    ''' <summary>
    ''' the message to show when in alarm
    ''' </summary>
    ''' <remarks></remarks>
    Public Message As String
    ''' <summary>
    ''' which output on the AlarmManager to use for alarming
    ''' </summary>
    ''' <remarks></remarks>
    Public DesiredOutPut As Integer

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        JumpAM = XHelper.Get(node, "JumpAM", "")
        Message = XHelper.Get(node, "Message", "Alarm")
        DesiredOutPut = XHelper.Get(node, "Output", 0)
        m_Inputs.Add(New Connector("i_0", True, True, Me))

    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Message", Message)
        XHelper.Set(node, "Output", DesiredOutPut)
    End Sub

    ''' <summary>
    ''' returns if in alarm or not
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InAlarm() As Boolean
        Return m_Inputs(0).DigValue
    End Function

    Public Overrides Sub Update()
        If (_AM Is Nothing Or _AM.UID <> JumpAM) AndAlso JumpAM <> "" Then
            _AM = myProject.GetBlock(JumpAM)
            If _AM IsNot Nothing Then _AM.Connect(Me)
        End If

    End Sub

    Public Sub SyncOutput() Implements iBlockIOoutput.SyncOutput
        'does nothing in this instance
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.AlarmGenerator
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Alm"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Alarm_Prop
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
