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
Public Class frmCom

    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Click
        TongHop.frmChamCom.obj.FlagChamCom = True
        If Me.txtSoBuaAn.Text = "" And Me.radTuDong.Checked = True Then
            TongHop.frmChamCom.obj.ChamCom = "NULL"
        Else
            TongHop.frmChamCom.obj.ChamCom = "'" + Me.txtSoBuaAn.Text + "'"

        End If
        Me.Close()
    End Sub

    Private Sub txtSoBuaAn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoBuaAn.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub frmCom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.radTuDong.Checked = True
        Me.txtSoBuaAn.Enabled = False
    End Sub

    Private Sub radSoBuaan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSoBuaan.CheckedChanged
        If Me.radSoBuaan.Checked = True Then
            Me.txtSoBuaAn.Enabled = True
            Me.txtSoBuaAn.Focus()
        End If
    End Sub

    Private Sub radTuDong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radTuDong.CheckedChanged
        If Me.radTuDong.Checked = True Then
            Me.txtSoBuaAn.Enabled = False
        End If
    End Sub

    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub
End Class