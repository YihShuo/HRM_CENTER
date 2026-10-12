Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinToolTip
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
Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports TongHop.clsTools
Imports TongHop.frmChamcongMain
Public Class frmCachTinhLuong

    Private Sub btTinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTinh.Click
        TongHop.frmTinhLuong.objLuong.FlagTinhLuong = True
        If Me.cbTinhLuong.Text = "" Then
            TongHop.frmTinhLuong.objLuong.LoaiLuong = "NULL"
        Else
            TongHop.frmTinhLuong.objLuong.LoaiLuong = Me.cbTinhLuong.SelectedIndex
        End If
        Me.Close()
    End Sub

    Private Sub btDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Click
        TongHop.frmTinhLuong.objLuong.FlagTinhLuong = False
        Me.Close()
    End Sub
End Class