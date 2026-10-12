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

Public Class frmCapquyen

    Private Sub frmCapquyen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBCapquyen
        Dim obj As New objNguoiDung
        obj.ChonBang = 1
        Me.methodLoad()
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objCapquyen
        obj.Setnull()
        obj.ChonBang = 1
        obj.TenDangNhap = Me.txtTendangnhap.Text
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/CapQuyen.xml"), typeControl.Grid, "coldgrNguoiDung")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        If (Me.dgrBC.Rows.Count > 0) Then
            Me.dgrBC.Rows.Item(0).Selected = True
            Me.dgrBC.Rows(0).Activated = True
            Me.ChonDong()
        End If
    End Sub

    Friend WithEvents b As clsBCapquyen

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        e.Layout.Bands(0).Columns(0).CellActivation() = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation() = Activation.NoEdit

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
            End If
        End If
    End Sub

    Private Sub btLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLuu.Activate
        Me.dgrBC.UpdateData()
        Dim obj As New objCapquyen
        obj.TenDangNhap = Me.txtTendangnhap.Text
        Me.b = New clsBCapquyen
        'Me.b.DeleteInfo(obj)

        Dim i As Integer = 0
        While i < Me.dgrBC.Rows.Count
            'MessageBox.Show(Me.dgrBC.Rows(i).Cells("Xoa").Value.ToString)
            If Me.dgrBC.Rows(i).Cells("Allow").Value Then
                obj.MaDanhMuc = Me.dgrBC.Rows(i).Cells("Ma_DM").Value.ToString
                If Me.dgrBC.Rows(i).Cells("Allow").Value = -1 Then
                    obj.Xem = 1
                End If
                If Me.dgrBC.Rows(i).Cells("Allow").Value = 0 Then
                    obj.Xem = 0
                End If
                If Me.dgrBC.Rows(i).Cells("Them").Value = -1 Then
                    obj.Them = 1
                End If
                If Me.dgrBC.Rows(i).Cells("Them").Value = 0 Then
                    obj.Them = 0
                End If
                If Me.dgrBC.Rows(i).Cells("Sua").Value = -1 Then
                    obj.Sua = 1
                End If
                If Me.dgrBC.Rows(i).Cells("Sua").Value = 0 Then
                    obj.Sua = 0
                End If
                If Me.dgrBC.Rows(i).Cells("Xoa").Value = -1 Then
                    obj.Xoa = 1
                End If
                If Me.dgrBC.Rows(i).Cells("Xoa").Value = 0 Then
                    obj.Xoa = 0
                End If
                If Me.dgrBC.Rows(i).Cells("KHUA").Value = -1 Then
                    obj.KHUA = 1
                End If
                If Me.dgrBC.Rows(i).Cells("KHUA").Value = 0 Then
                    obj.KHUA = 0
                End If
                If Me.dgrBC.Rows(i).Cells("KHUB").Value = -1 Then
                    obj.KHUB = 1
                End If
                If Me.dgrBC.Rows(i).Cells("KHUB").Value = 0 Then
                    obj.KHUB = 0
                End If
                'obj.Them = Me.dgrBC.Rows(i).Cells("Them").Value
                'obj.Sua = Me.dgrBC.Rows(i).Cells("Sua").Value
                'obj.Xoa = Me.dgrBC.Rows(i).Cells("Xoa").Value
                'obj.KHUA = Me.dgrBC.Rows(i).Cells("KHUA").Value
                'obj.KHUB = Me.dgrBC.Rows(i).Cells("KHUB").Value
                'obj.ChonBang = 1
                'Me.b.InsertInfo(obj)
                obj.ChonBang = 2
                Dim tb As New DataTable
                tb = Me.b.LoadDS(obj)
                If tb.Rows.Count > 0 Then
                    obj.ChonBang = 3
                    Me.b.LoadDS(obj)
                Else
                    obj.ChonBang = 1
                    Me.b.InsertInfo(obj)
                End If
                Me.dgrBC.UpdateData()
            End If
            i = i + 1
        End While
        MessageBox.Show("Đã lưu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.ChonDong()
    End Sub

End Class