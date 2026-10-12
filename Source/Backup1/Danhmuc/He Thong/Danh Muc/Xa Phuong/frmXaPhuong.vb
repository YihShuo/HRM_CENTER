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
Public Class frmXaPhuong
    Inherits Form
    Public ThemSua As Integer
    Dim obj As New Obj_XaPhuong
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmXaPhuong_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub
    Public TINHTHANH As String
    Public QUANHUYEN As String
    Friend WithEvents b As ClsB_XaPhuong
    Private Sub frmXaPhuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ThemSua = 0
        If TINHTHANH <> "" And QUANHUYEN <> "" Then
            LoadTinhThanh()
            Me.cbTinhThanh.Text = TINHTHANH
            Me.cbQuanHuyen.Text = QUANHUYEN
        Else
            LoadTinhThanh()
        End If
        Me.txtMaXaPhuong.Enabled = False
        Me.btnXoa.Visible = False
    End Sub
    Private Sub LoadTinhThanh()
        Me.b = New ClsB_XaPhuong
        Dim tblTinh As New DataTable

        obj.ChonBang = 2
        tblTinh = Me.b.LoadDS(obj)
        Me.cbTinhThanh.DataSource = Me.b.LoadDS(obj)
        cbTinhThanh.ValueMember = "TT_MA"
        cbTinhThanh.DisplayMember = "TT_TEN"
        cbTinhThanh.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend

        If tblTinh.Rows.Count > 0 Then
            cbTinhThanh.SelectedIndex = 0
            LoadQuanHuyen()
        Else
            cbTinhThanh.SelectedIndex = -1
        End If
    End Sub
    Private Sub LoadQuanHuyen()
        Me.b = New ClsB_XaPhuong
        Dim tblHuyen As New DataTable

        obj.ChonBang = 4
        obj.MATINHTHANH = Me.cbTinhThanh.Value
        tblHuyen = Me.b.LoadDS(obj)
        Me.cbQuanHuyen.DataSource = Me.b.LoadDS(obj)
        cbQuanHuyen.ValueMember = "QH_MA"
        cbQuanHuyen.DisplayMember = "QH_TEN"
        cbQuanHuyen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        If tblHuyen.Rows.Count > 0 Then
            cbQuanHuyen.SelectedIndex = 0
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            obj.MAQUANHUYEN = Me.cbQuanHuyen.Value
            methodLoad()
        Else
            cbQuanHuyen.SelectedIndex = -1
        End If
    End Sub
    Private Sub LoadAllComBo()
        LoadTinhThanh()
        LoadQuanHuyen()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_XaPhuong
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        clsTools.GridTheme1(Me.dgrBC)

        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/DM_XaPhuong.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)

        ThemMoi()
    End Sub
    Public Sub ThemMoi()

        Me.b = New ClsB_XaPhuong
        Me.ThemSua = 0
        Me.txtTenXaPhuong.Clear()
        Me.txtGhichu.Clear()
        Me.txtMaXaPhuong.Focus()

        Me.cbTinhThanh.Enabled = True
        Me.cbQuanHuyen.Enabled = True
        Me.txtMaXaPhuong.Enabled = False
        Me.txtTenXaPhuong.Enabled = True
        Me.txtGhichu.Enabled = True
        If Me.cbTinhThanh.Value.ToString() <> "" AndAlso Me.cbQuanHuyen.Value.ToString() <> "" Then
            TangID()
        Else
            Me.txtMaXaPhuong.Value = 1
        End If
        'LoadTinhThanh()
    End Sub
    Private Sub TangID()
        Me.b = New ClsB_XaPhuong
        obj.ChonBang = 8
        obj.MAQUANHUYEN = Me.cbQuanHuyen.Value
        obj.MATINHTHANH = Me.cbTinhThanh.Value
        Dim TblTangID As New DataTable
        TblTangID = Me.b.LoadDS(obj)
        If CInt(TblTangID.Rows(0).Item("XP_MA")) = 0 Then
            Me.txtMaXaPhuong.Value = 1
        Else
            Me.txtMaXaPhuong.Value = TblTangID.Rows(0).Item("XP_MA")
        End If
       
    End Sub
    Public Sub Sua()
        Me.b = New ClsB_XaPhuong
        Me.ThemSua = 1
        Me.txtMaXaPhuong.Enabled = False
        Me.txtTenXaPhuong.Focus()
        Me.cbQuanHuyen.Enabled = False
        Me.cbTinhThanh.Enabled = False
    End Sub
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim tblTempTT As DataTable
            Dim i As Integer
            Me.b = New ClsB_XaPhuong
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.ThemSua = 1
                Me.txtMaXaPhuong.Text = activeRow.Cells.Item("XP_MA").Value.ToString
                Me.txtMaXaPhuong.Enabled = False
                Me.txtTenXaPhuong.Text = activeRow.Cells.Item("XP_TEN").Value.ToString
                Me.cbTinhThanh.Enabled = False
                txtTenXaPhuong.Enabled = False
                Me.cbQuanHuyen.Enabled = False
                Me.txtGhichu.Enabled = False
                ''========= hien thi tinh thanh,quan huyen tuong ung theo quan huyen do ===''
                Me.txtGhichu.Text = activeRow.Cells.Item("XP_GHICHU").Value.ToString
                Me.cbTinhThanh.Text = activeRow.Cells.Item("TT_MA").Value.ToString
                Me.cbQuanHuyen.Text = activeRow.Cells.Item("QH_MA").Value.ToString
                Me.txtTenXaPhuong.Select()


            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jxaphuong As New Obj_XaPhuong
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim str As String
                Me.b = New ClsB_XaPhuong
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        str = StringType.FromObject(activeRow.Cells.Item("XP_MA").Value)
                        jxaphuong.MAXAPHUONG = str
                        jxaphuong.MATINHTHANH = StringType.FromObject(activeRow.Cells.Item("TT_MA").Value)
                        jxaphuong.MAQUANHUYEN = StringType.FromObject(activeRow.Cells.Item("QH_MA").Value)
                        Dim TblKiemtraNV As DataTable
                        jxaphuong.ChonBang = 7
                        TblKiemtraNV = Me.b.LoadDS(jxaphuong)
                        If TblKiemtraNV.Rows.Count > 0 Then
                            MessageBox.Show("Xã,phường:" & activeRow.Cells.Item("XP_Ten").Value & " đang được sử dụng,không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            Dim tblTinhHuyen As DataTable
                            jxaphuong.ChonBang = 6
                            tblTinhHuyen = Me.b.LoadDS(jxaphuong)
                            If tblTinhHuyen.Rows.Count > 0 Then
                                If (MessageBox.Show(("Bạn có muốn xóa xã phường có mã: " & str & ", huyện:" & tblTinhHuyen.Rows(0).Item("QH_TEN").ToString() & ", tỉnh:" & tblTinhHuyen.Rows(0).Item("TT_TEN").ToString() & " không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                    If Me.b.DeleteInfo(jxaphuong) Then
                                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        GoTo Label_0274
                                    End If
                                    MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                Else

                                End If
                            End If
                        End If


                    End If
                    Return
                End If
            End If

Label_0274:

            jxaphuong.setnull()
            methodLoad()
            Me.ThemSua = 0
            Me.ThemMoi()
            Me.btnThem.Enabled = True
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
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemSua = 0
        ThemMoi()
    End Sub
    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        'XoaDuLieu()
    End Sub
    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ThemSua = 1
        Me.ChonDong()
        Me.HieuChinh()
    End Sub
    Private Sub dgrBC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.ChonDong()
        Me.ThemSua = 0
        Me.ThemMoi()
    End Sub
    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.ThemSua = 1
        HieuChinh()
        Me.txtTenXaPhuong.Enabled = True
        Me.txtGhichu.Enabled = True
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel File(*.xls)|*.xls|All Filss(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Public Sub LuuDuLieu()
        Dim jxaphuong As New Obj_XaPhuong
        jxaphuong.setvalue(Me.txtMaXaPhuong.Text, Me.cbTinhThanh.Value, Me.cbQuanHuyen.Value, Me.txtTenXaPhuong.Text, Me.txtGhichu.Text)

        If Not jxaphuong.KtMaXaPhuong Then
            MessageBox.Show("Chưa nhập mã xã phường ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMaXaPhuong.Focus()
        ElseIf Not jxaphuong.KtTenXaPhuong Then
            MessageBox.Show("Chưa nhập tên xã phường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtTenXaPhuong.Focus()
        ElseIf Not jxaphuong.KtMaTinhThanh Then
            MessageBox.Show("Chưa chọn tỉnh thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbTinhThanh.Focus()
        ElseIf Not jxaphuong.KtMaQuanHuyen Then
            MessageBox.Show("Chưa chọn quận huyện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbQuanHuyen.Focus()
        Else
            Me.b = New ClsB_XaPhuong
            Try
                jxaphuong.TENTINHTHANH = Me.cbTinhThanh.Text
                jxaphuong.TENQUANHUYEN = Me.cbQuanHuyen.Text
                jxaphuong.MAQUANHUYEN = Me.cbQuanHuyen.Value
                jxaphuong.MATINHTHANH = Me.cbTinhThanh.Value
                If Me.b.CapNhat(jxaphuong, Me.ThemSua) Then
                    MessageBox.Show("Đã lưu dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                   
                Else
                    Me.txtMaXaPhuong.Focus()
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                clsTools.thongbaoLoi(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
        jxaphuong.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(jxaphuong)
        jxaphuong.setnull()
        If Me.btnThem.Enabled Then
            Me.ThemMoi()
        End If
    End Sub
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        LuuDuLieu()
    End Sub
    Private Sub cbTinhThanh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTinhThanh.KeyPress
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Or Char.GetNumericValue(e.KeyChar) >= 0 Or Char.IsDigit(e.KeyChar) = False Or Char.IsDigit(e.KeyChar) = True)) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbTinhThanh_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbTinhThanh.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbQuanHuyen_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbQuanHuyen.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbQuanHuyen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbQuanHuyen.KeyPress
        If ((Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Or Char.GetNumericValue(e.KeyChar) >= 0 Or Char.IsDigit(e.KeyChar) = False Or Char.IsDigit(e.KeyChar) = True)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbQuanHuyen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuanHuyen.TextChanged
        If Me.cbQuanHuyen.Text.ToString() <> "" And Me.cbTinhThanh.Text.ToString() <> "" Then
            obj.ChonBang = 1
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            obj.MAQUANHUYEN = Me.cbQuanHuyen.Value
            methodLoad()
        End If
    End Sub
    Private Sub btnDong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDong.Activate
        Me.Close()
    End Sub
    Private Sub cbTinhThanh_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTinhThanh.TextChanged
        If Me.cbTinhThanh.Text.ToString() <> "" Then
            obj.ChonBang = 4
            obj.MATINHTHANH = Me.cbTinhThanh.Value
            Me.b = New ClsB_XaPhuong
            Dim tblQuanHuyenTheoTinh As DataTable
            tblQuanHuyenTheoTinh = Me.b.LoadDS(obj)
            If tblQuanHuyenTheoTinh.Rows.Count > 0 Then
                Me.cbQuanHuyen.Text = ""
                Me.cbQuanHuyen.DataSource = Nothing
                Me.cbQuanHuyen.DataSource = tblQuanHuyenTheoTinh
                Me.cbQuanHuyen.SelectedIndex = 0
            Else
                Me.cbQuanHuyen.SelectedIndex = -1
            End If
        End If
    End Sub
End Class