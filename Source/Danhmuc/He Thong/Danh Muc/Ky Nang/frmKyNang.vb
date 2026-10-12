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
Public Class frmKyNang
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New objKynang
    Friend WithEvents b As clsBKyNang
    ' Methods
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBKyNang
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/Kynang.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub
    Private Sub frmKyNang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBKyNang
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.methodLoad()
        Me.txtMa.Focus()
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then

                Me.txtMa.Text = activeRow.Cells.Item("KN_MA").Value.ToString
                Me.txtMa.ReadOnly = True
                Me.txtTen.Text = activeRow.Cells.Item("KN_TEN").Value.ToString
                Me.txtTen.Select()
                Me.txtGhichu.Text = activeRow.Cells.Item("KN_GHICHU").Value.ToString
                Me.ThemSua = 1

            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub LuuDuLieu()
        Dim jkynang As New objKynang
        jkynang.setvalue(Me.txtMa.Text, Me.txtTen.Text, Me.txtGhichu.Text)

        If Not jkynang.KtMa Then
            MessageBox.Show("Chưa nhập mã kỹ năng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMa.Focus()
        ElseIf Not jkynang.KtTen Then
            MessageBox.Show("Chưa nhập tên kỹ năng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtTen.Focus()
        Else
            Me.b = New clsBKyNang
            Try
                If Me.b.CapNhat(jkynang, Me.ThemSua) Then
                    MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    jkynang.setnull()
                    Me.dgrBC.DataSource = Me.b.LoadDS(jkynang)
                    If Me.btnThem.Enabled Then
                        Me.ThemMoi()
                    End If
                Else
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
    Public Function Kiemtrakhoangoai(ByVal MaKynang As String) As Boolean
        Dim table As DataTable
        obj.ChonBang = 1
        obj.MAKYNANG = MaKynang
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub XoaDuLieu()
        Try
            Dim jkynang As New objKynang
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim str As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        str = StringType.FromObject(activeRow.Cells.Item("KN_MA").Value)
                        jkynang.MAKYNANG = str
                        If Kiemtrakhoangoai(jkynang.MAKYNANG) = False Then
                            MessageBox.Show("Không được xóa mã kỹ năng này.Vì kỹ năng này đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            If (MessageBox.Show(("Bạn có muốn xóa kỹ năng có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If jkynang.MAKYNANG = " " Then
                                    MessageBox.Show("Không thể xóa mã kỹ năng khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                If Me.b.DeleteInfo(jkynang) Then
                                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            Else
                                MessageBox.Show("Không được xóa mã kỹ năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If

                        End If
                    Return
                End If
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " kỹ năng đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)

                    str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("KN_MA").Value)
                    jkynang.MAKYNANG = str
                    If Me.b.DeleteInfo(jkynang) Then
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:

            jkynang.setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jkynang)

            If Me.btnThem.Enabled Then
                Me.ThemMoi()
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub ThemMoi()
        Me.b = New clsBKyNang
        Me.txtMa.Clear()
        Me.txtTen.Clear()
        Me.txtMa.ReadOnly = False
        Me.txtMa.Focus()
        Me.ThemSua = 0
    End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemMoi()
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
    End Sub

    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.HieuChinh()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub
    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub dgrBC_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        If Me.btnSua.Enabled Then
            Me.HieuChinh()
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
    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        Me.HieuChinh()
        Me.btnXoa.Enabled = True
        Me.btnThem.Enabled = True
    End Sub
End Class