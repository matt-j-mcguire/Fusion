<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim WireStyle1 As Fusion.WireStyle = New Fusion.WireStyle()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.tsNewProject = New System.Windows.Forms.ToolStripButton()
        Me.tsOpenProject = New System.Windows.Forms.ToolStripButton()
        Me.tsSaveProject = New System.Windows.Forms.ToolStripButton()
        Me.tsbar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsOptions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslblRunAs = New System.Windows.Forms.ToolStripLabel()
        Me.tsRunAs = New System.Windows.Forms.ToolStripComboBox()
        Me.tsPlay = New System.Windows.Forms.ToolStripButton()
        Me.tsStop = New System.Windows.Forms.ToolStripButton()
        Me.LowerStatus = New System.Windows.Forms.StatusStrip()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.tvProject = New System.Windows.Forms.TreeView()
        Me.ilTree = New System.Windows.Forms.ImageList(Me.components)
        Me.cmsTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tstvAddPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstvAddCommLoop = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAddCommOptoMux = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstvAddCommPoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssBar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstvCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstvCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstvPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstvDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstvProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpEdit = New System.Windows.Forms.TabPage()
        Me.CurrentPage = New Fusion.PageDesigner()
        Me.tsEdit = New System.Windows.Forms.ToolStrip()
        Me.tseLabel = New System.Windows.Forms.ToolStripButton()
        Me.tseAnd = New System.Windows.Forms.ToolStripButton()
        Me.tseOr = New System.Windows.Forms.ToolStripButton()
        Me.tseNot = New System.Windows.Forms.ToolStripButton()
        Me.tseNand = New System.Windows.Forms.ToolStripButton()
        Me.tseNor = New System.Windows.Forms.ToolStripButton()
        Me.tseExor = New System.Windows.Forms.ToolStripButton()
        Me.tseExnor = New System.Windows.Forms.ToolStripButton()
        Me.tseTruthTable = New System.Windows.Forms.ToolStripButton()
        Me.tseRelay = New System.Windows.Forms.ToolStripButton()
        Me.tseSetReset = New System.Windows.Forms.ToolStripButton()
        Me.tseCam = New System.Windows.Forms.ToolStripButton()
        Me.tseTimedSequence = New System.Windows.Forms.ToolStripButton()
        Me.tseCompareD = New System.Windows.Forms.ToolStripButton()
        Me.tseSwitch = New System.Windows.Forms.ToolStripButton()
        Me.tseDigitalInput = New System.Windows.Forms.ToolStripButton()
        Me.tseDigitalOutput = New System.Windows.Forms.ToolStripButton()
        Me.tseTimer = New System.Windows.Forms.ToolStripButton()
        Me.tseConstantD = New System.Windows.Forms.ToolStripButton()
        Me.tseConstantA = New System.Windows.Forms.ToolStripButton()
        Me.tseSettingA = New System.Windows.Forms.ToolStripButton()
        Me.tseSettingD = New System.Windows.Forms.ToolStripButton()
        Me.tseSettingT = New System.Windows.Forms.ToolStripButton()
        Me.tseSettingC = New System.Windows.Forms.ToolStripButton()
        Me.tseAnalogToBinary = New System.Windows.Forms.ToolStripButton()
        Me.tseBinaryToAnalog = New System.Windows.Forms.ToolStripButton()
        Me.tseBitShift = New System.Windows.Forms.ToolStripButton()
        Me.tseAnalogInput = New System.Windows.Forms.ToolStripButton()
        Me.tseAnalogOutput = New System.Windows.Forms.ToolStripButton()
        Me.tseTemperature = New System.Windows.Forms.ToolStripButton()
        Me.tseScale = New System.Windows.Forms.ToolStripButton()
        Me.tseRamp = New System.Windows.Forms.ToolStripButton()
        Me.tseCompareA = New System.Windows.Forms.ToolStripButton()
        Me.tseAddSubtract = New System.Windows.Forms.ToolStripButton()
        Me.tseMultiDivisor = New System.Windows.Forms.ToolStripButton()
        Me.tseModulo = New System.Windows.Forms.ToolStripButton()
        Me.tseCounter = New System.Windows.Forms.ToolStripButton()
        Me.tseRandom = New System.Windows.Forms.ToolStripButton()
        Me.tsePID = New System.Windows.Forms.ToolStripButton()
        Me.tseAverage = New System.Windows.Forms.ToolStripButton()
        Me.tseWetbulb = New System.Windows.Forms.ToolStripButton()
        Me.tseJumpTo = New System.Windows.Forms.ToolStripButton()
        Me.tseJumpFrom = New System.Windows.Forms.ToolStripButton()
        Me.tseAlarmGen = New System.Windows.Forms.ToolStripButton()
        Me.tseAlarmManager = New System.Windows.Forms.ToolStripButton()
        Me.tsEditBar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslEditWireWidth = New System.Windows.Forms.ToolStripLabel()
        Me.tsEditWireWidth = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsEditWireWidth1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireWidth2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireWidth3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireWidth4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireWidth5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireStyle = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsEditWireStyle_solid = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireStyle_Dashes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireStyle_DashDotDash = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireStyle_DashDotDot = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireStyle_Dots = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditWireColor = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsEditBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditAligntoGrid = New System.Windows.Forms.ToolStripButton()
        Me.tsEditShowGrid = New System.Windows.Forms.ToolStripButton()
        Me.tsShowInputs = New System.Windows.Forms.ToolStripButton()
        Me.tsShowOutputs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditCut = New System.Windows.Forms.ToolStripButton()
        Me.tsCopy = New System.Windows.Forms.ToolStripButton()
        Me.tsEditPaste = New System.Windows.Forms.ToolStripButton()
        Me.tsEditDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsEditBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsChangePageSize = New System.Windows.Forms.ToolStripButton()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.tpNotes = New System.Windows.Forms.TabPage()
        Me.splitLeft = New System.Windows.Forms.Splitter()
        Me.tsMain.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.cmsTree.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpEdit.SuspendLayout()
        Me.tsEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNewProject, Me.tsOpenProject, Me.tsSaveProject, Me.tsbar0, Me.tsOptions, Me.ToolStripSeparator2, Me.tslblRunAs, Me.tsRunAs, Me.tsPlay, Me.tsStop})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(1282, 25)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsNewProject
        '
        Me.tsNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsNewProject.Image = Global.Fusion.My.Resources.Resources.NewProject
        Me.tsNewProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNewProject.Name = "tsNewProject"
        Me.tsNewProject.Size = New System.Drawing.Size(23, 22)
        Me.tsNewProject.Text = "New Project"
        '
        'tsOpenProject
        '
        Me.tsOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsOpenProject.Image = Global.Fusion.My.Resources.Resources.Open
        Me.tsOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOpenProject.Name = "tsOpenProject"
        Me.tsOpenProject.Size = New System.Drawing.Size(23, 22)
        Me.tsOpenProject.Text = "Open Existing Project"
        '
        'tsSaveProject
        '
        Me.tsSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSaveProject.Image = Global.Fusion.My.Resources.Resources.Save
        Me.tsSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveProject.Name = "tsSaveProject"
        Me.tsSaveProject.Size = New System.Drawing.Size(23, 22)
        Me.tsSaveProject.Text = "Save Current Project"
        '
        'tsbar0
        '
        Me.tsbar0.Name = "tsbar0"
        Me.tsbar0.Size = New System.Drawing.Size(6, 25)
        '
        'tsOptions
        '
        Me.tsOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsOptions.Image = Global.Fusion.My.Resources.Resources.Options
        Me.tsOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOptions.Name = "tsOptions"
        Me.tsOptions.Size = New System.Drawing.Size(23, 22)
        Me.tsOptions.Text = "Options"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tslblRunAs
        '
        Me.tslblRunAs.Name = "tslblRunAs"
        Me.tslblRunAs.Size = New System.Drawing.Size(44, 22)
        Me.tslblRunAs.Text = "Run As"
        '
        'tsRunAs
        '
        Me.tsRunAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsRunAs.Enabled = False
        Me.tsRunAs.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tsRunAs.Items.AddRange(New Object() {"Run", "Simulate"})
        Me.tsRunAs.Name = "tsRunAs"
        Me.tsRunAs.Size = New System.Drawing.Size(121, 25)
        '
        'tsPlay
        '
        Me.tsPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPlay.Enabled = False
        Me.tsPlay.Image = Global.Fusion.My.Resources.Resources.Play
        Me.tsPlay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPlay.Name = "tsPlay"
        Me.tsPlay.Size = New System.Drawing.Size(23, 22)
        Me.tsPlay.Text = "Play"
        '
        'tsStop
        '
        Me.tsStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsStop.Enabled = False
        Me.tsStop.Image = Global.Fusion.My.Resources.Resources.cStop
        Me.tsStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsStop.Name = "tsStop"
        Me.tsStop.Size = New System.Drawing.Size(23, 22)
        Me.tsStop.Text = "Stop"
        '
        'LowerStatus
        '
        Me.LowerStatus.Location = New System.Drawing.Point(0, 527)
        Me.LowerStatus.Name = "LowerStatus"
        Me.LowerStatus.Size = New System.Drawing.Size(1282, 22)
        Me.LowerStatus.TabIndex = 1
        Me.LowerStatus.Text = "StatusStrip1"
        '
        'pnlSidebar
        '
        Me.pnlSidebar.Controls.Add(Me.tvProject)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 25)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 502)
        Me.pnlSidebar.TabIndex = 2
        '
        'tvProject
        '
        Me.tvProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvProject.FullRowSelect = True
        Me.tvProject.HideSelection = False
        Me.tvProject.HotTracking = True
        Me.tvProject.ImageIndex = 0
        Me.tvProject.ImageList = Me.ilTree
        Me.tvProject.LabelEdit = True
        Me.tvProject.Location = New System.Drawing.Point(0, 0)
        Me.tvProject.Name = "tvProject"
        Me.tvProject.SelectedImageIndex = 0
        Me.tvProject.Size = New System.Drawing.Size(200, 502)
        Me.tvProject.TabIndex = 0
        '
        'ilTree
        '
        Me.ilTree.ImageStream = CType(resources.GetObject("ilTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTree.Images.SetKeyName(0, "Project")
        Me.ilTree.Images.SetKeyName(1, "Page")
        Me.ilTree.Images.SetKeyName(2, "IO")
        Me.ilTree.Images.SetKeyName(3, "OptoMux")
        Me.ilTree.Images.SetKeyName(4, "CommPoint")
        '
        'cmsTree
        '
        Me.cmsTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstvAddPage, Me.tstvAddCommLoop, Me.tstvAddCommPoint, Me.tssBar0, Me.tstvCut, Me.tstvCopy, Me.tstvPaste, Me.tssBar1, Me.tstvDelete, Me.tssBar2, Me.tstvProperties})
        Me.cmsTree.Name = "cmsTree"
        Me.cmsTree.Size = New System.Drawing.Size(168, 198)
        '
        'tstvAddPage
        '
        Me.tstvAddPage.Image = Global.Fusion.My.Resources.Resources.Add_1
        Me.tstvAddPage.Name = "tstvAddPage"
        Me.tstvAddPage.Size = New System.Drawing.Size(167, 22)
        Me.tstvAddPage.Text = "Add Page"
        '
        'tstvAddCommLoop
        '
        Me.tstvAddCommLoop.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddCommOptoMux})
        Me.tstvAddCommLoop.Image = Global.Fusion.My.Resources.Resources.Add_1
        Me.tstvAddCommLoop.Name = "tstvAddCommLoop"
        Me.tstvAddCommLoop.Size = New System.Drawing.Size(167, 22)
        Me.tstvAddCommLoop.Text = "Add Comm Loop"
        '
        'tsAddCommOptoMux
        '
        Me.tsAddCommOptoMux.Image = Global.Fusion.My.Resources.Resources.Opto
        Me.tsAddCommOptoMux.Name = "tsAddCommOptoMux"
        Me.tsAddCommOptoMux.Size = New System.Drawing.Size(125, 22)
        Me.tsAddCommOptoMux.Text = "OptoMux"
        '
        'tstvAddCommPoint
        '
        Me.tstvAddCommPoint.Image = Global.Fusion.My.Resources.Resources.Add_1
        Me.tstvAddCommPoint.Name = "tstvAddCommPoint"
        Me.tstvAddCommPoint.Size = New System.Drawing.Size(167, 22)
        Me.tstvAddCommPoint.Text = "Add Comm Point"
        '
        'tssBar0
        '
        Me.tssBar0.Name = "tssBar0"
        Me.tssBar0.Size = New System.Drawing.Size(164, 6)
        '
        'tstvCut
        '
        Me.tstvCut.Image = Global.Fusion.My.Resources.Resources.CutHS
        Me.tstvCut.Name = "tstvCut"
        Me.tstvCut.Size = New System.Drawing.Size(167, 22)
        Me.tstvCut.Text = "Cut"
        '
        'tstvCopy
        '
        Me.tstvCopy.Image = Global.Fusion.My.Resources.Resources.CopyHS
        Me.tstvCopy.Name = "tstvCopy"
        Me.tstvCopy.Size = New System.Drawing.Size(167, 22)
        Me.tstvCopy.Text = "Copy"
        '
        'tstvPaste
        '
        Me.tstvPaste.Image = Global.Fusion.My.Resources.Resources.PasteHS
        Me.tstvPaste.Name = "tstvPaste"
        Me.tstvPaste.Size = New System.Drawing.Size(167, 22)
        Me.tstvPaste.Text = "Paste"
        '
        'tssBar1
        '
        Me.tssBar1.Name = "tssBar1"
        Me.tssBar1.Size = New System.Drawing.Size(164, 6)
        '
        'tstvDelete
        '
        Me.tstvDelete.Image = Global.Fusion.My.Resources.Resources.DeleteHS
        Me.tstvDelete.Name = "tstvDelete"
        Me.tstvDelete.Size = New System.Drawing.Size(167, 22)
        Me.tstvDelete.Text = "Delete"
        '
        'tssBar2
        '
        Me.tssBar2.Name = "tssBar2"
        Me.tssBar2.Size = New System.Drawing.Size(164, 6)
        '
        'tstvProperties
        '
        Me.tstvProperties.Image = Global.Fusion.My.Resources.Resources.TagBlue
        Me.tstvProperties.Name = "tstvProperties"
        Me.tstvProperties.Size = New System.Drawing.Size(167, 22)
        Me.tstvProperties.Text = "Properties"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.TabControl1)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(212, 25)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1070, 502)
        Me.pnlMain.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpEdit)
        Me.TabControl1.Controls.Add(Me.tpStatus)
        Me.TabControl1.Controls.Add(Me.tpNotes)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1070, 502)
        Me.TabControl1.TabIndex = 0
        '
        'tpEdit
        '
        Me.tpEdit.Controls.Add(Me.CurrentPage)
        Me.tpEdit.Controls.Add(Me.tsEdit)
        Me.tpEdit.Location = New System.Drawing.Point(4, 22)
        Me.tpEdit.Name = "tpEdit"
        Me.tpEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEdit.Size = New System.Drawing.Size(1062, 476)
        Me.tpEdit.TabIndex = 0
        Me.tpEdit.Text = "Edit"
        Me.tpEdit.UseVisualStyleBackColor = True
        '
        'CurrentPage
        '
        Me.CurrentPage.AlignToGrid = False
        Me.CurrentPage.AllowDrop = True
        Me.CurrentPage.AutoScroll = True
        Me.CurrentPage.AutoScrollMinSize = New System.Drawing.Size(1024, 768)
        Me.CurrentPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentPage.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentPage.GridSize = 0
        Me.CurrentPage.Location = New System.Drawing.Point(3, 49)
        Me.CurrentPage.Name = "CurrentPage"
        Me.CurrentPage.PageSize = New System.Drawing.Size(1024, 768)
        Me.CurrentPage.ShowGrid = False
        Me.CurrentPage.ShowInputsBlock = False
        Me.CurrentPage.ShowOutputsBlock = False
        Me.CurrentPage.Size = New System.Drawing.Size(1056, 424)
        Me.CurrentPage.TabIndex = 2
        Me.CurrentPage.Wire_Style = WireStyle1
        '
        'tsEdit
        '
        Me.tsEdit.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tseLabel, Me.tseAnd, Me.tseOr, Me.tseNot, Me.tseNand, Me.tseNor, Me.tseExor, Me.tseExnor, Me.tseTruthTable, Me.tseRelay, Me.tseSetReset, Me.tseCam, Me.tseTimedSequence, Me.tseCompareD, Me.tseSwitch, Me.tseDigitalInput, Me.tseDigitalOutput, Me.tseTimer, Me.tseConstantD, Me.tseConstantA, Me.tseSettingA, Me.tseSettingD, Me.tseSettingT, Me.tseSettingC, Me.tseAnalogToBinary, Me.tseBinaryToAnalog, Me.tseBitShift, Me.tseAnalogInput, Me.tseAnalogOutput, Me.tseTemperature, Me.tseScale, Me.tseRamp, Me.tseCompareA, Me.tseAddSubtract, Me.tseMultiDivisor, Me.tseModulo, Me.tseCounter, Me.tseRandom, Me.tsePID, Me.tseAverage, Me.tseWetbulb, Me.tseJumpTo, Me.tseJumpFrom, Me.tseAlarmGen, Me.tseAlarmManager, Me.tsEditBar0, Me.tslEditWireWidth, Me.tsEditWireWidth, Me.tsEditWireStyle, Me.tsEditWireColor, Me.tsEditBar1, Me.tsEditAligntoGrid, Me.tsEditShowGrid, Me.tsShowInputs, Me.tsShowOutputs, Me.ToolStripSeparator4, Me.tsEditCut, Me.tsCopy, Me.tsEditPaste, Me.tsEditDelete, Me.tsEditBar2, Me.tsChangePageSize})
        Me.tsEdit.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsEdit.Location = New System.Drawing.Point(3, 3)
        Me.tsEdit.Name = "tsEdit"
        Me.tsEdit.Size = New System.Drawing.Size(1056, 46)
        Me.tsEdit.TabIndex = 1
        '
        'tseLabel
        '
        Me.tseLabel.BackColor = System.Drawing.Color.BurlyWood
        Me.tseLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseLabel.Image = Global.Fusion.My.Resources.Resources.b_label
        Me.tseLabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseLabel.Name = "tseLabel"
        Me.tseLabel.Size = New System.Drawing.Size(23, 20)
        Me.tseLabel.Text = "Label"
        '
        'tseAnd
        '
        Me.tseAnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAnd.Image = Global.Fusion.My.Resources.Resources.b_And
        Me.tseAnd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAnd.Name = "tseAnd"
        Me.tseAnd.Size = New System.Drawing.Size(23, 20)
        Me.tseAnd.Text = "And"
        Me.tseAnd.ToolTipText = "And Gate"
        '
        'tseOr
        '
        Me.tseOr.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseOr.Image = Global.Fusion.My.Resources.Resources.b_Or
        Me.tseOr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseOr.Name = "tseOr"
        Me.tseOr.Size = New System.Drawing.Size(23, 20)
        Me.tseOr.Text = "Or"
        Me.tseOr.ToolTipText = "Or Gate"
        '
        'tseNot
        '
        Me.tseNot.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseNot.Image = Global.Fusion.My.Resources.Resources.b_Not
        Me.tseNot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseNot.Name = "tseNot"
        Me.tseNot.Size = New System.Drawing.Size(23, 20)
        Me.tseNot.Text = "Not"
        Me.tseNot.ToolTipText = "Not Gate"
        '
        'tseNand
        '
        Me.tseNand.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseNand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseNand.Image = Global.Fusion.My.Resources.Resources.b_nand
        Me.tseNand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseNand.Name = "tseNand"
        Me.tseNand.Size = New System.Drawing.Size(23, 20)
        Me.tseNand.Text = "Nand"
        Me.tseNand.ToolTipText = "Nand Gate"
        '
        'tseNor
        '
        Me.tseNor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseNor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseNor.Image = Global.Fusion.My.Resources.Resources.b_nor
        Me.tseNor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseNor.Name = "tseNor"
        Me.tseNor.Size = New System.Drawing.Size(23, 20)
        Me.tseNor.Text = "Nor"
        Me.tseNor.ToolTipText = "Nor Gate"
        '
        'tseExor
        '
        Me.tseExor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseExor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseExor.Image = Global.Fusion.My.Resources.Resources.b_Exor
        Me.tseExor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseExor.Name = "tseExor"
        Me.tseExor.Size = New System.Drawing.Size(23, 20)
        Me.tseExor.Text = "Exor"
        Me.tseExor.ToolTipText = "Exor Gate"
        '
        'tseExnor
        '
        Me.tseExnor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseExnor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseExnor.Image = Global.Fusion.My.Resources.Resources.b_Exnor
        Me.tseExnor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseExnor.Name = "tseExnor"
        Me.tseExnor.Size = New System.Drawing.Size(23, 20)
        Me.tseExnor.Text = "Exnor"
        Me.tseExnor.ToolTipText = "Exnor Gate"
        '
        'tseTruthTable
        '
        Me.tseTruthTable.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseTruthTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseTruthTable.Image = Global.Fusion.My.Resources.Resources.b_truthtable
        Me.tseTruthTable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseTruthTable.Name = "tseTruthTable"
        Me.tseTruthTable.Size = New System.Drawing.Size(23, 20)
        Me.tseTruthTable.Text = "TruthTable"
        Me.tseTruthTable.ToolTipText = "Truth Table"
        '
        'tseRelay
        '
        Me.tseRelay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseRelay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseRelay.Image = Global.Fusion.My.Resources.Resources.b_relay
        Me.tseRelay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseRelay.Name = "tseRelay"
        Me.tseRelay.Size = New System.Drawing.Size(23, 20)
        Me.tseRelay.Text = "Relay"
        '
        'tseSetReset
        '
        Me.tseSetReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSetReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSetReset.Image = Global.Fusion.My.Resources.Resources.b_setReset
        Me.tseSetReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSetReset.Name = "tseSetReset"
        Me.tseSetReset.Size = New System.Drawing.Size(23, 20)
        Me.tseSetReset.Text = "SetReset"
        Me.tseSetReset.ToolTipText = "Set Reset-Latching"
        '
        'tseCam
        '
        Me.tseCam.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseCam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseCam.Image = Global.Fusion.My.Resources.Resources.B_cam
        Me.tseCam.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseCam.Name = "tseCam"
        Me.tseCam.Size = New System.Drawing.Size(23, 20)
        Me.tseCam.Text = "Cam"
        Me.tseCam.ToolTipText = "Cam Roller"
        '
        'tseTimedSequence
        '
        Me.tseTimedSequence.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseTimedSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseTimedSequence.Image = Global.Fusion.My.Resources.Resources.b_timedsequence
        Me.tseTimedSequence.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseTimedSequence.Name = "tseTimedSequence"
        Me.tseTimedSequence.Size = New System.Drawing.Size(23, 20)
        Me.tseTimedSequence.Text = "TimedSequence"
        Me.tseTimedSequence.ToolTipText = "Timed Sequence"
        '
        'tseCompareD
        '
        Me.tseCompareD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseCompareD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseCompareD.Image = Global.Fusion.My.Resources.Resources.b_compareDig
        Me.tseCompareD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseCompareD.Name = "tseCompareD"
        Me.tseCompareD.Size = New System.Drawing.Size(23, 20)
        Me.tseCompareD.Text = "CompareD"
        Me.tseCompareD.ToolTipText = "Compare with Digital Out"
        '
        'tseSwitch
        '
        Me.tseSwitch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSwitch.Image = Global.Fusion.My.Resources.Resources.b_switch
        Me.tseSwitch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSwitch.Name = "tseSwitch"
        Me.tseSwitch.Size = New System.Drawing.Size(23, 20)
        Me.tseSwitch.Text = "Switch"
        Me.tseSwitch.ToolTipText = "Switch Input"
        '
        'tseDigitalInput
        '
        Me.tseDigitalInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseDigitalInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseDigitalInput.Image = Global.Fusion.My.Resources.Resources.b_DigitalInput
        Me.tseDigitalInput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseDigitalInput.Name = "tseDigitalInput"
        Me.tseDigitalInput.Size = New System.Drawing.Size(23, 20)
        Me.tseDigitalInput.Text = "DigitalInput"
        Me.tseDigitalInput.ToolTipText = "Digital Input"
        '
        'tseDigitalOutput
        '
        Me.tseDigitalOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseDigitalOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseDigitalOutput.Image = Global.Fusion.My.Resources.Resources.b_DigitalOutput
        Me.tseDigitalOutput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseDigitalOutput.Name = "tseDigitalOutput"
        Me.tseDigitalOutput.Size = New System.Drawing.Size(23, 20)
        Me.tseDigitalOutput.Text = "DigitalOutput"
        Me.tseDigitalOutput.ToolTipText = "Digital Output"
        '
        'tseTimer
        '
        Me.tseTimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseTimer.Image = Global.Fusion.My.Resources.Resources.b_timer
        Me.tseTimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseTimer.Name = "tseTimer"
        Me.tseTimer.Size = New System.Drawing.Size(23, 20)
        Me.tseTimer.Text = "Timer"
        Me.tseTimer.ToolTipText = "Once per second event tick"
        '
        'tseConstantD
        '
        Me.tseConstantD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseConstantD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseConstantD.Image = Global.Fusion.My.Resources.Resources.b_conDig
        Me.tseConstantD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseConstantD.Name = "tseConstantD"
        Me.tseConstantD.Size = New System.Drawing.Size(23, 20)
        Me.tseConstantD.Text = "ConstantD"
        Me.tseConstantD.ToolTipText = "Constant Digital Out"
        '
        'tseConstantA
        '
        Me.tseConstantA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseConstantA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseConstantA.Image = Global.Fusion.My.Resources.Resources.b_conAn
        Me.tseConstantA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseConstantA.Name = "tseConstantA"
        Me.tseConstantA.Size = New System.Drawing.Size(23, 20)
        Me.tseConstantA.Text = "ConstantA"
        Me.tseConstantA.ToolTipText = "Constant Analog Out"
        '
        'tseSettingA
        '
        Me.tseSettingA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSettingA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSettingA.Image = Global.Fusion.My.Resources.Resources.b_settingAnalog
        Me.tseSettingA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSettingA.Name = "tseSettingA"
        Me.tseSettingA.Size = New System.Drawing.Size(23, 20)
        Me.tseSettingA.Text = "SettingA"
        Me.tseSettingA.ToolTipText = "Setting: Analog Value"
        '
        'tseSettingD
        '
        Me.tseSettingD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSettingD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSettingD.Image = Global.Fusion.My.Resources.Resources.b_settingDigital
        Me.tseSettingD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSettingD.Name = "tseSettingD"
        Me.tseSettingD.Size = New System.Drawing.Size(23, 20)
        Me.tseSettingD.Text = "SettingD"
        Me.tseSettingD.ToolTipText = "Setting: On/Off Value"
        '
        'tseSettingT
        '
        Me.tseSettingT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSettingT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSettingT.Image = Global.Fusion.My.Resources.Resources.b_settingTime
        Me.tseSettingT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSettingT.Name = "tseSettingT"
        Me.tseSettingT.Size = New System.Drawing.Size(23, 20)
        Me.tseSettingT.Text = "SettingT"
        Me.tseSettingT.ToolTipText = "Setting: Time Schedule"
        '
        'tseSettingC
        '
        Me.tseSettingC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseSettingC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseSettingC.Image = Global.Fusion.My.Resources.Resources.b_settingCommand
        Me.tseSettingC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseSettingC.Name = "tseSettingC"
        Me.tseSettingC.Size = New System.Drawing.Size(23, 20)
        Me.tseSettingC.Text = "SettingC"
        Me.tseSettingC.ToolTipText = "Setting: Command (momentary push)"
        '
        'tseAnalogToBinary
        '
        Me.tseAnalogToBinary.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tseAnalogToBinary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAnalogToBinary.Image = Global.Fusion.My.Resources.Resources.b_AnalogToBinary
        Me.tseAnalogToBinary.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAnalogToBinary.Name = "tseAnalogToBinary"
        Me.tseAnalogToBinary.Size = New System.Drawing.Size(23, 20)
        Me.tseAnalogToBinary.Text = "AnalogToBinary"
        Me.tseAnalogToBinary.ToolTipText = "Analog To Binary"
        '
        'tseBinaryToAnalog
        '
        Me.tseBinaryToAnalog.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tseBinaryToAnalog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseBinaryToAnalog.Image = Global.Fusion.My.Resources.Resources.b_binaryToAnalog
        Me.tseBinaryToAnalog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseBinaryToAnalog.Name = "tseBinaryToAnalog"
        Me.tseBinaryToAnalog.Size = New System.Drawing.Size(23, 20)
        Me.tseBinaryToAnalog.Text = "BinaryToAnalog"
        Me.tseBinaryToAnalog.ToolTipText = "Binary To Analog"
        '
        'tseBitShift
        '
        Me.tseBitShift.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tseBitShift.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseBitShift.Image = Global.Fusion.My.Resources.Resources.b_Bitshift
        Me.tseBitShift.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseBitShift.Name = "tseBitShift"
        Me.tseBitShift.Size = New System.Drawing.Size(23, 20)
        Me.tseBitShift.Text = "BitShift"
        Me.tseBitShift.ToolTipText = "Bit shifting operation"
        '
        'tseAnalogInput
        '
        Me.tseAnalogInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseAnalogInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAnalogInput.Image = Global.Fusion.My.Resources.Resources.b_AnalogInput
        Me.tseAnalogInput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAnalogInput.Name = "tseAnalogInput"
        Me.tseAnalogInput.Size = New System.Drawing.Size(23, 20)
        Me.tseAnalogInput.Text = "AnalogInput"
        Me.tseAnalogInput.ToolTipText = "Analog Input"
        '
        'tseAnalogOutput
        '
        Me.tseAnalogOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseAnalogOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAnalogOutput.Image = Global.Fusion.My.Resources.Resources.b_AnalogOutput
        Me.tseAnalogOutput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAnalogOutput.Name = "tseAnalogOutput"
        Me.tseAnalogOutput.Size = New System.Drawing.Size(23, 20)
        Me.tseAnalogOutput.Text = "AnalogOutput"
        Me.tseAnalogOutput.ToolTipText = "Analog Output"
        '
        'tseTemperature
        '
        Me.tseTemperature.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseTemperature.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseTemperature.Image = Global.Fusion.My.Resources.Resources.b_temperature
        Me.tseTemperature.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseTemperature.Name = "tseTemperature"
        Me.tseTemperature.Size = New System.Drawing.Size(23, 20)
        Me.tseTemperature.Text = "Temperature"
        Me.tseTemperature.ToolTipText = "Temperature Probe"
        '
        'tseScale
        '
        Me.tseScale.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseScale.Image = Global.Fusion.My.Resources.Resources.b_scale
        Me.tseScale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseScale.Name = "tseScale"
        Me.tseScale.Size = New System.Drawing.Size(23, 20)
        Me.tseScale.Text = "Scale"
        Me.tseScale.ToolTipText = "Scale an Analog output"
        '
        'tseRamp
        '
        Me.tseRamp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseRamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseRamp.Image = Global.Fusion.My.Resources.Resources.b_ramp
        Me.tseRamp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseRamp.Name = "tseRamp"
        Me.tseRamp.Size = New System.Drawing.Size(23, 20)
        Me.tseRamp.Text = "Ramp"
        Me.tseRamp.ToolTipText = "Ramp Analog Out"
        '
        'tseCompareA
        '
        Me.tseCompareA.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseCompareA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseCompareA.Image = Global.Fusion.My.Resources.Resources.b_compareAn
        Me.tseCompareA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseCompareA.Name = "tseCompareA"
        Me.tseCompareA.Size = New System.Drawing.Size(23, 20)
        Me.tseCompareA.Text = "CompareA"
        Me.tseCompareA.ToolTipText = "Compare with Analog Out"
        '
        'tseAddSubtract
        '
        Me.tseAddSubtract.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseAddSubtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAddSubtract.Image = Global.Fusion.My.Resources.Resources.b_addsub
        Me.tseAddSubtract.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAddSubtract.Name = "tseAddSubtract"
        Me.tseAddSubtract.Size = New System.Drawing.Size(23, 20)
        Me.tseAddSubtract.Text = "AddSubtract"
        Me.tseAddSubtract.ToolTipText = "Add or Subtract"
        '
        'tseMultiDivisor
        '
        Me.tseMultiDivisor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseMultiDivisor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseMultiDivisor.Image = Global.Fusion.My.Resources.Resources.b_multiDiv
        Me.tseMultiDivisor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseMultiDivisor.Name = "tseMultiDivisor"
        Me.tseMultiDivisor.Size = New System.Drawing.Size(23, 20)
        Me.tseMultiDivisor.Text = "MultiDivisor"
        Me.tseMultiDivisor.ToolTipText = "Multiplication or Division"
        '
        'tseModulo
        '
        Me.tseModulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseModulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseModulo.Image = Global.Fusion.My.Resources.Resources.b_modulo
        Me.tseModulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseModulo.Name = "tseModulo"
        Me.tseModulo.Size = New System.Drawing.Size(23, 20)
        Me.tseModulo.Text = "Modulo"
        Me.tseModulo.ToolTipText = "Modulo (integer division remainder)"
        '
        'tseCounter
        '
        Me.tseCounter.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseCounter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseCounter.Image = Global.Fusion.My.Resources.Resources.b_counter
        Me.tseCounter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseCounter.Name = "tseCounter"
        Me.tseCounter.Size = New System.Drawing.Size(23, 20)
        Me.tseCounter.Text = "Counter"
        '
        'tseRandom
        '
        Me.tseRandom.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseRandom.Image = Global.Fusion.My.Resources.Resources.b_random
        Me.tseRandom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseRandom.Name = "tseRandom"
        Me.tseRandom.Size = New System.Drawing.Size(23, 20)
        Me.tseRandom.Text = "Random"
        Me.tseRandom.ToolTipText = "Random Number Generator"
        '
        'tsePID
        '
        Me.tsePID.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsePID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsePID.Image = Global.Fusion.My.Resources.Resources.b_pid
        Me.tsePID.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsePID.Name = "tsePID"
        Me.tsePID.Size = New System.Drawing.Size(23, 20)
        Me.tsePID.Text = "PID"
        '
        'tseAverage
        '
        Me.tseAverage.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseAverage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAverage.Image = Global.Fusion.My.Resources.Resources.b_average
        Me.tseAverage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAverage.Name = "tseAverage"
        Me.tseAverage.Size = New System.Drawing.Size(23, 20)
        Me.tseAverage.Text = "Average"
        Me.tseAverage.ToolTipText = "Average /Weighted Average"
        '
        'tseWetbulb
        '
        Me.tseWetbulb.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tseWetbulb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseWetbulb.Image = Global.Fusion.My.Resources.Resources.b_Wetbulb
        Me.tseWetbulb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseWetbulb.Name = "tseWetbulb"
        Me.tseWetbulb.Size = New System.Drawing.Size(23, 20)
        Me.tseWetbulb.Text = "Wetbulb"
        '
        'tseJumpTo
        '
        Me.tseJumpTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseJumpTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseJumpTo.Image = Global.Fusion.My.Resources.Resources.b_jumpTo
        Me.tseJumpTo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseJumpTo.Name = "tseJumpTo"
        Me.tseJumpTo.Size = New System.Drawing.Size(23, 20)
        Me.tseJumpTo.Text = "JumpTo"
        Me.tseJumpTo.ToolTipText = "Jump to another page"
        '
        'tseJumpFrom
        '
        Me.tseJumpFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseJumpFrom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseJumpFrom.Image = Global.Fusion.My.Resources.Resources.b_jumpFrom
        Me.tseJumpFrom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseJumpFrom.Name = "tseJumpFrom"
        Me.tseJumpFrom.Size = New System.Drawing.Size(23, 20)
        Me.tseJumpFrom.Text = "JumpFrom"
        Me.tseJumpFrom.ToolTipText = "Jump from another page"
        '
        'tseAlarmGen
        '
        Me.tseAlarmGen.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseAlarmGen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAlarmGen.Image = Global.Fusion.My.Resources.Resources.b_Alarm
        Me.tseAlarmGen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAlarmGen.Name = "tseAlarmGen"
        Me.tseAlarmGen.Size = New System.Drawing.Size(23, 20)
        Me.tseAlarmGen.Text = "AlarmGenerator"
        Me.tseAlarmGen.ToolTipText = "Alarm Generator"
        '
        'tseAlarmManager
        '
        Me.tseAlarmManager.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tseAlarmManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tseAlarmManager.Image = Global.Fusion.My.Resources.Resources.b_AlarmMaster
        Me.tseAlarmManager.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tseAlarmManager.Name = "tseAlarmManager"
        Me.tseAlarmManager.Size = New System.Drawing.Size(23, 20)
        Me.tseAlarmManager.Text = "AlarmManager"
        Me.tseAlarmManager.ToolTipText = "Alarm Manager"
        '
        'tsEditBar0
        '
        Me.tsEditBar0.Name = "tsEditBar0"
        Me.tsEditBar0.Size = New System.Drawing.Size(6, 23)
        '
        'tslEditWireWidth
        '
        Me.tslEditWireWidth.Name = "tslEditWireWidth"
        Me.tslEditWireWidth.Size = New System.Drawing.Size(62, 15)
        Me.tslEditWireWidth.Text = "Wire Style:"
        '
        'tsEditWireWidth
        '
        Me.tsEditWireWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsEditWireWidth.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsEditWireWidth1, Me.tsEditWireWidth2, Me.tsEditWireWidth3, Me.tsEditWireWidth4, Me.tsEditWireWidth5})
        Me.tsEditWireWidth.Image = CType(resources.GetObject("tsEditWireWidth.Image"), System.Drawing.Image)
        Me.tsEditWireWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditWireWidth.Name = "tsEditWireWidth"
        Me.tsEditWireWidth.Size = New System.Drawing.Size(26, 19)
        Me.tsEditWireWidth.Text = "1"
        Me.tsEditWireWidth.ToolTipText = "Line Width"
        '
        'tsEditWireWidth1
        '
        Me.tsEditWireWidth1.Name = "tsEditWireWidth1"
        Me.tsEditWireWidth1.Size = New System.Drawing.Size(80, 22)
        Me.tsEditWireWidth1.Text = "1"
        '
        'tsEditWireWidth2
        '
        Me.tsEditWireWidth2.Name = "tsEditWireWidth2"
        Me.tsEditWireWidth2.Size = New System.Drawing.Size(80, 22)
        Me.tsEditWireWidth2.Text = "2"
        '
        'tsEditWireWidth3
        '
        Me.tsEditWireWidth3.Name = "tsEditWireWidth3"
        Me.tsEditWireWidth3.Size = New System.Drawing.Size(80, 22)
        Me.tsEditWireWidth3.Text = "3"
        '
        'tsEditWireWidth4
        '
        Me.tsEditWireWidth4.Name = "tsEditWireWidth4"
        Me.tsEditWireWidth4.Size = New System.Drawing.Size(80, 22)
        Me.tsEditWireWidth4.Text = "4"
        '
        'tsEditWireWidth5
        '
        Me.tsEditWireWidth5.Name = "tsEditWireWidth5"
        Me.tsEditWireWidth5.Size = New System.Drawing.Size(80, 22)
        Me.tsEditWireWidth5.Text = "5"
        '
        'tsEditWireStyle
        '
        Me.tsEditWireStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditWireStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsEditWireStyle_solid, Me.tsEditWireStyle_Dashes, Me.tsEditWireStyle_DashDotDash, Me.tsEditWireStyle_DashDotDot, Me.tsEditWireStyle_Dots})
        Me.tsEditWireStyle.Image = Global.Fusion.My.Resources.Resources.line_solid
        Me.tsEditWireStyle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditWireStyle.Name = "tsEditWireStyle"
        Me.tsEditWireStyle.Size = New System.Drawing.Size(53, 20)
        Me.tsEditWireStyle.Text = "Line Style"
        '
        'tsEditWireStyle_solid
        '
        Me.tsEditWireStyle_solid.Image = Global.Fusion.My.Resources.Resources.line_solid
        Me.tsEditWireStyle_solid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle_solid.Name = "tsEditWireStyle_solid"
        Me.tsEditWireStyle_solid.Size = New System.Drawing.Size(175, 22)
        Me.tsEditWireStyle_solid.Text = "Solid"
        '
        'tsEditWireStyle_Dashes
        '
        Me.tsEditWireStyle_Dashes.Image = Global.Fusion.My.Resources.Resources.line_Dashes
        Me.tsEditWireStyle_Dashes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle_Dashes.Name = "tsEditWireStyle_Dashes"
        Me.tsEditWireStyle_Dashes.Size = New System.Drawing.Size(175, 22)
        Me.tsEditWireStyle_Dashes.Text = "Dashes"
        '
        'tsEditWireStyle_DashDotDash
        '
        Me.tsEditWireStyle_DashDotDash.Image = Global.Fusion.My.Resources.Resources.line_DashdotDash
        Me.tsEditWireStyle_DashDotDash.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle_DashDotDash.Name = "tsEditWireStyle_DashDotDash"
        Me.tsEditWireStyle_DashDotDash.Size = New System.Drawing.Size(175, 22)
        Me.tsEditWireStyle_DashDotDash.Text = "Dash Dot Dash"
        '
        'tsEditWireStyle_DashDotDot
        '
        Me.tsEditWireStyle_DashDotDot.Image = Global.Fusion.My.Resources.Resources.line_Dashdotdot
        Me.tsEditWireStyle_DashDotDot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle_DashDotDot.Name = "tsEditWireStyle_DashDotDot"
        Me.tsEditWireStyle_DashDotDot.Size = New System.Drawing.Size(175, 22)
        Me.tsEditWireStyle_DashDotDot.Text = "Dash Dot Dot"
        '
        'tsEditWireStyle_Dots
        '
        Me.tsEditWireStyle_Dots.Image = Global.Fusion.My.Resources.Resources.line_Dots
        Me.tsEditWireStyle_Dots.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEditWireStyle_Dots.Name = "tsEditWireStyle_Dots"
        Me.tsEditWireStyle_Dots.Size = New System.Drawing.Size(175, 22)
        Me.tsEditWireStyle_Dots.Text = "Dots"
        '
        'tsEditWireColor
        '
        Me.tsEditWireColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditWireColor.Image = Global.Fusion.My.Resources.Resources.c_Black
        Me.tsEditWireColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditWireColor.Name = "tsEditWireColor"
        Me.tsEditWireColor.Size = New System.Drawing.Size(29, 20)
        Me.tsEditWireColor.Text = "Line Color"
        '
        'tsEditBar1
        '
        Me.tsEditBar1.Name = "tsEditBar1"
        Me.tsEditBar1.Size = New System.Drawing.Size(6, 23)
        '
        'tsEditAligntoGrid
        '
        Me.tsEditAligntoGrid.CheckOnClick = True
        Me.tsEditAligntoGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditAligntoGrid.Image = Global.Fusion.My.Resources.Resources.AlignToGridHS
        Me.tsEditAligntoGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditAligntoGrid.Name = "tsEditAligntoGrid"
        Me.tsEditAligntoGrid.Size = New System.Drawing.Size(23, 20)
        Me.tsEditAligntoGrid.Text = "Align To Grid"
        '
        'tsEditShowGrid
        '
        Me.tsEditShowGrid.CheckOnClick = True
        Me.tsEditShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditShowGrid.Image = Global.Fusion.My.Resources.Resources.ShowGrid
        Me.tsEditShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditShowGrid.Name = "tsEditShowGrid"
        Me.tsEditShowGrid.Size = New System.Drawing.Size(23, 20)
        Me.tsEditShowGrid.Text = "Show Grid"
        '
        'tsShowInputs
        '
        Me.tsShowInputs.CheckOnClick = True
        Me.tsShowInputs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsShowInputs.Image = Global.Fusion.My.Resources.Resources.showInput
        Me.tsShowInputs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowInputs.Name = "tsShowInputs"
        Me.tsShowInputs.Size = New System.Drawing.Size(23, 20)
        Me.tsShowInputs.Text = "Show the Inputs Column"
        '
        'tsShowOutputs
        '
        Me.tsShowOutputs.CheckOnClick = True
        Me.tsShowOutputs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsShowOutputs.Image = Global.Fusion.My.Resources.Resources.showOutput
        Me.tsShowOutputs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowOutputs.Name = "tsShowOutputs"
        Me.tsShowOutputs.Size = New System.Drawing.Size(23, 20)
        Me.tsShowOutputs.Text = "Show the Outputs Column"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'tsEditCut
        '
        Me.tsEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditCut.Image = Global.Fusion.My.Resources.Resources.CutHS
        Me.tsEditCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditCut.Name = "tsEditCut"
        Me.tsEditCut.Size = New System.Drawing.Size(23, 20)
        Me.tsEditCut.Text = "Cut"
        '
        'tsCopy
        '
        Me.tsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsCopy.Image = Global.Fusion.My.Resources.Resources.CopyHS
        Me.tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCopy.Name = "tsCopy"
        Me.tsCopy.Size = New System.Drawing.Size(23, 20)
        Me.tsCopy.Text = "Copy"
        '
        'tsEditPaste
        '
        Me.tsEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditPaste.Image = Global.Fusion.My.Resources.Resources.PasteHS
        Me.tsEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditPaste.Name = "tsEditPaste"
        Me.tsEditPaste.Size = New System.Drawing.Size(23, 20)
        Me.tsEditPaste.Text = "Paste"
        '
        'tsEditDelete
        '
        Me.tsEditDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditDelete.Image = Global.Fusion.My.Resources.Resources.DeleteHS
        Me.tsEditDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditDelete.Name = "tsEditDelete"
        Me.tsEditDelete.Size = New System.Drawing.Size(23, 20)
        Me.tsEditDelete.Text = "Delete"
        '
        'tsEditBar2
        '
        Me.tsEditBar2.Name = "tsEditBar2"
        Me.tsEditBar2.Size = New System.Drawing.Size(6, 23)
        '
        'tsChangePageSize
        '
        Me.tsChangePageSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsChangePageSize.Image = Global.Fusion.My.Resources.Resources.Arrow_Green_All_Out
        Me.tsChangePageSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsChangePageSize.Name = "tsChangePageSize"
        Me.tsChangePageSize.Size = New System.Drawing.Size(23, 20)
        Me.tsChangePageSize.Text = "Change Page Size"
        '
        'tpStatus
        '
        Me.tpStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(1062, 476)
        Me.tpStatus.TabIndex = 1
        Me.tpStatus.Text = "Running Status"
        Me.tpStatus.UseVisualStyleBackColor = True
        '
        'tpNotes
        '
        Me.tpNotes.Location = New System.Drawing.Point(4, 22)
        Me.tpNotes.Name = "tpNotes"
        Me.tpNotes.Size = New System.Drawing.Size(1062, 476)
        Me.tpNotes.TabIndex = 2
        Me.tpNotes.Text = "Notes"
        Me.tpNotes.UseVisualStyleBackColor = True
        '
        'splitLeft
        '
        Me.splitLeft.Location = New System.Drawing.Point(200, 25)
        Me.splitLeft.Name = "splitLeft"
        Me.splitLeft.Size = New System.Drawing.Size(12, 502)
        Me.splitLeft.TabIndex = 4
        Me.splitLeft.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 549)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.splitLeft)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.LowerStatus)
        Me.Controls.Add(Me.tsMain)
        Me.Icon = Global.Fusion.My.Resources.Resources.Fusion
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Fusion"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.pnlSidebar.ResumeLayout(False)
        Me.cmsTree.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpEdit.ResumeLayout(False)
        Me.tpEdit.PerformLayout()
        Me.tsEdit.ResumeLayout(False)
        Me.tsEdit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsOpenProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSaveProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbar0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRunAs As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsPlay As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents LowerStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents splitLeft As System.Windows.Forms.Splitter
    Friend WithEvents tsNewProject As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslblRunAs As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tvProject As System.Windows.Forms.TreeView
    Friend WithEvents ilTree As System.Windows.Forms.ImageList
    Friend WithEvents cmsTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tstvAddPage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstvAddCommLoop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstvAddCommPoint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssBar0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstvCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstvCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstvPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssBar1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstvDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssBar2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstvProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAddCommOptoMux As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpEdit As System.Windows.Forms.TabPage
    Friend WithEvents tpStatus As System.Windows.Forms.TabPage
    Friend WithEvents tpNotes As System.Windows.Forms.TabPage
    Friend WithEvents tsEdit As System.Windows.Forms.ToolStrip
    Friend WithEvents tseLabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAnd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseOr As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseNot As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseNand As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseNor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseExor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseExnor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseTruthTable As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseRelay As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSetReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseCam As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseTimedSequence As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseCompareD As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseCompareA As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseRamp As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseScale As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAverage As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSwitch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseConstantD As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseConstantA As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAlarmGen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAlarmManager As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSettingA As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSettingD As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSettingT As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseSettingC As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseDigitalInput As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseDigitalOutput As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAnalogInput As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAnalogOutput As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseTemperature As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseJumpTo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseJumpFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAnalogToBinary As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseBinaryToAnalog As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseBitShift As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseAddSubtract As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseMultiDivisor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseModulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseCounter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseRandom As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsePID As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseWetbulb As System.Windows.Forms.ToolStripButton
    Friend WithEvents tseTimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEditBar0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslEditWireWidth As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsEditWireWidth As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsEditWireWidth1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireWidth2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireWidth3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireWidth4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireWidth5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireStyle As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsEditWireStyle_solid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireStyle_Dashes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireStyle_DashDotDash As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireStyle_DashDotDot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireStyle_Dots As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditWireColor As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsEditBar1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEditAligntoGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEditShowGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEditCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEditPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEditDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEditBar2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsChangePageSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents CurrentPage As Fusion.PageDesigner
    Friend WithEvents tsShowInputs As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsShowOutputs As System.Windows.Forms.ToolStripButton

End Class
