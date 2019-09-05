<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Alarm_Prop
    Inherits BaseItemProp

    'Control overrides dispose to clean up the component list.
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

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtUserLabel = New System.Windows.Forms.TextBox()
        Me.lblUserLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAlarmMessage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOutputs = New System.Windows.Forms.ComboBox()
        Me.cmbManagers = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUserLabel
        '
        Me.txtUserLabel.Location = New System.Drawing.Point(16, 29)
        Me.txtUserLabel.Name = "txtUserLabel"
        Me.txtUserLabel.Size = New System.Drawing.Size(172, 20)
        Me.txtUserLabel.TabIndex = 3
        '
        'lblUserLabel
        '
        Me.lblUserLabel.AutoSize = True
        Me.lblUserLabel.Location = New System.Drawing.Point(13, 12)
        Me.lblUserLabel.Name = "lblUserLabel"
        Me.lblUserLabel.Size = New System.Drawing.Size(58, 13)
        Me.lblUserLabel.TabIndex = 2
        Me.lblUserLabel.Text = "User Label"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Alarm Message"
        '
        'txtAlarmMessage
        '
        Me.txtAlarmMessage.Location = New System.Drawing.Point(16, 83)
        Me.txtAlarmMessage.Name = "txtAlarmMessage"
        Me.txtAlarmMessage.Size = New System.Drawing.Size(172, 20)
        Me.txtAlarmMessage.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Desired Alarm Output"
        '
        'cmbOutputs
        '
        Me.cmbOutputs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOutputs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOutputs.FormattingEnabled = True
        Me.cmbOutputs.Location = New System.Drawing.Point(16, 184)
        Me.cmbOutputs.Name = "cmbOutputs"
        Me.cmbOutputs.Size = New System.Drawing.Size(169, 21)
        Me.cmbOutputs.TabIndex = 7
        '
        'cmbManagers
        '
        Me.cmbManagers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbManagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbManagers.FormattingEnabled = True
        Me.cmbManagers.Location = New System.Drawing.Point(16, 133)
        Me.cmbManagers.Name = "cmbManagers"
        Me.cmbManagers.Size = New System.Drawing.Size(169, 21)
        Me.cmbManagers.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Desired Alarm Manager"
        '
        'B_Alarm_Prop
        '
        Me.Controls.Add(Me.cmbManagers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbOutputs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAlarmMessage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_Alarm_Prop"
        Me.Size = New System.Drawing.Size(202, 249)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOutputs As System.Windows.Forms.ComboBox
    Friend WithEvents cmbManagers As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class

