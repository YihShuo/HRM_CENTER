Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBDienBienLuong
    Friend WithEvents d As clsDDienBienLuong
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDDienBienLuong
    End Sub

    Public Function LoadDS(ByVal obj As objDienBienLuong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTucLoadDS(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTucLoadDS(m_sSP_Name, m_listpar)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
