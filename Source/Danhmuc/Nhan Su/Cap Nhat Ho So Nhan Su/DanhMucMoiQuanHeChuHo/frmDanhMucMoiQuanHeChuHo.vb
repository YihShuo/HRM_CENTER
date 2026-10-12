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
Imports System.DBNull
Imports Microsoft.VisualBasic.Strings
Public Class frmDanhMucMoiQuanHeChuHo

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBDanhMucMoiQuanHeChuHo
        Me.Path = "/layout/DanhMucMoiQuanHeChuHo.xml"
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrcongviec")
    End Sub

    Dim flag As Boolean
    Dim obj As New objDanhMucMoiQuanHeChuHo
    Dim Path As String
    Friend WithEvents d As clsDDanhMucMoiQuanHeChuHo  ' Nested Types
    Friend WithEvents b As clsBDanhMucMoiQuanHeChuHo
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        obj.ChonBang = 3
        Dim Temp5 As New DataTable
        Me.b = New clsBDanhMucMoiQuanHeChuHo
        Temp5 = Nothing
        obj.MaQHChuHo = Me.txtMaQH.Text
        Temp5 = Me.b.LoadDS(obj)
        ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
        If Temp5.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = True Then
            MessageBox.Show("Không được xóa mối quan hệ này")
            Exit Sub
        Else
            Me.Xoa()
            Me.txtMaQH.Clear()
            Me.txtTenQH.Clear()
            Me.txtMaQH.ReadOnly = False
            Me.btXoa.Enabled = False
            Me.btThem.Enabled = True
        End If
    End Sub
    Public Sub Xoa()
        Try
            Dim jFunction As New objDanhMucMoiQuanHeChuHo
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim ma As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        ma = StringType.FromObject(activeRow.Cells.Item("MAQH_CHUHO").Value)

                        jFunction.MaQHChuHo = ma

                        If jFunction.MaQHChuHo = ma Then
                            If (MessageBox.Show(("Bạn có muốn xóa chi nhánh có mã: " & ma & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                If Me.b.DeleteInfo(jFunction) Then
                                    'MessageBox.Show("Đã xóa thành công")
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không được xóa chi nhánh này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                'Return
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " nhân viên đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    ma = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("MAQH_CHUHO").Value)
                    jFunction.MaQHChuHo = ma
                    If Me.b.DeleteInfo(jFunction) Then
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:
            jFunction.Setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jFunction)
            Me.methodLoad()
            MessageBox.Show("Đã xóa thành công")
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub CapNhat()
        Dim MAQH As String
        Dim TENQH As String
        If Len(Me.txtMaQH.Text.Trim) > 0 Then
            MAQH = Me.txtMaQH.Text
            TENQH = Me.txtTenQH.Text

            ' SET VALUE
            obj.setvalue(MAQH, TENQH, 0)

            Dim flag As Boolean
            flag = False

            obj.ChonBang = 2
            Dim Temp2 As New DataTable
            Me.b = New clsBDanhMucMoiQuanHeChuHo
            Temp2 = Nothing
            obj.MaQHChuHo = Me.txtMaQH.Text
            Temp2 = Me.b.LoadDS(obj)
            ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
            If Temp2.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
            If flag = True Then
                MessageBox.Show("Mối quan hệ này đã có")
                Exit Sub
            Else
                obj.ChonBang = 1
                Me.b.InsertInfo(obj)
                MessageBox.Show("Cập Nhật Thành Công")
            End If
            Me.methodLoad()
        Else
            MessageBox.Show("Vui lòng nhập mã quan hệ !")
        End If
      
    End Sub
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Dim oldRow As Integer = 0
    Private Sub btThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThem.Activate
        Me.CapNhat()
        Me.txtMaQH.Clear()
        Me.txtTenQH.Clear()
    End Sub

    Private Sub frmDanhMucMoiQuanHe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.methodLoad()
        Me.btXoa.Enabled = False
    End Sub

    Private Sub btThoat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Activate
        Me.Close()
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        Me.HieuChinh()
    End Sub

    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.btXoa.Enabled = True
        Me.btThem.Enabled = False
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.btThem.Enabled = True
        Me.btXoa.Enabled = False
        Me.txtMaQH.Clear()
        Me.txtTenQH.Clear()
        Me.txtMaQH.ReadOnly = False
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
        e.Layout.GroupByBox.Prompt = "Kéo 1 cột vào đây để nhóm dữ liệu"

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub
    Public Sub HieuChinh()
        Try
            Dim atc As UltraGridCell = Me.dgrBC.ActiveCell
            Me.dgrBC.Rows(atc.Row.Index).Selected = 1

            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMaQH.Text = activeRow.Cells.Item("MAQH_CHUHO").Value.ToString
                Me.txtMaQH.ReadOnly = True
                Me.txtTenQH.Text = activeRow.Cells.Item("TENQH_CHUHO").Value.ToString
            End If
            Me.flag = 1
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub

End Class