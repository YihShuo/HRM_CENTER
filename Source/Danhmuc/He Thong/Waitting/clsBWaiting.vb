Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBWaiting
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDWaiting
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objWaiting) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function


    '' Fields
    Friend WithEvents d As clsDWaiting

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
