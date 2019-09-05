
''' <summary>
''' Has a one second interval
''' </summary>
''' <remarks></remarks>
Public Class B_Timer
    Inherits Block

    '10,000 ticks in 1 millisecond
    '1,000 millisecons in on second
    '10,000,000
    Private Const _ticks As Integer = 10000
    Private _last As Int64

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        _last = Now.Ticks
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Update()
        Dim l As Int64 = Now.Ticks
        Dim diff As Int64 = (l - _last) / _ticks
        If diff >= 500 Then 'every half second
            m_outputs(0).DigValue = Not m_outputs(0).DigValue
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Timer
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Timer"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Timer_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
