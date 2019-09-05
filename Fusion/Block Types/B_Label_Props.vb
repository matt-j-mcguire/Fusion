Public Class B_Label_Props
    Private _item As B_Label
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block

        txtUserLabel.Text = _item.notes

        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.notes = txtUserLabel.Text
        End If
    End Sub





End Class