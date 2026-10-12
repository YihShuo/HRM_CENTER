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
Public Class frmTraCuuNhanhNV
    ' Methods
    ''Người tạo : Trân
    ''Ngày tạo : 02-06-2013
    ''Nội dung tạo : Tạo form tra cứu thông tin nhân viên
    ''Người cập nhật :  Trân
    ''Ngày cập nhật : 06-08-2013,09-08-2013,01/07/2014
    ''Nội dung cập nhật : Thêm cột đơn vị điều động, sửa lỗi check change không hiển thị.ngày 09-08-2013 thêm cột công việc
    ''bổ sung thêm cột thường trú, ngày cấp, nơi cấp cmnd, số điện thoại di động, đt nhà riêng
    ''===============================================
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New objTraCuuNhanhNV

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        e.Layout.Bands(0).Columns("NV_MA").Header.Caption = "Số thẻ"
        e.Layout.Bands(0).Columns("NV_GIOITINH").Header.Caption = "Giới tính"
        e.Layout.Bands(0).Columns("NV_TEN").Header.Caption = "Họ tên"
        e.Layout.Bands(0).Columns("TV_NGAYTHOIVIEC").Header.Caption = "Ngày thôi việc"
        e.Layout.Bands(0).Columns("NV_TEN").Width = 200
        e.Layout.Bands(0).Columns("DV_MA").Header.Caption = "Đơn vị"
        e.Layout.Bands(0).Columns("DV_MA").Width = 200
        e.Layout.Bands(0).Columns("DV_MA_").Header.Caption = "Đơn vị điều động"
        e.Layout.Bands(0).Columns("NV_NGAYVAO").Header.Caption = "Ngày vào"
        e.Layout.Bands(0).Columns("HV_TEN").Header.Caption = "Học vấn"
        e.Layout.Bands(0).Columns("HV_TEN").Width = 50
        e.Layout.Bands(0).Columns("DT_TEN").Header.Caption = "Dân tộc"
        e.Layout.Bands(0).Columns("DT_TEN").Width = 90
        'e.Layout.Bands(0).Columns("cv_ma").Header.Caption = "Mã công việc"
        'e.Layout.Bands(0).Columns("cv_ten").Header.Caption = "Tên công việc"
        'e.Layout.Bands(0).Columns("cvu_ten").Header.Caption = "Chức vụ"
        e.Layout.Bands(0).Columns("nv_diachi").Header.Caption = "Địa chỉ"
        e.Layout.Bands(0).Columns("nv_diachi").Width = 300
        e.Layout.Bands(0).Columns("nv_noisinh").Header.Caption = "Nơi sinh"
        e.Layout.Bands(0).Columns("nv_noisinh").Width = 100
        e.Layout.Bands(0).Columns("nv_matu").Header.Caption = "Mã từ"
        e.Layout.Bands(0).Columns("nv_ngaysinh").Header.Caption = "Ngày sinh"
        e.Layout.Bands(0).Columns("CHICONAMSINH").Header.Caption = "Chỉ có năm sinh"
        e.Layout.Bands(0).Columns("CHICONAMSINH").Width = 100
        e.Layout.Bands(0).Columns("nv_ngaysinh").Width = 90
        e.Layout.Bands(0).Columns("nv_cmnd").Header.Caption = "Số CMND"
        e.Layout.Bands(0).Columns("namvao").Header.Caption = "Năm vào"
        e.Layout.Bands(0).Columns("namvao").Hidden = True
        e.Layout.Bands(0).Columns("namsinh").Header.Caption = "Năm sinh"
        e.Layout.Bands(0).Columns("namsinh").Hidden = True
        e.Layout.Bands(0).Columns("CV_DOCHAI").Hidden = True
        e.Layout.Bands(0).Columns("TTCV").Hidden = True
        e.Layout.Bands(0).Columns("NV_THUONGTRU").Hidden = True
        e.Layout.Bands(0).Columns("TV").Header.Caption = "Thôi việc"
        e.Layout.Bands(0).Columns("TV").Width = 90

        e.Layout.Bands(0).Columns("CV_MA").Header.Caption = "Mã công việc"
        e.Layout.Bands(0).Columns("CV_TEN").Header.Caption = "Tên công việc"
        e.Layout.Bands(0).Columns("CV_DOCHAI").Header.Caption = "Độc hại"
        e.Layout.Bands(0).Columns("TTCV").Header.Caption = "Trực tiếp"
        ''=========================== BO SUNG COT MOI ===========================''
        e.Layout.Bands(0).Columns("NV_THUONGTRU").Header.Caption = "Địa chỉ thường trú"
        e.Layout.Bands(0).Columns("NV_NgayCapCMND").Header.Caption = "Ngày cấp CMND"
        e.Layout.Bands(0).Columns("NV_NoiCapCMND").Header.Caption = "Nơi cấp CMND"
        e.Layout.Bands(0).Columns("NV_DTNhaRieng").Header.Caption = "Số điện thoại nhà riêng"
        e.Layout.Bands(0).Columns("NV_DTDiDong").Header.Caption = "Số điện thoại di động"
        e.Layout.Bands(0).Columns("MASOTHUE").Header.Caption = "Mã số thuế"
        e.Layout.Bands(0).Columns("SOTAIKHOAN").Header.Caption = "Số tài khoản"

        ''=========================== BO SUNG COT MOI ===========================''
        e.Layout.Bands(0).Columns("DVHT").Header.Caption = "Đơn vị hiện tại"
        e.Layout.Bands(0).Columns("CG").Header.Caption = "Chuyên gia"
        e.Layout.Bands(0).Columns("DT").Header.Caption = "Đồng tháp"
        e.Layout.Bands(0).Columns("BGD").Header.Caption = "Ban giám đốc"
        e.Layout.Bands(0).Columns("X_MA_DV_MA").Header.Caption = "Xưởng (đơn vị tính lương)"
        e.Layout.Bands(0).Columns("X_MA_DV_MA_").Header.Caption = "Xưởng (đơn vị điều động)"

        e.Layout.Bands(0).Columns("CNM_A").Header.Caption = "CNM Khu A"
        e.Layout.Bands(0).Columns("CNM_B").Header.Caption = "CNM Khu B"

        e.Layout.Bands(0).Columns("NV_DCSoNha_HOKHAU").Header.Caption = "Số nhà,đường phố,thôn xóm" & Chr(10) & "(Địa chỉ )"
        e.Layout.Bands(0).Columns("XA_HOKHAU").Header.Caption = "Xã" & Chr(10) & "(Địa chỉ )"
        e.Layout.Bands(0).Columns("HUYEN_HOKHAU").Header.Caption = "Huyện" & Chr(10) & "(Địa chỉ )"
        e.Layout.Bands(0).Columns("TINH_HOKHAU").Header.Caption = "Tỉnh" & Chr(10) & "(Địa chỉ )"


        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Left
            e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle

        Next
        ''thu
        e.Layout.Bands(0).Layout.Override.FilterUIType = FilterUIType.FilterRow
        e.Layout.Bands(0).Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        e.Layout.Bands(0).Layout.Override.ActiveRowAppearance.BackColor = Color.LightGreen
        'e.Layout.Bands(0).Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Bands(0).Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Bands(0).Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        e.Layout.Bands(0).Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        e.Layout.Bands(0).Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        e.Layout.Bands(0).Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        e.Layout.Bands(0).Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        e.Layout.Bands(0).Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        e.Layout.Bands(0).Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        band.ColHeaderLines = 2

        e.Layout.Bands(0).Layout.Override.FilterUIType = FilterUIType.FilterRow
        e.Layout.Bands(0).Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        'e.Layout.Bands(0).Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        ''field chooser
        e.Layout.Bands(0).Layout.Override.RowSelectors = DefaultableBoolean.True
        e.Layout.Bands(0).Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
        ''hien thi cot tong
        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing
    End Sub
    Private Sub LoadDV()
        Dim b As New ClsBTraCuuNhanhNV
        Me.b = New ClsBTraCuuNhanhNV
        Dim tam As DataTable
        obj.ChonBang = 3
        tam = Me.b.LoadDS(obj)
        tam.Rows.Add("TCT", "Toàn công ty")
        Me.cboDonvi.DataSource = tam
        Me.cboDonvi.ValueMember = "DV_MA"
        Me.cboDonvi.DisplayMember = "DV_TEN"

    End Sub
    Friend WithEvents b As ClsBTraCuuNhanhNV
    Private Sub frmTraCuuNhanhNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDV()
        Me.chkSothe.Checked = True
        Me.radDonviDD.Checked = False
        Me.radDV.Checked = False
        cboDonvi.Enabled = False
        Me.dtpNgay.Enabled = False
        Me.txtManv.Enabled = True
        Me.txtManv.Focus()
    End Sub
    Private Sub chkSothe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSothe.CheckedChanged
        If Me.chkSothe.Checked Then
            Me.radDV.Checked = False
            Me.radDonviDD.Checked = False
            Me.radNgayvao.Checked = False
            Me.txtManv.Enabled = True
            Me.dgrBC.DataSource = Nothing
            Me.cboDonvi.Enabled = False
            Me.radDilam.Enabled = False
            Me.radNghiViec.Enabled = False
        ElseIf Me.radDV.Checked Then
            Me.cboDonvi.Enabled = True
            Me.txtManv.Enabled = False
        ElseIf Me.radDonviDD.Checked Then
            Me.txtManv.Enabled = False
            Me.cboDonvi.Enabled = True
        ElseIf Me.radNgayvao.Checked Then
            Me.txtManv.Enabled = False
            Me.cboDonvi.Enabled = False
        End If
    End Sub

    Private Sub txtManv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManv.TextChanged
        If Trim(Me.txtManv.Text.Length) = 6 Then
            Dim b As New ClsBTraCuuNhanhNV
            Me.b = New ClsBTraCuuNhanhNV
            ''Tim theo so the
            If Me.chkSothe.Checked Then
                obj.MANV = Me.txtManv.Text
                obj.ChonBang = 1
                dgrBC.DataSource = Me.b.LoadDS(obj)
                If Me.b.LoadDS(obj).Rows.Count > 0 Then
                    Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                    'Me.txtTongso.Text = dgrBC.Rows.Count
                Else
                    MessageBox.Show("Không tìm thấy thông tin số thẻ: " & Me.txtManv.Text, "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub TimKiem()
        Dim tam As DataTable
        Dim tamDVNghiViec As DataTable
        ''Tim toan cong ty: lay het dv_ma va dv_ma_
        ''===================================== tim theo don vi ==========''
        If (Me.radDV.Checked Or Me.radDonviDD.Checked) And Me.cboDonvi.Text <> "" Then

            obj.Donvi = Me.cboDonvi.Value
            obj.ChonBang = 5
            tamDVNghiViec = Me.b.LoadDS(obj)

            If tamDVNghiViec.Rows.Count > 0 Then
                ''==== lọc danh sách đơn vị loại nghỉ việc chọn theo cột DV_MA 
                obj.LoaiDonViNghiViec = 1
            Else
                obj.LoaiDonViNghiViec = 0
            End If

            obj.ChonBang = 2
            If Me.cboDonvi.Value = "TCT" Then
                If Me.radDilam.Checked Then
                    obj.ChonDiLam = 1
                Else
                    obj.ChonDiLam = 0
                End If
            End If
            dgrBC.DataSource = Me.b.LoadDS(obj)
            If Me.b.LoadDS(obj).Rows.Count > 0 Then
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
                'Me.txtTongso.Text = dgrBC.Rows.Count
            Else
                MessageBox.Show("Không tìm thấy thông tin đơn vị: " & Me.cboDonvi.Text, "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If
        If Me.radNgayvao.Checked Then
            Dim ngay As Date = dtpNgay.Value
            obj.ChonBang = 4
            obj.NGAYVAO = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
            dgrBC.DataSource = Me.b.LoadDS(obj)

            If Me.b.LoadDS(obj).Rows.Count > 0 Then
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Else
                MessageBox.Show("Không có danh sách nhân viên vào công ty ngày: " & Me.dtpNgay.Text, "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


    End Sub
    Private Sub cboDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDonvi.ValueChanged
        If Not Me.cboDonvi.Value Is Nothing And Me.cboDonvi.Value = "TCT" Then
            Me.radDilam.Enabled = True
            Me.radNghiViec.Enabled = True
        Else
            Me.radDilam.Enabled = False
            Me.radNghiViec.Enabled = False
        End If
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Process.Start(Me.SaveFileDialog1.FileName)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub radDonviDD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonviDD.CheckedChanged
        If Me.radDonviDD.Checked Then
            Me.chkSothe.Checked = False
            Me.radDV.Checked = False
            Me.radNgayvao.Checked = False
            Me.cboDonvi.Enabled = True
            Me.txtManv.Enabled = False
            Me.txtManv.Clear()
            Me.dgrBC.DataSource = Nothing
            ''load lai
            TimKiem()
        End If
    End Sub
    Private Sub radDV_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDV.CheckedChanged
        If Me.radDV.Checked Then
            Me.chkSothe.Checked = False
            Me.radDonviDD.Checked = False
            Me.radNgayvao.Checked = False
            Me.cboDonvi.Enabled = True
            Me.txtManv.Enabled = False
            Me.txtManv.Clear()
            Me.dgrBC.DataSource = Nothing
            ''load lai
            TimKiem()
        End If
    End Sub
    Private Sub cboDonvi_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDonvi.KeyDown
        'If e.KeyCode = Keys.Delete Then
        '    e.Handled = True
        'End If
    End Sub
    Private Sub cboDonvi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDonvi.KeyPress
        'If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Or Char.GetNumericValue(e.KeyChar) >= 0 Or Char.IsDigit(e.KeyChar) = False Or Char.IsDigit(e.KeyChar) = True)) Then
        '    e.Handled = True
        'End If
    End Sub
    Private Sub txtManv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManv.KeyPress
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar))) Then
            e.Handled = True
        End If
    End Sub
    Private Sub radNgayvao_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radNgayvao.CheckedChanged
        If Me.radNgayvao.Checked Then
            Me.dtpNgay.Enabled = True
            Me.chkSothe.Checked = False
            Me.txtManv.Enabled = False
            Me.txtManv.Clear()
            Me.cboDonvi.Enabled = False
            ''load lai theo ngày vào
            Me.radDilam.Enabled = False
            Me.radNghiViec.Enabled = False
            TimKiem()

        Else
            Me.dtpNgay.Enabled = False
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        If Me.radNgayvao.Checked Then
            ''load lai theo ngày vào
            TimKiem()
        End If
    End Sub

    Private Sub dtpNgay_AfterDropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.AfterDropDown
        RemoveHandler dtpNgay.ValueChanged, AddressOf dtpNgay_ValueChanged
    End Sub
    Private Sub dtpNgay_AfterCloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.AfterCloseUp
        AddHandler dtpNgay.ValueChanged, AddressOf dtpNgay_ValueChanged
        Call dtpNgay_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub cboDonvi_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDonvi.SelectionChangeCommitted
        If Not Me.cboDonvi.Value Is Nothing Then
            TimKiem()
        End If
    End Sub

    Private Sub radNghiViec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNghiViec.CheckedChanged
        If Not Me.cboDonvi.Value Is Nothing And Me.cboDonvi.Value = "TCT" And Me.radNghiViec.Checked Then
            TimKiem()
        End If
    End Sub

    Private Sub radDilam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDilam.CheckedChanged
        If Not Me.cboDonvi.Value Is Nothing And Me.cboDonvi.Value = "TCT" And Me.radDilam.Checked Then
            TimKiem()
        End If
    End Sub
End Class