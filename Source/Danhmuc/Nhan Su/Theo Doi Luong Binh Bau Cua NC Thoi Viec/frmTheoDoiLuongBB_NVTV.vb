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
Public Class frmTheoDoiLuongBB_NVTV
    Public Temp As New DataTable
    Dim obj As New objTheoDoiLuongBB_NVTV
    Friend WithEvents d As clsDTheoDoiLuongBB_NVTV   ' Nested Types
    Friend WithEvents b As clsBTheoDoiLuongBB_NVTV

    Private Sub frmTheoDoiLuongBB_NVTV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 2
        Me.b = New clsBTheoDoiLuongBB_NVTV
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)
        Locdulieu(Me.Temp)
        Me.An()
        Me.btBinhBau.Visible = False
        Me.btLuong.Visible = False
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TheoDoiThoiViec.xml"), typeControl.Grid, "coldgrThoiviec")
    End Sub
    Public Sub An()
        Me.txtHoTen.ReadOnly = True
        Me.txtDonVi.ReadOnly = True
        Me.txtCongViec.ReadOnly = True
        Me.txtTrinhDoHV.ReadOnly = True
        Me.txtTrinhDoCM.ReadOnly = True
        Me.txtChucVu.ReadOnly = True
        Me.dtpNgaySinh.Enabled = False
        Me.dtpNgayVao.Enabled = False
        Me.dtpNgayBoNhiem.Enabled = False
    End Sub
    Public Sub Hien()
        Me.txtHoTen.ReadOnly = False
        Me.txtDonVi.ReadOnly = False
        Me.txtCongViec.ReadOnly = False
        Me.txtTrinhDoHV.ReadOnly = False
        Me.txtTrinhDoCM.ReadOnly = False
        Me.txtChucVu.ReadOnly = False
    End Sub
    Public Sub Clear()
        Me.txtHoTen.Clear()
        Me.txtDonVi.Clear()
        Me.txtCongViec.Clear()
        Me.txtTrinhDoHV.Clear()
        Me.dtpNgayVao.Text = Now
        Me.dtpNgayBoNhiem.Text = Now
        Me.dtpNgaySinh.Text = Now
        Me.txtTrinhDoCM.Clear()
        Me.txtChucVu.Clear()
    End Sub
    Public flag As Integer = 0
    Private Sub txtMa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.TextChanged
        Me.btBinhBau.Visible = True
        Me.btLuong.Visible = True
        Me.dgrBC.DataSource = Nothing
        If Me.txtMa.Text.Length = 6 Or Me.txtMa.Text.Length = 6 Then
            Me.btBinhBau.Visible = True
            Me.btLuong.Visible = True
            obj.ChonBang = 1
            Me.b = New clsBTheoDoiLuongBB_NVTV
            obj.NV_MA = Me.txtMa.Text.Trim()
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            If Temp.Rows.Count > 0 Then
                Me.txtHoTen.Text = Temp.Rows(0).Item("NV_TEN").ToString()
                Me.txtDonVi.Text = Temp.Rows(0).Item("DV_MA_").ToString()
                Me.dtpNgayVao.Text = Temp.Rows(0).Item("NV_NGAYVAO").ToString()
                Me.txtCongViec.Text = Temp.Rows(0).Item("CV_TEN").ToString()
                Me.txtTrinhDoHV.Text = Temp.Rows(0).Item("HV_TEN").ToString()
                Me.dtpNgaySinh.Text = Temp.Rows(0).Item("NV_NGAYSINH").ToString()
                Me.dtpNgayBoNhiem.Text = Temp.Rows(0).Item("NV_NGAYBONHIEM").ToString()
                Me.txtChucVu.Text = Temp.Rows(0).Item("CVU_TEN").ToString()
                Me.txtTrinhDoCM.Text = Temp.Rows(0).Item("CM_TEN").ToString()
            Else
                MessageBox.Show("Không có nhân viên này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Clear()
            End If
        End If
        If Me.txtMa.Text = "" Then
            Me.btBinhBau.Visible = False
            Me.btLuong.Visible = False
            Me.Clear()
            flag = 0
            obj.ChonBang = 2
            Me.b = New clsBTheoDoiLuongBB_NVTV
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            Locdulieu(Me.Temp)
        End If
    End Sub
    Private Sub Locdulieu2(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/XEMDBB.xml"), typeControl.Grid, "coldgrhoso")
    End Sub
    Private Sub btBinhBau_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBinhBau.Activate
        flag = 1
        Me.dgrBC.DataSource = Nothing
        Dim ma As String = Me.txtMa.Text.Trim()
        If (MessageBox.Show("Bạn có muốn xem bình bầu của nhân viên " & ma & " không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
            obj.NV_MA = ma
            obj.ChonBang = 3
            Me.b = New clsBTheoDoiLuongBB_NVTV
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            Locdulieu2(Me.Temp)
        End If
    End Sub
    Private Sub Locdulieu3(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/XEMLUONG.xml"), typeControl.Grid, "coldgrChamcongmain")
    End Sub
    Private Sub btLuong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuong.Activate
        flag = 2
        Me.dgrBC.DataSource = Nothing
        Dim ma As String = Me.txtMa.Text.Trim()
        If (MessageBox.Show("Bạn có muốn xem mức lương của nhân viên " & ma & " không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
            obj.NV_MA = ma
            obj.ChonBang = 4
            Me.b = New clsBTheoDoiLuongBB_NVTV
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            Locdulieu3(Me.Temp)
        End If
    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub LocdulieuDienBienluong(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/XEMDBL_NVTV.xml"), typeControl.Grid, "coldgrhoso")
    End Sub
    Private Sub btDienBienLuong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDienBienLuong.Activate
        flag = 3
        Me.dgrBC.DataSource = Nothing
        Dim ma As String = Me.txtMa.Text.Trim()
        If (MessageBox.Show("Bạn có muốn xem diễn biến lương của nhân viên " & ma & " không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
            obj.NV_MA = ma
            obj.ChonBang = 5
            Me.b = New clsBTheoDoiLuongBB_NVTV
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            LocdulieuDienBienluong(Me.Temp)
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer = 0
        With dgrBC.DisplayLayout
            For i = 0 To .Bands(0).Columns.Count - 1
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            Next
        End With
    End Sub
End Class