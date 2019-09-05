
<CLSCompliant(True)> Public Delegate Sub OptoExchange(ByVal incomming As Boolean, ByVal data As String)

''' <summary>
''' internal-responce information from the recievResponce function
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> Public Class RecieveData
    ''' <summary>
    ''' the message of the data with out the "A" or checksum or "cr"
    ''' </summary>
    ''' <remarks></remarks>
    Public Message As String
    ''' <summary>
    ''' if the returnd check sum a valid or not
    ''' </summary>
    ''' <remarks></remarks>
    Public ChecksumValid As Boolean
    ''' <summary>
    ''' any error codes
    ''' </summary>
    ''' <remarks></remarks>
    Public Errors As OptoDriverError
End Class

''' <summary>
''' information about the last error generated
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> Public Structure LastErrorData
    ''' <summary>
    ''' what the error code recieved was
    ''' </summary>
    ''' <remarks></remarks>
    Public ErrorCode As String
    ''' <summary>
    ''' what the error messaged ment
    ''' </summary>
    ''' <remarks></remarks>
    Public Errors As OptoDriverError
    ''' <summary>
    ''' the time date that it happened
    ''' </summary>
    ''' <remarks></remarks>
    Public Time As Date


    Public Overrides Function ToString() As String
        Return ErrorCode & " " & Errors.ToString.Replace("_"c, " "c) & " [" & Time.ToString("M/d/yy h:mm:ss tt") & "]"
    End Function

End Structure

''' <summary>
''' what the last error generated was
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> Public Enum OptoDriverError
    None = 0
    OptoMux_PUC_Expected = 1
    OptoMux_Undefined_Command = 2
    OptoMux_Checksum_Error = 3
    OptoMux_Input_buffer_Overrun = 4
    OptoMux_Non_Printable_Character_Received = 5
    OptoMux_Data_Field_Error = 6
    OptoMux_Watch_Dog_Timeout = 7
    OptoMux_Invalid_Limits = 8
    OptoMux_Unknown_Error = 9
    Comm_Port_Closed = 10
    Comm_Port_General_Error = 11
    Received_Invalid_Checksum = 12
    Comm_Port_Timeout_Received = 13
    Comm_Port_Bad_Data_Received = 14
    Attempting_Remote_Connection = 20
    Port_Not_Connected = 100
End Enum

''' <summary>
''' for resetting the watch dog timer
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> Public Enum OptoWatchDogDelay
    Disabled = 0
    TenSecond = 1
    Minute = 2
    TenMinute = 3
End Enum

''' <summary>
''' how to set the timer 
''' </summary>
''' <remarks></remarks>
<CLSCompliant(True)> Public Enum OptoDelayType
    None = 0
    Off_Ton_Off = 1
    Off_Toff_On = 2
    On_Toff_On = 3
    On_ton_Off = 4
End Enum

''' <summary>
''' what type of board it is
''' </summary>
''' <remarks>not used in the driver</remarks>
<CLSCompliant(True)> Public Enum OptoBoardType
    Digital = 0
    Analog = 1
End Enum


