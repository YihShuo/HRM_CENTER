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
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.IO
Imports Infragistics.Excel
Imports Infragistics
Imports Microsoft.Office


Public Class frmThongKePNMTTheoThang
    Dim Path As String
    Dim ReportID As String
    Friend WithEvents b As clsBThongKePNMTTheoThang
    Dim oldRow As Integer = 0
    Public iThang, iNam, iNamTruoc, iNamSau, dongTCT, i, j, k, l As Integer
    Public sChuoiNhomVe15h30, sCotSTT, sCotXuong, sCotDonvi, sCotMTD7T, sCotMTTren7T, sCotNCNho, sCotTongVe15h30, sCotTongCong, sCotNghiThaiSan As String
    Public bTinhST As Boolean = False
    Public tblTableLoad As New DataTable()
    Private Sub TinhSayThai(ByVal iNam As Integer)
        Me.b = New clsBThongKePNMTTheoThang

        Dim tblTemp As DataTable
        Dim listpar As New ArrayList(1)
        Dim listpar1 As New ArrayList(1)

        listpar.Clear()
        listpar.Add(New SqlParameter("@Nam", iNam))
        tblTemp = Me.b.GoiThuTucThongKe("SP_DSMT_TINHSAYTHAI_THAISAN", listpar)
        For i = 0 To tblTemp.Rows.Count - 1

            Try
                listpar1.Add(New SqlParameter("@NV_MA", tblTemp.Rows(i).Item("NV_MA").ToString()))
                If Me.b.GoiThuTucTinhToan("SP_LAYNGUOISAYTHAI_KMAX", listpar1) Then
                    bTinhST = True
                Else
                    bTinhST = False
                End If
                listpar1.Clear()
            Catch ex As Exception
                bTinhST = False
                MessageBox.Show("Lỗi,không tính được dữ liệu sảy thai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThongKe.Activate
        Select Case Me.tabTKPNMTThang.SelectedTab.Index
            Case 0
                dgrBC.DataSource = Nothing
                dgrBC.Refresh()
                If cbkChitiet.Checked = True Then
                    Me.XpCaption2.Text = "Danh sách chi tiết thai sản tháng" & Me.dtpThang.Text
                    LoadDataGrid_chitiet()
                    If Me.dgrBC.Rows.Count > 0 Then
                        Me.btnExcel.Enabled = True
                        LoadGridView_Chitiet1()
                    Else
                        Me.btnExcel.Enabled = False
                    End If
                End If
                If cbkChitiet.Checked = False Then
                    Me.XpCaption2.Text = "Thống kê mang thai tháng " & Me.dtpThang.Text
                    LoadDataGrid()
                    If Me.dgrBC.Rows.Count > 0 Then
                        Me.btnExcel.Enabled = True
                        LoadGridView()
                    Else
                        Me.btnExcel.Enabled = False
                    End If
                End If
            Case 1
        End Select
    End Sub
    Private Sub UltraGridExcelExporter1_CellExported(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs) Handles UltraGridExcelExporter1.CellExported
        Dim cell As UltraGridCell = e.GridRow.Cells(e.GridColumn)
        Dim mergedCells() As UltraGridCell = cell.GetMergedCells()

        If Not mergedCells Is Nothing Then

            Dim isFirstCell As Boolean = True
            For Each mergedCell As UltraGridCell In mergedCells
                If cell.Row.Index > mergedCell.Row.Index Then
                    isFirstCell = False
                    Return
                End If
            Next

            If isFirstCell Then
                Dim rowIndex, colIndex As Integer

                rowIndex = e.CurrentRowIndex
                colIndex = e.CurrentColumnIndex
                e.CurrentWorksheet.MergedCellsRegions.Add(rowIndex, colIndex, rowIndex + (mergedCells.Length - 1), colIndex)
            End If
        End If
    End Sub
   
    'Private Sub LoadGridView()
    '    Try
    '        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    '        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
    '        With Me.dgrBC.DisplayLayout.Bands(0)
    '            .ClearGroupByColumns()
    '            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
    '            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

    '            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
    '                .Columns(i).CellActivation = Activation.NoEdit
    '                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
    '                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
    '            Next

    '            .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
    '            .Columns("XUONGTENHOA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
    '            .Columns("STT").Header.Caption = "STT" ''=== CỘT THỨ TỰ MẶC ĐỊNH TRONG BÁO CÁO
    '            .Columns("STT1").Header.Caption = "STT" ''====== cột thứ tự không đếm dòng toàn công ty, tổng khu A, tổng khu B
    '            .Columns("KHUHIENTHI").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
    '            .Columns("KHUHIENTHI").Header.Appearance.FontData.Bold = DefaultableBoolean.True


    '            .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("X_MA_").Hidden = True
    '            .Columns("KHU").Hidden = True
    '            .Columns("STT").Hidden = True


    '            .Columns("KHUHIENTHI").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("TONGCONG_XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("STT1").Header.Appearance.FontData.Bold = DefaultableBoolean.True

    '            .Columns("SL_MTDUOI7THANG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("SL_TTT7").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("SL_NCNHO").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("SL_NGHITS").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("TONGCONG_XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
    '            .Columns("TONGCONG_15H30XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True

    '            .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

    '            .Columns("SL_MTDUOI7THANG").Header.Caption = sCotMTD7T
    '            .Columns("SL_TTT7").Header.Caption = sCotMTTren7T
    '            .Columns("SL_NCNHO").Header.Caption = sCotNCNho
    '            .Columns("SL_NGHITS").Header.Caption = sCotNghiThaiSan
    '            .Columns("TONGCONG_15H30XUONG").Header.Caption = sCotTongVe15h30
    '            .Columns("TONGCONG_XUONG").Header.Caption = sCotTongCong
    '            .Columns("THUTU").Hidden = True
    '            .Columns("X_MA_").Hidden = True
    '            .Columns("THUTU").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
    '            .Columns("X_MA_").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
    '            .Columns("KHU").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
    '            .Columns("STT").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True

    '            .Columns("KHUHIENTHI").MergedCellStyle = MergedCellStyle.Always
    '            .Columns("KHUHIENTHI").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

    '            ''=====
    '            .Columns("STT1").Header.VisiblePosition = 0
    '            .Columns("KHUHIENTHI").Header.VisiblePosition = 1
    '            .Columns("XUONGTENHOA").Header.VisiblePosition = 2
    '            .Columns("SL_MTDUOI7THANG").Header.VisiblePosition = 3
    '            .Columns("SL_TTT7").Header.VisiblePosition = 4
    '            .Columns("SL_NCNHO").Header.VisiblePosition = 5
    '            .Columns("TONGCONG_15H30XUONG").Header.VisiblePosition = 6
    '            .Columns("SL_NGHITS").Header.VisiblePosition = 7
    '            .Columns("TONGCONG_XUONG").Header.VisiblePosition = 8

    '            .Columns("KHUHIENTHI").Width = 100
    '            .Columns("SL_MTDUOI7THANG").Width = 120
    '            .Columns("SL_TTT7").Width = 120
    '            .Columns("SL_NCNHO").Width = 120
    '            .Columns("TONGCONG_15H30XUONG").Width = 120
    '            .Columns("SL_NGHITS").Width = 120
    '            .Columns("TONGCONG_XUONG").Width = 200
    '        End With

    '        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
    '        band.Layout.Override.FilterUIType = FilterUIType.FilterRow
    '        band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
    '        band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
    '        band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
    '        band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
    '        band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
    '        band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
    '        band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
    '        band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
    '        band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
    '        band.Layout.Override.RowSizing = RowSizing.AutoFree
    '        band.Layout.Override.CellMultiLine = DefaultableBoolean.True
    '        band.ColHeaderLines = 4

    '        band.Layout.Override.RowSelectors = DefaultableBoolean.True
    '        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
    '        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
    '        band.Layout.Bands(0).Summaries.Clear()
    '        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
    '        summary.Appearance.TextHAlign = HAlign.Right
    '        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
    '        band.SummaryFooterCaption = "Tổng số: "
    '        band = Nothing
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub LoadGridView_Chitiet1()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .Columns(i).Hidden = False
                Next

                .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns("KHU").Header.Caption = "KHU"
                .Columns("X_MA_").Header.Caption = "NHÀ XƯỞNG"

                .Columns("NV_MA").Header.Caption = "SỐ THẺ"
                .Columns("NV_TEN").Header.Caption = "HỌ TÊN NHÂN VIÊN"
                .Columns("NV_TEN").Width = 250
                .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("DV_MA").Header.Caption = "ĐƠN VỊ"
                .Columns("NGAYMANGTHAI").Header.Caption = "NGÀY MANG THAI"

                .Columns("NGAYVE15H30").Header.Caption = "NGÀY VỀ 15H30"
                .Columns("NGAYDUSINH").Header.Caption = "NGÀY DỰ SINH"
                .Columns("MANGTHAIDUOI7T").Header.Caption = "THAI DƯỚI 7 THÁNG"

                .Columns("MANGTHAITREN7T").Header.Caption = "THAI TRÊN 7 THÁNG"

                .Columns("NUOICONNHO").Header.Caption = "NUÔI CON NHỎ"

                .Columns("NGHITHAISAN").Header.Caption = "NGHỈ THAI SẢN"
                '.Columns("KHU").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                .Columns("X_MA_").MergedCellStyle = MergedCellStyle.Always
                .Columns("X_MA_").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            End With

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
            band.Layout.Override.RowSizing = RowSizing.AutoFree
            band.Layout.Override.CellMultiLine = DefaultableBoolean.False
            band.ColHeaderLines = 1

            band.Layout.Override.RowSelectors = DefaultableBoolean.True
            band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
            Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(2)
            band.Layout.Bands(0).Summaries.Clear()
            Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
            summary.Appearance.TextHAlign = HAlign.Right
            band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            band.SummaryFooterCaption = "Tổng số: "
            band = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            With Me.dgrBC.DisplayLayout.Bands(0)
                .ClearGroupByColumns()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next

                .Columns("STT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns("XUONGTENHOA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("STT").Header.Caption = "STT" ''=== CỘT THỨ TỰ MẶC ĐỊNH TRONG BÁO CÁO
                .Columns("STT1").Header.Caption = "STT" ''====== cột thứ tự không đếm dòng toàn công ty, tổng khu A, tổng khu B
                .Columns("KHUHIENTHI").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
                .Columns("KHUHIENTHI").Header.Appearance.FontData.Bold = DefaultableBoolean.True


                .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("X_MA_").Hidden = True
                .Columns("KHU").Hidden = True
                .Columns("STT").Hidden = True


                .Columns("KHUHIENTHI").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONGCONG_XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("STT1").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("SL_MTDUOI7THANG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("SL_TTT7").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("SL_NCNHO").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("SL_NGHITS").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONGCONG_XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONGCONG_15H30XUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                .Columns("SL_MTDUOI7THANG").Header.Caption = sCotMTD7T
                .Columns("SL_TTT7").Header.Caption = sCotMTTren7T
                .Columns("SL_NCNHO").Header.Caption = sCotNCNho
                .Columns("SL_NGHITS").Header.Caption = sCotNghiThaiSan
                .Columns("TONGCONG_15H30XUONG").Header.Caption = sCotTongVe15h30
                .Columns("TONGCONG_XUONG").Header.Caption = sCotTongCong
                .Columns("THUTU").Hidden = True
                .Columns("X_MA_").Hidden = True
                .Columns("THUTU").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                .Columns("X_MA_").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                .Columns("KHU").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                .Columns("STT").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True

                .Columns("KHUHIENTHI").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHUHIENTHI").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

                ''=====
                .Columns("STT1").Header.VisiblePosition = 0
                .Columns("KHUHIENTHI").Header.VisiblePosition = 1
                .Columns("XUONGTENHOA").Header.VisiblePosition = 2
                .Columns("SL_MTDUOI7THANG").Header.VisiblePosition = 3
                .Columns("SL_TTT7").Header.VisiblePosition = 4
                .Columns("SL_NCNHO").Header.VisiblePosition = 5
                .Columns("TONGCONG_15H30XUONG").Header.VisiblePosition = 6
                .Columns("SL_NGHITS").Header.VisiblePosition = 7
                .Columns("TONGCONG_XUONG").Header.VisiblePosition = 8

                .Columns("KHUHIENTHI").Width = 100
                .Columns("SL_MTDUOI7THANG").Width = 120
                .Columns("SL_TTT7").Width = 120
                .Columns("SL_NCNHO").Width = 120
                .Columns("TONGCONG_15H30XUONG").Width = 120
                .Columns("SL_NGHITS").Width = 120
                .Columns("TONGCONG_XUONG").Width = 200
            End With

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
            band.Layout.Override.RowSizing = RowSizing.AutoFree
            band.Layout.Override.CellMultiLine = DefaultableBoolean.True
            band.ColHeaderLines = 4

            band.Layout.Override.RowSelectors = DefaultableBoolean.True
            band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
            Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
            band.Layout.Bands(0).Summaries.Clear()
            Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
            summary.Appearance.TextHAlign = HAlign.Right
            band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            band.SummaryFooterCaption = "Tổng số: "
            band = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDataGrid_chitiet()
        dgrBC.Refresh()
        Me.b = New clsBThongKePNMTTheoThang
        Dim THANG As Integer
        THANG = Convert.ToInt32(CDate(Me.dtpThang.Value).Month)
        Dim NAM As Integer
        NAM = Convert.ToInt32(CDate(Me.dtpThang.Value).Year)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@THANG", THANG))
        listpar.Add(New SqlParameter("@NAM", NAM))

        If Me.radTCT.Checked And cbkChitiet.Checked Then
            tblTemp = Me.b.GoiThuTucThongKe("SP_THONGKEDANHSACHCHITIET_THAISAN", listpar)
        End If
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub LoadDataGrid()
        dgrBC.Refresh()
        Me.b = New clsBThongKePNMTTheoThang
        Dim obj As New objThongKePNMTTheoThang
        Dim tbltam, tblDMKhuA, tblDMKhuB, tblKhoiVP, tblTCT As New DataTable
        Dim listpar As New ArrayList(4)

        iNam = CInt(Me.dtpThang.Value.Substring(3, 4))
        iThang = CInt(Me.dtpThang.Text.Substring(0, 2))
        obj.NAM = iNam

        obj.NamTruoc = obj.NAM - 1
        obj.NamSau = obj.NAM + 1
        obj.THANG = iThang

        Dim sKhu As String
        If Me.radKhuA.Checked Then
            sKhu = "A"
        End If
        If Me.radKhuB.Checked Then
            sKhu = "B"
        End If
        If Me.radKhuDVC.Checked Then
            sKhu = "DVC"
        End If
        If Me.radTCT.Checked Then
            sKhu = "TCT"
        End If

        Dim sNgaydauthang, sNgaycuoithang As String
        Dim dNgaydauthang, dNgaycuoithang As Date
        If Me.dtpThang.Text.ToString() <> "" Then
            sNgaydauthang = Me.dtpThang.Text.Substring(3, 4) & "-" & Me.dtpThang.Text.Substring(0, 2) & "-01"

            dNgaydauthang = CDate(sNgaydauthang)
            dNgaycuoithang = dNgaydauthang.AddMonths(1).AddDays(-1)
            sNgaycuoithang = dNgaycuoithang.Day.ToString() & "/" & dNgaycuoithang.Month.ToString() & "/" & dNgaycuoithang.Year.ToString()
            sCotNghiThaiSan = "Nghỉ thai sản " & Chr(10) & sNgaycuoithang & Chr(10) & " 休產假"
        End If


        TinhSayThai(iNam)
        If bTinhST Then

            listpar.Clear()

            Try
                listpar.Add(New SqlParameter("@THANG", Me.iThang))
                listpar.Add(New SqlParameter("@NAM", obj.NAM))

                Select Case sKhu
                    Case "TCT"
                        tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_THEOTHANG", listpar)
                    Case Else
                        listpar.Add(New SqlParameter("@KHU", sKhu))
                        tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_THEOTHANG", listpar)
                End Select

                listpar.Clear()
            Catch ex As Exception
                MessageBox.Show("Lỗi,không tính được dữ liệu mang thai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        '''============= tính cột STT trên lưới =================''
        Dim dem As Integer = 0

        tblDMKhuA = Me.b.GoiThuTucThongKeKThamSo("SP_DANHMUCXUONG_KHUA_MOI_S")
        If tblDMKhuA.Rows.Count > 0 Then
            For l = 0 To tbltam.Rows.Count - 1
                For k = 0 To tblDMKhuA.Rows.Count - 1
                    If tblDMKhuA.Rows(k).Item("X_MA_").ToString() = tbltam.Rows(l).Item("X_MA_").ToString() And tbltam.Rows(l).Item("X_MA_").ToString() <> "TONGKHUA" Then
                        dem = dem + 1
                        tbltam.Rows(l).Item("STT1") = dem
                        tbltam.AcceptChanges()
                    End If
                    If tbltam.Rows(l).Item("X_MA_").ToString() = "TONGKHUA" Then
                        tbltam.Rows(l).Item("STT1") = ""
                        tbltam.AcceptChanges()
                    End If

                Next

            Next

        End If


        tblDMKhuB = Me.b.GoiThuTucThongKeKThamSo("SP_DANHMUCXUONG_KHUB_MOI_S")

        If tblDMKhuB.Rows.Count > 0 Then
            For l = 0 To tbltam.Rows.Count - 1
                For k = 0 To tblDMKhuB.Rows.Count - 1
                    If tblDMKhuB.Rows(k).Item("X_MA_").ToString() = tbltam.Rows(l).Item("X_MA_").ToString() And tbltam.Rows(l).Item("X_MA_").ToString() <> "TONGKHUB" Then
                        dem = dem + 1
                        tbltam.Rows(l).Item("STT1") = dem
                        tbltam.AcceptChanges()
                    End If
                    If tbltam.Rows(l).Item("X_MA_").ToString() = "TONGKHUB" Then
                        tbltam.Rows(l).Item("STT1") = ""
                        tbltam.AcceptChanges()
                    End If

                Next

            Next

        End If

        tblKhoiVP = Me.b.GoiThuTucThongKeKThamSo("SP_DANHMUCXUONG_KHUDVC_S")
        If tblKhoiVP.Rows.Count > 0 Then
            For l = 0 To tbltam.Rows.Count - 1
                If tblKhoiVP.Rows(0).Item("X_MA_").ToString() = tbltam.Rows(l).Item("X_MA_").ToString() Then
                    dem = dem + 1
                    tbltam.Rows(l).Item("STT1") = dem
                    tbltam.AcceptChanges()
                End If
            Next

        End If

        tblTCT = Me.b.GoiThuTucThongKeKThamSo("SP_DANHMUCTCT_DONGTONG_S")
        If tblTCT.Rows.Count > 0 Then
            For l = 0 To tbltam.Rows.Count - 1
                If tblTCT.Rows(0).Item("X_MA_").ToString() = tbltam.Rows(l).Item("X_MA_").ToString() Then
                    dem = dem + 1
                    tbltam.Rows(l).Item("STT1") = dem
                    tbltam.AcceptChanges()
                End If
            Next
        End If


        If tbltam.Rows.Count > 0 Then

            Me.dgrBC.DataSource = tbltam
            Me.btnExcel.Enabled = True
            For i = 0 To dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells("KHUHIENTHI").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Black

                If dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TONGKHUA" Or dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TONGKHUB" Or dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TONGKHUDVC" Then

                    Me.dgrBC.Rows(i).Cells("SL_MTDUOI7THANG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_TTT7").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_NCNHO").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_NGHITS").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG_15H30XUONG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG_XUONG").Appearance.FontData.Bold = DefaultableBoolean.True

                    Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SL_MTDUOI7THANG").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SL_TTT7").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SL_NCNHO").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("SL_NGHITS").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("TONGCONG_15H30XUONG").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("TONGCONG_XUONG").Appearance.ForeColor = Color.Red

                End If
                If dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TCT" Then

                    Me.dgrBC.Rows(i).Cells("SL_MTDUOI7THANG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_TTT7").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_NCNHO").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SL_NGHITS").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG_15H30XUONG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG_XUONG").Appearance.FontData.Bold = DefaultableBoolean.True

                    dongTCT = Me.dgrBC.Rows(i).Index
                End If
            Next
        Else
            Me.btnExcel.Enabled = False
        End If
    End Sub
    Private Sub Danhsach_Duoi7Thang(ByVal sKhu As String)
        Me.b = New clsBThongKePNMTTheoThang
        Dim obj As New objThongKePNMTTheoThang
        Dim tbltam As New DataTable
        Dim listpar As New ArrayList(2)

        iNam = CInt(Me.dtpThang1.Value.Substring(3, 4))
        iThang = CInt(Me.dtpThang1.Text.Substring(0, 2))
        obj.NAM = iNam
        obj.THANG = iThang
        listpar.Add(New SqlParameter("@THANG", Me.iThang))
        listpar.Add(New SqlParameter("@NAM", obj.NAM))

        Select Case sKhu
            Case "TCT"
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_DUOI7THANG_S", listpar)
                Me.XpCaption2.Text = "Danh sách mang thai dưới 7 tháng (" & Me.dtpThang1.Text & ") TCT"

            Case Else
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_DUOI7THANG_KHU_S", listpar)
                Me.XpCaption2.Text = "Danh sách mang thai dưới 7 tháng (" & Me.dtpThang1.Text & ") khu " + sKhu

        End Select
        listpar.Clear()
        If Not tbltam Is Nothing Then
            Me.dgrBC.DataSource = tbltam
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub Danhsach_Ve15h30(ByVal sKhu As String)
        Me.b = New clsBThongKePNMTTheoThang
        Dim obj As New objThongKePNMTTheoThang
        Dim tbltam As New DataTable
        Dim listpar As New ArrayList(2)

        iNam = CInt(Me.dtpThang1.Value.Substring(3, 4))
        iThang = CInt(Me.dtpThang1.Text.Substring(0, 2))
        obj.NAM = iNam
        obj.THANG = iThang
        listpar.Add(New SqlParameter("@THANG", Me.iThang))
        listpar.Add(New SqlParameter("@NAM", obj.NAM))

        Select Case sKhu
            Case "TCT"
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_VE15H30_S", listpar)
                Me.XpCaption2.Text = "Danh sách về 15h30 tháng " & Me.dtpThang1.Text

            Case Else
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_VE15H30_KHU_S", listpar)
                Me.XpCaption2.Text = "Danh sách về 15h30 tháng " & Me.dtpThang1.Text
        End Select
        listpar.Clear()
        If Not tbltam Is Nothing Then
            Me.dgrBC.DataSource = tbltam
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub Danhsach_Thaisan(ByVal sKhu As String)
        Me.b = New clsBThongKePNMTTheoThang
        Dim obj As New objThongKePNMTTheoThang
        Dim tbltam As New DataTable
        Dim listpar As New ArrayList(2)

        iNam = CInt(Me.dtpThang1.Value.Substring(3, 4))
        iThang = CInt(Me.dtpThang1.Text.Substring(0, 2))
        obj.NAM = iNam
        obj.THANG = iThang
        listpar.Add(New SqlParameter("@THANG", Me.iThang))
        listpar.Add(New SqlParameter("@NAM", obj.NAM))

        Select Case sKhu
            Case "TCT"
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_THAISAN_S", listpar)
                Me.XpCaption2.Text = "Danh sách nghỉ thai sản tháng " & Me.dtpThang1.Text & " TCT"

            Case Else
                listpar.Add(New SqlParameter("@KHU", sKhu))
                tbltam = Me.b.GoiThuTucThongKe("SP_BCTHONGKEPNMT_THAISAN_KHU_S", listpar)
                Me.XpCaption2.Text = "Danh sách nghỉ thai sản tháng " & Me.dtpThang1.Text & " Khu " + sKhu
        End Select
        listpar.Clear()
        If Not tbltam Is Nothing Then
            Me.dgrBC.DataSource = tbltam
            Me.btnExcel.Enabled = True
        End If

    End Sub
    Private Sub LoadAllCombo()
        Dim b As New clsBThongKePNMTTheoThang
        Dim obj As New objThongKePNMTTheoThang
        Me.b = New clsBThongKePNMTTheoThang
        Dim tblTemp As DataTable
        Dim listpar As New ArrayList(1)

        Try
            listpar.Add(New SqlParameter("@Nam", CInt(Now().Year.ToString())))
            tblTemp = Me.b.GoiThuTucThongKe("SP_DMTHANG_PNMT_S", listpar)
            listpar.Clear()
        Catch ex As Exception
            MessageBox.Show("Lỗi,không load được danh mục tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.dtpThang.DataSource = tblTemp
        Me.dtpThang1.DataSource = tblTemp

        If tblTemp.Rows.Count > 0 Then
            Me.dtpThang.SelectedIndex = 0
            Me.dtpThang.Focus()

            Me.dtpThang1.SelectedIndex = 0
            Me.dtpThang1.Focus()
        End If
    End Sub
    Private Sub frmThongKePNMTTheoThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sChuoiNhomVe15h30 = "Về 15:30 下班女工統計" & Chr(10) & ""
        sCotSTT = "STT" & Chr(10) & "序號"
        sCotXuong = "Xưởng" & Chr(10) & "廠別"
        sCotDonvi = "Đơn vị" & Chr(10) & "序號"
        sCotMTD7T = "Mang thai chưa tới 7 tháng" & Chr(10) & "懷孕7個月以下女工數"
        sCotMTTren7T = "Mang thai trên 7 tháng" & Chr(10) & "懷孕7個月及以上女工"
        sCotNCNho = "Nuôi con nhỏ " & Chr(10) & "dưới 1 tuổi" & Chr(10) & "養育1歲以下小孩女工"
        sCotTongVe15h30 = "TC小計" & Chr(10) & " "
        sCotNghiThaiSan = "Nghỉ thai sản " & Chr(10) & "" & Chr(10) & "休產假"
        sCotTongCong = "TC" & Chr(10) & "總計"
        LoadAllCombo()
        Me.btnXemchitiet.Visible = False
    End Sub
    Private Sub XuatExcel_TieuDe()
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "THỐNG KÊ PHỤ NỮ MANG THAI THÁNG " & iThang.ToString() & Chr(10) & "★每月孕婦管理:" & iThang.ToString() & ".全廠懷孕女工數統計總表"
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("3-2每月員工15h30下班人數")
                Dim sheet As Worksheet = myWorkbook.Worksheets("3-2每月員工15h30下班人數")

                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''
                Me.dgrBC.DisplayLayout.Bands(0).Columns("STT1").Header.VisiblePosition = 0
                Me.dgrBC.DisplayLayout.Bands(0).Columns("KHUHIENTHI").Header.VisiblePosition = 1
                Me.dgrBC.DisplayLayout.Bands(0).Columns("XUONGTENHOA").Header.VisiblePosition = 2
                Me.dgrBC.DisplayLayout.Bands(0).Columns("SL_MTDUOI7THANG").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("SL_TTT7").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("SL_NCNHO").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG_15H30XUONG").Header.VisiblePosition = 6
                Me.dgrBC.DisplayLayout.Bands(0).Columns("SL_NGHITS").Header.VisiblePosition = 7
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG_XUONG").Header.VisiblePosition = 8

                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 300
                myWorksheet.Rows(1).Height = 800
                myWorksheet.Rows(1).Cells(1).Value = sChuoiTieuDe

                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)

                For i = 2 To 3
                    For j = 1 To 9

                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(i).Cells(j).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Height = 200
                        myWorksheet.Rows(i).Height = 750

                        myWorksheet.Rows(i).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    Next
                Next

                myWorksheet.Rows(2).Cells(1).Value = sCotSTT
                myWorksheet.Rows(3).Cells(1).Value = sCotSTT

                myWorksheet.Rows(2).Cells(2).Value = sCotXuong
                myWorksheet.Rows(3).Cells(2).Value = sCotXuong

                myWorksheet.Rows(2).Cells(3).Value = sCotDonvi
                myWorksheet.Rows(3).Cells(3).Value = sCotDonvi

                myWorksheet.Rows(2).Cells(4).Value = sCotMTD7T
                myWorksheet.Rows(3).Cells(4).Value = sCotMTD7T

                myWorksheet.Rows(2).Cells(5).Value = sChuoiNhomVe15h30
                myWorksheet.Rows(2).Cells(6).Value = sChuoiNhomVe15h30
                myWorksheet.Rows(2).Cells(7).Value = sChuoiNhomVe15h30

                myWorksheet.Rows(3).Cells(5).Value = sCotMTTren7T
                myWorksheet.Rows(3).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(6).Value = sCotNCNho
                myWorksheet.Rows(3).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(7).Value = sCotTongVe15h30
                myWorksheet.Rows(3).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)


                myWorksheet.Rows(2).Cells(8).Value = sCotNghiThaiSan
                myWorksheet.Rows(3).Cells(8).Value = sCotNghiThaiSan
                myWorksheet.Rows(3).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)


                myWorksheet.Rows(2).Cells(9).Value = sCotTongCong
                myWorksheet.Rows(3).Cells(9).Value = sCotTongCong
                myWorksheet.Rows(3).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                sheet.MergedCellsRegions.Add(1, 1, 1, 9)
                sheet.MergedCellsRegions.Add(2, 1, 3, 1)
                sheet.MergedCellsRegions.Add(2, 2, 3, 2)
                sheet.MergedCellsRegions.Add(2, 3, 3, 3)
                sheet.MergedCellsRegions.Add(2, 4, 3, 4)
                sheet.MergedCellsRegions.Add(2, 5, 2, 7)
                sheet.MergedCellsRegions.Add(2, 8, 3, 8)
                sheet.MergedCellsRegions.Add(2, 9, 3, 9)

                myWorksheet.Rows(dongTCT + 6).Cells(1).Value = "BAN LÃNH ĐẠO"
                myWorksheet.Rows(dongTCT + 7).Cells(1).Value = "主管部"

                myWorksheet.Rows(dongTCT + 6).Cells(4).Value = " CHỦ QUẢN"
                myWorksheet.Rows(dongTCT + 7).Cells(4).Value = " 主管"

                myWorksheet.Rows(dongTCT + 6).Cells(7).Value = "LẬP BIỂU"
                myWorksheet.Rows(dongTCT + 7).Cells(7).Value = " 製表"

                For i = dongTCT + 6 To dongTCT + 7
                    For j = 1 To 9
                        myWorksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        myWorksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    Next


                Next
                sheet.MergedCellsRegions.Add(dongTCT + 6, 1, dongTCT + 6, 3)
                sheet.MergedCellsRegions.Add(dongTCT + 7, 1, dongTCT + 7, 3)
                sheet.MergedCellsRegions.Add(dongTCT + 6, 4, dongTCT + 6, 6)
                sheet.MergedCellsRegions.Add(dongTCT + 7, 4, dongTCT + 7, 6)
                sheet.MergedCellsRegions.Add(dongTCT + 6, 7, dongTCT + 6, 9)
                sheet.MergedCellsRegions.Add(dongTCT + 7, 7, dongTCT + 7, 9)

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub XuatExcel_TieuDe_Chitiet()
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "DANH SÁCH PHỤ NỮ MANG THAI THÁNG " & Month(dtpThang.Value).ToString() & " NĂM " & Year(dtpThang.Value).ToString()
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("DANH SÁCH MANG THAI")
                Dim sheet As Worksheet = myWorkbook.Worksheets("DANH SÁCH MANG THAI")

                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''
                Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.VisiblePosition = 0
                Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.VisiblePosition = 1
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NV_MA").Header.VisiblePosition = 2
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NV_TEN").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("DV_MA").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAYMANGTHAI").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAYVE15H30").Header.VisiblePosition = 6
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAYDUSINH").Header.VisiblePosition = 7
                Me.dgrBC.DisplayLayout.Bands(0).Columns("MANGTHAIDUOI7T").Header.VisiblePosition = 8
                Me.dgrBC.DisplayLayout.Bands(0).Columns("MANGTHAITREN7T").Header.VisiblePosition = 9
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NUOICONNHO").Header.VisiblePosition = 10
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGHITHAISAN").Header.VisiblePosition = 11

                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 300
                myWorksheet.Rows(1).Height = 400

                myWorksheet.Rows(1).Cells(1).Value = sChuoiTieuDe

                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 2, 1)

                For j = 1 To 12

                    myWorksheet.Rows(2).Cells(j).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(2).Cells(j).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(2).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(2).Cells(j).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(2).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    myWorksheet.Rows(2).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(2).Cells(j).CellFormat.Font.Height = 200
                    myWorksheet.Rows(2).Height = 750

                    myWorksheet.Rows(2).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(2).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(2).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(2).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                Next
                sheet.MergedCellsRegions.Add(1, 1, 1, 12)

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Select Case Me.tabTKPNMTThang.SelectedTab.Index
            Case 0
                If cbkChitiet.Checked Then
                    XuatExcel_TieuDe_Chitiet()
                Else
                    XuatExcel_TieuDe()
                End If
            Case 1
                Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
                If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                        MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
        End Select
    End Sub
    Private Sub dtpThang_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles dtpThang.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub
    Private Sub dtpThang1_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles dtpThang1.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub
    Private Sub btnXemchitiet_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemchitiet.Activate
        Dim sKhu As String
        If Me.radCT_KhuA.Checked Then
            sKhu = "A"
        End If
        If Me.radCT_KhuB.Checked Then
            sKhu = "B"
        End If
        If Me.radCT_KhuDVC.Checked Then
            sKhu = "DVC"
        End If
        If Me.radCT_TCT.Checked Then
            sKhu = "TCT"
        End If

        If Me.radMTD7Thang.Checked Then
            Danhsach_Duoi7Thang(sKhu)
        End If
        If Me.radVe15h30.Checked Then
            Danhsach_Ve15h30(sKhu)
        End If
        If Me.radThaisan.Checked Then
            Danhsach_Thaisan(sKhu)
        End If
        'LoadGridView_Chitiet()
    End Sub

    Private Sub tabTKPNMTThang_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabTKPNMTThang.SelectedTabChanged
        Select Case Me.tabTKPNMTThang.SelectedTab.Index
            Case 0
                Me.btnXemchitiet.Visible = False
                Me.btnThongKe.Visible = True
                Me.dgrBC.DataSource = Nothing
                Me.btnExcel.Enabled = False

            Case 1
                Me.btnXemchitiet.Visible = True
                Me.btnThongKe.Visible = False
                Me.dgrBC.DataSource = Nothing
                Me.btnExcel.Enabled = False
        End Select
    End Sub



End Class