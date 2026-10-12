<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuaAn
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
        Me.txtSoBuaAn = New System.Windows.Forms.TextBox
        Me.btCapNhat = New System.Windows.Forms.Button
        Me.radTuDong = New System.Windows.Forms.RadioButton
        Me.radSoBuaan = New System.Windows.Forms.RadioButton
        Me.btThoat = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtSoBuaAn
        '
        Me.txtSoBuaAn.Location = New System.Drawing.Point(99, 30)
        Me.txtSoBuaAn.Multiline = True
        Me.txtSoBuaAn.Name = "txtSoBuaAn"
        Me.txtSoBuaAn.Size = New System.Drawing.Size(93, 27)
        Me.txtSoBuaAn.TabIndex = 1
        '
        'btCapNhat
        '
        Me.btCapNhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btCapNhat.ForeColor = System.Drawing.Color.Blue
        Me.btCapNhat.Location = New System.Drawing.Point(39, 58)
        Me.btCapNhat.Name = "btCapNhat"
        Me.btCapNhat.Size = New System.Drawing.Size(74, 35)
        Me.btCapNhat.TabIndex = 2
        Me.btCapNhat.Text = "Cập Nhật"
        Me.btCapNhat.UseVisualStyleBackColor = True
        '
        'radTuDong
        '
        Me.radTuDong.AutoSize = True
        Me.radTuDong.ForeColor = System.Drawing.Color.Blue
        Me.radTuDong.Location = New System.Drawing.Point(19, 9)
        Me.radTuDong.Name = "radTuDong"
        Me.radTuDong.Size = New System.Drawing.Size(88, 17)
        Me.radTuDong.TabIndex = 3
        Me.radTuDong.TabStop = True
        Me.radTuDong.Text = "Tính tự động"
        Me.radTuDong.UseVisualStyleBackColor = True
        '
        'radSoBuaan
        '
        Me.radSoBuaan.AutoSize = True
        Me.radSoBuaan.ForeColor = System.Drawing.Color.Blue
        Me.radSoBuaan.Location = New System.Drawing.Point(19, 35)
        Me.radSoBuaan.Name = "radSoBuaan"
        Me.radSoBuaan.Size = New System.Drawing.Size(74, 17)
        Me.radSoBuaan.TabIndex = 3
        Me.radSoBuaan.TabStop = True
        Me.radSoBuaan.Text = "Số bữa ăn"
        Me.radSoBuaan.UseVisualStyleBackColor = True
        '
        'btThoat
        '
        Me.btThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btThoat.ForeColor = System.Drawing.Color.Blue
        Me.btThoat.Location = New System.Drawing.Point(118, 58)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(74, 35)
        Me.btThoat.TabIndex = 2
        Me.btThoat.Text = "Thoát"
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'frmBuaAn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 94)
        Me.ControlBox = False
        Me.Controls.Add(Me.radSoBuaan)
        Me.Controls.Add(Me.radTuDong)
        Me.Controls.Add(Me.btThoat)
        Me.Controls.Add(Me.btCapNhat)
        Me.Controls.Add(Me.txtSoBuaAn)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuaAn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BuaAn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSoBuaAn As System.Windows.Forms.TextBox
    Friend WithEvents btCapNhat As System.Windows.Forms.Button
    Friend WithEvents radTuDong As System.Windows.Forms.RadioButton
    Friend WithEvents radSoBuaan As System.Windows.Forms.RadioButton
    Friend WithEvents btThoat As System.Windows.Forms.Button
End Class
