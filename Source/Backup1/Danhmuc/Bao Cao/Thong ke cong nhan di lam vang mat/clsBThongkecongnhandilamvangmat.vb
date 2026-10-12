Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongkecongnhandilamvangmat

    Friend WithEvents d As clsDThongkecongnhandilamvangmat
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDThongkecongnhandilamvangmat
    End Sub
    Public Function LoadDanhSach(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.LoadDanhSach(m_sSP_Name, m_listpar)
    End Function
    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
