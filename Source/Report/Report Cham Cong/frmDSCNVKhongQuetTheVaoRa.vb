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
Public Class frmDSCNVKhongQuetTheVaoRa
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmDSCNVKhongQuetTheVaoRa_Load)
        Me.InitializeComponent()
    End Sub
    Private Sub btXemrport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemrport.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub frmDSCNVKhongQuetTheVaoRa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objReport
        obj.ChonBang = 1
        Me.b = New ClsBReport
        Tabletemp = Me.b.LoadDS(obj)
        Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Tabletemp
        Me.cbDonvi.SelectedIndex = 0
        Me.cbDonvi.Enabled = False

    End Sub
    Private Sub HienThiReport()
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = False Then
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
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = False And Me.rdDonvi.Checked = False Then
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
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = False And Me.rdDonvi.Checked = True Then
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
        End If
        If Me.chkKQTRa.Checked = False And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = False Then
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
        End If
        If Me.chkKQTRa.Checked = False And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = True Then
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
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = True Then
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
        End If

        If Me.chkKQTRa.Checked = False And Me.chkKQTVao.Checked = False And Me.rdDonvi.Checked = False Then
            Me.rptChamcong.ReportSource = Nothing
        End If

    End Sub

    Private Sub LayThamSo()
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = False Then
            Me.reportID = "KQTVRTC"
            Dim ngay As Date = Me.dtpNgay.Text

            Dim strArray As String() = New String() {ngay}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = False And Me.rdDonvi.Checked = False Then
            Me.reportID = "KQTRA"
            Dim ngay As Date = Me.dtpNgay.Text

            Dim strArray As String() = New String() {ngay}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = False And Me.rdDonvi.Checked = True Then
            Me.reportID = "KQTRADV"
            Dim Donvi As String = Me.cbDonvi.Value.ToString()
            Dim ngay As Date = Me.dtpNgay.Text
            Dim strArray As String() = New String() {ngay, Donvi}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        If Me.chkKQTRa.Checked = False And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = False Then
            Me.reportID = "KQTVAO"
            Dim ngay As Date = Me.dtpNgay.Text

            Dim strArray As String() = New String() {ngay}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        If Me.chkKQTRa.Checked = False And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = True Then
            Me.reportID = "KQTVAODV"
            Dim Donvi As String = Me.cbDonvi.Value.ToString()
            Dim ngay As Date = Me.dtpNgay.Text
            Dim strArray As String() = New String() {ngay, Donvi}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        If Me.chkKQTRa.Checked = True And Me.chkKQTVao.Checked = True And Me.rdDonvi.Checked = True Then
            Me.reportID = "KQTVRDV"
            Dim Donvi As String = Me.cbDonvi.Value.ToString()
            Dim ngay As Date = Me.dtpNgay.Text
            Dim strArray As String() = New String() {ngay, Donvi}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
    End Sub

    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        If Me.rdDonvi.Checked = True Then
            Me.cbDonvi.Enabled = True
        Else
            Me.cbDonvi.Enabled = False
        End If
    End Sub
End Class