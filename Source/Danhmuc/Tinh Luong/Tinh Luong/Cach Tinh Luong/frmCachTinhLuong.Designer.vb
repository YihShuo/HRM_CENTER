<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCachTinhLuong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbTinhLuong = New System.Windows.Forms.ComboBox
        Me.btTinh = New System.Windows.Forms.Button
        Me.btDong = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(4, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cách Tính Lương"
        '
        'cbTinhLuong
        '
        Me.cbTinhLuong.FormattingEnabled = True
        Me.cbTinhLuong.Items.AddRange(New Object() {"Lương thời gian công nhân", "Lương thời gian văn phòng", "Lương thời gian CBTS có trình độ", "Lương thời gian CBTS không trình độ"})
        Me.cbTinhLuong.Location = New System.Drawing.Point(99, 7)
        Me.cbTinhLuong.Name = "cbTinhLuong"
        Me.cbTinhLuong.Size = New System.Drawing.Size(178, 21)
        Me.cbTinhLuong.TabIndex = 1
        '
        'btTinh
        '
        Me.btTinh.ForeColor = System.Drawing.Color.Blue
        Me.btTinh.Location = New System.Drawing.Point(99, 33)
        Me.btTinh.Name = "btTinh"
        Me.btTinh.Size = New System.Drawing.Size(82, 33)
        Me.btTinh.TabIndex = 2
        Me.btTinh.Text = "Tính"
        Me.btTinh.UseVisualStyleBackColor = True
        '
        'btDong
        '
        Me.btDong.ForeColor = System.Drawing.Color.Blue
        Me.btDong.Location = New System.Drawing.Point(196, 33)
        Me.btDong.Name = "btDong"
        Me.btDong.Size = New System.Drawing.Size(82, 33)
        Me.btDong.TabIndex = 2
        Me.btDong.Text = "Đóng"
        Me.btDong.UseVisualStyleBackColor = True
        '
        'frmCachTinhLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(280, 67)
        Me.ControlBox = False
        Me.Controls.Add(Me.btDong)
        Me.Controls.Add(Me.btTinh)
        Me.Controls.Add(Me.cbTinhLuong)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCachTinhLuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbTinhLuong As System.Windows.Forms.ComboBox
    Friend WithEvents btTinh As System.Windows.Forms.Button
    Friend WithEvents btDong As System.Windows.Forms.Button
End Class
