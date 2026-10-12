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
Imports TongHop.MAIN
Imports Microsoft.VisualBasic.Strings
Public Class frmCapnhatMSTSTK

    Private Sub txtMaNV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaNV.ValueChanged
       
    End Sub
    Public Sub Clear()
        Me.txtHoTen.Clear()
        Me.cboDonVi.Clear()
        Me.dtpNgayVao.Text = Now
        Me.txtMaSoThue.Clear()
        Me.txtSoTaiKhoan.Clear()
        Me.txtMaNV.Clear()
    End Sub
    Dim flag As Boolean
    Dim obj As New objCapnhatMSTSTK
    Dim Path As String
    Friend WithEvents d As clsDCapnhatMSTSTK   ' Nested Types
    Friend WithEvents b As clsBCapnhatMSTSTK
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)

    Private Sub txtMaSoThue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaSoThue.KeyPress
        'If Convert.ToInt32(e.KeyChar) <> 8 Then
        '    If Not Information.IsNumeric(e.KeyChar) Then
        '        e.KeyChar = ""
        '    End If
        'End If
    End Sub

    Private Sub txtSoTaiKhoan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoTaiKhoan.KeyPress
        'If Convert.ToInt32(e.KeyChar) <> 8 Then
        '    If Not Information.IsNumeric(e.KeyChar) Then
        '        e.KeyChar = ""
        '    End If
        'End If
    End Sub

    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Click
        Dim CMND As String
        Dim MANV As String
        Dim TENNV As String
        Dim DONVI As String
        Dim NGAYVAO As String
        Dim MASOTHUE As String
        Dim SOTAIKHOAN As String

        CMND = Me.txtCMND.Text
        MANV = Me.txtMaNV.Text
        TENNV = Me.txtHoTen.Text
        DONVI = Me.cboDonVi.Text
        Dim NGAY As Date
        NGAY = Me.dtpNgayVao.Value
        If Me.dtpNgayVao.ToString = Nothing Then
            NGAYVAO = ""
        Else
            NGAYVAO = NGAY.Year.ToString() + "/" + NGAY.Month.ToString() + "/" + NGAY.Day.ToString()
        End If
        MASOTHUE = Me.txtMaSoThue.Text
        SOTAIKHOAN = Me.txtSoTaiKhoan.Text

        ' SET VALUE
        obj.setvalue(MANV, CMND, MASOTHUE, SOTAIKHOAN, 0)

        Dim flag As Boolean
        flag = False

        obj.ChonBang = 3
        Dim Temp2 As New DataTable
        Me.b = New clsBCapnhatMSTSTK
        Temp2 = Nothing
        obj.CMND = Me.txtCMND.Text
        obj.MaNV = Me.txtMaNV.Text
        Temp2 = Me.b.LoadDS(obj)
        ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
        If Temp2.Rows.Count > 0 Then
            flag = True
        Else
            flag = False
        End If
        If flag = True Then
            obj.ChonBang = 5
            Me.b.UpdateInfo(obj)
            obj.ChonBang = 6
            Me.b.UpdateThaoTac(obj)
            MessageBox.Show("Cập Nhật Thành Công")
            Dim grid As New clsTformatGrid
            Me.Path = "/layout/CapNhatMST.xml"
            obj.ChonBang = 2
            Dim Temp As New DataTable
            Me.b = New clsBCapnhatMSTSTK
            Temp = Nothing
            obj.MaNV = Me.txtCMND.Text
            Temp = Me.b.LoadDS(obj)
            ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
            Me.dgrBC.DataSource = Temp
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgr")

        Else
            MessageBox.Show("Nhân viên này chưa có")
            Exit Sub
        End If

    End Sub


    Public Sub luuThaoTacUpdate()


    End Sub

    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                Me.txtMaNV.Text = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.txtHoTen.Text = activeRow.Cells.Item("NV_TEN").Value.ToString
                Me.cboDonVi.Text = activeRow.Cells.Item("DV_MA").Value.ToString
                Me.dtpNgayVao.Text = activeRow.Cells.Item("NV_NGAYVAO").Value.ToString
                Me.txtSoTaiKhoan.Text = activeRow.Cells.Item("SOTAIKHOAN").Value.ToString
                Me.txtMaSoThue.Text = activeRow.Cells.Item("MASOTHUE").Value.ToString

            End If
            Me.flag = 1
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Dim grid As New clsTformatGrid
    Private Sub txtCMND_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCMND.ValueChanged
        If Me.txtCMND.TextLength = 9 Or Me.txtCMND.TextLength = 10 Or Me.txtCMND.TextLength = 12 Then

            Me.Path = "/layout/CapNhatMST.xml"
            obj.ChonBang = 2
            Me.b = New clsBCapnhatMSTSTK
            obj.CMND = Me.txtCMND.Text
            ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
            Me.dgrBC.DataSource = Me.b.LoadDS(obj)
            Dim dgrBC As Object = Me.dgrBC
            grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgr")
            Me.Clear()
        ElseIf Me.txtCMND.Text = "" Then
            Me.Clear()
        Else
            Me.Clear()
        End If
    End Sub

    Private Sub txtCMND_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCMND.KeyPress
    End Sub

    Private Sub frmCapnhatMSTSTK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtMaNV.Enabled = False
        Me.txtHoTen.Enabled = False
        Me.cboDonVi.Enabled = False
        Me.dtpNgayVao.Enabled = False
    End Sub

    Private Sub dgrBC_AfterSelectChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgrBC.AfterSelectChange
        Me.HieuChinh()
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer = 0
        While i <= 7
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
            i = i + 1
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ngay As DateTime = Now
        MessageBox.Show(userclient.ToString, ngay.ToString)
    End Sub
End Class