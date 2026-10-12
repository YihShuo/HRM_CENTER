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
Public Class frmReportBangCongKhoaSo

    Public bLoad As Boolean = False
    Private Sub frmReportBangCongKhoaSo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objBangCongKhoaSo
        Me.b = New clsBBangCongKhoaSo
        If Me.LoaiReport = 1 Then
            Me.Text = "Report chấm công tháng"
            Dim NgayCC As Date
            NgayCC = Me.dtpNgay.Value

            obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
            obj.ChonBang = 1
            Me.Tabletemp = Me.b.LoadDS(obj)
            If Me.Tabletemp.Rows.Count > 0 Then
                Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                Me.cbDonvi.DataSource = Me.Tabletemp
                Me.cbDonvi.DisplayMember = "DV_TEN"
                Me.cbDonvi.ValueMember = "DV_MA"
                Me.cbDonvi.SelectedIndex = 0
            Else
                Me.cbDonvi.DataSource = Nothing
                Me.rptChamcong.ReportSource = Nothing
                Me.cbDonvi.Text = ""
            End If

        End If
        If Me.LoaiReport = 2 Then
            Me.Text = "Report công cá nhân"
        End If
        bLoad = True
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
            Me.Text = "Report chấm công tháng"
            Me.reportID = "1KS"
        End If

        Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
        Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
        Dim dv_ma As String = Me.cbDonvi.Value.ToString()

        If (dv_ma <> "") Then
            Dim strArray As String() = New String() {Tungay, Denngay, dv_ma}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
    End Sub
    Public flag As Integer

    Public Shared rpmoi As Integer
    Public Shared LoaiReport As Integer
    Dim Tabletemp As DataTable
    Dim b As clsBBangCongKhoaSo
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String

    Private Sub btnXemPromaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemPromaz.Click
        If Me.cbDonvi.Text <> "" Then
            Me.rpmoi = 1
            Me.LayThamSo()
            Me.HienThiReport()
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        If bLoad = True Then
            Dim obj As New objBangCongKhoaSo
            Me.b = New clsBBangCongKhoaSo
            If Me.LoaiReport = 1 Then
                Me.Text = "Report chấm công tháng"
                Dim NgayCC As Date
                NgayCC = Me.dtpNgay.Value

                obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
                obj.ChonBang = 1
                Me.Tabletemp = Me.b.LoadDS(obj)
                If Me.Tabletemp.Rows.Count > 0 Then
                    Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
                    Me.cbDonvi.DataSource = Me.Tabletemp
                    Me.cbDonvi.DisplayMember = "DV_TEN"
                    Me.cbDonvi.ValueMember = "DV_MA"
                    Me.cbDonvi.SelectedIndex = 0
                Else
                    Me.cbDonvi.DataSource = Nothing
                    Me.rptChamcong.ReportSource = Nothing
                    Me.cbDonvi.Text = ""
                End If

            End If
        End If
    End Sub
End Class