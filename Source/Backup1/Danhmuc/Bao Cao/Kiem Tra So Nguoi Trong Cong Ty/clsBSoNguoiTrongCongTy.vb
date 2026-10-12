Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class clsBSoNguoiTrongCongTy
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New clsDSoNguoiTrongCongTy
    End Sub

    Public Function LoadDS(ByVal obj As objSoNguoiTrongCongTy) As DataTable
        Return Me.d.LoadDS(obj)
    End Function




    ' Fields
    Friend WithEvents d As clsDSoNguoiTrongCongTy
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
