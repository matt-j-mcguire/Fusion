
Public Class B_WetBulb
    Inherits Block

    Public ApproachAdd As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        ApproachAdd = XHelper.Get(node, "ApproachAdd", 15)
        m_Inputs.Add(New Connector("Temp", True, False, Me))
        m_Inputs.Add(New Connector("Humid", True, False, Me))
        m_outputs.Add(New Connector("Pounds", False, False, Me))
        m_outputs.Add(New Connector("WB", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "ApproachAdd", ApproachAdd)
    End Sub

    Public Overrides Sub Update()
        'get the current values from the sensors
        Dim sTemp As Double = m_Inputs(0).Value
        Dim sHumid As Double = m_Inputs(1).Value

        Dim SatWaterPress As Double 'Saturation Water pressure
        Dim ActWaterPress As Double 'the Actual Water Pressure
        Dim HumidtyRatio As Double  'the Humidity Ratio
        Dim SatEnthRatio As Double  'saturation enthalpy ratio

        'caculates the saturation Water pressure
        SatWaterPress = 0.018279513 + (0.001029904 * sTemp) + (0.00002579408 * sTemp ^ 2) + (0.0000002500493 * sTemp ^ 3) + (0.0000000008100939 * sTemp ^ 4) + _
            (0.00000000003256805 * sTemp ^ 5) + (-0.0000000000001001922199 * sTemp ^ 6) + (0.000000000000000244161 * sTemp ^ 7)
        'caculate the Actual Water Pressure
        ActWaterPress = sHumid * SatWaterPress
        'caculate the Humidity Ratio
        HumidtyRatio = (0.62198 * ActWaterPress) / (14.7 - ActWaterPress)
        'caculate the saturation enthalpy ratio
        SatEnthRatio = (0.24 * sTemp) + (HumidtyRatio * (1061 + (0.444 * sTemp)))
        'Cacultate the final wetbulb value
        Dim v As Double = -2.573698 + (3.487651 * SatEnthRatio) + (-0.05356738 * SatEnthRatio ^ 2) + (0.0004655972 * SatEnthRatio ^ 3) + (-0.000001540706 * SatEnthRatio ^ 4) + _
            (-0.00000000004580241 * SatEnthRatio ^ 5) + (0.00000000004568488 * SatEnthRatio ^ 6) + (-0.00000000000008833026 * SatEnthRatio ^ 7)


        Dim tTemp As Double = v + ApproachAdd
        Dim p As Double = (tTemp ^ 2) * 0.016 + (tTemp * 0.035) + 33.25

        m_outputs(0).Value = p
        m_outputs(1).Value = v
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Wetbulb
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return ""
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_WetBulb_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function


End Class
