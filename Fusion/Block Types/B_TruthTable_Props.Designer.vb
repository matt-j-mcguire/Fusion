<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_TruthTable_Props
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
        Me.nuInputs = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nuOutput = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.flp = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRemoveSequence = New System.Windows.Forms.Button()
        Me.btnAddSequence = New System.Windows.Forms.Button()
        CType(Me.nuInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuOutput, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtUserLabel.Size = New System.Drawing.Size(257, 20)
        Me.txtUserLabel.TabIndex = 1
        '
        'nuInputs
        '
        Me.nuInputs.Location = New System.Drawing.Point(16, 71)
        Me.nuInputs.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nuInputs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nuInputs.Name = "nuInputs"
        Me.nuInputs.Size = New System.Drawing.Size(257, 20)
        Me.nuInputs.TabIndex = 5
        Me.nuInputs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Input Count"
        '
        'nuOutput
        '
        Me.nuOutput.Location = New System.Drawing.Point(16, 116)
        Me.nuOutput.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nuOutput.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nuOutput.Name = "nuOutput"
        Me.nuOutput.Size = New System.Drawing.Size(257, 20)
        Me.nuOutput.TabIndex = 7
        Me.nuOutput.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Output Count"
        '
        'flp
        '
        Me.flp.AutoScroll = True
        Me.flp.BackColor = System.Drawing.Color.White
        Me.flp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp.Location = New System.Drawing.Point(16, 180)
        Me.flp.Name = "flp"
        Me.flp.Size = New System.Drawing.Size(257, 143)
        Me.flp.TabIndex = 11
        Me.flp.WrapContents = False
        '
        'btnRemoveSequence
        '
        Me.btnRemoveSequence.Image = Global.Fusion.My.Resources.Resources.DeleteHS
        Me.btnRemoveSequence.Location = New System.Drawing.Point(48, 151)
        Me.btnRemoveSequence.Name = "btnRemoveSequence"
        Me.btnRemoveSequence.Size = New System.Drawing.Size(26, 23)
        Me.btnRemoveSequence.TabIndex = 10
        Me.btnRemoveSequence.Text = " "
        Me.btnRemoveSequence.UseVisualStyleBackColor = True
        '
        'btnAddSequence
        '
        Me.btnAddSequence.Image = Global.Fusion.My.Resources.Resources.Add_1
        Me.btnAddSequence.Location = New System.Drawing.Point(16, 151)
        Me.btnAddSequence.Name = "btnAddSequence"
        Me.btnAddSequence.Size = New System.Drawing.Size(26, 23)
        Me.btnAddSequence.TabIndex = 9
        Me.btnAddSequence.Text = " "
        Me.btnAddSequence.UseVisualStyleBackColor = True
        '
        'B_TruthTable_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.flp)
        Me.Controls.Add(Me.btnRemoveSequence)
        Me.Controls.Add(Me.btnAddSequence)
        Me.Controls.Add(Me.nuOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuInputs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_TruthTable_Props"
        Me.Size = New System.Drawing.Size(289, 340)
        CType(Me.nuInputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents nuInputs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuOutput As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnRemoveSequence As System.Windows.Forms.Button
    Friend WithEvents btnAddSequence As System.Windows.Forms.Button
End Class
