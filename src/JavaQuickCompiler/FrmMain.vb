Imports System.Windows.Forms
Public Class FrmMain

    Private WithEvents Menu_Libs As New ContextMenuStrip

    Private Sub FrmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call EndApplication()
    End Sub

    Private Sub FrmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        With e.Graphics
            .DrawString("编译器路径", sender.Font, Drawing.Brushes.Black, 10, 10)
            .DrawString("项目路径", sender.Font, Drawing.Brushes.Black, 10, 50)
            .DrawString("依赖库", sender.Font, Drawing.Brushes.Black, 10, 86)
        End With
    End Sub

    Private Sub FrmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ChangeSize(Text_Compiler, 70)
        ChangeSize(Text_Project, 70)
        ChangeSize(List_Lib)
        Button_CompilerSelect.Left = Me.Width - 16 - Button_CompilerSelect.Width - 10
        Button_ProjectSelect.Left = Me.Width - 16 - Button_ProjectSelect.Width - 10
        List_Lib.Height = Me.Height - List_Lib.Top - 38 - 30
        Button_AddLib.Left = Me.Width - 26 - Button_AddLib.Width
        With Button_Compile
            .Left = Me.Width - 26 - .Width
            .Top = Me.Height - .Height - 38 - 6
        End With
    End Sub

    Private Sub ChangeSize(ByRef MyObj As Object, Optional ByVal Right As Single = 10)
        With MyObj
            .Width = Me.Width - .Left - 16 - Right
        End With
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        '初始化右键菜单
        Dim CMenu_Add As New ToolStripMenuItem("增加")
        Dim CMenu_Remove As New ToolStripMenuItem("移除")
        With CMenu_Add
            .Tag = True
            AddHandler .Click, AddressOf CMenu_Click
        End With
        With CMenu_Remove
            .Tag = False
            AddHandler .Click, AddressOf CMenu_Click
        End With
        With Menu_Libs.Items
            .Add(CMenu_Add)
            .Add(CMenu_Remove)
        End With
        List_Lib.ContextMenuStrip = Menu_Libs

        '初始化拖拽事件
        With Text_Compiler
            .Tag = True
            AddHandler .DragEnter, AddressOf Text_DragEnter
            AddHandler .DragDrop, AddressOf Text_Single_DragDrop
        End With
        With Text_Project
            .Tag = False
            AddHandler .DragEnter, AddressOf Text_DragEnter
            AddHandler .DragDrop, AddressOf Text_Single_DragDrop
        End With
        With List_Lib
            AddHandler .DragEnter, AddressOf Text_DragEnter
            AddHandler .DragDrop, AddressOf List_DragDrop
        End With
    End Sub

    Private Sub CMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
        If sender.Tag Then
            Call Button_AddLib_Click(Nothing, Nothing)
        Else
            If List_Lib.Items.Count > 0 Then
                List_Lib.Items.RemoveAt(List_Lib.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub Button_AddLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_AddLib.Click
        Dim MyDialog As New FrmAddLib
        With MyDialog
            .BringToFront()
            .ShowDialog()
            If Not String.IsNullOrEmpty(.Path) Then List_Lib.Items.Add(.Path)
            .Dispose()
        End With
        MyDialog = Nothing
    End Sub

    Private Sub Text_Single_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        For Each filepath As String In e.Data.GetData(DataFormats.FileDrop)
            If sender.Tag = IsFile(filepath) Then sender.Text = filepath
        Next
    End Sub

    Private Sub List_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        For Each filepath As String In e.Data.GetData(DataFormats.FileDrop)
            If Not sender.Items.Contains(filepath) Then sender.Items.Add(filepath)
        Next
    End Sub

    Private Sub Text_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Button_CompilerSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CompilerSelect.Click
        Dim MyDialog As New OpenFileDialog
        With MyDialog
            .AddExtension = True
            .CheckFileExists = True
            .DefaultExt = "javac.exe"
            .DereferenceLinks = True
            .Filter = "java编译器(javac.exe)|javac.exe"
            .Multiselect = False
            .ShowDialog()
            If Not String.IsNullOrEmpty(.FileName) Then Text_Compiler.Text = .FileName
            .Dispose()
        End With
        MyDialog = Nothing
    End Sub

    Private Sub Button_ProjectSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_ProjectSelect.Click
        Dim MyDialog As New FolderBrowserDialog
        With MyDialog
            .ShowNewFolderButton = False
            .ShowDialog()
            If Not String.IsNullOrEmpty(.SelectedPath) Then Text_Project.Text = .SelectedPath
            .Dispose()
        End With
        MyDialog = Nothing
    End Sub

    Private Sub Button_Compile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Compile.Click
        Dim MyLibs As New List(Of String)
        If List_Lib.Items.Count > 0 Then
            For i = 0 To List_Lib.Items.Count - 1
                MyLibs.Add(List_Lib.Items(i))
            Next
        End If
        Dim MyCompiler As New JavaCompiler(Text_Compiler.Text, Text_Project.Text, MyLibs)
        Me.Enabled = False
        Dim Result As Boolean = MyCompiler.Compile
        Me.Enabled = True
        MsgBox(IIf(Result, "恭喜，编译成功", "编译失败"), IIf(Result, 64, 16))
        MyCompiler = Nothing
    End Sub

End Class