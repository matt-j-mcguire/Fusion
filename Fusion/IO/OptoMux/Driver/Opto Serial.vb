

Public Class OptoSerial
    Inherits OptoDriver

    ''' <summary>
    ''' the serial port to connect to
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Port() As Integer
    ''' <summary>
    ''' the baud rate to run at
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Baud() As Integer
    ''' <summary>
    ''' the Comm port Object (if anything)
    ''' </summary>
    ''' <remarks></remarks>
    Private comm As SerialPort
    ''' <summary>
    ''' if the serial port is not able to open
    ''' </summary>
    ''' <remarks></remarks>
    Public SerialPortBad As Boolean


    Public Sub New(ByVal PortNumber As Integer, ByVal BaudRate As Integer)
        Port = PortNumber
        Baud = BaudRate

    End Sub


    ''' <summary>
    ''' opens the protocall 
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub open()
        Try
            Close()
            comm = New SerialPort("COM" & Port, Baud, Parity.None, 8, StopBits.One)
            comm.Open()
        Catch ex As IOException
            SerialPortBad = True
        End Try
    End Sub

    ''' <summary>
    ''' closes the protocall, and disposed any resources
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Close()
        If comm IsNot Nothing Then
            Try
                comm.Close()
            Catch ex As Exception
            End Try
            comm = Nothing
        End If
    End Sub

    ''' <summary>
    ''' if the port is currently trying to connect
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function isPortConnecting() As Boolean
        If SerialPortBad Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' if the current port is connected
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function PortisGood() As Boolean
        If SerialPortBad Then
            Return False
        Else
            If comm IsNot Nothing Then
                Return comm.IsOpen
            Else
                Return False
            End If
        End If
    End Function


    ''' <summary>
    ''' wrights the command to the serial output appending ">" and "cr" to the ends of the message
    ''' </summary>
    ''' <param name="TheCommand">the command to send</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function SendCommand(ByVal TheCommand As String) As OptoDriverError
        If comm IsNot Nothing AndAlso comm.IsOpen Then
            Dim data As String = ">" & CheckSumAppend(TheCommand)

            If m_exchange IsNot Nothing Then m_exchange(False, data)

            If comm.WriteTimeout <> 1000 Then
                comm.WriteTimeout = 1000
            End If
            Try
                comm.Write(data & CR)
            Catch ex As TimeoutException
                Return OptoDriverError.Comm_Port_Timeout_Received
            End Try
            Return OptoDriverError.None
        Else
            If isPortConnecting() = False Then
                Me.open()
            End If
            Return OptoDriverError.Comm_Port_Closed
        End If
    End Function

    ''' <summary>
    ''' reads from the serial port, for a set amount of time before giving up
    ''' </summary>
    ''' <param name="Timeout">how long to wait</param>
    ''' <returns>a recievedata structure with the trimmed message</returns>
    ''' <remarks></remarks>
    Protected Overrides Function RecievResponce(ByVal Timeout As Integer) As RecieveData
        Dim retval As New RecieveData
        Dim isconnecting As Boolean = False


        Try
            Dim dat As String = ""

            If Timeout > 0 AndAlso comm.ReadTimeout <> Timeout Then
                comm.ReadTimeout = Timeout
            End If
            dat = comm.ReadTo(CR)


            If m_exchange IsNot Nothing Then m_exchange(True, dat)
            If dat.StartsWith("N", StringComparison.OrdinalIgnoreCase) Then
                '=============error recieved==============
                Dim er As OptoDriverError = GetErrorCode(dat)
                With retval
                    .Message = ""
                    .Errors = er
                    .ChecksumValid = False
                End With
                With m_lastError
                    .Errors = er
                    .ErrorCode = dat
                    .Time = Now
                End With
            Else
                '=============possible good data==============
                If isconnecting = False AndAlso CheckSumValid(dat) Then
                    With retval
                        If dat.Length = 1 Then
                            .Message = ""
                        Else
                            .Message = dat.Substring(1, dat.Length - 3)
                        End If

                        .Errors = OptoDriverError.None
                        .ChecksumValid = True
                    End With
                ElseIf isconnecting Then
                    '==========Connection is attempting to connect =================
                    With retval
                        .Message = ""
                        .Errors = OptoDriverError.Attempting_Remote_Connection
                        .ChecksumValid = True
                    End With
                    With m_lastError
                        .Errors = OptoDriverError.Attempting_Remote_Connection
                        .ErrorCode = ""
                        .Time = Now
                    End With
                Else
                    '==========Check sum was not valid =================
                    With retval
                        .Message = ""
                        .Errors = OptoDriverError.Received_Invalid_Checksum
                        .ChecksumValid = False
                    End With
                    With m_lastError
                        .Errors = OptoDriverError.Received_Invalid_Checksum
                        .ErrorCode = ""
                        .Time = Now
                    End With
                End If
                comm.DiscardInBuffer()
            End If
        Catch te As TimeoutException
            '==============no valid data was reciedved on the comm port in the amount of time=========
            With retval
                .Message = ""
                .Errors = OptoDriverError.Comm_Port_Timeout_Received
                .ChecksumValid = False
            End With
            With m_lastError
                .Errors = OptoDriverError.Comm_Port_Timeout_Received
                .ErrorCode = ""
                .Time = Now
            End With
        Catch ipe As InvalidOperationException
            '======com port is closed or not valid mark the data========
            With retval
                .ChecksumValid = False
                .Errors = OptoDriverError.Comm_Port_Closed
                .Message = ""
            End With
            With m_lastError
                .ErrorCode = ""
                .Errors = OptoDriverError.Comm_Port_Closed
                .Time = Now
            End With
        Catch ioe As IOException
            '==============no valid data was reciedved on TCP/IP in the amount of time=========
            With retval
                .Message = ""
                .Errors = OptoDriverError.Comm_Port_Timeout_Received
                .ChecksumValid = False
            End With
            With m_lastError
                .Errors = OptoDriverError.Comm_Port_Timeout_Received
                .ErrorCode = ""
                .Time = Now
            End With
        Catch ex As Exception
            '========other type error===========
            With retval
                .ChecksumValid = False
                .Errors = OptoDriverError.Comm_Port_General_Error
                .Message = ""
            End With
            With m_lastError
                .ErrorCode = ""
                .Errors = OptoDriverError.Comm_Port_General_Error
                .Time = Now
            End With
        End Try

        Return retval
    End Function

    ''' <summary>
    ''' parsing failed, clear the input buffer and set the new error
    ''' </summary>
    ''' <param name="theData"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub BadParse(ByVal theData As RecieveData)
        Try
            If comm.IsOpen Then comm.DiscardInBuffer()
        Finally
            theData.Errors = OptoDriverError.Comm_Port_Bad_Data_Received
        End Try
    End Sub

End Class