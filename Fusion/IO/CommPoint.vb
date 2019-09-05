
''' <summary>
''' represents a single communication device on a commLoop, such as a Opto22 board
''' </summary>
''' <remarks>Abstract, inherit for actual communications</remarks>
Public MustInherit Class CommPoint
    Implements iItemCommonFunctions


    Public Node As XmlNode
    Public Iopoints As List(Of IOPoint)

#Region "public changable properties (vars)"
    ''' <summary>
    ''' the name of the item
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' when communicating, to ignore reading back outputs (if possible
    ''' </summary>
    ''' <remarks></remarks>
    Public NoReadOutputs As Boolean
    ''' <summary>
    ''' stats about this item
    ''' </summary>
    ''' <remarks></remarks>
    Public Stats As CommPoint_Info
    ''' <summary>
    ''' if enabled to communicate
    ''' </summary>
    ''' <remarks></remarks>
    Public Enabled As Boolean
#End Region

    Public Sub New(nd As XmlNode)
        Node = nd
        Iopoints = New List(Of IOPoint)
    End Sub

    ''' <summary>
    ''' for saving all the information back to the xml
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Save()

    ''' <summary>
    ''' gets or sets the user info for the commpoint_info
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserInfo() As String
        Get
            Return Stats.UserInfo
        End Get
        Set(value As String)
            Stats.UserInfo = value
        End Set
    End Property

    ''' <summary>
    ''' when renaming this item if the name is ok to use
    ''' </summary>
    ''' <param name="newname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function isNewNameOK(newname As String) As Boolean

    ''' <summary>
    ''' for showing the properties for this comm item
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub ShowProperties() Implements iItemCommonFunctions.ShowProperties

    Public ReadOnly Property Name1 As String Implements iItemCommonFunctions.Name
        Get
            Return Me.Name
        End Get
    End Property

End Class

''' <summary>
''' info about each Commpoint item
''' </summary>
''' <remarks></remarks>
<Serializable()> Public Structure CommPoint_Info
    ''' <summary>
    ''' name of this item
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' info about this commpoint
    ''' </summary>
    ''' <remarks></remarks>
    Public Description As String
    ''' <summary>
    ''' if in error
    ''' </summary>
    ''' <remarks></remarks>
    Public InError As Boolean
    ''' <summary>
    ''' how may error since launch of program
    ''' </summary>
    ''' <remarks></remarks>
    Public ErrorCount As Integer
    ''' <summary>
    ''' how many writes have occured since launch
    ''' </summary>
    ''' <remarks></remarks>
    Public Writes As Integer
    ''' <summary>
    ''' how mnay reads since launch
    ''' </summary>
    ''' <remarks></remarks>
    Public Reads As Integer
    ''' <summary>
    ''' how many good reads
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodReads As Integer
    ''' <summary>
    ''' last error recieved
    ''' </summary>
    ''' <remarks></remarks>
    Public LastError As String
    ''' <summary>
    ''' if currently enabled
    ''' </summary>
    ''' <remarks></remarks>
    Public Enabled As Boolean
    ''' <summary>
    ''' user set item information
    ''' </summary>
    ''' <remarks></remarks>
    Public UserInfo As String
End Structure
