
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
Public Class frmBaocaogioconghangngay

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objBaocaogioconghangngay
        Me.b = New clsBBaocaogioconghangngay

        If Me.rdGCHangNgay.Checked = True Then
            obj.Table = "JELLTHONGKEGIOCONGHANGNGAY_PHUONGNGANTABLE"
            obj.ChonBang = 1
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrGioCongDV_Ngay")
        End If

        If Me.rdGCHangThang.Checked = True Then
            obj.Table = "JELLTHONGKEGIOCONGHANGTHANG_PHUONGNGANTABLE"
            obj.ChonBang = 2
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrGioCongDV_Thang")
        End If

        If Me.rdGCHangNam.Checked = True Then
            obj.Table = "JELLTHONGKEGIOCONGHANGNAM_PHUONGNGANTABLE"
            obj.ChonBang = 3
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrGioCongDV_Nam")
        End If

        If Me.rdGCHangTuan.Checked = True Then
            obj.Table = "JELLTHONGKEGIOCONGHANGTUAN_PHUONGNGANTABLE"
            obj.ChonBang = 4
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrGioCongDV_Tuan")
        End If

        End Sub

    Public Language As Integer
    Private Sub frmBaocaogioconghangngay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim obj As New objBaocaogioconghangngay
        Me.b = New clsBBaocaogioconghangngay
        obj.ChonBang = 5
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        obj.ChonBang = 6
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.SelectedIndex = 0
        Me.cbXuong.SelectedIndex = 0
        obj.Setnull()
        Me.rdGCHangNgay.Checked = True

        'An hoac hien cac control dieu kien
        Me.An()
    End Sub

    Public Sub Setchecknull()
        Me.chbNgay.Checked = False
        Me.chbTuan.Checked = False
        Me.chbDonvi.Checked = False
        Me.chbXuong.Checked = False

    End Sub

    Dim ReportID As String
    Dim PATH As String
    Dim chStateNgay As Boolean
    Dim chStateTuan As Boolean
    Dim chStateXuong As Boolean
    Dim chStateDonvi As Boolean
    Dim chStateNganh As Boolean
    Dim chStateCapNhatNgay As Boolean
    Dim chStateCapNhatThang As Boolean
    Dim chStateCapNhatTuan As Boolean
    Dim chStateCapNhatNam As Boolean
    Dim obj As New objBaocaogioconghangngay
    Friend WithEvents b As clsBBaocaogioconghangngay

    Private Sub rdGCHangNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGCHangNgay.CheckedChanged
        Me.An()
        Me.AnTuan()

        If Me.rdGCHangNgay.Checked = True Then
            clsTools.GridTheme1(Me.dgrBC)
            Me.ReportID = "114"
            Me.PATH = "/layout/GioCongHangNgay.xml"
            'Me.methodLoad()
        End If
    End Sub

    Private Sub An()
        Me.Setchecknull()
        Me.Trangthaidieukien()
    End Sub


    Private Sub AnTuan()
        Me.chbTuan.Visible = False
        Me.txtTuan.Visible = False
        Me.txtNam.Visible = False
        Me.lbTuan.Visible = False
        Me.lbNam.Visible = False

        Me.chbNgay.Visible = True
        Me.lbNgay.Visible = True
        Me.cbNgaythangnam.Visible = True
    End Sub

    Private Sub HienTuan()
        Me.chbTuan.Visible = True
        Me.txtTuan.Visible = True
        Me.txtNam.Visible = True
        Me.lbTuan.Visible = True
        Me.lbNam.Visible = True

        Me.chbNgay.Visible = False
        Me.lbNgay.Visible = False
        Me.cbNgaythangnam.Visible = False
    End Sub


    Private Sub btExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btXemBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chbNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgay.CheckedChanged
        chStateNgay = Me.chbNgay.Checked
        Me.Trangthaidieukien()
    End Sub
    Public Sub Trangthaidieukien()
        Me.cbNgaythangnam.Enabled = Me.chStateNgay
        Me.txtTuan.Enabled = Me.chStateTuan
        Me.cbXuong.Enabled = Me.chStateXuong
        Me.cbDonvi.Enabled = Me.chStateDonvi
    End Sub

    Private Sub chbXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbXuong.CheckedChanged
        chStateXuong = Me.chbXuong.Checked
        Me.cbXuong.Focus()
        Me.Trangthaidieukien()
    End Sub

    Private Sub chbDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDonvi.CheckedChanged
        chStateDonvi = Me.chbDonvi.Checked
        Me.Trangthaidieukien()
    End Sub


    'Public Sub VietNam()
    '    'Dieu kien loc, chung
    '    Me.grbDieukienloc.Text = clsLanguage.DieuKienLoc()
    '    Me.lbNgay.Text = clsLanguage.Ngay()
    '    Me.lbXuong.Text = clsLanguage.Xuong()
    '    Me.lbDonvi.Text = clsLanguage.Donvi()

    '    'Tieu de
    '    Me.Text = clsLanguage.ThongKeGioCongHangNgayTheoDV()
    '    Me.xpTKgiocong.Text = clsLanguage.ThongKeGioCongHangNgayTheoDV()
    '    Me.tabTKgiocongdonvi.Tabs(0).Text = clsLanguage.ThongKeGioCongHangNgayTheoDV()
    '    Me.grbTKgiocongdonvi.Text = clsLanguage.ThongKeGioCongHangNgayTheoDV()
    '    Me.xpDSgiocong.Text = clsLanguage.Danhsachgiocong()

    '    'Report
    '    Me.rdGCHangNgay.Text = clsLanguage.ThongKeGioCongHangNgayTheoDV()
    'End Sub


    'Public Sub TaiWan()
    '    'Dieu kien loc, chung
    '    Me.grbDieukienloc.Text = clsLanguage.DieuKienLocTaiwan()
    '    Me.lbNgay.Text = clsLanguage.NgayTaiwan()
    '    Me.lbXuong.Text = clsLanguage.XuongTaiwan()
    '    Me.lbDonvi.Text = clsLanguage.DonviTaiwan()

    '    'Tieu de
    '    Me.Text = clsLanguage.ThongKeGioCongHangNgayTheoDVTaiwan()
    '    Me.xpTKgiocong.Text = clsLanguage.ThongKeGioCongHangNgayTheoDVTaiwan()
    '    Me.tabTKgiocongdonvi.Tabs(0).Text = clsLanguage.ThongKeGioCongHangNgayTheoDVTaiwan()
    '    Me.grbTKgiocongdonvi.Text = clsLanguage.ThongKeGioCongHangNgayTheoDVTaiwan()
    '    Me.xpDSgiocong.Text = clsLanguage.DanhsachgiocongTaiwan()

    '    'Report
    '    Me.rdGCHangNgay.Text = clsLanguage.ThongKeGioCongHangNgayTheoDVTaiwan()
    'End Sub
   
    Private Sub ButtonItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub ButtonItem2_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Activate
        Dim Ngay As Date
        Ngay = Me.cbNgaythangnam.Value

        Dim report As New FrmReport
        'Ma so report
        report.reportID = Me.ReportID

        'Truyen tham so cho report 
        Dim strArray As String()

        If Me.rdGCHangNgay.Checked = True Then
            strArray = New String() {Me.cbNgaythangnam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi}
        End If
        'Tuan------------------------------
        If Me.rdGCHangTuan.Checked = True Then
            strArray = New String() {Me.txtTuan.Text, Me.txtNam.Text, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateTuan, Me.chStateXuong, Me.chStateDonvi}
        End If
        ''Thang------------------------------
        If Me.rdGCHangThang.Checked = True Then
            strArray = New String() {Ngay.Month.ToString, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi, Ngay.Year.ToString}
        End If
        ''Nam------------------------------
        If Me.rdGCHangNam.Checked = True Then
            strArray = New String() {Ngay.Year.ToString, Me.cbXuong.Text, Me.cbDonvi.Text, Me.chStateNgay, Me.chStateXuong, Me.chStateDonvi}
        End If

        report.para = strArray

        report.issysReport = True

        report.Show()
    End Sub

    Private Sub ButtonItem3_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Activate
        Dim frm As New frmWaiting
        If Me.rdGCHangNgay.Checked = True Then
            If Me.chStateNgay = False Then
                MessageBox.Show("Bạn phải chọn một ngày để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbNgay.Checked = True
                Me.cbNgaythangnam.Focus()
                Exit Sub
            End If
            Dim Ngay As Date = Me.cbNgaythangnam.Value
            frm.ID_Ngay = Ngay.Day.ToString()
            frm.ID_Thang = Ngay.Month.ToString()
            frm.ID_Nam = Ngay.Year.ToString()
            frm.Bang = 9
        End If

        If Me.rdGCHangThang.Checked = True Then
            If Me.chStateNgay = False Then
                MessageBox.Show("Bạn phải chọn một tháng để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbNgay.Checked = True
                Me.cbNgaythangnam.Focus()
                Exit Sub
            End If
            Dim Ngay As Date = Me.cbNgaythangnam.Value
            frm.ID_Thang = Ngay.Month.ToString()
            frm.ID_Nam = Ngay.Year.ToString()
            frm.Bang = 14
        End If

        If Me.rdGCHangNam.Checked = True Then
            If Me.chStateNgay = False Then
                MessageBox.Show("Bạn phải chọn một năm để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbNgay.Checked = True
                Me.cbNgaythangnam.Focus()
                Exit Sub
            End If
            Dim Ngay As Date = Me.cbNgaythangnam.Value
            frm.ID_Nam = Ngay.Year.ToString()
            frm.Bang = 15
        End If

        If Me.rdGCHangTuan.Checked = True Then
            If Me.chStateTuan = False Then
                MessageBox.Show("Bạn phải chọn một tuần để cập nhật", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.chbTuan.Checked = True
                Me.txtTuan.Focus()
                Exit Sub
            End If
            frm.ID_Tuan = Me.txtTuan.Text
            frm.ID_Nam = Me.txtNam.Text

            frm.Bang = 16
        End If

        frm.ShowDialog()
        Me.methodLoad()
    End Sub

    
    Private Sub rdGCHangThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGCHangThang.CheckedChanged
        Me.An()
        Me.AnTuan()

        If Me.rdGCHangThang.Checked = True Then
            clsTools.GridTheme1(Me.dgrBC)
            Me.ReportID = "118"
            Me.PATH = "/layout/GioCongHangThang.xml"
            'Me.methodLoad()
        End If
    End Sub

   
    Private Sub rdGCHangNam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGCHangNam.CheckedChanged
        Me.An()
        Me.AnTuan()

        If Me.rdGCHangNam.Checked = True Then
            clsTools.GridTheme1(Me.dgrBC)
            Me.ReportID = "119"
            Me.PATH = "/layout/GioCongHangNam.xml"
            'Me.methodLoad()
        End If
    End Sub

    Private Sub rdGCHangTuan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdGCHangTuan.CheckedChanged
        Me.An()
        Me.HienTuan()

        If Me.rdGCHangTuan.Checked = True Then
            clsTools.GridTheme1(Me.dgrBC)
            Me.ReportID = "120"
            Me.PATH = "/layout/GioCongHangTuan.xml"
            'Me.methodLoad()
        End If
    End Sub

    Private Sub chbTuan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTuan.CheckedChanged
        Me.chStateTuan = Me.chbTuan.Checked
        Me.Trangthaidieukien()
    End Sub

   

    Private Sub txtTuan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTuan.TextChanged

    End Sub

    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        Me.methodLoad()
    End Sub
End Class