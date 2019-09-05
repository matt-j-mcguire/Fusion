Public Class PageDesigner

    Private _page As Page
    Private _Items As List(Of i_UIelement)
    Private _cur_connect As Cursor
    Private _cur_noconnect As Cursor
    Private _cur_lineDrag As Cursor
    Private _ctrl As Boolean
    Private _CurrentStartConnector As NewLineOptions
    Private _MouseDownOffset As Point
    Private _MousePossibleMove As Boolean
    Private _mouseCurrentPos As Point
    Private _MousePossibleSelectBox As Boolean
    Private _popupLocation As Point
    Private WithEvents _propSettings As ItemSettings

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.ResizeRedraw Or
                 ControlStyles.UserPaint Or
                 ControlStyles.ContainerControl, True)
        'things can be dropped here
        AllowDrop = True
        Wire_Style = New WireStyle
        _Items = New List(Of i_UIelement)

        'defines the minimum size
        Me.AutoScroll = True
        Me.AutoScrollMinSize = New Size(1000, 800)

        Dim thisExe As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        _cur_connect = New Cursor(thisExe.GetManifestResourceStream("Fusion.Connect.cur"))
        _cur_noconnect = New Cursor(thisExe.GetManifestResourceStream("Fusion.NoConnect.cur"))
        _cur_lineDrag = New Cursor(thisExe.GetManifestResourceStream("Fusion.LineDrag.cur"))
    End Sub

    ''' <summary>
    ''' loads up and existing page
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Public Sub LoadPage(p As Page)

        '--------------------
        'detach the last page
        tmrUpdate.Enabled = False
        If _page IsNot Nothing Then
            Me.Save()
            _Items.Clear()
        End If


        '---------------------
        'load up the new page
        Me.AutoScrollMinSize = XHelper.Get(p.Node, "V_size", New Point(1000, 800))
        Me.AutoScrollPosition = New Point(0, 0)
        For xloop As Integer = 0 To p.Blocks.Count - 1
            Dim b As Block_UI = p.Blocks(xloop).GetUI
            _Items.Add(b)
            AddHandler b.ConnectorEvent, AddressOf ConnectorEvent
        Next
        For xloop As Integer = 0 To p.Wires.Count - 1
            Dim w As Wire_UI = p.Wires(xloop).GetUI
            _Items.Add(w)
            AddHandler w.MouseOverEvent, AddressOf WireEvent
        Next
        _page = p
        tmrUpdate.Enabled = True

    End Sub

    Public Sub Save()
        If _page IsNot Nothing Then
            XHelper.Set(_page.Node, "V_size", Me.AutoScrollMinSize)
            For xloop As Integer = 0 To _Items.Count - 1
                _Items(xloop).Save()
            Next
        End If
    End Sub

    ''' <summary>
    ''' returns the current page
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentPage() As Page
        Get
            Return _page
        End Get
    End Property

