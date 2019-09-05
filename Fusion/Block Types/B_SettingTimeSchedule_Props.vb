Public Class B_SettingTimeSchedule_Props
    Private _item As B_SettingTimeSchedule
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        cmbType.SelectedIndex = _item.TimeAction
        For xloop As Integer = 0 To _item.Times.Count - 1
            lbDates.Items.Add(_item.Times(xloop))
        Next
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If _loaded Then
            _item.TimeAction = cmbType.SelectedIndex
            _item.Times.Clear()
            lbDates.Items.Clear()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ex As New B_SettingTimeScheduleTimeAdd(_item.TimeAction)
        If ex.ShowDialog(Me) = DialogResult.OK Then
            lbDates.Items.Add(ex.SelectValue)
            _item.Times.Add(ex.SelectValue)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lbDates.SelectedIndex > -1 Then
            Dim index As Integer = lbDates.SelectedIndex
            lbDates.Items.RemoveAt(index)
            _item.Times.RemoveAt(index)
        End If
    End Sub

    Private Sub lbDates_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lbDates.DrawItem
        If e.Index > -1 Then
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            Dim v As Integer = CInt(lbDates.SelectedItem)
            Select Case _item.TimeAction
                Case B_SettingTimeSchedule.TimeType.Twenty_Four_Hour
                    Dim t As New Date(Now.Year, Now.Month, Now.Day, v \ 60, v Mod 60, 0, 0)
                    e.Graphics.DrawString(t.ToString("h:mm tt"), Me.Font, Brushes.Black, e.Bounds.Location)
                Case B_SettingTimeSchedule.TimeType.Day_Of_Week
                    Dim t As DayOfWeek = v
                    e.Graphics.DrawString(t.ToString, Me.Font, Brushes.Black, e.Bounds.Location)
                Case B_SettingTimeSchedule.TimeType.Day_Of_Month
                    e.Graphics.DrawString(v.ToString, Me.Font, Brushes.Black, e.Bounds.Location)
                Case B_SettingTimeSchedule.TimeType.Day_Of_Year
                    Dim t As New Date(Now.Year, 1, 1)
                    t = t.AddMinutes(v - 1)
                    e.Graphics.DrawString(t.ToString("MMMM dd"), Me.Font, Brushes.Black, e.Bounds.Location)
            End Select
        End If
    End Sub


End Class