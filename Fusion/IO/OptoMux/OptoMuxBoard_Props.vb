Public Class OptoMuxBoard_Props

    Private _nd As XmlNode
    Private _omb As OptoMuxBoard


    ''' <summary>
    ''' editing an exiting item
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Public Sub New(item As OptoMuxBoard)
        InitializeComponent()
        _omb = item

        udName.Value = CInt(item.Name)
        cmbWatchdog.SelectedIndex = item.WatchdogDelay
        txtIO.Text = item.GetIOString
        txtnotes.Text = item.UserInfo
        chkEnabled.Checked = item.Enabled
        chkSkip.Checked = item.NoReadOutputs
    End Sub

    ''' <summary>
    ''' editing a new items
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Public Sub New(item As XmlNode)
        InitializeComponent()
        _nd = item
        cmbWatchdog.SelectedIndex = 0
        txtIO.Text = "iiii,iiii,iiii,iiii"
    End Sub

    ''' <summary>
    ''' force any input not an i or o to be an i
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtIO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIO.KeyPress
        If e.KeyChar <> "i" AndAlso e.KeyChar <> "o" Then
            e.Handled = True
            e.KeyChar = "i"
        End If
    End Sub

    ''' <summary>
    ''' save the settings
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtIO.MaskFull Then
            If _nd IsNot Nothing Then _omb = New OptoMuxBoard(_nd)

            With _omb
                .Name = udName.Value
                .WatchdogDelay = cmbWatchdog.SelectedIndex
                .UserInfo = txtnotes.Text
                .Enabled = chkEnabled.Checked
                .NoReadOutputs = chkSkip.Checked
                .isAnalog = chkIsAnalog.Checked
                Dim io As String = txtIO.Text.Replace(",", "")
                .Iopoints.Clear()
                For xloop As Integer = 0 To 15
                    If .isAnalog Then
                        .Iopoints.Add(New IOPoint(xloop, _omb, (io.Chars(xloop) = "i"c), 4095, IOPointSupports.Analog))
                    Else
                        .Iopoints.Add(New IOPoint(xloop, _omb, (io.Chars(xloop) = "i"c), 1, IOPointSupports.Digital Or IOPointSupports.DigitalTimeDelay))
                    End If
                    .Iopoints(xloop).isInput = (io.Chars(xloop) = "i"c)
                Next
            End With
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public ReadOnly Property OptoMuxBoard() As OptoMuxBoard
        Get
            Return _omb
        End Get
    End Property


End Class