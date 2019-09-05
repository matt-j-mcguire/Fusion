
Public MustInherit Class Block
    Implements iBaseItem

    Protected m_Inputs As List(Of Connector)
    Protected m_outputs As List(Of Connector)
    Protected m_UIElement As i_UIelement
    Protected m_UID As String

    ''' <summary>
    ''' pulled from a file
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <remarks></remarks>
    Public Sub New(nd As XmlNode)
        m_Inputs = New List(Of Connector)
        m_outputs = New List(Of Connector)
        node = nd
        m_UID = XHelper.Get(node, "UID", "1-1")
        UserLabel = XHelper.Get(node, "Label", "")
    End Sub

    ''' <summary>
    ''' gets a block from the xml
    ''' </summary>
    ''' <param name="xnode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBlockItem(xnode As XmlNode) As Block
        Dim ret As Block = Nothing
        Dim tp As BlockType
        [Enum].TryParse(Of BlockType)(XHelper.Get(xnode, "BlockType", BlockType.Label.ToString), tp)
        Select Case tp
            Case Fusion.BlockType.label
                ret = New B_Label(xnode)
            Case Fusion.BlockType.And
                ret = New B_And(xnode)
            Case Fusion.BlockType.or
                ret = New B_Or(xnode)
            Case Fusion.BlockType.not
                ret = New b_Not(xnode)
            Case Fusion.BlockType.Nand
                ret = New B_Nand(xnode)
            Case Fusion.BlockType.Nor
                ret = New B_Nor(xnode)
            Case Fusion.BlockType.Exor
                ret = New B_Exor(xnode)
            Case Fusion.BlockType.Exnor
                ret = New B_Exnor(xnode)
            Case Fusion.BlockType.TruthTable
                ret = New B_TruthTable(xnode)
            Case Fusion.BlockType.Relay
                ret = New B_Relay(xnode)
            Case Fusion.BlockType.Cam
                ret = New B_Cam(xnode)
            Case Fusion.BlockType.TimedSequence
                ret = New B_TimedSequence(xnode)
            Case Fusion.BlockType.CompareD
                ret = New B_CompareDigital(xnode)
            Case Fusion.BlockType.CompareA
                ret = New B_CompareAnalog(xnode)
            Case Fusion.BlockType.Ramp
                ret = New B_Ramp(xnode)
            Case Fusion.BlockType.Scale
                ret = New B_Scale(xnode)
            Case Fusion.BlockType.Average
                ret = New B_Average(xnode)
            Case Fusion.BlockType.Switch
                ret = New B_Switch(xnode)
            Case Fusion.BlockType.ConstantD
                ret = New B_ConstantDigital(xnode)
            Case Fusion.BlockType.constantA
                ret = New B_ConstantAnalog(xnode)
            Case Fusion.BlockType.AlarmGenerator
                ret = New B_Alarm(xnode)
            Case Fusion.BlockType.AlarmManager
                ret = New B_AlarmManager(xnode)
            Case Fusion.BlockType.SettingA
                ret = New B_SettingAnalog(xnode)
            Case Fusion.BlockType.SettingD
                ret = New B_SettingDigital(xnode)
            Case Fusion.BlockType.SettingT
                ret = New B_SettingTimeSchedule(xnode)
            Case Fusion.BlockType.SettingC
                ret = New B_SettingCommand(xnode)
            Case Fusion.BlockType.SetReset
                ret = New B_SetReset(xnode)
            Case Fusion.BlockType.DigitalInput
                ret = New B_DigitalInput(xnode)
            Case Fusion.BlockType.DigitalOutput
                ret = New B_DigitalOutput(xnode)
            Case Fusion.BlockType.AnalogInput
                ret = New B_AnalogInput(xnode)
            Case Fusion.BlockType.AnalogOutput
                ret = New B_AnalogOutput(xnode)
            Case Fusion.BlockType.Temperature
                ret = New B_TemperatureProbe(xnode)
            Case Fusion.BlockType.Wetbulb
                ret = New B_WetBulb(xnode)
            Case Fusion.BlockType.JumpTo
                ret = New B_JumpTo(xnode)
            Case Fusion.BlockType.JumpFrom
                ret = New B_JumpFrom(xnode)
            Case Fusion.BlockType.AnalogToBinary
                ret = New B_AnalogToBinary(xnode)
            Case Fusion.BlockType.BinaryToAnalog
                ret = New B_BinaryToAnalog(xnode)
            Case Fusion.BlockType.BitShift
                ret = New B_BitShift(xnode)
            Case Fusion.BlockType.AddSubtract
                ret = New B_AddSubtract(xnode)
            Case Fusion.BlockType.MultiDivisor
                ret = New B_MultiDiv(xnode)
            Case Fusion.BlockType.Modulo
                ret = New B_Modulo(xnode)
            Case Fusion.BlockType.Counter
                ret = New B_Counter(xnode)
            Case Fusion.BlockType.Timer
                ret = New B_Timer(xnode)
            Case Fusion.BlockType.Random
                ret = New B_Random(xnode)
            Case Fusion.BlockType.PID
                ret = New B_PID(xnode)
        End Select
        Return ret
    End Function

    ''' <summary>
    ''' the first time on the screen being created
    ''' </summary>
    ''' <param name="xnode">new node to generate the item with</param>
    ''' <param name="theType">the type of block wanted</param>
    ''' <param name="uid">a uid to set</param>
    ''' <returns>a block item</returns>
    ''' <remarks></remarks>
    Public Shared Function GetNewBlockItem(xnode As XmlNode, theType As BlockType, uid As String) As Block
        XHelper.Set(xnode, "UID", uid)
        XHelper.Set(xnode, "BlockType", theType.ToString)
        Return GetBlockItem(xnode)
    End Function

    ''' <summary>
    ''' saves the base information
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Save() Implements iBaseItem.Save
        XHelper.Set(node, "UID", UID)
        XHelper.Set(node, "Label", UserLabel)
    End Sub

    ''' <summary>
    ''' returns all the connectors
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Allconnectors() As Connector()
        Get
            Dim lst As New List(Of Connector)
            lst.AddRange(m_Inputs.ToArray)
            lst.AddRange(m_outputs.ToArray)
            Return lst.ToArray
        End Get
    End Property

    ''' <summary>
    ''' returns a connector only by name
    ''' </summary>
    ''' <param name="name"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ConnectorByName(name As String) As Connector
        Get
            Dim ret As Connector = Nothing
            For xloop As Integer = 0 To m_Inputs.Count - 1
                If m_Inputs(xloop).Name = name Then
                    ret = m_Inputs(xloop)
                    Exit For
                End If
            Next
            If ret Is Nothing Then
                For xloop As Integer = 0 To m_outputs.Count - 1
                    If m_outputs(xloop).Name = name Then
                        ret = m_outputs(xloop)
                        Exit For
                    End If
                Next
            End If
            Return ret
        End Get
    End Property

    ''' <summary>
    ''' returns only the input connectors
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property InputConnectors() As Connector()
        Get
            Return m_Inputs.ToArray
        End Get
    End Property

    ''' <summary>
    ''' returns only the output connectors
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OutputConnectors() As Connector()
        Get
            Return m_outputs.ToArray
        End Get
    End Property

    ''' <summary>
    ''' finds the index of a connector
    ''' </summary>
    ''' <returns>return -1 if not found</returns>
    ''' <remarks></remarks>
    Public Function IndexOf(c As Connector) As Integer
        Dim ret As Integer = -1
        If c.isInput Then
            ret = m_Inputs.IndexOf(c)
        Else
            ret = m_outputs.IndexOf(c)
        End If
        Return ret

    End Function

    ''' <summary>
    ''' updates the block, returns true if the value changed
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Update()

    ''' <summary>
    ''' creates a new UI element
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetUI() As i_UIelement Implements iBaseItem.GetUI
        If m_UIElement IsNot Nothing Then
            Return m_UIElement
        Else
            Dim ex As New Block_UI(Me)
            m_UIElement = ex
            Return ex
        End If
    End Function

    ''' <summary>
    ''' xmlnode to save properties to
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property node As XmlNode Implements iBaseItem.node

    Public ReadOnly Property Type As BaseType Implements iBaseItem.Type
        Get
            Return BaseType.Block
        End Get
    End Property

    Public ReadOnly Property blockIOtype() As BlockIOtype
        Get
            Dim ret As BlockIOtype = Fusion.BlockIOtype.None
            If m_Inputs.Count > 0 Then ret = Fusion.BlockIOtype.InputOnly
            If m_outputs.Count > 0 Then ret += Fusion.BlockIOtype.OutputOnly
            Return ret
        End Get
    End Property

    Public ReadOnly Property UID() As String
        Get
            Return m_UID
        End Get
    End Property

    ''' <summary>
    ''' label is optional, used for user friendly label in the editor/HMI
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserLabel() As String

    ''' <summary>
    ''' a back reference to the page owner
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OwnerPage As Page

    ''' <summary>
    ''' the current type of block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property BlockType() As BlockType

    ''' <summary>
    ''' returns the icon for this block type
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIcon() As Bitmap
        Dim ret As Bitmap = Nothing
        Select Case Me.BlockType
            Case Fusion.BlockType.Label
                ret = My.Resources.b_label
            Case Fusion.BlockType.And
                ret = My.Resources.b_And
            Case Fusion.BlockType.Or
                ret = My.Resources.b_Or
            Case Fusion.BlockType.Not
                ret = My.Resources.b_Not
            Case Fusion.BlockType.Nand
                ret = My.Resources.b_nand
            Case Fusion.BlockType.Nor
                ret = My.Resources.b_nor
            Case Fusion.BlockType.Exor
                ret = My.Resources.b_Exor
            Case Fusion.BlockType.Exnor
                ret = My.Resources.b_Exnor
            Case Fusion.BlockType.TruthTable
                ret = My.Resources.b_truthtable
            Case Fusion.BlockType.Relay
                ret = My.Resources.b_relay
            Case Fusion.BlockType.Cam
                ret = My.Resources.B_cam
            Case Fusion.BlockType.TimedSequence
                ret = My.Resources.b_timedsequence
            Case Fusion.BlockType.CompareD
                ret = My.Resources.b_compareDig
            Case Fusion.BlockType.CompareA
                ret = My.Resources.b_compareAn
            Case Fusion.BlockType.Ramp
                ret = My.Resources.b_ramp
            Case Fusion.BlockType.Scale
                ret = My.Resources.b_scale
            Case Fusion.BlockType.Average
                ret = My.Resources.b_average
            Case Fusion.BlockType.Switch
                ret = My.Resources.b_switch
            Case Fusion.BlockType.ConstantD
                ret = My.Resources.b_conDig
            Case Fusion.BlockType.ConstantA
                ret = My.Resources.b_conAn
            Case Fusion.BlockType.AlarmGenerator
                ret = My.Resources.b_Alarm
            Case Fusion.BlockType.AlarmManager
                ret = My.Resources.b_AlarmMaster
            Case Fusion.BlockType.SettingA
                ret = My.Resources.b_settingAnalog
            Case Fusion.BlockType.SettingD
                ret = My.Resources.b_settingDigital
            Case Fusion.BlockType.SettingT
                ret = My.Resources.b_settingTime
            Case Fusion.BlockType.SettingC
                ret = My.Resources.b_settingCommand
            Case Fusion.BlockType.SetReset
                ret = My.Resources.b_setReset
            Case Fusion.BlockType.DigitalInput
                ret = My.Resources.b_DigitalInput
            Case Fusion.BlockType.DigitalOutput
                ret = My.Resources.b_DigitalOutput
            Case Fusion.BlockType.AnalogInput
                ret = My.Resources.b_AnalogInput
            Case Fusion.BlockType.AnalogOutput
                ret = My.Resources.b_AnalogOutput
            Case Fusion.BlockType.Temperature
                ret = My.Resources.b_temperature
            Case Fusion.BlockType.Wetbulb
                ret = My.Resources.b_Wetbulb
            Case Fusion.BlockType.JumpTo
                ret = My.Resources.b_jumpTo
            Case Fusion.BlockType.JumpFrom
                ret = My.Resources.b_jumpFrom
            Case Fusion.BlockType.AnalogToBinary
                ret = My.Resources.b_AnalogToBinary
            Case Fusion.BlockType.BinaryToAnalog
                ret = My.Resources.b_binaryToAnalog
            Case Fusion.BlockType.BitShift
                ret = My.Resources.b_Bitshift
            Case Fusion.BlockType.AddSubtract
                ret = My.Resources.b_addsub
            Case Fusion.BlockType.MultiDivisor
                ret = My.Resources.b_multiDiv
            Case Fusion.BlockType.Modulo
                ret = My.Resources.b_modulo
            Case Fusion.BlockType.Counter
                ret = My.Resources.b_counter
            Case Fusion.BlockType.Timer
                ret = My.Resources.b_timer
            Case Fusion.BlockType.Random
                ret = My.Resources.b_random
            Case Fusion.BlockType.PID
                ret = My.Resources.b_pid
        End Select
        Return ret
    End Function

    ''' <summary>
    ''' a simple name to fit in the UI for the block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property TextForBlock_UI() As String

    ''' <summary>
    ''' returns the standard Block_ui_props, unless overridden
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function GetPropsPage() As BaseItemProp

End Class
