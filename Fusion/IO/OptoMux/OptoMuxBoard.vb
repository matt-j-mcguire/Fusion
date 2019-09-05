
''' <summary>
''' Basic Optomux Board functionallity
''' </summary>
''' <remarks></remarks>
Public Class OptoMuxBoard
    Inherits CommPoint



#Region "Variables"
    ''' <summary>
    ''' the watchdog delay
    ''' </summary>
    ''' <remarks></remarks>
    Public WatchdogDelay As Integer
    ''' <summary>
    ''' if this opto board is analog or digital
    ''' </summary>
    ''' <remarks></remarks>
    Public isAnalog As Boolean
    ''' <summary>
    ''' how many errors in a row have happened
    ''' </summary>
    ''' <remarks></remarks>
    Private _ConcurrentAlarm As Integer
    ''' <summary>
    ''' if the board is currently initalized
    ''' </summary>
    ''' <remarks></remarks>
    Private _Initalized As Boolean
    ''' <summary>
    ''' when the first error was recieved in a constant error
    ''' </summary>
    ''' <remarks></remarks>
    Private _FirstErrorTime As Date
#End Region

    ''' <summary>
    ''' public New, called from inheriters
    ''' </summary>
    ''' <param name="nd">xmlnode to parse</param>
    ''' <param name="isAnalog">if analog or digital</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal nd As XmlNode, ByVal isAnalog As Boolean)
        MyBase.New(nd)
        isAnalog = isAnalog

        '------------------------------------------------------------------
        '-----------------parse the xmlnode to find the values-------------
        '------------------------------------------------------------------
        Me.Name = XHelper.Get(Node, "Name", "1")
        Me.NoReadOutputs = XHelper.Get(Node, "NoReadOutputs", False)
        Me.Enabled = XHelper.Get(Node, "Enabled", True)
        Me.UserInfo = XHelper.Get(Node, "UserInfo", "")
        Me.WatchdogDelay = XHelper.Get(Node, "Watchdog", 0)
        Dim pts As String = XHelper.Get(Node, "IO", "iiii,iiii,iiii,iiii").Replace(",", "")

        '------------------------------------------------------------------
        'set up the new instance of each module (i for input, o for output)
        '-----------------------------------------------------------------
        For xloop As Integer = 0 To 15
            Dim isIn As Boolean = If(xloop >= pts.Length, False, (Char.ToLower(pts.Chars(xloop)) = "i"c))
            If isAnalog Then
                Iopoints.Add(New IOPoint(xloop, Me, isIn, 4095, IOPointSupports.Analog))
            Else
                Iopoints.Add(New IOPoint(xloop, Me, isIn, 1, IOPointSupports.Digital Or IOPointSupports.DigitalTimeDelay))
            End If
        Next

        '------------------------------------------------------------------
        '----------------------Set the start-up flags----------------------
        '------------------------------------------------------------------
        _FirstErrorTime = Now
        _Initalized = False
    End Sub

    ''' <summary>
    ''' used when creating a new item from scratch
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal nd As XmlNode)
        MyBase.New(nd)
        _FirstErrorTime = Now
        _Initalized = False
    End Sub

    ''' <summary>
    ''' saves the settings back to file
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Save()
        XHelper.Set(Node, "Name", Me.Name)
        XHelper.Set(Node, "NoReadOutputs", Me.NoReadOutputs)
        XHelper.Set(Node, "Enabled", Me.Enabled)
        XHelper.Set(Node, "UserInfo", Me.UserInfo)
        XHelper.Set(Node, "Watchdog", Me.WatchdogDelay)
        XHelper.Set(Node, "IO", GetIOString)
    End Sub

    Public Function GetIOString() As String
        Dim bld As New StringBuilder
        For xloop As Integer = 0 To 15
            If Iopoints(xloop).isInput Then
                bld.Append("i")
            Else
                bld.Append("o")
            End If
            If xloop > 15 AndAlso (xloop + 1) Mod 4 = 0 Then bld.Append(",")
        Next
        Return bld.ToString
    End Function

#Region "Functions"

    ''' <summary>
    ''' any value over the count,clear them  back to 1
    ''' </summary>
    ''' <remarks>to keep an over flow from happening</remarks>
    <DebuggerStepThrough()> Protected Sub CheckForCountOverFlow()
        'any value over the count,clear them  back to 1
        If Stats.ErrorCount >= 1000000 Then
            Stats.ErrorCount = 1
        End If
        If Stats.Writes >= 1000000 Then
            Stats.Writes = 1
        End If
        If Stats.Reads >= 1000000 Then
            Stats.Reads = 1
        End If
        If Stats.GoodReads >= 1000000 Then
            Stats.GoodReads = 1
        End If

    End Sub

    ''' <summary>
    ''' this will keep trying to reset the board untill sucessfully initallized
    ''' </summary>
    ''' <returns>if successful</returns>
    ''' <remarks></remarks>
    Protected Overridable Function ResetPowerUpClear(ByVal drv As OptoDriver, ByVal timeout As Integer) As Boolean

        '------------------------------------------------------------------
        '---comm is lost or needs reset, all inputs set back to default----
        '------------------------------------------------------------------
        For Each xmod As IOPoint In Iopoints
            If xmod.isInput Then xmod.ResetValue()
        Next

        '------------------------------------------------------------------
        '-----------------write the power up clear-------------------------
        '------------------------------------------------------------------
        Dim optoErr As OptoDriverError = drv.OptoPowerUpClear(CInt(Stats.Name), timeout)
        CheckforError(drv, optoErr, True, "Power Up Clear")

        '------------------------------------------------------------------
        '--------------write the Reset for the board-----------------------
        '------------------------------------------------------------------
        optoErr = drv.OptoReset(CInt(Stats.Name), timeout)
        Dim AllGood As Boolean = Not CheckforError(drv, optoErr, True, "Board Reset")

        '------------------------------------------------------------------
        '-----------give the board a few milliseconds to reset-------------
        '------------------------------------------------------------------
        If AllGood Then Thread.Sleep(100)

        Return AllGood
    End Function

    ''' <summary>
    ''' sets up the wach dog to reset the board after so long
    ''' </summary>
    ''' <remarks>internal command</remarks>
    Protected Overridable Function SetUpWatchDog(ByVal drv As OptoDriver, ByVal timeout As Integer) As Boolean
        Dim wdd As OptoWatchDogDelay
        Select Case WatchdogDelay
            Case 1
                wdd = OptoWatchDogDelay.Minute
            Case 10
                wdd = OptoWatchDogDelay.TenMinute
            Case Else
                wdd = OptoWatchDogDelay.Disabled
        End Select

        Dim optoErr As OptoDriverError
        If isAnalog Then
            Dim pos() As Boolean = {True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}
            optoErr = drv.OptoSetAnalowatchDogDelay(CInt(Stats.Name), timeout, wdd, pos)
        Else
            optoErr = drv.OptoSetDigitalWatchDogDelay(CInt(Stats.Name), timeout, wdd)
        End If
        Dim allgood As Boolean = Not CheckforError(drv, optoErr, True, "Set WatchDog Delay")

        Return allgood
    End Function

    ''' <summary>
    ''' to be handled after a resetpowerupclear to setup what modules must
    ''' be inputs and what must be outputs
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Function SetIO(ByVal drv As OptoDriver, ByVal timeout As Integer) As Boolean

        Dim thePos(15) As Boolean
        For xloop As Integer = 0 To Iopoints.Count - 1
            thePos(xloop) = Not Iopoints(xloop).isInput
        Next

        Dim optoErr As OptoDriverError = drv.OptoConfigurePositions(CInt(Stats.Name), timeout, thePos)
        Return Not Me.CheckforError(drv, optoErr, True, "Configure Positions")
    End Function

    ''' <summary>
    ''' during its write/read time, the sub should first check if there is 
    ''' any data needed to write to a module before trying to do a read.
    ''' </summary>
    ''' <remarks>call mybase first when overridden</remarks>
    Public Overridable Sub WriteRead(ByVal drv As OptoDriver, ByVal timeout As Integer)

        If Enabled = False Then
            Stats.Writes = 10
            Stats.Reads = 10
            Stats.GoodReads = 10
            Stats.InError = False
            Stats.ErrorCount = 10
            Stats.LastError = ""
            Exit Sub
        Else
            'see if it has been initalized
            If _Initalized = False Then
                Dim x As Boolean = True
                If x AndAlso ResetPowerUpClear(drv, timeout) = False Then x = False
                If x AndAlso SetUpWatchDog(drv, timeout) = False Then x = False
                If x AndAlso SetIO(drv, timeout) = False Then x = False
                _Initalized = x
            End If
            If isAnalog Then
                WriteReadAnalog(drv, timeout)
            Else
                WriteReadDigital(drv, timeout)
            End If

            'check the counters
            CheckForCountOverFlow()
        End If
    End Sub

    ''' <summary>
    ''' this checks too see if the sent message was sucessfull or returnd an error. if 5 consecutive errors happen
    ''' then and an alarm is started
    ''' </summary>
    ''' <param name="ErrorNumber">the error number sent. 0 will clear any alarm and consecutive count</param>
    ''' <param name="isWrite">if write or read used for counting up the stats</param>
    ''' <param name="ExtraInfo">a string to append to the error of why the alarm happened</param>
    ''' <returns>'0 to clear the error, all other values will create an alarm</returns>
    ''' <remarks></remarks>
    Protected Function CheckforError(ByVal drv As OptoDriver, ByVal ErrorNumber As OptoDriverError, ByVal isWrite As Boolean, ByVal ExtraInfo As String) As Boolean
        Dim retval As Boolean
        If ErrorNumber <> OptoDriverError.None Then
            'add one to the error count
            Stats.ErrorCount += 1
            Stats.InError = True
            _ConcurrentAlarm += 1
            If isWrite = False Then Stats.Reads = 0
            If _ConcurrentAlarm = 1 Then _FirstErrorTime = Now

            Dim restart As Boolean = False
            Select Case ErrorNumber
                Case OptoDriverError.OptoMux_Input_buffer_Overrun
                    restart = True
                Case OptoDriverError.OptoMux_Non_Printable_Character_Received
                    restart = True
                Case OptoDriverError.OptoMux_PUC_Expected
                    restart = True
                Case OptoDriverError.OptoMux_Undefined_Command
                    restart = True
                Case OptoDriverError.OptoMux_Unknown_Error
                    restart = True
                Case OptoDriverError.OptoMux_Watch_Dog_Timeout
                    restart = True
            End Select

            If ErrorNumber = OptoDriverError.Port_Not_Connected Then
                Stats.LastError = "Port Not Connected"
            End If

            If _ConcurrentAlarm > 5 AndAlso restart = False AndAlso _Initalized Then
                Dim ts As TimeSpan = Now.Subtract(_FirstErrorTime)
                If ts.Seconds + ts.Minutes * 60 > 30 Then restart = True
            End If

            '------------------------------------------------------------------
            '--------create a new alarm if it is does not exist yet------------
            '------------------------------------------------------------------
            'todo: setup for somesort of alarming if no communication to a board
            'If _ConcurrentAlarm > 5 AndAlso myMain.Alarms.isValid(m_Alarm) = False Then
            '    myMain.Alarms.CreateOpto(m_Alarm, ALM_BOARD, Me.Stats.Basic.Name, ErrorNumber.ToString.Replace("_"c, " "c)) '-1
            'End If

            '------------------------------------------------------------------
            '------------clear the opto modules value if in alarm-------------
            '------------------------------------------------------------------
            If _ConcurrentAlarm > 5 Then
                For Each xmod As IOPoint In Iopoints
                    If xmod.isInput Then
                        If isAnalog Then xmod.Analog = -4096 Else xmod.Digital = False
                    Else
                        If restart Then xmod.NeedsWrite = True
                    End If
                Next
            End If

            '------------------------------------------------------------------
            '----if the we need to reset this board, mark all outputs for -----
            '----------next writing and set the initalized to false------------
            '------------------------------------------------------------------
            If restart = True Then _Initalized = False
            If Not drv Is Nothing AndAlso ErrorNumber <> OptoDriverError.Port_Not_Connected Then
                Stats.LastError = drv.LastError.ToString
            End If

            retval = True
        Else
            '------------------------------------------------------------------
            'communicaion was restored, clear the error, reset the concurrent to 0
            '------------------------------------------------------------------
            _ConcurrentAlarm = 0
            Stats.InError = False
            retval = False
            If isWrite = False Then Stats.GoodReads += 1
        End If

        If isWrite Then Stats.Writes += 1 Else Stats.Reads += 1
        Return retval
    End Function

    ''' <summary>
    ''' this checks the configuration every 5 minutes (call from opto base) to see if it matches with the computers idea of IO
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub CheckConfiguration(ByVal drv As OptoDriver, timeout As Integer)
        Dim optoErr As OptoDriverError
        '------------------------------------------------------------------
        'don't evaulate any virtual boards, they pull from a remote compter
        'and the ReadConfiguration would fail.
        '------------------------------------------------------------------
        If Enabled = True AndAlso _Initalized = True Then
            Dim pos(15) As Boolean
            optoErr = drv.OptoReadConfiguration(CInt(Stats.Name), timeout, pos)
            If CheckforError(drv, optoErr, False, "Read Confiquration") = False Then
                For xloop As Integer = 0 To 15
                    If (pos(xloop) = True AndAlso Iopoints(xloop).isInput) OrElse (pos(xloop) = False AndAlso Iopoints(xloop).isInput = False) Then
                        '------------------------------------------------------------------
                        '-----returned i/o values did not match,must restart board---------
                        '------------------------------------------------------------------
                        _Initalized = False
                        Exit For
                    End If
                Next

            End If
        End If
    End Sub

    ''' <summary>
    ''' clears the needs write flags on the selected modules
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ClearNeedsWrite(ByVal Pos() As Boolean)
        For xloop As Integer = 0 To 15
            If Pos(xloop) Then Iopoints(xloop).NeedsWrite = False
        Next
    End Sub

    ''' <summary>
    ''' checks to see if any boards need a write
    ''' </summary>
    ''' <returns>true if write is needed</returns>
    ''' <remarks></remarks>
    Public Function CheckNeeedsWrite() As Boolean
        Dim needswrite As Boolean = False
        For Each x As IOPoint In Iopoints
            If x.NeedsWrite Then
                needswrite = True
                Exit For
            End If
        Next
        Return needswrite
    End Function

    ''' <summary>
    ''' Clears the status of this board back to 0
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> Public Sub ClearStat()
        Stats.ErrorCount = 0
        Stats.GoodReads = 0
        Stats.Reads = 0
        Stats.Writes = 0
        Stats.InError = False
        Stats.LastError = ""
    End Sub

    ''' <summary>
    ''' returns if a new name is ok or not
    ''' </summary>
    ''' <param name="newname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function isNewNameOK(newname As String) As Boolean
        Dim ret As Boolean = False
        Dim m As Match = Regex.Match(newname, "(\d{1,3})")
        If m.Success Then
            Dim n As Integer = CInt(m.Groups(1).Value)
            If n >= 0 AndAlso n <= 255 Then ret = True
        End If
        Return ret
    End Function

    ''' <summary>
    ''' show the properties for this commloop
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub ShowProperties()
        Dim ex As New OptoMuxBoard_Props(Me)
        If ex.ShowDialog() Then
            Me.Save()
        End If
    End Sub

