
Public Enum IOPointSupports
    Digital = 1
    Analog = 2
    DigitalTimeDelay = 4

End Enum


Public Class IOPoint

    ''' <summary>
    ''' name of this I/O point
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Name As String
    ''' <summary>
    ''' a flag for this io point that need writing
    ''' </summary>
    ''' <remarks></remarks>
    Public NeedsWrite As Boolean
    ''' <summary>
    ''' what type of functionallity this module supports
    ''' </summary>
    ''' <remarks></remarks>
    Private _supports As IOPointSupports
    ''' <summary>
    ''' what is the maximum value this io point can handle
    ''' </summary>
    ''' <remarks></remarks>
    Private _maxRes As Integer
    ''' <summary>
    ''' who is the master controller for this IO
    ''' </summary>
    ''' <remarks></remarks>
    Private _owner As CommPoint
    ''' <summary>
    ''' what the current value is
    ''' </summary>
    ''' <remarks></remarks>
    Private _Value As Integer
    ''' <summary>
    ''' when the last up date occured
    ''' </summary>
    ''' <remarks></remarks>
    Public LastChange As DateTime
    ''' <summary>
    ''' how many times since midnight this module has turned on
    ''' </summary>
    ''' <remarks></remarks>
    Public OnCount As Integer
    ''' <summary>
    ''' how many times since midnight this module has turned off
    ''' </summary>
    ''' <remarks></remarks>
    Public OffCount As Integer


    ''' <summary>
    ''' creates a new IO point
    ''' </summary>
    ''' <param name="thename">name of this point</param>
    ''' <param name="owner">who ownes this</param>
    ''' <param name="isthisInput">input or output</param>
    ''' <param name="MaxResolution">maximum value this module can work with</param>
    ''' <param name="supportsWhat">functionallity this item supports</param>
    ''' <remarks></remarks>
    Public Sub New(thename As String, owner As CommPoint, isthisInput As Boolean, MaxResolution As Integer, supportsWhat As IOPointSupports)
        Name = thename
        _owner = owner
        isInput = isthisInput
        _maxRes = MaxResolution
        _supports = supportsWhat
        CallerName = "Empty"
        _Value = 0
        LastChange = Now
    End Sub

    ''' <summary>
    ''' what type of functionallity this module supports
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Supports() As IOPointSupports
        Get
            Return _supports
        End Get
    End Property

    ''' <summary>
    ''' what is the maximum value this io point can handle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MaxResolution() As Integer
        Get
            Return _maxRes
        End Get
    End Property

    ''' <summary>
    ''' if this is an input or output
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isInput() As Boolean

    ''' <summary>
    ''' asked when a commpoint looses communications
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetValue()
        If isInput Then _Value = 0
    End Sub

    ''' <summary>
    ''' who is working with this IO piece
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CallerName() As String

#Region "Analog Code"

    ''' <summary>
    ''' get/sets the analog value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>when setting (if output), flaggs the needswrite</remarks>
    Public Property Analog() As Integer
        Get
            Return _Value
        End Get
        Set(value As Integer)
            If Not isInput Then
                If value > MaxResolution Then
                    value = MaxResolution
                ElseIf value < -(MaxResolution + 1) Then
                    value = -(MaxResolution + 1)
                End If
                If _Value <> value Then
                    _Value = value
                    LastChange = Now
                    NeedsWrite = True
                End If

            End If
        End Set
    End Property

    ''' <summary>
    ''' gets or sets the current value with scaled value
    ''' </summary>
    ''' <value></value>
    ''' <returns>whole value percentace of the current reading</returns>
    ''' <remarks>scales by MaxResolution, maximum allowed value</remarks>
    Public Property AnalogScaled() As Double
        <DebuggerStepThrough()> Get
            Return (_Value / MaxResolution) * 100
        End Get
        Set(ByVal value As Double)
            Dim tval As Integer = (value / 100) * MaxResolution
            If _Value <> tval Then
                _Value = tval
                LastChange = Now
                NeedsWrite = True
            End If
        End Set
    End Property

    ''' <summary>
    ''' just setts the value, only to be used by the CommPoint (owner)
    ''' </summary>
    ''' <param name="value">value to set</param>
    ''' <remarks></remarks>
    Public Sub SetAnalog(value As Integer)
        If _Value <> value Then
            _Value = value
            LastChange = Now
        End If
    End Sub

#End Region

