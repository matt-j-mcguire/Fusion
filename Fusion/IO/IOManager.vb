
''' <summary>
''' manager over all the loops,points, and IOpoints
''' </summary>
''' <remarks></remarks>
Public Class IOManager

    ''' <summary>
    ''' a collection of comm loops
    ''' </summary>
    ''' <remarks></remarks>
    Public Loops As List(Of CommLoop)
    ''' <summary>
    ''' the xmlnode holding the settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Node As XmlNode
    ''' <summary>
    ''' if the loops are currently running or not
    ''' </summary>
    ''' <remarks></remarks>
    Private _Running As Boolean

    Public Sub New(nd As XmlNode)
        Node = nd
        Loops = New List(Of CommLoop)
        _Running = False

        For Each c As XmlNode In nd.ChildNodes
            Dim clp As CommLoop = CommLoop.CreateLoop(c)
            If clp IsNot Nothing Then Loops.Add(clp)
        Next
    End Sub

    ''' <summary>
    ''' tells each loop to save the settings
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        For Each l As CommLoop In Loops
            l.Save()
        Next
    End Sub

    ''' <summary>
    ''' starts or stopps the comm loops
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartStop() As Boolean
        Get
            Return _Running
        End Get
        Set(value As Boolean)
            For Each l As CommLoop In Loops
                l.StartStop = value
            Next
            _Running = value
        End Set
    End Property

    ''' <summary>
    ''' returns an I/O point based off of the lookup string
    ''' </summary>
    ''' <param name="LookUp">somethinglike Comm 4.101-1</param>
    ''' <returns></returns>
    ''' <remarks>See notes on IO point types</remarks>
    Public Function GetIOPoint(LookUp As String) As IOPoint
        Dim ret As IOPoint = Nothing

        Dim m As Match = Regex.Match(LookUp, "([0-9A-Ba-z]+)\.([0-9A-Ba-z]+)-([0-9A-Ba-z]+)")
        If m.Success Then
            For Each l As CommLoop In Loops
                ret = l.GetIOPoint(m.Groups(1).Value, m.Groups(2).Value, m.Groups(3).Value)
                If ret IsNot Nothing Then Exit For
            Next
        End If
        Return ret
    End Function

    Public Function GetIOPOintConnectionStrings(isAnalog As Boolean, isInput As Boolean) As String()
        Dim ret As New List(Of String)
        For Each cl As CommLoop In Loops
            For Each cp As CommPoint In cl.CommPoints
                For Each pt As IOPoint In cp.Iopoints
                    If pt.isInput = isInput AndAlso ((pt.Supports = IOPointSupports.Analog And isAnalog) Or (pt.Supports = IOPointSupports.Digital And Not isAnalog)) Then
                        ret.Add(cl.Name & "." & cp.Name & "-" & pt.Name)
                    End If
                Next
            Next
        Next
        Return ret.ToArray
    End Function

    ''' <summary>
    ''' adds a new commloop to the commloop collection
    ''' </summary>
    ''' <param name="tp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewCommLoop(tp As CommLoopType) As CommLoop
        Dim ret As CommLoop = Nothing

        Dim pn As XmlNode = XHelper.NodeCreate(Node.OwnerDocument, tp.ToString)
        Select Case tp
            Case CommLoopType.OptoMux
                Dim ex As New CommLoop_OptoMux_Props(pn)
                If ex.ShowDialog = DialogResult.OK Then
                    ret = ex.commloop
                End If
        End Select

        If ret IsNot Nothing Then
            Node.AppendChild(pn)
            Loops.Add(ret)
        End If
        Return ret
    End Function

    ''' <summary>
    ''' creates a comm loop from an xmlnode
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns>nothing if it failed</returns>
    ''' <remarks></remarks>
    Public Function AddLoop(nd As XmlNode) As CommLoop
        Dim ret As CommLoop = Nothing
        Try
            ret = CommLoop.CreateLoop(nd)
            Loops.Add(ret)
        Catch ex As Exception
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' removes a commloop from the collection
    ''' </summary>
    ''' <param name="n"></param>
    ''' <remarks></remarks>
    Public Sub RemoveLoop(n As CommLoop)
        Loops.Remove(n)
        n.Node.ParentNode.RemoveChild(n.Node)
    End Sub

    ''' <summary>
    ''' removes a commpoint from a commloop
    ''' </summary>
    ''' <param name="n"></param>
    ''' <remarks></remarks>
    Public Sub RemovePoint(n As CommPoint)
        For xloop As Integer = 0 To Loops.Count - 1
            If Loops(xloop).CommPoints.Contains(n) Then
                Loops(xloop).CommPoints.Remove(n)
                n.Node.ParentNode.RemoveChild(n.Node)
            End If
        Next
    End Sub

End Class


