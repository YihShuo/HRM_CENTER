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
Public Class frmSoLuongKyLuat
    Dim ReportID As String
    Public para As Object()
    Public issysReport As Boolean
    Public sortAtt As String()
    Public strFileName As String
    Dim kttungay As Date
    Dim ktdenngay As Date
    Dim thoadk As Boolean = True
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmSoLuongKyLuat_Load)
        Me.InitializeComponent()
    End Sub
    Private Sub LayThamSo()
        Me.ReportID = "SLKL"
        Dim Tungay As Date = dtpTuNgay.Value.Year.ToString() + "-" + dtpTuNgay.Value.Month.ToString() + "-" + dtpTuNgay.Value.Day.ToString()
        Dim Denngay As Date = dtpDenNgay.Value.Day.ToString() + "-" + dtpDenNgay.Value.Month.ToString() + "-" + dtpDenNgay.Value.Year.ToString()
        Dim strArray As String() = New String() {Denngay, Tungay}
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
        Me.rptReport.ReportSource = document
    End Sub
    Private Sub frmSoLuongKyLuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTuNgay.Value = Now
        Me.dtpDenNgay.Value = Now
    End Sub
    Private Sub kiemtra()
        kttungay = Me.dtpTuNgay.Value
        ktdenngay = Me.dtpDenNgay.Value
        If kttungay > ktdenngay Then
            MessageBox.Show("Vui lòng chọn từ ngày < đến ngày !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            thoadk = False
        End If
    End Sub
    Private Sub btXemBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBC.Click
        kiemtra()
        If thoadk = True Then
            Me.LayThamSo()
            Me.HienThiReport()
        End If
        thoadk = True
    End Sub
End Class