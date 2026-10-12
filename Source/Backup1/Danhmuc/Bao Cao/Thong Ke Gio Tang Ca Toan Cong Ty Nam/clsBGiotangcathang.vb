Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBGiotangcathang
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDGiotangcathang
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function LoadDS(ByVal obj As objGiotangcathang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function LoadTruyVanThongKeGioCong(ByVal obj As objGiotangcathang) As DataTable
        Return Me.d.LoadTruyVanThongKeGioCong(obj)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String)
        Return Me.d.GoiThuTucKhongThamSo(m_sSP_Name)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.ThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucThongKeGioCong(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.ThuTucThongKeGioCong(m_sSP_Name, m_listpar)
    End Function
    Public Function LoadDanhMucDonvi_NhomXuong(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function ThongKeGioCong(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Return Me.d.ThongKeGioCong(m_sSP_Name, SqlParam)
    End Function
    '' Fields
    Friend WithEvents d As clsDGiotangcathang
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class

