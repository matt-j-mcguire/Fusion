
Public Enum KnowWireColor
    Black = 0
    Light_Gray = 1
    Gray = 2
    Dark_Gray = 3
    Red = 4
    Green = 5
    Lime = 6
    Light_Blue = 7
    Blue = 8
    Dark_Blue = 9
    Brown = 10
    Orange = 11
    Purple = 12
End Enum

''' <summary>
''' for the predefined wirecolors
''' </summary>
''' <remarks></remarks>
Public Structure WireColor

    Private _C As Color
    Private _t As KnowWireColor
    Private Const MaxColors As Integer = 13

    ''' <summary>
    ''' creates a new line color with the wanted knownwirecolor
    ''' </summary>
    ''' <param name="t"></param>
    ''' <remarks></remarks>
    Public Sub New(t As KnowWireColor)
        _t = t
        Select Case t
            Case KnowWireColor.Black
                _C = Color.Black
            Case KnowWireColor.Light_Gray
                _C = Color.LightGray
            Case KnowWireColor.Gray
                _C = Color.Gray
            Case KnowWireColor.Dark_Gray
                _C = Color.DarkGray
            Case KnowWireColor.Red
                _C = Color.Red
            Case KnowWireColor.Green
                _C = Color.Green
            Case KnowWireColor.Lime
                _C = Color.Lime
            Case KnowWireColor.Light_Blue
                _C = Color.LightBlue
            Case KnowWireColor.Blue
                _C = Color.CornflowerBlue
            Case KnowWireColor.Dark_Blue
                _C = Color.DarkBlue
            Case KnowWireColor.Brown
                _C = Color.Brown
            Case KnowWireColor.Orange
                _C = Color.Orange
            Case KnowWireColor.Purple
                _C = Color.Purple
            Case Else
                _C = Color.Black
                _t = KnowWireColor.Black
        End Select

    End Sub

    Public Function ToColor() As Color
        If _C.A = 0 Then
            Return Color.Black
        Else
            Return _C
        End If
    End Function

    Public Function CurrType() As KnowWireColor
        Return _t
    End Function

    Public Overrides Function ToString() As String
        Return _t.ToString
    End Function

    ''' <summary>
    ''' returns the image for the item
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ColorIcon() As Bitmap
        Return My.Resources.ResourceManager.GetObject("c_" & _t.ToString)
    End Function

    ''' <summary>
    ''' save as to string, but removes any "_" to be replaced with a space
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FriendlyName() As String
        Return _t.ToString.Replace("_", " ")
    End Function

#Region "Shared items"

    Public Shared ReadOnly Property Black() As WireColor
        Get
            Return New WireColor(KnowWireColor.Black)
        End Get
    End Property

    Public Shared ReadOnly Property Light_Gray() As WireColor
        Get
            Return New WireColor(KnowWireColor.Light_Gray)
        End Get
    End Property

    Public Shared ReadOnly Property Gray() As WireColor
        Get
            Return New WireColor(KnowWireColor.Gray)
        End Get
    End Property

    Public Shared ReadOnly Property Dark_Gray() As WireColor
        Get
            Return New WireColor(KnowWireColor.Dark_Gray)
        End Get
    End Property

    Public Shared ReadOnly Property Red() As WireColor
        Get
            Return New WireColor(KnowWireColor.Red)
        End Get
    End Property

    Public Shared ReadOnly Property Green() As WireColor
        Get
            Return New WireColor(KnowWireColor.Green)
        End Get
    End Property

    Public Shared ReadOnly Property Lime() As WireColor
        Get
            Return New WireColor(KnowWireColor.Lime)
        End Get
    End Property

    Public Shared ReadOnly Property Light_Blue() As WireColor
        Get
            Return New WireColor(KnowWireColor.Light_Blue)
        End Get
    End Property

    Public Shared ReadOnly Property Blue() As WireColor
        Get
            Return New WireColor(KnowWireColor.Blue)
        End Get
    End Property

    Public Shared ReadOnly Property Dark_Blue() As WireColor
        Get
            Return New WireColor(KnowWireColor.Dark_Gray)
        End Get
    End Property

    Public Shared ReadOnly Property Brown() As WireColor
        Get
            Return New WireColor(KnowWireColor.Brown)
        End Get
    End Property

    Public Shared ReadOnly Property Orange() As WireColor
        Get
            Return New WireColor(KnowWireColor.Orange)
        End Get
    End Property

    Public Shared ReadOnly Property Purple() As WireColor
        Get
            Return New WireColor(KnowWireColor.Purple)
        End Get
    End Property

    Public Shared Widening Operator CType(item As WireColor) As Color
        Return item.ToColor
    End Operator

    Public Shared Operator =(a As WireColor, b As WireColor) As Boolean
        Return a.CurrType = b.CurrType
    End Operator

    Public Shared Operator <>(a As WireColor, b As WireColor) As Boolean
        Return a.CurrType <> b.CurrType
    End Operator

    Public Shared ReadOnly Property FriendlyNames() As String()
        Get
            Dim ret As New List(Of String)
            Dim xstr() As String = [Enum].GetNames(GetType(KnowWireColor))

            For xloop As Integer = 0 To xstr.Length - 1
                ret.Add(xstr(xloop).Replace("_", " "))
            Next
            Return ret.ToArray
        End Get
    End Property

    ''' <summary>
    ''' can be one of the friendlynames
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FromName(name As String) As WireColor
        Dim v As KnowWireColor = KnowWireColor.Black
        name = name.Replace(" ", "_")
        [Enum].TryParse(Of KnowWireColor)(name, v)
        Return New WireColor(v)
    End Function

    Public Shared ReadOnly Property Count() As Integer
        Get
            Return MaxColors
        End Get
    End Property

#End Region

End Structure
