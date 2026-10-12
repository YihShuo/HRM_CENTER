Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBDanhSachCNNghiKPTheoNam
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDDanhSachCNNghiKPTheoNam
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objDanhSachCNNghiKPTheoNam) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function ThongKe(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Return Me.d.ThongKe(m_sSP_Name, SqlParam)
    End Function

    ' Fields
    Friend WithEvents d As clsDDanhSachCNNghiKPTheoNam
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
