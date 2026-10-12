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
Public Class frm_BangLuong
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frm_BangLuong_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub frm_BangLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdDonvi.Checked = True

        If Me.LoaiReport = 1 Then
            Me.Text = "Report bảng lương"
        End If
        If Me.LoaiReport = 2 Then
            Me.Text = "Report phiếu lương cá nhân"
        End If

        Me.dtpNgay.Value = Now
        Dim obj As New objChamcongMain
        obj.ChonBang = 1
        Me.b = New clsBChamcongMain
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0
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

    Private Sub LayThamSo()

        'Report cham cong thang
        If Me.LoaiReport = 1 Then
            Me.Text = "Report bảng lương"
            'Chon rdDonvi
            Me.reportID = "9998"
            Dim THANG As String = Me.dtpNgay.Text
            Dim dv_ma As String = Me.cbDonvi.Value.ToString()

            If (dv_ma <> "") Then
                Dim strArray As String() = New String() {THANG, dv_ma}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
            'MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            'Chon rdNghiviec
            'If Me.rdDonviNV.Checked = True Or Me.rdDonviNV01.Checked = True Then
            '    Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
            '    Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
            '    Dim ngayNV As Date = "15" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
            '    Dim NV As String = ""

            '    If Me.rdDonviNV.Checked = True Then
            '        NV = "NV"
            '    ElseIf Me.rdDonviNV01.Checked = True Then
            '        NV = "NV01"
            '    End If

            '    If Me.rpmoi = 1 Then
            '        Me.reportID = "9001"
            '    Else
            '        Me.reportID = "3011"
            '    End If

            '    Dim strArray As String() = New String() {Tungay, Denngay, NV, ngayNV}
            '    Me.para = strArray
            '    Me.issysReport = True
            '    Me.Refresh()
            '    Exit Sub
            'End If
            'Chon rdNghiviec

        End If

        If Me.LoaiReport = 2 Then
            'Me.btnXemPromaz.Enabled = True
            Me.Text = "Report phiếu lương cá nhân"
            Me.reportID = "9997"
            Dim THANG As String = Me.dtpNgay.Text
            Dim dv_ma As String = Me.cbDonvi.Value.ToString()
            If (dv_ma <> "" And dv_ma <> "TCT") Then
                Dim strArray As String() = New String() {THANG, dv_ma}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
            MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
        End If

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

    Private Sub btXem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub rptBangLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptBangLuong.Load

    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged

    End Sub
End Class