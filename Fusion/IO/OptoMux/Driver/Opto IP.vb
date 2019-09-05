

Public Class OptoIP
    Inherits OptoDriver

    ''' <summary>
    ''' the ip address or host name to resolve
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IPName() As String
    ''' <summary>
    ''' if tcp port to run on
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IpPort() As String
    ''' <summary>
    ''' the Socket object (if anything)
    ''' </summary>
    ''' <remarks></remarks>
    Public sock As TcpClient
    ''' <summary>
    ''' if this connection is trying to connect
    ''' </summary>
    ''' <remarks></remarks>
    Public isConnecting As Boolean

    Public Sub New(ByVal IP_Name As String, ByVal Port As Integer)
        IPName = IP_Name
        IpPort = Port
    End Sub

    ''' <summary>
    ''' opens the protocall 
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub open()
        If isConnecting = False Then
            sock = New TcpClient
            Dim tr As New Thread(AddressOf startConnection)
            tr.Name = "Start sock " & IPName
            tr.Start()
        End If

    End Sub

    ''' <summary>
    ''' starts the connection on a new xthread, too keep the connection from blocking
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub startConnection()
        isConnecting = True

        Try
            sock.Connect(IPName, IpPort)
            sock.ReceiveBufferSize = 256
            sock.SendBufferSize = 256
        Catch ex As Exception
            Try
                'somelogging of this error would be good
                My.Computer.FileSystem.WriteAllText("Err.txt", Now.ToString & ControlChars.CrLf & ex.ToString & ControlChars.CrLf & ControlChars.CrLf, True)
            Catch exy As Exception

            End Try
        Finally
            isConnecting = False
        End Try
    End Sub

    ''' <summary>
    ''' closes the protocall, and disposed any resources
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Close()
        If sock IsNot Nothing Then
            sock.Close()
            sock = Nothing
        End If
    End Sub

    ''' <summary>
    ''' if the port is currently trying to connect
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function isPortConnecting() As Boolean
        If isConnecting Then
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
        If sock Is Nothing Then
            Return False
        Else
            Return sock.Client.Connected
        End If
    End Function

    ''' <summary>
    ''' wrights the command to the serial output appending ">" and "cr" to the ends of the message
    ''' </summary>
    ''' <param name="TheCommand">the command to send</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function SendCommand(ByVal TheCommand As String) As OptoDriverError
        If sock IsNot Nothing AndAlso sock.Client.Connected Then
            Dim data As String = ">" & CheckSumAppend(TheCommand)
            If m_exchange IsNot Nothing Then m_exchange(False, data)

            Dim dat() As Byte = ASCIIEncoding.ASCII.GetBytes(data & CR)
            Dim gs As NetworkStream = sock.GetStream
            If gs.DataAvailable Then
                Dim bf(256) As Byte
                Dim cnt As Integer = gs.Read(bf, 0, 256)
                Dim xdat As String = ASCIIEncoding.ASCII.GetString(bf, 0, cnt)
                xdat = xdat.TrimEnd(New Char() {NullChar, CR})
            End If
            sock.ReceiveTimeout = 250
            sock.SendTimeout = 1000

            gs.Write(dat, 0, dat.Length)

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

            If sock IsNot Nothing AndAlso sock.Client.Connected Then
                Dim gs As NetworkStream = sock.GetStream
                '''''If Timeout > 0 Then op.sock.ReceiveTimeout = Timeout
                Dim buff(256) As Byte
                Dim btRead As Integer = 0
                Dim timeOuts As Integer = 0
                Do
                    If gs.DataAvailable Then
                        btRead += gs.Read(buff, btRead, 256 - btRead)
                        If buff(btRead - 2) = 13 Then Exit Do
                        timeOuts = 0
                    Else
                        timeOuts += 10
                        If timeOuts <= Timeout Then
                            Thread.Sleep(10)
                        Else
                            Exit Do
                        End If
                    End If
                Loop

                If timeOuts > Timeout Then
                    Throw New TimeoutException()
                ElseIf btRead > 0 Then
                    dat = ASCIIEncoding.ASCII.GetString(buff, 0, btRead)
                    dat = dat.TrimEnd(New Char() {NullChar, CR})
                Else
                    dat = ""
                End If
            Else
                dat = ""
                If isPortConnecting() = False Then
                    Me.open()
                End If
            End If

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
                sock.GetStream.Flush()
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
            If sock.Client.Connected Then sock.GetStream.Flush()
        Finally
            theData.Errors = OptoDriverError.Comm_Port_Bad_Data_Received
        End Try
    End Sub

End Class