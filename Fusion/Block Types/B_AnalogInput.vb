
''' <summary>
''' represents a scalled analog input
''' </summary>
''' <remarks></remarks>
Public Class B_AnalogInput
    Inherits Block

    Public IOConnection As String
    Public IOp As IOPoint

    Public MaxInput As Double '% of fullsignal
    Public ScaleMin As Double
    Public ScaleMax As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        MaxInput = XHelper.Get(node, "MaxInput", 100.0)
        ScaleMin = XHelper.Get(node, "ScaleMin", 0.0)
        ScaleMax = XHelper.Get(node, "ScaleMax", 100.0)

        IOConnection = XHelper.Get(node, "IOpoint", "")
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "MaxInput", MaxInput)
        XHelper.Set(node, "ScaleMin", ScaleMin)
        XHelper.Set(node, "ScaleMax", ScaleMax)
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


        If IOp IsNot Nothing AndAlso myProject.RunType = RunStyle.Run Then
            Dim xin As Integer = IOp.Analog
            'get the percentage of the incomming value (based off of maxinput)
            Dim max As Double = xin / (IOp.MaxResolution * (MaxInput / 100))
            'scale the percentage from the scaled min and max values
            Dim v As Double = ((ScaleMax - ScaleMin) * max) + ScaleMin
            m_outputs(0).Value = v
        End If
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.AnalogInput
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_AnalogInput_Prop
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
