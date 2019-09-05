

Public Class EventLogger

#Region "Variables"
    ''' <summary>
    ''' the working directory
    ''' </summary>
    ''' <remarks></remarks>
    Private _Path As DirectoryInfo
    ''' <summary>
    ''' provides a Que for incomming messaages waiting to be written to 
    ''' </summary>
    ''' <remarks></remarks>
    Private _Queue As Queue(Of String)
    ''' <summary>
    ''' checks once a second for writing data
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents _Timer As Threading.Timer
    ''' <summary>
    ''' when the next write to file is allowed
    ''' </summary>
    ''' <remarks></remarks>
    Private _Future As Date
    ''' <summary>
    ''' how long to store the daily files
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxKeepDays() As Integer
    ''' <summary>
    ''' if currently writting data or not
    ''' </summary>
    ''' <remarks></remarks>
    Private _inWrite As Boolean
#End Region

    ''' <summary>
    ''' creates a new eventlogger
    ''' </summary>
    ''' <param name="StartPath">where to put the Logs folder-Use Application.StartupPath</param>
    ''' <param name="maxdays">how many file days to keep</param>
    ''' <remarks>uses a Queue and Threading.Timer for flushing data</remarks>
    Public Sub New(ByVal StartPath As String, ByVal maxdays As Integer)
        _Path = New DirectoryInfo(StartPath & "\Logs\")
        If _Path.Exists = False Then _Path.Create()
        If maxdays < 30 Then maxdays = 30
        MaxKeepDays = maxdays
        _Queue = New Queue(Of String)
        _Timer = New Threading.Timer(AddressOf Tick, Nothing, 5000, 1000)
    End Sub

    ''' <summary>
    ''' writes information to the log
    ''' </summary>
    ''' <param name="Data">anything</param>
    ''' <remarks></remarks>
    Public Sub WriteInfo(ByVal Data As String)
        _Queue.Enqueue(Now.ToShortTimeString & "  " & Data & ControlChars.CrLf & ControlChars.CrLf)
        _Future = Now.AddSeconds(1)
    End Sub

    ''' <summary>
    ''' if the queue has some data, and no new data has been written to this class 
    ''' then write the whole chunk of data from the buffer to the current file
    ''' </summary>
    ''' <param name="o"></param>
    ''' <remarks></remarks>
    Private Sub Tick(ByVal o As Object)
        Try
            If _Queue.Count > 0 AndAlso _Future < Now Then
                Writedata()
            ElseIf _Queue.Count > 200 Then
                Writedata()
            End If
        Catch ex As Exception
            ErrorLogger.Write(ex)
        End Try
    End Sub

    ''' <summary>
    ''' writes all the data currently in the queue buffer to file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Writedata()

        If _inWrite = False Then
            _inWrite = True
            Dim fl As String = _Path.FullName & "EventLog-" & Now.ToString("yyyy-MM-dd") & ".txt"
            Dim exists As Boolean = File.Exists(fl)

            '---------------------------------------
            'flush the queue buffer to the daily file
            '---------------------------------------
            Try
                Using xwriter As TextWriter = File.AppendText(fl)
                    Dim Length As Integer = _Queue.Count - 1
                    For xloop As Integer = 0 To Length
                        Dim data As String = _Queue.Dequeue
                        xwriter.Write(data)

                    Next
                End Using
            Catch ex As Exception
            End Try

            '--------------------------------------
            'only look to clean up at the beggining
            'of each day (when a new file is created)
            '-------------------------------------
            If Not exists Then CleanOldFiles()
            _inWrite = False

        End If
    End Sub

    ''' <summary>
    ''' delete the oldest files except those wanted by history
    ''' </summary>
    ''' <remarks>(only works with the log-????????.txt files)</remarks>
    Private Sub CleanOldFiles()
        Dim xFiles() As FileInfo = _Path.GetFiles("EventLog-????-??-??.txt", SearchOption.TopDirectoryOnly)
        Dim oldest As Date = Now.AddDays(-MaxKeepDays)
        For xloop As Integer = 0 To xFiles.Length - 1
            If xFiles(xloop).LastWriteTime < oldest Then
                xFiles(xloop).Delete()
            End If
        Next

    End Sub

    ''' <summary>
    ''' writes all the info leftover and cleans
    ''' up any resources still left over
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        If _Queue.Count > 0 Then Writedata()
        _Timer.Dispose()
        _Queue.Clear()
    End Sub

End Class
