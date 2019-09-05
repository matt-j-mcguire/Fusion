

<CLSCompliant(True)> Public MustInherit Class OptoDriver
    Implements IDisposable

    ''' <summary>
    ''' special end of line marker
    ''' </summary>
    ''' <remarks></remarks>
    Protected Const CR As Char = Chr(13)
    Protected Const NullChar As Char = Chr(0)
    ''' <summary>
    ''' contains the last error data information
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_lastError As LastErrorData
    ''' <summary>
    ''' for showing off the comms
    ''' </summary>
    ''' <remarks></remarks>
    Protected m_exchange As OptoExchange

    ''' <summary>
    ''' opens the protocall 
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Open()

    ''' <summary>
    ''' closes the protocall, and disposed any resources
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Close()

    ''' <summary>
    ''' if the port is currently trying to connect
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function isPortConnecting() As Boolean

    ''' <summary>
    ''' if the current port is connected
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function PortisGood() As Boolean

    ''' <summary>
    ''' for hooding up to get opto exchange info
    ''' </summary>
    ''' <param name="addr"></param>
    ''' <remarks></remarks>
    Public Sub ExchangeRegister(ByVal addr As OptoExchange)
        m_exchange = addr
    End Sub

    ''' <summary>
    ''' unhooks the exchange info
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExchangeUnRegister()
        m_exchange = Nothing
    End Sub

    ''' <summary>
    ''' returns the last data error created
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LastError() As LastErrorData
        Get
            Return m_lastError
        End Get
    End Property

#Region "Commands"

    ''' <summary>
    ''' Command 1 "A" first command sent after a power-up
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoPowerUpClear(ByVal BoardNum As Integer, ByVal Timeout As Integer) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "A")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 2 "B" Resets the optomum to power -up conditions
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoReset(ByVal BoardNum As Integer, ByVal Timeout As Integer) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "B")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 5 "F" instructs optomux to identify itself
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="BrdType">returns the board Analog or Digital if sucessfull</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoIdentifyOptomuxType(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByRef BrdType As OptoBoardType) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "F")
        If xerr = OptoDriverError.None Then

            Dim ret As RecieveData = RecievResponce(Timeout)
            If ret.Errors = OptoDriverError.None Then
                If ret.Message = "00" Then
                    BrdType = OptoBoardType.Digital
                Else
                    BrdType = OptoBoardType.Analog
                End If
            End If
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 3 "D" Sets a delay timer, for loss of comms to reset all outputs to off
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="delayType">how long to delay</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoSetDigitalWatchDogDelay(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal delayType As OptoWatchDogDelay) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "D" & CInt(delayType))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 45 "D" Sets a delay timer, for loss of comms to reset all outputs to zero scale
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="delayType">how long to delay</param>
    ''' <param name="pos">what positions to effect (16)</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoSetAnalowatchDogDelay(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal delayType As OptoWatchDogDelay, ByVal pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "D" & PositionstoHex(pos) & CInt(delayType))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 6 "G" configures the positions on the rack to outputs
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="OutputPos">the positions to convert to outputs (16)</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks>the positions in the OutputPos array marked false will default to inputs</remarks>
    Public Function OptoConfigurePositions(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal OutputPos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "G" & PositionstoHex(OutputPos))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 9 "J" turns off and on the digital output positions
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">an array of 16 positions of item to turn on or off, only effects outputs, inputs are ignored</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoWriteDigitalOutputs(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal Pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "J" & PositionstoHex(Pos))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 9 "K" turns on the digital output positions
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">an array of 16 positions of item to turn on, only effects outputs, inputs are ignored</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoWriteDigialOutputsOn(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal Pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "K" & PositionstoHex(Pos))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 9 "L" turns off the digital output positions
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">an array of 16 positions of item to turn off, only effects outputs, inputs are ignored</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoWriteDigialOutputsOff(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal Pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "L" & PositionstoHex(Pos))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 12 "M" Read all the positions for on/off status
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">a reference array, to be returnd back to caller of the status of all postions</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoReadOnOffStatus(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByRef Pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "M")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Try
                If ret.Errors = OptoDriverError.None Then
                    If ret.Message <> "" Then
                        Pos = HexToPositions(ret.Message)
                    End If
                End If
            Catch ex As Exception
                BadParse(ret)
            End Try

            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 25 "Z" Set the time delay for the digital output modules
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">an array of 16 positions of item set a delay, only effects outputs, inputs are ignored</param>
    ''' <param name="Delay">how long to delay in milliseconds 10ms resolution</param>
    ''' <param name="DelayType">how to initalize the timer</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoSetTimeDelay(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal Pos() As Boolean, ByVal Delay As Integer, ByVal DelayType As OptoDelayType) As OptoDriverError
        Dim cmd As String = ""
        Select Case DelayType
            Case OptoDelayType.None
                cmd = "G"
            Case OptoDelayType.Off_Ton_Off
                cmd = "H"
            Case OptoDelayType.Off_Toff_On
                cmd = "I"
            Case OptoDelayType.On_Toff_On
                cmd = "J"
            Case OptoDelayType.On_ton_Off
                cmd = "K"
        End Select

        Delay \= 10
        If Delay > 65535 Then Delay = 65535
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "Z" & PositionstoHex(Pos) & cmd & Delay.ToString("X"))
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 70 "j" reads the current I/O configuration setup
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">a reference array, to be returnd back to caller of the status of all postions</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoReadConfiguration(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByRef Pos() As Boolean) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "j")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Try
                If ret.Errors = OptoDriverError.None Then Pos = HexToPositions(ret.Message)
            Catch ex As Exception
                BadParse(ret)
            End Try
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 46 "S" writes to all the selected analog outputs different values
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="Pos">an array of the items to write to (16 pos)</param>
    ''' <param name="posData">the actual data to write 4095 to 0 (16 pos)</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoUpdateAnalogOutputs(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByVal Pos() As Boolean, ByVal posData() As Integer) As OptoDriverError
        Dim data As New StringBuilder
        For xloop As Integer = 15 To 0 Step -1
            If Pos(xloop) Then
                If posData(xloop) > 4095 Then posData(xloop) = 4095
                If posData(xloop) < 0 Then posData(xloop) = 0
                data.Append(posData(xloop).ToString("X3"))
            End If
        Next
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "S" & PositionstoHex(Pos) & data.ToString)
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 36 "K" reads all the digital outputs on the brain board, and returns as 16 position array
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="posData">a reference to an array to dump 16 values (analog inputs will be marked -1)</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoReadAnalogOutputs(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByRef posData() As Integer) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "KFFFF")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Try
                If ret.Errors = OptoDriverError.None AndAlso ret.Message IsNot Nothing Then
                    For xloop As Integer = 0 To 15
                        Dim sbs As String = ret.Message.Substring(xloop * 3, 3)
                        If sbs = "???" Then
                            posData(15 - xloop) = -1
                        Else
                            posData(15 - xloop) = CInt("&H" & sbs)
                        End If
                    Next
                End If
            Catch ex As Exception
                BadParse(ret)
            End Try

            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

    ''' <summary>
    ''' Command 37 "L" reads all the digital Inputs on the brain board, and returns as 16 position array
    ''' </summary>
    ''' <param name="BoardNum">the address to worked with</param>
    ''' <param name="Timeout">the timeout before giving up</param>
    ''' <param name="posData">a reference to an array to dump 16 values (analog outputs will be marked -1)</param>
    ''' <returns>opto error status if sucessfull or not</returns>
    ''' <remarks></remarks>
    Public Function OptoReadAnalogInputs(ByVal BoardNum As Integer, ByVal Timeout As Integer, ByRef posData() As Integer) As OptoDriverError
        Dim xerr As OptoDriverError = SendCommand(BoardNum.ToString("X2") & "LFFFF")
        If xerr = OptoDriverError.None Then
            Dim ret As RecieveData = RecievResponce(Timeout)
            Try
                If ret.Errors = OptoDriverError.None AndAlso ret.Message IsNot Nothing Then
                    For xloop As Integer = 0 To 15
                        Dim sbs As String = ret.Message.Substring(xloop * 4, 4)
                        If sbs = "????" Then
                            posData(15 - xloop) = -1
                        Else
                            posData(15 - xloop) = CInt("&H" & sbs) - &H1000
                        End If
                    Next
                End If
            Catch ex As Exception
                BadParse(ret)
            End Try

            Return ret.Errors
        Else
            Return xerr
        End If
    End Function

#End Region

    ''' <summary>
    ''' parsing failed, clear the input buffer and set the new error
    ''' </summary>
    ''' <param name="theData"></param>
    ''' <remarks></remarks>
    Protected MustOverride Sub BadParse(ByVal theData As RecieveData)

    ''' <summary>
    ''' convers an array of positions (16) to a binarry hex number
    ''' </summary>
    ''' <param name="pos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Shared Function PositionstoHex(ByVal pos() As Boolean) As String
        Dim bin As Integer = 0
        For xloop As Integer = 0 To 15
            bin += pos(xloop) And 2 ^ xloop
        Next
        Return bin.ToString("X4")
    End Function

    ''' <summary>
    ''' opsite of above, convers data from hex back to an array of positions
    ''' </summary>
    ''' <param name="data">data to parse</param>
    ''' <returns>an array of booleans</returns>
    ''' <remarks></remarks>
    Protected Shared Function HexToPositions(ByVal data As String) As Boolean()
        Dim pos(15) As Boolean
        Dim value As Integer = CInt("&H" & data)
        For xloop As Integer = 0 To 15
            If value And 2 ^ xloop Then pos(xloop) = True
        Next
        Return pos
    End Function

    ''' <summary>
    ''' appends a Checksum to the command to be sent
    ''' </summary>
    ''' <param name="Command">the parameter to parse</param>
    ''' <remarks>leave off the ">" char before this command and cr at the end</remarks>
    Protected Shared Function CheckSumAppend(ByVal Command As String) As String
        Dim bts() As Byte = ASCIIEncoding.ASCII.GetBytes(Command)
        Dim tot As Integer = 0
        For xloop As Integer = 0 To bts.Length - 1
            tot += bts(xloop)
        Next
        Dim remain As Integer = tot Mod 256
        Command &= remain.ToString("X2")
        Return Command
    End Function

    ''' <summary>
    ''' reviews a command to varify the checksum is correct
    ''' </summary>
    ''' <param name="Info">to command to parse</param>
    ''' <returns>true if the check sum matches</returns>
    ''' <remarks>leave off the cr at the end</remarks>
    Protected Shared Function CheckSumValid(ByVal Info As String) As Boolean
        If Info.StartsWith("N", StringComparison.OrdinalIgnoreCase) Then
            'error recieved, no checksum
            Return True
        ElseIf Info.Length = 1 Then
            'responce was just a Acr no checksum needed
            Return True
        Else
            'longer messages do require a checksum
            Dim bts() As Byte = ASCIIEncoding.ASCII.GetBytes(Info.ToCharArray, 1, Info.Length - 3)
            Try
                Dim chs As Integer = CInt("&H" & Info.Substring(Info.Length - 2))

                Dim tot As Integer = 0
                For xloop As Integer = 0 To bts.Length - 1
                    tot += bts(xloop)
                Next
                If tot Mod 256 = chs Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                'possible bad chars in the returned string
                'causing a bad parse of the value
                Return False
            End Try
        End If
    End Function

    ''' <summary>
    ''' returns the error code of the message
    ''' </summary>
    ''' <param name="theCommand">the returned command fom the comm port</param>
    ''' <returns>the error in the retured message</returns>
    ''' <remarks>filters out good messages and invalid error codes</remarks>
    Protected Shared Function GetErrorCode(ByVal theCommand As String) As OptoDriverError
        If theCommand.StartsWith("N", StringComparison.OrdinalIgnoreCase) Then
            Dim err As Integer = CInt(theCommand.Substring(1, 2)) + 1
            If err > 8 Then err = 9
            Return err
        Else
            Return OptoDriverError.None
        End If
    End Function

    ''' <summary>
    ''' wrights the command to the serial output appending ">" and "cr" to the ends of the message
    ''' </summary>
    ''' <param name="TheCommand">the command to send</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function SendCommand(ByVal TheCommand As String) As OptoDriverError

    ''' <summary>
    ''' reads from the serial port, for a set amount of time before giving up
    ''' </summary>
    ''' <param name="Timeout">how long to wait</param>
    ''' <returns>a recievedata structure with the trimmed message</returns>
    ''' <remarks></remarks>
    Protected MustOverride Function RecievResponce(ByVal Timeout As Integer) As RecieveData

#Region " IDisposable Support "

    ''' <summary>
    ''' To detect redundant calls
    ''' </summary>
    ''' <remarks></remarks>
    Private disposedValue As Boolean = False

    ''' <summary>
    '''  IDisposable
    ''' </summary>
    ''' <param name="disposing"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Try
                    Me.Close()
                Catch ex As Exception
                    'possible one already closed
                End Try
            End If
        End If
        Me.disposedValue = True
    End Sub

    ''' <summary>
    '''  This code added by Visual Basic to correctly implement the disposable pattern.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class

