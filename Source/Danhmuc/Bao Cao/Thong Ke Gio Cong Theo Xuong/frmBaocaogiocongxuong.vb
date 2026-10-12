Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar

Public Class frmBaocaogiocongxuong

    Private Sub rdKTNgayXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKTNgayXuong.CheckedChanged
        Me.chStateCapNhatNgay = Me.rdKTNgayXuong.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdKTNgayXuong.Checked = True Then
            Me.Andieukientuan()
            clsTools.GridTheme1(Me.dgrBC)
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False

            Me.ReportID = "100"
            Me.PATH = "/layout/Thongke/Thongkegiocongtheoxuong/GioCongNgayXuong.xml"

            obj.Table = "JELL_THONGKEGIOCONG_NGAYXUONGTABLE"
            obj.ChonBang = 1

            Me.b = New clsBBaocaogiocongxuong
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdKTTuanXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKTTuanXuong.CheckedChanged
        Me.chStateCapNhatTuan = Me.rdKTTuanXuong.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdKTTuanXuong.Checked = True Then
            Me.Hiendieukientuan()
            clsTools.GridTheme1(Me.dgrBC)
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False

            Me.ReportID = "101"
            Me.PATH = "/layout/Thongke/Thongkegiocongtheoxuong/GioCongTuanXuong.xml"

            obj.Table = "JELL_THONGKEGIOCONG_TUANXUONGTABLE"
            obj.ChonBang = 2

            Me.b = New clsBBaocaogiocongxuong
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdKTThangXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKTThangXuong.CheckedChanged
        Me.chStateCapNhatThang = Me.rdKTThangXuong.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdKTThangXuong.Checked = True Then
            clsTools.GridTheme1(Me.dgrBC)
            Me.Andieukientuan()
            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False


            Me.ReportID = "102"
            Me.PATH = "/layout/Thongke/Thongkegiocongtheoxuong/GioCongThangXuong.xml"

            obj.Table = "JELL_THONGKEGIOCONG_THANGXUONGTABLE"
            obj.ChonBang = 3

            Me.b = New clsBBaocaogiocongxuong
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdKTNamXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKTNamXuong.CheckedChanged
        Me.chStateCapNhatNam = Me.rdKTNamXuong.Checked
        Me.Trangthaidieukienbtcapnhat()
        If Me.rdKTNamXuong.Checked = True Then

            clsTools.GridTheme1(Me.dgrBC)
            Me.Andieukientuan()

            Me.chbNgay.Checked = False
            Me.chbXuong.Checked = False


            Me.ReportID = "103"
            Me.PATH = "/layout/Thongke/Thongkegiocongtheoxuong/GioCongNamXuong.xml"

            obj.Table = "JELL_THONGKEGIOCONG_NAMXUONGTABLE"
            obj.ChonBang = 4

            Me.b = New clsBBaocaogiocongxuong
            'Me.methodLoad()
        End If
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrKhacThuong")
    End Sub

    Public Sub Setchecknull()
        chStateNgay = False
        chStateXuong = False
        chStateTuan = False
    End Sub

    Public Sub Trangthaidieukien()
        Me.cbNgaythangnam.Enabled = chStateNgay
        Me.cbXuong.Enabled = chStateXuong
        Me.txtTuan.Enabled = chStateTuan
        Me.txtNam.Enabled = chStateTuan

    End Sub

    Public Sub Trangthaidieukienbtcapnhat()
        Me.btCapnhatngay.Enabled = Me.chStateCapNhatNgay
        Me.btCapnhatthang.Enabled = Me.chStateCapNhatThang
        Me.btCapnhatTuan.Enabled = Me.chStateCapNhatTuan
        Me.btCapnhatnam.Enabled = Me.chStateCapNhatNam
    End Sub

    Public Sub Hiendieukientuan()
        Me.lbTuan.Visible = True
        Me.lbNam.Visible = True
        Me.txtNam.Visible = True
        Me.chbTuan.Visible = True
        Me.txtTuan.Visible = True

        Me.lbNgay.Visible = False
        Me.chbNgay.Visible = False
        Me.cbNgaythangnam.Visible = False
    End Sub

    Public Sub Andieukientuan()
        Me.lbTuan.Visible = False
        Me.lbNam.Visible = False
        Me.txtNam.Visible = False
        Me.chbTuan.Visible = False
        Me.txtTuan.Visible = False

        Me.lbNgay.Visible = True
        Me.chbNgay.Visible = True
        Me.cbNgaythangnam.Visible = True
    End Sub


    Public Function KiemTraThamSo() As Integer
        If Me.chbTuan.Visible = True And Me.chbTuan.Checked = True Then
            If Me.txtTuan.Text = "" Then
                Me.txtTuan.Focus()
                MessageBox.Show("Bạn Phải Nhập Vào Tuần")
                Return 1
            End If
            If Me.txtNam.Text = "" Then
                Me.txtNam.Focus()
                MessageBox.Show("Bạn Phải Nhập Vào Năm")
                Return 1
            End If
        End If
        Return 0
    End Function


   



    Private Sub btExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub chbTuan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTuan.CheckedChanged
        chStateTuan = Me.chbTuan.Checked
        If Me.chbTuan.Checked = False Then
            Me.txtTuan.Text = "01"
            Me.txtNam.Text = "2009"
        End If
        Me.Trangthaidieukien()
    End Sub

    Private Sub chbXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbXuong.CheckedChanged
        chStateXuong = Me.chbXuong.Checked
        Me.cbXuong.Focus()
        Me.Trangthaidieukien()
    End Sub

    Private Sub chbNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgay.CheckedChanged
        chStateNgay = Me.chbNgay.Checked
        Me.Trangthaidieukien()
    End Sub


    Private Sub txtTuan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTuan.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtNam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNam.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Public Language As Integer
    Private Sub frmBaocaogiocongxuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        obj.Setnull()
        obj.Table = "ST_NXUONG"
        obj.ChonBang = 5
        Me.b = New clsBBaocaogiocongxuong
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.SelectedIndex = 0

        Me.rdKTNgayXuong.Checked = True

        'An hoac hien cac control dieu kien
        Me.Setchecknull()
        Me.Trangthaidieukien()
    End Sub

    ' bien
    Dim ReportID As String
    Dim PATH As String
    Dim chStateNgay As Boolean
    Dim chStateTuan As Boolean
    Dim chStateXuong As Boolean
    Dim chStateCapNhatNgay As Boolean
    Dim chStateCapNhatThang As Boolean
    Dim chStateCapNhatTuan As Boolean
    Dim chStateCapNhatNam As Boolean
    Dim obj As New objBaocaogiocongxuong
    Friend WithEvents b As clsBBaocaogiocongxuong

    Private Sub btCapnhatngay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatngay.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một ngày để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value
        frm.ID_Ngay = Ngay.Day.ToString()
        frm.ID_Thang = Ngay.Month.ToString()
        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 10
        frm.ShowDialog()
       
        Me.methodLoad()
    End Sub

    Private Sub btCapnhattuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhattuan.Click
        If Me.chStateTuan = False Then
            MessageBox.Show("Bạn phải chọn một tuần của năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbTuan.Checked = True
            Me.txtTuan.Focus()
            Exit Sub
        Else
            If Me.txtTuan.Text = "" Or Me.txtNam.Text = "" Then
                MessageBox.Show("Bạn phải chọn một tuần của năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbTuan.Checked = True
                Me.txtTuan.Focus()
                Exit Sub
            End If
        End If

        Dim frm As New frmWaiting
        frm.ID_Tuan = Me.txtTuan.Value
        frm.ID_Nam = Me.txtNam.Value
        frm.Bang = 11

        frm.ShowDialog()
        Me.methodLoad()
    End Sub

    Private Sub btCapnhatthang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatthang.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một tháng để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value

        frm.ID_Thang = Ngay.Month.ToString()
        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 12

        frm.ShowDialog()
        Me.methodLoad()
    End Sub

    Private Sub btCapnhatnam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhatnam.Click
        If Me.chStateNgay = False Then
            MessageBox.Show("Bạn phải chọn một năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.chbNgay.Checked = True
            Me.cbNgaythangnam.Focus()
            Exit Sub
        End If

        Dim frm As New frmWaiting
        Dim Ngay As Date = Me.cbNgaythangnam.Value

        frm.ID_Nam = Ngay.Year.ToString()
        frm.Bang = 13

        frm.ShowDialog()
        Me.methodLoad()
    End Sub

    'Public Sub VietNam()
    '    'Dieu kien loc, chung
    '    Me.grbDieukienloc.Text = clsLanguage.DieuKienLoc()
    '    Me.lbTuan.Text = clsLanguage.Tuan()
    '    Me.lbNgay.Text = clsLanguage.Ngay()
    '    Me.lbNam.Text = clsLanguage.Nam()
    '    Me.lbXuong.Text = clsLanguage.Xuong()        
    '    Me.btCapnhatnam.Text = clsLanguage.CapNhat()
    '    Me.btCapnhatngay.Text = clsLanguage.CapNhat()
    '    Me.btCapnhatTuan.Text = clsLanguage.CapNhat()
    '    Me.btCapnhatthang.Text = clsLanguage.CapNhat()


    '    'Tieu de
    '    Me.Text = clsLanguage.ThongKeGioCongTheoXuong()
    '    Me.xpTKgiocong.Text = clsLanguage.ThongKeGioCongTheoXuong()
    '    Me.tabTKgiocongxuong.Tabs(0).Text = clsLanguage.ThongKeGioCongTheoXuong()
    '    Me.grbTKgiocongxuong.Text = clsLanguage.ThongKeGioCongTheoXuong()
    '    Me.xpDSgiocong.Text = clsLanguage.Danhsachgiocong()

    '    'Report
    '    Me.rdKTNamXuong.Text = clsLanguage.ThongKeGioCongNamX()
    '    Me.rdKTNgayXuong.Text = clsLanguage.ThongKeGioCongNgayX()
    '    Me.rdKTThangXuong.Text = clsLanguage.ThongKeGioCongThangX()
    '    Me.rdKTTuanXuong.Text = clsLanguage.ThongKeGioCongTuanX()



    'End Sub


    'Public Sub TaiWan()
    '    'Dieu kien loc, chung
    '    Me.grbDieukienloc.Text = clsLanguage.DieuKienLocTaiwan()
    '    Me.lbTuan.Text = clsLanguage.TuanTaiwan()
    '    Me.lbNgay.Text = clsLanguage.NgayTaiwan()
    '    Me.lbNam.Text = clsLanguage.NamTaiwan()
    '    Me.lbXuong.Text = clsLanguage.XuongTaiwan()
    '    Me.btCapnhatnam.Text = clsLanguage.CapNhatTaiwan()
    '    Me.btCapnhatngay.Text = clsLanguage.CapNhatTaiwan()
    '    Me.btCapnhattuan.Text = clsLanguage.CapNhatTaiwan()
    '    Me.btCapnhatthang.Text = clsLanguage.CapNhatTaiwan()


    '    'Tieu de
    '    Me.Text = clsLanguage.ThongKeGioCongTheoXuongTaiwan()
    '    Me.xpTKgiocong.Text = clsLanguage.ThongKeGioCongTheoXuongTaiwan()
    '    Me.tabTKgiocongxuong.Tabs(0).Text = clsLanguage.ThongKeGioCongTheoXuongTaiwan()
    '    Me.grbTKgiocongxuong.Text = clsLanguage.ThongKeGioCongTheoXuongTaiwan()
    '    Me.xpDSgiocong.Text = clsLanguage.DanhsachgiocongTaiwan()

    '    'Report
    '    Me.rdKTNamXuong.Text = clsLanguage.ThongKeGioCongNamXTaiwan()
    '    Me.rdKTNgayXuong.Text = clsLanguage.ThongKeGioCongNgayXTaiwan()
    '    Me.rdKTThangXuong.Text = clsLanguage.ThongKeGioCongThangXTaiwan()
    '    Me.rdKTTuanXuong.Text = clsLanguage.ThongKeGioCongTuanXTaiwan()
    'End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate
        Dim report As New FrmReport
        'Ma so report
        report.reportID = Me.ReportID

        If KiemTraThamSo() = 1 Then
            Exit Sub
        End If
        'Truyen tham so cho report 
        Dim strArray As String()

        'Ngay------------------------------
        If Me.rdKTNgayXuong.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.chStateNgay, Me.chStateXuong}
        End If

        'Tuan------------------------------
        If Me.rdKTTuanXuong.Checked = True Then
            strArray = New String() {Me.txtTuan.Text, Me.txtNam.Text, Me.cbXuong.Text, Me.chStateTuan, Me.chStateXuong}
        End If

        'Thang------------------------------
        If Me.rdKTThangXuong.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.chStateNgay, Me.chStateXuong}
        End If

        'Nam------------------------------
        If Me.rdKTNamXuong.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.chStateNgay, Me.chStateXuong}
        End If

        report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        Me.methodLoad()
    End Sub
End Class