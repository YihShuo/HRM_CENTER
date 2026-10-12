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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports Infragistics.Excel




Public Class frmGioCongHangNgayDonVi
    Inherits Form
    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Dim obj As New ObjGioCongHangNgayDonVi
    Dim PATH As String
    Friend WithEvents b As ClsBGioCongHangNgayDonVi
    Dim tableDictionary, TABLELUOI As DataTable
    Public i, j, k, l As Integer
    Dim TABLEDV, TABLEK As DataTable
    Dim tongsocot As Integer
    Public fWaiting As frmWaiting_GC

    'Public Sub New()
    '    AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmGioCongHangNgayDonVi_Load)
    '    Me.issysReport = True
    '    Me.InitializeComponent()
    'End Sub

    Private Sub frmGioCongHangNgayDonVi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
        Me.CrystalReportViewer1.RefreshReport()
        Me.btnXuatEX.Enabled = False
        Me.UltraGrid1.Visible = True
        Me.UltraGrid1.BringToFront()
        Me.CrystalReportViewer1.Visible = False
        'Me.ProgressBar1.Value = 0
        'Me.ProgressBar1.Style = ProgressBarStyle.Blocks
        'Me.ProgressBar1.Visible = True

    End Sub
    'Public Sub Loading()

    '    Me.b = New ClsBGioCongHangNgayDonVi
    '    Dim tblTemp As DataTable
    '    Dim i As Integer
    '    Do
    '        For i = 0 To Me.tableDictionary.Rows.Count - 1
    '            Threading.Thread.Sleep(100)
    '            If Me.UltraGrid1.Rows.Count > 1 Then
    '                Me.ProgressBar1.Value = (100 * i) / Me.tableDictionary.Rows.Count()
    '                Me.ProgressBar1.Step = (100 * i) / Me.tableDictionary.Rows.Count()
    '                Me.ProgressBar1.PerformStep()
    '            Else
    '                Me.ProgressBar1.Value = 100
    '            End If
    '        Next
    '        'i = i + 1
    '    Loop Until ProgressBar1.Value >= ProgressBar1.Maximum
    'End Sub
    Private Sub HienThiReport()
        Dim document As ReportDocument
        Dim report As New ClsBReport
        Try
            If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
                document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
            Else
                document = report.InitReport(Me.reportID)
            End If
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
        Me.CrystalReportViewer1.ReportSource = document
    End Sub
    Private Sub LayThamSo()
        If Me.radKhuA.Checked = True Or Me.radKhuB.Checked = True Or Me.radKhuDVC.Checked = True Then
            Me.reportID = "022KHU"
            Dim thang As String = Month(Me.dtpNgay.Value)
            If Len(thang) = 1 Then
                thang = "0" + thang
            Else
                thang = thang
            End If
            Dim nam As String = Year(Me.dtpNgay.Value)
            Dim t_ma As String = Me.dtpNgay.Text
            Dim khu As String
            If Me.radKhuA.Checked = True Then
                khu = "A"
            ElseIf Me.radKhuB.Checked = True Then
                khu = "B"
            ElseIf Me.radKhuDVC.Checked = True Then
                khu = "DVC"
            End If
            Dim strArray As String() = New String() {nam, t_ma, thang, "'" + khu + "'"}
            'Dim strArray As String() = New String() {"'" + nam + "'", "'" + t_ma + "'", "'" + thang + "'", "'" + khu + "'"}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        ElseIf Me.radTCT.Checked = True Then
            Me.reportID = "022"
            Dim thang As String = Month(Me.dtpNgay.Value)
            Dim nam As String = Year(Me.dtpNgay.Value)
            Dim t_ma As String = Me.dtpNgay.Text
            Dim strArray As String() = New String() {nam, t_ma, thang}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If

        
    End Sub
    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        'Me.ProgressBar1.Visible = False
        Me.CrystalReportViewer1.BringToFront()
        Me.CrystalReportViewer1.Visible = True
        Me.UltraGrid1.Visible = False
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub btnXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Click

        fWaiting = frmWaiting_GC.ShowProgress(Me)
        tableDictionary = New DataTable()
        Me.b = New ClsBGioCongHangNgayDonVi
        Me.UltraGrid1.Visible = True
        Me.UltraGrid1.BringToFront()
        Me.CrystalReportViewer1.Visible = False
        Me.XpCaption1.Text = "Danh sách giờ công đơn vị tháng " & obj.THANG & " năm " & obj.NAM
        Dim UltraGrid1 As Object = Me.UltraGrid1
        If Me.radKhuA.Checked = True Then
            obj.CHONKHU = "A"
        ElseIf Me.radKhuB.Checked = True Then
            obj.CHONKHU = "B"
        ElseIf Me.radKhuDVC.Checked = True Then
            obj.CHONKHU = "DVC"
        Else
            obj.CHONKHU = "TCT"
        End If
        obj.ChonBang = 1
        obj.THANG = Month(Me.dtpNgay.Value)
        obj.NAM = Year(Me.dtpNgay.Value)
        obj.T_MA = Me.dtpNgay.Text
        tableDictionary = Me.b.LoadDS(obj)

        fWaiting.CloseProgress()
        If tableDictionary.Rows.Count > 0 Then
            Me.UltraGrid1.DataSource = tableDictionary
        Else
            Me.UltraGrid1.DataSource = Nothing
        End If
        If Me.UltraGrid1.Rows.Count > 0 Then

            Me.btnXuatEX.Enabled = True
            loadgridview1()
            Ancottheothang(obj.THANG, obj.NAM)
            'Loading()
        Else
            Me.btnXuatEX.Enabled = False
            '    loadgridview1()
            '    Ancottheothang(obj.THANG, obj.NAM)
        End If
        Me.BringToFront()
        frmMain.SendToBack()
 

    End Sub
    
    Private Sub loadgridview1()
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        With Me.UltraGrid1.DisplayLayout.Bands(0)
            For i = 0 To Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
                .Columns(i).CellActivation = Activation.NoEdit
                .Columns(i).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                .Columns(i).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
            Next
            For i = 2 To Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 2
                .Columns(i).Width = 50
            Next
            '.Columns("STT").Header.Caption = "STT"
            .Columns("X_MA_").Header.Caption = "廠別/單位"
            .Columns("X_MA_").Header.VisiblePosition = 1
            .Columns("DV_MA").Header.Caption = "線別"
            .Columns("DV_MA").Header.VisiblePosition = 2
            .Columns("GC1").Header.Caption = " " & obj.THANG & "/1"
            .Columns("GC1").Header.VisiblePosition = 3
            .Columns("GC2").Header.Caption = " " & obj.THANG & "/2"
            .Columns("GC2").Header.VisiblePosition = 4
            .Columns("GC3").Header.Caption = " " & obj.THANG & "/3"
            .Columns("GC3").Header.VisiblePosition = 5
            .Columns("GC4").Header.Caption = " " & obj.THANG & "/4"
            .Columns("GC4").Header.VisiblePosition = 6
            .Columns("GC5").Header.Caption = " " & obj.THANG & "/5"
            .Columns("GC5").Header.VisiblePosition = 7
            .Columns("GC6").Header.Caption = " " & obj.THANG & "/6"
            .Columns("GC6").Header.VisiblePosition = 8
            .Columns("GC7").Header.Caption = " " & obj.THANG & "/7"
            .Columns("GC7").Header.VisiblePosition = 9
            .Columns("GC8").Header.Caption = " " & obj.THANG & "/8"
            .Columns("GC8").Header.VisiblePosition = 10
            .Columns("GC9").Header.Caption = " " & obj.THANG & "/9"
            .Columns("GC9").Header.VisiblePosition = 11
            .Columns("GC10").Header.Caption = " " & obj.THANG & "/10"
            .Columns("GC10").Header.VisiblePosition = 12
            .Columns("GC11").Header.Caption = " " & obj.THANG & "/11"
            .Columns("GC11").Header.VisiblePosition = 13
            .Columns("GC12").Header.Caption = " " & obj.THANG & "/12"
            .Columns("GC12").Header.VisiblePosition = 14
            .Columns("GC13").Header.Caption = " " & obj.THANG & "/13"
            .Columns("GC13").Header.VisiblePosition = 15
            .Columns("GC14").Header.Caption = " " & obj.THANG & "/14"
            .Columns("GC14").Header.VisiblePosition = 16
            .Columns("GC15").Header.Caption = " " & obj.THANG & "/15"
            .Columns("GC15").Header.VisiblePosition = 17
            .Columns("GC16").Header.Caption = " " & obj.THANG & "/16"
            .Columns("GC16").Header.VisiblePosition = 18
            .Columns("GC17").Header.Caption = " " & obj.THANG & "/17"
            .Columns("GC17").Header.VisiblePosition = 19
            .Columns("GC18").Header.Caption = " " & obj.THANG & "/18"
            .Columns("GC18").Header.VisiblePosition = 20
            .Columns("GC19").Header.Caption = " " & obj.THANG & "/19"
            .Columns("GC19").Header.VisiblePosition = 21
            .Columns("GC20").Header.Caption = " " & obj.THANG & "/20"
            .Columns("GC20").Header.VisiblePosition = 22
            .Columns("GC21").Header.Caption = " " & obj.THANG & "/21"
            .Columns("GC21").Header.VisiblePosition = 23
            .Columns("GC22").Header.Caption = " " & obj.THANG & "/22"
            .Columns("GC22").Header.VisiblePosition = 24
            .Columns("GC23").Header.Caption = " " & obj.THANG & "/23"
            .Columns("GC23").Header.VisiblePosition = 25
            .Columns("GC24").Header.Caption = " " & obj.THANG & "/24"
            .Columns("GC24").Header.VisiblePosition = 26
            .Columns("GC25").Header.Caption = " " & obj.THANG & "/25"
            .Columns("GC25").Header.VisiblePosition = 27
            .Columns("GC26").Header.Caption = " " & obj.THANG & "/26"
            .Columns("GC26").Header.VisiblePosition = 28
            .Columns("GC27").Header.Caption = " " & obj.THANG & "/27"
            .Columns("GC27").Header.VisiblePosition = 29
            .Columns("GC28").Header.Caption = " " & obj.THANG & "/28"
            .Columns("GC28").Header.VisiblePosition = 30
            .Columns("GC29").Header.Caption = " " & obj.THANG & "/29"
            .Columns("GC29").Header.VisiblePosition = 31
            .Columns("GC30").Header.Caption = " " & obj.THANG & "/30"
            .Columns("GC30").Header.VisiblePosition = 32
            .Columns("GC31").Header.Caption = " " & obj.THANG & "/31"
            .Columns("GC31").Header.VisiblePosition = 33
            .Columns("tc").Header.Caption = " " & obj.THANG & "月合計"
            .Columns("tc").Header.VisiblePosition = 34
        End With
       
    End Sub
    Private Sub Ancottheothang(ByVal sThang As String, ByVal sNam As String)
        Dim thang = CInt(sThang)
        Dim nam = CInt(sNam)
        With UltraGrid1.DisplayLayout.Bands(0)
            Select Case thang
                Case 1, 3, 5, 7, 8, 10, 12
                    tongsocot = 33
                    .Columns("GC29").Hidden = False
                    .Columns("GC30").Hidden = False
                    .Columns("GC31").Hidden = False
                Case 2
                    If nam Mod 4 = 0 Then
                        .Columns("GC29").Hidden = False
                        .Columns("GC30").Hidden = True
                        .Columns("GC31").Hidden = True
                        tongsocot = 31


                    Else
                        .Columns("GC29").Hidden = True
                        .Columns("GC30").Hidden = True
                        .Columns("GC31").Hidden = True
                        tongsocot = 30

                    End If
                Case 4, 6, 9, 11
                    .Columns("GC29").Hidden = False
                    .Columns("GC30").Hidden = False
                    .Columns("GC31").Hidden = True
                    tongsocot = 32
                   

                    
            End Select
        End With

    End Sub
    
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'e.Layout.Bands(0).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
        Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(1)
        On Error Resume Next
        e.Layout.Bands(0).Summaries.RemoveAt(0)
        Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        ' Me.UltraGrid1.Text = "DANH SÁCH THỐNG KÊ NGÀY CÔNG"

        e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"
        'Sort
        e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle

        'Filter
        e.Layout.Override.FilterUIType = FilterUIType.FilterRow
        e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        e.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        'Column Chooser

        e.Layout.Override.RowSelectors = DefaultableBoolean.True
        e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
    End Sub
    Private Sub XuatExcel_TieuDe1()
        Dim ngaytam As String = Me.dtpNgay.Text.ToString()
        Dim sChuoiTieuDe As String = ""
        sChuoiTieuDe = "" & obj.NAM & "年" & obj.THANG & "月份各廠實際日工時統計表 (單位:線)"
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim myWorkbook As New Workbook
            Dim myWorksheet As Worksheet
            Try
                myWorksheet = myWorkbook.Worksheets.Add("TK")
                Dim sheet As Worksheet = myWorkbook.Worksheets("TK")

                Me.UltraGrid1.DisplayLayout.Bands(0).Summaries.Clear()

                ''======= GÁN VỊ TRÍ CỘT CỐ ĐỊNH TRÊN GRID ============''

                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("X_MA_").Header.VisiblePosition = 0
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("DV_MA").Header.VisiblePosition = 1
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC1").Header.VisiblePosition = 2
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC2").Header.VisiblePosition = 3
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC3").Header.VisiblePosition = 4
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC4").Header.VisiblePosition = 5
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC5").Header.VisiblePosition = 6
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC6").Header.VisiblePosition = 7
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC7").Header.VisiblePosition = 8
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC8").Header.VisiblePosition = 9
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC9").Header.VisiblePosition = 10
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC10").Header.VisiblePosition = 11
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC11").Header.VisiblePosition = 12
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC12").Header.VisiblePosition = 13
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC13").Header.VisiblePosition = 14
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC14").Header.VisiblePosition = 15
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC15").Header.VisiblePosition = 16
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC16").Header.VisiblePosition = 17
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC17").Header.VisiblePosition = 18
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC18").Header.VisiblePosition = 19
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC19").Header.VisiblePosition = 20
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC20").Header.VisiblePosition = 21
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC21").Header.VisiblePosition = 22
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC22").Header.VisiblePosition = 23
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC23").Header.VisiblePosition = 24
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC24").Header.VisiblePosition = 25
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC25").Header.VisiblePosition = 26
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC26").Header.VisiblePosition = 27
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC27").Header.VisiblePosition = 28
                Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC28").Header.VisiblePosition = 29
                If tongsocot = 30 Then
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("TC").Header.VisiblePosition = 30
                End If
                If tongsocot = 31 Then
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC29").Header.VisiblePosition = 30
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("TC").Header.VisiblePosition = 31
                End If
                If tongsocot = 32 Then
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC29").Header.VisiblePosition = 30
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC30").Header.VisiblePosition = 31
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("TC").Header.VisiblePosition = 32
                End If
                If tongsocot = 33 Then
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC29").Header.VisiblePosition = 30
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC30").Header.VisiblePosition = 31
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("GC31").Header.VisiblePosition = 32
                    Me.UltraGrid1.DisplayLayout.Bands(0).Columns("TC").Header.VisiblePosition = 33
                End If

                myWorksheet.Rows(0).Cells(2).Value = sChuoiTieuDe
                myWorksheet.Rows(0).Cells(2).CellFormat.Font.Color = Color.Black
                myWorksheet.Rows(0).Cells(2).CellFormat.Font.Name = "Arial"
                myWorksheet.Rows(0).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.CenterAcrossSelection
                myWorksheet.Rows(0).Cells(2).CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True
                myWorksheet.Rows(0).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                myWorksheet.Rows(0).Cells(2).CellFormat.WrapText = ExcelDefaultableBoolean.True
                myWorksheet.Rows(0).Cells(2).CellFormat.Font.Height = 300


                myWorksheet.Rows(0).Cells(2).Value = sChuoiTieuDe

                Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, myWorksheet, 1, 0)

                For i = 0 To 1
                    For j = 0 To tongsocot
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Color = Color.Black
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Name = "Arial"
                        myWorksheet.Rows(i).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(i).Cells(j).CellFormat.WrapText = ExcelDefaultableBoolean.True
                        myWorksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = VerticalCellAlignment.Center
                        myWorksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        If i = 0 Then
                            myWorksheet.Rows(i).Cells(j).CellFormat.Font.Height = 450
                            myWorksheet.Rows(i).Height = 800
                        Else
                            myWorksheet.Rows(i).Cells(j).CellFormat.Font.Height = 200
                            myWorksheet.Rows(i).Height = 500
                        End If
                        myWorksheet.Rows(i).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        myWorksheet.Rows(i).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                    Next
                Next
             


                myWorksheet.Rows(1).Cells(0).Value = " 廠別/單位 "
                myWorksheet.Rows(1).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(1).Value = " 線別 "
                myWorksheet.Rows(1).Cells(1).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(2).Value = obj.THANG & "/1"
                myWorksheet.Rows(1).Cells(2).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(3).Value = obj.THANG & "/2"
                myWorksheet.Rows(1).Cells(3).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(4).Value = obj.THANG & "/3"
                myWorksheet.Rows(1).Cells(4).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(5).Value = obj.THANG & "/4"
                myWorksheet.Rows(1).Cells(5).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(6).Value = obj.THANG & "/5"
                myWorksheet.Rows(1).Cells(6).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(7).Value = obj.THANG & "/6"
                myWorksheet.Rows(1).Cells(7).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(8).Value = obj.THANG & "/7"
                myWorksheet.Rows(1).Cells(8).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(9).Value = obj.THANG & "/8"
                myWorksheet.Rows(1).Cells(9).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(10).Value = obj.THANG & "/9"
                myWorksheet.Rows(1).Cells(10).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(11).Value = obj.THANG & "/10"
                myWorksheet.Rows(1).Cells(11).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(12).Value = obj.THANG & "/11"
                myWorksheet.Rows(1).Cells(12).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(13).Value = obj.THANG & "/12"
                myWorksheet.Rows(1).Cells(13).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(14).Value = obj.THANG & "/13"
                myWorksheet.Rows(1).Cells(14).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(15).Value = obj.THANG & "/14"
                myWorksheet.Rows(1).Cells(15).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(16).Value = obj.THANG & "/15"
                myWorksheet.Rows(1).Cells(16).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(17).Value = obj.THANG & "/16"
                myWorksheet.Rows(1).Cells(17).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(18).Value = obj.THANG & "/17"
                myWorksheet.Rows(1).Cells(18).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(19).Value = obj.THANG & "/18"
                myWorksheet.Rows(1).Cells(19).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(20).Value = obj.THANG & "/19"
                myWorksheet.Rows(1).Cells(20).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(21).Value = obj.THANG & "/20"
                myWorksheet.Rows(1).Cells(21).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(22).Value = obj.THANG & "/21"
                myWorksheet.Rows(1).Cells(22).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(23).Value = obj.THANG & "/22"
                myWorksheet.Rows(1).Cells(23).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(24).Value = obj.THANG & "/23"
                myWorksheet.Rows(1).Cells(24).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(25).Value = obj.THANG & "/24"
                myWorksheet.Rows(1).Cells(25).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(26).Value = obj.THANG & "/25"
                myWorksheet.Rows(1).Cells(26).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(27).Value = obj.THANG & "/26"
                myWorksheet.Rows(1).Cells(27).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(28).Value = obj.THANG & "/27"
                myWorksheet.Rows(1).Cells(28).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)

                myWorksheet.Rows(1).Cells(29).Value = obj.THANG & "/28"
                myWorksheet.Rows(1).Cells(29).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                If tongsocot = 30 Then
                    myWorksheet.Rows(1).Cells(30).Value = obj.THANG & "月合計"
                    myWorksheet.Rows(1).Cells(30).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                End If
                If tongsocot = 31 Then
                    myWorksheet.Rows(1).Cells(30).Value = obj.THANG & "/29"
                    myWorksheet.Rows(1).Cells(30).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(31).Value = obj.THANG & "月合計"
                    myWorksheet.Rows(1).Cells(31).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                End If
                If tongsocot = 32 Then
                    myWorksheet.Rows(1).Cells(30).Value = obj.THANG & "/29"
                    myWorksheet.Rows(1).Cells(30).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(31).Value = obj.THANG & "/30"
                    myWorksheet.Rows(1).Cells(31).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(32).Value = obj.THANG & "月合計"
                    myWorksheet.Rows(1).Cells(32).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                End If
                If tongsocot = 33 Then
                    myWorksheet.Rows(1).Cells(30).Value = obj.THANG & "/29"
                    myWorksheet.Rows(1).Cells(30).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(31).Value = obj.THANG & "/30"
                    myWorksheet.Rows(1).Cells(31).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(32).Value = obj.THANG & "/31"
                    myWorksheet.Rows(1).Cells(32).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                    myWorksheet.Rows(1).Cells(33).Value = obj.THANG & "月合計"
                    myWorksheet.Rows(1).Cells(33).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                End If

              

                myWorksheet.Rows(0).Cells(0).Value = ""
                myWorksheet.Rows(0).Cells(0).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(0).Cells(2).CellFormat.FillPatternForegroundColor = Color.FromArgb(255, 255, 255)
                myWorksheet.Rows(0).Cells(2).Value = sChuoiTieuDe


                'mer tiêu đề
                sheet.MergedCellsRegions.Add(0, 2, 0, tongsocot)
                
                'mer 3 cột đầu
                sheet.MergedCellsRegions.Add(0, 0, 0, 1)
              
                BIFF8Writer.WriteWorkbookToFile(myWorkbook, Me.SaveFileDialog1.FileName)
                MessageBox.Show("Đã xuất excel xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btnXuatEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatEX.Click
        XuatExcel_TieuDe1()
    End Sub

End Class