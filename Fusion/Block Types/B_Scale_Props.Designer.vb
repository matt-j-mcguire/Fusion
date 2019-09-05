<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Scale_Props
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
        Me.nuMinDev = New System.Windows.Forms.NumericUpDown()
        Me.nuMaxDev = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuMinOut = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nuMaxOut = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.nuMinDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMaxDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMinOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMaxOut, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(13, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Minimum Deviation"
        '
        'nuMinDev
        '
        Me.nuMinDev.DecimalPlaces = 1
        Me.nuMinDev.Location = New System.Drawing.Point(16, 79)
        Me.nuMinDev.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMinDev.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMinDev.Name = "nuMinDev"
        Me.nuMinDev.Size = New System.Drawing.Size(172, 20)
        Me.nuMinDev.TabIndex = 3
        '
        'nuMaxDev
        '
        Me.nuMaxDev.DecimalPlaces = 1
        Me.nuMaxDev.Location = New System.Drawing.Point(16, 122)
        Me.nuMaxDev.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMaxDev.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMaxDev.Name = "nuMaxDev"
        Me.nuMaxDev.Size = New System.Drawing.Size(172, 20)
        Me.nuMaxDev.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Maximum Deviation"
        '
        'nuMinOut
        '
        Me.nuMinOut.DecimalPlaces = 1
        Me.nuMinOut.Location = New System.Drawing.Point(16, 166)
        Me.nuMinOut.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMinOut.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMinOut.Name = "nuMinOut"
        Me.nuMinOut.Size = New System.Drawing.Size(172, 20)
        Me.nuMinOut.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Minimum Output"
        '
        'nuMaxOut
        '
        Me.nuMaxOut.DecimalPlaces = 1
        Me.nuMaxOut.Location = New System.Drawing.Point(16, 211)
        Me.nuMaxOut.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuMaxOut.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuMaxOut.Name = "nuMaxOut"
        Me.nuMaxOut.Size = New System.Drawing.Size(172, 20)
        Me.nuMaxOut.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Maximum Output"
        '
        'B_Scale_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.nuMaxOut)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nuMinOut)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuMaxDev)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuMinDev)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_Scale_Props"
        Me.Size = New System.Drawing.Size(200, 252)
        CType(Me.nuMinDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMaxDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMinOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMaxOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuMinDev As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuMaxDev As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuMinOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nuMaxOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
