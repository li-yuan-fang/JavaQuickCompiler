Public Class FrmConsole

    Public Property Title As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Public Sub WriteLine(ByVal Str As String, Optional ByVal AutoTime As Boolean = True)
        If AutoTime Then Str = "[" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "] " & Str
        With Text_Console
            .Text &= Str & vbCrLf
            .SelectionStart = Strings.Len(.Text)
            .ScrollToCaret()
        End With
    End Sub

    Public Sub Write(ByVal Str As String, Optional ByVal AutoTime As Boolean = True)
        If AutoTime Then Str = "[" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "] " & Str
        With Text_Console
            .Text &= Str
            .SelectionStart = Strings.Len(.Text)
            .ScrollToCaret()
        End With
    End Sub

    Private Sub FrmConsole_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Text_Console.Width = Me.Width - 16
        Text_Console.Height = Me.Height - 38
    End Sub

End Class