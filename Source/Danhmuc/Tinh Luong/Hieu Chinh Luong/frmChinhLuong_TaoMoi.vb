Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinEditors
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports Infragistics
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinListView.UltraListViewItem
Imports Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn
Imports Infragistics.Win.AutoCompleteMode
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.Data.SqlClient.SqlParameter
Public Class frmChinhLuong_TaoMoi
    Public chon As Boolean = False
    'Public Shared obj_ChinhLuong_TaoMoi As New obj_ChinhLuong
    Public hs1 As Double
    Public hs15 As Double
    Public hs2 As Double
    Public hs3 As Double
    Public cdem As Double
    Public nviec As Double
    Public p As Double
    Public r As Double
    Public ro As Double
    Public om As Double
    Public ts As Double
    Public kt As Double
    Public tu As Double
    Public com As Double
    Public pc As Double
    Public pcap As Double
    Public tienyt As Double
    Public tienxh As Double
    Public bhyt As Boolean
    Public bhxh As Boolean

    Private Sub bntDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntDong.Click
        Me.Close()
    End Sub
    Private Sub bntTinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntTinh.Click
        If IsNumeric(Trim(Me.txtPCKhac.Text)) = False Then
            MsgBox("Tiền phụ cấp khác là kiểu số", MsgBoxStyle.Critical, "Sai kiểu dữ liệu")
            Me.txtPCKhac.Focus()
            Exit Sub
        Else
            If Trim(Me.txtPCKhac.Text) < 0 Then
                MsgBox("Tiền phụ cấp khác phải>=0", MsgBoxStyle.Critical, "Thông báo")
                Me.txtPCKhac.Focus()
                Exit Sub
            End If
        End If
        If Me.txtPCKhac.Text <> "" Then
            pcap = Me.txtPCKhac.Text.Trim()
        Else
            pcap = 0
        End If
        If Me.chBHYT.Checked = True Then
            Me.tienyt = 1
        Else
            Me.tienyt = 0
        End If

        If Me.chBHXH.Checked = True Then
            Me.tienxh = 1
        Else
            Me.tienxh = 0
        End If
        Me.Close()
    End Sub
    Private Sub frmChinhLuong_TaoMoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtHS1.Text = hs1.ToString
        Me.txtHS15.Text = hs15.ToString
        Me.txtHS2.Text = hs2.ToString
        Me.txtHS3.Text = hs3.ToString
        Me.txtCongdem.Text = cdem.ToString
        Me.txtNgungviec.Text = nviec.ToString
        Me.txtNghiP.Text = p.ToString
        Me.txtNghiR.Text = r.ToString
        Me.txtNghiRO.Text = ro.ToString
        Me.txtNghiOM.Text = om.ToString
        Me.txtNghiTS.Text = ts.ToString
        Me.txtNghiKT.Text = kt.ToString
        Me.txtTamUng.Text = tu.ToString
        Me.txtBuaAn.Text = com.ToString
        Me.txtPCKhac.Text = pc.ToString
        If bhyt = True Then
            Me.chBHYT.Checked = True
        Else
            Me.chBHYT.Checked = False
        End If
        If bhxh = True Then
            Me.chBHXH.Checked = True
        Else
            Me.chBHXH.Checked = False
        End If
    End Sub

End Class