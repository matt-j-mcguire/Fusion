Public Class Page_Props


    Private _pro As Page

    Public Sub New(owner As Page)

        InitializeComponent()
        _pro = owner
        txtName.Text = owner.Name

    End Sub


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        _pro.Name = txtName.Text
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class