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
Public Class frmBinhBauNam_
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBBinhBauNam_
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmBinhBauNam__Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objBinhBauNam_
        obj.ChonBang = 1
        Me.b = New clsBBinhBauNam_
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
        Dim obj As New objBinhBauNam_
        'Don Vi Checked
        If Me.cbDonvi.SelectedIndex <> -1 Then
            'Load danh sach nhan vien theo don vi
            obj.ChonBang = 2
            obj.DV_MA = Me.cbDonvi.Value.ToString()
            obj.NAM = Me.dtpNgay.Text
            Me.Tabletemp = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp)
        Else
            'obj.ChonBang = 3
            'Me.Tabletemp = Me.b.LoadDS(obj)
        End If
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/BBNAM.xml"), typeControl.Grid, "coldgrhoso")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Dim oldRow As Integer = 0

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public Shared objBB As New objBinhBauNam_
    Public Sub TinhBinhBauNam()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objBB.NV_MA))
        listpar.Add(New SqlParameter("@BB_Nam", objBB.NAM))
        listpar.Add(New SqlParameter("@Binhbau", objBB.Binhbau))
        Me.b.GoiThuTuc("SP_BINHBAUNAM", listpar)
        listpar.Clear()
    End Sub
    Private Sub EditTinhBinhBauNam()
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim i As Integer = 0
        While i <= Me.dgrBC.Rows.Count - 1
            objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
            Me.TinhBinhBauNam()
            i = i + 1
        End While
        MessageBox.Show("Đã cập nhật thành công")
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim frm As New frmLoaiBB_
        frm.ShowDialog()
        If objBB.FlagTinhBinhBau = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objBB.NAM = Me.dtpNgay.Text
                    'Goi ham TINH binh bau
                    Me.TinhBinhBauNam()
                End If
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim frm As New frmLoaiBB_
        frm.ShowDialog()
        If objBB.FlagTinhBinhBau = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objBB.NAM = Me.dtpNgay.Text
                TinhBinhBauNam()
                i = i + 1
            End While
            MessageBox.Show("Đã cập nhật thành công")
        End If

        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    objBB.Setnull()
                    objBB.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                    objBB.NAM = Me.dtpNgay.Text
                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frmLoaiBB_
                    frm.ShowDialog()
                    If objBB.FlagTinhBinhBau = True Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        Me.TinhBinhBauNam()
                    End If
                    Me.Tim()
                    Me.ChonDongCu()
            End Select
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 24
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
End Class