
''' <summary>
''' manages for incomming alarms
''' </summary>
''' <remarks></remarks>
Public Class B_AlarmManager
    Inherits Block

    Private _Cons As List(Of B_Alarm)
    Private _messages() As String


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        _Cons = New List(Of B_Alarm)

        Dim cnt As Integer = XHelper.Get(node, "Count", 2)
        For xloop As Integer = 0 To cnt - 1
            m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
        Next

    End Sub

    ''' <summary>
    ''' changes the ammount of output connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        If cnt > m_outputs.Count Then
            For xloop As Integer = m_outputs.Count To cnt - 1
                m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
            Next
        Else
            For xloop As Integer = cnt To m_outputs.Count - 1 Step -1
                If m_outputs(xloop).isUsed Then m_outputs(xloop).Disconnect()
                m_outputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Count", m_outputs.Count)
    End Sub

    Public Sub Connect(item As B_Alarm)
        _Cons.Add(item)
    End Sub

    Public Function GetAllMessages() As String()
        Return _messages
    End Function

    Public Overrides Sub Update()
        Dim outs(m_outputs.Count - 1) As Boolean
        Dim msg As New List(Of String)
        For xloop As Integer = 0 To _Cons.Count - 1
            If _Cons(xloop).InAlarm Then
                If _Cons(xloop).DesiredOutPut > outs.Length Then outs(_Cons(xloop).DesiredOutPut) = True
                msg.Add(_Cons(xloop).Message)
            End If
        Next
        _messages = msg.ToArray

        'update the outputs
        For xloop As Integer = 0 To m_outputs.Count - 1
            m_outputs(xloop).DigValue = outs(xloop)
        Next
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.AlarmManager
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Alm Mgr."
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_AlarmManager_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
