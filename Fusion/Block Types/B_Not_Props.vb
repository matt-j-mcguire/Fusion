Public Class B_Not_Props
    Private _item As Block_UI
    Private _bam As B_Not
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = _item.Block
        txtUserLabel.Text = _item.Block.UserLabel
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.Block.UserLabel = txtUserLabel.Text
        End If
    End Sub

End Class