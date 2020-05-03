Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Public Class JavaCompiler

    Private JavaCompiler As String
    Private ProjectPath As String
    Private Libs As List(Of String)
    Private JavaSrc As List(Of String)

    Private Compiling As Boolean = False

    Public Sub New(ByVal Javac As String, ByVal Project As String, ByVal Libraries As List(Of String))
        JavaCompiler = Javac
        ProjectPath = Replace(Project & "\", "\\", "\")
        Libs = Libraries
        Libs.Add(Strings.Left(ProjectPath, Strings.Len(ProjectPath) - 1))
        Compiling = False
    End Sub

    Public Function Compile() As Boolean
        Compiling = True
        Dim MyConsole As New FrmConsole
        Dim Result As Boolean
        With MyConsole
            .Title = "编译日志"
            AddHandler .Text_Console.KeyPress, AddressOf Console_KeyPress
            AddHandler .FormClosed, AddressOf Console_FormClosed
            .Show()
            .WriteLine("正在执行文件检查...")
            .WriteLine("正在检查编译器路径...")
            Result = IO.File.Exists(JavaCompiler)
            .WriteLine(JavaCompiler & "..." & Result)
            If Not Result Then Compiling = False : .Write("请按任意键继续...", False) : Return False

            .WriteLine("正在检查工程路径...")
            Result = IO.Directory.Exists(ProjectPath)
            .WriteLine(ProjectPath & "..." & Result)
            If Not Result Then Compiling = False : .Write("请按任意键继续...", False) : Return False

            .WriteLine("正在检查依赖库...")
            For i = 0 To Libs.Count - 1
                .Write(Libs(i) & "...")
                Result = IIf(IsFile(Libs(i)), IO.File.Exists(Libs(i)), IO.Directory.Exists(Libs(i)))
                .WriteLine(Result, False)
                If Not Result Then Compiling = False : .Write("请按任意键继续...", False) : Return False
                Application.DoEvents()
            Next

            .WriteLine("正在查找Java源码...")
            JavaSrc = FileSearch.SearchFiles(ProjectPath, "class")
            If JavaSrc.Count > 0 Then
                For i = 0 To JavaSrc.Count - 1
                    IO.File.Delete(JavaSrc(i))
                Next
            End If
            JavaSrc.Clear()
            JavaSrc = Nothing
            JavaSrc = FileSearch.SearchFiles(ProjectPath, "java")
            If JavaSrc.Count = 0 Then .WriteLine("无有效的Java源码") : Compiling = False : .Write("请按任意键继续...", False) : Return False
            .WriteLine("已成功找到 " & JavaSrc.Count & " 个源码文件")

            .WriteLine("正在检查源码文件...")
            Dim Packages As List(Of String) = GetPackages(JavaSrc, ProjectPath)
            Dim IndexList As New List(Of Integer)
            For i = 0 To JavaSrc.Count - 1
                If Not CheckJavaSrc(Packages, IO.File.ReadAllText(JavaSrc(i), Encoding.UTF8)) Then IndexList.Add(i)
                Application.DoEvents()
            Next
            .WriteLine("源码检查完成")

            .WriteLine("正在尝试编译...")
            Dim MyTick As Long = Date.Now.Ticks
            Dim ClassPath As String = GetClassPath()
            Dim RStr As String = vbNullString
            If IndexList.Count = JavaSrc.Count Then
                For i = 0 To JavaSrc.Count - 1
                    .Write(Packages(i) & "...")
                    RStr = JavaCompile(JavaCompiler, JavaSrc(i), ClassPath)
                    .WriteLine(RStr, False)
                    If Not RStr = "Successful" Then Compiling = False : .Write("请按任意键继续...", False) : Return False
                    .Title = "编译日志 -" & Format(1 - (Packages.Count / JavaSrc.Count), "0.00") & "%"
                    Application.DoEvents()
                Next
            Else
                Dim RemoveList As New List(Of String)
                While Packages.Count > 0
                    IndexList.Clear()
                    For i = 0 To Packages.Count - 1
                        If Not CheckJavaSrc(Packages, IO.File.ReadAllText(ProjectPath & Packages(i).Replace(".", "\") & ".java", Encoding.UTF8)) Then IndexList.Add(i)
                        Application.DoEvents()
                    Next
                    If IndexList.Count = Packages.Count Then .WriteLine("编译逻辑死锁") : Compiling = False : .Write("请按任意键继续...", False) : Return False
                    RemoveList.Clear()
                    For i = 0 To Packages.Count - 1
                        If Not IndexList.Contains(i) Then
                            .Write(Packages(i) & "...")
                            RStr = JavaCompile(JavaCompiler, ProjectPath & Packages(i).Replace(".", "\") & ".java", ClassPath)
                            .WriteLine(RStr, False)
                            If Not RStr = "Successful" Then Compiling = False : .Write("请按任意键继续...", False) : Return False
                            RemoveList.Add(Packages(i))
                            .Title = "编译日志 -" & Format(1 - (Packages.Count / JavaSrc.Count), "0.00") & "%"
                        End If
                        Application.DoEvents()
                    Next
                    For i = 0 To RemoveList.Count - 1
                        Packages.Remove(RemoveList(i))
                        Application.DoEvents()
                    Next
                    RemoveList.Clear()
                    Application.DoEvents()
                End While
                RemoveList = Nothing
            End If

            MyTick = Date.Now.Ticks - MyTick
            .WriteLine("共 " & JavaSrc.Count & " 个class编译完成，用时共 " & Format(Convert.ToDouble(MyTick / 10 ^ 7), "0.00") & " s")
            .Title = "编译日志"

            .WriteLine("正在处理数据中...")
            RStr = Strings.Left(ProjectPath, Strings.Len(ProjectPath) - 1) & "_Compiled\"
            My.Computer.FileSystem.CopyDirectory(ProjectPath, RStr)
            Dim DelList As List(Of String) = FileSearch.SearchFiles(ProjectPath, "class")
            If DelList.Count > 0 Then
                For i = 0 To DelList.Count - 1
                    IO.File.Delete(DelList(i))
                Next
            End If
            DelList.Clear()
            DelList = FileSearch.SearchFiles(RStr, "java")
            If DelList.Count > 0 Then
                For i = 0 To DelList.Count - 1
                    IO.File.Delete(DelList(i))
                Next
            End If
            DelList.Clear()
            DelList = Nothing
            If Not IO.Directory.Exists(RStr & "META-INF\") Then IO.Directory.CreateDirectory(RStr & "META-INF\")
            If Not IO.File.Exists(RStr & "META-INF\MANIFEST.MF") Then IO.File.WriteAllText(RStr & "META-INF\MANIFEST.MF", "Manifest-Version: 1.0", Encoding.UTF8)

            .WriteLine("处理完成，编译过程完成，输出路径为：" & RStr)

            .Write("请按任意键继续...", False)

            Compiling = False
            Return True
        End With
    End Function

    Private Function GetClassPath() As String
        Dim RStr As String = vbNullString
        For i = 0 To Libs.Count - 1
            RStr = RStr & Libs(i) & IIf(i < Libs.Count - 1, ";", vbNullString)
        Next
        Return RStr
    End Function

    Private Sub Console_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Compiling Then
            sender.Parent.Close()
        End If
    End Sub

    Private Sub Console_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        On Error Resume Next
        If Compiling Then
            KillProcess("javac")
            Dim DelList As List(Of String) = FileSearch.SearchFiles(ProjectPath, "class")
            If DelList.Count > 0 Then
                For i = 0 To DelList.Count - 1
                    IO.File.Delete(DelList(i))
                Next
            End If
            DelList.Clear()
            DelList = Nothing
        End If
        Form_Main.Invoke(Sub() ClearConsole(sender))
    End Sub

    Private Sub ClearConsole(ByVal sender As Object)
        Try : sender.Dispose() : Catch : End Try
        sender = Nothing
    End Sub

    Private Shared Function GetPackages(ByVal Src As List(Of String), ByVal Project As String) As List(Of String)
        Dim MyList As New List(Of String)
        Dim RStr As String
        For i = 0 To Src.Count - 1
            RStr = Src(i).Replace(Project, vbNullString).Replace("\", ".")
            MyList.Add(Strings.Left(RStr, Strings.InStrRev(RStr, ".") - 1))
        Next
        Return MyList
    End Function

    Private Shared Function CheckJavaSrc(ByVal Packages As List(Of String), ByVal Src As String) As Boolean
        If Not InStr(Src, "import ") > 0 Then Return True
        Dim MyImports() As String
        Try
            MyImports = Strings.Split(Src, "import ")
            For i = 0 To MyImports.Count - 1
                MyImports(i) = Strings.Left(MyImports(i), InStr(MyImports(i), ";") - 1)
                If Packages.Contains(MyImports(i)) Then Return False
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Function JavaCompile(ByVal Compiler As String, ByVal Src As String, ByVal ClassPath As String) As String
        Try
            Dim RStr As String
            Dim ShellThread As New Thread(Sub() RStr = ShellForError(Compiler, "-cp """ & ClassPath & """ """ & Src & """"))
            ShellThread.Start()
            While ShellThread.IsAlive
                Application.DoEvents()
            End While
            Try : ShellThread.Abort() : Catch : End Try
            ShellThread = Nothing
            If Not IO.File.Exists(Strings.Left(Src, Strings.InStrRev(Src, ".")) & "class") Then Return "Failed" & vbCrLf & RStr
            Return "Successful"
        Catch
            Return "Error"
        End Try
    End Function

    Private Shared Function CheckClass(ByVal Srcs As List(Of String)) As Boolean
        Dim RStr As String = vbNullString
        For i = 0 To Srcs.Count - 1
            If Not IO.File.Exists(Strings.Mid(Srcs(i), Strings.InStrRev(Srcs(i), ".")) & "class") Then Return False
        Next
        Return True
    End Function

    Private Shared Function ShellForError(ByVal FileName As String, ByVal Arguments As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(FileName, Arguments)
        Dim RStr As String = vbNullString
        With oStartInfo
            .CreateNoWindow = True
            .UseShellExecute = False
            .RedirectStandardError = True
        End With
        With oProcess
            .StartInfo = oStartInfo
            .Start()

            While Not .StandardError.EndOfStream
                RStr &= .StandardError.ReadLine & vbCrLf
            End While
        End With
        If InStr(RStr, vbCrLf) > 0 Then RStr = Strings.Left(RStr, Strings.InStrRev(RStr, vbCrLf) - 1)
        Return RStr
    End Function

    Private Shared Sub KillProcess(ByVal ProcessName As String)
        For Each proc In Process.GetProcesses
            If LCase(proc.ProcessName) = LCase(ProcessName) Then
                proc.Kill()
            End If
        Next
    End Sub

End Class
