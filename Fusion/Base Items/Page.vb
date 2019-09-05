Public Class Page
    Implements iItemCommonFunctions


    Public Blocks As List(Of Block)
    Public Wires As List(Of Wire)
    Public Node As XmlNode
    Public Name As String
    Public UID As Int32

    Public Sub New(ByVal nd As XmlNode)
        Node = nd
        Blocks = New List(Of Block)
        Wires = New List(Of Wire)

        Name = XHelper.Get(Node, "Name", "Page")
        UID = XHelper.Get(Node, "UID", -1)

        Dim nds As XmlNodeList = nd.SelectNodes("Block")
        For Each xnd As XmlNode In nds
            Dim b As Block = Block.GetBlockItem(xnd)
            b.OwnerPage = Me
            Blocks.Add(b)
        Next
        nds = nd.SelectNodes("Wire")
        For Each xnd As XmlNode In nds
            Dim w As Wire = New Wire(xnd, Me)
            If w.isValid Then Wires.Add(w)
        Next
    End Sub

    Public Sub New(ByVal nd As XmlNode, NewName As String, newUID As Integer)
        Node = nd
        Name = NewName
        UID = newUID

        Blocks = New List(Of Block)
        Wires = New List(Of Wire)
    End Sub

    ''' <summary>
    ''' saves all the current info back to the xml
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        XHelper.Set(Node, "Name", Name)
        XHelper.Set(Node, "UID", UID)
        For Each b As Block In Blocks
            b.Save()
        Next
        For Each w As Wire In Wires
            w.Save()
        Next
    End Sub

    ''' <summary>
    ''' stepps through the whole page of blocks and wires
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Sub Update()

        'outputonly means that the block has no input connectors, only outputs
        Dim itms() As Block = GetBlocksByType(BlockIOtype.OutputOnly)

        'clear all the prevous pass flags on each connector
        For xloop As Integer = 0 To Wires.Count - 1
            Wires(xloop).Flagged = False
        Next

        'starts the processing of this page of all the wires and blocks
        ProcessNext(itms)

        'finalize the writing of all the outputs to remote I/O or other blocks
        'inputonly means that the block has output connectors, only inputs
        itms = GetBlocksByType(BlockIOtype.InputOnly)
        For xloop As Integer = 0 To itms.Length - 1
            If TypeOf itms(xloop) Is iBlockIOoutput Then
                DirectCast(itms(xloop), iBlockIOoutput).SyncOutput()
            End If
        Next
    End Sub

    ''' <summary>
    ''' works the control tree
    ''' </summary>
    ''' <param name="Items">list of blocks to process on this loop</param>
    ''' <remarks></remarks>
    Private Sub ProcessNext(Items() As Block)
        Dim tW As New List(Of Wire)
        For xloop As Integer = 0 To Items.Length - 1
            Items(xloop).Update()
            For yloop As Integer = 0 To Items(xloop).OutputConnectors.Length - 1
                tW.Add(Items(xloop).OutputConnectors(yloop).Wire)
            Next
        Next

        If tW.Count > 0 Then
            Dim lst As New List(Of Block)
            For xloop As Integer = 0 To tW.Count - 1
                If tW(xloop).Update() Then
                    Dim con() As Connector = tW(xloop).To.ToArray
                    For yloop As Integer = 0 To con.Length - 1
                        'add the next block items to a collecion to be processed on
                        'the next loop
                        If Not lst.Contains(con(yloop).Owner) Then lst.Add(con(yloop).Owner)
                    Next
                End If
            Next
            ProcessNext(lst.ToArray)
        End If


    End Sub

#Region "Element getters"

    ''' <summary>
    ''' called from the wire class to parse a string
    ''' to get the connector to attach to
    ''' </summary>
    ''' <param name="input">something along the lines of longNumber.connectorName</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConnector(input As String) As Connector
        Dim ret As Connector = Nothing
        Dim m As Match = Regex.Match(input, "(\w+-\w+)\.(\w+)")

        If m.Success Then
            Dim l As String = m.Groups(1).Value
            Dim n As String = m.Groups(2).Value
            For xloop As Integer = 0 To Blocks.Count - 1
                If Blocks(xloop).UID = l Then
                    ret = Blocks(xloop).ConnectorByName(n)
                    Exit For
                End If
            Next
        End If
        Return ret
    End Function

    ''' <summary>
    ''' gets the block requested by UID
    ''' </summary>
    ''' <param name="uid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBlock(uid As String) As Block
        Dim ret As Block = Nothing
        For xloop As Integer = 0 To Blocks.Count - 1
            If Blocks(xloop).UID = uid Then
                ret = Blocks(xloop)
                Exit For
            End If
        Next
        Return ret
    End Function

    ''' <summary>
    ''' get an array of blocks by there type
    ''' </summary>
    ''' <param name="theType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBlocksByType(theType As BlockIOtype) As Block()
        Dim ret As New List(Of Block)
        For xloop As Integer = 0 To Blocks.Count - 1
            If Blocks(xloop).blockIOtype = theType Then
                ret.Add(Blocks(xloop))
            End If
        Next
        Return ret.ToArray
    End Function

    ''' <summary>
    ''' get an array of blocks by there type
    ''' </summary>
    ''' <param name="theType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBlocksByType(theType As Type) As Block()
        Dim ret As New List(Of Block)
        For xloop As Integer = 0 To Blocks.Count - 1
            If Blocks(xloop).GetType Is theType Then
                ret.Add(Blocks(xloop))
            End If
        Next
        Return ret.ToArray
    End Function

