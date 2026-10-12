Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinToolTip
Imports Microsoft.VisualBasic.Strings
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
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic
Public Class frmNuoiConDuoi6Tuoi
    Dim oldRow As Integer = 0
    Public trangthai As Integer
    Public tuoi, thangtuoi As Integer
    Dim Tabletemp As DataTable
    Public NgayHienTai As String = ""
    Friend WithEvents b As ClsB_ConDuoi6Tuoi
    Friend WithEvents d As New ClsD_ConDuoi6Tuoi
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public obj As New Obj_ConDuoi6Tuoi
    Dim Path, thangnam As String
    Public strArray As String()
    Dim ReportID As String
    ''=========== xét phân quyền chức năng khi thêm sửa xóa form nuoi con nho  ===''
    Public Them As Boolean = False
    Public Sua As Boolean = False
    Public Xoa As Boolean = False
    Public bAdmin As Boolean = False
    Public bChuyenDuLieu As Boolean = False
    ''===== xet phân quyền phân chia khu A, B
    Public sTenNguoiDung As String  ''lấy trạng thái khu A, B từ bảng phân quyền chủ yếu Tab0: nhập, tab1: chuyen du lieu
    Public KHUA As Boolean = False
    Public KHUB As Boolean = False  ''mặc định là 0
    Public bTCT As Boolean = False  '' khi khu A, khu B= 1
    ''==================================================

    Private Sub frmNuoiConDuoi6Tuoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''=========== trạng thái mặc định ===''
        Dim thangnamht As String = Now().Month.ToString() & "-" & Now().Year.ToString()
        Dim item As Integer
        Me.dtpNgayHETHAN.Enabled = False
        Me.radDu6Tuoi.Enabled = False
        Me.radChuadu6Tuoi.Enabled = False
        Me.radXemThangNam.Checked = True
        Me.dtpXemNgThNam.Enabled = True

        Me.NgayHienTai = NgayHT()
        Me.txtTCNgayHT.Text = Me.NgayHienTai

        LoadThangNam()
        If dtpXemNgThNam.Items.Count > 0 Then
            For item = 0 To Me.dtpXemNgThNam.Items.Count - 1
                If dtpXemNgThNam.Items(item).ToString() = NgayHienTai.Substring(3, 7) Then
                    dtpXemNgThNam.SelectedIndex = item
                End If
            Next
        End If
        LoadCombo()
        ClearThongTin()
        Me.dtpNgaynhap.Text = NgayHienTai
        Me.dtpNgaySanh.Value = NgayHienTai
        ''============= XÉT PHÂN QUYỀN ======''
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        sTenNguoiDung = obj.TenDangNhap
        obj.ChonBang = 8
        Dim TQuyenTruyCap, TUser As New DataTable
        TUser = Me.b.LoadDS(obj)
        If TUser.Rows.Count > 0 Then
            obj.ChonBang = 9
            TQuyenTruyCap = Me.b.LoadDS(obj)
            If TQuyenTruyCap.Rows.Count > 0 Then
                ''======================== xet trang thai la admin thi bo qua ==============''
                If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Or TUser.Rows(0).Item("Ten_Dangnhap").ToString().ToLower = "admin" Then
                    Them = True
                    Sua = True
                    Xoa = True
                    bAdmin = True
                    bChuyenDuLieu = True
                    bTCT = True
                    KHUA = True
                    KHUB = True
                    ''gan mac dinh admin dc them xoa sua chuyen du lieu, thao tac toan cong ty

                Else
                    bAdmin = False
                    If TQuyenTruyCap.Rows(0).Item("Them").ToString() = "" Then
                        Them = False
                    Else
                        Them = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Them"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Sua").ToString() = "" Then
                        Sua = False
                    Else
                        Sua = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Sua"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Xoa").ToString() = "" Then
                        Xoa = False
                    Else
                        Xoa = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Xoa"))
                    End If
                    ''========== xet trang thai dang la khu A, B nếu cả A, B thi trang thai là toan cong ty
                    If TQuyenTruyCap.Rows(0).Item("KHUA").ToString() = "" Then
                        KHUA = False
                    Else
                        KHUA = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("KHUA"))
                    End If

                    If TQuyenTruyCap.Rows(0).Item("KHUB").ToString() = "" Then
                        KHUB = False
                    Else
                        KHUB = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("KHUB"))
                    End If
                    ''======== đưa về trạng thái toàn công ty ======
                    If KHUA = True And KHUB = True Then
                        bTCT = True
                    Else
                        bTCT = False
                    End If
                    QuyenTruyCap()
                End If
            Else
                Them = False
                Sua = False
                Xoa = False
                bChuyenDuLieu = False
            End If

        Else
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.trangthai = 1
        Themmoi()
        Me.btSua.Enabled = False
        LoadDulieu()
    End Sub
    Private Sub LoadThangNam()
        Dim i As Integer = 12
        While (i > 0)
            If i <= 9 Then
                Me.dtpXemNgThNam.Items.Add("0" & i & "-" & Year(Now().ToString()))
            Else
                Me.dtpXemNgThNam.Items.Add(i & "-" & Year(Now().ToString()))
            End If
            i = i - 1
        End While
       
    End Sub
    Public Function NgayHT() As String
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim tableNgay As DataTable
        Dim ngay As Date
        Dim ngaynhaptrocap As String
        obj.ChonBang = 30
        tableNgay = Me.b.LoadDS(obj)
        If tableNgay.Rows.Count > 0 Then
            NgayHienTai = tableNgay.Rows(0).Item("NGAY").ToString()
            'dtpNgaynhap.Value = NgayHienTai
            'ngay = dtpNgaynhap.Value
            'obj.NgayNhapTC = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
            'obj.MATHANG = NgayHienTai.Substring(3, 7)

            'Me.dtpNgaynhap.Text = ngay.ToString("dd-MM-yyyy")
            'Me.dtpNgaySanh.Text = ngay.ToString("dd-MM-yyyy")
            ngaynhaptrocap = NgayHienTai
        Else
            'Me.NgayHienTai = Now().ToString("dd-MM-yyyy")
            'dtpNgaynhap.Value = Me.NgayHienTai
            'ngay = dtpNgaynhap.Value
            'obj.NgayNhapTC = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
            'Me.dtpNgaynhap.Text = NgayHienTai.ToString("dd-MM-yyyy")
            'Me.dtpNgaySanh.Text = NgayHienTai.ToString("dd-MM-yyyy")
            'obj.MATHANG = NgayHienTai.Substring(3, 7)
            ngaynhaptrocap = Now().Date.ToString("dd-MM-yyyy")
        End If

        Return ngaynhaptrocap
    End Function
    Private Function LayNgayCuoiThang(ByVal sT_Ma As String) As String
        Dim tableNgayCuoiThang As DataTable
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim ngay As String = ""
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@T_MA", sT_Ma))
        tableNgayCuoiThang = Me.b.LoadThuTuc("SP_LAYNGAYCUOITHANG_S", listpar).Tables(0)
        Try
            If tableNgayCuoiThang.Rows.Count > 0 Then
                ngay = tableNgayCuoiThang.Rows(0).Item("NGAYCUOITHANG").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Không thể lấy ngày cuối của tháng." + ex.Message(), "Thông báo", MessageBoxButtons.OK)
        End Try
        Return ngay
    End Function
    Private Sub ClearThongTin()
        Me.txtMaNV.Clear()
        Me.txtHoTen.Clear()
        Me.txtDonvi.Clear()
        Me.dtpNgayKyHD.Clear()

        Me.dtpNgaySanh.Value = Now()
        Me.dtpNgayHETHAN.Value = Now().Date.AddYears(6)
        Me.txtMaNV.Focus()
        Me.lblSoCon.Text = "Số con:"
        Me.lblSothang.Text = ""
        Me.chkTrungNgay.Checked = False
        Me.txtSCTrungNgay.Value = 0
    End Sub
    Private Sub Themmoi()
        Me.dtpNgaySanh.Enabled = True
        Me.chkTrungNgay.Enabled = True
        Me.txtSCTrungNgay.Enabled = True
        Me.txtGhichuSD.Enabled = True
        Me.txtMaNV.Enabled = True
        Me.txtMaNV.Focus()
        Me.trangthai = 1
    End Sub
    Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
    Private Sub LoadCombo()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_ConDuoi6Tuoi
        ''load combo Xuong
        obj.ChonBang = 13
        Me.cboXuong.DataSource = Me.b.LoadDS(obj)
        Tabletemp = Me.b.LoadDS(obj)

        Tabletemp.Rows.Add("A", "Khu A")
        Tabletemp.Rows.Add("B", "Khu B")
        Tabletemp.Rows.Add("TCT", "全部公司 Toàn công ty")
        Me.cboXuong.DataSource = Tabletemp
        Me.cboXuong.SelectedIndex = 0

        Me.cboXuong.ValueMember() = "X_MA_"
        Me.cboXuong.DisplayMember() = "X_TEN"
        Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 13
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)

        Tabletemp = Me.b.LoadDS(obj)

        Tabletemp.Rows.Add("A", "Khu A")
        Tabletemp.Rows.Add("B", "Khu B")
        Tabletemp.Rows.Add("TCT", "全部公司 Toàn công ty")
        Me.cbXuong.DataSource = Tabletemp
        Me.cbXuong.SelectedIndex = 0

        Me.cbXuong.ValueMember() = "X_MA_"
        Me.cbXuong.DisplayMember() = "X_TEN"
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub
    'Public Sub New()
    '    AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmNuoiConDuoi6Tuoi_Load)
    '    Me.InitializeComponent()
    'End Sub
    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Public Sub QuyenTruyCap()
        If Them Then
            Me.btnThem.Visible = True
        Else
            Me.btnThem.Visible = False
        End If

        If Sua Then
            Me.btSua.Visible = True
        Else
            Me.btSua.Visible = False
        End If
      
        If Them And Sua And Xoa Then
            bChuyenDuLieu = True
        Else
            bChuyenDuLieu = False
            Me.btLuu.Visible = False
            Me.btnChuyenTroCap.Visible = False
        End If
        ''=========== tự check khi biết quyền ở khu nào ==================''
        If bTCT = True Then
            Me.radTCT_Tab0.Checked = True ''nút toàn công ty bên tab nhập liệu
            Me.radTCT_Tab1.Checked = True ''nút toàn công ty bên tab chuyển dữ liệu
        Else
            If KHUA = True And KHUB = False Then
                Me.radKhuA_Tab0.Checked = True ''quyền nhập khu A
                Me.radKhuA_Tab1.Checked = True ''quyền nhập khu A
            End If
            If KHUA = False And KHUB = True Then
                Me.radKhuB_Tab0.Checked = True ''quyền nhập khu B
                Me.radKhuB_Tab1.Checked = True ''quyền nhập khu B
            End If
            If KHUA = True And KHUB = True Then
                Me.radTCT_Tab0.Checked = True
                Me.radTCT_Tab1.Checked = True
            End If

            If KHUA = False And KHUB = False Then ''chưa cấp quyền hoặc đã cấp nhưng chỉ đc xem;sau này có phân quyền nút thì đổi lại chỗ này
                Me.radTCT_Tab0.Checked = True
                Me.radTCT_Tab1.Checked = True
            End If
        End If

       
    End Sub
    Public Sub LoadDulieu()
        Dim grid As New clsTformatGrid
        Dim Table1 As DataTable
        Dim thangnam As String
        Dim Table_LOC As DataTable
        Dim obj As New Obj_ConDuoi6Tuoi
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim dgrBC As Object = Me.dgrBC

        If Me.radTCT_Tab0.Checked Then
            obj.ChonKhu = "TCT"
        End If

        If Me.radKhuA_Tab0.Checked Then
            obj.ChonKhu = "A"
        End If

        If Me.radKhuB_Tab0.Checked Then
            obj.ChonKhu = "B"
        End If


        If Me.radXemThangNam.Checked Then
            If dtpXemNgThNam.Text = "" Then
                ''neu rong thi mac dinh la thang 01/2012
                obj.ThangNamTinhLuong = "01-2012"
            Else
                obj.ThangNamTinhLuong = dtpXemNgThNam.Text

            End If
            obj.ChonBang = 35
            Table1 = Me.b.LoadDS(obj)
            Me.XpCaption2.Text = " Danh sách trợ cấp đã nhập liệu tháng: " & obj.ThangNamTinhLuong & " theo " & obj.ChonKhu
        End If

        If Me.radTatca.Checked Then
            obj.ChonBang = 26
            Table1 = Me.b.LoadDS(obj)
            Me.XpCaption2.Text = " Toàn bộ danh sách đã nhập liệu " & " theo " & obj.ChonKhu
            ''==============================
        End If

        If Table1.Rows.Count > 0 Then
            Me.dgrBC.DataSource = Table1
            Me.Path = "/layout/NUOICONDUOI6TUOI_THANGTUOIload.xml"
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
            If (Me.dgrBC.Rows.Count > 0) Then
                Me.dgrBC.Rows.Item(0).Selected = True
                Me.dgrBC.Rows(0).Activated = True
            End If
        Else
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub
    Private Sub ThongKeDSTroCap(ByVal sThangNam As String, ByVal sXuong As String)
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim tblTroCap As New DataTable
        Dim objTC6T As New Obj_ConDuoi6Tuoi
        Dim dgrBC As Object = Me.dgrBC
        Dim grid As New clsTformatGrid

        If Me.radXemNgayHT.Checked Then
            objTC6T.Xemtruoc = 1
            objTC6T.Ngay_HienTai = CDate(Me.NgayHienTai.ToString()).Year.ToString() + "-" + CDate(Me.NgayHienTai.ToString()).Month.ToString() + "-" + CDate(Me.NgayHienTai.ToString()).Day.ToString()

            If Me.radChiTiet.Checked Then
                ''=========== danh sach chi tiet ==========='
                objTC6T.ChonBang = 32
                objTC6T.Xuong = sXuong
                tblTroCap = Me.b.LoadDS(objTC6T)
                Me.XpCaption2.Text = " Bảng chi tiết thống kê trợ cấp theo đến ngày: " & Me.NgayHienTai.ToString() & " của " & Me.cboXuong.Text & " không bao gồm nghỉ việc"
                Me.Path = "/layout/NUOICONDUOI6TUOI_ChiTiet.xml"
            ElseIf Me.radTong.Checked Then
                ''=========== danh sach tong ==========='
                Me.Path = "/layout/NUOICONDUOI6TUOI_Tong.xml"
                Dim listpar As New ArrayList(1)
                Select Case Me.cboXuong.Value
                    Case "TCT"
                        listpar.Add(New SqlParameter("@XUONG", sXuong))
                        tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_NGAYHIENTAI_S", listpar).Tables(0)
                        listpar.Clear()
                    Case "A"
                        tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_NGAYHIENTAI_KHUA_S").Tables(0)
                    Case "B"
                        tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_NGAYHIENTAI_KHUB_S").Tables(0)
                    Case Else
                        listpar.Add(New SqlParameter("@XUONG", sXuong))
                        tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_NGAYHIENTAI_S", listpar).Tables(0)
                        listpar.Clear()
                End Select
            End If

        ElseIf Me.radThangTroCap.Checked Then
            objTC6T.Xemtruoc = 0
            objTC6T.NgayCuoiThang = LayNgayCuoiThang(sThangNam)
            objTC6T.ThangNamTinhLuong = sThangNam
            If KiemTra_ThangDaChuyenDuLieu(sThangNam) = False And Me.radThangTroCap.Checked Then
                MessageBox.Show("Tháng này chưa chuyển dữ liệu trợ cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgrBC.DataSource = Nothing
                Exit Sub
            Else
                If Me.radChiTiet.Checked Then
                    ''=========== danh sach chi tiet ==========='
                    objTC6T.ChonBang = 32
                    objTC6T.Xuong = sXuong

                    tblTroCap = Me.b.LoadDS(objTC6T)
                    Me.XpCaption2.Text = " Bảng chi tiết thống kê trợ cấp theo tháng lương: " & sThangNam & " của " & Me.cboXuong.Text
                    Me.Path = "/layout/NUOICONDUOI6TUOI_ChiTiet.xml"

                ElseIf Me.radTong.Checked Then
                    ''=========== danh sach tong ==========='
                    Me.XpCaption2.Text = " Bảng chi tiết thống kê tổng trợ cấp theo tháng lương: " & sThangNam & " của " & Me.cboXuong.Text

                    Me.Path = "/layout/NUOICONDUOI6TUOI_Tong.xml"
                    Dim listpar As New ArrayList(2)

                    Select Case Me.cboXuong.Value
                        Case "TCT"
                            listpar.Add(New SqlParameter("@T_MA", sThangNam))
                            listpar.Add(New SqlParameter("@XUONG", sXuong))
                            tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_S", listpar).Tables(0)
                            listpar.Clear()
                        Case "A"
                            listpar.Add(New SqlParameter("@T_MA", sThangNam))
                            tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_KHUA_S", listpar).Tables(0)
                        Case "B"
                            listpar.Add(New SqlParameter("@T_MA", sThangNam))
                            tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_KHUB_S", listpar).Tables(0)
                        Case Else
                            listpar.Add(New SqlParameter("@T_MA", sThangNam))
                            listpar.Add(New SqlParameter("@XUONG", sXuong))
                            tblTroCap = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOITHANG_TONGDONVI_S", listpar).Tables(0)

                    End Select

                End If
            End If
        End If

        If tblTroCap.Rows.Count <= 0 OrElse tblTroCap Is Nothing Then
        Else
            Me.dgrBC.DataSource = tblTroCap
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        End If
    End Sub
    Private Sub bntLoc_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntLoc.Activate
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
                LoadDulieu()
            Case 1
                ''chuyen du lieu
            Case 2
                ''thống kê trợ cấp đã chuyển ''
                If Me.dtpchitietThang.Text = "" Or Me.dtpchitietThang.Value = Nothing Then
                    MessageBox.Show("Vui lòng chọn tháng để xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Me.cboXuong.Text = "" Or Me.cboXuong.Value = Nothing Then
                        MessageBox.Show("Vui lòng chọn xưởng để xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ThongKeDSTroCap(dtpchitietThang.Text.ToString(), cboXuong.Value)
                    End If

                End If

            Case 3
        End Select

    End Sub
   
    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
                Me.ChonDong()
                Me.HieuChinh()
                'If Me.btSua.Enabled = False Or Me.btnThem.Enabled = False Then
                '    Me.btSua.Enabled = True
                Me.btnThem.Enabled = True
                'End If
            Case 1
                Me.ChonDong()
                Me.HieuChinh()
            Case 2

        End Select
    End Sub
    Private Function KiemTra_ThangDaChuyenDuLieu(ByVal sThangNam As String) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim tbl As New DataTable
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@T_MA", sThangNam))
        If Me.radKhuA_Tab1.Checked Then
            tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_THANG_DACHUYENDULIEU_KHUA_S", listpar).Tables(0)
        End If
        If Me.radKhuB_Tab1.Checked Then
            tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_THANG_DACHUYENDULIEU_KHUB_S", listpar).Tables(0)
        End If
        If Me.radTCT_Tab1.Checked Then
            tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_THANG_DACHUYENDULIEU_TCT_S", listpar).Tables(0)
        End If
        listpar.Clear()
        If Convert.ToInt32(tbl.Rows(0).Item("DACHUYEN")) > 0 Then
            Return True
        Else
            If tbl Is Nothing Then
                Return False
            Else
                Return False
            End If
        End If
    End Function
    Private Function KhoasoThangDaChuyenDuLieu(ByVal sThangNam As String) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim tblTCT As New DataTable
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@T_MA", sThangNam))
        tblTCT = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_THANG_DACHUYENDULIEU_TCT_S", listpar).Tables(0)
        listpar.Clear()
        If Convert.ToInt32(tblTCT.Rows(0).Item("DACHUYEN")) > 0 Then
            Return True
        Else
            If tblTCT Is Nothing Then
                Return False
            Else
                Return False
            End If
        End If
    End Function
    Private Function KiemTra_SoTheDaChuyenDuLieu(ByVal sNV_Ma As String, ByVal dNgaysanh As Date) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim tbl As DataTable
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma))
        listpar.Add(New SqlParameter("@NGAYSANHCON", dNgaysanh))
        tbl = Me.b.LoadThuTuc("SP_IT_NUOICONDUOI6TUOI_SOTHE_DACHUYENDULIEU_S", listpar).Tables(0)
        listpar.Clear()
        If Convert.ToBoolean(tbl.Rows(0).Item("SOTHEDACHUYEN")) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        Dim obj As New Obj_ConDuoi6Tuoi
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim tableNV As DataTable
             Select Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
                Case 0
                    Select Case ColA
                        Case "2"

                            ''kiem tra xoa nguoi thoi viec khi changetab
                            obj.ChonBang = 3
                            Me.b = New ClsB_ConDuoi6Tuoi
                            obj.NV_MA = activeCell.Row.Cells.Item("MANV").Text
                            obj.NgaySanh = activeCell.Row.Cells.Item("NGAYSANHCON").Value
                            tableNV = Me.b.LoadDS(obj)
                            ''======== xet phan quyen duoc xoa =========''
                            If Them And Xoa And Sua Then


                                If tableNV.Rows.Count > 0 Then
                                    ''========== THÁNG HIỆN TẠI ĐÃ CHUYỂN DỮ LIỆU CHƯA =============''
                                    If KiemTra_ThangDaChuyenDuLieu(NgayHienTai.Substring(3, 7)) = False Then
                                        If KiemTra_SoTheDaChuyenDuLieu(obj.NV_MA, obj.NgaySanh) Then
                                            MessageBox.Show("Số thẻ này đã chuyển dữ liệu trợ cấp ở các tháng trước, bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            ClearThongTin()
                                            Themmoi()
                                            Exit Sub
                                        Else
                                            If MessageBox.Show("Bạn có muốn xóa nhân viên " & obj.NV_MA & " và ngày sanh:" & obj.NgaySanh & ChrW(10) & ChrW(13) & "  khỏi danh sách trợ cấp không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                                Me.b.DeleteInfo(obj)
                                                obj.Get_HanhDong = 3
                                                ThaoTac_BackUp1()
                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("Tháng này đã chuyển dữ liệu, bạn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        ClearThongTin()
                                        Themmoi()
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Không thể xóa số thẻ đã thôi việc hoặc không tồn tại trong hồ sơ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ClearThongTin()
                                    Themmoi()
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Bạn không có quyền xóa trong chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            LoadDulieu()
                            ClearThongTin()
                            Themmoi()
                    End Select
                Case 1
                
                Case 2
            End Select


        End If
    End Sub
    Private Sub ThaoTac_BackUp1()
        Dim i As Integer = 0
        'obj.Setnull()
        Me.b = New ClsB_ConDuoi6Tuoi
        obj.Get_Now = Me.NgayHienTai
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@ThoiDiem", Now()))
        listpar.Add(New SqlParameter("@HanhDong", d.obj_D.TruyVan))
        listpar.Add(New SqlParameter("@GiaTri", d.obj_D.Get_HanhDong.ToString()))
        listpar.Add(New SqlParameter("@Ten_DangNhap", d.obj_D.TenDangNhap))
        Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
        listpar.Clear()
    End Sub

    Private Sub txtMaNV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaNV.ValueChanged
        Dim obj As New Obj_ConDuoi6Tuoi
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
               TinhTuoiCon()
            Case 1
            Case 2
        End Select
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMaNV.Text = activeRow.Cells.Item("MANV").Value.ToString
                Me.txtMaNV.Enabled = False
                Me.txtHoTen.Text = activeRow.Cells.Item("NV_TEN").Value.ToString
                Me.dtpNgayKyHD.Text = activeRow.Cells.Item("HD_NGAYKY").Value.ToString
                Me.dtpNgaySanh.Text = activeRow.Cells.Item("NGAYSANHCON").Value.ToString
                Me.dtpNgayHETHAN.Text = activeRow.Cells.Item("NGAYHETHAN").Value.ToString
                Me.txtDonvi.Text = activeRow.Cells.Item("DV_MA").Value.ToString
                If IsDBNull(activeRow.Cells.Item("CHK_SANHDOI").Value) Then
                    Me.chkTrungNgay.Checked = False
                ElseIf Convert.ToBoolean(activeRow.Cells.Item("CHK_SANHDOI").Value) Then
                    Me.chkTrungNgay.Checked = True
                Else
                    Me.chkTrungNgay.Checked = False
                End If
                Me.txtSCTrungNgay.Text = activeRow.Cells.Item("SOCON").Value.ToString
                Me.txtGhichuSD.Text = activeRow.Cells.Item("GHICHU").Value.ToString
                ''=============
                Me.dtpNgaySanh.Enabled = False
                Me.chkTrungNgay.Enabled = False
                Me.txtSCTrungNgay.Enabled = False
                Me.txtGhichuSD.Enabled = False
            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Function KiemTraKyHopDong(ByVal sNV_Ma As String) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim objNC6T As New Obj_ConDuoi6Tuoi
        Dim tblNuoiConD6T As DataTable
        objNC6T.ChonBang = 11
        objNC6T.NV_MA = sNV_Ma
        tblNuoiConD6T = Me.b.LoadDS(objNC6T)
        If tblNuoiConD6T.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function KiemTraThoiViec(ByVal sNV_Ma As String) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim objNC6T As New Obj_ConDuoi6Tuoi
        Dim tblNuoiConD6T As DataTable
        objNC6T.ChonBang = 3
        objNC6T.NV_MA = sNV_Ma
        tblNuoiConD6T = Me.b.LoadDS(objNC6T)
        If tblNuoiConD6T.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function KiemTraKhongTrong() As Boolean
        If Me.dtpNgaySanh.Text = Nothing Or Me.dtpNgaySanh.Text.Trim() = "" Or Me.dtpNgaySanh.Value Is Nothing Or IsDate(Me.dtpNgaySanh.Value) = False Then
            MsgBox("Chưa chọn ngày sanh em bé!")
            Return False
            Exit Function
        End If
        If Me.txtMaNV.Text = Nothing Or Me.txtMaNV.Text = "" Then
            MsgBox("Bạn hãy nhập số thẻ!")
            Return False
            Exit Function
        End If
        ''============ không bắt buộc nhập ghi chú =======''


        Return True
    End Function
    Public Sub Tinh_tudong()
        If Me.dtpNgaySanh.Value.ToString() = "" Or Me.txtMaNV.Text.ToString() = "" Then
        Else
            ''khi thay doi ngay sanh thi tu dong tinh ngay het han tro cap
            Dim NgayS As Date = Me.dtpNgaySanh.Value.ToString
            Dim NgayS_convert As String = NgayS.Year.ToString() + "/" + NgayS.Month.ToString() + "/" + NgayS.Day.ToString()
            obj.NgaySanh = NgayS_convert
            ''tinh het han tro cap=ngaysanh + 11 thang + 5 nam
            Dim ngayhethan As Date
            'ngayhethan = NgayS.AddMonths(12).ToString()
            ngayhethan = NgayS.AddYears(6).ToString()
            Dim ngayhethantcap As String = ngayhethan.Year.ToString() + "/" + ngayhethan.Month.ToString() + "/" + ngayhethan.Day.ToString()
            obj.NgayHetHan = ngayhethantcap
            dtpNgayHETHAN.Text = ngayhethan
        End If
    End Sub
    Private Sub TinhTuoiCon()
        Dim obj As New Obj_ConDuoi6Tuoi
        Dim Ngay As Date
        If Me.dtpNgaySanh.Text.ToString() = "" Or Me.txtMaNV.Text.ToString() = "" Or Len(txtMaNV.Text.Trim()) <> 6 Then
        Else
            ''tim trong bang Nhân viên

            obj.ChonBang = 3
            Dim Temp, Temp1, Temp2, Temp3, Temp4 As New DataTable

            Temp = Nothing
            Temp1 = Nothing
            Temp2 = Nothing
            Temp3 = Nothing

            Me.b = New ClsB_ConDuoi6Tuoi

            obj.NV_MA = Me.txtMaNV.Text
            Temp = Me.b.LoadDS(obj)

            Dim flag As Boolean
            flag = False  ''mac dinh la flag=false

            If Temp.Rows.Count > 0 Then    ''tim co trong nhan vien la hop le
                flag = True
            Else
                flag = False
                ClearThongTin()
                MessageBox.Show("Số thẻ này không tồn tại trong Hồ Sơ Nhân Viên hoặc đã thôi việc, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Me.btLuu.Enabled = False
                Exit Sub
            End If
            If flag = True Then  ''hien thong tin nhan vien trong bang nhan vien neu tim thay
                Me.txtHoTen.Text = Temp.Rows(0).Item("TEN").ToString
                Me.dtpNgayKyHD.Value = Temp.Rows(0).Item("NGAYKYHD").ToString
                Me.txtDonvi.Text = Temp.Rows(0).Item("DONVI").ToString
                obj.DV_MA = Temp.Rows(0).Item("MADV").ToString
                ''========== kiểm tra giới tính nữ ======''
                'If Convert.ToBoolean(Temp.Rows(0).Item("NV_GIOITINH")) Then
                '    MessageBox.Show("Số thẻ là nữ mới được nhập trợ cấp!", "Thông tin nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    ClearThongTin()
                '    Exit Sub
                'End If
                ''tìm trong bang IT_ConDuoi6tuoi, nếu có hiện ngày max
                obj.ChonBang = 6
                Me.b = New ClsB_ConDuoi6Tuoi
                Temp1 = Me.b.LoadDS(obj)
                If Temp1.Rows.Count > 0 Then
                    ''========= hiển thị ngày sanh con max ====''
                    Me.btLuu.Enabled = True
                    Me.btSua.Enabled = True
                    obj.ChonBang = 4
                    Me.b = New ClsB_ConDuoi6Tuoi
                    Temp2 = Me.b.LoadDS(obj)
                    If Temp2.Rows.Count > 0 Then
                        Me.dtpNgaySanh.Value = Temp2.Rows(0).Item("NGAYSANHCON").ToString
                        Me.dtpNgayHETHAN.Value = Temp2.Rows(0).Item("NGAYHETHAN").ToString
                        ''========== tính ngày sanh max ->ngày hiện tại
                        obj.ChonBang = 7
                        obj.NgayNhapTC = CDate(NgayHienTai).Year.ToString() + "/" + CDate(NgayHienTai).Month.ToString() + "/" + CDate(NgayHienTai).Day.ToString()
                        Me.b = New ClsB_ConDuoi6Tuoi
                        Temp3 = Me.b.LoadDS(obj)
                        If Temp3.Rows.Count > 0 Then
                            obj.SoThang = Temp3.Rows(0).Item("SOTHANG").ToString
                            If (obj.SoThang <= 0 Or Temp3.Rows.Count <= 0) Then
                                lblSothang.Visible = False
                                Me.lblSothang.Text = ""
                                Exit Sub
                            Else
                                lblSothang.Enabled = True
                                Me.lblSothang.Text = "Số tháng theo ngày sanh " & String.Format("{0:d}", Me.dtpNgaySanh.Value) & " tính đến: " & NgayHienTai & " là :" & obj.SoThang & " tháng =(" & Temp3.Rows(0).Item("TUOI").ToString() & " Tuổi ," & Temp3.Rows(0).Item("THANGTUOI").ToString() & " tháng tuổi)"
                            End If
                            If Me.lblSothang.Text = "72" Or obj.SoThang >= 72 Then
                                Me.radDu6Tuoi.Checked = True
                                Me.btLuu.Enabled = False
                            Else
                                Me.radChuadu6Tuoi.Checked = True
                                Me.btLuu.Enabled = True
                            End If
                        End If
                    End If
                    obj.ChonBang = 29
                    Me.b = New ClsB_ConDuoi6Tuoi
                    Temp4 = Me.b.LoadDS(obj)
                    If Temp4.Rows.Count > 0 Then
                        Me.lblSoCon.Text = "Số con: " & Temp4.Rows(0).Item("SOCON").ToString()
                    Else
                        Me.lblSoCon.Text = "Số con:0 "
                    End If
                Else
                    ''========== tính ngày sanh mới ->ngày hiện tại
                    Me.lblSoCon.Text = "Số con:0 "
                    If Not (Me.dtpNgaySanh.Value Is Nothing) Then
                        obj.ChonBang = 5
                        obj.NgaySanh = Me.dtpNgaySanh.Value
                        obj.NgayNhapTC = CDate(NgayHienTai).Year.ToString() + "/" + CDate(NgayHienTai).Month.ToString() + "/" + CDate(NgayHienTai).Day.ToString()
                        Me.b = New ClsB_ConDuoi6Tuoi
                        Temp3 = Me.b.LoadDS(obj)
                        If Temp3.Rows.Count > 0 Then
                            obj.SoThang = Temp3.Rows(0).Item("SOTHANG").ToString
                            If (obj.SoThang <= 0 Or Temp3.Rows.Count <= 0) Then
                                lblSothang.Visible = False
                                Me.lblSothang.Text = ""
                            Else
                                lblSothang.Enabled = True
                                Me.lblSothang.Text = "Số tháng theo ngày sanh " & String.Format("{0:d}", Me.dtpNgaySanh.Value) & " tính đến: " & NgayHienTai & " là :" & obj.SoThang & " tháng =(" & Temp3.Rows(0).Item("TUOI").ToString() & " Tuổi ," & Temp3.Rows(0).Item("THANGTUOI").ToString() & " tháng tuổi)"
                            End If
                            If Me.lblSothang.Text = "72" Or obj.SoThang >= 72 Then
                                Me.radDu6Tuoi.Checked = True
                                Me.btLuu.Enabled = False
                            Else
                                Me.radChuadu6Tuoi.Checked = True
                                Me.btLuu.Enabled = True
                            End If
                        End If
                    End If
                End If
                Hien_dieukhien()
            End If

        End If
    End Sub
    Private Function KiemtraTrangThaiSanhDoi() As Boolean
        If Me.chkTrungNgay.Checked Then
            If Me.txtSCTrungNgay.Value <= 1 Then
                MessageBox.Show("Bạn phải nhập số > 1 (từ 2 con trở lên)", "Nhắc nhở")
                txtSCTrungNgay.Focus()
                Return False
                Exit Function
            End If
            If Me.txtSCTrungNgay.Value >= 5 Then
                If (MessageBox.Show(("Số con trùng ngày sanh chỉ từ 2-4,bạn muốn thêm " & ChrW(10) & ChrW(13) & " số con >4 ? "), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Return True
                Else
                    Return False
                    Exit Function
                End If
            Else
                Return True
            End If
            'If Me.txtGhichuSD.Text = "" Then
            '    MessageBox.Show("Bạn phải chú thích là sanh mấy con và nhập vào tháng nào", "Nhắc nhở:")
            '    Return False
            '    Exit Function
            'Else
            '    Return True
            'End If
        Else
            If Me.txtSCTrungNgay.Value >= 2 AndAlso Me.chkTrungNgay.Checked = False Then
                MessageBox.Show("Vui lòng check vào ô trùng ngày sanh ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.chkTrungNgay.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Private Sub Hien_dieukhien()
        Me.radChuadu6Tuoi.Visible = True
        Me.radDu6Tuoi.Visible = True
        Me.lblSothang.Visible = True
    End Sub
    Private Sub Luu()
        ''====== kiểm tra khóa chính ======''
        Dim tblNuoiConD6T As DataTable
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim objNC6T As New Obj_ConDuoi6Tuoi
        objNC6T.NV_MA = Me.txtMaNV.Text.Trim()
        objNC6T.NgaySanh = Me.dtpNgaySanh.Value
        objNC6T.ChonBang = 1
        tblNuoiConD6T = Me.b.LoadDS(objNC6T)
        If tblNuoiConD6T.Rows.Count > 0 Then
            If trangthai = 1 Then
                If CInt(tblNuoiConD6T.Rows(0).Item("KT")) = 1 Then
                    MessageBox.Show("Ngày sinh con của số thẻ này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpNgaySanh.Focus()
                    Exit Sub
                Else
                    ''=========== thêm mới ========''

                    'Andrew-Sửa lại Chưa ký HĐ vẫn được hưởng trợ cấp này
                    'If KiemTraKyHopDong(Me.txtMaNV.Text.Trim()) = False Then
                    '    MessageBox.Show("Số thẻ này chưa ký hợp đồng lao động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    ClearThongTin()
                    '    Themmoi()
                    '    Exit Sub
                    'End If
                    If KiemTraThoiViec(Me.txtMaNV.Text.Trim()) = False Then
                        MessageBox.Show("Số thẻ này đã thôi việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ClearThongTin()
                        Themmoi()
                        Exit Sub
                    End If
                    If KiemtraTrangThaiSanhDoi() = False Then
                        Me.txtSCTrungNgay.Focus()
                        Exit Sub
                    End If
                    If Me.radDu6Tuoi.Checked Then
                        If tuoi = 6 And thangtuoi = 1 Then
                            Dim thangtruoc As Date = DateAdd(DateInterval.Month, -1, CDate(Me.NgayHienTai))
                            MessageBox.Show("Con đủ 6 tuổi tính đến ngày:" & Me.NgayHienTai & " bạn không thể thêm." & ChrW(10) & ChrW(13) & ". Nếu bạn muốn thêm để tính lương tháng:" & thangtruoc.Month & "/" & thangtruoc.Year & " vui lòng liên hệ IT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show("Con đủ 6 tuổi tính đến ngày:" & Me.NgayHienTai & " bạn không thể thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Exit Sub
                    End If
                    If (MessageBox.Show(("Số thẻ: " & Me.txtMaNV.Text & " ngày sanh:" & String.Format("{0:d}", dtpNgaySanh.Value) & Chr(10) & ChrW(13) & " chưa có.Bạn có muốn thêm thông tin trợ cấp cho số thẻ này?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                        objNC6T.NgayHetHan = Me.dtpNgayHETHAN.Value
                        objNC6T.ChkSanhDoi = Me.chkTrungNgay.Checked
                        If Me.chkTrungNgay.Checked Then
                            objNC6T.SoconSD = Me.txtSCTrungNgay.Value
                            objNC6T.GhichuSD = Me.txtGhichuSD.Text
                        Else
                            objNC6T.SoconSD = 0
                            objNC6T.GhichuSD = ""
                        End If

                        ''============== mặc định khi nhập số con từ 2 trở lên tự check =========''

                        objNC6T.NgayNhap = Me.NgayHienTai

                        If Me.b.InsertInfo(objNC6T) = True Then
                            MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                           
                        Else
                            MessageBox.Show("Không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ClearThongTin()
                            Themmoi()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If trangthai = 0 Then
                If MessageBox.Show("Dữ liệu đã có, bạn có muốn sửa số thẻ: " & txtMaNV.Text & " ngày sanh:" & Me.dtpNgaySanh.Text & ChrW(10) & ChrW(13) & " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    Me.dtpNgaySanh.Enabled = False
                    Me.txtSCTrungNgay.Enabled = True
                    Me.chkTrungNgay.Enabled = True
                    Me.txtGhichuSD.Enabled = True
                    ''=========== sửa ========''
                    objNC6T.ChkSanhDoi = Me.chkTrungNgay.Checked
                    objNC6T.SoconSD = Me.txtSCTrungNgay.Value
                    objNC6T.GhichuSD = Me.txtGhichuSD.Text
                    If KiemtraTrangThaiSanhDoi() = False Then
                        Me.txtSCTrungNgay.Focus()
                        Exit Sub
                    End If
                    If Me.b.UpdateInfo(objNC6T) = True Then
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Không thể thêm được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
            LoadDulieu()
            ClearThongTin()
            Themmoi()
        Else
        End If
    End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        ClearThongTin()
        trangthai = 1
        Tinh_tudong()
        Themmoi()
    End Sub
    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        trangthai = 0
        Me.btnThem.Enabled = False
        HieuChinh()
        Me.chkTrungNgay.Enabled = True
        Me.txtSCTrungNgay.Enabled = True
        Me.txtGhichuSD.Enabled = True
    End Sub
    Private Sub btLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuu.Activate
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
                If KiemTraKhongTrong() Then
                    Luu()
                End If
            Case 1
            Case 2
        End Select
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        '' Khoa cot
        Dim i As Integer
        For i = 0 To 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
            e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
        Next
        For i = 2 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
            e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
        Next
         Select Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0

                If Them And Sua And Xoa Then
                    e.Layout.Bands(0).Columns("2").CellAppearance.Image = 2
                Else
                    e.Layout.Bands(0).Columns("2").Hidden = True
                    e.Layout.Bands(0).Columns("2").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True

                End If
            Case 1
        End Select
    End Sub
    Private Sub dtpNgaySanh_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpNgaySanh.ValueChanged
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
                ''TinhTuoiCon()
                Dim tblThangTuoi, tblSoCon As DataTable
                If Not (Me.dtpNgaySanh.Value Is Nothing) And Me.NgayHienTai <> "" Then
                    Tinh_tudong()
                    obj.ChonBang = 5
                    obj.NgaySanh = Me.dtpNgaySanh.Value
                    obj.NgayNhapTC = CDate(NgayHienTai).Year.ToString() + "/" + CDate(NgayHienTai).Month.ToString() + "/" + CDate(NgayHienTai).Day.ToString()
                    Me.b = New ClsB_ConDuoi6Tuoi
                    tblThangTuoi = Me.b.LoadDS(obj)
                    If tblThangTuoi.Rows.Count > 0 Then
                        obj.SoThang = tblThangTuoi.Rows(0).Item("SOTHANG").ToString
                        If (obj.SoThang <= 0 Or tblThangTuoi.Rows.Count <= 0) Then
                            lblSothang.Visible = False
                            Me.lblSothang.Text = ""

                        Else
                            lblSothang.Enabled = True
                            Me.lblSothang.Text = "Số tháng theo ngày sanh " & String.Format("{0:d}", Me.dtpNgaySanh.Value) & " tính đến: " & NgayHienTai & " là :" & obj.SoThang & " tháng =(" & tblThangTuoi.Rows(0).Item("TUOI").ToString() & " Tuổi ," & tblThangTuoi.Rows(0).Item("THANGTUOI").ToString() & " tháng tuổi)"
                        End If
                        If Me.lblSothang.Text = "72" Or obj.SoThang >= 72 Then
                            Me.radDu6Tuoi.Checked = True
                            Me.tuoi = CInt(tblThangTuoi.Rows(0).Item("TUOI").ToString())
                            Me.thangtuoi = CInt(tblThangTuoi.Rows(0).Item("THANGTUOI").ToString())
                            Me.btLuu.Enabled = False
                        Else
                            Me.radChuadu6Tuoi.Checked = True
                            Me.btLuu.Enabled = True
                        End If
                    End If
                    Hien_dieukhien()
                End If
                If (Me.txtMaNV.Text <> "" And Len(Me.txtMaNV.Text.Trim()) = 6) Then
                    obj.ChonBang = 29
                    obj.NV_MA = Me.txtMaNV.Text.Trim()
                    Me.b = New ClsB_ConDuoi6Tuoi
                    tblSoCon = Me.b.LoadDS(obj)
                    If tblSoCon.Rows.Count > 0 Then
                        Me.lblSoCon.Text = "Số con: " & tblSoCon.Rows(0).Item("SOCON").ToString()
                    Else
                        Me.lblSoCon.Text = "Số con: 0"
                    End If
                End If
            Case 1
            Case 2
        End Select
    End Sub
    Private Sub tabPhuNuNuoiCon6Tuoi_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabPhuNuNuoiCon6Tuoi.SelectedTabChanged
        Me.btnThem.Enabled = False
        Me.btSua.Enabled = False
        Me.btLuu.Enabled = False
        Me.btnChuyenTroCap.Enabled = False
        Me.btnLocTroCap.Enabled = False
        Me.bntLoc.Enabled = False
        'Me.btnXembaocao.Enabled = False
        Me.dgrBC.DataSource = Nothing
        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
                ClearThongTin()
                Themmoi()
                Me.bntLoc.Enabled = True
                If Me.txtMaNV.Text.Trim() <> "" And Not (Me.dtpNgaySanh.Value Is Nothing) Then
                    Me.btSua.Enabled = True
                    Me.btLuu.Enabled = True
                Else
                    Me.btSua.Enabled = False
                    Me.btLuu.Enabled = False
                End If
            Case 1
                Me.btnLocTroCap.Enabled = True
                If Me.dgrBC.DataSource Is Nothing Then
                Else
                    If bChuyenDuLieu Then
                        Me.btnChuyenTroCap.Enabled = True
                    Else
                        Me.btnChuyenTroCap.Visible = False ''======== khong co quyen
                    End If

                End If

            Case 2
                Me.bntLoc.Enabled = True
            Case 3

                'Me.btnXembaocao.Enabled = True
        End Select

    End Sub
    Private Sub radXemThangNam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXemThangNam.CheckedChanged
        If Me.radXemThangNam.Checked Then
            Me.dtpXemNgThNam.Enabled = True
        Else
            Me.dtpXemNgThNam.Enabled = False
        End If
    End Sub
    Private Sub chkTrungNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrungNgay.CheckedChanged
        If Me.chkTrungNgay.Checked Then
            Me.txtSCTrungNgay.Enabled = True
        Else
            Me.txtSCTrungNgay.Enabled = False
            Me.txtSCTrungNgay.Value = 0
        End If
    End Sub
    Private Function LocDuLieuTruocKhiChuyenTroCap(ByVal sThangTinhLuong As String) As DataTable
        Dim tbl As DataTable = Nothing
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim listpar As New ArrayList(1)
        Dim grid As New clsTformatGrid
        listpar.Add(New SqlParameter("@T_MA", sThangTinhLuong))
        If Me.radTCT_Tab1.Checked Then
            tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_S", listpar).Tables(0)
        End If

        If Me.radKhuA_Tab1.Checked Then
            ''------ không hiển thị đơn vị tạm trên lưới ---------
            If Me.chkTinhTam.Checked Then
                tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUA_TINHTAM_S", listpar).Tables(0)
            Else
                tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUA_S", listpar).Tables(0)
            End If

        End If

        If Me.radKhuB_Tab1.Checked Then
            If Me.chkTinhTam.Checked Then
                tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUB_TINHTAM_S", listpar).Tables(0)
            Else
                tbl = Me.b.LoadThuTuc("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUB_S", listpar).Tables(0)
            End If

        End If
        listpar.Clear()
        Return tbl
    End Function
    Private Function ChuyenTroCap(ByVal sThangTinhLuong As String) As Boolean
        Dim bcHUYEN As Boolean = False

        Dim listpar As New ArrayList(3)
        Dim listpar1 As New ArrayList(3)

        listpar.Add(New SqlParameter("@T_MA", sThangTinhLuong))
        listpar.Add(New SqlParameter("@NGUOITAO", sTenNguoiDung))
        listpar.Add(New SqlParameter("@NGAYTAO", Now()))



     
        If Me.radTCT_Tab1.Checked Then
            ''SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_I + ĐƠN VỊ TẠM
            bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_TCT_I", listpar)

        End If

        If Me.radKhuA_Tab1.Checked Then
            bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUA_I", listpar)

            ''---- CHUYEN TAM ---------
            listpar1.Clear()
            listpar1.Add(New SqlParameter("@T_MA", sThangTinhLuong))
            listpar1.Add(New SqlParameter("@NGUOITAO", sTenNguoiDung))
            listpar1.Add(New SqlParameter("@NGAYTAO", Now()))
            bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_DONVITAM_I", listpar1)

        End If

        If Me.radKhuB_Tab1.Checked Then
            bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_KHUB_I", listpar)
            listpar1.Clear()
            listpar1.Add(New SqlParameter("@T_MA", sThangTinhLuong))
            listpar1.Add(New SqlParameter("@NGUOITAO", sTenNguoiDung))
            listpar1.Add(New SqlParameter("@NGAYTAO", Now()))
            bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CHUYENDULIEU_DONVITAM_I", listpar1)
        End If
        Return bcHUYEN
    End Function
    Private Function CapNhatThaiSan_NghiViec(ByVal sThangTinhLuong As String) As Boolean
        Me.b = New ClsB_ConDuoi6Tuoi
        Dim listpar As New ArrayList(1)
        Dim bcHUYEN As Boolean = False
        listpar.Add(New SqlParameter("@T_MA", sThangTinhLuong))
        bcHUYEN = Me.b.ChuyenTroCap("SP_IT_QT_TROCAPCONDUOI6TUOI_CAPNHATTRANGTHAI_TS_NV", listpar)
        Return bcHUYEN
    End Function
    Private Sub btnChuyenTroCap_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChuyenTroCap.Activate
        Dim sThongbao As String = ""
        Dim sThongbao_ChuyenRoi As String = "Dữ liệu trợ cấp "
        Dim sThongbao_Thanhcong As String = "Đã chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString()

        If Me.radTCT_Tab1.Checked Then
            sThongbao_ChuyenRoi = sThongbao_ChuyenRoi + "toàn công ty"
            sThongbao_Thanhcong = sThongbao_Thanhcong + " toàn công ty xong."
        End If
        If Me.radKhuA_Tab1.Checked Then
            sThongbao_ChuyenRoi = sThongbao_ChuyenRoi + "khu A"
            sThongbao_Thanhcong = sThongbao_Thanhcong + " khu A xong."
        End If
        If Me.radKhuB_Tab1.Checked Then
            sThongbao_ChuyenRoi = sThongbao_ChuyenRoi + "khu B"
            sThongbao_Thanhcong = sThongbao_Thanhcong + " khu B xong."
        End If
        sThongbao_ChuyenRoi = sThongbao_ChuyenRoi + " tháng này đã chuyển rồi"

        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
            Case 1
                If Me.dgrBC.DataSource Is Nothing Then
                    MessageBox.Show("Vui lòng lọc dữ liệu trợ cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If KhoasoThangDaChuyenDuLieu(Me.dtpThangTroCap.Text) Then  ''---chưa chuyển dữ liệu hết 2 khu
                        MessageBox.Show("Dữ liệu trợ cấp khu A, khu B đã khóa, bạn không thể chuyển dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        If KiemTra_ThangDaChuyenDuLieu(Me.dtpThangTroCap.Text) = False Then  '' nếu chọn khu thì kiểm tra khu đó chuyển chưa ,ngược lại thì cho chuyển dữ liệu
                            Me.dgrBC.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
                            ''==============
                            If CDate(Me.dtpThangTroCap.Value).Month < 10 Then ' tu thang 1 den thang 9 thi them so 0 o truoc
                                thangnam = "0" + CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                            Else
                                thangnam = CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                            End If
                            ''====================== TACH KHU A, B==================
                            If Me.radTCT_Tab1.Checked Then
                                sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " toàn công ty không?"
                            End If

                            If Me.radKhuA_Tab1.Checked Then
                                sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " khu A không?"
                            End If

                            If Me.radKhuB_Tab1.Checked Then
                                sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " khu B không?"
                            End If

                            If MessageBox.Show(sThongbao, "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                If ChuyenTroCap(thangnam) = False Then
                                    MessageBox.Show("Không thể chuyển trợ cấp được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    LocDuLieuTruocKhiChuyenTroCap(thangnam)  ''===load lai danh sach truoc khi chuyen
                                Else
                                    CapNhatThaiSan_NghiViec(thangnam)
                                    MessageBox.Show(sThongbao_Thanhcong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                LocDuLieuTruocKhiChuyenTroCap(thangnam)
                                Dim grid As New clsTformatGrid
                                If LocDuLieuTruocKhiChuyenTroCap(thangnam).Rows.Count > 0 Then
                                    Me.dgrBC.DataSource = LocDuLieuTruocKhiChuyenTroCap(thangnam)
                                    Me.Path = "/layout/NUOICONDUOI6TUOI_THANGTUOICHUYENTROCAP.xml"
                                    Me.XpCaption2.Text = "Danh sách con nhỏ được hưởng trợ cấp tháng :" & Me.dtpThangTroCap.Text
                                    grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
                                    Me.btnChuyenTroCap.Enabled = True
                                End If
                            Else
                                Me.dgrBC.DataSource = Nothing
                            End If
                        Else
                            ''========= khu/TCT đã chọn đã chuyển rồi ; nếu đang chọn nút toàn công ty thì phải =========''
                            MessageBox.Show(sThongbao_ChuyenRoi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If


                    End If

                    'If KiemTra_ThangDaChuyenDuLieu(Me.dtpThangTroCap.Text) = False Then  '' nếu chọn khu thì kiểm tra khu đó chuyển chưa ,ngược lại thì cho chuyển dữ liệu

                    '    Me.dgrBC.DisplayLayout.Bands(0).ColumnFilters.ClearAllFilters()
                    '    ''==============
                    '    If CDate(Me.dtpThangTroCap.Value).Month < 10 Then
                    '        thangnam = "0" + CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                    '    Else
                    '        thangnam = CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                    '    End If
                    '    ''====================== TACH KHU A, B==================
                    '    If Me.radTCT_Tab1.Checked Then
                    '        sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " toàn công ty không?"
                    '    End If

                    '    If Me.radKhuA_Tab1.Checked Then
                    '        sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " khu A không?"
                    '    End If

                    '    If Me.radKhuB_Tab1.Checked Then
                    '        sThongbao = "Bạn muốn chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " khu B không?"
                    '    End If

                    '    If MessageBox.Show(sThongbao, "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    '        If ChuyenTroCap(thangnam) = False Then
                    '            MessageBox.Show("Không thể chuyển trợ cấp được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '            LocDuLieuTruocKhiChuyenTroCap(thangnam)  ''===load lai danh sach truoc khi chuyen
                    '        Else
                    '            CapNhatThaiSan_NghiViec(thangnam)
                    '            MessageBox.Show("Đã chuyển trợ cấp tháng: " & Me.dtpThangTroCap.Text.ToString() & " xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        End If
                    '        LocDuLieuTruocKhiChuyenTroCap(thangnam)
                    '    Else
                    '        Me.dgrBC.DataSource = Nothing
                    '    End If

                    'Else
                    '    MessageBox.Show("Tháng này đã chuyển trợ cấp rồi, bạn không thể chuyển lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Me.dgrBC.DataSource = Nothing
                    'End If
                    End If
            Case 2
        End Select

    End Sub
    Private Sub btnLocTroCap_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocTroCap.Activate
        Dim tblTroCapTruocKhiChuyen As DataTable
        Dim grid As New clsTformatGrid

        Select Case Me.tabPhuNuNuoiCon6Tuoi.SelectedTab.Index
            Case 0
            Case 1
                If Me.dtpThangTroCap.Value = Nothing Then
                    MessageBox.Show("Vui lòng chọn tháng trợ cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If CDate(Me.dtpThangTroCap.Value).Month < 10 Then
                        thangnam = "0" + CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                    Else
                        thangnam = CDate(Me.dtpThangTroCap.Value).Month.ToString() + "-" + CDate(Me.dtpThangTroCap.Value).Year.ToString()
                    End If
                    tblTroCapTruocKhiChuyen = LocDuLieuTruocKhiChuyenTroCap(thangnam)
                    If tblTroCapTruocKhiChuyen.Rows.Count > 0 Then
                        Me.dgrBC.DataSource = tblTroCapTruocKhiChuyen
                        Me.Path = "/layout/NUOICONDUOI6TUOI_THANGTUOICHUYENTROCAP.xml"
                        Me.XpCaption2.Text = "Danh sách con nhỏ được hưởng trợ cấp tháng :" & Me.dtpThangTroCap.Text
                        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
                        Me.btnChuyenTroCap.Enabled = True
                    End If
                End If
            Case 2
        End Select
    End Sub
    Private Sub bntXuatExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXuatExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            'Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub bntReportHetHan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntReportHetHan.Click
        Dim report As New FrmReport
        Me.ReportID = "CON6T1"
        Dim sKhu As String
        If Me.cbXuong.Value = Nothing Or Me.cbXuong.Text = "" Or Me.dtpNamHH.Value.ToString() = "" Or Me.dtpNamHH.Text = "" Then
            MessageBox.Show("Vui lòng chọn đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
        End If
        Select Case Me.cbXuong.Value
            Case "A"
                sKhu = "KHUA"
            Case "B"
                sKhu = "KHUB"
            Case "TCT"
                sKhu = "TCT"
            Case Else
                sKhu = cbXuong.Value
        End Select
        strArray = New String() {dtpNamHH.Text, sKhu}
        report.reportID = Me.ReportID
        report.para = strArray
        report.issysReport = True
        report.Refresh()
        report.Show()
    End Sub
    Private Sub bntXemdsHH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXemdsHH.Click
        Dim tblTroCap6THetHan As DataTable
        Dim grid As New clsTformatGrid
        Dim objTC6THH As New Obj_ConDuoi6Tuoi
    
        If Me.cbXuong.Value = Nothing Or Me.cbXuong.Text = "" Or Me.dtpNamHH.Value.ToString() = "" Or Me.dtpNamHH.Text = "" Then
            MessageBox.Show("Vui lòng chọn đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            objTC6THH.ChonBang = 20
            objTC6THH.Xuong = Me.cbXuong.Value
            objTC6THH.Nam = Me.dtpNamHH.Text

            tblTroCap6THetHan = Me.b.LoadDS(objTC6THH)
            If tblTroCap6THetHan.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tblTroCap6THetHan
                Me.Path = "/layout/NUOICONNHO6TUOI_HETHAN_DK.xml"
                Me.XpCaption2.Text = "Danh sách con nhỏ hết hạn trợ cấp năm :" & Me.dtpNamHH.Text
                grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
            End If
        End If
    End Sub
    Private Sub bntXemDSTCTV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXemDSTCTV.Click
        Dim tblTroCapDaNghiViec As DataTable
        Dim grid As New clsTformatGrid
        Dim objTC6TTV As New Obj_ConDuoi6Tuoi
        If Me.radTCTVNam.Checked Then
            If Me.dtpTCTVNam.Text = "" Or dtpTCTVNam.Value.ToString() = "" Then
                MessageBox.Show("Vui lòng năm để lọc dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                objTC6TTV.ChonBang = 18
                objTC6TTV.Nam = Me.dtpTCTVNam.Text
                Me.XpCaption2.Text = "Danh sách trợ cấp con nhỏ đã nghỉ việc năm: " & Me.dtpTCTVNam.Text
                tblTroCapDaNghiViec = Me.b.LoadDS(objTC6TTV)
            End If
        ElseIf Me.radXemdsTCTV.Checked Then
            objTC6TTV.ChonBang = 17
            Me.XpCaption2.Text = "Danh sách trợ cấp con nhỏ đã nghỉ việc "
            tblTroCapDaNghiViec = Me.b.LoadDS(objTC6TTV)
        End If
        Me.dgrBC.DataSource = tblTroCapDaNghiViec
        If tblTroCapDaNghiViec.Rows.Count > 0 Then
            Me.Path = "/layout/NUOICONNHO6TUOI_NGHIVIEC.xml"
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        End If
    End Sub
 
End Class