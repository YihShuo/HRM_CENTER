Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThaiSan

    Friend WithEvents d As clsDThaiSan
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThaiSan
    End Sub

    Public Function LoadDS(ByVal obj As objThaiSan) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
