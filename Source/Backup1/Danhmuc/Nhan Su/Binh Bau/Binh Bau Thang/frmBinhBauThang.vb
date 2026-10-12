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
Public Class frmBinhBauThang
    Dim Tabletemp As DataTable
    Dim TabletempDem As DataTable

    Friend WithEvents b As clsBBinhBauThang
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmBinhBauThang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objBinhBauThang
        obj.ChonBang = 1
        Me.b = New clsBBinhBauThang
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
        Dim obj As New objBinhBauThang
        'Don Vi Checked
        If Me.cbDonvi.SelectedIndex <> -1 Then
            'Load danh sach nhan vien theo don vi
            obj.ChonBang = 2
            obj.DV_MA = Me.cbDonvi.Value.ToString()
            obj.THANG = Me.dtpNgay.Text
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
        'Me.dgrBC.UpdateData()
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/BBTHANG.xml"), typeControl.Grid, "coldgrhoso")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()

        Dim obj As New objBinhBauThang
        obj.ChonBang = 4
        obj.DV_MA = Me.cbDonvi.Value.ToString()
        obj.THANG = Me.dtpNgay.Text
        Me.TabletempDem = Me.b.LoadDS(obj)
        If Not Me.TabletempDem Is Nothing Then
            If Me.TabletempDem.Rows.Count > 0 Then
                Me.txtA.Text = Me.TabletempDem.Rows(0).Item("A").ToString()
                Me.txtB.Text = Me.TabletempDem.Rows(0).Item("B").ToString()
                Me.txtC.Text = Me.TabletempDem.Rows(0).Item("C").ToString()
                Me.txtD.Text = Me.TabletempDem.Rows(0).Item("D").ToString()
                Me.txtOX.Text = Me.TabletempDem.Rows(0).Item("OX").ToString()
                Me.txtHS.Text = Me.TabletempDem.Rows(0).Item("HS").ToString()
                Me.txtST.Text = Me.TabletempDem.Rows(0).Item("ST").ToString()
            End If

        End If

        If TableDS.Rows.Count > 0 Then
            If TableDS.Rows.Count < oldRow Then
                Exit Sub
            Else
                Me.dgrBC.Rows(oldRow).Activated = True
            End If

        End If
    End Sub

    Dim oldRow As Integer = 0

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
        Application.DoEvents()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public Shared objBB As New objBinhBauThang

    Public Sub TinhBinhBau()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objBB.NV_MA))
        listpar.Add(New SqlParameter("@T_Ma", objBB.THANG))
        listpar.Add(New SqlParameter("@Binhbau", objBB.Binhbau))
        Me.b.GoiThuTuc("SP_BINHBAUTHANG", listpar)
        listpar.Clear()
    End Sub
    Private Sub EditTinhBinhBau()
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim i As Integer = 0
        While i <= Me.dgrBC.Rows.Count - 1
            objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
            Me.TinhBinhBau()
            i = i + 1
        End While
        MessageBox.Show("Đã cập nhật thành công")
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim frm As New frm_LoaiBB
        frm.ShowDialog()
        If objBB.FlagTinhBinhBau = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objBB.THANG = Me.dtpNgay.Text
                    'Goi ham TINH binh bau
                    Me.TinhBinhBau()
                End If
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        Me.dgrBC.UpdateData()
        objBB.Setnull()
        Dim frm As New frm_LoaiBB
        frm.ShowDialog()
        If objBB.FlagTinhBinhBau = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objBB.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objBB.THANG = Me.dtpNgay.Text
                TinhBinhBau()
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


    'Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs)

    'End Sub


    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub mnToanBo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnToanBo.Click
        Dim i As Integer
        While i <= Me.dgrBC.Rows.Count - 1
            Me.dgrBC.Rows(i).Cells(1).Value = True
            i = i + 1
        End While
    End Sub

    Private Sub mnBoChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBoChon.Click
        Dim i As Integer
        While i <= Me.dgrBC.Rows.Count - 1
            Me.dgrBC.Rows(i).Cells(1).Value = False
            i = i + 1
        End While
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("BB_Ma").Header.Appearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 24
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i

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
                    objBB.THANG = Me.dtpNgay.Text
                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frm_LoaiBB
                    frm.ShowDialog()
                    If objBB.FlagTinhBinhBau = True Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        Me.TinhBinhBau()
                        'Locdulieu(Me.Tabletemp)
                    End If
                    Me.Tim()
                    Me.ChonDongCu()
                Case "BB_Ma"
                    objBB.Setnull()
                    objBB.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                    objBB.THANG = Me.dtpNgay.Text
                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frm_LoaiBB
                    frm.ShowDialog()
                    If objBB.FlagTinhBinhBau = True Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        Me.TinhBinhBau()
                        'Locdulieu(Me.Tabletemp)
                    End If
                    Me.Tim()
                    Me.ChonDongCu()
            End Select
        End If
    End Sub

  

  
End Class