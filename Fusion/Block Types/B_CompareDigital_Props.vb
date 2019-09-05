Public Class B_CompareDigital_Props
    Private _item As B_CompareDigital
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _item.UserLabel
        Select Case _item.Compare
            Case B_CompareDigital.CompareType.Equal
                cmbcompare.SelectedIndex = 0
            Case B_CompareDigital.CompareType.EqualGreater
                cmbcompare.SelectedIndex = 1
            Case B_CompareDigital.CompareType.EqualLess
                cmbcompare.SelectedIndex = 2
            Case B_CompareDigital.CompareType.Greater
                cmbcompare.SelectedIndex = 3
            Case B_CompareDigital.CompareType.Less
                cmbcompare.SelectedIndex = 4
        End Select
        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub cmbShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcompare.SelectedIndexChanged
        If _loaded Then
            Select Case cmbcompare.SelectedIndex
                Case 0
                    _item.Compare = B_CompareDigital.CompareType.Equal
                Case 1
                    _item.Compare = B_CompareDigital.CompareType.EqualGreater
                Case 2
                    _item.Compare = B_CompareDigital.CompareType.EqualLess
                Case 3
                    _item.Compare = B_CompareDigital.CompareType.Greater
                Case 4
                    _item.Compare = B_CompareDigital.CompareType.Less
            End Select
        End If
    End Sub

End Class