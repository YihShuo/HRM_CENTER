Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient

Public Class clsDTKSOLUONGKYHDLD
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
    End Function

End Class
