Public Class B_Timer_Props
    Private _item As Block_UI
    Private _loaded As Boolean


    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.Block.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        txtUserLabel.Text = _item.Block.UserLabel

        _loaded = True
    End Sub



End Class