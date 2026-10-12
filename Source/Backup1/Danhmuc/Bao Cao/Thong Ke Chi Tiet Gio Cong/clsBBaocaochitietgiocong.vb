Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBBaocaochitietgiocong

    Public Sub New()
        Me.d = New clsDBaocaochitietgiocong
    End Sub

    Public Function LoadDS(ByVal obj As objBaocaochitietgiocong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function DeleteInfo(ByVal obj As objBaocaochitietgiocong) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objBaocaochitietgiocong) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function


    Friend WithEvents d As clsDBaocaochitietgiocong
End Class
