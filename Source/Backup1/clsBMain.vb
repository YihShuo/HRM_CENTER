Imports System
Imports System.Data
Imports System.Runtime.CompilerServices


Public Class clsBMain
    '' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDMain
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objMain) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    '' Fields
    Friend WithEvents d As clsDMain

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
