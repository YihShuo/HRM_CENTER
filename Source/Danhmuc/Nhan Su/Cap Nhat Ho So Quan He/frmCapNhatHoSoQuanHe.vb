Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
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
Imports System.DBNull
Imports System.Drawing.Bitmap
Imports System.Configuration
Public Class frmCapNhatHoSoQuanHe
    ''Người tạo: Quyến
    ''Ngày tạo: năm 2011
    ''Nội dung tạo: Cập nhật và xem thông tin-lý lịch nhân viên
    ''Người hiệu chỉnh: Trân
    ''Ngày hiệu chỉnh: 11/03/2016
    ''Nội dung hiệu chỉnh: Tách tab2 của Hồ sơ nhân sự thành form nhân viên quan hệ
    Dim Them As Boolean = False
    Dim Sua As Boolean = False
    Dim Xoa As Boolean = False
    Dim bNamSinh As Boolean = False
    Dim bNamSinhQH As Boolean = False
    '' biến toàn cục tách chuỗi ngày tháng năm từ lưới (đã định dạng thành ngày/tháng/năm; kiểu chuỗi) (khi định dạng ngày trên máy không đúng kiểu dd/MM/yyyy)
    Dim ngaythangnam, ngaythang, ngay, thang, nam, tungay As String
    'Public Sub New()
    '    AddHandler MyBase.Load, New EventHandler(AddressOf Me.CapNhat_Load)
    '    'Me.InitializeComponent()
    'End Sub
    ''' <summary>
    ''' Đổi định dạng từ lưới lên datetimepicker
    ''' <returns> ngày kiểu chuỗi theo định dạng yyyy/MM/dd</returns>
    Private Function DoiDinhDangNgay(ByVal sNgay As String) As String
        Dim chuoingay As String = ""
        Dim kieu_phancachngay As String = "-"
        If sNgay <> "" Then
            ngaythangnam = sNgay
            ngaythang = ngaythangnam.Substring(0, ngaythangnam.LastIndexOf("-"))

            ngay = ngaythang.Substring(0, ngaythang.LastIndexOf("-"))
            thang = ngaythang.Substring(ngaythang.LastIndexOf("-") + 1)
            nam = ngaythangnam.Substring(ngaythangnam.LastIndexOf("-") + 1)
            chuoingay = nam + "-" + thang + "-" + ngay
        End If
        Return chuoingay
    End Function
    Private Sub chkXemHinhtab2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXemHinhtab2.CheckedChanged

        Dim pic As Bitmap
        On Error GoTo Loi
        If Me.chkXemHinhtab2.Checked = True Then
            'Me.Picturetab2.Image = pic.FromFile("D:\HinhNV\000002.JPG")
            Me.Picturetab2.Image = pic.FromFile("\\" & clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Server")) & "\HinhNV\" & Trim(Me.txtManvTab2.Text) + ".JPG")
        Else
            Me.Picturetab2.Image = Nothing
        End If
        Exit Sub
Loi:
        Me.Picturetab2.Image = Nothing

    End Sub
    'Bien
    Dim oldRow As Integer = 0
    Dim flag As Boolean
    Dim obj As New objCapNhatHoSoQuanHe
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Friend WithEvents d As clsDCapNhatHoSoQuanHe    ' Nested Types
    Friend WithEvents b As clsBCapNhatHoSoQuanHe
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Private Sub frmCapNhatHoSoQuanHe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 1
        'Me.dtpNgaySinhQH.Format = DateTimePickerFormat.Custom
        'Me.methodLoad()
        'End Select
        obj.NGUOIDUNG = frmDangNhap.txtTendangnhap.Text
        obj.ChonBang = 34
        Dim TQuyenTruyCap As New DataTable
        Me.b = New clsBCapNhatHoSoQuanHe
        TQuyenTruyCap = Me.b.LoadDS(obj)
        If TQuyenTruyCap.Rows.Count > 0 Then
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
        End If
        Me.QuyenTruyCap()
    End Sub
    Public Sub QuyenTruyCap()
        If Them Then
            Me.btThem.Visible = True
        Else
            Me.btThem.Visible = False
        End If

        If Sua Then
            Me.btCapNhat.Visible = True
            'Me.btCapNhatHDLD.Visible = True
            'Me.btCapNhatHoSoThoiViec.Visible = True
            'Me.btCapNhatDoanvien.Visible = True
            'Me.btnLable.Visible = True
        Else
            Me.btCapNhat.Visible = False
            'Me.btCapNhatHDLD.Visible = False
            'Me.btCapNhatHoSoThoiViec.Visible = False
            'Me.btCapNhatDoanvien.Visible = False
            'Me.btnLable.Visible = False
        End If

        If Xoa Then
            Me.btXoa.Visible = True
        Else
            Me.btXoa.Visible = False
        End If
    End Sub
    Private Sub txtManvTab2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManvTab2.ValueChanged
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 0

        'Case 1
        Dim ngaysinhNV As String ''======= ngày sinh format định dạng khi sai ngày trong máy người dùng
        Dim dNgaysinhNV As Date
        If txtManvTab2.TextLength = 6 Then
            ''================
            obj.SetnullQH()

            obj.ChonBang = 31
            Dim Temp2 As New DataTable
            Me.b = New clsBCapNhatHoSoQuanHe
            obj.Table = "ST_NHANVIEN"
            Temp2 = Nothing
            obj.MaNVQH = Me.txtManvTab2.Text
            Temp2 = Me.b.LoadDS(obj)

            If Temp2.Rows.Count > 0 Then
                Me.TrangThaiThemMoi()
                Me.btXoa.Enabled = True
                Me.btThem.Enabled = True
                Me.btCapNhat.Enabled = False
                'Me.btCapNhatHDLD.Enabled = False
                'Me.btCapNhatHoSoThoiViec.Enabled = False
                '' --------------------------------------
                Me.txtTenTab2.Text = Temp2.Rows(0).Item(1).ToString()
                Me.txtTenThuongGoi.Text = Temp2.Rows(0).Item(1).ToString()
                Me.txtTenNVQH.Text = Temp2.Rows(0).Item(1).ToString()
                Me.dtpNgayVaoTab2.Text = Temp2.Rows(0).Item(2).ToString()
                Me.txtDiachitab2.Text = Temp2.Rows(0).Item(3).ToString()
                Me.txtDiaChiQH.Text = Me.txtDiachitab2.Text
                Me.txtDVTab2.Text = Temp2.Rows(0).Item(4).ToString()
                Me.txtCVtab2.Text = Temp2.Rows(0).Item(5).ToString()
                Me.txtChucVutab2.Text = Temp2.Rows(0).Item(6).ToString()
                Me.txtchuyenmon.Text = Temp2.Rows(0).Item(7).ToString()

                ''========= hien thi nam sinh hoac ngay sinh=======''

                ''========= hien thi nam sinh hoac ngay sinh=======''

                If IsDBNull(Temp2.Rows(0).Item("NV_NAMSINH")) Then
                    ngaysinhNV = DoiDinhDangNgay(Temp2.Rows(0).Item("NV_NGAYSINH").Value.ToString)
                    dNgaysinhNV = Date.Parse(ngaysinhNV)
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "dd/MM/yyyy"
                    dtpNgaySinhQH.Value = dtpNgaysinhtab2.Value
                ElseIf Convert.ToBoolean(Temp2.Rows(0).Item("NV_NAMSINH").ToString()) = True Then
                    dNgaysinhNV = Date.Parse(Temp2.Rows(0).Item("NV_NGAYSINHTT").ToString())
                    ngaysinhNV = dNgaysinhNV.Year.ToString()
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "yyyy"
                    dtpNgaySinhQH.Value = dtpNgaysinhtab2.Value
                Else
                    ngaysinhNV = DoiDinhDangNgay(Temp2.Rows(0).Item("NV_NGAYSINH").ToString)
                    dNgaysinhNV = Date.Parse(ngaysinhNV)
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "dd/MM/yyyy"
                    dtpNgaySinhQH.Value = dtpNgaysinhtab2.Value
                End If
                Dim ngaycmnd As String ''======= ngày sinh format định dạng khi sai ngày trong máy người dùng
                Dim dNgaycmnd As Date
                'Me.dtpNgaysinhtab2.Text = Temp2.Rows(0).Item(8).ToString()
                Me.dtpNgaykyHD.Text = Temp2.Rows(0).Item("NV_NGAYKHD").ToString()
                Me.txtMucluongtab2.Text = Temp2.Rows(0).Item("HD_LUONGCB").ToString()
                Me.lblcmnd.Text = Temp2.Rows(0).Item("NV_CMND").ToString()
                'Me.txtKhaiSinh.Text = Temp2.Rows(0).Item("NV_QueQuan").ToString()
                Me.txtSoCMNDQH.Text = Temp2.Rows(0).Item("NV_CMND").ToString()
                Me.lblNoiCapCMND.Text = Temp2.Rows(0).Item("NV_NoiCapCMND").ToString()
                ngaycmnd = Temp2.Rows(0).Item("NV_NgayCapCMND").ToString
                dNgaycmnd = Date.Parse(ngaycmnd)
                Me.lblNgayCapCMND.Text = dNgaycmnd

                Me.lblGioiTinh.Text = Temp2.Rows(0).Item("NV_GioiTinh").ToString()
                Me.lblsdt.Text = Temp2.Rows(0).Item("NV_DTDiDong").ToString()
                'Me.txtDT.Text = Temp2.Rows(0).Item("SDT_QH").ToString()
                'khoa
                'Me.txtManvTab2.ReadOnly = True
                Me.txtTenTab2.ReadOnly = True
                Me.dtpNgayVaoTab2.ReadOnly = True
                Me.txtDiachitab2.ReadOnly = True
                Me.txtDVTab2.ReadOnly = True
                Me.txtCVtab2.ReadOnly = True
                Me.txtChucVutab2.ReadOnly = True
                Me.txtchuyenmon.ReadOnly = True
                'Me.dtpNgaysinhtab2.ReadOnly = True
                Me.dtpNgaysinhtab2.Enabled = False
                Me.dtpNgaykyHD.ReadOnly = True
                Me.txtMucluongtab2.ReadOnly = True
                Me.Picturetab2.Image = Nothing
                Me.chkXemHinhtab2.Checked = False
                Me.GroupBox1.Enabled = True '
                Me.dtpNgayCapQH.Enabled = False
                Me.dtpNgayCapQH.Text = Nothing
                Me.txtSoThe.Enabled = False
                Me.btXoa.Enabled = False
                Me.btXem.Enabled = True

                obj.ChonBang = 30
                'Load Don Vi
                Me.b = New clsBCapNhatHoSoQuanHe
                Me.cbMoiQH.DataSource = Me.b.LoadDS(obj)
                Me.cbMoiQH.DisplayMember() = "TEN_QH"
                Me.cbMoiQH.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

                obj.ChonBang = 35
                'Load Don Vi
                Me.b = New clsBCapNhatHoSoQuanHe
                Me.cbChuHo.DataSource = Me.b.LoadDS(obj)
                Me.cbChuHo.DisplayMember() = "TENQH_CHUHO"
                Me.cbChuHo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
                Me.methodLoad2()

                obj.ChonBang = 37
                Dim Temp37 As New DataTable
                Me.b = New clsBCapNhatHoSoQuanHe
                Temp37 = Me.b.LoadDS(obj)
                Me.txtKhaiSinh.Text = Temp37.Rows(0).Item("NOIKHAISINH").ToString()

            End If
        End If
        'End Select
    End Sub
    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Dim b As New clsBCapNhatHoSoQuanHe
        Me.Path = "/layout/CapNhatHoSoNhanSuQuanHe.xml"
        obj.SetnullQH()

        obj.ChonBang = 33
        obj.MaNVQH = Me.txtManvTab2.Text.Trim()
        Me.dgrBC.DataSource = Nothing
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")

    End Sub
    Public Sub TrangThaiThemMoi()
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 1
        Me.cbMoiQH.Clear()
        Me.cbChuHo.Clear()
        Me.txtTenNVQH.Clear()
        Me.dtpNgaySinhQH.Text = Now
        Me.txtTenThuongGoi.Clear()
        Me.txtNgheNghiep.Clear()
        Me.txtNoiCongTac.Clear()
        Me.txtDiaChiQH.Clear()
        Me.txtSoCMNDQH.Clear()
        Me.txtDT.Clear()
        Me.dtpNgayCapQH.Text = Nothing
        Me.txtCapTai.Clear()
        Me.chkColamviec.Checked = False
        Me.rdNam.Checked = True
        Me.radNu.Checked = False
        ' Me.txtSoSoHK.Clear()
        Me.txtSoThe.Clear()
        Me.cbMoiQH.ReadOnly = False
        Me.cbChuHo.ReadOnly = False
        Me.btThem.Enabled = True
        Me.btCapNhat.Enabled = False
        Me.btXoa.Enabled = False
        Me.cbMoiQH.Enabled = True
        Me.cbChuHo.Enabled = True
        ''========== Mặc định chọn ngày sinh quan hệ=======''
        Me.chkNamSinhQH.Enabled = True
        Me.chkNamSinhQH.Checked = False
        Me.dtpNgaySinhQH.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgaySinhQH.Format = DateTimePickerFormat.Custom
        Me.dtpNgaySinhQH.ShowUpDown = False
        Me.txtDiaChiQH.Text = Me.txtDiachitab2.Text
        'End Select
    End Sub

    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 0
        '    Case 1
        Dim report As New FrmReport
        Me.ReportID = "1004"
        report.reportID = Me.ReportID
        Dim strArray As String() = New String() {Me.txtManvTab2.Text}
        report.para = strArray
        report.issysReport = True
        report.Show()
        ' Case 2
        'End Select
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New frmDanhMucMoiQuanHe
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub
    Private Sub cbMoiQH_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbMoiQH.BeforeDropDown
        obj.ChonBang = 30
        'Load Don Vi
        Me.b = New clsBCapNhatHoSoQuanHe
        Me.cbMoiQH.DataSource = Me.b.LoadDS(obj)
        Me.cbMoiQH.DisplayMember() = "TEN_QH"
        Me.cbMoiQH.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub
    Private Sub cbChuHo_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbChuHo.BeforeDropDown
        obj.ChonBang = 35
        'Load Don Vi  
        Me.b = New clsBCapNhatHoSoQuanHe
        Me.cbChuHo.DataSource = Me.b.LoadDS(obj)
        Me.cbChuHo.DisplayMember() = "TENQH_CHUHO"
        Me.cbChuHo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub Format_NamSinh()
        ''======= tab moi quan he cua nhan vien =====''
        Me.dtpNgaySinhQH.Format = DateTimePickerFormat.Custom
        If Me.dtpNgaySinhQH.Text.ToString() <> "" Then
            If Me.chkNamSinhQH.Checked Then
                Me.dtpNgaySinhQH.CustomFormat = "yyyy"
                Me.lblNgaysinhQH.Text = "Năm sinh :"
                bNamSinhQH = True
                dtpNgaySinhQH.ShowUpDown = True
            Else
                bNamSinhQH = False
                Me.dtpNgaySinhQH.CustomFormat = "dd/MM/yyyy"
                Me.lblNgaysinhQH.Text = "Ngày sinh :"
                dtpNgaySinhQH.ShowUpDown = False
            End If
        Else
            Me.chkNamSinhQH.Checked = False
            Me.dtpNgaySinhQH.CustomFormat = "dd/MM/yyyy"
            Me.lblNgaysinhQH.Text = "Ngày sinh :"
            dtpNgaySinhQH.ShowUpDown = False
            bNamSinhQH = False
        End If
    End Sub
    Private Sub chkNamSinhQH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNamSinhQH.CheckedChanged
        Format_NamSinh()
    End Sub

    Private Sub txtSoCMNDQH_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoCMNDQH.ValueChanged
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 0
        '    Case 1
        If Me.txtSoCMNDQH.Text = "" Then
            Me.dtpNgayCapQH.Enabled = False
            Me.dtpNgayCapQH.Text = Nothing
            Me.txtCapTai.Enabled = False
            Me.txtCapTai.Text = ""
        Else
            Me.dtpNgayCapQH.Enabled = True
            Me.dtpNgayCapQH.Text = Now
            Me.txtCapTai.Enabled = True
        End If
        'End Select
    End Sub

    Private Sub chkColamviec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkColamviec.CheckedChanged
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 0

        '    Case 1
        If Me.chkColamviec.Checked = True Then
            Me.txtSoThe.Enabled = True
        Else
            Me.txtSoThe.Enabled = False
            Me.txtSoThe.Text = ""
        End If
        'End Select
    End Sub

    Private Sub txtSoThe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoThe.KeyPress
        'Select Case tabCapNhatHoSo.SelectedTab.Index
        '    Case 0
        '    Case 1
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
        'End Select
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBCapNhatHoSoQuanHe
        Me.Path = "/layout/CapNhatHoSoNhanSuQuanHe.xml"
        obj.ChonBang = 27
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub
    Public Sub LuuDuLieuQH()
        Dim manv As String
        Dim maqh As String
        Dim hotenqh As String

        Dim ngaySqh As Date
        Dim ngaysinhqh As String
        Dim chonnamsinhqh As Integer

        Dim namS As String
        Dim ngayS As Date
        Dim ngaysinhquanhe As String

        ''============ cho phép cập nhật năm sinh quan hệ =======''
        'Dim namS As String
        'Dim ngayS As Date

        'If chonnamsinh = 1 Then
        '    namS = Me.dtpNgaysinh.Text
        '    ngaysinh = namS + "/" + "01" + "/" + "01"
        'Else
        '    ngayS = Me.dtpNgaysinh.Text
        '    ngaysinh = ngayS.Year.ToString() + "/" + ngayS.Month.ToString() + "/" + ngayS.Day.ToString()
        'End If

        If Me.chkNamSinhQH.Checked Then
            chonnamsinhqh = 1
        Else
            chonnamsinhqh = 0
        End If

        ''=========== đổi tạm kiểu format datetimepicker =======''
        Me.dtpNgaySinhQH.CustomFormat = "dd-MM-yyyy"
        If chonnamsinhqh = 1 Then
            ngaysinhquanhe = DoiDinhDangNgay(dtpNgaySinhQH.Text.ToString()).Replace("-", "/")
            ngayS = Date.Parse(ngaysinhquanhe)
            namS = ngayS.Year.ToString()
            ngaysinhqh = namS + "/" + "01" + "/" + "01"
        Else
            ngaysinhquanhe = DoiDinhDangNgay(dtpNgaySinhQH.Text.ToString()).Replace("-", "/")
            ngayS = Date.Parse(ngaysinhquanhe)
            ngaysinhqh = ngayS.Year.ToString() + "/" + ngayS.Month.ToString() + "/" + ngayS.Day.ToString()
        End If

        'If Me.dtpNgaySinhQH.Text = Nothing Then
        '    ngaysinhqh = "NULL"
        'Else
        '    ngaySqh = Me.dtpNgaySinhQH.Text
        '    ngaysinhqh = ngaySqh.Year.ToString() + "/" + ngaySqh.Month.ToString() + "/" + ngaySqh.Day.ToString()
        'End If

        Dim tenthuonggoi As String
        Dim nghenghiep As String
        Dim noicongtac As String
        Dim diachiqh As String
        Dim socmndqh As String
        Dim ngaycqh As Date
        Dim ngaycapqh As String
        Dim gioitinh As Integer
        Dim sosoHK As String
        Dim MaQHChuHo As String
        Dim noicapkhaisinh As String
        Dim sdt As String
        If Me.dtpNgayCapQH.Text = Nothing Then
            ngaycapqh = "NULL"
        Else
            ngaycqh = Me.dtpNgayCapQH.Text
            ngaycapqh = "'" + ngaycqh.Year.ToString() + "/" + ngaycqh.Month.ToString() + "/" + ngaycqh.Day.ToString() + "'"
        End If

        Dim captai As String
        Dim sothe As String
        Dim colamviec As Integer
        Dim sott As Integer

        ' obj.SetnullQH()
        manv = Me.txtManvTab2.Text
        maqh = Me.cbMoiQH.Value
        hotenqh = Me.txtTenNVQH.Text
        tenthuonggoi = Me.txtTenThuongGoi.Text
        nghenghiep = Me.txtNgheNghiep.Text
        noicongtac = Me.txtNoiCongTac.Text
        diachiqh = Me.txtDiaChiQH.Text
        socmndqh = Me.txtSoCMNDQH.Text
        captai = Me.txtCapTai.Text
        sothe = Me.txtSoThe.Text
        sosoHK = Me.txtSoSoHK.Text
        MaQHChuHo = Me.cbChuHo.Value
        noicapkhaisinh = Me.txtKhaiSinh.Text
        sdt = Me.txtDT.Text
        If Me.chkColamviec.Checked = True Then
            colamviec = 1
        Else
            colamviec = 0
        End If
        If Me.rdNam.Checked Then
            gioitinh = 1

        Else
            gioitinh = 0
        End If

        ' Kiem tra ma qh
        If (StringType.StrCmp(Me.cbMoiQH.Text, "", False) = 0) Then
            MessageBox.Show(" Chưa nhập mã quan hệ", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Kiem tra ma qh voi chu ho
        If (StringType.StrCmp(Me.cbChuHo.Text, "", False) = 0) Then
            MessageBox.Show(" Chưa nhập mã quan hệ với chủ hộ", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ' Kiem tra ngay sinh quan he bỏ trống
        If (StringType.StrCmp(Me.dtpNgaySinhQH.Text, "", False) = 0) Then
            MessageBox.Show(" Chưa chọn ngày sinh quan hệ", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.rdNam.Checked = False And Me.rdNu.Checked = False Then
            MessageBox.Show(" Chưa chọn giới tính", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

        obj.ChonBang = 32
        Dim Temp1 As New DataTable
        Me.b = New clsBCapNhatHoSoQuanHe
        obj.Table = "IT_NHANVIENQUANHE"
        Temp1 = Nothing
        Temp1 = Me.b.LoadDS(obj)

        If Temp1.Rows.Count = 0 Then
            sott = 1
        Else
            sott = Temp1.Rows.Count + 1
        End If
        obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

        ' tao bang tam
        Dim flag As Boolean
        flag = False

        obj.ChonBang = 28
        Dim Temp As New DataTable
        Me.b = New clsBCapNhatHoSoQuanHe
        obj.Table = "IT_NHANVIENQUANHE"
        Temp = Nothing
        obj.MaNVQH = Me.txtManvTab2.Text
        obj.MaQH = Me.cbMoiQH.Value
        '  obj.SoTT = Temp1.Rows.Count
        obj.SoTT = sott ''======= 

        ' THEM KHOA CHINH STT
        Temp = Me.b.LoadDS(obj)
        ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
        If Temp.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = False Then
            If Temp1.Rows.Count = 0 Then
                sott = 1
            Else
                sott = Temp1.Rows.Count + 1
            End If
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)
            obj.MaNVQH = Me.txtManvTab2.Text
            obj.MaQH = Me.cbMoiQH.Value
            obj.MaQHCHUHO = Me.cbChuHo.Value
            obj.GioiTinhqh = gioitinh
            obj.SoSoHK = sosoHK


            'Kiểm tra có nhập 2 dòng chủ hộ hay k
            Dim Temp2 As New DataTable
            obj.ChonBang = 36
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)
            Temp2 = Me.b.LoadDS(obj)
            If Temp2.Rows.Count > 0 And obj.MaQHCHUHO = "CHUHO" Then
                MessageBox.Show("Đã có chủ hộ , vui lòng xoá chủ hộ hiện tại để thêm mới chủ hộ !")
                Exit Sub
            Else

            End If
            obj.ChonBang = 2
            Me.b = New clsBCapNhatHoSoQuanHe
            If Me.b.InsertInfo(obj) Then
                MessageBox.Show("Đã Lưu Thành Công")
            Else
                MessageBox.Show("Không thể thêm quan hệ.")
            End If
            ''======= chi load lai quan he cua so the vua nhap ========='' 
            ''Me.methodLoad()
            Me.methodLoad2()

        Else
            If Temp1.Rows.Count = 0 Then
                sott = 1
            Else
                sott = Temp1.Rows.Count + 1
            End If
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)
            'obj.MaNVQH = Me.txtManvTab2.Text
            'obj.MaQH = Me.cbMoiQH.Value
            'obj.MaQHCHUHO = Me.cbChuHo.Value
            'obj.GioiTinhqh = gioitinh
            'obj.SoSoHK = sosoHK
            'Kiểm tra có nhập 2 dòng chủ hộ hay k
            Dim Temp2 As New DataTable
            obj.ChonBang = 36
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, sott, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, sothe, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)
            Temp2 = Me.b.LoadDS(obj)
            If Temp2.Rows.Count > 0 Then
                MessageBox.Show("Đã có chủ hộ , vui lòng xoá chủ hộ hiện tại để thêm mới chủ hộ !")
                Exit Sub
            Else

            End If




            '-------------------------------------
            obj.ChonBang = 2
            Me.b = New clsBCapNhatHoSoQuanHe
            obj.GioiTinhqh = gioitinh
            If Me.b.InsertInfo(obj) Then
                MessageBox.Show("Đã Lưu Thành Công")
            Else
                MessageBox.Show("Không thể thêm quan hệ.")
            End If

            '' Me.methodLoad()
            Me.methodLoad2()
        End If
        Me.TrangThaiThemMoi()
    End Sub
    Private Sub btThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThem.Activate
        Me.LuuDuLieuQH()
    End Sub
    Private Sub btCapNhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Activate
        Me.CapNhatQH()
    End Sub
    Public Sub CapNhatQH()
        Dim manv As String
        Dim maqh As String
        Dim hotenqh As String

        Dim ngaySqh As Date
        'ngaySqh = Me.dtpNgaySinhQH.Text
        Dim ngaysinhqh As String
        Dim chonnamsinhqh As Integer

        Dim namS As String
        Dim ngayS As Date
        'Dim ngaysinhqh As String = ngaySqh.Year.ToString() + "/" + ngaySqh.Month.ToString() + "/" + ngaySqh.Day.ToString()

        Dim tenthuonggoi As String
        Dim nghenghiep As String
        Dim noicongtac As String
        Dim diachiqh As String
        Dim socmndqh As String

        Dim ngaycqh As Date
        Dim ngaycapqh As String
        Dim gioitinh As Integer
        Dim sosoHK As String
        Dim MaQHChuHo As String
        Dim noicapkhaisinh As String
        Dim sdt As String
        If Me.dtpNgayCapQH.Text = Nothing Then
            ngaycapqh = "NULL"
        Else
            ngaycqh = Me.dtpNgayCapQH.Text
            ngaycapqh = "'" + ngaycqh.Year.ToString() + "/" + ngaycqh.Month.ToString() + "/" + ngaycqh.Day.ToString() + "'"
        End If

        Dim captai As String
        Dim SOTT As Integer
        Dim SOTHE As String
        Dim colamviec As Integer
        ' obj.SetnullQH()
        manv = Me.txtManvTab2.Text
        maqh = Me.cbMoiQH.Value
        hotenqh = Me.txtTenNVQH.Text
        tenthuonggoi = Me.txtTenThuongGoi.Text
        nghenghiep = Me.txtNgheNghiep.Text
        noicongtac = Me.txtNoiCongTac.Text
        diachiqh = Me.txtDiaChiQH.Text
        socmndqh = Me.txtSoCMNDQH.Text
        captai = Me.txtCapTai.Text
        SOTHE = Me.txtSoThe.Text
        sosoHK = Me.txtSoSoHK.Text
        MaQHChuHo = Me.cbChuHo.Value
        noicapkhaisinh = Me.txtKhaiSinh.Text
        sdt = Me.txtDT.Text
        If Me.rdNam.Checked Then
            gioitinh = 1
        Else
            gioitinh = 0
        End If
        If Me.chkColamviec.Checked = True Then
            colamviec = 1
        Else
            colamviec = 0
        End If
        If Me.chkNamSinhQH.Checked Then
            chonnamsinhqh = 1
        Else
            chonnamsinhqh = 0
        End If

        If chonnamsinhqh = 1 Then
            namS = Me.dtpNgaySinhQH.Text
            ngaysinhqh = namS + "/" + "01" + "/" + "01"
        Else
            ngayS = Me.dtpNgaySinhQH.Text
            ngaysinhqh = ngayS.Year.ToString() + "/" + ngayS.Month.ToString() + "/" + ngayS.Day.ToString()
        End If

        ' Kiem tra ma qh
        If (StringType.StrCmp(Me.cbMoiQH.Text, "", False) = 0) Then
            MessageBox.Show(" Chưa nhập mã quan hệ", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Kiem tra khong chon ngay sinh
        If (StringType.StrCmp(Me.dtpNgaySinhQH.Text, "", False) = 0) Then
            MessageBox.Show(" Chưa chọn ngày sinh quan hệ.", "Th" & ChrW(244) & "ng b" & ChrW(225) & "o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)


        ' tao bang tam
        Dim flag As Boolean
        flag = False

        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        SOTT = activeRow.Cells.Item("STT").Value.ToString
        ' kiem tra loai quan he
        obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

        obj.ChonBang = 28
        Dim Temp As New DataTable
        Me.b = New clsBCapNhatHoSoQuanHe
        obj.Table = "IT_NHANVIENQUANHE"
        Temp = Nothing
        'obj.MaNVQH = Me.txtManvTab2.Text
        'obj.MaQH = activeRow.Cells.Item("MA_QH").Value.ToString
        'obj.SoTTLUOI = activeRow.Cells.Item("STT").Value.ToString
        Temp = Me.b.LoadDS(obj)

        ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
        If Temp.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = False Then
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

            'MessageBox.Show("Người này chưa có, bạn không được sửa")
            obj.ChonBang = 29
            Dim Temp2 As New DataTable
            Me.b = New clsBCapNhatHoSoQuanHe
            obj.Table = "IT_NHANVIENQUANHE"
            Temp2 = Nothing
            obj.MaNVQH = Me.txtManvTab2.Text
            obj.MaQH = Me.cbMoiQH.Text
            Temp2 = Me.b.LoadDS(obj)

            Dim flag1 As Boolean
            flag1 = False
            If Temp2.Rows.Count > 0 Then
                flag1 = True
            Else
                flag1 = False
            End If
            If flag1 = True Then
                If maqh = activeRow.Cells.Item("MA_QH").Value.ToString And SOTT = activeRow.Cells.Item("STT").Value.ToString Then
                    obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

                    obj.ChonBang = 29
                    'obj.MaQHLUOI = activeRow.Cells.Item("MA_QH").Value.ToString
                    'obj.SoTTLUOI = activeRow.Cells.Item("STT").Value.ToString
                    Me.b = New clsBCapNhatHoSoQuanHe
                    If (MessageBox.Show("Bạn có muốn cập nhật mối quan hệ: " & activeRow.Cells.Item("MA_QH").Text.ToString & " cho số thẻ " & obj.MaNVQH & " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        If Me.b.UpdateInfo(obj) = False Then
                            MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Đã cập nhật thành công.")
                        End If
                    End If
                    'Me.methodLoad()
                    Me.methodLoad2()
                Else
                    MessageBox.Show("Mối quan hệ của người này đã có")
                    Exit Sub
                End If
            Else
                obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

                obj.ChonBang = 29
                obj.MaQHLUOI = activeRow.Cells.Item("MA_QH").Value.ToString
                obj.SoTTLUOI = activeRow.Cells.Item("STT").Value.ToString
                Me.b = New clsBCapNhatHoSoQuanHe
                If (MessageBox.Show("Bạn có muốn cập nhật mối quan hệ: " & activeRow.Cells.Item("MA_QH").Text.ToString & " cho số thẻ " & obj.MaNVQH & " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    If Me.b.UpdateInfo(obj) = False Then
                        MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Đã cập nhật thành công.")
                    End If
                End If
                ' Me.methodLoad()
                Me.methodLoad2()

            End If
        Else
            obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

            obj.ChonBang = 29
            Dim Temp2 As New DataTable
            Me.b = New clsBCapNhatHoSoQuanHe
            obj.Table = "IT_NHANVIENQUANHE"
            Temp2 = Nothing
            obj.MaNVQH = Me.txtManvTab2.Text
            obj.MaQH = Me.cbMoiQH.Text
            Temp2 = Me.b.LoadDS(obj)

            Dim flag1 As Boolean
            flag1 = False
            If Temp2.Rows.Count > 0 Then
                flag1 = True
            Else
                flag1 = False
            End If
            If flag1 = True Then
                If maqh = activeRow.Cells.Item("MA_QH").Value.ToString And SOTT = activeRow.Cells.Item("STT").Value.ToString Then
                    obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

                    obj.ChonBang = 29
                    obj.MaQHLUOI = activeRow.Cells.Item("MA_QH").Value.ToString
                    obj.SoTTLUOI = activeRow.Cells.Item("STT").Value.ToString
                    Me.b = New clsBCapNhatHoSoQuanHe
                    If (MessageBox.Show("Bạn có muốn cập nhật mối quan hệ: " & activeRow.Cells.Item("MA_QH").Text.ToString & " cho số thẻ " & obj.MaNVQH & " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        If Me.b.UpdateInfo(obj) = False Then
                            MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Đã cập nhật thành công.")
                        End If
                    End If
                    '' Me.methodLoad()
                    Me.methodLoad2()
                Else
                    MessageBox.Show("Mối quan hệ của người này đã có")
                    Exit Sub
                End If
            Else
                obj.setvalueQH("", "IT_NHANVIENQUANHE", manv, maqh, SOTT, hotenqh, ngaysinhqh, chonnamsinhqh, tenthuonggoi, nghenghiep, noicongtac, diachiqh, socmndqh, ngaycapqh, captai, SOTHE, colamviec, 0, sosoHK, gioitinh, MaQHChuHo, noicapkhaisinh, sdt)

                obj.ChonBang = 29
                obj.MaQHLUOI = activeRow.Cells.Item("MA_QH").Value.ToString
                obj.SoTTLUOI = activeRow.Cells.Item("STT").Value.ToString
                Me.b = New clsBCapNhatHoSoQuanHe
                If (MessageBox.Show("Bạn có muốn cập nhật mối quan hệ: " & activeRow.Cells.Item("MA_QH").Text.ToString & " cho số thẻ " & obj.MaNVQH & " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    If Me.b.UpdateInfo(obj) = False Then
                        MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Đã cập nhật thành công.")
                    End If
                End If
                ''Me.methodLoad()
                Me.methodLoad2()
                MessageBox.Show("Đã cập nhật thành công")
            End If
        End If
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jFunction As New objCapNhatHoSoQuanHe
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim ma As String
                Dim moiqh As String
                Dim STT As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        ma = StringType.FromObject(activeRow.Cells.Item("NV_MA").Value)
                        moiqh = StringType.FromObject(activeRow.Cells.Item("MA_QH").Value)
                        STT = StringType.FromObject(activeRow.Cells.Item("STT").Value)
                        jFunction.MaNVQH = ma
                        jFunction.MaQH = moiqh
                        jFunction.SoTT = STT

                        If jFunction.MaNVQH = ma And jFunction.MaQH = moiqh And jFunction.SoTT = STT Then
                            If (MessageBox.Show(("Bạn có muốn xóa mối quan hệ: " & moiqh & " của nhân viên có số thẻ " & ma & " thứ  " & STT & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo(jFunction) Then
                                    MessageBox.Show("Đã xóa thành công")
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không được xóa nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                'Return
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nhân viên đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    ma = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("NV_MA").Value)
                    moiqh = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("MA_QH").Value)
                    STT = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("STT").Value)
                    If Me.b.DeleteInfo(jFunction) Then
                        MessageBox.Show("Đã xóa thành công")
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:
            jFunction.Setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jFunction)
            Me.methodLoad2()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        Me.XoaDuLieu()
        Me.TrangThaiThemMoi()
        Me.methodLoad2()
    End Sub
    Private Sub ChonDong()
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        If Not activeRow Is Nothing Then
            If activeRow.Index <> -1 Then
                Me.dgrBC.Rows(activeRow.Index).Activated = True
                Me.dgrBC.Rows(activeRow.Index).Selected = True
                Me.oldRow = activeRow.Index

            End If
        End If
    End Sub
    Public Sub HieuChinh()
        Try
            Dim dNgaysinhQH As Date
            Dim ngaysinhQH As String
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                ''========= lay so the co nhan than vua chon ========''
                Me.txtManvTab2.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.cbMoiQH.Text = activeRow.Cells.Item("MA_QH").Value.ToString
                Me.cbChuHo.Text = activeRow.Cells.Item("MA_QHCHUHO").Value.ToString
                Me.txtTenNVQH.Text = activeRow.Cells.Item("NV_TEN").Value.ToString
                Me.txtKhaiSinh.Text = activeRow.Cells.Item("NOICAPKHAISINH_QH").Value.ToString
                ''========= hien thi nam sinh hoac ngay sinh=======''
                If activeRow.Cells.Item("NVQH_NAMSINH").Value.ToString = Nothing Then
                    ngaysinhQH = DoiDinhDangNgay(activeRow.Cells.Item("NGAYSINH_QH").Value.ToString())
                    dNgaysinhQH = Date.Parse(ngaysinhQH)
                    Me.dtpNgaySinhQH.Text = dNgaysinhQH
                    dtpNgaySinhQH.CustomFormat = "dd/MM/yyyy"
                    Me.chkNamSinhQH.Checked = False
                ElseIf activeRow.Cells.Item("NVQH_NAMSINH").Value.ToString = True Then
                    ''======= format định dạng cột ngày sinh thực tế =========''
                    dNgaysinhQH = Date.Parse(activeRow.Cells.Item("NGAYSINH_QHTT").Value.ToString())
                    ngaysinhQH = dNgaysinhQH.Year.ToString()
                    Me.dtpNgaySinhQH.Text = dNgaysinhQH
                    dtpNgaySinhQH.CustomFormat = "yyyy"
                    Me.chkNamSinhQH.Checked = True
                Else
                    ngaysinhQH = DoiDinhDangNgay(activeRow.Cells.Item("NGAYSINH_QH").Value.ToString())
                    dNgaysinhQH = Date.Parse(ngaysinhQH)
                    Me.dtpNgaySinhQH.Text = dNgaysinhQH
                    dtpNgaySinhQH.CustomFormat = "dd/MM/yyyy"
                    Me.chkNamSinhQH.Checked = False
                End If

                'Me.dtpNgaySinhQH.Text = activeRow.Cells.Item("NGAYSINH_QH").Value.ToString
                Me.txtTenThuongGoi.Text = activeRow.Cells.Item("TENTHUONGGOI").Value.ToString
                Me.txtNgheNghiep.Text = activeRow.Cells.Item("NGHENGHIEP_QH").Value.ToString
                Me.txtNoiCongTac.Text = activeRow.Cells.Item("NOICONGTAC").Value.ToString
                Me.txtDiaChiQH.Text = activeRow.Cells.Item("DIACHI_QH").Value.ToString
                Me.txtSoCMNDQH.Text = activeRow.Cells.Item("SOCMND_QH").Value.ToString
                Me.dtpNgayCapQH.Text = activeRow.Cells.Item("NGAYCAP_QH").Value.ToString
                Me.txtSoThe.Text = activeRow.Cells.Item("SOTHE").Value.ToString
                Me.txtCapTai.Text = activeRow.Cells.Item("TAI_QH").Value.ToString
                Me.txtDT.Text = activeRow.Cells.Item("SDT_QH").Value.ToString
                Me.txtSoSoHK.Text = activeRow.Cells.Item("SOSOHK_QH").Value.ToString
                If activeRow.Cells.Item("COLAMVIEC").Value.ToString = Nothing Then
                    Me.chkColamviec.Checked = False
                ElseIf activeRow.Cells.Item("COLAMVIEC").Value.ToString = True Then
                    Me.chkColamviec.Checked = True
                Else
                    Me.chkColamviec.Checked = False
                End If

                If activeRow.Cells.Item("GIOITINH_QH").Value.ToString = "" Then
                    Me.rdNam.Checked = False
                    Me.rdNu.Checked = False
                ElseIf activeRow.Cells.Item("GIOITINH_QH").Value.ToString = "False" Then

                    Me.rdNu.Checked = True
                    'Me.txtSoThe.Text = activeRow.Cells.Item("GIOITINH_QH").Value.ToString
                Else
                    Me.rdNam.Checked = True
                    ' Me.txtSoThe.Text = activeRow.Cells.Item("GIOITINH_QH").Value.ToString

                End If

                Me.cbMoiQH.Enabled = False
                Me.cbChuHo.Enabled = False

            End If
            Me.flag = 1
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub

    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        ''==================
        Me.HieuChinh()
        Me.btCapNhat.Enabled = True
        Me.btThem.Enabled = False
        Me.btXoa.Enabled = True
        Me.cbMoiQH.ReadOnly = True
        Me.cbChuHo.ReadOnly = True
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.TrangThaiThemMoi()
        Me.btCapNhat.Enabled = False
        Me.btThem.Enabled = True
        Me.btXoa.Enabled = False
        Me.cbMoiQH.ReadOnly = False
        Me.cbChuHo.ReadOnly = False
        Me.dtpNgayCapQH.Text = Nothing
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        ' Khoa cot
        Dim i As Integer

        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next
    End Sub
    Private Sub btnXemMoiQH_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        methodLoad()
    End Sub

    Private Sub Label44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label44.Click

    End Sub


    Private Sub rdNam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNam.CheckedChanged
        If Me.radNam.Checked Then
            Me.radNu.Checked = False
        End If
    End Sub

    Private Sub rdNu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNu.CheckedChanged
        If Me.radNu.Checked Then
            Me.radNam.Checked = False
        End If
    End Sub

    Private Sub cbChuHo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChuHo.ValueChanged
        'obj.ChonBang = 35
        'Load Don Vi
        'Me.b = New clsBCapNhatHoSoQuanHe
        'Me.cbChuHo.DataSource = Me.b.LoadDS(obj)
        'Me.cbChuHo.DisplayMember() = "TENQH_CHUHO"
        'Me.cbChuHo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

    End Sub


    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        TrangThaiThemMoi()
    End Sub

    Private Sub txtDiaChiQH_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiaChiQH.ValueChanged

    End Sub
    Private Sub Label47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label47.Click

    End Sub

    Private Sub cbMoiQH_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoiQH.ValueChanged
        If Me.cbMoiQH.Value = "CHUHO" Then
            Me.cbChuHo.Value = "CHUHO"
            Me.txtTenNVQH.Text = Me.txtTenTab2.Text
            Me.dtpNgaySinhQH.Value = Me.dtpNgaysinhtab2.Value
            Me.txtSoCMNDQH.Text = Me.lblcmnd.Text
            Me.dtpNgayCapQH.Text = lblNgayCapCMND.Text
            dtpNgayCapQH.FormatString = "dd/MM/yyyy"
            Me.txtCapTai.Text = Me.lblNoiCapCMND.Text
            If Me.lblGioiTinh.Text = "False" Then
                Me.rdNu.Checked = True
            ElseIf Me.lblGioiTinh.Text = "True" Then
                Me.rdNam.Checked = True
            Else

            End If
            Me.chkColamviec.Checked = True
            Me.txtSoThe.Text = Me.txtManvTab2.Text
            Me.txtDT.Text = Me.lblsdt.Text
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frm As New frmDanhMucMoiQuanHeChuHo
        frm.WindowState = FormWindowState.Normal
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub txtTenThuongGoi_AfterExitEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTenThuongGoi.AfterExitEditMode
        Me.txtTenThuongGoi.Text = txtTenThuongGoi.Text.ToUpper()
    End Sub

    Private Sub txtTenNVQH_AfterExitEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTenNVQH.AfterExitEditMode
        Me.txtTenNVQH.Text = txtTenNVQH.Text.ToUpper()
    End Sub
End Class