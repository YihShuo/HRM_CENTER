Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient

Public Class frmChuyenDV

    Inherits Form
    Dim obj As New objChuyenDV
    Public ThemSua As Integer

    'Khai báo biến sử dụng cho hàm xuất/in
    Public para As Object()
    Public issysReport As Boolean

    ' Methods
    Public Sub New()
        Me.ThemSua = 0
        AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmChuyenDV_KeyUp)
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Public Sub frmChuyenDV_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
            Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
        End If
    End Sub
    Private Sub frmChuyenDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.obj.ChonBang = 4
        Me.b = New ClsBChuyenDV
        Me.cbDVMoi.DataSource = Me.b.LoadDS(obj)
        Me.cbDVMoi.DisplayMember() = "DV_MA"
        Me.cbDVMoi.ValueMember() = "DV_MA"
        Me.cbDVMoi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        '  Me.methodLoad()

        Me.obj.ChonBang = 7
        Me.cbCVuMoi.DataSource = Me.b.LoadDS(obj)
        Me.cbCVuMoi.DisplayMember() = "CVU_MA"
        Me.cbCVuMoi.ValueMember() = "CVU_MA"
        Me.cbCVuMoi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        '   Me.methodLoad()
        Me.txtMa.MaxLength = 6 ''chặn nhập 5 số ---------
        ''===== ẩn những gì không nhập =========== ''
        Me.txtTen.Enabled = False
        Me.txtDV.Enabled = False
        Me.txtChucVu.Enabled = False

        Me.methodLoad()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsBChuyenDV
        Me.Path = "/layout/ChuyenDonVi.xml"
        obj.MANV = Me.txtMa.Text
        obj.ChonBang = 3
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
        ''======
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            Me.btnXoa.Enabled = True
            Me.btnSua.Enabled = True
        Else
            Me.btnXoa.Enabled = False
            Me.btnSua.Enabled = False
        End If
    End Sub
    'Public Sub methodLoad2()
    '    Dim grid As New clsTformatGrid
    '    Me.b = New ClsBChuyenDV
    '    Me.Path = "/layout/ChuyenDonVi.xml"
    '    obj.MANV = Me.txtMa.Text
    '    obj.ChonBang = 5
    '    Me.dgrBC.DataSource = Me.b.LoadDS(obj)
    '    Dim dgrBC As Object = Me.dgrBC
    '    grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrtieuchuan")
    'End Sub
    Private Sub UltraGridExcelExporter1_CellExporting(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportingEventArgs) Handles UltraGridExcelExporter1.CellExporting
        If e.GridColumn.Key = "STT" Then
            Dim worksheetCell As Infragistics.Excel.WorksheetCell = e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(e.CurrentColumnIndex)
            worksheetCell.Value = e.CurrentRowIndex.ToString
            worksheetCell.CellFormat.BottomBorderStyle = Infragistics.Excel.CellBorderLineStyle.Default
            worksheetCell.CellFormat.BottomBorderColor = Color.AliceBlue
            worksheetCell.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Center
            e.Cancel = True
        End If
    End Sub
    Private Sub txtMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.TextChanged
        If Me.txtMa.TextLength = 6 Then

            Dim Temp As New DataTable
            Me.b = New ClsBChuyenDV
            Temp = Nothing

            ''=========
            obj.setnull()
            obj.ChonBang = 1
            obj.MANV = Me.txtMa.Text
            Temp = Me.b.LoadDS(obj)
            ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
            If Temp.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
            If flag = True Then
                Me.txtMa.Text = Temp.Rows(0).Item("NV_MA").ToString
                Me.txtTen.Text = Temp.Rows(0).Item("NV_TEN").ToString
                Me.txtTen.ReadOnly = True
                Me.txtDV.Text = Temp.Rows(0).Item("DV_MA").ToString
                Me.txtDV.ReadOnly = True
                Me.txtChucVu.Text = Temp.Rows(0).Item("CVU_MA").ToString
                Me.txtMa.ReadOnly = False
                Me.txtChucVu.ReadOnly = True
                Me.cbDVMoi.ReadOnly = False
                Me.cbCVuMoi.ReadOnly = True
                Me.dtpNgayCD.ReadOnly = False
                'Me.cbDVMoi.Text = ""
                Me.cbCVuMoi.Text = Temp.Rows(0).Item("CVU_MA").ToString
                Me.dtpNgayCD.Text = Now
                ''=========== load luoi theo so the ==========''
                Me.methodLoad()
                ''=========== nếu đã thôi việc thì ẩn nút lưu ==========''
                If Convert.ToBoolean(Temp.Rows(0).Item("TV")) Then
                    MessageBox.Show("Số thẻ :" & Me.txtMa.Text & " đã thôi việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnLuu.Enabled = False
                Else
                    ''========== xet dieu dong nghi viec ==============''
                    If Convert.ToBoolean(Temp.Rows(0).Item("DDNGHIVIEC")) Then
                        MessageBox.Show("Số thẻ :" & Me.txtMa.Text & " đang điều động nghỉ việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnLuu.Enabled = False
                    Else
                        Me.btnLuu.Enabled = True
                    End If
                End If
            Else
                MessageBox.Show("Không có nhân viên này!", "Thông Báo")
                Me.txtMa.Focus()
                Me.btnLuu.Enabled = False ''========== chặn thao tác
                Exit Sub
            End If
        ElseIf Me.txtMa.Text = "" Then
            Me.Themmoi()
        End If
    End Sub
    Private Function KiemTraDonvi(ByVal sDonvi As String) As Boolean
        Dim objCDV As New objChuyenDV
        Dim tblTempDonvi As DataTable
        Me.b = New ClsBChuyenDV
        objCDV.ChonBang = 9
        objCDV.DONVICBX = sDonvi
        tblTempDonvi = Me.b.LoadDS(objCDV)
        If tblTempDonvi.Rows.Count > 0 Then
            If Convert.ToBoolean(tblTempDonvi.Rows(0).Item("DV_LOCBB")) Then
                Return False
            Else
                Return True
            End If

        Else
            Return False
        End If
    End Function
    Public Sub btnSua_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnSua.Activate
        If Me.btnSua.Enabled Then
            Me.HieuChinh()
            Me.dtpNgayCD.ReadOnly = False
            Me.cbDVMoi.ReadOnly = False
            Me.cbCVuMoi.ReadOnly = False
            Me.cbDVMoi.Focus()
            Me.ThemSua = 1
        End If
    End Sub

    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow

            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMa.Text = activeRow.Cells.Item("MA").Value.ToString
                Me.txtMa.ReadOnly = True
                Me.txtTen.Text = activeRow.Cells.Item("TEN").Value.ToString
                Me.txtTen.ReadOnly = True
                Me.dtpNgayCD.Text = activeRow.Cells.Item("NGAYCD").Value.ToString
                Me.dtpNgayCD.ReadOnly = True
                Me.txtDV.Text = activeRow.Cells.Item("DVCU").Value.ToString
                Me.txtDV.ReadOnly = True
                Me.txtChucVu.Text = activeRow.Cells.Item("CVUCU").Value.ToString
                Me.txtChucVu.ReadOnly = True
                Me.cbDVMoi.Text = activeRow.Cells.Item("DVMOI").Value.ToString
                Me.cbDVMoi.ReadOnly = True
                Me.cbCVuMoi.Text = activeRow.Cells.Item("CVUMOI").Value.ToString
                Me.cbCVuMoi.ReadOnly = True
                'Me.ThemSua = 1
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Dim oldRow As Integer = 0

    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        Else
            ''========= dang active row =============''
            If Not Me.dgrBC.ActiveRow Is Nothing Then
                If Me.dgrBC.ActiveRow.Index <> -1 Then
                    Me.dgrBC.Rows(Me.dgrBC.ActiveRow.Index).Selected = True
                    Me.oldRow = Me.dgrBC.ActiveRow.Index
                End If
            End If
        End If
    End Sub

    Public Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        'If Me.btnSua.Enabled Then
        '    Me.HieuChinh()
        'End If
    End Sub

    Public Sub Themmoi()
        Me.txtMa.Clear()
        Me.txtTen.Clear()
        Me.dtpNgayCD.Text = Now
        'Me.cbDVMoi.Clear()
        Me.txtDV.Clear()
        Me.cbCVuMoi.Clear()
        Me.txtChucVu.Clear()
        Me.txtMa.Focus()
        Me.txtMa.ReadOnly = False
        Me.cbDVMoi.ReadOnly = False
        Me.cbCVuMoi.ReadOnly = False
        Me.dtpNgayCD.ReadOnly = False
        Me.ThemSua = 0
        Me.txtMa.Focus()
    End Sub

    Public Sub btnThem_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnThem.Activate
        Me.Themmoi()
    End Sub

    Public Sub LuuDuLieu()
        Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
        Dim jChuyenDV As New objChuyenDV
        Dim NGAY As Date
        NGAY = Me.dtpNgayCD.Text
        Dim ngaytao, ngaycapnhat, nguoitao, nguoicapnhat As String
        Dim dt As DateTime
        dt = DateTime.Now()

        If Me.txtMa.Text.Trim() = "" Then
            MessageBox.Show("Chưa nhập số thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMa.Focus()
            Exit Sub
        End If

        If Me.txtDV.Text.Trim() = "" Then
            MessageBox.Show("Đơn vị cũ chưa có, bạn không thể chuyển đơn vị cho người này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtDV.Focus()
            Exit Sub
        End If

        If Me.dtpNgayCD.Value Is Nothing Then
            MessageBox.Show("Chưa chọn ngày chuyển đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.dtpNgayCD.Focus()
            Exit Sub
        End If

        If Me.txtChucVu.Text.Trim() = "" Then
            MessageBox.Show("Người này không có chức vụ, bạn không thể chuyển đơn vị cho người này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtChucVu.Focus()
            Exit Sub
        End If

        If Me.cbDVMoi.Value Is Nothing Then
            MessageBox.Show("Chưa chọn đơn vị mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbDVMoi.Focus()
            Exit Sub
        End If

        If Me.cbCVuMoi.Value Is Nothing Then
            MessageBox.Show("Chưa chọn chức vụ mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbCVuMoi.Focus()
            Exit Sub
        End If

        If KiemTraDonvi(Me.cbDVMoi.Text) = False Then
            MessageBox.Show("Đơn vị mới không tồn tại hoặc không còn sử dụng nữa, vui lòng chọn lại đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbDVMoi.Focus()
            Exit Sub
        End If

        If KiemTraDonvi(Me.txtDV.Text) = False Then
            MessageBox.Show("Đơn vị cũ không tồn tại hoặc không còn sử dụng nữa, vui lòng chọn lại đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtDV.Focus()
            Exit Sub
        End If


        nguoitao = MAIN.userclient
        nguoicapnhat = MAIN.userclient
        ngaytao = dt.ToString("yyyy/MM/dd HH:mm:ss")
        ngaycapnhat = dt.ToString("yyyy/MM/dd HH:mm:ss")

        Dim NGAY1 As String
        NGAY1 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        obj.NGAYCD = NGAY1
        'TRUYỀN DỮ LIỆU VÀO TẤT CẢ CÁC CỘT ĐÃ KHAI BÁO Ở LỚP OBJ
        jChuyenDV.setvalue(Me.txtMa.Text, NGAY1, Me.txtDV.Text, Me.txtChucVu.Text, Me.cbDVMoi.Text, Me.cbCVuMoi.Text)
        If Not jChuyenDV.KtMa Then
            MessageBox.Show("Chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMa.Focus()
        Else
            Me.b = New ClsBChuyenDV
            Try
                If (Me.ThemSua = 0) Then
                    jChuyenDV.ChonBang = 2
                    jChuyenDV.MANV = Me.txtMa.Text
                    jChuyenDV.NGAYCD = NGAY1
                    If (MessageBox.Show("Bạn có muốn lưu số thẻ " & Me.txtMa.Text & " đơn vị " & Me.cbDVMoi.Text & " ngày " & NGAY.Day.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Year.ToString() & " không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
                        If Me.b.InsertInfo(jChuyenDV, nguoitao, ngaytao, nguoicapnhat, ngaycapnhat) Then
                            MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Số thẻ :" & Me.txtMa.Text & " có chuyển dữ liệu ngày " & Me.dtpNgayCD.Value & ",không lưu được.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If
                        jChuyenDV.setnull()
                        Me.dgrBC.DataSource = Me.b.LoadDS(jChuyenDV)
                        Me.methodLoad()
                        Me.txtMa.Focus()

                        'UPDATE DU LIEU O BANG ST_NHANVIEN KHI CHUYEN DOI DON VI
                        'If (Me.ThemSua = 0) Then
                        obj.ChonBang = 8
                        obj.MANV = Me.txtMa.Text
                        NGAY = Me.dtpNgayCD.Text
                        Dim NGAY2 As String
                        NGAY2 = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
                        obj.NGAYCD = NGAY2
                        Me.b.UpdateInfo(obj, nguoicapnhat, ngaycapnhat)

                    End If ''end if xac nhan luu

                ElseIf (Me.ThemSua = 1) Then
                    obj.setnull()
                    obj.setvalue(Me.txtMa.Text, NGAY1, Me.txtDV.Text, Me.txtChucVu.Text, Me.cbDVMoi.Text, Me.cbCVuMoi.Text)
                    obj.MANV = Me.txtMa.Text
                    Dim NGAYCD1 As Date = activeRow.Cells.Item("NGAYCD").Value.ToString
                    Dim NGAYCD2 As String
                    NGAYCD2 = NGAYCD1.Year.ToString() + "/" + NGAYCD1.Month.ToString() + "/" + NGAYCD1.Day.ToString()
                    obj.NGAYCD_LUOI = NGAYCD2
                    obj.ChonBang = 2

                    If (MessageBox.Show("Bạn có muốn lưu số thẻ " & Me.txtMa.Text & " đơn vị " & Me.cbDVMoi.Text & " ngày " & NGAYCD1.Day.ToString() + "/" + NGAYCD1.Month.ToString() + "/" + NGAYCD1.Year.ToString() & " không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
                        If Me.b.UpdateInfo(obj, nguoicapnhat, ngaycapnhat) Then
                            MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Không lưu được dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If
                    End If
                    Me.methodLoad()
                Else
                    Exit Sub
                    Me.txtMa.Focus()
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                clsTools.thongbaoLoi(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Public Sub btnLuu_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Dim ReportID As String
    Dim flag As Boolean
    Dim Table As String
    Dim Path As String
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    ' XÓA TẤT CẢ CÁC THÔNG TIN VỀ NHÂN VIÊN ĐÃ THÔI VIỆC
    Public Sub Xoa()
        Try
            Dim jFunction As New objChuyenDV
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim ma As String
                Dim NGAY As Date
                Dim ngaycd As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        ma = StringType.FromObject(activeRow.Cells.Item("MA").Value)
                        NGAY = StringType.FromObject(activeRow.Cells.Item("NGAYCD").Value)
                        ngaycd = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()

                        jFunction.MANV = ma
                        jFunction.NGAYCD = ngaycd
                        If jFunction.MANV = ma And jFunction.NGAYCD = ngaycd Then
                            If (MessageBox.Show(("Bạn có muốn xóa nhân viên có mã: " & ma & " và ngày chuyển đổi" & ngaycd & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then

                                jFunction.ChonBang = 1
                                If Me.b.DeleteInfo(jFunction) Then
                                    MessageBox.Show("Đã xóa thành công")
                                    GoTo Label_0274
                                Else
                                    MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                End If
                                '  MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không được xóa nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                'Return
                'If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nhân viên đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                '    Return
                'End If
                'Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                'Dim i As Integer = 0
                'Do While (i <= num2)
                '    ma = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("MA").Value)
                'Loop
            End If
Label_0274:
            jFunction.setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jFunction)
            Me.methodLoad()
            ''====== xóa xong thêm mới lại =============''
            Me.Themmoi()
            'MessageBox.Show("Đã xóa thành công")
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub btnXoa_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnXoa.Activate
        ''=== ACTIVE DONG DANG CHON =========''
        Me.ChonDong()
        Me.Xoa()
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        'Me.HieuChinh()
        Me.btnXoa.Enabled = True
        Me.btnThem.Enabled = True
        If Me.txtMa.Text = Me.dgrBC.ActiveRow.Cells("MA").Text Then
            Me.HieuChinh()
        End If
    End Sub

    Private Sub dgrBC_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.ChonDong()
        Me.Themmoi()
        Me.btnThem.Enabled = True
        Me.btnXoa.Enabled = True
        Me.txtMa.Clear()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(3).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(4).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(5).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(7).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit
        e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub

    Private Sub cbDVMoi_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Load Don Vi
        Dim obj As New objChuyenDV
        obj.ChonBang = 4
        Me.b = New ClsBChuyenDV
        Me.cbDVMoi.DataSource = Me.b.LoadDS(obj)
        Me.cbDVMoi.DisplayMember() = "DV_MA"
        Me.cbDVMoi.ValueMember() = "DV_MA"
        Me.cbDVMoi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub

    Private Sub cbCVuMoi_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Load Chức vụ
        Dim obj As New objChuyenDV
        obj.ChonBang = 7
        Me.b = New ClsBChuyenDV
        Me.cbCVuMoi.DataSource = Me.b.LoadDS(obj)
        Me.cbCVuMoi.DisplayMember() = "CVU_MA"
        Me.cbCVuMoi.ValueMember() = "CVU_MA"
        Me.cbCVuMoi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
    End Sub
    Private Sub txtMa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMa.KeyPress
        'If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
        '    If Not Information.IsNumeric(e.KeyChar) Then
        '        e.KeyChar = ""
        '    End If
        'End If
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar))) Then
            e.Handled = True
        End If
    End Sub
    Friend WithEvents d As ClsDChuyenDV   ' Nested Types

    Private Sub txtMa_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.ValueChanged

    End Sub
End Class