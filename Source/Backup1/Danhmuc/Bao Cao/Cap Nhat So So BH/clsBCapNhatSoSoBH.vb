Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBCapNhatSoSoBH
    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New clsDCapNhatSoSoBH
    End Sub

    Public Function LoadDS(ByVal obj As objCapNhatSoSoBH) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As objCapNhatSoSoBH) As Boolean
        Return Me.d.UpdateInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    Friend WithEvents d As clsDCapNhatSoSoBH
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
