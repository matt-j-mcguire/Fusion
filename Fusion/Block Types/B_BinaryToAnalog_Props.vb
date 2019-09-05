

Public Class B_BinaryToAnalog_Props


    Private _item As B_BinaryToAnalog
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel

        cmbSize.Items.AddRange({4, 8, 16, 24, 32, 48, 64})

        Dim indx As Integer = cmbSize.Items.IndexOf(_item.InputConnectors.Length)
        cmbSize.SelectedIndex = indx

        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbPoints_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSize.SelectedIndexChanged
        If _loaded Then
            _item.ChangeConnectorCount(CInt(cmbSize.SelectedItem))
            DirectCast(_item.GetUI, Block_UI).ReloadUIPoints()
        End If
    End Sub

End Class
