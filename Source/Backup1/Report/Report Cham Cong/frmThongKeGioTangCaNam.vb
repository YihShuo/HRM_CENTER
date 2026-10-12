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


Public Class frmThongKeGioTangCaNam

    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmReportChamCong_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub frmReportChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
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
        Me.rptChamcong.ReportSource = document
    End Sub
    Private Sub LayThamSo()
        'Report cham cong thang
        If Me.LoaiReport = 1 Then
            Me.Text = "Report thống kê tăng ca toàn công ty"
            Me.reportID = "TKT01"
            Dim strArray As String() = New String() {dtpNgay.Text}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
        End If
        If Me.LoaiReport = 2 Then
            ' lay theo don vi dieu dong
            'Me.btnXemPromaz.Enabled = True
            Me.Text = "Report thống kê tăng ca khu A"
            Me.reportID = "TKT02"
            Dim strArray As String() = New String() {dtpNgay.Text}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
        End If
        If Me.LoaiReport = 3 Then
            ' lay theo don vi promaz
            'Me.btnXemPromaz.Enabled = True
            Me.Text = "Report thống kê tăng ca khu B"
            Me.reportID = "TKT03"
            Dim strArray As String() = New String() {dtpNgay.Text}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
        End If
    End Sub
    Public flag As Integer
    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        LoaiReport = 1
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub


    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Dim b As clsBChamcongMain
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub btnXemPromaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemPromaz.Click
        LoaiReport = 2
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub btXemBCPRExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBCPRExcel.Click
        LoaiReport = 3
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
End Class