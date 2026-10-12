Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDKhoaSoLuong
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objKhoaSoLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then
            If obj.DonVi = "TCT" Then
                strSQL = " SELECT STT = '',HOTEN,"
                strSQL = strSQL + " SOTHE,MASOTHUE,"
                strSQL = strSQL + " SOTAIKHOAN,LUONGCHINH,CMON_CVIEC, "
                strSQL = strSQL + " UUDAI,CHUYENCAN,MOITRUONG,LUONG_TCCMON_CVIEC,CONG_TT,"
                strSQL = strSQL + " LUONGTHANG,HS_15, HS_195,HS_2,HS_3,TIENLAMTHEM,GIOLAMDEM,"
                strSQL = strSQL + " TIENLAMDEM,GIOKHAC,TIENKHAC,GIO_R_LE, TIENNGHI_R_LE,PHEPNAM,"
                strSQL = strSQL + " TIENPHEPNAM,TIEN_NTRO_KHAC_SHP,TIENNUOICON6T,SOPHANCOM, "
                strSQL = strSQL + " BINHBAU,[23PT_BH_PHEP],CONGLUONG,DATAMUNG,THUETHUNHAP,"
                strSQL = strSQL + " TIENBH_YT_XH_TN, TIENCONGDOAN, CONLANHCUOIKY, THUCLANH, KYNHAN"
                strSQL = strSQL + " FROM IT_BANGLUONGMOI WHERE T_MA = '" + obj.NamThang + "' ORDER BY SOTHE"

            Else
                strSQL = " SELECT STT = '',HOTEN,"
                strSQL = strSQL + " SOTHE,MASOTHUE,"
                strSQL = strSQL + " SOTAIKHOAN,LUONGCHINH,CMON_CVIEC, "
                strSQL = strSQL + " UUDAI,CHUYENCAN,MOITRUONG,LUONG_TCCMON_CVIEC,CONG_TT,"
                strSQL = strSQL + " LUONGTHANG,HS_15, HS_195,HS_2,HS_3,TIENLAMTHEM,GIOLAMDEM,"
                strSQL = strSQL + " TIENLAMDEM,GIOKHAC,TIENKHAC,GIO_R_LE, TIENNGHI_R_LE,PHEPNAM,"
                strSQL = strSQL + " TIENPHEPNAM,TIEN_NTRO_KHAC_SHP,TIENNUOICON6T,SOPHANCOM, "
                strSQL = strSQL + " BINHBAU,[23PT_BH_PHEP],CONGLUONG,DATAMUNG,THUETHUNHAP,"
                strSQL = strSQL + " TIENBH_YT_XH_TN, TIENCONGDOAN, CONLANHCUOIKY, THUCLANH, KYNHAN"
                strSQL = strSQL + " FROM IT_BANGLUONGMOI WHERE T_MA = '" + obj.NamThang + "' AND DV_MA = '" + obj.DonVi + "'  ORDER BY SOTHE"

            End If
              End If

        If obj.ChonBang = 8 Then
            strSQL = "SELECT T_MA FROM ST_THANG"
            strSQL = strSQL + " WHERE Right(T_MA, 4) = '" + obj.Nam + "'"
            strSQL = strSQL + " ORDER BY T_MA"
        End If

        If obj.ChonBang = 9 Then
            'strSQL = "SELECT * FROM ST_THANG WHERE T_MA = '" + obj.NamThang + "' ORDER BY T_MA"
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
