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
Public Class frmCongNhanMoi

    Private Sub btHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuy.Click
        Me.Close()
    End Sub

    Private Sub btThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThem.Click
        Dim obj As New objDiemDanhHangNgay
        obj.ChonBang = 77
        obj.Ngay = Me.dtpNgay.Value.Year().ToString + "/" + Me.dtpNgay.Value.Month().ToString + "/" + Me.dtpNgay.Value.Day().ToString
        Dim table As DataTable
        Me.b = New clsBDiemDanhHangNgay
        table = Me.b.LoadDS(obj)

        If table.Rows.Count > 0 Then
            'MessageBox.Show("Cap nhat vao bang")
            obj.ChonBang = 130
            obj.DV_MA = "CNMT"
            obj.TS = Me.txtTongso.Text
            obj.TSTT = Me.txtTongsothucte.Text
            obj.Nam = Me.txtNam.Text
            obj.Nu = Me.txtNu.Text
            Me.b.UpdateInfo(obj)

            obj.DV_MA = "CNMHocATLD"
            obj.TS = Me.txtTongsoh.Text
            obj.TSTT = Me.txtTongsothucteh.Text
            obj.Nam = Me.txtNamh.Text
            obj.Nu = Me.txtNuh.Text
            Me.b.UpdateInfo(obj)


            'Luu so nam nu thuc te
            obj.ChonBang = 131
            obj.DV_MA = "CNMT"
            obj.TS = Me.txtTongso.Text
            obj.TSTT = Me.txtTongsothucte.Text
            obj.Nam = Me.txtNamtt.Text
            obj.Nu = Me.txtNutt.Text
            Me.b.UpdateInfo(obj)

            obj.DV_MA = "CNMHocATLD"
            obj.TS = Me.txtTongsoh.Text
            obj.TSTT = Me.txtTongsothucteh.Text
            obj.Nam = Me.txtNamtth.Text
            obj.Nu = Me.txtNutth.Text
            Me.b.UpdateInfo(obj)



        Else
            obj.ChonBang = 52
            obj.DV_MA = "CNMT"
            obj.TS = Me.txtTongso.Text
            obj.TSTT = Me.txtTongsothucte.Text
            obj.Nam = Me.txtNam.Text
            obj.Nu = Me.txtNu.Text
            Me.b.InsertInfo(obj)

            obj.DV_MA = "CNMHocATLD"
            obj.TS = Me.txtTongsoh.Text
            obj.TSTT = Me.txtTongsothucteh.Text
            obj.Nam = Me.txtNamh.Text
            obj.Nu = Me.txtNuh.Text
            Me.b.InsertInfo(obj)


            'Luu so nam nu thuc te
            obj.ChonBang = 53
            obj.DV_MA = "CNMT"
            obj.TS = Me.txtTongso.Text
            obj.TSTT = Me.txtTongsothucte.Text
            obj.Nam = Me.txtNamtt.Text
            obj.Nu = Me.txtNutt.Text
            Me.b.InsertInfo(obj)

            obj.DV_MA = "CNMHocATLD"
            obj.TS = Me.txtTongsoh.Text
            obj.TSTT = Me.txtTongsothucteh.Text
            obj.Nam = Me.txtNamtth.Text
            obj.Nu = Me.txtNutth.Text
            Me.b.InsertInfo(obj)


        End If
        MessageBox.Show("Đã cập nhật dữ liệu")

    End Sub

    Private Sub frmCongNhanMoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Friend WithEvents b As clsBDiemDanhHangNgay
    Public Shared ngay As Date

    Private Sub btXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Click

        If MessageBox.Show("Bạn có muốn xóa 2 đơn vị 'CNMT' Và 'CNMHocATLD' Tại ngày " + Me.dtpNgay.Value.Day().ToString + "/" + Me.dtpNgay.Value.Month().ToString + "/" + Me.dtpNgay.Value.Year().ToString + " ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim obj As New objDiemDanhHangNgay
            obj.Ngay = Me.dtpNgay.Value.Year().ToString + "/" + Me.dtpNgay.Value.Month().ToString + "/" + Me.dtpNgay.Value.Day().ToString
            Me.b = New clsBDiemDanhHangNgay
            'MessageBox.Show("Cap nhat vao bang")
            obj.ChonBang = 4
            Me.b.DeleteInfo(obj)

            'Luu so nam nu thuc te
            obj.ChonBang = 5
            Me.b.DeleteInfo(obj)
            MessageBox.Show("Đã xóa dữ liệu ")

        End If
    End Sub
End Class