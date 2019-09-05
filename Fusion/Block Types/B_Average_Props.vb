Public Class B_Average_Props
    Private _item As Block_UI
    Private _bam As B_Average
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = _item.Block
        txtUserLabel.Text = _bam.UserLabel
        nuOutputs.Value = _bam.InputConnectors.Count
        nuHighError.Value = _bam.HighInputError
        nuLowError.Value = _bam.LowInputError
        chkUseWeights.Checked = _bam.UseWeights
        txtWeights.Text = String.Join(",", _bam.Weights)

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

    Private Sub nuHighError_ValueChanged(sender As Object, e As EventArgs) Handles nuHighError.ValueChanged
        If _loaded Then
            _bam.HighInputError = nuHighError.Value
        End If
    End Sub

    Private Sub nuLowError_ValueChanged(sender As Object, e As EventArgs) Handles nuLowError.ValueChanged
        If _loaded Then
            _bam.LowInputError = nuLowError.Value
        End If
    End Sub

    Private Sub chkUseWeights_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseWeights.CheckedChanged
        If _loaded Then
            _bam.UseWeights = chkUseWeights.Checked
        End If
    End Sub

    ''' <summary>
    ''' for filtering out bad key strokes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtWeights_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeights.KeyPress
        Dim valid As String = ",0123456789"
        If Not valid.Contains(e.KeyChar) Then
            e.Handled = False
            e.KeyChar = ControlChars.NullChar
        End If
    End Sub

    Private Sub txtWeights_TextChanged(sender As Object, e As EventArgs) Handles txtWeights.TextChanged
        If _loaded Then
            Dim v() As String = txtWeights.Text.Split(",")
            ReDim Preserve v(nuOutputs.Value - 1)
            For xloop As Integer = 0 To v.Length - 1
                If String.IsNullOrEmpty(v(xloop)) Then v(xloop) = "0"
                _bam.Weights(xloop) = CInt(v(xloop))
            Next
        End If
    End Sub

End Class