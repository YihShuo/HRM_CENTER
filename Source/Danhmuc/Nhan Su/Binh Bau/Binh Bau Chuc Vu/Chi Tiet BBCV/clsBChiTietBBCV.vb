Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBChiTietBBCV
    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New clsDChiTietBBCV
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function LoadDS(ByVal obj As objChiTietBBCV) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function InsertInfo(ByVal obj As objChiTietBBCV) As Boolean
        'Dim table As DataTable = Me.LoadDS(obj)
        Return Me.d.InsertInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã nhân viên, Không thêm được.")
        End If
        Return False
    End Function
    Public Function DeleteInfo(ByVal obj As objChiTietBBCV) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As objChiTietBBCV) As Boolean
        Return Me.d.UpdateInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    ' Fields
    Friend WithEvents d As clsDChiTietBBCV
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
