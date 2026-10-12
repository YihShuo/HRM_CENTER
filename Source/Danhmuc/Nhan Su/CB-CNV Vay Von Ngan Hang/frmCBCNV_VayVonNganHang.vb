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
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Imports System.Xml
Public Class frmCBCNV_VayVonNganHang
    ''' Người tạo: Trân
    ''' Ngày tạo: 22/11/2013
    ''' Nội dung: Tạo mới form vay vốn ngân hàng
    ''' Ngày hiệu chỉnh: 26/11/2013,20/02/2014
    ''' Người hiệu chỉnh: Trân
    ''' Nội dung: thêm cột ngày vay vốn, lọc trên lưới theo xưởng,đơn vi hiện 2 loại
    ''' 20/2/2014: thêm tìm kiếm theo số tài khoản bắt sự kiện enter
    ''' thêm cột ngày vay vốn. 23/04/2014: những người đã hoàn vốn rồi đc vay tiếp.
    ''' chặn sự kiện khi đang tìm theo số tài khoản thì không gọi tìm số cmnd
    Dim Tabletemp As DataTable
    Public Flag As Boolean = False
    Friend WithEvents b As clsB_CBCNV_VayVonNganHang
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public flagThem As Integer = 0
    Public flagSua As Integer = 0
    Public TenCot As String = ""
    Public flagTim As Integer = 0  ''biến chặn phát sinh gọi sự kiện value_change số cmnd và số tài khoản khi chọn từ lưới sẽ không tim theo
    Dim i As Integer = 0
    Public flagTimSoTaiKhoan As Integer = 0
    Private Sub frmCBCNV_VayVonNganHang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        methodLoad()
        An()
        Me.txtMa.MaxLength = 6
        'txtSoCMND.MaxLength = 10
        'Me.txtSotaikhoan.MaxLength = 20
        chkSothe.Checked = True
        Me.txtSolanvay.Enabled = False
        Ansolanvay()
        obj.TimNgayHoanVon = 0
        Me.btnXoa.Enabled = False
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsB_CBCNV_VayVonNganHang
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/VayVonNganHang.xml"), typeControl.Grid, "coldgrThoiviec")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        Me.ClearTT()
        If (Me.dgrBC.Rows.Count > 0) Then
            Me.dgrBC.Rows.Item(0).Selected = True
            Me.dgrBC.Rows(0).Activated = True
        End If
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
    Public Sub HuyBo()
        Dim grid As New clsTformatGrid
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        Dim tngay As Date = activeRow.Cells.Item("NGAYBDVAY").Value
        If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
            Dim MA As String = activeRow.Cells.Item("NV_MA").Value.ToString
            If (MessageBox.Show(("Bạn có muốn hủy số thẻ :" & MA & " vay ngày: " & tngay & " khỏi danh sách vay vốn ngân hàng không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.ChonBang = 1
                obj.NV_MA = MA
                obj.NGAYBD = tngay.Year.ToString() + "/" + tngay.Month.ToString() + "/" + tngay.Day.ToString()
                Me.b = New clsB_CBCNV_VayVonNganHang
                Me.b.DeleteInfo(obj)
                MessageBox.Show("Bạn đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        ClearTT()
        TrangThaiThem()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub Laythongtin()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            Dim tableTam As DataTable
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMa.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                If Me.txtMa.Text = "" Then
                    obj.NV_MA_Luoi = ""
                    Exit Sub
                Else
                    obj.NV_MA_Luoi = Me.txtMa.Text.ToString.Trim()
                    obj.NV_MA = Me.txtMa.Text
                End If
                flagTim = 0
                flagTimSoTaiKhoan = 0
                obj.TenCot = "''NV_MA''"
                Me.txtSoCMND.Text = activeRow.Cells.Item("NV_CMND").Value.ToString
                Me.txtSotaikhoan.Text = activeRow.Cells.Item("SOTAIKHOAN").Value.ToString
                Me.txtTen.Text = activeRow.Cells.Item("NV_TEN").Value.ToString
                Me.txtDonvi.Text = activeRow.Cells.Item("DV_MA").Value.ToString
                Me.dtpNgayvao.Value = activeRow.Cells.Item("NV_NGAYVAO").Value.ToString
                Me.txtSotaikhoan.Enabled = False
                Me.txtSoCMND.Enabled = False
                ''==================== trạng thái sửa theo dòng click trên lưới ==========''
                ''============== xet so lan vay von ================''
                TinhSoLanVay(4, obj.TenCot)
                If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
                    ''================= lấy từ datetimepicker ==================''
                    Me.cboNgayvayvon.Visible = False
                    Me.dtpNgayvay.Visible = True
                    Me.dtpNgayvay.Enabled = False
                    Me.dtpNgayvay.Value = activeRow.Cells.Item("NGAYBDVAY").Value.ToString

                    Me.btnSua.Enabled = True
                    Me.btnThem.Enabled = False
                    Me.btnXoa.Enabled = True

                ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then
                    Me.dtpNgayvay.Value = Nothing
                    Me.dtpNgayvay.Enabled = False
                    Me.btnSua.Enabled = False
                    Me.btnThem.Enabled = False
                    Me.btnXoa.Enabled = False
                Else
                    Me.cboNgayvayvon.Visible = True
                    Me.dtpNgayvay.Visible = False
                    Me.dtpNgayvay.Enabled = False
                    ''=================== đưa ngày vay vào combo ==========''
                    Dim ngayvayt As Date
                    Me.cboNgayvayvon.Enabled = False
                    Me.cboNgayvayvon.Items.Clear()
                    ngayvayt = activeRow.Cells.Item("NGAYBDVAY").Value
                    Me.cboNgayvayvon.Items.Add(String.Format(ngayvayt, "dd/MM/yyyy"))
                    Me.cboNgayvayvon.SelectedIndex = 0
                    Me.btnSua.Enabled = True
                    Me.btnThem.Enabled = False
                    Me.btnXoa.Enabled = True
                End If

                If Convert.ToBoolean(activeRow.Cells.Item("HOANVON").Value) = False Or activeRow.Cells.Item("HOANVON").Value = 0 Then
                    Me.dtpNgayHoanVon.Value = Nothing
                    Me.chkHoanvon.Checked = False
                    Me.dtpNgayHoanVon.Enabled = False
                Else
                    Me.dtpNgayHoanVon.Value = activeRow.Cells.Item("NGAYHOANVON").Value
                    Me.chkHoanvon.Checked = True
                    Me.dtpNgayHoanVon.Enabled = True
                End If

                If activeRow.Cells.Item("NV_GioiTinh").Value = 0 Then
                    Me.radGioiTinh.CheckedIndex = 1
                Else
                    Me.radGioiTinh.CheckedIndex = 0 ''NỮ
                End If
                If activeRow.Cells.Item("DATHOIVIEC").Value = 0 Then
                    Me.chkThoiviec.Checked = False
                Else
                    Me.chkThoiviec.Checked = True
                End If
                If activeRow.Cells.Item("TV_NGAYTHOIVIEC").Value.ToString() = "" Then
                    Me.dtpNgaythoiviec.Text = ""
                Else
                    Me.dtpNgaythoiviec.Text = activeRow.Cells.Item("TV_NGAYTHOIVIEC").Value.ToString
                End If
                If activeRow.Cells.Item("IT_DDNGHIVIEC").Value = True Then
                    Me.chkDieudong.Checked = True
                Else
                    Me.chkDieudong.Checked = False
                End If
                ''=============== tim don vi moi va don vi cu cua so the dang chon ============
                If activeRow.Cells.Item("DV_MA").Value.ToString() = activeRow.Cells.Item("DV_MA_").Value.ToString() Then
                    An()
                Else
                    Hien()
                End If
                If Convert.ToBoolean(activeRow.Cells.Item("IT_DDNGHIVIEC").Value) = True Then
                    Me.chkDieudong.Checked = True
                    '' the hien 2 don vi: dv_ma va dv_ma_
                    Me.txtDonvi_.Text = activeRow.Cells.Item("DV_MA").Value.ToString()
                    Me.txtDonvi.Text = activeRow.Cells.Item("DV_MA_").Value.ToString()
                Else
                    Me.chkDieudong.Checked = False
                    Me.txtDonvi_.Text = activeRow.Cells.Item("DV_MA_").Value.ToString()
                    Me.txtDonvi.Text = activeRow.Cells.Item("DV_MA").Value.ToString()
                End If
                Me.txtLoaithoiviec.Text = activeRow.Cells.Item("LTV_Ten").Value.ToString
                Me.txtLyDo.Text = activeRow.Cells.Item("TV_LYDO").Value.ToString
            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Shared obj As New Obj_CBCNV_VayVonNganHang
    Dim oldRow As Integer = 0
    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.ChonDong()
        Laythongtin()
        flagThem = 0
    End Sub
    Private Sub dgrBC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        flagThem = 1
        ClearTT()
        Me.txtMa.Focus()
        TrangThaiThem()
        Me.flagTim = 0
    End Sub
    Private Sub TinhSoLanVay(ByVal chonbang As Integer, ByVal sCot As String)
        Dim tableTam As DataTable
        obj.ChonBang = chonbang

        If flagTim = 0 Then
            obj.NV_MA = obj.NV_MA_Luoi
            tableTam = Me.b.LoadDS(obj)
            ''=================== sử dụng hàm hiệu chỉnh:số thẻ từ dòng active ===================''
            If tableTam.Rows.Count > 0 Then
                For i = 0 To tableTam.Rows.Count - 1
                    If tableTam.Rows(i).Item("NV_MA").ToString() = obj.NV_MA Then ''======= tim thấy đúng số thẻ đang đi làm có vay vốn
                        If Convert.ToInt32(tableTam.Rows(i).Item("SOLANVAY")) = 0 Then
                            Ansolanvay()
                        Else
                            Hiensolanvay()
                        End If
                        Me.txtSolanvay.Text = tableTam.Rows(i).Item("SOLANVAY")
                    End If
                Next
            Else
                Me.txtSolanvay.Text = "0"
            End If
        Else
            ''=================== sử dụng hàm tìm kiếm: số thẻ gán từ obj trước đó ===================''
            tableTam = Me.b.LoadDS(obj)
            If tableTam.Rows.Count > 0 Then
                If Convert.ToInt32(tableTam.Rows(0).Item("SOLANVAY")) = 0 Then
                    Ansolanvay()
                Else
                    Hiensolanvay()
                End If
                Me.txtSolanvay.Text = tableTam.Rows(0).Item("SOLANVAY")
            Else
                Me.txtSolanvay.Text = "0"
            End If
        End If
    End Sub
    Private Sub Hiensolanvay()
        Me.lblSolanvay.Visible = True
        Me.txtSolanvay.Visible = True
    End Sub
    Private Sub Ansolanvay()
        Me.lblSolanvay.Visible = False
        Me.txtSolanvay.Visible = False
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next i
    End Sub
    Private Sub An()
        Me.txtTen.Enabled = False
        Me.dtpNgayvao.Enabled = False
        Me.txtDonvi.Enabled = False
        Me.txtDonvi_.Enabled = False
        Me.dtpNgaythoiviec.Enabled = False
        Me.txtLoaithoiviec.Enabled = False
        Me.txtLyDo.Enabled = False
        Me.chkThoiviec.Enabled = False
        Me.radGioiTinh.Enabled = False
        Me.txtMa.MaxLength = 6
        ''==============
        chkDieudong.Visible = False
        chkDieudong.Enabled = False
        Me.txtDonvi.Visible = False
        Me.txtDonvi_.Height = 21
        Me.txtDonvi_.Width = 268

    End Sub
    Private Function KiemTraTrong() As Boolean
        If Me.txtMa.Text.Trim() = "" Then
            MessageBox.Show("Bạn chưa nhập số thẻ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If Me.dtpNgayvay.Text.Trim() = "" Then
            MessageBox.Show("Bạn chưa chọn ngày vay vốn.,", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If (Me.chkHoanvon.Checked And Me.dtpNgayHoanVon.Value Is Nothing) Then
            MessageBox.Show("Bạn chưa chọn ngày hoàn vốn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If Me.dtpNgayHoanVon.Value <= dtpNgayvay.Value And Me.chkHoanvon.Checked Then
            MessageBox.Show("Ngày hoàn vốn phải  >= ngày vay vốn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function
    Private Function KiemTra_HoanVonChua(ByVal sNV_Ma As String) As Boolean
        Dim tblKiemtra As DataTable
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("NV_MA", sNV_Ma))
        tblKiemtra = Me.b.GoiThuTuc("SP_KIEMTRA_HOANVONNGANHANG_NV_MA", listpar)
        listpar.Clear()
        If tblKiemtra.Rows.Count > 0 Then
            If Convert.ToBoolean(tblKiemtra.Rows(0).Item("HOPLE")) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Sub Hien()
        Me.txtDonvi.Visible = True
        Me.txtDonvi_.Height = 21
        Me.txtDonvi_.Width = 147
        chkDieudong.Visible = True
    End Sub
    Private Sub ClearTT()
        Me.txtMa.Clear()
        Me.txtSoCMND.Clear()
        Me.txtSotaikhoan.Clear()
        Me.txtTen.Clear()
        Me.dtpNgayvao.Value = Now.Date
        Me.dtpNgayvay.Value = Now.Date
        Me.dtpNgayHoanVon.Value = Now.Date
        Me.chkHoanvon.Checked = False
        Me.txtDonvi.Clear()
        Me.txtDonvi_.Clear()
        Me.dtpNgaythoiviec.Text = ""
        Me.chkThoiviec.Checked = False
        Me.txtLoaithoiviec.Clear()
        Me.txtLyDo.Clear()
        txtSotaikhoan.Focus()
        Me.cboNgayvayvon.Items.Clear()
        Me.lblSolanvay.Visible = False
        Me.txtSolanvay.Clear()
        Me.txtSolanvay.Visible = False
        obj.setnull()
    End Sub
    Private Sub txtMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.ValueChanged
        If Me.chkSothe.Checked Then
            TimSothe()
        End If
    End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        If KiemTraTrong() Then
            Dim tableTam, tableTV As DataTable
            Dim tngay As Date = Me.dtpNgayvay.Value

            obj.NV_MA = Me.txtMa.Text
            obj.NGAYBD = tngay.Year.ToString() + "/" + tngay.Month.ToString() + "/" + tngay.Day.ToString()
            If Me.chkHoanvon.Checked Then
                obj.HoanVon = 1
                Dim tngayhoanvon As Date = Me.dtpNgayHoanVon.Value
                obj.NGAYHOANVON = tngayhoanvon.Year.ToString() + "/" + tngayhoanvon.Month.ToString() + "/" + tngayhoanvon.Day.ToString()
            Else
                obj.HoanVon = 0
                obj.NGAYHOANVON = ""
            End If
            obj.ChonBang = 1
            tableTam = Me.b.LoadDS(obj)
            If tableTam.Rows.Count > 0 Then
                obj.TenCot = "''NV_MA''"
                obj.ChonBang = 6
                tableTV = Me.b.LoadDS(obj)
                If tableTV.Rows.Count > 0 Then
                    MessageBox.Show("Không thể thêm số thẻ thôi việc vào danh sách vay vốn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Me.b.InsertInfo(obj) Then
                        MessageBox.Show("Đã thêm vào danh sách vay vốn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Không tìm thấy số thẻ trong hồ sơ nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        ClearTT()
        methodLoad()
    End Sub
    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        If KiemTraTrong() Then
            Dim tableTam, tableKT As DataTable
            Dim tngay As Date

            obj.NV_MA = Me.txtMa.Text
            If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
                ''================= lấy từ datetimepicker ==================''
                tngay = Me.dtpNgayvay.Value
                obj.NGAYBD = tngay.Year.ToString() + "/" + tngay.Month.ToString() + "/" + tngay.Day.ToString()

            ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then
            Else
                ''================= lấy từ combobox ==================''
                tngay = Me.cboNgayvayvon.Value
                obj.NGAYBD = tngay.Year.ToString() + "-" + tngay.Month.ToString() + "-" + tngay.Day.ToString()
            End If

            If Me.chkHoanvon.Checked Then
                obj.HoanVon = 1
                Dim tngayhoanvon As Date = Me.dtpNgayHoanVon.Value
                obj.NGAYHOANVON = tngayhoanvon.Year.ToString() + "/" + tngayhoanvon.Month.ToString() + "/" + tngayhoanvon.Day.ToString()
            Else
                obj.HoanVon = 0
                obj.NGAYHOANVON = ""
            End If

            obj.ChonBang = 3
            tableTam = Me.b.LoadDS(obj)
            If tableTam.Rows.Count > 0 Then
                If Me.b.UpdateInfo(obj) Then
                    MessageBox.Show("Đã cập nhật vào danh sách vay vốn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Không tìm thấy số thẻ trong danh sách vay vốn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        ClearTT()
        methodLoad()
    End Sub
    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        HuyBo()
        methodLoad()
    End Sub
    Private Sub btnEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub btnLoc_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoc.Activate
        methodLoad()
        An()
    End Sub
    Private Sub TrangThaiThem()
        Me.btnThem.Enabled = True
        Me.btnSua.Enabled = False
        Me.btnXoa.Enabled = False
        Me.dtpNgayvay.Enabled = True
        Me.dtpNgayvay.Value = Now.Date()
        Me.dtpNgayHoanVon.Enabled = False
        Me.chkHoanvon.Checked = False
        Me.dtpNgayHoanVon.Value = Nothing
        Me.chkSothe.Checked = True
        Me.txtMa.Focus()
        ''=========== ẩn cbobox ngày vay vốn =========''
        Me.cboNgayvayvon.Visible = False
        Me.dtpNgayvay.Visible = True
    End Sub
    Private Sub TrangThaiSua()
        Me.btnThem.Enabled = False
        Me.btnSua.Enabled = True
        Me.btnXoa.Enabled = True
        Me.dtpNgayvay.Enabled = False
        ''=========== hiện cbobox ngày vay vốn =========''
        Me.dtpNgayvay.Visible = False
        Me.cboNgayvayvon.Visible = True
        Me.cboNgayvayvon.SortStyle = ValueListSortStyle.DescendingByValue
    End Sub
    Private Sub TimSothe()
        Dim tableNV, tableVayVon As New DataTable

        If Me.txtMa.TextLength = 6 Then
            obj.ChonBang = 1
            obj.TenCot = "''NV_MA''"
            obj.NV_MA = Me.txtMa.Text
            obj.TimNgayHoanVon = 0
            flagTim = 1
            tableNV = Me.b.LoadDS(obj)

            If tableNV.Rows.Count > 0 Then
                Me.txtTen.Text = tableNV.Rows(0).Item("NV_TEN").ToString()
                Me.txtSoCMND.Text = tableNV.Rows(0).Item("NV_CMND").ToString
                Me.txtSotaikhoan.Text = tableNV.Rows(0).Item("SOTAIKHOAN").ToString()
                Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                If tableNV.Rows(0).Item("NV_GioiTinh") = True Then
                    radGioiTinh.CheckedIndex = 0
                Else
                    radGioiTinh.CheckedIndex = 1
                End If
                Me.dtpNgayvao.Text = tableNV.Rows(0).Item("NV_NGAYVAO").ToString()

                TinhSoLanVay(4, obj.TenCot)
                ''=========== lay ngay vay von len combo =======''
                obj.ChonBang = 5 ''tên cột, số thẻ đã lấy dòng If trên
                tableVayVon = Me.b.LoadDS(obj)

                If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
                    ''============= hoan von roi: duoc vay tiep ============''
                    If KiemTra_HoanVonChua(obj.NV_MA) Then
                        TrangThaiThem()
                    Else

                        Me.btnThem.Enabled = False
                        Me.btnSua.Enabled = True
                        Me.btnXoa.Enabled = False
                        Me.dtpNgayvay.Enabled = False
                        Me.dtpNgayvay.Value = tableVayVon.Rows(0).Item("NGAYBDVAY")
                        If tableNV.Rows(0).Item("HOANVON").ToString() = "" OrElse tableNV.Rows(0).Item("HOANVON") = 0 Then
                            Me.chkHoanvon.Checked = False
                            Me.dtpNgayHoanVon.Value = Nothing
                            Me.dtpNgayHoanVon.Enabled = False
                        Else
                            Me.chkHoanvon.Checked = True
                            Me.dtpNgayHoanVon.Value = tableNV.Rows(0).Item("NGAYHOANVON")
                            Me.dtpNgayHoanVon.Enabled = True
                        End If
                    End If
                ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then ''chua co trong bang vay von
                    TrangThaiThem()
                Else
                    ''============== tu 2 lan tro len ==========''
                    If KiemTra_HoanVonChua(obj.NV_MA) Then
                        TrangThaiThem()
                    Else
                        TrangThaiSua()
                        ''=================== được chọn ngày vay từ combo, không đc xóa từ tìm số thẻ ===============''
                        Me.cboNgayvayvon.Enabled = True
                        Me.btnXoa.Enabled = False
                        If tableVayVon.Rows.Count > 0 Then
                            ''=================== remove item trong cbo ngay vay von ==========''
                            Me.cboNgayvayvon.Items.Clear()
                            For i = 0 To tableVayVon.Rows.Count - 1
                                Me.cboNgayvayvon.Items.Add(tableVayVon.Rows(i).Item("NGAYBDVAY"))
                            Next
                            Me.cboNgayvayvon.SelectedIndex = 0  ''hiển thị giá trị đầu tiên lên combo
                            ''============ gán giá trị ngày hoàn vốn bằng index của dòng có ngày vay vốn ===========''
                            For i = 0 To Me.cboNgayvayvon.Items.Count - 1
                                If tableVayVon.Rows(i).Item("NGAYBDVAY").ToString() = cboNgayvayvon.SelectedItem.DataValue.ToString() Then
                                    Me.chkHoanvon.Checked = Convert.ToBoolean(tableVayVon.Rows(i).Item("HOANVON"))
                                    Me.dtpNgayHoanVon.Value = tableVayVon.Rows(i).Item("NGAYHOANVON")
                                    Me.dtpNgayHoanVon.Enabled = True
                                End If
                            Next
                        Else
                            Me.chkHoanvon.Checked = False
                            Me.dtpNgayHoanVon.Value = Nothing
                            Me.dtpNgayHoanVon.Enabled = False
                        End If
                    End If
                End If

                If tableNV.Rows(0).Item("DATHOIVIEC") = 1 Then
                    Me.chkThoiviec.Checked = True
                Else
                    Me.chkThoiviec.Checked = False
                End If
                Me.dtpNgaythoiviec.Text = tableNV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                Me.txtLoaithoiviec.Text = tableNV.Rows(0).Item("LTV_Ten").ToString()
                Me.txtLyDo.Text = tableNV.Rows(0).Item("TV_LYDO").ToString()
                ''===============an hien textbox don vi cu ===========
                If tableNV.Rows(0).Item("DV_MA").ToString() = tableNV.Rows(0).Item("DV_MA_").ToString() Then
                    An()
                Else
                    Hien()
                End If
                ''================= xet trang thai dieu dong ============
                If tableNV.Rows(0).Item("IT_DDNGHIVIEC") = True Then
                    Me.chkDieudong.Checked = True
                    '' the hien 2 don vi: dv_ma va dv_ma_
                    Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                Else
                    Me.chkDieudong.Checked = False
                    Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                End If
            Else
                MessageBox.Show("Số thẻ: " & Me.txtMa.Text & " không tìm thấy trong hồ sơ nhân sự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearTT()
            End If
        End If
    End Sub
    Private Sub TimSoTaiKhoan()
        Dim tableNV, tableVayVon As New DataTable
        obj.ChonBang = 1
        obj.SOTAIKHOAN = Me.txtSotaikhoan.Text.Trim()
        obj.TenCot = "''SOTAIKHOAN''"
        obj.TimNgayHoanVon = 0
        Me.flagTim = 1
        flagTimSoTaiKhoan = 1
        tableNV = Me.b.LoadDS(obj)
        If tableNV.Rows.Count > 0 Then
            ''============== tim thay dung 1 dong ===========
            If tableNV.Rows.Count = 1 Then
                Me.txtMa.Text = tableNV.Rows(0).Item("NV_MA").ToString()
                Me.txtTen.Text = tableNV.Rows(0).Item("NV_TEN").ToString()
                Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                Me.txtSotaikhoan.Text = tableNV.Rows(0).Item("SOTAIKHOAN").ToString()
                Me.txtSoCMND.Text = tableNV.Rows(0).Item("NV_CMND").ToString()
                If tableNV.Rows(0).Item("NV_GioiTinh") = True Then
                    radGioiTinh.CheckedIndex = 0
                Else
                    radGioiTinh.CheckedIndex = 1
                End If
                Me.dtpNgayvao.Text = tableNV.Rows(0).Item("NV_NGAYVAO").ToString()

                TinhSoLanVay(4, obj.TenCot)

                ''=========== lay ngay vay von len combo =======''
                obj.ChonBang = 5 ''tên cột, số thẻ đã lấy dòng If trên
                tableVayVon = Me.b.LoadDS(obj)

                If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
                    ''============= hoan von roi: duoc vay tiep ============''
                    If KiemTra_HoanVonChua(obj.NV_MA) Then
                        TrangThaiThem()
                    Else

                        Me.btnThem.Enabled = False
                        Me.btnSua.Enabled = True
                        Me.btnXoa.Enabled = False
                        Me.dtpNgayvay.Enabled = False
                        Me.dtpNgayvay.Value = tableVayVon.Rows(0).Item("NGAYBDVAY")
                        If tableNV.Rows(0).Item("HOANVON").ToString() = "" OrElse tableNV.Rows(0).Item("HOANVON") = 0 Then
                            Me.chkHoanvon.Checked = False
                            Me.dtpNgayHoanVon.Value = Nothing
                            Me.dtpNgayHoanVon.Enabled = False
                        Else
                            Me.chkHoanvon.Checked = True
                            Me.dtpNgayHoanVon.Value = tableNV.Rows(0).Item("NGAYHOANVON")
                            Me.dtpNgayHoanVon.Enabled = True
                        End If
                    End If
                ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then ''chua co trong bang vay von
                    TrangThaiThem()
                Else
                    ''============== tu 2 lan tro len ==========''
                    If KiemTra_HoanVonChua(obj.NV_MA) Then
                        TrangThaiThem()
                    Else
                        TrangThaiSua()
                        ''=================== được chọn ngày vay từ combo, không đc xóa từ tìm số thẻ ===============''
                        Me.cboNgayvayvon.Enabled = True
                        Me.btnXoa.Enabled = False
                        If tableVayVon.Rows.Count > 0 Then
                            ''=================== remove item trong cbo ngay vay von ==========''
                            Me.cboNgayvayvon.Items.Clear()
                            For i = 0 To tableVayVon.Rows.Count - 1
                                Me.cboNgayvayvon.Items.Add(tableVayVon.Rows(i).Item("NGAYBDVAY"))
                            Next
                            Me.cboNgayvayvon.SelectedIndex = 0  ''hiển thị giá trị đầu tiên lên combo
                            ''============ gán giá trị ngày hoàn vốn bằng index của dòng có ngày vay vốn ===========''
                            For i = 0 To Me.cboNgayvayvon.Items.Count - 1
                                If tableVayVon.Rows(i).Item("NGAYBDVAY").ToString() = cboNgayvayvon.SelectedItem.DataValue.ToString() Then
                                    Me.chkHoanvon.Checked = Convert.ToBoolean(tableVayVon.Rows(i).Item("HOANVON"))
                                    Me.dtpNgayHoanVon.Value = tableVayVon.Rows(i).Item("NGAYHOANVON")
                                    Me.dtpNgayHoanVon.Enabled = True
                                End If
                            Next
                        Else
                            Me.chkHoanvon.Checked = False
                            Me.dtpNgayHoanVon.Value = Nothing
                            Me.dtpNgayHoanVon.Enabled = False
                        End If
                    End If
                End If
                If tableNV.Rows(0).Item("DATHOIVIEC") = 1 Then
                    Me.chkThoiviec.Checked = True
                Else
                    Me.chkThoiviec.Checked = False
                End If
                Me.dtpNgaythoiviec.Text = tableNV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                Me.txtLoaithoiviec.Text = tableNV.Rows(0).Item("LTV_Ten").ToString()
                Me.txtLyDo.Text = tableNV.Rows(0).Item("TV_LYDO").ToString()
                ''===============an hien textbox don vi cu ===========
                If tableNV.Rows(0).Item("DV_MA").ToString() = tableNV.Rows(0).Item("DV_MA_").ToString() Then
                    An()
                Else
                    Hien()
                End If
                ''================= xet trang thai dieu dong ============
                If tableNV.Rows(0).Item("IT_DDNGHIVIEC") = True Then
                    Me.chkDieudong.Checked = True
                    '' the hien 2 don vi: dv_ma va dv_ma_
                    Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                Else
                    Me.chkDieudong.Checked = False
                    Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                End If
            Else
                ''==================== tim thay tren 2 dong cung co so tai khoan nay
                ClearTT()
                If (MessageBox.Show(("Đã tìm thấy : " & tableNV.Rows.Count & " dòng có số tài khoản ngày.Bạn muốn xem thông tin không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.dgrBC.DataSource = tableNV
                    Me.btnThem.Enabled = False
                    Me.btnSua.Enabled = False
                    Me.btnXoa.Enabled = False
                Else
                    methodLoad()
                End If
            End If

        Else
            MessageBox.Show("Số tài khoản: " & Me.txtSotaikhoan.Text & " không tìm thấy trong hồ sơ nhân sự hoặc đã thôi việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearTT()
        End If
    End Sub
    Private Sub TimSoCMND()
        Dim tableNV, tableVayVon As New DataTable
        If Me.txtSoCMND.TextLength >= 9 Then
            obj.ChonBang = 1
            obj.NV_CMND = Me.txtSoCMND.Text.Trim()
            obj.TenCot = "''NV_CMND''"
            obj.TimNgayHoanVon = 0
            Me.flagTim = 1
            tableNV = Me.b.LoadDS(obj)

            If tableNV.Rows.Count > 0 Then
                ''============== tim thay dung 1 dong ===========
                If tableNV.Rows.Count = 1 Then
                    Me.txtMa.Text = tableNV.Rows(0).Item("NV_MA").ToString()
                    Me.txtTen.Text = tableNV.Rows(0).Item("NV_TEN").ToString()
                    Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                    Me.txtSotaikhoan.Text = tableNV.Rows(0).Item("SOTAIKHOAN").ToString()
                    Me.txtSoCMND.Text = tableNV.Rows(0).Item("NV_CMND").ToString()
                    If tableNV.Rows(0).Item("NV_GioiTinh") = True Then
                        radGioiTinh.CheckedIndex = 0
                    Else
                        radGioiTinh.CheckedIndex = 1
                    End If
                    Me.dtpNgayvao.Text = tableNV.Rows(0).Item("NV_NGAYVAO").ToString()

                    TinhSoLanVay(4, obj.TenCot)
                    ''=========== lay ngay vay von len combo =======''
                    obj.ChonBang = 5 ''tên cột, số thẻ đã lấy dòng If trên
                    tableVayVon = Me.b.LoadDS(obj)

                    If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
                        ''============= hoan von roi: duoc vay tiep ============''
                        If KiemTra_HoanVonChua(obj.NV_MA) Then
                            TrangThaiThem()
                        Else

                            Me.btnThem.Enabled = False
                            Me.btnSua.Enabled = True
                            Me.btnXoa.Enabled = False
                            Me.dtpNgayvay.Enabled = False
                            Me.dtpNgayvay.Value = tableVayVon.Rows(0).Item("NGAYBDVAY")
                            If tableNV.Rows(0).Item("HOANVON").ToString() = "" OrElse tableNV.Rows(0).Item("HOANVON") = 0 Then
                                Me.chkHoanvon.Checked = False
                                Me.dtpNgayHoanVon.Value = Nothing
                                Me.dtpNgayHoanVon.Enabled = False
                            Else
                                Me.chkHoanvon.Checked = True
                                Me.dtpNgayHoanVon.Value = tableNV.Rows(0).Item("NGAYHOANVON")
                                Me.dtpNgayHoanVon.Enabled = True
                            End If
                        End If
                    ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then ''chua co trong bang vay von
                        TrangThaiThem()
                    Else
                        ''============== tu 2 lan tro len ==========''
                        If KiemTra_HoanVonChua(obj.NV_MA) Then
                            TrangThaiThem()
                        Else
                            TrangThaiSua()
                            ''=================== được chọn ngày vay từ combo, không đc xóa từ tìm số thẻ ===============''
                            Me.cboNgayvayvon.Enabled = True
                            Me.btnXoa.Enabled = False
                            If tableVayVon.Rows.Count > 0 Then
                                ''=================== remove item trong cbo ngay vay von ==========''
                                Me.cboNgayvayvon.Items.Clear()
                                For i = 0 To tableVayVon.Rows.Count - 1
                                    Me.cboNgayvayvon.Items.Add(tableVayVon.Rows(i).Item("NGAYBDVAY"))
                                Next
                                Me.cboNgayvayvon.SelectedIndex = 0  ''hiển thị giá trị đầu tiên lên combo
                                ''============ gán giá trị ngày hoàn vốn bằng index của dòng có ngày vay vốn ===========''
                                For i = 0 To Me.cboNgayvayvon.Items.Count - 1
                                    If tableVayVon.Rows(i).Item("NGAYBDVAY").ToString() = cboNgayvayvon.SelectedItem.DataValue.ToString() Then
                                        Me.chkHoanvon.Checked = Convert.ToBoolean(tableVayVon.Rows(i).Item("HOANVON"))
                                        Me.dtpNgayHoanVon.Value = tableVayVon.Rows(i).Item("NGAYHOANVON")
                                        Me.dtpNgayHoanVon.Enabled = True
                                    End If
                                Next
                            Else
                                Me.chkHoanvon.Checked = False
                                Me.dtpNgayHoanVon.Value = Nothing
                                Me.dtpNgayHoanVon.Enabled = False
                            End If
                        End If
                    End If

                    If tableNV.Rows(0).Item("DATHOIVIEC") = 1 Then
                        Me.chkThoiviec.Checked = True
                    Else
                        Me.chkThoiviec.Checked = False
                    End If
                    Me.dtpNgaythoiviec.Text = tableNV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                    Me.txtLoaithoiviec.Text = tableNV.Rows(0).Item("LTV_Ten").ToString()
                    Me.txtLyDo.Text = tableNV.Rows(0).Item("TV_LYDO").ToString()
                    ''===============an hien textbox don vi cu ===========
                    If tableNV.Rows(0).Item("DV_MA").ToString() = tableNV.Rows(0).Item("DV_MA_").ToString() Then
                        An()
                    Else
                        Hien()
                    End If

                    ''================= xet trang thai dieu dong ============
                    If tableNV.Rows(0).Item("IT_DDNGHIVIEC") = True Then
                        Me.chkDieudong.Checked = True
                        '' the hien 2 don vi: dv_ma va dv_ma_
                        Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                        Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                    Else
                        Me.chkDieudong.Checked = False
                        Me.txtDonvi_.Text = tableNV.Rows(0).Item("DV_MA_").ToString()
                        Me.txtDonvi.Text = tableNV.Rows(0).Item("DV_MA").ToString()
                    End If
                Else
                    ''==================== tim thay tren 2 dong cung co so cmnd
                    ClearTT()
                    If (MessageBox.Show(("Đã tìm thấy : " & tableNV.Rows.Count & " dòng có số CMND ngày.Bạn muốn xem thông tin không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                        Me.dgrBC.DataSource = tableNV
                        Me.btnThem.Enabled = False
                        Me.btnSua.Enabled = False
                        Me.btnXoa.Enabled = False
                    Else
                        methodLoad()
                    End If
                End If
            Else
                MessageBox.Show("Số chứng minh: " & Me.txtSoCMND.Text & " không tìm thấy trong hồ sơ nhân sự hoặc đã thôi việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearTT()
            End If
        End If
    End Sub
    Private Sub chkSothe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSothe.CheckedChanged
        ''============ tim theo so the
        If chkSothe.Checked Then
            Me.txtMa.Enabled = True
            Me.txtSoCMND.Enabled = False
            Me.txtSotaikhoan.Enabled = False
            TimSothe()
        Else
            ''====================== tim theo so CMND
            flagTim = 1
            Me.txtMa.Enabled = False
            Me.txtSoCMND.Enabled = True
            Me.txtSotaikhoan.Enabled = True
            ClearTT()
            Me.txtSoCMND.Focus()
        End If
    End Sub
    Private Sub txtSoCMND_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoCMND.ValueChanged
        If Me.chkSothe.Checked = False And flagTim = 1 And Me.txtSoCMND.Text.ToString().Trim() <> "" And flagTimSoTaiKhoan = 0 Then
            TimSoCMND()
        End If
    End Sub
    Private Sub txtSotaikhoan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSotaikhoan.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And Me.chkSothe.Checked = False And Me.txtSotaikhoan.Text.ToString().Trim() <> "" Then
            TimSoTaiKhoan()
        End If
    End Sub
    Private Sub chkHoanvon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHoanvon.CheckedChanged
        If Me.chkHoanvon.Checked Then
            Me.dtpNgayHoanVon.Enabled = True
        Else
            Me.dtpNgayHoanVon.Enabled = False
            Me.dtpNgayHoanVon.Text = ""
        End If
    End Sub
    Private Sub cboNgayvayvon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNgayvayvon.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub
    Private Sub cboNgayvayvon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNgayvayvon.SelectionChanged
        Dim tableTam As DataTable
        Dim ngayvay As Date
        obj.TimNgayHoanVon = 1
        obj.ChonBang = 5
        obj.TenCot = "''NV_MA''"
        obj.NV_MA = Me.txtMa.Text
        If Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 1 Then
        ElseIf Convert.ToInt32(Me.txtSolanvay.Text.ToString()) = 0 Then
        Else
            ngayvay = Me.cboNgayvayvon.Value
            obj.NGAYBD = ngayvay.Year.ToString() + "-" + ngayvay.Month.ToString() + "-" + ngayvay.Day.ToString()
        End If
        tableTam = Me.b.LoadDS(obj)
        If tableTam.Rows.Count > 0 Then
            If tableTam.Rows(0).Item("HOANVON").ToString() = "" OrElse tableTam.Rows(0).Item("HOANVON") = 0 Then
                Me.chkHoanvon.Checked = False
                Me.dtpNgayHoanVon.Value = Nothing
                Me.dtpNgayHoanVon.Enabled = False
            Else
                Me.chkHoanvon.Checked = True
                Me.dtpNgayHoanVon.Value = tableTam.Rows(0).Item("NGAYHOANVON")
                Me.dtpNgayHoanVon.Enabled = True
            End If
        End If
    End Sub
    Private Sub cboNgayvayvon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNgayvayvon.KeyPress
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Or Char.GetNumericValue(e.KeyChar) >= 0 Or Char.IsDigit(e.KeyChar) = False Or Char.IsDigit(e.KeyChar) = True)) Then
            e.Handled = True
        End If
    End Sub
End Class