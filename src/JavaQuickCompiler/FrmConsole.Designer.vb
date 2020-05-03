<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsole
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsole))
        Me.Text_Console = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Text_Console
        '
        Me.Text_Console.BackColor = System.Drawing.Color.Black
        Me.Text_Console.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Text_Console.ForeColor = System.Drawing.Color.White
        Me.Text_Console.Location = New System.Drawing.Point(0, 0)
        Me.Text_Console.Multiline = True
        Me.Text_Console.Name = "Text_Console"
        Me.Text_Console.ReadOnly = True
        Me.Text_Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Text_Console.Size = New System.Drawing.Size(132, 81)
        Me.Text_Console.TabIndex = 0
        '
        'FrmConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(584, 362)
        Me.Controls.Add(Me.Text_Console)
        Me.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "FrmConsole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Console"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_Console As System.Windows.Forms.TextBox
End Class
