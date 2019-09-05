
''' <summary>
''' a schedule of time periods
''' </summary>
''' <remarks></remarks>
Public Class B_SettingTimeSchedule
    Inherits Block


    Public Enum TimeType
        ''' <summary>
        ''' time is stored in minutes since midnight
        ''' </summary>
        ''' <remarks></remarks>
        Twenty_Four_Hour = 0
        ''' <summary>
        ''' time is stored 0-6 (7 days a week)
        ''' </summary>
        ''' <remarks></remarks>
        Day_Of_Week = 1
        ''' <summary>
        ''' time is stored 1-31 (days of the month)
        ''' </summary>
        ''' <remarks></remarks>
        Day_Of_Month = 2
        ''' <summary>
        ''' Time is Stored 1-365 days of the year
        ''' </summary>
        ''' <remarks></remarks>
        Day_Of_Year = 3
    End Enum

    Public TimeAction As TimeType
    Public Times As List(Of Integer)


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        Times = New List(Of Integer)

        TimeAction = XHelper.Get(node, "Action", 0)
        Dim cnt As Integer = XHelper.Get(node, "Count", 0)
        For xloop As Integer = 0 To cnt - 1
            Dim t As Integer = XHelper.Get(node, "Time" & xloop, 1)
            Times.Add(t)
        Next

        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Action", CInt(TimeAction))
        XHelper.Set(node, "Count", Times.Count)
        For xloop As Integer = 0 To Times.Count - 1
            XHelper.Set(node, "Time" & xloop, Times(xloop))
        Next
    End Sub

    Public Overrides Sub Update()
        Dim isOn As Boolean = False
        Select Case TimeAction
            Case TimeType.Twenty_Four_Hour
                For xloop As Integer = 0 To Times.Count - 1
                    Dim t As TimeSpan = Now.TimeOfDay()
                    Dim v As Integer = (t.Hours * 60) + t.Minutes
                    If v = Times(xloop) Then isOn = True
                Next
            Case TimeType.Day_Of_Week
                For xloop As Integer = 0 To Times.Count - 1
                    If CInt(Now.DayOfWeek) = Times(xloop) Then isOn = True
                Next
            Case TimeType.Day_Of_Month
                For xloop As Integer = 0 To Times.Count - 1
                    If Now.Day = Times(xloop) Then isOn = True
                Next
            Case TimeType.Day_Of_Year
                For xloop As Integer = 0 To Times.Count - 1
                    If Now.DayOfYear = Times(xloop) Then isOn = True
                Next
        End Select

        m_outputs(0).DigValue = isOn
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.SettingT
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Sett ☼"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_SettingTimeSchedule_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
