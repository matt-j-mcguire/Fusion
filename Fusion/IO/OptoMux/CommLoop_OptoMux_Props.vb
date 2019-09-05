Public Class CommLoop_OptoMux_Props

    Private _nd As XmlNode
    Private _clo As CommLoop_OptoMux

    ''' <summary>
    ''' editing an existing item
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Public Sub New(item As CommLoop_OptoMux)
        InitializeComponent()
        _clo = item
        LoadCommPorts()

        txtName.Text = item.Name
        udTimeout.Value = item.TimeOut
        udRest.Value = item.RestTime
        cmbSerialPort.SelectedItem = item.SerialPort.ToString
        cmbBaud.SelectedItem = item.SerialBaud.ToString
        txtIP.Text = item.IPName
        udIPPort.Value = item.IPPort
        If Not item.IsIP Then
            OptSerial.Checked = True
        Else
            optTCP.Checked = True
        End If

    End Sub

    ''' <summary>
    ''' editing a new item
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <remarks></remarks>
    Public Sub New(nd As XmlNode)
        InitializeComponent()
        _nd = nd
        LoadCommPorts()

        Name = "Name"
        udTimeout.Value = 150
        udRest.Value = 1000
        cmbSerialPort.SelectedItem = "3"
        cmbBaud.SelectedItem = "19200"
        txtIP.Text = "192.168.0.102"
        udIPPort.Value = 4000
        OptSerial.Checked = True
    End Sub

    ''' <summary>
    ''' generatates a list of aviable comm ports (number only)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCommPorts()
        Dim lst() As String = SerialPort.GetPortNames
        For xloop As Integer = 0 To lst.Length - 1
            lst(xloop) = lst(xloop).Replace("COM", "")
        Next
        cmbSerialPort.Items.AddRange(lst)
    End Sub

    ''' <summary>
    ''' enable/disable controls
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OptSerial_CheckedChanged(sender As Object, e As EventArgs) Handles OptSerial.CheckedChanged, optTCP.CheckedChanged
        Dim s As Boolean = OptSerial.Checked
        lblSerialPort.Enabled = s
        cmbSerialPort.Enabled = s
        lblBaudRate.Enabled = s
        cmbBaud.Enabled = s
        lblIPAddress.Enabled = Not s
        txtIP.Enabled = Not s
        lblIPPort.Enabled = Not s
        udIPPort.Enabled = Not s
    End Sub

    ''' <summary>
    ''' saves the settings back to file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim good As Boolean = False
        If OptSerial.Checked Then good = cmbSerialPort.SelectedIndex > -1 AndAlso cmbBaud.SelectedIndex > -1
        If optTCP.Checked Then good = udIPPort.Value > 0 AndAlso ValidateIP()

        If good Then
            If _nd IsNot Nothing Then _clo = New CommLoop_OptoMux(_nd)

            With _clo
                .Name = txtName.Text
                .TimeOut = udTimeout.Value
                .RestTime = udRest.Value
                If OptSerial.Checked Then
                    .SerialPort = CInt(cmbSerialPort.SelectedItem)
                    .SerialBaud = CInt(cmbBaud.SelectedItem)
                    .IsIP = False
                Else
                    .IPName = txtIP.Text
                    .IPPort = udIPPort.Value
                    .IsIP = True
                End If

            End With
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' validates the IP address
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateIP() As Boolean
        Dim good As Boolean = True
        Dim m As Match = Regex.Match(txtIP.Text, "(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})")
        If m.Success Then
            For xloop As Integer = 1 To 4
                If CInt(m.Groups(xloop).Value) > 255 Then
                    good = False
                    MessageBox.Show("An IP address cannot have any value greater than 255", "incorrect format")
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("IP format is incorrect, please use the dot notation:(192.168.0.1)", "incorrect format")
            good = False
        End If

        Return good
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public ReadOnly Property Commloop() As CommLoop
        Get
            Return _clo
        End Get
    End Property

End Class