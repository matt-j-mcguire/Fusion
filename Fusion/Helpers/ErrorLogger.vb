
Public Class ErrorLogger

    Private Shared _pth As String

    Shared Sub New()
        _pth = Application.StartupPath & "\ErrorLog.txt"
    End Sub

    ''' <summary>
    ''' write any sort of info
    ''' </summary>
    ''' <param name="info"></param>
    ''' <remarks></remarks>
    Public Shared Sub Write(info As String)
        My.Computer.FileSystem.WriteAllText(_pth, Now.ToString & ControlChars.CrLf & info & ControlChars.CrLf & ControlChars.CrLf, True)
    End Sub

    ''' <summary>
    ''' write any sort of info
    ''' </summary>
    ''' <param name="info"></param>
    ''' <remarks></remarks>
    Public Shared Sub Write(info As Exception)
        My.Computer.FileSystem.WriteAllText(_pth, Now.ToString & ControlChars.CrLf & info.ToString & ControlChars.CrLf & ControlChars.CrLf, True)
    End Sub

End Class
