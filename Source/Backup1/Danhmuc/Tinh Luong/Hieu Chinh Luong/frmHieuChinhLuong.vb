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
Public Class frmHieuChinhLuong
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBHieuChinhLuong
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmHieuChinhLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objHieuChinhLuong
        obj.ChonBang = 1
        Me.b = New clsBHieuChinhLuong
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        Me.dtpNgay.Value = Now

        Me.Tim()
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        'Me.b = New clsBTinhLuong
        Dim obj As New objHieuChinhLuong


        'Don Vi Checked
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                'Load danh sach nhan vien theo don vi
                obj.ChonBang = 2
                obj.DonVi = Me.cbDonvi.Value.ToString()
                obj.NamThang = Me.dtpNgay.Text
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            Else
                'obj.ChonBang = 3
                'Me.Tabletemp = Me.b.LoadDS(obj)
            End If
        End If

    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/HieuChinhLuong.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        Dim i As Integer
        For i = 0 To 9
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub cbThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public Shared objUng As New objHieuChinhLuong
    Public sotien As Double
    Public sotien1 As Double

    Public tienhs1 As Double
    Public tienhs15 As Double
    Public tienhs2 As Double
    Public tienhs3 As Double
    Public tiencdem As Double
    Public tiennviec As Double
    Public tienp As Double
    Public tienr As Double
    Public tienro As Double
    Public tienom As Double
    Public tients As Double
    Public tienkt As Double
    Public tientu As Double
    Public tiencom As Double
    Public tienpc As Double
    Public tienbhyt As Boolean
    Public tienbhxh As Boolean

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim ngaycn As String
            Dim nguoicn As String
            nguoicn = MAIN.userclient
            Dim ngaycn1 As DateTime = Now()
            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString


            objUng.NGUOICN = nguoicn
            objUng.NGAYCN = ngaycn
            Select Case ColA
                Case "1"
                    objUng.Setnull()
                    objUng.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text

                    ' kiem tra xem nhan vien nay da co tam ung chua
                    objUng.ChonBang = 3
                    objUng.NamThang = Me.dtpNgay.Text
                    Dim Temp As New DataTable
                    Me.b = New clsBHieuChinhLuong
                    Temp = Nothing
                    Temp = Me.b.LoadDS(objUng)
                    objUng.DonVi = Me.cbDonvi.Value.ToString()


                    If activeCell.Row.Cells.Item("L_CONGHS1").Text = "" Then
                        Me.tienhs1 = 0
                    Else
                        Me.tienhs1 = Convert.ToDouble(activeCell.Row.Cells.Item("L_CONGHS1").Text)
                    End If
                    If activeCell.Row.Cells.Item("L_CONGHS15").Text = "" Then
                        Me.tienhs15 = 0
                    Else
                        Me.tienhs15 = Convert.ToDouble(activeCell.Row.Cells.Item("L_CONGHS15").Text)
                    End If
                    If activeCell.Row.Cells.Item("L_CONGHS2").Text = "" Then
                        Me.tienhs2 = 0
                    Else
                        Me.tienhs2 = Convert.ToDouble(activeCell.Row.Cells.Item("L_CONGHS2").Text)
                    End If
                    If activeCell.Row.Cells.Item("L_CONGHS3").Text = "" Then
                        Me.tienhs3 = 0
                    Else
                        Me.tienhs3 = Convert.ToDouble(activeCell.Row.Cells.Item("L_CONGHS3").Text)
                    End If
                    If activeCell.Row.Cells.Item("L_CONGCADEM").Text = "" Then
                        Me.tiencdem = 0
                    Else
                        Me.tiencdem = Convert.ToDouble(activeCell.Row.Cells.Item("L_CONGCADEM").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGUNGVIEC").Text = "" Then
                        Me.tiennviec = 0
                    Else
                        Me.tiennviec = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGUNGVIEC").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGHIP").Text = "" Then
                        Me.tienp = 0
                    Else
                        Me.tienp = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHIP").Text)
                    End If



                    If activeCell.Row.Cells.Item("L_NGHIR").Text = "" Then
                        Me.tienr = 0
                    Else
                        Me.tienr = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHIR").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGHIRO").Text = "" Then
                        Me.tienro = 0
                    Else
                        Me.tienro = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHIRO").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGHIOM").Text = "" Then
                        Me.tienom = 0
                    Else
                        Me.tienom = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHIOM").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGHITS").Text = "" Then
                        Me.tients = 0
                    Else
                        Me.tients = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHITS").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_NGHIKHAMTHAI").Text = "" Then
                        Me.tienkt = 0
                    Else
                        Me.tienkt = Convert.ToDouble(activeCell.Row.Cells.Item("L_NGHIKHAMTHAI").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_TAMUNG").Text = "" Then
                        Me.tientu = 0
                    Else
                        Me.tientu = Convert.ToDouble(activeCell.Row.Cells.Item("L_TAMUNG").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_SOPHANCOM").Text = "" Then
                        Me.tiencom = 0
                    Else
                        Me.tiencom = Convert.ToDouble(activeCell.Row.Cells.Item("L_SOPHANCOM").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_PHUCAPKHAC").Text = "" Then
                        Me.tienpc = 0
                    Else
                        Me.tienpc = Convert.ToDouble(activeCell.Row.Cells.Item("L_PHUCAPKHAC").Text)
                    End If

                    If activeCell.Row.Cells.Item("L_BHYT").Text = False Then
                        Me.tienbhyt = 0
                    Else
                        Me.tienbhyt = True
                    End If

                    If activeCell.Row.Cells.Item("L_BHXH").Text = False Then
                        Me.tienbhxh = 0
                    Else
                        Me.tienbhxh = True
                    End If


                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frmChinhLuong_TaoMoi
                    frm.hs1 = tienhs1
                    frm.hs15 = tienhs15
                    frm.hs2 = tienhs2
                    frm.hs3 = tienhs3
                    frm.cdem = tiencdem
                    frm.nviec = tiennviec
                    frm.p = tienp
                    frm.r = tienr
                    frm.ro = tienro
                    frm.om = tienom
                    frm.ts = tients
                    frm.kt = tienkt
                    frm.tu = tientu
                    frm.com = tiencom
                    frm.pc = tienpc
                    frm.bhyt = tienbhyt
                    frm.bhxh = tienbhxh

                    frm.ShowDialog()
                    objUng.SoTien = frm.pcap
                    objUng.BHXH = frm.tienxh
                    objUng.BHYT = frm.tienyt
                    If Temp.Rows.Count > 0 Then
                        ' CAP NHAT BANG LUONG
                        objUng.ChonBang = 1
                        Me.b = New clsBHieuChinhLuong
                        Me.b.UpdateInfo(objUng)
                        ' CAP NHAT BANG LUONG MOI

                        objUng.ChonBang = 2
                        Me.b = New clsBHieuChinhLuong
                        Me.b.UpdateInfo(objUng)

                        ' GOI THU TUC TINH LAI TIEN BH
                        Me.TinhBH()


                        Me.Tim()
                        Me.ChonDongCu()
                    Else
                    End If
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        'Dim obj As New objTinhLuong
                        objUng.Setnull()
                        objUng.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objUng.NamThang = Me.dtpNgay.Text
                        Me.b.DeleteInfo(objUng)
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub
    Public Sub TinhBH()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objUng.NV_MA))
        listpar.Add(New SqlParameter("@T_MA", objUng.NamThang))
        Me.b.GoiThuTuc("SP_TINHLUONG_DC", listpar)
        listpar.Clear()
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub
End Class