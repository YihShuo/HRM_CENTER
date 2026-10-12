Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDTKCongViecHDLD
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objTKCongViecHDLD) As DataTable
        Dim table As DataTable
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT ST_DONVI.X_MA_ ")
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_CONGVIECHDLD ON ST_NHANVIEN.NV_MA = IT_CONGVIECHDLD.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " GROUP BY ST_DONVI.X_MA_ "
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT ST_NHANVIEN.DV_MA ")
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_CONGVIECHDLD ON ST_NHANVIEN.NV_MA = IT_CONGVIECHDLD.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.DV_MA "
        End If

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
