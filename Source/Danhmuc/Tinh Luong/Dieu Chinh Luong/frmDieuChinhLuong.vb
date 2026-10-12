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
Public Class frmDieuChinhLuong
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBDieuChinhLuong
        Me.Path = "/layout/DieuChinhLuong.xml"
        obj.NamThang = Me.cbNamThang.Text
        obj.DonVi = Me.cbDonvi.Text
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
    End Sub
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        Me.methodLoad()
    End Sub
    Dim flag As Boolean
    Dim obj As New objDieuChinhLuong
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDDieuChinhLuong  ' Nested Types
    Friend WithEvents b As clsBDieuChinhLuong
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim ReportID As String
    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate

        If Me.cbNamThang.Text = "2010-01" Then
            Dim report As New FrmReport
            Me.ReportID = "695"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2010-02" Then
            Dim report As New FrmReport
            Me.ReportID = "701"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2009-02" Then
            Dim report As New FrmReport
            Me.ReportID = "695"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2009-01" Then
            Dim report As New FrmReport
            Me.ReportID = "695"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2011-01" Then
            Dim report As New FrmReport
            Me.ReportID = "695"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2011-02" Then
            Dim report As New FrmReport
            Me.ReportID = "701"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2011-07" Then
            Dim report As New FrmReport
            Me.ReportID = "701"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.cbNamThang.Text = "2011-10" Then
            Dim report As New FrmReport
            Me.ReportID = "701"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbNamThang.Text, Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
    End Sub

    Private Sub frmDieuChinhLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        obj.ChonBang = 2
        'Load Don Vi
        Me.b = New clsBDieuChinhLuong
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub cbNamThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNamThang.ValueChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class