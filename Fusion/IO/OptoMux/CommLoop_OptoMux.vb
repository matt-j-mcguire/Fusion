

Public Class CommLoop_OptoMux
    Inherits CommLoop



#Region "public changable properties (vars)"
    Public SerialPort As Integer
    Public SerialBaud As Integer
    Public TimeOut As Integer
    Public IsIP As Boolean
    Public IPName As String
    Public IPPort As Integer
    Public RestTime As Integer
#End Region

#Region "private variables"
    ''' <summary>
    ''' the opto driver (ip or serial)
    ''' </summary>
    ''' <remarks></remarks>
    Friend _OptoDV As OptoDriver
    ''' <summary>
    ''' when to check all the boards for I/O setup [default 3mins]
    ''' </summary>
    ''' <remarks></remarks>
    Private _NextCheckConfiguration As Date
    ''' <summary>
    ''' for processing the updates on the pages
    ''' </summary>
    ''' <remarks></remarks>
    Private _workThread As Thread
    ''' <summary>
    ''' flag for allowing the loop to work
    ''' </summary>
    ''' <remarks></remarks>
    Private _AllowWork As Boolean
    ''' <summary>
    ''' for resetting the control loop, if something bad happens
    ''' </summary>
    ''' <remarks></remarks>
    Private _ResetTimer As System.Threading.Timer
