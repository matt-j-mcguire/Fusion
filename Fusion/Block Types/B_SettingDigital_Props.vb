Public Class B_SettingDigital_Props
    Private _item As B_SettingDigital
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel

        _loaded = True
    End Sub


    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub


    Private Sub txtText_TextChanged(sender As Object, e As EventArgs) Handles txtText.TextChanged
        If _loaded Then
            _item.SettingText = txtText.Text
        End If
    End Sub

    Private Sub chkValue_CheckedChanged(sender As Object, e As EventArgs) Handles chkValue.CheckedChanged
        If _loaded Then
            _item.Value = chkValue.Checked
        End If
    End Sub

End Class