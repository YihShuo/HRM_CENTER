Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBPhepNam
    Friend WithEvents d As clsDPhepNam
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDPhepNam
    End Sub

    Public Function LoadDS(ByVal obj As objPhepNam) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function LoadTruyVan(ByVal strSQL As String) As DataTable
        Return Me.d.LoadTruyVan(strSQL)
    End Function
    Public Function ThuTucThongKe(ByVal m_sSP_Name As String, ByVal nam As String, ByVal donvitrongxuong As String) As DataTable
        Return Me.d.ThuTucThongKe(m_sSP_Name, nam, donvitrongxuong)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
