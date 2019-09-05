
''' <summary>
''' provides a base to recieve a value from another "jump to" block
''' </summary>
''' <remarks>has both analog and digital</remarks>
Public Class B_JumpFrom
    Inherits Block

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_outputs.Add(New Connector("o_0", False, True, Me))
        m_outputs.Add(New Connector("o_1", False, False, Me))
    End Sub


    Public Sub RecieveValue(b As Boolean, a As Double)
        m_outputs(0).DigValue = b
        m_outputs(1).Value = a
    End Sub

    Public Overrides Sub Update()
        'does nothing for this block
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.JumpFrom
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "->Jump"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_JumpFrom_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
