Imports System.Windows.Forms.Form
Public Class frmChuyenDuLieu
    Dim Tabletemp As DataTable
    Friend WithEvents b As clsBPhuCapKhac
    Public THANGT As String
    Public Ngay As String
    Private Sub frmChuyenDuLieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim thang As String
        Dim nam As String
        thang = Month(frmPhuCapKhac.dtpNgay.Value)
        If Len(thang) = 1 Then
            thang = "0" + thang
        Else
            thang = thang
        End If
        nam = Year(frmPhuCapKhac.dtpNgay.Value)
        Dim obj As New objPhuCapKhac
        obj.ChonBang = 8
        obj.NamThang = thang + "-" + nam

        Me.b = New clsBPhuCapKhac
        Me.Tabletemp = Me.b.LoadDS(obj)
        Me.cbThang.DataSource = Me.Tabletemp
        Me.cbThang.SelectedIndex = 0
        'Me.cbThang.Text = Me.THANGT

    End Sub

    Private Sub btCapNhat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Click

        If Me.cbThang.Text <> "" Then
            Me.THANGT = Me.cbThang.Value.ToString()
        Else
            Me.THANGT = ""
        End If
        Me.Close()
    End Sub

    Private Sub btThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub
End Class