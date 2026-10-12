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
Public Class frmNoiDangKyKCB
    Friend WithEvents b As clsBNoiDangKyKCB
    Dim Tabletemp As DataTable
    Dim Table As DataTable
    Public Sub Loaddulieu()
        Dim grid As New clsTformatGrid
        Dim obj As New objNoiDangKyKCB
        Me.b = New clsBNoiDangKyKCB
        obj.ChonBang = 2
        Me.dgrBC2.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC2
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/NOIKCB.xml"), typeControl.Grid, "colNKCB")
        Me.dgrBC2 = DirectCast(dgrBC, UltraGrid)
    End Sub
    Private Sub frmNoiDangKyKCB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New objNoiDangKyKCB
        Me.b = New clsBNoiDangKyKCB
        obj.ChonBang = 1
        Me.Tabletemp = Me.b.LoadDS(obj)
        If Me.Tabletemp.Rows.Count > 0 Then
            Me.txtMa.Text = Me.Tabletemp.Rows(0).Item("MA").ToString()
            Me.txtMa.Focus()
        Else
            Me.txtMa.Text = "BV_"
        End If
        Loaddulieu()
        Me.btSua.Enabled = False
        Me.btXoa.Enabled = False
        Me.btnLuu.Enabled = True
    End Sub
    Private Sub Clear()
        Me.txtMa.Clear()
        Me.txtTen.Clear()
    End Sub
    Private Sub dgrBC2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC2.InitializeLayout
        Dim i As Integer
        For i = 0 To 1
            e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
        Next i
        Me.dgrBC2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC2.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC2.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub dgrBC2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC2.DoubleClick
        Clear()
        Me.btSua.Enabled = False
        Me.btXoa.Enabled = False
        Me.btnLuu.Enabled = True
        Me.txtMa.Enabled = True
        Me.txtMa.Text = "BV_"
    End Sub

    Private Sub dgrBC2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC2.Click
        Me.btSua.Enabled = True
        Me.btXoa.Enabled = True
        Me.btnLuu.Enabled = False
        Me.txtMa.Enabled = False
        HieuChinh()
    End Sub
    Private Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC2.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMa.Text = activeRow.Cells.Item("MA").Value.ToString
                Me.txtMa.Enabled = False
                If Me.txtMa.Text = "" Then
                    Exit Sub
                End If
                Me.txtTen.Text = activeRow.Cells.Item("TEN").Text.ToString()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub LuuDuLieu()
        Dim ma As String
        Dim TEN As String
        
        Dim ngaytao As String
        Dim nguoitao As String
        Dim ngaycn As String
        Dim nguoicn As String

        ma = Me.txtMa.Text().Trim()
        TEN = Me.txtTen.Text().Trim()
       
        Dim obj As New objNoiDangKyKCB

        obj.MA = ma
        obj.TEN = TEN
 

        nguoitao = MAIN.userclient
        nguoicn = MAIN.userclient
        Dim ngaytao1 As DateTime = Now()
        ngaytao = ngaytao1.Year.ToString + "/" + ngaytao1.Month.ToString() + "/" + ngaytao1.Day.ToString() + " " + ngaytao1.Hour.ToString + ":" + ngaytao1.Minute.ToString + ":" + ngaytao1.Second.ToString
        Dim ngaycn1 As DateTime = Now()
        ngaycn = ngaycn1.Year.ToString + "/" + ngaycn1.Month.ToString() + "/" + ngaycn1.Day.ToString() + " " + ngaycn1.Hour.ToString + ":" + ngaycn1.Minute.ToString + ":" + ngaycn1.Second.ToString
       
        obj.NGUOITAO = nguoitao
        obj.NGAYTAO = ngaytao
        obj.NGUOICN = nguoicn
        obj.NGAYCN = ngaycn

        obj.ChonBang = 3
        Me.Table = Me.b.LoadDS(obj)
        If Me.Table.Rows.Count = 0 Then
            obj.ChonBang = 1
            Me.b.InsertInfo(obj)
            Me.Loaddulieu()
            Clear()
            Me.txtMa.Text = "BV_"
            MessageBox.Show("Đã lưu thành công")
        Else
            'Me.HieuChinh()
            If (MessageBox.Show(("Mã này đã có bạn có muốn cập nhật lại không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then

                obj.ChonBang = 1
                Me.b.UpdateInfo(obj)
                Me.Loaddulieu()
                Me.ChonDongCu()
                MessageBox.Show("Đã lưu thành công")
            End If
        End If
    End Sub
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC2.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC2.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub

    Private Sub ChonDongCu()
        If Me.dgrBC2.Rows.Count > 0 Then
            Me.dgrBC2.Rows(oldRow).Selected = True
        End If

    End Sub

    Dim oldRow As Integer = 0
    Private Sub btSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSua.Activate
        If Me.txtTen.Text <> "" And Me.txtMa.Text <> "" Then
            LuuDuLieu()
        Else
            MessageBox.Show("Bạn vui lòng chọn mã")
            Exit Sub
        End If
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        If Me.txtTen.Text <> "" And Me.txtMa.Text <> "" Then
            LuuDuLieu()
        Else
            MessageBox.Show("Bạn vui lòng chọn mã")
            Exit Sub
        End If
    End Sub

    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        Dim obj As New objNoiDangKyKCB
        Dim nguoicn As String
        Dim ma As String
        If Me.txtTen.Text <> "" And Me.txtMa.Text <> "" Then
            ma = Me.txtMa.Text().Trim()
            obj.MA = ma
            nguoicn = MAIN.userclient
            obj.TenDangNhap = nguoicn
            obj.ChonBang = 1
            Me.Table = Me.b.LoadDS(obj)
            If Me.Table.Rows.Count > 0 Then
                If (MessageBox.Show(("Bạn có chắc chắn muốn xóa mã " + ma + " không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    obj.ChonBang = 1
                    Me.b.DeleteInfo(obj)
                    Me.Loaddulieu()
                    Clear()
                    MessageBox.Show("Đã xóa thành công")
                End If
            Else
                MessageBox.Show("Không xóa được")
                Exit Sub
            End If
        Else
            MessageBox.Show("Bạn vui lòng chọn mã")
            Exit Sub
        End If
       
    End Sub

    Private Sub btDong_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Activate
        Me.Close()
    End Sub

    Private Sub dgrBC2_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC2.AfterSelectChange
        Me.ChonDong()
    End Sub
End Class