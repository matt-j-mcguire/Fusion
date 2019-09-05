
Public Enum CommLoopType
    OptoMux = 0
    'fill in the others later
End Enum


''' <summary>
''' represents one logical comm grouping, such as a single serial port
''' </summary>
''' <remarks></remarks>
Public MustInherit Class CommLoop
    Implements iItemCommonFunctions



    ''' <summary>
    ''' xmlnode to save settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Node As XmlNode
    ''' <summary>
    ''' list of communication points
    ''' </summary>
    ''' <remarks></remarks>
    Public CommPoints As List(Of CommPoint)
    ''' <summary>
    ''' the name for this commloop
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String
    ''' <summary>
    ''' how long it takes to do one loop
    ''' </summary>
    ''' <remarks></remarks>
    Public LoopTime As String

    Public Sub New(nd As XmlNode)
        Node = nd
        CommPoints = New List(Of CommPoint)
    End Sub

    ''' <summary>
    ''' saves any settings back to the xml
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Save()

    ''' <summary>
    ''' for starting and stopping the loop
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Property StartStop() As Boolean

    ''' <summary>
    ''' the loop worker, launched by startstop, updates all sub CommPoints
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub DoWork()

    ''' <summary>
    ''' retrieves an io point from the passed references
    ''' </summary>
    ''' <param name="Drivername">the driver type</param>
    ''' <param name="Identifier">commpoint name</param>
    ''' <param name="Point">Io point name</param>
    ''' <returns>if not found, returns null</returns>
    ''' <remarks></remarks>
    Public Function GetIOPoint(Drivername As String, Identifier As String, Point As String) As IOPoint
        Dim ret As IOPoint = Nothing
        If Drivername = Me.Name Then
            For xloop As Integer = 0 To CommPoints.Count - 1
                If CommPoints(xloop).Name = Identifier Then
                    For Each iop As IOPoint In CommPoints(xloop).Iopoints
                        If iop.Name = Point Then
                            ret = iop
                            Exit For
                        End If
                    Next
                    If ret IsNot Nothing Then Exit For
                End If
            Next
        End If
        Return ret
    End Function

    ''' <summary>
    ''' what type of loop/driver is this
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property CommType As CommLoopType

    ''' <summary>
    ''' creates a new CommLoop
    ''' </summary>
    ''' <param name="nd">xmlnode to parse</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateLoop(nd As XmlNode) As CommLoop
        Dim tp As String = XHelper.Get(nd, "CommType", "OptoMux")
        Select Case tp.ToLower
            Case "optomux"
                Return New CommLoop_OptoMux(nd)
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' if this is a valid commloop node
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsVallidCommLoopNode(nd As XmlNode) As Boolean
        Dim ret As Boolean = False
        If nd.Name.ToLower = "optomux" Then
            ret = True
        End If
        Return ret
    End Function

    ''' <summary>
    ''' if this is a valid commpoint node for this typeof commloop
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function isVallidCommPoint(nd As XmlNode) As Boolean

    ''' <summary>
    ''' adds a new comm point to the system
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function AddNewCommPoint() As CommPoint

    ''' <summary>
    ''' adds a commpoints to the collection
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns>returns nothing if node is not valid for this type</returns>
    ''' <remarks></remarks>
    Public MustOverride Function AddPoint(nd As XmlNode) As CommPoint

    ''' <summary>
    ''' shows the propties dialog for the specific stuff
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub ShowPropertiesDialog()

    ''' <summary>
    ''' for showing the properties for this commloop
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub ShowProperties() Implements iItemCommonFunctions.ShowProperties

    Public ReadOnly Property Name1 As String Implements iItemCommonFunctions.Name
        Get
            Return Me.Name
        End Get
    End Property

End Class



