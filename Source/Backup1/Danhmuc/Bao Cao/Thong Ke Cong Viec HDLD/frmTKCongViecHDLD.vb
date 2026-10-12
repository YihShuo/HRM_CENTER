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
Public Class frmTKCongViecHDLD
    Dim flag As Boolean
    Dim obj As New objTKCongViecHDLD
    Dim Table As String
    Dim Path As String
    Friend WithEvents d As clsDTKCongViecHDLD ' Nested Types
    Friend WithEvents b As clsBTKCongViecHDLD
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim ReportID As String

    Private Sub btXemBaoCao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXemBaoCao.Activate
        If Me.radTongquat.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "702"
            report.reportID = Me.ReportID
            Dim ngay As Date
            ngay = Me.dtpThang.Text
            Dim ngay2 As String
            ngay2 = Month(ngay)
            Dim strArray As String() = New String() {"'" + ngay2 + "'"}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radXuong.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "703"
            report.reportID = Me.ReportID
            Dim ngay As Date
            ngay = Me.dtpThang.Text
            Dim ngay2 As String
            ngay2 = Month(ngay)
            Dim strArray As String() = New String() {"'" + Me.cbXuong.Text + "'", "'" + ngay2 + "'"}
            report.para = strArray
            report.issysReport = True
            report.Show()
        ElseIf Me.radDonvi.Checked = True Then
            Dim report As New FrmReport
            Me.ReportID = "704"
            report.reportID = Me.ReportID
            Dim ngay As Date
            ngay = Me.dtpThang.Text
            Dim ngay2 As String
            ngay2 = Month(ngay)
            Dim strArray As String() = New String() {"'" + Me.cbDonvi.Text + "'", "'" + ngay2 + "'"}
            report.para = strArray
            report.issysReport = True
            report.Show()
        End If
    End Sub

    Private Sub frmTKCongViecHDLD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBTKCongViecHDLD
        Me.cbXuong.DataSource = Me.b.LoadDS(obj)
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 2
        'Load Don Vi
        Me.b = New clsBTKCongViecHDLD
        Me.cbDonvi.DataSource = Me.b.LoadDS(obj)
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        Me.cbXuong.Enabled = False
        Me.cbDonvi.Enabled = False
    End Sub

    Private Sub radTongquat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTongquat.CheckedChanged
        If Me.radTongquat.Checked = True Then
            Me.cbXuong.Clear()
            Me.cbDonvi.Clear()
        End If
    End Sub

    Private Sub radXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radXuong.CheckedChanged
        If Me.radXuong.Checked = True Then
            Me.cbDonvi.Clear()
            Me.cbXuong.Enabled = True
        Else
            Me.cbXuong.Enabled = False
        End If
    End Sub

    Private Sub radDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDonvi.CheckedChanged
        If Me.radDonvi.Checked = True Then
            Me.cbXuong.Clear()
            Me.cbDonvi.Enabled = True
        Else
            Me.cbDonvi.Enabled = False
        End If
    End Sub
End Class