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

Imports CrystalDecisions.CrystalReports.Engine
Public Class frmThongKeHD
    Private xuong As String
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Private Sub radKyHDLD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btXemreport_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemreport.Activate
        laygiatrixuong()
        'If Me.radCBCNVKyHDLDDongBHXH.Checked = True Then
        '    Dim report As New FrmReport
        '    Me.ReportID = "689"
        '    report.reportID = Me.ReportID
        '    Dim strArray As String() = New String() {Me.dtpNgay.Text, xuong}
        '    report.para = strArray
        '    report.issysReport = True
        '    report.Show()
        'End If
        'If Me.radTCTYKYHDLD.Checked = True Then
        '    Dim report As New FrmReport
        '    Me.ReportID = "690"
        '    report.reportID = Me.ReportID
        '    Dim strArray As String() = New String() {}
        '    report.para = strArray
        '    report.issysReport = True
        '    report.Show()
        'End If
        If Me.radChuaKyHDLDThang.Checked = True Then

            ''cách 1 hiện trong form
            Me.CrystalReportViewer1.BringToFront()
            Me.CrystalReportViewer1.Visible = True
            Me.dgrBC.Visible = False
            LayThamSo()
            HienThiReport()
            '' cách 2 hiện = form report
            'Dim report As New FrmReport
            'Me.reportID = "691"
            'report.reportID = Me.reportID
            'Dim strArray As String() = New String() {Me.dtpNgay.Text, Me.dtpDenNgay.Text, xuong}
            'report.para = strArray
            'report.issysReport = True
            'report.Show()
        End If
        'If Me.radTheoNgay.Checked = True Then
        '    Dim report As New FrmReport
        '    Me.ReportID = "6911"
        '    report.reportID = Me.ReportID
        '    Dim strArray As String() = New String() {Me.dtpNgay.Text}
        '    report.para = strArray
        '    report.issysReport = True
        '    report.Show()
        'End If
    End Sub
    Private Sub LayThamSo()
        Me.reportID = "691"
        Dim strArray As String() = New String() {Me.dtpNgay.Text, Me.dtpDenNgay.Text, xuong}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
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
        Me.CrystalReportViewer1.ReportSource = document
    End Sub
    Dim flag As Boolean
    Dim obj As New objThongKeHD
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDThongKeHD  ' Nested Types
    Friend WithEvents b As clsBThongKeHD
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    ' Dim ReportID As String
    'Private Sub radDSCNMoi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radDSCNMoi.Checked = True Then
    '        Me.dtpNgay.Enabled = False
    '        Me.dtpDenNgay.Enabled = False
    '    End If
    'End Sub
    'Private Sub radBHXH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radBHXH.Checked = True Then
    '        Me.dtpNgay.Enabled = False
    '        Me.dtpDenNgay.Enabled = False
    '    End If
    'End Sub
    'Private Sub radTCTYKYHDLD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radTCTYKYHDLD.Checked = True Then
    '        Me.dtpNgay.Enabled = False
    '        Me.dtpDenNgay.Enabled = False
    '    End If
    'End Sub

    'Private Sub radCBCNVKyHDLDDongBHXH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radCBCNVKyHDLDDongBHXH.Checked = True Then
    '        Me.dtpNgay.Enabled = True
    '        Me.dtpDenNgay.Enabled = False
    '    End If
    'End Sub

    Private Sub radChuaKyHDLDThang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radChuaKyHDLDThang.CheckedChanged
        If Me.radChuaKyHDLDThang.Checked = True Then
            Me.dtpNgay.Enabled = True
            Me.dtpDenNgay.Enabled = True
        End If
    End Sub

    'Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radTheoNgay.Checked = True Then
    '        Me.dtpNgay.Enabled = True
    '        Me.dtpDenNgay.Enabled = False
    '    End If
    'End Sub

    Private Sub frmThongKeHD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radKhuA.Checked = True
        Me.radChuaKyHDLDThang.Checked = True
    End Sub
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
End Class