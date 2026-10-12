Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDSoNguoiTrongCongTy
    Inherits DALSQL
    ' Methods
 
    Public Function LoadDS(ByVal obj As objSoNguoiTrongCongTy) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (obj.ChonBang = 1) Then
            strSQL = "select * from st_nhanvien where nv_ma not in (select nv_ma from st_nhanvienthoiviec)"
        End If

        If (obj.ChonBang = 2) Then
            strSQL = "select * from st_nhanvien where nv_ma not in (select nv_ma from st_nhanvienthoiviec) and dv_ma like 'NV%'"
        End If

        If (obj.ChonBang = 3) Then
            strSQL = "SELECT * FROM ST_NHANVIEN INNER JOIN ST_DONVI " & _
            "ON (ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA) " & _
            "WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) " & _
            "AND ST_DONVI.N_MA IN ('CG') "
        End If

        If (obj.ChonBang = 4) Then
            strSQL = "SELECT * FROM ST_NHANVIEN INNER JOIN ST_DONVI " & _
        "ON (ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA) " & _
        "WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) " & _
        "AND ST_DONVI.N_MA IN ('BGD') "
        End If

        If (obj.ChonBang = 5) Then
            strSQL = "SELECT * FROM ST_NHANVIEN INNER JOIN ST_DONVI " & _
        "ON (ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA) " & _
        "WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) " & _
        "AND ST_DONVI.X_MA_ IN ('DT') " & _
        "and st_donvi.n_ma not in ('BGD','CG','CNM') " & _
        "and st_donvi.dv_ma not like 'NV%'"
        End If

        If (obj.ChonBang = 6) Then
            strSQL = "SELECT * FROM ST_NHANVIEN INNER JOIN ST_DONVI " & _
        "ON (ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA) " & _
        "WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) " & _
        "AND ST_DONVI.X_MA_ IN ('KB') " & _
        "and st_donvi.n_ma not in ('BGD','CG','CNM') " & _
        "and st_donvi.dv_ma not like 'NV%'"
        End If

        If (obj.ChonBang = 7) Then
            strSQL = "SELECT * FROM ST_NHANVIEN INNER JOIN ST_DONVI " & _
        "ON (ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA) " & _
        "WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) " & _
        "AND ST_DONVI.N_MA IN ('CNM') "
        End If

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

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

   
End Class
