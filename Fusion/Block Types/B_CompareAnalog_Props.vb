Public Class B_CompareAnalog_Props
    Private _item As B_CompareAnalog
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        If _item.Compare = B_CompareAnalog.CompareType.Greater Then cmbcompare.SelectedIndex = 0 Else cmbcompare.SelectedIndex = 1
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcompare.SelectedIndexChanged
        If _loaded Then
            If cmbcompare.SelectedIndex = 0 Then _item.Compare = B_CompareAnalog.CompareType.Greater Else _item.Compare = B_CompareAnalog.CompareType.Less
        End If
    End Sub

End Class