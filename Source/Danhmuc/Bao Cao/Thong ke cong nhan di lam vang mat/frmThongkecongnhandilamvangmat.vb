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

Public Class frmThongkecongnhandilamvangmat
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmTongHopBaoCaoNhanSu_Load)
        Me.InitializeComponent()
    End Sub
    Public Sub methodLoad()
        Dim table As DataTable
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongkecongnhandilamvangmat
        Me.Path = "/layout/TongHopBaoCaoNhanSu.xml"
        Dim NGAY As Date
        NGAY = Me.cbNgaythangnam.Text
        Dim NGAY2 As String
        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAY = NGAY2
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NGAY", obj.NGAY))
        table = Me.b.LoadDanhSach("SP_DSTONGHOPBAOCAONHANSU_S", listpar)
        Me.dgrBC.DataSource = table
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    End Sub
    Private Sub frmTongHopBaoCaoNhanSu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbNgaythangnam.Value = Now
        'methodLoad()

    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxem.Click
        methodLoad()
    End Sub

    Private Sub btXemBC_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Activate

        Dim report As New FrmReport
        Me.ReportID = "TKCNDLVM"
        report.reportID = Me.ReportID
        Dim strArray As String() = New String() {Me.cbNgaythangnam.Text}
        report.para = strArray
        report.issysReport = True
        report.Show()


    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Dim band As UltraGridBand = dgrBC.DisplayLayout.Bands.Item(0)
        'band.Layout.Override.FilterUIType = FilterUIType.FilterRow
        'band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        'band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        'band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        'band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        'band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        'band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        'band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        'band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        'band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        ''Column Chooser

        'band.Layout.Override.RowSelectors = DefaultableBoolean.True
        'band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

        'Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
        'band.Layout.Bands(0).Summaries.Clear()
        'Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng", SummaryType.Sum, columnToSummarize)
        'summary.Appearance.TextHAlign = HAlign.Right

        'Dim columnToSummarize2 As UltraGridColumn = band.Layout.Bands(0).Columns(2)
        'band.Layout.Bands(0).Summaries.Clear()
        'Dim summary2 As SummarySettings = band.Layout.Bands(0).Summaries.Add("Tổng", SummaryType.Sum, columnToSummarize)
        'summary2.Appearance.TextHAlign = HAlign.Right


        'band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        'band.SummaryFooterCaption = "Tổng số: "
        'band = Nothing
    End Sub
    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    ' Khai bao bien toan cuc
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Dim obj As New objThongkecongnhandilamvangmat
End Class