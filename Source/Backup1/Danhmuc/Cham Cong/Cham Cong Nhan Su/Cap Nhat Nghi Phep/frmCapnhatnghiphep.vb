
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



Public Class frmCapnhatnghiphep

    Private Sub btHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuy.Click
        TongHop.frmChamcongMain.objChamCong.FlagChamCong = False
        Me.Close()
    End Sub

    Private Sub btCapnhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhat.Click
        TongHop.frmChamcongMain.objChamCong.FlagChamCong = True
        TongHop.frmChamcongMain.objChamCong.TuNgay = Me.dtpTungay.Value.Year().ToString() + "/" + Me.dtpTungay.Value.Month().ToString() + "/" + Me.dtpTungay.Value.Day().ToString()
        TongHop.frmChamcongMain.objChamCong.DenNgay = Me.dtpDenngay.Value.Year().ToString() + "/" + Me.dtpDenngay.Value.Month().ToString() + "/" + Me.dtpDenngay.Value.Day().ToString()
        Me.Close()
    End Sub

    Private Sub frmCapnhatnghiphep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTungay.Text = TongHop.frmChamcongMain.objChamCong.Ngay
        Me.dtpDenngay.Text = TongHop.frmChamcongMain.objChamCong.Ngay
    End Sub
End Class