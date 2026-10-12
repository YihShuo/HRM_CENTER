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

Public Class frmBangTheoDoiNgayPhepCuaCBCNV

    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub

    Private Sub frmBangTheoDoiNgayPhepCuaCBCNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Visible = False
        cbDonvi.Visible = False
        Dim obj As New objReport
        Dim i As Integer
        obj.ChonBang = 1
        Me.b = New ClsBReport
        Tabletemp = Me.b.LoadDS(obj)
        Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Tabletemp
        'Me.cbDonvi.SelectedIndex = 0

        obj.ChonBang = 3
        Me.b = New ClsBReport
        Tabletemp1 = Me.b.LoadDS(obj)
        Tabletemp1.Rows.Add("TCT")
        Me.cbXuong.DataSource = Tabletemp1
        'Me.cbXuong.SelectedIndex = 0
        Me.cbXuong.Enabled = False
        '''add combo nam lay theo bang thang-nam nhap trong danh muc
        obj.ChonBang = 4
        Me.b = New ClsBReport
        Tabletemp2 = Me.b.LoadDS(obj)
        If Me.Tabletemp2.Rows.Count > 0 Then
            For i = 0 To Me.Tabletemp2.Rows.Count - 1
                Me.dtpNam.Items.Add(Tabletemp2.Rows(i).Item(0).ToString())
            Next
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
        Me.rptNhansu.ReportSource = document
    End Sub

    Public Sub TrangThaiDieuKien()
        Me.cbXuong.Enabled = chkStateXuong
    End Sub

    Public Sub TrangThaiDieuKienCheck()
        If Me.chkXuong.Checked = False Then
            Me.cbXuong.ReadOnly = True
        End If
        If (Me.chkXuong.Checked = True) Then
            Me.cbDonvi.ReadOnly = True
            Me.cbXuong.ReadOnly = False
            Me.cbDonvi.Clear()
        End If
    End Sub

    Private Sub chkXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXuong.CheckedChanged
        If (Me.chkXuong.Checked = False) Then
            Me.cbXuong.Text = ""
            Me.cbDonvi.ReadOnly = False
        End If
        chkStateXuong = Me.chkXuong.Checked
        Me.TrangThaiDieuKien()
        Me.TrangThaiDieuKienCheck()
    End Sub

    Private Sub LayThamSo()
        Me.TrangThaiDieuKienCheck()
        If Me.cbXuong.Text <> "" Then
            Me.reportID = "305"
            Dim Nam As String = Me.dtpNam.Text
            Dim Xuong As String = Me.cbXuong.Value.ToString()

            Dim strArray As String() = New String() {Nam, Xuong}
            Me.para = strArray
            Me.issysReport = True
            Me.Refresh()
            Exit Sub
            'ElseIf Me.cbDonvi.Text <> "" Then
            '    Me.reportID = "001"
            '    Dim Nam As String = Me.dtpNam.Text
            '    Dim Donvi As String = Me.cbDonvi.Value.ToString()

            '    Dim strArray As String() = New String() {Nam, Donvi}
            '    Me.para = strArray
            '    Me.issysReport = True
            '    Me.Refresh()
            '    Exit Sub
        End If
    End Sub

    Dim chkStateXuong As Boolean
    Dim Tabletemp As DataTable
    Dim Tabletemp1 As DataTable
    Dim Tabletemp2 As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
End Class