<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptoMuxBoard_Props
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
        Me.udName = New System.Windows.Forms.NumericUpDown()
        Me.chkSkip = New System.Windows.Forms.CheckBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblWatchDog = New System.Windows.Forms.Label()
        Me.cmbWatchdog = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblInputsoutputs = New System.Windows.Forms.Label()
        Me.txtIO = New System.Windows.Forms.MaskedTextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtnotes = New System.Windows.Forms.TextBox()
        Me.chkIsAnalog = New System.Windows.Forms.CheckBox()
        CType(Me.udName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'udName
        '
        Me.udName.Location = New System.Drawing.Point(126, 9)
        Me.udName.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.udName.Name = "udName"
        Me.udName.Size = New System.Drawing.Size(150, 20)
        Me.udName.TabIndex = 1
        '
        'chkSkip
        '
        Me.chkSkip.AutoSize = True
        Me.chkSkip.Location = New System.Drawing.Point(126, 211)
        Me.chkSkip.Name = "chkSkip"
        Me.chkSkip.Size = New System.Drawing.Size(123, 17)
        Me.chkSkip.TabIndex = 10
        Me.chkSkip.Text = "Skip reading outputs"
        Me.chkSkip.UseVisualStyleBackColor = True
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(125, 157)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(65, 17)
        Me.chkEnabled.TabIndex = 8
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(13, 11)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(107, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Node Address/Name"
        '
        'lblWatchDog
        '
        Me.lblWatchDog.AutoSize = True
        Me.lblWatchDog.Location = New System.Drawing.Point(12, 43)
        Me.lblWatchDog.Name = "lblWatchDog"
        Me.lblWatchDog.Size = New System.Drawing.Size(98, 13)
        Me.lblWatchDog.TabIndex = 2
        Me.lblWatchDog.Text = "Watchdog Timeout"
        '
        'cmbWatchdog
        '
        Me.cmbWatchdog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWatchdog.FormattingEnabled = True
        Me.cmbWatchdog.Items.AddRange(New Object() {"Disabled", "10 Seconds", "1 Minute", "10 Minutes"})
        Me.cmbWatchdog.Location = New System.Drawing.Point(126, 39)
        Me.cmbWatchdog.Name = "cmbWatchdog"
        Me.cmbWatchdog.Size = New System.Drawing.Size(150, 21)
        Me.cmbWatchdog.TabIndex = 3
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(53, 260)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(150, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblInputsoutputs
        '
        Me.lblInputsoutputs.AutoSize = True
        Me.lblInputsoutputs.Location = New System.Drawing.Point(12, 74)
        Me.lblInputsoutputs.Name = "lblInputsoutputs"
        Me.lblInputsoutputs.Size = New System.Drawing.Size(78, 13)
        Me.lblInputsoutputs.TabIndex = 4
        Me.lblInputsoutputs.Text = "Inputs/Outputs"
        '
        'txtIO
        '
        Me.txtIO.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIO.Location = New System.Drawing.Point(125, 70)
        Me.txtIO.Mask = "<LLLL,LLLL,LLLL,LLLL"
        Me.txtIO.Name = "txtIO"
        Me.txtIO.Size = New System.Drawing.Size(151, 20)
        Me.txtIO.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(13, 106)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(60, 13)
        Me.lblNotes.TabIndex = 6
        Me.lblNotes.Text = "User Notes"
        '
        'txtnotes
        '
        Me.txtnotes.Location = New System.Drawing.Point(125, 100)
        Me.txtnotes.Multiline = True
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtnotes.Size = New System.Drawing.Size(151, 47)
        Me.txtnotes.TabIndex = 7
        '
        'chkIsAnalog
        '
        Me.chkIsAnalog.AutoSize = True
        Me.chkIsAnalog.Location = New System.Drawing.Point(126, 184)
        Me.chkIsAnalog.Name = "chkIsAnalog"
        Me.chkIsAnalog.Size = New System.Drawing.Size(99, 17)
        Me.chkIsAnalog.TabIndex = 9
        Me.chkIsAnalog.Text = "Is Analog Rack"
        Me.chkIsAnalog.UseVisualStyleBackColor = True
        '
        'OptoMuxBoard_Props
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(288, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkIsAnalog)
        Me.Controls.Add(Me.txtnotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtIO)
        Me.Controls.Add(Me.lblInputsoutputs)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cmbWatchdog)
        Me.Controls.Add(Me.lblWatchDog)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.chkSkip)
        Me.Controls.Add(Me.udName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "OptoMuxBoard_Props"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OptoMux Board Properties"
        CType(Me.udName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents udName As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkSkip As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblWatchDog As System.Windows.Forms.Label
    Friend WithEvents cmbWatchdog As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblInputsoutputs As System.Windows.Forms.Label
    Friend WithEvents txtIO As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtnotes As System.Windows.Forms.TextBox
    Friend WithEvents chkIsAnalog As System.Windows.Forms.CheckBox
End Class
