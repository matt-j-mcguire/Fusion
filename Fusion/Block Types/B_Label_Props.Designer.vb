<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Label_Props
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
        Me.SuspendLayout()
        '
        'lblUserLabel
        '
        Me.lblUserLabel.AutoSize = True
        Me.lblUserLabel.Location = New System.Drawing.Point(13, 13)
        Me.lblUserLabel.Name = "lblUserLabel"
        Me.lblUserLabel.Size = New System.Drawing.Size(108, 13)
        Me.lblUserLabel.TabIndex = 0
        Me.lblUserLabel.Text = "Displayed Information"
        '
        'txtUserLabel
        '
        Me.txtUserLabel.Location = New System.Drawing.Point(16, 30)
        Me.txtUserLabel.Multiline = True
        Me.txtUserLabel.Name = "txtUserLabel"
        Me.txtUserLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtUserLabel.Size = New System.Drawing.Size(335, 186)
        Me.txtUserLabel.TabIndex = 1
        '
        'B_Label_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_Label_Props"
        Me.Size = New System.Drawing.Size(368, 232)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
End Class
