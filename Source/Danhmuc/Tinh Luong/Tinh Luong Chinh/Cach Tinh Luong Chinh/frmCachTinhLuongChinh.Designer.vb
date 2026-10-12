<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCachTinhLuongChinh
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
        Me.btDong = New System.Windows.Forms.Button
        Me.btTinh = New System.Windows.Forms.Button
        Me.cbTinhLuong = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btDong
        '
        Me.btDong.ForeColor = System.Drawing.Color.Blue
        Me.btDong.Location = New System.Drawing.Point(199, 37)
        Me.btDong.Name = "btDong"
        Me.btDong.Size = New System.Drawing.Size(78, 33)
        Me.btDong.TabIndex = 5
        Me.btDong.Text = "Đóng"
        Me.btDong.UseVisualStyleBackColor = True
        '
        'btTinh
        '
        Me.btTinh.ForeColor = System.Drawing.Color.Blue
        Me.btTinh.Location = New System.Drawing.Point(100, 37)
        Me.btTinh.Name = "btTinh"
        Me.btTinh.Size = New System.Drawing.Size(78, 33)
        Me.btTinh.TabIndex = 6
        Me.btTinh.Text = "Tính"
        Me.btTinh.UseVisualStyleBackColor = True
        '
        'cbTinhLuong
        '
        Me.cbTinhLuong.FormattingEnabled = True
        Me.cbTinhLuong.Items.AddRange(New Object() {"Lương thời gian công nhân", "Lương thời gian văn phòng", "Lương thời gian CBTS có trình độ", "Lương thời gian CBTS không trình độ"})
        Me.cbTinhLuong.Location = New System.Drawing.Point(100, 12)
        Me.cbTinhLuong.Name = "cbTinhLuong"
        Me.cbTinhLuong.Size = New System.Drawing.Size(177, 21)
        Me.cbTinhLuong.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(5, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cách Tính Lương"
        '
        'frmCachTinhLuongChinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(278, 71)
        Me.ControlBox = False
        Me.Controls.Add(Me.btDong)
        Me.Controls.Add(Me.btTinh)
        Me.Controls.Add(Me.cbTinhLuong)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCachTinhLuongChinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btDong As System.Windows.Forms.Button
    Friend WithEvents btTinh As System.Windows.Forms.Button
    Friend WithEvents cbTinhLuong As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
