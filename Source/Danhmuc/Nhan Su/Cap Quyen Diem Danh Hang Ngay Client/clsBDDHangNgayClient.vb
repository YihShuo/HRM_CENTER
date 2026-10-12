Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDDHangNgayClient
    '' Events
    Public Event _errorRaise As _errorRaiseEventHandler
    '' Methods
    Public Sub New()
        Me.d = New clsDDDHangNgayClient
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function DeleteInfo(ByVal obj As objDDHangNgayClient) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objDDHangNgayClient) As Boolean

        Return Me.d.InsertInfo(obj)

        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(ChrW(272) & ChrW(227) & " t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng th" & ChrW(234) & "m " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function

    Public Function LoadDS(ByVal obj As objDDHangNgayClient) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    '' Fields
    Friend WithEvents d As clsDDDHangNgayClient
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
