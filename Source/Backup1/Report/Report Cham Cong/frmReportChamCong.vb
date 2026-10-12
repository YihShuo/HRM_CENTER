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


Public Class frmReportChamCong

    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmReportChamCong_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub frmReportChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdDonvi.Checked = True

        If Me.LoaiReport = 1 Then
            Me.Text = "Report chấm công tháng"
            Me.radManv.Visible = False
            Me.txtManv.Visible = False
        End If
        If Me.LoaiReport = 2 Then
            Me.Text = "Report chấm công tay"
            Me.radManv.Visible = False
            Me.txtManv.Visible = False
        End If
        If Me.LoaiReport = 3 Then
            Me.Text = "Report chấm công cá nhân"
        End If
        If Me.LoaiReport = 4 Then
            Me.Text = "Report chấm cơm"
            Me.radManv.Visible = False
            Me.txtManv.Visible = False
        End If
        If Me.LoaiReport = 5 Then
            Me.Text = "Report chấm công tháng excel"
            Me.radManv.Visible = False
            Me.txtManv.Visible = False
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
        Me.rptChamcong.ReportSource = document
    End Sub

    Private Sub LayThamSo()

        'Report cham cong thang
        If Me.LoaiReport = 1 Then
            Me.Text = "Report chấm công tháng"
            'Chon rdDonvi
            If Me.rdDonvi.Checked = True Then
                If Me.rpmoi = 2 Then
                    Me.reportID = "306"
                ElseIf Me.rpmoi = 4 Then
                    Me.reportID = "3063"
                Else
                    Me.reportID = "301"
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
                'MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            End If
        End If
        If Me.LoaiReport = 2 Then
            If flag = 0 Then
                ' lay theo don vi dieu dong
                'Me.btnXemPromaz.Enabled = True
                Me.Text = "Report chấm công tay"
                Me.reportID = "302"
                Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
                Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
                Dim dv_ma As String = Me.cbDonvi.Value.ToString()

                If (dv_ma <> "" And dv_ma <> "TCT") Then
                    Dim strArray As String() = New String() {Tungay, dv_ma}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                    Exit Sub
                End If
                MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            End If
            If flag = 1 Then
                ' lay theo don vi promaz
                'Me.btnXemPromaz.Enabled = True
                Me.Text = "Report chấm công tay"
                Me.reportID = "3022"
                Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
                Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
                Dim dv_ma As String = Me.cbDonvi.Value.ToString()

                If (dv_ma <> "" And dv_ma <> "TCT") Then
                    Dim strArray As String() = New String() {Tungay, dv_ma}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                    Exit Sub
                End If
                MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            End If
        End If
        If Me.LoaiReport = 3 Then
            If Me.rdDonvi.Checked = True Then
                Me.btnXemPromaz.Enabled = True
                'Me.Text = "Report chấm công cá nhân"
                Me.reportID = "303"
                Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
                Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
                Dim dv_ma As String = Me.cbDonvi.Value.ToString()

                If (dv_ma <> "" And dv_ma <> "TCT") Then
                    Dim strArray As String() = New String() {Tungay, Denngay, dv_ma}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
                    Exit Sub
                End If
                MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
            ElseIf Me.radManv.Checked = True Then
                Me.btnXemPromaz.Enabled = False
                'Me.Text = "Report chấm công cá nhân"
                Me.reportID = "3033"
                Dim Tungay1 As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
                Dim tungay As String = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
                Dim Denngay1 As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay1))
                Dim denngay As String = Denngay1.Day.ToString() + "/" + Denngay1.Month.ToString() + "/" + Denngay1.Year.ToString()
                Dim manv As String = Me.txtManv.Text


                Dim strArray As String() = New String() {denngay, manv, tungay}
                'Dim strArray As String() = New String() {Tungay, Denngay, NV_MA}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
            End If
        End If

        If Me.LoaiReport = 4 Then
            'Me.btnXemPromaz.Enabled = True
            Me.Text = "Report chấm cơm"
            Me.reportID = "304"
            Dim Tungay As Date = "1" + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Year.ToString()
            Dim Denngay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Tungay))
            Dim dv_ma As String = Me.cbDonvi.Value.ToString()

            If (dv_ma <> "" And dv_ma <> "TCT") Then
                Dim strArray As String() = New String() {Tungay, Denngay, dv_ma}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
            MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)
        End If

    End Sub
    Public flag As Integer
    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.rpmoi = 0
        Me.flag = 0
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

    Private Sub btXemrport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.rpmoi = 1
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub btnXemPromaz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemPromaz.Click
        Me.rpmoi = 2
        Me.flag = 1
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub radManv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radManv.CheckedChanged
        If Me.radManv.Checked = True Then
            Me.cbDonvi.Clear()
            Me.cbDonvi.Enabled = False
            Me.txtManv.Enabled = True
            Me.btnXemPromaz.Enabled = False
        End If
    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        If Me.rdDonvi.Checked = True Then
            Me.txtManv.Clear()
            Me.cbDonvi.Enabled = True
            Me.txtManv.Enabled = False
            Me.btnXemPromaz.Enabled = True
            Dim obj As New objChamcongMain
            obj.ChonBang = 1
            Me.b = New clsBChamcongMain
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.SelectedIndex = 0
        End If
    End Sub
    Private Sub btXemBCPRExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBCPRExcel.Click
        Me.rpmoi = 4
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
End Class