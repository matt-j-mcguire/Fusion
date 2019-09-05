

Public Class B_AnalogInput_Prop


    Private _item As B_AnalogInput
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        nuMaxInput.Value = _item.MaxInput
        nuMinOutput.Value = _item.ScaleMin
        nuMaxoutput.Value = _item.ScaleMax
        cmbPoints.Items.AddRange(myProject.IO.GetIOPOintConnectionStrings(True, True))

        Dim indx As Integer = cmbPoints.Items.IndexOf(_item.IOConnection)
        cmbPoints.SelectedIndex = indx


        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuMaxInput_ValueChanged(sender As Object, e As EventArgs) Handles nuMaxInput.ValueChanged
        If _loaded Then
            _item.MaxInput = nuMaxInput.Value
        End If
    End Sub

    Private Sub nuMinOutput_ValueChanged(sender As Object, e As EventArgs) Handles nuMinOutput.ValueChanged
        If _loaded Then
            _item.ScaleMin = nuMinOutput.Value
        End If
    End Sub

    Private Sub nuMaxoutput_ValueChanged(sender As Object, e As EventArgs) Handles nuMaxoutput.ValueChanged
        If _loaded Then
            _item.ScaleMax = nuMaxoutput.Value
        End If
    End Sub

    Private Sub cmbPoints_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPoints.SelectedIndexChanged
        If _loaded Then
            Dim v As String = cmbPoints.SelectedItem
            _item.ChangeExistingIOPoint(v)
        End If
    End Sub

End Class
