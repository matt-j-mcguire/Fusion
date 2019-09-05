Public Enum WireOverArgs
    None = 0
    Horizontal = 1
    Vertical = 2
End Enum


Public Class Wire_UI
    Implements i_UIelement

    Public Delegate Function PointFromConnector(con As Connector) As Point

    Public Event MouseOverEvent(sender As Wire_UI, Args As WireOverArgs, pt As Point)

    ''' <summary>
    ''' like the point structure but a instance class
    ''' </summary>
    ''' <remarks></remarks>
    Private Class PointX
        Public Sub New()
        End Sub

        Public Sub New(NewX As Integer, NewY As Integer)
            X = NewX
            Y = NewY
        End Sub

        Public X As Integer
        Public Y As Integer

        Public Shared Widening Operator CType(p As PointX) As Point
            Return New Point(p.X, p.Y)
        End Operator

        Public Shared Narrowing Operator CType(p As Point) As PointX
            Return New PointX(p.X, p.Y)
        End Operator
        Public ReadOnly Property IsValid() As Boolean
            Get
                If X = 0 AndAlso Y = 0 Then Return False Else Return True
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return "x=" & X & " | y=" & Y
        End Function

    End Class

    ''' <summary>
    ''' holds an array of points
    ''' </summary>
    ''' <remarks></remarks>
    Private Class pts
        ''' <summary>
        ''' 6 points to anywhere
        ''' </summary>
        ''' <remarks></remarks>
        Private _itms(5) As PointX

        Public Sub New()
            For xloop As Integer = 0 To 5
                _itms(xloop) = New PointX
            Next
        End Sub

        ''' <summary>
        ''' gets or setts a point for one of the six points available
        ''' </summary>
        ''' <param name="index">0-5</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public Property Item(index As Integer) As PointX
            Get
                If index > -1 AndAlso index < 6 Then
                    Return _itms(index)
                Else
                    Throw New IndexOutOfRangeException()
                End If
            End Get
            Set(value As PointX)
                If index > -1 AndAlso index < 6 Then
                    _itms(index) = value
                Else
                    Throw New IndexOutOfRangeException()
                End If
            End Set
        End Property

        ''' <summary>
        ''' gets or sets the first point
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property First() As PointX
            Get
                Return _itms(0)
            End Get
            Set(value As PointX)
                _itms(0) = value
            End Set
        End Property

        ''' <summary>
        ''' gets or setts the last point
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Last() As PointX
            Get
                Return _itms(5)
            End Get
            Set(value As PointX)
                _itms(5) = value
            End Set
        End Property

        ''' <summary>
        ''' gets the array
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property toArray() As Point()
            Get
                Dim ret(5) As Point
                For xloop As Integer = 0 To 5
                    ret(xloop) = _itms(xloop)
                Next
                Return ret
            End Get
        End Property

        ''' <summary>
        ''' returns the count of items
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Count() As Integer
            Get
                Return 6
            End Get
        End Property

    End Class

    Private _item As Wire
    Private _ui_nd As XmlNode
    Private _wireStyle As WireStyle
    Private _Wires As List(Of pts)
    Private _vOffset As Point
    Private _lastOver As WireOverArgs
    Private _lastWire As Integer
    Private _lastWireSection As Integer

    Public Sub New(item As Wire)
        _item = item

        _ui_nd = _item.node.SelectSingleNode("UI")
        If _ui_nd Is Nothing Then _ui_nd = XHelper.NodeAppendNew(_item.node, "UI")

        'get the stored props for wire style
        _wireStyle = New WireStyle
        _wireStyle.Size = XHelper.Get(_ui_nd, "WireSize", 1)
        _wireStyle.style = XHelper.Get(_ui_nd, "WireStyle", DashStyle.Solid)
        _wireStyle.Color = XHelper.Get(_ui_nd, "WireColor", WireColor.Black)

        'get the stored arrays of points for the wires
        _Wires = New List(Of pts)
        For xloop As Integer = 0 To item.To.Count - 1
            Dim nd As XmlNode = _ui_nd.SelectSingleNode("Wire" & xloop & "Pts")
            If nd Is Nothing Then nd = XHelper.NodeAppendNew(_ui_nd, "Wire" & xloop & "Pts")
            Dim p As New pts
            For yloop As Integer = 0 To p.Count - 1
                p(yloop) = XHelper.Get(nd, "P" & yloop, New Point(0, 0))
            Next
            _Wires.Add(p)
        Next
    End Sub

    ''' <summary>
    ''' saves the settings back to the node
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save() Implements i_UIelement.Save
        XHelper.Set(_ui_nd, "WireSize", _wireStyle.Size)
        XHelper.Set(_ui_nd, "WireStyle", _wireStyle.style)
        XHelper.Set(_ui_nd, "WireColor", _wireStyle.Color)
        For xloop As Integer = 0 To _Wires.Count - 1
            Dim nd As XmlNode = _ui_nd.SelectSingleNode("Wire" & xloop & "Pts")
            If nd Is Nothing Then nd = XHelper.NodeAppendNew(_ui_nd, "Wire" & xloop & "Pts")
            For yloop As Integer = 0 To _Wires(xloop).Count - 1
                XHelper.Set(nd, "P" & yloop, _Wires(xloop).Item(yloop))
            Next
        Next
        _item.Save()
    End Sub

    ''' <summary>
    ''' the page designer calls this to tell it to reconnect up the ends
    ''' </summary>
    ''' <param name="adr">some call back ability to find a connector's screen location</param>
    ''' <remarks></remarks>
    Public Sub ReconnectPointEnds(adr As PointFromConnector)
        Dim newitemflag As Boolean = False
        If _item.To.Count < _Wires.Count Then _Wires.RemoveAt(_Wires.Count - 1)
        If _item.To.Count > _Wires.Count Then _Wires.Add(New pts)

        'initalize all the wires
        Dim pt As Point = adr(_item.From)
        For xloop As Integer = 0 To _Wires.Count - 1
            _Wires(xloop).First = pt
            _Wires(xloop).Last = adr(_item.To(xloop))
            If Not ValidateList(_Wires(xloop)) Then checkNextPoint(_Wires(xloop), xloop)
        Next

    End Sub

    ''' <summary>
    ''' loops thrugh the points varifing the validity of each
    ''' </summary>
    ''' <param name="lst"></param>
    ''' <remarks></remarks>
    Private Sub checkNextPoint(lst As pts, wirenum As Integer)
        'setup the knows 0 and 1 (y)s are equal
        'and so are the 4 and 5 (y)s
        lst(1).Y = lst(0).Y
        lst(4).Y = lst(5).Y
        If lst(1).X = 0 Then lst(1).X = lst(0).X + 5
        If lst(4).X = 0 Then lst(4).X = lst(5).X - 5

        'if the items have moved past there other end
        'then check for min and max run length for
        'the secondary (x)s
        If lst.First.X + 10 >= lst.Last.X Then
            'the second item is left or equal to
            'the first item make the minimum first stubb 5 px
            If lst(1).X - lst(0).X < 5 Then lst(1).X = lst(0).X + 5
            If lst(5).X - lst(4).X < 5 Then lst(4).X = lst(5).X - 5
        Else

            'the first item is left of the second, 
            'check for an over lapping wire
            If lst(1).X + 5 > lst(0).X Then
                'if it's longer then the last point trim
                'it back to the last point -5px which 
                'should be the 4th point possibly
                If lst(1).X > lst.Last.X - 5 Then lst(1).X = lst.Last.X - 5
            End If
            'if the 4.x point overlapps the 1.x trim it back
            If lst(4).X < lst(1).X Then lst(4).X = (lst(5).X - 5) 'lst(1).X
        End If

        'Fill in the missing peices between
        'points 1 and 4 to compleate the wire
        If lst(1).Y = lst(4).Y Then
            'special case where there is a strait horizontal line 
            'between two points, re-adjust all the center points to align
            For xloop As Integer = 2 To 3
                lst(xloop).Y = lst(1).Y
                If lst(xloop).X < lst(xloop - 1).X Then
                    lst(xloop).X = lst(xloop - 1).X + 1
                End If
            Next

        ElseIf lst(1).X = lst(4).X Then
            'spectial case where there is a strait vertial line
            'between two points, re-adjust all the center points to align
            For xloop As Integer = 2 To 3
                lst(xloop).X = lst(1).X
                If lst(1).Y < lst(4).Y Then
                    'item 1 is above the other 4
                    If lst(xloop).Y < lst(xloop - 1).Y Then
                        lst(xloop).Y = lst(xloop - 1).Y + 1
                    End If
                Else
                    'item 1 is below the other 4
                    If lst(xloop).Y > lst(xloop - 1).Y Then
                        lst(xloop).Y = lst(xloop - 1).Y - 1
                    End If
                End If
            Next
        Else
            'there are multiple steps for this item
            'if the first item matches (x)s or is 
            'past the second one the stepping will go
            'behind, else it will use the normal stair step
            If lst.First.X + 10 >= lst.Last.X Then
                'this is the wrap around
                Dim g1 As Boolean = LinesUp(lst(1), lst(2))
                Dim g2 As Boolean = LinesUp(lst(3), lst(4))
                If Not g1 And Not g2 Then
                    'both pieces do not line up
                    'mak all new points
                    lst(2).X = lst(1).X
                    lst(3).X = lst(4).X
                    Dim b1 As Block_UI = _item.From.Owner.GetUI
                    Dim b2 As Block_UI = _item.To(wirenum).Owner.GetUI
                    Dim max As Integer = Math.Max(b1.Rect.Bottom, b2.Rect.Bottom)
                    lst(2).Y = max + 5
                    lst(3).Y = max + 5
                ElseIf Not g1 And g2 Then
                    'g2 was fine but make g1 match up
                    lst(2).X = lst(1).X
                    lst(2).Y = lst(3).Y
                ElseIf g1 And Not g2 Then
                    'g1 was fine but make g2 match up
                    lst(3).X = lst(4).X
                    lst(3).Y = lst(2).Y
                End If
            Else
                'this is the stair step
                'lign up all the (x)s first
                'if the two (y)s are in range
                'leave them alone else adjust them    
                Dim min As Integer = Math.Min(lst(1).Y, lst(4).Y)
                Dim max As Integer = Math.Max(lst(1).Y, lst(4).Y)
                Dim mid As Integer = (max - min) / 2
                If Not lst(2).IsValid Then
                    lst(2).Y = min + mid
                End If
                lst(2).X = lst(1).X
                If Not lst(3).IsValid Then
                    lst(3).Y = min + mid
                End If
                lst(3).X = lst(4).X
            End If
        End If

    End Sub

    ''' <summary>
    ''' to see if the two points are valid and line up on the same x-axis
    ''' </summary>
    ''' <param name="pt1"></param>
    ''' <param name="pt2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LinesUp(pt1 As PointX, pt2 As PointX) As Boolean
        If pt1.IsValid AndAlso pt2.IsValid AndAlso pt1.X = pt2.X Then Return True Else Return False
    End Function

    ''' <summary>
    ''' checks to make sure all points are still linked
    ''' </summary>
    ''' <param name="pt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateList(pt As pts) As Boolean
        Dim good As Boolean = True

        For xloop As Integer = 0 To 4
            If Not pt(xloop).IsValid Then good = False
            If pt(xloop).X <> pt(xloop + 1).X AndAlso pt(xloop).Y <> pt(xloop + 1).Y Then
                good = False
            End If
        Next

        Return good
    End Function

    ''' <summary>
    ''' the wire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Wire() As Wire
        Get
            Return _item
        End Get
    End Property

    ''' <summary>
    ''' how to draw the wire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Wire_style() As WireStyle
        Get
            Return _wireStyle
        End Get
    End Property

    ''' <summary>
    ''' if the point falls onto any point on the wire
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HitTest(e As Point) As HitTestType Implements i_UIelement.HitTest
        Dim ret As HitTestType = HitTestType.None
        Dim p As New Point(e.X - _vOffset.X, e.Y - _vOffset.Y)

        For xloop As Integer = 0 To _Wires.Count - 1
            For yloop As Integer = 0 To _Wires(xloop).Count - 2
                Dim pt1 As Point = _Wires(xloop).Item(yloop)
                Dim pt2 As Point = _Wires(xloop).Item(yloop + 1)
                Dim addr As Integer = (Wire_style.Size \ 2) + 1

                If pt1.X = pt2.X Then
                    'this is a vertical wire section
                    Dim max As Integer = pt1.X + addr
                    Dim min As Integer = pt1.X - addr
                    If p.X <= max AndAlso p.X >= min Then
                        max = Math.Max(pt1.Y, pt2.Y)
                        min = Math.Min(pt1.Y, pt2.Y)
                        If p.Y <= max AndAlso p.Y >= min Then
                            ret = HitTestType.Wire
                            Exit For
                        End If
                    End If
                Else
                    'this is a horizontal wire section
                    Dim max As Integer = pt1.Y + addr
                    Dim min As Integer = pt1.Y - addr
                    If p.Y <= max AndAlso p.Y >= min Then
                        max = Math.Max(pt1.X, pt2.X)
                        min = Math.Min(pt1.X, pt2.X)
                        If p.X <= max AndAlso p.X >= min Then
                            ret = HitTestType.Wire
                            Exit For
                        End If
                    End If
                End If
            Next
            If ret > HitTestType.None Then Exit For
        Next

        Return ret
    End Function

    ''' <summary>
    ''' for handling mouse down event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MouseDown(e As MouseEventArgs, ctrl As Boolean) As Boolean Implements i_UIelement.MouseDown
        If HitTest(New Point(e.X, e.Y)) = HitTestType.Wire Then Return True Else Return False
    End Function

    ''' <summary>
    ''' for handling mouse move event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MouseMove(e As MouseEventArgs) As Boolean Implements i_UIelement.MouseMove
        Dim ret As Boolean
        Dim p As New Point(e.X - _vOffset.X, e.Y - _vOffset.Y)

        For xloop As Integer = 0 To _Wires.Count - 1
            For yloop As Integer = 0 To _Wires(xloop).Count - 2
                Dim pt1 As Point = _Wires(xloop).Item(yloop)
                Dim pt2 As Point = _Wires(xloop).Item(yloop + 1)
                Dim addr As Integer = (Wire_style.Size \ 2) + 1

                If pt1.X = pt2.X Then
                    'this is a vertical wire section
                    Dim max As Integer = pt1.X + addr
                    Dim min As Integer = pt1.X - addr
                    If p.X <= max AndAlso p.X >= min Then
                        max = Math.Max(pt1.Y, pt2.Y)
                        min = Math.Min(pt1.Y, pt2.Y)
                        If p.Y <= max AndAlso p.Y >= min Then
                            ret = True
                            If _lastOver <> WireOverArgs.Vertical Then
                                RaiseEvent MouseOverEvent(Me, WireOverArgs.Vertical, New Point(e.X, e.Y))
                                _lastOver = WireOverArgs.Vertical
                                _lastWire = xloop
                                _lastWireSection = yloop + 1
                            End If

                            Exit For
                        End If
                    End If
                Else
                    'this is a horizontal wire section
                    Dim max As Integer = pt1.Y + addr
                    Dim min As Integer = pt1.Y - addr
                    If p.Y <= max AndAlso p.Y >= min Then
                        max = Math.Max(pt1.X, pt2.X)
                        min = Math.Min(pt1.X, pt2.X)
                        If p.X <= max AndAlso p.X >= min Then
                            ret = True
                            If yloop = 2 AndAlso _lastOver <> WireOverArgs.Horizontal Then
                                RaiseEvent MouseOverEvent(Me, WireOverArgs.Horizontal, New Point(e.X, e.Y))
                                _lastOver = WireOverArgs.Horizontal
                                _lastWire = xloop
                                _lastWireSection = yloop + 1
                            End If

                            Exit For
                        End If
                    End If
                End If
            Next

            If ret = True Then Exit For
        Next

        'the mouse is moving
        If e.Button = MouseButtons.Left AndAlso _lastOver > WireOverArgs.None AndAlso Me.selected Then
            '1= horz
            '2 = vert/horz (movable as vert)
            '3 = horz (movable)
            '4 = vert/horz (movable as vert)
            '5  = horz

            Select Case _lastWireSection
                Case 2
                    If _lastOver = WireOverArgs.Vertical Then
                        _Wires(_lastWire).Item(1).X = p.X
                        _Wires(_lastWire).Item(2).X = p.X
                    End If
                Case 3
                    _Wires(_lastWire).Item(2).Y = p.Y
                    _Wires(_lastWire).Item(3).Y = p.Y
                Case 4
                    If _lastOver = WireOverArgs.Vertical Then
                        _Wires(_lastWire).Item(3).X = p.X
                        _Wires(_lastWire).Item(4).X = p.X
                    End If
            End Select

            Return True
        End If

        If ret = False AndAlso _lastOver > WireOverArgs.None Then
            _lastOver = WireOverArgs.None
            RaiseEvent MouseOverEvent(Me, WireOverArgs.None, New Point(e.X, e.Y))
        End If

        Return ret
    End Function

    ''' <summary>
    ''' for handling the mouseup event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MouseUp(e As MouseEventArgs) As Boolean Implements i_UIelement.MouseUp
        If HitTest(New Point(e.X, e.Y)) = HitTestType.Wire Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' paints this item to the screen
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="fnt"></param>
    ''' <param name="running"></param>
    ''' <param name="OrigionOffset"></param>
    ''' <remarks></remarks>
    Public Sub Paint(g As Graphics, fnt As Font, running As Boolean, OrigionOffset As Point) Implements i_UIelement.Paint
        _vOffset = OrigionOffset

        Using p As New Pen(Color.FromArgb(255, Wire_style.Color), Wire_style.Size)
            p.DashStyle = Wire_style.style
            p.StartCap = LineCap.RoundAnchor
            p.EndCap = LineCap.RoundAnchor

            For xloop As Integer = 0 To _Wires.Count - 1
                Dim pts() As Point = _Wires(xloop).toArray
                For yloop As Integer = 0 To pts.Length - 1
                    pts(yloop).X += _vOffset.X
                    pts(yloop).Y += _vOffset.Y
                Next
                If selected Then
                    Using px As New Pen(Color.Yellow, Wire_style.Size + 2)
                        g.DrawLines(px, pts)
                    End Using
                End If

                g.DrawLines(p, pts)
            Next
        End Using

    End Sub

    ''' <summary>
    ''' if this item is select or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property selected As Boolean Implements i_UIelement.selected

    ''' <summary>
    ''' returns the property page for this wire
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPropertyPageType() As BaseItemProp Implements i_UIelement.GetPropertyPageType
        Dim ex As New Wire_UI_Props()
        ex.LoadItem(Me)
        Return ex
    End Function


End Class
