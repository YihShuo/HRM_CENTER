Public Class mError
    Public Shared Function getMSG(ByVal index As Integer) As String
        Select Case index
            Case 1
                Return "Không kết nối được với Server"
            Case 2
                Return "Lỗi trong quá trình lấy dữ liệu"
            Case 3
                Return "Không lấy được chuổi kết nối"
            Case 4
                Return "Đường dẫn đến file không hợp lệ"
            Case 5
                Return "Lỗi trong quá trình cập nhật dữ liệu"
        End Select
        Return ""
    End Function
End Class
