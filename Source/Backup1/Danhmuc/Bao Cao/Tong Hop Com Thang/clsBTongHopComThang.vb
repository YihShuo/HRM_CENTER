Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBTongHopComThang

    Friend WithEvents d As clsDTongHopComThang
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDTongHopComThang
    End Sub

    Public Function LoadDS(ByVal obj As objTongHopComThang) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
