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
Public Class frmTinhLuong13
    Public Shared objLuong13 As New objTinhLuong13
    Dim Tabletemp As DataTable
    Friend WithEvents b As clsBTinhLuong13
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub frmTinhLuong13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdDV.Checked = True
        Me.rdXuong.Checked = False
        loadcombo()
        'Dim obj As New objTinhLuong13
        'obj.CHONBANG = 1
        'Me.b = New clsBTinhLuong13
        'Me.Tabletemp = Me.b.LoadDS(obj)
        'Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        'Me.cbDonvi.DataSource = Me.Tabletemp
        'Me.cbDonvi.SelectedIndex = 0
        Me.dtpNam.Value = Now
        Me.Tim()
    End Sub
    Private Sub loadcombo()
        If Me.rdXuong.Checked Then
            Me.Tabletemp = Nothing
            Dim obj As New objTinhLuong13
            obj.CHONBANG = 3
            obj.LOAIBAOCAO = 1 'xuong
            Me.b = New clsBTinhLuong13
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.ValueMember = "X_MA_"
            Me.cbDonvi.DisplayMember = "X_TEN"
            Me.cbDonvi.SelectedIndex = 0
        Else
            Me.Tabletemp = Nothing
            Dim obj As New objTinhLuong13
            obj.CHONBANG = 1
            obj.LOAIBAOCAO = 2 'dv
            Me.b = New clsBTinhLuong13
            Me.Tabletemp = Me.b.LoadDS(obj)
            Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
            Me.cbDonvi.DataSource = Me.Tabletemp
            Me.cbDonvi.ValueMember = "DV_MA"
            Me.cbDonvi.DisplayMember = "TEN_DV"
            Me.cbDonvi.SelectedIndex = 0
        End If
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Dim obj As New objTinhLuong13
        obj.NAM = Me.dtpNam.Text
        obj.DONVI = Me.cbDonvi.Value
        obj.CHONBANG = 2
        If Me.rdXuong.Checked Then
            obj.LOAIBAOCAO = 1
        Else
            obj.LOAIBAOCAO = 2
        End If
        Me.Tabletemp = Me.b.LoadDS(obj)
        Locdulieu(Me.Tabletemp)
    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/TinhLuongThang13.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 11
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

    Private Sub dtpNam_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNam.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub
    Public Sub TinhLuongThang13()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", objLuong13.NV_MA))
        listpar.Add(New SqlParameter("@Nam", objLuong13.NAM))
        listpar.Add(New SqlParameter("@Luong", objLuong13.LUONG))
        listpar.Add(New SqlParameter("@Phucap", objLuong13.PHUCAP))
        listpar.Add(New SqlParameter("@Heso", objLuong13.HESO))
        listpar.Add(New SqlParameter("@Sothang", objLuong13.SOTHANG))
        Me.b.GoiThuTuc("SP_THUONGTHANG13", listpar)
        listpar.Clear()
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub EditTinhLuong()
        Me.dgrBC.UpdateData()
        Dim i As Integer = 0
        While i <= Me.dgrBC.Rows.Count - 1
            objLuong13.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
            objLuong13.NAM = Me.dtpNam.Text
            objLuong13.LUONG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Luong").Text)
            objLuong13.PHUCAP = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Phucap").Text)
            objLuong13.HESO = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Heso").Text)
            objLuong13.SOTHANG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Sothang").Text)
            TinhLuongThang13()
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
            Select Case ColA
                Case "1"
                    objLuong13.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                    objLuong13.NAM = Me.dtpNam.Text
                    objLuong13.LUONG = Double.Parse(activeCell.Row.Cells.Item("L13_Luong").Text)
                    objLuong13.PHUCAP = Double.Parse(activeCell.Row.Cells.Item("L13_Phucap").Text)
                    objLuong13.SOTHANG = Double.Parse(activeCell.Row.Cells.Item("L13_Sothang").Text)
                    Dim frm As New frmHeSo
                    frm.ShowDialog()
                    If objLuong13.FLAGTINHLUONG = True Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        TinhLuongThang13()
                    End If
                    Me.Tim()
                    Me.ChonDongCu()
                Case "3"
                    If MessageBox.Show("Bạn có muốn xóa thưởng tháng 13 của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        objLuong13.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objLuong13.NAM = Me.dtpNam.Text
                        Me.b.UpdateInfo(objLuong13)
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        Me.dgrBC.UpdateData()
        Dim frm As New frmHeSo
        frm.ShowDialog()
        If objLuong13.FLAGTINHLUONG = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                    objLuong13.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objLuong13.NAM = Me.dtpNam.Text
                    objLuong13.LUONG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Luong").Text)
                    objLuong13.PHUCAP = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Phucap").Text)
                    objLuong13.SOTHANG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Sothang").Text)

                    'Goi ham TINH LUONG
                    TinhLuongThang13()
                End If
                i = i + 1
            End While
        End If
        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        Me.dgrBC.UpdateData()
        Dim frm As New frmHeSo
        frm.ShowDialog()
        If objLuong13.FLAGTINHLUONG = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objLuong13.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                objLuong13.NAM = Me.dtpNam.Text
                objLuong13.LUONG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Luong").Text)
                objLuong13.PHUCAP = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Phucap").Text)
                objLuong13.SOTHANG = Double.Parse(Me.dgrBC.Rows(i).Cells("L13_Sothang").Text)

                TinhLuongThang13()
                i = i + 1
            End While
            MessageBox.Show("Đã cập nhật thành công")
        End If

        Me.Tim()
        Me.ChonDongCu()
    End Sub

    Private Sub lbBangThuong13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbBangThuong13.LinkClicked
        objLuong13.LOAIBAOCAO = 1
        Dim report As New frm_BangLuong13
        report.Show()
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub lblLuongThuongCaNhan_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblLuongThuongCaNhan.LinkClicked
        objLuong13.LOAIBAOCAO = 2
        Dim report As New frm_BangLuong13
        report.Show()
    End Sub

    Private Sub rdDV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDV.CheckedChanged
        Me.lblDVXUONG.Text = "Đơn vị :"
        loadcombo()

    End Sub

    Private Sub rdXuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdXuong.CheckedChanged
        Me.lblDVXUONG.Text = "Xưởng :"
        loadcombo()

    End Sub
End Class