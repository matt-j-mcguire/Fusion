

Public Class B_AnalogOutPut_Prop


    Private _item As B_AnalogOutput
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        cmbPoints.Items.AddRange(myProject.IO.GetIOPOintConnectionStrings(True, False))

        Dim indx As Integer = cmbPoints.Items.IndexOf(_item.IOConnection)
        cmbPoints.SelectedIndex = indx

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

End Class
