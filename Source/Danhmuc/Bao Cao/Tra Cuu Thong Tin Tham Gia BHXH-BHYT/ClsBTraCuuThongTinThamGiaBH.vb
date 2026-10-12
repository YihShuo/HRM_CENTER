Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsBTraCuuThongTinThamGiaBH
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDTraCuuThongTinThamGiaBH
    End Sub
    Public Function LoadDS(ByVal obj As ObjTraCuuThongTinThamGiaBH) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    ' Fields
    Friend WithEvents d As clsDTraCuuThongTinThamGiaBH

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
