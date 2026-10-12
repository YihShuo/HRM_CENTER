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
Public Class frm_BangLuong13
    Inherits Form
    ' Methods
    Public Shared objLuong13 As New objTinhLuong13
    Dim Tabletemp As DataTable
    Friend WithEvents b As clsBTinhLuong13
    Public Shared rpmoi As Integer
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String


    Private Sub btXem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub
    Private Sub LayThamSo()
        If frmTinhLuong13.objLuong13.LOAIBAOCAO = 1 Then
            Me.Text = "Bảng thưởng tháng 13"
            Me.reportID = "777"
        Else
            Me.Text = "Phiếu thưởng tháng 13 cá nhân"
            Me.reportID = "778"
        End If
        Dim Nam As String = Me.dtpNam.Text
        Dim dv_ma As String = Me.cbDonvi.Value.ToString()
        Dim loai As String
        If Me.rdDV.Checked Then
            loai = "1"
        Else
            loai = "2"
        End If

        If dv_ma <> "" Then
            Dim strArray As String() = New String() {dv_ma, Nam, loai}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
        End If
        MessageBox.Show("Bạn phải chọn một đơn vị cụ thể cần xem báo cáo", "Thông Báo", MessageBoxButtons.OK)


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

    Private Sub frm_BangLuong13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdDV.Checked = True
        Me.rdXuong.Checked = True
        loadcombo()
        Me.dtpNam.Value = Now
    End Sub
    Private Sub loadcombo()
        If Me.rdXuong.Checked Then
            Me.Tabletemp = Nothing
            Dim obj As New objTinhLuong13
            obj.CHONBANG = 3
            Me.b = New clsBTinhLuong13
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.ValueMember = "X_MA_"
            Me.cbDonvi.DisplayMember = "X_TEN"
            Me.cbDonvi.SelectedIndex = 0
        Else
            Me.Tabletemp = Nothing
            Dim obj As New objTinhLuong13
            obj.CHONBANG = 1
            Me.b = New clsBTinhLuong13
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.ValueMember = "DV_MA"
            Me.cbDonvi.DisplayMember = "TEN_DV"
            Me.cbDonvi.SelectedIndex = 0
        End If
    End Sub

    Private Sub rdXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdXuong.CheckedChanged
        Me.lblDVXUONG.Text = "Xưởng :"
        loadcombo()
    End Sub

    Private Sub rdDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDV.CheckedChanged
        Me.lblDVXUONG.Text = "Đơn vị :"
        loadcombo()
    End Sub

End Class