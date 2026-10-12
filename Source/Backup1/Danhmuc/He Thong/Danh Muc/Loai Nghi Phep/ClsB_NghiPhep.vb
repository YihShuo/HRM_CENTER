Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class ClsB_NghiPhep
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New ClsD_NghiPhep
    End Sub

    Public Function CapNhat(ByVal obj As Obj_NghiPhep, ByVal ThemSua As Integer) As Boolean
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

    Public Function DeleteInfo(ByVal obj As Obj_NghiPhep) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_NghiPhep) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj)
        Else
            MessageBox.Show("Đã tồn tại Mã Nghỉ Phép này, không thêm được. Vui lòng nhập lại!")

        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã nghỉ phép này, Không thêm được.")
        End If
        Return False
    End Function

    Public Function LoadDS(ByVal obj As Obj_NghiPhep) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function PhatSinhMa() As String
        Return Me.d.PhatSinhMa
    End Function

    Public Function UpdateInfo(ByVal obj As Obj_NghiPhep) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        If ((Not table Is Nothing) AndAlso (table.Rows.Count <> 0)) Then
            Return Me.d.UpdateInfo(obj)
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Không tồn tại mã nghỉ phép này, không sửa được.")
        End If
        Return False
    End Function


    ' Fields
    Friend WithEvents d As ClsD_NghiPhep

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
