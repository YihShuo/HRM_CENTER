<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDangNhap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblThongBao = New System.Windows.Forms.Label()
        Me.btDoiMatKhau = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btDangNhap = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btThoat = New System.Windows.Forms.Button()
        Me.txtMatkhau = New System.Windows.Forms.TextBox()
        Me.txtTendangnhap = New System.Windows.Forms.TextBox()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.lblThongBao)
        Me.UltraTabPageControl1.Controls.Add(Me.btDoiMatKhau)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.btDangNhap)
        Me.UltraTabPageControl1.Controls.Add(Me.Label2)
        Me.UltraTabPageControl1.Controls.Add(Me.btThoat)
        Me.UltraTabPageControl1.Controls.Add(Me.txtMatkhau)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTendangnhap)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(369, 156)
        '
        'lblThongBao
        '
        Me.lblThongBao.AutoSize = True
        Me.lblThongBao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblThongBao.ForeColor = System.Drawing.Color.Red
        Me.lblThongBao.Location = New System.Drawing.Point(27, 77)
        Me.lblThongBao.Name = "lblThongBao"
        Me.lblThongBao.Size = New System.Drawing.Size(272, 16)
        Me.lblThongBao.TabIndex = 8
        Me.lblThongBao.Text = "Yêu cầu người dùng thay đổi mật khẩu!"
        Me.lblThongBao.Visible = False
        '
        'btDoiMatKhau
        '
        Me.btDoiMatKhau.BackColor = System.Drawing.Color.DarkOrange
        Me.btDoiMatKhau.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btDoiMatKhau.ForeColor = System.Drawing.Color.White
        Me.btDoiMatKhau.Location = New System.Drawing.Point(151, 107)
        Me.btDoiMatKhau.Name = "btDoiMatKhau"
        Me.btDoiMatKhau.Size = New System.Drawing.Size(100, 26)
        Me.btDoiMatKhau.TabIndex = 7
        Me.btDoiMatKhau.Text = "Đổi mật khẩu"
        Me.btDoiMatKhau.UseVisualStyleBackColor = False
        Me.btDoiMatKhau.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(28, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên đăng nhập:"
        '
        'btDangNhap
        '
        Me.btDangNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btDangNhap.ForeColor = System.Drawing.Color.Blue
        Me.btDangNhap.Location = New System.Drawing.Point(151, 107)
        Me.btDangNhap.Name = "btDangNhap"
        Me.btDangNhap.Size = New System.Drawing.Size(100, 26)
        Me.btDangNhap.TabIndex = 2
        Me.btDangNhap.Text = "Đăng nhập"
        Me.btDangNhap.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(51, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mật khẩu:"
        '
        'btThoat
        '
        Me.btThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btThoat.ForeColor = System.Drawing.Color.Blue
        Me.btThoat.Location = New System.Drawing.Point(257, 107)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(85, 26)
        Me.btThoat.TabIndex = 3
        Me.btThoat.Text = "Thoát"
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'txtMatkhau
        '
        Me.txtMatkhau.Location = New System.Drawing.Point(151, 50)
        Me.txtMatkhau.MaxLength = 50
        Me.txtMatkhau.Name = "txtMatkhau"
        Me.txtMatkhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatkhau.Size = New System.Drawing.Size(176, 20)
        Me.txtMatkhau.TabIndex = 1
        '
        'txtTendangnhap
        '
        Me.txtTendangnhap.Location = New System.Drawing.Point(151, 22)
        Me.txtTendangnhap.MaxLength = 50
        Me.txtTendangnhap.Name = "txtTendangnhap"
        Me.txtTendangnhap.Size = New System.Drawing.Size(176, 20)
        Me.txtTendangnhap.TabIndex = 0
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(373, 179)
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
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(369, 156)
        '
        'frmDangNhap
        '
        Me.AcceptButton = Me.btDangNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(373, 179)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDangNhap"
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
    Friend WithEvents btDangNhap As System.Windows.Forms.Button
    Friend WithEvents btThoat As System.Windows.Forms.Button
    Friend WithEvents txtTendangnhap As System.Windows.Forms.TextBox
    Friend WithEvents txtMatkhau As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lblThongBao As System.Windows.Forms.Label
    Friend WithEvents btDoiMatKhau As System.Windows.Forms.Button
End Class
