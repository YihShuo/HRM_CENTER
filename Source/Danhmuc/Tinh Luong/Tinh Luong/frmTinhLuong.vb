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
Public Class frmTinhLuong
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBTinhLuong
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Private Sub frmTinhLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        Dim obj As New objTinhLuong
        obj.ChonBang = 1
        Me.b = New clsBTinhLuong
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0


        'obj.ChonBang = 8
        'Me.b = New clsBTinhLuong
        'Me.Tabletemp = Me.b.LoadDS(obj)
        'Me.cbThang.DataSource = Me.Tabletemp
        'Me.cbThang.SelectedIndex = 0
        Me.dtpNgay.Value = Now

        Me.Tim()
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        'Me.b = New clsBTinhLuong
        Dim NgayCC As Date
        Dim obj As New objTinhLuong
        obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()


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

        'Don Vi Nghi Viec Checked
        If Me.rdDonvinghiviec.Checked = True Then
            'Load danh sach nhan vien don vi nghi viec
            obj.ChonBang = 4
            obj.Thang = NgayCC.Month.ToString()
            obj.Nam = NgayCC.Year.ToString()
            Me.Tabletemp = Me.b.LoadDS(obj)
            Locdulieu(Me.Tabletemp)
        End If
    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TinhLuong.xml"), typeControl.Grid, "coldgrChamcongmain")
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
        For i = 0 To 10
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub rdDonvinghiviec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvinghiviec.CheckedChanged
        Me.oldRow = 0
        Me.Tim()
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
    Public Shared objLuong As New objTinhLuong
    Public Sub TinhLuong()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objLuong.NV_MA))
        listpar.Add(New SqlParameter("@T_MA", objLuong.NamThang))
        listpar.Add(New SqlParameter("@Loailuong", objLuong.LoaiLuong))
        Me.b.GoiThuTuc("SP_TINHLUONG_", listpar)
        listpar.Clear()
    End Sub
    Private Sub EditTinhLuong()
        Me.dgrBC.UpdateData()
        objLuong.Setnull()
        Dim i As Integer = 0
        While i <= Me.dgrBC.Rows.Count - 1
            objLuong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
            TinhLuong()
            i = i + 1
        End While
        MessageBox.Show("Đã cập nhật thành công")
        Me.Tim()
        Me.ChonDongCu()
    End Sub
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

            objLuong.NGUOITAO = nguoitao
            objLuong.NGAYTAO = ngaytao
            objLuong.NGUOICN = nguoicn
            objLuong.NGAYCN = ngaycn
            Select Case ColA
                Case "1"
                    objLuong.Setnull()
                    objLuong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                    objLuong.NamThang = Me.dtpNgay.Text
                    'objLuong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim frm As New frmCachTinhLuong
                    frm.ShowDialog()
                    If objLuong.FlagTinhLuong = True Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        TinhLuong()
                    End If
                    Me.Tim()
                    Me.ChonDongCu()
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        'Dim obj As New objTinhLuong
                        objLuong.Setnull()
                        objLuong.ChonBang = 1
                        objLuong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objLuong.NamThang = Me.dtpNgay.Text
                        Me.b.DeleteInfo(objLuong)

                        objLuong.ChonBang = 2
                        objLuong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objLuong.NamThang = Me.dtpNgay.Text
                        Me.b.DeleteInfo(objLuong)

                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Me.dgrBC.UpdateData()
        objLuong.Setnull()
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

        objLuong.NGUOITAO = nguoitao
        objLuong.NGAYTAO = ngaytao
        objLuong.NGUOICN = nguoicn
        objLuong.NGAYCN = ngaycn
        Dim frm As New frmCachTinhLuong
        frm.ShowDialog()
        If objLuong.FlagTinhLuong = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    objLuong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objLuong.NamThang = Me.dtpNgay.Text
                    'Goi ham TINH LUONG
                    TinhLuong()
                End If
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        Me.dgrBC.UpdateData()
        objLuong.Setnull()
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

        objLuong.NGUOITAO = nguoitao
        objLuong.NGAYTAO = ngaytao
        objLuong.NGUOICN = nguoicn
        objLuong.NGAYCN = ngaycn
        Dim frm As New frmCachTinhLuong
        frm.ShowDialog()
        If objLuong.FlagTinhLuong = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objLuong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objLuong.NamThang = Me.dtpNgay.Text
                TinhLuong()
                i = i + 1
            End While
            MessageBox.Show("Đã cập nhật thành công")
        End If

        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbBangLuong_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbBangLuong.LinkClicked
        Dim report As New frm_BangLuong
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub lbPhieuLuongCaNhan_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbPhieuLuongCaNhan.LinkClicked
        Dim report As New frm_BangLuong
        report.LoaiReport = 2
        report.Show()
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class