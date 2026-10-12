Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsBTraCuuNhanhNV
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDTraCuuNhanhNV
    End Sub
    Public Function LoadDS(ByVal obj As objTraCuuNhanhNV) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    ' Fields
    Friend WithEvents d As clsDTraCuuNhanhNV

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
