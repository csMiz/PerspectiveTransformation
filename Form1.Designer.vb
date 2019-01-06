<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.P = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PSource = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.P, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'P
        '
        Me.P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P.Location = New System.Drawing.Point(56, 61)
        Me.P.Name = "P"
        Me.P.Size = New System.Drawing.Size(1000, 800)
        Me.P.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.P.TabIndex = 0
        Me.P.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1111, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(215, 149)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PSource
        '
        Me.PSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PSource.Location = New System.Drawing.Point(81, 78)
        Me.PSource.Name = "PSource"
        Me.PSource.Size = New System.Drawing.Size(1000, 800)
        Me.PSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PSource.TabIndex = 2
        Me.PSource.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1111, 236)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(215, 149)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1401, 917)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PSource)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.P)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.P, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents P As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PSource As PictureBox
    Friend WithEvents Button2 As Button
End Class
