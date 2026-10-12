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
Public Class ThamGiaBHXH
    Dim k As Integer = 0
    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        k = 0
        Me.LayThamSo()
        Me.HienThiReport()
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
        Me.rptThamGiaBHXH.ReportSource = document
    End Sub

    Private Sub LayThamSo()
        Dim Tungay As Date = Me.dtpTuNgay.Value.Year.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Day.ToString()
        Dim Denngay As Date = Me.dtpDenNgay.Value.Year.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Day.ToString()
        If k = 0 Then
            Me.reportID = "BH01"
        Else
            If k = 1 Then
                Me.reportID = "GKSK01"
            Else
                Me.reportID = "DSKSK"
            End If
        End If
        'Dim Tungay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
        'Dim Denngay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()

        Dim strArray As String() = New String() {Denngay, Tungay}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub

    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub btsk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsk.Click
        k = 1
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        k = 2
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
End Class