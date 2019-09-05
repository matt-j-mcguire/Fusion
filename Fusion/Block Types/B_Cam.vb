
''' <summary>
''' Cam
''' </summary>
''' <remarks>
''' </remarks>
Public Class B_Cam
    Inherits Block

    ''' <summary>
    ''' the last incomming call
    ''' </summary>
    ''' <remarks></remarks>
    Private _lastIn As Boolean = False
    ''' <summary>
    ''' current output index
    ''' </summary>
    ''' <remarks></remarks>
    Private _Index As Integer = 0

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        m_Inputs.Add(New Connector("Trigger", True, True, Me))
        m_Inputs.Add(New Connector("Reset", True, True, Me))

        Dim cnt As Integer = XHelper.Get(node, "Count", 2)
        For xloop As Integer = 0 To cnt - 1
            m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
        Next

    End Sub

    ''' <summary>
    ''' changes the ammount of output connectors
    ''' </summary>
    ''' <param name="cnt"></param>
    ''' <remarks></remarks>
    Public Sub ChangeConnectorCount(cnt As Integer)
        If cnt > m_outputs.Count Then
            For xloop As Integer = m_outputs.Count To cnt - 1
                m_outputs.Add(New Connector("o_" & xloop, False, True, Me))
            Next
        Else
            For xloop As Integer = cnt To m_outputs.Count - 1 Step -1
                If m_outputs(xloop).isUsed Then m_outputs(xloop).Disconnect()
                m_outputs.RemoveAt(xloop)
            Next
        End If
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Count", m_outputs.Count)
    End Sub

    Public Overrides Sub Update()
        'check for a change in the input ("trigger")
        If _lastIn <> m_Inputs(0).DigValue Then
            _lastIn = m_Inputs(0).DigValue
            'index up one if we are on an "on" value
            If _lastIn Then
                _Index += 1
                If _Index > m_outputs.Count - 1 Then _Index = 0
            End If
        End If

        'check the reset input for setting back to 0
        If m_Inputs(1).DigValue Then _Index = 0

        'update the outputs
        For xloop As Integer = 0 To m_outputs.Count - 1
            m_outputs(xloop).DigValue = (xloop = _Index)
        Next

    End Sub


    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Cam
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "cam"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Cam_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
