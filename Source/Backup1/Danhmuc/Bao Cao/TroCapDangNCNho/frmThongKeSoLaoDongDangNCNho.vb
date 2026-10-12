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
Imports EO.Internal
Imports EO.Internal.a29

Public Class frmThongKeSoLaoDongDangNCNho
    Public sThangHT_VN, sThangTruoc_VN, sThangHT_TW, sThangTruoc_TW As String
    Public Ngaydauthanght, Ngaydauthangtruoc, Ngaycuoithangtruoc, sNgay, sThang, sNam As String
    Public iSoluongCot As Integer = 9
    Public iDongTCT As Integer = 0
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        If radTCT.Checked = True And cbkChitiet.Checked = True Then
            Me.XpCaption2.Text = "Danh sách chi tiết trợ cấp con dưới 6 tuổi theo tháng"
            methodLoad_ThongKeSoLaoDongDangNCNho_Chitiet()
            Try
                LoadGridView_Chitiet()
            Catch ex As Exception

            End Try
        Else
            methodLoad_ThongKeSoLaoDongDangNCNho()
            LoadGridView()
        End If

    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate

        If radTCT.Checked = True And cbkChitiet.Checked = True Then
            XuatExcel_ThongKeSoLaoDongDangNCNho_Chitiet()
        Else
            XuatExcel_ThongKeSoLaoDongDangNCNho()
        End If
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

    Private Sub XuatExcel_ThongKeSoLaoDongDangNCNho_Chitiet()
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "DANH SÁCH CÔNG NHÂN VIÊN NHẬN TRỢ CẤP NUÔI CON DƯỚI 6 TUỔI THÁNG " & Month(dtpThang.Value).ToString() & " NĂM " & Year(dtpThang.Value).ToString()
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TRỢ CẤP CON 6T")
                Dim sheet As Worksheet = myWorkbook.Worksheets("TRỢ CẤP CON 6T")

                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''
                Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.VisiblePosition = 0
                Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.VisiblePosition = 1
                Me.dgrBC.DisplayLayout.Bands(0).Columns("DV_MA").Header.VisiblePosition = 2
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NV_MA").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NV_TEN").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAYSANHCON").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("NGAYHETHAN").Header.VisiblePosition = 6
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TUOI").Header.VisiblePosition = 7
                Me.dgrBC.DisplayLayout.Bands(0).Columns("THANGTUOI").Header.VisiblePosition = 8
                Me.dgrBC.DisplayLayout.Bands(0).Columns("DENGHITHANGTRUOC").Header.VisiblePosition = 9
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TANGTHEM").Header.VisiblePosition = 10

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
                Dim j As Integer
                For j = 1 To 11
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
                sheet.MergedCellsRegions.Add(1, 1, 1, 11)

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub XuatExcel_ThongKeSoLaoDongDangNCNho()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TKNCD6T")
                Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TKNCD6T")
                ''======== tiêu đề và Header ============''
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(1).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 250
                myWorksheet.Rows(1).Height = 980
                If Me.radTCT.Checked Then
                    myWorksheet.Rows(1).Cells(1).Value = "BẢNG THỐNG KÊ ĐIỀU CHỈNH HƯỞNG CHẾ ĐỘ NGƯỜI LAO ĐỘNG " & Chr(10) & "ĐANG NUÔI CON NHỎ  DƯỚI  6 TUỔI" & Chr(10) & " 享有養育未滿6歲小孩補助人數匯總表"
                End If

                If Me.radKhuA.Checked Then
                    myWorksheet.Rows(1).Cells(1).Value = "BẢNG THỐNG KÊ ĐIỀU CHỈNH HƯỞNG CHẾ ĐỘ NGƯỜI LAO ĐỘNG " & Chr(10) & "ĐANG NUÔI CON NHỎ  DƯỚI  6 TUỔI KHU A" & Chr(10) & " 享有養育未滿6歲小孩補助人數匯總表"
                End If

                If Me.radKhuB.Checked Then
                    myWorksheet.Rows(1).Cells(1).Value = "BẢNG THỐNG KÊ ĐIỀU CHỈNH HƯỞNG CHẾ ĐỘ NGƯỜI LAO ĐỘNG " & Chr(10) & "ĐANG NUÔI CON NHỎ  DƯỚI  6 TUỔI KHU B" & Chr(10) & " 享有養育未滿6歲小孩補助人數匯總表"
                End If

                If Me.radKhuDVC.Checked Then
                    myWorksheet.Rows(1).Cells(1).Value = "BẢNG THỐNG KÊ ĐIỀU CHỈNH HƯỞNG CHẾ ĐỘ NGƯỜI LAO ĐỘNG " & Chr(10) & "ĐANG NUÔI CON NHỎ  DƯỚI  6 TUỔI KHU DVC" & Chr(10) & " 享有養育未滿6歲小孩補助人數匯總表"
                End If
                sheet.MergedCellsRegions.Add(1, 1, 1, iSoluongCot)

                myWorksheet.Rows(2).Cells(2).Value = "Áp dụng từ Ngày " & sNgay & " Tháng " & sThang & " Năm " & sNam & Chr(10) & " 從 " & sNam & " 年 " & sThang & " 月 " & sNgay & " 日 " & "適用"
                myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Left
                myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
                myWorksheet.Rows(2).Height = 500

                sheet.MergedCellsRegions.Add(2, 2, 2, iSoluongCot)

                If Me.radTCT.Checked Then
                    For dong As Integer = 0 To dgrBC.Rows.Count - 1
                        If dgrBC.Rows(dong).Cells("XUONGTENHOA").Value = "全廠合計 TC" Then
                            dgrBC.Rows(dong).Cells("XUONGTENHOA").Value = Nothing
                            iDongTCT = dgrBC.Rows(dong).Index
                        End If
                    Next
                    sheet.MergedCellsRegions.Add(iDongTCT + 4, 1, iDongTCT + 4, 2)
                End If


                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)

                If Me.radTCT.Checked Then
                    myWorksheet.Rows(iDongTCT + 4).Cells(1).Value = "全廠合計 TC"
                    myWorksheet.Rows(iDongTCT + 4).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                End If
                'myWorksheet.Rows(iDongTCT + 4).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                'myWorksheet.Rows(iDongTCT + 4).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                'myWorksheet.Rows(iDongTCT + 4).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center

                If Me.radTCT.Checked Then
                    For dongexcel As Integer = 4 To iDongTCT + 4
                        For cotso As Integer = 7 To 8
                            myWorksheet.Rows(dongexcel).Cells(cotso).CellFormat.FormatString = "#,##0_);(#,##0)"
                        Next
                        myWorksheet.Rows(dongexcel).Cells(9).CellFormat.FormatString = "$#,##0_);($#,##0)"
                    Next

                    For k As Integer = 1 To 9
                        For dong As Integer = 4 To iDongTCT + 4
                            myWorksheet.Rows(dong).Cells(k).CellFormat.WrapText = ExcelDefaultableBoolean.True
                            myWorksheet.Rows(dong).Cells(k).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                            myWorksheet.Rows(dong).Cells(k).CellFormat.Font.Name = "Arial"
                            myWorksheet.Rows(dong).Cells(k).CellFormat.Font.Height = 200
                            myWorksheet.Rows(dong).Height = 300
                        Next
                    Next
                Else
                    For dongexcel As Integer = 4 To dgrBC.Rows.Count + 4
                        For cotso As Integer = 7 To 8
                            ' myWorksheet.Rows(dongexcel).Cells(cotso).CellFormat.FormatString = "#,##0_);(#,##0)"
                        Next
                        '  myWorksheet.Rows(dongexcel).Cells(9).CellFormat.FormatString = "$#,##0_);($#,##0)"
                    Next

                    For k As Integer = 1 To 9
                        For dong As Integer = 4 To dgrBC.Rows.Count + 4
                            myWorksheet.Rows(dong).Cells(k).CellFormat.WrapText = ExcelDefaultableBoolean.True
                            myWorksheet.Rows(dong).Cells(k).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                            myWorksheet.Rows(dong).Cells(k).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                            myWorksheet.Rows(dong).Cells(k).CellFormat.Font.Name = "Arial"
                            myWorksheet.Rows(dong).Cells(k).CellFormat.Font.Height = 200
                            myWorksheet.Rows(dong).Height = 300
                        Next
                    Next
                End If
                'If Me.radTCT.Checked Then

                'End If




                ''======== Footer ============''
                Dim footer As Integer

                If Me.radTCT.Checked Then
                    footer = iDongTCT + 5
                Else
                    footer = Me.dgrBC.Rows.Count + 5
                End If



                myWorksheet.Rows(footer).Cells(6).Value = "Tỷ Bách, ngày " & sNgay & " tháng " & sThang & " năm " & sNam
                myWorksheet.Rows(footer).Cells(6).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(footer).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(footer).Cells(6).CellFormat.Font.Height = 200
                myWorksheet.Rows(footer).Height = 400
                sheet.MergedCellsRegions.Add(footer, 6, footer, 9)

                myWorksheet.Rows(footer + 1).Cells(6).Value = "Lập Biểu 制表:"
                myWorksheet.Rows(footer + 1).Cells(6).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(footer + 1).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
                sheet.MergedCellsRegions.Add(footer + 1, 6, footer + 1, 9)


                myWorksheet.Rows(footer + 1).Cells(4).Value = "NNL"
                myWorksheet.Rows(footer + 1).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(footer + 1).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
                sheet.MergedCellsRegions.Add(footer + 1, 4, footer + 1, 5)


                myWorksheet.Rows(footer + 1).Cells(1).Value = "Duyệt"
                myWorksheet.Rows(footer + 1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(footer + 1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
                sheet.MergedCellsRegions.Add(footer + 1, 1, footer + 1, 3)

                myWorksheet.Rows(footer + 2).Cells(4).Value = "人資:"
                myWorksheet.Rows(footer + 2).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(footer + 2).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                sheet.MergedCellsRegions.Add(footer + 2, 4, footer + 2, 5)

                myWorksheet.Rows(footer + 2).Cells(1).Value = "審核"
                myWorksheet.Rows(footer + 2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(footer + 2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                sheet.MergedCellsRegions.Add(footer + 2, 1, footer + 2, 3)

                myWorksheet.Rows(footer + 3).Cells(6).Value = ""
                myWorksheet.Rows(footer + 3).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(footer + 3).Cells(6).CellFormat.Font.Italic = ExcelDefaultableBoolean.True
                sheet.MergedCellsRegions.Add(footer + 3, 6, footer + 3, 9)

                For i As Integer = footer To footer + 3
                    For cot As Integer = 1 To 9
                        myWorksheet.Rows(i).Cells(cot).CellFormat.Font.Name = "Times New Roman"
                        myWorksheet.Rows(i).Cells(cot).CellFormat.Font.Height = 200
                        myWorksheet.Rows(i).Height = 310
                        myWorksheet.Rows(3).Cells(cot).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                        myWorksheet.Rows(3).Cells(cot).CellFormat.Font.Height = 200
                        myWorksheet.Rows(3).Height = 500
                    Next

                Next
                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Lỗi.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub methodLoad_ThongKeSoLaoDongDangNCNho_Chitiet()
        Dim THANG As Integer
        THANG = Convert.ToInt32(CDate(Me.dtpThang.Value).Month)
        Dim NAM As Integer
        NAM = Convert.ToInt32(CDate(Me.dtpThang.Value).Year)
        Dim listpar As New ArrayList(2)
        Dim tblTemp As DataTable
        listpar.Clear()
        listpar.Add(New SqlParameter("@THANG", THANG))
        listpar.Add(New SqlParameter("@NAM", NAM))

        If Me.radTCT.Checked Then
            tblTemp = Me.b.Load("SP_THONGKEDANHSACHCHITIET_TROCAPNUOICONDUOI6T", listpar)
        End If
        listpar.Clear()
        If tblTemp Is Nothing OrElse tblTemp.Rows.Count <= 0 Then
            MessageBox.Show("Không có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.dgrBC.DataSource = tblTemp
            Me.btnExcel.Enabled = True
        End If
    End Sub
    Private Sub methodLoad_ThongKeSoLaoDongDangNCNho()
        Dim obj As New objThongKeSoLaoDongDangNCNho
        Dim listpar As New ArrayList(3)
        Dim listpar1 As New ArrayList(1)
        Dim tblTam, tblNgaydiemdanh As DataTable
        'Dim Ngaydauht, Ngaydautruoc, Ngaycuoitruoc As Date

        Me.dtpThang.CustomFormat = "dd/MM/yyyy"

        Ngaydauthanght = CDate(Me.dtpThang.Value).Year.ToString() + "/" + CDate(Me.dtpThang.Value).Month.ToString() + "/01"
        Ngaydauthangtruoc = CDate(Ngaydauthanght).AddMonths(-1)
        Ngaycuoithangtruoc = CDate(Ngaydauthangtruoc).AddMonths(1).AddDays(-1)

        'Ngaydauthanght = "'" + Ngaydauht.Year.ToString + "/" + Ngaydauht.Month.ToString + "/01" + "'"
        'Ngaydauthangtruoc = "'" + Ngaydautruoc.ToString + "'"
        'Ngaycuoithangtruoc = "'" + Ngaycuoitruoc.ToString + "'"

        obj.Ngay = Me.dtpThang.Text.Substring(0, 2)
        obj.Thang = Me.dtpThang.Text.Substring(3, 2)
        obj.Nam = Me.dtpThang.Text.Substring(6, 4)

        sNgay = obj.Ngay
        sThang = obj.Thang
        sNam = obj.Nam

        sThangHT_VN = obj.Thang + "/" + obj.Nam
        sThangHT_TW = obj.Nam + "/" + obj.Thang

        sThangTruoc_VN = Ngaydauthangtruoc.Substring(3, 2) + "/" + Ngaydauthangtruoc.Substring(6, 4)

        sThangTruoc_TW = Ngaydauthangtruoc.Substring(6, 4) + "/" + Ngaydauthangtruoc.Substring(3, 2)

        obj.T_Ma = obj.Thang + "-" + obj.Nam
        obj.T_Ma_Truoc = sThangTruoc_VN


        obj.NgayDD = CDate(Me.dtpNgayDD.Value).Year.ToString() + "/" + CDate(dtpNgayDD.Value).Month.ToString() + "/" + CDate(dtpNgayDD.Value).Day.ToString()

        listpar1.Clear()
        listpar1.Add(New SqlParameter("@NGAY", obj.NgayDD))
        tblNgaydiemdanh = Me.b.Load("SP_NGAYDIEMDANH_S", listpar1)
        If tblNgaydiemdanh Is Nothing Then
            MessageBox.Show("Ngày bạn vừa chọn chưa có dử liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpThang.CustomFormat = "MM/yyyy"
            Exit Sub
        ElseIf tblNgaydiemdanh.Rows.Count <= 0 Then
            MessageBox.Show("Ngày bạn vừa chọn chưa có dử liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpThang.CustomFormat = "MM/yyyy"
            Exit Sub
        End If

        If CDbl(ucUSD.Value) = 0.0 Then
            MessageBox.Show("Vui lòng nhập số tiền USD > 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpThang.CustomFormat = "MM/yyyy"
            Exit Sub
        End If

        obj.Doi1USD = Me.ucUSD.Value
        Dim TinhTAM As Integer = 0
        If Me.chkTinhTAM.Checked Then
            TinhTAM = 1
        Else
            TinhTAM = 0
        End If

        listpar.Clear()
        listpar.Add(New SqlParameter("@T_MA", obj.T_Ma))
        listpar.Add(New SqlParameter("@NGAYDIEMDD", obj.NgayDD))
        listpar.Add(New SqlParameter("@QUYDOI1USD", obj.Doi1USD))
        listpar.Add(New SqlParameter("@TinhTAM", TinhTAM))
        If Me.radTCT.Checked Then
            tblTam = Me.b.Load("SP_THONGKETCNUOICONDUOI6TUOI_S", listpar)
        End If
        If Me.radKhuA.Checked Then
            tblTam = Me.b.Load("SP_THONGKETCNUOICONDUOI6TUOI_KHUA_S", listpar)
        End If
        If Me.radKhuB.Checked Then
            tblTam = Me.b.Load("SP_THONGKETCNUOICONDUOI6TUOI_KHUB_S", listpar)
        End If
        If Me.radKhuDVC.Checked Then
            tblTam = Me.b.Load("SP_THONGKETCNUOICONDUOI6TUOI_KHUDVC_S", listpar)
        End If

        listpar.Clear()
        If tblTam.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTam
            Me.btnExcel.Enabled = True
        End If
        Me.dtpThang.CustomFormat = "MM/yyyy"

    End Sub
    Dim b As New clsBThongKeSoLaoDongDangNCNho

    Private Sub DinhDangChung(ByVal iCot As Integer)
        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With Me.dgrBC.DisplayLayout.Bands(0)
            .ClearGroupByColumns()
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Transparent
            Dim i As Integer
            For i = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                .Columns(i).Header.Appearance.FontData.Bold = DefaultableBoolean.True
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
        band.ColHeaderLines = iCot

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
        'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(iCot)
        'band.Layout.Bands(0).Summaries.Clear()
        'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        'summary.Appearance.TextHAlign = HAlign.Right
        'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        'band.SummaryFooterCaption = "Tổng số: "
        'band = Nothing
    End Sub
    Private Sub LoadGridView_Chitiet()
        DinhDangChung(4)
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("KHU").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("KHU").Header.Caption = "KHU"
            .Columns("X_MA_").Header.Caption = "NHÀ XƯỞNG"
            .Columns("DV_MA").Header.Caption = "ĐƠN VỊ"
            .Columns("DV_MA").Width = 150
            .Columns("NV_MA").Header.Caption = "SỐ THẺ"
            .Columns("NV_TEN").Header.Caption = "HỌ TÊN NHÂN VIÊN"
            .Columns("NV_TEN").Width = 250
            .Columns("NV_TEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("NGAYSANHCON").Header.Caption = "NGÀY SINH CON"

            .Columns("NGAYHETHAN").Header.Caption = "NGÀY HẾT HẠN"
            .Columns("TUOI").Header.Caption = "TUỔI CON"
            .Columns("THANGTUOI").Header.Caption = "THÁNG TUỔI"

            .Columns("DENGHITHANGTRUOC").Header.Caption = "ĐỀ NGHỊ THÁNG TRƯỚC"
            .Columns("DENGHITHANGTRUOC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("TANGTHEM").Header.Caption = "TĂNG THÊM THÁNG NÀY"
            .Columns("TANGTHEM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns("SANHDOI").Header.Caption = "SANH ĐÔI"
            .Columns("SANHDOI").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            '.Columns("KHU").Hidden = True
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("X_MA_").MergedCellStyle = MergedCellStyle.Always
            .Columns("X_MA_").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
            .Columns("DV_MA").MergedCellStyle = MergedCellStyle.Always
            .Columns("DV_MA").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        End With
    End Sub
    Private Sub LoadGridView()
        Try
            dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            Me.dgrBC.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            With Me.dgrBC.DisplayLayout.Bands(0)

                .ClearGroupByColumns()
                dgrBC.DisplayLayout.Bands(0).Columns.ClearUnbound()
                dgrBC.DisplayLayout.Bands(0).SortedColumns.Clear()
                Me.dgrBC.DisplayLayout.CaptionAppearance.BackColor = Color.Black
                Me.dgrBC.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

                For j As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(j).Header.Appearance.FontData.Bold = DefaultableBoolean.True
                Next

                .Columns("STT").Hidden = True

                .Columns("X_MA_").Header.Caption = "Mã xưởng" & Chr(10) & "廠別"
                .Columns("X_MA_").Width = 100

                .Columns("KHU").Header.Caption = "Xưởng" & Chr(10) & "廠別"
                .Columns("KHU").Width = 100
                .Columns("XUONGTENHOA").Header.Caption = "Đơn vị" & Chr(10) & "單位"
                .Columns("XUONGTENHOA").Width = 110


                .Columns("TSTT").Header.Caption = "Tổng số lao động" & Chr(10) & "thực tế" & Chr(10) & "單位實際總人數"
                .Columns("TSTT").Width = 200

                .Columns("TSDN").Header.Caption = "Số người đề nghị" & Chr(10) & " đến tháng " & sThangTruoc_VN & Chr(10) & sThangTruoc_TW & " 單位實際總人數"
                .Columns("TSDN").Width = 200

                .Columns("TSTS").Header.Caption = "Tăng thêm trong" & Chr(10) & " tháng " & sThangHT_VN & Chr(10) & sThangHT_TW & " 月新增"
                .Columns("TSTS").Width = 200

                .Columns("TONGCONG").Header.Caption = "Tổng số người" & Chr(10) & " hưởng trợ cấp" & Chr(10) & " 享有 補助人數"
                .Columns("TONGCONG").Width = 200

                .Columns("SOTIEN").Header.Caption = "Số tiền trợ cấp" & Chr(10) & " 補助金額(每人)"
                .Columns("SOTIEN").Width = 200


                .Columns("SOTIENVN").Header.Caption = "VND" & Chr(10) & " 越幣"
                .Columns("SOTIENVN").Width = 200

                .Columns("SOTIENUSD").Header.Caption = "USD" & Chr(10) & " 美金"
                .Columns("SOTIENUSD").Width = 200

                .Columns("KHU").Header.VisiblePosition = 0
                .Columns("X_MA_").Header.VisiblePosition = 1
                .Columns("XUONGTENHOA").Header.VisiblePosition = 2
                .Columns("TSTT").Header.VisiblePosition = 3
                .Columns("X_MA_").Hidden = True

                For i As Integer = 0 To Me.dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                    .Columns(i).CellActivation = Activation.NoEdit
                    .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Next
                .Columns("XUONGTENHOA").CellAppearance.TextHAlign = HAlign.Left
                .Columns("KHU").CellAppearance.TextHAlign = HAlign.Left

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
                band.ColHeaderLines = 4

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
                For dong As Integer = 0 To dgrBC.Rows.Count - 1
                    Select Case Me.dgrBC.Rows(dong).Cells("X_MA_").Value.ToString()
                        Case "TONGKHUA", "TONGKHUB", "TONGKHUDVC"
                            For cot As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                Me.dgrBC.Rows(dong).Cells(cot).Appearance.ForeColor = Color.Red
                            Next
                            Me.dgrBC.Rows(dong).Cells("KHU").Appearance.ForeColor = Color.Black
                        Case "TCT"
                            For cot As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                Me.dgrBC.Rows(dong).Cells(cot).Appearance.FontData.Bold = DefaultableBoolean.True
                            Next
                            Me.dgrBC.Rows(dong).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.False
                        Case Else
                            For cot As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
                                If dgrBC.DisplayLayout.Bands(0).Columns(cot).Key = "SOTIENVN" Or dgrBC.DisplayLayout.Bands(0).Columns(cot).Key = "SOTIEN" Then
                                    dgrBC.DisplayLayout.Bands(0).Columns(cot).Style = UltraWinGrid.ColumnStyle.CurrencyPositive
                                    dgrBC.DisplayLayout.Bands(0).Columns(cot).Format = "#,##0"
                                End If
                            Next

                    End Select
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmThongKeSoLaoDongDangNCNho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        Me.btnExcel.Enabled = False
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        Me.btnExcel.Enabled = False
    End Sub
End Class