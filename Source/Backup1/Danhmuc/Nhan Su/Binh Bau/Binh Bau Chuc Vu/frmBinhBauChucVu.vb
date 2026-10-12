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
Public Class frmBinhBauChucVu
    Dim Tabletemp As DataTable

    Friend WithEvents b As clsBBinhBauChucVu
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBBinhBauChucVu
        Me.Path = "/layout/BBCHUCVU.xml"
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")
        Me.txtSonhanvien.Text = Me.dgrBC.Rows.Count()
    End Sub
    Public Shared obj As New objBinhBauChucVu
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Dim oldRow As Integer = 0
    Friend WithEvents d As clsDBinhBauChucVu
    Private Sub ChonDong()
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            If activeCell.Row.Index <> -1 Then
                Me.dgrBC.Rows(activeCell.Row.Index).Selected = True
                Me.oldRow = activeCell.Row.Index
            End If
        End If
    End Sub
    Private Sub ChonDongCu()
        Me.dgrBC.Rows(oldRow).Selected = True
    End Sub
    Public flagD As Integer = 0
    Private Sub lbTaoMoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTaoMoi.Click
        Dim frm As New frmChiTietBBCV
        frm.ShowDialog()
        If frm.FLAG = 0 Then

            ' kiem tra coi co chua
            obj.ChonBang = 5
            obj.BB_CVMA = frm.mabb
            obj.CVU_MA = frm.cvu
            Dim Temp As New DataTable
            Me.b = New clsBBinhBauChucVu
            Temp = Nothing
            Temp = Me.b.LoadDS(obj)

            If Temp.Rows.Count > 0 Then
                ''cap nhat, hien thi len
                If (MessageBox.Show(("Bình bầu này đã có, bạn có muốn cập nhật không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    obj.Setnull()
                    obj.BB_CVMA = frm.mabb
                    obj.CVU_MA = frm.cvu
                    obj.SoTien = frm.tien
                    obj.setvalue(obj.BB_CVMA, obj.CVU_MA, obj.SoTien, 0)
                    obj.ChonBang = 1
                    Me.b = New clsBBinhBauChucVu
                    Me.b.UpdateInfo(obj)
                    MessageBox.Show("Đã lưu dữ liệu")
                    Me.methodLoad()
                End If
            Else
                '' them moi

                obj.Setnull()
                obj.BB_CVMA = frm.mabb
                obj.CVU_MA = frm.cvu
                obj.SoTien = frm.tien
                obj.setvalue(obj.BB_CVMA, obj.CVU_MA, obj.SoTien, 0)
                obj.ChonBang = 1
                Me.b = New clsBBinhBauChucVu
                Me.b.InsertInfo(obj)
                MessageBox.Show("Đã lưu dữ liệu")
                Me.methodLoad()

            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        'Chen bieu tuong vao luoi
        e.Layout.Bands(0).Columns("1").CellAppearance.Image = 0
        e.Layout.Bands(0).Columns("2").CellAppearance.Image = 2
        Dim i As Integer
        For i = 0 To 4
            'If i <> 1 Then
            e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
            'End If
        Next i
        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub frmBinhBauChucVu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.methodLoad()
    End Sub

    Private Sub dgrBC_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dgrBC.DoubleClickCell
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If Not activeCell Is Nothing Then
            'MessageBox.Show(activeCell.Column.Key.ToString())
            Dim ColA As String = (activeCell.Column.Key.ToString())
            Dim RowA As Integer = (activeCell.Row.Index)
            Select Case ColA
                Case "1"
                    Me.flagD = 1
                    obj.BB_CVMA = activeCell.Row.Cells.Item("BBCV_MA").Text
                    obj.CVU_MA = activeCell.Row.Cells.Item("CVU_MA").Text
                    Dim frm As New frmChiTietBBCV
                    obj.ChonBang = 5
                    Dim Temp3 As New DataTable
                    Me.b = New clsBBinhBauChucVu
                    Temp3 = Nothing
                    Temp3 = Me.b.LoadDS(obj)
                    If Temp3.Rows.Count > 0 Then

                        Dim MABB As String = Temp3.Rows(0).Item("BBCV_MA").ToString
                        Dim CVU As String = Temp3.Rows(0).Item("CVU_MA").ToString
                        Dim STIEN As String = Temp3.Rows(0).Item("SOTIEN").ToString

                        frm.cbBinhBau.Text = MABB
                        frm.cbChucVu.Text = CVU
                        frm.txtSoTien.Text = STIEN
                    End If
                    frm.cbBinhBau.Enabled = False
                    frm.ShowDialog()

                    If frm.FLAG = 0 Then
                        'Goi ham cham cong (SP_CHAMCONGN)
                        obj.Setnull()
                        obj.BB_CVMA = frm.mabb
                        obj.CVU_MA = frm.cvu
                        obj.SoTien = frm.tien
                        obj.setvalue(obj.BB_CVMA, obj.CVU_MA, obj.SoTien, 0)
                        obj.ChonBang = 1
                        Me.b = New clsBBinhBauChucVu
                        Me.b.UpdateInfo(obj)
                        MessageBox.Show("Đã lưu dữ liệu")
                        Me.methodLoad()
                    Else
                        Exit Sub
                    End If

                    Me.ChonDongCu()
                Case "2"
                    Me.flagD = 0
                    If MessageBox.Show("Bạn có muốn xóa record của bình bầu " + activeCell.Row.Cells.Item("BBCV_MA").Text + "  và chức vụ " + activeCell.Row.Cells.Item("CVU_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                        obj.ChonBang = 1
                        obj.BB_CVMA = activeCell.Row.Cells.Item("BBCV_MA").Text
                        obj.CVU_MA = activeCell.Row.Cells.Item("CVU_MA").Text
                        Me.b = New clsBBinhBauChucVu
                        Me.b.DeleteInfo(obj)
                        MessageBox.Show("Đã xóa thành công")
                        Me.methodLoad()
                    End If
            End Select
        End If
    End Sub
End Class