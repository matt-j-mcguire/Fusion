
<CLSCompliant(False)> Public NotInheritable Class Blts

#Region "get or set Bits by indexs"

    ''' <summary>
    ''' returns if a number is even or not
    ''' </summary>
    ''' <param name="num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Even(ByVal num As Integer) As Boolean
        Return If(num And 1, True, False)
    End Function

    ''' <summary>
    ''' returns if a bit is set with a signed integer (8,16,32,64 inflate)
    ''' </summary>
    ''' <param name="num">the number to check</param>
    ''' <param name="index">index position of the bit</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BitGet(ByVal num As Int64, ByVal index As Integer) As Boolean
        Return If(num And (1 << index), True, False)
    End Function

    ''' <summary>
    ''' returns if a bit is set with a Unsigned integer (u8,u16,u32,u64 inflate)
    ''' </summary>
    ''' <param name="num">the number to check</param>
    ''' <param name="index">index position of the bit</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BitGet(ByVal num As UInt64, ByVal index As Integer) As Boolean
        Return If(num And (1 << index), True, False)
    End Function

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">signed 64 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 62</remarks>
    Public Shared Sub BitSet(ByRef num As Int64, ByVal index As Integer, ByVal value As Boolean)
        If index < 63 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If
    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">unsigned 64 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 63</remarks>
    Public Shared Sub BitSet(ByRef num As UInt64, ByVal index As Integer, ByVal value As Boolean)
        If index < 64 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If

    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">signed 32 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 30</remarks>
    Public Shared Sub BitSet(ByRef num As Int32, ByVal index As Integer, ByVal value As Boolean)
        If index < 31 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If

    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">unsigned 32 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 31</remarks>
    Public Shared Sub BitSet(ByRef num As UInt32, ByVal index As Integer, ByVal value As Boolean)
        If index < 32 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If
    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">signed 16 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 14</remarks>
    Public Shared Sub BitSet(ByRef num As Int16, ByVal index As Integer, ByVal value As Boolean)
        If index < 15 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If
    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">unsigned 16 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 15</remarks>
    Public Shared Sub BitSet(ByRef num As UInt16, ByVal index As Integer, ByVal value As Boolean)
        If index < 16 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If
    End Sub

    ''' <summary>
    ''' sets a bit on or off based off the index
    ''' </summary>
    ''' <param name="num">8 bit int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <param name="value">on/off status</param>
    ''' <remarks>ignors any index greater than 7</remarks>
    Public Shared Sub BitSet(ByRef num As Byte, ByVal index As Integer, ByVal value As Boolean)
        If index < 8 Then
            If value Then
                num = num Or (1 << index)
            Else
                num = num And Not (1 << index)
            End If
        End If
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">signed 64 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 62</remarks>
    Public Shared Sub BitToggle(ByRef num As Int64, ByVal index As Integer)
        If index < 63 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">unsigned 64 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 63</remarks>
    Public Shared Sub BitToggle(ByRef num As UInt64, ByVal index As Integer)
        If index < 64 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">signed 32 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 30</remarks>
    Public Shared Sub BitToggle(ByRef num As Int32, ByVal index As Integer)
        If index < 31 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">unsigned 32 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 31</remarks>
    Public Shared Sub BitToggle(ByRef num As UInt32, ByVal index As Integer)
        If index < 32 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">signed 16 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 14</remarks>
    Public Shared Sub BitToggle(ByRef num As Int16, ByVal index As Integer)
        If index < 15 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">unsigned 16 int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 15</remarks>
    Public Shared Sub BitToggle(ByRef num As UInt16, ByVal index As Integer)
        If index < 16 Then num = num Xor (1 << index)
    End Sub

    ''' <summary>
    ''' toggles a bit to the reverse
    ''' </summary>
    ''' <param name="num">8 bit int to set</param>
    ''' <param name="index">index position of the bit</param>
    ''' <remarks>ignors any index greater than 7</remarks>
    Public Shared Sub BitToggle(ByRef num As Byte, ByVal index As Integer)
        If index < 8 Then num = num Xor (1 << index)
    End Sub

#End Region

#Region "get or set Nibbles"

    ''' <summary>
    ''' gets a nibble out of larger value
    ''' </summary>
    ''' <param name="Value">any integer base</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>will widen any value passed to a U64</remarks>
    Public Shared Function GetNibble(ByVal Value As Int64, ByVal bitpos As Integer) As Byte
        Value >>= bitpos
        Return Value Mod &H10
    End Function

    ''' <summary>
    ''' setts a nibble to the passed int overriding 4 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Nibble">4 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>any value in the Nibble greater then 0xF will be trimmed off</remarks>
    Public Shared Function SetNibble(ByVal value As Int64, ByVal Nibble As Byte, ByVal bitpos As Integer) As Int64
        Dim remove As UInt64 = GetNibble(value, bitpos)

        value = value Xor (remove << bitpos)
        'ensures that the nibble is not greater then 15
        If Nibble > &HF Then Nibble = Nibble Mod &H10
        value = value Or (Nibble << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a nibble to the passed int overriding 4 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Nibble">4 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>any value in the Nibble greater then 0xF will be trimmed off</remarks>
    Public Shared Function SetNibble(ByVal value As Int32, ByVal Nibble As Byte, ByVal bitpos As Integer) As Int32
        Dim remove As UInt32 = GetNibble(value, bitpos)

        value = value Xor (remove << bitpos)
        'ensures that the nibble is not greater then 15
        If Nibble > &HF Then Nibble = Nibble Mod &H10
        value = value Or (Nibble << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a nibble to the passed int overriding 4 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Nibble">4 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>any value in the Nibble greater then 0xF will be trimmed off</remarks>
    Public Shared Function SetNibble(ByVal value As Int16, ByVal Nibble As Byte, ByVal bitpos As Integer) As Int16
        Dim remove As UInt16 = GetNibble(value, bitpos)

        value = value Xor (remove << bitpos)
        'ensures that the nibble is not greater then 15
        If Nibble > &HF Then Nibble = Nibble Mod &H10
        value = value Or (Nibble << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a nibble to the passed int overriding 4 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Nibble">4 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>any value in the Nibble greater then 0xF will be trimmed off</remarks>
    Public Shared Function SetNibble(ByVal value As Byte, ByVal Nibble As Byte, ByVal bitpos As Integer) As Byte
        Dim remove As Byte = GetNibble(value, bitpos)

        value = value Xor (remove << bitpos)
        'ensures that the nibble is not greater then 15
        If Nibble > &HF Then Nibble = Nibble Mod &H10
        value = value Or (Nibble << bitpos)

        Return value
    End Function

#End Region

#Region "Get or Set Bytes"

    ''' <summary>
    ''' gets a byte out of larger value
    ''' </summary>
    ''' <param name="Value">any integer base</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>will widen any value passed to a 64</remarks>
    Public Shared Function GetByte(ByVal Value As Int64, ByVal bitpos As Integer) As Byte
        Value >>= bitpos
        Return Value Mod &H100
    End Function

    ''' <summary>
    ''' setts a byte to the passed int overriding 8 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="bite">8 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetByte(ByVal value As Int64, ByVal Bite As Byte, ByVal bitpos As Integer) As UInt64
        Dim remove As UInt64 = GetByte(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (Bite << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a byte to the passed int overriding 8 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Bite">8 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetByte(ByVal value As Int32, ByVal Bite As Byte, ByVal bitpos As Integer) As UInt32
        Dim remove As UInt32 = GetByte(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (Bite << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a byte to the passed int overriding 8 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Bite">8 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetByte(ByVal value As Int16, ByVal Bite As Byte, ByVal bitpos As Integer) As UInt16
        Dim remove As UInt16 = GetByte(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (Bite << bitpos)

        Return value
    End Function

#End Region

#Region "Get or Set UShort"

    ''' <summary>
    ''' gets a Unsigned short out of larger value
    ''' </summary>
    ''' <param name="Value">any integer base</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>will widen any value passed to a U64</remarks>
    Public Shared Function GetUShort(ByVal Value As Int64, ByVal bitpos As Integer) As UInt16
        Value >>= bitpos
        Return Value Mod &H1000
    End Function

    ''' <summary>
    ''' setts a uShort to the passed int overriding 16 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Ushrt">16 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetUshort(ByVal value As Int64, ByVal Ushrt As UShort, ByVal bitpos As Integer) As UInt64
        Dim remove As UInt64 = GetUShort(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (Ushrt << bitpos)

        Return value
    End Function

    ''' <summary>
    ''' setts a uShort to the passed int overriding 16 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="Ushrt">16 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetUshort(ByVal value As Int32, ByVal Ushrt As UShort, ByVal bitpos As Integer) As UInt32
        Dim remove As UInt32 = GetUShort(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (Ushrt << bitpos)

        Return value
    End Function

#End Region

#Region "Get Or Set UInt32"

    ''' <summary>
    ''' gets a unsigned 32bit integer out of larger value
    ''' </summary>
    ''' <param name="Value">any integer base</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks>will widen any value passed to a U64</remarks>
    Public Shared Function GetUint32(ByVal Value As Int64, ByVal bitpos As Integer) As UInt32
        Value >>= bitpos
        Return Value Mod &H100000000
    End Function

    ''' <summary>
    ''' setts a UInt32 to the passed int overriding 32 bits
    ''' </summary>
    ''' <param name="value">value to modify</param>
    ''' <param name="u32">32 bits to overrite with</param>
    ''' <param name="bitpos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetUint32(ByVal value As Int64, ByVal U32 As UInt32, ByVal bitpos As Integer) As UInt64
        Dim remove As UInt64 = GetUint32(value, bitpos)

        value = value Xor (remove << bitpos)
        value = value Or (U32 << bitpos)


        Return value
    End Function

    ''' <summary>
    ''' returns only hte high 32 bits
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetHigh32(ByVal value As Int64) As Int32
        value >>= 32
        Return value
    End Function

    ''' <summary>
    ''' returns only the lower 32 bits
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLow32(ByVal value As Int64) As Int32
        Return value Mod &H100000000
    End Function

    ''' <summary>
    ''' merges both int32s into a int64
    ''' </summary>
    ''' <param name="high"></param>
    ''' <param name="low"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetHighLow(high As Int32, low As Int32) As Int64
        Return (CLng(high) << 32) + low
    End Function

