Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThoiViecKhongThamGiaBHTN
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDThoiViecKhongThamGiaBHTN
    End Sub
    Public Function LoadDS(ByVal obj As objThoiViecKhongThamGiaBHTN) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    ' Fields
    Friend WithEvents d As clsDThoiViecKhongThamGiaBHTN

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
