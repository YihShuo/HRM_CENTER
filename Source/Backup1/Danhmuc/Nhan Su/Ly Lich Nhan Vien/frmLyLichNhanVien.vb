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
Public Class frmLyLichNhanVien
    Public Temp As New DataTable
    Dim obj As New objLyLichNhanVien
    Friend WithEvents d As clsDLyLichNhanVien    ' Nested Types
    Friend WithEvents b As clsBLyLichNhanVien
    Private Sub frmLyLichNhanVien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 2
        Me.b = New clsBLyLichNhanVien
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)
        Locdulieu(Me.Temp)
        Me.An()
        Me.btDienBienLuong.Visible = False
        ' LOADT CONG VIEC
        obj.ChonBang = 3
        Me.b = New clsBLyLichNhanVien
        Me.UltraDropDown_CV.DataSource = Me.b.LoadDS(obj)
        ' LOADT CHƯC VU
        obj.ChonBang = 4
        Me.b = New clsBLyLichNhanVien
        Me.UltraDropDown_CVU.DataSource = Me.b.LoadDS(obj)
    End Sub
    Private Sub Locdulieu(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/LyLichNV.xml"), typeControl.Grid, "coldgrhoso")
    End Sub
    Public Sub An()
        Me.txtHoTen.ReadOnly = True
        Me.txtDonVi.ReadOnly = True
        Me.txtCongViec.ReadOnly = True
        Me.txtTrinhDoHV.ReadOnly = True
        Me.txtTrinhDoCM.ReadOnly = True
        Me.txtChucVu.ReadOnly = True
        Me.dtpNgaySinh.Enabled = False
        Me.dtpNgayVao.Enabled = False
        Me.dtpNgayBoNhiem.Enabled = False
    End Sub
    Public Sub Hien()
        Me.txtHoTen.ReadOnly = False
        Me.txtDonVi.ReadOnly = False
        Me.txtCongViec.ReadOnly = False
        Me.txtTrinhDoHV.ReadOnly = False
        Me.txtTrinhDoCM.ReadOnly = False
        Me.txtChucVu.ReadOnly = False
    End Sub
    Public Sub Clear()
        Me.txtHoTen.Clear()
        Me.txtDonVi.Clear()
        Me.txtCongViec.Clear()
        Me.txtTrinhDoHV.Clear()
        Me.dtpNgayVao.Text = Now
        Me.dtpNgayBoNhiem.Text = Now
        Me.dtpNgaySinh.Text = Now
        Me.txtTrinhDoCM.Clear()
        Me.txtChucVu.Clear()
    End Sub
    '' biến toàn cục tách chuỗi ngày tháng năm từ lưới (đã định dạng thành ngày/tháng/năm; kiểu chuỗi) (khi định dạng ngày trên máy không đúng kiểu dd/MM/yyyy)
    Dim ngaythangnam, ngaythang, ngay, thang, nam, tungay As String

    Private Function DoiDinhDangNgay(ByVal sNgay As String) As String
        Dim chuoingay As String = ""
        Dim kieu_phancachngay As String = "/"
        If sNgay <> "" Then
            ngaythangnam = sNgay
            ngaythang = ngaythangnam.Substring(0, ngaythangnam.LastIndexOf("/"))

            ngay = ngaythang.Substring(0, ngaythang.LastIndexOf("/"))
            thang = ngaythang.Substring(ngaythang.LastIndexOf("/") + 1)
            nam = ngaythangnam.Substring(ngaythangnam.LastIndexOf("/") + 1)
            chuoingay = nam + "/" + thang + "/" + ngay
        End If
        Return chuoingay
    End Function

    Private Sub txtMa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMa.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
        'If Me.txtMa.Text.Length < 5 Then
        '    Me.btDienBienLuong.Visible = False
        '    Me.btCapNhatNVKyHDLD.Visible = True
        '    Me.btCapNhatNV.Visible = True
        '    Me.btCapnhat.Visible = True
        '    Me.Clear()

        '    'LOAD LAI LUOI
        '    obj.ChonBang = 2
        '    Me.b = New clsBLyLichNhanVien
        '    Temp = Nothing
        '    Temp = Me.b.LoadDS(obj)
        '    Locdulieu(Me.Temp)
        '    flag = 0
        'Else
        '    Me.btDienBienLuong.Visible = True
        '    Me.btCapNhatNVKyHDLD.Visible = False
        '    Me.btCapNhatNV.Visible = False
        '    Me.btCapnhat.Visible = False

        'End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        If flag = 1 Then
            Dim i As Integer
            For i = 0 To 11
                e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            Next i
            Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
            Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
        Else
            With dgrBC.DisplayLayout
                ' set "DropDown" properties
                .Bands(0).Columns("CV_MA").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
                .Bands(0).Columns("CV_MA").ValueList = Me.UltraDropDown_CV
                .Bands(0).Columns("CV_MA").AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend

                ' set "DropDown" properties
                .Bands(0).Columns("CVU_MA").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
                .Bands(0).Columns("CVU_MA").ValueList = Me.UltraDropDown_CVU
                .Bands(0).Columns("CVU_MA").AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
            End With
            e.Layout.Bands(0).Columns("NV_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("DV_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_NGAYVAO").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_GIOITINH").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_NGAYSINH").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_DIACHI").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_CMND").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_NgayCapCMND").CellActivation() = Activation.NoEdit

            e.Layout.Bands(0).Columns("NV_NoiCapCMND").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_DTNhaRieng").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_DTDiDong").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_NAMSINH").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_NGAYSINHTT").CellActivation() = Activation.NoEdit

            e.Layout.Bands(0).Columns("NV_NGAYKHD").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("CV_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("HV_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("HV_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("CVU_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("CM_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("CM_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("TH_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("TH_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NN_MA").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NN_TEN").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_THOIVIEC").CellActivation() = Activation.NoEdit
            e.Layout.Bands(0).Columns("NV_DAKYHDLD").CellActivation() = Activation.NoEdit
            ''======== ẩn ra khỏi chooser list ====
            e.Layout.Bands(0).Columns("NV_NGAYSINHTT").ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
            Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
        End If
        
    End Sub

    Private Sub dgrBC_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgrBC.MouseUp
        If flag = 1 Then
        Else
            Dim i As Integer
            For i = 0 To Me.dgrBC.Rows.Count - 1
                Me.dgrBC.Rows(i).Update()
            Next
        End If

    End Sub

    Private Sub dgrBC_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgrBC.AfterCellUpdate
        If flag = 1 Then
        Else
            Dim i As Integer
            If e.Cell.Column.Index < 27 Then
                For i = 0 To 27
                    If e.Cell.Row.Index = -1 Then Exit Sub
                    If i <> e.Cell.Column.Index Then
                        dgrBC.Rows(e.Cell.Row.Index).Cells("FLAG").Value = True
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub Luudulieu()
        Dim obj As New objLyLichNhanVien
        dgrBC.PerformAction(ExitEditMode, False, False)
        Dim num2 As Integer = (Me.dgrBC.Rows.Count - 1)
        Dim i As Integer = 0
        'I. Vòng lập duyệt từng nhân viên==========================
        While (i <= num2)
            Dim MA As String = Me.dgrBC.Rows.Item(i).Cells.Item("NV_MA").Value
            Dim CONGVIEC As String
            Dim CHUCVU As String
            Dim NGAY As Date = Me.dgrBC.Rows.Item(i).Cells.Item("NV_NGAYBONHIEM").Value
            Dim NGAYBONHIEM As String
            NGAYBONHIEM = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
            Dim DHNN As Integer
            If Me.dgrBC.Rows.Item(i).Cells.Item("CV_MA").Value.ToString = "" Then
                CONGVIEC = ""
            Else
                CONGVIEC = Me.dgrBC.Rows.Item(i).Cells.Item("CV_MA").Value
            End If

            If Me.dgrBC.Rows.Item(i).Cells.Item("CVU_MA").Value.ToString = "" Then
                CHUCVU = ""
            Else
                CHUCVU = Me.dgrBC.Rows.Item(i).Cells.Item("CVU_MA").Value
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("NV_NGAYBONHIEM").Value.ToString = "" Then
                NGAYBONHIEM = ""
            Else
                NGAYBONHIEM = NGAYBONHIEM
            End If
            If Me.dgrBC.Rows.Item(i).Cells.Item("HD_CVNANGNHOCDH").Value.ToString() = Nothing Then
                DHNN = 0
            ElseIf Me.dgrBC.Rows.Item(i).Cells.Item("HD_CVNANGNHOCDH").Value.ToString() = False Then
                DHNN = 0
            Else
                DHNN = 1
            End If

            obj.Setnull()
            obj.MaNV = MA
            obj.CongViec = CONGVIEC
            obj.ChucVu = CHUCVU
            obj.NgayBoNhiem = NGAYBONHIEM
            obj.DHNN = DHNN
            obj.setvalue(obj.MaNV, obj.CongViec, obj.ChucVu, obj.NgayBoNhiem, OBJ.DHNN)
            Dim bFLAG As Boolean = StringType.FromObject(Me.dgrBC.Rows.Item(i).Cells.Item("FLAG").Value)
            If bFLAG = True Then
                obj.ChonBang = 1
                Me.b.UpdateInfo(obj)
                obj.ChonBang = 1
                Me.b.UpdateThaoTac(obj)
            End If
            i += 1
        End While
        obj.ChonBang = 2
        Me.b = New clsBLyLichNhanVien
        Temp = Nothing
        Temp = Me.b.LoadDS(obj)
        Locdulieu(Me.Temp)
        MessageBox.Show("Bạn đã cập nhật thành công")
    End Sub

    Private Sub btCapnhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapnhat.Activate
        Me.Luudulieu()

    End Sub

    Private Sub btCapNhatNVKyHDLD_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatNVKyHDLD.Activate
        obj.ChonBang = 2
        Me.b.UpdateInfo(obj)
        obj.ChonBang = 3
        Me.b.UpdateInfo(obj)
        MessageBox.Show("Cập Nhật Thành Công")
    End Sub

    Private Sub btCapNhatNV_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhatNV.Activate
        obj.ChonBang = 4
        Me.b.UpdateInfo(obj)
        obj.ChonBang = 5
        Me.b.UpdateInfo(obj)
        MessageBox.Show("Cập Nhật Thành Công")
    End Sub

    Private Sub btExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub Locdulieu2(ByVal TableDS As DataTable)
        Dim grid As New clsTformatGrid
        Me.dgrBC.DataSource = TableDS
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXMLCC((dgrBC), (Application.StartupPath & "/layout/XEMDBL.xml"), typeControl.Grid, "coldgrhoso")
    End Sub
    Public flag As Integer = 0

    Private Sub btDienBienLuong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDienBienLuong.Activate
        flag = 1
        Dim ma As String = Me.txtMa.Text.Trim()
        If (MessageBox.Show("Bạn có muốn xem diễn biến lương của nhân viên " & ma & " không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.No) Then
            obj.MaNV = ma
            obj.ChonBang = 5
            Me.b = New clsBLyLichNhanVien
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            Locdulieu2(Me.Temp)
        End If
    End Sub

    Private Sub txtMa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMa.KeyDown
        If e.KeyCode = Keys.Enter Then

           

        End If
        
    End Sub

    Private Sub txtMa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.TextChanged

        Me.dgrBC.DataSource = Nothing
        If Me.txtMa.Text.Length = 6 Then
            Me.btDienBienLuong.Visible = True
            Me.btDienBienLuong.Visible = True
            Me.btCapNhatNVKyHDLD.Visible = False
            Me.btCapNhatNV.Visible = False
            Me.btCapnhat.Visible = False
            obj.ChonBang = 1
            Me.b = New clsBLyLichNhanVien
            obj.MaNV = Me.txtMa.Text.Trim()
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            If Temp.Rows.Count > 0 Then
                Me.txtHoTen.Text = Temp.Rows(0).Item("NV_TEN").ToString()
                Me.txtDonVi.Text = Temp.Rows(0).Item("DV_MA").ToString()
                Me.dtpNgayVao.Text = Temp.Rows(0).Item("NV_NGAYVAO").ToString()
                Me.txtCongViec.Text = Temp.Rows(0).Item("CV_TEN").ToString()
                Me.txtTrinhDoHV.Text = Temp.Rows(0).Item("HV_TEN").ToString()

                Dim ngaysinhNV As String ''======= ngày sinh format định dạng khi sai ngày trong máy người dùng
                Dim dNgaysinhNV As Date
                dtpNgaySinh.Format = DateTimePickerFormat.Custom
                If Convert.ToBoolean(Temp.Rows(0).Item("NV_NAMSINH").ToString) = False Then
                    ngaysinhNV = DoiDinhDangNgay(Temp.Rows(0).Item("NV_NGAYSINH").ToString())
                    dNgaysinhNV = Date.Parse(ngaysinhNV)
                    Me.dtpNgaySinh.Text = ngaysinhNV
                    dtpNgaySinh.CustomFormat = "dd/MM/yyyy"

                Else
                    dtpNgaySinh.CustomFormat = "yyyy"
                    dNgaysinhNV = Date.Parse(Temp.Rows(0).Item("NV_NGAYSINHTT").ToString())
                    ngaysinhNV = dNgaysinhNV.Year.ToString()
                    Me.dtpNgaySinh.Text = dNgaysinhNV
                End If

                'Me.dtpNgaySinh.Text = Temp.Rows(0).Item("NV_NGAYSINH").ToString()
                Me.dtpNgayBoNhiem.Text = Temp.Rows(0).Item("NV_NGAYBONHIEM").ToString()
                Me.txtChucVu.Text = Temp.Rows(0).Item("CVU_TEN").ToString()
                Me.txtTrinhDoCM.Text = Temp.Rows(0).Item("CM_TEN").ToString()
            Else
                MessageBox.Show("Không có nhân viên này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Clear()
            End If
        End If
        If Me.txtMa.Text = "" Then
            Me.btDienBienLuong.Visible = False
            Me.btCapNhatNVKyHDLD.Visible = True
            Me.btCapNhatNV.Visible = True
            Me.btCapnhat.Visible = True
            Me.Clear()
            flag = 0
            obj.ChonBang = 2
            Me.b = New clsBLyLichNhanVien
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)
            Locdulieu(Me.Temp)
        End If
    End Sub
End Class