
''' <summary>
''' bit shifts a incomming number right or left
''' </summary>
''' <remarks></remarks>
Public Class B_BitShift
    Inherits Block

    Public Enum Shift
        Left = 0
        Right = 1
    End Enum

    Public direction As Shift

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        direction = XHelper.Get(node, "direction", 1)

        m_Inputs.Add(New Connector("Value", True, False, Me))
        m_Inputs.Add(New Connector("Shift_By", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "direction", direction)
    End Sub

    Public Overrides Sub Update()
        Dim v As Long = CInt(m_Inputs(0).Value)
        Dim d As Integer = CInt(m_Inputs(1).Value)
        If direction = Shift.Left Then
            v <<= d
        Else
            v >>= d
        End If
        m_outputs(0).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.BitShift
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            If direction = Shift.Left Then
                Return "<<Bit"
            Else
                Return "Bit>>"
            End If
        End Get
    End Property


    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_BitShift_props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
