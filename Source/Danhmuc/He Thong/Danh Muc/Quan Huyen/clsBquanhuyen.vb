Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBquanhuyen
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDquanhuyen
    End Sub

    Public Function CapNhat(ByVal obj As objquanhuyen, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo(obj)
        End If
        Return Me.UpdateInfo(obj)
    End Function

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function InsertInfo(ByVal obj As objquanhuyen) As Boolean
        If (Me.d.InsertInfo(obj)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function LoadDS(ByVal obj As objquanhuyen) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function UpdateInfo(ByVal obj As objquanhuyen) As Boolean
        If (Me.d.UpdateInfo(obj)) Then
            Return True
        Else
            Return False
        End If
    End Function


    ' Fields
    Friend WithEvents d As clsDquanhuyen

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