#End Region

#Region "Get or Set an array of bytes"

    ''' <summary>
    ''' returns an array of bytes for a unsigned 16bit integer
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>2 bytes</returns>
    ''' <remarks>lowest byte to highest</remarks>
    Public Shared Function GetBytes(ByVal Value As Int16) As Byte()
        Dim retval(1) As Byte
        retval(0) = Value Mod &H100
        retval(1) = (Value >> 8) Mod &H100
        Return retval
    End Function

    ''' <summary>
    ''' returns an array of bytes for a unsigned 32bit integer
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>4 bytes</returns>
    ''' <remarks>lowest byte to highest</remarks>
    Public Shared Function GetBytes(ByVal Value As Int32) As Byte()
        Dim retval(3) As Byte
        retval(0) = Value Mod &H100
        retval(1) = (Value >> 8) Mod &H100
        retval(2) = (Value >> 16) Mod &H100
        retval(3) = (Value >> 24) Mod &H100
        Return retval
    End Function

    ''' <summary>
    ''' returns an array of bytes for a unsigned 64bit integer
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>8 bytes</returns>
    ''' <remarks>lowest byte to highest</remarks>
    Public Shared Function GetBytes(ByVal Value As Int64) As Byte()
        Dim retval(7) As Byte
        retval(0) = Value Mod &H100
        retval(1) = (Value >> 8) Mod &H100
        retval(2) = (Value >> 16) Mod &H100
        retval(3) = (Value >> 24) Mod &H100
        retval(4) = (Value >> 32) Mod &H100
        retval(5) = (Value >> 40) Mod &H100
        retval(6) = (Value >> 48) Mod &H100
        retval(7) = (Value >> 56) Mod &H100
        Return retval
    End Function

    ''' <summary>
    ''' returns a Uint 64 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 8 bytes; 0=lowest byte 8=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 8 bytes the array will automatically be resized</remarks>
    Public Shared Function SetUBytes64(ByVal ParamArray bts() As Byte) As UInt64
        If bts.Length < 8 Then ReDim Preserve bts(7)

        Dim retval As UInt64
        For xloop As Integer = 7 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

    ''' <summary>
    ''' returns a Int 64 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 8 bytes; 0=lowest byte 8=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 8 bytes the array will automatically be resized</remarks>
    Public Shared Function SetSByte64(ByVal ParamArray bts() As Byte) As Int64
        If bts.Length < 8 Then ReDim Preserve bts(7)

        Dim retval As Int64
        For xloop As Integer = 7 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

    ''' <summary>
    ''' returns a Uint 32 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 4 bytes; 0=lowest byte 4=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 4 bytes the array will automatically be resized</remarks>
    Public Shared Function SetUBytes32(ByVal ParamArray bts() As Byte) As UInt64
        If bts.Length < 4 Then ReDim Preserve bts(3)

        Dim retval As UInt32
        For xloop As Integer = 3 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

    ''' <summary>
    ''' returns a Int 32 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 4 bytes; 0=lowest byte 4=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 4 bytes the array will automatically be resized</remarks>
    Public Shared Function SetSByte32(ByVal ParamArray bts() As Byte) As Int64
        If bts.Length < 4 Then ReDim Preserve bts(3)

        Dim retval As Int32
        For xloop As Integer = 3 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

    ''' <summary>
    ''' returns a Uint 16 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 2 bytes; 0=lowest byte 2=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 2 bytes the array will automatically be resized</remarks>
    Public Shared Function SetUBytes16(ByVal ParamArray bts() As Byte) As UInt64
        If bts.Length < 2 Then ReDim Preserve bts(1)

        Dim retval As UInt16
        For xloop As Integer = 1 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

    ''' <summary>
    ''' returns a Int 16 integer using an array of bytes
    ''' </summary>
    ''' <param name="bts">use 2 bytes; 0=lowest byte 2=highest</param>
    ''' <returns></returns>
    ''' <remarks>if less then 2 bytes the array will automatically be resized</remarks>
    Public Shared Function SetSByte16(ByVal ParamArray bts() As Byte) As Int64
        If bts.Length < 2 Then ReDim Preserve bts(1)

        Dim retval As Int16
        For xloop As Integer = 1 To 0 Step -1
            retval = retval Or bts(xloop) << 8 * xloop
        Next

        Return retval
    End Function

#End Region

End Class

