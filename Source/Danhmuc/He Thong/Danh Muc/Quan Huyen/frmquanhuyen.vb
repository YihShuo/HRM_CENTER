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
Imports System.Text.RegularExpressions

Public Class frmquanhuyen
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New objquanhuyen
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmquanhuyen_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub
    Public TINHTHANH As String
    Public QUANHUYEN As String
    Friend WithEvents b As clsBquanhuyen

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemSua = 0
        ThemMoi()
    End Sub
    Public Sub ThemMoi()

        Me.b = New clsBquanhuyen
        Me.ThemSua = 0
        Me.txttenqh.Clear()
        Me.txtGhichu.Clear()

        Me.cbTinhThanh.Enabled = True
        Me.txtGhichu.Enabled = True
        If Me.cbTinhThanh.Value.ToString() <> "" Then
            TangID()
        End If
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.ThemSua = 1
        HieuChinh()
        Me.txtGhichu.Enabled = True
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim tblTempTT As DataTable
            Dim i As Integer
            Me.b = New clsBquanhuyen
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.ThemSua = 1
                Me.cbTinhThanh.Text = activeRow.Cells.Item("TT_MA").Value.ToString
                Me.cbTinhThanh.Enabled = False
                Me.txtmaqh.Text = activeRow.Cells.Item("QH_MA").Value.ToString
                Me.txtmaqh.Enabled = False
                Me.txttenqh.Text = activeRow.Cells.Item("QH_TEN").Value.ToString
                Me.cbloai.Value = activeRow.Cells.Item("QH_LOAI").Value.ToString
                Me.txtGhichu.Text = activeRow.Cells.Item("QH_TENLOAI").Value.ToString
                Me.txttenqh.Select()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        LuuDuLieu()
    End Sub
    Public Sub LuuDuLieu()
        Dim obj As New objquanhuyen
        obj.setvalue(Me.cbTinhThanh.Value, Me.txtmaqh.Text, Me.txttenqh.Text, Me.cbloai.Value, Me.txtGhichu.Text)
        Try
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            obj.MAQUANHUYEN = Me.txtmaqh.Text
            obj.LOAIQUANHUYEN = Me.cbloai.Value
            obj.TENQUANHUYEN = Me.txttenqh.Text
            obj.GHICHU = Me.txtGhichu.Text
            If Me.b.CapNhat(obj, Me.ThemSua) Then
                MessageBox.Show("Đã lưu dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                Me.txtmaqh.Focus()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongbaoLoi(exception.Message)
            ProjectData.ClearProjectError()
        End Try
        obj.ChonBang = 5
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        obj.setnull()
        methodLoad()
        If Me.btnThem.Enabled Then
            Me.ThemMoi()
        End If
    End Sub

    Private Sub LoadTinhThanh()
        Me.b = New clsBquanhuyen
        Dim tblTinh As New DataTable
        obj.ChonBang = 1
        tblTinh = Me.b.LoadDS(obj)
        Me.cbTinhThanh.DataSource = Me.b.LoadDS(obj)
        cbTinhThanh.ValueMember = "TT_MA"
        cbTinhThanh.DisplayMember = "TT_TEN"
        cbTinhThanh.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        If tblTinh.Rows.Count > 0 Then
            cbTinhThanh.SelectedIndex = 0
            TangID()
            loadloaiquanhuyen()
        Else
            cbTinhThanh.SelectedIndex = -1
        End If
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
    Private Sub TangID()
        Try
            Me.b = New clsBquanhuyen
            obj.ChonBang = 2
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            Dim TblTangID As New DataTable
            TblTangID = Me.b.LoadDS(obj)
            If CInt(TblTangID.Rows(0).Item("QH_MA")) = 0 Then
                Me.txtmaqh.Text = 1
            Else
                Me.txtmaqh.Text = TblTangID.Rows(0).Item("QH_MA")
            End If
        Catch ex As Exception
            MessageBox.Show("Vui lòng chọn giá trị, không nhập liệu vào ô tỉnh thành!.")
        End Try
    End Sub
    Private Sub loadloaiquanhuyen()
        Me.b = New clsBquanhuyen
        Dim tblloaiqh As New DataTable
        obj.ChonBang = 3
        tblloaiqh = Me.b.LoadDS(obj)
        Me.cbloai.DataSource = Me.b.LoadDS(obj)
        cbloai.ValueMember = "QH_LOAI"
        cbloai.DisplayMember = "QH_LOAI"
        cbloai.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        If tblloaiqh.Rows.Count > 0 Then
            cbloai.SelectedIndex = 0
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            obj.MAQUANHUYEN = Me.txtmaqh.Text
            obj.LOAIQUANHUYEN = Me.cbloai.Value
        Else
            cbloai.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel File(*.xls)|*.xls|All Filss(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnDong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDong.Activate
        Me.Close()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBquanhuyen
        obj.ChonBang = 5
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        clsTools.GridTheme1(Me.dgrBC)

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DM_QuanHuyen.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        ThemMoi()
    End Sub
    Private Sub frmquanhuyen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cbTinhThanh.Modified = False
        Me.ThemSua = 0
        If TINHTHANH <> "" Then
            LoadTinhThanh()
            Me.cbTinhThanh.Text = TINHTHANH
        Else
            LoadTinhThanh()
        End If
        methodLoad()
    End Sub

    Private Sub cbTinhThanh_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTinhThanh.ValueChanged
        TangID()
        methodLoad()
    End Sub
End Class
