Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
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
Public Class frmThongKeDanhSachCB_CNVBiKyLuat
    Private Sub frmThongKeDanhSachCB_CNVBiKyLuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radDSKL.Checked = True

    End Sub
    Public Sub methodLoad()
        ''danh sach ki luat tong hop tung don vi-tung loai kyluat
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeDanhSachCB_CNVBiKyLuat
        Me.Path = "/layout/DanhSachKyLuat.xml"
        Dim NGAY As Date = Me.dtpNgaybatdau.Text
        Dim NGAYBD As String = NGAY.Year().ToString + "/" + NGAY.Month().ToString + "/" + NGAY.Day().ToString
        obj.NBD = NGAYBD

        Dim NGAY2 As Date = Me.dtpNgayketthuc.Text
        Dim NGAYKT As String = NGAY2.Year().ToString + "/" + NGAY2.Month().ToString + "/" + NGAY2.Day().ToString
        obj.NKT = NGAYKT
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub
    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeDanhSachCB_CNVBiKyLuat
        Me.Path = "/layout/KyLuatKhienTrach.xml"
        Dim NGAY As Date = Me.dtpNgaybatdau.Text
        Dim NGAYBD As String = NGAY.Year().ToString + "/" + NGAY.Month().ToString + "/" + NGAY.Day().ToString
        obj.NBD = NGAYBD

        Dim NGAY2 As Date = Me.dtpNgayketthuc.Text
        Dim NGAYKT As String = NGAY2.Year().ToString + "/" + NGAY2.Month().ToString + "/" + NGAY2.Day().ToString
        obj.NKT = NGAYKT
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub

    Public Sub methodLoad3()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeDanhSachCB_CNVBiKyLuat
        Me.Path = "/layout/KyLuatKDTGNL.xml"
        Dim NGAY As Date = Me.dtpNgaybatdau.Text
        Dim NGAYBD As String = NGAY.Year().ToString + "/" + NGAY.Month().ToString + "/" + NGAY.Day().ToString
        obj.NBD = NGAYBD

        Dim NGAY2 As Date = Me.dtpNgayketthuc.Text
        Dim NGAYKT As String = NGAY2.Year().ToString + "/" + NGAY2.Month().ToString + "/" + NGAY2.Day().ToString
        obj.NKT = NGAYKT
        obj.ChonBang = 3
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub

    Public Sub methodLoad4()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThongKeDanhSachCB_CNVBiKyLuat
        Me.Path = "/layout/KyLuatST.xml"
        Dim NGAY As Date = Me.dtpNgaybatdau.Text
        Dim NGAYBD As String = NGAY.Year().ToString + "/" + NGAY.Month().ToString + "/" + NGAY.Day().ToString
        obj.NBD = NGAYBD

        Dim NGAY2 As Date = Me.dtpNgayketthuc.Text
        Dim NGAYKT As String = NGAY2.Year().ToString + "/" + NGAY2.Month().ToString + "/" + NGAY2.Day().ToString
        obj.NKT = NGAYKT
        obj.ChonBang = 4
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub

    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        If Me.radDSKL.Checked = True Then
            Me.methodLoad()
        ElseIf Me.radKLKT.Checked = True Then
            Me.methodLoad2()
        ElseIf Me.radKLKDTGNL.Checked = True Then
            Me.methodLoad3()
        ElseIf Me.radKLST.Checked = True Then
            Me.methodLoad4()
        End If
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
    Private Sub UltraGridExcelExporter1_CellExporting(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportingEventArgs) Handles UltraGridExcelExporter1.CellExporting
        If e.GridColumn.Key = "STT" Then
            Dim worksheetCell As Infragistics.Excel.WorksheetCell = e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(e.CurrentColumnIndex)
            worksheetCell.Value = e.CurrentRowIndex.ToString
            worksheetCell.CellFormat.BottomBorderStyle = Infragistics.Excel.CellBorderLineStyle.Default
            worksheetCell.CellFormat.BottomBorderColor = Color.Black
            worksheetCell.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Center
            e.Cancel = True
        End If
    End Sub

    Private Sub radKLKT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKLKT.CheckedChanged
        If Me.radKLKT.Checked = False Then
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub

    Private Sub radDSKL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDSKL.CheckedChanged
        If Me.radDSKL.Checked = False Then
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub

    Private Sub radKLKDTGNL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKLKDTGNL.CheckedChanged
        If Me.radKLKDTGNL.Checked = False Then
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub

    Private Sub radKLST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKLST.CheckedChanged
        If Me.radKLST.Checked = False Then
            Me.dgrBC.DataSource = Nothing
        End If
    End Sub

    Private Sub btXemreport_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemreport.Activate
        If Me.radDSKL.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "671"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.dtpNgaybatdau.Text, Me.dtpNgayketthuc.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radKLKT.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "672"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.dtpNgaybatdau.Text, Me.dtpNgayketthuc.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radKLKDTGNL.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "673"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.dtpNgaybatdau.Text, Me.dtpNgayketthuc.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radKLST.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "674"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.dtpNgaybatdau.Text, Me.dtpNgayketthuc.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
    End Sub

    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Dim ReportID As String
    Dim flag As Boolean
    Dim obj As New objThongKeDanhSachCB_CNVBiKyLuat
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDThongKeDanhSachCB_CNVBiKyLuat  ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class