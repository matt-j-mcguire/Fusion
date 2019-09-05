<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_AnalogOutPut_Prop
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
        Me.cmbPoints = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        'cmbPoints
        '
        Me.cmbPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPoints.FormattingEnabled = True
        Me.cmbPoints.Location = New System.Drawing.Point(16, 76)
        Me.cmbPoints.Name = "cmbPoints"
        Me.cmbPoints.Size = New System.Drawing.Size(169, 21)
        Me.cmbPoints.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Connected I/O Point"
        '
        'B_AnalogOutPut_Prop
        '
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbPoints)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_AnalogOutPut_Prop"
        Me.Size = New System.Drawing.Size(202, 121)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents cmbPoints As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class

