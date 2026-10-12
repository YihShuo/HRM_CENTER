Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient
Public Class clsBThongKeDanhSachCanBoThang
    Friend WithEvents d As clsDThongKeDanhSachCanBoThang
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)
    Public Sub New()
        Me.d = New clsDThongKeDanhSachCanBoThang
    End Sub
    Public Function LoadDS(ByVal obj As objThongKeDanhSachCanBoThang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Return Me.d.GoiThuTuc(m_sSP_Name, listpar)
    End Function

    Public Function ThongKe(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Return Me.d.ThongKe(m_sSP_Name, SqlParam)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