#End Region


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)


        Name = XHelper.Get(Node, "Name", "Default")
        SerialPort = XHelper.Get(Node, "SerialPort", 3)
        SerialBaud = XHelper.Get(Node, "BaudRate", 19200)
        TimeOut = XHelper.Get(Node, "Timeout", 250)
        IsIP = XHelper.Get(Node, "Isip", False)
        IPName = XHelper.Get(Node, "Ip", "192.168.0.102")
        IPPort = XHelper.Get(Node, "Ipport", 4000)
        RestTime = XHelper.Get(Node, "Rest", 500)

        '=====================================================
        'sub boards are called "OptoMuxBoard"
        '=====================================================
        Dim lst As XmlNodeList = nd.SelectNodes("OptoMuxBoard")
        For Each nl As XmlNode In lst
            Dim isd As Boolean = XHelper.Get(nl, "digital", True)
            Me.CommPoints.Add(New OptoMuxBoard(nl, Not isd))
        Next

        _NextCheckConfiguration = Now.AddMinutes(3)
    End Sub

    ''' <summary>
    ''' saves everything back to the comm loop
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Save()
        XHelper.Set(Node, "Name", Me.Name)
        XHelper.Set(Node, "SerialPort", SerialPort)
        XHelper.Set(Node, "BaudRate", SerialBaud)
        XHelper.Set(Node, "Timeout", TimeOut)
        XHelper.Set(Node, "Isip", IsIP)
        XHelper.Set(Node, "Ip", IPName)
        XHelper.Set(Node, "Ipport", IPPort)
        XHelper.Set(Node, "Rest", RestTime)

        For xloop As Integer = 0 To CommPoints.Count - 1
            CommPoints(xloop).Save()
        Next
    End Sub

    ''' <summary>
    ''' returns the commloop type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property CommType As CommLoopType
        Get
            Return CommLoopType.OptoMux
        End Get
    End Property

    ''' <summary>
    ''' starts or stoppes the commloop
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property StartStop As Boolean
        Get
            Return _workThread IsNot Nothing
        End Get
        Set(value As Boolean)
            If value Then
                _AllowWork = True

                If IsIP Then
                    _OptoDV = New OptoIP(IPName, IPPort)
                Else
                    _OptoDV = New OptoSerial(SerialPort, SerialBaud)
                End If
                _OptoDV.Open()

                _workThread = New Thread(AddressOf Me.DoWork)
                _workThread.Name = "Opto" & Name
                _workThread.Priority = ThreadPriority.Normal
                _workThread.IsBackground = True
                _workThread.Start()
            Else
                _AllowWork = False
                _OptoDV.Close()
                Try
                    _workThread.Abort()
                Finally
                    _workThread = Nothing
                    _OptoDV = Nothing
                End Try
            End If
        End Set
    End Property

    ''' <summary>
    ''' updates all the commpoints (opto boards)
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub DoWork()
        Thread.Sleep(500)
        Dim parseTime As Date = Now
        Dim timediff2 As Single
        Dim bd As OptoMuxBoard = Nothing
        Dim Index As Integer

        Try
            Do
                bd = CommPoints(Index)
                Try
                    If _AllowWork = False Then Exit Do
                    If _OptoDV IsNot Nothing Then
                        If bd.Enabled = False Then
                            bd.WriteRead(_OptoDV, TimeOut)
                            Thread.Sleep(50)
                        Else
                            bd.WriteRead(_OptoDV, TimeOut)
                        End If
                    End If
                Catch exy As ThreadAbortException
                    Exit Do
                Catch ex As Exception
                    ErrorLogger.Write(ex)
                End Try

                Index += 1
                '=====================================================================
                '====only if the loop has compleated a full loop of all the boards====
                '=====================================================================
                If Index > CommPoints.Count - 1 Then
                    timediff2 = CSng((Now.Ticks - parseTime.Ticks) / 10000000)
                    LoopTime = timediff2.ToString("#0.00")
                    parseTime = Now
                    Thread.Sleep(RestTime)
                    Index = 0
                End If

                '======================================================================
                '=================Reset all the Opto digital counts====================
                '======================================================================
                If Now.Hour = 0 AndAlso Now.Minute = 0 AndAlso Now.Second = 0 Then
                    For Each brd As OptoMuxBoard In CommPoints
                        brd.ResetSwitchCount()
                    Next
                End If

                '====================================================================
                '=====check all the boards configuration after three minutes=========
                '====================================================================
                If _NextCheckConfiguration <= Now Then
                    For Each brd As OptoMuxBoard In CommPoints
                        brd.CheckConfiguration(_OptoDV, TimeOut)
                    Next
                    _NextCheckConfiguration = Now.AddMinutes(3)
                End If
            Loop
        Catch exy As Threading.ThreadAbortException
            '----------------------------------
            'do nothing, program is closing
            '----------------------------------
        Catch ex As Exception
            ErrorLogger.Write(ex)

            If _ResetTimer Is Nothing Then
                Dim timerDelegate As TimerCallback = AddressOf _ResetTimer_Tick
                _ResetTimer = New System.Threading.Timer(timerDelegate, New Object, 60000, System.Threading.Timeout.Infinite)
                Exit Sub
            End If
        End Try
    End Sub

    ''' <summary>
    ''' used when resetting the commloop if an error occured
    ''' </summary>
    ''' <param name="stateInfo"></param>
    ''' <remarks></remarks>
    Private Sub _ResetTimer_Tick(ByVal stateInfo As Object)
        StartStop = False
        Application.DoEvents()
        _ResetTimer.Dispose()
        _ResetTimer = Nothing
        StartStop = True
    End Sub

    ''' <summary>
    ''' if this is a valid commpoint node for this typeof commloop
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function isVallidCommPoint(nd As XmlNode) As Boolean
        If nd.Name.ToLower = "optomuxboard" Then Return True Else Return False
    End Function

    ''' <summary>
    ''' adds a new comm point to the system
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function AddNewCommPoint() As CommPoint

        Dim xnd As XmlNode = XHelper.NodeCreate(Node.OwnerDocument, "OptoMuxBoard")
        Dim ex As New OptoMuxBoard_Props(xnd)
        If ex.ShowDialog = DialogResult.OK Then
            Node.AppendChild(xnd)
            Me.CommPoints.Add(ex.OptoMuxBoard)
            ex.OptoMuxBoard.Save()
            Return ex.OptoMuxBoard
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' adds a new comm point
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns>if not the right type of xmlnode, it will return nothing</returns>
    ''' <remarks></remarks>
    Public Overrides Function AddPoint(nd As XmlNode) As CommPoint
        Dim ret As CommPoint = Nothing
        If nd.Name = "OptoMuxBoard" Then
            Dim isd As Boolean = XHelper.Get(nd, "digital", True)
            ret = New OptoMuxBoard(nd, Not isd)
            Me.CommPoints.Add(ret)
        End If
        Return ret
    End Function

    ''' <summary>
    ''' shows the dialog for editing the properties of this item
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub ShowPropertiesDialog()
        Dim ex As New CommLoop_OptoMux_Props(Me)
        If ex.ShowDialog() = DialogResult.OK Then
            Me.Save()
        End If
    End Sub

    ''' <summary>
    ''' show the properties for this commloop
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub ShowProperties()
        Dim ex As New CommLoop_OptoMux_Props(Me)
        If ex.ShowDialog() Then
            Me.Save()
        End If
    End Sub

End Class


