Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDDSCongNhanMay
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objDSCongNhanMay) As DataTable
        Dim table As DataTable
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("  SELECT * FROM (SELECT")
            strSQL = strSQL + " ST_DONVI.X_MA_"
            'strSQL = strSQL + " A = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 120000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + " B = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 100000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + " C = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 80000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + " D = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 60000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + " E = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 40000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + " KHONGBAC = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapCV = 30000 AND ST_HOPDONGLAODONG.HD_TrocapUD = 0 THEN 1 ELSE 0 END)"

            strSQL = strSQL + " FROM ST_HOPDONGLAODONG INNER JOIN ST_NHANVIEN ON ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE ST_HOPDONGLAODONG.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('BGD')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE '%CGVP'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('A1MDT','A2MDT')"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.HD_CongviecDH = 1"
            strSQL = strSQL + " AND (ST_HOPDONGLAODONG.HD_TrocapCV > 0 OR ST_HOPDONGLAODONG.HD_TrocapUD >0)"
            strSQL = strSQL + " AND NOT ST_HOPDONGLAODONG.HD_TrocapCV > 30000  AND ST_DONVI.DV_TV <> 1"
            strSQL = strSQL + " GROUP BY"
            strSQL = strSQL + " ST_DONVI.X_MA_ ) AS V UNION  SELECT 'KHUA' AS X_MA_  UNION SELECT 'KHUB' AS X_MA_ "
        End If

        If obj.ChonBang = 2 Then
            strSQL = (" SELECT ")
            strSQL = strSQL + " ST_DONVI.DV_MA"
            'strSQL = strSQL + "A = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 120000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + "B = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 100000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + "C = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 80000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + "D = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 60000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + "E = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapUD = 40000 THEN 1 ELSE 0 END),"
            'strSQL = strSQL + "KHONGBAC = SUM(CASE WHEN ST_HOPDONGLAODONG.HD_TrocapCV = 30000 AND ST_HOPDONGLAODONG.HD_TrocapUD = 0 THEN 1 ELSE 0 END)"

            strSQL = strSQL + " FROM ST_HOPDONGLAODONG INNER JOIN ST_NHANVIEN ON ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE ST_HOPDONGLAODONG.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('BGD')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE '%CGVP'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('A1MDT','A2MDT')"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.HD_CongviecDH = 1"
            strSQL = strSQL + " AND (ST_HOPDONGLAODONG.HD_TrocapCV > 0 OR ST_HOPDONGLAODONG.HD_TrocapUD >0)"
            strSQL = strSQL + " AND NOT ST_HOPDONGLAODONG.HD_TrocapCV > 30000  AND ST_DONVI.DV_TV <> 1"
            strSQL = strSQL + " GROUP BY"
            strSQL = strSQL + " ST_DONVI.DV_MA"
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
