Public Class Wire_UI_Props
    Private _item As Wire_UI
    Private _loaded As Boolean

    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item

        udSize.Value = _item.Wire_style.Size
        Select Case _item.Wire_style.style
            Case DashStyle.Solid
                cmbStyle.SelectedIndex = 0
            Case DashStyle.Dash
                cmbStyle.SelectedIndex = 1
            Case DashStyle.DashDot
                cmbStyle.SelectedIndex = 2
            Case DashStyle.DashDotDot
                cmbStyle.SelectedIndex = 3
            Case DashStyle.Dot
                cmbStyle.SelectedIndex = 4
        End Select

        Dim index As Integer = 0
        For xloop As Integer = 0 To WireColor.Count - 1
            Dim c As WireColor = New WireColor(xloop)
            cmbColor.Items.Add(c)
            If c = _item.Wire_style.Color Then index = xloop
        Next
        cmbColor.SelectedIndex = index

        _loaded = True
    End Sub

    Private Sub cmbStyle_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbStyle.DrawItem
        If e.Index > -1 Then
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            Select Case e.Index
                Case 0 'solid
                    e.Graphics.DrawImage(My.Resources.line_solid, e.Bounds.X, e.Bounds.Y)
                Case 1 ' dashes
                    e.Graphics.DrawImage(My.Resources.line_Dashes, e.Bounds.X, e.Bounds.Y)
                Case 2 'Dash Dot Dash
                    e.Graphics.DrawImage(My.Resources.line_DashdotDash, e.Bounds.X, e.Bounds.Y)
                Case 3 'Dash Dot Dot
                    e.Graphics.DrawImage(My.Resources.line_Dashdotdot, e.Bounds.X, e.Bounds.Y)
                Case 4 'Dots
                    e.Graphics.DrawImage(My.Resources.line_Dots, e.Bounds.X, e.Bounds.Y)
            End Select
        End If
    End Sub

    Private Sub cmbStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStyle.SelectedIndexChanged
        If _loaded = True Then
            Select Case cmbStyle.SelectedIndex
                Case 0
                    _item.Wire_style.style = DashStyle.Solid
                Case 1
                    _item.Wire_style.style = DashStyle.Dash
                Case 2
                    _item.Wire_style.style = DashStyle.DashDot
                Case 3
                    _item.Wire_style.style = DashStyle.DashDotDot
                Case 4
                    _item.Wire_style.style = DashStyle.Dot
            End Select
        End If
    End Sub

    Private Sub cmbColor_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbColor.DrawItem
        If e.Index > -1 Then
            Dim c As WireColor = cmbColor.Items(e.Index)
            e.Graphics.DrawImage(c.ColorIcon, e.Bounds.X, e.Bounds.Y)
            e.Graphics.DrawString(c.FriendlyName, cmbColor.Font, Brushes.Black, New Point(e.Bounds.X + 20, e.Bounds.Y + 2))
        End If
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedIndexChanged
        If _loaded = True Then
            _item.Wire_style.Color = cmbColor.SelectedItem
        End If
    End Sub

    Private Sub udSize_ValueChanged(sender As Object, e As EventArgs) Handles udSize.ValueChanged
        If _loaded Then
            _item.Wire_style.Size = udSize.Value
        End If
    End Sub

End Class