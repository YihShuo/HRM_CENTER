Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKeNghiPhep

    Friend WithEvents d As clsDThongKeNghiPhep
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThongKeNghiPhep
    End Sub

    Public Function LoadDS(ByVal obj As objThongKeNghiPhep) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
