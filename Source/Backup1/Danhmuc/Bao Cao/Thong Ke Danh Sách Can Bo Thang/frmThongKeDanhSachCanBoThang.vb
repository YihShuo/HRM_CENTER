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
Imports Infragistics.Excel

Public Class frmThongKeDanhSachCanBoThang
    Dim obj As New objThongKeDanhSachCanBoThang
    Friend WithEvents b As clsBThongKeDanhSachCanBoThang
    Public i, j, k, l As Integer
    Dim KhuA As Integer = 0
    Dim KhuB As Integer = 0
    Dim KhuDVC As Integer = 0
    Dim KhuA1 As Integer = 0
    Dim ngay As String
    Dim KhuB1 As Integer = 0
    Dim KHUCHON As String
 
    Private Sub frmThongKeDanhSachCanBoThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now()
        Me.ButtonItem1.Enabled = False
        Me.radTCT.Checked = True
    End Sub
    Public Sub methodLoad()
        dgrBC.DataSource = Nothing
        giatrikhu()
        Me.b = New clsBThongKeDanhSachCanBoThang
        Dim SqlParam As SqlParameter() = {New SqlParameter("@KHU", SqlDbType.NVarChar)}
        SqlParam(0).Value = KHUCHON
        Dim tblTam As DataTable
        If KHUCHON <> "TCT" Then
            tblTam = Me.b.GoiThuTuc("SP_THONGKEDSCB_THEOKHU_FC", SqlParam)
        Else
            tblTam = Me.b.GoiThuTuc("SP_THONGKEDSCB_S_TEST_FC", SqlParam) 'SP_THONGKEDSCB_S
        End If

        KhuA = 0
        KhuB = 0
        KhuDVC = 0
        If tblTam.Rows.Count > 0 Then
            dgrBC.DataSource = tblTam
            Me.ButtonItem1.Enabled = True
            Me.dgrBC.DataSource = tblTam
            For i = 0 To dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Black
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.False
                Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Black
                If dgrBC.Rows(i).Cells("X_MA_").Value.ToString() = "小計" Then
                    Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("X_MA_").Appearance.ForeColor = Color.Red 'màu 
                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("KHU").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("CHUNHIEM").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("CHUNHIEM").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("PHOCHUNHIEM").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("PHOCHUNHIEM").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TRUONGNGANH").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("TRUONGNGANH").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("PHONGANH").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("PHONGANH").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TOTRUONG").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("TOTRUONG").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TOPHO").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("TOPHO").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TRUONGBAN").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("TRUONGBAN").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("CBTS").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("CBTS").Appearance.ForeColor = Color.Red

                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.FontData.Bold = DefaultableBoolean.False
                    Me.dgrBC.Rows(i).Cells("TONGCONG").Appearance.ForeColor = Color.Red


                End If
                If Me.radKhuA.Checked Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" And dgrBC.Rows(i).Cells("X_MA_").Value.ToString() <> "小計" Then
                        KhuA = KhuA + 1
                    End If
                    KhuB = 0
                    KhuDVC = 0
                End If
                If Me.radKhuB.Checked Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" And dgrBC.Rows(i).Cells("X_MA_").Value.ToString() <> "小計" Then
                        KhuB = KhuB + 1
                    End If
                    KhuA = 0
                    KhuDVC = 0
                End If
                If Me.rdDVC.Checked Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC 區" And dgrBC.Rows(i).Cells("X_MA_").Value.ToString() <> "小計" Then
                        KhuDVC = KhuDVC + 1
                    End If
                    KhuA = 0
                    KhuB = 0
                End If

                If Me.radTCT.Checked Then
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "A 區" Then
                        KhuA = KhuA + 1
                    End If
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "B 區" Then
                        KhuB = KhuB + 1
                    End If
                    If dgrBC.Rows(i).Cells("KHU").Value.ToString() = "DVC 區" Then
                        KhuDVC = KhuDVC + 1
                    End If
                End If

            Next
            loadgridview1()



        End If

    End Sub

    Private Sub giatrikhu()
        If Me.radKhuA.Checked Then
            KHUCHON = "A"
        End If
        If Me.radKhuB.Checked Then
            KHUCHON = "B"
        End If
        If Me.rdDVC.Checked Then
            KHUCHON = "DVC"
        End If
        If Me.radTCT.Checked Then
            KHUCHON = "TCT"
        End If
    End Sub
    Private Sub MethodLoadChiTiet()
        dgrBC.DataSource = Nothing
        Dim ngay As Date = Me.dtpNgay.Value
        Dim ngayselect As String
        ngayselect = ngay.Year.ToString() + "-" + ngay.Month.ToString() + "-" + ngay.Day.ToString()
        giatrikhu()
        Me.b = New clsBThongKeDanhSachCanBoThang
        Dim SqlParam As SqlParameter() = {New SqlParameter("@KHU", Data.SqlDbType.NVarChar), _
                     New SqlParameter("@NGAY", Data.SqlDbType.NVarChar)}
        SqlParam(0).Value = KHUCHON
        SqlParam(1).Value = ngayselect
        Dim tblTamchitiet As DataTable
        'If KHUCHON <> "TCT" Then
        '    tblTamchitiet = Me.b.GoiThuTuc("SP_THONGKEDSCB_CHITIET_THEOKHU_S_TEST_FC", SqlParam)
        'Else
        '    tblTamchitiet = Me.b.GoiThuTuc("SP_THONGKEDSCB_CHITIET_TCT_S_TEST_FC", SqlParam) 'SP_THONGKEDSCB_S
        'End If
        If KHUCHON <> "TCT" Then
            tblTamchitiet = Me.b.ThongKe("SP_THONGKEDSCB_CHITIET_THEOKHU_S_TEST_FC", SqlParam)
        Else
            tblTamchitiet = Me.b.ThongKe("SP_THONGKEDSCB_CHITIET_TCT_S_TEST_FC", SqlParam) 'SP_THONGKEDSCB_S
        End If
      dgrBC.DataSource = tblTamchitiet
        If tblTamchitiet.Rows.Count > 0 Then
            Me.dgrBC.DataSource = tblTamchitiet
            Me.ButtonItem1.Enabled = True
            Dim i As Integer = 0
            For i = 0 To Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Cells(0).Value = i + 1
            Next
        End If
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
    Private Sub loadgridviewChitiet()
        With Me.dgrBC.DisplayLayout.Bands(0)
            .Columns("STT").Header.Caption = "stt" & Chr(10) & "序號"
            .Columns("STT").Width = 40
            .Columns("KHU").CellActivation = Activation.NoEdit
            .Columns("KHU").Header.Caption = "Khu" & Chr(10) & "廠別"
            .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("KHU").Width = 50
            .Columns("X_MA_").Header.Caption = "Xưởng" & Chr(10) & "單位"
            .Columns("X_MA_").Width = 90
            .Columns("X_MA_").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("DV_MA").Header.Caption = "Đơn vị" & Chr(10) & "單位"
            .Columns("DV_MA").Width = 90
            .Columns("DV_MA").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("NV_Ma").Header.Caption = "Số thẻ" & Chr(10) & "工號"
            .Columns("NV_Ma").Width = 90
            .Columns("NV_Ma").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("NV_Ten").Header.Caption = "Họ tên" & Chr(10) & "姓名"
            .Columns("NV_Ten").Width = 200
            .Columns("NV_Ten").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("GIOITINH").Header.Caption = "Nam/Nữ" & Chr(10) & "男/女"
            .Columns("GIOITINH").Width = 200
            .Columns("GIOITINH").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("NGAYVAO").Header.Caption = "Ngày vào" & Chr(10) & "進廠日期"
            .Columns("NGAYVAO").Width = 200
            .Columns("NGAYVAO").Format = "dd/MM/yyyy"
            .Columns("CV_TEN").Header.Caption = "Công việc"
            .Columns("CV_TEN").Width = 200
            .Columns("CVU_Ten").Header.Caption = "Chức vụ" & Chr(10) & "職務"
            .Columns("CVU_Ten").Width = 200
            .Columns("KHU").MergedCellStyle = MergedCellStyle.Never
        End With
    End Sub
    Private Sub loadgridview1()

        With Me.dgrBC.DisplayLayout.Bands(0)
            Dim STT As UltraGridColumn = dgrBC.DisplayLayout.Bands(0).Columns.Add("STT", "STT")
            STT.DataType = GetType(String)
            STT.CellActivation = Activation.NoEdit
            STT.Header.VisiblePosition = 0
            dgrBC.DisplayLayout.Bands(0).Columns("STT").Header.Caption = "stt" & Chr(10) & "序號"
            Me.dgrBC.DisplayLayout.Bands(0).Columns("STT_AN").Hidden = True
            .Columns("STT").Width = 40
            .Columns("STT").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("KHU").CellActivation = Activation.NoEdit
            .Columns("KHU").Header.Caption = "Xưởng" & Chr(10) & "廠別"
            .Columns("KHU").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("KHU").Width = 50
            .Columns("X_MA_").Header.Caption = "Đơn vị" & Chr(10) & "單位"
            .Columns("X_MA_").Width = 90
            .Columns("X_MA_").Header.Appearance.FontData.Bold = DefaultableBoolean.False

            .Columns("CHUNHIEM").Header.Caption = "Chủ nhiệm" & Chr(10) & "主任"
            .Columns("CHUNHIEM").Width = 90
            .Columns("CHUNHIEM").Header.Appearance.FontData.Bold = DefaultableBoolean.False

            .Columns("PHOCHUNHIEM").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("PHOCHUNHIEM").Header.Caption = "Phó Chủ nhiệm" & Chr(10) & "副主任"
            .Columns("PHOCHUNHIEM").Width = 90

            .Columns("TRUONGNGANH").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("TRUONGNGANH").Header.Caption = "Trưởng Ngành" & Chr(10) & "(CBB5)" & Chr(10) & "課長（第五級幹部）"
            .Columns("TRUONGNGANH").Width = 90

            .Columns("PHONGANH").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("PHONGANH").Header.Caption = "Phó Ngành" & Chr(10) & "(CBB4)" & Chr(10) & "副課長（第四級幹部）"
            .Columns("PHONGANH").Width = 90

            .Columns("TOTRUONG").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("TOTRUONG").Header.Caption = "Tổ trưởng" & Chr(10) & "(CBB3) " & Chr(10) & "組長（第三級幹部）"
            .Columns("TOTRUONG").Width = 100

            .Columns("TOPHO").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("TOPHO").Header.Caption = "Tổ phó" & Chr(10) & "(CBB2)" & Chr(10) & "副組長（第二級幹部）"
            .Columns("TOPHO").Width = 90

            .Columns("TRUONGBAN").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("TRUONGBAN").Header.Caption = "Trưởng ban" & Chr(10) & "(CBB1) " & Chr(10) & "班長（第一級幹部）"
            .Columns("TRUONGBAN").Width = 90

            .Columns("CBTS").Header.Appearance.FontData.Bold = DefaultableBoolean.False
            .Columns("CBTS").Header.Caption = "CBTS" & Chr(10) & "佐理"
            .Columns("CBTS").Width = 90

            .Columns("TONGCONG").Header.Caption = "Tổng cộng" & Chr(10) & "合計"
            .Columns("TONGCONG").Width = 90
            .Columns("TONGCONG").Header.Appearance.FontData.Bold = DefaultableBoolean.False

            .Columns("KHU").MergedCellStyle = MergedCellStyle.Always
            .Columns("KHU").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue

            ''=====
            .Columns("STT").Header.VisiblePosition = 0
            .Columns("KHU").Header.VisiblePosition = 1
            .Columns("X_MA_").Header.VisiblePosition = 2
            .Columns("CHUNHIEM").Header.VisiblePosition = 3
            .Columns("PHOCHUNHIEM").Header.VisiblePosition = 4
            .Columns("TRUONGNGANH").Header.VisiblePosition = 5
            .Columns("PHONGANH").Header.VisiblePosition = 6
            .Columns("TOTRUONG").Header.VisiblePosition = 7
            .Columns("TOPHO").Header.VisiblePosition = 8
            .Columns("TRUONGBAN").Header.VisiblePosition = 9
            .Columns("CBTS").Header.VisiblePosition = 10
            .Columns("TONGCONG").Header.VisiblePosition = 11
            Dim sttchay As Integer = 0
            For i = 0 To dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells("STT_AN").Value.ToString <> "" Then
                    Me.dgrBC.Rows(i).Cells("STT").Value = sttchay + 1
                    sttchay = sttchay + 1
                Else
                    Me.dgrBC.Rows(i).Cells("STT").Value = Me.dgrBC.Rows(i).Cells("STT_AN").Value.ToString
                End If
            Next

        End With
    End Sub
 
    Private Sub XuatExcel_TieuDe1()
        Dim ngaytam As String = Me.dtpNgay.Text.ToString()
        ngay = ngaytam.Substring(3, 7)
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "THỐNG KÊ CÁN BỘ TOÀN CÔNG TY THÁNG " & ngay
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
                Me.dgrBC.DisplayLayout.Bands(0).Columns("X_MA_").Header.VisiblePosition = 2
                Me.dgrBC.DisplayLayout.Bands(0).Columns("CHUNHIEM").Header.VisiblePosition = 3
                Me.dgrBC.DisplayLayout.Bands(0).Columns("PHOCHUNHIEM").Header.VisiblePosition = 4
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TRUONGNGANH").Header.VisiblePosition = 5
                Me.dgrBC.DisplayLayout.Bands(0).Columns("PHONGANH").Header.VisiblePosition = 6
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TOTRUONG").Header.VisiblePosition = 7
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TOPHO").Header.VisiblePosition = 8
                Me.dgrBC.DisplayLayout.Bands(0).Columns("TRUONGBAN").Header.VisiblePosition = 9
                Me.dgrBC.DisplayLayout.Bands(0).Columns("CBTS").Header.VisiblePosition = 10
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
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.False
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

                myWorksheet.Rows(3).Cells(0).Value = "stt" & Chr(10) & " 序號"
                myWorksheet.Rows(3).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(1).Value = "Xưởng" & Chr(10) & " 廠別"
                myWorksheet.Rows(3).Cells(1).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(3).Cells(2).Value = "Đơn vị" & Chr(10) & " 序號"
                myWorksheet.Rows(3).Cells(2).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)


                myWorksheet.Rows(3).Cells(3).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(4).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(5).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(6).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(7).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(8).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(9).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(10).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(10).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(3).Cells(11).Value = "CÁN BỘ 幹部"
                myWorksheet.Rows(3).Cells(11).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(3).Value = "Chủ nhiệm " & Chr(10) & " 主任"
                myWorksheet.Rows(4).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(4).Value = "Phó Chủ nhiệm " & Chr(10) & " 副主任"
                myWorksheet.Rows(4).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(5).Value = "Trưởng Ngành " & Chr(10) & " (CBB5)" & Chr(10) & "課長（第五級幹部）"
                myWorksheet.Rows(4).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(6).Value = "Phó Ngành " & Chr(10) & " (CBB4) " & Chr(10) & "副課長（第四級幹部）"
                myWorksheet.Rows(4).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(7).Value = "Tổ Trưởng" & Chr(10) & " (CBB3) " & Chr(10) & "組長（第三級幹部）"
                myWorksheet.Rows(4).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(8).Value = "Tổ Phó" & Chr(10) & "(CBB2)" & Chr(10) & "副組長（第二級幹部）"
                myWorksheet.Rows(4).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(9).Value = "Trưởng Ban" & Chr(10) & "(CBB1)" & Chr(10) & "班長（第一級幹部）"
                myWorksheet.Rows(4).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(4).Cells(10).Value = "CBTS" & Chr(10) & "佐理"
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
                If Me.radKhuA.Checked Then
                    'khu A
                    sheet.MergedCellsRegions.Add(5, 1, 5 + (KhuA - 1), 1)
                End If
                If Me.radKhuB.Checked Then
                    'Khu B
                    sheet.MergedCellsRegions.Add(5 + KhuA, 1, 5 + KhuA + (KhuB - 1), 1)
                End If
                If Me.rdDVC.Checked Then
                    'Khu DVC
                    sheet.MergedCellsRegions.Add(5 + KhuA + KhuB, 1, 5 + KhuA + KhuB + (KhuDVC - 1), 1)
                End If
                If Me.radTCT.Checked Then
                    'khu A
                    sheet.MergedCellsRegions.Add(5, 1, 5 + (KhuA - 1), 1)
                    'Khu B
                    sheet.MergedCellsRegions.Add(5 + KhuA, 1, 5 + KhuA + (KhuB - 1), 1)
                    'Khu DVC
                    sheet.MergedCellsRegions.Add(5 + KhuA + KhuB, 1, 5 + KhuA + KhuB + (KhuDVC - 1), 1)
                End If
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).Value = "TC 合計:"
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.False
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC).Cells(0).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                'mer tong cộng
                sheet.MergedCellsRegions.Add(5 + KhuA + KhuB + KhuDVC, 0, 5 + KhuA + KhuB + KhuDVC, 1)

                'Cuối trang
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 3).Cells(9).Value = "LẬP BIỂU:"
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 3).Cells(9).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 3).Cells(9).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                sheet.MergedCellsRegions.Add(5 + KhuA + KhuB + KhuDVC + 3, 9, 5 + KhuA + KhuB + KhuDVC + 3, 11)
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 4).Cells(10).Value = "製表"
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 4).Cells(10).CellFormat.Alignment = HorizontalCellAlignment.Center
                myWorksheet.Rows(5 + KhuA + KhuB + KhuDVC + 4).Cells(10).CellFormat.VerticalAlignment = VerticalCellAlignment.Center

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate
        If Me.chkChiTiet.Checked = False Then
            methodLoad()

        End If
        If Me.chkChiTiet.Checked = True Then
            MethodLoadChiTiet()
            loadgridviewChitiet()
            'Me.ButtonItem1.Enabled = False
        End If
        Me.ButtonItem1.Enabled = True
        'loadgridview1()
    End Sub

   
    Private Sub ButtonItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Activate
        If Me.chkChiTiet.Checked = False Then
            XuatExcel_TieuDe1()
        Else
            XuatExcel_chitiet()
        End If
    End Sub
    Private Sub XuatExcel_chitiet()
    
        '=============================================================================================
        Dim ngaytam As String = Me.dtpNgay.Text.ToString()
        ngay = ngaytam.Substring(3, 7)
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "THỐNG KÊ CÁN BỘ TOÀN CÔNG TY THÁNG " & ngay
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TK")
                Dim sheet As Worksheet = myWorkbook.Worksheets("TK")

                Me.dgrBC.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, myWorksheet, 0, 0)
                'mer đơn vị giống nhau
                'Dim biendau As Integer = 0
                'For i = 0 To Me.dgrBC.Rows.Count - 2
                '    If Me.dgrBC.Rows(biendau).Cells("DV_MA").Value = Me.dgrBC.Rows(i + 1).Cells("DV_MA").Value Then
                '        sheet.MergedCellsRegions.Add(biendau, 2, i + 1, 2)
                '    Else
                '        biendau = i
                '    End If
                'Next

                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If


    End Sub

    Private Sub chkChiTiet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChiTiet.CheckedChanged
        If Me.chkChiTiet.Checked Then
            If Me.radKhuA.Checked = False And Me.radKhuB.Checked = False And Me.radTCT.Checked = False Then
                Me.radTCT.Checked = True
            End If
        End If
        Me.ButtonItem1.Enabled = False
    End Sub

    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        Me.ButtonItem1.Enabled = False
    End Sub

    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        Me.ButtonItem1.Enabled = False
    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        Me.ButtonItem1.Enabled = False
    End Sub
End Class