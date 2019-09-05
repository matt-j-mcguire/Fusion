
''' <summary>
''' container for all io points and control logic
''' </summary>
''' <remarks></remarks>
Public Class Project
    Implements iItemCommonFunctions


#Region "Public Vars"
    ''' <summary>
    ''' the collection of control pages
    ''' </summary>
    ''' <remarks></remarks>
    Public Pages As List(Of Page)
    ''' <summary>
    ''' the manager of all the IO points
    ''' </summary>
    ''' <remarks></remarks>
    Public IO As IOManager
    ''' <summary>
    ''' lets block inputs and outputs know if
    ''' they can work with an actual I/O point
    ''' </summary>
    ''' <remarks></remarks>
    Public RunType As RunStyle
    ''' <summary>
    ''' the file name to save things
    ''' </summary>
    ''' <remarks></remarks>
    Public FileName As String
    ''' <summary>
    ''' if the file currently needs saved
    ''' </summary>
    ''' <remarks></remarks>
    Public NeedsSave As Boolean
    ''' <summary>
    ''' the name of the project
    ''' </summary>
    ''' <remarks></remarks>
    Public Name As String

#End Region

#Region "Private Vars"
    ''' <summary>
    ''' the document to work with
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents _xml As XmlDocument
    ''' <summary>
    ''' the node for this project
    ''' </summary>
    ''' <remarks></remarks>
    Public Node As XmlNode
    ''' <summary>
    ''' if we sucussfull loaded up
    ''' </summary>
    ''' <remarks></remarks>
    Private _canRun As Boolean
    ''' <summary>
    ''' for processing the updates on the pages
    ''' </summary>
    ''' <remarks></remarks>
    Private _workThread As Thread
    ''' <summary>
    ''' flag for allowing the loop to work
    ''' </summary>
    ''' <remarks></remarks>
    Private _AllowWork As Boolean
    ''' <summary>
    ''' when the system and do a save
    ''' </summary>
    ''' <remarks></remarks>
    Private _NextSaveTime As DateTime
    ''' <summary>
    ''' if the current project is running or not
    ''' </summary>
    ''' <remarks></remarks>
    Private _isRunning As Boolean
#End Region

    ''' <summary>
    ''' opens a new or existing project
    ''' </summary>
    ''' <param name="TheFile">the file to open or save as</param>
    ''' <param name="Create">if to open or create as new</param>
    ''' <remarks></remarks>
    Public Sub New(TheFile As String, Create As Boolean)
        FileName = TheFile
        _canRun = False
        myLog = New EventLogger(Application.StartupPath, 365)

        Dim allbad As Boolean = False
        If Create Then
            'create a new empty Project from scratch
            _xml = XHelper.CreateNewDocument("Project")
            Dim p As XmlNode = _xml.SelectSingleNode("Project")
            XHelper.NodeAppendNew(p, "IO")
            _xml.Save(TheFile)
        Else
            'this section will try to load up the last xml config
            'file, if it is damaged, then it will attempt to open
            'up any one of the prevous days of the week backup
            'config file. if it finds a good file it will load up
            'the contents to the  _xml doc.
            Dim xFile As New FileInfo(TheFile)
            Try
                _xml = New XmlDocument
                _xml.Load(TheFile)
            Catch ex As Exception
                'the file was currupted go backwards through the days
                'until i find a file thats still good.
                myLog.WriteInfo("Main config file was damaged")
                Dim foundgood As Boolean = False
                Dim base As String = xFile.FullName.Replace(xFile.Extension, "")
                For xloop As Integer = 1 To 7
                    Dim dt As Date = Now.AddDays(-xloop)
                    myLog.WriteInfo("Looking for " & dt.DayOfWeek.ToString & " backup config file")
                    Dim fl As String = base & "." & dt.DayOfWeek.ToString
                    If File.Exists(fl) Then
                        myLog.WriteInfo("found " & dt.DayOfWeek.ToString & " backup config file")
                        Try
                            foundgood = True
                            _xml.Load(fl)
                            myLog.WriteInfo("Loaded " & dt.DayOfWeek.ToString & " backup config file; dated: " & File.GetCreationTime(fl).ToLongTimeString)
                        Catch exc As Exception
                            foundgood = False
                            myLog.WriteInfo(dt.DayOfWeek.ToString & " backup config is also damaged")
                        End Try
                        If foundgood Then Exit For
                    Else
                        myLog.WriteInfo(dt.DayOfWeek.ToString & " backup config file not found")
                    End If
                Next
                If Not foundgood Then allbad = True
            End Try
        End If


        If Not allbad Then
            Node = _xml.SelectSingleNode("Project")
            Name = XHelper.Get(Node, "Name", "Project")
            RunType = XHelper.Get(Node, "Runtype", RunStyle.Simulate)


            Dim nd As XmlNode = Node.SelectSingleNode("IO")
            IO = New IOManager(nd)

            Dim pgs As XmlNodeList = Node.SelectNodes("Page")
            Pages = New List(Of Page)
            For xloop As Integer = 0 To pgs.Count - 1
                Pages.Add(New Page(pgs(xloop)))
            Next
            _xml.Save(TheFile & ".Temp")

            'todo:stubb out loading data writeing manager
            NeedsSave = False
            _canRun = True
        End If

    End Sub

    ''' <summary>
    ''' if this project in it's current state can run
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CanRun() As Boolean
        Get
            Return _canRun
        End Get
    End Property

    ''' <summary>
    ''' if the project is currently running or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property isRunning() As Boolean
        Get
            Return _isRunning
        End Get
    End Property

    ''' <summary>
    ''' for saving to file
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save(Optional AppendName As String = "")
        XHelper.Set(Node, "Name", Me.Name)
        XHelper.Set(Node, "Runtype", Me.RunType)
        IO.Save()

        For Each p As Page In Pages
            p.Save()
        Next
        If String.IsNullOrEmpty(AppendName) Then
            _xml.Save(Me.FileName)
        Else
            _xml.Save(Me.FileName & "." & AppendName)
        End If
        NeedsSave = False
    End Sub

    ''' <summary>
    ''' starts the exicution threads for I/O and pages
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Run()
        'startup the IO work before
        'turning on the logic of the pages
        IO.StartStop = True
        _AllowWork = True
        _workThread = New Thread(AddressOf DoWork)
        _workThread.Name = "Page Work"
        _workThread.Priority = ThreadPriority.Normal
    End Sub

    ''' <summary>
    ''' stops the exicution threads for I/O and pages
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Stop]()
        'wait for the working to stop before
        'shutting down the IO loops
        _AllowWork = False
        If _workThread IsNot Nothing Then _workThread.Join()
        _workThread = Nothing
        If IO IsNot Nothing Then IO.StartStop = False
        _isRunning = False
    End Sub

    ''' <summary>
    ''' processes the pages in order
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoWork()
        Dim index As Integer = 0
        Do
            _isRunning = True
            If _AllowWork Then
                Pages(index).Update()
                index += 1
                If index > Pages.Count - 1 Then index = 0
            Else
                Exit Do
            End If

            'do the automatic saving of hte xml at midnight only
            If Now > _NextSaveTime Then
                If Now.Hour = 0 AndAlso Now.Minute = 0 Then
                    Save(Now.DayOfWeek.ToString)
                End If
                _NextSaveTime = Now.AddMinutes(1)
            End If

        Loop
    End Sub

#Region "Get Functions"

    ''' <summary>
    ''' returns the requested page by name
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks>Returns nothing if not found</remarks>
    Public Function GetPage(name As String) As Page
        Dim ret As Page = Nothing
        For xloop As Integer = 0 To Pages.Count - 1
            If Pages(xloop).Name = name Then
                ret = Pages(xloop)
                Exit For
            End If
        Next
        Return ret
    End Function

    ''' <summary>
    ''' returns a specific block from the whole project
    ''' </summary>
    ''' <param name="UID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBlock(UID As String) As Block
        Dim ret As Block = Nothing
        Dim m As Match = Regex.Match(UID, "(\w+)-(\w+)")

        For xloop As Integer = 0 To Pages.Count - 1
            If Pages(xloop).UID = m.Groups(1).Value Then
                ret = Pages(xloop).GetBlock(UID)
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
    Public Function GetBlocksByType(theType As BlockType) As Block()
        Dim ret As New List(Of Block)
        For yloop As Integer = 0 To Pages.Count - 1
            For xloop As Integer = 0 To Pages(yloop).Blocks.Count - 1
                If Pages(yloop).Blocks(xloop).blockIOtype = theType Then
                    ret.Add(Pages(yloop).Blocks(xloop))
                End If
            Next
        Next

        Return ret.ToArray
    End Function

#End Region

    ''' <summary>
    ''' used to set if the project needs saved
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _xml_NodeChanged(sender As Object, e As XmlNodeChangedEventArgs) Handles _xml.NodeChanged, _xml.NodeInserted, _xml.NodeRemoved
        NeedsSave = True
    End Sub

#Region "Add/Remove Pages"

    ''' <summary>
    ''' if a certian node is a valid Page node
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isVallidPageNode(nd As XmlNode) As Boolean
        If nd.Name = "Page" Then Return True Else Return False
    End Function

    ''' <summary>
    ''' adds a new page to the pages collection
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewPage(name As String) As Page
        Dim pn As XmlNode = XHelper.NodeAppendNew(Node, "Page")
        Dim newUID As Integer = -1

        'Make a list of all the existing UIDs
        'and then loop throu the uids +1 to find then
        'next new number
        Dim lst As New List(Of Integer)
        For xloop As Integer = 0 To Pages.Count - 1
            lst.Add(Pages(xloop).UID)
        Next
        For xloop As Integer = 1 To Pages.Count + 1
            If Not lst.Contains(xloop) Then
                newUID = xloop
                Exit For
            End If
        Next
        Dim p As New Page(pn, name, newUID)
        Pages.Add(p)
        Return p
    End Function

    ''' <summary>
    ''' tries to create a new page from the passed node
    ''' </summary>
    ''' <param name="nd"></param>
    ''' <returns>a page if it was able to be parsed, else nothing</returns>
    ''' <remarks></remarks>
    Public Function AddPage(nd As XmlNode) As Page
        Dim ret As Page = Nothing
        Try
            If nd.Name = "Page" Then
                ret = New Page(nd)
                Pages.Add(ret)
            End If
        Catch ex As Exception
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' removes a page from the collection
    ''' and the xml
    ''' </summary>
    ''' <param name="ThePage"></param>
    ''' <remarks></remarks>
    Public Sub RemovePage(ThePage As Page)
        Pages.Remove(ThePage)
        Dim pn As XmlNode = ThePage.Node.ParentNode
        pn.RemoveChild(ThePage.Node)
    End Sub

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
        Dim ex As New Project_Props(Me)
        If ex.ShowDialog() = DialogResult.OK Then
            Me.Save()
        End If
    End Sub


End Class
