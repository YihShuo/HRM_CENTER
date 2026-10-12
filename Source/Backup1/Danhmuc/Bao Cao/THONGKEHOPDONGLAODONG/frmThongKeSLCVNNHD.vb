Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Excel
Imports Infragistics.Win

Public Class frmThongKeSLCVNNHD
    Friend WithEvents b As clsBTKSOLUONGKYHDLD
    Public i, j, k, l As Integer
    Dim KhuA As Integer
    Dim KhuB As Integer

    Dim KhuA1 As Integer
    Dim KhuB1 As Integer
    Dim DVC As Integer
    Dim btn As String
    Private Sub frmTKCongViecHDLD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpNgaybatdau.Value = Now
        Me.btXemBaoCao.Enabled = False
        Me.radTCT.Checked = True
    End Sub

    Private Sub loadgridview2()
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT_AN").Hidden = True
            .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
            .Columns("STT").Width = 80
            .Columns("STT").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("KHU").CellActivation = Activation.NoEdit
            .Columns("KHU").Header.Caption = "XƯỞNG" & Chr(10) & "廠別"
            .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("KHU").Width = 100
            .Columns("x_ma_").Header.Caption = "ĐƠN VỊ" & Chr(10) & "單位"
            .Columns("x_ma_").Width = 180
            .Columns("x_ma_").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("PHETKEO").Header.Caption = "Phết keo đế và mũ giầy" & Chr(10) & "鞋底及鞋面刷膠"
            .Columns("PHETKEO").Width = 120
            .Columns("PHETKEO").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("SONINDA").Header.Caption = "Sơn, in da và pha chế hóa chất để sơn, in da" & Chr(10) & "漆,印刷及調漆調膠"
            .Columns("SONINDA").Width = 180
            .Columns("SONINDA").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("HAPLUUHOA").Header.Caption = "Hấp lưu hóa giầy, dép cao su " & Chr(10) & "加硫鞋"
            .Columns("HAPLUUHOA").Width = 180
            .Columns("HAPLUUHOA").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("TRAIVAI").Header.Caption = "Trải vải" & Chr(10) & "貼合"
            .Columns("TRAIVAI").Width = 180
            .Columns("TRAIVAI").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("CANLUYENCS").Header.Caption = "Cán, luyện cao su trong sản xuất giầy, dép" & Chr(10) & "生產鞋子中的大車"
            .Columns("CANLUYENCS").Width = 180
            .Columns("CANLUYENCS").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("MAINHAN").Header.Caption = "Mài nhẵn mặt da, lạng da" & Chr(10) & "打粗,削皮"
            .Columns("MAINHAN").Width = 180
            .Columns("MAINHAN").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("VANHANHMAYGO").Header.Caption = "Vận hành máy gò giấy" & Chr(10) & "運行成型機"
            .Columns("VANHANHMAYGO").Width = 180
            .Columns("VANHANHMAYGO").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("VANHANHMAYMAY").Header.Caption = "Vận hành máy may" & Chr(10) & "運車機"
            .Columns("VANHANHMAYMAY").Width = 180
            .Columns("VANHANHMAYMAY").Header.Appearance.FontData.Bold = DefaultableBoolean.True


            .Columns("TONGCONG").Header.Caption = "Tổng cộng" & Chr(10) & "合計"
            .Columns("TONGCONG").Width = 80
            .Columns("TONGCONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

            ''=====
            .Columns("STT").Header.VisiblePosition = 0
            .Columns("KHU").Header.VisiblePosition = 1
            .Columns("x_ma_").Header.VisiblePosition = 2
            .Columns("PHETKEO").Header.VisiblePosition = 3
            .Columns("SONINDA").Header.VisiblePosition = 4
            .Columns("HAPLUUHOA").Header.VisiblePosition = 5
            .Columns("TRAIVAI").Header.VisiblePosition = 6
            .Columns("CANLUYENCS").Header.VisiblePosition = 7
            .Columns("MAINHAN").Header.VisiblePosition = 8
            .Columns("VANHANHMAYGO").Header.VisiblePosition = 9
            .Columns("VANHANHMAYMAY").Header.VisiblePosition = 10
            .Columns("TONGCONG").Header.VisiblePosition = 11
        End With
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout

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
    Private Sub XuatExcel_TieuDe2()
        Dim sChuoiTieuDe As String = ""
        If Me.radTCT.Checked Then
            sChuoiTieuDe = "THỐNG KÊ SỐ LƯỢNG LAO ĐỘNG LÀM VIỆC THUỘC NNĐH TOÀN CÔNG TY THÁNG " & Month(dtpNgaybatdau.Value) & "/" & Year(dtpNgaybatdau.Value) & "" & Chr(10) & "" & Year(dtpNgaybatdau.Value) & "/" & Month(dtpNgaybatdau.Value) & " 月份從事繁重毒害工作人數統計"
        End If

        If Me.radKhuA.Checked Then
            sChuoiTieuDe = "THỐNG KÊ SỐ LƯỢNG LAO ĐỘNG LÀM VIỆC THUỘC NNĐH KHU A THÁNG " & Month(dtpNgaybatdau.Value) & "/" & Year(dtpNgaybatdau.Value) & "" & Chr(10) & "" & Year(dtpNgaybatdau.Value) & "/" & Month(dtpNgaybatdau.Value) & " 月份從事繁重毒害工作人數統計"
        End If

        If Me.radKhuB.Checked Then
            sChuoiTieuDe = "THỐNG KÊ SỐ LƯỢNG LAO ĐỘNG LÀM VIỆC THUỘC NNĐH KHU B THÁNG " & Month(dtpNgaybatdau.Value) & "/" & Year(dtpNgaybatdau.Value) & "" & Chr(10) & "" & Year(dtpNgaybatdau.Value) & "/" & Month(dtpNgaybatdau.Value) & " 月份從事繁重毒害工作人數統計"
        End If
        If Me.radDVC.Checked Then
            sChuoiTieuDe = "THỐNG KÊ SỐ LƯỢNG LAO ĐỘNG LÀM VIỆC THUỘC NNĐH KHU DVC THÁNG " & Month(dtpNgaybatdau.Value) & "/" & Year(dtpNgaybatdau.Value) & "" & Chr(10) & "" & Year(dtpNgaybatdau.Value) & "/" & Month(dtpNgaybatdau.Value) & " 月份從事繁重毒害工作人數統計"
        End If

        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TK")
                Dim sheet As Worksheet = myWorkbook.Worksheets("TK")

                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''
                Me.dgrBC.DisplayLayout.Bands(0).Columns("STT").Header.VisiblePosition = 0
                Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.VisiblePosition = 1
                Me.dgrBC.DisplayLayout.Bands(0).Columns("x_ma_").Header.VisiblePosition = 2
                Me.dgrBC.DisplayLayout.Bands(0).Columns("PHETKEO").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("SONINDA").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("HAPLUUHOA").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TRAIVAI").Header.VisiblePosition = 6
                Me.dgrBC.DisplayLayout.Bands(0).Columns("CANLUYENCS").Header.VisiblePosition = 7
                Me.dgrBC.DisplayLayout.Bands(0).Columns("MAINHAN").Header.VisiblePosition = 8
                Me.dgrBC.DisplayLayout.Bands(0).Columns("VANHANHMAYGO").Header.VisiblePosition = 9
                Me.dgrBC.DisplayLayout.Bands(0).Columns("VANHANHMAYMAY").Header.VisiblePosition = 10
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG").Header.VisiblePosition = 11

                myWorksheet.Rows(0).Cells(0).Value = "CÔNG TY TNHH TỶ XUÂN"
                myWorksheet.Rows(1).Cells(0).Value = "VINH LONG FOOTWEAR CO., LTD"
                myWorksheet.Rows(2).Cells(0).Value = sChuoiTieuDe
                myWorksheet.Rows(2).Cells(0).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(2).Cells(0).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(2).Cells(0).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(0).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(0).CellFormat.Font.Height = 300
                myWorksheet.Rows(2).Height = 800
                myWorksheet.Rows(2).Cells(0).Value = sChuoiTieuDe

                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 4, 0)

                For i = 3 To 4
                    For j = 0 To 11

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

                myWorksheet.Rows(3).Cells(0).Value = "STT" & Chr(10) & "序號"
                myWorksheet.Rows(3).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(1).Value = "Xưởng" & Chr(10) & "廠別"
                myWorksheet.Rows(3).Cells(1).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(2).Value = "Đơn vị" & Chr(10) & "序號"
                myWorksheet.Rows(3).Cells(2).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(3).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(4).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(5).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(6).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(7).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(8).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(9).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(10).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(10).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(11).Value = "TÊN CÔNG VIỆC工作名稱"
                myWorksheet.Rows(3).Cells(11).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(3).Value = "Phết keo đế và mũ giầy" & Chr(10) & "鞋底及鞋面刷膠"
                myWorksheet.Rows(4).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(4).Value = "Sơn, in da và pha chế hóa chất để sơn, in da " & Chr(10) & "漆,印刷及調漆調膠"
                myWorksheet.Rows(4).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(5).Value = "Hấp lưu hóa giầy, dép cao su " & Chr(10) & "加硫鞋"
                myWorksheet.Rows(4).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(6).Value = "Trải vải" & Chr(10) & "貼合"
                myWorksheet.Rows(4).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(7).Value = "Cán, luyện cao su trong sản xuất giầy, dép " & Chr(10) & "生產鞋子中的大車"
                myWorksheet.Rows(4).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(8).Value = "Mài nhẵn mặt da, lạng da " & Chr(10) & "打粗,削皮"
                myWorksheet.Rows(4).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(9).Value = "Vận hành máy gò giấy" & Chr(10) & "運行成型機"
                myWorksheet.Rows(4).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(10).Value = "Vận hành máy may" & Chr(10) & "運針車機"
                myWorksheet.Rows(4).Cells(10).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(11).Value = "Tổng cộng" & Chr(10) & "合計"
                myWorksheet.Rows(4).Cells(11).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                'mer tiêu đề
                sheet.MergedCellsRegions.Add(0, 0, 0, 11)
                sheet.MergedCellsRegions.Add(1, 0, 1, 11)
                sheet.MergedCellsRegions.Add(2, 0, 2, 11)
                'mer 3 cột đầu
                sheet.MergedCellsRegions.Add(3, 0, 4, 0)
                sheet.MergedCellsRegions.Add(3, 1, 4, 1)
                sheet.MergedCellsRegions.Add(3, 2, 4, 2)
                'mer 4 cột cuối
                sheet.MergedCellsRegions.Add(3, 3, 3, 11)
                'mer khu
                'khu A
                If KhuA1 > 0 Then
                    sheet.MergedCellsRegions.Add(5, 1, 5 + (KhuA1 - 1), 1)
                End If

                If KhuB1 > 0 Then
                    sheet.MergedCellsRegions.Add(5 + KhuA1, 1, 5 + KhuA1 + (KhuB1 - 1), 1)
                End If
                'Khu B
                If DVC > 0 Then
                    sheet.MergedCellsRegions.Add(5 + KhuA1 + KhuB1, 1, 5 + KhuA1 + KhuB1 + (DVC - 1), 1)
                End If

                If Me.radTCT.Checked Then
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).Value = "TC 合計:"
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.Font.Color = Color.Red
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA1 + KhuB1 + DVC).Cells(0).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    'mer tong cộng
                    sheet.MergedCellsRegions.Add(5 + KhuA1 + KhuB1 + DVC, 0, 5 + KhuA1 + KhuB1 + DVC, 1)
                End If
              
                'For i = 3 To 6
                '    myWorksheet.Rows(5 + KhuA + KhuB + 1).Cells(i).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                '    myWorksheet.Rows(5 + KhuA + KhuB + 1).Cells(i).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                '    myWorksheet.Rows(5 + KhuA + KhuB + 1).Cells(i).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                '    myWorksheet.Rows(5 + KhuA + KhuB + 1).Cells(i).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                'Next

                'sheet.MergedCellsRegions.Add(dongTCT + 6, 1, dongTCT + 6, 3)
                'sheet.MergedCellsRegions.Add(dongTCT + 7, 1, dongTCT + 7, 3)
                'sheet.MergedCellsRegions.Add(dongTCT + 6, 4, dongTCT + 6, 6)
                'sheet.MergedCellsRegions.Add(dongTCT + 7, 4, dongTCT + 7, 6)
                'sheet.MergedCellsRegions.Add(dongTCT + 6, 7, dongTCT + 6, 9)
                'sheet.MergedCellsRegions.Add(dongTCT + 7, 7, dongTCT + 7, 9)

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate
        If btn = "ThongKeCanBo" Then
            XuatExcel_TieuDe2()
        End If
    End Sub
    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub btnThongkeCanBo_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThongkeCanBo.Activate
        btn = "ThongKeCanBo"
        Me.b = New clsBTKSOLUONGKYHDLD
        Dim SqlParam As SqlParameter() = {New SqlParameter("@NGAY", SqlDbType.NVarChar)}
        SqlParam(0).Value = Format(dtpNgaybatdau.Value, "yyyy-MM-dd")
        Dim tblTam1 As DataTable
        If Me.radTCT.Checked Then
            tblTam1 = Me.b.GoiThuTuc("SP_THONGKENHDH_HDLD_TEST", SqlParam) 'SP_THONGKENHDH_HDLD
        End If

        If Me.radKhuA.Checked Then
            tblTam1 = Me.b.GoiThuTuc("SP_THONGKENHDH_HDLD_KHUA_S_TEST", SqlParam) 'SP_THONGKENHDH_HDLD_KHUA_S
        End If
        If Me.radDVC.Checked Then
            tblTam1 = Me.b.GoiThuTuc("SP_THONGKENHDH_HDLD_DVC_S_TEST", SqlParam)
        End If

        If Me.radKhuB.Checked Then
            tblTam1 = Me.b.GoiThuTuc("SP_THONGKENHDH_HDLD_KHUB_S_TEST", SqlParam) 'SP_THONGKENHDH_HDLD_KHUB_S
        End If


        'dgrBC.DataSource = tblTam
        If tblTam1.Rows.Count > 0 Then
            Me.btXemBaoCao.Enabled = True
            KhuA1 = 0
            KhuB1 = 0
            DVC = 0
            dgrBC.DataSource = Nothing
            dgrBC.DataSource = tblTam1

            For i = 0 To dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells("x_ma_").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("x_ma_").Appearance.ForeColor = Color.Black
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Black
                If dgrBC.Rows(i).Cells("x_ma_").Value.ToString() = "小計" Or dgrBC.Rows(i).Cells("x_ma_").Value.ToString() = "TC 總合計" Then
                    Me.dgrBC.Rows(i).Cells("x_ma_").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("x_ma_").Appearance.ForeColor = Color.Red
                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("PHETKEO").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("PHETKEO").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("SONINDA").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("SONINDA").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("HAPLUUHOA").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("HAPLUUHOA").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TRAIVAI").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TRAIVAI").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("CANLUYENCS").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("CANLUYENCS").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("MAINHAN").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("MAINHAN").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("VANHANHMAYGO").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("VANHANHMAYGO").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("VANHANHMAYMAY").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("VANHANHMAYMAY").Appearance.ForeColor = Color.Red

                End If
                If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A區" Then

                    KhuA1 = KhuA1 + 1

                End If
                If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B區" Then

                    KhuB1 = KhuB1 + 1

                End If
                If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC區" Then

                    DVC = DVC + 1

                End If
            Next
            loadgridview2()

        End If
    End Sub
End Class