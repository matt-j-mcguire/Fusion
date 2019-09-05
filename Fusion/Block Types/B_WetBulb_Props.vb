Public Class B_WetBulb_Props
    Private _item As B_WetBulb
    Private _loaded As Boolean



    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        nuApproach.Value = _item.ApproachAdd
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuApproach_ValueChanged(sender As Object, e As EventArgs) Handles nuApproach.ValueChanged
        If _loaded Then
            _item.ApproachAdd = nuApproach.Value
        End If
    End Sub

End Class