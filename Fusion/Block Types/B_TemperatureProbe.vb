

Public Class B_TemperatureProbe
    Inherits Block

    Public Enum TemperatureType
        RTD = 0
        TypeJ = 1
        Linier = 2
        DoublKold = 3
    End Enum

    Public IOConnection As String
    Public IOp As IOPoint
    Public ProbeType As TemperatureType
    Public Offset As Integer
    Public LinierHi As Double
    Public LinierLo As Double


    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        ProbeType = XHelper.Get(node, "Type", 0)
        Offset = XHelper.Get(node, "Offset", 1113)
        LinierHi = XHelper.Get(node, "LinierHi", 100.0)
        LinierLo = XHelper.Get(node, "LinierLo", 0.0)
        IOConnection = XHelper.Get(node, "IOpoint", "")
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Sub ChangeExistingIOPoint(newConnetion As String)
        IOConnection = newConnetion
        IOp = Nothing
        'next call to update will re-establish the connecton
    End Sub


    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Type", CInt(ProbeType))
        XHelper.Set(node, "Offset", Offset)
        XHelper.Set(node, "LinierHi", LinierHi)
        XHelper.Set(node, "LinierLo", LinierLo)
        XHelper.Set(node, "IOpoint", IOConnection)
    End Sub

    Public Overrides Sub Update()
        If IOp Is Nothing AndAlso Not String.IsNullOrEmpty(IOConnection) Then
            IOp = myProject.IO.GetIOPoint(IOConnection)
        End If


        If IOp IsNot Nothing Then
            Dim v As Integer = IOp.Analog
            'scale the input value to 12bit
            Dim sc As Double = v / IOp.MaxResolution
            Dim xz As Double = sc * 4095 '&HFFF
            Dim value As Double = 0.0

            'caculate the temperature and send it out
            Select Case ProbeType
                Case TemperatureType.DoublKold
                    value = DKvalue(xz, Offset)
                Case TemperatureType.Linier
                    value = Linier(xz, LinierHi, LinierLo)
                Case TemperatureType.RTD
                    value = RTDvalue(xz)
                Case TemperatureType.TypeJ
                    value = Jvalue(xz)
            End Select
            m_outputs(0).Value = value
        End If
    End Sub

#Region "Caculations"

    Shared Function DKvalue(ByVal Raw As Integer, ByVal Offset As Integer) As Double
        Dim ScaleData As Double 'data after offset
        Dim calc As Double 'for calulation divisor
        Dim Retval As Double 'functions output

        'in case probe offset gets screwed up, use default
        If Offset <= 800 Or Offset >= 1300 Then Offset = 1113

        'get the scalled data
        ScaleData = Raw - Offset
        'caculate the divisor
        calc = ((0.00623 * ScaleData) - ((ScaleData * 0.0000028) * ScaleData)) + 25.7
        'make the temperature for the probe 
        Retval = ((ScaleData / calc) + 0.01)

        Return Retval
    End Function

    Shared Function Jvalue(ByVal Raw As Integer) As Double
        Dim ScaleData As Double = Raw
        Dim Retval As Double 'functions output

        'select the range that the raw data falls into
        Select Case ScaleData
            Case 0 To 161
                Retval = ((((ScaleData / 161) * 30) + 0.1) * 1.8) + 32
            Case 162 To 354
                Retval = (((((ScaleData - 161) / 193) * 35) + 30.19) * 1.8) + 32
            Case 355 To 551
                Retval = (((((ScaleData - 354) / 197) * 35) + 65.1) * 1.8) + 32
            Case 552 To 867
                Retval = (((((ScaleData - 551) / 316) * 55) + 100.15) * 1.8) + 32
            Case 868 To 1767
                Retval = (((((ScaleData - 867) / 899) * 155) + 155.1) * 1.8) + 32
        End Select

        Return Retval
    End Function

    Shared Function RTDvalue(ByVal Raw As Integer) As Double
        Dim ScaleData As Double = Raw
        Dim CelsTemp As Double
        Dim tempVal As Double
        Dim Retval As Double 'functions output

        'select the catigory that the rawvalue falls into
        If ScaleData > 6218 Then
            tempVal = (ScaleData - 6219) * 0.118525 - 135
            CelsTemp = tempVal - (-0.000188 * tempVal * tempVal) + 711.56
        ElseIf ScaleData > 4094 Then
            tempVal = (ScaleData - 4095) * 0.1082863 - 115
            CelsTemp = tempVal - (-0.00017 * tempVal * tempVal) + 462.76
        ElseIf ScaleData > 2110 Then
            tempVal = (ScaleData - 2111) * 0.1008065 - 100
            CelsTemp = tempVal - (-0.000156 * tempVal * tempVal) + 248.45
        Else
            tempVal = (ScaleData * 0.09474182) - 50
            CelsTemp = tempVal - (-0.000156 * tempVal * tempVal) - (0.0156 * tempVal) - 1.11
        End If

        'convert to degrees f
        Retval = ((CelsTemp * 9.0) / 5.0) + 32.0

        Return (Retval)
    End Function

    Shared Function Linier(ByVal Raw As Integer, hi As Integer, lo As Integer) As Double
        Dim tot As Integer = hi - lo
        Dim per As Double = Raw / 4095
        Dim tmp As Double = (tot * per) + lo
        Return tmp
    End Function

#End Region

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Temperature
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Temp."
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_TemperatureProbe_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