#End Region

#Region "Analog Code"

    ''' <summary>
    ''' Updates all the module positions
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteReadAnalog(ByVal drv As OptoDriver, ByVal timeout As Integer)
        If Me.Enabled = True Then
            Dim thePos(15) As Boolean
            Dim thedata(15) As Integer
            Dim optoErr As OptoDriverError

            '---------------------------------------------------
            '----------Write the Analog Outputs-----------------
            '---------------------------------------------------
            If CheckNeeedsWrite() Then
                For xloop As Integer = 0 To Iopoints.Count - 1
                    If Iopoints(xloop).isInput = False Then ' AndAlso iopoints(xloop).NeedsWrite Then
                        thePos(xloop) = True
                        thedata(xloop) = Iopoints(xloop).Analog
                    End If
                Next
                optoErr = drv.OptoUpdateAnalogOutputs(CInt(Stats.Name), timeout, thePos, thedata)
                If Me.CheckforError(drv, optoErr, True, "Analog output not written") = False Then ClearNeedsWrite(thePos)
            End If

            '---------------------------------------------------
            '----------Read the Analog Outputs------------------
            '---------------------------------------------------
            If HasAny(False) AndAlso Not MyBase.NoReadOutputs Then
                optoErr = drv.OptoReadAnalogOutputs(CInt(Stats.Name), timeout, thedata)
                If Me.CheckforError(drv, optoErr, False, "Analog Output not Read") = False Then
                    For xloop As Integer = 0 To 15
                        If Iopoints(xloop).isInput = False Then
                            Iopoints(xloop).SetAnalog(thedata(xloop))
                        End If
                    Next
                End If
            End If


            '---------------------------------------------------
            '----------Read the Analog Inputs  -----------------
            '---------------------------------------------------
            If HasAny(True) Then
                optoErr = drv.OptoReadAnalogInputs(CInt(Stats.Name), timeout, thedata)
                If Me.CheckforError(drv, optoErr, False, "Analog Inputs not read") = False Then
                    For xloop As Integer = 0 To Iopoints.Count - 1
                        If Iopoints(xloop).isInput Then
                            Iopoints(xloop).SetAnalog(thedata(xloop))
                        End If
                    Next
                End If
            End If

        End If

    End Sub

    ''' <summary>
    ''' checks to see if there are any inputs or outputs on this rack to work with
    ''' </summary>
    ''' <remarks></remarks>
    Private Function HasAny(ByVal CheckInputs As Boolean) As Boolean
        Dim retval As Boolean = False
        For xloop As Integer = 0 To 15
            If Iopoints(xloop).isInput = CheckInputs Then
                retval = True
                Exit For
            End If
        Next
        Return retval
    End Function

