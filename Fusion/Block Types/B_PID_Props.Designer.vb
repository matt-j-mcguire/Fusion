<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_PID_Props
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
        Me.nuReset = New System.Windows.Forms.NumericUpDown()
        Me.nuGain = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuDGain = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nuMin = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nuMax = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nuChange = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nuWait = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.nuReset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuGain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuDGain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuWait, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reset (P)"
        '
        'nuReset
        '
        Me.nuReset.DecimalPlaces = 1
        Me.nuReset.Location = New System.Drawing.Point(16, 74)
        Me.nuReset.Name = "nuReset"
        Me.nuReset.Size = New System.Drawing.Size(172, 20)
        Me.nuReset.TabIndex = 3
        '
        'nuGain
        '
        Me.nuGain.DecimalPlaces = 1
        Me.nuGain.Location = New System.Drawing.Point(16, 115)
        Me.nuGain.Name = "nuGain"
        Me.nuGain.Size = New System.Drawing.Size(172, 20)
        Me.nuGain.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Gain (I)"
        '
        'nuDGain
        '
        Me.nuDGain.DecimalPlaces = 1
        Me.nuDGain.Location = New System.Drawing.Point(16, 157)
        Me.nuDGain.Name = "nuDGain"
        Me.nuDGain.Size = New System.Drawing.Size(172, 20)
        Me.nuDGain.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Derivative Gain (D)"
        '
        'nuMin
        '
        Me.nuMin.DecimalPlaces = 1
        Me.nuMin.Location = New System.Drawing.Point(16, 201)
        Me.nuMin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nuMin.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nuMin.Name = "nuMin"
        Me.nuMin.Size = New System.Drawing.Size(172, 20)
        Me.nuMin.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Minimum Calc"
        '
        'nuMax
        '
        Me.nuMax.DecimalPlaces = 1
        Me.nuMax.Location = New System.Drawing.Point(16, 243)
        Me.nuMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nuMax.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nuMax.Name = "nuMax"
        Me.nuMax.Size = New System.Drawing.Size(172, 20)
        Me.nuMax.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Maximum Calc"
        '
        'nuChange
        '
        Me.nuChange.DecimalPlaces = 1
        Me.nuChange.Location = New System.Drawing.Point(16, 284)
        Me.nuChange.Name = "nuChange"
        Me.nuChange.Size = New System.Drawing.Size(172, 20)
        Me.nuChange.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Max Change Per Calc"
        '
        'nuWait
        '
        Me.nuWait.DecimalPlaces = 1
        Me.nuWait.Location = New System.Drawing.Point(16, 328)
        Me.nuWait.Name = "nuWait"
        Me.nuWait.Size = New System.Drawing.Size(172, 20)
        Me.nuWait.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 311)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Wait Time between Calcs (Seconds)"
        '
        'B_PID_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.nuWait)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nuChange)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nuMax)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nuMin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nuDGain)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuGain)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuReset)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_PID_Props"
        Me.Size = New System.Drawing.Size(200, 362)
        CType(Me.nuReset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuGain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuDGain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuWait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuReset As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuGain As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuDGain As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nuMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nuMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nuChange As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nuWait As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
