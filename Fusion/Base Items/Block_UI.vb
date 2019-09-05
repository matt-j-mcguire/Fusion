Public Enum ConnectorEventArgs
    Down
    Up
    Over
    Leave
End Enum

Public Class Block_UI
    Implements i_UIelement


    Protected m_item As Block
    Protected m_ui_nd As XmlNode
    Protected m_inputRecs() As Rectangle
    Protected m_outputRecs() As Rectangle
    Protected m_innerRec As Rectangle
    Private _lastMouseOverConnector As Connector
    Private _vOffset As Point
    Private _vRect As Rectangle

    Public Event ConnectorEvent(sender As Block_UI, theConnector As Connector, Args As ConnectorEventArgs, pt As Point)

    Public Sub New(theItem As Block)
        m_item = theItem

        m_ui_nd = m_item.node.SelectSingleNode("UI")
        If m_ui_nd Is Nothing Then m_ui_nd = XHelper.NodeAppendNew(m_item.node, "UI")
        ReloadUIPoints()


    End Sub

    Public Sub ReloadUIPoints()
        'find out what the default size should be (min 32x48)
        Dim inx As Integer = m_item.InputConnectors.Length
        Dim outx As Integer = m_item.OutputConnectors.Length
        Dim cnt As Integer = Math.Max(inx, outx)
        Rect.Height = (20 * cnt) + 10
        If Rect.Height < 32 Then Rect.Height = 32
        Rect.Width = 68
        Rect.Location = XHelper.Get(m_ui_nd, "Location", New Point(0, 0))
        ReDim m_inputRecs(inx - 1)
        ReDim m_outputRecs(outx - 1)
        UpdateRectangles()
    End Sub

    ''' <summary>
    ''' saves settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save() Implements i_UIelement.Save
        XHelper.Set(m_ui_nd, "Location", Rect.Location)
        m_item.Save()
    End Sub

    ''' <summary>
    ''' updates all the rectangles
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateRectangles()
        _vRect = New Rectangle(_vOffset.X + Rect.X, _vOffset.Y + Rect.Y, Rect.Width, Rect.Height)
        m_innerRec = New Rectangle(_vRect.X + 10, _vRect.Y, 48, _vRect.Height)
        'to space it evenly add one to the count divide into
        'total height
        Dim top As Integer = (m_innerRec.Height - ((m_inputRecs.Length * 20) - 10)) / 2
        For xloop As Integer = 0 To m_inputRecs.Length - 1
            m_inputRecs(xloop) = New Rectangle(m_innerRec.X - 10, m_innerRec.Y + top + (20 * xloop), 10, 8)
        Next
        top = (m_innerRec.Height - ((m_outputRecs.Length * 20) - 10)) / 2
        For xloop As Integer = 0 To m_outputRecs.Length - 1
            m_outputRecs(xloop) = New Rectangle(m_innerRec.Right, m_innerRec.Y + top + (20 * xloop), 10, 8)
        Next
    End Sub

    ''' <summary>
    ''' the block item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Block() As Block
        Get
            Return m_item
        End Get
    End Property

    ''' <summary>
    ''' if the point falls within this block and all connectors
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns>true if within area</returns>
    ''' <remarks></remarks>
    Public Function HitTest(e As Point) As HitTestType Implements i_UIelement.HitTest
        Dim ret As HitTestType = HitTestType.None
        If _vRect.Contains(e.X, e.Y) Then
            ret = HitTestType.Block
            If m_innerRec.Contains(e.X, e.Y) Then
                ret = HitTestType.BlockInnerRec
            Else
                For xloop As Integer = 0 To m_inputRecs.Length - 1
                    If m_inputRecs(xloop).Contains(e.X, e.Y) Then
                        ret = HitTestType.BlockConnectorInput
                        Exit For
                    End If
                Next
                For xloop As Integer = 0 To m_outputRecs.Length - 1
                    If m_outputRecs(xloop).Contains(e.X, e.Y) Then
                        ret = HitTestType.BlockConnectorOutput
                        Exit For
                    End If
                Next
            End If
        End If
        Return ret
    End Function

    ''' <summary>
    ''' for handling mouse down event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Function MouseDown(e As MouseEventArgs, ctrl As Boolean) As Boolean Implements i_UIelement.MouseDown
        Dim ret As Boolean = False
        If Me._vRect.Contains(e.X, e.Y) Then
            ret = True
            'check for the connector under the mouse
            Dim c As Connector = Me.GetConnectorUnderPoint(New Point(e.X, e.Y))
            If c IsNot Nothing Then RaiseEvent ConnectorEvent(Me, c, ConnectorEventArgs.Down, New Point(e.X, e.Y))
        End If
        Return ret
    End Function

    ''' <summary>
    ''' for handling mouse movements
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Function MouseMove(e As MouseEventArgs) As Boolean Implements i_UIelement.MouseMove
        Dim ret As Boolean = False
        Dim c As Connector = Nothing
        If Me._vRect.Contains(e.X, e.Y) Then
            'check for the connector under the mouse
            c = Me.GetConnectorUnderPoint(New Point(e.X, e.Y))
        End If

        If c IsNot Nothing Then
            RaiseEvent ConnectorEvent(Me, c, ConnectorEventArgs.Over, New Point(e.X, e.Y))
            _lastMouseOverConnector = c
        ElseIf _lastMouseOverConnector IsNot Nothing Then
            RaiseEvent ConnectorEvent(Me, c, ConnectorEventArgs.Leave, New Point(e.X, e.Y))
            _lastMouseOverConnector = Nothing
        End If

        Return ret
    End Function

    ''' <summary>
    ''' for handling mouse up event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Function MouseUp(e As MouseEventArgs) As Boolean Implements i_UIelement.MouseUp
        Dim ret As Boolean = False
        If Me._vRect.Contains(e.X, e.Y) Then
            'check for the connector under the mouse
            Dim c As Connector = Me.GetConnectorUnderPoint(New Point(e.X, e.Y))
            If c IsNot Nothing Then RaiseEvent ConnectorEvent(Me, c, ConnectorEventArgs.Up, New Point(e.X, e.Y))
        End If
        Return ret
    End Function

    ''' <summary>
    ''' moves the block
    ''' </summary>
    ''' <param name="offset"></param>
    ''' <remarks></remarks>
    Public Sub MoveItem(offset As Point)
        Rect.X += offset.X
        Rect.Y += offset.Y
        UpdateRectangles()
    End Sub

    ''' <summary>
    ''' returns what connector is under the point
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns>returns nothing is not found</returns>
    ''' <remarks></remarks>
    Public Function GetConnectorUnderPoint(e As Point) As Connector
        Dim ret As Connector = Nothing

        For xloop As Integer = 0 To m_inputRecs.Length - 1
            If m_inputRecs(xloop).Contains(e.X, e.Y) Then
                ret = m_item.InputConnectors(xloop)
                Exit For
            End If
        Next
        If ret Is Nothing Then
            For xloop As Integer = 0 To m_outputRecs.Length - 1
                If m_outputRecs(xloop).Contains(e.X, e.Y) Then
                    ret = m_item.OutputConnectors(xloop)
                    Exit For
                End If
            Next
        End If

        Return ret
    End Function

    ''' <summary>
    ''' returns the connector point, without the offset applied
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPointForConnector(c As Connector) As Point
        Dim ret As Point
        Dim index As Integer = m_item.IndexOf(c)
        If c.isInput Then
            ret = New Point(m_inputRecs(index).X, m_inputRecs(index).Y + 4)
        Else
            ret = New Point(m_outputRecs(index).Right, m_outputRecs(index).Y + 4)
        End If
        ret.X -= _vOffset.X
        ret.Y -= _vOffset.Y

        Return ret
    End Function

    ''' <summary>
    ''' paints the item to the screen
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Public Sub Paint(g As Graphics, fnt As Font, running As Boolean, OrigionOffset As Point) Implements i_UIelement.Paint
        _vOffset = OrigionOffset
        UpdateRectangles()

        'draw the input and output connectors
        For xloop As Integer = 0 To m_inputRecs.Length - 1
            If m_item.InputConnectors(xloop).isDigital Then
                Using b As New LinearGradientBrush(m_inputRecs(xloop), Color.DarkGray, Color.White, 90)
                    b.SetBlendTriangularShape(0.5)
                    g.FillRectangle(b, m_inputRecs(xloop))
                End Using
            Else
                Using b As New LinearGradientBrush(m_inputRecs(xloop), Color.Blue, Color.White, 90)
                    b.SetBlendTriangularShape(0.5)
                    g.FillRectangle(b, m_inputRecs(xloop))
                End Using
            End If
            g.DrawRectangle(Pens.DimGray, m_inputRecs(xloop))
            'draw the connector label below the connector
            Dim txt As String = m_item.InputConnectors(xloop).Name & If(running, " - " & m_item.InputConnectors(xloop).ValueAsString, "")
            Dim sz As SizeF = g.MeasureString(txt, fnt)
            Dim p As New Point(m_innerRec.X - (sz.Width + 2), m_inputRecs(xloop).Bottom)
            g.DrawString(txt, fnt, Brushes.DimGray, p)
        Next
        For xloop As Integer = 0 To m_outputRecs.Length - 1
            If m_item.OutputConnectors(xloop).isDigital Then
                Using b As New LinearGradientBrush(m_outputRecs(xloop), Color.DarkGray, Color.White, 90)
                    b.SetBlendTriangularShape(0.5)
                    g.FillRectangle(b, m_outputRecs(xloop))
                End Using
            Else
                Using b As New LinearGradientBrush(m_outputRecs(xloop), Color.Blue, Color.White, 90)
                    b.SetBlendTriangularShape(0.5)
                    g.FillRectangle(b, m_outputRecs(xloop))
                End Using
            End If
            g.DrawRectangle(Pens.DimGray, m_outputRecs(xloop))
            'draw the connector label below the connector
            Dim txt As String = m_item.OutputConnectors(xloop).Name & If(running, " - " & m_item.OutputConnectors(xloop).ValueAsString, "")
            Dim p As New Point(m_innerRec.Right + 2, m_outputRecs(xloop).Bottom)
            g.DrawString(txt, fnt, Brushes.DimGray, p)
        Next

        'draw the block box, and if there is a userlable, draw it also above the box
        Using stf As New StringFormat
            stf.Alignment = StringAlignment.Center
            If Not String.IsNullOrEmpty(m_item.UserLabel) Then
                Dim above As New Rectangle(Me._vRect.X, Me._vRect.Y - 12, Me._vRect.Width, 12)
                g.DrawString(m_item.UserLabel, fnt, Brushes.Black, above, stf)
            End If

            Dim sc As Color = If(selected, Color.Olive, Color.LightGray)
            Dim ec As Color = If(selected, Color.Yellow, Color.White)
            Using pth As GraphicsPath = Draw.RoundedRectangle(m_innerRec, 5, 0, Draw.rrCor.All), b As New LinearGradientBrush(m_innerRec, sc, ec, 0)
                b.SetBlendTriangularShape(0.5, 0.9)
                g.FillPath(b, pth)
                g.DrawPath(Pens.DimGray, pth)
            End Using



            Dim sz As SizeF = g.MeasureString(m_item.TextForBlock_UI, fnt, Me._vRect.Width)
            Dim tp As Integer = Me._vRect.Y + (Me._vRect.Height - (sz.Height + 16)) / 2
            Dim rrect As New Rectangle(m_innerRec.X, tp + 16, m_innerRec.Width, sz.Height)
            g.DrawImage(m_item.GetIcon, m_innerRec.X + (m_innerRec.Width - 16) \ 2, tp)
            g.DrawString(m_item.TextForBlock_UI, fnt, Brushes.Black, rrect, stf)
        End Using

    End Sub

    ''' <summary>
    ''' if currently selected or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property selected As Boolean Implements i_UIelement.selected

    ''' <summary>
    ''' this is the location rectangle for it's point on the screen
    ''' </summary>
    ''' <remarks></remarks>
    Public Rect As Rectangle

    ''' <summary>
    ''' returns the property page for this block
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPropertyPageType() As BaseItemProp Implements i_UIelement.GetPropertyPageType
        Return Block.GetPropsPage
    End Function

End Class
