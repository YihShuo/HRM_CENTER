Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDocHaiNangNhoc
    ' Methods
    Public Event _errorRaise As _errorRaiseEventHandler

    Public Sub New()
        Me.d = New clsDDocHaiNangNhoc
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objDocHaiNangNhoc) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As objDocHaiNangNhoc) As Boolean
        'Dim table As DataTable = Me.LoadDS(obj)
        'If ((Not table Is Nothing) AndAlso (table.Rows.Count <> 0)) Then
        Return Me.d.UpdateInfo(obj)
        'End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    Friend WithEvents d As clsDDocHaiNangNhoc
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
