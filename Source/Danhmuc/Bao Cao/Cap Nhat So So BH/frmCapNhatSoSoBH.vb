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
Public Class frmCapNhatSoSoBH
    Dim flag As Boolean
    Dim obj As New objCapNhatSoSoBH
    Dim Path As String
    Friend WithEvents d As clsDCapNhatSoSoBH   ' Nested Types
    Friend WithEvents b As clsBCapNhatSoSoBH
    Public Sub Clear()
        Me.txtHoTen.Clear()
        Me.txtCMND.Clear()
        Me.cboDonVi.Clear()
        Me.dtpNgayVao.Text = Now
        Me.txtSoSoBH.Clear()
    End Sub
    Public Sub Enable(ByVal enable As Boolean)
        Me.txtHoTen.Enabled = enable
        Me.txtCMND.Enabled = enable
        Me.cboDonVi.Enabled = enable
        Me.dtpNgayVao.Enabled = enable

    End Sub

    Private Sub txtSoSoBH_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoSoBH.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Click
        If Me.txtMaNV.Text = "" Then
            MessageBox.Show("Vui lòng nhập mã nhân viên")
            Me.txtMaNV.Focus()
        Else

            Dim MANV As String
            MANV = Me.txtMaNV.Text
            obj.ChonBang = 2
            Dim Temp2 As New DataTable
            Me.b = New clsBCapNhatSoSoBH
            Temp2 = Nothing
            obj.MaNV = Me.txtMaNV.Text
            Temp2 = Me.b.LoadDS(obj)
            Dim flag1 As Boolean
            flag1 = False
            If Temp2.Rows.Count > 0 Then
                flag1 = True
            Else
                flag1 = False
            End If
            If flag1 = True Then
                obj.SOSOBAOHIEM = Me.txtSoSoBH.Text
                If obj.SOSOBAOHIEM <> "" Then
                    obj.ChonBang = 5
                    Me.b.UpdateInfo(obj)
                    MessageBox.Show("Cập Nhật Thành Công")
                Else
                    MessageBox.Show("Vui lòng nhập số sổ bảo hiểm")
                    Me.txtSoSoBH.Focus()
                End If
            Else
                MessageBox.Show("Nhân viên này chưa có")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtMaNV_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaNV.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtMaNV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaNV.ValueChanged

        If Me.txtMaNV.TextLength = 6 Then
            Dim MANV As String
            MANV = Me.txtMaNV.Text
            obj.ChonBang = 2
            Dim Temp As New DataTable
            Me.b = New clsBCapNhatSoSoBH
            Temp = Nothing
            obj.MaNV = Me.txtMaNV.Text
            Temp = Me.b.LoadDS(obj)
            ' Kiem tra neu nhanvien nhap vao co trong bang nhanvien thi bien flag = true nguoc lai bien flag = false
            If Temp.Rows.Count > 0 Then
                flag = True
            Else
                flag = False
            End If
            If flag = True Then
                Me.txtCMND.Text = Temp.Rows(0).Item("NV_CMND").ToString
                Me.txtHoTen.Text = Temp.Rows(0).Item("NV_TEN").ToString
                Me.cboDonVi.Text = Temp.Rows(0).Item("DV_MA").ToString
                Me.dtpNgayVao.Text = Temp.Rows(0).Item("NV_NGAYVAO").ToString
                'Me.txtSoSoBH.Text = Temp.Rows(0).Item("NV_SoSoBH").ToString
                Enable(False)
            Else
                Me.Clear()
                Enable(True)
                Me.txtMaNV.SelectAll()
                MessageBox.Show("Mã nhân viên này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf Me.txtMaNV.Text = "" Then
            Me.Clear()
        End If
    End Sub

    Private Sub frmCapNhatSoSoBH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Enable(False)
    End Sub
End Class