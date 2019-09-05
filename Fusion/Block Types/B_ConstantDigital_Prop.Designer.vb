<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_ConstantDigital_Props
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
        Me.optOn = New System.Windows.Forms.RadioButton()
        Me.optOff = New System.Windows.Forms.RadioButton()
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
        'optOn
        '
        Me.optOn.AutoSize = True
        Me.optOn.Location = New System.Drawing.Point(16, 57)
        Me.optOn.Name = "optOn"
        Me.optOn.Size = New System.Drawing.Size(114, 17)
        Me.optOn.TabIndex = 2
        Me.optOn.TabStop = True
        Me.optOn.Text = "Value is always On"
        Me.optOn.UseVisualStyleBackColor = True
        '
        'optOff
        '
        Me.optOff.AutoSize = True
        Me.optOff.Location = New System.Drawing.Point(16, 81)
        Me.optOff.Name = "optOff"
        Me.optOff.Size = New System.Drawing.Size(114, 17)
        Me.optOff.TabIndex = 3
        Me.optOff.TabStop = True
        Me.optOff.Text = "Value is always Off"
        Me.optOff.UseVisualStyleBackColor = True
        '
        'B_ConstantDigital_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.optOff)
        Me.Controls.Add(Me.optOn)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_ConstantDigital_Props"
        Me.Size = New System.Drawing.Size(200, 120)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents optOn As System.Windows.Forms.RadioButton
    Friend WithEvents optOff As System.Windows.Forms.RadioButton
End Class
