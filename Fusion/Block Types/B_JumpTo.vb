

Public Class B_JumpTo
    Inherits Block
    Implements iBlockIOoutput


    ''' <summary>
    ''' jump address of the remote "JumpFrom" block
    ''' </summary>
    ''' <remarks></remarks>
    Public Jump As Long
    Private _jf As B_JumpFrom

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        Jump = XHelper.Get(node, "Jump", 0L)
        m_Inputs.Add(New Connector("i_0", True, True, Me))
        m_Inputs.Add(New Connector("i_1", True, False, Me))

    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Jump", Jump)
    End Sub

    Public Overrides Sub Update()
        If _jf Is Nothing Or _jf.UID <> Jump Then
            _jf = myProject.GetBlock(Jump)
        End If


    End Sub

    Public Sub SyncOutput() Implements iBlockIOoutput.SyncOutput
        If _jf IsNot Nothing Then
            _jf.RecieveValue(m_Inputs(0).DigValue, m_Inputs(1).Value)
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.JumpTo
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Jump->"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_JumpTo_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
