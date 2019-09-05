Public Class B_JumpTo_Props
    Private _item As B_JumpTo
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel

        Dim lst() As Block = myProject.GetBlocksByType(BlockType.AlarmManager)
        cmbManagers.Items.AddRange(lst)
        For xloop As Integer = 0 To lst.Count - 1
            If lst(xloop).UID = _item.UID Then cmbManagers.SelectedIndex = xloop
        Next

        _loaded = True
    End Sub


    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbManagers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbManagers.SelectedIndexChanged
        If _loaded Then

            Dim b As B_JumpFrom = cmbManagers.SelectedItem
          
            _item.Jump = b.UID
        End If
    End Sub


End Class