Public Class B_ConstantDigital_Props
    Private _item As Block_UI
    Private _bam As B_ConstantDigital
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = _item.Block
        txtUserLabel.Text = _item.Block.UserLabel
        If _bam.Value Then optOn.Checked = True Else optOff.Checked = True
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.Block.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub optOn_CheckedChanged(sender As Object, e As EventArgs) Handles optOn.CheckedChanged
        If _loaded Then
            _bam.Value = True
        End If
    End Sub

    Private Sub optOff_CheckedChanged(sender As Object, e As EventArgs) Handles optOff.CheckedChanged
        If _loaded Then
            _bam.Value = False
        End If
    End Sub

End Class