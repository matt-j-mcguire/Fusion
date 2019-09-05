<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_SettingAnalog_Props
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
        Me.nuValue = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nuMax = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuMin = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.chkFloat = New System.Windows.Forms.CheckBox()
        CType(Me.nuValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'nuValue
        '
        Me.nuValue.DecimalPlaces = 1
        Me.nuValue.Location = New System.Drawing.Point(16, 123)
        Me.nuValue.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuValue.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuValue.Name = "nuValue"
        Me.nuValue.Size = New System.Drawing.Size(172, 20)
        Me.nuValue.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Value"
        '
        'nuMax
        '
        Me.nuMax.DecimalPlaces = 1
        Me.nuMax.Location = New System.Drawing.Point(16, 199)
        Me.nuMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMax.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMax.Name = "nuMax"
        Me.nuMax.Size = New System.Drawing.Size(172, 20)
        Me.nuMax.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "User Max Value"
        '
        'nuMin
        '
        Me.nuMin.DecimalPlaces = 1
        Me.nuMin.Location = New System.Drawing.Point(16, 253)
        Me.nuMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMin.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMin.Name = "nuMin"
        Me.nuMin.Size = New System.Drawing.Size(172, 20)
        Me.nuMin.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "User Min Value"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Setting Display Text"
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(16, 75)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(172, 20)
        Me.txtText.TabIndex = 11
        '
        'chkFloat
        '
        Me.chkFloat.AutoSize = True
        Me.chkFloat.Location = New System.Drawing.Point(16, 155)
        Me.chkFloat.Name = "chkFloat"
        Me.chkFloat.Size = New System.Drawing.Size(158, 17)
        Me.chkFloat.TabIndex = 12
        Me.chkFloat.Text = "Value has a floating decimal"
        Me.chkFloat.UseVisualStyleBackColor = True
        '
        'B_SettingAnalog_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkFloat)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nuMin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuMax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_SettingAnalog_Props"
        Me.Size = New System.Drawing.Size(211, 320)
        CType(Me.nuValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents nuValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents chkFloat As System.Windows.Forms.CheckBox
End Class
