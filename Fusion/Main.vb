Public Class Main


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CurrentPage.GridSize = My.Settings.GridSize
        CurrentPage.AlignToGrid = My.Settings.AlignToGrid
        tsEditAligntoGrid.Checked = My.Settings.AlignToGrid
        CurrentPage.ShowGrid = My.Settings.ShowGrid
        tsEditShowGrid.Checked = My.Settings.ShowGrid
        CurrentPage.ShowInputsBlock = My.Settings.ShowInputblockLocation
        tsShowInputs.Checked = My.Settings.ShowInputblockLocation
        CurrentPage.ShowOutputsBlock = My.Settings.ShowOutputBlockLocation
        tsShowOutputs.Checked = My.Settings.ShowOutputBlockLocation
        loadWireOptions(My.Settings.WireSize, My.Settings.WireStyle, My.Settings.WireColor)
        windowHelp.SetWinRec(Me, My.Settings.MainLocation, My.Settings.MainSize)
        If My.Settings.AutoLoad Then
            Me.LoadFile(My.Settings.AutoLoadFile, False)
            If myProject IsNot Nothing AndAlso myProject.CanRun Then
                tsRunAs.Enabled = True
                tsPlay.Enabled = True
                If My.Settings.AutoStartFile Then
                    tsPlay_Click(tsPlay, New EventArgs)
                End If
            End If
        End If

        tsEdit.Enabled = False
        CurrentPage.Enabled = False
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.GridSize = CurrentPage.GridSize
        My.Settings.AlignToGrid = CurrentPage.AlignToGrid
        My.Settings.ShowGrid = CurrentPage.ShowGrid
        My.Settings.WireSize = CurrentPage.Wire_Style.Size
        My.Settings.WireStyle = CurrentPage.Wire_Style.style
        My.Settings.WireColor = CurrentPage.Wire_Style.Color.ToString
        My.Settings.ShowInputblockLocation = CurrentPage.ShowInputsBlock
        My.Settings.ShowOutputBlockLocation = CurrentPage.ShowOutputsBlock
        If Me.Size.Width > 300 AndAlso Me.Size.Height > 300 Then
            My.Settings.MainSize = Me.Size
        Else
            My.Settings.MainSize = New Size(300, 300)
        End If

        My.Settings.MainLocation = Me.Location

        My.Settings.Save()
    End Sub

