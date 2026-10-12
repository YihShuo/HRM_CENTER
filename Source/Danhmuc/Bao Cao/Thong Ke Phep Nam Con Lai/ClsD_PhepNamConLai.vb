Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsD_PhepNamConLai
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As ObjPhepNamConLai) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 5 Then
            strSQL = ("SELECT  ST_PHEPNAM.PN_NAM AS NAM,")
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MANV,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TENNV,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_Songaynamtruoc,0) AS NAMTRUOC,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_Songaynamnay,0)AS NAMNAY,"
            strSQL = strSQL + "ISNULL(PHEPNAM_CONLAI.PN_DANGHI,0)AS DANGHI,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_NangnhocDH,0)AS DHNN,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_PhepTren5Nam,0)AS TREN5NAM,"
            strSQL = strSQL + "	'CONLAI' = ISNULL(ST_PHEPNAM.PN_Songaynamtruoc,0)+ISNULL(ST_PHEPNAM.PN_Songaynamnay,0)+ISNULL(ST_PHEPNAM.PN_PhepTren5Nam,0)+ISNULL(ST_PHEPNAM.PN_NangnhocDH,0)-ISNULL(PHEPNAM_CONLAI.PN_DANGHI,0) "
            strSQL = strSQL + "FROM ST_NHANVIEN INNER JOIN  ST_PHEPNAM ON ST_NHANVIEN.NV_MA = ST_PHEPNAM.NV_MA	INNER JOIN PHEPNAM_CONLAI ON ST_PHEPNAM.NV_MA = PHEPNAM_CONLAI.NV_MA AND ST_PHEPNAM.PN_NAM = PHEPNAM_CONLAI.NAM INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND  ST_DONVI.X_MA_ NOT IN ('BGD','CG','KB','DT')"
            strSQL = strSQL + "  AND ST_PHEPNAM.PN_NAM = '2010' "
        End If

        If obj.ChonBang = 6 Then
            strSQL = ("SELECT  ST_PHEPNAM.PN_NAM AS NAM,")
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MANV,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TENNV,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_Songaynamtruoc,0) AS NAMTRUOC,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_Songaynamnay,0)AS NAMNAY,"
            strSQL = strSQL + "ISNULL(PHEPNAM_CONLAI.PN_DANGHI,0)AS DANGHI,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_NangnhocDH,0)AS DHNN,"
            strSQL = strSQL + "ISNULL(ST_PHEPNAM.PN_PhepTren5Nam,0)AS TREN5NAM,"
            strSQL = strSQL + "	'CONLAI' = ISNULL(ST_PHEPNAM.PN_Songaynamtruoc,0)+ISNULL(ST_PHEPNAM.PN_Songaynamnay,0)+ISNULL(ST_PHEPNAM.PN_PhepTren5Nam,0)+ISNULL(ST_PHEPNAM.PN_NangnhocDH,0)-ISNULL(PHEPNAM_CONLAI.PN_DANGHI,0) "
            strSQL = strSQL + "FROM ST_NHANVIEN INNER JOIN  ST_PHEPNAM ON ST_NHANVIEN.NV_MA = ST_PHEPNAM.NV_MA	INNER JOIN PHEPNAM_CONLAI ON ST_PHEPNAM.NV_MA = PHEPNAM_CONLAI.NV_MA AND ST_PHEPNAM.PN_NAM = PHEPNAM_CONLAI.NAM INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND  ST_DONVI.X_MA_ NOT IN ('BGD','CG','KB','DT')"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If

        If obj.ChonBang = 7 Then
            strSQL = (" SELECT DISTINCT PN_NAM ")
            strSQL = strSQL + "FROM ST_PHEPNAM"
        End If

        If obj.ChonBang = 8 Then
            strSQL = (" SELECT DISTINCT X_MA_ ")
            strSQL = strSQL + "FROM ST_DONVI WHERE X_MA_ NOT IN ('BGD','CG','KB','DT')"
        End If

        If obj.ChonBang = 9 Then
            strSQL = (" SELECT DISTINCT DV_MA ")
            strSQL = strSQL + "FROM ST_DONVI WHERE  X_MA_ = '" + obj.XUONG + "'"

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
