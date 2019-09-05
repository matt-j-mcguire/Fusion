
''' <summary>
''' smallest base for the wire and block functions
''' </summary>
''' <remarks></remarks>
Public Interface iBaseItem

    Property node() As XmlNode

    Sub Save()

    ReadOnly Property Type() As baseType

    Function GetUI() As i_UIelement

End Interface

''' <summary>
''' special function to deal with syncing out to IO
''' </summary>
''' <remarks></remarks>
Public Interface iBlockIOoutput

    Sub SyncOutput()


End Interface

''' <summary>
''' common functions for some classes with properties
''' </summary>
''' <remarks></remarks>
Public Interface iItemCommonFunctions

    Sub ShowProperties()

    ReadOnly Property Name() As String

End Interface

''' <summary>
''' current Run style
''' </summary>
''' <remarks></remarks>
Public Enum RunStyle
    Simulate = 0
    Run = 1
End Enum

''' <summary>
''' what type of page element this is
''' </summary>
''' <remarks></remarks>
Public Enum BaseType
    Block = 0
    Wire = 1
End Enum

''' <summary>
''' how does this block function
''' </summary>
''' <remarks></remarks>
Public Enum BlockIOtype
    None = 0
    InputOnly = 1
    OutputOnly = 2
    Mixed = 3
End Enum

''' <summary>
''' function block types
''' </summary>
''' <remarks></remarks>
Public Enum BlockType
    [Label] = 0
    [And]
    [Or]
    [Not]
    Nand
    Nor
    Exor
    Exnor
    TruthTable
    Relay
    SetReset
    Cam
    TimedSequence
    CompareD
    CompareA
    Ramp
    Scale
    Average
    Switch
    ConstantD
    ConstantA
    AlarmGenerator
    AlarmManager
    SettingA
    SettingD
    SettingT
    SettingC
    DigitalInput
    DigitalOutput
    AnalogInput
    AnalogOutput
    Temperature
    JumpTo
    JumpFrom
    AnalogToBinary
    BinaryToAnalog
    BitShift
    AddSubtract
    MultiDivisor
    Modulo
    Counter
    Timer
    Random
    PID
    Wetbulb
End Enum

''' <summary>
''' base functions for drawing and working with on screen
''' </summary>
''' <remarks></remarks>
Public Interface i_UIelement

    ''' <summary>
    ''' if the point falls within this area
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns>true if within area</returns>
    ''' <remarks></remarks>
    Function HitTest(e As Point) As HitTestType

    ''' <summary>
    ''' for handling mouse movements
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Function MouseMove(e As MouseEventArgs) As Boolean

    ''' <summary>
    ''' for handling mouse down event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Function MouseDown(e As MouseEventArgs, ctrl As Boolean) As Boolean

    ''' <summary>
    ''' for handling mouse up event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Function MouseUp(e As MouseEventArgs) As Boolean



    ''' <summary>
    ''' returns the a control to be shown
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPropertyPageType() As BaseItemProp


    ''' <summary>
    ''' saves settings
    ''' </summary>
    ''' <remarks></remarks>
    Sub Save()

    ''' <summary>
    ''' paints the item to the screen
    ''' </summary>
    ''' <param name="g"></param>
    ''' <remarks></remarks>
    Sub Paint(g As Graphics, fnt As Font, running As Boolean, OrigonOffset As Point)

    ''' <summary>
    ''' if currently selected or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property selected() As Boolean

End Interface

Public Enum HitTestType
    None
    Block
    BlockInnerRec
    BlockConnectorInput
    BlockConnectorOutput
    Wire
End Enum
