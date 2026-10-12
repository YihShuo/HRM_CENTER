Public Class frmNgayDiemDanh
    Public btOK As Boolean = False
    Public ngaydd As String
    Dim ngaydiemdanh As Date


    Private Sub btnChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon.Click
        If Me.dtpNgay.Value.ToString = "" Then
            MessageBox.Show("Bạn hãy chọn ngày điểm danh để thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btOK = False
            Me.Close()
        Else
            btOK = True
            ngaydiemdanh = Me.dtpNgay.Value
            ngaydd = ngaydiemdanh.Year.ToString() + "-" + ngaydiemdanh.Month.ToString() + "-" + ngaydiemdanh.Day.ToString()
            Me.Close()
        End If
    End Sub
    Private Sub btnHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuy.Click
        btOK = False
        Me.Close()
    End Sub

    Private Sub frmNgayDiemDanh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class