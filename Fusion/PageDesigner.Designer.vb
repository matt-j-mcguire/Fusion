<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageDesigner
    Inherits UserControl

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
        Me.components = New System.ComponentModel.Container()
        Me.tmrUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProperitesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrUpdate
        '
        Me.tmrUpdate.Enabled = True
        Me.tmrUpdate.Interval = 250
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.ProperitesToolStripMenuItem})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(153, 148)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.Fusion.My.Resources.Resources.CutHS
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.Fusion.My.Resources.Resources.CopyHS
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = Global.Fusion.My.Resources.Resources.PasteHS
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.Fusion.My.Resources.Resources.DeleteHS
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'ProperitesToolStripMenuItem
        '
        Me.ProperitesToolStripMenuItem.Image = Global.Fusion.My.Resources.Resources.TagBlue
        Me.ProperitesToolStripMenuItem.Name = "ProperitesToolStripMenuItem"
        Me.ProperitesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ProperitesToolStripMenuItem.Text = "Properites"
        '
        'PageDesigner
        '
        Me.AutoScroll = True
        Me.DoubleBuffered = True
        Me.Name = "PageDesigner"
        Me.Size = New System.Drawing.Size(133, 133)
        Me.cms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrUpdate As System.Windows.Forms.Timer
    Private WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProperitesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

