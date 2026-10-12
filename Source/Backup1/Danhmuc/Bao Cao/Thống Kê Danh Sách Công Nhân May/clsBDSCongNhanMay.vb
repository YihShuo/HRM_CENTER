Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDSCongNhanMay
    Friend WithEvents d As clsDDSCongNhanMay
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDDSCongNhanMay
    End Sub

    Public Function LoadDS(ByVal obj As objDSCongNhanMay) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
