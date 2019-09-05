
''' <summary>
''' adds up or down
''' </summary>
''' <remarks></remarks>
Public Class B_Counter
    Inherits Block

    Private _lAdd As Boolean = False
    Private _lSub As Boolean = False

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Add", True, True, Me))
        m_Inputs.Add(New Connector("Subtract", True, True, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))

    End Sub



    Public Overrides Sub Update()
        Dim v As Integer = CInt(m_outputs(0).Value)
        If _lAdd <> m_Inputs(0).DigValue Then
            _lAdd = m_Inputs(0).DigValue
            v += 1
        End If
        If _lSub <> m_Inputs(1).DigValue Then
            _lSub = m_Inputs(1).DigValue
            v -= 1
        End If
        m_outputs(0).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Counter
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Cnt+"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_counter_props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
