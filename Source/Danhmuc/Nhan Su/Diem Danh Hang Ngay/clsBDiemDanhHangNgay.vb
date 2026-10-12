Public Class clsBDiemDanhHangNgay


    Friend WithEvents d As clsDDiemDanhHangNgay

    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Event _errorRaise As _errorRaiseEventHandler

    Public Sub New()
        Me.d = New clsDDiemDanhHangNgay
    End Sub

    Public Function LoadDS(ByVal obj As objDiemDanhHangNgay) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function CapNhat(ByVal obj As objDiemDanhHangNgay, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo(obj)
        End If
        Return Me.UpdateInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objDiemDanhHangNgay) As Boolean

        Return Me.d.InsertInfo(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As objDiemDanhHangNgay) As Boolean

        Return Me.d.UpdateInfo(obj)

    End Function

    Public Function DeleteInfo(ByVal obj As objDiemDanhHangNgay) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    'Public Function GoiThuTuc(ByVal Table As String, ByVal para As ArrayList, ByVal indexOut As Integer) As DataTable
    '    Return Me.d.GoiThuTuc(Table, para, indexOut)
    'End Function

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
End Class
