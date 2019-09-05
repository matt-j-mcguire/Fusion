Public Class B_SettingAnalog_Props
    Private _item As B_SettingAnalog
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        txtText.Text = _item.SettingText
        nuValue.Value = _item.Value
        chkFloat.Checked = _item.isFloat
        nuMax.Value = _item.SettingMax
        nuMin.Value = _item.SettingMin
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

    Private Sub nuValue_ValueChanged(sender As Object, e As EventArgs) Handles nuValue.ValueChanged
        If _loaded Then
            If nuValue.Value > nuMax.Value Then nuValue.Value = nuMax.Value
            If nuValue.Value < nuMin.Value Then nuValue.Value = nuMin.Value
            _item.Value = nuValue.Value
        End If
    End Sub

    Private Sub chkFloat_CheckedChanged(sender As Object, e As EventArgs) Handles chkFloat.CheckedChanged
        If chkFloat.Checked Then
            nuValue.DecimalPlaces = 1
            nuMax.DecimalPlaces = 1
            nuMin.DecimalPlaces = 1
        Else
            nuValue.DecimalPlaces = 0
            nuMax.DecimalPlaces = 0
            nuMin.DecimalPlaces = 0
        End If
        If _loaded Then
            _item.isFloat = chkFloat.Checked
        End If
    End Sub

    Private Sub nuMax_ValueChanged(sender As Object, e As EventArgs) Handles nuMax.ValueChanged
        If _loaded Then
            _item.SettingMax = nuMax.Value
            nuValue_ValueChanged(sender, e)
        End If
    End Sub

    Private Sub nuMin_ValueChanged(sender As Object, e As EventArgs) Handles nuMin.ValueChanged
        If _loaded Then
            _item.SettingMin = nuMin.Value
            nuValue_ValueChanged(sender, e)
        End If
    End Sub
End Class