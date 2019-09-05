Public Class B_Switch_Props
    Private _item As Block_UI
    Private _bam As B_Switch
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = _item.Block
        txtUserLabel.Text = _item.Block.UserLabel
        nuOutputs.Value = _item.Block.InputConnectors.Count / 2
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.Block.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuOutputs_ValueChanged(sender As Object, e As EventArgs) Handles nuOutputs.ValueChanged
        If _loaded Then
            _bam.ChangeConnectorCount(nuOutputs.Value)
            _item.ReloadUIPoints()
        End If
    End Sub

End Class