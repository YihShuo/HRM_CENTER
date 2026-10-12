
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
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmDanhSachThongKeNgayCong
    Dim PATH As String
    Friend WithEvents b As New clsBDanhSachThongKeNgayCong
    Dim obj As New objDanhSachThongKeNgayCong
    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.dgrBC.Visible = True
        Me.dgrBC.BringToFront()
        Me.rptReport.Visible = False
        Me.btExcel.Visible = True
        ProgressBar1.Visible = True
        Dim grid As New clsTformatGrid

        obj.ChonBang = 1
        obj.TUNGAY = Me.dtpTuNgay.Value.Year.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Day.ToString()
        obj.DENNGAY = Me.dtpDenNgay.Value.Year.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Day.ToString()
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        Me.PATH = "/layout/DANHSACHSONGAYCONG.xml"
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.PATH), typeControl.Grid, "coldgrhoso")
        Loading()
        Me.ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        If Me.dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Visible = True
            Me.dgrBC.BringToFront()
            Me.rptReport.Visible = False
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Override.RowAlternateAppearance.BackColor = Color.AliceBlue
        Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns(1)
        On Error Resume Next
        e.Layout.Bands(0).Summaries.RemoveAt(0)
        Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("Tổng cộng", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        Me.dgrBC.Text = "DANH SÁCH THỐNG KÊ NGÀY CÔNG"

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

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        If Me.dgrBC.Rows.Count > 0 Then
            e.Row.Cells("STT").Value = e.Row.Index + 1
        End If
    End Sub
   
    Public Sub Loading()
        Me.b = New clsBDanhSachThongKeNgayCong
        Dim tblTemp As DataTable
        Dim i As Integer
        For i = 0 To Me.dgrBC.DataSource.Rows.Count - 1
            If Me.dgrBC.DataSource.Rows.Count > 1 Then
                Me.ProgressBar1.Value = (100 * i) / Me.dgrBC.DataSource.Rows.Count()
                Me.ProgressBar1.Step = (100 * i) / Me.dgrBC.DataSource.Rows.Count()
                Me.ProgressBar1.PerformStep()
            Else
                Me.ProgressBar1.Value = 100
            End If
        Next

    End Sub
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
        Me.rptReport.ReportSource = document
    End Sub

    Private Sub LayThamSo()
        Me.reportID = "SNC"
        dtpTuNgay.Format = DateTimePickerFormat.Short
        dtpDenNgay.Format = DateTimePickerFormat.Short
        Dim Tungay As Date = dtpTuNgay.Value.Day.ToString() + "/" + dtpTuNgay.Value.Month.ToString() + "/" + dtpTuNgay.Value.Year.ToString()
        Dim Denngay As Date = dtpDenNgay.Value.Day.ToString() + "/" + dtpDenNgay.Value.Month.ToString() + "/" + dtpDenNgay.Value.Year.ToString()

        Dim strArray As String() = New String() {Denngay, Tungay}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub

    Dim Tabletemp As DataTable
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Private Sub btXemReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemReport.Click
        Me.rptReport.BringToFront()
        Me.rptReport.Visible = True
        Me.dgrBC.Visible = False
        Me.btExcel.Visible = False
        ProgressBar1.Visible = False

        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub frmDanhSachThongKeNgayCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgrBC.BringToFront()
        Me.rptReport.Visible = True
        Me.btExcel.Visible = False
        ProgressBar1.Visible = False
    End Sub
End Class