Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Excel
Imports Infragistics.Win

Public Class frmTKSOLUONGKYHDLD
    Friend WithEvents b As clsBTKSOLUONGKYHDLD
    Public i, j, k, l As Integer
    Dim KhuA As Integer
    Dim KhuB As Integer
    Dim DVC As Integer
    Dim KhuA1 As Integer
    Dim KhuB1 As Integer
    Dim btn As String
    Private tieude As String
    Private Sub frmTKCongViecHDLD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radKhuA.Checked = True
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub btnXemSoLuongKyHDLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub loadgridview1()
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
            .Columns("KHONGTHOIHAN").Header.Caption = "Không thời hạn" & Chr(10) & "無期限合同"
            .Columns("KHONGTHOIHAN").Width = 120
            .Columns("KHONGTHOIHAN").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("THOIHAN1NAM").Header.Caption = "Thời hạn 1 năm" & Chr(10) & "期限為一年"
            .Columns("THOIHAN1NAM").Width = 180
            .Columns("THOIHAN1NAM").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("THAMGIABAOHIEM").Header.Caption = "Tham gia bảo hiểm" & Chr(10) & "參加保險人數"
            .Columns("THAMGIABAOHIEM").Width = 180
            .Columns("THAMGIABAOHIEM").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            .Columns("TONGCONG").Header.Caption = "Tổng cộng" & Chr(10) & "合計"
            .Columns("TONGCONG").Width = 80
            .Columns("TONGCONG").Header.Appearance.FontData.Bold = DefaultableBoolean.True

            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

            ''=====
            .Columns("STT").Header.VisiblePosition = 0
            .Columns("KHU").Header.VisiblePosition = 1
            .Columns("x_ma_").Header.VisiblePosition = 2
            .Columns("KHONGTHOIHAN").Header.VisiblePosition = 3
            .Columns("THOIHAN1NAM").Header.VisiblePosition = 4
            .Columns("THAMGIABAOHIEM").Header.VisiblePosition = 5
            .Columns("TONGCONG").Header.VisiblePosition = 6
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
    Private Sub XuatExcel_TieuDe1()
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "THỐNG KÊ SỐ LƯỢNG ĐÃ KÝ HĐLĐ " & tieude & " " & Chr(10) & "全廠已簽署合約人數統計"
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
                Me.dgrBC.DisplayLayout.Bands(0).Columns("KHONGTHOIHAN").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("THOIHAN1NAM").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("THAMGIABAOHIEM").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG").Header.VisiblePosition = 6

                myWorksheet.Rows(0).Cells(0).Value = "CÔNG TY TNHH TỶ BÁCH"
                myWorksheet.Rows(1).Cells(0).Value = "TY BACH CO., LTD"
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
                    For j = 0 To 6

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

                myWorksheet.Rows(3).Cells(3).Value = "LOẠI HĐ 合同種類"
                myWorksheet.Rows(3).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(4).Value = "LOẠI HĐ 合同種類"
                myWorksheet.Rows(3).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(5).Value = "LOẠI HĐ 合同種類"
                myWorksheet.Rows(3).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(6).Value = "LOẠI HĐ 合同種類"
                myWorksheet.Rows(3).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(4).Cells(3).Value = "KXĐ thời hạn" & Chr(10) & "無期限合同"
                myWorksheet.Rows(4).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(4).Value = "Có thời hạn 01 năm" & Chr(10) & "期限為一年"
                myWorksheet.Rows(4).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(5).Value = "Số lượng Tham gia bảo hiểm" & Chr(10) & "參加保險人數"
                myWorksheet.Rows(4).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(6).Value = "Tổng cộng" & Chr(10) & "合計"
                myWorksheet.Rows(4).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                'mer tiêu đề
                sheet.MergedCellsRegions.Add(0, 0, 0, 6)
                sheet.MergedCellsRegions.Add(1, 0, 1, 6)
                sheet.MergedCellsRegions.Add(2, 0, 2, 6)
                'mer 3 cột đầu
                sheet.MergedCellsRegions.Add(3, 0, 4, 0)
                sheet.MergedCellsRegions.Add(3, 1, 4, 1)
                sheet.MergedCellsRegions.Add(3, 2, 4, 2)
                'mer 4 cột cuối
                sheet.MergedCellsRegions.Add(3, 3, 3, 6)
                'mer khu
                If Me.radKhuA.Checked Then 'nếu khu a thì gom nhóm a
                    'khu A
                    sheet.MergedCellsRegions.Add(5, 1, 5 + (KhuA - 1), 1)
                End If
                If Me.radKhuB.Checked Then 'nếu khu b thì gom nhóm b
                    'Khu B
                    sheet.MergedCellsRegions.Add(5 + KhuA, 1, 5 + KhuA + (KhuB - 1), 1)
                End If
                If Me.radDVC.Checked Then 'nếu dvc thì gom nhóm dvc
                    'DVC
                    sheet.MergedCellsRegions.Add(5 + KhuA + KhuB, 1, 5 + KhuA + KhuB + (DVC - 1), 1)
                End If
                If Me.radTCT.Checked Then ' nếu TCT thì gom nhóm  khu a,b
                    'khu A
                    sheet.MergedCellsRegions.Add(5, 1, 5 + (KhuA - 1), 1)
                    'Khu B
                    sheet.MergedCellsRegions.Add(5 + KhuA, 1, 5 + KhuA + (KhuB - 1), 1)
                    'DVC
                    sheet.MergedCellsRegions.Add(5 + KhuA + KhuB, 1, 5 + KhuA + KhuB + DVC - 1, 1)
                End If
                If Me.radTCT.Checked Then  ' nếu chọn TCT thì mới có dòng tổng phía cuối cùng
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).Value = "TC 合計:"
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.Font.Color = Color.Red
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                    myWorksheet.Rows(5 + KhuA + KhuB + DVC).Cells(0).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    'mer tong cộng
                    sheet.MergedCellsRegions.Add(5 + KhuA + KhuB + DVC, 0, 5 + KhuA + KhuB + DVC, 1)
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
        If btn = "ThongKeSoLuong" Then
            XuatExcel_TieuDe1()
        End If
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        Me.btXemBaoCao.Enabled = False
    End Sub

    Private Sub UltraGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox2.Click

    End Sub

    Private Sub btnxem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxem.Activate
        btn = "ThongKeSoLuong"
        Dim tungay As Date = dtptungay.Value
        Dim strtungay As String = tungay.ToString("yyyy-MM-dd")
        Dim denngay As Date = dtpdenngay.Value
        Dim strdenngay As String = denngay.ToString("yyyy-MM-dd")

        Me.b = New clsBTKSOLUONGKYHDLD
        Dim SqlParam As SqlParameter() = {New SqlParameter("@DONVI", SqlDbType.NVarChar), _
                                          New SqlParameter("@tungay", SqlDbType.NVarChar), _
                                          New SqlParameter("@denngay", SqlDbType.NVarChar)}
        SqlParam(0).Value = "A"
        SqlParam(1).Value = strtungay
        SqlParam(2).Value = strdenngay
        Dim tblTam As DataTable
        If Me.radKhuA.Checked Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKESOLUONG_HDLD_KHUA_TEST_K", SqlParam) 'SP_THONGKESOLUONG_HDLD_KHUA
        End If
        If Me.radKhuB.Checked Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKESOLUONG_HDLD_KHUB_TEST_K", SqlParam) 'SP_THONGKESOLUONG_HDLD_KHUB
        End If
        If Me.radDVC.Checked Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKESOLUONG_HDLD_DVC_TEST_K", SqlParam)
        End If
        If Me.radTCT.Checked Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKESOLUONG_HDLD_TEST_K", SqlParam) 'SP_THONGKESOLUONG_HDLD
        End If
        ' tblTam = Me.b.GoiThuTuc("SP_THONGKESOLUONG_HDLD", SqlParam)
        If tblTam.Rows.Count > 0 Then
            Me.btXemBaoCao.Enabled = True
            dgrBC.DataSource = Nothing
            dgrBC.DataSource = tblTam
            'Me.dgrBC.DataSource = tblTam
            KhuA = 0
            KhuB = 0
            DVC = 0
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

                    Me.dgrBC.Rows(i).Cells("KHONGTHOIHAN").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("KHONGTHOIHAN").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("THOIHAN1NAM").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("THOIHAN1NAM").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("THAMGIABAOHIEM").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("THAMGIABAOHIEM").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.True
                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red

                End If
                If Me.radKhuA.Checked Then
                    tieude = "KHU A"
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" Then
                        KhuA = KhuA + 1
                    End If
                    KhuB = 0
                    DVC = 0
                End If
                If Me.radKhuB.Checked Then
                    tieude = "KHU B"
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" Then
                        KhuB = KhuB + 1
                    End If
                    KhuA = 0
                    DVC = 0
                End If
                If Me.radDVC.Checked Then
                    tieude = "Đơn vị chung"
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC 區" Then
                        DVC = DVC + 1
                    End If
                    KhuA = 0
                    KhuB = 0
                End If
                If Me.radTCT.Checked Then
                    tieude = "TOÀN CÔNG TY"
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" Then
                        KhuA = KhuA + 1
                    End If
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" Then
                        KhuB = KhuB + 1
                    End If
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC 區" Then
                        DVC = DVC + 1
                    End If
                End If

            Next
            loadgridview1()

        End If

    End Sub
End Class