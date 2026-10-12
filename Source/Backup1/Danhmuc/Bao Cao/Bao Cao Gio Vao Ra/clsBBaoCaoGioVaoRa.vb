Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBBaoCaoGioVaoRa
    Friend WithEvents d As clsDBaoCaoGioVaoRa
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDBaoCaoGioVaoRa
    End Sub

    Public Function LoadDS(ByVal obj As objBaoCaoGioVaoRa) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
