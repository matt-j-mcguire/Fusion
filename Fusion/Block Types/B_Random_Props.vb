Public Class B_Random_Props
    Private _item As B_Random
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        nuMin.Value = _item.Min
        nuMax.Value = _item.Max
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuMin_ValueChanged(sender As Object, e As EventArgs) Handles nuMin.ValueChanged
        If _loaded Then
            _item.Min = nuMin.Value
        End If
    End Sub

    Private Sub nuMax_ValueChanged(sender As Object, e As EventArgs) Handles nuMax.ValueChanged
        If _loaded Then
            _item.Max = nuMax.Value
        End If
    End Sub


End Class