Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsBGioCongHangNgayDonVi
    Public Event _errorRaise As _errorRaiseEventHandler
    Public Sub New()
        Me.d = New ClsDGioCongHangNgayDonVi
    End Sub
    Public Function LoadDS(ByVal obj As ObjGioCongHangNgayDonVi) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Friend WithEvents d As ClsDGioCongHangNgayDonVi
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
