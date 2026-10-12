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
Public Class frmKhoanTruKhac
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBKhoanTruKhac
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmKhoanTruKhac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objKhoanTruKhac
        obj.ChonBang = 1
        Me.b = New clsBKhoanTruKhac
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0

        'obj.ChonBang = 8
        'Me.b = New clsBKhoanTruKhac
        'Me.Tabletemp = Me.b.LoadDS(obj)
        'Me.cbThang.DataSource = Me.Tabletemp
        'Me.cbThang.SelectedIndex = 0
        Me.dtpNgay.Value = Now

        Me.Tim()
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        'Me.b = New clsBTinhLuong
        Dim obj As New objKhoanTruKhac

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
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/KhoanTruKhac.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
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

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub cbThang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.oldRow = 0
        Me.Tim()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public Shared objUng As New objKhoanTruKhac
    Public sotien As Double
    Public sotien1 As Double

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Dim ngaytao As String
            Dim nguoitao As String
            Dim ngaycn As String
            Dim nguoicn As String
            nguoitao = MAIN.userclient
            nguoicn = MAIN.userclient
            Dim ngaycn1 As DateTime = Now()
            ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
            Dim ngaytao1 As DateTime = Now()
            ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString

            objUng.NGUOITAO = nguoitao
            objUng.NGAYTAO = ngaytao
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
                    Me.b = New clsBKhoanTruKhac
                    Temp = Nothing
                    Temp = Me.b.LoadDS(objUng)


                    objUng.DonVi = Me.cbDonvi.Value.ToString()

                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frmTienKhoanTruKhac
                    If activeCell.Row.Cells.Item("SOTIEN").Text = "" Then
                        frm.sotienf = 0
                    Else
                        frm.sotienf = Convert.ToDouble(activeCell.Row.Cells.Item("SOTIEN").Text)
                    End If

                    frm.ShowDialog()
                    sotien = frm.tien
                    objUng.SoTien = sotien
                    If frm.flag = False Then
                    Else
                        objUng.setvalue(objUng.NV_MA, objUng.NamThang, objUng.SoTien)
                        If Temp.Rows.Count > 0 Then
                            objUng.ChonBang = 1
                            Me.b = New clsBKhoanTruKhac
                            Me.b.UpdateInfo(objUng)
                            Me.Tim()
                            Me.ChonDongCu()
                        Else
                            objUng.ChonBang = 1
                            Me.b = New clsBKhoanTruKhac
                            Me.b.InsertInfo(objUng)
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
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

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Me.dgrBC.UpdateData()
        objUng.Setnull()
        Dim frm As New frmTienKhoanTruKhac
        frm.ShowDialog()
        sotien = frm.tien
        objUng.SoTien = sotien
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString

        objUng.NGUOITAO = nguoitao
        objUng.NGAYTAO = ngaytao
        objUng.NGUOICN = nguoicn
        objUng.NGAYCN = ngaycn
        If frm.flag = False Then
        Else
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    'Goi ham TINH LUONG

                    objUng.ChonBang = 3
                    objUng.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objUng.NamThang = Me.dtpNgay.Text
                    Dim Temp2 As New DataTable
                    Me.b = New clsBKhoanTruKhac
                    Temp2 = Nothing
                    Temp2 = Me.b.LoadDS(objUng)

                    objUng.setvalue(objUng.NV_MA, objUng.NamThang, objUng.SoTien)
                    If Temp2.Rows.Count > 0 Then
                        objUng.ChonBang = 1
                        Me.b = New clsBKhoanTruKhac
                        Me.b.UpdateInfo(objUng)
                    Else
                        objUng.ChonBang = 1
                        Me.b = New clsBKhoanTruKhac
                        Me.b.InsertInfo(objUng)
                    End If
                End If
                i = i + 1
            End While
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        Me.dgrBC.UpdateData()
        objUng.Setnull()
        Dim frm As New frmTienKhoanTruKhac
        frm.ShowDialog()
        sotien = frm.tien
        objUng.SoTien = sotien
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String
        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString

        objUng.NGUOITAO = nguoitao
        objUng.NGAYTAO = ngaytao
        objUng.NGUOICN = nguoicn
        objUng.NGAYCN = ngaycn
        If frm.flag = False Then
        Else
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1

                objUng.ChonBang = 3
                objUng.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objUng.NamThang = Me.dtpNgay.Text
                Dim Temp2 As New DataTable
                Me.b = New clsBKhoanTruKhac
                Temp2 = Nothing
                Temp2 = Me.b.LoadDS(objUng)

                objUng.setvalue(objUng.NV_MA, objUng.NamThang, objUng.SoTien)
                If Temp2.Rows.Count > 0 Then
                    objUng.ChonBang = 1
                    Me.b = New clsBKhoanTruKhac
                    Me.b.UpdateInfo(objUng)
                Else
                    objUng.ChonBang = 1
                    Me.b = New clsBKhoanTruKhac
                    Me.b.InsertInfo(objUng)
                End If
                i = i + 1
            End While
            MessageBox.Show("Đã cập nhật thành công")
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub
End Class