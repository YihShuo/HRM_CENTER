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
Public Class frmPhuCapKhac
    Dim Tabletemp As DataTable
    Dim Temp3 As New DataTable
    Friend WithEvents b As clsBPhuCapKhac
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmPhuCapKhac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objPhuCapKhac
        obj.ChonBang = 1
        Me.b = New clsBPhuCapKhac
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        Me.dtpNgay.Value = Now

        Me.Tim()
        ' kiem tra
        objPCK.ChonBang = 5
        objPCK.NamThang = Me.dtpNgay.Text
        Me.b = New clsBPhuCapKhac
        Temp3 = Nothing
        Temp3 = Me.b.LoadDS(objPCK)
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                If Temp3.Rows.Count > 0 Then
                    Me.lbLayDuLieu.Enabled = False
                Else
                    Me.lbLayDuLieu.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        'Me.b = New clsBTinhLuong
        Dim obj As New objPhuCapKhac

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
    Public Shared objPCK As New objPhuCapKhac
    Public sotien As Double
    Public sotien1 As Double
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/PhuCapKhac.xml"), typeControl.Grid, "coldgrChamcongmain")
        'Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
        objPCK.ChonBang = 5
        objPCK.NamThang = Me.dtpNgay.Text
        Me.b = New clsBPhuCapKhac
        Temp3 = Nothing
        Temp3 = Me.b.LoadDS(objPCK)
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                If Temp3.Rows.Count > 0 Then
                    Me.lbLayDuLieu.Enabled = False
                Else
                    Me.lbLayDuLieu.Enabled = True
                End If
            End If
        End If
        
    End Sub


    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Activate
        Me.dgrBC.UpdateData()
        objPCK.Setnull()
        Dim frm As New frmSoTienPC
        frm.ShowDialog()
        sotien = frm.tien
        objPCK.SoTien = sotien
        If frm.flag = False Then
        Else
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1

                objPCK.ChonBang = 3
                objPCK.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objPCK.LoaiPC = "PCKH"
                objPCK.NamThang = Me.dtpNgay.Text
                Dim Temp2 As New DataTable
                Me.b = New clsBPhuCapKhac
                Temp2 = Nothing
                Temp2 = Me.b.LoadDS(objPCK)

                objPCK.setvalue(objPCK.NV_MA, objPCK.LoaiPC, objPCK.NamThang, objPCK.SoTien)
                If Temp2.Rows.Count > 0 Then
                    objPCK.ChonBang = 1
                    Me.b = New clsBPhuCapKhac
                    Me.b.UpdateInfo(objPCK)
                Else
                    objPCK.ChonBang = 1
                    Me.b = New clsBPhuCapKhac
                    Me.b.InsertInfo(objPCK)
                End If
                i = i + 1
            End While
            MessageBox.Show("Đã cập nhật thành công")
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Activate
        Me.dgrBC.UpdateData()
        objPCK.Setnull()
        Dim frm As New frmSoTienPC
        frm.ShowDialog()
        sotien = frm.tien
        objPCK.SoTien = sotien
        If frm.flag = False Then

        Else
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    'Goi ham TINH LUONG

                    objPCK.ChonBang = 3
                    objPCK.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objPCK.LoaiPC = "PCKH"
                    objPCK.NamThang = Me.dtpNgay.Text
                    Dim Temp2 As New DataTable
                    Me.b = New clsBPhuCapKhac
                    Temp2 = Nothing
                    Temp2 = Me.b.LoadDS(objPCK)

                    objPCK.setvalue(objPCK.NV_MA, objPCK.LoaiPC, objPCK.NamThang, objPCK.SoTien)
                    If Temp2.Rows.Count > 0 Then
                        objPCK.ChonBang = 1
                        Me.b = New clsBPhuCapKhac
                        Me.b.UpdateInfo(objPCK)
                    Else
                        objPCK.ChonBang = 1
                        Me.b = New clsBPhuCapKhac
                        Me.b.InsertInfo(objPCK)
                    End If
                End If
                i = i + 1
            End While
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    objPCK.Setnull()
                    objPCK.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                    objPCK.LoaiPC = "PCKH"
                    ' kiem tra xem nhan vien nay da co tam ung chua
                    objPCK.ChonBang = 3
                    objPCK.NamThang = Me.dtpNgay.Text
                    Dim Temp As New DataTable
                    Me.b = New clsBPhuCapKhac
                    Temp = Nothing
                    Temp = Me.b.LoadDS(objPCK)


                    objPCK.DonVi = Me.cbDonvi.Value.ToString()

                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frmSoTienPC
                    If activeCell.Row.Cells.Item("PC_SOTIEN").Text = "" Then
                        frm.sotienf = 0
                    Else
                        frm.sotienf = Convert.ToDouble(activeCell.Row.Cells.Item("PC_SOTIEN").Text)
                    End If

                    frm.ShowDialog()
                    sotien = frm.tien
                    objPCK.SoTien = sotien
                    If frm.flag = False Then
                    Else
                        objPCK.setvalue(objPCK.NV_MA, objPCK.LoaiPC, objPCK.NamThang, objPCK.SoTien)
                        If Temp.Rows.Count > 0 Then
                            objPCK.ChonBang = 1
                            Me.b = New clsBPhuCapKhac
                            Me.b.UpdateInfo(objPCK)
                            Me.Tim()
                            Me.ChonDongCu()
                        Else
                            objPCK.ChonBang = 1
                            Me.b = New clsBPhuCapKhac
                            Me.b.InsertInfo(objPCK)
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
                    End If
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        'Dim obj As New objTinhLuong
                        objPCK.Setnull()
                        objPCK.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objPCK.NamThang = Me.dtpNgay.Text
                        objPCK.ChonBang = 1
                        Me.b.DeleteInfo(objPCK)
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 6
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub
    Public thangtruoc As String
    Public thanght As String
    Public thang_truoc As String
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub

    Private Sub lbLayDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLayDuLieu.Activate
        objPCK.ChonBang = 5
        objPCK.NamThang = Me.dtpNgay.Text
        Me.b = New clsBPhuCapKhac
        Temp3 = Nothing
        Temp3 = Me.b.LoadDS(objPCK)
        If Temp3.Rows.Count > 0 Then
            If (MessageBox.Show(("Dữ liệu tháng này đã có. Bạn có muốn lấy lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                Dim frm As New frmChuyenDuLieu
                frm.ShowDialog()
                thangtruoc = frm.THANGT
                If thangtruoc = Nothing Then
                    Exit Sub
                Else
                    ' XOA DU LIEU NEU DA CO ROI
                    objPCK.ChonBang = 2
                    objPCK.NamThang = Me.dtpNgay.Text
                    Me.b = New clsBPhuCapKhac
                    Me.b.DeleteInfo(objPCK)
                    ' INSERT VAO DU LIEU CUA THANG TRUOC
                    objPCK.ChonBang = 2
                    objPCK.NamThang = Me.dtpNgay.Text
                    objPCK.Thang_T = thangtruoc
                    Me.b = New clsBPhuCapKhac
                    Me.b.InsertInfo(objPCK)
                    MessageBox.Show("Đã lấy dữ liệu thành công")
                    Me.Tim()
                    Me.ChonDongCu()
                End If
            End If
        Else
            Dim frm1 As New frmChuyenDuLieu
            frm1.ShowDialog()
            thangtruoc = frm1.THANGT
            If thangtruoc = Nothing Then
                Exit Sub
            Else
                ' INSERT VAO DU LIEU CUA THANG TRUOC
                objPCK.ChonBang = 2
                objPCK.NamThang = Me.dtpNgay.Text
                objPCK.Thang_T = thangtruoc
                Me.b = New clsBPhuCapKhac
                Me.b.InsertInfo(objPCK)
                MessageBox.Show("Đã lấy dữ liệu thành công")
                Me.Tim()
                Me.ChonDongCu()
            End If
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
        objPCK.ChonBang = 5
        objPCK.NamThang = Me.dtpNgay.Text
        Me.b = New clsBPhuCapKhac
        Temp3 = Nothing
        Temp3 = Me.b.LoadDS(objPCK)
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                If Temp3.Rows.Count > 0 Then
                    Me.lbLayDuLieu.Enabled = False
                Else
                    Me.lbLayDuLieu.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
End Class