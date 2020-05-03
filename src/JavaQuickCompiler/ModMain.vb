Imports System.Windows.Forms
Module ModMain

    '定义主窗体
    Public Form_Main As FrmMain


    Sub Main()

        Form_Main = New FrmMain
        Form_Main.Show()

        Application.Run()
    End Sub

    Public Sub EndApplication()
        End
    End Sub

    Public Function IsFile(ByVal Path As String) As Boolean
        Dim RStr As String = vbNullString
        Try
            RStr = Mid(Path, InStrRev(Path, "\") + 1)
            Dim i As Integer = InStrRev(RStr, ".")
            If i > 0 Then
                If i <> 1 And i <> Len(RStr) Then
                    If Not IO.Directory.Exists(Path) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
                Else
                    Return False
                End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
