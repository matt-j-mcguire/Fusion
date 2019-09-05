Public Class Options


    Public Sub New()
        InitializeComponent()
        txtAutoLoad.Text = My.Settings.AutoLoadFile
        chkAutoLoad.Checked = My.Settings.AutoLoad
        chkAutoRun.Checked = My.Settings.AutoStartFile
        udGridSize.Value = My.Settings.GridSize
    End Sub
   
    Private Sub btnFindFile_Click(sender As Object, e As EventArgs) Handles btnFindFile.Click
        Dim op As New OpenFileDialog
        With op
            .Filter = "DK Fusion files|*.dkfusion"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtAutoLoad.Text = .FileName
            End If
        End With
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If chkAutoLoad.Checked Then
            If Not File.Exists(txtAutoLoad.Text) Then chkAutoLoad.Checked = False
        End If
        My.Settings.AutoLoad = chkAutoLoad.Checked
        My.Settings.AutoLoadFile = txtAutoLoad.Text
        My.Settings.AutoStartFile = chkAutoRun.Checked
        My.Settings.GridSize = udGridSize.Value

        Me.Close()
    End Sub

    Public ReadOnly Property GridSize() As Integer
        Get
            Return udGridSize.Value
        End Get
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class