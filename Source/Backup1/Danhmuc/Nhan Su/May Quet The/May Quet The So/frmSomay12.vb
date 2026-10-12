Imports TongHop.frmMayChamCongSo

Public Class frmSomay12

    Private Sub btHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHuy.Click
        TongHop.frmMayChamCongSo.SoMayThayThe = 0
        Me.Close()
    End Sub

    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        If Me.rdSomay1.Checked = True Then
            TongHop.frmMayChamCongSo.SoMayThayThe = 1
        ElseIf Me.rdSomay2.Checked = True Then
            TongHop.frmMayChamCongSo.SoMayThayThe = 2
        End If
        Me.Close()

    End Sub

    Private Sub frmSomay12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rdSomay1.Checked = True
    End Sub
End Class