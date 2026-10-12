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

Public Class frmCaLamViec

    Inherits Form
    Public ThemSua As Integer
    Dim obj As New Obj_CaLamViec
    ' Methods
    Public Sub New()
        AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmCaLamViec_KeyUp)
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmCaLamViec_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Public Sub btnIn_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnIn.Activate
        Dim report As New FrmReport
        report.reportID = "1070"
        'Dim strArray As String() = New String() {Me.txtMaNganh.Text}
        'report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub

    Public Sub btnLuu_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Activate
        Me.LuuDuLieu()
    End Sub

    Public Sub btnSua_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnSua.Activate
        Me.HieuChinh()
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

    Public Sub frmCaLamViec_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
            Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
        End If
    End Sub

    Private Sub frmCaLamViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnIn.Visible = False
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New ClsB_CaLamViec
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.methodLoad()
        Me.txtMa.Focus()
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsB_CaLamViec
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/H_CaLamViec.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub


    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then

                Me.txtMa.Text = activeRow.Cells.Item("CA_MA").Value.ToString
                Me.txtMa.ReadOnly = True
                Me.dtpBDau.Text = activeRow.Cells.Item("CA_GIOBATDAU").Value.ToString
                Me.dtpKT.Text = activeRow.Cells.Item("CA_GIOKETTHUC").Value.ToString
                Me.dtpGL.Text = activeRow.Cells.Item("CA_GIOGIAILAO").Value.ToString
                Me.txtPhut.Text = activeRow.Cells.Item("CA_SOPHUTGIAILAO").Value.ToString
                Me.txtShift.Text = activeRow.Cells.Item("SHIFT").Value.ToString

                Me.dtpBD.Select()
                Me.ThemSua = 1

            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub LuuDuLieu()
        Dim jcalamviec As New Obj_CaLamViec
        jcalamviec.setvalue(Me.txtMa.Text, Me.dtpBDau.Value, Me.dtpKT.Value, Me.dtpGL.Value, Me.txtPhut.Text, Me.txtShift.Text)

        If Not jcalamviec.KtMa Then
            MessageBox.Show("Chưa nhập mã Ca ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtMa.Focus()
        Else
            Me.b = New ClsB_CaLamViec
            Try
                If Me.b.CapNhat(jcalamviec, Me.ThemSua) Then
                    MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    jcalamviec.setnull()
                    Me.dgrBC.DataSource = Me.b.LoadDS(jcalamviec)
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

    Public Sub ThemMoi()
        Me.b = New ClsB_CaLamViec
        Me.txtMa.Clear()
        Me.dtpBDau.Text = Now
        Me.dtpKT.Text = Now
        Me.dtpGL.Text = Now
        Me.txtPhut.Clear()
        Me.txtShift.Clear()
        Me.txtMa.ReadOnly = False
        Me.txtMa.Focus()
        Me.ThemSua = 0
    End Sub

    Public Sub XoaDuLieu()
        Try
            Dim jcalamviec As New Obj_CaLamViec
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                Dim str As String
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        str = StringType.FromObject(activeRow.Cells.Item("CA_MA").Value)
                        jcalamviec.MACA = str
                        If (MessageBox.Show(("Bạn có muốn xóa Ca  có mã: " & str & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                            If Me.b.DeleteInfo(jcalamviec) Then
                                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                GoTo Label_0274
                            End If
                            MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Else
                            MessageBox.Show("Không được xóa mã Ca này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                    Return
                End If
                If (MessageBox.Show(("Bạn muốn xóa " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " Ca đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)

                    str = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("CA_MA").Value)
                    jcalamviec.MACA = str
                    If Me.b.DeleteInfo(jcalamviec) Then
                    Else
                        MessageBox.Show("Xóa bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    i += 1
                Loop
            End If
Label_0274:

            jcalamviec.setnull()
            Me.dgrBC.DataSource = Me.b.LoadDS(jcalamviec)

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
        Me.txtMa.Clear()
    End Sub

    Friend WithEvents b As ClsB_CaLamViec

    Private Sub btnThoat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThoat.Activate
        If (Me.btnThoat.Enabled = True) Then
            If (MessageBox.Show(("Bạn muốn thoát khỏi ứng dụng này?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                Me.Close()
            End If
        End If

    End Sub
End Class