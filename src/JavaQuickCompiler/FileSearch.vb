Public Class FileSearch

    Public Shared Function SearchFiles(ByVal Folder As String, ByVal FileType As String) As List(Of String)
        Dim MyFiles As New List(Of String)
        GetAllFiles(Folder, FileType, MyFiles)
        Return MyFiles
    End Function

    Private Shared Sub GetAllFiles(ByVal strDirect As String, ByVal FileType As String, ByRef FileList As List(Of String))
        If Not (strDirect Is Nothing) Then
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            Try
                For Each mFileInfo In mDirInfo.GetFiles("*." & FileType)
                    FileList.Add(mFileInfo.FullName)
                Next

                For Each mDir In mDirInfo.GetDirectories
                    GetAllFiles(mDir.FullName, FileType, FileList)
                Next
            Catch ex As System.IO.DirectoryNotFoundException
                Debug.Print("目录没找到：" + ex.Message)
            End Try
        End If
    End Sub

End Class
