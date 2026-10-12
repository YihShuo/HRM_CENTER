Imports System.Windows.Forms.Form
Public Class frm_TamUng_TaoMoi
    Public chon As Boolean = False
    Public tien As Double
    Public sotienf As Double
    Public flag As Boolean = False
    Private Sub frm_TamUng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Clear()
        Me.TextBox1.Focus()

        Me.TextBox1.Text = sotienf
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.flag = True
        If IsNumeric(Trim(Me.TextBox1.Text)) = False Then
            MsgBox("Tiền tạm ứng là kiểu số", MsgBoxStyle.Critical, "Sai kiểu dữ liệu")
            Me.TextBox1.Focus()
            Exit Sub
        Else
            If Trim(Me.TextBox1.Text) < 0 Then
                MsgBox("Tiền tạm ứng phải>=0", MsgBoxStyle.Critical, "Thông báo")
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

    Private Sub btDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDong.Click
        Me.Close()
        Me.flag = False
    End Sub
End Class