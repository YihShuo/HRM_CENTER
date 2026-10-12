Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKeSoNgayNghiOMCOTrongNam

    Friend WithEvents d As clsDThongKeSoNgayNghiOMCOTrongNam
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)


    Public Sub New()
        Me.d = New clsDThongKeSoNgayNghiOMCOTrongNam
    End Sub
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTuc_LoadBang(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataSet
        Return Me.d.GoiThuTuc_LoadBang(m_sSP_Name, m_listpar)
    End Function
    Public Function LoadDS(ByVal obj As objThongKeSoNgayNghiOMCOTrongNam) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
