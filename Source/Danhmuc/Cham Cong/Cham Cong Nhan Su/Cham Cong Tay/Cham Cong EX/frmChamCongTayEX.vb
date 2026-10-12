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
Public Class frmChamCongTayEX

    Private Sub cbChamcong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbChamcong.Click
        TongHop.frmChamCongTay.objChamCong.FlagChamCong = True
        'Set cac thuong tinh trong form chamcongex vao objChamCong
        TongHop.frmChamCongTay.objChamCong.setvalue(Me.dtpTungay.Value.Year().ToString() + "/" + Me.dtpTungay.Value.Month().ToString() + "/" + Me.dtpTungay.Value.Day().ToString(), Me.dtpDenngay.Value.Year().ToString() + "/" + Me.dtpDenngay.Value.Month().ToString() + "/" + Me.dtpDenngay.Value.Day().ToString(), Me.chkSom.Checked, Me.chbLuontinhducong.Checked, Me.chbtinhtangca.Checked, Me.chbkhongtinhditre.Checked, Me.chbkhongtinhquenquetthe.Checked, Me.chbluontinhditre.Checked, Me.chbluontinhquenquetthe.Checked, Me.chbgioihantangcatoida.Checked, Me.chbgiailaotangca.Checked, Me.chbtinhlamdemtuluc.Checked, Me.chbtinhducongkhididu.Checked, Me.txtGioihantangcatoida.Text, Me.txtGiailaotangca.Text, Me.txtTinhlamdemtuluc.Text, Me.txtTinhducongkhididu.Text, Me.txtHesongaycong.Text)
        Me.Close()
    End Sub

    Private Sub cbDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDong.Click
        TongHop.frmChamCongTay.objChamCong.FlagChamCong = False
        Me.Close()
    End Sub

    Private Sub frmChamCongTayEX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTungay.Text = TongHop.frmChamCongTay.objChamCong.Ngay
        Me.dtpDenngay.Text = TongHop.frmChamCongTay.objChamCong.Ngay
    End Sub
End Class