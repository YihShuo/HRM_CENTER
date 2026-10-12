
Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBBaocaogioconghangngay
    Public Sub New()
        Me.d = New clsDBaocaogioconghangngay
    End Sub

    Public Function LoadDS(ByVal obj As objBaocaogioconghangngay) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function DeleteInfo(ByVal obj As objBaocaogioconghangngay) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objBaocaogioconghangngay) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function

    Friend WithEvents d As clsDBaocaogioconghangngay
End Class
