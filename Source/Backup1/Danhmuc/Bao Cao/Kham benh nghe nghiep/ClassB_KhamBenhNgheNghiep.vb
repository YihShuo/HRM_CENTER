Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class ClassB_KhamBenhNgheNghiep
    Public Event _errorRaise As _errorRaiseEventHandler
    Friend WithEvents d As ClassD_KhamBenhNgheNghiep
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Public Sub New()
        Me.d = New ClassD_KhamBenhNgheNghiep
    End Sub
    Public Function LoadDS(ByVal obj As obj_KhamBenhNgheNghiep) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function ThongKeTheoXuong(ByVal obj As obj_KhamBenhNgheNghiep, ByVal bChonDenNgay As Integer) As DataTable
        Return Me.d.ThongKeTheoXuong(obj, bChonDenNgay)
    End Function
End Class
