Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBTienVuotSanLuong
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDTienVuotSanLuong
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function DeleteInfo(ByVal obj As objTienVuotSanLuong) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    Public Function LoadDS(ByVal obj As objTienVuotSanLuong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Friend WithEvents d As clsDTienVuotSanLuong

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
