<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_TemperatureProbe_Props
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPoints = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbProbeType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuOffset = New System.Windows.Forms.NumericUpDown()
        Me.nuLinierHi = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nuLinierLow = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.nuOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuLinierHi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuLinierLow, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtUserLabel.Location = New System.Drawing.Point(19, 30)
        Me.txtUserLabel.Name = "txtUserLabel"
        Me.txtUserLabel.Size = New System.Drawing.Size(166, 20)
        Me.txtUserLabel.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Connected I/O Point"
        '
        'cmbPoints
        '
        Me.cmbPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPoints.FormattingEnabled = True
        Me.cmbPoints.Location = New System.Drawing.Point(19, 76)
        Me.cmbPoints.Name = "cmbPoints"
        Me.cmbPoints.Size = New System.Drawing.Size(166, 21)
        Me.cmbPoints.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Probe Type"
        '
        'cmbProbeType
        '
        Me.cmbProbeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProbeType.FormattingEnabled = True
        Me.cmbProbeType.Items.AddRange(New Object() {"RTD", "Type J", "Linier", "Doubl-Kold"})
        Me.cmbProbeType.Location = New System.Drawing.Point(19, 122)
        Me.cmbProbeType.Name = "cmbProbeType"
        Me.cmbProbeType.Size = New System.Drawing.Size(166, 21)
        Me.cmbProbeType.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "DK Probe Calibrated Offset"
        '
        'nuOffset
        '
        Me.nuOffset.Location = New System.Drawing.Point(19, 176)
        Me.nuOffset.Maximum = New Decimal(New Integer() {4096, 0, 0, 0})
        Me.nuOffset.Name = "nuOffset"
        Me.nuOffset.Size = New System.Drawing.Size(166, 20)
        Me.nuOffset.TabIndex = 17
        '
        'nuLinierHi
        '
        Me.nuLinierHi.Location = New System.Drawing.Point(19, 218)
        Me.nuLinierHi.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuLinierHi.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuLinierHi.Name = "nuLinierHi"
        Me.nuLinierHi.Size = New System.Drawing.Size(166, 20)
        Me.nuLinierHi.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Linier Probe High Value"
        '
        'nuLinierLow
        '
        Me.nuLinierLow.Location = New System.Drawing.Point(19, 263)
        Me.nuLinierLow.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nuLinierLow.Minimum = New Decimal(New Integer() {2147483647, 0, 0, -2147483648})
        Me.nuLinierLow.Name = "nuLinierLow"
        Me.nuLinierLow.Size = New System.Drawing.Size(166, 20)
        Me.nuLinierLow.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Linier Probe Low Value"
        '
        'B_TemperatureProbe_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.nuLinierLow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nuLinierHi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuOffset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbProbeType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbPoints)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_TemperatureProbe_Props"
        Me.Size = New System.Drawing.Size(200, 307)
        CType(Me.nuOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuLinierHi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuLinierLow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPoints As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbProbeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuLinierHi As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nuLinierLow As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
