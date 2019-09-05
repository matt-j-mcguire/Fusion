<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommLoop_OptoMux_Props
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblCommTimeout = New System.Windows.Forms.Label()
        Me.udTimeout = New System.Windows.Forms.NumericUpDown()
        Me.OptSerial = New System.Windows.Forms.RadioButton()
        Me.udRest = New System.Windows.Forms.NumericUpDown()
        Me.lblLoopRest = New System.Windows.Forms.Label()
        Me.optTCP = New System.Windows.Forms.RadioButton()
        Me.lblSerialPort = New System.Windows.Forms.Label()
        Me.cmbSerialPort = New System.Windows.Forms.ComboBox()
        Me.cmbBaud = New System.Windows.Forms.ComboBox()
        Me.lblBaudRate = New System.Windows.Forms.Label()
        Me.udIPPort = New System.Windows.Forms.NumericUpDown()
        Me.lblIPPort = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.lblIPAddress = New System.Windows.Forms.Label()
        CType(Me.udTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udRest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udIPPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(156, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(59, 296)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 16
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(13, 13)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(156, 10)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(120, 20)
        Me.txtName.TabIndex = 1
        '
        'lblCommTimeout
        '
        Me.lblCommTimeout.AutoSize = True
        Me.lblCommTimeout.Location = New System.Drawing.Point(13, 40)
        Me.lblCommTimeout.Name = "lblCommTimeout"
        Me.lblCommTimeout.Size = New System.Drawing.Size(99, 13)
        Me.lblCommTimeout.TabIndex = 2
        Me.lblCommTimeout.Text = "Comm Timeout (ms)"
        '
        'udTimeout
        '
        Me.udTimeout.Location = New System.Drawing.Point(156, 38)
        Me.udTimeout.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
        Me.udTimeout.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.udTimeout.Name = "udTimeout"
        Me.udTimeout.Size = New System.Drawing.Size(120, 20)
        Me.udTimeout.TabIndex = 3
        Me.udTimeout.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'OptSerial
        '
        Me.OptSerial.AutoSize = True
        Me.OptSerial.Location = New System.Drawing.Point(16, 93)
        Me.OptSerial.Name = "OptSerial"
        Me.OptSerial.Size = New System.Drawing.Size(108, 17)
        Me.OptSerial.TabIndex = 6
        Me.OptSerial.TabStop = True
        Me.OptSerial.Text = "Serial Connection"
        Me.OptSerial.UseVisualStyleBackColor = True
        '
        'udRest
        '
        Me.udRest.Location = New System.Drawing.Point(156, 66)
        Me.udRest.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udRest.Name = "udRest"
        Me.udRest.Size = New System.Drawing.Size(120, 20)
        Me.udRest.TabIndex = 5
        '
        'lblLoopRest
        '
        Me.lblLoopRest.AutoSize = True
        Me.lblLoopRest.Location = New System.Drawing.Point(13, 68)
        Me.lblLoopRest.Name = "lblLoopRest"
        Me.lblLoopRest.Size = New System.Drawing.Size(104, 13)
        Me.lblLoopRest.TabIndex = 4
        Me.lblLoopRest.Text = "Loop Rest Time (ms)"
        '
        'optTCP
        '
        Me.optTCP.AutoSize = True
        Me.optTCP.Location = New System.Drawing.Point(16, 177)
        Me.optTCP.Name = "optTCP"
        Me.optTCP.Size = New System.Drawing.Size(115, 17)
        Me.optTCP.TabIndex = 11
        Me.optTCP.TabStop = True
        Me.optTCP.Text = "Tcp/IP connection"
        Me.optTCP.UseVisualStyleBackColor = True
        '
        'lblSerialPort
        '
        Me.lblSerialPort.AutoSize = True
        Me.lblSerialPort.Location = New System.Drawing.Point(48, 122)
        Me.lblSerialPort.Name = "lblSerialPort"
        Me.lblSerialPort.Size = New System.Drawing.Size(55, 13)
        Me.lblSerialPort.TabIndex = 7
        Me.lblSerialPort.Text = "Serial Port"
        '
        'cmbSerialPort
        '
        Me.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerialPort.FormattingEnabled = True
        Me.cmbSerialPort.Location = New System.Drawing.Point(156, 119)
        Me.cmbSerialPort.Name = "cmbSerialPort"
        Me.cmbSerialPort.Size = New System.Drawing.Size(120, 21)
        Me.cmbSerialPort.TabIndex = 8
        '
        'cmbBaud
        '
        Me.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Items.AddRange(New Object() {"110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000", "256000"})
        Me.cmbBaud.Location = New System.Drawing.Point(156, 148)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(120, 21)
        Me.cmbBaud.TabIndex = 10
        '
        'lblBaudRate
        '
        Me.lblBaudRate.AutoSize = True
        Me.lblBaudRate.Location = New System.Drawing.Point(48, 151)
        Me.lblBaudRate.Name = "lblBaudRate"
        Me.lblBaudRate.Size = New System.Drawing.Size(50, 13)
        Me.lblBaudRate.TabIndex = 9
        Me.lblBaudRate.Text = "Baudrate"
        '
        'udIPPort
        '
        Me.udIPPort.Location = New System.Drawing.Point(156, 230)
        Me.udIPPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udIPPort.Name = "udIPPort"
        Me.udIPPort.Size = New System.Drawing.Size(120, 20)
        Me.udIPPort.TabIndex = 15
        '
        'lblIPPort
        '
        Me.lblIPPort.AutoSize = True
        Me.lblIPPort.Location = New System.Drawing.Point(48, 232)
        Me.lblIPPort.Name = "lblIPPort"
        Me.lblIPPort.Size = New System.Drawing.Size(39, 13)
        Me.lblIPPort.TabIndex = 14
        Me.lblIPPort.Text = "IP Port"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(156, 202)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(120, 20)
        Me.txtIP.TabIndex = 13
        '
        'lblIPAddress
        '
        Me.lblIPAddress.AutoSize = True
        Me.lblIPAddress.Location = New System.Drawing.Point(48, 205)
        Me.lblIPAddress.Name = "lblIPAddress"
        Me.lblIPAddress.Size = New System.Drawing.Size(58, 13)
        Me.lblIPAddress.TabIndex = 12
        Me.lblIPAddress.Text = "IP Address"
        '
        'CommLoop_OptoMux_Props
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(288, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.udIPPort)
        Me.Controls.Add(Me.lblIPPort)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.lblIPAddress)
        Me.Controls.Add(Me.cmbBaud)
        Me.Controls.Add(Me.lblBaudRate)
        Me.Controls.Add(Me.cmbSerialPort)
        Me.Controls.Add(Me.lblSerialPort)
        Me.Controls.Add(Me.optTCP)
        Me.Controls.Add(Me.udRest)
        Me.Controls.Add(Me.lblLoopRest)
        Me.Controls.Add(Me.OptSerial)
        Me.Controls.Add(Me.udTimeout)
        Me.Controls.Add(Me.lblCommTimeout)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CommLoop_OptoMux_Props"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OptoMux Comm Loop Properties"
        CType(Me.udTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udRest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udIPPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblCommTimeout As System.Windows.Forms.Label
    Friend WithEvents udTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents OptSerial As System.Windows.Forms.RadioButton
    Friend WithEvents udRest As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLoopRest As System.Windows.Forms.Label
    Friend WithEvents optTCP As System.Windows.Forms.RadioButton
    Friend WithEvents lblSerialPort As System.Windows.Forms.Label
    Friend WithEvents cmbSerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaudRate As System.Windows.Forms.Label
    Friend WithEvents udIPPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIPPort As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents lblIPAddress As System.Windows.Forms.Label
End Class
