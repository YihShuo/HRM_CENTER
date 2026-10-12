Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports Infragistics.Excel
Imports System.IO
Imports Infragistics.Win.UltraWinGrid
Public Class frmThongKeCN_TT_GT
    Dim thang As String
    Public ngay As Date
    Dim listpar As New ArrayList(1)
    Dim listpar1 As New ArrayList(2)
    Dim listpar2 As New ArrayList(4)
    Public para As Object()
    Public issysReport As Boolean
    Friend WithEvents b As clsBThongKeCN_TT_GT
    Public ngayselectdauthang, ngayselectcuoithang, reportID As String
    Public tblThongKeXuong, tblTableExcelMerge As New DataTable()
    Public bChuaCoDuLieu As Boolean = False
    Private Sub LayNgayCuoiThang()
        Dim tblTemp As DataTable
        Dim obj As New objThongKeCN_TT_GT
        Me.b = New clsBThongKeCN_TT_GT
        listpar.Clear()
        obj.ThangNam = Me.dtpThang.Text

        listpar.Add(New SqlParameter("@T_MA", obj.ThangNam))
        tblTemp = Me.b.GoiThuTuc("SP_LAYNGAYCUOITHANG_DDHN_S", listpar)
        listpar.Clear()
        If tblTemp Is Nothing Or tblTemp.Rows(0).Item("NGAYCUOICUNG").ToString() = "" Then
            ngayselectcuoithang = Now().Date.Year.ToString() + "-" + Now().Month.ToString() + "-" + Now().Day.ToString()
            bChuaCoDuLieu = True
        Else
            ngay = tblTemp.Rows(0).Item("NGAYCUOICUNG")
            ngayselectcuoithang = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
            bChuaCoDuLieu = False
        End If
    End Sub
    Private Sub LayNgayDauThang()
        Dim tblTemp As DataTable
        Dim obj As New objThongKeCN_TT_GT
        Me.b = New clsBThongKeCN_TT_GT
        listpar.Clear()
        obj.ThangNam = Me.dtpThang.Text

        listpar.Add(New SqlParameter("@T_MA", obj.ThangNam))
        tblTemp = Me.b.GoiThuTuc("SP_LAYNGAYDAUTHANG_DDHN_S", listpar)
        listpar.Clear()
        If tblTemp Is Nothing Or tblTemp.Rows(0).Item("NGAYDAUTHANG").ToString() = "" Then
            ngayselectdauthang = Now().Date.Year.ToString() + "-" + Now().Month.ToString() + "-" + Now().Day.ToString()
            bChuaCoDuLieu = True
        Else
            ngay = tblTemp.Rows(0).Item("NGAYDAUTHANG")
            ngayselectdauthang = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
            bChuaCoDuLieu = False
        End If
    End Sub
    Private Sub frmThongKeCN_TT_GT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCombo()
        Me.cboDinhDangExcel.Visible = False
        ''=========mac dinh ngay cuoi thang
        Me.chkTinhdauthang.Enabled = True
        Me.chkTinhdauthang.Checked = False
        LayNgayCuoiThang()
    End Sub
    Private Sub HienThiReport()
        Dim document As ReportDocument
        Dim report As New ClsBReport
        Dim strArray As String()
        Dim khu As String
        Dim bTinhCNM As Boolean
        If Me.radKhuA.Checked Then
            khu = "A"
        End If
        If Me.radKhuB.Checked Then
            khu = "B"
        End If
        If Me.radTCT.Checked Then
            khu = "TCT"
        End If
        If Me.radDVC.Checked Then
            khu = "DVC"
        End If
        bTinhCNM = Me.chkTinhCNM.Checked

        If Me.chkTinhdauthang.Checked Then
            strArray = New String() {ngayselectdauthang, "'" + khu + "'", bTinhCNM}
        Else
            strArray = New String() {ngayselectcuoithang, "'" + khu + "'", bTinhCNM}

        End If

        Me.dgrBC.Visible = False
        Me.rptThongKeCN_TT_GT.Visible = True
        Me.rptThongKeCN_TT_GT.BringToFront()
        Select Case cboLoaiBaoCao.Value
            Case "DV"
                Me.reportID = "TKCNTTGTDV"
            Case "XUONG"
                Me.reportID = "TKCNTTGTX"
            Case "X_MAU"
                Me.reportID = "TT_GT_X"
            Case "CHITIET"
                Exit Sub
        End Select
        Try
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            ''======================
            document = report.InitReport(Me.reportID)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            Me.Close()
            ProjectData.ClearProjectError()
            Return
        End Try
        If Me.issysReport Then
            document = report.SetParameter(document, Me.para)
        End If
        Me.rptThongKeCN_TT_GT.ReportSource = document
    End Sub
    Private Sub LoadCombo()
        Me.cboLoaiBaoCao.Items.Add("DV", "Thống kê công nhân trực tiếp và gián tiếp theo đơn vị")
        Me.cboLoaiBaoCao.Items.Add("XUONG", "Thống kê công nhân trực tiếp và gián tiếp theo xưởng")
        Me.cboLoaiBaoCao.Items.Add("X_MAU", "Thống kê trực tiếp gián tiếp xưởng")
        Me.cboLoaiBaoCao.Items.Add("CHITIET", "Thống kê danh sách công nhân trực tiếp gián tiếp")
        Me.cboLoaiBaoCao.SelectedIndex = 0
    End Sub
    Private Sub cboLoaiBaoCao_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiBaoCao.ValueChanged
        Me.btnBaocao.Visible = True
        Select Case cboLoaiBaoCao.Value
            Case "DV"
                Me.reportID = "TKCNTTGTDV"
            Case "XUONG"
                Me.reportID = "TKCNTTGTX"
            Case "X_MAU"
                Me.reportID = "TT_GT_X"
            Case "CHITIET"
                Me.btnBaocao.Visible = False
        End Select
    End Sub
    Private Sub XuatExcelMau_XuongKHD()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            myWorksheet = myWorkbook.Worksheets.Add("TTGT_XUONGMAU")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TTGT_XUONGMAU")
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            If Me.radTCT.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "THỐNG KÊ CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            If Me.radKhuA.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "THỐNG KÊ CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP KHU A" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            If Me.radKhuB.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "THỐNG KÊ CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP KHU B" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            If Me.radDVC.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "THỐNG KÊ CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP KHU DVC" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If
            ''-------
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(1).Value = "STT 秩序"
            myWorksheet.Rows(1).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(1).Value = "STT 秩序"

            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(2).Value = "Xưởng 廠別"
            myWorksheet.Rows(1).Cells(2).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(2).Value = "Xưởng 廠別"


            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(3).Value = "Đơn vị 單位 "
            myWorksheet.Rows(1).Cells(3).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(3).Value = "Đơn vị 單位 "


            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(4).Value = "TRỰC TIẾP " & Chr(10) & " 直接人員"
            myWorksheet.Rows(2).Cells(4).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(5).Value = " GIÁN TIẾP " & Chr(10) & " 間接人員 "
            myWorksheet.Rows(2).Cells(5).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(6).Value = " "
            myWorksheet.Rows(2).Cells(6).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(7).Value = "CHƯA KÝ  " & Chr(10) & " HDLD " & Chr(10) & "未簽正式 CKHD 合同人數()"
            myWorksheet.Rows(2).Cells(7).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(8).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(8).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(8).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(8).Value = "GHI CHÚ " & Chr(10) & " 備註"
            myWorksheet.Rows(1).Cells(8).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(8).Value = ""



            sheet.MergedCellsRegions.Add(0, 1, 0, dgrBC.DisplayLayout.Bands(0).Columns.Count)
            sheet.MergedCellsRegions.Add(1, 1, 3, 1)
            sheet.MergedCellsRegions.Add(1, 2, 3, 2)
            sheet.MergedCellsRegions.Add(1, 3, 3, 3)

            sheet.MergedCellsRegions.Add(1, 4, 2, 4)
            sheet.MergedCellsRegions.Add(1, 5, 2, 6)

            sheet.MergedCellsRegions.Add(1, 7, 3, 7)

            sheet.MergedCellsRegions.Add(1, 8, 3, 8)
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub XuatExcelMau_XuongDonvi()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        Try
            myWorksheet = myWorkbook.Worksheets.Add("TTGT_XUONGDONVI")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TTGT_XUONGDONVI")
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            If Me.radTCT.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP TOÀN CÔNG TY"
            End If

            If Me.radKhuA.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU A"
            End If
            If Me.radKhuB.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU B"
            End If

            If Me.radDVC.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU DVC"
            End If

            ''-------
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(1).Value = "秩序 STT"
            myWorksheet.Rows(1).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(1).Value = "秩序 STT"

            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(2).Value = "區 Khu"
            myWorksheet.Rows(1).Cells(2).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(2).Value = "區 Khu"


            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(3).Value = "廠別 Xưởng"

            myWorksheet.Rows(1).Cells(3).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(3).Value = "廠別 Xưởng"


            myWorksheet.Rows(1).Cells(4).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(4).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(4).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(4).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(4).Value = "單位 Đơn vị"

            myWorksheet.Rows(1).Cells(4).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(4).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(4).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(4).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(4).Value = "單位 Đơn vị"


            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(5).Value = "直接人工 " & Chr(10) & " Công nhân trực tiếp"
            myWorksheet.Rows(2).Cells(5).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(5).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(6).Value = ""



            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(7).Value = "間接人工 " & Chr(10) & " Công nhân gián tiếp"
            myWorksheet.Rows(2).Cells(7).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(7).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(8).Value = ""


            myWorksheet.Rows(1).Cells(9).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(9).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(9).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(9).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(9).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(9).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(9).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(9).Value = "總人數" & Chr(10) & " Tổng số CN"
            myWorksheet.Rows(1).Cells(9).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(9).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(9).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(9).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(9).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(9).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(9).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(9).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(9).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(9).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(9).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(9).Value = ""


            sheet.MergedCellsRegions.Add(0, 1, 0, dgrBC.DisplayLayout.Bands(0).Columns.Count - 1)

            sheet.MergedCellsRegions.Add(1, 1, 3, 1)
            sheet.MergedCellsRegions.Add(1, 2, 3, 2)
            sheet.MergedCellsRegions.Add(1, 3, 3, 3)
            sheet.MergedCellsRegions.Add(1, 4, 3, 4)

            sheet.MergedCellsRegions.Add(1, 5, 2, 6)
            sheet.MergedCellsRegions.Add(1, 7, 2, 8)

            sheet.MergedCellsRegions.Add(1, 9, 3, 9)

            Dim i, vt As Integer
            Dim vtchuoi As String = ""
            Dim chuoigiatriMerge As String = ""
            For i = 0 To Me.cboDinhDangExcel.Items.Count - 1
                vt = Me.cboDinhDangExcel.Items(i).ToString().LastIndexOf("-")
                vtchuoi = Me.cboDinhDangExcel.Items(i).ToString().Substring(vt + 1, Me.cboDinhDangExcel.Items(i).ToString().Length - 1 - vt)
                chuoigiatriMerge = Me.cboDinhDangExcel.Items(i).ToString().Substring(0, vt)
                sheet.MergedCellsRegions.Add(CInt(vtchuoi) + 3, 3, CInt(vtchuoi) + 3, 4)

                If chuoigiatriMerge = "TONGKHUA" Or chuoigiatriMerge = "TONGKHUB" Then
                    sheet.Rows(CInt(vtchuoi) + 3).Cells(3).Value = "小計"
                    myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.Font.Color = Color.Red

                ElseIf chuoigiatriMerge = "TCT" Then
                    sheet.Rows(CInt(vtchuoi) + 3).Cells(3).Value = "Tổng cộng  合計"
                    myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.Font.Color = Color.Blue
                Else
                    sheet.Rows(CInt(vtchuoi) + 3).Cells(3).Value = chuoigiatriMerge
                    myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.Font.Color = Color.Red
                End If

                myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

                sheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                sheet.Rows(CInt(vtchuoi) + 3).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True

            Next
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Xuất excel bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub XuatExcelMau_Xuong()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            myWorksheet = myWorkbook.Worksheets.Add("TTGT_XUONG")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TTGT_XUONG")
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            If Me.radTCT.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP TOÀN CÔNG TY"
            End If

            If Me.radKhuA.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU A"
            End If

            If Me.radKhuB.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU B"
            End If

            If Me.radDVC.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "BẢNG THỐNG KÊ CÔNG NHÂN VIÊN THAM GIA CÔNG VIỆC " & Chr(10) & " TRỰC TIẾP-GIÁN TIẾP KHU DVC"
            End If

            ''-------
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(1).Value = "秩序 STT"
            myWorksheet.Rows(1).Cells(1).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(1).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(1).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(1).Value = "秩序 STT"

            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(2).Value = "廠別 Xưởng"
            myWorksheet.Rows(1).Cells(2).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(2).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin


            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(2).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(2).Value = "廠別 Xưởng"


            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(3).Value = "單位 Đơn vị"
            myWorksheet.Rows(1).Cells(3).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(3).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(3).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(3).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(3).Value = "單位 Đơn vị"



            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(4).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(4).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(4).Value = "直接人工 " & Chr(10) & " Công nhân trực tiếp"
            myWorksheet.Rows(2).Cells(4).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(4).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(5).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(5).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(5).Value = ""



            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(6).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(6).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(6).Value = "間接人工 " & Chr(10) & " Công nhân gián tiếp"
            myWorksheet.Rows(2).Cells(6).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(2).Cells(6).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(7).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(7).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(7).Value = ""


            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(8).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(1).Cells(8).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(1).Cells(8).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(1).Cells(8).CellFormat.Font.Height = 200
            myWorksheet.Rows(1).Height = 500
            myWorksheet.Rows(1).Cells(8).Value = "總人數" & Chr(10) & " Tổng số CN"
            myWorksheet.Rows(1).Cells(8).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
            myWorksheet.Rows(1).Cells(8).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin

            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(2).Cells(8).CellFormat.Alignment = HorizontalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            myWorksheet.Rows(2).Cells(8).CellFormat.Font.Height = 200
            myWorksheet.Rows(2).Height = 500
            myWorksheet.Rows(2).Cells(8).Value = ""





            sheet.MergedCellsRegions.Add(0, 1, 0, dgrBC.DisplayLayout.Bands(0).Columns.Count)
            sheet.MergedCellsRegions.Add(1, 1, 3, 1)
            sheet.MergedCellsRegions.Add(1, 2, 3, 2)
            sheet.MergedCellsRegions.Add(1, 3, 3, 3)

            sheet.MergedCellsRegions.Add(1, 4, 2, 5)
            sheet.MergedCellsRegions.Add(1, 6, 2, 7)

            sheet.MergedCellsRegions.Add(1, 8, 3, 8)


            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Xuất excel lỗi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Tablethongke As System.Data.DataTable
    Public grid As New clsTformatGrid
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
    Private Sub LoadDataGrid()
        Dim tblTongXuong As New DataTable()
        Dim tblXuong As New DataTable()
        Dim i As Integer = 0
        Dim obj As New objThongKeCN_TT_GT
        Me.b = New clsBThongKeCN_TT_GT
        Dim dgrBC As Object = Me.dgrBC
        Dim tblDMXuong_KhuA, tblDMXuong_KhuB, tblDMXuong_TCT, tblDMXuong_KhoiVP, tblDMXuong_DVC As DataTable
        clsTools.GridTheme1(Me.dgrBC)

        ''=========== TÁCH KHU A, KHU B =======''
        If Me.radKhuA.Checked Then
            obj.ChonKhu = "A"
        End If

        If Me.radKhuB.Checked Then
            obj.ChonKhu = "B"
        End If

        If Me.radTCT.Checked Then
            obj.ChonKhu = "TCT"
        End If

        If Me.radDVC.Checked Then
            obj.ChonKhu = "DVC"
        End If

        If Me.chkTinhCNM.Checked Then
            obj.TinhCNM = 1
        Else
            obj.TinhCNM = 0
        End If

        listpar.Clear()
        listpar1.Clear()
        tblThongKeXuong.Clear()
        tblTongXuong.Clear()
        tblXuong.Clear()

        If bChuaCoDuLieu Then
            'MessageBox.Show("Tháng này chưa có dữ liệu điểm danh,vui lòng lấy dử liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.tblThongKeXuong = New DataTable()
        tblThongKeXuong.Columns.Add("STT", GetType(Integer))
        tblThongKeXuong.Columns("STT").AutoIncrement = True
        tblThongKeXuong.Columns("STT").AutoIncrementSeed = 1

        Me.cboDinhDangExcel.Items.Clear()

        Select Case Me.cboLoaiBaoCao.Value
            Case "DV"
                Select Case obj.ChonKhu.ToUpper()
                    Case "A"
                        tblDMXuong_KhuA = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUA_TINHVP_S_NEW")
                        If tblDMXuong_KhuA.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_KhuA.Rows.Count - 1
                                If tblDMXuong_KhuA.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU A" Then
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuA.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "A"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If

                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)
                                    listpar1.Clear()
                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuA.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "A"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 1)) ''GÁN =1 ĐỂ CỘNG VP VÀO DÒNG TỔNG KHU A
                                listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                                listpar2.Clear()

                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else
                                    End If
                                End If

                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If

                    Case "B"
                        ''============load khu B
                        Select Case obj.TinhCNM
                            Case 0
                                tblDMXuong_KhuB = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUB_S_NEW")
                            Case 1
                                tblDMXuong_KhuB = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUB_TINHCNM_S_NEW")
                        End Select

                        If tblDMXuong_KhuB.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_KhuB.Rows.Count - 1
                                If tblDMXuong_KhuB.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU B" Then
                                    listpar1.Clear()
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuB.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "B"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If

                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)


                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                ''======== load cho dòng tổng: tổng từng xưởng hoặc tổng từng khu, dòng tổng toàn công ty
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuB.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "B"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 0))
                                listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))

                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)


                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else
                                    End If

                                End If

                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If

                    Case "DVC"
                        '==== Load DVC
                        tblDMXuong_DVC = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUDVC_S_NEW")
                        If tblDMXuong_DVC.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_DVC.Rows.Count - 1
                                listpar1.Clear()
                                If tblDMXuong_DVC.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU DVC" Then
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_DVC.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "DVC"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If
                                    listpar2.Add(New SqlParameter("@TINHVP", 0))
                                    listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)
                                    listpar1.Clear()

                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_DVC.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "DVC"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 1))
                                listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                                listpar2.Clear()
                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else

                                    End If
                                End If

                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If

                    Case "TCT"
                        ''========== toàn công ty 
                        tblDMXuong_KhuA = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUA_TINHVP_S_NEW")
                        If tblDMXuong_KhuA.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_KhuA.Rows.Count - 1
                                If tblDMXuong_KhuA.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU A" Then
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuA.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "A"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If

                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)
                                    listpar1.Clear()
                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuA.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "A"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 1))
                                listpar2.Add(New SqlParameter("@TINHCNM", 0))
                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                                listpar2.Clear()

                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else

                                    End If
                                End If
                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If

                        ''--------------- KHU Bs
                        Select Case obj.TinhCNM
                            Case 0
                                tblDMXuong_KhuB = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUB_S_NEW")
                            Case 1
                                tblDMXuong_KhuB = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUB_TINHCNM_S_NEW")
                        End Select


                        If tblDMXuong_KhuB.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_KhuB.Rows.Count - 1
                                If tblDMXuong_KhuB.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU B" Then
                                    listpar1.Clear()
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuB.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "B"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If

                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)


                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                ''======== load cho dòng tổng: tổng từng xưởng hoặc tổng từng khu, dòng tổng toàn công ty
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhuB.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "B"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 1))
                                listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))

                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)


                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else

                                    End If

                                End If

                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If


                        '============= load khối văn phòng ============''
                        'tblDMXuong_KhoiVP = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHOIVP_S")
                        'If tblDMXuong_KhoiVP.Rows.Count > 0 Then
                        '    For i = 0 To tblDMXuong_KhoiVP.Rows.Count - 1
                        '        listpar1.Clear()
                        '        If tblDMXuong_KhoiVP.Rows(i).Item("X_MA_").ToString() <> "TONGKHUB" Then
                        '            listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhoiVP.Rows(i).Item("X_MA_")))
                        '            'listpar1.Add(New SqlParameter("@KHU", tblDMXuong_KhoiVP.Rows(i).Item("KHU")))
                        '            If Me.chkTinhdauthang.Checked Then
                        '                listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                        '            Else
                        '                listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                        '            End If
                        '            listpar2.Add(New SqlParameter("@TINHVP", 0))
                        '            listpar2.Add(New SqlParameter("@TINHCNM", 0))
                        '            tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)
                        '            listpar1.Clear()

                        '            If tblXuong Is Nothing Then
                        '            ElseIf tblXuong.Rows.Count <= 0 Then
                        '            Else
                        '                tblThongKeXuong.Merge(tblXuong)
                        '            End If

                        '        End If
                        '        listpar2.Clear()
                        '        listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_KhoiVP.Rows(i).Item("X_MA_")))
                        '        listpar2.Add(New SqlParameter("@KHU", tblDMXuong_KhoiVP.Rows(i).Item("KHU")))
                        '        If Me.chkTinhdauthang.Checked Then
                        '            listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                        '        Else
                        '            listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                        '        End If
                        '        listpar2.Add(New SqlParameter("@TINHVP", 0))
                        '        listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        '        tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                        '        listpar2.Clear()
                        '        If tblTongXuong Is Nothing Then
                        '        ElseIf tblTongXuong.Rows.Count <= 0 Then
                        '        Else
                        '            If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                        '                tblThongKeXuong.Merge(tblTongXuong)
                        '            Else

                        '            End If
                        '        End If

                        '        tblXuong.Clear()
                        '        tblTongXuong.Clear()
                        '    Next
                        'End If

                        ''========= Load DVC
                        tblDMXuong_DVC = Me.b.GoiThuTucKhongThamSo("SP_DANHMUCXUONG_KHUDVC_S_NEW")
                        If tblDMXuong_DVC.Rows.Count > 0 Then
                            For i = 0 To tblDMXuong_DVC.Rows.Count - 1
                                listpar1.Clear()
                                If tblDMXuong_DVC.Rows(i).Item("X_MA_").ToString() <> "TỔNG KHU DVC" Then
                                    listpar1.Add(New SqlParameter("@MAXUONG", tblDMXuong_DVC.Rows(i).Item("X_MA_")))
                                    listpar1.Add(New SqlParameter("@KHU", "DVC"))
                                    If Me.chkTinhdauthang.Checked Then
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                    Else
                                        listpar1.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                    End If
                                    listpar2.Add(New SqlParameter("@TINHVP", 1))
                                    listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                                    tblXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TUNGXUONG_S_TEST", listpar1)
                                    listpar1.Clear()

                                    If tblXuong Is Nothing Then
                                    ElseIf tblXuong.Rows.Count <= 0 Then
                                    Else
                                        tblThongKeXuong.Merge(tblXuong)
                                    End If

                                End If
                                listpar2.Clear()
                                listpar2.Add(New SqlParameter("@MAXUONG", tblDMXuong_DVC.Rows(i).Item("X_MA_")))
                                listpar2.Add(New SqlParameter("@KHU", "DVC"))
                                If Me.chkTinhdauthang.Checked Then
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                                Else
                                    listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                                End If
                                listpar2.Add(New SqlParameter("@TINHVP", 1))
                                listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                                tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                                listpar2.Clear()
                                If tblTongXuong Is Nothing Then
                                ElseIf tblTongXuong.Rows.Count <= 0 Then
                                Else
                                    If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                        tblThongKeXuong.Merge(tblTongXuong)
                                    Else

                                    End If
                                End If

                                tblXuong.Clear()
                                tblTongXuong.Clear()
                            Next
                        End If

                        ''============load TCT
                        listpar2.Add(New SqlParameter("@MAXUONG", "TCT"))
                        listpar2.Add(New SqlParameter("@KHU", "TCT"))

                        If Me.chkTinhdauthang.Checked Then
                            listpar2.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                        Else
                            listpar2.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                        End If
                        listpar2.Add(New SqlParameter("@TINHVP", 0))
                        listpar2.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        tblTongXuong = Me.b.GoiThuTuc("SP_TKTTGT_XUONGDONVI_TONGXUONG_KHU_S_DEMO", listpar2)
                        listpar2.Clear()

                        If tblTongXuong Is Nothing Then
                        ElseIf tblTongXuong.Rows.Count <= 0 Then
                        Else
                            If CInt(tblTongXuong.Rows(0).Item("TONGCN")) > 0 Then
                                tblThongKeXuong.Merge(tblTongXuong)
                            Else

                            End If
                        End If

                        tblXuong.Clear()
                        tblTongXuong.Clear()

                    Case Else

                End Select

                ''============= nạp lên lưới ================
                Me.dgrBC.DataSource = tblThongKeXuong

                For i = 0 To dgrBC.Rows.Count - 1
                    If IsDBNull(Me.dgrBC.Rows(i).Cells("LOAI").Value) Then
                    ElseIf Me.dgrBC.Rows(i).Cells("LOAI").Value = "TONGXUONG" Then
                        Me.cboDinhDangExcel.Items.Add(Me.dgrBC.Rows(i).Cells("X_MA_").Value.ToString() + "-" + dgrBC.Rows(i).Cells("STT").Value.ToString())
                        If Me.dgrBC.Rows(i).Cells("X_MA_").Value <> "TCT" Then
                            Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("DV_TEN").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.ForeColor = Color.Red
                        Else
                            Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("DV_TEN").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.ForeColor = Color.Blue
                            Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.ForeColor = Color.Blue

                            Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("DV_TEN").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                            Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                            Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        End If
                    End If



                    If IsDBNull(Me.dgrBC.Rows(i).Cells("X_MA_").Value) Then
                    Else
                        If (Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU A") Or (Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU B") Or (Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU DVC") Then
                            Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("DV_TEN").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                            Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                            Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("DV_TEN").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.ForeColor = Color.Red
                            Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.ForeColor = Color.Red
                        End If
                    End If
                Next
                Me.tblTableExcelMerge = Me.cboDinhDangExcel.DataSource

            Case "XUONG"
                listpar.Clear()

                If Me.chkTinhdauthang.Checked Then
                    listpar.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                Else
                    listpar.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                End If

                Select Case obj.ChonKhu
                    Case "A"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Select Case obj.TinhCNM
                            Case 0
                                Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_KHUA_S_KHONGTINHCNM", listpar)
                            Case 1
                                Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_KHUA_S", listpar)
                        End Select
                    Case "B"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_KHUB_S", listpar)
                    Case "DVC"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_KHUDVC_S", listpar)
                    Case "TCT"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Select Case obj.TinhCNM
                            Case 0
                                Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_TCT_S_1_KHONGTINHCNM", listpar)
                            Case 1
                                Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_TCT_S_1", listpar)
                        End Select
                    Case Else
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Tablethongke = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_TCT_S_1_KHONGTINHCNM", listpar)
                End Select

                listpar.Clear()
                Me.dgrBC.DataSource = Tablethongke
                If Tablethongke.Rows.Count > 0 Then
                    Me.btnExcel.Enabled = True
                End If

            Case "X_MAU"
                Dim tblTemp As DataTable
                listpar.Clear()
                If Me.chkTinhdauthang.Checked Then
                    listpar.Add(New SqlParameter("@DENNGAY", ngayselectdauthang))
                Else
                    listpar.Add(New SqlParameter("@DENNGAY", ngayselectcuoithang))
                End If

                Select Case obj.ChonKhu
                    Case "A"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Select Case obj.TinhCNM
                            Case 0
                                tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_KHUA_S_KHONGTINHCNM", listpar)
                            Case 1
                                tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_KHUA_S", listpar)
                        End Select
                    Case "B"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_KHUB_S", listpar)
                    Case "DVC"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_KHUDVC_S", listpar)
                    Case "TCT"
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        Select Case obj.TinhCNM
                            Case 0
                                tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_TCT_S_KHONGTINHCNM", listpar)
                            Case 1
                                tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_TCT_S", listpar)
                        End Select
                    Case Else
                        listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                        tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_TCT_S_KHONGTINHCNM", listpar)
                End Select

                'tblTemp = Me.b.GoiThuTuc("SP_TKTTGT_XUONG_CHUAKYHDLD_S", listpar)
                listpar.Clear()
                Me.dgrBC.DataSource = tblTemp

                For i = 0 To dgrBC.Rows.Count - 1
                    Me.cboDinhDangExcel.Items.Add(Me.dgrBC.Rows(i).Cells("X_MA_").Value.ToString() + "-" + dgrBC.Rows(i).Cells("THUTU").Value.ToString())
                    If Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TONGKHUA" Or Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TONGKHUB" Or Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TONGKHUDVC" Then
                        Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("TT").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("GTHT").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("GTDVC").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.ForeColor = Color.Red
                        Me.dgrBC.Rows(i).Cells("CKHD").Appearance.ForeColor = Color.Red

                    ElseIf Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TCT" Then
                        Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("TT").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("GTHT").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("GTDVC").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.ForeColor = Color.Blue
                        Me.dgrBC.Rows(i).Cells("CKHD").Appearance.ForeColor = Color.Blue

                        Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("TT").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("GTHT").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                        Me.dgrBC.Rows(i).Cells("GTDVC").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("GHICHU").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        Me.dgrBC.Rows(i).Cells("CKHD").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                    End If

                Next
            Case "CHITIET"
                If bChuaCoDuLieu = False Then
                    listpar.Clear()
                    Dim tblTemp As DataTable
                    If Me.chkTinhdauthang.Checked = False Then
                        ''========danh sach ngay cuoi thang
                        listpar.Add(New SqlParameter("@Ngay", ngayselectcuoithang))
                    Else
                        ''========danh sach ngay dau thang
                        listpar.Add(New SqlParameter("@Ngay", ngayselectdauthang))
                    End If
                    obj.TinhCNM = Me.chkTinhCNM.Checked

                    Select Case obj.ChonKhu
                        Case "A"
                            listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                            tblTemp = Me.b.GoiThuTuc("SP_IT_DIEMDANHHANGNGAY_TRUCTIEPGIANTIEP_KHUA_S", listpar)
                        Case "B"
                            listpar.Add(New SqlParameter("@TINHCNM", 0))
                            tblTemp = Me.b.GoiThuTuc("SP_IT_DIEMDANHHANGNGAY_TRUCTIEPGIANTIEP_KHUB_S", listpar)
                        Case "DVC"
                            listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                            tblTemp = Me.b.GoiThuTuc("SP_IT_DIEMDANHHANGNGAY_TRUCTIEPGIANTIEP_KHUDVC_S", listpar)
                        Case "TCT"
                            listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                            tblTemp = Me.b.GoiThuTuc("SP_IT_DIEMDANHHANGNGAY_TRUCTIEPGIANTIEP_TCT_S", listpar)
                        Case Else
                            listpar.Add(New SqlParameter("@TINHCNM", obj.TinhCNM))
                            tblTemp = Me.b.GoiThuTuc("SP_IT_DIEMDANHHANGNGAY_TRUCTIEPGIANTIEP_TCT_S", listpar)
                    End Select

                    Try
                        Me.dgrBC.DataSource = tblTemp
                        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DanhSachCNTTGT.xml"), typeControl.Grid, "coldgrNghiPhep")
                    Catch ex As Exception
                        ProjectData.SetProjectError(ex)
                        Dim exception As Exception = ex
                        Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
                        Me.Close()
                        ProjectData.ClearProjectError()
                        Return
                    End Try
                End If
        End Select
        grid.initControlNoXML(Me.dgrBC)
    End Sub
    Private Sub LoadGridView_MauXuongKHD()
        Dim i As Integer

        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).Header.Appearance.ForeColor = Color.Blue
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Next

        Me.dgrBC.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.Override.RowSizing = RowSizing.Free
        Me.dgrBC.DisplayLayout.Bands(0).Columns("THUTU").Header.Caption = "STT 秩序 "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.Caption = "Xưởng 廠別 "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.Caption = " Đơn vị 單位"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("XUONGTENHOA").Header.Caption = "Đơn vị 單位 "

        Me.dgrBC.DisplayLayout.Bands(0).Columns("TT").Header.Caption = "SỐ NGƯỜI 直接人數"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("GTHT").Header.Caption = "HIỆN TRƯỜNG 現場人數"

        Me.dgrBC.DisplayLayout.Bands(0).Columns("GTDVC").Header.Caption = "DV CHUNG 共同單位人數 "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CKHD").Header.Caption = "未簽正式 CKHD 合同人數 "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("GHICHU").Header.Caption = "GHI CHÚ 備註"

        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellStyle = MergedCellStyle.Always
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Hidden = True


    End Sub
    Private Sub XuatExcelMau_DanhsachChiTiet()
        Dim myWorkbook As New Infragistics.Excel.Workbook
        Dim myWorksheet As Infragistics.Excel.Worksheet
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"

        Try
            myWorksheet = myWorkbook.Worksheets.Add("TTGT_CHITIET")
            Dim sheet As Infragistics.Excel.Worksheet = myWorkbook.Worksheets("TTGT_CHITIET")
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Color = Color.Blue
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Name = "Arial"
            myWorksheet.Rows(0).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
            myWorksheet.Rows(0).Cells(1).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.WrapText = ExcelDefaultableBoolean.True
            myWorksheet.Rows(0).Cells(1).CellFormat.Font.Height = 300
            myWorksheet.Rows(0).Height = 800
            If Me.radKhuA.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "DANH SÁCH LAO ĐỘNG LÀM CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP KHU A" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            If Me.radKhuB.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "DANH SÁCH LAO ĐỘNG LÀM CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP KHU B" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            If Me.radTCT.Checked Then
                myWorksheet.Rows(0).Cells(1).Value = "DANH SÁCH LAO ĐỘNG LÀM CÔNG VIỆC TRỰC TIẾP VÀ GIÁN TIẾP TOÀN CÔNG TY" & Chr(10) & " 億春各廠直接與間接人數統計表 "
            End If

            sheet.MergedCellsRegions.Add(0, 1, 0, dgrBC.DisplayLayout.Bands(0).Columns.Count)

            Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 3, 1)
            BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Lỗi!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadGridView_MauXuongDonvi()
        Dim i As Integer
        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).Header.Appearance.ForeColor = Color.Blue
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Next
        Me.dgrBC.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.Override.RowSizing = RowSizing.Free
        Me.dgrBC.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed

        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        Me.dgrBC.DisplayLayout.Bands(0).Columns("STT").Header.Caption = "秩序 STT"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.Caption = "廠別 Xưởng"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.Caption = "單位 Đơn vị"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("DV_TEN").Header.Caption = "單位 Đơn vị"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNTRUCTIEP").Header.Caption = "人數 Số lượng"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNGIANTIEP").Header.Caption = "人數 Số lượng"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNTRUCTIEP").Header.Caption = "  %  "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNGIANTIEP").Header.Caption = "  %  "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCN").Header.Caption = "總人數 Tổng số CN"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellStyle = MergedCellStyle.Always
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").MergedCellStyle = MergedCellStyle.Always
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Hidden = False
        Me.dgrBC.DisplayLayout.Bands(0).Columns("LOAI").Hidden = True
        Me.dgrBC.DisplayLayout.Bands(0).Columns("LOAI").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True

        Me.dgrBC.DisplayLayout.Bands(0).Columns("STT").Header.VisiblePosition = 0
        Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").Header.VisiblePosition = 1
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.VisiblePosition = 2
        Me.dgrBC.DisplayLayout.Bands(0).Columns("DV_TEN").Header.VisiblePosition = 3
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNTRUCTIEP").Header.VisiblePosition = 4
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNTRUCTIEP").Header.VisiblePosition = 5
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNGIANTIEP").Header.VisiblePosition = 6
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNGIANTIEP").Header.VisiblePosition = 7
        Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCN").Header.VisiblePosition = 8
    End Sub
    Private Sub LoadGridView_MauXuong()
        Dim i As Integer

        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).Header.Appearance.ForeColor = Color.Blue
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            Me.dgrBC.DisplayLayout.Bands(0).Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Next
        Me.dgrBC.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        Me.dgrBC.DisplayLayout.Override.RowSizing = RowSizing.Free
        Me.dgrBC.DisplayLayout.Bands(0).Columns("THUTU").Header.Caption = "秩序 STT"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.Caption = "廠別 Xưởng"
        'Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.Caption = "單位 Đơn vị"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("XUONGTENHOA").Header.Caption = "單位 Đơn vị"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNTRUCTIEP").Header.Caption = "人數 Số lượng"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("CNGIANTIEP").Header.Caption = "人數 Số lượng"
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNTRUCTIEP").Header.Caption = "  %  "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("PTCNGIANTIEP").Header.Caption = "  %  "
        Me.dgrBC.DisplayLayout.Bands(0).Columns("TONGCN").Header.Caption = "總人數 Tổng số CN"
        'Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellStyle = MergedCellStyle.Always
        'Me.dgrBC.DisplayLayout.Bands(0).Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue
        'Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Hidden = True

        For i = 0 To dgrBC.Rows.Count - 1
            If Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU A" Or Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU B" Or Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TỔNG KHU DVC" Then
                Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.ForeColor = Color.Red
                Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.ForeColor = Color.Red
            End If
            If Me.dgrBC.Rows(i).Cells("X_MA_").Value = "TCT" Then
                Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.ForeColor = Color.Blue
                Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.ForeColor = Color.Blue
                Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.ForeColor = Color.Blue
                Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.ForeColor = Color.Blue
                Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.ForeColor = Color.Blue
                Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.ForeColor = Color.Blue

                Me.dgrBC.Rows(i).Cells("XUONGTENHOA").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("CNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("CNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("PTCNTRUCTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("PTCNGIANTIEP").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.dgrBC.Rows(i).Cells("TONGCN").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If
        Next
    End Sub

    Private Sub dtpThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpThang.ValueChanged
        If Me.chkTinhdauthang.Checked = False Then
            LayNgayCuoiThang()
        Else
            LayNgayDauThang()
        End If

    End Sub

    Private Sub chkTinhdauthang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTinhdauthang.CheckedChanged
        If Me.chkTinhdauthang.Checked = False Then
            LayNgayCuoiThang()
        Else
            LayNgayDauThang()
        End If
    End Sub

    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        Me.dgrBC.Visible = True
        Me.rptThongKeCN_TT_GT.Visible = False
        Me.dgrBC.BringToFront()

        Select Case cboLoaiBaoCao.Value
            Case "DV"
                LoadDataGrid()
                If bChuaCoDuLieu = False Then
                    LoadGridView_MauXuongDonvi()
                Else
                    MessageBox.Show("Tháng bạn vừa chọn chưa có dữ liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case "XUONG"
                LoadDataGrid()
                If bChuaCoDuLieu = False Then
                    LoadGridView_MauXuong()
                Else
                    MessageBox.Show("Tháng bạn vừa chọn chưa có dữ liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case "X_MAU"
                LoadDataGrid()
                If bChuaCoDuLieu = False Then
                    LoadGridView_MauXuongKHD()
                Else
                    MessageBox.Show("Tháng bạn vừa chọn chưa có dữ liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case "CHITIET"
                If bChuaCoDuLieu = False Then
                    LoadDataGrid()
                Else
                    MessageBox.Show("Tháng bạn vừa chọn chưa có dữ liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select
        If Me.dgrBC.Rows.Count > 0 Then
            Me.btnExcel.Enabled = True
        End If
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Select Case cboLoaiBaoCao.Value
                Case "DV"
                    LoadDataGrid()
                    If bChuaCoDuLieu = False Then
                        LoadGridView_MauXuongDonvi()
                        XuatExcelMau_XuongDonvi()
                        ' MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Case "XUONG"
                    LoadDataGrid()
                    If bChuaCoDuLieu = False Then
                        LoadGridView_MauXuong()
                        XuatExcelMau_Xuong()
                        'MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Case "X_MAU"
                    LoadDataGrid()
                    If bChuaCoDuLieu = False Then
                        LoadGridView_MauXuongKHD()
                        XuatExcelMau_XuongKHD()
                        ' MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                Case "CHITIET"
                    LoadDataGrid()
                    If bChuaCoDuLieu = False Then

                        XuatExcelMau_DanhsachChiTiet()
                        'MessageBox.Show("Đã xuất file excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If


            End Select
        End If
    End Sub
    Private Sub btnBaocao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaocao.Activate
        If bChuaCoDuLieu = False Then
            Me.HienThiReport()
        Else
            MessageBox.Show("Tháng bạn vừa chọn chưa có dữ liệu điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class