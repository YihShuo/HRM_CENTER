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

Public Class frmHocVanDM
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New Obj_HocVanDM
    ' Methods
    Public Sub New()
        AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmHocVan_KeyUp)
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmHocVan_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Public Sub btnIn_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnIn.Activate
        Dim report As New FrmReport
        report.reportID = "1054"
        'Dim strArray As String() = New String() {Me.txtMaNganh.Text}
        'report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    Public Sub btnLuu_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Public Sub btnThem_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnThem.Activate
        Me.ThemMoi()
    End Sub

    Public Sub btnXoa_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
    End Sub

    Public Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        If Me.btnSua.Enabled Then
            Me.HieuChinh()
        End If
    End Sub


    Public Sub frmHocVan_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
            Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
        End If
    End Sub
    Private Sub frmHocVan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnIn.Visible = False
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New ClsB_HocVanDM
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.methodLoad()
        Me.txtMaHocVan.Focus()
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_HocVanDM
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/H_HocVan.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub


    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then

                Me.txtMaHocVan.Text = activeRow.Cells.Item("HV_MA").Value.ToString
                Me.txtMaHocVan.ReadOnly = True
                Me.txtTenHocVan.Text = activeRow.Cells.Item("HV_TEN").Value.ToString
                Me.txtTenHocVan.Select()
                Me.ThemSua = 1

            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub LuuDuLieu()
        Dim jhocvan As New Obj_HocVanDM
        jhocvan.setvalue(Me.txtMaHocVan.Text, Me.txtTenHocVan.Text)

        If Not jhocvan.KtMa Then
            MessageBox.Show("Chưa nhập mã học vấn ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMaHocVan.Focus()
        ElseIf Not jhocvan.KtTen Then
            MessageBox.Show("Chưa nhập tên học vấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtTenHocVan.Focus()
        Else
            Me.b = New ClsB_HocVanDM
            Try
                If Me.b.CapNhat(jhocvan, Me.ThemSua) Then
                    MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    jhocvan.setnull()
                    Me.dgrBC.DataSource = Me.b.LoadDS(jhocvan)
                    If Me.btnThem.Enabled Then
                        Me.ThemMoi()
                    End If
                Else
                    Me.txtMaHocVan.Focus()
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                clsTools.thongbaoLoi(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Public Sub ThemMoi()
        Me.b = New ClsB_HocVanDM
        Me.txtMaHocVan.Clear()
        Me.txtTenHocVan.Clear()
        Me.txtMaHocVan.ReadOnly = False
        Me.txtMaHocVan.Focus()
        Me.ThemSua = 0
    End Sub

    Public Sub XoaDuLieu()
        Try
            Dim jhocvan As New Obj_HocVanDM
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim str As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        str = StringType.FromObject(activeRow.Cells.Item("HV_MA").Value)
                        jhocvan.MAHOCVAN = str
                        If (MessageBox.Show(("Bạn có muốn xóa học vấn   có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then

                            If Me.b.DeleteInfo(jhocvan) Then

                                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                GoTo Label_0274

                            End If
                            MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Else
                            MessageBox.Show("Không được xóa mã học vấn  này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                    Return
                End If
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " học vấn  đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)

                    str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("HV_MA").Value)
                    jhocvan.MAHOCVAN = str
                    If Me.b.DeleteInfo(jhocvan) Then
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:

            jhocvan.setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jhocvan)

            If Me.btnThem.Enabled Then
                Me.ThemMoi()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub


    ' LOAD LỮ LIỆU LÊN 
    '=======================================================================================

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
        Me.btnXoa.Enabled = True
        Me.btnThem.Enabled = True

    End Sub

    Private Sub dgrBC_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.ChonDong()
        Me.Themmoi()
        Me.btnThem.Enabled = True
        Me.btnXoa.Enabled = True
        Me.txtMaHocVan.Clear()
    End Sub

    '==============================  TẠO THÊM CỘT STT       =======================================================

    'Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
    '    e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
    '    e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
    '    e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(3).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(4).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(5).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(7).CellActivation = Activation.NoEdit
    '    'e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit

    '    e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"
    '    Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    '    Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    '    Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
    '    Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    'End Sub

    'Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
    '    e.Row.Cells("STT").Value = e.Row.Index + 1
    '    e.Row.Update()
    'End Sub

    'Private Sub UltraGridExcelExporter1_CellExporting(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.CellExportingEventArgs) Handles UltraGridExcelExporter1.CellExporting
    '    If e.GridColumn.Key = "STT" Then
    '        Dim worksheetCell As Infragistics.Excel.WorksheetCell = e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(e.CurrentColumnIndex)
    '        worksheetCell.Value = e.CurrentRowIndex.ToString
    '        worksheetCell.CellFormat.BottomBorderStyle = Infragistics.Excel.CellBorderLineStyle.Default
    '        worksheetCell.CellFormat.BottomBorderColor = Color.AliceBlue
    '        worksheetCell.CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Center
    '        e.Cancel = True
    '    End If
    'End Sub
    '=======================================================================================

    Friend WithEvents b As ClsB_HocVanDM



End Class