#Region "Adding/ removing items"

    ''' <summary>
    ''' varify the new item being dragged over is a BlockType
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Me_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        Dim str As String = e.Data.GetData(DataFormats.StringFormat)
        Dim bt As BlockType
        If [Enum].TryParse(Of BlockType)(str, bt) Then
            'valid dropping item
            e.Effect = DragDropEffects.Copy
        Else
            'bad format of dragged input
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' dropps a new item to the page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tpEdit_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        AddNewItem(e.Data.GetData(DataFormats.StringFormat), Me.PointToClient(New Point(e.X, e.Y)))
    End Sub

    ''' <summary>
    ''' adds a new item to the screen
    ''' </summary>
    ''' <param name="item">the item to try and parse</param>
    ''' <param name="location">the desired location for the new item, set to -1,-1 for default placement</param>
    ''' <remarks></remarks>
    Public Sub AddNewItem(item As String, location As Point)
        Dim bt As BlockType
        If [Enum].TryParse(Of BlockType)(item, bt) Then
            Dim b As Block = CurrentPage.AddBlock(bt)
            Dim bui As Block_UI = b.GetUI()
            If location.X = -1 AndAlso location.Y = -1 Then
                bui.Rect.X = (Me.Width - bui.Rect.Width) \ 2
                bui.Rect.Y = (Me.Height - bui.Rect.Height) \ 2
            Else
                bui.Rect.X = location.X - (bui.Rect.Width \ 2)
                bui.Rect.Y = location.Y - (bui.Rect.Height \ 2)
            End If
            If Me.AlignToGrid Then
                bui.Rect.X = RoundToGrid(bui.Rect.X)
                bui.Rect.Y = RoundToGrid(bui.Rect.Y)
            End If
            AdjustIfOutSideOfRegion(bui)
            bui.Save()
            Me._Items.Add(bui)
            AddHandler bui.ConnectorEvent, AddressOf ConnectorEvent
        End If
    End Sub

    ''' <summary>
    ''' cuts the currently selected items from the page
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cut()
        Dim c As New List(Of iBaseItem)
        For xloop As Integer = 0 To _Items.Count - 1
            _Items(xloop).Save()
            If _Items(xloop).selected Then
                If TypeOf _Items(xloop) Is Block_UI Then
                    With DirectCast(c(xloop), Block_UI)
                        c.Add(.Block)
                    End With
                ElseIf TypeOf c(xloop) Is Wire_UI Then
                    With DirectCast(c(xloop), Wire_UI)
                        c.Add(.Wire)
                    End With
                End If
            End If
        Next

        If c.Count > 0 Then
            Dim nd() As XmlNode = CurrentPage.Cut(c.ToArray)
            Dim x As XmlDocument = XHelper.CreateNewDocument("FusionPage")
            Dim root As XmlNode = x.SelectSingleNode("FusionPage")
            For xloop As Integer = 0 To nd.Length - 1
                nd(xloop) = x.ImportNode(nd(xloop), True)
                root.AppendChild(nd(xloop))
            Next
            Clipboard.SetText(x.OuterXml)
            'just incase there were some other wires no longer
            'connected (the page class would of cleared the broken
            'links), reload the page
            LoadPage(CurrentPage)
        End If
    End Sub

    ''' <summary>
    ''' copies the currently selected items from the page
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Copy()
        Dim c As New List(Of iBaseItem)
        For xloop As Integer = 0 To _Items.Count - 1
            _Items(xloop).Save()
            If _Items(xloop).selected Then
                If TypeOf _Items(xloop) Is Block_UI Then
                    With DirectCast(_Items(xloop), Block_UI)
                        c.Add(.Block)
                    End With
                ElseIf TypeOf _Items(xloop) Is Wire_UI Then
                    With DirectCast(_Items(xloop), Wire_UI)
                        c.Add(.Wire)
                    End With
                End If
            End If
        Next

        If c.Count > 0 Then
            Dim nd() As XmlNode = CurrentPage.Copy(c.ToArray)
            Dim x As XmlDocument = XHelper.CreateNewDocument("FusionPage")
            Dim root As XmlNode = x.SelectSingleNode("FusionPage")
            For xloop As Integer = 0 To nd.Length - 1
                nd(xloop) = x.ImportNode(nd(xloop), True)
                root.AppendChild(nd(xloop))
            Next
            Clipboard.SetText(x.OuterXml)
            'just incase there were some other wires no longer
            'connected (the page class would of cleared the broken
            'links), reload the page
            LoadPage(CurrentPage)
        End If
    End Sub

    ''' <summary>
    ''' pastes the current stored items from the clipboard
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Paste()
        Dim lst() As XmlNode = CheckClipBoardForNode()
        If lst.Count > 0 Then
            CurrentPage.Paste(lst)
            'just incase there were some other wires no longer
            'connected (the page class would of cleared the broken
            'links), reload the page
            LoadPage(CurrentPage)
        End If

    End Sub

    ''' <summary>
    ''' checks to see if there is an xmlnode in the clipboard
    ''' and returns if it does
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckClipBoardForNode() As XmlNode()
        Dim ret As New List(Of XmlNode)
        If Clipboard.ContainsText Then
            Dim t As New XmlDocument
            Try
                t.LoadXml(Clipboard.GetText)
                Dim b As XmlNode = t.SelectSingleNode("FusionPage")
                If b IsNot Nothing Then
                    For Each ch As XmlNode In b
                        ret.Add(ch)
                    Next
                End If

            Catch ex As Exception
                'failed to load the xml
            End Try
        End If

        Return ret.ToArray
    End Function

    ''' <summary>
    ''' deletes the current selected items
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Delete()
        Dim c As New List(Of i_UIelement)
        For xloop As Integer = 0 To _Items.Count - 1
            _Items(xloop).Save()
            If _Items(xloop).selected Then c.Add(_Items(xloop))
        Next

        If c.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete these items?", "Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                For xloop As Integer = 0 To c.Count - 1
                    If TypeOf c(xloop) Is Block_UI Then
                        With DirectCast(c(xloop), Block_UI)
                            Me.CurrentPage.RemoveBlock(.Block)
                            Me._Items.Remove(.Block.GetUI)
                        End With
                    ElseIf TypeOf c(xloop) Is Wire_ui Then
                        With DirectCast(c(xloop), Wire_UI)
                            Me.CurrentPage.RemoveWire(.Wire)
                        End With
                    End If
                Next
                'just incase there were some other wires no longer
                'connected (the page class would of cleared the broken
                'links), reload the page
                LoadPage(CurrentPage)
            End If
        End If
    End Sub


    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Paste()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete()
    End Sub

    Private Sub ProperitesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProperitesToolStripMenuItem.Click
        PageDesigner_MouseDoubleClick(Me, New System.Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Right, 1, _popupLocation.X, _popupLocation.Y, 0))
    End Sub


#End Region

#Region "Props"

    ''' <summary>
    ''' the current wire style
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Wire_Style() As WireStyle

    ''' <summary>
    ''' if to align the items to a grid
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignToGrid() As Boolean

    ''' <summary>
    ''' if to show the grid
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowGrid() As Boolean

    ''' <summary>
    ''' the grid size
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridSize() As Integer

    ''' <summary>
    ''' if to show the left rectangle for inputs
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowInputsBlock() As Boolean

    ''' <summary>
    ''' if to show the right rectangle for outputs
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowOutputsBlock() As Boolean

    ''' <summary>
    ''' gets or sets visible working area of the current page
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PageSize() As Size
        Get
            Return Me.AutoScrollMinSize
        End Get
        Set(value As Size)
            Me.AutoScrollMinSize = value
            Me.AutoScrollPosition = New Point(0, 0)
            For xloop As Integer = 0 To _Items.Count - 1
                If TypeOf _Items(xloop) Is Block_UI Then
                    AdjustIfOutSideOfRegion(_Items(xloop))
                End If
            Next
        End Set
    End Property

#End Region

    ''' <summary>
    ''' forces the screen to update
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrUpdate_Tick(sender As Object, e As EventArgs) Handles tmrUpdate.Tick
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' renders the screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        MyBase.OnPaint(e)

        e.Graphics.FillRectangle(Brushes.LightGray, New Rectangle(0, 0, Me.Width, Me.Height))
        Dim rx As New Rectangle(0, 0, Me.AutoScrollMinSize.Width, Me.AutoScrollMinSize.Height)
        If Not Me.Enabled Then
            e.Graphics.FillRectangle(Brushes.LightGray, rx)
        Else
            e.Graphics.FillRectangle(Brushes.White, rx)
        End If
        e.Graphics.DrawRectangle(Pens.Gray, rx)

        'draw the grid if it's enabled
        If ShowGrid Then GridPaint(e.Graphics)

        'show the input and output container blocks
        If ShowInputsBlock Then
            Dim r As New Rectangle(5, 15, 58, Me.AutoScrollMinSize.Height - 20)
            Using rg As GraphicsPath = Draw.RoundedRectangle(r, 5, 0, Draw.rrCor.All), b As New Pen(Color.FromArgb(100, Color.DimGray), 2)
                e.Graphics.DrawPath(b, rg)
                Using stf As New StringFormat
                    stf.Alignment = StringAlignment.Center
                    stf.LineAlignment = StringAlignment.Center
                    Dim tr As New Rectangle(5, 0, r.Width, 15)
                    e.Graphics.DrawString("Inputs", Me.Font, Brushes.Black, tr, stf)
                End Using
            End Using

        End If

        If ShowOutputsBlock Then
            Dim r As New Rectangle(Me.AutoScrollMinSize.Width - 63, 15, 58, Me.AutoScrollMinSize.Height - 20)
            Using rg As GraphicsPath = Draw.RoundedRectangle(r, 5, 0, Draw.rrCor.All), b As New Pen(Color.FromArgb(100, Color.DimGray), 2)
                e.Graphics.DrawPath(b, rg)
                Using stf As New StringFormat
                    stf.Alignment = StringAlignment.Center
                    stf.LineAlignment = StringAlignment.Center
                    Dim tr As New Rectangle(Me.AutoScrollMinSize.Width - 63, 0, r.Width, 15)
                    e.Graphics.DrawString("Outputs", Me.Font, Brushes.Black, tr, stf)
                End Using
            End Using
        End If

        '---------------------------------------
        'draws all the items on the screen
        For xloop As Integer = 0 To _Items.Count - 1
            _Items(xloop).Paint(e.Graphics, Me.Font, myProject.isRunning, Me.AutoScrollPosition)
        Next

        '----------------------------------------
        'draw the current 'pulling' wire using the
        'current wire style settings
        If _CurrentStartConnector IsNot Nothing Then
            Using l As New Pen(Me.Wire_Style.Color, Me.Wire_Style.Size)
                l.DashStyle = Me.Wire_Style.style
                l.EndCap = LineCap.RoundAnchor
                e.Graphics.DrawLine(l, _CurrentStartConnector.StartPoint, Me.PointToClient(MousePosition))
            End Using
        End If

        '-----------------------------------------
        'if we are drawing a slection box, draw
        'it with the current wire style settings
        If _MousePossibleSelectBox Then
            Dim xrec As Rectangle = Draw.GetRecFrmPts(_mouseCurrentPos, _MouseDownOffset)
            Using l As New Pen(Me.Wire_Style.Color, Me.Wire_Style.Size)
                l.DashStyle = Me.Wire_Style.style
                l.EndCap = LineCap.RoundAnchor
                e.Graphics.DrawRectangle(l, xrec)
            End Using
        End If

    End Sub

    ''' <summary>
    ''' paints the grid
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Private Sub GridPaint(g As Graphics)
        Dim rows As Integer = (Me.AutoScrollMinSize.Height \ GridSize) - 1
        Dim cols As Integer = (Me.AutoScrollMinSize.Width \ GridSize) - 1
        Using p As New Pen(Color.FromArgb(150, Color.LightBlue))
            For yloop As Integer = 0 To rows + 1
                g.DrawLine(p, vPoint(0, yloop * GridSize), vPoint(Me.AutoScrollMinSize.Width, yloop * GridSize))
            Next
            For xloop As Integer = 0 To cols + 1
                g.DrawLine(p, vPoint(xloop * GridSize, 0), vPoint(xloop * GridSize, Me.AutoScrollMinSize.Height))
            Next
            g.DrawRectangle(p, New Rectangle(Me.AutoScrollPosition, Me.AutoScrollMinSize))
        End Using
    End Sub

    ''' <summary>
    ''' translates the real position to the virtual positon with the slidebars
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function vPoint(x As Integer, y As Integer) As Point
        x += Me.AutoScrollPosition.X
        y += Me.AutoScrollPosition.Y
        Return New Point(x, y)
    End Function

    ''' <summary>
    ''' translates the real position to the virtual positon with the slidebars
    ''' </summary>
    ''' <param name="p"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function vPoint(p As Point) As Point
        Return vPoint(p.X, p.Y)
    End Function

    ''' <summary>
    ''' returns the point of location for the connector
    ''' </summary>
    ''' <param name="con"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPointFromConnector(con As Connector) As Point
        Dim ret As Point
        Dim b As Block_UI = con.Owner.GetUI
        ret = b.GetPointForConnector(con)
        Return ret
    End Function

#Region "Mouse related stuff"

    ''' <summary>
    ''' updates all the controls for mousedown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'update all the items for the mousedown event
        Dim dwnItem As i_UIelement = Nothing
        For xloop As Integer = 0 To _Items.Count - 1
            If _Items(xloop).MouseDown(e, _ctrl) Then dwnItem = _Items(xloop)
        Next

        '------------------------------------------------
        'if we found an item and the inner area was clicked on
        'then we select it, but if the control key as pressed
        'then it toggles the selection. if no item was found
        'or misses one of the tests then all the items are 
        'unselected unless the control key was pressed
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim ht As HitTestType = HitTestType.None
            If dwnItem IsNot Nothing Then ht = dwnItem.HitTest(New Point(e.X, e.Y))
            If ht = HitTestType.BlockInnerRec Or ht = HitTestType.Wire Then
                _MouseDownOffset = New Point(e.X, e.Y)
                _MousePossibleMove = True
                If _ctrl Then
                    dwnItem.selected = Not dwnItem.selected
                ElseIf Not dwnItem.selected Then
                    For xloop As Integer = 0 To _Items.Count - 1
                        _Items(xloop).selected = False
                    Next
                    dwnItem.selected = True
                End If
            Else
                _MousePossibleMove = False
                If Not _ctrl Then
                    For xloop As Integer = 0 To _Items.Count - 1
                        _Items(xloop).selected = False
                    Next
                End If
            End If
        End If


        '-------------------------------------------------
        'didn't find anything under the mouse down, so this
        'could be a selection rectangle starting
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso dwnItem Is Nothing Then
            _MousePossibleSelectBox = True
            _MouseDownOffset = New Point(e.X, e.Y)
        End If

    End Sub

    ''' <summary>
    ''' updates the items for mousemove
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim fnd As New List(Of i_UIelement)
        'update the items on the screen for the mousemove
        For xloop As Integer = 0 To _Items.Count - 1
            Dim ret As Boolean = _Items(xloop).MouseMove(e)
            If ret Then fnd.Add(_Items(xloop))
        Next

        '-------------------------------------------------
        'update the current selected item(s) when moving 
        'them around the screen
        Dim wrs As New List(Of Wire)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If _MousePossibleMove Then
                Dim diff As New Point(_MouseDownOffset.X - e.X, _MouseDownOffset.Y - e.Y)
                For xloop As Integer = 0 To _Items.Count - 1
                    If TypeOf _Items(xloop) Is Block_UI AndAlso _Items(xloop).selected Then
                        With DirectCast(_Items(xloop), Block_UI)
                            .Rect.X -= diff.X
                            .Rect.Y -= diff.Y
                            'check to make sure the item is still with in the region
                            AdjustIfOutSideOfRegion(_Items(xloop))

                            'force the updateing of any of the wires
                            Dim c() As Connector = .Block.Allconnectors
                            For yloop As Integer = 0 To c.Length - 1
                                If c(yloop).isUsed AndAlso Not wrs.Contains(c(yloop).Wire) Then wrs.Add(c(yloop).Wire)
                            Next
                        End With
                    End If
                Next
                For xloop As Integer = 0 To wrs.Count - 1
                    Dim cui As Wire_UI = wrs(xloop).GetUI
                    cui.ReconnectPointEnds(AddressOf GetPointFromConnector)
                Next

                _MouseDownOffset = New Point(e.X, e.Y)
            End If

            Me.Invalidate()
        End If
        _mouseCurrentPos = New Point(e.X, e.Y)
    End Sub

    ''' <summary>
    ''' if outside of the page region, adjust to put it backin
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Private Sub AdjustIfOutSideOfRegion(item As Block_UI)
        Dim r As New Rectangle(0, 0, Me.AutoScrollMinSize.Width, Me.AutoScrollMinSize.Height)
        With item


            If .Rect.Right > r.Right Then .Rect.X = r.Right - .Rect.Width
            If .Rect.Bottom > r.Bottom Then .Rect.Y = r.Bottom - .Rect.Height
            If .Rect.X < 0 Then .Rect.X = 0
            If .Rect.Y < 0 Then .Rect.Y = 0


            .UpdateRectangles()
        End With


    End Sub

    ''' <summary>
    ''' rounds the block(s) x, or y values to
    ''' fit to the grid (closest location)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RoundToGrid(value As Integer) As Integer
        Dim mid As Double = GridSize / 2
        Dim v As Integer = value Mod GridSize
        If v > mid Then
            'closer to the upper number
            Return (value - v) + GridSize
        Else
            'closer to the lower number
            Return value - v
        End If
    End Function

    ''' <summary>
    ''' handles the mouse up events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        'up date all the items for the mouseup event
        Dim clickItem As i_UIelement = Nothing
        For xloop As Integer = 0 To _Items.Count - 1
            If _Items(xloop).MouseUp(e) Then clickItem = _Items(xloop)
        Next

        '------------------------------------------
        'if there was no connector under the 
        'mouse when the up was issued this means
        'is was a canceled event
        If clickItem Is Nothing Then
            _CurrentStartConnector = Nothing
            Me.Cursor = Cursors.Default
        End If



        '------------------------------------------
        'if we were drawing a selection square
        'then find all the items within the square
        'and mark them selected
        If _MousePossibleSelectBox Then
            Dim xrec As Rectangle = Draw.GetRecFrmPts(_mouseCurrentPos, _MouseDownOffset)
            For xloop As Integer = 0 To _Items.Count - 1
                If TypeOf _Items(xloop) Is Block_UI Then
                    With DirectCast(_Items(xloop), Block_UI)
                        Dim trec As Rectangle = .Rect
                        trec.Location = vPoint(trec.Location)
                        If trec.IntersectsWith(xrec) Then
                            .selected = True
                        End If
                    End With
                End If
            Next
            _MousePossibleSelectBox = False
        End If

        '--------------------------------------------
        'if we were moving any items, and the aligntogrid
        'was checked then readjust all the items to match with the
        'current grid
        Dim wrs As New List(Of Wire)
        If _MousePossibleMove Then
            For xloop As Integer = 0 To _Items.Count - 1
                If TypeOf _Items(xloop) Is Block_UI AndAlso _Items(xloop).selected Then
                    With DirectCast(_Items(xloop), Block_UI)
                        If AlignToGrid Then
                            .Rect.X = RoundToGrid(.Rect.X)
                            .Rect.Y = RoundToGrid(.Rect.Y)
                            .UpdateRectangles()
                        End If
                        'force the updateing of any of the wires
                        Dim c() As Connector = .Block.Allconnectors
                        For yloop As Integer = 0 To c.Length - 1
                            If c(yloop).isUsed AndAlso Not wrs.Contains(c(yloop).Wire) Then wrs.Add(c(yloop).Wire)
                        Next

                    End With
                End If
            Next
            For xloop As Integer = 0 To wrs.Count - 1
                Dim cui As Wire_UI = wrs(xloop).GetUI
                cui.ReconnectPointEnds(AddressOf GetPointFromConnector)
            Next
            _MousePossibleMove = False
        End If


        If e.Button = Windows.Forms.MouseButtons.Right Then
            _popupLocation = New Point(e.X, e.Y)

            Dim itms As New List(Of i_UIelement)
            For xloop As Integer = 0 To _Items.Count - 1
                If _Items(xloop).selected Then itms.Add(_Items(xloop))
            Next
            Dim lst() As XmlNode = CheckClipBoardForNode()

            CutToolStripMenuItem.Enabled = itms.Count > 0
            CopyToolStripMenuItem.Enabled = itms.Count > 0
            PasteToolStripMenuItem.Enabled = lst.Count > 0
            DeleteToolStripMenuItem.Enabled = itms.Count > 0
            ProperitesToolStripMenuItem.Enabled = itms.Count = 1
            cms.Show(Me, e.X, e.Y)
        End If
    End Sub

    ''' <summary>
    ''' for opening up the property page for the selected item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick

        Dim clickItem As i_UIelement = Nothing
        For xloop As Integer = 0 To _Items.Count - 1
            If _Items(xloop).HitTest(New Point(e.X, e.Y)) Then
                clickItem = _Items(xloop)
                Exit For
            End If
        Next
        If clickItem IsNot Nothing AndAlso myProject.isRunning = False Then
            If _propSettings Is Nothing Then
                _propSettings = New ItemSettings()
                _propSettings.Show(Me)
            End If
            _propSettings.LoadControl(clickItem.GetPropertyPageType)
            _propSettings.BringToFront()
        End If


    End Sub

    ''' <summary>
    ''' for capturing key events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Control = False Then _ctrl = False
    End Sub

    ''' <summary>
    ''' for capturing key events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageDesigner_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Control = False Then _ctrl = True
    End Sub

    Private Sub WireEvent(sender As Wire_UI, args As WireOverArgs, pt As Point)
        Select Case args
            Case WireOverArgs.None
                Me.Cursor = Cursors.Default
            Case WireOverArgs.Vertical
                Me.Cursor = Cursors.SizeWE
            Case WireOverArgs.Horizontal
                Me.Cursor = Cursors.SizeNS
        End Select
    End Sub

    ''' <summary>
    ''' events sent from a block
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="theConnector"></param>
    ''' <param name="Args"></param>
    ''' <remarks></remarks>
    Private Sub ConnectorEvent(sender As Block_UI, theConnector As Connector, Args As ConnectorEventArgs, pt As Point)
        If Args = ConnectorEventArgs.Over Then
            If _CurrentStartConnector Is Nothing AndAlso Not theConnector.isInput Then
                Me.Cursor = _cur_connect
            ElseIf _CurrentStartConnector IsNot Nothing AndAlso theConnector.isInput Then
                If theConnector.isUsed Or theConnector.isDigital <> _CurrentStartConnector.StartConnector.isDigital Then
                    Me.Cursor = _cur_noconnect
                Else
                    Me.Cursor = _cur_connect '_cur_lineDrag
                End If
            End If
        ElseIf Args = ConnectorEventArgs.Leave Then
            If _CurrentStartConnector IsNot Nothing Then
                Me.Cursor = _cur_lineDrag
            Else
                Me.Cursor = Cursors.Default
            End If

        ElseIf Args = ConnectorEventArgs.Down Then
            If Not theConnector.isInput Then
                _CurrentStartConnector = New NewLineOptions()
                _CurrentStartConnector.StartConnector = theConnector
                _CurrentStartConnector.StartPoint = pt
            End If
        Else 'Args = ConnectorEventArgs.Up
            If theConnector.isInput AndAlso _CurrentStartConnector IsNot Nothing AndAlso
                Not theConnector.isUsed AndAlso theConnector.isDigital = _CurrentStartConnector.StartConnector.isDigital Then
                If _CurrentStartConnector.StartConnector.isUsed Then
                    _CurrentStartConnector.StartConnector.Wire.To.Add(theConnector)
                    DirectCast(_CurrentStartConnector.StartConnector.Wire.GetUI, Wire_UI).ReconnectPointEnds(AddressOf GetPointFromConnector)
                Else
                    Dim w As Wire = CurrentPage.AddWire(_CurrentStartConnector.StartConnector, theConnector)
                    Dim ex As Wire_UI = w.GetUI
                    ex.Wire_style.Color = Wire_Style.Color
                    ex.Wire_style.style = Wire_Style.style
                    ex.Wire_style.Size = Wire_Style.Size
                    ex.ReconnectPointEnds(AddressOf GetPointFromConnector)
                    Me._Items.Add(ex)
                    AddHandler ex.MouseOverEvent, AddressOf WireEvent
                End If
                _CurrentStartConnector = Nothing
            End If
        End If
    End Sub

#End Region

    Private Sub _propSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles _propSettings.FormClosing
        _propSettings = Nothing
    End Sub

End Class

Public Class NewLineOptions
    Public StartConnector As Connector
    Public StartPoint As Point

End Class
