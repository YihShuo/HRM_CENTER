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

Public Class frmDanhSachHetHangHDKyLai

    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub frmBangTheoDoiNgayPhepCuaCBCNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objReport
        Me.b = New ClsBReport
        Me.radXuong.Checked = True
        Me.radKhu.Checked = False
        Me.radDonvi.Checked = False
        Me.cbKhu.Enabled = False
        Me.cbDonvi.Enabled = False
        Me.cbXuong.Enabled = True
        obj.ChonBang = 1
        Tabletemp = Me.b.LoadDS(obj)
        'Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Tabletemp
        If Tabletemp.Rows.Count > 0 Then
            Me.cbDonvi.SelectedIndex = 0
        End If
        '' load xuong
        obj.ChonBang = 3
        Tabletemp1 = Me.b.LoadDS(obj)
        'Tabletemp1.Rows.Add("TCT")
        Me.cbXuong.DataSource = Tabletemp1
        Me.radXuong.Checked = True
        If Tabletemp1.Rows.Count > 0 Then
            Me.cbXuong.SelectedIndex = 0
        End If
        ''load khu
        Tabletemp2 = New DataTable
        Tabletemp2.Columns.Add("MAKHU", GetType(String))
        Tabletemp2.Columns.Add("TENKHU", GetType(String))
        Tabletemp2.Rows.Add("A", "KHU A")
        Tabletemp2.Rows.Add("B", "KHU B")
        Tabletemp2.Rows.Add("DVC", "KHU DVC")
        Tabletemp2.Rows.Add("TCT", "全部公司Toàn công ty")

        Me.cbKhu.DataSource = Tabletemp2
        If Tabletemp2.Rows.Count > 0 Then
            Me.cbKhu.SelectedIndex = 0
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
        document.ReportOptions.EnableSaveDataWithReport = False
        Me.rptChamcong.ReportSource = document

    End Sub

    Private Sub LayThamSo()
        Dim Tungay As Date = Me.dtpTuNgay.Value.Year.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Day.ToString()
        Dim Denngay As Date = Me.dtpDenNgay.Value.Year.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Day.ToString()
        Dim strArray As String()

        If Me.radXuong.Checked Then
            Select Case Me.cbXuong.Value
                'Case "TCT" ''TOÀN CÔNG TY NÚT RADIPO XƯỞNG
                '    Xuong_khu = "TCT"
                '    Me.reportID = "30551"
                '    strArray = New String() {Tungay, Denngay}
                Case Else
                    Me.reportID = "30552"
                    strArray = New String() {Tungay, Denngay, Me.cbXuong.Value.ToString()}

            End Select
        End If

        If Me.radDonvi.Checked Then
            Select Case Me.cbDonvi.Value
                Case "TCT" ''TOÀN CÔNG TY NÚT RADIPO ĐƠN VỊ
                    Me.reportID = "30551"
                    strArray = New String() {Tungay, Denngay}
                Case Else ''ĐƠN VỊ
                    Me.reportID = "3055"
                    strArray = New String() {Tungay, Denngay, Me.cbDonvi.Value}
            End Select
        End If

        If Me.radKhu.Checked Then
            Select Case Me.cbKhu.Value
                Case "TCT" ''TOÀN CÔNG TY  
                    Me.reportID = "30551"
                    strArray = New String() {Tungay, Denngay}
                Case Else ''KHU
                    Me.reportID = "30553"
                    strArray = New String() {Tungay, Denngay, Me.cbKhu.Value.ToString()}
            End Select
        End If
        Me.para = strArray
        Me.issysReport = True
        Me.rptChamcong.Refresh()
        Me.Refresh()
    End Sub

    Dim Tabletemp, Tabletemp1, Tabletemp2 As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        Me.cbXuong.Enabled = Me.radXuong.Checked
    End Sub
    Private Sub radKhu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radKhu.CheckedChanged
        Me.cbKhu.Enabled = Me.radKhu.Checked
    End Sub
    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        Me.cbDonvi.Enabled = Me.radDonvi.Checked
    End Sub
    Private Sub LayThamSo2()
        Dim Tungay As Date = Me.dtpTuNgay.Value.Year.ToString() + "/" + Me.dtpTuNgay.Value.Month.ToString() + "/" + Me.dtpTuNgay.Value.Day.ToString()
        Dim Denngay As Date = Me.dtpDenNgay.Value.Year.ToString() + "/" + Me.dtpDenNgay.Value.Month.ToString() + "/" + Me.dtpDenNgay.Value.Day.ToString()
        Dim strArray As String()

        If Me.radXuong.Checked Then
            Select Case Me.cbXuong.Value
                Case Else
                    Me.reportID = "30552TL"
                    strArray = New String() {Tungay, Denngay, Me.cbXuong.Value.ToString()}
            End Select
        End If

        If Me.radDonvi.Checked Then
            Select Case Me.cbDonvi.Value
                Case "TCT" ''TOÀN CÔNG TY NÚT RADIPO ĐƠN VỊ
                    Me.reportID = "30551TL"
                    strArray = New String() {Tungay, Denngay}
                Case Else ''ĐƠN VỊ
                    Me.reportID = "3055TL"
                    strArray = New String() {Tungay, Denngay, Me.cbDonvi.Value}
            End Select
        End If

        If Me.radKhu.Checked Then
            Select Case Me.cbKhu.Value
                Case "TCT" ''TOÀN CÔNG TY  
                    Me.reportID = "30551TL"
                    strArray = New String() {Tungay, Denngay}
                Case Else ''khu
                    Me.reportID = "30553TL"
                    strArray = New String() {Tungay, Denngay, cbKhu.Value.ToString()}
            End Select
        End If
        Me.para = strArray
        Me.issysReport = True
        Me.rptChamcong.Refresh()
        Me.rptChamcong.Update()
        Me.Update()
        Me.Refresh()
    End Sub
    Private Sub btDSTangLuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDSTangLuong.Click
        Me.LayThamSo2()
        Me.HienThiReport()
    End Sub
End Class