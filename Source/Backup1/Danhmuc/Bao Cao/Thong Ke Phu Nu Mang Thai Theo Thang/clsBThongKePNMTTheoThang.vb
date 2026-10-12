Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKePNMTTheoThang
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDThongKePNMTTheoThang
    End Sub
    Public Function LoadDS(ByVal obj As objThongKePNMTTheoThang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function LoadDanhmucThang(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.LoadDanhmucThang(m_sSP_Name)
    End Function
    Public Function GoiThuTucThongKeKThamSo(ByVal m_sSP_Name As String) As DataTable
        Return Me.d.GoiThuTucThongKeKThamSo(m_sSP_Name)
    End Function
    Public Function GoiThuTucTinhToan(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTucTinhToan(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucThongKe(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.GoiThuTucThongKe(m_sSP_Name, m_listpar)
    End Function
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    ' Fields
    Friend WithEvents d As clsDThongKePNMTTheoThang

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
