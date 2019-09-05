<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_TimedSequence_Props
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
        Me.nuOutputs = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemoveSequence = New System.Windows.Forms.Button()
        Me.btnAddSequence = New System.Windows.Forms.Button()
        Me.flp = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.nuOutputs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtUserLabel.Size = New System.Drawing.Size(260, 20)
        Me.txtUserLabel.TabIndex = 1
        '
        'nuOutputs
        '
        Me.nuOutputs.Location = New System.Drawing.Point(16, 72)
        Me.nuOutputs.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nuOutputs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nuOutputs.Name = "nuOutputs"
        Me.nuOutputs.Size = New System.Drawing.Size(260, 20)
        Me.nuOutputs.TabIndex = 5
        Me.nuOutputs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Output Count"
        '
        'btnRemoveSequence
        '
        Me.btnRemoveSequence.Image = Global.Fusion.My.Resources.Resources.DeleteHS
        Me.btnRemoveSequence.Location = New System.Drawing.Point(51, 110)
        Me.btnRemoveSequence.Name = "btnRemoveSequence"
        Me.btnRemoveSequence.Size = New System.Drawing.Size(26, 23)
        Me.btnRemoveSequence.TabIndex = 7
        Me.btnRemoveSequence.Text = " "
        Me.btnRemoveSequence.UseVisualStyleBackColor = True
        '
        'btnAddSequence
        '
        Me.btnAddSequence.Image = Global.Fusion.My.Resources.Resources.Add_1
        Me.btnAddSequence.Location = New System.Drawing.Point(19, 110)
        Me.btnAddSequence.Name = "btnAddSequence"
        Me.btnAddSequence.Size = New System.Drawing.Size(26, 23)
        Me.btnAddSequence.TabIndex = 6
        Me.btnAddSequence.Text = " "
        Me.btnAddSequence.UseVisualStyleBackColor = True
        '
        'flp
        '
        Me.flp.AutoScroll = True
        Me.flp.BackColor = System.Drawing.Color.White
        Me.flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp.Location = New System.Drawing.Point(19, 139)
        Me.flp.Name = "flp"
        Me.flp.Size = New System.Drawing.Size(257, 143)
        Me.flp.TabIndex = 8
        Me.flp.WrapContents = False
        '
        'B_TimedSequence_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.flp)
        Me.Controls.Add(Me.btnRemoveSequence)
        Me.Controls.Add(Me.btnAddSequence)
        Me.Controls.Add(Me.nuOutputs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_TimedSequence_Props"
        Me.Size = New System.Drawing.Size(290, 296)
        CType(Me.nuOutputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents nuOutputs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAddSequence As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSequence As System.Windows.Forms.Button
    Friend WithEvents flp As System.Windows.Forms.FlowLayoutPanel
End Class
