<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChiTietBBCV
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
        Me.cbChucVu = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.btDong = New System.Windows.Forms.Button
        Me.btChon = New System.Windows.Forms.Button
        Me.txtSoTien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbBinhBau = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        CType(Me.cbChucVu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBinhBau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbChucVu
        '
        Me.cbChucVu.Location = New System.Drawing.Point(84, 41)
        Me.cbChucVu.Name = "cbChucVu"
        Me.cbChucVu.Size = New System.Drawing.Size(201, 21)
        Me.cbChucVu.TabIndex = 38
        '
        'btDong
        '
        Me.btDong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btDong.Location = New System.Drawing.Point(167, 94)
        Me.btDong.Name = "btDong"
        Me.btDong.Size = New System.Drawing.Size(76, 32)
        Me.btDong.TabIndex = 36
        Me.btDong.Text = "Đóng"
        Me.btDong.UseVisualStyleBackColor = True
        '
        'btChon
        '
        Me.btChon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btChon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btChon.Location = New System.Drawing.Point(85, 94)
        Me.btChon.Name = "btChon"
        Me.btChon.Size = New System.Drawing.Size(76, 32)
        Me.btChon.TabIndex = 37
        Me.btChon.Text = "Chọn"
        Me.btChon.UseVisualStyleBackColor = True
        '
        'txtSoTien
        '
        Me.txtSoTien.Location = New System.Drawing.Point(84, 68)
        Me.txtSoTien.Name = "txtSoTien"
        Me.txtSoTien.Size = New System.Drawing.Size(202, 20)
        Me.txtSoTien.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(34, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Số tiền :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(28, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Chức vụ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(9, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Mã bình bầu :"
        '
        'cbBinhBau
        '
        Me.cbBinhBau.Location = New System.Drawing.Point(85, 13)
        Me.cbBinhBau.Name = "cbBinhBau"
        Me.cbBinhBau.Size = New System.Drawing.Size(201, 21)
        Me.cbBinhBau.TabIndex = 38
        '
        'frmChiTietBBCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(290, 130)
        Me.Controls.Add(Me.cbBinhBau)
        Me.Controls.Add(Me.cbChucVu)
        Me.Controls.Add(Me.btDong)
        Me.Controls.Add(Me.btChon)
        Me.Controls.Add(Me.txtSoTien)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmChiTietBBCV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmChiTietBBCV"
        CType(Me.cbChucVu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBinhBau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbChucVu As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btDong As System.Windows.Forms.Button
    Friend WithEvents btChon As System.Windows.Forms.Button
    Friend WithEvents txtSoTien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBinhBau As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
