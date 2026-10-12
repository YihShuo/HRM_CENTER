Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Public Class frmThongKeDanhSachCanBo
    Dim flag As Boolean
    Dim obj As New objThongKeDanhSachCanBo
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDThongKeDanhSachCanBo ' Nested Types
    Friend WithEvents b As clsBThongKeDanhSachCanBo
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim ReportID As String

    Private Sub frmThongKeDanhSachCanBo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBThongKeDanhSachCanBo
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 2
        'Load Don Vi
        Me.b = New clsBThongKeDanhSachCanBo
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        Me.cbXuong.Enabled = False
        Me.cbDonvi.Enabled = False
    End Sub

    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate
        If Me.radTongquat.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "6966"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radXuong.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "6977"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbXuong.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radDonvi.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "6988"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {Me.cbDonvi.Text}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radtongXuong.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "6999"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radTongDonvi.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "7000"
            report.reportID = Me.ReportID
            Dim strArray As String() = New String() {}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
    End Sub

    Private Sub radTongquat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongquat.CheckedChanged
        If Me.radTongquat.Checked = True Then
            Me.cbXuong.Clear()
            Me.cbDonvi.Clear()
            Me.radtongXuong.Checked = False
            Me.radTongDonvi.Checked = False
        End If
    End Sub

    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        If Me.radXuong.Checked = True Then
            Me.cbDonvi.Clear()
            Me.cbXuong.Enabled = True
            Me.radtongXuong.Checked = False
            Me.radTongDonvi.Checked = False
        Else
            Me.cbXuong.Enabled = False
        End If
    End Sub

    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        If Me.radDonvi.Checked = True Then
            Me.cbXuong.Clear()
            Me.cbDonvi.Enabled = True
            Me.radtongXuong.Checked = False
            Me.radTongDonvi.Checked = False
        Else
            Me.cbDonvi.Enabled = False
        End If
    End Sub

    Private Sub radtongXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radtongXuong.CheckedChanged
        Me.radDonvi.Checked = False
        Me.radXuong.Checked = False
        Me.radTongquat.Checked = False
    End Sub

    Private Sub UltraGroupBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox3.Click

    End Sub

    Private Sub radTongDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongDonvi.CheckedChanged
        Me.radDonvi.Checked = False
        Me.radXuong.Checked = False
        Me.radTongquat.Checked = False
    End Sub
End Class