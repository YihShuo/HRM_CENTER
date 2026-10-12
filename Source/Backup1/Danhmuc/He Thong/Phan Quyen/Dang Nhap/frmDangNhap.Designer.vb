<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangNhap
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
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.cbChinhanh = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btDangnhap = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btThoat = New System.Windows.Forms.Button
        Me.txtMatkhau = New System.Windows.Forms.TextBox
        Me.txtTendangnhap = New System.Windows.Forms.TextBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.cbChinhanh)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.btDangnhap)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.btThoat)
        Me.UltraTabPageControl1.Controls.Add(Me.txtMatkhau)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTendangnhap)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(337, 133)
        '
        'cbChinhanh
        '
        Me.cbChinhanh.DisplayMember = "Tỷ Thạc"
        Me.cbChinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChinhanh.FormattingEnabled = True
        Me.cbChinhanh.Items.AddRange(New Object() {"Tỷ Thạc"})
        Me.cbChinhanh.Location = New System.Drawing.Point(142, 16)
        Me.cbChinhanh.Name = "cbChinhanh"
        Me.cbChinhanh.Size = New System.Drawing.Size(176, 21)
        Me.cbChinhanh.TabIndex = 6
        Me.cbChinhanh.ValueMember = "Tỷ Thạc"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(19, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Chọn Chi Nhánh"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(20, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên Đăng Nhập"
        '
        'btDangnhap
        '
        Me.btDangnhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDangnhap.ForeColor = System.Drawing.Color.Blue
        Me.btDangnhap.Location = New System.Drawing.Point(142, 98)
        Me.btDangnhap.Name = "btDangnhap"
        Me.btDangnhap.Size = New System.Drawing.Size(85, 26)
        Me.btDangnhap.TabIndex = 2
        Me.btDangnhap.Text = "Đăng Nhập"
        Me.btDangnhap.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(51, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mật Khẩu"
        '
        'btThoat
        '
        Me.btThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThoat.ForeColor = System.Drawing.Color.Blue
        Me.btThoat.Location = New System.Drawing.Point(233, 98)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(85, 26)
        Me.btThoat.TabIndex = 3
        Me.btThoat.Text = "Thoát"
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'txtMatkhau
        '
        Me.txtMatkhau.Location = New System.Drawing.Point(142, 70)
        Me.txtMatkhau.MaxLength = 50
        Me.txtMatkhau.Name = "txtMatkhau"
        Me.txtMatkhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatkhau.Size = New System.Drawing.Size(176, 20)
        Me.txtMatkhau.TabIndex = 1
        '
        'txtTendangnhap
        '
        Me.txtTendangnhap.Location = New System.Drawing.Point(142, 43)
        Me.txtTendangnhap.MaxLength = 50
        Me.txtTendangnhap.Name = "txtTendangnhap"
        Me.txtTendangnhap.Size = New System.Drawing.Size(176, 20)
        Me.txtTendangnhap.TabIndex = 3
        Me.txtTendangnhap.Text = "admin"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(341, 156)
        Me.UltraTabControl1.TabIndex = 6
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Thông Tin Đăng Nhập"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.VisualStudio2005
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(337, 133)
        '
        'frmDangNhap
        '
        Me.AcceptButton = Me.btDangnhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(341, 156)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDangNhap"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng Nhập"
        Me.TopMost = True
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btDangnhap As System.Windows.Forms.Button
    Friend WithEvents btThoat As System.Windows.Forms.Button
    Friend WithEvents txtTendangnhap As System.Windows.Forms.TextBox
    Friend WithEvents txtMatkhau As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbChinhanh As System.Windows.Forms.ComboBox
End Class
