<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Wire_UI_Props
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
        Me.lblWireSize = New System.Windows.Forms.Label()
        Me.udSize = New System.Windows.Forms.NumericUpDown()
        Me.lblStyle = New System.Windows.Forms.Label()
        Me.lblWireColor = New System.Windows.Forms.Label()
        Me.cmbStyle = New System.Windows.Forms.ComboBox()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        CType(Me.udSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWireSize
        '
        Me.lblWireSize.AutoSize = True
        Me.lblWireSize.Location = New System.Drawing.Point(32, 20)
        Me.lblWireSize.Name = "lblWireSize"
        Me.lblWireSize.Size = New System.Drawing.Size(52, 13)
        Me.lblWireSize.TabIndex = 0
        Me.lblWireSize.Text = "Wire Size"
        '
        'udSize
        '
        Me.udSize.Location = New System.Drawing.Point(35, 36)
        Me.udSize.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.udSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udSize.Name = "udSize"
        Me.udSize.Size = New System.Drawing.Size(120, 20)
        Me.udSize.TabIndex = 1
        Me.udSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblStyle
        '
        Me.lblStyle.AutoSize = True
        Me.lblStyle.Location = New System.Drawing.Point(32, 72)
        Me.lblStyle.Name = "lblStyle"
        Me.lblStyle.Size = New System.Drawing.Size(55, 13)
        Me.lblStyle.TabIndex = 2
        Me.lblStyle.Text = "Wire Style"
        '
        'lblWireColor
        '
        Me.lblWireColor.AutoSize = True
        Me.lblWireColor.Location = New System.Drawing.Point(32, 125)
        Me.lblWireColor.Name = "lblWireColor"
        Me.lblWireColor.Size = New System.Drawing.Size(56, 13)
        Me.lblWireColor.TabIndex = 4
        Me.lblWireColor.Text = "Wire Color"
        '
        'cmbStyle
        '
        Me.cmbStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStyle.FormattingEnabled = True
        Me.cmbStyle.ItemHeight = 16
        Me.cmbStyle.Items.AddRange(New Object() {"Solid", "Dashes", "Dash Dot Dash", "Dash Dot Dot", "Dots"})
        Me.cmbStyle.Location = New System.Drawing.Point(35, 88)
        Me.cmbStyle.Name = "cmbStyle"
        Me.cmbStyle.Size = New System.Drawing.Size(121, 22)
        Me.cmbStyle.TabIndex = 3
        '
        'cmbColor
        '
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.ItemHeight = 16
        Me.cmbColor.Location = New System.Drawing.Point(35, 141)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(121, 22)
        Me.cmbColor.TabIndex = 5
        '
        'Wire_UI_Props
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.cmbStyle)
        Me.Controls.Add(Me.lblWireColor)
        Me.Controls.Add(Me.lblStyle)
        Me.Controls.Add(Me.udSize)
        Me.Controls.Add(Me.lblWireSize)
        Me.Name = "Wire_UI_Props"
        Me.Size = New System.Drawing.Size(200, 189)
        CType(Me.udSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblWireSize As System.Windows.Forms.Label
    Friend WithEvents udSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStyle As System.Windows.Forms.Label
    Friend WithEvents lblWireColor As System.Windows.Forms.Label
    Friend WithEvents cmbStyle As System.Windows.Forms.ComboBox
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox

End Class
