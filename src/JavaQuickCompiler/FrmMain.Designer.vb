<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Text_Compiler = New System.Windows.Forms.TextBox()
        Me.Text_Project = New System.Windows.Forms.TextBox()
        Me.Button_AddLib = New System.Windows.Forms.Button()
        Me.List_Lib = New System.Windows.Forms.ListBox()
        Me.Button_Compile = New System.Windows.Forms.Button()
        Me.Button_ProjectSelect = New System.Windows.Forms.Button()
        Me.Button_CompilerSelect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Text_Compiler
        '
        Me.Text_Compiler.AllowDrop = True
        Me.Text_Compiler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Text_Compiler, "Text_Compiler")
        Me.Text_Compiler.Name = "Text_Compiler"
        '
        'Text_Project
        '
        Me.Text_Project.AllowDrop = True
        Me.Text_Project.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Text_Project, "Text_Project")
        Me.Text_Project.Name = "Text_Project"
        '
        'Button_AddLib
        '
        Me.Button_AddLib.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button_AddLib, "Button_AddLib")
        Me.Button_AddLib.Name = "Button_AddLib"
        Me.Button_AddLib.UseVisualStyleBackColor = True
        '
        'List_Lib
        '
        Me.List_Lib.AllowDrop = True
        Me.List_Lib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.List_Lib.FormattingEnabled = True
        resources.ApplyResources(Me.List_Lib, "List_Lib")
        Me.List_Lib.Name = "List_Lib"
        '
        'Button_Compile
        '
        Me.Button_Compile.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button_Compile, "Button_Compile")
        Me.Button_Compile.Name = "Button_Compile"
        Me.Button_Compile.UseVisualStyleBackColor = True
        '
        'Button_ProjectSelect
        '
        Me.Button_ProjectSelect.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button_ProjectSelect, "Button_ProjectSelect")
        Me.Button_ProjectSelect.Name = "Button_ProjectSelect"
        Me.Button_ProjectSelect.UseVisualStyleBackColor = True
        '
        'Button_CompilerSelect
        '
        Me.Button_CompilerSelect.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button_CompilerSelect, "Button_CompilerSelect")
        Me.Button_CompilerSelect.Name = "Button_CompilerSelect"
        Me.Button_CompilerSelect.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_CompilerSelect)
        Me.Controls.Add(Me.Button_ProjectSelect)
        Me.Controls.Add(Me.Button_Compile)
        Me.Controls.Add(Me.List_Lib)
        Me.Controls.Add(Me.Button_AddLib)
        Me.Controls.Add(Me.Text_Project)
        Me.Controls.Add(Me.Text_Compiler)
        Me.Name = "FrmMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_Compiler As System.Windows.Forms.TextBox
    Friend WithEvents Text_Project As System.Windows.Forms.TextBox
    Friend WithEvents Button_AddLib As System.Windows.Forms.Button
    Friend WithEvents List_Lib As System.Windows.Forms.ListBox
    Friend WithEvents Button_Compile As System.Windows.Forms.Button
    Friend WithEvents Button_ProjectSelect As System.Windows.Forms.Button
    Friend WithEvents Button_CompilerSelect As System.Windows.Forms.Button
End Class
