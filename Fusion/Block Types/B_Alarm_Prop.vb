Public Class B_Alarm_Prop

    Private _item As B_Alarm
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        txtAlarmMessage.Text = _item.Message

        Dim lst() As Block = myProject.GetBlocksByType(BlockType.AlarmManager)
        cmbManagers.Items.AddRange(lst)
        For xloop As Integer = 0 To lst.Count - 1
            If lst(xloop).UID = _item.UID Then cmbManagers.SelectedIndex = xloop
        Next

        Dim b As B_AlarmManager = cmbManagers.SelectedItem
        If b IsNot Nothing Then
            Dim selindex As Integer = -1
            For xloop As Integer = 0 To b.OutputConnectors.Count - 1
                cmbOutputs.Items.Add(b.OutputConnectors(xloop).Name)
                If b.OutputConnectors(xloop).Name = _item.DesiredOutPut Then selindex = xloop
            Next
            If selindex > -1 Then cmbOutputs.SelectedIndex = selindex
        End If

        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub txtAlarmMessage_TextChanged(sender As Object, e As EventArgs) Handles txtAlarmMessage.TextChanged
        If _loaded Then
            _item.Message = txtAlarmMessage.Text
        End If
    End Sub

    Private Sub cmbManagers_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbManagers.DrawItem
        If e.Index > -1 Then
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            Dim b As B_AlarmManager = cmbManagers.Items(e.Index)
            If b.UserLabel <> "" Then
                e.Graphics.DrawString(b.UserLabel, Me.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y)
            Else
                e.Graphics.DrawString(b.UID, Me.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y)
            End If
        End If
    End Sub

    Private Sub cmbManagers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbManagers.SelectedIndexChanged
        If _loaded Then
            cmbOutputs.Items.Clear()
            Dim b As B_AlarmManager = cmbManagers.SelectedItem
            For xloop As Integer = 0 To b.OutputConnectors.Count - 1
                cmbOutputs.Items.Add(b.OutputConnectors(xloop).Name)
            Next
            _item.JumpAM = b.UID
        End If
    End Sub

    Private Sub cmbOutputs_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbOutputs.DrawItem
        If e.Index > -1 Then
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            e.Graphics.DrawString(cmbOutputs.Items(e.Index), Me.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y)
        End If
    End Sub

    Private Sub cmbOutputs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutputs.SelectedIndexChanged
        If _loaded Then
            _item.DesiredOutPut = cmbOutputs.SelectedItem
        End If
    End Sub

End Class
