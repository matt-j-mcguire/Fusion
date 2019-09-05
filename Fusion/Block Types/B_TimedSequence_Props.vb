Public Class B_TimedSequence_Props
    Private _item As Block_UI
    Private _bam As B_TimedSequence
    Private _loaded As Boolean


    Public Overrides Sub LoadItem(item As i_UIelement)
        _item = item
        _bam = DirectCast(item, Block_UI).Block
        txtUserLabel.Text = _bam.UserLabel
        nuOutputs.Value = _bam.OutputConnectors.Count

        For xloop As Integer = 0 To _bam.steps.Count - 1
            Dim x As New TSI(_bam.steps(xloop), _bam.OutputConnectors.Count)
            AddHandler x.ItemSelected, AddressOf SelectedItemChanged
            Me.flp.Controls.Add(x)
        Next

        _loaded = True
    End Sub

    Private Sub txtUserLabel_TextChanged(sender As Object, e As EventArgs) Handles txtUserLabel.TextChanged
        If _loaded Then
            _bam.UserLabel = txtUserLabel.Text
        End If
    End Sub

    Private Sub nuOutputs_ValueChanged(sender As Object, e As EventArgs) Handles nuOutputs.ValueChanged
        If _loaded Then
            _bam.ChangeConnectorCount(nuOutputs.Value)
            _item.ReloadUIPoints()
            For Each item As TSI In flp.Controls
                item.OutCount = nuOutputs.Value
                item.Invalidate()
            Next
        End If
    End Sub

    Private Sub btnAddSequence_Click(sender As Object, e As EventArgs) Handles btnAddSequence.Click
        Dim ex As New B_TimedSequence.TimedSequenceStep
        Dim item As New TSI(ex, nuOutputs.Value)
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
        Private _TmRec As Rectangle
        Private _OutRecs(-1) As Rectangle
        Private _cnt As Integer

        Public Sub New(item As B_TimedSequence.TimedSequenceStep, outCnt As Integer)
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.FixedHeight Or
                     ControlStyles.FixedWidth Or ControlStyles.Opaque Or
                     ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or
                     ControlStyles.UserPaint, True)


            TheStep = item
            OutCount = outCnt
            Selected = False

            Me.Height = 18
            Me.Width = 50 + outCnt * 16
        End Sub

        Public Property OutCount() As Integer
            Get
                Return _cnt
            End Get
            Set(value As Integer)
                _cnt = value
                Me.Width = 50 + value * 16
            End Set
        End Property

        Public Property TheStep() As B_TimedSequence.TimedSequenceStep

        Public Property Selected() As Boolean

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If Not Selected Then
                Me.Selected = True
                RaiseEvent ItemSelected(Me, New EventArgs)
            Else
                If _TmRec.Contains(e.X, e.Y) Then
                    Dim ex As New B_timedSequence_Interval(TheStep.Len)
                    If ex.ShowDialog(Me) = DialogResult.OK Then
                        TheStep.Len = ex.Value
                    End If
                Else
                    For xloop As Integer = 0 To OutCount - 1
                        If _OutRecs(xloop).Contains(e.X, e.Y) Then
                            Blts.BitToggle(TheStep.Oo, xloop)
                            Me.Invalidate()
                            Exit For
                        End If
                    Next
                End If
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
            _TmRec = New Rectangle(1, 1, 49, 16)

            Using stf As New StringFormat
                stf.Alignment = StringAlignment.Center
                stf.LineAlignment = StringAlignment.Center

                e.Graphics.DrawString(TheStep.Len \ 60 & "m " & TheStep.Len Mod 60 & "s :", Me.Font, Brushes.Black, _TmRec, stf)

                For xloop As Integer = 0 To OutCount - 1
                    _OutRecs(xloop) = New Rectangle(50 + (xloop * 16), 1, 16, 16)
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
