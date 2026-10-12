Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDanhSachCongViec
    Friend WithEvents d As clsDDanhSachCongViec
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDDanhSachCongViec
    End Sub

    Public Function LoadDS(ByVal obj As objDanhSachCongViec) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
