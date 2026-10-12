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
Imports System.Drawing.Bitmap
Imports System.Configuration
Public Class frmDanhMucQLMTCV_PTCV
    Dim Tabletemp As DataTable
    Private Sub frmDanhMucQLMTCV_PTCV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Me.methodLoad()
        Me.btnSua.Enabled = False

        'AddHandler dgrBC.InitializeRow, AddressOf dgrBC_InitializeRow
        'If Me.chkXemMTCVPTCV.Checked = True Then
        '    Me.lbCheck.Text = "Hoa"
        'Else
        '    Me.lbCheck.Text = "Việt"
        'End If
        Me.chkTrucTiep.Checked = False
    End Sub

    Dim obj As New objDanhMucQLMTCV_PTCV
    Friend WithEvents d As clsDDanhMucQLMTCV_PTCV    ' Nested Types
    Friend WithEvents b As clsBDanhMucQLMTCV_PTCV
    Dim tableSoTT As New DataTable
    Dim SOTT As String = ""
    Dim Path As String
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBDanhMucQLMTCV_PTCV
        Me.Path = "/layout/QuanLyMTCVPTCV.xml"
        obj.ChonBang = 2
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrql")
    End Sub
    Private Sub cbDonvi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.methodLoad()
    End Sub
    Private Sub dgrBC_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgrBC.MouseDown
    End Sub

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Dim DV_MA As String
        Dim NHOMCV_MA As String
        Dim NHOMCV_TEN As String
        Dim GHICHU As String
        Dim NHOMCV_TT As Integer
        Dim NHOMCV_TINHTRANG As Integer

        NHOMCV_MA = Me.txtMaNhomCV.Text.Trim()
        NHOMCV_TEN = Me.txtTenNhomCV.Text.Trim()
        GHICHU = Me.txtGhiChu.Text.Trim()
        If Me.chkTrucTiep.Checked = True Then
            NHOMCV_TT = 1
        Else
            NHOMCV_TT = 0
        End If
        If Me.chkTinhTrang.Checked = True Then
            NHOMCV_TINHTRANG = 1
        Else
            NHOMCV_TINHTRANG = 0
        End If

        obj.DONVI = DV_MA
        obj.NHOMCV_MA = NHOMCV_MA
        obj.NHOMCV_TEN = NHOMCV_TEN
        obj.GHICHU = GHICHU
        obj.NHOMCV_TT = NHOMCV_TT
        obj.NHOMCV_TINHTRANG = NHOMCV_TINHTRANG

        obj.ChonBang = 3
        Dim table As DataTable
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            MessageBox.Show("Mã nhóm công việc này đã có")
            Me.txtMaNhomCV.Focus()
            Exit Sub
        Else

            obj.setvalue(NHOMCV_MA, NHOMCV_TEN, obj.GHICHU, NHOMCV_TT, NHOMCV_TINHTRANG)
            obj.ChonBang = 1
            Me.b = New clsBDanhMucQLMTCV_PTCV
            Me.b.InsertInfo(obj)
            MessageBox.Show("Bạn đã thêm thành công")
        End If
        Me.methodLoad()
        Me.ClearNoiDung()

    End Sub

    Public Sub ClearNoiDung()
        Me.txtMaNhomCV.Clear()
        Me.txtTenNhomCV.Clear()
        Me.txtGhiChu.Clear()
        Me.txtMaNhomCV.Focus()
        Me.chkTrucTiep.Checked = False
    End Sub



    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Dim DV_MA As String
        Dim NHOMCV_MA As String
        Dim NHOMCV_TEN As String
        Dim GHICHU As String
        Dim NHOMCV_TT As Integer
        Dim NHOMCV_TINHTRANG As Integer

        NHOMCV_MA = Me.txtMaNhomCV.Text.Trim()
        NHOMCV_TEN = Me.txtTenNhomCV.Text.Trim()
        GHICHU = Me.txtGhiChu.Text.Trim()

        If Me.chkTrucTiep.Checked = True Then
            NHOMCV_TT = 1
        Else
            NHOMCV_TT = 0
        End If
        If Me.chkTinhTrang.Checked = True Then
            NHOMCV_TINHTRANG = 1
        Else
            NHOMCV_TINHTRANG = 0
        End If

        obj.DONVI = DV_MA
        obj.NHOMCV_MA = NHOMCV_MA
        obj.NHOMCV_TEN = NHOMCV_TEN
        obj.GHICHU = GHICHU
        obj.NHOMCV_TT = NHOMCV_TT
        obj.NHOMCV_TINHTRANG = NHOMCV_TINHTRANG

        obj.ChonBang = 3
        Dim table As DataTable
        table = Me.b.LoadDS(obj)
        If table.Rows.Count > 0 Then
            obj.setvalue(NHOMCV_MA, NHOMCV_TEN, obj.GHICHU, NHOMCV_TT, NHOMCV_TINHTRANG)
            obj.ChonBang = 1
            Me.b = New clsBDanhMucQLMTCV_PTCV
            Me.b.UpdateInfo(obj)
            MessageBox.Show("Bạn đã sửa thành công")
        End If
        Me.methodLoad()
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.txtMaNhomCV.Enabled = True
        Me.btnThem.Enabled = True
        Me.btnSua.Enabled = False
        Me.btnXoa.Enabled = False
        Me.ClearNoiDung()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer
        For i = 0 To 4
            e.Layout.Bands(0).Columns(i).CellActivation() = Activation.NoEdit
        Next i
    End Sub
    Private Sub HieuChinh()
        Try
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            Me.txtMaNhomCV.Text = activeRow.Cells.Item("NHOMCV_MA").Value.ToString
            Me.txtTenNhomCV.Text = activeRow.Cells.Item("NHOMCV_TEN").Value.ToString
            Me.txtGhiChu.Text = activeRow.Cells.Item("GHICHU").Value.ToString

            If activeRow.Cells.Item("NHOMCV_TT").Value = True Then
                Me.chkTrucTiep.Checked = True
            Else
                Me.chkTrucTiep.Checked = False
            End If
            If activeRow.Cells.Item("NHOMCV_TINHTRANG").Value = True Then
                Me.chkTinhTrang.Checked = True
            Else
                Me.chkTinhTrang.Checked = False
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.btnSua.Enabled = True
        Me.txtMaNhomCV.Enabled = False
        Me.btnThem.Enabled = False
        Me.btnXoa.Enabled = True
        HieuChinh()
    End Sub

    Private Sub txtSoNguoi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Dim activeCell As UltraGridCell = Me.dgrBC.ActiveCell
        If MessageBox.Show("Bạn muốn xóa mã nhóm công việc " + activeCell.Row.Cells.Item("NHOMCV_MA").Text + " không? ", "Thông Báo", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            obj.ChonBang = 1
            obj.NHOMCV_MA = activeCell.Row.Cells.Item("NHOMCV_MA").Text
            Me.b = New clsBDanhMucQLMTCV_PTCV
            Me.b.DeleteInfo(obj)
            MessageBox.Show("Bạn đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.methodLoad()
            Me.ClearNoiDung()
            Me.btnThem.Enabled = True
            Me.btnSua.Enabled = False
            Me.btnXoa.Enabled = False
            Me.txtMaNhomCV.Enabled = True
        End If
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs)

    End Sub
    Private Sub chkXemMTCVPTCV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class