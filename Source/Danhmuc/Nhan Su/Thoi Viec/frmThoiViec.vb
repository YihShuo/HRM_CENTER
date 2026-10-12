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
Public Class frmThoiViec
    ''==================  hieu chinh code ngay 20/12/2013 ====================''
    ''ngay sua: 20/12/2013
    ''nguoi sua: Tran
    ''noi dung: phan quyen them xoa sua an hien group phep nam, xoa thong tin khi nhap thoi viec xong
    Dim Tabletemp As DataTable
    Public Flag As Boolean = False
    Friend WithEvents b As clsBThoiViec
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Dim Them As Boolean = False
    Dim Sua As Boolean = False
    Dim Xoa As Boolean = False
    Public bXemNghiPhep As Boolean
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBThoiViec
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            Me.dgrBC.Rows(0).Activated = True
            Me.dgrBC.Rows(0).Selected = True
            Laythongtin()
        End If
        LuoiThoiViec()
    End Sub
    Private Sub frmThoiViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLoaiTV()
        Me.btnXemNghiViec.Visible = False
        Me.txtTen.Enabled = False
        Me.txtDonvicu.Enabled = False
        Me.txtCMND.Enabled = False
 
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.NGUOITAO = obj.TenDangNhap
        obj.NGUOICAPNHAT = obj.TenDangNhap
        obj.NGAYTAO = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())
        obj.NGAYCAPNHAT = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())

        obj.ChonBang = 10
        Dim TQuyenTruyCap, TUser As New DataTable
        TUser = Me.b.LoadDS(obj)
        If TUser.Rows.Count > 0 Then
            obj.ChonBang = 11
            TQuyenTruyCap = Me.b.LoadDS(obj)
            If TQuyenTruyCap.Rows.Count > 0 Then
                ''======================== xet trang thai la admin thi bo qua ==============''
                If Convert.ToBoolean(TUser.Rows(0).Item("Admin")) Then
                    Them = True
                    Sua = True
                    Xoa = True
                    ''gan mac dinh admin dc xem
                Else
                    If TQuyenTruyCap.Rows(0).Item("Them").ToString() = "" Then
                        Them = False
                    Else
                        Them = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Them"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Sua").ToString() = "" Then
                        Sua = False
                    Else
                        Sua = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Sua"))
                    End If
                    If TQuyenTruyCap.Rows(0).Item("Xoa").ToString() = "" Then
                        Xoa = False
                    Else
                        Xoa = Convert.ToBoolean(TQuyenTruyCap.Rows(0).Item("Xoa"))
                    End If
                    QuyenTruyCap()
                End If
            Else
                Them = False
                Sua = False
                Xoa = False
            End If

        Else
            MessageBox.Show("Không tìm thấy người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.methodLoad()
    End Sub
    Public Sub QuyenTruyCap()
        If Them And Sua And Xoa Then
            Me.bntXemchitietnghiphep.Visible = True
            Me.GroupPhepNam.Visible = True
            Me.btnCapnhat.Visible = True
        Else
            'Me.bntXemchitietnghiphep.Visible = False
            'Me.GroupPhepNam.Visible = False
            Me.btnCapnhat.Visible = False
        End If
    End Sub
    Public Shared obj As New objThoiViec
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Dim oldRow As Integer = 0
    Friend WithEvents d As clsDThoiViec    ' Nested Types
    Private Sub ChonDong()
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        If Not activeRow Is Nothing Then
            If activeRow.Index <> -1 Then
                Me.dgrBC.Rows(activeRow.Index).Selected = True
                Me.oldRow = activeRow.Index
            End If
        End If
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.ChonDong()
        Laythongtin()
    End Sub
    Public flagD As Integer = 0
    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        Dim activeCell As UltraGridCell
        If Not activeRow Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String
            For Each cell As UltraGridCell In Me.dgrBC.Rows(activeRow.Index).Cells
                ColA = cell.Column.Key
                Select Case ColA
                    Case "1"
                        If btnXemNghiViec.Visible Then
                            MessageBox.Show("Bạn không thể xóa khi đang xem thông tin phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Me.flagD = 0
                            If MessageBox.Show("Bạn muốn xóa nhân viên " + activeRow.Cells.Item("NV_MA").Text + " khỏi danh sách thôi việc không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                                obj.ChonBang = 1
                                obj.NV_MA = activeRow.Cells.Item("NV_MA").Text
                                Me.b = New clsBThoiViec
                                obj.NGUOIXOA = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())
                                obj.NGUOIXOA = frmDangNhap.tennguoidung
                                If Me.b.DeleteInfo(obj) Then
                                    obj.ChonBang = 3
                                    Me.b.UpdateInfo(obj)
                                End If
                                MessageBox.Show("Bạn đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.methodLoad()
                            End If
                        End If

                End Select

            Next
        End If
    End Sub
    Private Sub LoadLoaiTV()
        obj.ChonBang = 4
        Me.b = New clsBThoiViec
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cbLoai.DataSource = Me.Tabletemp
        Me.cbLoai.DisplayMember = "LTV_Ten"
        Me.cbLoai.ValueMember = "LTV_Ma"
        If Tabletemp.Rows.Count > 0 Then
            cbLoai.SelectedIndex = 0
        End If
    End Sub
    Private Sub Laythongtin()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMa.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                If Me.txtMa.Text = "" Then
                    Exit Sub
                End If
                Me.dtpNgay.Text = activeRow.Cells.Item("TV_NGAYTHOIVIEC").Value.ToString

                If IsDBNull(activeRow.Cells.Item("TV_SOQUYETDINH").Value) Then
                    Me.txtSoQD.Text = ""
                ElseIf activeRow.Cells.Item("TV_SOQUYETDINH").Value.ToString <> "" Then
                    Me.txtSoQD.Text = activeRow.Cells.Item("TV_SOQUYETDINH").Value.ToString
                Else
                    Me.txtSoQD.Text = ""
                End If

                'Me.cbLoai.Value = activeRow.Cells.Item("LTV_MA").Value.ToString
                Me.txtLyDo.Text = activeRow.Cells.Item("TV_LYDO").Value.ToString
                Me.cbLoai.Text = activeRow.Cells.Item("LTV_TEN").Value.ToString
                If activeRow.Cells.Item("DONVICU").Value.ToString <> "" Then
                    Me.txtDonvicu.Text = activeRow.Cells.Item("DONVICU").Value.ToString
                Else
                    Me.txtDonvicu.Text = ""
                End If

                If activeRow.Cells.Item("NV_CMND").Text.ToString = "" Then
                    Me.txtCMND.Text = ""
                Else
                    Me.txtCMND.Text = activeRow.Cells.Item("NV_CMND").Text.ToString()
                End If

            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub btnCapnhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhat.Activate
        ''go so the ==> hien thong tin tuong ung; neu co roi thi hien thong bao cap nhat; neu chua thi them luon
        ' kiem tra coi co chua
        Flag = False '' mac dinh: false la sua , true : them
        Dim ngayvao As String
        obj.ChonBang = 5
        obj.NV_MA = Me.txtMa.Text
        Dim Temp As New DataTable
        Me.b = New clsBThoiViec
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)
        ngayvao = CDate(Me.dtpNgayvao.Value).Year.ToString() + "/" + CDate(Me.dtpNgayvao.Value).Month.ToString() + "/" + CDate(Me.dtpNgayvao.Value).Day.ToString()
        obj.NgayTV = CDate(Me.dtpNgay.Value).Year.ToString() + "/" + CDate(dtpNgay.Value).Month.ToString() + "/" + CDate(dtpNgay.Value).Day.ToString()

        If Me.cbLoai.Value = "" Then
            MessageBox.Show("Vui lòng chọn loại thôi việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Me.dtpNgayvao.Value > Me.dtpNgay.Value Then
            MessageBox.Show("Vui lòng chọn ngày thôi việc >= ngày vào." & Chr(10) & Chr(13) & "(Số thẻ " & Me.txtMa.Text & " vào công ty ngày " & Me.dtpNgayvao.Value & ").", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If Temp.Rows.Count > 0 Then
            ''cap nhat, hien thi len
            If (MessageBox.Show(("Số thẻ này đã có, bạn có muốn cập nhật không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.Setnull()
                obj.NV_MA = Me.txtMa.Text
                obj.LyDO = Me.txtLyDo.Text
                obj.SoQD = Me.txtSoQD.Text
                obj.LoaiTV = Me.cbLoai.Value

                obj.setvalue(obj.NV_MA, obj.NgayTV, obj.SoQD, obj.LyDO, obj.LoaiTV, 0)
                obj.ChonBang = 1
                Flag = False
                Me.b = New clsBThoiViec
                Me.b.UpdateInfo(obj)
                obj.ChonBang = 2
                Me.b.UpdateInfo(obj)
                MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.methodLoad()
                Me.txtMa.Clear()
                Me.txtMa.Focus()
            End If
        Else
            '' them moi
            obj.Setnull()
            obj.NV_MA = Me.txtMa.Text
            obj.LyDO = Me.txtLyDo.Text
            obj.SoQD = Me.txtSoQD.Text
            obj.LoaiTV = Me.cbLoai.Value

            obj.setvalue(obj.NV_MA, obj.NgayTV, obj.SoQD, obj.LyDO, obj.LoaiTV, 0)
            obj.ChonBang = 1
            Flag = True
            Me.b = New clsBThoiViec
            Me.b.InsertInfo(obj)
            obj.ChonBang = 2
            Me.b.UpdateInfo(obj)
            MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.methodLoad()
            Me.txtMa.Clear()
            Me.txtMa.Focus()
        End If
    End Sub
    Private Sub btnEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEx.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub ClearTT()

        Me.txtTen.Clear()
        Me.txtSoQD.Clear()
        Me.cbLoai.Text = ""
        Me.txtLyDo.Clear()
        Me.dtpNgay.Text = ""
        Me.dtpNgayvao.Text = ""
        Me.txtCMND.Clear()
        Me.txtDonvicu.Clear()


        ''=============== trang thai clear thong tin xem nhap phep ====================''
        txtSNNamtruoc.Clear()
        txtSNNamnay.Clear()
        txtSNNNDH.Clear()
        txtSN5Nam.Clear()
        txtDanghi.Clear()
        txtConlai.Clear()
    End Sub
    Private Sub AnThongTinPhep()
        Me.txtSN5Nam.Enabled = False
        Me.txtSNNamnay.Enabled = False
        Me.txtSNNamtruoc.Enabled = False
        Me.txtSNNNDH.Enabled = False
        Me.dtpNgayvao.Enabled = False
        Me.txtConlai.Enabled = False
        Me.txtDanghi.Enabled = False
    End Sub
    Private Sub GetThongTinPhep(ByVal manv As String, ByVal Nam As String)
        Dim obj As New objThoiViec
        Me.b = New clsBThoiViec
        Dim tamPN As DataTable
        Dim tamGioQT As DataTable
        Dim SongayCL As Integer
        Dim PN_Nam As Date
        AnThongTinPhep()
        If Me.cbNam.Text.ToString() <> "" AndAlso Me.txtMa.Text <> "" Then
            obj.Nam = Nam
            obj.NV_MA = manv
            obj.ChonBang = 8
            tamPN = Me.b.LoadDS(obj)
            If tamPN.Rows.Count > 0 Then
                Me.txtSNNamtruoc.Text = tamPN.Rows(0).Item("PN_Songaynamtruoc").ToString()
                Me.txtSNNamnay.Text = tamPN.Rows(0).Item("PN_Songaynamnay").ToString()
                Me.txtSNNNDH.Text = tamPN.Rows(0).Item("PN_NangnhocDH").ToString()
                Me.txtSN5Nam.Text = tamPN.Rows(0).Item("PN_PhepTren5Nam").ToString()
            Else
                txtSNNamtruoc.Clear()
                txtSNNamnay.Clear()
                txtSNNNDH.Clear()
                txtSN5Nam.Clear()
            End If
            'Lay thong tin trong bang st_nhanviennghiphep: tinh so ngay da nghi, so ngay con lai =================
            obj.ChonBang = 12
            tamGioQT = Me.b.LoadDS(obj)
            If tamGioQT.Rows.Count > 0 Then
                Me.txtDanghi.Text = tamGioQT.Rows(0).Item("SONGAYDANGHI").ToString()
                SongayCL = (Val(Me.txtSNNamtruoc.Text) + Val(Me.txtSNNamnay.Text) + Val(Me.txtSNNNDH.Text) + Val(Me.txtSN5Nam.Text)) - Val(Me.txtDanghi.Text)
                Me.txtConlai.Text = SongayCL.ToString()
            Else
                Me.txtDanghi.Clear()
                Me.txtConlai.Clear()
            End If
        End If
    End Sub
    Private Sub txtMa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.TextChanged
        ''hien thi thong tin nhan vien
        ClearTT()
        Dim obj As New objThoiViec
        Dim tempTV, tempNV As DataTable
        tempTV = Nothing
        tempNV = Nothing
        obj.NV_MA = Me.txtMa.Text

        Me.b = New clsBThoiViec
        If Me.txtMa.TextLength = 6 Then
            ''chua nhap hoac so the khong on tai
            obj.ChonBang = 6
            tempNV = Me.b.LoadDS(obj)
            If tempNV.Rows.Count > 0 Then
                Me.txtMa.Text = tempNV.Rows(0).Item("NV_MA").ToString()
                Me.txtTen.Text = tempNV.Rows(0).Item("NV_TEN").ToString()
                Me.dtpNgayvao.Value = tempNV.Rows(0).Item("NV_NGAYVAO").ToString()
                Me.txtDonvicu.Text = tempNV.Rows(0).Item("DV_MA_").ToString()
                Me.txtCMND.Text = tempNV.Rows(0).Item("NV_CMND").ToString()
                '  If Them And Sua And Xoa Then
                GetThongTinPhep(Me.txtMa.Text.Trim(), Me.cbNam.Text.ToString())
                'End If

                obj.ChonBang = 7
                tempTV = Me.b.LoadDS(obj)

                If tempTV.Rows.Count > 0 Then
                    Me.txtMa.Text = tempTV.Rows(0).Item("NV_MA").ToString()
                    Me.txtLyDo.Text = tempTV.Rows(0).Item("TV_LYDO").ToString()
                    Me.dtpNgay.Text = tempTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                    Me.cbLoai.Text = tempTV.Rows(0).Item("LTV_TEN").ToString()
                End If
            Else
                MessageBox.Show("Số thẻ:" & Me.txtMa.Text & " không tìm thấy trong Hồ Sơ Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtMa.Clear()
                Me.txtMa.Focus()
            End If

        End If

    End Sub
    Public Sub methodLoad1()
        Dim grid As New clsTformatGrid
        ''clsTools.GridTheme1(Me.dgrBC)
        Dim temp As DataTable
        Dim obj As New objThoiViec
        ''xem theo so the
        Me.btnCapnhat.Visible = False
        obj.ChonBang = 9
        obj.NV_MA = Me.txtMa.Text.ToString()
        obj.Nam = Me.cbNam.Text.ToString()
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        'grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NghiPhep.xml"), typeControl.Grid, "coldgrNghiPhep")
        LuoiNghiPhep()
        If Me.dgrBC.Rows.Count <= 0 Then
            MessageBox.Show("Số thẻ " & txtMa.Text & " không có dữ liệu nghỉ phép", "Thông báo", MessageBoxButtons.OK)
            Me.txtMa.Focus()
            Me.txtMa.SelectAll()
        Else
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        End If

    End Sub
    Private Sub LuoiThoiViec()
        If Them And Sua And Xoa Then
            dgrBC.DisplayLayout.Bands(0).Columns("1").CellAppearance.Image = 2
            dgrBC.DisplayLayout.Bands(0).Columns("1").Hidden = False
            dgrBC.DisplayLayout.Bands(0).Columns("1").ExcludeFromColumnChooser = ExcludeFromColumnChooser.False

        Else
            If dgrBC.DisplayLayout.Bands(0).Columns.Exists("1") Then
                dgrBC.DisplayLayout.Bands(0).Columns("1").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                dgrBC.DisplayLayout.Bands(0).Columns("1").Hidden = True
            End If
        End If

        dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        For i As Integer = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            dgrBC.DisplayLayout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
        Next i
        dgrBC.DisplayLayout.Bands(0).Columns("1").Header.Caption = ""
        dgrBC.DisplayLayout.Bands(0).Columns("NV_MA").Header.Caption = "Số thẻ"
        dgrBC.DisplayLayout.Bands(0).Columns("NV_MA").Width = 100
        dgrBC.DisplayLayout.Bands(0).Columns("NV_TEN").Header.Caption = "Họ Tên"
        dgrBC.DisplayLayout.Bands(0).Columns("NV_TEN").Width = 200
        dgrBC.DisplayLayout.Bands(0).Columns("DONVICU").Header.Caption = "Đơn vị cũ"
        dgrBC.DisplayLayout.Bands(0).Columns("DONVICU").Width = 150
        dgrBC.DisplayLayout.Bands(0).Columns("TV_NGAYTHOIVIEC").Header.Caption = "Ngày Thôi Việc"
        dgrBC.DisplayLayout.Bands(0).Columns("TV_NGAYTHOIVIEC").Width = 100
        dgrBC.DisplayLayout.Bands(0).Columns("TV_SOQUYETDINH").Header.Caption = "Số Quyết Định"
        dgrBC.DisplayLayout.Bands(0).Columns("TV_SOQUYETDINH").Width = 100
        dgrBC.DisplayLayout.Bands(0).Columns("TV_LYDO").Header.Caption = "Lý Do"
        dgrBC.DisplayLayout.Bands(0).Columns("TV_LYDO").Width = 150
        dgrBC.DisplayLayout.Bands(0).Columns("LTV_TEN").Header.Caption = "Loại Thôi Việc"
        dgrBC.DisplayLayout.Bands(0).Columns("NV_CMND").Header.Caption = "CMND"
        dgrBC.DisplayLayout.Bands(0).Columns("LTV_TEN").Width = 150
        dgrBC.DisplayLayout.Bands(0).Columns("LTV_MA").Hidden = True

        Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
        band.Layout.Override.FilterUIType = FilterUIType.FilterRow
        band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        band.Layout.Override.RowSizing = RowSizing.AutoFree

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
    End Sub
    Private Sub LuoiNghiPhep()
        With dgrBC.DisplayLayout.Bands(0)
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).CellActivation() = Activation.NoEdit
            Next i
            If dgrBC.DisplayLayout.Bands(0).Columns.Exists("1") Then
                dgrBC.DisplayLayout.Bands(0).Columns("1").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
                dgrBC.DisplayLayout.Bands(0).Columns("1").Hidden = True
            End If
            .Columns("NV_MA").Header.Caption = "Số thẻ"
            .Columns("NV_MA").Width = 100
            .Columns("NP_TUNGAY").Header.Caption = "Từ ngày"
            .Columns("NP_TUNGAY").Width = 150
            .Columns("NP_DENNGAY").Header.Caption = "Ngày kết thúc"
            .Columns("NP_DENNGAY").Width = 150
            .Columns("DV_MA").Header.Caption = "Đơn vị"
            .Columns("DV_MA").Width = 200
            .Columns("NP_GHICHU").Header.Caption = "Ghi chú"
            .Columns("NP_GHICHU").Width = 150
            .Columns("NP_MA").Header.Caption = "Loại nghỉ phép"
            .Columns("NP_MA").Width = 150

            Dim band As UltraGridBand = Me.dgrBC.DisplayLayout.Bands.Item(0)
            band.Layout.Override.FilterUIType = FilterUIType.FilterRow
            band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
            band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
            band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
            band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
            band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
            band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
            band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
            band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
            band.Layout.Override.RowSizing = RowSizing.AutoFree
            band.ColHeaderLines = 1

            band.Layout.Override.RowSelectors = DefaultableBoolean.True
            band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
        End With
      End Sub
    Private Sub bntXemchitietnghiphep_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntXemchitietnghiphep.Activate
        If (MessageBox.Show(("Bạn muốn xem chi tiết nghỉ phép  " & Me.txtMa.Text & " của năm:" & Me.cbNam.Text & " phải không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            methodLoad1()
            Me.bntXemchitietnghiphep.Visible = False
            Me.btnXemNghiViec.Visible = True
            Me.btnCapnhat.Visible = False
        End If
    End Sub
    Private Sub btnXemNghiViec_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXemNghiViec.Activate
        Me.bntXemchitietnghiphep.Visible = True
        Me.btnXemNghiViec.Visible = False
        If Them And Sua And Xoa Then
            Me.btnCapnhat.Visible = True
        End If
        Me.methodLoad()
    End Sub

    Private Sub cbNam_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNam.ValueChanged
        If Me.dtpNgay.Text <> "" And Me.txtMa.Text <> "" Then
            ''hien thi thong tin nhan vien
            ClearTT()
            Dim obj As New objThoiViec
            Dim tempTV, tempNV As DataTable
            tempTV = Nothing
            tempNV = Nothing
            obj.NV_MA = Me.txtMa.Text

            Me.b = New clsBThoiViec
            If Me.txtMa.TextLength = 6 Then
                ''chua nhap hoac so the khong on tai
                obj.ChonBang = 6
                tempNV = Me.b.LoadDS(obj)
                If tempNV.Rows.Count > 0 Then
                    Me.txtMa.Text = tempNV.Rows(0).Item("NV_MA").ToString()
                    Me.txtTen.Text = tempNV.Rows(0).Item("NV_TEN").ToString()
                    Me.dtpNgayvao.Value = tempNV.Rows(0).Item("NV_NGAYVAO").ToString()
                    Me.txtDonvicu.Text = tempNV.Rows(0).Item("DV_MA_").ToString()
                    If Them And Sua And Xoa Then
                        GetThongTinPhep(Me.txtMa.Text.Trim(), Me.cbNam.Text.ToString())
                    End If
                    obj.ChonBang = 7
                    tempTV = Me.b.LoadDS(obj)

                    If tempTV.Rows.Count > 0 Then
                        Me.txtMa.Text = tempTV.Rows(0).Item("NV_MA").ToString()
                        Me.txtLyDo.Text = tempTV.Rows(0).Item("TV_LYDO").ToString()
                        Me.dtpNgay.Text = tempTV.Rows(0).Item("TV_NGAYTHOIVIEC").ToString()
                        Me.cbLoai.Text = tempTV.Rows(0).Item("LTV_TEN").ToString()
                    End If
                Else
                    'MessageBox.Show("Số thẻ:" & Me.txtMa.Text & " không tìm thấy trong Hồ Sơ Nhân Viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMa.Clear()
                    Me.txtMa.Focus()
                End If

            End If
        End If
    End Sub
 
End Class