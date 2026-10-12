<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHeSo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btDong = New System.Windows.Forms.Button
        Me.btTinh = New System.Windows.Forms.Button
        Me.cbHeSo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btDong
        '
        Me.btDong.ForeColor = System.Drawing.Color.Blue
        Me.btDong.Location = New System.Drawing.Point(145, 40)
        Me.btDong.Name = "btDong"
        Me.btDong.Size = New System.Drawing.Size(82, 33)
        Me.btDong.TabIndex = 5
        Me.btDong.Text = "Đóng"
        Me.btDong.UseVisualStyleBackColor = True
        '
        'btTinh
        '
        Me.btTinh.ForeColor = System.Drawing.Color.Blue
        Me.btTinh.Location = New System.Drawing.Point(48, 40)
        Me.btTinh.Name = "btTinh"
        Me.btTinh.Size = New System.Drawing.Size(82, 33)
        Me.btTinh.TabIndex = 6
        Me.btTinh.Text = "Tính"
        Me.btTinh.UseVisualStyleBackColor = True
        '
        'cbHeSo
        '
        Me.cbHeSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHeSo.FormattingEnabled = True
        Me.cbHeSo.Items.AddRange(New Object() {"2.3", "2.1", "1.9", "1.8", "1.7", "1.6", "1.5", "1"})
        Me.cbHeSo.Location = New System.Drawing.Point(48, 14)
        Me.cbHeSo.Name = "cbHeSo"
        Me.cbHeSo.Size = New System.Drawing.Size(178, 21)
        Me.cbHeSo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Hệ số:"
        '
        'frmHeSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(239, 88)
        Me.ControlBox = False
        Me.Controls.Add(Me.btDong)
        Me.Controls.Add(Me.btTinh)
        Me.Controls.Add(Me.cbHeSo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmHeSo"
        Me.Text = "Hệ Số"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btDong As System.Windows.Forms.Button
    Friend WithEvents btTinh As System.Windows.Forms.Button
    Friend WithEvents cbHeSo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
