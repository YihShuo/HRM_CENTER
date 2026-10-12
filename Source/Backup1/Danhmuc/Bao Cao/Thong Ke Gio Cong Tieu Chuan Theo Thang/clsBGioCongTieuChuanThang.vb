Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBGioCongTieuChuanThang

    Public Sub New()
        Me.d = New clsDGioCongTieuChuanThang
    End Sub

    Public Function LoadDS(ByVal obj As objGioCongTieuChuanThang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTuc_table(ByVal m_sSP_Name As String) As DataTable
        Return d.GoiThuTuc_table(m_sSP_Name)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function DeleteInfo(ByVal obj As objGioCongTieuChuanThang) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objGioCongTieuChuanThang) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function

    Friend WithEvents d As clsDGioCongTieuChuanThang
End Class
