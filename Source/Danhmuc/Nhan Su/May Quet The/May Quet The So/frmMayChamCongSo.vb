Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinListView.UltraListViewItem
Imports Infragistics.Win.UltraWinListView.UltraListViewSubItemColumn
Imports Infragistics.Win.AutoCompleteMode
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlParameter
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Public Class frmMayChamCongSo

    Public MaySo As String
    Public Shared SoMayThayThe As Integer = 0


    Friend WithEvents b As clsBMayChamCongSo

    Private Sub frmPhanCa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtSomay.Text = MaySo
        Me.LoadDS()
        Me.LoadDSDUOCPHEPQUET()

        clsTools.GridTheme1(Me.dgrBC)
        Me.methodLoad()
    End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objMayChamCongSo

        obj.Setnull()
        obj.ChonBang = 1
        obj.SoMay = MaySo
        Me.b = New clsBMayChamCongSo
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/MayChamCongSo.xml"), typeControl.Grid, "coldgrMayChamCongSo")
    End Sub

    'Private Sub btHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuy.Click
    '    'Dua nhung nhan vien duoc check vao luoi nhan vien 
    '    Dim lvi_nv As UltraListViewItem
    '    Dim Ma, Hoten, Ca, NgayBatDau, NgayKetThuc As String
    '    Dim nRow As Integer = 0
    '    While nRow < Me.clbNhanvienchon.Items.Count
    '        If Me.clbNhanvienchon.Items(nRow).CheckState = CheckState.Checked Then
    '            Ma = Me.clbNhanvienchon.Items(nRow).Value
    '            Hoten = Me.clbNhanvienchon.Items(nRow).SubItems(0).Value
    '            Ca = Me.clbNhanvienchon.Items(nRow).SubItems(1).Value
    '            NgayBatDau = Me.clbNhanvienchon.Items(nRow).SubItems(2).Value
    '            NgayKetThuc = Me.clbNhanvienchon.Items(nRow).SubItems(3).Value
    '            lvi_nv = New UltraListViewItem(Ma, New UltraListViewSubItem() {New UltraListViewSubItem(Hoten, Nothing), New UltraListViewSubItem(Ca, Nothing), New UltraListViewSubItem(NgayBatDau, Nothing), New UltraListViewSubItem(NgayKetThuc, Nothing)}, Nothing)
    '            Me.clbNhanvien.Items.Add(lvi_nv)
    '        End If
    '        nRow = nRow + 1
    '    End While
    '    'Xoa nhung nhan vien da duoc dua vao list nhan vien duoc chon
    '    nRow = 0
    '    While nRow < Me.clbNhanvienchon.Items.Count
    '        If Me.clbNhanvienchon.Items(nRow).CheckState = CheckState.Checked Then
    '            Me.clbNhanvienchon.Items.RemoveAt(nRow)
    '        Else
    '            nRow = nRow + 1
    '        End If
    '    End While
    '    txtTongkchon.Text = Me.clbNhanvien.Items.Count()
    '    txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
    'End Sub

    '    Private Sub chbCa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCa.CheckedChanged
    '        Me.cbCa.Enabled() = Me.chbCa.Checked()
    '    End Sub

    '    Private Sub chbNgaybatdau_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgaybatdau.CheckedChanged
    '        Me.dtpNgayBatDau.Enabled() = Me.chbNgaybatdau.Checked()
    '    End Sub

    '    Private Sub chbNgayketthuc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNgayketthuc.CheckedChanged
    '        Me.dtpNgayKetThuc.Enabled() = Me.chbNgayketthuc.Checked()
    '    End Sub

    '    Private Sub chbGiobatdau_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGiobatdau.CheckedChanged
    '        Me.dtpGioBatDau.Enabled() = Me.chbGiobatdau.Checked()
    '    End Sub

    '    Private Sub chbGioketthuc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGioketthuc.CheckedChanged
    '        Me.dtpGioKetThuc.Enabled() = Me.chbGioketthuc.Checked()
    '    End Sub

    '    Private Sub cbDonVi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDonVi.ValueChanged
    '        'Me.LoadDS()
    '    End Sub

    Private Sub LoadDS()
        Dim obj As New objMayChamCongSo
        obj.ChonBang = 2
        obj.SoMay = MaySo
        Me.b = New clsBMayChamCongSo
        Dim table As New DataTable
        table = Me.b.LoadDS(obj)

        'If table.Rows.Count = 0 Then
        '    'MessageBox.Show("Không có nhân viên trong đơn vị này!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.clbNhanvien.Items.Clear()
        '    Me.clbNhanvienchon.Items.Clear()
        '    txtTongkchon.Text = Me.clbNhanvien.Items.Count()
        '    txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
        '    Exit Sub
        'End If

        Dim lvi_nv As UltraListViewItem
        Dim row As DataRow
        Me.clbCacdonvikhongduocquet.Items.Clear()
        Dim nRow As Integer = 0
        While nRow < table.Rows.Count
            row = table.Rows(nRow)
            lvi_nv = New UltraListViewItem(row("DV_MA").ToString, New UltraListViewSubItem() {New UltraListViewSubItem(row("DV_TEN").ToString, Nothing), New UltraListViewSubItem(row("QT_SOMAY1").ToString, Nothing), New UltraListViewSubItem(row("QT_SOMAY2").ToString, Nothing)}, Nothing)
            Me.clbCacdonvikhongduocquet.Items.Add(lvi_nv)
            nRow += 1
        End While
        Me.txtTongvitri.Text = Me.clbCacdonvikhongduocquet.Items.Count

    End Sub

    Private Sub LoadDSDUOCPHEPQUET()
        Dim obj As New objMayChamCongSo
        obj.ChonBang = 3
        obj.SoMay = MaySo
        Me.b = New clsBMayChamCongSo
        Dim table As New DataTable
        table = Me.b.LoadDS(obj)

        'If table.Rows.Count = 0 Then
        '    'MessageBox.Show("Không có nhân viên trong đơn vị này!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.clbNhanvien.Items.Clear()
        '    Me.clbNhanvienchon.Items.Clear()
        '    txtTongkchon.Text = Me.clbNhanvien.Items.Count()
        '    txtTongchon.Text = Me.clbNhanvienchon.Items.Count()
        '    Exit Sub
        'End If

        Dim lvi_nv As UltraListViewItem
        Dim row As DataRow
        Me.clbCacdonviduocphepquet.Items.Clear()
        Dim nRow As Integer = 0
        While nRow < table.Rows.Count
            row = table.Rows(nRow)
            lvi_nv = New UltraListViewItem(row("DV_MA").ToString, New UltraListViewSubItem() {New UltraListViewSubItem(row("DV_TEN").ToString, Nothing), New UltraListViewSubItem(row("QT_SOMAY1").ToString, Nothing), New UltraListViewSubItem(row("QT_SOMAY2").ToString, Nothing)}, Nothing)
            Me.clbCacdonviduocphepquet.Items.Add(lvi_nv)
            nRow += 1
        End While
        Me.txtTongvitriduocquet.Text = Me.clbCacdonviduocphepquet.Items.Count

    End Sub

    '    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
    '        'Kiem tra ngay ket thuc lon hon ngay bat dau
    '        If Me.KiemTra() = True Then
    '            Exit Sub
    '        End If

    '        'Bakup du lieu cu
    '        'If MessageBox.Show("Bạn có muốn sao lưu (Bakup) thông tin phân ca lần trước lại không", "Bakup Dữ Liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        '    Me.Bakup()
    '        'End If

    '        'Dinh dang ngay theo kieu yyyy-mm-dd
    '        Dim NgayBD As Date = Me.dtpNgayBatDau.Value
    '        Dim NgayBatDau As String = NgayBD.Year.ToString + "-" + NgayBD.Month.ToString + "-" + NgayBD.Day.ToString
    '        Dim NgayKT As Date = Me.dtpNgayKetThuc.Value
    '        Dim NgayKetThuc As String = NgayKT.Year.ToString + "-" + NgayKT.Month.ToString + "-" + NgayKT.Day.ToString

    '        Dim Ma As String
    '        Dim nRow As Integer = 0
    '        While nRow < Me.clbNhanvienchon.Items.Count
    '            Ma = Me.clbNhanvienchon.Items(nRow).Value
    '            'MessageBox.Show(Ma)
    '            Dim table As New DataTable
    '            Dim obj As New objPhanCa
    '            obj.ChonBang = 4
    '            obj.ID = Ma
    '            Me.b = New clsBPhanCa
    '            table = Me.b.LoadDS(obj)
    '            If table.Rows.Count > 0 Then
    '                'MessageBox.Show("Cap Nhat")
    '                obj.Setnull()
    '                obj.setvalue(Ma, Me.cbCa.Text, NgayBatDau, NgayKetThuc, Me.dtpGioBatDau.Text, Me.dtpGioKetThuc.Text, Me.cbDonVi.Text)
    '                Me.b.UpdateInfo(obj)
    '            Else
    '                'MessageBox.Show("Insert")
    '                obj.Setnull()
    '                obj.setvalue(Ma, Me.cbCa.Text, NgayBatDau, NgayKetThuc, Me.dtpGioBatDau.Text, Me.dtpGioKetThuc.Text, Me.cbDonVi.Text)
    '                Me.b.InsertInfo(obj)
    '            End If
    '            nRow = nRow + 1
    '        End While
    '        MessageBox.Show("Đã lưu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Me.methodLoad()
    '    End Sub

   
    '    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
    '        Me.XoaDuLieu()
    '    End Sub

    '    Public Sub XoaDuLieu()
    '        Try
    '            Dim obj As New objPhanCa
    '            If (Me.dgrBC.Selected.Rows.Count > 0) Then

    '                '1========Neu chi co mot dong duoc chon===============================
    '                If (Me.dgrBC.Selected.Rows.Count = 1) Then
    '                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
    '                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
    '                        obj.NV_MA = StringType.FromObject(activeRow.Cells.Item("NV_MA").Value)
    '                        If Me.b.IsDeleteOK(obj) Then
    '                            If (MessageBox.Show("Bạn có muốn xoá dòng được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
    '                                If Me.b.DeleteInfo(obj) Then
    '                                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                                    GoTo Label_0274
    '                                End If
    '                                MessageBox.Show("Xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '                            End If
    '                        Else
    '                            MessageBox.Show("Không thể xoá nhân viên " + obj.NV_MA + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        End If
    '                    End If
    '                    Return
    '                End If

    '                '2==============================================
    '                If (MessageBox.Show(("Bạn muốn xoá " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " dòng đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
    '                    Return
    '                End If

    '                '3==========Neu co nhieu dong duoc chon========================================
    '                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
    '                Dim i As Integer = 0
    '                Do While (i <= num2)
    '                    obj.Setnull()
    '                    obj.NV_MA = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("NV_MA").Value)
    '                    If Me.b.IsDeleteOK(obj) Then
    '                        If Me.b.DeleteInfo(obj) Then
    '                            'MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '                        Else
    '                            MessageBox.Show("Xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '                        End If
    '                    Else
    '                        MessageBox.Show("Không thể xoá nhân viên " + obj.NV_MA + ". ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    End If
    '                    i += 1
    '                Loop

    '            End If
    'Label_0274:
    '            Me.methodLoad()
    '        Catch exception1 As Exception
    '            ProjectData.SetProjectError(exception1)
    '            Dim exception As Exception = exception1
    '            ProjectData.ClearProjectError()
    '        End Try
    '    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btThoat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btChon.Click
        'Dua nhung nhan vien duoc check vao luoi nhan vien chon
        Dim lvi_nv As UltraListViewItem
        Dim MaDV, TenDV, SoMay1, SoMay2 As String
        Dim nRow As Integer = 0
        While nRow < clbCacdonvikhongduocquet.Items.Count
            If Me.clbCacdonvikhongduocquet.Items(nRow).CheckState = CheckState.Checked Then
                MaDV = Me.clbCacdonvikhongduocquet.Items(nRow).Value
                TenDV = Me.clbCacdonvikhongduocquet.Items(nRow).SubItems(0).Value
                SoMay1 = Me.clbCacdonvikhongduocquet.Items(nRow).SubItems(1).Value
                SoMay2 = Me.clbCacdonvikhongduocquet.Items(nRow).SubItems(2).Value
                lvi_nv = New UltraListViewItem(MaDV, New UltraListViewSubItem() {New UltraListViewSubItem(TenDV, Nothing), New UltraListViewSubItem(SoMay1, Nothing), New UltraListViewSubItem(SoMay2, Nothing)}, Nothing)
                Me.clbCacdonviduocphepquet.Items.Add(lvi_nv)
            End If
            nRow = nRow + 1
        End While

        'Xoa nhung nhan vien da duoc dua vao list nhan vien duoc chon
        nRow = 0
        While nRow < Me.clbCacdonvikhongduocquet.Items.Count
            If Me.clbCacdonvikhongduocquet.Items(nRow).CheckState = CheckState.Checked Then
                Me.clbCacdonvikhongduocquet.Items.RemoveAt(nRow)
            Else
                nRow = nRow + 1
            End If
        End While
        txtTongvitri.Text = Me.clbCacdonvikhongduocquet.Items.Count()
        txtTongvitriduocquet.Text = Me.clbCacdonviduocphepquet.Items.Count()
    End Sub

    Private Sub btHuychon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuychon.Click
        'Dua nhung nhan vien duoc check vao luoi nhan vien chon
        Dim lvi_nv As UltraListViewItem
        Dim MaDV, TenDV, SoMay1, SoMay2 As String
        Dim nRow As Integer = 0
        While nRow < clbCacdonviduocphepquet.Items.Count
            If Me.clbCacdonviduocphepquet.Items(nRow).CheckState = CheckState.Checked Then
                MaDV = Me.clbCacdonviduocphepquet.Items(nRow).Value
                TenDV = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(0).Value
                SoMay1 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(1).Value
                SoMay2 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(2).Value
                lvi_nv = New UltraListViewItem(MaDV, New UltraListViewSubItem() {New UltraListViewSubItem(TenDV, Nothing), New UltraListViewSubItem(SoMay1, Nothing), New UltraListViewSubItem(SoMay2, Nothing)}, Nothing)
                Me.clbCacdonvikhongduocquet.Items.Add(lvi_nv)
            End If
            nRow = nRow + 1
        End While

        'Xoa nhung nhan vien da duoc dua vao list nhan vien duoc chon
        nRow = 0
        While nRow < Me.clbCacdonviduocphepquet.Items.Count
            If Me.clbCacdonviduocphepquet.Items(nRow).CheckState = CheckState.Checked Then
                Me.clbCacdonviduocphepquet.Items.RemoveAt(nRow)
            Else
                nRow = nRow + 1
            End If
        End While
        txtTongvitri.Text = Me.clbCacdonvikhongduocquet.Items.Count()
        txtTongvitriduocquet.Text = Me.clbCacdonviduocphepquet.Items.Count()
    End Sub

    
    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        'Dua nhung nhan vien duoc check vao luoi nhan vien chon
        Dim lvi_nv As UltraListViewItem
        Dim MaDV, TenDV, SoMay1, SoMay2 As String
        Dim nRow As Integer = 0
        If MessageBox.Show("Bạn có muốn xoá số máy quẹt thẻ trên không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes Then
            While nRow < clbCacdonviduocphepquet.Items.Count
                MaDV = Me.clbCacdonviduocphepquet.Items(nRow).Value
                SoMay1 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(1).Value
                SoMay2 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(2).Value

                If SoMay1 = Me.txtSomay.Text Then
                    'MessageBox.Show("update so may 1 thanh rong")
                    Dim obj As New objMayChamCongSo
                    obj.DonVi = MaDV
                    obj.ChonBang = 1
                    Me.b.UpdateInfoSoMay1(obj)
                End If

                If SoMay2 = Me.txtSomay.Text Then
                    'MessageBox.Show("update so may 2 thanh rong")
                    Dim obj As New objMayChamCongSo
                    obj.DonVi = MaDV
                    obj.ChonBang = 1
                    Me.b.UpdateInfoSoMay2(obj)
                End If

                nRow = nRow + 1
            End While
        End If
        Me.Refresh()
        txtTongvitri.Text = Me.clbCacdonvikhongduocquet.Items.Count()
        txtTongvitriduocquet.Text = Me.clbCacdonviduocphepquet.Items.Count()
    End Sub

    Private Sub btRefresh_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefresh.Activate
        Me.Refresh()
    End Sub


    Private Sub Refresh()
        Me.txtSomay.Text = MaySo
        Me.LoadDS()
        Me.LoadDSDUOCPHEPQUET()

        clsTools.GridTheme1(Me.dgrBC)
        Me.methodLoad()
    End Sub

    Private Sub btThaythe_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThaythe.Activate
        If MessageBox.Show("Bạn có muốn thay thế không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
            Dim frm As New frmSomay12
            frm.ShowDialog()
            'MessageBox.Show(Me.SoMayThayThe)
            If Me.SoMayThayThe <> 0 Then
                'Dua nhung nhan vien duoc check vao luoi nhan vien chon
                Dim lvi_nv As UltraListViewItem
                Dim MaDV, TenDV, SoMay1, SoMay2 As String
                Dim nRow As Integer = 0
                While nRow < clbCacdonviduocphepquet.Items.Count
                    MaDV = Me.clbCacdonviduocphepquet.Items(nRow).Value
                    SoMay1 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(1).Value
                    SoMay2 = Me.clbCacdonviduocphepquet.Items(nRow).SubItems(2).Value
                    If Me.SoMayThayThe = 1 Then
                        'MessageBox.Show("update qt so may 1 thanh so may duoc chon")
                        Dim obj As New objMayChamCongSo
                        obj.ChonBang = 2
                        obj.DonVi = MaDV
                        obj.SoMay = Me.txtSomay.Text
                        Me.b.UpdateInfoSoMay1(obj)
                    ElseIf Me.SoMayThayThe = 2 Then
                        'MessageBox.Show("update qt so may 2 thanh so may duoc chon")
                        Dim obj As New objMayChamCongSo
                        obj.ChonBang = 2
                        obj.DonVi = MaDV
                        obj.SoMay = Me.txtSomay.Text
                        Me.b.UpdateInfoSoMay2(obj)
                    End If

                    nRow = nRow + 1
                End While
            End If
        End If
        txtTongvitri.Text = Me.clbCacdonvikhongduocquet.Items.Count()
        txtTongvitriduocquet.Text = Me.clbCacdonviduocphepquet.Items.Count()
        Me.SoMayThayThe = 0
    End Sub

End Class


