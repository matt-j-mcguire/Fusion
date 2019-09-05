''' <summary>
''' get or set the bits for 8 bits
''' </summary>
''' <remarks></remarks>
Public Structure BitArr8

    Public Sub New(ByVal value As Byte)
        Int = value
    End Sub

    Public Property Int() As Byte

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for 16 bits
''' </summary>
''' <remarks></remarks>
Public Structure BitArr16

    Public Sub New(ByVal value As Int16)
        Int = value
    End Sub

    Public Property Int() As Int16

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for U16 bits
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False)> Public Structure BitArrU16

    Public Sub New(ByVal value As UInt16)
        Int = value
    End Sub

    Public Property Int() As UInt16

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for 32 bits
''' </summary>
''' <remarks></remarks>
Public Structure BitArr32

    Public Sub New(ByVal value As Int32)
        Int = value
    End Sub

    Public Property Int() As Int32

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for U32 bits
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False)> Public Structure BitArrU32

    Public Sub New(ByVal value As UInt32)
        Int = value
    End Sub

    Public Property Int() As UInt32

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for 64 bits
''' </summary>
''' <remarks></remarks>
Public Structure BitArr64

    Public Sub New(ByVal value As Int64)
        Int = value
    End Sub

    Public Property Int() As Int64

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure

''' <summary>
''' get or set the bits for U64 bits
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False)> Public Structure BitArrU64

    Public Sub New(ByVal value As UInt64)
        Int = value
    End Sub

    Public Property Int() As UInt64

    Public Property bit(ByVal index As Integer) As Boolean
        Get
            Return Blts.BitGet(Int, index)
        End Get
        Set(ByVal value As Boolean)
            Blts.BitSet(Int, index, value)
        End Set
    End Property

End Structure



