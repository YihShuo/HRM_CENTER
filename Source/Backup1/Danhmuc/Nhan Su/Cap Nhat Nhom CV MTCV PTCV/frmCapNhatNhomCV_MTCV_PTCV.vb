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
Public Class frmCapNhatNhomCV_MTCV_PTCV
    Dim Tabletemp As DataTable
    Dim TabletempDem As DataTable
    Friend WithEvents b As clsBCapNhatNhomCV_MTCV_PTCV
    Private Sub frmCapNhatNhomCV_MTCV_PTCV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objCapNhatNhomCV_MTCV_PTCV
        obj.ChonBang = 1
        Me.b = New clsBCapNhatNhomCV_MTCV_PTCV
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        obj.ChonBang = 2
        Me.b = New clsBCapNhatNhomCV_MTCV_PTCV
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cbNhomCV.DataSource = Me.Tabletemp
        Me.cbNhomCV.ValueMember = "NHOMCV_MA"
        Me.cbNhomCV.DisplayMember = "TEN_NHOM"
        Me.cbNhomCV.SelectedIndex = 0
        Me.Tim()
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Dim obj As New objCapNhatNhomCV_MTCV_PTCV
        If Me.cbDonvi.SelectedIndex <> -1 Then
            'Load danh sach nhan vien theo don vi
            obj.ChonBang = 3
            obj.DV_MA = Me.cbDonvi.Value.ToString()
            Me.Tabletemp = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp)
        End If
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Dim oldRow As Integer = 0
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/NHOMCV.xml"), typeControl.Grid, "coldgr")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            If TableDS.Rows.Count < oldRow Then
                Exit Sub
            Else
                Me.dgrBC.Rows(oldRow).Activated = True
            End If

        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 10
            If (i <> 1) Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i

    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
    Public Shared objnhom As New objCapNhatNhomCV_MTCV_PTCV
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    If MessageBox.Show("Bạn có muốn nhập nhóm công việc " + Me.cbNhomCV.Value + " cho số thẻ  " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        objnhom.Setnull()
                        objnhom.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objnhom.NHOMCV_MA = Me.cbNhomCV.Value
                        objnhom.ChonBang = 1
                        Me.b.UpdateInfo(objnhom)
                        Me.Tim()
                        Me.ChonDongCu()
                        MessageBox.Show("Cập nhật thành công")
                    End If
                    
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        objnhom.Setnull()
                        objnhom.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objnhom.NHOMCV_MA = ""
                        objnhom.ChonBang = 2
                        Me.b.UpdateInfo(objnhom)
                        Me.Tim()
                        Me.ChonDongCu()
                        MessageBox.Show("Xóa thành công")
                    End If
            End Select
        End If
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        If MessageBox.Show("Bạn có muốn nhập nhóm nhân viên được chọn với nhóm công việc " + Me.cbNhomCV.Value + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            Me.dgrBC.UpdateData()
            objnhom.Setnull()
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    objnhom.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objnhom.NHOMCV_MA = Me.cbNhomCV.Value
                    objnhom.ChonBang = 1
                    Me.b.UpdateInfo(objnhom)
                End If
                i = i + 1
            End While
            Me.Tim()
            Me.ChonDongCu()
            MessageBox.Show("Cập nhật thành công")
        End If
       
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        If MessageBox.Show("Bạn có muốn nhập toàn bộ đơn vị " + Me.cbDonvi.Value + " với nhóm công việc  " + Me.cbNhomCV.Value + "  không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            Me.dgrBC.UpdateData()
            objnhom.Setnull()
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objnhom.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objnhom.NHOMCV_MA = Me.cbNhomCV.Value
                objnhom.ChonBang = 1
                Me.b.UpdateInfo(objnhom)
                i = i + 1
            End While
            Me.Tim()
            Me.ChonDongCu()
            MessageBox.Show("Đã cập nhật thành công")
        End If
       
    End Sub
End Class