#Region "Digital Code"

    ''' <summary>
    ''' basic on and off of the module
    ''' </summary>
    ''' <value>true or false</value>
    ''' <returns>current state of the module</returns>
    ''' <remarks></remarks>
    Public Property Digital() As Boolean
        <DebuggerStepThrough()> Get
            If _Value = 0 Then Return False Else Return True
        End Get
        Set(ByVal Value As Boolean)
            If _isInput = False AndAlso CBool(_Value) <> Value Then
                If Value = True Then
                    _Value = 1
                    OnCount += 1
                Else
                    _Value = 0
                    OffCount += 1
                End If

                NeedsWrite = True
                LastChange = Now
            End If
        End Set
    End Property

    ''' <summary>
    ''' used only for setting digital delays on outputs
    ''' </summary>
    ''' <param name="MilliTimeOut"></param>
    ''' <param name="delayType"></param>
    ''' <remarks></remarks>
    Public Sub DigitalDelay(ByVal MilliTimeOut As Integer, ByVal delayType As OptoDelayType, value As Boolean)
        If Not isInput Then
            If DigitalTimeDelay Is Nothing Then DigitalTimeDelay = New TimeDelays
            If DigitalTimeDelay.DelayOver Then
                DigitalTimeDelay.SetDelay(MilliTimeOut, delayType)
                Digital = value
            End If
        End If
    End Sub

    ''' <summary>
    ''' just setts the value, only to be used by the CommPoint (owner)
    ''' </summary>
    ''' <param name="value">value to set</param>
    ''' <remarks></remarks>
    Public Sub SetDigital(value As Boolean)
        If CBool(_Value) <> value Then
            If value = True Then
                _Value = 1
                OnCount += 1
            Else
                _Value = 0
                OffCount += 1
            End If
            LastChange = Now
        End If

    End Sub

    ''' <summary>
    ''' resets the digital on/off counts
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DigitalResetSwitchCount()
        OnCount = 0
        OffCount = 0
    End Sub

    ''' <summary>
    ''' for setting a time delay with a digital module
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DigitalTimeDelay As TimeDelays

#End Region

End Class

''' <summary>
''' represents Time delay that needs to be sent to the opto board
''' </summary>
''' <remarks></remarks>
Public Class TimeDelays
    Private _DelayValue As Integer      'length of the time delay
    Private _Type As OptoDelayType      'How the delay mods work
    Private _DelayWrote As Date         'the last time the delay write was used
    Private _ClearDelay As Boolean      'if to clear the delay time

    ''' <summary>
    ''' Sets up the delay to be sent in the next write
    ''' </summary>
    ''' <param name="delay">how long is the delay (milliseconds)</param>
    ''' <param name="delaytype">what type of delay will this be</param>
    ''' <remarks>delay limited to 655300 (MS) 10.9225 minutes</remarks>
    Public Sub SetDelay(ByVal delay As Integer, ByVal delaytype As OptoDelayType)
        If delay >= 655350 Then delay = 655300
        _DelayValue = delay
        If _Type <> OptoDelayType.None AndAlso delaytype = OptoDelayType.None Then _ClearDelay = True
        _Type = delaytype
    End Sub

    ''' <summary>
    ''' clears out the current delay and marks when
    ''' the last delay was actually sent to determin
    ''' if the delay is actually over or not.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        _DelayWrote = Now.AddSeconds(DelayValue / 1000)
        _DelayValue = 0
        _ClearDelay = False
    End Sub

    ''' <summary>
    ''' checks to see if there is a delay currently waiting
    ''' </summary>
    ''' <remarks></remarks>
    Public Function isDelaySet() As Boolean
        If (DelayValue > 0 AndAlso _Type > OptoDelayType.None) Or _ClearDelay Then Return True Else Return False
    End Function

    ''' <summary>
    ''' checks to see if the delay is over with,
    ''' if the delay has not been cleared yet, it 
    ''' will automatically return false, else it will
    ''' check the time stamp
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property DelayOver() As Boolean
        Get
            If isDelaySet() Then
                Return False
            Else
                Return (Now > _DelayWrote)
            End If
        End Get
    End Property

    ''' <summary>
    ''' returns the delay value in milliseconds
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property DelayValue() As Integer
        Get
            Return _DelayValue
        End Get
    End Property

    ''' <summary>
    ''' returns the optodelaytype
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property DelayType() As OptoDelayType
        Get
            Return _Type
        End Get
    End Property

End Class

