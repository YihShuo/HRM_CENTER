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
Public Class frmNguyenNhanKyLuat
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New ObjNguyenNhanKyLuat
    Friend WithEvents b As clsBNguyenNhanKyLuat
    ' Methods
    Public Sub New()
        'AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmKyLuat_KeyUp)
        'AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmNguyenNhanKyLuat_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub
    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
  
    Private Sub frmNguyenNhanKyLuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'btnIn.Visible = False
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBNguyenNhanKyLuat
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.methodLoad()
        Me.txtMaNNKL.Focus()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBNguyenNhanKyLuat
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DM_NguyenNhanKyLuat.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        If Me.b.LoadDS(obj).Rows.Count > 0 Then
            Me.dgrBC.Rows(0).Activate()
            Me.dgrBC.Rows(0).Selected = True
            Me.btnSua.Enabled = True
            Me.btnXoa.Enabled = True
        Else
            Me.btnSua.Enabled = False
            Me.btnXoa.Enabled = False
        End If
    End Sub

    Public Sub ThemMoi()
        Me.txtMaNNKL.Clear()
        Me.txtTenNNKL.Clear()
        Me.txtGhichuNNKL.Clear()
        Me.txtMaNNKL.ReadOnly = False
        Me.txtMaNNKL.Focus()
        Me.ThemSua = 0
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
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then

                Me.txtMaNNKL.Text = activeRow.Cells.Item("NNKL_MA").Value.ToString
                Me.txtMaNNKL.ReadOnly = True
                Me.txtTenNNKL.Text = activeRow.Cells.Item("NNKL_TEN").Value.ToString
                Me.txtTenNNKL.Select()
                Me.txtGhichuNNKL.Text = activeRow.Cells.Item("NNKL_GHICHU").Value.ToString
                Me.ThemSua = 1

            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub LuuDuLieu()
        Dim jNNkyluat As New ObjNguyenNhanKyLuat
        Dim flag As Boolean
        flag = False
        jNNkyluat.setvalue(Me.txtMaNNKL.Text, Me.txtTenNNKL.Text, Me.txtGhichuNNKL.Text)

        If Not jNNkyluat.KtMa Then
            MessageBox.Show("Chưa nhập mã nguyên nhân kỷ luật ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMaNNKL.Focus()
        ElseIf Not jNNkyluat.KtTen Then
            MessageBox.Show("Chưa nhập tên nguyên nhân kỷ luật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtTenNNKL.Focus()
        Else
            Me.b = New clsBNguyenNhanKyLuat
            Try
                jNNkyluat.ChonBang = 2
                Dim Temp2 As New DataTable
                Temp2 = Nothing
                jNNkyluat.MANNKYLUAT = Me.txtMaNNKL.Text
                Temp2 = Me.b.LoadDS(jNNkyluat)
                If Temp2.Rows.Count > 0 Then
                    flag = True
                Else
                    flag = False
                End If

                If flag = True Then
                    Me.txtMaNNKL.ReadOnly = False
                    Me.ThemSua = 1
                    If (MessageBox.Show(("Nguyên nhân kỷ luật này đã có, bạn có muốn sửa lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                        If Me.b.CapNhat(jNNkyluat, Me.ThemSua) Then
                            MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Else
                            MessageBox.Show("Không thể cập nhật nguyên nhân kỷ luật này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.txtMaNNKL.Focus()
                        End If
                    Else

                    End If
                Else
                    Me.ThemSua = 0
                    If Me.b.CapNhat(jNNkyluat, Me.ThemSua) Then
                        MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Else
                        MessageBox.Show("Không thể cập nhật nguyên nhân kỷ luật này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.txtMaNNKL.Focus()
                    End If

                End If
                jNNkyluat.setnull()
                methodLoad()

            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                clsTools.thongbaoLoi(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jNNkyluat As New ObjNguyenNhanKyLuat
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim str As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        str = StringType.FromObject(activeRow.Cells.Item("NNKL_MA").Value)
                        jNNkyluat.MANNKYLUAT = str
                        If (MessageBox.Show(("Bạn có muốn xóa nguyên nhân kỷ luật có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then

                            If Me.b.DeleteInfo(jNNkyluat) Then

                                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                GoTo Label_0274
                            Else
                                MessageBox.Show("Xóa bị lỗi, nguyên nhân kỷ luật này đang sử dụng." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            ' MessageBox.Show("Không được xóa mã nguyên nhân kỷ luật này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                    Return
                End If
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nguyên nhân kỷ luật đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)

                    str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("NNKL_MA").Value)
                    jNNkyluat.MANNKYLUAT = str
                    If Me.b.DeleteInfo(jNNkyluat) Then
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:

            jNNkyluat.setnull()
            '  Me.dgrBC.DataSource = Me.b.LoadDS(jNNkyluat)
            '  Me.ThemMoi()
            methodLoad()

            If Me.btnThem.Enabled Then
                Me.ThemMoi()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()

        End Try
    End Sub

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        ThemMoi()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        LuuDuLieu()
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        ChonDong()
        XoaDuLieu()
    End Sub

    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        HieuChinh()
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        Me.HieuChinh()
    End Sub

    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.ChonDong()
        Me.HieuChinh()
        Me.btnXoa.Enabled = True
        Me.btnSua.Enabled = True
    End Sub
    Private Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClickRow
        Me.ThemMoi()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class