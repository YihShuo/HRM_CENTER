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
Public Class ThoiViecKhongThamGiaBHTN
    Dim obj As New objThoiViecKhongThamGiaBHTN
    Dim TableNhanVien As New DataTable
    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        If Me.txtManv.Text <> "" Then
            TinhTongSoNgayPhep()
            '' load lưới
            TinhTroCapThoiViec()
            methodLoad()
        End If
    End Sub
    Dim Path As String
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThoiViecKhongThamGiaBHTN
        Me.Path = "/layout/TroCapThoiViec.xml"
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrTCTV")
    End Sub
    Private Sub TinhTongSoNgayPhep()
        Dim listpar As New ArrayList(16)
        listpar.Add(New SqlParameter("@NV_MA", obj.MANV))
        Me.b.GoiThuTuc("SP_TONGSONGAYPHEP", listpar)
        listpar.Clear()
    End Sub
    Private Sub TinhTroCapThoiViec()
        Dim listpar As New ArrayList(16)
        listpar.Add(New SqlParameter("@NV_MA", obj.MANV))
        Me.b.GoiThuTuc("SP_TROCAPTHOIVIEC", listpar)
        listpar.Clear()
    End Sub
    Friend WithEvents b As clsBThoiViecKhongThamGiaBHTN
    Private Sub txtManv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManv.TextChanged
        If Trim(Me.txtManv.Text.Length) = 6 Then
            Dim b As New clsBThoiViecKhongThamGiaBHTN
            Me.b = New clsBThoiViecKhongThamGiaBHTN

            ''Tim theo so the

            obj.MANV = Me.txtManv.Text
            obj.ChonBang = 1
            obj.MANV = Me.txtManv.Text.Trim
            TableNhanVien = Me.b.LoadDS(obj)
            If Me.b.LoadDS(obj).Rows.Count > 0 Then
                Me.txtHoTen.Text = Me.b.LoadDS(obj).Rows(0).Item("NV_TEN").ToString
                Me.txtNgayVao.Text = Me.b.LoadDS(obj).Rows(0).Item("NV_NGAYVAO").ToString
                Me.txtNgayKyHD.Text = Me.b.LoadDS(obj).Rows(0).Item("NV_NGAYKYHD").ToString
            Else
                MessageBox.Show("Không tìm thấy thông tin số thẻ: " & Me.txtManv.Text, "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ThoiViecKhongThamGiaBHTN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class