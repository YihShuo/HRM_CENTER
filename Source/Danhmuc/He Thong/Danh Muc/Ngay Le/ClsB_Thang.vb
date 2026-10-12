Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class ClsB_Thang
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New ClsD_Thang
    End Sub

    Public Function CapNhat(ByVal obj As Obj_Thang, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo(obj)
        End If
        Return Me.UpdateInfo(obj)
    End Function

    Public Function CapNhat1(ByVal obj As Obj_Thang, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo1(obj)
        End If
        Return Me.UpdateInfo1(obj)
    End Function

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function DeleteInfo(ByVal obj As Obj_Thang) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function DeleteInfo1(ByVal obj As Obj_Thang) As Boolean
        Return Me.d.DeleteInfo1(obj)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_Thang) As Boolean
        obj.ChonBang = 4
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj)
        Else
            MessageBox.Show("Đã tồn tại mã Tháng này, không thêm được. Vui lòng nhập lại!")
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã Tháng này, Không thêm được.")
        End If
        Return False
        'Return Me.d.InsertInfo(obj)
    End Function

    Public Function InsertInfo1(ByVal obj As Obj_Thang) As Boolean
        obj.ChonBang = 5
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo1(obj)
        Else
            MessageBox.Show("Đã tồn tại mã Tháng này, vui lòng nhập lại!")
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã Tháng  này, không thêm được. Không thêm được.")
        End If
        Return False
        'Return Me.d.InsertInfo1(obj)
    End Function

    Public Function LoadDS(ByVal obj As Obj_Thang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As Obj_Thang) As Boolean
        Return Me.d.UpdateInfo(obj)
    End Function

    Public Function UpdateInfo1(ByVal obj As Obj_Thang) As Boolean
        Return Me.d.UpdateInfo1(obj)
    End Function

    ' Fields
    Friend WithEvents d As ClsD_Thang

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
