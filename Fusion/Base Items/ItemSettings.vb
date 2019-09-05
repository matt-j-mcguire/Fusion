Public Class ItemSettings
    Private _cur As BaseItemProp


    Public Sub LoadControl(item As BaseItemProp)
        If _cur IsNot Nothing Then
            Me.Controls.Remove(_cur)
            _cur.Dispose()
        End If
        _cur = item
        Me.Controls.Add(_cur)
    End Sub


End Class