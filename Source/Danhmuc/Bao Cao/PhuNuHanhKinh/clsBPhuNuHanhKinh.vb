Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBPhuNuHanhKinh
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDPhuNuHanhKinh
    End Sub
    Public Function LoadDS(ByVal obj As ObjPhuNuHanhKinh) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function LoadDanhmucThang(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.LoadDanhmucThang(m_sSP_Name)
    End Function
    Public Function LoadDSNghiHanhKinh(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.LoadDSNghiHanhKinh(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucTinhToan(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTucTinhToan(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.d.GoiThuTucKhongThamSo(m_sSP_Name)
    End Function
    Public Function CapNhatSoGioNghiHanhKinh(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.CapNhatSoGioNghiHanhKinh(m_sSP_Name, m_listpar)
    End Function
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function InsertInfo(ByVal obj As ObjPhuNuHanhKinh) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function
    Public Function DeleteInfo(ByVal obj As ObjPhuNuHanhKinh) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    ' Fields
    Friend WithEvents d As clsDPhuNuHanhKinh

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
