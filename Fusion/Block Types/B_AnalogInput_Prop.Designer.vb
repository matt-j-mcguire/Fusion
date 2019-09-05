<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_AnalogInput_Prop
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
        Me.nuMaxInput = New System.Windows.Forms.NumericUpDown()
        Me.nuMinOutput = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuMaxoutput = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPoints = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.nuMaxInput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMinOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuMaxoutput, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Max Input % of full scale"
        '
        'nuMaxInput
        '
        Me.nuMaxInput.Location = New System.Drawing.Point(19, 73)
        Me.nuMaxInput.Name = "nuMaxInput"
        Me.nuMaxInput.Size = New System.Drawing.Size(169, 20)
        Me.nuMaxInput.TabIndex = 5
        '
        'nuMinOutput
        '
        Me.nuMinOutput.Location = New System.Drawing.Point(19, 119)
        Me.nuMinOutput.Name = "nuMinOutput"
        Me.nuMinOutput.Size = New System.Drawing.Size(169, 20)
        Me.nuMinOutput.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Output scale minimum %"
        '
        'nuMaxoutput
        '
        Me.nuMaxoutput.Location = New System.Drawing.Point(19, 165)
        Me.nuMaxoutput.Name = "nuMaxoutput"
        Me.nuMaxoutput.Size = New System.Drawing.Size(169, 20)
        Me.nuMaxoutput.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Output scale maximum %"
        '
        'cmbPoints
        '
        Me.cmbPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPoints.FormattingEnabled = True
        Me.cmbPoints.Location = New System.Drawing.Point(19, 211)
        Me.cmbPoints.Name = "cmbPoints"
        Me.cmbPoints.Size = New System.Drawing.Size(169, 21)
        Me.cmbPoints.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Connected I/O Point"
        '
        'B_AnalogInput_Prop
        '
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbPoints)
        Me.Controls.Add(Me.nuMaxoutput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nuMinOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nuMaxInput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserLabel)
        Me.Controls.Add(Me.lblUserLabel)
        Me.Name = "B_AnalogInput_Prop"
        Me.Size = New System.Drawing.Size(202, 249)
        CType(Me.nuMaxInput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMinOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuMaxoutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserLabel As System.Windows.Forms.TextBox
    Friend WithEvents lblUserLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nuMaxInput As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuMinOutput As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nuMaxoutput As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPoints As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class

