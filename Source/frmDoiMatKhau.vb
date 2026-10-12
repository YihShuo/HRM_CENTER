Imports System.Data.SqlClient

Public Class frmDoiMatKhau

    Private TenDangNhap As String
    Dim connString As String = frmDangNhap.GetConnectionString()

    Public Sub New(userName As String)
        InitializeComponent()
        TenDangNhap = userName
    End Sub

    Private Function KiemTraDoManhMatKhau(mk As String) As Boolean
        If mk.Length < 8 Then Return False
        If Not System.Text.RegularExpressions.Regex.IsMatch(mk, "[A-Z]") Then Return False
        If Not System.Text.RegularExpressions.Regex.IsMatch(mk, "[a-z]") Then Return False
        If Not System.Text.RegularExpressions.Regex.IsMatch(mk, "[0-9]") Then Return False
        If Not System.Text.RegularExpressions.Regex.IsMatch(mk, "[!@#$%^&*()_+\-=\[\]{};':"",.<>/?\\|]") Then Return False
        Return True
    End Function

    Private Sub btDoiMatKhau_Click(sender As Object, e As EventArgs) Handles btDoiMatKhau.Click
        Dim mkCu As String = txtMatKhauCu.Text.Trim()
        Dim mkMoi As String = txtMatKhauMoi.Text.Trim()
        Dim mkNhapLai As String = txtNhapLai.Text.Trim()

        If mkCu = "" Or mkMoi = "" Or mkNhapLai = "" Then
            MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!", "Thông báo")
            Exit Sub
        End If

        If mkMoi <> mkNhapLai Then
            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo")
            Exit Sub
        End If

        If Not KiemTraDoManhMatKhau(mkMoi) Then
            MessageBox.Show("Mật khẩu mới phải có tối thiểu 8 ký tự," & vbCrLf &
                            "bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt!",
                            "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim mkCuMaHoa As String = clsTools.Encrypt1(mkCu)
        Dim mkMoiMaHoa As String = clsTools.Encrypt1(mkMoi)

        Try
            Using conn As New SqlConnection(connString)
                conn.Open()

                ' Kiểm tra mật khẩu cũ
                Dim sqlCheck As String = "SELECT COUNT(*) FROM JELL_USER WHERE Ten_DangNhap=@user AND MK_DN=@oldmk"
                Using cmd As New SqlCommand(sqlCheck, conn)
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = TenDangNhap
                    cmd.Parameters.Add("@oldmk", SqlDbType.NVarChar, 100).Value = mkCuMaHoa

                    Dim soDong As Integer = CInt(cmd.ExecuteScalar())
                    If soDong = 0 Then
                        MessageBox.Show("❌ Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                ' Cập nhật mật khẩu mới
                Dim sqlUpdate As String = "UPDATE JELL_USER SET MK_DN=@newmk, NgayDoiMatKhau=GETDATE() WHERE Ten_DangNhap=@user"
                Using cmd As New SqlCommand(sqlUpdate, conn)
                    cmd.Parameters.Add("@newmk", SqlDbType.NVarChar, 100).Value = mkMoiMaHoa
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = TenDangNhap

                    Dim rows As Integer = cmd.ExecuteNonQuery()
                    If rows > 0 Then
                        MessageBox.Show("✅ Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Ẩn form đổi mật khẩu
                        Me.Hide()

                        ' Mở form đăng nhập mới
                        Dim frm As New frmDangNhap()
                        frm.Show()

                        ' Đóng form đổi mật khẩu
                        Me.Close()
                    Else
                        MessageBox.Show("Không tìm thấy người dùng!", "Thông báo")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("❌ Lỗi SQL: " & ex.Message, "Thông báo")
        End Try
    End Sub

    Private Sub btThoat_Click(sender As Object, e As EventArgs) Handles btThoat.Click
        Me.Close()
    End Sub

    Private Sub frmDoiMatKhau_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Logic khi load form nếu cần
    End Sub

End Class