#Region "Open/load and save functions"


    ''' <summary>
    ''' opens the save file dialog, to create a new .dkfusion file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsNewProject_Click(sender As Object, e As EventArgs) Handles tsNewProject.Click
        Dim opn As New SaveFileDialog()
        With opn
            .Filter = "DK Fusion files|*.dkfusion"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadFile(.FileName, True)
            End If
        End With
    End Sub

    ''' <summary>
    ''' opens the open file dialog, to open an existing .dkfusion file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsOpenProject_Click(sender As Object, e As EventArgs) Handles tsOpenProject.Click
        Dim opn As New OpenFileDialog()
        With opn
            .Filter = "DK Fusion files|*.dkfusion"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadFile(.FileName, False)
            End If
        End With
    End Sub

    ''' <summary>
    ''' loads a project from file
    ''' </summary>
    ''' <param name="file"></param>
    ''' <remarks></remarks>
    Private Sub LoadFile(file As String, isnew As Boolean)
        '---------------------------------------------
        'see if there was already an open project open
        'if there was see, if we want of save before
        'opening up the new file
        '---------------------------------------------
        If myProject IsNot Nothing Then
            If myProject.NeedsSave AndAlso MessageBox.Show("The current file still needs saved. Save", "Save file", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                myProject.Save()
            End If
            myProject.Stop()
            myProject = Nothing
        End If

        tvProject.Nodes.Clear()
        myProject = New Project(file, isnew)
        If myProject.CanRun Then
            tsRunAs.SelectedItem = myProject.RunType.ToString

            '---------------------------------------------
            'load up the main project item to the treeview
            'and all the pages.
            '---------------------------------------------
            Dim t As TreeNode = tvProject.Nodes.Add("", myProject.Name, "Project", "Project")
            t.Tag = myProject
            For Each item As Page In myProject.Pages
                Dim p As TreeNode = t.Nodes.Add("", item.Name, "Page", "Page")
                p.Tag = item
            Next

            '---------------------------------------------
            'load up IO system and all the sub IO
            'loop, and comm items
            '---------------------------------------------
            t = tvProject.Nodes.Add("IO_nodex", "I/O Manager", "IO", "IO")
            t.Tag = myProject.IO
            For Each c As CommLoop In myProject.IO.Loops
                Dim p As TreeNode = t.Nodes.Add("", c.Name, c.CommType.ToString, c.CommType.ToString)
                p.Tag = c
                For Each pi As CommPoint In c.CommPoints
                    Dim i As TreeNode = p.Nodes.Add("", pi.Name, "CommPoint", "CommPoint")
                    i.Tag = pi
                Next
            Next

            tvProject.ExpandAll()
        Else
            MessageBox.Show("Project was not able to be loaded, check EventLogs and ErrorLogs for details", "Error")
        End If

    End Sub

    ''' <summary>
    ''' saves the project back to the file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsSaveProject_Click(sender As Object, e As EventArgs) Handles tsSaveProject.Click
        CurrentPage.Save()
        If myProject IsNot Nothing Then myProject.Save()
    End Sub

#End Region

#Region "Tree operations"

    ''' <summary>
    ''' edits and saves the name of the xmlnode
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvProject_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tvProject.AfterLabelEdit
        Dim o As Object = e.Node.Tag
        If TypeOf o Is Project Then
            DirectCast(o, Project).Name = e.Label
        ElseIf TypeOf o Is Page Then
            DirectCast(o, Page).Name = e.Label
        ElseIf TypeOf o Is CommLoop Then
            DirectCast(o, CommLoop).Name = e.Label
        ElseIf TypeOf o Is CommPoint Then
            With DirectCast(o, CommPoint)
                If .isNewNameOK(e.Label) Then
                    .Name = e.Label
                Else
                    e.CancelEdit = True
                    MessageBox.Show("New Name: " & e.Label & " was not in the correct format")
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' loads up the page to be edited
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvProject_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvProject.AfterSelect
        Dim o As Object = e.Node.Tag
        If TypeOf o Is Page Then
            CurrentPage.LoadPage(o)
            tsEdit.Enabled = True
            CurrentPage.Enabled = True
            tpEdit.Text = "Edit - " & CurrentPage.CurrentPage.Name
        End If
    End Sub

    ''' <summary>
    ''' cancel editing of node name if it is an IoManager or nothing is in the tag of the node
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvProject_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tvProject.BeforeLabelEdit
        Dim o As Object = e.Node.Tag
        If o Is Nothing OrElse TypeOf o Is IOManager Then e.CancelEdit = True
    End Sub

    ''' <summary>
    ''' customizes the context menu depending on what node was selected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvProject_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvProject.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim pg, cl, cp, cutcopy, del, paste As Boolean
            Dim tmpnode As XmlNode = CheckClipBoardForNode()

            Dim o As Object = e.Node.Tag
            If TypeOf o Is Project Then
                pg = True
                If tmpnode IsNot Nothing AndAlso Project.isVallidPageNode(tmpnode) Then paste = True
            ElseIf TypeOf o Is Page Then
                cutcopy = True
                del = True
            ElseIf TypeOf o Is IOManager Then
                cl = True
                If tmpnode IsNot Nothing AndAlso CommLoop.IsVallidCommLoopNode(tmpnode) Then paste = True
            ElseIf TypeOf o Is CommLoop Then
                cp = True
                cutcopy = True
                del = True
                If tmpnode IsNot Nothing AndAlso DirectCast(o, CommLoop).isVallidCommPoint(tmpnode) Then paste = True
            ElseIf TypeOf o Is CommPoint Then
                cutcopy = True
                del = True
            End If

            tssBar0.Visible = pg Or cl Or cp
            tstvAddPage.Visible = pg
            tstvAddCommLoop.Visible = cl
            tstvAddCommPoint.Visible = cp
            tstvCut.Enabled = cutcopy
            tstvCopy.Enabled = cutcopy
            tstvProperties.Enabled = (TypeOf o Is iItemCommonFunctions)
            tstvDelete.Enabled = del
            tstvPaste.Enabled = paste

            tvProject.SelectedNode = e.Node
            cmsTree.Show(tvProject, e.X, e.Y)
        End If

    End Sub

    ''' <summary>
    ''' checks to see if there is an xmlnode in the clipboard
    ''' and returns if it does
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckClipBoardForNode() As XmlNode
        Dim ret As XmlNode = Nothing
        If Clipboard.ContainsText Then
            Dim t As New XmlDocument
            Try
                t.LoadXml(Clipboard.GetText)
                Dim b As XmlNode = t.SelectSingleNode("Fusion")
                If b IsNot Nothing Then
                    ret = b.ChildNodes(0)
                End If



            Catch ex As Exception
                'failed to load the xml
            End Try
        End If

        Return ret
    End Function

    ''' <summary>
    ''' adds a new page to the project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvAddPage_Click(sender As Object, e As EventArgs) Handles tstvAddPage.Click
        Dim ret As String = InputBox("Name for New Page", "New Page", "Page")
        If Not String.IsNullOrEmpty(ret) Then
            Dim p As Page = myProject.AddNewPage(ret)
            Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, "Page", "Page")
            ptv.Tag = p
            tvProject.SelectedNode.ExpandAll()
        End If
    End Sub

    ''' <summary>
    ''' adds a new optomux comm loop to the project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsAddCommOptoMux_Click(sender As Object, e As EventArgs) Handles tsAddCommOptoMux.Click
        AddCommLoop(CommLoopType.OptoMux)
    End Sub

    ''' <summary>
    ''' does the actual adding of the comm loops to the project
    ''' </summary>
    ''' <param name="ts"></param>
    ''' <remarks></remarks>
    Private Sub AddCommLoop(ts As CommLoopType)
        Dim p As CommLoop = myProject.IO.AddNewCommLoop(ts)
        If p IsNot Nothing Then
            Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, ts.ToString, ts.ToString.ToString)
            ptv.Tag = p
            tvProject.SelectedNode.ExpandAll()
        End If
    End Sub

    ''' <summary>
    ''' adds a new commpoint to the project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvAddCommPoint_Click(sender As Object, e As EventArgs) Handles tstvAddCommPoint.Click
        Dim cl As CommLoop = tvProject.SelectedNode.Tag
        Dim p As CommPoint = cl.AddNewCommPoint()
        If p IsNot Nothing Then
            Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, "CommPoint", "CommPoint")
            ptv.Tag = p
            tvProject.SelectedNode.ExpandAll()
        End If
    End Sub

    ''' <summary>
    ''' cuts a node from the tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvCut_Click(sender As Object, e As EventArgs) Handles tstvCut.Click
        Dim n As Object = tvProject.SelectedNode.Tag
        Dim nd As XmlNode = Nothing
        If TypeOf n Is Page Then
            With DirectCast(n, Page)
                .Save()
                nd = .Node
            End With
        ElseIf TypeOf n Is CommLoop Then
            With DirectCast(n, CommLoop)
                .Save()
                nd = .Node
            End With
        ElseIf TypeOf n Is CommPoint Then
            With DirectCast(n, CommPoint)
                .Save()
                nd = .Node
            End With
        End If
        If nd IsNot Nothing Then
            Dim x As XmlDocument = XHelper.CreateNewDocument("Fusion")
            nd = x.ImportNode(nd, True)
            x.SelectSingleNode("Fusion").AppendChild(nd)
            Clipboard.SetText(x.OuterXml)
            nd.ParentNode.RemoveChild(nd)
            tvProject.SelectedNode.Remove()
        End If

    End Sub

    ''' <summary>
    ''' copies a node from the tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvCopy_Click(sender As Object, e As EventArgs) Handles tstvCopy.Click
        Dim n As Object = tvProject.SelectedNode.Tag
        Dim nd As XmlNode = Nothing
        If TypeOf n Is Page Then
            With DirectCast(n, Page)
                .Save()
                nd = .Node
            End With
        ElseIf TypeOf n Is CommLoop Then
            With DirectCast(n, CommLoop)
                .Save()
                nd = .Node
            End With
        ElseIf TypeOf n Is CommPoint Then
            With DirectCast(n, CommPoint)
                .Save()
                nd = .Node
            End With
        End If
        If nd IsNot Nothing Then
            'temporarlly make a new document "text"
            'to put on the clipboard, to be parsed later
            Dim x As XmlDocument = XHelper.CreateNewDocument("Fusion")
            nd = x.ImportNode(nd, True)
            x.SelectSingleNode("Fusion").AppendChild(nd)
            Clipboard.SetText(x.OuterXml)
        End If
    End Sub

    ''' <summary>
    ''' pastes an item form the clipboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvPaste_Click(sender As Object, e As EventArgs) Handles tstvPaste.Click

        Dim nd As XmlNode = CheckClipBoardForNode()
        If nd IsNot Nothing Then
            nd = myProject.Node.OwnerDocument.ImportNode(nd, True)

            Dim n As Object = tvProject.SelectedNode.Tag
            If TypeOf n Is Project Then
                'to add a page
                Dim p As Page = myProject.AddPage(nd)
                If p IsNot Nothing Then
                    Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, "Page", "Page")
                    ptv.Tag = p
                    tvProject.SelectedNode.ExpandAll()
                End If
            ElseIf TypeOf n Is IOManager Then
                'to add a commloop
                Dim p As CommLoop = myProject.IO.AddLoop(nd)
                If p IsNot Nothing Then
                    Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, p.CommType.ToString, p.CommType.ToString)
                    ptv.Tag = p
                    tvProject.SelectedNode.ExpandAll()
                End If

            ElseIf TypeOf n Is CommLoop Then
                'to add a commpoint
                Dim p As CommPoint = DirectCast(n, CommLoop).AddPoint(nd)
                If p IsNot Nothing Then
                    Dim ptv As TreeNode = tvProject.SelectedNode.Nodes.Add("", p.Name, "CommPoint", "CommPoint")
                    ptv.Tag = p
                    tvProject.SelectedNode.ExpandAll()
                End If
            End If
        End If


    End Sub

    ''' <summary>
    ''' deletes a node from the tree
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvDelete_Click(sender As Object, e As EventArgs) Handles tstvDelete.Click
        If MessageBox.Show("Are you sure you want to delete: " & tvProject.SelectedNode.Text & "?", "Delete", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim n As Object = tvProject.SelectedNode.Tag
            If TypeOf n Is Page Then
                myProject.RemovePage(n)
            ElseIf TypeOf n Is CommLoop Then
                myProject.IO.RemoveLoop(n)
            ElseIf TypeOf n Is CommPoint Then
                myProject.IO.RemovePoint(n)
            End If
            tvProject.SelectedNode.Remove()
        End If

    End Sub

    ''' <summary>
    ''' shows the properties for the selected item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tstvProperties_Click(sender As Object, e As EventArgs) Handles tstvProperties.Click
        Dim o As Object = tvProject.SelectedNode.Tag

        If TypeOf o Is iItemCommonFunctions Then
            With DirectCast(o, iItemCommonFunctions)
                .ShowProperties()
                If .Name <> tvProject.SelectedNode.Text Then tvProject.SelectedNode.Text = .Name
            End With
        End If
    End Sub

    ''' <summary>
    ''' opens the properties for the selected item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvProject_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvProject.NodeMouseDoubleClick
        tstvProperties_Click(sender, New EventArgs)
    End Sub

#End Region

    ''' <summary>
    ''' shows the options for the program
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsOptions_Click(sender As Object, e As EventArgs) Handles tsOptions.Click
        Dim ex As New Options
        If ex.ShowDialog = Windows.Forms.DialogResult.OK Then
            CurrentPage.GridSize = ex.GridSize
        End If
    End Sub

    ''' <summary>
    ''' changes how the project is ran
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsRunAs_Click(sender As Object, e As EventArgs) Handles tsRunAs.SelectedIndexChanged
        myProject.RunType = [Enum].Parse(GetType(RunStyle), tsRunAs.ComboBox.SelectedItem.ToString)
    End Sub

    ''' <summary>
    ''' starts the project running
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsPlay_Click(sender As Object, e As EventArgs) Handles tsPlay.Click
        If myProject.CanRun Then
            myProject.Run()
            tsPlay.Enabled = False
            tsStop.Enabled = True
            tsRunAs.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' stops the current running project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsStop_Click(sender As Object, e As EventArgs) Handles tsStop.Click
        If myProject.isRunning Then
            myProject.Stop()
            tsPlay.Enabled = True
            tsStop.Enabled = False
            tsRunAs.Enabled = True
        End If
    End Sub

#Region "edit tab toolbar"

    ''' <summary>
    ''' starts the drag drop operation to the current page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tseItem_MouseDown(sender As Object, e As MouseEventArgs) Handles tseLabel.MouseDown, tseAnd.MouseDown, tseOr.MouseDown, tseNot.MouseDown, tseNand.MouseDown,
                                                                        tseNor.MouseDown, tseExor.MouseDown, tseExnor.MouseDown, tseTruthTable.MouseDown, tseRelay.MouseDown,
                                                                        tseSetReset.MouseDown, tseCam.MouseDown, tseTimedSequence.MouseDown, tseCompareD.MouseDown,
                                                                        tseCompareA.MouseDown, tseRamp.MouseDown, tseScale.MouseDown, tseAverage.MouseDown, tseSwitch.MouseDown,
                                                                        tseConstantA.MouseDown, tseConstantD.MouseDown, tseAlarmGen.MouseDown, tseAlarmManager.MouseDown,
                                                                        tseSettingA.MouseDown, tseSettingC.MouseDown, tseSettingD.MouseDown, tseSettingT.MouseDown,
                                                                        tseDigitalInput.MouseDown, tseDigitalOutput.MouseDown, tseAnalogInput.MouseDown, tseAnalogOutput.MouseDown,
                                                                        tseTemperature.MouseDown, tseJumpTo.MouseDown, tseJumpFrom.MouseDown, tseAnalogToBinary.MouseDown, tseBinaryToAnalog.MouseDown,
                                                                        tseBitShift.MouseDown, tseAddSubtract.MouseDown, tseMultiDivisor.MouseDown, tseModulo.MouseDown,
                                                                        tseCounter.MouseDown, tseTimer.MouseDown, tseRandom.MouseDown, tsePID.MouseDown, tseWetbulb.MouseDown

        'sends the text of the button (that should match one
        'of the BlockType values) to an the current page
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As ToolStripButton = sender
            b.DoDragDrop(b.Text, DragDropEffects.Copy)
        End If

    End Sub

    ''' <summary>
    ''' loads up the wire options from start
    ''' </summary>
    ''' <param name="width"></param>
    ''' <param name="style"></param>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Private Sub loadWireOptions(width As Integer, style As DashStyle, c As String)
        Select Case width
            Case 1
                tsEditWireWidth_Click(tsEditWireWidth1, New EventArgs)
            Case 2
                tsEditWireWidth_Click(tsEditWireWidth2, New EventArgs)
            Case 3
                tsEditWireWidth_Click(tsEditWireWidth3, New EventArgs)
            Case 4
                tsEditWireWidth_Click(tsEditWireWidth4, New EventArgs)
            Case 5
                tsEditWireWidth_Click(tsEditWireWidth5, New EventArgs)
        End Select
        Select Case style
            Case DashStyle.Solid
                tsEditWireStyle_Click(tsEditWireStyle_solid, New EventArgs)
            Case DashStyle.DashDot
                tsEditWireStyle_Click(tsEditWireStyle_DashDotDash, New EventArgs)
            Case DashStyle.DashDotDot
                tsEditWireStyle_Click(tsEditWireStyle_DashDotDot, New EventArgs)
            Case DashStyle.Dot
                tsEditWireStyle_Click(tsEditWireStyle_Dots, New EventArgs)
            Case DashStyle.Dash
                tsEditWireStyle_Click(tsEditWireStyle_Dashes, New EventArgs)
        End Select

        Dim xitm As ToolStripMenuItem = Nothing
        Dim tmp As WireColor = WireColor.FromName(c)
        For xloop As Integer = 0 To WireColor.Count - 1
            Dim cx As WireColor = New WireColor(xloop)
            Dim itm As ToolStripMenuItem = tsEditWireColor.DropDownItems.Add(cx.FriendlyName, cx.ColorIcon, AddressOf tsEditWireColor_Click)
            itm.Tag = cx
            If tmp = cx Then xitm = itm
        Next
        tsEditWireColor_Click(xitm, New EventArgs)

    End Sub

    ''' <summary>
    ''' setts the current wire width
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditWireWidth_Click(sender As Object, e As EventArgs) Handles tsEditWireWidth1.Click, tsEditWireWidth2.Click, tsEditWireWidth3.Click,
                                                                                tsEditWireWidth4.Click, tsEditWireWidth5.Click
        Dim m As ToolStripMenuItem = sender
        CurrentPage.Wire_Style.Size = CInt(m.Text)
        tsEditWireWidth.Text = m.Text
    End Sub

    ''' <summary>
    ''' setts the current wire style
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditWireStyle_Click(sender As Object, e As EventArgs) Handles tsEditWireStyle_solid.Click, tsEditWireStyle_DashDotDash.Click,
                                                                                tsEditWireStyle_DashDotDot.Click, tsEditWireStyle_Dots.Click,
                                                                                tsEditWireStyle_Dashes.Click
        If sender Is tsEditWireStyle_solid Then
            CurrentPage.Wire_Style.style = DashStyle.Solid
            tsEditWireStyle.Image = My.Resources.line_solid
        ElseIf sender Is tsEditWireStyle_Dashes Then
            CurrentPage.Wire_Style.style = DashStyle.Dash
            tsEditWireStyle.Image = My.Resources.line_Dashes
        ElseIf sender Is tsEditWireStyle_DashDotDash Then
            CurrentPage.Wire_Style.style = DashStyle.DashDot
            tsEditWireStyle.Image = My.Resources.line_DashdotDash
        ElseIf sender Is tsEditWireStyle_DashDotDot Then
            CurrentPage.Wire_Style.style = DashStyle.DashDotDot
            tsEditWireStyle.Image = My.Resources.line_Dashdotdot
        ElseIf sender Is tsEditWireStyle_Dots Then
            CurrentPage.Wire_Style.style = DashStyle.Dot
            tsEditWireStyle.Image = My.Resources.line_Dots
        End If
    End Sub

    ''' <summary>
    ''' setts the current wire color
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditWireColor_Click(sender As Object, e As EventArgs)
        Dim mnu As ToolStripMenuItem = sender
        Dim c As WireColor = mnu.Tag
        CurrentPage.Wire_Style.Color = c
        tsEditWireColor.Image = c.ColorIcon
    End Sub

    ''' <summary>
    ''' to turn on or off aligning to grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditAligntoGrid_Click(sender As Object, e As EventArgs) Handles tsEditAligntoGrid.CheckedChanged
        CurrentPage.AlignToGrid = tsEditAligntoGrid.Checked
    End Sub

    ''' <summary>
    ''' to turn on or off showing the grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditShowGrid_Click(sender As Object, e As EventArgs) Handles tsEditShowGrid.CheckedChanged
        CurrentPage.ShowGrid = tsEditShowGrid.Checked
    End Sub

    ''' <summary>
    ''' cuts the currently selected items from the page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditCut_Click(sender As Object, e As EventArgs) Handles tsEditCut.Click
        CurrentPage.Cut()
    End Sub

    ''' <summary>
    ''' copys the currently selected item from the page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsCopy_Click(sender As Object, e As EventArgs) Handles tsCopy.Click
        CurrentPage.Copy()
    End Sub

    ''' <summary>
    ''' pastes the current stored items from the clipboard
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditPaste_Click(sender As Object, e As EventArgs) Handles tsEditPaste.Click
        CurrentPage.Paste()
    End Sub

    ''' <summary>
    ''' deletes the current selected items
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsEditDelete_Click(sender As Object, e As EventArgs) Handles tsEditDelete.Click
        CurrentPage.Delete()
    End Sub

    ''' <summary>
    ''' brings up a dialog to change the pagesize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tseEditExpandPage_Click(sender As Object, e As EventArgs) Handles tsChangePageSize.Click
        Dim ex As New ChangePageSize()
        ex.theSize = CurrentPage.PageSize
        If ex.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            CurrentPage.PageSize = ex.theSize
        End If
    End Sub

    ''' <summary>
    ''' to show the inputs column on the screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsShowInputs_Click(sender As Object, e As EventArgs) Handles tsShowInputs.Click
        CurrentPage.ShowInputsBlock = tsShowInputs.Checked
    End Sub

    ''' <summary>
    ''' to show the outputs column on the screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsShowOutputs_Click(sender As Object, e As EventArgs) Handles tsShowOutputs.Click
        CurrentPage.ShowOutputsBlock = tsShowOutputs.Checked
    End Sub

#End Region

    ''' <summary>
    ''' for sending key combonations to the current page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Main_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.C
                If e.Control AndAlso CurrentPage.ContainsFocus Then CurrentPage.Copy()
            Case Keys.X
                If e.Control AndAlso CurrentPage.ContainsFocus Then CurrentPage.Cut()
            Case Keys.V
                If e.Control AndAlso CurrentPage.ContainsFocus Then CurrentPage.Paste()
            Case Keys.Delete
                If CurrentPage.ContainsFocus Then CurrentPage.Delete()
            Case Keys.S
                Me.tsSaveProject_Click(tsSaveProject, New EventArgs)
            Case Keys.O
                Me.tsOpenProject_Click(tsOpenProject, New EventArgs)
            Case Keys.F5
                Me.tsPlay_Click(tsPlay, New EventArgs)
            Case Keys.Pause 'stop
                Me.tsStop_Click(tsStop, New EventArgs)
        End Select
    End Sub


    Private Sub tseExor_Click(sender As Object, e As EventArgs) Handles tseExor.Click

    End Sub
End Class
