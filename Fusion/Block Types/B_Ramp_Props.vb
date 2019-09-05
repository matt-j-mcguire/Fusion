Public Class B_Ramp_Props
    Private _item As B_Ramp
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

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles nuMin.ValueChanged
        If _loaded Then
            _item.Min = nuMin.Value
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles nuMax.ValueChanged
        If _loaded Then
            _item.Max = nuMax.Value
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles nuStep.ValueChanged
        If _loaded Then
            _item.Step = nuStep.Value
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkReset.CheckedChanged
        If _loaded Then
            _item.ResetsOnMax = chkReset.Checked
        End If
    End Sub

End Class