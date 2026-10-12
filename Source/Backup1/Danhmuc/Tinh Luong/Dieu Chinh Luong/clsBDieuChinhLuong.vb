Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDieuChinhLuong

    Friend WithEvents d As clsDDieuChinhLuong
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDDieuChinhLuong
    End Sub

    Public Function LoadDS(ByVal obj As objDieuChinhLuong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
