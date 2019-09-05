Public Class ChangePageSize

    Public Property theSize() As Size
        Get
            Return New Size(nuWidth.Value, nuHeight.Value)
        End Get
        Set(value As Size)
            nuWidth.Value = value.Width
            nuHeight.Value = value.Height
        End Set
    End Property

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnCancel.Click
        Me.Close()
    End Sub
End Class