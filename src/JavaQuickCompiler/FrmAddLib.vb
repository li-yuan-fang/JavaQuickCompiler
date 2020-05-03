Imports System.Windows.Forms

Public Class FrmAddLib

    Public Path As String = vbNullString

    Private Sub FrmAddLib_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        With e.Graphics
            .DrawString("类型", sender.Font, Drawing.Brushes.Black, 10, 10)
            .DrawString("路径", sender.Font, Drawing.Brushes.Black, 10, 50)
        End With
    End Sub

    Private Sub Text_Path_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Text_Path.DragDrop
        For Each filepath As String In e.Data.GetData(DataFormats.FileDrop)
            If RadioButton_File.Checked = IsFile(filepath) Then
                Text_Path.Text = filepath
            End If
        Next
    End Sub

    Private Sub Text_Path_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Text_Path.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Button_Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Confirm.Click
        If IIf(RadioButton_File.Checked, IO.File.Exists(Text_Path.Text), IO.Directory.Exists(Text_Path.Text)) Then
            Path = Text_Path.Text
            Me.Close()
        Else
            MsgBox(IIf(RadioButton_File.Checked, "文件", "目录") & "不存在", 16)
        End If
    End Sub

    Private Sub Button_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Select.Click
        If RadioButton_File.Checked Then
            Dim MyDialog As New OpenFileDialog
            With MyDialog
                .AddExtension = True
                .CheckFileExists = True
                .DefaultExt = "*.jar"
                .DereferenceLinks = True
                .Filter = "jar包(*.jar)|*.jar"
                .Multiselect = False
                .ShowDialog()
                If Not String.IsNullOrEmpty(.FileName) Then Text_Path.Text = .FileName
                .Dispose()
            End With
            MyDialog = Nothing
        Else
            Dim MyDialog As New FolderBrowserDialog
            With MyDialog
                .ShowNewFolderButton = False
                .ShowDialog()
                If Not String.IsNullOrEmpty(.SelectedPath) Then Text_Path.Text = .SelectedPath
                .Dispose()
            End With
            MyDialog = Nothing
        End If
    End Sub
End Class