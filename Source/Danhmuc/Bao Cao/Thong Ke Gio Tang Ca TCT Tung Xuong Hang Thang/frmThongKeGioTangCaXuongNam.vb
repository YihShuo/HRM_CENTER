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
Imports TYXUAN_NS.clsLanguage
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO
Public Class frmThongKeGioTangCaXuongNam
    Inherits Form
    Public i, j, dongTCT As Integer
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        If CDate(Me.dtpDenNgay.Value).Year.ToString() <> CDate(Me.dtpDenNgay.Value).Year.ToString() Then
            MessageBox.Show("Vui lòng chọn khoảng thời gian trong 1 năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            LoadDataGrid()
            If Me.dgrBC.Rows.Count > 0 Then
                Me.btnExcel.Enabled = True
                LoadGridView()
                For i = 0 To dgrBC.Rows.Count - 1
                    If dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TONGKHUA" Or dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TONGKHUB" Then
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TC200_229").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TC230_249").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TC250_269").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TC270_300").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True
                    End If
                    If dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "TCT" Then
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TC200_229").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TC230_249").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TC250_269").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TC270_300").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Black


                        Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TC200_229").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TC230_249").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TC250_269").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TC270_300").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True

                        dongTCT = Me.dgrBC.Rows(i).Index
                    End If
                Next
            Else
                Me.btnExcel.Enabled = False
            End If
        End If
    End Sub
    Dim b As New clsBThongKeGioTangCaXuongNam
    Private Sub LoadDataGrid()
        Try

            'Dim listpar As New ArrayList(3)
            Dim tblTemp As DataTable

            'listpar.Clear()

            'listpar.Add(New SqlParameter("@THANGBD", CDate(Me.dtpTuNgay.Value).Month))
            'listpar.Add(New SqlParameter("@THANGKT", CDate(Me.dtpDenNgay.Value).Month))
            'listpar.Add(New SqlParameter("@NAM", CDate(Me.dtpDenNgay.Value).Year))



            tblTemp = Me.b.GoiThuTucThongKe("SP_BCTHONGKEGIOTANGCA200TIENG", CDate(Me.dtpTuNgay.Value).Month, CDate(Me.dtpDenNgay.Value).Month, CDate(Me.dtpTuNgay.Value).Year)
            'listpar.Clesar()


            If tblTemp.Rows.Count > 0 Then
                Me.dgrBC.DataSource = tblTemp
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                .Columns("STT").Header.Caption = "STT"
                .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("XUONGTENHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("X_MA_").Hidden = True

                .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TONGCONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("TC200_229").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TC230_249").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TC250_269").Header.Appearance.FontData.Bold = DefaultableBoolean.True
                .Columns("TC270_300").Header.Appearance.FontData.Bold = DefaultableBoolean.True

                .Columns("XUONGTENHOA").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"

                .Columns("TC200_229").Header.Caption = "達200 - 229小時" & Chr(10) & "以上人數"
                .Columns("TC230_249").Header.Caption = "達230 - 249 小時" & Chr(10) & "以上人數"
                .Columns("TC250_269").Header.Caption = "達250 - 269小時" & Chr(10) & "以上人數"
                .Columns("TC270_300").Header.Caption = "達270 - 300小時" & Chr(10) & "以上人數"
                .Columns("TONGCONG").Header.Caption = "TC 合計" & Chr(10) & ""
                .Columns("TONGCONG").Width = 200
                .Columns("TONGCONG").Header.Caption = "TC 合計" & Chr(10) & ""
                .Columns("X_MA_").Hidden = True
                .Columns("STT").Hidden = True
                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                .Columns("STT").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                .Columns("X_MA_").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
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
            band.ColHeaderLines = 2

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
    Private Sub XuatExcel_TieuDe()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        Dim sChuoi As String = ""
        Dim sNgaybatdauVN, sNgayketthucVN, sNgaybatdauTW, sNgayketthucTW As String

        dtpTuNgay.CustomFormat = "yyyy/MM/dd"
        dtpDenNgay.CustomFormat = "yyyy/MM/dd"

        sNgaybatdauVN = dtpTuNgay.Text
        sNgayketthucVN = dtpDenNgay.Text

        dtpTuNgay.CustomFormat = "dd/MM/dd"
        dtpDenNgay.CustomFormat = "dd/MM/dd"

        sNgaybatdauTW = dtpTuNgay.Text
        sNgayketthucTW = dtpDenNgay.Text

        Try
            myWorksheet = myWorkbook.Worksheets.Add("4-1全廠加班工時統計表")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("4-1全廠加班工時統計表")

            Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(1).Height = 800
            myWorksheet.Rows(1).Cells(1).Value = "BẢNG THỐNG KÊ TỔNG GiỜ TĂNG CA CÁC XƯỞNG THÁNG " & CDate(Me.dtpDenNgay.Value).Month.ToString() & " NĂM " & CDate(Me.dtpDenNgay.Value).Year.ToString() & Chr(10) & CDate(Me.dtpDenNgay.Value).Year.ToString() & " 年 " & CDate(Me.dtpDenNgay.Value).Month.ToString() & " 月份各廠年度正常加班工時匯總表"

            sChuoi = "Số người có giờ tăng ca từ 200 tiếng trở lên" & Chr(10) & " 本年度正常加班工時已達到200小時以上人數  " & Chr(10) & "時間範圍: " & sNgaybatdauVN & " 至 " & sNgayketthucVN & " Mốc thời gian từ " & sNgaybatdauTW & " - " & sNgayketthucTW
            ''-------
            For i = 2 To 3
                For j = 1 To 3

                    myWorksheet.Rows(i).Cells(j).CellFormat.Font.Color = Color.Black
                    myWorksheet.Rows(i).Cells(j).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(i).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(i).Cells(j).CellFormat.WrapText = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    myWorksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(i).Cells(j).CellFormat.Font.Height = 200
                    myWorksheet.Rows(i).Height = 500

                    myWorksheet.Rows(i).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(i).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(i).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(i).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                Next
            Next

            myWorksheet.Rows(2).Cells(1).Value = "XƯỞNG" & Chr(10) & "廠區"
            myWorksheet.Rows(3).Cells(1).Value = "XƯỞNG" & Chr(10) & "廠別"
            myWorksheet.Rows(2).Cells(2).Value = "ĐƠN VỊ" & Chr(10) & "單位"

            myWorksheet.Rows(2).Cells(3).Value = sChuoi
            myWorksheet.Rows(2).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Left
            myWorksheet.Rows(2).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Height = 250
            myWorksheet.Rows(2).Height = 900

            sheet.MergedCellsRegions.Add(1, 1, 1, 7)
            sheet.MergedCellsRegions.Add(2, 1, 3, 1)
            sheet.MergedCellsRegions.Add(2, 2, 3, 2)
            sheet.MergedCellsRegions.Add(2, 3, 2, 7)

            myWorksheet.Rows(dongTCT + 4).Cells(1).Value = "全廠合計 TC"
            myWorksheet.Rows(dongTCT + 4).Cells(2).Value = "全廠合計 TC"

            myWorksheet.Rows(dongTCT + 5).Cells(2).Value = "BAN LÃNH ĐẠO"
            myWorksheet.Rows(dongTCT + 5).Cells(3).Value = "BAN LÃNH ĐẠO"
            myWorksheet.Rows(dongTCT + 6).Cells(3).Value = "主管部"
            myWorksheet.Rows(dongTCT + 6).Cells(3).Value = "主管部"

            For i = dongTCT + 5 To dongTCT + 6
                For j = 3 To 7
                    myWorksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                Next
                

            Next
         

            myWorksheet.Rows(dongTCT + 5).Cells(4).Value = "CHỦ QUẢN"
            myWorksheet.Rows(dongTCT + 6).Cells(5).Value = "主管"

            myWorksheet.Rows(dongTCT + 5).Cells(7).Value = "LẬP BIỂU"
            myWorksheet.Rows(dongTCT + 6).Cells(7).Value = "  製表"

            sheet.MergedCellsRegions.Add(dongTCT + 5, 2, dongTCT + 5, 3)
            sheet.MergedCellsRegions.Add(dongTCT + 6, 2, dongTCT + 6, 3)

            sheet.MergedCellsRegions.Add(dongTCT + 5, 4, dongTCT + 5, 5)
            sheet.MergedCellsRegions.Add(dongTCT + 6, 4, dongTCT + 6, 5)

            sheet.MergedCellsRegions.Add(dongTCT + 5, 6, dongTCT + 5, 7)
            sheet.MergedCellsRegions.Add(dongTCT + 6, 6, dongTCT + 6, 7)

            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.Font.Color = Color.Black
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(dongTCT + 4).Height = 500
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(dongTCT + 4).Cells(1).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            sheet.MergedCellsRegions.Add(dongTCT + 4, 1, dongTCT + 4, 2)

            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)

            myWorksheet.Rows(3).Cells(3).Value = Me.dgrBC.DisplayLayout.Bands(0).Columns("TC200_229").Header.Caption
            myWorksheet.Rows(3).Cells(4).Value = Me.dgrBC.DisplayLayout.Bands(0).Columns("TC230_249").Header.Caption
            myWorksheet.Rows(3).Cells(5).Value = Me.dgrBC.DisplayLayout.Bands(0).Columns("TC250_269").Header.Caption
            myWorksheet.Rows(3).Cells(6).Value = Me.dgrBC.DisplayLayout.Bands(0).Columns("TC270_300").Header.Caption
            myWorksheet.Rows(3).Cells(7).Value = Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG").Header.Caption

            myWorksheet.Rows(3).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
            myWorksheet.Rows(3).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
            myWorksheet.Rows(3).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
            myWorksheet.Rows(3).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
            myWorksheet.Rows(3).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            XuatExcel_TieuDe()

        End If
    End Sub
    Private Sub frmThongKeGioTangCaXuongNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnExcel.Enabled = False
    End Sub
End Class