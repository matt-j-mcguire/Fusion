Public Class B_timedSequence_Interval

    Private _value As Integer

    Public Sub New(initValue As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        _value = initValue
        ' Add any initialization after the InitializeComponent() call.
        txtInterval.Text = initValue \ 60 & ":" & initValue Mod 60
    End Sub

    Private Sub TxtInterval_TextChanged(sender As Object, e As EventArgs) Handles txtInterval.TextChanged

    End Sub

    Public ReadOnly Property Value() As Integer
        Get
            Return _value
        End Get
    End Property

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim m As Match = Regex.Match(txtInterval.Text, "(\d+):(\d+)")
        If m.Success Then
            _value = CInt(m.Groups(1).Value) * 60 + CInt(m.Groups(2).Value)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Inputted format is not in the correct format", "Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class