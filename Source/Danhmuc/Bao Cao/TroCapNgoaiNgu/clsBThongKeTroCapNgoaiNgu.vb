Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKeTroCapNgoaiNgu
    Friend WithEvents d As clsDThongKeTroCapNgoaiNgu
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThongKeTroCapNgoaiNgu
    End Sub

    Public Function TinhsolieutrocapNgoaiNgu(ByVal obj As objThongKeTroCapNgoaiNgu) As Boolean
        Return Me.d.TinhsolieutrocapNgoaiNgu(obj)
    End Function
    Public Function LoadKhongThamso(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.LoadKhongThamso(m_sSP_Name)
    End Function
    Public Function Load(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.Load(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.GoiThuTucKhongThamSo(m_sSP_Name)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
