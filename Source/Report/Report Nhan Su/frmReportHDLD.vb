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


Public Class frmReportHDLD

    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmReportChamCong_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Private Sub frmReportChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Ancombo()
        Me.rdXuong.Checked = True
        Me.cbXuong.Enabled = True

        Dim obj As New objChamcongMain
        'Load Xuong
        obj.ChonBang = 6
        Me.b = New clsBChamcongMain
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.SelectedIndex = 0

        'Load Nganh
        obj.ChonBang = 7
        Me.b = New clsBChamcongMain
        Me.cbNganh.DataSource = Me.b.LoadDS(obj)
        Me.cbNganh.SelectedIndex = 0

        'Load Don Vi
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
        Me.reportID = "901"
        Dim Tungay As Date = Me.dtpTungayKHD.Value
        Dim Denngay As Date = Me.dtpDenngayKHD.Value
        Dim TungayNV As Date = Me.dtpTungayNV.Value
        Dim DenngayNV As Date = Me.dtpDenngayNV.Value
        Dim strArray As String() = New String() {Tungay, Denngay, Tungay, TungayNV, DenngayNV, Me.chsXuong, Me.chsNganh, Me.chsDonvi, Me.cbXuong.Value, Me.cbNganh.Value, Me.cbDonvi.Value}
        Me.para = strArray
        Me.issysReport = True
        Me.Refresh()
        Exit Sub
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Me.LayThamSo()
        Me.HienThiReport()
    End Sub



    'Public Shared rpmoi As Integer
    Dim Tabletemp As DataTable
    Dim b As clsBChamcongMain
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Public strFileName As String
    Public chsXuong As Boolean
    Public chsNganh As Boolean
    Public chsDonvi As Boolean




    Private Sub rdXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdXuong.CheckedChanged
        Me.chsXuong = Me.rdXuong.Checked
        Me.cbXuong.Enabled = Me.rdXuong.Checked
    End Sub

    Private Sub rdNganh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNganh.CheckedChanged
        Me.chsNganh = Me.rdNganh.Checked
        Me.cbNganh.Enabled = Me.rdNganh.Checked
    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        Me.chsDonvi = Me.rdDonvi.Checked
        Me.cbDonvi.Enabled = Me.rdDonvi.Checked
    End Sub


    Private Sub Ancombo()
        Me.cbNganh.Enabled = False
        Me.cbXuong.Enabled = False
        Me.cbDonvi.Enabled = False
    End Sub


End Class