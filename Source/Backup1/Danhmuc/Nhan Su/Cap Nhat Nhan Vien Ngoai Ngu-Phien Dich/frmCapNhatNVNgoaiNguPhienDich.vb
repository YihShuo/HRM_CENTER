Imports Infragistics.Win
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
Imports Infragistics.Excel

''' Nội dung: Chỉnh sửa giao diện cho phù hợp,chỉnh sửa báo cáo,bổ sung lọc thêm cán bộ ===============
''' Ngày:28/03/2015
''' Người cập nhật: Trân
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Imports System.Xml
Public Class frmCapNhatNVNgoaiNguPhienDich
    Friend WithEvents b As clsBCapNhatNVNgoaiNguPhienDich
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Shared obj As New objCapNhatNVNgoaiNguPhienDich
    Public bChonCapNhat As Boolean = False
    Public bCVPhiendich As Boolean = False
    Public bChonxemluoi As Boolean = False
    Dim i As Integer
    Private Sub frmCapNhatNVNgoaiNguPhienDich_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCombo()
        An()
        Me.txtMa.Focus()
        Me.btnXem.Enabled = True
        Me.radLoaiPD.CheckedIndex = 0
        LoadDSPhienDich()
        Me.txtMa.MaxLength = 6
    End Sub
    Private Sub LoadCombo()
        Dim tblComoNVNN, tblComboNNPD As DataTable
        Dim obj As New objCapNhatNVNgoaiNguPhienDich
        Me.b = New clsBCapNhatNVNgoaiNguPhienDich
        Dim i As Integer = 2008
        obj.ChonBang = 3
        Me.cbLoai.ValueMember = "NN_MA"
        Me.cbLoai.DisplayMember = "NN_TEN"
        tblComoNVNN = Me.b.LoadDS(obj)
        If tblComoNVNN.Rows.Count > 0 Then
            Me.cbLoai.DataSource = tblComoNVNN
            Me.cbLoai.Enabled = True
            Me.cbLoai.SelectedIndex = 0
        Else
            Me.cbLoai.DataSource = Nothing
            Me.cbLoai.Enabled = False
        End If
        ''=========== năm =========''
        Me.cboNam.Items.Clear()
        Me.cboNam.Items.Add(Now.Date.Year.ToString())
        i = Now.Date.Year - 1
        While (i > 2008)
            Me.cboNam.Items.Add(i)
            i = i - 1
        End While
        If Me.cboNam.Items.Count > 0 Then
            Me.cboNam.SelectedIndex = 0

        Else
            Me.cboNam.SelectedIndex = -1
        End If
    End Sub
    Private Function KhoiTaoDulieuThongKe() As Boolean
        If Me.radKhuA.Checked Then
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            Dim bKhoitao As Boolean
            bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_THONGKENGOAINGU_TEST_KHUA")
            Return bKhoitao
        End If
        If Me.radKhuB.Checked Then
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            Dim bKhoitao As Boolean
            bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_THONGKENGOAINGU_TEST_KHUB")
            Return bKhoitao
        End If
        If Me.radKhuDVC.Checked Then
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            Dim bKhoitao As Boolean
            bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_THONGKENGOAINGU_TEST_KHUDVC")
            Return bKhoitao
        End If
        If Me.radTCT.Checked Then
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            Dim bKhoitao As Boolean
            bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_THONGKENGOAINGU_TEST")
            Return bKhoitao
        End If
    End Function
    Private Function KhoiTaoDuLieuChung() As Boolean
        Me.b = New clsBCapNhatNVNgoaiNguPhienDich
        Dim bKhoitao As Boolean
        bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_CHUNG_TKNNGU")
        Return bKhoitao
    End Function
    Private Function KhoiTaoDulieuThongKeThang() As Boolean
        Me.b = New clsBCapNhatNVNgoaiNguPhienDich
        Dim bKhoitao As Boolean
        bKhoitao = Me.b.KhoiTaoDL("SP_KHOITAODULIEU_THONGKENGOAINGUTHEOTHANG")
        Return bKhoitao
    End Function
    Private Function CapNhatXuong_TenTiengHoa() As Boolean
        Me.b = New clsBCapNhatNVNgoaiNguPhienDich
        Dim bKhoitao As Boolean
        bKhoitao = Me.b.CapNhatTen_MaXuong("SP_CAPNHATXUONG_TENHOA")
        Return bKhoitao
    End Function
    Private Sub txtMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.ValueChanged
        Dim tableNV, tableDVHT As DataTable
        Dim bNgoainguTA, bNgoainguTH, bNgoainguKhac, bNhanvien, bPhiendich, bThoiViec As Boolean
        Dim b As New clsBCapNhatNVNgoaiNguPhienDich
        Dim i As Integer
        bNgoainguTA = False
        bNhanvien = False
        bPhiendich = False
        bNgoainguTH = False
        bNgoainguKhac = False
        bCVPhiendich = False

        If Me.txtMa.TextLength = 6 Then

            obj.NV_MA = Me.txtMa.Text.Trim.ToString()
            ''=========tim nhan vien===========''
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            tableNV = Me.b.TimNV("SP_TIMNHANVIEN_NGOAINGU_SOTHE", obj.NV_MA)
            tableDVHT = Me.b.TimNV("SP_DONVIHT_NHANVIEN", obj.NV_MA)

            If tableNV.Rows.Count > 0 Then
                ''===== trag thai thoi viec =======
                If Convert.ToBoolean(tableNV.Rows(0).Item("DA_THOIVIEC")) Then
                    Me.chkThoiviec.Checked = True
                    Me.txtNgaythoiviec.Text = tableNV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()

                    Me.lblDVTruocKhiNghi.Visible = True
                    Me.lblDVTruocKhiNghi.Text = "Đơn vị trước khi nghỉ: " + tableNV.Rows(0).Item("DV_MA_").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()

                Else
                    Me.chkThoiviec.Checked = False
                    Me.txtNgaythoiviec.Text = ""
                    Me.lblDVTruocKhiNghi.Visible = False
                    Me.lblDVTruocKhiNghi.Text = "Đơn vị trước khi nghỉ: "
                    Me.txtDonvi.Text = tableDVHT.Rows(0).Item("DV_MA").ToString()

                End If

                Me.txtTen.Text = tableNV.Rows(0).Item("NV_TEN").ToString()
                Me.txtChucvu.Text = tableNV.Rows(0).Item("CVU_Ten").ToString
                Me.txtCongviec.Text = tableNV.Rows(0).Item("CV_TEN").ToString()
                Me.dtpNgayvao.Value = tableNV.Rows(0).Item("NV_Ngayvao").ToString()
                Me.txtHocvan.Text = tableNV.Rows(0).Item("HV_Ten").ToString()
                Me.txtChuyenmon.Text = tableNV.Rows(0).Item("CM_Ten").ToString()
                bCVPhiendich = Convert.ToBoolean(tableNV.Rows(0).Item("CV_PD")) ''====== danh dau dang lam cong viec phien dich

                bNgoainguTA = Convert.ToBoolean(tableNV.Rows(0).Item("NN_TA"))
                bNgoainguTH = Convert.ToBoolean(tableNV.Rows(0).Item("NN_TH"))
                bNgoainguKhac = Convert.ToBoolean(tableNV.Rows(0).Item("NN_KHAC"))
                bNhanvien = Convert.ToBoolean(tableNV.Rows(0).Item("NVBT"))  ''nhanvienbt
                bPhiendich = Convert.ToBoolean(tableNV.Rows(0).Item("PD"))  '' PHIEN DICH

                ''========= hien thi trang thai phien dich hoac nv ngoai ngu ==========''

                If bPhiendich Then
                    Me.radLoaiPD.CheckedIndex = 0
                End If

                If bNgoainguTA Then
                    Me.radLoaiPD.CheckedIndex = 1
                End If

                If bNgoainguTH Then
                    Me.radLoaiPD.CheckedIndex = 2
                End If

                If bNgoainguKhac Then
                    Me.radLoaiPD.CheckedIndex = 3
                    Me.cbLoai.DropDownStyle = DropDownStyle.DropDown
                    Me.cbLoai.Text = tableNV.Rows(0).Item("NN_MA")
                End If

                If bNhanvien Then
                    Me.radLoaiPD.CheckedIndex = 4
                End If

                ''=========== SAI DU LIEU HOAC CHUA CAP NHAT ========''
                If bPhiendich = False And bNgoainguTA = False And bNgoainguTH = False And bNgoainguKhac = False And bNhanvien = False Then
                    Me.radLoaiPD.CheckedIndex = 4 '' kchon cai nao mac dinh la nhan vien
                End If

                Me.radLoaiPD.Enabled = True
                Me.btnCapNhat.Enabled = True
                bChonCapNhat = True
                Me.btnXem.Enabled = True

            Else
                MessageBox.Show("Không tìm thấy số thẻ: " & Me.txtMa.Text & " trong hồ sơ nhân viên, không thể cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bChonCapNhat = False
                Me.btnCapNhat.Enabled = False
                Me.btnXem.Enabled = True
                ClearTT()
            End If
        End If
    End Sub
    Private Sub btnCapNhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapNhat.Activate
        If Me.txtMa.Text.Trim().Length = 6 And bChonCapNhat = True Then
            obj.NV_MA = txtMa.Text.Trim().ToString()
            Select Case Me.radLoaiPD.CheckedIndex
                Case 0
                    obj.NV_PhienDich = 1
                    obj.NV_NgoaiNgu_TA = 0
                    obj.NV_NgoaiNgu_TH = 0
                    obj.NV_NgoaiNgu_KH = 0
                    obj.LOAINGOAINGU = "PD"  ''mac dinh
                Case 1
                    obj.NV_PhienDich = 0
                    obj.NV_NgoaiNgu_TA = 1
                    obj.NV_NgoaiNgu_TH = 0
                    obj.NV_NgoaiNgu_KH = 0
                    obj.LOAINGOAINGU = "TIENGANH"
                Case 2
                    obj.NV_PhienDich = 0
                    obj.NV_NgoaiNgu_TA = 0
                    obj.NV_NgoaiNgu_TH = 1
                    obj.NV_NgoaiNgu_KH = 0
                    obj.LOAINGOAINGU = "TIENGHOA"
                Case 3
                    obj.NV_PhienDich = 0
                    obj.NV_NgoaiNgu_TA = 0
                    obj.NV_NgoaiNgu_TH = 0
                    obj.NV_NgoaiNgu_KH = 1
                    obj.LOAINGOAINGU = Me.cbLoai.Value.ToString()
                Case 4
                    obj.NV_PhienDich = 0
                    obj.NV_NgoaiNgu_TA = 0
                    obj.NV_NgoaiNgu_TH = 0
                    obj.NV_NgoaiNgu_KH = 0
                    obj.LOAINGOAINGU = ""
                Case Else
                    obj.NV_PhienDich = 0
                    obj.NV_NgoaiNgu_TA = 0
                    obj.NV_NgoaiNgu_TH = 0
                    obj.NV_NgoaiNgu_KH = 0
                    obj.LOAINGOAINGU = ""  ''mac dinh
            End Select
            If bCVPhiendich Then
                If Me.b.UpdateInfo(obj) Then
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ''xac nhan cap nhat neu lam cong viec khac phien dich==========
                If MessageBox.Show("Số thẻ hiện không làm công việc phiên dịch, câp nhật?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If Me.b.UpdateInfo(obj) Then
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else

                End If
            End If

            ClearTT()
            Me.txtMa.Focus()
            Me.btnXem.Enabled = False
            Me.bChonCapNhat = False
            Me.radLoaiPD.CheckedIndex = 0
            Me.LoadDSPhienDich()
        Else
            MessageBox.Show("Chưa nhập số thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub ClearTT()
        Me.txtMa.Clear()
        Me.txtTen.Clear()
        Me.txtCongviec.Clear()
        Me.txtChucvu.Clear()
        Me.dtpNgayvao.Text = ""
        Me.txtDonvi.Clear()
    End Sub
    Dim oldRow As Integer = 0
    Private Sub Laythongtin()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            Dim tableTam As DataTable
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMa.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                'If Me.txtMa.Text = "" Then
                '    obj.NV_MA_Luoi = ""
                '    Exit Sub
                'Else
                '    obj.NV_MA_Luoi = Me.txtMa.Text.ToString.Trim()
                '    obj.NV_MA = Me.txtMa.Text
                'End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub LaydulieuNgoaiNguHT(ByVal sDenngay As String)
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_NGAYVAO", sDenngay))
        Me.b.GoiThuTuc("SP_THONGKETINHHINH_NGOAINGU_DVHT_TEST", listpar)
        listpar.Clear()
    End Sub
    Private Sub ThongKeNNThang(ByVal sNam As String)
        Dim listpar As New ArrayList(2)
        listpar.Add(New SqlParameter("@NAM", sNam))
        If Me.chkHienthangHT.Checked Then
            If MessageBox.Show("Bạn muốn thống kê đến tháng hiện tại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                listpar.Add(New SqlParameter("@TINHTHANGHT", 1))

            Else
                listpar.Add(New SqlParameter("@TINHTHANGHT", 0))

            End If
        Else
            listpar.Add(New SqlParameter("@TINHTHANGHT", 0))
        End If
        Me.b.GoiThuTuc("SP_THONGKETINHHINH_NGOAINGU_THEOTHANG", listpar)
        listpar.Clear()
    End Sub
    Private Sub CapNhatSoLuongNgoaiNguKhac()
        Me.b.TinhNgoaiNguKhac("SP_TKEPHANBONGOAINGU_KHAC")
    End Sub
    Private Sub LoadDSPhienDich()
        Dim grid As New clsTformatGrid
        Dim tableTK As DataTable
        Me.b = New clsBCapNhatNVNgoaiNguPhienDich
        tableTK = Me.b.LoadDS1("SP_TKEDANHSACH_PHIENDICH")
        If tableTK.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tableTK
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/CapNhatNVNgoaiNgu.xml"), typeControl.Grid, "coldgrThoiviec")
            Me.dgrBC = DirectCast(dgrBC, UltraGrid)
            If (Me.dgrBC.Rows.Count > 0) Then
                Me.dgrBC.Rows.Item(0).Selected = True
                Me.dgrBC.Rows(0).Activated = True
            End If
        End If
        Me.ClearTT()

    End Sub
    Private Sub CapNhatTrangThaiThoiViec(ByVal sTuNgay As Date, ByVal sDenngay As Date)
        Dim listpar As New ArrayList(3)
        listpar.Add(New SqlParameter("@TUNGAY", sTuNgay))
        listpar.Add(New SqlParameter("@DENNGAY", sDenngay))
        Me.b.GoiThuTuc("SP_CAPNHAT_TRANGTHAITHOIVIEC", listpar)
        listpar.Clear()
    End Sub
    Private Sub CapNhatTrangThaiHienTaiTuyenMoi(ByVal sTuNgay As Date, ByVal sDenngay As Date)
        Dim listpar As New ArrayList(3)
        listpar.Add(New SqlParameter("@TUNGAY", sTuNgay))
        listpar.Add(New SqlParameter("@DENNGAY", sDenngay))
        Me.b.GoiThuTuc("SP_CAPNHAT_TRANGTHAIHIENTAI_MOITUYEN", listpar)
        listpar.Clear()
    End Sub
    Private Sub TinhSoLuongPhanBoNgoaiNgu()
        Try
            Me.b.TinhSoLuongPhanBoNN("SP_TKEPHANBONGOAINGU_ALL")
        Catch ex As Exception
            MessageBox.Show("Lỗi,không tính được số lượng ngoại ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Sub PhanBoTinhHinhNgoaiNgu_Xuong(ByVal sTuNgay As Date, ByVal sDenngay As Date)
        Try
            CapNhatTrangThaiThoiViec(sTuNgay, sDenngay)
            CapNhatTrangThaiHienTaiTuyenMoi(sTuNgay, sDenngay)
            TinhSoLuongPhanBoNgoaiNgu()

        Catch ex As Exception
            MessageBox.Show("Lỗi,không tính được số lượng ngoại ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Private Sub CapNhatTrangThaiNgoaiNguKhac(ByVal sLoaiNgoaiNgu As String, ByVal sTuNgay As Date, ByVal sDenngay As Date)
        Try
            Dim listpar As New ArrayList(3)
            listpar.Add(New SqlParameter("@LOAINGOAINGU", sLoaiNgoaiNgu))
            listpar.Add(New SqlParameter("@TUNGAY", sTuNgay))
            listpar.Add(New SqlParameter("@DENNGAY", sDenngay))
            Me.b.GoiThuTuc("SP_TRANGTHAI_NGOAINGUKHAC", listpar)
            listpar.Clear()

        Catch ex As Exception
            MessageBox.Show("Lỗi,không tính được số lượng ngoại ngữ khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

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
    Private Sub An()
        Me.txtChucvu.Enabled = False
        Me.txtCongviec.Enabled = False
        Me.txtDonvi.Enabled = False
        Me.txtTen.Enabled = False
        Me.dtpNgayvao.Enabled = False
        Me.chkThoiviec.Enabled = False
        Me.txtNgaythoiviec.Enabled = False
        Me.lblDVTruocKhiNghi.Visible = False
        Me.cbLoai.Enabled = False
        Me.btnCapNhat.Enabled = False
        Me.chkDaNghiViec.Visible = False
        Me.txtHocvan.Enabled = False
        Me.txtChuyenmon.Enabled = False
        ''==========AN TAM======''
        Me.chkChonHinh.Visible = False
    End Sub
    Private Sub tabNhanvienNNPD_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabNhanvienNNPD.SelectedTabChanged
        Me.dgrBC.DataSource = Nothing
        Select Case Me.tabNhanvienNNPD.SelectedTab.Index

            Case 0
                ''Tab nhap lieu

                Me.btnCapNhat.Visible = True
                Me.btnBaocao.Visible = False
                Me.btnExcel.Visible = (Me.dgrBC.Rows.Count > 0)
            Case 1
                If Me.radThongkeNNThang.Checked Then
                    Me.cboNam.Visible = True
                    Me.lblTungay.Text = "Năm :"
                    Me.btnXem.Enabled = False
                    Me.lblDenngay.Visible = False
                    Me.dtpTungay.Visible = False
                    Me.dtpDenngay.Visible = False
                Else
                    Me.btnXem.Enabled = True
                    Me.cboNam.Visible = False
                    Me.dtpDenngay.Visible = True
                    Me.lblTungay.Text = "Từ ngày :"
                    Me.lblDenngay.Text = "Đến ngày :"
                    Me.dtpTungay.Visible = True
                    Me.dtpDenngay.Visible = True
                    Me.lblDenngay.Visible = True
                End If
                Me.btnBaocao.Visible = True
                Me.btnCapNhat.Visible = False
                Me.btnExcel.Visible = (Me.dgrBC.Rows.Count > 0)
            Case Else
        End Select
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            'Process.Start(Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        'If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    XuatExcel_BaoCaoNVNN_PD()
        'End If
    End Sub

    'Private Sub XuatExcel_BaoCaoNVNN_PD()
    '    Dim myWorkbook As New Infragistics.Excel.Workbook
    '    Dim myWorksheet As Infragistics.Excel.Worksheet
    '    Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

    '    Try
    '        myWorksheet = myWorkbook.Worksheets.Add("NVNN")
    '        Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("NVNN")
    '        myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Blue
    '        myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
    '        myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
    '        myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
    '        myWorksheet.Rows(0).Height = 800
    '        If Me.radTCT.Checked Then
    '            myWorksheet.Rows(0).Cells(1).Value = "BÁO CÁO TÌNH HÌNH PHÂN BỔ NHÂN VIÊN NGOẠI NGỮ TCT " & Chr(10) & " TỪ NGÀY  ĐẾN NGÀY " & Chr(10) & " 從年  月 日 至  年  月 日 外語人才分配情況報告"
    '        End If

    '        If Me.radKhuA.Checked Then
    '            myWorksheet.Rows(0).Cells(1).Value = "BÁO CÁO TÌNH HÌNH PHÂN BỔ NHÂN VIÊN NGOẠI NGỮ  KHU A" & Chr(10) & " TỪ NGÀY  ĐẾN NGÀY " & Chr(10) & " 從年  月 日 至  年  月 日 外語人才分配情況報告"
    '        End If

    '        If Me.radKhuB.Checked Then
    '            myWorksheet.Rows(0).Cells(1).Value = "BÁO CÁO TÌNH HÌNH PHÂN BỔ NHÂN VIÊN NGOẠI NGỮ  KHU B" & Chr(10) & " TỪ NGÀY  ĐẾN NGÀY " & Chr(10) & " 從年  月 日 至  年  月 日 外語人才分配情況報告"
    '        End If

    '        If Me.radKhuDVC.Checked Then
    '            myWorksheet.Rows(0).Cells(1).Value = "BÁO CÁO TÌNH HÌNH PHÂN BỔ NHÂN VIÊN NGOẠI NGỮ  KHU DVC" & Chr(10) & " TỪ NGÀY  ĐẾN NGÀY " & Chr(10) & " 從年  月 日 至  年  月 日 外語人才分配情況報告"
    '        End If


    '        myWorksheet.Rows(1).Cells(2).CellFormat.Font.Color = Color.Blue
    '        myWorksheet.Rows(1).Cells(2).CellFormat.Font.Name = "Arial"
    '        myWorksheet.Rows(1).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(1).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
    '        myWorksheet.Rows(1).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
    '        myWorksheet.Rows(1).Cells(2).CellFormat.Font.Height = 200
    '        myWorksheet.Rows(1).Height = 500
    '        myWorksheet.Rows(1).Cells(2).Value = "Nhà xưởng " & Chr(10) & "廠別"
    '        myWorksheet.Rows(1).Cells(2).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
    '        myWorksheet.Rows(1).Cells(2).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
    '        myWorksheet.Rows(1).Cells(2).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
    '        myWorksheet.Rows(1).Cells(2).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


    '        myWorksheet.Rows(2).Cells(2).CellFormat.Font.Color = Color.Blue
    '        myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
    '        myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
    '        myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
    '        myWorksheet.Rows(2).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
    '        myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
    '        myWorksheet.Rows(2).Height = 500
    '        myWorksheet.Rows(2).Cells(2).Value = "Nhà xưởng " & Chr(10) & "廠別"

    '        sheet.MergedCellsRegions.Add(0, 1, 0, dgrBC.DisplayLayout.Bands(0).Columns.Count)
    '        sheet.MergedCellsRegions.Add(1, 1, 3, 1)
    '        'sheet.MergedCellsRegions.Add(1, 2, 3, 2)

    '        Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)
    '        BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
    '        MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show("Xuất excel lỗi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub ThongKeTHNN_theothang()
        Dim report As New FrmReport
        Dim nam, ngaycuoinam As String
        Dim ngaydau As Date = Me.dtpTungay.Value.Day.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Year.ToString()
        nam = ngaydau.Year.ToString()
        ngaycuoinam = ngaydau.Year.ToString() + "-12-31"
        ''========== tinh toan du lieu========''
        If KhoiTaoDulieuThongKeThang() = False Then
            MessageBox.Show("Không thể khởi tạo dữ liệu thống kê theo tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                LaydulieuNgoaiNguHT(ngaycuoinam)  ''lay ngay vao den ngay hien tai
                ThongKeNNThang(nam)
                CapNhatXuong_TenTiengHoa()

            Catch ex As Exception
                MessageBox.Show("Lỗi,không tính được số lượng ngoại ngữ theo tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
            Try
                report.reportID = "THNN_THANG"
                Dim strArray As String() = New String() {}
                strArray = New String() {}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Catch ex As Exception
                MessageBox.Show("lỗi", "Thông báo")
            End Try
        End If
    End Sub
    Private Function KhongHienThiThangReport() As Boolean
        Return Me.b.KhoiTaoDL("SP_CAPNHATTHANGHT_TKENGOAINGUTHANG")
    End Function
    Private Function KiemtraThoiGian(ByVal dTungay As Date, ByVal dDenngay As Date) As Boolean
        If dTungay.Year.ToString() <> dDenngay.Year.ToString() Then
            MessageBox.Show("Vui lòng chọn thời gian trong 1 năm.", "Thông báo", MessageBoxButtons.OK)
            Return False
        Else
            If dTungay.Month.ToString() <> dDenngay.Month.ToString() Then
                MessageBox.Show("Vui lòng chọn thời gian bắt đầu và kết thúc trong 1 tháng.", "Thông báo", MessageBoxButtons.OK)
                Return False
            Else
                Return True
            End If
        End If
    End Function
    Private Sub BaocaoPhanbo()
        Dim report As New FrmReport
        'Dim ngaydau As Date = Me.dtpTungay.Value.Day.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Year.ToString()
        'Dim ngaycuoi As Date = Me.dtpDenngay.Value.Day.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Year.ToString()
        Dim ngaydau As Date = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim ngaycuoi As Date = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()

        Dim ngayselectdau As String = "'" + ngaydau.Year.ToString() + "-" + ngaydau.Month.ToString() + "-" + ngaydau.Day.ToString() + "'"
        Dim ngayselectcuoi As String = "'" + ngaycuoi.Year.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Day.ToString() + "'"
        Dim NGAYVAO As String = ngaycuoi.Year.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Day.ToString()
        Dim tbleNNKhac As DataTable
        Dim NN_Ma As String = ""

        'If Me.radKhuA.Checked Then

        'End If

        'If Me.radKhuB.Checked Then

        'End If

        'If Me.radKhuDVC.Checked Then

        'End If

        'If Me.radTCT.Checked Then
        ''=============== khoi tao du lieu ============''
        If KhoiTaoDuLieuChung() Then
            If KhoiTaoDulieuThongKe() Then
                ''========== tinh toan du lieu ========''
                Try
                    LaydulieuNgoaiNguHT(NGAYVAO)
                    PhanBoTinhHinhNgoaiNgu_Xuong(ngaydau, ngaycuoi)

                    ''TINH TUNG LOAI NGOAI NGU KHAC ======''
                    obj.ChonBang = 3
                    tbleNNKhac = Me.b.LoadDS(obj)
                    If tbleNNKhac.Rows.Count > 0 Then
                        For i = 0 To tbleNNKhac.Rows.Count - 1
                            NN_Ma = tbleNNKhac.Rows(i).Item("NN_MA").ToString()
                            CapNhatTrangThaiNgoaiNguKhac(NN_Ma, ngaydau, ngaycuoi)
                        Next
                        CapNhatSoLuongNgoaiNguKhac()
                        CapNhatXuong_TenTiengHoa()
                    End If
                Catch ex As Exception
                    MessageBox.Show("lỗi", "Thông báo")
                End Try
            Else
                MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'End If


        ''======= tuy chon xem bao cao hay loc du lieu ====''
        If bChonxemluoi Then
            Dim grid As New clsTformatGrid
            Dim tableTK As DataTable
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            tableTK = Me.b.LoadDS1("SP_THONGKETINHHINHPB_NNPHIENDICH")
            If tableTK.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tableTK
                Dim dgrBC As Object = Me.dgrBC
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/TinhHinhPhanBoNNguPDich.xml"), typeControl.Grid, "coldgrThoiviec")
                Me.dgrBC = DirectCast(dgrBC, UltraGrid)
                If (Me.dgrBC.Rows.Count > 0) Then
                    Me.dgrBC.Rows.Item(0).Selected = True
                    Me.dgrBC.Rows(0).Activated = True
                End If
            End If
        Else
            report.reportID = "THNN01"
            Dim strArray As String() = New String() {}
            Dim ngayt, thangt As String
            Dim ngaybd As String = ngaydau.Day.ToString() + "-" + ngaydau.Month.ToString() + "-" + ngaydau.Year.ToString()
            Dim ngaykt As String = ngaycuoi.Day.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Year.ToString()
            Try
                strArray = New String() {Me.dtpTungay.Text.ToString(), Me.dtpDenngay.Text.ToString()}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Catch ex As Exception
                MessageBox.Show("lỗi", "Thông báo")
            End Try
        End If
    End Sub
    Private Sub radLoaiPD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLoaiPD.ValueChanged
        If Me.radLoaiPD.CheckedIndex = 3 Then
            Me.cbLoai.Enabled = True
        Else
            Me.cbLoai.Enabled = False
        End If
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Select Case Me.tabNhanvienNNPD.SelectedTab.Index
            Case 0
                Me.LoadDSPhienDich()
                An()
            Case 1
                Me.XpCaption2.Text = "Danh Sách"
                Me.dtpTungay.Enabled = True
                Me.lblDVTruocKhiNghi.Enabled = True
                ''=== xem tình hình phân bổ ========
                bChonxemluoi = True
                If Me.radPBNVNN.Checked Then
                    Me.XpCaption2.Text = "Bảng phân bố tình hình ngoại ngữ"
                    BaocaoPhanbo()
                    ''=========== tinh tong cac cot can tinh ===================''
                    Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
                    band.Layout.Bands(0).Summaries.Clear()

                    Dim columnToSummarize1 As UltraGridColumn = band.Layout.Bands(0).Columns("HT_TIENGHOA")
                    Dim summary1 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng Tiếng Hoa(HT):", SummaryType.Sum, columnToSummarize1)
                    summary1.Appearance.TextHAlign = HAlign.Right
                    summary1.DisplayFormat = "Tổng Tiếng Hoa(HT) = {0}"

                    Dim columnToSummarize2 As UltraGridColumn = band.Layout.Bands(0).Columns("MOI_TIENGHOA")
                    Dim summary2 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize2)
                    summary2.Appearance.TextHAlign = HAlign.Right
                    summary2.DisplayFormat = "Tổng Tiếng Hoa (mới tuyển) = {0}"

                    Dim columnToSummarize3 As UltraGridColumn = band.Layout.Bands(0).Columns("NGHIVIEC_TIENGHOA")
                    Dim summary3 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize3)
                    summary3.Appearance.TextHAlign = HAlign.Right
                    summary3.DisplayFormat = "Tổng Tiếng Hoa (NV) = {0}"

                    Dim columnToSummarize4 As UltraGridColumn = band.Layout.Bands(0).Columns("HT_TIENGANH")
                    Dim summary4 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize4)
                    summary4.Appearance.TextHAlign = HAlign.Right
                    summary4.DisplayFormat = "Tổng Tiếng Anh(HT) = {0}"

                    Dim columnToSummarize5 As UltraGridColumn = band.Layout.Bands(0).Columns("MOI_TIENGANH")
                    Dim summary5 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize5)
                    summary5.Appearance.TextHAlign = HAlign.Right
                    summary5.DisplayFormat = "Tổng Tiếng Anh(mới tuyển)= {0}"

                    Dim columnToSummarize6 As UltraGridColumn = band.Layout.Bands(0).Columns("NGHIVIEC_TIENGANH")
                    Dim summary6 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize6)
                    summary6.Appearance.TextHAlign = HAlign.Right
                    summary6.DisplayFormat = "Tổng Tiếng Anh (NV) = {0}"

                    Dim columnToSummarize7 As UltraGridColumn = band.Layout.Bands(0).Columns("HT_NGOAINGUKHAC")
                    Dim summary7 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize7)
                    summary7.Appearance.TextHAlign = HAlign.Right
                    summary7.DisplayFormat = "Tổng N.Ngữ Khác(HT) = {0}"

                    Dim columnToSummarize8 As UltraGridColumn = band.Layout.Bands(0).Columns("MOI_NGOAINGUKHAC")
                    Dim summary8 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize8)
                    summary8.Appearance.TextHAlign = HAlign.Right
                    summary8.DisplayFormat = "Tổng N.Ngữ Khác(mới tuyển) = {0}"

                    Dim columnToSummarize9 As UltraGridColumn = band.Layout.Bands(0).Columns("NGHIVIEC_NGOAINGUKHAC")
                    Dim summary9 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize9)
                    summary9.Appearance.TextHAlign = HAlign.Right
                    summary9.DisplayFormat = "Tổng N.Ngữ Khác(NV) = {0}"

                    Dim columnToSummarize10 As UltraGridColumn = band.Layout.Bands(0).Columns("HT_PHIENDICH")
                    Dim summary10 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize10)
                    summary10.Appearance.TextHAlign = HAlign.Right
                    summary10.DisplayFormat = "Tổng Phiên Dịch(HT) = {0}"

                    Dim columnToSummarize11 As UltraGridColumn = band.Layout.Bands(0).Columns("MOI_PHIENDICH")
                    Dim summary11 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize11)
                    summary11.Appearance.TextHAlign = HAlign.Right
                    summary11.DisplayFormat = "Tổng Phiên Dịch(mới tuyển) = {0}"

                    Dim columnToSummarize12 As UltraGridColumn = band.Layout.Bands(0).Columns("NGHIVIEC_PHIENDICH")
                    Dim summary12 As SummarySettings = band.Layout.Bands(0).Summaries.Add(SummaryType.Sum, columnToSummarize12)
                    summary12.Appearance.TextHAlign = HAlign.Right
                    summary12.DisplayFormat = "Tổng Phiên Dịch(NV) = {0}"

                    band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                    band.SummaryFooterCaption = "Tổng số: "

                End If
                ''=== xem thống kê ngoại ngữ đến hiện tại (bỏ thôi việc: thôi việc tính DDG từ ngày - đến ngày) ========
                If Me.radNVNNTH.Checked Then

                    Me.lblDVTruocKhiNghi.Enabled = False

                    DSNVNgoainguTH()
                End If
                ''=== xem thống kê ngoại ngữ trong tháng: hiện tại hoặc nghỉ việc ========
                If Me.radNVNN.Checked Then
                    Dim dngaybd, dngaykt As Date
                    dngaybd = Me.dtpTungay.Value
                    dngaykt = Me.dtpDenngay.Value
                    'If KiemtraThoiGian(dngaybd, dngaykt) Then
                    If Me.chkDaNghiViec.Checked Then
                        'Me.XpCaption2.Text = "Danh Sách ngoại ngữ nghỉ việc đến ngày:" & Me.dtpDenngay.TextRenderingMode.ToString()
                        DSNVNgoainguNghiviec()
                    Else
                        'Me.XpCaption2.Text = "Danh Sách ngoại ngữ mới tuyển từ ngày: " & Me.dtpTungay.Text & " đến " & Me.dtpDenngay.Text
                        DSNVNgoaingu()
                    End If
                    'End If
                End If
                ''=== xem thống kê ngoại ngữ trong năm theo từng tháng ========
                If Me.radThongkeNNThang.Checked Then

                    bChonxemluoi = False '' khong xem duoc luoi nay
                End If
        End Select
        btnExcel.Visible = (Me.dgrBC.Rows.Count > 0)
    End Sub
    Private Sub DSNVNgoainguTH()
        Dim report As New FrmReport
        'Dim ngaydau As Date = Me.dtpTungay.Value.Day.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Year.ToString()
        'Dim ngaycuoi As Date = Me.dtpDenngay.Value.Day.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Year.ToString()
        Dim ngaydau As Date = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim ngaycuoi As Date = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()
        Dim NGAYVAO As String = ngaycuoi.Year.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Day.ToString()

        If KhoiTaoDuLieuChung() Then
            If KhoiTaoDulieuThongKe() Then
                ''========== tinh toan du lieu ========''
                Try
                    LaydulieuNgoaiNguHT(NGAYVAO)
                    PhanBoTinhHinhNgoaiNgu_Xuong(ngaydau, ngaycuoi)
                Catch ex As Exception
                    MessageBox.Show("lỗi", "Thông báo")
                End Try
            Else
                MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ''========== tinh toan du lieu: lay theo diem danh tu ngay den ngay ========''
        If bChonxemluoi Then
            Dim grid As New clsTformatGrid
            Dim tableTK As DataTable
            Me.b = New clsBCapNhatNVNgoaiNguPhienDich
            ''=================== gọi tham số,cập nhật các trạng thái, dựa theo bảng IT_nvnnpd 

            Dim listpar As New ArrayList(2)
            'listpar.Add(New SqlParameter("@TUNGAY", ngaydau))
            listpar.Add(New SqlParameter("@DENNGAY", ngaycuoi))
            If Me.radKhuA.Checked Then
                tableTK = Me.b.GoiThuTucThongKe("SP_TKEDANHSACHNGOAINGU_TH_KHUA", listpar)
            End If
            If Me.radKhuB.Checked Then
                tableTK = Me.b.GoiThuTucThongKe("SP_TKEDANHSACHNGOAINGU_TH_KHUB", listpar)
            End If
            If Me.radKhuDVC.Checked Then
                tableTK = Me.b.GoiThuTucThongKe("SP_TKEDANHSACHNGOAINGU_TH_KHUDVC", listpar)
            End If
            If Me.radTCT.Checked Then
                tableTK = Me.b.GoiThuTucThongKe("SP_TKEDANHSACHNGOAINGU_TH", listpar)
            End If

            listpar.Clear()

            If tableTK.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tableTK
                Dim dgrBC As Object = Me.dgrBC
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DanhSachNVNgoaiNguTongHop.xml"), typeControl.Grid, "coldgrThoiviec")
                Me.dgrBC = DirectCast(dgrBC, UltraGrid)
                If (Me.dgrBC.Rows.Count > 0) Then
                    Me.dgrBC.Rows.Item(0).Selected = True
                    Me.dgrBC.Rows(0).Activated = True
                End If
            End If
        Else
            Try
                Dim khu As String
                If Me.radKhuA.Checked Then
                    khu = "A"
                End If
                If Me.radKhuB.Checked Then
                    khu = "B"
                End If
                If Me.radKhuDVC.Checked Then
                    khu = "DVC"
                End If
                If Me.radTCT.Checked Then
                    khu = "TCT"
                End If
                report.reportID = "DSNNTH"
                Dim strArray As String() = New String() {}
                strArray = New String() {ngaycuoi, "'" + khu + "'", ngaydau}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Catch ex As Exception
                MessageBox.Show("lỗi", "Thông báo")
            End Try
        End If


    End Sub
    Private Sub DSNVNgoainguNghiviec()
        Dim report As New FrmReport
        'Dim ngaydau As Date = Me.dtpTungay.Value.Day.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Year.ToString()
        'Dim ngaycuoi As Date = Me.dtpDenngay.Value.Day.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Year.ToString()
        Dim ngaydau As Date = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim ngaycuoi As Date = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()

        Dim stngay, sdngay As String
        stngay = ngaydau.Year.ToString() + "/" + ngaydau.Month.ToString() + "/" + ngaydau.Day.ToString()
        sdngay = ngaycuoi.Year.ToString() + "/" + ngaycuoi.Month.ToString() + "/" + ngaycuoi.Day.ToString()

        Dim NGAYVAO As String = ngaycuoi.Year.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Day.ToString()

        If KhoiTaoDuLieuChung() Then
            If KhoiTaoDulieuThongKe() Then
                ''========== tinh toan du lieu ========''
                Try
                    LaydulieuNgoaiNguHT(NGAYVAO)
                    PhanBoTinhHinhNgoaiNgu_Xuong(ngaydau, ngaycuoi)
                Catch ex As Exception
                    MessageBox.Show("lỗi", "Thông báo")
                End Try
            Else
                MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ''========== tinh toan du lieu ========''
        'DanhSachNVNgoaiNguNghiViec.xml
        If bChonxemluoi Then
            Dim grid As New clsTformatGrid
            Dim tableTK As DataTable
            'Me.b = New clsBCapNhatNVNgoaiNguPhienDich

            Me.b = New clsBCapNhatNVNgoaiNguPhienDich

            If Me.radKhuA.Checked Then
                tableTK = Me.b.DanhSachNNgu_ThoiViec("SP_TKEDANHSACHNGOAINGU_NV_KHUA", stngay, sdngay)
            End If
            If Me.radKhuB.Checked Then
                tableTK = Me.b.DanhSachNNgu_ThoiViec("SP_TKEDANHSACHNGOAINGU_NV_KHUB", stngay, sdngay)
            End If
            If Me.radKhuDVC.Checked Then
                tableTK = Me.b.DanhSachNNgu_ThoiViec("SP_TKEDANHSACHNGOAINGU_NV_KHUDVC", stngay, sdngay)
            End If
            If Me.radTCT.Checked Then
                tableTK = Me.b.DanhSachNNgu_ThoiViec("SP_TKEDANHSACHNGOAINGU_NV", stngay, sdngay)
            End If
            If tableTK.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tableTK
                Dim dgrBC As Object = Me.dgrBC
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DanhSachNVNgoaiNguNghiViec.xml"), typeControl.Grid, "coldgrThoiviec")
                Me.dgrBC = DirectCast(dgrBC, UltraGrid)
                If (Me.dgrBC.Rows.Count > 0) Then
                    Me.dgrBC.Rows.Item(0).Selected = True
                    Me.dgrBC.Rows(0).Activated = True
                End If
            End If
        Else
            Try
                Dim khu As String
                If Me.radKhuA.Checked Then
                    khu = "A"
                End If
                If Me.radKhuB.Checked Then
                    khu = "B"
                End If
                If Me.radKhuDVC.Checked Then
                    khu = "DVC"
                End If
                If Me.radTCT.Checked Then
                    khu = "TCT"
                End If
                report.reportID = "THNN_NV"
                Dim strArray As String() = New String() {}
                strArray = New String() {ngaydau, ngaycuoi, "'" + khu + "'"}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Catch ex As Exception
                MessageBox.Show("lỗi", "Thông báo")
            End Try
        End If
    End Sub
    Private Sub DSNVNgoaingu()
        Dim report As New FrmReport
        'Dim ngaydau As Date = Me.dtpTungay.Value.Day.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Year.ToString()
        'Dim ngaycuoi As Date = Me.dtpDenngay.Value.Day.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Year.ToString()
        Dim ngaydau As Date = Me.dtpTungay.Value.Year.ToString() + "/" + Me.dtpTungay.Value.Month.ToString() + "/" + Me.dtpTungay.Value.Day.ToString()
        Dim ngaycuoi As Date = Me.dtpDenngay.Value.Year.ToString() + "/" + Me.dtpDenngay.Value.Month.ToString() + "/" + Me.dtpDenngay.Value.Day.ToString()

        ''========== tinh toan du lieu ========''
        Dim stngay, sdngay As String
        stngay = ngaydau.Year.ToString() + "/" + ngaydau.Month.ToString() + "/" + ngaydau.Day.ToString()
        sdngay = ngaycuoi.Year.ToString() + "/" + ngaycuoi.Month.ToString() + "/" + ngaycuoi.Day.ToString()

        Dim NGAYVAO As String = ngaycuoi.Year.ToString() + "-" + ngaycuoi.Month.ToString() + "-" + ngaycuoi.Day.ToString()

        If KhoiTaoDuLieuChung() Then
            If KhoiTaoDulieuThongKe() Then
                ''========== tinh toan du lieu ========''
                Try
                    LaydulieuNgoaiNguHT(NGAYVAO)
                    PhanBoTinhHinhNgoaiNgu_Xuong(ngaydau, ngaycuoi)
                Catch ex As Exception
                    MessageBox.Show("lỗi", "Thông báo")
                End Try
            Else
                MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            MessageBox.Show("Không thể khởi tạo dữ liệu thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If bChonxemluoi Then
            Dim grid As New clsTformatGrid
            Dim tableTK As DataTable

            Me.b = New clsBCapNhatNVNgoaiNguPhienDich

            If Me.radKhuA.Checked Then
                tableTK = Me.b.DanhSachNNgu_HienTai("SP_TKEDANHSACHNGOAINGU_TM_KHUA", stngay, sdngay)
            End If
            If Me.radKhuB.Checked Then
                tableTK = Me.b.DanhSachNNgu_HienTai("SP_TKEDANHSACHNGOAINGU_TM_KHUB", stngay, sdngay)
            End If
            If Me.radKhuDVC.Checked Then
                tableTK = Me.b.DanhSachNNgu_HienTai("SP_TKEDANHSACHNGOAINGU_TM_KHUDVC", stngay, sdngay)
            End If
            If Me.radTCT.Checked Then
                tableTK = Me.b.DanhSachNNgu_HienTai("SP_TKEDANHSACHNGOAINGU_TM", stngay, sdngay)
            End If
            If tableTK.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tableTK
                Dim dgrBC As Object = Me.dgrBC
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DanhSachNVNgoaiNguHienTai.xml"), typeControl.Grid, "coldgrThoiviec")
                Me.dgrBC = DirectCast(dgrBC, UltraGrid)
                If (Me.dgrBC.Rows.Count > 0) Then
                    Me.dgrBC.Rows.Item(0).Selected = True
                    Me.dgrBC.Rows(0).Activated = True
                End If
            Else
                Me.dgrBC.DataSource = tableTK
                grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DanhSachNVNgoaiNguHienTai.xml"), typeControl.Grid, "coldgrThoiviec")
                Me.dgrBC = DirectCast(dgrBC, UltraGrid)
            End If
        Else
            Try
                Dim khu As String
                If Me.radKhuA.Checked Then
                    khu = "A"
                End If
                If Me.radKhuB.Checked Then
                    khu = "B"
                End If
                If Me.radKhuDVC.Checked Then
                    khu = "DVC"
                End If
                If Me.radTCT.Checked Then
                    khu = "TCT"
                End If
                report.reportID = "THNN_TM"
                Dim strArray As String() = New String() {}
                strArray = New String() {ngaydau, ngaycuoi, "'" + khu + "'"}
                report.para = strArray
                report.issysReport = True
                report.Show()
            Catch ex As Exception
                MessageBox.Show("lỗi", "Thông báo")
            End Try
        End If


    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit

        Next i
    End Sub
    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.ChonDong()
        Laythongtin()
    End Sub
    Private Sub btnBaocao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaocao.Activate
        Select Case Me.tabNhanvienNNPD.SelectedTab.Index
            Case 0

            Case 1
                bChonxemluoi = False
                If Me.radPBNVNN.Checked Then
                    BaocaoPhanbo()
                End If

                If Me.radNVNNTH.Checked Then
                    DSNVNgoainguTH()
                End If

                If Me.radNVNN.Checked Then
                    If Me.chkDaNghiViec.Checked Then
                        DSNVNgoainguNghiviec()
                    Else
                        DSNVNgoaingu()
                    End If
                End If

                If Me.radThongkeNNThang.Checked Then
                    MessageBox.Show("Hiện báo cáo chưa có công thức mới để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'ThongKeTHNN_theothang()
                End If

        End Select

    End Sub
    Private Sub radNVNN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNVNN.CheckedChanged
        If Me.radNVNN.Checked Then
            Me.chkDaNghiViec.Visible = True
        Else
            Me.chkDaNghiViec.Visible = False
        End If
    End Sub
    Private Sub radThongkeNNThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radThongkeNNThang.CheckedChanged
        If Me.radThongkeNNThang.Checked Then
            Me.cboNam.Visible = True
            Me.lblTungay.Text = "Năm :"
            Me.btnXem.Enabled = False
            Me.lblDenngay.Visible = False
            Me.dtpTungay.Visible = False
            Me.dtpDenngay.Visible = False
            Me.XpCaption2.Text = "Thống kê ngoại ngữ năm :" & Me.cboNam.Text.ToString()
            Me.chkHienthangHT.Visible = True
        Else
            Me.btnXem.Enabled = True
            Me.cboNam.Visible = False
            Me.dtpDenngay.Visible = True
            Me.lblTungay.Text = "Từ ngày :"
            Me.lblDenngay.Text = "Đến ngày :"
            Me.dtpTungay.Visible = True
            Me.dtpDenngay.Visible = True
            Me.lblDenngay.Visible = True
            Me.chkHienthangHT.Visible = False
        End If
    End Sub

    Private Sub radNVNNTH_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radNVNNTH.CheckedChanged
        If Me.radThongkeNNThang.Checked Then
            Me.XpCaption2.Text = "Danh Sách ngoại ngữ đến ngày:" & Me.dtpDenngay.Text.ToString()
        Else
        End If
    End Sub

    Private Sub chkDaNghiViec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDaNghiViec.CheckedChanged
        If Me.radNVNN.Checked Then
            If Me.chkDaNghiViec.Checked Then
                Me.XpCaption2.Text = "Danh Sách ngoại ngữ nghỉ việc từ ngày: " & Me.dtpTungay.Text.ToString() & " đến ngày:" & Me.dtpDenngay.Text.ToString()
                'DSNVNgoainguNghiviec()
            Else
                Me.XpCaption2.Text = "Danh Sách ngoại ngữ mới tuyển từ ngày: " & Me.dtpTungay.Text.ToString() & " đến " & Me.dtpDenngay.Text.ToString()
                'DSNVNgoaingu()
            End If
        Else
        End If
    End Sub

    Private Sub chkHienthangHT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHienthangHT.CheckedChanged
        If (Me.chkHienthangHT.Checked) Then
            If MessageBox.Show("Bạn muốn thống kê đến tháng hiện tại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            End If
        End If
    End Sub

End Class