Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class clsBBaocaogiocongxuong

    Public Sub New()
        Me.d = New clsDBaocaogiocongxuong
    End Sub

    Public Function LoadDS(ByVal obj As objBaocaogiocongxuong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function


    Public Function DeleteInfo(ByVal obj As objBaocaogiocongxuong) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objBaocaogiocongxuong) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function

    Friend WithEvents d As clsDBaocaogiocongxuong
End Class
