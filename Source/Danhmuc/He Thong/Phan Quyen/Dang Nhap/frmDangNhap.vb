Imports System
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports TD.SandBar
Imports TongHop.frmMainMain
Imports TongHop.MAIN

Public Class frmDangNhap

    Friend WithEvents b As clsBDangNhap
    Public tennguoidung As String

    Private Sub btDangnhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDangNhap.Click

        If Not loadServerCurr() Then
            Dim tdb As New FrmConnectDB
            tdb.ShowDialog()
            Interaction.MsgBox("Vui lòng khởi động lại chương trình", MsgBoxStyle.Information)
            Application.Exit()
            Exit Sub
        End If

        Dim tenDN As String = txtTendangnhap.Text.Trim()
        Dim mkNhap As String = txtMatkhau.Text.Trim()

        If tenDN = "" Or mkNhap = "" Then
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo")
            Exit Sub
        End If

        Dim mkMaHoa As String = clsTools.Encrypt1(mkNhap)
        Dim obj As New objDangNhap
        obj.ChonBang = 1
        obj.setvalue(tenDN, mkMaHoa)

        Me.b = New clsBDangNhap
        Dim table As DataTable = Me.b.LoadDS(obj)

        If table Is Nothing Or table.Rows.Count = 0 Then
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
            "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            txtMatkhau.Focus()
            Exit Sub
        End If

        'If table Is Nothing Or table.Rows.Count = 0 Then
        '    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtMatkhau.Focus()
        '    Exit Sub
        'End If
        Dim nv As DataTable = Me.b.KiemTraThoiviec(obj)

        ' Chỉ kiểm tra thôi việc khi có thông tin nhân viên
        If nv IsNot Nothing AndAlso nv.Rows.Count > 0 Then

            If Not IsDBNull(nv.Rows(0)("NV_THOIVIEC")) Then

                If Convert.ToInt32(nv.Rows(0)("NV_THOIVIEC")) = 1 Then
                    MessageBox.Show("Tài khoản đã bị khóa!")
                    Exit Sub
                End If

            End If

        End If

        Dim ngayDoi As DateTime = Date.MinValue

        If Not IsDBNull(table.Rows(0)("NgayDoiMatKhau")) Then
            ngayDoi = Date.Parse(table.Rows(0)("NgayDoiMatKhau"))
        End If

        Dim soThang As Integer = DateDiff(DateInterval.Month, ngayDoi, Now)

        If soThang >= 3 Then
            lblThongBao.Visible = True
            lblThongBao.ForeColor = Color.DarkOrange
            lblThongBao.Text = "Mật khẩu đã quá 3 tháng, vui lòng đổi mật khẩu!"
            btDoiMatKhau.Visible = True
            Exit Sub
        End If

        MAIN.userclient = tenDN
        MAIN.PassLogin = mkMaHoa

        If table.Rows.Count > 0 Then
            MAIN.USER_KT = False 'table.Rows(0).Item("USER_KT").ToString
            Dim frm As New frmMain
            frm.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub btDoiMatKhau_Click(sender As Object, e As EventArgs) Handles btDoiMatKhau.Click
        Me.Hide()
        Dim frm As New frmDoiMatKhau(txtTendangnhap.Text)
        frm.ShowDialog()
        lblThongBao.Text = ""
        btDoiMatKhau.Visible = False
        'Me.Close()
    End Sub

    '=====================================================
    ' NÚT THOÁT
    '=====================================================
    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub
    Public Shared Function GetConnectionString() As String
        Dim server = clsTools.Decrypt1(ConfigurationManager.AppSettings("Server"))
        Dim db = clsTools.Decrypt1(ConfigurationManager.AppSettings("Database"))
        Dim user = clsTools.Decrypt1(ConfigurationManager.AppSettings("UserID"))
        Dim pass = clsTools.Decrypt1(ConfigurationManager.AppSettings("Password"))
        Return $"Data Source={server};Initial Catalog={db};User ID={user};Password={pass}"
    End Function


    '=====================================================
    ' FORM LOAD
    '=====================================================
    Private Sub frmDangNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.cbChinhanh.Text = "Tỷ Thạc"

        If Not loadServerCurr() Then
            Dim tdb As New FrmConnectDB
            tdb.ShowDialog()
            Interaction.MsgBox("Vui lòng khởi động lại chương trình", MsgBoxStyle.Information)
            Application.Exit()
        End If

    End Sub

End Class
