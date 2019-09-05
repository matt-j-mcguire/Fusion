Public Class B_Scale_Props
    Private _item As B_Scale
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        nuMinDev.Value = _item.MinDiv
        nuMaxDev.Value = _item.MaxDiv
        nuMinOut.Value = _item.MinOut
        nuMaxOut.Value = _item.MaxOut
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuMinDev_ValueChanged(sender As Object, e As EventArgs) Handles nuMinDev.ValueChanged
        If _loaded Then
            _item.MinDiv = nuMinDev.Value
        End If
    End Sub

    Private Sub nuMaxDev_ValueChanged(sender As Object, e As EventArgs) Handles nuMaxDev.ValueChanged
        If _loaded Then
            _item.MaxDiv = nuMaxDev.Value
        End If
    End Sub

    Private Sub nuMinOut_ValueChanged(sender As Object, e As EventArgs) Handles nuMinOut.ValueChanged
        If _loaded Then
            _item.MinOut = nuMinOut.Value
        End If
    End Sub

    Private Sub nuMaxOut_ValueChanged(sender As Object, e As EventArgs) Handles nuMaxOut.ValueChanged
        If _loaded Then
            _item.MaxOut = nuMaxOut.Value
        End If
    End Sub

End Class