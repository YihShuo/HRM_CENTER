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
Public Class frmDanhSachCongViec
    Private xuong As String
    Private Sub laygiatrixuong()
        If Me.radKhuA.Checked Then
            xuong = "KHUA"
        End If
        If Me.radKhuB.Checked Then
            xuong = "KHUB"
        End If
        If Me.radDVC.Checked Then
            xuong = "DVC"
        End If
        If Me.radTCT.Checked Then
            xuong = "TCT"
        End If
    End Sub
    Public Sub methodLoad()
        laygiatrixuong()
        obj.XUONG = xuong
        Dim grid As New clsTformatGrid
        Me.b = New clsBDanhSachCongViec
        Me.Path = "/layout/DanhSachPhienDich.xml"
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrphiendich")

    End Sub
    Public Sub methodLoad2()
        laygiatrixuong()
        obj.XUONG = xuong
        Dim grid As New clsTformatGrid
        Me.b = New clsBDanhSachCongViec
        Me.Path = "/layout/DanhSachCanBo.xml"
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrphiendich")

    End Sub
    Public Sub methodLoad3()

        laygiatrixuong()
        obj.XUONG = xuong
        Dim grid As New clsTformatGrid
        Me.b = New clsBDanhSachCongViec
        Me.Path = "/layout/DanhSachCB-CNV KY HDLD.xml"
        obj.ChonBang = 3
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrphiendich")

    End Sub
    Private Sub frmDanhSachCongViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radKhuA.Checked = True
        Me.radPhienDich.Checked = True
    End Sub

    Private Sub radPhienDich_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPhienDich.CheckedChanged
        'If Me.radPhienDich.Checked = True Then
        '    ' Load danh sach phien dich
        '    Me.methodLoad()
        '    Me.btExcel.Enabled = True
        '    Me.btXemreport.Enabled = True

        'End If
    End Sub

    Private Sub radCanBo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCanBo.CheckedChanged
        'If Me.radCanBo.Checked = True Then

        '    ' Load danh sach can bo
        '    Me.methodLoad2()
        '    Me.btExcel.Enabled = True
        '    Me.btXemreport.Enabled = True

        'End If
    End Sub

    Private Sub radKHDLD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKHDLD.CheckedChanged
        'If Me.radKHDLD.Checked = True Then

        '    ' Load danh sach hop dong
        '    Me.methodLoad3()
        '    Me.btExcel.Enabled = True
        '    Me.btXemreport.Enabled = True

        'End If
    End Sub
    Public Sub Loading()

        Me.b = New clsBDanhSachCongViec
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
    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        If Me.radPhienDich.Checked = True Then
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        End If
        If Me.radCanBo.Checked = True Then
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        End If
        If Me.radKHDLD.Checked = True Then
            Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
                Process.Start(Me.SaveFileDialog1.FileName)
            End If
        End If
    End Sub
    Dim ReportID As String
    Private Sub btXemreport_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemreport.Activate
        laygiatrixuong()
        If Me.radPhienDich.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "582"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {xuong}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
        If Me.radCanBo.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "583"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {xuong}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
        If Me.radKHDLD.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "584"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {xuong}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
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
    Private Sub dgrBC_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
    Dim flag As Boolean
    Dim obj As New objDanhSachCongViec
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDDanhSachCongViec  ' Nested Types
    Friend WithEvents b As clsBDanhSachCongViec
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    

    Private Sub loadluoi()
        If Me.radPhienDich.Checked = True Then
            ' Load danh sach phien dich
            Me.methodLoad()
            Me.btExcel.Enabled = True
            Me.btXemreport.Enabled = True
        End If
        If Me.radCanBo.Checked = True Then
            ' Load danh sach can bo
            Me.methodLoad2()
            Me.btExcel.Enabled = True
            Me.btXemreport.Enabled = True
        End If
        If Me.radKHDLD.Checked = True Then
            ' Load danh sach hop dong
            Me.methodLoad3()
            Me.btExcel.Enabled = True
            Me.btXemreport.Enabled = True
        End If
    End Sub
    Private Sub radKhuA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuA.CheckedChanged
        'loadluoi()
    End Sub
    Private Sub radKhuB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhuB.CheckedChanged
        'loadluoi()

    End Sub

    Private Sub radTCT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTCT.CheckedChanged
        'loadluoi()
    End Sub

    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        loadluoi()
        ProgressBar1.Visible = True
        Loading()
        Me.ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub
End Class