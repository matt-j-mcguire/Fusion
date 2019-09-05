Public Class B_PID_Props
    Private _item As B_PID
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        nuReset.Value = _item.Reset
        nuGain.Value = _item.Gain
        nuDGain.Value = _item.DerivativeGain
        nuMin.Value = _item.Minimum
        nuMax.Value = _item.Maximum
        nuChange.Value = _item.MaxChange
        nuWait.Value = _item.WaitTime
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuReset_ValueChanged(sender As Object, e As EventArgs) Handles nuReset.ValueChanged
        If _loaded Then
            _item.Reset = nuReset.Value
        End If
    End Sub

    Private Sub nuGain_ValueChanged(sender As Object, e As EventArgs) Handles nuGain.ValueChanged
        If _loaded Then
            _item.Gain = nuGain.Value
        End If
    End Sub

    Private Sub nuDGain_ValueChanged(sender As Object, e As EventArgs) Handles nuDGain.ValueChanged
        If _loaded Then
            _item.DerivativeGain = nuDGain.Value
        End If
    End Sub

    Private Sub nuMin_ValueChanged(sender As Object, e As EventArgs) Handles nuMin.ValueChanged
        If _loaded Then
            _item.Minimum = nuMin.Value
        End If
    End Sub

    Private Sub nuMax_ValueChanged(sender As Object, e As EventArgs) Handles nuMax.ValueChanged
        If _loaded Then
            _item.Maximum = nuMax.Value
        End If
    End Sub

    Private Sub nuChange_ValueChanged(sender As Object, e As EventArgs) Handles nuChange.ValueChanged
        If _loaded Then
            _item.MaxChange = nuChange.Value
        End If
    End Sub

    Private Sub nuWait_ValueChanged(sender As Object, e As EventArgs) Handles nuWait.ValueChanged
        If _loaded Then
            _item.WaitTime = nuWait.Value
        End If
    End Sub

End Class