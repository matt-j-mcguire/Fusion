<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Me.gbAutoLoad = New System.Windows.Forms.GroupBox()
        Me.btnFindFile = New System.Windows.Forms.Button()
        Me.txtAutoLoad = New System.Windows.Forms.TextBox()
        Me.lblfileauto = New System.Windows.Forms.Label()
        Me.chkAutoRun = New System.Windows.Forms.CheckBox()
        Me.chkAutoLoad = New System.Windows.Forms.CheckBox()
        Me.lblGridSize = New System.Windows.Forms.Label()
        Me.udGridSize = New System.Windows.Forms.NumericUpDown()
        Me.gbAutoLoad.SuspendLayout()
        CType(Me.udGridSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(113, 231)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(210, 231)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbAutoLoad
        '
        Me.gbAutoLoad.Controls.Add(Me.btnFindFile)
        Me.gbAutoLoad.Controls.Add(Me.txtAutoLoad)
        Me.gbAutoLoad.Controls.Add(Me.lblfileauto)
        Me.gbAutoLoad.Controls.Add(Me.chkAutoRun)
        Me.gbAutoLoad.Controls.Add(Me.chkAutoLoad)
        Me.gbAutoLoad.Location = New System.Drawing.Point(13, 13)
        Me.gbAutoLoad.Name = "gbAutoLoad"
        Me.gbAutoLoad.Size = New System.Drawing.Size(363, 144)
        Me.gbAutoLoad.TabIndex = 0
        Me.gbAutoLoad.TabStop = False
        Me.gbAutoLoad.Text = "Autoload"
        '
        'btnFindFile
        '
        Me.btnFindFile.Location = New System.Drawing.Point(327, 57)
        Me.btnFindFile.Name = "btnFindFile"
        Me.btnFindFile.Size = New System.Drawing.Size(30, 23)
        Me.btnFindFile.TabIndex = 3
        Me.btnFindFile.Text = "..."
        Me.btnFindFile.UseVisualStyleBackColor = True
        '
        'txtAutoLoad
        '
        Me.txtAutoLoad.Location = New System.Drawing.Point(9, 43)
        Me.txtAutoLoad.Multiline = True
        Me.txtAutoLoad.Name = "txtAutoLoad"
        Me.txtAutoLoad.Size = New System.Drawing.Size(313, 49)
        Me.txtAutoLoad.TabIndex = 2
        '
        'lblfileauto
        '
        Me.lblfileauto.AutoSize = True
        Me.lblfileauto.Location = New System.Drawing.Point(6, 27)
        Me.lblfileauto.Name = "lblfileauto"
        Me.lblfileauto.Size = New System.Drawing.Size(82, 13)
        Me.lblfileauto.TabIndex = 1
        Me.lblfileauto.Text = "File to auto load"
        '
        'chkAutoRun
        '
        Me.chkAutoRun.AutoSize = True
        Me.chkAutoRun.Location = New System.Drawing.Point(6, 121)
        Me.chkAutoRun.Name = "chkAutoRun"
        Me.chkAutoRun.Size = New System.Drawing.Size(121, 17)
        Me.chkAutoRun.TabIndex = 5
        Me.chkAutoRun.Text = "Run auto loaded file"
        Me.chkAutoRun.UseVisualStyleBackColor = True
        '
        'chkAutoLoad
        '
        Me.chkAutoLoad.AutoSize = True
        Me.chkAutoLoad.Location = New System.Drawing.Point(6, 98)
        Me.chkAutoLoad.Name = "chkAutoLoad"
        Me.chkAutoLoad.Size = New System.Drawing.Size(156, 17)
        Me.chkAutoLoad.TabIndex = 4
        Me.chkAutoLoad.Text = "Auto load this file on startup"
        Me.chkAutoLoad.UseVisualStyleBackColor = True
        '
        'lblGridSize
        '
        Me.lblGridSize.AutoSize = True
        Me.lblGridSize.Location = New System.Drawing.Point(13, 174)
        Me.lblGridSize.Name = "lblGridSize"
        Me.lblGridSize.Size = New System.Drawing.Size(92, 13)
        Me.lblGridSize.TabIndex = 6
        Me.lblGridSize.Text = "Designer Grid size"
        '
        'udGridSize
        '
        Me.udGridSize.Location = New System.Drawing.Point(113, 172)
        Me.udGridSize.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.udGridSize.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.udGridSize.Name = "udGridSize"
        Me.udGridSize.Size = New System.Drawing.Size(120, 20)
        Me.udGridSize.TabIndex = 7
        Me.udGridSize.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Options
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(388, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.udGridSize)
        Me.Controls.Add(Me.lblGridSize)
        Me.Controls.Add(Me.gbAutoLoad)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.gbAutoLoad.ResumeLayout(False)
        Me.gbAutoLoad.PerformLayout()
        CType(Me.udGridSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbAutoLoad As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindFile As System.Windows.Forms.Button
    Friend WithEvents txtAutoLoad As System.Windows.Forms.TextBox
    Friend WithEvents lblfileauto As System.Windows.Forms.Label
    Friend WithEvents chkAutoRun As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoLoad As System.Windows.Forms.CheckBox
    Friend WithEvents lblGridSize As System.Windows.Forms.Label
    Friend WithEvents udGridSize As System.Windows.Forms.NumericUpDown
End Class
