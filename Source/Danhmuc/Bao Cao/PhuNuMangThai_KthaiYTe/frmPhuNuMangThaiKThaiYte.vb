Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinToolTip
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
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Infragistics.Win
Public Class frmPhuNuMangThaiKThaiYte
    Dim obj As New Obj_PhuNuMangThai_KThaiYte
    Friend WithEvents b As ClsB_PhuNuMangThai_KThaiYte
    Dim oldRow As Integer = 0
    Public flagThem As Integer = 0
    Public flagTrangThaiTTT7 As Integer = 0
    Dim Path As String
    Public Flag_chonLuu As Boolean = False
    Dim i As Integer
    Friend WithEvents d As New ClsD_PhuNuMangThai_KThaiYte
    ''======== biến toàn cục: đổi kiểu ngày =======''
    Dim Ngaydauthangbd, Ngaycuoithangbd, Ngaycuoithangkt As String
    Dim ThangBD, ThangKT, NgaybdTT7, NgayktTT7 As Date
    Public tong_insert As Integer = 0
    Public tong_update As Integer = 0
    Public activeRow As UltraGridRow

    ''=========== xét phân quyền chức năng khi thêm sửa xóa form PNMT ===''
    Public Them As Boolean = False
    Public Sua As Boolean = False
    Public Xoa As Boolean = False
    Public bAdmin As Boolean = False
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmPhuNuMangThaiKThaiYte_Load)
        Me.InitializeComponent()
    End Sub
    Private Sub frmPhuNuMangThaiKThaiYte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAllCombo()
        Me.btSua.Enabled = False
        An_dieukhien()
        ClearTT()
        XetPhanQuyen()
        TrangThaiThem()
    End Sub
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
    Private Sub XetPhanQuyen()
        ''================= XET TRANG THAI PHAN QUYEN THEM XOA SUA ============
        ''Ngay sua: 11/10/2013,15/10/2013
        ''nguoi sua: Trân
        ''noi dung: phan quyen them xoa sua. quyen admin thi khong xet (nếu đc thêm xóa sửa thì đc xóa dl sảy thai trong TT7)

        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.ChonBang = 89
        Dim TQuyenTruyCap, TUser As New DataTable
        TUser = Me.b.LoadDS(obj)
        If TUser.Rows.Count > 0 Then
            ''======================== xet nguoi dung la admin thi bo qua ==============''
            If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Then
                Them = True
                Sua = True
                Xoa = True
                bAdmin = True
                ''gan mac dinh admin dc xem
                QuyenTruyCap()
            Else
                obj.ChonBang = 90
                TQuyenTruyCap = Me.b.LoadDS(obj)
                If TQuyenTruyCap.Rows.Count > 0 Then
                    ''======================== xet trang thai la admin thi bo qua ==============''
                    If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Then
                        Them = True
                        Sua = True
                        Xoa = True
                        bAdmin = True
                        ''gan mac dinh admin dc xem
                        QuyenTruyCap()
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
                        QuyenTruyCap()
                    End If
                Else
                    Them = False
                    Sua = False
                    Xoa = False
                End If
            End If
        Else
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub
    Public Sub QuyenTruyCap()
        If Them Then
            Me.btnThem.Visible = True
            Me.btnThem.Enabled = True
        Else
            Me.btnThem.Visible = False
        End If

        If Sua Then
            Me.btSua.Visible = True
            Me.btSua.Enabled = True

        Else
            Me.btSua.Visible = False
        End If
        ''========== nút xóa trên lưới =======''
        'If Xoa Then
        '    Me.btnXoa.Visible = True
        '    Me.btnXoa.Enabled = True
        'Else
        '    Me.btnXoa.Visible = False
        'End If
        ''==============an menu context (khong co menucontext) ================''
        If bAdmin Then
            Me.btCapNhat.Visible = True
        Else
            If Them And Sua And Xoa Then
                Me.btCapNhat.Visible = True
            Else
                Me.btCapNhat.Visible = False
            End If
        End If

    End Sub
    Public Sub LoadAllCombo()
        Dim Tabletemp As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        ''=========== tab 0: Nhập dữ liệu =========''
        obj.ChonBang = 1
        obj.Xuong = Me.cbXuong.Text.ToString()

        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Tabletemp = Me.b.LoadDS(obj)
        Tabletemp.Rows.Add("TCT", "全部公司 Toàn công ty")
        Me.cbXuong.DataSource = Tabletemp
        Me.cbXuong.SelectedIndex = 0

        Me.cbXuong.ValueMember() = "X_MA_"
        Me.cbXuong.DisplayMember() = "X_TEN"
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

    End Sub
    Public Sub An_dieukhien()
        Me.txtHoTen.Enabled = False
        Me.txtDonvi.Enabled = False
        Me.dtpLan1.Enabled = False
        Me.dtpLan2.Enabled = False
        Me.dtpLan3.Enabled = False
        Me.dtpLan4.Enabled = False
        Me.dtpLan5.Enabled = False
        Me.dtpNgaydusinh.Enabled = False
        Me.dtpNgayMangThai.Enabled = False
        Me.dtpNgayVao.Enabled = False
        Me.dtpNgayve15h30.Enabled = False
        Me.btSua.Enabled = False
        Me.btCapNhat.Enabled = False
        Me.txtLan.Enabled = False
    End Sub
    Public Sub Hien_dieukhien()
        Me.txtHoTen.Enabled = False
        Me.txtDonvi.Enabled = False
        Me.dtpLan1.Enabled = False
        Me.dtpLan2.Enabled = False
        Me.dtpLan3.Enabled = False
        Me.dtpLan4.Enabled = False
        Me.dtpLan5.Enabled = False
        Me.dtpNgaydusinh.Enabled = True
        Me.dtpNgayMangThai.Enabled = True
        Me.dtpNgayVao.Enabled = False
        Me.dtpNgayve15h30.Enabled = False
        Me.btCapNhat.Enabled = True
    End Sub
    Private Sub Kiemtra_SayThai()
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Kiemtra_SayThai_TextBox(ByVal sNV_Ma As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma.Trim()))
        Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub LoaiST_tuthang_denthang()
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_CacLanKThai()
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGAYKTHAI_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_CacLanKThaiTuThangDenThang()
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_LAYNGAYKTHAI_KMAX", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Tinh_CacLanKThai_Textbox(ByVal sNV_Ma As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma.Trim()))
        Me.b.GoiThuTuc("SP_LAYNGAYKTHAI_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub CapNhatSoLanMT_Textbox(ByVal sNV_Ma As String)
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)
        obj.NV_MA = Trim(sNV_Ma.ToString())
        listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
        Me.b.GoiThuTuc("SP_TINHSOLANMT", listpar)
        listpar.Clear()
    End Sub
    Private Sub CapNhatSoLanMT()
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        While i <= Me.dgrBC.Rows.Count - 1
            obj.NV_MA = Me.dgrBC.Rows(i).Cells("MA").Text
            listpar.Add(New SqlParameter("@NV_MA", obj.NV_MA))
            Me.b.GoiThuTuc("SP_TINHSOLANMT", listpar)
            listpar.Clear()
            i = i + 1
        End While
    End Sub
    Private Sub Kiemtra_SayThaiTextBox(ByVal sNV_Ma As String)
        Dim listpar As New ArrayList(1)
        obj.NV_MA = Trim(sNV_Ma)
        listpar.Add(New SqlParameter("@NV_MA", sNV_Ma.Trim()))
        Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub ThaoTac_BackUp()
        Dim i As Integer = 0
        obj.Get_Now = Now().ToString()
        Dim listpar As New ArrayList(4)
        listpar.Add(New SqlParameter("@ThoiDiem", obj.Get_Now))
        listpar.Add(New SqlParameter("@HanhDong", obj.TruyVan))
        listpar.Add(New SqlParameter("@GiaTri", obj.Get_HanhDong.ToString()))
        listpar.Add(New SqlParameter("@Ten_DangNhap", obj.TenDangNhap))
        Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
        listpar.Clear()
    End Sub
    Private Sub ThaoTac_BackUp1()
        Dim i As Integer = 0
        obj.Get_Now = Now().ToString()
        Dim listpar As New ArrayList(4)
        listpar.Add(New SqlParameter("@ThoiDiem", obj.Get_Now))
        listpar.Add(New SqlParameter("@HanhDong", obj.TruyVan))
        listpar.Add(New SqlParameter("@GiaTri", obj.Get_HanhDong.ToString()))
        listpar.Add(New SqlParameter("@Ten_DangNhap", obj.TenDangNhap))
        Me.b.GoiThuTuc("BACKUP_THAOTAC_THAITHANGT7", listpar)
        listpar.Clear()
    End Sub
    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                Me.ChonDong()
                flagThem = 0
                HieuChinh()
            Case 1
            Case 2
        End Select
    End Sub
    Public Sub HieuChinh()

        Try
            Dim grid As New clsTformatGrid

            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            TrangThaiSua()
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMaNV.Text = activeRow.Cells.Item("MA").Value.ToString
                Me.txtHoTen.Text = activeRow.Cells.Item("TEN").Value.ToString
                Me.dtpNgayVao.Text = activeRow.Cells.Item("NGAYVAO").Value.ToString
                Me.dtpNgayve15h30.Text = activeRow.Cells.Item("VE_15H30").Value.ToString
                Me.dtpNgayMangThai.Text = activeRow.Cells.Item("BDAU_MANGTHAI").Value.ToString
                Me.dtpNgaydusinh.Text = activeRow.Cells.Item("DUSINH").Value.ToString
                Me.txtDonvi.Text = activeRow.Cells.Item("DONVI").Value.ToString
                ''**********************CAC LAN KHAM THAI***********************
                For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    Select Case dgrBC.DisplayLayout.Bands(0).Columns(i).Key.ToString()
                        Case "LAN1"
                            If activeRow.Cells.Item("LAN1").Value.ToString = Nothing Then
                                Me.dtpLan1.Text = ""
                            Else
                                Me.dtpLan1.Text = activeRow.Cells.Item("LAN1").Value.ToString
                            End If
                        Case "LAN2"
                            If activeRow.Cells.Item("LAN2").Value.ToString = Nothing Then
                                Me.dtpLan2.Text = ""
                            Else
                                Me.dtpLan2.Text = activeRow.Cells.Item("LAN2").Value.ToString
                            End If
                        Case "LAN3"
                            If activeRow.Cells.Item("LAN3").Value.ToString = Nothing Then
                                Me.dtpLan3.Text = ""
                            Else
                                Me.dtpLan3.Text = activeRow.Cells.Item("LAN3").Value.ToString
                            End If

                        Case "LAN4"
                            If activeRow.Cells.Item("LAN4").Value.ToString = Nothing Then
                                Me.dtpLan4.Text = ""
                            Else
                                Me.dtpLan4.Text = activeRow.Cells.Item("LAN4").Value.ToString
                            End If

                        Case "LAN5"
                            If activeRow.Cells.Item("LAN5").Value.ToString = Nothing Then
                                Me.dtpLan5.Text = ""
                            Else
                                Me.dtpLan5.Text = activeRow.Cells.Item("LAN5").Value.ToString
                            End If
                    End Select
                Next
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub TrangThaiThem()
        If Me.tabPhuNuKT.SelectedTab.Index = 0 Then
            Me.flagThem = 1
            Lay_mau_macdinh()
            Me.txtMaNV.Enabled = True
            Me.dtpNgayMangThai.Enabled = True
            Me.dtpNgaydusinh.Enabled = True
            Me.btSua.Enabled = False
            Me.dtpNgayMangThai.Value = Now().Date
            ''========= 
            If Them And Sua And Xoa Then Me.btCapNhat.Enabled = True
            ''========== KO CHO SUA LUON =========''
            Tinh_tudong()
            Me.txtMaNV.Focus()
        End If
    End Sub
    Private Sub TrangThaiSua()
        If Me.tabPhuNuKT.SelectedTab.Index = 0 Then
            Me.flagThem = 0
            Me.txtMaNV.Enabled = False
            Me.dtpNgayMangThai.Enabled = False
            Me.btnThem.Enabled = True
            ''========== chi duoc sua ngay du sinh ========''
            Me.dtpNgaydusinh.Enabled = True
            ' Me.dtpNgaydusinh.ReadOnly = False
        End If
    End Sub
    Private Sub dgrBC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                TrangThaiSua()
                Me.btCapNhat.Enabled = True
        End Select
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        ' Khoa cot
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                Next
                ''============ set image xoa cot 2 ===========
                e.Layout.Bands(0).Columns("2").CellAppearance.Image = 2
            Case 1
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle

                    If (e.Layout.Bands(0).Columns(i).Key = "3") Then
                        ''============ mo cot check ===========
                        e.Layout.Bands(0).Columns("3").CellActivation = Activation.AllowEdit
                        e.Layout.Bands(0).Columns("3").Hidden = False
                    Else
                        e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    End If
                Next
                ''============ bỏ cột xóa ===========
                If e.Layout.Bands(0).Columns.Exists("2") Then
                    e.Layout.Bands(0).Columns("2").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                End If

            Case 2
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle

                    If (e.Layout.Bands(0).Columns(i).Key = "3") Then
                        ''============ an cot check ===========
                        e.Layout.Bands(0).Columns("3").CellActivation = Activation.AllowEdit
                        e.Layout.Bands(0).Columns("3").Hidden = True
                    Else
                        e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    End If
                Next
                ''============ set image xoa cot 2 ===========
                If flagTrangThaiTTT7 Then
                    e.Layout.Bands(0).Columns("2").CellAppearance.Image = 2
                Else

                End If
                ''============ bỏ cột check ===========
                'If e.Layout.Bands(0).Columns.Exists("3") Then
                '    e.Layout.Bands(0).Columns("3").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                'End If
            Case 3
                For i = 0 To e.Layout.Bands(0).Columns.Count - 1
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
                    e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
                    e.Layout.Bands(0).Columns(i).CellClickAction = CellClickAction.RowSelect
                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit

                    If (e.Layout.Bands(0).Columns(i).Key = "3") Then
                        ''============ mo cot check ===========
                        e.Layout.Bands(0).Columns("3").CellActivation = Activation.AllowEdit
                        e.Layout.Bands(0).Columns("3").Hidden = False
                    Else
                        e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                    End If
                Next
                ''============ bỏ cột check, cột xóa ===========
                If e.Layout.Bands(0).Columns.Exists("2") Then
                    e.Layout.Bands(0).Columns("2").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                End If
                If e.Layout.Bands(0).Columns.Exists("3") Then
                    e.Layout.Bands(0).Columns("3").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                End If
        End Select
    End Sub
    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                ChonDong()
                HieuChinh()
        End Select
    End Sub
    Private Sub ClearTT()
        Me.txtMaNV.Clear()
        Me.txtHoTen.Clear()
        Me.txtDonvi.Clear()
        Me.txtXuong.Clear()
        Me.dtpNgayVao.Text = ""

        Me.dtpLan1.Text = ""
        Me.dtpLan2.Text = ""
        Me.dtpLan3.Text = ""
        Me.dtpLan4.Text = ""
        Me.dtpLan5.Text = ""
        Me.txtMaNV.Focus()
    End Sub
    Public Sub Tinh_tudong()
        ''khi thay doi ngay mang thai thi tu dong cap nhat ngay du kien sinh,ve 15h30
        Dim NgayMT As Date = Me.dtpNgayMangThai.Value.ToString
        Dim NgayMT_convert As String = NgayMT.Year.ToString() + "/" + NgayMT.Month.ToString() + "/" + NgayMT.Day.ToString()
        obj.NgayMangThai = NgayMT_convert
        ''tinh ngayve15h30=ngaymangthay_moi + 6 thang
        Dim ngayve As Date
        ngayve = NgayMT.AddMonths(6).ToString()
        Dim ngayve15h30 As String = ngayve.Year.ToString() + "/" + ngayve.Month.ToString() + "/" + ngayve.Day.ToString()
        obj.NgayVe15H30 = ngayve15h30
        Me.dtpNgayve15h30.Value = ngayve15h30

        obj.NgayVe15H30 = ngayve15h30
        ''ngaydusinh=ngaymangthaimoi+9thang10ngay
        Dim ngaysinh1 As Date
        ngaysinh1 = NgayMT.AddDays(7).ToString()
        ngaysinh1 = ngaysinh1.AddMonths(9).ToString()

        Dim ngaydusinh As String = ngaysinh1.Year.ToString() + "/" + ngaysinh1.Month.ToString() + "/" + ngaysinh1.Day.ToString()
        Me.dtpNgaydusinh.Value = ngaydusinh
        obj.NgayDuSinh = ngaydusinh
    End Sub
    Private Sub btCapNhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Activate
        ' Lay_mau_macdinh()
        If Me.tabPhuNuKT.SelectedTab.Index = 0 Then
            If Me.dtpNgayMangThai.Text = "" Then
                MessageBox.Show("Bạn chưa chọn ngày mang thai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Me.txtMaNV.Text = "" Then
                MessageBox.Show("Bạn chưa nhập số thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If IsNumeric(Me.txtMaNV.Text.Trim()) = False Then
                MessageBox.Show("Vui lòng nhập chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Me.txtMaNV.Text.Length <> 6 Then
                MessageBox.Show("Vui lòng nhập đủ 6 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Me.dtpNgayve15h30.Text = "" Or Me.dtpNgaydusinh.Text = "" Then
                Me.dtpNgayMangThai.Focus()
                MessageBox.Show("Vui lòng chọn ngày mang thai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Luu_DuLieu()
        End If
    End Sub
    Private Sub Ancheckchonthang()
        If Me.chkdenthang.Checked Then
            Me.dtpdenthang.Enabled = True
        Else
            Me.dtpdenthang.Enabled = False
        End If
    End Sub
    Private Sub LoadNgayHT()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_Load.xml"
        Dim banght As DataTable
        Dim ngayht As Date = Now()
        Dim ngayload As String = ngayht.Year.ToString() + "/" + ngayht.Month.ToString() + "/" + ngayht.Day.ToString()
        obj.ChonBang = 37
        obj.NgayNhap = ngayload
        CapNhatSoLanMT()
        Kiemtra_SayThai()
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.XpCaption2.Text = "Danh sách nhân viên khám thai  "
    End Sub
    Private Sub Luu_DuLieu()
        Flag_chonLuu = True
        If flagThem = 0 Then

            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then

                obj.NgayMangThai = Me.dtpNgayMangThai.Value
                obj.NgayVe15H30 = Me.dtpNgayve15h30.Value
                obj.NgayDuSinh = Me.dtpNgaydusinh.Value
                'Date.Parse(Me.dtpNgaydusinh.Value.ToString())
                'obj.GhiChu = Me.txtGhiChu.Text
                ''=========== lưu lại ngày về 15h30, dự sinh cũ ===========''
                obj.NgayVe15H30Cu = Date.Parse(activeRow.Cells.Item("VE_15H30").Value.ToString()).Year.ToString() + "/" + Date.Parse(activeRow.Cells.Item("VE_15H30").Value.ToString()).Month.ToString() + "/" + Date.Parse(activeRow.Cells.Item("VE_15H30").Value.ToString()).Day.ToString()
                obj.NgayDuSinhCu = Date.Parse(activeRow.Cells.Item("DUSINH").Value.ToString()).Year.ToString() + "/" + Date.Parse(activeRow.Cells.Item("DUSINH").Value.ToString()).Month.ToString() + "/" + Date.Parse(activeRow.Cells.Item("DUSINH").Value.ToString()).Day.ToString()

                ''***********xet dk: neu ngay sinh thay doi thi lay theo ngay thay doi; nguoc lai lay theo ngay tu dong
                Dim ngaysinh1 As Date
                obj.NV_MA = Me.txtMaNV.Text.Trim()
                ''giu ngay mang thai cu de cap nhat
                obj.NgayMangThai = activeRow.Cells.Item("BDAU_MANGTHAI").Value
                obj.NgayMT = Date.Parse(obj.NgayMangThai).Year.ToString() + "/" + Date.Parse(obj.NgayMangThai).Month.ToString() + "/" + Date.Parse(obj.NgayMangThai).Day.ToString()
                NgaybdTT7 = Date.Parse(activeRow.Cells.Item("VE_15H30").Value.ToString())
                NgayktTT7 = Date.Parse(activeRow.Cells.Item("DUSINH").Value.ToString())

                obj.Batdautu = NgaybdTT7.Year.ToString() + "/" + NgaybdTT7.Month.ToString() + "/" + NgaybdTT7.Day.ToString()
                obj.DenNgay = NgayktTT7.Year.ToString() + "/" + NgayktTT7.Month.ToString() + "/" + NgayktTT7.Day.ToString()


                Me.b = New ClsB_PhuNuMangThai_KThaiYte
                obj.ChonBang = 6
                obj.Get_HanhDong = flagThem

                If Me.b.CapNhatNgaydusinh(obj) = True Then
                    MessageBox.Show("Đã cập nhật thành công ngày dự sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ThaoTac_BackUp()
                Else
                    MessageBox.Show("Số thẻ:" & Me.txtMaNV.Text & " mang thai ngày: " & Me.dtpNgayMangThai.Value & ", đã về 15h30.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
                'Me.b.UpdateInfo(obj) ''============ BO CAI NAY RA CHI CHO CAP NHAT NGAY DU SINH, KTRA CO CHUYEN DU LIEU ttt7 CHUA
                CapNhatSoLanMT_Textbox(obj.NV_MA)
                Kiemtra_SayThaiTextBox(obj.NV_MA)
                Tinh_CacLanKThai_Textbox(obj.NV_MA)
                ''======== neu cap nhat ko ngay thang dang chon thi ko load lai ngày ht; load lại theo tháng năm mang thai (bỏ sảy thai) ========''
                LocDulieuMangThai()
                An_dieukhien()
                TrangThaiThem()

            Else
                ''======== k chon tu luoi ========''
            End If
            ''========== trangthaisua()
        Else
            flagThem = 1 ''trang thai them
            obj.Get_HanhDong = flagThem
            ' TrangThaiThem()
            obj.NV_MA = Me.txtMaNV.Text.Trim()
            obj.NgayMangThai = Me.dtpNgayMangThai.Value
            obj.NgayVe15H30 = Me.dtpNgayve15h30.Value
            obj.NgayDuSinh = Me.dtpNgaydusinh.Value
            Dim ngayht As Date = Now()
            Dim ngayload As String = ngayht.Year.ToString() + "/" + ngayht.Month.ToString() + "/" + ngayht.Day.ToString()
            obj.NgayNhap = ngayload

            If Me.b.InsertInfo(obj) = True Then
                ThaoTac_BackUp()
                MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''tinh so lan mang thai
                CapNhatSoLanMT_Textbox(obj.NV_MA)
                Kiemtra_SayThaiTextBox(obj.NV_MA)
                Tinh_CacLanKThai_Textbox(obj.NV_MA)
            Else
                MessageBox.Show("Ngày mang thai đã có, không thể thêm được số thẻ: " & Me.txtMaNV.Text & " ngày mang thai:" & Me.dtpNgayMangThai.Value, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            TrangThaiThem()
            '' Me.methodLoad1()
        End If
        ClearTT()
        LoadNgayHT()
        Me.dtpNgayMangThai.Value = Now ''sua
    End Sub
    Public Sub methodLoad1()
        '' =====  Lọc ds ban đầu lên lưới theo tháng mang thai =====
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_Load.xml"

        obj.Xuong = Me.cbXuong.Value.ToString()
        Dim Thang As Date = Me.dtpNgay.Value.ToString()
        Dim ThangMT As String = Thang.Month.ToString()
        Dim NamMT As String = Thang.Year.ToString()

        obj.Thang = ThangMT
        obj.Nam = NamMT

        If obj.Xuong = "TCT" Then
            obj.ChonBang = 12
        Else
            obj.ChonBang = 11
        End If

        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.XpCaption2.Text = "Danh sách nhân viên khám thai  "
    End Sub
    Private Sub Load_DS_bandau()
        methodLoad1()
        Me.Kiemtra_SayThai()
    End Sub
    Private Sub methodDSMT_TuThangDenThang()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_Load.xml"

        Dim TuThang As Date = Me.dtpNgay.Value.ToString()
        Dim TuThangMT As String = TuThang.Month.ToString()
        Dim TuNamMT As String = TuThang.Year.ToString()
        Dim ngaydauthang As String = TuNamMT + "-" + TuThangMT + "-" + "01"

        Dim DenThang As Date = Me.dtpdenthang.Value.ToString()
        Dim DenThangMT As String = DenThang.Month.ToString()
        Dim DenNamMT As String = DenThang.Year.ToString()
        Dim ngaycuoi As String = GetEnday_InMonth(DenThangMT).ToString()
        Dim ngaycuoithang As String = DenNamMT + "-" + DenThangMT + "-" + ngaycuoi

        obj.Setnull()
        obj.Xuong = Me.cbXuong.Value.ToString()
        obj.NgayDauThang = ngaydauthang
        obj.NgayCuoiThang = ngaycuoithang
        If obj.Xuong = "TCT" Then
            obj.ChonBang = 28
        Else
            obj.ChonBang = 27
        End If

        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.XpCaption2.Text = ""
        Me.XpCaption2.Text = "Danh sách nhân viên mang thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng" & Me.dtpdenthang.Text.ToString()
        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        Dim columnToSummarize As UltraGridColumn

        Dim summary As SummarySettings

        Dim band1 As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band1.Layout.Bands(0).Summaries.Clear()

        Dim columnToSummarize1 As UltraGridColumn = band1.Layout.Bands(0).Columns(4)
        Dim summary1 As SummarySettings = band1.Layout.Bands(0).Summaries.Add("Tổng số:", SummaryType.Count, columnToSummarize1)
        summary1.Appearance.TextHAlign = HAlign.Right
        summary1.DisplayFormat = "Tổng số dòng = {0}"
    End Sub
    Private Sub Load_DS_bandaudenthang()
        '' =====  Loại sảy thai từ ds lọc ds ban đầu từ tháng đến tháng =======
        methodDSMT_TuThangDenThang()
        LoaiST_tuthang_denthang()
    End Sub
    Public Function GetEnday_InMonth(ByVal thang As String) As String
        Dim Ngaycuoithang As String
        Select Case thang
            Case "1", "3", "5", "7", "8", "10", "12" : Ngaycuoithang = "31"
            Case "4", "6", "9", "11" : Ngaycuoithang = "30"
            Case "2" : Ngaycuoithang = IIf(Year(Now()) Mod 4 = 0, 29, 28)
        End Select
        Return Ngaycuoithang
    End Function
    Private Function KiemTra_Khoa() As Boolean
        obj.NV_MA = Me.txtMaNV.Text
        obj.NgayMangThai = Me.dtpNgayMangThai.Value
        obj.ChonBang = 81
        Dim TempTimKhoa As New DataTable
        Me.b = New ClsB_PhuNuMangThai_KThaiYte

        TempTimKhoa = Nothing
        TempTimKhoa = Me.b.LoadDS(obj)
        If TempTimKhoa.Rows.Count > 0 Then
            If Convert.ToInt32(TempTimKhoa.Rows(0).Item("KT")) = 1 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Sub Doi_mau()
        ''to mau
        Me.lblve15h30.ForeColor = Color.Red
        Me.dtpNgayve15h30.Appearance.ForeColorDisabled = Color.Blue
        'Me.dtpNgayve15h30.Appearance.BackColorDisabled = Color.LightCyan

        Me.lblDuSinh.ForeColor = Color.Red
        Me.dtpNgaydusinh.Appearance.ForeColorDisabled = Color.Blue
        'Me.dtpNgaydusinh.Appearance.BackColorDisabled = Color.LightCyan
    End Sub
    Private Sub Lay_mau_macdinh()
        ''to mau
        Me.lblve15h30.ForeColor = Color.Blue
        Me.dtpNgayve15h30.Appearance.ForeColorDisabled = Color.Empty
        'Me.dtpNgayve15h30.Appearance.BackColorDisabled = Color.LightCyan

        Me.lblDuSinh.ForeColor = Color.Blue
        Me.dtpNgaydusinh.Appearance.ForeColorDisabled = Color.Empty
        'Me.dtpNgaydusinh.Appearance.BackColorDisabled = Color.LightCyan
    End Sub
    Private Sub txtMaNV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaNV.ValueChanged
        If Me.txtMaNV.TextLength = 6 Then
            If IsNumeric(Me.txtMaNV.Text) Then
                ''tim trong bang Nhân viên
                Me.txtLan.Text = ""
                obj.ChonBang = 7
                Dim Temp As New DataTable
                Me.b = New ClsB_PhuNuMangThai_KThaiYte
                Temp = Nothing
                obj.NV_MA = Me.txtMaNV.Text
                Temp = Me.b.LoadDS(obj)

                Dim flag As Boolean
                flag = False  ''mac dinh la flag=false

                If Temp.Rows.Count > 0 Then    ''tim co trong nhan vien la hop le

                    Me.txtHoTen.Text = Temp.Rows(0).Item("TEN").ToString
                    Me.dtpNgayVao.Value = Temp.Rows(0).Item("NGAYVAO").ToString
                    Me.txtDonvi.Text = Temp.Rows(0).Item("DONVI").ToString
                    Me.txtXuong.Text = Temp.Rows(0).Item("XUONG").ToString
                    obj.DV_MA = Temp.Rows(0).Item("MADV").ToString
                    ''========== XET THOI VIEC =====''
                    If Convert.ToBoolean(Temp.Rows(0).Item("THOIVIEC")) Or Convert.ToBoolean(Temp.Rows(0).Item("DV_NGHIVIEC")) Then
                        flag = False
                        An_dieukhien()
                        MessageBox.Show("Số thẻ vừa nhập không tồn tại trong Nhân Viên hoặc đã thôi việc, vui lòng kiểm tra lại!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        flag = True
                    End If
                    ''============== XÉT NAM/NỮ =========''
                    If Convert.ToBoolean(Temp.Rows(0).Item("NV_GIOITINH")) Then
                        flag = False
                        Flag_chonLuu = False
                        An_dieukhien()
                        Me.dtpNgayMangThai.Value = Now().Date
                        Me.dtpLan1.Value = Now().Date
                        Me.dtpLan2.Value = Now().Date
                        Me.dtpLan3.Value = Now().Date
                        Me.dtpLan4.Value = Now().Date
                        Me.dtpLan5.Value = Now().Date
                        MessageBox.Show("Số thẻ vừa nhập là nam, vui lòng kiểm tra lại!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        flag = True

                    End If

                Else
                    MessageBox.Show("Số thẻ vừa nhập không tồn tại trong Nhân Viên hoặc đã thôi việc, vui lòng kiểm tra lại!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btCapNhat.Enabled = False
                    Exit Sub
                End If

                ''tìm trong bang IT_PNMT và IT_PNMT_KThai
                Dim Temp2 As New DataTable
                Temp2 = Nothing
                obj.NV_MA = Me.txtMaNV.Text.Trim()
                obj.ChonBang = 8
                Me.b = New ClsB_PhuNuMangThai_KThaiYte
                Temp2 = Me.b.LoadDS(obj)
                Dim flag2 As Boolean
                flag2 = False

                If Temp2.Rows.Count = 0 Then ''tim thay trong bang nay IT_PNMT la co roi (KHOA LA NV_MA,NGAYMANGTHAI)
                    flag2 = False
                Else
                    flag2 = True
                End If

                If flag2 Then
                    ''========= trạng thái sửa ======''
                    Doi_mau()
                    Me.btSua.Enabled = True
                    Me.txtHoTen.Text = Temp.Rows(0).Item("TEN").ToString
                    Me.dtpNgayVao.Value = Temp.Rows(0).Item("NGAYVAO").ToString
                    Me.txtDonvi.Text = Temp.Rows(0).Item("DONVI").ToString
                    Me.txtXuong.Text = Temp.Rows(0).Item("XUONG").ToString
                    Me.dtpNgayMangThai.Value = Temp2.Rows(0).Item("NGAYMANGTHAI").ToString
                    Me.dtpNgayve15h30.Value = Temp2.Rows(0).Item("NGAYVE15H30").ToString
                    Me.dtpNgaydusinh.Value = Temp2.Rows(0).Item("NGAYDUSINH").ToString
                    ''  =================== hien thi cac lan mang thai cua ngay max ===================
                    Tinh_CacLanKThai_Textbox(obj.NV_MA)
                    Me.CapNhatSoLanMT_Textbox(obj.NV_MA)
                    Dim LanMangThai As New DataTable
                    obj.ChonBang = 9
                    Me.b = New ClsB_PhuNuMangThai_KThaiYte
                    obj.NV_MA = Me.txtMaNV.Text
                    LanMangThai = Me.b.LoadDS(obj)

                    If LanMangThai.Rows.Count > 0 Then
                        If LanMangThai.Rows(0).Item("LAN1").ToString = Nothing Then
                            Me.dtpLan1.Text = ""
                        Else
                            Me.dtpLan1.Text = LanMangThai.Rows(0).Item("LAN1").ToString
                        End If
                        If LanMangThai.Rows(0).Item("LAN2").ToString = Nothing Then
                            Me.dtpLan2.Text = ""
                        Else
                            Me.dtpLan2.Text = LanMangThai.Rows(0).Item("LAN2").ToString
                        End If

                        If LanMangThai.Rows(0).Item("LAN3").ToString = Nothing Then
                            Me.dtpLan3.Text = ""
                        Else
                            Me.dtpLan3.Text = LanMangThai.Rows(0).Item("LAN3").ToString
                        End If

                        If LanMangThai.Rows(0).Item("LAN4").ToString = Nothing Then
                            Me.dtpLan4.Text = ""
                        Else
                            Me.dtpLan4.Text = LanMangThai.Rows(0).Item("LAN4").ToString
                        End If

                        If LanMangThai.Rows(0).Item("LAN5").ToString = Nothing Then
                            Me.dtpLan5.Text = ""
                        Else
                            Me.dtpLan5.Text = LanMangThai.Rows(0).Item("LAN5").ToString
                        End If
                        ''============ hien thi so lan mang thai ===========''
                        Dim TempLanMT As New DataTable
                        Me.b = New ClsB_PhuNuMangThai_KThaiYte
                        TempLanMT = Nothing
                        obj.ChonBang = 38
                        obj.NV_MA = Me.txtMaNV.Text
                        TempLanMT = Me.b.LoadDS(obj)

                        If TempLanMT.Rows(0).Item("SOLANMT").ToString = Nothing Then
                            Me.lblLan.Visible = False
                            Me.txtLan.Visible = False
                        Else
                            Me.lblLan.Visible = True
                            Me.txtLan.Visible = True
                            Me.txtLan.Value = TempLanMT.Rows(0).Item("SOLANMT").ToString()
                        End If

                    Else
                        Me.dtpLan1.Value = ""
                        Me.dtpLan2.Text = ""
                        Me.dtpLan3.Text = ""
                        Me.dtpLan4.Text = ""
                        Me.dtpLan5.Text = ""
                    End If
                Else
                    Lay_mau_macdinh()
                    TrangThaiThem()
                End If
                If flag = True Then
                Else
                    An_dieukhien()
                End If
            End If
        End If
    End Sub
    Private Sub LocDulieuMangThai()
        If Me.chkdenthang.Checked Then
            Load_DS_bandaudenthang()
            CapNhatSoLanMT()
            LayThaiSanHienTai()
            LOAD_LANSAUDENTHANG()
        Else
            Load_DS_bandau()
            CapNhatSoLanMT()
            LayThaiSanHienTai()
            LOAD_LANSAU()
        End If
    End Sub
    Private Sub HuyHet()
        Dim i As Integer = 0
        While i <= Me.dgrBC.Rows.Count - 1
            If Me.dgrBC.Rows(i).Cells("3").Value = True Then
                Me.dgrBC.Rows(i).Cells("3").Value = False
            End If
            i = i + 1
        End While
    End Sub
    Private Sub bntLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntLoc.Click
        Flag_chonLuu = False
        Ancheckchonthang()
        LocDulieuMangThai()
    End Sub
    Private Sub LOAD_LANSAUDENTHANG()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_Load.xml"

        'clsTools.GridTheme1(Me.dgrBC)
        'If Me.splDetail.IsCollapsed Then
        '    Me.splDetail.ToggleState()
        'End If
        ''load combo Xuong
        obj.Xuong = Me.cbXuong.Value.ToString()
        Dim Thang As Date = Me.dtpNgay.Value.ToString()
        Dim ThangMT As String = Thang.Month.ToString()
        Dim NamMT As String = Thang.Year.ToString()

        obj.Thang = ThangMT
        obj.Nam = NamMT

        If obj.Xuong = "TCT" Then
            obj.ChonBang = 30
            Me.XpCaption2.Text = "Danh sách nhân viên mang thai khám thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng " & Me.dtpdenthang.Text.ToString() & " toàn công ty"
        Else
            obj.ChonBang = 29
            Me.XpCaption2.Text = "Danh sách nhân viên mang thai khám thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng " & Me.dtpdenthang.Text.ToString() & " của " & obj.Xuong
        End If

        Me.dgrBC.DataSource = Me.b.LoadDS(obj)

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            Me.btTinh.Visible = True
        Else
            Me.btTinh.Visible = False
        End If

    End Sub
    Private Sub LOAD_LANSAU()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_Load.xml"
        'clsTools.GridTheme1(Me.dgrBC)
        'If Me.splDetail.IsCollapsed Then
        '    Me.splDetail.ToggleState()
        'End If
        ''load combo Xuong
        obj.Xuong = Me.cbXuong.Value.ToString()
        Dim Thang As Date = Me.dtpNgay.Value.ToString()
        Dim ThangMT As String = Thang.Month.ToString()
        Dim NamMT As String = Thang.Year.ToString()

        obj.Thang = ThangMT
        obj.Nam = NamMT

        If obj.Xuong = "TCT" Then
            obj.ChonBang = 112
            Me.XpCaption2.Text = "Danh sách nhân viên mang thai tháng:  " & obj.Thang & " - " & obj.Nam & " của toàn công ty"

        Else
            obj.ChonBang = 111
            Me.XpCaption2.Text = "Danh sách nhân viên mang thai tháng:  " & obj.Thang & " - " & obj.Nam & " của xưởng" & obj.Xuong
        End If
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub
    Private Sub LayThaiSanHienTai()
        ''========= bỏ vòng lặp không cần thiết =======''
        Dim i As Integer = 0
        Dim thang As Integer
        Dim listpar As New ArrayList(3)
        Dim tuthang, denthang As String
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpdenthang.CustomFormat = "MM-yyyy"

        listpar.Add(New SqlParameter("@TNAMBD", Me.dtpNgay.Text))
        listpar.Add(New SqlParameter("@TNAMKT", Me.dtpdenthang.Text))
        If Me.chkdenthang.Checked Then
            listpar.Add(New SqlParameter("@CHONDENTHANG", 1))
        Else
            listpar.Add(New SqlParameter("@CHONDENTHANG", 0))
        End If
        Me.b.GoiThuTuc("SP_LAYTHAISANHIENTAI_", listpar)
        listpar.Clear()
    End Sub
    Private Sub tabPhuNuKT_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabPhuNuKT.SelectedTabChanged
        ''======== xet phan quyen ====
        If Them And Sua And Xoa Then

            Select Case Me.tabPhuNuKT.SelectedTab.Index
                Case 0
                    An_dieukhien()
                    Me.dgrBC.Visible = True
                    Me.XpCaption2.Text = "Danh sách CB-CNV mang thai"

                    Me.btnThem.Visible = True
                    Me.btSua.Visible = True
                    Me.btCapNhat.Visible = True
                    Me.btTinh.Visible = True

                    ''load lai danh sach mang thai 
                    'If Me.cbXuong.Text <> "" AndAlso Me.dtpNgay.Value.ToString() <> "" Then
                    '    Ancheckchonthang()
                    '    If Me.chkdenthang.Checked Then
                    '        Load_DS_bandaudenthang()
                    '        CapNhatSoLanMT()
                    '        LayThaiSanHienTai()
                    '        LOAD_LANSAUDENTHANG()
                    '    Else
                    '        Load_DS_bandau()
                    '        CapNhatSoLanMT()
                    '        LayThaiSanHienTai()
                    '        LOAD_LANSAU()
                    '    End If
                    'End If
                    TrangThaiThem()
                    ClearTT()

                Case 1
                    Me.dgrBC.Visible = False
                    Me.btnThem.Visible = False
                    Me.btSua.Visible = False
                    Me.btCapNhat.Visible = False
                    Me.btTinh.Visible = False
                    Me.btExcel.Visible = False

            End Select
        Else
            Me.btnThem.Visible = False
            Me.btSua.Visible = False
            Me.btTinh.Visible = False
            Me.btCapNhat.Visible = False
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub
    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
    Private Sub dtpNgayMangThai_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgayMangThai.ValueChanged
        Tinh_tudong()
        ''Doi_mau()
    End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        If Me.tabPhuNuKT.SelectedTab.Index = 0 Then
            TrangThaiThem()
            ClearTT()
            Me.txtMaNV.Enabled = True
            Me.txtMaNV.Focus()
            Me.btCapNhat.Enabled = True
            Me.btSua.Enabled = False
        End If
    End Sub
    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        If Me.tabPhuNuKT.SelectedTab.Index = 0 Then
            Me.HieuChinh()
            Me.btCapNhat.Enabled = True
        Else
            Exit Sub
        End If
    End Sub
    Private Sub dgrBC_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        ' ChonDong()
        Dim activeRow As UltraGridRow
        Dim activeCell As UltraGridCell

        Select Case Me.tabPhuNuKT.SelectedTab.Index
            Case 0
                'ChonDong()
                'ChonDongCu()
                activeRow = Me.dgrBC.ActiveRow
                activeCell = Me.dgrBC.ActiveCell
                If Not activeCell Is Nothing Then
                    'MessageBox.Show(activeCell.Column.Key.ToString())
                    Dim ColA As String = (activeCell.Column.Key.ToString())
                    Dim RowA As Integer = (activeCell.Row.Index)
                    Select Case ColA
                        Case "2"
                            Dim obj As New Obj_PhuNuMangThai_KThaiYte
                            obj.Setnull()
                            obj.NV_MA = activeCell.Row.Cells.Item("MA").Text
                            obj.NgayMangThai = activeCell.Row.Cells.Item("BDAU_MANGTHAI").Value
                            ''============ xet phân quyền được xóa ==========''
                            If (Them AndAlso Sua AndAlso Xoa) Or (Me.bAdmin) Then

                                Try
                                    NgaybdTT7 = Date.Parse(dgrBC.ActiveRow.Cells("VE_15H30").Value.ToString())
                                    NgayktTT7 = Date.Parse(dgrBC.ActiveRow.Cells("DUSINH").Value.ToString())

                                    obj.Batdautu = NgaybdTT7.Year.ToString() + "/" + NgaybdTT7.Month.ToString() + "/" + NgaybdTT7.Day.ToString()
                                    obj.DenNgay = NgayktTT7.Year.ToString() + "/" + NgayktTT7.Month.ToString() + "/" + NgayktTT7.Day.ToString()

                                    If Me.b.DeleteInfo(obj) Then
                                        Me.ThaoTac_BackUp()
                                        ''======= tinh so lan mang thai lai ======''
                                        CapNhatSoLanMT_Textbox(obj.NV_MA)
                                        MessageBox.Show("Đã xóa ngày mang thai của số thẻ " & obj.NV_MA & " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Else
                                        MessageBox.Show("Không thể xóa ngày mang thai đã về 15h30.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Me.btnThem.Enabled = True
                                        TrangThaiThem()
                                        ClearTT()
                                        Exit Sub
                                    End If
                                Catch ex As Exception
                                    ' MessageBox.Show("Không thể xóa ngày mang thai của số thẻ " & obj.NV_MA, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    'ProjectData.ClearProjectError()
                                End Try
                                Me.btnThem.Enabled = True
                                TrangThaiThem()
                                ClearTT()
                                LocDulieuMangThai()
                            Else
                                ''================== truong hop khong load luoi lai: khong mat cot xoa ========
                                MessageBox.Show("Bạn không có quyền được xóa trong chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                    End Select
                End If
            Case 1
                've 15h30 ko co nut xoa

        End Select
    End Sub
    Public Sub methodLoadTuThangDenThang()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_lan.xml"
        Dim ngaydauthang, ngaycuoithang As String

        obj.Setnull()
        ngaydauthang = Date.Parse(Me.dtpNgay.Value.ToString()).Year.ToString() + "/" + Date.Parse(Me.dtpNgay.Value.ToString()).Month.ToString() + "/01"
        ngaycuoithang = Date.Parse(Me.dtpdenthang.Value.ToString()).Year.ToString() + "/" + Date.Parse(Me.dtpdenthang.Value.ToString()).Month.ToString() + "/" + GetEnday_InMonth(Me.dtpdenthang.Value.Month.ToString()).ToString()
        obj.Xuong = Me.cbXuong.Value.ToString()
        obj.NgayDauThang = ngaydauthang
        obj.NgayCuoiThang = ngaycuoithang

        If obj.Xuong <> "" Then
            Select Case obj.Xuong
                Case "TCT"
                    obj.ChonBang = 32
                    Me.XpCaption2.Text = "Danh sách nhân viên mang thai và các lần khám thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng " & Me.dtpdenthang.Text.ToString() & " toàn công ty"
                Case Else
                    obj.ChonBang = 31
                    Me.XpCaption2.Text = "Danh sách nhân viên mang thai và các lần khám thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng " & Me.dtpdenthang.Text.ToString() & " xưởng " & obj.Xuong
            End Select
        End If
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.XpCaption2.Text = ""
        Me.XpCaption2.Text = "Danh sách nhân viên mang thai và các lần khám thai từ tháng " & Me.dtpNgay.Text.ToString() & " đến tháng " & Me.dtpdenthang.Text.ToString() & " của xưởng " & Me.cbXuong.Text.ToString()

        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        Dim columnToSummarize As UltraGridColumn

        Dim summary As SummarySettings

        Dim band1 As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band1.Layout.Bands(0).Summaries.Clear()

        Dim columnToSummarize1 As UltraGridColumn = band1.Layout.Bands(0).Columns(4)
        Dim summary1 As SummarySettings = band1.Layout.Bands(0).Summaries.Add("Tổng số:", SummaryType.Count, columnToSummarize1)
        summary1.Appearance.TextHAlign = HAlign.Right
        summary1.DisplayFormat = "Tổng số dòng = {0}"
    End Sub
    Public Sub methodLoadThang()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Me.Path = "/layout/PNMT_KThai_lan.xml"
        obj.Xuong = Me.cbXuong.Value.ToString()
        Dim Thang As Date = Me.dtpNgay.Value.ToString()

        obj.Thang = Date.Parse(Me.dtpNgay.Value.ToString()).Month.ToString()
        obj.Nam = Date.Parse(Me.dtpNgay.Value.ToString()).Year.ToString()

        If obj.Xuong <> "" Then
            Select Case obj.Xuong
                Case "TCT"
                    obj.ChonBang = 14
                    Me.XpCaption2.Text = "Danh sách nhân viên mang thai và các lần khám thai tháng " & Me.dtpNgay.Text.ToString() & " toàn công ty"
                Case Else
                    obj.ChonBang = 3
                    Me.XpCaption2.Text = "Danh sách nhân viên mang thai và các lần khám thai tháng " & Me.dtpNgay.Text.ToString() & " xưởng " & obj.Xuong
            End Select
        End If
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        Dim columnToSummarize As UltraGridColumn

        Dim summary As SummarySettings

        Dim band1 As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band1.Layout.Bands(0).Summaries.Clear()

        Dim columnToSummarize1 As UltraGridColumn = band1.Layout.Bands(0).Columns(4)
        Dim summary1 As SummarySettings = band1.Layout.Bands(0).Summaries.Add("Tổng số:", SummaryType.Count, columnToSummarize1)
        summary1.Appearance.TextHAlign = HAlign.Right
        summary1.DisplayFormat = "Tổng số dòng = {0}"
    End Sub
    Private Sub btTinh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTinh.Activate
        If Me.chkdenthang.Checked Then
            methodDSMT_TuThangDenThang()
            CapNhatSoLanMT()
            Tinh_CacLanKThaiTuThangDenThang()
            LoaiST_tuthang_denthang()
            methodLoadTuThangDenThang() ''===== ds mang thai  + kthai
        Else
            methodLoad1()
            CapNhatSoLanMT()
            Tinh_CacLanKThai()
            Kiemtra_SayThai()
            methodLoadThang() ''===== ds mang thai  + kthai
        End If
    End Sub
    Private Sub chkdenthang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdenthang.CheckedChanged
        Ancheckchonthang()
        ''tu tinh va hien thi cac lan kham thai
    End Sub
    Private Sub bntXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXem.Click
        If Me.dgrBC.DataSource Is Nothing Then
            MsgBox("Hãy lọc dữ liệu trước khi xem báo cáo!", MsgBoxStyle.Information, "Thông báo")
            Exit Sub
        Else
            ''loc danh sach mang thai va tinh so lan kham thai 
            If Me.chkdenthang.Checked Then
                Load_DS_bandaudenthang()
                CapNhatSoLanMT()
                LayThaiSanHienTai()
                LOAD_LANSAUDENTHANG()
                Me.Tinh_CacLanKThaiTuThangDenThang()
            Else
                Load_DS_bandau()
                CapNhatSoLanMT()
                LayThaiSanHienTai()
                LOAD_LANSAU()
                Tinh_CacLanKThaiTuThangDenThang()
            End If
            ''phan danh cho report
            Dim report As New FrmReport
            If Me.chkdenthang.Checked Then
                ''neu chon tct thi M
                obj.Xuong = Me.cbXuong.Value.ToString()
                Dim TuThang As Date = Me.dtpNgay.Value.ToString()
                Dim TuThangMT As String = TuThang.Month.ToString()
                Dim TuNamMT As String = TuThang.Year.ToString()
                Dim ngaydauthang As String = TuNamMT + "-" + TuThangMT + "-" + "01"

                Dim DenThang As Date = Me.dtpdenthang.Value.ToString()
                Dim DenThangMT As String = DenThang.Month.ToString()
                Dim DenNamMT As String = DenThang.Year.ToString()
                Dim ngaycuoi As String = GetEnday_InMonth(DenThangMT).ToString()
                Dim ngaycuoithang As String = DenNamMT + "-" + DenThangMT + "-" + ngaycuoi
                If obj.Xuong = "TCT" Then
                    report.reportID = "MT0111"
                    Dim strArray As String() = New String() {"TCT", ngaydauthang, ngaycuoithang}
                    report.para = strArray
                Else
                    report.reportID = "MT0111"
                    Dim strArray As String() = New String() {obj.Xuong, ngaydauthang, ngaycuoithang}
                    report.para = strArray
                End If
                report.issysReport = True
                report.Show()
            Else
                ''khong check den thang
                obj.Xuong = Me.cbXuong.Value.ToString()
                Dim TuThang As Date = Me.dtpNgay.Value.ToString()
                Dim TuThangMT As String = TuThang.Month.ToString()
                Dim TuNamMT As String = TuThang.Year.ToString()
                Dim ngaydauthang As String = TuNamMT + "-" + TuThangMT + "-" + "01"
                If obj.Xuong = "TCT" Then
                    report.reportID = "MT04"
                    Dim strArray As String() = New String() {ngaydauthang, "TCT"}
                    report.para = strArray
                Else
                    report.reportID = "MT04"
                    Dim strArray As String() = New String() {ngaydauthang, obj.Xuong}
                    report.para = strArray
                End If
                report.issysReport = True
                report.Show()
            End If
        End If
    End Sub
    Private Sub TinhNgayDuongSuc(ByVal sManv As String)
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", sManv))
        Me.b.GoiThuTuc("SP_LAYNGAYDS_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub TinhNgaySayThai(ByVal sManv As String)
        Dim i As Integer = 0
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", sManv))
        Me.b.GoiThuTuc("SP_LAYNGUOISAYTHAI_KMAX", listpar)
        listpar.Clear()
    End Sub
    Private Sub TinhSoLanTS(ByVal manv As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", manv))
        Me.b.GoiThuTuc("SP_TINHSOLANTS", listpar)
        listpar.Clear()
    End Sub
    Private Sub TinhSoLanMT(ByVal manv As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", manv))
        Me.b.GoiThuTuc("SP_TINHSOLANMT", listpar)
        listpar.Clear()
    End Sub
    Private Sub chkDThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDThang.CheckedChanged
        If chkDThang.Checked Then
            Me.dtpTgkt.Enabled = True
        Else
            Me.dtpTgkt.Enabled = False
        End If
    End Sub
    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        If Me.dgrBC.Rows.Count = 0 Then
            MessageBox.Show("Vui lòng lọc dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
                ' MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub
    Private Sub txtTimSoThe_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimSoThe.ValueChanged
        Dim SolanMT As New DataTable
        Dim MangThai As New DataTable
        If Me.txtTimSoThe.Text.Length = 6 Then
            obj.ChonBang = 7
            Dim Temp As New DataTable
            Me.b = New ClsB_PhuNuMangThai_KThaiYte
            Temp = Nothing
            obj.NV_MA = Me.txtTimSoThe.Text
            Temp = Me.b.LoadDS(obj)

            Dim flag As Boolean
            flag = False  ''mac dinh la flag=false

            If Temp.Rows.Count > 0 Then    ''tim co trong nhan vien la hop le
                flag = True
                Me.lblHoTen.Visible = True
                Me.lblDonvi.Visible = True
                Me.txtHienthiTen.Visible = True
                Me.txtHienthiDonvi.Visible = True
                Me.txtHienthiTen.Text = Temp.Rows(0).Item("TEN").ToString
                Me.txtHienthiDonvi.Text = Temp.Rows(0).Item("DONVI").ToString

                ''------------ Hien thi thong tin mang thai ----------------------
                Dim k As Integer
                obj.ChonBang = 94
                MangThai = Nothing
                obj.NV_MA = Me.txtTimSoThe.Text
                MangThai = Me.b.LoadDS(obj)

                If MangThai.Rows.Count > 0 Then
                    Me.groupKq.Visible = True
                    ''tinh so lan mang thai cua 1 nhanvien
                    TinhSoLanMT(txtTimSoThe.Text)
                    TinhSoLanTS(txtTimSoThe.Text)
                    ''------------ dua cac ngay mang thai vao combo -----------
                    Me.dtpKqNgayMT.Items.Clear()
                    For k = 0 To MangThai.Rows.Count - 1
                        Me.dtpKqNgayMT.Items.Add(MangThai.Rows(k).Item("NGAYMANGTHAI"))
                    Next
                    Me.dtpKqNgayMT.SelectedIndex = 0

                    obj.ChonBang = 95
                    Me.b = New ClsB_PhuNuMangThai_KThaiYte
                    SolanMT = Nothing
                    obj.NV_MA = Me.txtTimSoThe.Text
                    SolanMT = Me.b.LoadDS(obj)
                    If SolanMT.Rows.Count > 0 Then
                        Me.txtLanMangThai.Visible = True
                        If SolanMT.Rows(0).Item("SOLAN_MT").ToString = Nothing Then
                            Me.lblDem.Visible = False
                            Me.txtLanMangThai.Visible = False
                            Exit Sub
                        Else
                            Me.lblDem.Text = SolanMT.Rows(0).Item("SOLAN_MT").ToString + " lần"
                            Me.txtLanMangThai.Visible = True
                            Me.txtLanMangThai.Text = "Đã mang thai "
                            Me.dtpKqNgayMT.Enabled = True
                        End If
                    End If

                Else
                    MsgBox("Số thẻ vừa nhập không tìm thấy trong Phụ Nữ Mang Thai!", MsgBoxStyle.Information, "Thông báo!")
                    Me.groupKq.Visible = False
                    Exit Sub
                End If
            Else
                flag = False
                MsgBox("Số thẻ vừa nhập không tồn tại trong Nhân Viên, vui lòng kiểm tra lại!", MsgBoxStyle.Critical, "Thông báo!")
                Exit Sub
            End If

            If flag = True Then ''thay trong nv
                ''=========== ham tim thong tin thai san, duong suc ======================''
                If Not Me.dtpKqNgayMT.Value Is Nothing Then
                    Try
                        Dim ngaymt As Date = Me.dtpKqNgayMT.Value
                        TinhNgayDuongSuc(Me.txtTimSoThe.Text.Trim())
                        TinhNgaySayThai(Me.txtTimSoThe.Text.Trim())
                        TimThongTin_ThaiSan_DSuc_KThai(Me.txtTimSoThe.Text.Trim(), ngaymt)
                    Catch ex As Exception

                    End Try

                Else
                    Exit Sub
                End If

                ''lay ngay say thai trong nhanviennghiphep

            Else
                'MsgBox("Số thẻ này khong ton tai trong nhan vien, vui lòng nhập lại!", MsgBoxStyle.Critical, "Thông báo!")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TimThongTin_ThaiSan_DSuc_KThai(ByVal sManv As String, ByVal dNgaymangthai As Date)
        Dim Temp2 As New DataTable
        Temp2 = Nothing
        obj.NV_MA = Me.txtTimSoThe.Text
        obj.ChonBang = 96
        obj.NgayMangThai = dNgaymangthai.Year.ToString() + "-" + dNgaymangthai.Month.ToString() + "-" + dNgaymangthai.Day.ToString()
        Me.b = New ClsB_PhuNuMangThai_KThaiYte
        Temp2 = Me.b.LoadDS(obj)

        If Temp2.Rows(0).Item("VE15H30").ToString = Nothing Then
            Me.dtpKqVe15h30.Value = ""
        Else
            Me.dtpKqVe15h30.Value = Temp2.Rows(0).Item("VE15H30").ToString
        End If

        If Temp2.Rows(0).Item("DUSINH").ToString = Nothing Then
            Me.dtpKqDusinh.Value = ""
        Else
            Me.dtpKqDusinh.Value = Temp2.Rows(0).Item("DUSINH").ToString
        End If
        Tinh_CacLanKThai()

        If Temp2.Rows(0).Item("TUNGAY").ToString = Nothing Then
            Me.dtpkqTSTungay.Value = ""
        Else
            dtpkqTSTungay.Value = Temp2.Rows(0).Item("TUNGAY").ToString
        End If

        If Temp2.Rows(0).Item("DENNGAY").ToString = Nothing Then
            Me.dtpkqTSDenNgay.Value = ""
        Else
            Me.dtpkqTSDenNgay.Value = Temp2.Rows(0).Item("DENNGAY").ToString
        End If

        If Trim(Temp2.Rows(0).Item("NGAYSANH")) = "" OrElse Temp2.Rows(0).Item("NGAYSANH") Is Nothing Then
            Me.dtpKqNgaySanh.Value = ""
        Else
            Me.dtpKqNgaySanh.Text = Temp2.Rows(0).Item("NGAYSANH").ToString
        End If

        If Temp2.Rows(0).Item("NGAYGIAHAN").ToString = Nothing Or Temp2.Rows(0).Item("NGAYGIAHAN").ToString = "" Then
            Me.chkkqNgayGH.Checked = False
            Me.dtpKqNgayGH.Text = ""
        Else
            Me.chkkqNgayGH.Checked = True
            Me.dtpKqNgayGH.Text = Temp2.Rows(0).Item("NGAYGIAHAN").ToString
        End If

        If Temp2.Rows(0).Item("BATDAU_NC").ToString = Nothing Or Temp2.Rows(0).Item("BATDAU_NC").ToString = "" Then
            Me.dtpKqBdNC.Text = ""
        Else
            Me.dtpKqBdNC.Text = Temp2.Rows(0).Item("BATDAU_NC").ToString
        End If

        If Temp2.Rows(0).Item("KETTHUC_NC").ToString = Nothing Or Temp2.Rows(0).Item("KETTHUC_NC").ToString = "" Then
            Me.dtpKqKtNC.Text = ""
        Else
            Me.dtpKqKtNC.Text = Temp2.Rows(0).Item("KETTHUC_NC").ToString
        End If
        ''===================== thong tin ngay nghỉ dưỡng sức ============================
        If Temp2.Rows(0).Item("NGAYBD_DS").ToString = Nothing Then
            Me.dtpKqNgayGH.Value = ""
            Me.chkkqNgayGH.Checked = False
        Else
            Me.dtpKqNgayGH.Value = Temp2.Rows(0).Item("NGAYBD_DS").ToString
            Me.chkkqNgayGH.Checked = True
        End If

        If Temp2.Rows(0).Item("NGAYKT_DS").ToString = Nothing Then
            Me.dtpKqDSDenngay.Value = ""
        Else
            Me.dtpKqDSDenngay.Value = Temp2.Rows(0).Item("NGAYKT_DS").ToString
        End If
        ''===================== thong tin các ngày khám thai  ============================
        If Temp2.Rows(0).Item("LAN1").ToString = Nothing Then
            Me.dtpKqKTLan1.Value = ""
        Else
            Me.dtpKqKTLan1.Value = Temp2.Rows(0).Item("LAN1").ToString
        End If
        If Temp2.Rows(0).Item("LAN2").ToString = Nothing Then
            Me.dtpKqKTLan2.Text = ""
        Else
            Me.dtpKqKTLan2.Text = Temp2.Rows(0).Item("LAN2").ToString
        End If

        If Temp2.Rows(0).Item("LAN3").ToString = Nothing Then
            Me.dtpKqKTLan3.Text = ""
        Else
            Me.dtpKqKTLan3.Text = Temp2.Rows(0).Item("LAN3").ToString
        End If

        If Temp2.Rows(0).Item("LAN4").ToString = Nothing Then
            Me.dtpKqKTLan4.Text = ""
        Else
            Me.dtpKqKTLan4.Text = Temp2.Rows(0).Item("LAN4").ToString
        End If

        If Temp2.Rows(0).Item("LAN5").ToString = Nothing Then
            Me.dtpKqKTLan5.Text = ""
        Else
            Me.dtpKqKTLan5.Text = Temp2.Rows(0).Item("LAN5").ToString
        End If
        ''===================== thong tin ngay say thai ============================
        If Temp2.Rows(0).Item("NGAYSAYTHAI").ToString = Nothing Then
            Me.chkKqST.Checked = False
            dtpkqSTTuNgay.Text = ""
            Me.dtpKqSTDenngay.Text = ""
        Else
            Me.chkKqST.Checked = True
            dtpkqSTTuNgay.Text = Temp2.Rows(0).Item("NGAYSAYTHAI").ToString
            Me.dtpKqSTDenngay.Text = Temp2.Rows(0).Item("NGAYKTSAYTHAI").ToString
        End If
    End Sub

    Private Sub dtpKqNgayMT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpKqNgayMT.ValueChanged
        If Not Me.dtpKqNgayMT.Value Is Nothing And Me.txtTimSoThe.Text <> "" Then
            Try
                Dim ngaymt As Date = Me.dtpKqNgayMT.Text
                'Dim ngaymt As String = CDate(Me.dtpKqNgayMT.Text).Year.ToString() + "/" + CDate(Me.dtpKqNgayMT.Text).Month.ToString() + "/" + CDate(Me.dtpKqNgayMT.Text).Day.ToString()
                TimThongTin_ThaiSan_DSuc_KThai(Me.txtTimSoThe.Text.Trim(), ngaymt)

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class