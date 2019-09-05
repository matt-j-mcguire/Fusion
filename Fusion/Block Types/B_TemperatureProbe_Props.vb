Public Class B_TemperatureProbe_Props
    Private _item As B_TemperatureProbe
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel

        cmbPoints.Items.AddRange(myProject.IO.GetIOPOintConnectionStrings(True, False))
        Dim indx As Integer = cmbPoints.Items.IndexOf(_item.IOConnection)
        cmbPoints.SelectedIndex = indx

        cmbProbeType.SelectedIndex = _item.ProbeType
        nuOffset.Value = _item.Offset
        nuLinierHi.Value = _item.LinierHi
        nuLinierLow.Value = _item.LinierLo

        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbPoints_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPoints.SelectedIndexChanged
        If _loaded Then
            Dim v As String = cmbPoints.SelectedItem
            _item.ChangeExistingIOPoint(v)
        End If
    End Sub

    Private Sub cmbProbeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProbeType.SelectedIndexChanged
        If _loaded Then
            _item.ProbeType = cmbProbeType.SelectedIndex
        End If
    End Sub

    Private Sub nuOffset_ValueChanged(sender As Object, e As EventArgs) Handles nuOffset.ValueChanged
        If _loaded Then
            _item.Offset = nuOffset.Value
        End If
    End Sub

    Private Sub nuLinierHi_ValueChanged(sender As Object, e As EventArgs) Handles nuLinierHi.ValueChanged
        If _loaded Then
            _item.LinierHi = nuLinierHi.Value
        End If
    End Sub

    Private Sub nuLinierLow_ValueChanged(sender As Object, e As EventArgs) Handles nuLinierLow.ValueChanged
        If _loaded Then
            _item.LinierLo = nuLinierLow.Value
        End If
    End Sub

End Class