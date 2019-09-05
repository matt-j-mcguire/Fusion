

Public Module IntInput


    Public Function Show(ByVal title As String, ByVal Info As String, ByVal max As Integer, ByVal min As Integer, ByVal defaultValue As Integer, Optional ByVal DefX As Integer = -1, Optional ByVal DefY As Integer = -1) As Integer
        Dim ex As New II
        With ex
            .Text = title
            .lblInfo.Text = Info
            .Max = max
            .Min = min
            .Value = defaultValue

            If DefX = -1 Then
                .Location = New Point(DefX, DefY)
            Else
                .StartPosition = FormStartPosition.CenterScreen
            End If

            If .ShowDialog = DialogResult.OK Then
                Return .Value
            Else
                Return defaultValue
            End If
        End With

    End Function


    Public Class II
        Inherits Form

#Region "designer code"


        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lblInfo = New System.Windows.Forms.Label()
            Me.udValue = New System.Windows.Forms.TextBox()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblInfo
            '
            Me.lblInfo.AutoSize = True
            Me.lblInfo.BackColor = System.Drawing.Color.Transparent
            Me.lblInfo.Location = New System.Drawing.Point(10, 23)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(25, 13)
            Me.lblInfo.TabIndex = 0
            Me.lblInfo.Text = "Info"
            '
            'udValue
            '
            Me.udValue.Location = New System.Drawing.Point(13, 39)
            Me.udValue.Name = "udValue"
            Me.udValue.Size = New System.Drawing.Size(315, 20)
            Me.udValue.TabIndex = 1
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(218, 65)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(52, 21)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "OK"
            Me.btnOK.UseVisualStyleBackColor = True
            '
            'BtnCancel
            '
            Me.BtnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.BtnCancel.ForeColor = System.Drawing.Color.Black
            Me.BtnCancel.Location = New System.Drawing.Point(276, 65)
            Me.BtnCancel.Name = "BtnCancel"
            Me.BtnCancel.Size = New System.Drawing.Size(52, 21)
            Me.BtnCancel.TabIndex = 3
            Me.BtnCancel.Text = "Cancel"
            Me.BtnCancel.UseVisualStyleBackColor = True
            '
            'II
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.BtnCancel
            Me.ClientSize = New System.Drawing.Size(340, 99)
            Me.Controls.Add(Me.BtnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.udValue)
            Me.Controls.Add(Me.lblInfo)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "II"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblInfo As System.Windows.Forms.Label
        Friend WithEvents udValue As System.Windows.Forms.TextBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents BtnCancel As System.Windows.Forms.Button

#End Region

        Private _value As Integer

        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
                'udValue.Text = value
                udValue.SelectedText = value
            End Set
        End Property

        Public Property Max() As Integer
        Public Property Min() As Integer

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            _value = CInt(udValue.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub udValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles udValue.TextChanged
            If IsNumeric(udValue.Text) = False Then
                udValue.BackColor = Color.Red
                udValue.ForeColor = Color.White
                btnOK.Enabled = False
            Else
                udValue.BackColor = Color.White
                udValue.ForeColor = Color.Black
                btnOK.Enabled = True

                Dim v As Integer = CInt(udValue.Text)
                If v > Max Then v = Max
                If v < Min Then v = Min
            End If
        End Sub

    End Class

End Module