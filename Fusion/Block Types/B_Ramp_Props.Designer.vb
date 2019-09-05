<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Ramp_Props
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
        Me.nuMin = New System.Windows.Forms.NumericUpDown()
        Me.nuMax = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuStep = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkReset = New System.Windows.Forms.CheckBox()
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuStep, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(16, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Minimum Output"
        '
        'nuMin
        '
        Me.nuMin.Location = New System.Drawing.Point(16, 74)
        Me.nuMin.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nuMin.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.nuMin.Name = "nuMin"
        Me.nuMin.Size = New System.Drawing.Size(172, 20)
        Me.nuMin.TabIndex = 3
        '
        'nuMax
        '
        Me.nuMax.Location = New System.Drawing.Point(16, 120)
        Me.nuMax.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nuMax.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.nuMax.Name = "nuMax"
        Me.nuMax.Size = New System.Drawing.Size(172, 20)
        Me.nuMax.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Maximum Output"
        '
        'nuStep
        '
        Me.nuStep.Location = New System.Drawing.Point(16, 164)
        Me.nuStep.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nuStep.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nuStep.Name = "nuStep"
        Me.nuStep.Size = New System.Drawing.Size(172, 20)
        Me.nuStep.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Step Value"
        '
        'chkReset
        '
        Me.chkReset.AutoSize = True
        Me.chkReset.Location = New System.Drawing.Point(16, 199)
        Me.chkReset.Name = "chkReset"
        Me.chkReset.Size = New System.Drawing.Size(190, 17)
        Me.chkReset.TabIndex = 8
        Me.chkReset.Text = "Reset to Min when Max is reached"
        Me.chkReset.UseVisualStyleBackColor = True
        '
        'B_Ramp_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkReset)
        Me.Controls.Add(Me.nuStep)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuMax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuMin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_Ramp_Props"
        Me.Size = New System.Drawing.Size(220, 231)
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkReset As System.Windows.Forms.CheckBox
End Class
