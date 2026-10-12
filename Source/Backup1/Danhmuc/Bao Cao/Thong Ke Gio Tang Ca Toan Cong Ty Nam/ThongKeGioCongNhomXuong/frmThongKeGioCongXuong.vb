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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Configuration
Public Class frmThongKeGioCongXuong
    Friend WithEvents b As clsBGiotangcathang
    Dim obj As New objGiotangcathang
    Public bChonXuong As Boolean = False
    Public TableDonviTrongXuong As DataTable
    Dim Path As String
    Private Sub frmThongKeGioCongXuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadXuong()
        Me.lblTongXuong.Visible = False
        XemDanhMucXuongThongKeCong()

    End Sub
    Private Sub LoadXuong()
        Dim Tabletemp1 As DataTable
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBGiotangcathang
        obj.ChonBang = 1
        Tabletemp1 = Me.b.LoadDS(obj)
        Me.cboXuong.DataSource = Tabletemp1
        Me.cboXuong.DisplayMember() = "X_MA_"
        Me.cboXuong.ValueMember() = "X_MA_"
        Me.cboXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        If Tabletemp1.Rows.Count > 0 Then
            Me.cboXuong.SelectedIndex = 0
        Else
            Me.cboXuong.Enabled = False
            Exit Sub
        End If
    End Sub
    Private Sub cboXuong_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboXuong.ValueChanged
        Dim tblXuong As DataTable
        If Me.cboXuong.Text.ToString() <> "" Then
            obj.ChonBang = 4
            obj.MANX = cboXuong.Value
            tblXuong = Me.b.LoadDS(obj)
            If tblXuong.Rows.Count > 0 Then
                bChonXuong = True
                Me.btnLuu.Enabled = True
            Else
                Me.btnLuu.Enabled = False
                bChonXuong = False
                MessageBox.Show("Xưởng này không có đơn vị nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            bChonXuong = False
            Me.btnLuu.Enabled = False
            'MessageBox.Show("Vui lòng chọn xưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        'If bChonXuong Then

        '    Dim i As Integer
        '    obj.ChonBang = 9 ''========== kiem tra xuong da co ==========''
        '    obj.MANX = cboXuong.Value
        '    TableDonviTrongXuong = Me.b.LoadDS(obj)
        '    If TableDonviTrongXuong.Rows.Count > 0 Then
        '        ''============= xoa xuong da luu + them lai =========''
        '        Me.b.DeleteDonvi(obj)

        '    End If
        '    Me.b.InsertDonvi(obj)
        '    MessageBox.Show("Bạn đã thêm xưởng xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    XemDanhMucXuongThongKeCong()
        'End If
    End Sub

    Private Sub XemDanhMucXuongThongKeCong()
        Dim tblSLXuong As DataTable
        obj.ChonBang = 6
        Me.b = New clsBGiotangcathang
        Dim grid As New clsTformatGrid
        Me.Path = "/layout/DanhMucXuongThongKeCong.xml"

        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")

        obj.ChonBang = 8
        tblSLXuong = Me.b.LoadDS(obj)
        If CInt(tblSLXuong.Rows(0).Item("SLXUONG")) <> 0 Then
            Me.lblTongXuong.Visible = True
            Me.lblTongXuong.Text = "Nhóm xưởng hiện có: " & tblSLXuong.Rows(0).Item("SLXUONG").ToString()
        Else
            Me.lblTongXuong.Visible = False
        End If
    End Sub
    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        XemDanhMucXuongThongKeCong()
    End Sub
    Private Sub dgrBC_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        ' Khoa cot
        Dim i As Integer
        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            e.Layout.Bands(0).Columns(i).CellAppearance.TextHAlign = HAlign.Center
            e.Layout.Bands(0).Columns(i).CellAppearance.TextVAlign = VAlign.Middle
        Next
        e.Layout.Bands(0).Columns("DV_TEN").CellAppearance.TextHAlign = HAlign.Left

    End Sub

    Private Sub btEx_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEx.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub
End Class