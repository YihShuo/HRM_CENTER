Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKeDanhSachCanBo
    Friend WithEvents d As clsDThongKeDanhSachCanBo
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThongKeDanhSachCanBo
    End Sub

    Public Function LoadDS(ByVal obj As objThongKeDanhSachCanBo) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
