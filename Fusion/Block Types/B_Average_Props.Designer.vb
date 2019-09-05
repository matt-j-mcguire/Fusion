<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Average_Props
    Inherits BaseItemProp

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
        Me.lblUserLabel = New System.Windows.Forms.Label()
        Me.txtUserLabel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nuOutputs = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuHighError = New System.Windows.Forms.NumericUpDown()
        Me.nuLowError = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkUseWeights = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtWeights = New System.Windows.Forms.TextBox()
        CType(Me.nuOutputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuHighError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuLowError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUserLabel
        '
        Me.lblUserLabel.AutoSize = True
        Me.lblUserLabel.Location = New System.Drawing.Point(13, 13)
        Me.lblUserLabel.Name = "lblUserLabel"
        Me.lblUserLabel.Size = New System.Drawing.Size(58, 13)
        Me.lblUserLabel.TabIndex = 0
        Me.lblUserLabel.Text = "User Label"
        '
        'txtUserLabel
        '
        Me.txtUserLabel.Location = New System.Drawing.Point(16, 30)
        Me.txtUserLabel.Name = "txtUserLabel"
        Me.txtUserLabel.Size = New System.Drawing.Size(172, 20)
        Me.txtUserLabel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Input Count"
        '
        'nuOutputs
        '
        Me.nuOutputs.Location = New System.Drawing.Point(16, 166)
        Me.nuOutputs.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nuOutputs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nuOutputs.Name = "nuOutputs"
        Me.nuOutputs.Size = New System.Drawing.Size(172, 20)
        Me.nuOutputs.TabIndex = 3
        Me.nuOutputs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "High Input Error"
        '
        'nuHighError
        '
        Me.nuHighError.Location = New System.Drawing.Point(16, 74)
        Me.nuHighError.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nuHighError.Minimum = New Decimal(New Integer() {1316134912, 2328, 0, -2147483648})
        Me.nuHighError.Name = "nuHighError"
        Me.nuHighError.Size = New System.Drawing.Size(172, 20)
        Me.nuHighError.TabIndex = 5
        '
        'nuLowError
        '
        Me.nuLowError.Location = New System.Drawing.Point(16, 116)
        Me.nuLowError.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nuLowError.Minimum = New Decimal(New Integer() {-727379968, 232, 0, -2147483648})
        Me.nuLowError.Name = "nuLowError"
        Me.nuLowError.Size = New System.Drawing.Size(172, 20)
        Me.nuLowError.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Low Input Error"
        '
        'chkUseWeights
        '
        Me.chkUseWeights.AutoSize = True
        Me.chkUseWeights.Location = New System.Drawing.Point(16, 203)
        Me.chkUseWeights.Name = "chkUseWeights"
        Me.chkUseWeights.Size = New System.Drawing.Size(152, 17)
        Me.chkUseWeights.TabIndex = 8
        Me.chkUseWeights.Text = "Use Weights for averaging"
        Me.chkUseWeights.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Weight Values (comma seperated)"
        '
        'txtWeights
        '
        Me.txtWeights.Location = New System.Drawing.Point(16, 254)
        Me.txtWeights.Name = "txtWeights"
        Me.txtWeights.Size = New System.Drawing.Size(172, 20)
        Me.txtWeights.TabIndex = 10
        '
        'B_Average_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtWeights)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkUseWeights)
        Me.Controls.Add(Me.nuLowError)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuHighError)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuOutputs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_Average_Props"
        Me.Size = New System.Drawing.Size(209, 298)
        CType(Me.nuOutputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuHighError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuLowError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuOutputs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuHighError As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuLowError As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkUseWeights As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWeights As System.Windows.Forms.TextBox
End Class
