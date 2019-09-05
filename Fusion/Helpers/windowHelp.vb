
''' <summary>
''' helper class to ease Form common tasks
''' </summary>
''' <remarks>all function are shared</remarks>
Public NotInheritable Class windowHelp

    ''' <summary>
    '''  gets the settings for the windows location and size
    ''' </summary>
    ''' <param name="window">the form to get</param>
    ''' <remarks>will readjust the location if off the screen</remarks>
    Public Shared Sub SetWinRec(window As Form, loc As Point, sz As Size)

        Dim msz As Size = window.MinimumSize

        If Not msz.IsEmpty AndAlso (msz.Width > sz.Width OrElse msz.Height > sz.Height) Then sz = msz

        Dim rec As New Rectangle(loc, sz)
        Dim s() As Screen = Screen.AllScreens
        Dim fnd As Boolean = False
        For xloop As Integer = 0 To s.Length - 1
            Dim r As Rectangle = s(xloop).Bounds
            If r.IntersectsWith(rec) Then
                If sz.Width > r.Width Then sz.Width = r.Width
                If sz.Height > r.Height Then sz.Height = r.Height
                rec.Size = sz
                If r.Contains(rec) = False Then
                    If rec.X < r.X Then loc.X = r.X
                    If rec.Y < r.Y Then loc.Y = r.Y
                    If rec.Right > r.Right Then loc.X = (r.Right - rec.Width)
                    If rec.Bottom > r.Bottom Then loc.Y = (r.Bottom - rec.Height)
                End If
                fnd = True
                Exit For
            End If
        Next

        If fnd Then
            window.Location = loc
        Else
            Dim r As Rectangle = Screen.PrimaryScreen.Bounds
            window.Location = r.Location
            If sz.Width > r.Width Then sz.Width = r.Width
            If sz.Height > r.Height Then sz.Height = r.Height
        End If
        window.Size = sz

    End Sub

End Class
