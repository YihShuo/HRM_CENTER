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
Public Class frmXinDiKhamBenh
    Dim Tabletemp As DataTable
    Dim Table As DataTable
    Friend WithEvents b As clsBXinDiKhamBenh
    Private Sub frmXinDiKhamBenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objXinDiKhamBenh
        obj.ChonBang = 1
        Me.b = New clsBXinDiKhamBenh
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cboNoiKCB.DataSource = Me.Tabletemp
        Me.cboNoiKCB.DisplayMember = "KCB_TEN"
        Me.cboNoiKCB.ValueMember = "KCB_MA"
        Me.cboNoiKCB.SelectedIndex = 0
        Me.dtpNgay.Value = Now
        Me.btSua.Enabled = False
        Me.btXoa.Enabled = False
        Me.btnLuu.Enabled = True
        Me.Loaddulieu()
    End Sub

    Private Sub txtSothe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSothe.TextChanged
        Dim obj As New objXinDiKhamBenh
        Dim tempTV, tempNV As DataTable
        tempTV = Nothing
        tempNV = Nothing
        obj.NV_MA = Me.txtSothe.Text

        Me.b = New clsBXinDiKhamBenh
        If Me.txtSothe.TextLength = 6 Then
            ''chua nhap hoac so the khong on tai
            obj.ChonBang = 2
            tempNV = Me.b.LoadDS(obj)
            If tempNV.Rows.Count > 0 Then
                Me.txtSothe.Text = tempNV.Rows(0).Item("NV_MA").ToString()
                Me.txtHoTen.Text = tempNV.Rows(0).Item("NV_TEN").ToString()
                Me.txtDonVi.Text = tempNV.Rows(0).Item("DV_MA").ToString()
            Else
                MessageBox.Show("Số thẻ:" & Me.txtSothe.Text & " không tìm thấy trong Hồ Sơ Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSothe.Clear()
                Me.txtSothe.Focus()
            End If

        End If
    End Sub
    Private Sub LuuDuLieu()
        Dim ma As String
        Dim dv As String
        Dim ngay As Date
        Dim ngay2 As String

        Dim noikham As String
        Dim chandoan As String
        Dim ghichu As String
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String

        ma = Me.txtSothe.Text().Trim()
        dv = Me.txtDonVi.Text().Trim()
        ngay = Me.dtpNgay.Value
        ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
        noikham = Me.cboNoiKCB.Value
        chandoan = Me.txtChanDoan.Text().Trim()
        ghichu = Me.txtGhiChu.Text().Trim()
        Dim obj As New objXinDiKhamBenh

        obj.NV_MA = ma
        obj.DONVI = dv
        obj.Ngay = ngay2
        obj.NOIKHAM = noikham
        obj.CHANDOAN = chandoan
        obj.GHICHU = ghichu

        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient

        Dim ngaytao1 As DateTime = Now()
        Dim ngaycn1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
        
        obj.NGUOITAO = nguoitao
        obj.NGAYTAO = ngaytao
        obj.NGUOICN = nguoicn
        obj.NGAYCN = ngaycn

        obj.ChonBang = 3
        Me.Table = Me.b.LoadDS(obj)
        If Me.Table.Rows.Count = 0 Then
            obj.ChonBang = 1
            Me.b.InsertInfo(obj)
            Me.Loaddulieu()
            Clear()
            MessageBox.Show("Đã lưu thành công")
        Else
            If (MessageBox.Show(("Số thẻ này đã có bạn có muốn cập nhật lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.ChonBang = 1
                Me.b.UpdateInfo(obj)
                Me.Loaddulieu()
                Me.ChonDongCu()
                MessageBox.Show("Đã lưu thành công")
            End If
            
        End If
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

    Private Sub ChonDongCu()
        If Me.dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        End If

    End Sub

    Dim oldRow As Integer = 0
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        If Me.txtSothe.Text <> "" And Me.txtChanDoan.Text <> "" And KiemTraFlag() = False Then
            LuuDuLieu()
        Else
            MessageBox.Show("Bạn chưa chọn số thẻ hoặc dữ liệu này đã bị khóa")
            Exit Sub
        End If
    End Sub
    Private Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtSothe.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.txtSothe.Enabled = False
                If Me.txtSothe.Text = "" Then
                    Exit Sub
                End If
                Me.dtpNgay.Text = activeRow.Cells.Item("KCB_NGAY").Value.ToString
                Me.dtpNgay.Enabled = False
                Me.txtChanDoan.Text = activeRow.Cells.Item("KCB_CHANDOAN").Value.ToString
                Me.cboNoiKCB.Value = activeRow.Cells.Item("KCB_NOIKCB").Value.ToString
                Me.txtGhiChu.Text = activeRow.Cells.Item("KCB_GHICHU").Text.ToString()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Function KiemTraFlag() As Boolean
        Dim obj As New objXinDiKhamBenh
        Dim TabelFalg As New DataTable()
        Dim flag As Boolean
        Dim ngay As Date
        Dim ngay2 As String
        Dim b_Flag As String
        ngay = Me.dtpNgay.Value
        ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
        obj.ChonBang = 5
        obj.Ngay = ngay2
        Me.b = New clsBXinDiKhamBenh
        TabelFalg = Me.b.LoadDS(obj)
        If TabelFalg.Rows.Count > 0 Then

            b_Flag = TabelFalg.Rows(0).Item("KCB_FLAG").ToString()
        End If
        If b_Flag = "True" Then
            flag = True
        Else
            flag = False
        End If
        Return flag
    End Function
    Private Sub Loaddulieu()
        Dim grid As New clsTformatGrid
        Dim obj As New objXinDiKhamBenh
        Dim ngay As Date
        Dim ngay2 As String
        ngay = Me.dtpNgay.Value
        ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
        obj.ChonBang = 4
        obj.Ngay = ngay2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/XINDIKHAMBENH.xml"), typeControl.Grid, "colKCB")
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        For i = 0 To 5
            e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub
    Private Sub Clear()
        Me.txtSothe.Clear()
        Me.txtHoTen.Clear()
        Me.txtDonVi.Clear()
        Me.txtChanDoan.Clear()
        Me.txtGhiChu.Clear()
    End Sub
    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Clear()
        Me.btSua.Enabled = False
        Me.btXoa.Enabled = False
        Me.btnLuu.Enabled = True
        Me.txtSothe.Enabled = True
        Me.dtpNgay.Enabled = True
    End Sub

    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.btSua.Enabled = True
        Me.btXoa.Enabled = True
        Me.btnLuu.Enabled = False
        Me.txtSothe.Enabled = False
        Me.dtpNgay.Enabled = False
        HieuChinh()
    End Sub

    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        If Me.txtSothe.Text <> "" And Me.txtChanDoan.Text <> "" And KiemTraFlag() = False Then
            LuuDuLieu()
            Me.ChonDongCu()
        Else
            MessageBox.Show("Bạn chưa chọn số thẻ hoặc dữ liệu này đã bị khóa")
            Exit Sub
        End If
    End Sub

    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate

        Dim obj As New objXinDiKhamBenh
        Dim nguoicn As String
        Dim ma As String
        Dim ngay As Date
        Dim ngay2 As String
        ngay = Me.dtpNgay.Value
        ngay2 = ngay.Year.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Day.ToString()
        If Me.txtSothe.Text <> "" And Me.txtChanDoan.Text <> "" And KiemTraFlag() = False Then
            obj.Ngay = ngay2
            ma = Me.txtSothe.Text().Trim()
            obj.NV_MA = ma
            nguoicn = MAIN.userclient
            obj.TenDangNhap = nguoicn
            obj.ChonBang = 1
            Me.Table = Me.b.LoadDS(obj)
            If Me.Table.Rows.Count > 0 Then
                If (MessageBox.Show(("Bạn có chắc chắn muốn xóa số thẻ " + ma + " không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    obj.ChonBang = 1
                    Me.b.DeleteInfo(obj)
                    Me.Loaddulieu()
                    Clear()
                    MessageBox.Show("Đã xóa thành công")
                    'End If
                End If
            Else
                MessageBox.Show("Không xóa được")
                Exit Sub
            End If
        Else
            MessageBox.Show("Bạn chưa chọn số thẻ hoặc dữ liệu này đã bị khóa")
            Exit Sub
        End If

    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Clear()
        Loaddulieu()
    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub linkNoiKCB_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkNoiKCB.LinkClicked
        Dim frm As New frmNoiDangKyKCB
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub cboNoiKCB_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboNoiKCB.BeforeDropDown
        Dim obj As New objXinDiKhamBenh
        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBXinDiKhamBenh
        Me.cboNoiKCB.DataSource = Me.b.LoadDS(obj)
        Me.cboNoiKCB.DisplayMember = "KCB_TEN"
        Me.cboNoiKCB.ValueMember = "KCB_MA"
        Me.cboNoiKCB.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
End Class