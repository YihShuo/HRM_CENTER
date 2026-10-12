Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBTKCongViecHDLD
    Friend WithEvents d As clsDTKCongViecHDLD
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDTKCongViecHDLD
    End Sub

    Public Function LoadDS(ByVal obj As objTKCongViecHDLD) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
