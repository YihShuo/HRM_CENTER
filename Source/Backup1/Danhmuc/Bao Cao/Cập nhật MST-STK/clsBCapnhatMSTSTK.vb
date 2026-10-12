Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBCapnhatMSTSTK
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDCapnhatMSTSTK
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objCapnhatMSTSTK) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As objCapnhatMSTSTK) As Boolean
        Return Me.d.UpdateInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function


    Public Function UpdateThaoTac(ByVal obj As objCapnhatMSTSTK) As Boolean
        Return Me.d.UpdateThaoTac(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function




    Public Function InsertInfo(ByVal obj As objCapnhatMSTSTK) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        'If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
        Return Me.d.InsertInfo(obj)
        'End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã nhân viên, Không thêm được.")
        End If
        Return False
    End Function
    Friend WithEvents d As clsDCapnhatMSTSTK
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
