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

Public Class frmCaDacBiet
    Inherits Form
    Public trangthai As Integer
    Dim obj As New Obj_CaDacBiet

    '----------Khởi động----------
    Public Sub New()
        'AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmCaDacBiet_KeyUp)
        'AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmCaDacBiet_Load)
        Me.trangthai = 1 'trạng thái thêm mới
        Me.InitializeComponent()
    End Sub

    '----------Load Form Chính 'frmCaDacBiet----------

    Private Sub frmCaDacBiet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New ClsB_CaDacBiet
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If

        btnSua.Enabled = False
        txtTenNV.Enabled = False
        txtDV.Enabled = False
        Me.methodLoad()
    End Sub


    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.ChonDong()
        Me.ThemMoi()
        Me.btnThem.Enabled = True
        Me.btnXoa.Enabled = True
        Me.txtMaNV.Clear()
    End Sub


    '----------Phương thức load lấy từ file xml----------
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_CaDacBiet
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/H_CaDacBiet.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub

    '----------Load Grid lên Box---------
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMaNV.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.txtTenNV.Text = activeRow.Cells.Item("NV_Ten").Value.ToString
                Me.txtDV.Text = activeRow.Cells.Item("DV_MA").Value.ToString
                Me.cboCaMa.Value = activeRow.Cells.Item("CA_MA").Value.ToString
                trangthai = 0
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
        End If
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        Me.HieuChinh()
    End Sub

    '----------Xử lý dữ liệu nhập đầu vào---------

    Private Sub txtMaNV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaNV.ValueChanged
        If Me.txtMaNV.TextLength = 6 Then
            'Kiểm tra MANV nhập có trước đó chưa
            obj.ChonBang = 3
            Dim Temp As New DataTable
            Me.b = New ClsB_CaDacBiet
            Temp = Nothing
            obj.MaNhanVien = Me.txtMaNV.Text
            Temp = Me.b.LoadDS(obj)

            Dim flag As Boolean
            flag = False

            If Temp.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
            'Nếu có thì load các thông tin tương ứng
            If flag = True Then
                Me.txtTenNV.Text = Temp.Rows(0).Item("NV_TEN").ToString
                Me.txtDV.Text = Temp.Rows(0).Item("DV_MA").ToString
            Else
                MessageBox.Show("Không có nhân viên này")
                Exit Sub
            End If
        ElseIf Me.txtMaNV.Text = "" Then
            Me.ThemMoi()
        End If

    End Sub

    '----------Các hàm xử lý dữ liệu---------

    Public Sub ThemMoi()
        Me.txtMaNV.Text = ""
        Me.txtTenNV.Clear()
        Me.txtDV.Clear()
        Me.cboCaMa.Clear()
    End Sub

    Public Sub LuuDuLieu()
        Dim manv As String
        Dim dv As String
        Dim cama As String

        manv = Me.txtMaNV.Text
        dv = Me.txtDV.Text
        cama = Me.cboCaMa.Text

        '-------------------------Trạng thái thêm mới  
        If trangthai = 1 Then
            obj.ChonBang = 2
            Dim Temp As New DataTable
            Me.b = New ClsB_CaDacBiet
            Temp = Nothing
            obj.MaNhanVien = Me.txtMaNV.Text
            Temp = Me.b.LoadDS(obj)

            Dim FLAG As Boolean = 0

            If Temp.Rows.Count > 0 Then
                FLAG = True
            Else
                FLAG = False
            End If

            If FLAG = True Then
                MessageBox.Show("Nhân viên này đã đăng ký ca đặc biệt, không thể thêm" & Me.obj.MaNhanVien)
                Exit Sub
            Else
                'THEM
                obj.setnull()
                obj.setvalue(manv, dv, cama)
                If (MessageBox.Show(("Bạn có muốn đăng ký ca đăng biệt cho nhân viên này không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    obj.ChonBang = 1
                    Me.b = New ClsB_CaDacBiet
                    Me.b.InsertInfo(obj)
                    Me.methodLoad()
                Else
                    Exit Sub
                End If
            End If
            '-------------------------Trạng thái cập nhật
        ElseIf trangthai = 0 Then
            obj.setnull()
            obj.setvalue(manv, dv, cama)
            If (MessageBox.Show(("Bạn có muốn sửa thông tin của nhân viên này trong bảng Ca Đặc Biệt Không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.ChonBang = 1
                Me.b = New ClsB_CaDacBiet
                Me.b.UpdateInfo(obj)
                Me.methodLoad()
            Else
                Exit Sub
            End If
        End If
        Me.ThemMoi()
        Me.trangthai = 1
    End Sub

    Public Sub XoaDuLieu()
        Dim manv As String
        Dim dv As String
        Dim cama As String

        manv = Me.txtMaNV.Text
        dv = Me.txtTenNV.Text
        cama = Me.cboCaMa.Text

        obj.setnull()
        obj.setvalue(manv, dv, cama)
        If (MessageBox.Show(("Bạn có muốn xóa nhân viên này không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
            obj.ChonBang = 1
            Me.b = New ClsB_CaDacBiet
            Me.b.DeleteInfo(obj)
            Me.methodLoad()
        Else
            Exit Sub
        End If

        Me.ThemMoi()

    End Sub

    '----------Gáng các nút---------

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemMoi()
        Me.btnLuu.Enabled = True
        trangthai = 1
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter.Export(Me.dgrBC, Me.SaveFileDialog.FileName)
            Process.Start(Me.SaveFileDialog.FileName)
        End If
    End Sub

    'Public Sub b__errorRaise(ByVal messege As String)
    '    Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    'End Sub

    'Public Sub frmCaDacBiet_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
    '        Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    End If
    'End Sub

    Friend WithEvents b As ClsB_CaDacBiet

End Class

