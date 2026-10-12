Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsB_XaPhuong
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New ClsD_XaPhuong
    End Sub

    Public Function CapNhat(ByVal obj As Obj_XaPhuong, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo(obj)
        End If
        Return Me.UpdateInfo(obj)
    End Function

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function DeleteInfo(ByVal obj As Obj_XaPhuong) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_XaPhuong) As Boolean
        obj.ChonBang = 6
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj)
        Else
            MessageBox.Show("Đã tồn tại dữ liệu: " & obj.MAXAPHUONG & ",quận/huyện: " & obj.TENQUANHUYEN & ",tỉnh: " & obj.TENTINHTHANH & ".Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã xã phường này, Không thêm được.")
        End If
        Return False
    End Function

    Public Function LoadDS(ByVal obj As Obj_XaPhuong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As Obj_XaPhuong) As Boolean
        obj.ChonBang = 6
        Dim table As DataTable = Me.LoadDS(obj)
        If ((Not table Is Nothing) AndAlso (table.Rows.Count <> 0)) Then
            Return Me.d.UpdateInfo(obj)
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Không tồn tại mã xã phường này, không sửa được.")
        End If
        Return False
    End Function


    ' Fields
    Friend WithEvents d As ClsD_XaPhuong

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
