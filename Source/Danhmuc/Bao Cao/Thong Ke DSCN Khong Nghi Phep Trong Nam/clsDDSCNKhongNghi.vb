Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDDSCNKhongNghi
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objDSCNKhongNghi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = "select "
            strSQL += "st_nhanvien.dv_ma, "
            strSQL += "st_nhanvien.nv_ten, "
            strSQL += "st_nhanvien.nv_ma, "
            strSQL += "st_nhanvien.nv_ngayvao, "
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) as tongsogionghi "

            strSQL += "from st_gioquetthe inner join st_nhanvien on st_gioquetthe.nv_ma = st_nhanvien.nv_ma "
            strSQL += "where st_gioquetthe.np_ma not in ('P','NO') "
            strSQL += "and st_nhanvien.nv_ma not in (select nv_ma from st_nhanvienthoiviec) "
            strSQL += "and year(st_gioquetthe.qt_ngay)=" + obj.Nam + " "
            strSQL += "group by "
            strSQL += "st_nhanvien.dv_ma, "
            strSQL += "st_nhanvien.nv_ten, "
            strSQL += "st_nhanvien.nv_ma, "
            strSQL += "st_nhanvien.nv_ngayvao "
            strSQL += "having "
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) <= 0"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "select "
            strSQL += "st_nhanvien.dv_ma,"
            strSQL += "st_nhanvien.nv_ten,"
            strSQL += "st_nhanvien.nv_ma,"
            strSQL += "st_nhanvien.nv_ngayvao,"
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) as tongsogionghi "

            strSQL += "from st_gioquetthe inner join st_nhanvien on st_gioquetthe.nv_ma = st_nhanvien.nv_ma "
            strSQL += "where st_gioquetthe.np_ma not in ('P','NO')"
            strSQL += "and st_nhanvien.nv_ma not in (select nv_ma from st_nhanvienthoiviec)"
            strSQL += "and year(st_gioquetthe.qt_ngay)=" + obj.Nam + " "
            strSQL += "group by "
            strSQL += "st_nhanvien.dv_ma,"
            strSQL += "st_nhanvien.nv_ten,"
            strSQL += "st_nhanvien.nv_ma,"
            strSQL += "st_nhanvien.nv_ngayvao "
            strSQL += "having "
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) < 8 "
            strSQL += "and sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) <> 0"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "select "
            strSQL += "st_nhanvien.dv_ma, "
            strSQL += "st_nhanvien.nv_ten, "
            strSQL += "st_nhanvien.nv_ma, "
            strSQL += "st_nhanvien.nv_ngayvao, "
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) as tongsogionghi "

            strSQL += "from st_gioquetthe inner join st_nhanvien on st_gioquetthe.nv_ma = st_nhanvien.nv_ma "
            strSQL += "where st_gioquetthe.np_ma not in ('P','NO') "
            strSQL += "and st_nhanvien.nv_ma not in (select nv_ma from st_nhanvienthoiviec) "
            strSQL += "and datediff(M,st_nhanvien.nv_ngayvao,getdate()) > 6 "
            strSQL += "and datediff(M,st_nhanvien.nv_ngayvao,getdate()) < 12 "
            strSQL += "and year(st_gioquetthe.qt_ngay)=" + obj.Nam + " "

            strSQL += " group by "
            strSQL += "st_nhanvien.dv_ma, "
            strSQL += "st_nhanvien.nv_ten, "
            strSQL += "st_nhanvien.nv_ma, "
            strSQL += "st_nhanvien.nv_ngayvao "
            strSQL += "having "
            strSQL += "sum(case when isnull(st_gioquetthe.cc_sogionghi,0) > 0 then isnull(st_gioquetthe.cc_sogionghi,0) else 0 end) <= 0 "
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