#End Region

#Region "Adder/Remover/cut/copy/paste for blocks and wires"

    ''' <summary>
    ''' generates a creates a new block
    ''' </summary>
    ''' <param name="theBlock"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddBlock(theBlock As BlockType) As Block
        Dim nd As XmlNode = XHelper.NodeAppendNew(Node, "Block")
        Dim b As Block = Block.GetNewBlockItem(nd, theBlock, GenerateNewUID)
        Blocks.Add(b)
        Return b
    End Function

    ''' <summary>
    ''' generates a new unique identification number for a new block about to be
    ''' added to the page.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GenerateNewUID() As String
        Dim low As Int32
        Dim rx As New Regex("\w+-(\d+)")

        'create a list of existing UID numbers
        'and retrieve them from each block 
        Dim lows As New List(Of Integer)
        For xloop As Integer = 0 To Blocks.Count - 1
            Dim m As Match = rx.Match(Blocks(xloop).UID)
            If m.Success Then
                lows.Add(CInt(m.Groups(1).Value))
            End If

        Next

        'start counting up to blocks.count+1, if we
        'come accross a number that does not already
        'exist in the collection, that is our new
        'low 32bit number
        For xloop As Integer = 0 To Blocks.Count + 1
            If Not lows.Contains(xloop) Then
                low = xloop
                Exit For
            End If
        Next

        'combine the high number (my UID int)
        'with the new found number and return
        'the result
        Return Me.UID & "-" & low
    End Function

    ''' <summary>
    ''' removes a block from the page
    ''' </summary>
    ''' <param name="theBlock">the block to remove</param>
    ''' <remarks>if connected wires are no longer valid
    ''' they will be removed also
    ''' </remarks>
    Public Sub RemoveBlock(theBlock As Block)
        Dim inx() As Connector = theBlock.Allconnectors()
        For xloop As Integer = 0 To inx.Length - 1
            Dim w As Wire = inx(xloop).Wire
            inx(xloop).Disconnect()
            If w IsNot Nothing AndAlso Not w.isValid Then RemoveWire(w)
        Next
        Blocks.Remove(theBlock)
        theBlock.node.ParentNode.RemoveChild(theBlock.node)
    End Sub

    ''' <summary>
    ''' adds a new wire to the page and returns the wire
    ''' </summary>
    ''' <param name="from">the output connector on a block</param>
    ''' <param name="to">the input connector on a block</param>
    ''' <returns>the new wire reference</returns>
    ''' <remarks>if there is already a wire existing, the [to] will be
    ''' added to the connections of the existing wire, else it will 
    ''' create a new wire
    ''' </remarks>
    Public Function AddWire([from] As Connector, [to] As Connector) As Wire
        Dim w As Wire = Nothing
        If [from].isUsed Then
            w = [from].Wire
            [to].Connect(w)
        Else
            Dim nd As XmlNode = XHelper.NodeAppendNew(Node, "Wire")
            w = New Wire(nd, Me, [from], [to])
        End If
        Wires.Add(w)
        Return w
    End Function

    ''' <summary>
    ''' disconnects and removes the wire from the page
    ''' </summary>
    ''' <param name="theWire"></param>
    ''' <remarks></remarks>
    Public Sub RemoveWire(theWire As Wire)
        Dim c As Connector = theWire.From
        If c IsNot Nothing Then c.Disconnect()
        Dim cs() As Connector = theWire.To.ToArray
        For xloop As Integer = 0 To cs.Length - 1
            If cs(xloop) IsNot Nothing Then cs(xloop).Disconnect()
        Next
        Wires.Remove(theWire)
    End Sub

    ''' <summary>
    ''' copies and then removes items from the screen
    ''' </summary>
    ''' <param name="items"></param>
    ''' <returns>the xmlnode(s) representation of the elements</returns>
    ''' <remarks></remarks>
    Public Function Cut(items() As iBaseItem) As XmlNode()
        'call the copy function to get all the xmlnodes first
        Dim ret() As XmlNode = Copy(items)

        'remove only the blocks from the list, by use
        'of 'removeBlock' if anywires that were attached
        'are now invalid then they also get removed.
        For xloop As Integer = 0 To items.Length - 1
            If TypeOf items(xloop) Is Block Then
                RemoveBlock(items(xloop))
                items(xloop) = Nothing
            End If
        Next

        Return ret
    End Function

    ''' <summary>
    ''' copies items from the screen
    ''' </summary>
    ''' <param name="items"></param>
    ''' <returns>the xmlnode(s) representation of the elements</returns>
    ''' <remarks></remarks>
    Public Function Copy(items() As iBaseItem) As XmlNode()
        Dim ret As New List(Of XmlNode)

        'saves and then copies all the xmlnodes, 
        'using a deep clone of the xml
        For xloop As Integer = 0 To items.Length - 1
            items(xloop).Save()
            Dim nd As XmlNode = items(xloop).node
            ret.Add(nd.CloneNode(True))
        Next

        Return ret.ToArray
    End Function

    ''' <summary>
    ''' Pastes items to the screen via xmlnode(s)
    ''' </summary>
    ''' <param name="items"></param>
    ''' <returns>the instance of the items</returns>
    ''' <remarks></remarks>
    Public Function Paste(items() As XmlNode) As iBaseItem()
        'make two lists of items
        '1 the blocks to paste first, each getting a new uid
        '2 the wires to hookup to the new blocks
        'when the blocks are getting the new numbers save a 
        'reference to the old one, so before the wires are added
        'update any of the references needed.
        Dim w As New List(Of XmlNode)
        Dim look As New Dictionary(Of String, String) 'key= old number,value = new number
        Dim ret As New List(Of iBaseItem)

        For xloop As Integer = 0 To items.Length - 1
            'incase from another document, convert the xml to this document
            items(xloop) = Node.OwnerDocument.ImportNode(items(xloop), True)

            If items(xloop).Name = "Wire" Then
                'work with the wires later
                w.Add(items(xloop))
            Else
                'convert the item with the new UID
                Dim xuid As String = XHelper.Get(items(xloop), "UID", "1-1")
                Dim tp As BlockType = XHelper.Get(items(xloop), "BlockType", 0)
                Dim nuid As String = GenerateNewUID()
                Dim bx As Block = Block.GetNewBlockItem(items(xloop), tp, nuid)
                look.Add(xuid, nuid)
                ret.Add(bx)
                Blocks.Add(bx)
            End If
        Next

        Dim rx As New Regex("(\w+-\w+)\.(\w+)")
        For xloop As Integer = 0 To w.Count - 1
            'convert the from tag from the older UID (stored
            'as the key in Look table) to the new UID by using
            'regex match to parse the value
            Dim xfrom As String = XHelper.Get(w(xloop), "from", "")
            Dim m As Match = rx.Match(xfrom)
            If m.Success Then
                Dim l As String = m.Groups(1).Value
                Dim n As String = m.Groups(2).Value
                l = look(l)
                XHelper.Set(w(xloop), "from", l & "." & n)
            End If

            'convert the 'to' tag from the older UID (stored
            'as the key in Look table) to the new UID by using
            'regex match to parse the value, there might be
            'more then one 'to' so the "to_cnt" must be checked 
            'first to figure out the count
            Dim cnt As Integer = XHelper.Get(w(xloop), "to_cnt", 1)
            For yloop As Integer = 0 To cnt - 1
                Dim xto As String = XHelper.Get(w(xloop), "to" & yloop, "")
                m = rx.Match(xto)
                If m.Success Then
                    Dim l As String = m.Groups(1).Value
                    Dim n As String = m.Groups(2).Value
                    l = look(l)
                    XHelper.Set(w(xloop), "to" & yloop, l & "." & n)
                End If
            Next

            'finally load up the final item as a wire
            Dim wx As New Wire(w(xloop), Me)
            If wx.isValid Then
                Wires.Add(wx)
                ret.Add(wx)
            End If
        Next
        Return ret.ToArray
    End Function

#End Region

    ''' <summary>
    ''' returns the name for this item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Name1 As String Implements iItemCommonFunctions.Name
        Get
            Return Name
        End Get
    End Property

    ''' <summary>
    ''' shows the properties of the project
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowProperties() Implements iItemCommonFunctions.ShowProperties
        Dim ex As New Page_Props(Me)
        If ex.ShowDialog() = DialogResult.OK Then
            Me.Save()
        End If
    End Sub

End Class
