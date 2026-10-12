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

Public Class frmQuyetdinhTV
    Public obj As New clsDQuyetdinhTV
    Private Sub rptqdtv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptqdtv.Load

    End Sub
    Private Sub frmQuyetdinhTV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LayThamSo()
        Dim nv_ma As String = obj.manv
        Dim ngay As Date = obj.ngay
        Dim soquyetdinh As String = obj.soquyetdinh
        Me.reportID = "QDTV"
        Dim strArray As String() = New String() {nv_ma, ngay, soquyetdinh}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub LayThamSoPHLL()
        Dim nv_ma As String = obj.manv
        Dim ngay As Date = obj.ngay
        Dim soquyetdinh As String = obj.soquyetdinh
        Me.reportID = "PHLL"
        Dim strArray As String() = New String() {nv_ma, ngay, soquyetdinh}
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
        Me.rptqdtv.ReportSource = document
    End Sub
    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()

    Private Sub btnin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnin.Click
        obj.manv = "'" & txtsothe.Text.Trim.ToString() & "'"
        obj.soquyetdinh = txtSoQuyetDinh.Text.Trim.ToString()
        obj.ngay = dtpk.Value.Year.ToString() + "/" + dtpk.Value.Month.ToString() + "/" + dtpk.Value.Day.ToString()
        LayThamSo()
        HienThiReport()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        obj.manv = txtsothe.Text.Trim.ToString()
        obj.soquyetdinh = txtSoQuyetDinh.Text.Trim.ToString()
        obj.ngay = dtpk.Value
        LayThamSoPHLL()
        HienThiReport()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtSoQuyetDinh_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoQuyetDinh.ValueChanged

    End Sub

    Private Sub dtpk_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpk.ValueChanged

    End Sub
End Class