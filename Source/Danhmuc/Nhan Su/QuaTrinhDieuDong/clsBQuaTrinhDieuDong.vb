Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBQuaTrinhDieuDong
    Friend WithEvents d As clsDQuaTrinhDieuDong
    Public Sub New()
        Me.d = New clsDQuaTrinhDieuDong
    End Sub
    Public Function LoadDS(ByVal obj As objQuaTrinhDieuDong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
End Class
