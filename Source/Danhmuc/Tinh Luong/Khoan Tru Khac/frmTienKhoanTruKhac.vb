Imports System.Windows.Forms.Form
Public Class frmTienKhoanTruKhac
    Public chon As Boolean = False
    Public tien As Double
    Public sotienf As Double
    Public flag As Boolean = False
    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Click
        Me.flag = True
        If IsNumeric(Trim(Me.TextBox1.Text)) = False Then
            MsgBox("Tiền trừ khác là kiểu số", MsgBoxStyle.Critical, "Sai kiểu dữ liệu")
            Me.TextBox1.Focus()
            Exit Sub
        Else
            If Trim(Me.TextBox1.Text) < 0 Then
                MsgBox("Tiền trừ phài>=0", MsgBoxStyle.Critical, "Thông báo")
                Me.TextBox1.Focus()
                Exit Sub
            End If
        End If
        If Me.TextBox1.Text <> "" Then
            tien = Me.TextBox1.Text.Trim()
        Else
            tien = 0
        End If
        Me.Close()
    End Sub

    Private Sub frmTienKhoanTruKhac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Clear()
        Me.TextBox1.Focus()
        Me.TextBox1.Text = sotienf
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.flag = False
        Me.Close()
    End Sub
End Class