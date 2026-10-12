Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmtokhaithue
    Public obj As New objToKhaiThue
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        obj.Ngay = dtpNgay.Value
        LayThamSo()
        HienThiReport()
    End Sub
    Private Sub LayThamSo()
        'Dim ngay As String = obj.Ngay
        Dim ngay As Date = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
        Me.reportID = "031"
        Dim strArray As String() = New String() {ngay}
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
            'ProjectData.SetProjectError(exception1)
            'Dim exception As Exception = exception1
            'Interaction.MsgBox(Exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            'Me.Close()
            'ProjectData.ClearProjectError()
            Return
        End Try
        If Me.issysReport Then
            document = report.SetParameter(document, Me.para)
        End If
        Me.rptToKhaiThue.ReportSource = document

    End Sub
    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub rptToKhaiThue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptToKhaiThue.Load

    End Sub
End Class