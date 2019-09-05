Public Class B_SettingTimeScheduleTimeAdd

    Private _sts As B_SettingTimeSchedule.TimeType

    Public Sub New(schtype As B_SettingTimeSchedule.TimeType)
        InitializeComponent()
        dt.Value = Now
        _sts = schtype
        Select Case schtype
            Case B_SettingTimeSchedule.TimeType.Twenty_Four_Hour
                dt.CustomFormat = "h:mm tt"
                dt.ShowUpDown = True
            Case B_SettingTimeSchedule.TimeType.Day_Of_Week
                dt.CustomFormat = "dddd"
                dt.ShowUpDown = True
            Case B_SettingTimeSchedule.TimeType.Day_Of_Month
                dt.CustomFormat = "d"
                dt.ShowUpDown = True
            Case B_SettingTimeSchedule.TimeType.Day_Of_Year
                dt.CustomFormat = "MMMM d"
                dt.ShowUpDown = False
        End Select
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnCancel.Click
        Me.Close()
    End Sub

    Public ReadOnly Property SelectValue() As Integer
        Get
            Dim ret As Integer = 0
            Select Case _sts
                Case B_SettingTimeSchedule.TimeType.Twenty_Four_Hour
                    ret = dt.Value.Hour * 60 + dt.Value.Minute
                Case B_SettingTimeSchedule.TimeType.Day_Of_Week
                    ret = dt.Value.DayOfWeek
                Case B_SettingTimeSchedule.TimeType.Day_Of_Month
                    ret = dt.Value.Day
                Case B_SettingTimeSchedule.TimeType.Day_Of_Year
                    ret = dt.Value.DayOfYear
            End Select
            Return ret
        End Get
    End Property

End Class