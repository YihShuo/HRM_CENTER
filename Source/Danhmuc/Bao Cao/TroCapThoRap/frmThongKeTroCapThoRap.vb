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
Public Class frmThongKeTroCapThoRap
    Public soluongcot_dong As Integer = 0
    Public soluongcot_codinh As Integer = 0
    Public tblTempMucTien As New DataTable()
    Public schuoicot As String = ""
    Public schuoitinhtong As String = ""
    Public tongsocot As Integer = 0
    Private khu As String
    Private tieudeviet As String
    Private tieudehoa As String
    Dim KhuA As Integer = 0
    Dim KhuB As Integer = 0
    Dim DVC As Integer = 0
    Private i, j As Integer
    Private ngay As String
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
                Me.dgrBC.DisplayLayout.Bands(0).Columns("STT_AN").Hidden = True
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
                band.Layout.Override.RowSelectors = DefaultableBoolean.True
                band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
                'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(3)
                'band.Layout.Bands(0).Summaries.Clear()
                'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
                'summary.Appearance.TextHAlign = HAlign.Right
                'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                'band.SummaryFooterCaption = "Tổng số: "
                'band = Nothing
            End With

            If Me.dgrBC.Rows.Count > 0 Then
                Dim sttchay As Integer = 0
                For dong As Integer = 0 To dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUA" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUB" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TONGKHUDVC" Or Me.dgrBC.Rows(dong).Cells("X_MA_").Value = "TCT" Then
                        For cot As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                            Me.dgrBC.Rows(dong).Cells(cot).Appearance.ForeColor = Color.Red
                        Next
                        Me.dgrBC.Rows(dong).Cells("KHU").Appearance.ForeColor = Color.Black
                        Me.dgrBC.Rows(dong).Cells("STT").Appearance.ForeColor = Color.Black
                    End If
                    If Me.dgrBC.Rows(dong).Cells("STT_AN").Value.ToString <> "" Then
                        Me.dgrBC.Rows(dong).Cells("STT").Value = sttchay + 1
                        sttchay = sttchay + 1
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim b As New clsBThongKeTroCapThoRap
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
    Private Sub XuatExcel_TrocapThoRap()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TKTR")
                Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TKTR")
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
                myWorksheet.Rows(2).Cells(1).Value = "THỐNG KÊ PHỤ CẤP THỢ RẬP TOÀN CÔNG TY THÁNG " & Me.dtpThang.Text & Chr(10) & Me.dtpThang.Text & " 月份全廠版師津貼金統計"

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
                vt_dongTCT = Me.dgrBC.Rows.Count + 6
                sheet.MergedCellsRegions.Add(vt_dongTCT - 1, 1, vt_dongTCT - 1, 3)
                myWorksheet.Rows(vt_dongTCT - 1).Cells(1).Value = "TC 合計:"
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
                MessageBox.Show("Lỗi.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        'XuatExcel_TrocapThoRap()
        XuatExcel_TrocapThoRap_gam()
    End Sub

    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        methodLoad_ThongKeThoRap()
        LoadGridView()
        Me.btnExcel.Enabled = True
    End Sub
    Private Sub methodLoad_ThongKeThoRap()
        Dim listpar As New ArrayList(2)
        Dim obj As New objThongKeTroCapThoRap
        Dim tblTam As DataTable
        'Gán biến KHUA , KHUB mặc định trở về 0
        KhuA = 0
        KhuB = 0
        DVC = 0
        'Xét giá trị khu chọn
        If Me.radKhuA.Checked Then
            obj.Khu = "A"
            tieudeviet = "KHU A"
            tieudehoa = "A廠區"
        End If
        If Me.radKhuB.Checked Then
            obj.Khu = "B"
            tieudeviet = "KHU B"
            tieudehoa = "B廠區"
        End If
        If Me.radDVC.Checked Then
            obj.Khu = "DVC"
            tieudeviet = "DVC"
            tieudehoa = "DVC廠區"
        End If
        If Me.radTCT.Checked Then
            obj.Khu = "TCT"
            tieudeviet = "TOÀN CÔNG TY"
            tieudehoa = "全廠"
        End If
        '--------------------
        'listpar.Clear()
        'tblTempMucTien.Clear()
        'tblTempMucTien = Me.b.LoadKhongThamso("SP_THONGKETCTHORAP_MUCTIENTHORAP_S")
        'If tblTempMucTien.Rows.Count > 0 Then
        '    soluongcot_dong = tblTempMucTien.Rows.Count
        '    ''========== TAO bang 
        '    schuoitinhtong = ""
        '    schuoicot = ""
        '    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCTHORAP_TAOBANG")
        '    ''==================================================================================================
        '    'If Me.radKhuA.Checked Then
        '    '    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCTHORAP_TAODMXUONG_KHUA_TEST") 'SP_THONGKETCTHORAP_TAODMXUONG
        '    'End If
        '    'If Me.radKhuB.Checked Then
        '    '    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCTHORAP_TAODMXUONG_KHUB_TEST") 'SP_THONGKETCTHORAP_TAODMXUONG
        '    'End If
        '    'If Me.radDVC.Checked Then
        '    '    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCTHORAP_TAODMXUONG_DVC_TEST")
        '    'End If
        '    'If Me.radTCT.Checked Then
        '    '    Me.b.GoiThuTucKhongThamSo("SP_THONGKETCTHORAP_TAODMXUONG_TEST") 'SP_THONGKETCTHORAP_TAODMXUONG
        '    'End If
        '    ''===================================================================================================
        '    For i As Integer = 0 To tblTempMucTien.Rows.Count - 1
        '        schuoicot = schuoicot + " [" + tblTempMucTien.Rows(i).Item("HD_TROCAPTHORAP").ToString() + "] INT ,"
        '        schuoitinhtong = schuoitinhtong + " ISNULL([" + tblTempMucTien.Rows(i).Item("HD_TROCAPTHORAP").ToString() + "],0) + "
        '    Next

        '    schuoicot = schuoicot.Substring(0, Len(schuoicot) - 1)
        '    schuoicot = schuoicot + ",TONGCONG INT"
        '    schuoitinhtong = schuoitinhtong.Substring(0, Len(schuoitinhtong) - 2)
        '    ''========== alter bang 
        '    listpar.Clear()
        '    listpar.Add(New SqlParameter("@sql", schuoicot))
        '    Me.b.GoiThuTuc("SP_THONGKETCTHORAP_TAOCOT", listpar)
        '    listpar.Clear()

        '    For i As Integer = 0 To tblTempMucTien.Rows.Count - 1
        '        obj.ChonBang = 1
        '        obj.Tencot = tblTempMucTien.Rows(i).Item(0).ToString()
        '        obj.HD_TrocapTR = Convert.ToDouble(tblTempMucTien.Rows(i).Item(0))
        '        Me.b.TinhsolieutrocapThoRap(obj)
        '    Next
        '    obj.ChonBang = 2
        '    obj.Chuoitinhtong = schuoitinhtong
        '    Me.b.TinhsolieutrocapThoRap(obj)

        Me.b = New clsBThongKeTroCapThoRap
        Dim SqlParam As SqlParameter() = {New SqlParameter("@KHU", SqlDbType.NVarChar)}
        SqlParam(0).Value = obj.Khu
        If obj.Khu <> "TCT" Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKETROCAPTHORAP_THEOKHU_FC", SqlParam)
        Else
            tblTam = Me.b.GoiThuTuc("SP_THONGKETROCAPTHORAP_TCT_FC", SqlParam) 'SP_THONGKEDSCB_S
        End If

        '  tblTam = Me.b.LoadKhongThamso("SP_THONGKETCTHORAP_S")
        Me.dgrBC.DataSource = tblTam
        If Not tblTam Is Nothing Then
            ' sl cột động
            tblTempMucTien.Clear()
            tblTempMucTien = Me.b.LoadKhongThamso("SP_THONGKETCTHORAP_MUCTIENTHORAP_S")
            soluongcot_dong = tblTempMucTien.Rows.Count

            'Dim k As Integer
            'For k = 3 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            '    soluongcot_dong = soluongcot_dong + 1
            '    k = k + 1

            'Next

            Me.btnExcel.Enabled = True
            For Me.i = 0 To dgrBC.Rows.Count - 1
                If obj.Khu = "A" Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" Then
                        KhuA = KhuA + 1
                    End If
                    KhuB = 0
                    DVC = 0
                End If
                If obj.Khu = "B" Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" Then
                        KhuB = KhuB + 1
                    End If
                    KhuA = 0
                    DVC = 0
                End If
                If obj.Khu = "DVC" Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC 區" Then
                        DVC = DVC + 1
                    End If
                    KhuA = 0
                    KhuB = 0
                End If
                If obj.Khu = "TCT" Then
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
                'If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" Then
                '    KhuA = KhuA + 1
                'End If
                'If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" Then

                '    KhuB = KhuB + 1

                'End If
            Next

        End If
        'Else
        'MessageBox.Show("Không thể thống kê được do không có mức trợ cấp thợ rập nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmThongKeTroCapThoRap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnExcel.Enabled = False
        Me.radKhuA.Checked = True
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        If Me.radKhuA.Checked Then
            'khu = "KHUA"
            Me.btnExcel.Enabled = False
        End If
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        If Me.radKhuB.Checked Then
            ' khu = "KHUB"
            Me.btnExcel.Enabled = False
        End If
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        If Me.radTCT.Checked Then
            ' khu = "TCT"
            Me.btnExcel.Enabled = False
        End If
    End Sub
    Private Sub XuatExcel_TrocapThoRap_gam()
        'đặt giá trị độ rộng lưới phù hợp để xuất excel
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Me.dgrBC.DisplayLayout.Bands(0).Columns("STT").Width = 100
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Width = 175
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Width = 175
        Me.dgrBC.DisplayLayout.Bands(0).Columns("XUONGTENHOA").Width = 175
        Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCONG").Width = 175
        For j As Integer = 1 To soluongcot_dong
            Me.dgrBC.DisplayLayout.Bands(0).Columns("" & tblTempMucTien.Rows(j - 1).Item(0).ToString() & "").Width = 75
        Next
        '==============================================
        ngay = Me.dtpThang.Text
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "THỐNG KÊ PHỤ CẤP THỢ RẬP " & tieudeviet & " THÁNG " & ngay & " " & Chr(10) & "" & ngay & "月份全廠版師津貼" & tieudehoa & "計"
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TKTR")
                Dim sheet As Worksheet = myWorkbook.Worksheets("TKTR")
                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                'Tiêu đề công ty 
                myWorksheet.Rows(0).Cells(1).Value = "CÔNG TY TNHH TỶ XUÂN"
                myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Left
                sheet.MergedCellsRegions.Add(0, 1, 0, 5)
                myWorksheet.Rows(1).Cells(1).Value = "VINH LONG FOOTWEAR CO., LTD"
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Left
                sheet.MergedCellsRegions.Add(1, 1, 1, 6)
                'chuỗi tiêu đề
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(2).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 300
                myWorksheet.Rows(2).Height = 800
                For Me.i = 1 To soluongcot_dong + 4
                    myWorksheet.Rows(2).Cells(i).Value = sChuoiTieuDe
                Next
                sheet.MergedCellsRegions.Add(2, 1, 2, 3 + soluongcot_dong + 1)
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(2).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 5, 1)
                '3 cột đầu cố định
                myWorksheet.Rows(3).Cells(1).Value = "STT" & Chr(10) & "序號"
                sheet.MergedCellsRegions.Add(3, 1, 5, 1)
                myWorksheet.Rows(3).Cells(2).Value = "Xưởng" & Chr(10) & "序號"
                sheet.MergedCellsRegions.Add(3, 2, 5, 2)
                myWorksheet.Rows(3).Cells(3).Value = "Đơn vị" & Chr(10) & "單位"
                sheet.MergedCellsRegions.Add(3, 3, 5, 3)
                For Me.i = 1 To soluongcot_codinh
                    myWorksheet.Rows(3).Cells(i).CellFormat.Font.Name = "Arial"
                    myWorksheet.Rows(3).Cells(i).CellFormat.Alignment = HorizontalCellAlignment.Center
                    myWorksheet.Rows(3).Cells(i).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                    myWorksheet.Rows(3).Cells(i).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                Next
                'ô phụ cấp
                For Me.i = 4 To soluongcot_dong + 4
                    myWorksheet.Rows(3).Cells(i).Value = "SỐ TIỀN PHỤ CẤP 津貼金額"

                Next
                sheet.MergedCellsRegions.Add(3, 4, 4, soluongcot_dong + 4)
                myWorksheet.Rows(3).Cells(4).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(3).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(3).Cells(4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                myWorksheet.Rows(3).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

                'cột động
                For j As Integer = 1 To soluongcot_dong
                    myWorksheet.Rows(5).Cells(4 + j - 1).Value = tblTempMucTien.Rows(j - 1).Item(0).ToString()
                    sheet.MergedCellsRegions.Add(5, 4 + j - 1, 5, 4 + j - 1)
                    myWorksheet.Rows(5).Cells(4 + j - 1).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                Next
                'cột tổng cộng
                myWorksheet.Rows(5).Cells(3 + soluongcot_dong + 1).Value = "Tổng Cộng " & Chr(10) & "合計"
                sheet.MergedCellsRegions.Add(5, 3 + soluongcot_dong + 1, 5, 3 + soluongcot_dong + 1)
                myWorksheet.Rows(5).Cells(3 + soluongcot_dong + 1).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                'merge khu A

                ' sheet.MergedCellsRegions.Add(6, 2, 6 + (KhuA - 1), 2)
                'merge khu B
                'sheet.MergedCellsRegions.Add(6 + KhuA, 2, 6 + KhuA + (KhuB - 1), 2)
                'merge tổng cộng
                ' myWorksheet.Rows(6 + KhuA + (KhuB - 1) + 2).Cells(1).Value = "TC 合計: "
                ' sheet.MergedCellsRegions.Add(6 + KhuA + (KhuB - 1) + 2, 1, 6 + KhuA + (KhuB - 1) + 2, 3)

                For Me.i = 3 To 6 + KhuA + (KhuB - 1)  ' For Me.i = 3 To 6 + KhuA + (KhuB - 1) + 2
                    For Me.j = 1 To 3 + soluongcot_dong + 1
                        myWorksheet.Rows(i).Cells(j).CellFormat.LeftBorderColor = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.RightBorderColor = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.TopBorderColor = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.BottomBorderColor = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    Next
                Next
                'Cuối trang 
                myWorksheet.Rows(KhuA + (KhuB - 1) + 11).Cells(soluongcot_dong + 4).Value = "LẬP BIỂU:" & Chr(10) & "製表"
                myWorksheet.Rows(KhuA + (KhuB - 1) + 11).Cells(soluongcot_dong + 4).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(KhuA + (KhuB - 1) + 11).Cells(soluongcot_dong + 4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center


                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class