Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKeHD
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objThongKeHD) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Thuc thi cau truy van
        Try
            table = Me.getTableSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            table = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return table
    End Function
End Class
