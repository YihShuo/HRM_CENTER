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
Public Class frmKhoaSoLuong
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBKhoaSoLuong
    Dim Flag As Boolean = False

    Private Sub frmKhoaSoLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim obj As New objKhoaSoLuong
        obj.ChonBang = 1
        Me.b = New clsBKhoaSoLuong
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        Dim nam As Integer = Microsoft.VisualBasic.DatePart(DateInterval.Year, Now())
        Dim i As Integer = 2009
        While i <= nam
            Me.cbNam.Items.Add(i.ToString)
            i += 1
        End While

        Dim thanght As Integer
        thanght = Month(Now)
        Me.cbNam.Text = nam
        obj.Nam = Me.cbNam.Value
        obj.ChonBang = 8
        Me.b = New clsBKhoaSoLuong
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cbThang.DataSource = Me.Tabletemp
        Me.cbThang.SelectedIndex = thanght - 1
        Locdulieu()
        Flag = True
    End Sub
   
    Dim oldRow As Integer = 0
    Private Sub Locdulieu()
        Dim grid As New clsTformatGrid
        Dim obj As New objKhoaSoLuong
        Me.b = New clsBKhoaSoLuong
        If Me.cbThang.Text = "" Then
            Exit Sub
        Else
        End If
        'Don Vi Checked
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                'Load danh sach nhan vien theo don vi
                obj.ChonBang = 2
                obj.DonVi = Me.cbDonvi.Value.ToString()
                obj.NamThang = Me.cbThang.Text
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Else
                obj.ChonBang = 3
                Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            End If
        End If
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/LuongKhoaSo.xml"), typeControl.Grid, "coldgrhoso")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public Shared objLuong As New objKhoaSoLuong

    Private Sub lbBangLuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBangLuong.Click
        Dim report As New frmBangLuongKhoaSo
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub lbPhieuLuongCaNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPhieuLuongCaNhan.Click
        Dim report As New frmBangLuongKhoaSo
        report.LoaiReport = 2
        report.Show()
    End Sub

    Private Sub cbNam_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNam.ValueChanged
        If Flag = True Then
            Dim obj As New objKhoaSoLuong
            Me.b = New clsBKhoaSoLuong

            obj.Nam = Me.cbNam.Value
            obj.ChonBang = 8
            Me.b = New clsBKhoaSoLuong
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.cbThang.DataSource = Nothing
            Me.cbThang.DataSource = Me.Tabletemp
            Me.cbThang.SelectedIndex = 0
            'Locdulieu()
        End If
    End Sub

    Private Sub btXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Click
        Locdulieu()
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.dgrBC.DataSource = Nothing
    End Sub

    Private Sub cbThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbThang.ValueChanged
        Me.dgrBC.DataSource = Nothing
    End Sub
End Class