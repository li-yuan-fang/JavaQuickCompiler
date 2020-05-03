<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddLib
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddLib))
        Me.RadioButton_Folder = New System.Windows.Forms.RadioButton()
        Me.Panel_Select = New System.Windows.Forms.Panel()
        Me.RadioButton_File = New System.Windows.Forms.RadioButton()
        Me.Text_Path = New System.Windows.Forms.TextBox()
        Me.Button_Select = New System.Windows.Forms.Button()
        Me.Button_Confirm = New System.Windows.Forms.Button()
        Me.Panel_Select.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButton_Folder
        '
        Me.RadioButton_Folder.AutoSize = True
        Me.RadioButton_Folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_Folder.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton_Folder.Name = "RadioButton_Folder"
        Me.RadioButton_Folder.Size = New System.Drawing.Size(59, 25)
        Me.RadioButton_Folder.TabIndex = 0
        Me.RadioButton_Folder.TabStop = True
        Me.RadioButton_Folder.Text = "目录"
        Me.RadioButton_Folder.UseVisualStyleBackColor = True
        '
        'Panel_Select
        '
        Me.Panel_Select.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Select.Controls.Add(Me.RadioButton_File)
        Me.Panel_Select.Controls.Add(Me.RadioButton_Folder)
        Me.Panel_Select.Location = New System.Drawing.Point(50, 4)
        Me.Panel_Select.Name = "Panel_Select"
        Me.Panel_Select.Size = New System.Drawing.Size(138, 33)
        Me.Panel_Select.TabIndex = 1
        '
        'RadioButton_File
        '
        Me.RadioButton_File.AutoSize = True
        Me.RadioButton_File.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButton_File.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadioButton_File.Location = New System.Drawing.Point(78, 3)
        Me.RadioButton_File.Name = "RadioButton_File"
        Me.RadioButton_File.Size = New System.Drawing.Size(59, 25)
        Me.RadioButton_File.TabIndex = 1
        Me.RadioButton_File.TabStop = True
        Me.RadioButton_File.Text = "文件"
        Me.RadioButton_File.UseVisualStyleBackColor = True
        '
        'Text_Path
        '
        Me.Text_Path.AllowDrop = True
        Me.Text_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text_Path.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Text_Path.Location = New System.Drawing.Point(9, 72)
        Me.Text_Path.Name = "Text_Path"
        Me.Text_Path.Size = New System.Drawing.Size(321, 29)
        Me.Text_Path.TabIndex = 2
        '
        'Button_Select
        '
        Me.Button_Select.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Select.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Select.Location = New System.Drawing.Point(336, 72)
        Me.Button_Select.Name = "Button_Select"
        Me.Button_Select.Size = New System.Drawing.Size(75, 29)
        Me.Button_Select.TabIndex = 3
        Me.Button_Select.Text = "浏览"
        Me.Button_Select.UseVisualStyleBackColor = True
        '
        'Button_Confirm
        '
        Me.Button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Confirm.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Confirm.Location = New System.Drawing.Point(336, 117)
        Me.Button_Confirm.Name = "Button_Confirm"
        Me.Button_Confirm.Size = New System.Drawing.Size(75, 29)
        Me.Button_Confirm.TabIndex = 4
        Me.Button_Confirm.Text = "确定"
        Me.Button_Confirm.UseVisualStyleBackColor = True
        '
        'FrmAddLib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 154)
        Me.Controls.Add(Me.Button_Confirm)
        Me.Controls.Add(Me.Button_Select)
        Me.Controls.Add(Me.Text_Path)
        Me.Controls.Add(Me.Panel_Select)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddLib"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "增加依赖库"
        Me.Panel_Select.ResumeLayout(False)
        Me.Panel_Select.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButton_Folder As System.Windows.Forms.RadioButton
    Friend WithEvents Panel_Select As System.Windows.Forms.Panel
    Friend WithEvents RadioButton_File As System.Windows.Forms.RadioButton
    Friend WithEvents Text_Path As System.Windows.Forms.TextBox
    Friend WithEvents Button_Select As System.Windows.Forms.Button
    Friend WithEvents Button_Confirm As System.Windows.Forms.Button
End Class
