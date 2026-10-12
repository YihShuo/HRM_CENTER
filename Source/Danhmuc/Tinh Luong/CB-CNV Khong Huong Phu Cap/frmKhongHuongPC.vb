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
Public Class frmKhongHuongPC
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBKhongHuongPC
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmKhongHuongPC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objKhongHuongPC
        obj.ChonBang = 1
        Me.b = New clsBKhongHuongPC
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        'obj.ChonBang = 8
        'Me.b = New clsBKhongHuongPC
        'Me.Tabletemp = Me.b.LoadDS(obj)
        'Me.cbThang.DataSource = Me.Tabletemp
        'Me.cbThang.SelectedIndex = 0

        Me.dtpNgay.Value = Now
        Me.Tim()
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        'Me.b = New clsBTinhLuong
        Dim obj As New objKhongHuongPC
        'Don Vi Checked
        If Me.cbDonvi.SelectedIndex <> -1 Then
            'Load danh sach nhan vien theo don vi
            obj.ChonBang = 2
            obj.DonVi = Me.cbDonvi.Value.ToString()
            Me.Tabletemp = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp)
        Else
            'obj.ChonBang = 3
            'Me.Tabletemp = Me.b.LoadDS(obj)
        End If

    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/KhongPC.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 2
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub
    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Shared objkhpc As New objKhongHuongPC
    Dim MA As String
    Dim MT As Integer
    Dim CC As Integer
    Dim TN As Integer
    Dim K As Integer
    Public Sub TinhPhuCap()
        objkhpc.NamThang = Me.dtpNgay.Text
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objkhpc.NV_MA))
        listpar.Add(New SqlParameter("@T_MA", objkhpc.NamThang))
        Me.b.GoiThuTuc("SP_TINHLUONG_PC", listpar)
        listpar.Clear()
    End Sub
    Private Sub dgrBC_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgrBC.AfterCellUpdate
        If e.Cell.Value = True Then

            ' KIEM TRA XEM DA CO TRONG BANG KHONG HUONG PC CHUA

            objkhpc.ChonBang = 3
            objkhpc.NV_MA = dgrBC.Rows(e.Cell.Row.Index).Cells("NV_MA").Value.ToString()
            MA = objkhpc.NV_MA
            Dim Temp2 As New DataTable
            Me.b = New clsBKhongHuongPC
            Temp2 = Nothing
            Temp2 = Me.b.LoadDS(objkhpc)
            If Temp2.Rows.Count > 0 Then

                objkhpc.ChonBang = 1
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCMoitruong").Value.ToString() = True Then
                    objkhpc.MoiTruong = 1
                    MT = objkhpc.MoiTruong
                Else
                    objkhpc.MoiTruong = 0
                    MT = objkhpc.MoiTruong
                End If

                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCChuyencan").Value.ToString() = True Then
                    objkhpc.ChuyenCan = 1
                    CC = objkhpc.ChuyenCan
                Else
                    objkhpc.ChuyenCan = 0
                    CC = objkhpc.ChuyenCan
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCTrachnhiem").Value.ToString() = True Then
                    objkhpc.TrachNhiem = 1
                    TN = objkhpc.TrachNhiem
                Else
                    objkhpc.TrachNhiem = 0
                    TN = objkhpc.TrachNhiem
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCKhac").Value.ToString() = True Then
                    objkhpc.Khac = 1
                    K = objkhpc.Khac
                Else
                    objkhpc.Khac = 0
                    K = objkhpc.Khac
                End If
                objkhpc.setvalue(MA, MT, CC, TN, K)
                objkhpc.NV_MA = MA
                objkhpc.MoiTruong = MT
                objkhpc.ChuyenCan = CC
                objkhpc.TrachNhiem = TN
                objkhpc.Khac = K
                'objkhpc.setvalue(objkhpc.NV_MA, objkhpc.MoiTruong, objkhpc.ChuyenCan, objkhpc.TrachNhiem, objkhpc.Khac)
                If MT = 0 And CC = 0 And TN = 0 And K = 0 Then
                    Me.b = New clsBKhongHuongPC
                    Me.b.DeleteInfo(objkhpc)
                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                Else
                    Me.b = New clsBKhongHuongPC
                    Me.b.UpdateInfo(objkhpc)

                    ' tinh lai tien phu cap
                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                End If

            Else
                objkhpc.ChonBang = 1
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCMoitruong").Value.ToString() = True Then
                    objkhpc.MoiTruong = 1
                    MT = objkhpc.MoiTruong
                Else
                    objkhpc.MoiTruong = 0
                    MT = objkhpc.MoiTruong
                End If

                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCChuyencan").Value.ToString() = True Then
                    objkhpc.ChuyenCan = 1
                    CC = objkhpc.ChuyenCan
                Else
                    objkhpc.ChuyenCan = 0
                    CC = objkhpc.ChuyenCan
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCTrachnhiem").Value.ToString() = True Then
                    objkhpc.TrachNhiem = 1
                    TN = objkhpc.TrachNhiem
                Else
                    objkhpc.TrachNhiem = 0
                    TN = objkhpc.TrachNhiem
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCKhac").Value.ToString() = True Then
                    objkhpc.Khac = 1
                    K = objkhpc.Khac
                Else
                    objkhpc.Khac = 0
                    K = objkhpc.Khac
                End If
                objkhpc.setvalue(MA, MT, CC, TN, K)
                objkhpc.NV_MA = MA
                objkhpc.MoiTruong = MT
                objkhpc.ChuyenCan = CC
                objkhpc.TrachNhiem = TN
                objkhpc.Khac = K
                If MT = 0 And CC = 0 And TN = 0 And K = 0 Then
                    Exit Sub
                Else
                    Me.b = New clsBKhongHuongPC
                    Me.b.InsertInfo(objkhpc)
                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                End If

            End If
            Else
                ' KIEM TRA XEM DA CO TRONG BANG KHONG HUONG PC CHUA
            objkhpc.ChonBang = 3
            objkhpc.NV_MA = dgrBC.Rows(e.Cell.Row.Index).Cells("NV_MA").Value.ToString()
            MA = objkhpc.NV_MA
            Dim Temp2 As New DataTable
            Me.b = New clsBKhongHuongPC
            Temp2 = Nothing
            Temp2 = Me.b.LoadDS(objkhpc)
            If Temp2.Rows.Count > 0 Then

                objkhpc.ChonBang = 1
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCMoitruong").Value.ToString() = True Then
                    objkhpc.MoiTruong = 1
                    MT = objkhpc.MoiTruong
                Else
                    objkhpc.MoiTruong = 0
                    MT = objkhpc.MoiTruong
                End If

                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCChuyencan").Value.ToString() = True Then
                    objkhpc.ChuyenCan = 1
                    CC = objkhpc.ChuyenCan
                Else
                    objkhpc.ChuyenCan = 0
                    CC = objkhpc.ChuyenCan
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCTrachnhiem").Value.ToString() = True Then
                    objkhpc.TrachNhiem = 1
                    TN = objkhpc.TrachNhiem
                Else
                    objkhpc.TrachNhiem = 0
                    TN = objkhpc.TrachNhiem
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCKhac").Value.ToString() = True Then
                    objkhpc.Khac = 1
                    K = objkhpc.Khac
                Else
                    objkhpc.Khac = 0
                    K = objkhpc.Khac
                End If
                objkhpc.setvalue(MA, MT, CC, TN, K)
                objkhpc.NV_MA = MA
                objkhpc.MoiTruong = MT
                objkhpc.ChuyenCan = CC
                objkhpc.TrachNhiem = TN
                objkhpc.Khac = K
                'objkhpc.setvalue(objkhpc.NV_MA, objkhpc.MoiTruong, objkhpc.ChuyenCan, objkhpc.TrachNhiem, objkhpc.Khac)
                If MT = 0 And CC = 0 And TN = 0 And K = 0 Then
                    Me.b = New clsBKhongHuongPC
                    Me.b.DeleteInfo(objkhpc)
                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                Else
                    Me.b = New clsBKhongHuongPC
                    Me.b.UpdateInfo(objkhpc)

                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                End If
            Else

                objkhpc.ChonBang = 1
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCMoitruong").Value.ToString() = True Then
                    objkhpc.MoiTruong = 1
                    MT = objkhpc.MoiTruong
                Else
                    objkhpc.MoiTruong = 0
                    MT = objkhpc.MoiTruong
                End If

                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCChuyencan").Value.ToString() = True Then
                    objkhpc.ChuyenCan = 1
                    CC = objkhpc.ChuyenCan
                Else
                    objkhpc.ChuyenCan = 0
                    CC = objkhpc.ChuyenCan
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCTrachnhiem").Value.ToString() = True Then
                    objkhpc.TrachNhiem = 1
                    TN = objkhpc.TrachNhiem
                Else
                    objkhpc.TrachNhiem = 0
                    TN = objkhpc.TrachNhiem
                End If
                If dgrBC.Rows(e.Cell.Row.Index).Cells("NV_PCKhac").Value.ToString() = True Then
                    objkhpc.Khac = 1
                    K = objkhpc.Khac
                Else
                    objkhpc.Khac = 0
                    K = objkhpc.Khac
                End If
                objkhpc.setvalue(MA, MT, CC, TN, K)
                objkhpc.NV_MA = MA
                objkhpc.MoiTruong = MT
                objkhpc.ChuyenCan = CC
                objkhpc.TrachNhiem = TN
                objkhpc.Khac = K
                If MT = 0 And CC = 0 And TN = 0 And K = 0 Then
                    Exit Sub
                Else
                    Me.b = New clsBKhongHuongPC
                    Me.b.InsertInfo(objkhpc)
                    ' cap nhat phu cap
                    Me.TinhPhuCap()
                End If
            End If
            End If
    End Sub

    Private Sub dgrBC_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgrBC.MouseUp
        Dim i As Integer
        For i = 0 To Me.dgrBC.Rows.Count - 1
            Me.dgrBC.Rows(i).Update()
        Next
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        'Dim obj As New objTinhLuong
                        objkhpc.Setnull()
                        objkhpc.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        Me.b.DeleteInfo(objkhpc)
                        ' cap nhat phu cap
                        Me.TinhPhuCap()
                        Me.Tim()
                    End If
            End Select
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged

    End Sub

    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class