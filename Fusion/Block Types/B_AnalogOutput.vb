
''' <summary>
''' represents a scaled analog output
''' </summary>
''' <remarks></remarks>
Public Class B_AnalogOutput
    Inherits Block
    Implements iBlockIOoutput

    Public IOConnection As String
    Public IOp As IOPoint
    Public MaxValue As Double
    Public MaxOutput As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        IOConnection = XHelper.Get(node, "IOpoint", "")
        m_Inputs.Add(New Connector("o_i", True, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "IOpoint", IOConnection)
    End Sub

    Public Sub ChangeExistingIOPoint(newConnetion As String)
        IOConnection = newConnetion
        IOp = Nothing
        'next call to update will re-establish the connecton
    End Sub


    Public Overrides Sub Update()
        If IOp Is Nothing AndAlso Not String.IsNullOrEmpty(IOConnection) Then
            IOp = myProject.IO.GetIOPoint(IOConnection)
        End If
    End Sub

    Public Sub SyncOutput() Implements iBlockIOoutput.SyncOutput
        If IOp IsNot Nothing AndAlso myProject.RunType = RunStyle.Run Then
            Dim v As Double = m_Inputs(0).Value
            'get the percentage of full value
            Dim per As Double = v / MaxValue
            'get the actual range of the output
            Dim rng As Integer = IOp.MaxResolution * (MaxOutput / 100)
            'new output value is percentage x actual range
            IOp.Analog = (per * rng)
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.AnalogOutput
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_AnalogOutput_prop
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
