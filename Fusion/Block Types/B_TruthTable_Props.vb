Public Class B_TruthTable_Props
    Private _item As Block_UI
    Private _bam As B_TruthTable
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = _item.Block
        txtUserLabel.Text = _item.Block.UserLabel
        nuInputs.Value = _bam.InputConnectors.Count
        nuOutput.Value = _bam.OutputConnectors.Count


        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _item.Block.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuInputs_ValueChanged(sender As Object, e As EventArgs) Handles nuInputs.ValueChanged
        If _loaded Then
            _bam.ChangeInputConnectorCount(nuInputs.Value)
            _item.ReloadUIPoints()
            For Each item As TSI In flp.Controls
                item.inCount = nuInputs.Value
                item.Invalidate()
            Next
        End If
    End Sub

    Private Sub nuOutputs_ValueChanged(sender As Object, e As EventArgs) Handles nuOutput.ValueChanged
        If _loaded Then
            _bam.ChangeOutputConnectorCount(nuOutput.Value)
            _item.ReloadUIPoints()
            For Each item As TSI In flp.Controls
                item.OutCount = nuOutput.Value
                item.Invalidate()
            Next
        End If
    End Sub

    Private Sub btnAddSequence_Click(sender As Object, e As EventArgs) Handles btnAddSequence.Click
        Dim ex As New B_TruthTable.TruthTableStep
        Dim item As New TSI(ex, nuInputs.Value, nuOutput.Value)
        AddHandler item.ItemSelected, AddressOf SelectedItemChanged
        Me.flp.Controls.Add(item)
    End Sub

    Private Sub btnRemoveSequence_Click(sender As Object, e As EventArgs) Handles btnRemoveSequence.Click
        Dim sel As TSI = Nothing
        For Each item As TSI In flp.Controls
            If item.Selected Then sel = item
        Next

        If sel IsNot Nothing Then
            _bam.steps.Remove(sel.TheStep)
            RemoveHandler sel.ItemSelected, AddressOf SelectedItemChanged
            flp.Controls.Remove(sel)
        End If
    End Sub

    Private Sub SelectedItemChanged(sender As Object, e As EventArgs)
        For Each item As TSI In flp.Controls
            If sender IsNot item Then item.Selected = False
            item.Invalidate()
        Next
    End Sub

    Private Class TSI
        Inherits UserControl

        Public Event ItemSelected As EventHandler
        Private _inRecs(-1) As Rectangle
        Private _OutRecs(-1) As Rectangle
        Private _incnt As Integer
        Private _outcnt As Integer

        Public Sub New(item As B_TruthTable.TruthTableStep, incnt As Integer, outCnt As Integer)
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.FixedHeight Or
                     ControlStyles.FixedWidth Or ControlStyles.Opaque Or
                     ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or
                     ControlStyles.UserPaint, True)


            TheStep = item
            OutCount = outCnt
            InCount = incnt
            Selected = False

            Me.Height = 36
            Me.Width = 24 + Math.Max(outCnt, incnt) * 16
        End Sub

        Public Property OutCount() As Integer
            Get
                Return _outcnt
            End Get
            Set(value As Integer)
                _outcnt = value
                Me.Width = 24 + Math.Max(value, InCount) * 16
            End Set
        End Property

        Public Property InCount() As Integer
            Get
                Return _incnt
            End Get
            Set(value As Integer)
                _incnt = value
                Me.Width = 24 + Math.Max(value, OutCount) * 16
            End Set
        End Property

        Public Property TheStep() As B_TruthTable.TruthTableStep

        Public Property Selected() As Boolean

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If Not Selected Then
                Me.Selected = True
                RaiseEvent ItemSelected(Me, New EventArgs)
            Else
                For xloop As Integer = 0 To InCount - 1
                    If _inRecs(xloop).Contains(e.X, e.Y) Then
                        Blts.BitToggle(TheStep.Io, xloop)
                        Me.Invalidate()
                        Exit For
                    End If
                Next
                For xloop As Integer = 0 To OutCount - 1
                    If _OutRecs(xloop).Contains(e.X, e.Y) Then
                        Blts.BitToggle(TheStep.Oo, xloop)
                        Me.Invalidate()
                        Exit For
                    End If
                Next
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            If Me.Selected Then
                e.Graphics.FillRectangle(Brushes.PowderBlue, Me.Bounds)
            Else
                e.Graphics.FillRectangle(Brushes.White, Me.Bounds)
            End If

            If _OutRecs.Count <> OutCount Then ReDim _OutRecs(OutCount - 1)
            If _inRecs.Count <> InCount Then ReDim _inRecs(InCount - 1)

            Using stf As New StringFormat
                stf.Alignment = StringAlignment.Center
                stf.LineAlignment = StringAlignment.Center
                e.Graphics.DrawImage(My.Resources.Play, 1, 10)


                e.Graphics.DrawString("In", Me.Font, Brushes.Black, 16, 4)
                For xloop As Integer = 0 To InCount - 1
                    _inRecs(xloop) = New Rectangle(24 + (xloop * 16), 1, 16, 16)
                    If TheStep.Io And (1 << xloop) Then
                        e.Graphics.FillRectangle(Brushes.CornflowerBlue, _OutRecs(xloop))
                        e.Graphics.DrawRectangle(Pens.Gray, _OutRecs(xloop))
                        e.Graphics.DrawString(xloop.ToString, Me.Font, Brushes.White, _OutRecs(xloop), stf)
                    Else
                        e.Graphics.DrawRectangle(Pens.Gray, _OutRecs(xloop))
                        e.Graphics.DrawString(xloop.ToString, Me.Font, Brushes.Black, _OutRecs(xloop), stf)
                    End If
                Next

                e.Graphics.DrawString("Out", Me.Font, Brushes.Black, 26, 4)
                For xloop As Integer = 0 To OutCount - 1
                    _OutRecs(xloop) = New Rectangle(24 + (xloop * 16), 18, 16, 16)
                    If TheStep.Oo And (1 << xloop) Then
                        e.Graphics.FillRectangle(Brushes.CornflowerBlue, _OutRecs(xloop))
                        e.Graphics.DrawRectangle(Pens.Gray, _OutRecs(xloop))
                        e.Graphics.DrawString(xloop.ToString, Me.Font, Brushes.White, _OutRecs(xloop), stf)
                    Else
                        e.Graphics.DrawRectangle(Pens.Gray, _OutRecs(xloop))
                        e.Graphics.DrawString(xloop.ToString, Me.Font, Brushes.Black, _OutRecs(xloop), stf)
                    End If
                Next
            End Using

        End Sub

    End Class


End Class