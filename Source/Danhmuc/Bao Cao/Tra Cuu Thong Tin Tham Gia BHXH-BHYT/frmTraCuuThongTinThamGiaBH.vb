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
Public Class frmTraCuuThongTinThamGiaBH
    Inherits Form
    Public ThemSua As Integer
    Friend WithEvents b As ClsBTraCuuThongTinThamGiaBH
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate

        Dim obj As New ObjTraCuuThongTinThamGiaBH
        Dim b As New ClsBTraCuuThongTinThamGiaBH
        Me.b = New ClsBTraCuuThongTinThamGiaBH

        If Me.dtpTuNgay.Text.ToString() <> "" And Me.dtpDenNgay.Text.ToString() <> "" Then
            obj.ChonBang = 1
            Dim grid As New clsTformatGrid
            clsTools.GridTheme1(Me.dgrBC)
            obj.TUNGAY = Me.dtpTuNgay.Value.Year.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Day.ToString()
            obj.DENNGAY = Me.dtpDenNgay.Value.Year.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Day.ToString()
            If dtpTuNgay.Value > dtpDenNgay.Value Then
                MessageBox.Show("Vui lòng chọn ngày kết thúc >= ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            LoadGridView()
            Dim dgrBC As Object = Me.dgrBC
            ' grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/TraCuuThongTinThamGiaBH.xml"), typeControl.Grid, "coldgrNghiPhep")
        End If

    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            If (MessageBox.Show("Đã xuất file excel xong, bạn có muốn mở file đã lưu ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        End If
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next
                .Columns("STT").Header.Caption = "STT"
                .Columns("NV_MA").Header.Caption = "Số thẻ"
                .Columns("DV_MA").Header.Caption = "Đơn vị"
                .Columns("NV_Ten_NLD").Header.Caption = "Họ tên NLĐ"
                .Columns("NV_NGAYSINH").Header.Caption = "Ngày sinh NLĐ"
                .Columns("GIOITINH").Header.Caption = "Giới tính NLĐ"
                .Columns("DT_Ten").Header.Caption = "Dân tộc"
                .Columns("NV_CMND").Header.Caption = "CMND NLĐ"

                .Columns("NV_NAMSINH").Header.Caption = "Năm sinh NLĐ"
                .Columns("DV_MA").Header.Caption = "Đơn vị"
                .Columns("NV_Ngayvao").Header.Caption = "Ngày vào"
                .Columns("QT_Ten").Header.Caption = "Quốc tịch"
                .Columns("NV_NgayCapCMND").Header.Caption = "Ngày cấp CMND NLĐ"
                .Columns("NV_NoiCapCMND").Header.Caption = "Nơi cấp CMND NLĐ"
                .Columns("NV_CMND").Header.Caption = "Số CMND"
                .Columns("GIOITINH").Header.Caption = "Giới tính" & Chr(10) & "(Nam/Nữ) "
                .Columns("DT_Ten").Header.Caption = "Dân tộc"
                .Columns("MOIQHNLD").Header.Caption = "Quan hệ với NLĐ"

                .Columns("DV_MA").Hidden = True
                .Columns("NV_Ngayvao").Hidden = True

                .Columns("NV_NAMSINH").Hidden = True
                .Columns("NV_Ngayvao").Hidden = True
                .Columns("QT_Ten").Hidden = True
                .Columns("NV_NgayCapCMND").Hidden = True
                .Columns("NV_NoiCapCMND").Hidden = True


                .Columns("NV_MA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns("GIOITINH").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns("NV_NGAYSINH").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns("NV_CMND").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                '.Columns("NV_NGAYSINH_NLD").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                '.Columns("NV_NGAYSINH_QH").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                '.Columns("SOCMND_QH").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

                .Columns("XA_KHAISINH").Header.Caption = "Xã" & Chr(10) & "(Nơi Đăng ký giấy khai sinh-Nguyên quán )"

                .Columns("HUYEN_KHAISINH").Header.Caption = "Huyện" & Chr(10) & "(Nơi Đăng ký giấy khai sinh-Nguyên quán )"
                .Columns("TINH_KHAISINH").Header.Caption = "Tỉnh" & Chr(10) & "(Nơi Đăng ký giấy khai sinh-Nguyên quán )"

                .Columns("NV_DCSoNha_HOKHAU").Header.Caption = "Số nhà,đường phố,thôn xóm" & Chr(10) & "(Địa chỉ )"

                .Columns("XA_HOKHAU").Header.Caption = "Xã" & Chr(10) & "(Địa chỉ )"
                .Columns("HUYEN_HOKHAU").Header.Caption = "Huyện" & Chr(10) & "(Địa chỉ )"
                .Columns("TINH_HOKHAU").Header.Caption = "Tỉnh" & Chr(10) & "(Địa chỉ )"

                .Columns("TENQUANHE").Header.Caption = "Họ và tên (*)"

                .Columns("NV_NGAYSINH_QH").Header.Caption = "Ngày sinh " & Chr(10) & "(Chỉ nhập năm nếu chỉ nhớ năm sinh) "
                .Columns("MOIQH_CHUHO").Header.Caption = "Mối quan hệ với chủ hộ"
                .Columns("GT_QUANHE").Header.Caption = "Giới tính" & Chr(10) & "(Nam/Nữ)"
                .Columns("NOICAPKHAISINH_QH").Header.Caption = "Nơi cấp giấy khai sinh-Nguyên quán " & Chr(10) & "(Nhập Xã-huyện-Tỉnh)"
                .Columns("SOCMND_QH").Header.Caption = "Số CMND"
                .Columns("TENCHUHO").Header.Caption = "Họ tên chủ hộ"
                .Columns("SOSOHK_QH").Header.Caption = "Số sổ hộ khẩu"

                .Columns("DIACHI_QH").Header.Caption = "Địa chỉ " & Chr(10) & "(Nhập Ấp-Xã-huyện-Tỉnh)"

                .Columns("TENQUANHE").Width = 200
                .Columns("DV_MA").Width = 150
                .Columns("NV_NGAYSINH_QH").Width = 150
                .Columns("MOIQH_CHUHO").Width = 150
                .Columns("GT_QUANHE").Width = 100
                .Columns("NOICAPKHAISINH_QH").Width = 200
                .Columns("SOCMND_QH").Width = 120
                .Columns("TENCHUHO").Width = 200
                .Columns("DIACHI_QH").Width = 250

                Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
                band.Layout.Override.FilterUIType = FilterUIType.FilterRow
                band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
                band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
                band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
                band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
                band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
                band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
                band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
                band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)


                'Column Chooser
                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(11)
                band.Layout.Bands(0).Summaries.Clear()
                Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                summary.Appearance.TextHAlign = HAlign.Right
                band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                band.SummaryFooterCaption = "Tổng số: "
                band = Nothing
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Me.dgrBC.DisplayLayout.Bands.Item(0).ColHeaderLines = 2
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        'e.Row.Cells("STT").Value = e.Row.Index + 1
        'e.Row.Update()
    End Sub

End Class