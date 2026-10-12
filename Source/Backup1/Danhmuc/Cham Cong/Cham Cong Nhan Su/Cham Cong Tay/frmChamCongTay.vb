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
Public Class frmChamCongTay
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBChamCongTay
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub Tim()
        Me.Tabletemp = Nothing
        Me.b = New clsBChamCongTay
        Dim NgayCC As Date
        NgayCC = Me.dtpNgay.Value
        Dim obj As New objChamCongTay
        obj.Ngay = NgayCC.Year.ToString() + "/" + NgayCC.Month.ToString() + "/" + NgayCC.Day.ToString()
        Dim tamDVNghiViec As DataTable
        'Don Vi Checked
        If Me.rdDonvi.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then
                'Load danh sach nhan vien theo don vi
                obj.DonVi = Me.cbDonvi.Value.ToString()
                obj.ChonBang = 20
	            tamDVNghiViec = Me.b.LoadDS(obj)	
	            If tamDVNghiViec.Rows.Count > 0 Then
	                ''==== lọc danh sách đơn vị loại nghỉ việc chọn theo cột DV_MA 
	                obj.LoaiDonViNghiViec = 1
	            Else
	                obj.LoaiDonViNghiViec = 0
	            End If
	            
                obj.ChonBang = 2                
                Me.Tabletemp = Me.b.LoadDS(obj)
                Locdulieu(Me.Tabletemp)
            Else
                obj.ChonBang = 3
                Me.Tabletemp = Me.b.LoadDS(obj)
                'Locdulieu(Me.Tabletemp)
            End If
        End If
        'DON VI PROMAZ DUOC CHECK
        If Me.radPro.Checked = True Then
            If Me.cbDonvi.SelectedIndex <> -1 Then

                'Load danh sach nhan vien theo don vi
                obj.ChonBang = 9
                obj.DonVi = Me.cbDonvi.Value.ToString()
                Me.Tabletemp = Me.b.LoadDS(obj)
                LocdulieuPro(Me.Tabletemp)
            Else
                obj.ChonBang = 11
                Me.Tabletemp = Me.b.LoadDS(obj)
            End If
        End If
    End Sub
    Private Sub LocdulieuPro(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        'Me.dgrBC.UpdateData()
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ChamCongTayPro.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub
    Dim oldRow As Integer = 0
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/ChamCongTay.xml"), typeControl.Grid, "coldgrChamcongmain")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
        If TableDS.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Activated = True
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub

    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonvi.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        Me.oldRow = 0
        Me.Tim()
    End Sub

    Private Sub rdDonvinghiviec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.oldRow = 0
        Me.Tim()
    End Sub
    Dim TableND As DataTable
    Private Sub rdDonvi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdDonvi.CheckedChanged
        If Me.rdDonvi.Checked = True Then
            Me.oldRow = 0
            Me.Tim()
        End If
    End Sub
    Public Shared objChamCong As New objChamCongTay
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs)

    End Sub
    Private Sub ChonDongCu()
        If Me.dgrBC.Rows.Count > 0 Then
            Me.dgrBC.Rows(oldRow).Selected = True
        End If
    End Sub
    Private Sub EditChamcong()
        Dim listpar As New ArrayList(16)
        objChamCong.NgayChamCong = objChamCong.TuNgay

        While objChamCong.NgayChamCong <= objChamCong.DenNgay
            listpar.Add(New SqlParameter("@Ngay", objChamCong.NgayChamCong))
            listpar.Add(New SqlParameter("@NV_MA", objChamCong.NV_MA))
            listpar.Add(New SqlParameter("@CHK_Som", objChamCong.TinhTangCaSom))
            listpar.Add(New SqlParameter("@CHK_TINHDUCONG", objChamCong.LuonTinhDuCong))
            listpar.Add(New SqlParameter("@CHK_TINHTANGCA", objChamCong.TinhTangCa))
            listpar.Add(New SqlParameter("@CHK_TINHLAMDEM", objChamCong.TinhLamDemTuLuc))
            listpar.Add(New SqlParameter("@CHK_DUCONGKHIDU", objChamCong.TinhDuCongKhiDiDu))
            listpar.Add(New SqlParameter("@CHK_GIOIHANTANGCA", objChamCong.GioiHanTangCaToiDa))
            listpar.Add(New SqlParameter("@CHK_GIAILAOTANGCA", objChamCong.GiaiLaoTangCa))
            listpar.Add(New SqlParameter("@DUCONGKHIDU", objChamCong.sTinhDuCongKhiDiDu))
            listpar.Add(New SqlParameter("@GIOIHANTANGCA", objChamCong.sGioiHanTangCaToiDa))
            listpar.Add(New SqlParameter("@GIAILAOTANGCA", objChamCong.sGiaiLaoTangCa))
            listpar.Add(New SqlParameter("@TINHLAMDEM", "2000-01-01 " & objChamCong.sTinhLamDemTuLuc))
            listpar.Add(New SqlParameter("@HESONGAYCONG", objChamCong.HeSoNgayCong))
            listpar.Add(New SqlParameter("@CHK_DITRE", objChamCong.KhongTinhDiTre))
            listpar.Add(New SqlParameter("@CHK_QUEN", objChamCong.KhongTinhQuenQuetThe))
            listpar.Add(New SqlParameter("@CHK_LUONDITRE", objChamCong.LuonTinhDiTre))
            listpar.Add(New SqlParameter("@CHK_LUONQUENQT", objChamCong.LuonTinhQuenQuetThe))
            Me.b.GoiThuTuc("SP_CHAMCONGN_", listpar)
            listpar.Clear()
            objChamCong.NgayChamCong = objChamCong.NgayChamCong.AddDays(1)
        End While
    End Sub
    Private Sub Editvaora()
        'Load nhan vien co ma so tai ngay cham cong
        objChamCong.ChonBang = 5
        Me.b = New clsBChamCongTay
        Me.Tabletemp = Me.b.LoadDS(objChamCong)
        If Me.Tabletemp.Rows.Count > 0 Then
            'MessageBox.Show("Update vaoratay vao bang st_gioquetthe")
            objChamCong.ChonBang = 1
            Me.b.UpdateInfo(objChamCong)
        Else
            'MessageBox.Show("insert vaoratay vao bang st_gioquetthe")
            Me.b.InsertInfo(objChamCong)
        End If
    End Sub
    Public frm As New frmBuaAn
    Private Sub EditChamCom()
        'Load nhan vien co ma so tai ngay cham cong
        objChamCong.ChonBang = 5
        Me.b = New clsBChamCongTay
        Me.Tabletemp = Me.b.LoadDS(objChamCong)
        If Me.Tabletemp.Rows.Count > 0 Then
            'MessageBox.Show("Update bua an vao bang st_gioquetthe_")
            objChamCong.ChonBang = 2
            Me.b.UpdateInfo(objChamCong)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub lbNhom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhom.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Me.dgrBC.UpdateData()
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmChamCongTayEX
            frm.ShowDialog()
            If objChamCong.FlagChamCong = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then

                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        'Goi ham cham cong (SP_CHAMCONGN)
                        EditChamcong()
                    End If
                    i = i + 1
                End While
            End If
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbToanbo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbo.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmChamCongTayEX
            frm.ShowDialog()
            If objChamCong.FlagChamCong = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    'Goi ham cham cong (SP_CHAMCONGN)
                    EditChamcong()
                    i = i + 1
                End While
            End If
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbNhomvaora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhomvaora.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Me.dgrBC.UpdateData()
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmChamCongTayVaoRa
            frm.ShowDialog()
            If objChamCong.FlagChamVaoRa = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        Editvaora()
                    End If
                    i = i + 1
                End While
            End If
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub lbToanbovaora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanbovaora.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            objChamCong.Setnull()
            objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
            Dim frm As New frmChamCongTayVaoRa
            frm.ShowDialog()
            If objChamCong.FlagChamVaoRa = True Then
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    Editvaora()
                    i = i + 1
                End While
            End If
            Me.Tim()
            Me.ChonDongCu()
        End If
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim report As New frmReportChamCongTay
        report.LoaiReport = 1
        report.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim report As New frmReportChamCongTay
        report.LoaiReport = 2
        report.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim report As New frmReportChamCongTay
        report.LoaiReport = 3
        report.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim report As New frmReportChamCongTay
        report.LoaiReport = 4
        report.Show()
    End Sub

    Private Sub lbCapnhatnghiphep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        objChamCong.Setnull()
        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
        Dim frm As New frmCapnhatnghiphep
        frm.ShowDialog()
        If objChamCong.FlagChamCong = True Then
            Dim i As Integer = 0
            While i <= Me.dgrBC.Rows.Count - 1
                objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                'Goi ham cap nhat nghi phep (SP_CAPNHATNGHIPHEP)
                Capnhatphep()
                i = i + 1
            End While
        End If
        Me.Tim()
    End Sub
    Private Sub Capnhatphep()
        Dim listpar As New ArrayList(1)
        objChamCong.NgayChamCong = objChamCong.TuNgay

        While objChamCong.NgayChamCong <= objChamCong.DenNgay
            listpar.Add(New SqlParameter("@Ngay", objChamCong.NgayChamCong))
            listpar.Add(New SqlParameter("@NV_MA", objChamCong.NV_MA))
            Me.b.GoiThuTuc("SP_CAPNHATNGHIPHEP", listpar)
            listpar.Clear()

            objChamCong.NgayChamCong = objChamCong.NgayChamCong.AddDays(1)
        End While
    End Sub

    Private Sub dgrBC_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("GIOVAOTAY").Header.Appearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("GIORATAY").Header.Appearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("GIOVAOTAY").CellAppearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("GIORATAY").CellAppearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("CC_SUATAN").Header.Appearance.ForeColor = Color.Red
        e.Layout.Bands(0).Columns("CC_SUATAN").Header.Appearance.ForeColor = Color.Red

        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("3").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 21
            If i <> 1 Then
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub dgrBC_DoubleClickCell_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        objChamCong.Setnull()
                        objChamCong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        Dim frm As New frmChamCongTayEX
                        frm.ShowDialog()
                        If objChamCong.FlagChamCong = True Then
                            'Goi ham cham cong (SP_CHAMCONGN)
                            EditChamcong()
                        End If
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
                Case "3"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        If MessageBox.Show("Bạn có muốn xóa record của nhân viên " + activeCell.Row.Cells.Item("NV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                            Dim obj As New objChamCongTay
                            obj.Setnull()
                            obj.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                            obj.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                            Me.b.DeleteInfo(obj)
                            Me.Tim()
                            Me.ChonDongCu()
                        End If
                    End If
                Case "GIOVAOTAY", "GIORATAY"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        objChamCong.Setnull()
                        objChamCong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        objChamCong.CA_Ma = activeCell.Row.Cells.Item("MACA").Text

                        Dim frm As New frmChamCongTayVaoRa
                        frm.ShowDialog()
                        If objChamCong.FlagChamVaoRa = True Then
                            'Goi ham cham vao ra ()
                            Editvaora()
                        End If
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
                Case "CC_SUATAN"
                    If MAIN.USER_KT = True Then
                        Exit Sub
                    Else
                        objChamCong.Setnull()
                        objChamCong.NV_MA = activeCell.Row.Cells.Item("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        objChamCong.CA_Ma = activeCell.Row.Cells.Item("MACA").Text

                        Dim frm As New frmBuaAn
                        frm.radTuDong.Hide()
                        frm.radSoBuaan.Checked = True
                        frm.ShowDialog()
                        If objChamCong.FlagChamCom = True Then
                            'Goi ham cham vao ra ()
                            EditChamCom()
                        End If
                        Me.Tim()
                        Me.ChonDongCu()
                    End If
            End Select
        End If
    End Sub

    Private Sub lbNhomBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNhomBA.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Dim frm As New frmBuaAn
            frm.ShowDialog()
            If frm.radTuDong.Checked = True Then
                If (MessageBox.Show(("Bạn có muốn cập nhật suất ăn không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.dgrBC.UpdateData()
                    objChamCong.Setnull()
                    objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim i As Integer = 0
                    While i <= Me.dgrBC.Rows.Count - 1
                        If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                            objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                            CapNhatCom()
                            'MessageBox.Show(Me.dgrBC.Rows(i).Cells(1).Value)
                        End If
                        i = i + 1
                    End While
                    MessageBox.Show("Đã cập nhật thành công")
                    Me.Tim()
                    Me.ChonDongCu()
                Else
                    Exit Sub
                End If
            ElseIf frm.radSoBuaan.Checked = True Then
                Me.dgrBC.UpdateData()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    If Me.dgrBC.Rows(i).Cells(1).Value = True Then
                        objChamCong.ChamCom = frm.txtSoBuaAn.Text
                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                        objChamCong.CA_Ma = Me.dgrBC.Rows(i).Cells("MACA").Text

                        EditChamCom()
                    End If
                    i = i + 1
                End While
                MessageBox.Show("Đã cập nhật thành công")
                Me.Tim()
                Me.ChonDongCu()
            End If
        End If
    End Sub
    Public Sub CapNhatCom()
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@Ngay", objChamCong.Ngay))
        listpar.Add(New SqlParameter("@NV_MA", objChamCong.NV_MA))
        Me.b.GoiThuTuc("SP_CAPNHATSUATAN_", listpar)
        listpar.Clear()
    End Sub
    Private Sub lbToanBoBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbToanBoBA.Click
        If MAIN.USER_KT = True Then
            Exit Sub
        Else
            Dim frm As New frmBuaAn
            frm.ShowDialog()
            If frm.radTuDong.Checked = True Then
                If (MessageBox.Show(("Bạn có muốn cập nhật suất ăn không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    Me.dgrBC.UpdateData()
                    objChamCong.Setnull()
                    objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    Dim i As Integer = 0
                    While i <= Me.dgrBC.Rows.Count - 1
                        objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                        CapNhatCom()
                        i = i + 1
                    End While
                    MessageBox.Show("Đã cập nhật thành công")
                    Me.Tim()
                    Me.ChonDongCu()
                Else
                    Exit Sub
                End If
            ElseIf frm.radSoBuaan.Checked = True Then
                Me.dgrBC.UpdateData()
                Dim i As Integer = 0
                While i <= Me.dgrBC.Rows.Count - 1
                    objChamCong.ChamCom = frm.txtSoBuaAn.Text
                    objChamCong.NV_MA = Me.dgrBC.Rows(i).Cells("NV_MA").Text
                    objChamCong.Ngay = Me.dtpNgay.Value.Year.ToString() + "/" + Me.dtpNgay.Value.Month.ToString() + "/" + Me.dtpNgay.Value.Day.ToString()
                    objChamCong.CA_Ma = Me.dgrBC.Rows(i).Cells("MACA").Text

                    EditChamCom()
                    i = i + 1
                End While
                MessageBox.Show("Đã cập nhật thành công")
                Me.Tim()
                Me.ChonDongCu()
            End If
        End If
    End Sub

    Private Sub radDonViPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub radPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPro.CheckedChanged
        'If Me.radPro.Checked = True Then
        '    Me.rdDonvi.Checked = False
        '    Me.cbDonvi.Enabled = False
        '    Me.cbDonViPro.Enabled = True
        '    Me.dgrBC.DataSource = Nothing

        '    Dim obj As New objChamCongTay
        '    obj.ChonBang = 1
        '    Me.b = New clsBChamCongTay
        '    Me.Tabletemp = Me.b.LoadDS(obj)
        '    Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        '    Me.cbDonViPro.DataSource = Me.Tabletemp
        '    Me.cbDonViPro.SelectedIndex = 0
        'Else
        '    Me.cbDonViPro.Text = ""
        'End If
        'Me.oldRow = 0
        'Me.Tim()
        If Me.radPro.Checked = True Then
            Me.oldRow = 0
            Me.Tim()
        Else
            'Me.cbDonvi.Text = ""
        End If
    End Sub
    Private Sub ChamComTuDong()
        Dim listpar As New ArrayList(1)

        Dim NGAY As Date
        NGAY = dtpNgay.Text
        Dim ngaycc As String = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()

        If NGAY < Now.Date Then
            objChamCong.NgayChamCong = ngaycc

            listpar.Add(New SqlParameter("@Ngay", objChamCong.NgayChamCong))
            Me.b.GoiThuTuc("SP_CHAMCOMNGOAIGIO_TUDONG", listpar)
            listpar.Clear()
            MessageBox.Show("Đã chấm cơm thành công")
        Else
            MessageBox.Show("Ngày chấm cơm phải nhỏ hơn ngày hiện tại")
        End If

    End Sub
    Private Sub lnkChamComToanBo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChamComToanBo.LinkClicked
        If (MessageBox.Show(("Bạn có chắc đã chấm công ngoài giờ rồi chưa?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            ChamComTuDong()
        End If
    End Sub

    Private Sub frmChamCongTay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
        Me.b = New clsBChamCongTay
        Dim i As Integer
        Dim obj As New objChamCongTay

        '        Dim nguoidung As String = MAIN.userclient.ToLower()
        '        obj.NGUOIDUNG = nguoidung
        '        If nguoidung = "admin" Then
        '            obj.ChonBang = 1
        '            GoTo LAP
        '        End If
        '        obj.MA_DM = "1" + Me.Name
        '        obj.ChonBang = 21
        '        Me.b = New clsBChamCongTay
        '        Me.TableND = Me.b.LoadDS(obj)
        '        Dim KHUA As Boolean
        '        Dim KHUB As Boolean
        '        KHUA = TableND.Rows(0).Item("KHUA").ToString
        '        KHUB = TableND.Rows(0).Item("KHUB").ToString
        '        If KHUA = True And KHUB = False Then
        '            obj.ChonBang = 22
        '            GoTo LAP
        '        ElseIf KHUA = False And KHUB = True Then
        '            obj.ChonBang = 23
        '            GoTo LAP
        '        ElseIf KHUA = True And KHUB = True Then
        '            obj.ChonBang = 1
        '            GoTo LAP
        '        Else
        '            obj.ChonBang = 1
        '            GoTo LAP
        '        End If
        'LAP:

        obj.ChonBang = 1
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.Tabletemp.Rows.Add("TCT", "全部公司Toàn công ty")
        Me.cbDonvi.DataSource = Me.Tabletemp
        Me.cbDonvi.SelectedIndex = 0
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub
End Class