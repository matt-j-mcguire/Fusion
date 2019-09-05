
''' <summary>
''' uses a named/pair for connectors on blocks
''' </summary>
''' <remarks>name can only have a-z, A-Z, 0-9 and underscores</remarks>
Public Class Connector
    Private _owner As Block

    ''' <summary>
    ''' creates a new named / pair
    ''' </summary>
    ''' <param name="theName">name of this port</param>
    ''' <param name="is_input">for inputs or outputs</param>
    ''' <param name="is_Digital">if digital or analog values</param>
    ''' <remarks></remarks>
    Public Sub New(theName As String, is_input As Boolean, is_Digital As Boolean, Owner As Block)
        Name = theName
        isInput = is_input
        isDigital = is_Digital
        _owner = Owner
    End Sub

    ''' <summary>
    ''' name of this port
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Name As String

    ''' <summary>
    ''' if an input or output
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly isInput As Boolean

    ''' <summary>
    ''' if digital or analog values
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly isDigital As Boolean

    ''' <summary>
    ''' current value stored as a double floating value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As Double

    ''' <summary>
    ''' current value as a digital (boolean)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DigValue() As Boolean
        Get
            Return CBool(Value)
        End Get
        Set(xvalue As Boolean)
            If xvalue Then
                Value = 1
            Else
                Value = 0
            End If
        End Set
    End Property

    ''' <summary>
    ''' returns the current value as a user friendly name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValueAsString() As String
        If isDigital Then
            If Value = 0 Then
                Return "Off"
            Else
                Return "On"
            End If
        Else
            Return Value.ToString("#.##")
        End If
    End Function

    ''' <summary>
    ''' reference to incomming or outgoing wire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Wire() As Wire

    ''' <summary>
    ''' if there is a wire connected or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property isUsed() As Boolean
        Get
            Return Wire IsNot Nothing
        End Get
    End Property

    ''' <summary>
    ''' returns the block thats the owner of this connector
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Owner() As Block
        Get
            Return _owner
        End Get
    End Property

    ''' <summary>
    ''' used for the wire class to save to file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveString() As String
        Return _owner.UID & "." & Name
    End Function

    ''' <summary>
    ''' connects a wire
    ''' </summary>
    ''' <param name="w"></param>
    ''' <remarks></remarks>
    Public Sub Connect(w As Wire)
        If isInput Then
            w.To.Add(Me)
        Else
            w.From = Me
        End If
        Me.Wire = w
    End Sub

    ''' <summary>
    ''' removes a wire
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        If Wire IsNot Nothing Then
            If isInput Then
                Wire.To.Remove(Me)
            Else
                Wire.From = Nothing
            End If
            Me.Wire = Nothing
        End If
    End Sub


End Class