#End Region

#Region "Digital Code"

    ''' <summary>
    ''' Updates all the module positions
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteReadDigital(ByVal drv As OptoDriver, ByVal timeout As Integer)
        If Me.Enabled = True Then

            Dim optoErr As OptoDriverError 'last retured opto error from the brain board/Comm
            Dim OnPos(15) As Boolean        'positions effected On (if applicable)
            Dim OffPos(15) As Boolean       'positions effected Off(if applicable)

            '-------------------------------------------------------------------
            '---------Set any Time delays for modules needing to be set---------
            '---------Turn on/off any Modules needing to be turned on/off-------
            '-------------------------------------------------------------------

            If Me.CheckNeeedsWrite Then
                Dim hasAnyOn, hasAnyOff As Boolean
                For xloop As Integer = 0 To Iopoints.Count - 1
                    If Iopoints(xloop).isInput = False Then

                        Dim add As Boolean = False
                        If Not (Iopoints(xloop).DigitalTimeDelay Is Nothing) AndAlso Iopoints(xloop).DigitalTimeDelay.isDelaySet Then
                            Dim pos() As Boolean = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
                            pos(xloop) = True
                            optoErr = drv.OptoSetTimeDelay(CInt(Stats.Name), timeout, pos, Iopoints(xloop).DigitalTimeDelay.DelayValue, Iopoints(xloop).DigitalTimeDelay.DelayType)
                            If Me.CheckforError(drv, optoErr, True, "Digital Outputs delay not Written.") = False Then Iopoints(xloop).DigitalTimeDelay.Clear()
                            add = True
                        ElseIf Iopoints(xloop).NeedsWrite Then
                            add = True
                        End If

                        If add Then
                            If Iopoints(xloop).Digital Then
                                OnPos(xloop) = True
                                hasAnyOn = True
                            Else
                                OffPos(xloop) = True
                                hasAnyOff = True
                            End If
                        End If

                    End If
                Next

                '------------Set the digital pulse modules only -------------------------------
                If hasAnyOn Then
                    optoErr = drv.OptoWriteDigialOutputsOn(CInt(Stats.Name), timeout, OnPos)
                    If Me.CheckforError(drv, optoErr, True, "Digital Outputs ON not Written.") = False Then Me.ClearNeedsWrite(OnPos)
                End If
                '------------Set the digital pulse modules only -------------------------------
                If hasAnyOff Then
                    optoErr = drv.OptoWriteDigialOutputsOff(CInt(Stats.Name), timeout, OffPos)
                    If Me.CheckforError(drv, optoErr, True, "Digital Outputs OFF not Written.") = False Then Me.ClearNeedsWrite(OffPos)
                End If

            End If

            '-----------------------------------------------------------------
            '---------Read the Status of all Input and Output modules---------
            '-----------------------------------------------------------------
            optoErr = drv.OptoReadOnOffStatus(CInt(Stats.Name), timeout, OnPos)
            If Me.CheckforError(drv, optoErr, False, "Read on/off Status Failed") = False Then
                For xloop As Integer = 0 To Iopoints.Count - 1
                    Iopoints(xloop).SetDigital(OnPos(xloop))
                Next
            End If
        End If

    End Sub

    ''' <summary>
    ''' clears the counting of off and on trips
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetSwitchCount()
        For xloop As Integer = 0 To Iopoints.Count - 1
            Iopoints(xloop).DigitalResetSwitchCount()
        Next
    End Sub

#End Region

End Class

