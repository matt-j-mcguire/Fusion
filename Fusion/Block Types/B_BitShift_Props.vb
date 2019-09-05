Public Class B_BitShift_Props
    Private _item As B_BitShift
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        If _item.direction = B_BitShift.Shift.Left Then cmbShift.SelectedIndex = 0 Else cmbShift.SelectedIndex = 1
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbShift.SelectedIndexChanged
        If _loaded Then
            If cmbShift.SelectedIndex = 0 Then _item.direction = B_BitShift.Shift.Left Else _item.direction = B_BitShift.Shift.Right
        End If
    End Sub

End Class