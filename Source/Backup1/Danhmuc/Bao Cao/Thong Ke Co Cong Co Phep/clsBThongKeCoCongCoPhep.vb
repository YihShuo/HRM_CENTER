Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBThongKeCoCongCoPhep
    Friend WithEvents d As clsDThongKeCoCongCoPhep
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThongKeCoCongCoPhep
    End Sub

    Public Function LoadDS(ByVal obj As objThongKeCoCongCoPhep) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function ThongKe(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Return Me.d.ThongKe(m_sSP_Name, SqlParam)
    End Function
    Public Function ThongKe(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.ThongKe(m_sSP_Name)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
