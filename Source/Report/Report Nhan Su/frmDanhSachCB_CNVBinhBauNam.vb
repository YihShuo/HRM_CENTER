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

Public Class frmDanhSachCB_CNVBinhBauNam
    Dim obj As New objLyLichNhanVien
    Friend WithEvents c As clsBLyLichNhanVien
    Public Temp As New DataTable
    Dim objkt As New objLyLichNhanVien
    Private flag As Boolean = True
    Private Sub btIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIn.Click
        kiemtradk()
        If flag = True Then
            If Me.rdSoThe.Checked = True Then
                kiemtrasothe()
          End If
            Me.LayThamSo()
            Me.HienThiReport()
       End If
        flag = True
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
            If flag = True Then
                Me.rptChamcong.ReportSource = document
            Else
                Me.rptChamcong.ReportSource = Nothing
            End If
            'Else
            '    document = Nothing
            '    Me.rptChamcong.ReportSource = Nothing
        End If

    End Sub

    Private Sub LayThamSo()
        kiemtradk()
        If flag = True Then
            If Me.cbLoaiBB.Text = "Bình bầu năm" Then
                Me.reportID = "BBN"
                Dim nam As String = Me.cbNam.Text.Trim()
                Dim Donvi As String = Me.cbDonVi.Value.ToString()
                Dim strArray As String() = New String() {nam, Donvi}
                Me.para = strArray
                Me.issysReport = True
                Me.Refresh()
                Exit Sub
            End If
            If Me.cbLoaiBB.Text = "Bình bầu năm chấm tay" Then
                If Me.rdDonVi.Checked = True Then
                    Dim nam As String = Me.cbNam.Text.Trim()
                    Dim Donvi As String = Me.cbDonVi.Value.ToString()
                    If Me.cbDonVi.Value = "TCT" Then
                        Me.reportID = "BBNTAYTCT"
                        Dim strArray As String() = New String() {nam}
                        Me.para = strArray
                        Me.issysReport = True
                        Me.Refresh()
                    Else
                        'Dim nam As String = Me.cbNam.Text.Trim()
                        'Dim Donvi As String = Me.cbDonVi.Value.ToString()
                        Me.reportID = "BBNTAY"
                        Dim strArray As String() = New String() {nam, Donvi}
                        Me.para = strArray
                        Me.issysReport = True
                        Me.Refresh()
                    End If
                ElseIf Me.rdSoThe.Checked = True Then
                    'kiemtradk()
                    Dim nam As String = Me.cbNam.Text.Trim()
                    Dim SoThe As String = Me.txtSoThe.Text.Trim()
                    Me.reportID = "BBNTAYST"
                    Dim strArray As String() = New String() {nam, SoThe}
                    Me.para = strArray
                    Me.issysReport = True
                    Me.Refresh()
               End If
                'Me.reportID = "BBNTAY"
                'Dim nam As String = Me.cbNam.Text.Trim()
                'Dim Donvi As String = Me.cbDonVi.Value.ToString()
                'Dim strArray As String() = New String() {nam, Donvi}
                'Me.para = strArray
                'Me.issysReport = True
                'Me.Refresh()
                Exit Sub
            End If
        End If

    End Sub
    Dim Tabletemp As DataTable
    Dim b As ClsBReport
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Private Sub frmDanhSachCB_CNVBinhBauNam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objReport
        obj.ChonBang = 1
        Me.b = New ClsBReport
        Tabletemp = Me.b.LoadDS(obj)
        Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonVi.DataSource = Tabletemp
        Me.cbDonVi.SelectedIndex = 0
        Me.rdDonVi.Checked = True

        Me.cbNam.Items.Clear()
        For i As Integer = 2009 To Now().Year
            Me.cbNam.Items.Add(i.ToString())
        Next
        dieukhien()
    End Sub
    Private Sub dieukhien()
        If rdSoThe.Checked = True Then
            Me.rdDonVi.Checked = False
            Me.txtSoThe.Enabled = True
            Me.cbDonVi.Enabled = False
        Else
            Me.rdDonVi.Checked = True
            Me.txtSoThe.Enabled = False
            Me.cbDonVi.Enabled = True
        End If
        If rdDonVi.Checked = True Then
            Me.txtSoThe.Clear()
            rdSoThe.Checked = False
            Me.cbDonVi.Enabled = True
            Me.txtSoThe.Enabled = False
        Else
            rdSoThe.Checked = True
            Me.cbDonVi.Enabled = False
            Me.txtSoThe.Enabled = True
        End If
    End Sub
    Private Sub rdSoThe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSoThe.CheckedChanged
        dieukhien()
    End Sub

    Private Sub rdDonVi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonVi.CheckedChanged
        dieukhien()
    End Sub
    Private Sub kiemtrasothe()
        objkt.ChonBang = 1
        Me.c = New clsBLyLichNhanVien
        objkt.MaNV = Me.txtSoThe.Text.Trim()
        Temp = Nothing
        Temp = Me.c.LoadDS(objkt)
        If Temp.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
            MessageBox.Show("Số thẻ không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
    Private Sub kiemtradk()
        Dim nam As String = Me.cbNam.Text.Trim()
        If nam = "" Then
            flag = False
            MessageBox.Show("Vui lòng chọn năm ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
        If rdDonVi.Checked = True Then
            Dim Donvi As String = Me.cbDonVi.Value.ToString()
            If Donvi = "" Then
                flag = False
                MessageBox.Show("Vui lòng chọn đơn vị !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If rdSoThe.Checked Then
            Dim sothe As String = Me.txtSoThe.Text.Trim()
            If sothe = "" Then
                flag = False
                MessageBox.Show("Vui lòng nhập vào số thẻ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If Me.cbLoaiBB.Text = "" Then
            flag = False
            MessageBox.Show("Vui lòng chọn loại bình bầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cbLoaiBB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLoaiBB.ValueChanged
        If Me.cbLoaiBB.Text = "Bình bầu năm" Then
            Me.rdSoThe.Checked = False
            Me.rdSoThe.Enabled = False
        Else
            Me.rdSoThe.Enabled = True
        End If
    End Sub
End Class