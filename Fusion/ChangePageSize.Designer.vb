<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePageSize
    Inherits System.Windows.Forms.Form

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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.nuWidth = New System.Windows.Forms.NumericUpDown()
        Me.nuHeight = New System.Windows.Forms.NumericUpDown()
        CType(Me.nuWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(12, 116)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(115, 116)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(21, 30)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(35, 13)
        Me.lblWidth.TabIndex = 0
        Me.lblWidth.Text = "Width"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(21, 67)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(38, 13)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "Height"
        '
        'nuWidth
        '
        Me.nuWidth.Location = New System.Drawing.Point(70, 28)
        Me.nuWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nuWidth.Minimum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nuWidth.Name = "nuWidth"
        Me.nuWidth.Size = New System.Drawing.Size(120, 20)
        Me.nuWidth.TabIndex = 1
        Me.nuWidth.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'nuHeight
        '
        Me.nuHeight.Location = New System.Drawing.Point(70, 67)
        Me.nuHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nuHeight.Minimum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nuHeight.Name = "nuHeight"
        Me.nuHeight.Size = New System.Drawing.Size(120, 20)
        Me.nuHeight.TabIndex = 3
        Me.nuHeight.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'ChangePageSize
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(206, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.nuHeight)
        Me.Controls.Add(Me.nuWidth)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ChangePageSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Page Size"
        CType(Me.nuWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents nuWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuHeight As System.Windows.Forms.NumericUpDown
End Class
