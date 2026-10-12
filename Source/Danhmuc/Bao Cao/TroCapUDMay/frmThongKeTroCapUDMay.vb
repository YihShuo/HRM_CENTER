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
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO
Public Class frmThongKeTroCapUDMay

    Public soluongcot_dong As Integer = 0
    Public soluongcot_codinh As Integer = 0
    Public tblTempMucTien As New DataTable()
    Public schuoicot As String = ""
    Public schuoitinhtong As String = ""
    Public tongsocot As Integer = 0
    Private Sub LoadGridView_Chitiet()

        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            With Me.dgrBC.DisplayLayout.Bands(0)
                tongsocot = 0
                .ClearGroupByColumns()
                dgrBC.DisplayLayout.Bands(0).Columns.ClearUnbound()
                dgrBC.DisplayLayout.Bands(0).SortedColumns.Clear()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti


                .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
                .Columns("STT").Width = 100
                .Columns("X_MA_").Header.Caption = "Mã xưởng" & Chr(10) & "序號"
                .Columns("X_MA_").Width = 200
                .Columns("KHU").Header.Caption = "Khu" & Chr(10) & "區"
                .Columns("NV_MA").Header.Caption = "Số thẻ" & Chr(10) & "工號"
                .Columns("NV_TEN").Header.Caption = "Họ tên" & Chr(10) & " 姓名"
                .Columns("DV_MA").Header.Caption = "Đơn vị" & Chr(10) & "單位"
                .Columns("NV_NGAYVAO").Header.Caption = "Ngày vào" & Chr(10) & "進廠日期"
                .Columns("HD_NGAYKY").Header.Caption = "Ngày ký" & Chr(10) & "簽合同"
                .Columns("NV_GioiTinh").Header.Caption = "Giới tính" & Chr(10) & "性別"
                .Columns("CV_TEN").Header.Caption = "Công việc" & Chr(10) & "序號"
                .Columns("CVU_TEN").Header.Caption = "Chức vụ" & Chr(10) & "工作"
                .Columns("NV_Ngaysinh").Header.Caption = "Ngày sinh" & Chr(10) & "出生年"
                .Columns("CV_MA").Hidden = True

                .Columns("KHU").Width = 200
                .Columns("XUONGTENHOA").Header.Caption = "Xưởng" & Chr(10) & "序號"
                .Columns("NV_MA").Width = 100
                .Columns("NV_TEN").Width = 200
                .Columns("DV_MA").Width = 150
                .Columns("NV_NGAYVAO").Width = 100
                .Columns("HD_NGAYKY").Width = 100
                .Columns("NV_GioiTinh").Width = 100
                .Columns("NV_Ngaysinh").Width = 100
                .Columns("CV_TEN").Width = 200
                .Columns("CVU_TEN").Width = 200

                .Columns("X_MA_").Hidden = True

                For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next
                .Columns("CV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("CVU_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColMoving = AllowColMoving.NotAllowed
                Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColSwapping = AllowColMoving.NotAllowed

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
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            With Me.dgrBC.DisplayLayout.Bands(0)
                tongsocot = 0
                .ClearGroupByColumns()
                dgrBC.DisplayLayout.Bands(0).Columns.ClearUnbound()
                dgrBC.DisplayLayout.Bands(0).SortedColumns.Clear()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
                Dim STT, X_MA_, KHU, XUONGTENHOA, TONGCONG As UltraGridColumn
                soluongcot_codinh = 3 ''(STT, X_MA_, KHU, XUONGTENHOA; cột ẩn trên lưới ko tính)



                If .Columns.Exists("STT") = False Then
                    STT = dgrBC.DisplayLayout.Bands(0).Columns.Add("STT", "STT")
                    STT.DataType = GetType(Integer)
                    STT.CellActivation = Activation.NoEdit

                    .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
                    .Columns("STT").Width = 100
                End If

                If .Columns.Exists("X_MA_") = False Then
                    X_MA_ = dgrBC.DisplayLayout.Bands(0).Columns.Add("X_MA_", "X_MA_")
                    X_MA_.DataType = GetType(String)
                    X_MA_.CellActivation = Activation.NoEdit
                End If

                If .Columns.Exists("KHU") = False Then
                    KHU = dgrBC.DisplayLayout.Bands(0).Columns.Add("KHU", "KHU")
                    KHU.DataType = GetType(String)
                    KHU.CellActivation = Activation.NoEdit
                End If

                If .Columns.Exists("XUONGTENHOA") = False Then
                    XUONGTENHOA = dgrBC.DisplayLayout.Bands(0).Columns.Add("XUONGTENHOA", "XUONGTENHOA")
                    XUONGTENHOA.DataType = GetType(String)
                    XUONGTENHOA.CellActivation = Activation.NoEdit
                End If

                If .Columns.Exists("TONGCONG") = False Then
                    TONGCONG = dgrBC.DisplayLayout.Bands(0).Columns.Add("TONGCONG", "TONGCONG")
                    TONGCONG.DataType = GetType(String)
                    TONGCONG.CellActivation = Activation.NoEdit
                    TONGCONG.Header.VisiblePosition = soluongcot_dong + 1
                Else
                    ''========= CÓ RỒI THI GÁN TAG ==============
                    .Columns("TONGCONG").Tag = "A"
                End If
                tongsocot = tongsocot + soluongcot_codinh + soluongcot_dong + 1 ''số lượng cột = số cột cố định + số cột động + 1 (cột tổng)
                .Columns("STT").Header.Caption = "STT" & Chr(10) & "序號"
                .Columns("STT").Width = 100
                .Columns("X_MA_").Header.Caption = "Mã xưởng" & Chr(10) & "序號"
                .Columns("X_MA_").Width = 200
                .Columns("KHU").Header.Caption = "Xưởng" & Chr(10) & "序號"
                .Columns("KHU").Width = 200
                .Columns("XUONGTENHOA").Header.Caption = "Đơn vị" & Chr(10) & "單位"
                .Columns("XUONGTENHOA").Width = 200
                .Columns("TONGCONG").Header.Caption = "Tổng Cộng" & Chr(10) & "合計"
                .Columns("TONGCONG").Width = 200

                .Columns("STT").Header.VisiblePosition = 0
                .Columns("KHU").Header.VisiblePosition = 1
                .Columns("X_MA_").Header.VisiblePosition = 2
                .Columns("XUONGTENHOA").Header.VisiblePosition = 3
                .Columns("X_MA_").Hidden = True


                For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    ''============== PHÂN LOẠI NHỮNG CỘT CỐ ĐỊNH VÀ CỘT ĐỘNG 
                Next

                .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
                .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
                Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColMoving = AllowColMoving.NotAllowed
                Me.dgrBC.DisplayLayout.Bands(0).Override.AllowColSwapping = AllowColMoving.NotAllowed

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

                'band.Layout.Override.RowSelectors = DefaultableBoolean.True
                'band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
                'band.Layout.Bands(0).Summaries.Clear()
                'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                'summary.Appearance.TextHAlign = HAlign.Right
                'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                'band.SummaryFooterCaption = "Tổng số: "
                'band = Nothing
                If Me.dgrBC.Rows.Count > 0 Then
                    For dong As Integer = 0 To dgrBC.Rows.Count - 1
                        If Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGCONGKHUA" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUA" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUB" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUDVC" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TCT" Then
                            For cot As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                Me.dgrBC.Rows(dong).Cells(cot).Appearance.ForeColor = Color.Red
                            Next
                            Me.dgrBC.Rows(dong).Cells("KHU").Appearance.ForeColor = Color.Black
                            Me.dgrBC.Rows(dong).Cells("STT").Appearance.ForeColor = Color.Black
                        End If
                    Next
                End If
            End With
          
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Dim b As New clsBThongKeTroCapUDMay
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
    Private Sub XuatExcel_TrocapUDMay()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TKUDM")
                Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TKUDM")
                ''======== Header ============''
                myWorksheet.Rows(0).Cells(1).Value = "CÔNG TY TNHH TỶ XUÂN"
                myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Left
                sheet.MergedCellsRegions.Add(0, 1, 0, 5)

                myWorksheet.Rows(1).Cells(1).Value = "VINH LONG FOOTWEAR CO., LTD"
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Left
                sheet.MergedCellsRegions.Add(1, 1, 1, 6)

                ''======== tieu đề ============'' cell 4 (0-3: trừ 3 cột cố định)
                ''========= số lượng cột động :Me.tblTempMucTien.Rows.Count 
                myWorksheet.Rows(3).Cells(soluongcot_codinh + 1).Value = "SỐ TIỀN PHỤ CẤP 津貼金額"
                myWorksheet.Rows(3).Cells(soluongcot_codinh + 1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(3).Cells(soluongcot_codinh + 1).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(3).Cells(soluongcot_codinh + 1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                myWorksheet.Rows(3).Cells(soluongcot_codinh + 1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

                sheet.MergedCellsRegions.Add(3, soluongcot_codinh + 1, 4, soluongcot_dong + 1 + 3) ''---- tổng số cột merge = số cột cố định + 1; vị trí bđ cột động đầu tiên; Me.tblTempMucTien.Rows.Count + 1: số lượng cột động + cột tổng cột cuối cùng + số lượng cột cố định

                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(2).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 300
                myWorksheet.Rows(2).Height = 800
                If Me.radKhuA.Checked Then
                    myWorksheet.Rows(2).Cells(1).Value = "THỐNG KÊ PHỤ CẤP ƯU ĐÃI MAY KHU A THÁNG " & Me.dtpThang.Text & Chr(10) & Me.dtpThang.Text & " 月份全廠針車手藝優待津貼統計"
                End If

                If Me.radKhuB.Checked Then
                    myWorksheet.Rows(2).Cells(1).Value = "THỐNG KÊ PHỤ CẤP ƯU ĐÃI MAY KHU B THÁNG " & Me.dtpThang.Text & Chr(10) & Me.dtpThang.Text & " 月份全廠針車手藝優待津貼統計"
                End If

                If Me.radKhuDVC.Checked Then
                    myWorksheet.Rows(2).Cells(1).Value = "THỐNG KÊ PHỤ CẤP ƯU ĐÃI MAY KHU ĐƠN VỊ CHUNG THÁNG " & Me.dtpThang.Text & Chr(10) & Me.dtpThang.Text & " 月份全廠針車手藝優待津貼統計"
                End If

                If radTCT.Checked Then
                    myWorksheet.Rows(2).Cells(1).Value = "THỐNG KÊ PHỤ CẤP ƯU ĐÃI MAY TOÀN CÔNG TY THÁNG " & Me.dtpThang.Text & Chr(10) & Me.dtpThang.Text & " 月份全廠針車手藝優待津貼統計"
                End If

                sheet.MergedCellsRegions.Add(2, 1, 2, soluongcot_dong + 1 + 3)

                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 5, 1)

                ''============= vòng lặp merge cho các cột ko cố định =====================''
                For j As Integer = 1 To soluongcot_codinh
                    sheet.MergedCellsRegions.Add(3, j, 5, j)
                Next

                For k As Integer = 1 To soluongcot_dong + 1 + 3
                    For dong As Integer = 3 To 5
                        myWorksheet.Rows(dong).Cells(k).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(dong).Cells(k).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(dong).Cells(k).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(dong).Cells(k).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(dong).Cells(k).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(dong).Cells(k).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    Next
                Next
                Dim vt_dongTCT As Integer ''dong toàn công ty
                If Me.radTCT.Checked Then
                    vt_dongTCT = Me.dgrBC.Rows.Count + 6
                    sheet.MergedCellsRegions.Add(vt_dongTCT - 1, 1, vt_dongTCT - 1, 3)
                    myWorksheet.Rows(vt_dongTCT - 1).Cells(1).Value = "TC 合計:"
                End If
              
                ''======== Footer ============''
                Dim sodongtieude, footer, soluongcot As Integer ''số dòng tiêu đề trong excel
                sodongtieude = 6
                footer = sodongtieude + dgrBC.Rows.Count + 2 ''cách bao xa thi cộng vô; số lượng cột = soluongcot_dong + 1 + 3
                soluongcot = soluongcot_dong + 1 + 3
                myWorksheet.Rows(footer).Cells(soluongcot - 2).Value = "LẬP BIỂU:" & Chr(10) & "製表"
                myWorksheet.Rows(footer).Cells(soluongcot - 2).CellFormat.Alignment = HorizontalCellAlignment.Center

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub methodLoad_ThongKeTroCapUDMay_Chitiet(ByVal sMucTien As String)
        Dim listpar As New ArrayList(2)
        Dim obj As New objThongKeTroCapUDMay
        Dim tblTam, tblTemp, tblMucTienChitiet As DataTable
        ''=========== TÁCH KHU A, KHU B =======''

        If Me.radKhuA_Chitiet.Checked Then
            obj.ChonKhu = "A"
        End If

        If Me.radKhuB_Chitiet.Checked Then
            obj.ChonKhu = "B"
        End If

        If Me.radKhuDVC_Chitiet.Checked Then
            obj.ChonKhu = "DVC"
        End If

        If Me.radTCT_Chitiet.Checked Then
            obj.ChonKhu = "TCT"
        End If

        tblTemp = New DataTable()
        tblTam = New DataTable()
        tblTam.Clear()
        tblMucTienChitiet = Me.b.LoadKhongThamso("SP_THONGKETCUDMAY_MUCTIENMAY_S")

        If sMucTien <> "ALL" Then
            listpar.Clear()
            listpar.Add(New SqlParameter("@MUCTIEN", sMucTien))

            Select Case obj.ChonKhu.ToUpper()
                Case "A", "B", "DVC"
                    listpar.Add(New SqlParameter("@KHU", obj.ChonKhu))
                    tblTam = Me.b.Load("SP_THONGKETCUDMAY_CHITIET_KHU_MOI_S", listpar)
         
                Case "TCT"
                    tblTam = Me.b.Load("SP_THONGKETCUDMAY_CHITIET_MOI_S", listpar)
            End Select

        Else
            If tblMucTienChitiet.Rows.Count > 0 Then
                For i As Integer = 0 To tblMucTienChitiet.Rows.Count - 1
                    listpar.Clear()
                    listpar.Add(New SqlParameter("@MUCTIEN", tblMucTienChitiet.Rows(i).Item("HD_TROCAPUD").ToString()))

                    Select Case obj.ChonKhu.ToUpper()
                        Case "A", "B", "DVC"
                            listpar.Add(New SqlParameter("@KHU", obj.ChonKhu))

                            tblTemp = Me.b.Load("SP_THONGKETCUDMAY_CHITIET_KHU_MOI_S", listpar)
                        Case "TCT"
                            tblTemp = Me.b.Load("SP_THONGKETCUDMAY_CHITIET_MOI_S", listpar)
                    End Select
                    If tblTemp.Rows.Count > 0 Then
                        tblTam.Merge(tblTemp)
                    End If
                Next
              
            End If
        End If

        If tblTam Is Nothing Then
            Me.dgrBC.DataSource = Nothing
            Me.btnExcel.Enabled = False
            Exit Sub
        End If
        If tblTam.Rows.Count > 0 Then
            Dim stringSort As String = "KHU ASC"
            tblTam.DefaultView.Sort = stringSort
            Me.dgrBC.DataSource = tblTam
            Me.btnExcel.Enabled = True
        Else
            Me.dgrBC.DataSource = Nothing
            Me.btnExcel.Enabled = False
        End If
    End Sub
    Private Sub methodLoad_ThongKeTroCapUDMay()
        Dim listpar As New ArrayList(2)
        Dim listpar1 As New ArrayList(2)
        Dim listpar2 As New ArrayList(1)
        Dim obj As New objThongKeTroCapUDMay
        Dim tblTam As DataTable

        listpar.Clear()
        tblTempMucTien.Clear()
        tblTempMucTien = Me.b.LoadKhongThamso("SP_THONGKETCUDMAY_MUCTIENMAY_S")
        If tblTempMucTien.Rows.Count > 0 Then
            soluongcot_dong = tblTempMucTien.Rows.Count
            ''========== TAO bang 
            schuoitinhtong = ""
            schuoicot = ""
            Me.b.GoiThuTucKhongThamSo("SP_THONGKETCUDMAY_TAOBANG")
            ''=========== TÁCH KHU A, KHU B =======''

            If Me.radKhuA.Checked Then
                obj.ChonKhu = "A"
            End If

            If Me.radKhuB.Checked Then
                obj.ChonKhu = "B"
            End If

            If Me.radKhuDVC.Checked Then
                obj.ChonKhu = "DVC"
            End If

            If Me.radTCT.Checked Then
                obj.ChonKhu = "TCT"
            End If

            Select Case obj.ChonKhu.ToUpper()
                Case "A", "B", "DVC"
                    listpar.Clear()
                    listpar.Add(New SqlParameter("@KHU", obj.ChonKhu))
                    Me.b.GoiThuTuc("SP_THONGKETCUDMAY_TAODMXUONG_KHU_MOI", listpar)
                Case "TCT"
                    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCUDMAY_TAODMXUONG_TCT_MOI")

            End Select


            For i As Integer = 0 To tblTempMucTien.Rows.Count - 1
                schuoicot = schuoicot + " [" + tblTempMucTien.Rows(i).Item("HD_TrocapUD").ToString() + "] INT ,"
                schuoitinhtong = schuoitinhtong + " ISNULL([" + tblTempMucTien.Rows(i).Item("HD_TrocapUD").ToString() + "],0) + "
            Next

            schuoicot = schuoicot.Substring(0, Len(schuoicot) - 1)
            schuoicot = schuoicot + ",TONGCONG INT"
            schuoitinhtong = schuoitinhtong.Substring(0, Len(schuoitinhtong) - 2)
            ''========== alter bang 
            listpar.Clear()
            listpar.Add(New SqlParameter("@sql", schuoicot))
            Me.b.GoiThuTuc("SP_THONGKETCUDMAY_TAOCOT", listpar)
            listpar.Clear()

            For i As Integer = 0 To tblTempMucTien.Rows.Count - 1
                obj.ChonBang = 1
                obj.Tencot = tblTempMucTien.Rows(i).Item(0).ToString()
                obj.HD_TrocapUD = Convert.ToDouble(tblTempMucTien.Rows(i).Item(0))
                'Me.b.TinhsolieutrocapUDMay(obj) ''thay bằng thủ tục
                listpar1.Clear()
                listpar1.Add(New SqlParameter("@TENCOT", obj.Tencot))
                listpar1.Add(New SqlParameter("@HD_TrocapUD", obj.HD_TrocapUD))

                Me.b.GoiThuTuc("TINHSOLIEUTCUDMAY_MUCTIEN_MOI_S", listpar1) ''tính theo cột mức tiền

            Next
            obj.ChonBang = 2
            obj.Chuoitinhtong = schuoitinhtong
            'Me.b.TinhsolieutrocapUDMay(obj)  ''tính theo cột tổng cộng
            listpar2.Clear()
            listpar2.Add(New SqlParameter("@CHUOITINHTONG", obj.Chuoitinhtong))
            Me.b.GoiThuTuc("TINHSOLIEUTCUDMAY_TONGCONG_MOI_S", listpar2)
           
            tblTam = Me.b.LoadKhongThamso("SP_THONGKETCUDMAY_MOI_S")
            Me.dgrBC.DataSource = tblTam
            If Not tblTam Is Nothing Then
                Me.btnExcel.Enabled = True
            End If
        Else
            MessageBox.Show("Không thể thống kê được do không có mức trợ cấp ưu đãi may nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Select Case Me.tabTKgiocongxuong.SelectedTab.Index
            Case 0
                methodLoad_ThongKeTroCapUDMay()
                If Not Me.dgrBC.DataSource Is Nothing Then
                    LoadGridView()
                End If
                Me.XpCaption2.Text = "Danh sách trợ cấp ưu đãi may"
            Case 1
                methodLoad_ThongKeTroCapUDMay_Chitiet(Me.cbMucTienTCMay.Value.ToString())
                If Not Me.dgrBC.DataSource Is Nothing Then
                    LoadGridView_Chitiet()
                End If
                Me.XpCaption2.Text = "Bảng thống kê trợ cấp ưu đãi may"
        End Select
    End Sub
    Private Sub LoadCombo()
        Dim listpar As New ArrayList(2)
        Dim obj As New objThongKeTroCapUDMay
        Dim tblTam, tblTam1 As DataTable
        listpar.Clear()

        tblTam = Me.b.LoadKhongThamso("SP_THONGKETCUDMAY_MUCTIENMAY_COMBO_S")
        If tblTam.Rows.Count > 0 Then          
            Me.cbMucTienTCMay.DataSource = tblTam
            Me.cbMucTienTCMay.SelectedIndex = 0
        End If
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Select Case Me.tabTKgiocongxuong.SelectedTab.Index
            Case 0
                If Me.dgrBC.Rows.Count > 0 Then
                    XuatExcel_TrocapUDMay()
                Else
                    MessageBox.Show("Vui lòng lọc dữ liệu rồi mới xuất excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 1
                Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
                If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                    MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select

    End Sub
    Private Sub frmThongKeTroCapUDMay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnExcel.Enabled = False
        LoadCombo()
        Me.radTCT.Checked = True
        Me.radTCT_Chitiet.Checked = True
    End Sub
    Private Sub cbMucTienTCMay_EditorSpinButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs) Handles cbMucTienTCMay.EditorSpinButtonClick
        Select Case e.ButtonType
            Case SpinButtonItem.PreviousItem
                SendKeys.Send("{Up}")
            Case SpinButtonItem.NextItem
                SendKeys.Send("{Down}")
        End Select
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        Me.dgrBC.DataSource = Nothing
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged, radKhuDVC.CheckedChanged
        Me.dgrBC.DataSource = Nothing
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        Me.dgrBC.DataSource = Nothing
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub tabTKgiocongxuong_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabTKgiocongxuong.SelectedTabChanged
        Me.dgrBC.DataSource = Nothing
        Me.btnExcel.Enabled = False
        Select Case Me.tabTKgiocongxuong.SelectedTab.Index
            Case 1
                Me.XpCaption2.Text = "Danh sách trợ cấp ưu đãi may"
            Case 0
                Me.XpCaption2.Text = "Bảng thống kê trợ cấp ưu đãi may"
            Case Else
        End Select
    End Sub
End Class