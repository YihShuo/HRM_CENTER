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
Public Class frmKhu
    Inherits Form
    Dim flag As Boolean
    Dim obj As New objKhu
    Dim Path As String
    Friend WithEvents d As clsDKhu   ' Nested Types
    Friend WithEvents b As clsBKhu
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public ThemSua As Integer = 0
    Public Sub New()
        AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.frmKhu_KeyUp)
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmKhu_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub
    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Public Sub ThemMoi()
        Me.txtMaKhu.ReadOnly = False
        Me.txtMaKhu.Clear()
        Me.txtSoTT.Clear()
        Me.txtTenKhu.Clear()
        Me.txtGhiChu.Clear()
        Me.txtMaKhu.Focus()
        Me.txtTenKhu.Enabled = True
        Me.txtSoTT.Enabled = True
        Me.txtGhiChu.Enabled = True
    End Sub
    
    Private Sub frmKhu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If ((e.KeyCode = Keys.F2) AndAlso Me.btnLuu.Enabled) Then
            Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
        End If
    End Sub

    Private Sub frmKhu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBKhu
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        methodLoad()
        Me.ThemMoi()
        Me.btnSua.Enabled = True
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBKhu
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/Khu.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub
    Dim oldRow As Integer = 0
    Private Sub ChonDong()
        Dim oldRow As Integer = 0
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub txtSoTT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoTT.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub
    Public Sub HieuChinh()
        Dim flag As Boolean
        flag = False
        Dim Temp2 As New DataTable
        Me.ThemSua = 1

        Me.txtMaKhu.ReadOnly = True
        Me.txtTenKhu.Enabled = False
        Me.txtSoTT.Enabled = False
        Me.txtGhiChu.Enabled = False

        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                obj.ChonBang = 1
                Me.txtMaKhu.Text = activeRow.Cells.Item("KHU_MA").Value.ToString
                obj.MaKhu = Me.txtMaKhu.Text

                Me.b = New clsBKhu
                Temp2 = Nothing
                obj.MaKhu = Me.txtMaKhu.Text
                Temp2 = Me.b.LoadDS(obj)
                ' Kiem tra neu nha xuong nhap vao co trong bang nha xuong thi bien flag = true nguoc lai bien flag = false
                If Temp2.Rows.Count > 0 Then
                    flag = True
                Else
                    flag = False
                End If
                If Temp2.Rows(0).Item("KHU_TEN").ToString = Nothing Then
                    Me.txtTenKhu.Text = ""
                Else
                    Me.txtTenKhu.Text = Temp2.Rows(0).Item("KHU_TEN")
                End If
                Me.txtSoTT.Text = Temp2.Rows(0).Item("THUTU")
                If Temp2.Rows(0).Item("KHU_GHICHU").ToString = Nothing Then
                    Me.txtGhiChu.Text = ""
                Else
                    Me.txtGhiChu.Text = Temp2.Rows(0).Item("KHU_GHICHU")
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.ThemMoi()
    End Sub
    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.ChonDong()
        Me.HieuChinh()
        Me.txtTenKhu.Enabled = True
        Me.txtSoTT.Enabled = True
        Me.txtGhiChu.Enabled = True
    End Sub
    Public Sub LuuDuLieu()
        Dim MAKHU As String
        Dim TENKHU As String
        Dim SOTT As Integer
        Dim GHICHU As String


        If Me.txtSoTT.Text = "" Then
            SOTT = 0
        Else
            SOTT = Me.txtSoTT.Text
        End If

        If Me.txtMaKhu.Text = "" Then
            MessageBox.Show("Bạn phải nhập mã khu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMaKhu.Focus()
            Exit Sub
        End If

        If Me.txtTenKhu.Text = "" Then
            MessageBox.Show("Bạn phải nhập tên nhà khu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtTenKhu.Focus()
            Exit Sub
        End If

        MAKHU = Me.txtMaKhu.Text
        TENKHU = Me.txtTenKhu.Text
        GHICHU = Me.txtGhiChu.Text

        ' SET VALUE
        obj.setvalue(MAKHU, TENKHU, SOTT, GHICHU, 0)

        Dim flag As Boolean
        flag = False

        obj.ChonBang = 1
        Dim Temp2 As New DataTable
        Me.b = New clsBKhu
        Temp2 = Nothing
        obj.MaKhu = Me.txtMaKhu.Text
        Temp2 = Me.b.LoadDS(obj)
        ' Kiem tra neu nha xuong nhap vao co trong bang nha xuong thi bien flag = true nguoc lai bien flag = false
        If Temp2.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = True Then
            Me.txtMaKhu.ReadOnly = False
            If (MessageBox.Show(("Khu này đã có, bạn có muốn sửa lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                obj.ChonBang = 3
                If Me.b.UpdateInfo(obj) Then
                    MessageBox.Show("Đã cập nhật khu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Không thể cập nhật khu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                GoTo Them
            End If
        Else
            obj.ChonBang = 1
            If Me.b.InsertInfo(obj) Then
                MessageBox.Show("Đã thêm khu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không thể thêm khu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        methodLoad()
Them:
        Me.ThemMoi()
        Me.btnThem.Enabled = True
    End Sub
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        LuuDuLieu()
    End Sub
    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
        Me.HieuChinh()
    End Sub
    Private Sub dgrBC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.ChonDong()
        Me.HieuChinh()
    End Sub
    Private Sub dgrBC_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgrBC.DoubleClickRow
        Me.ThemMoi()
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        dgrBC.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        dgrBC.DisplayLayout.Bands(0).Override.SelectTypeRow = SelectType.Single
        For i = 0 To dgrBC.DisplayLayout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next
    End Sub
End Class