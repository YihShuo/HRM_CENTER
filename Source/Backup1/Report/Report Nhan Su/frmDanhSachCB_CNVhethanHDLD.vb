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

Public Class frmDanhSachCB_CNVhethanHDLD
    'Private khu As String
    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub frmBangTheoDoiNgayPhepCuaCBCNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objReport
        Me.b = New ClsBReport

        obj.ChonBang = 1
        Tabletemp = Me.b.LoadDS(obj)
        ' Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        '' load xuong
        obj.ChonBang = 3
        Tabletemp1 = Me.b.LoadDS(obj)
        ' Tabletemp1.Rows.Add("TCT")
        Me.cbXuong.DataSource = Tabletemp1
        Me.cbXuong.SelectedIndex = 0
        Me.cbXuong.Enabled = False
        Me.cbDonvi.Enabled = False
        Me.cbKhu.Enabled = False

        '' load Khu
        Dim Tabletemp2 = New DataTable
        Tabletemp2.Columns.Add("MA_KHU", GetType(String))
        Tabletemp2.Columns.Add("TEN_KHU", GetType(String))
        Tabletemp2.Rows.Add("KHUA", "KHU A")
        Tabletemp2.Rows.Add("KHUB", "KHU B")
        Tabletemp2.Rows.Add("DVC", "Đơn vị chung")
        Tabletemp2.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbKhu.DataSource = Tabletemp2
        Me.cbKhu.DisplayMember = "TEN_KHU"
        Me.cbKhu.ValueMember = "MA_KHU"
        Me.cbKhu.SelectedIndex = 0

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
        ''toan cong ty
        If Me.cbXuong.Value.ToString() = "" Then
            MessageBox.Show("Bạn chưa chọn xưởng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Me.cbDonvi.Value.ToString() = "" Then
            MessageBox.Show("Bạn chưa chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim Tungay As Date = Me.dtpTuNgay.Value.Day.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Year.ToString()
        Dim Denngay As Date = Me.dtpDenNgay.Value.Day.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Year.ToString()

        If Me.radDonvi.Checked Then
            If cbDonvi.Value.ToString() = "TCT" Then
                'Me.reportID = "3051"
                'Dim strArray As String() = New String() {Denngay, Tungay}
                'Me.para = strArray
                'Me.issysReport = True
                'Me.Refresh()
                'Exit Sub
            Else
                Me.reportID = "3053"
                Dim Donvi As String = Me.cbDonvi.Value.ToString()
                Dim strArray As String() = New String() {Denngay, Tungay, Donvi}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
          
        End If
        If Me.radXuong.Checked Then
            If Me.cbXuong.Value.ToString() = "TCT" Then
                'Me.reportID = "3051"
                'Dim strArray As String() = New String() {Denngay, Tungay}
                'Me.para = strArray
                'Me.issysReport = True
                'Me.Refresh()
                'Exit Sub
            Else
                Me.reportID = "3052"
                Dim Xuong As String = Me.cbXuong.Value.ToString()

                Dim strArray As String() = New String() {Denngay, Tungay, Xuong}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
        End If
        If Me.radKhu.Checked Then
            Me.reportID = "3051"
            Dim Khu As String = Me.cbKhu.Value.ToString()
            Dim strArray As String() = New String() {Denngay, Tungay, Khu}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
    End Sub

    Dim Tabletemp, Tabletemp1, Tabletemp2 As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Dim chSdonvi As Boolean = True

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.txtManv.Enabled = False
        'Me.cbDonvi.Enabled = True
        'Me.chSdonvi = True
    End Sub

    Private Sub rdNvma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.cbDonvi.Enabled = False
        'Me.txtManv.Enabled = True
        'Me.chSdonvi = False
    End Sub



    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        If Me.radXuong.Checked Then
            Me.cbDonvi.Enabled = False
            Me.radDonvi.Checked = False
            Me.cbKhu.Enabled = False
            Me.radKhu.Checked = False
            Me.cbXuong.Enabled = True
        Else
            'Me.cbDonvi.Enabled = True
            'Me.radDonvi.Checked = True
            'Me.cbXuong.Enabled = False
        End If
    End Sub

    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        If Me.radDonvi.Checked Then
            Me.cbDonvi.Enabled = True
            Me.radXuong.Checked = False
            Me.cbXuong.Enabled = False
            Me.cbKhu.Enabled = False
            Me.radKhu.Checked = False
        Else
            'Me.cbDonvi.Enabled = False
            'Me.radXuong.Checked = True
            'Me.cbXuong.Enabled = True
        End If
    End Sub

    Private Sub radKhu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhu.CheckedChanged
        If Me.radKhu.Checked Then
            Me.cbKhu.Enabled = True
            Me.radXuong.Checked = False
            Me.cbXuong.Enabled = False
            Me.cbDonvi.Enabled = False
            Me.radDonvi.Checked = False
        Else
            'Me.cbDonvi.Enabled = False
            'Me.radXuong.Checked = True
            'Me.cbXuong.Enabled = True
        End If
    End Sub
    'Private Sub laygiatrikhu()
    '    If Me.radKhu.Checked Then
    '        khu = Me.cbKhu.Value.ToString()
    '    End If
    'End Sub
End Class