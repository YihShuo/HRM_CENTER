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
Public Class frmTinhLuongChinh_BangGop

    Private Sub frmTinhLuongChinh_BangGop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdXuongDT.Checked = True
    End Sub
    Private Sub LayThamSo()
        Dim THANG As String = Me.dtpNgay.Text
        If Me.rdXuongDT.Checked Then
            Me.reportID = "99989"
            Dim strArray As String() = New String() {THANG}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If

        If Me.rdXuongDC.Checked Then
            Me.reportID = "99990"
            Dim strArray As String() = New String() {THANG}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
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
        Me.rptBangLuong.ReportSource = document
    End Sub
    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
    'Public Shared rpmoi As Integer
    'Public Shared Loai_Report As Integer
    'Dim Tabletemp As DataTable
    'Dim TabletempXuong As DataTable
    Dim b As clsBChamcongMain
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    'Public strFileName As String


End Class