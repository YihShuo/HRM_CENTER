Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class clsBTKSOLUONGKYHDLD
    Friend WithEvents d As clsDTKSOLUONGKYHDLD
    Public Delegate Sub _erorrRaiseEventHandler(ByVal message As String)

    Public Sub New()
        Me.d = New clsDTKSOLUONGKYHDLD
    End Sub
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Return Me.d.GoiThuTuc(m_sSP_Name, listpar)
    End Function


    Public Event _erorrRaise As _erorrRaiseEventHandler
End Class
