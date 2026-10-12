Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTangLuongThang2
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As objTangLuongThang2) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 13 Then
            strSQL = "SELECT JELL_QUYENTRUYCAP.Ma_DM,KHUA = ISNULL(JELL_QUYENTRUYCAP.KHUA,0),KHUB = ISNULL(JELL_QUYENTRUYCAP.KHUB,0)  "
            strSQL = strSQL + " FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM "
            strSQL = strSQL + " WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.NGUOIDUNG + "' and JELL_DANHMUC.Ma_DM = '" + obj.MA_DM + "'"
        End If
        If obj.ChonBang = 1 Then
            strSQL = "SELECT DISTINCT T_MA FROM IT_BANGLUONGTHANG0109 WHERE CONVERT (INT,LEFT(T_MA,4)) > 2014 ORDER BY T_MA DESC"
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_MA NOT LIKE 'HCM%' AND DV_LOCBB = 0 ORDER BY DV_MA")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 AND DV_MA LIKE 'HCM%' ORDER BY DV_MA")
        End If
        If obj.ChonBang = 6 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 AND DV_MA LIKE 'B%' ORDER BY DV_MA")
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM ST_HOPDONGLAODONGLOG INNER JOIN ST_NHANVIEN ON ST_HOPDONGLAODONGLOG.NV_Ma = ST_NHANVIEN.NV_Ma  WHERE T_MA = '" & obj.NAM & "'"
        End If
        If obj.ChonBang = 7 Then
            strSQL = "SELECT * FROM ST_HOPDONGLAODONGLOG INNER JOIN ST_NHANVIEN ON ST_HOPDONGLAODONGLOG.NV_Ma = ST_NHANVIEN.NV_Ma WHERE T_MA = '" & obj.NAM & "' AND ST_NHANVIEN.DV_MA NOT LIKE 'B%'"
        End If
        If obj.ChonBang = 8 Then
            strSQL = "SELECT * FROM ST_HOPDONGLAODONGLOG INNER JOIN ST_NHANVIEN ON ST_HOPDONGLAODONGLOG.NV_Ma = ST_NHANVIEN.NV_Ma  WHERE T_MA = '" & obj.NAM & "' AND ST_NHANVIEN.DV_MA LIKE 'B%'"
        End If
        If obj.ChonBang = 4 Then
            strSQL = "SELECT * "
            strSQL = strSQL + " FROM IT_BANGLUONGTHANG0109 "
            strSQL = strSQL + " WHERE T_MA = '" & obj.NAM & "'"
            strSQL = strSQL + " AND NV_Ma  IN (SELECT NV_Ma FROM ST_DIENBIENLUONG WHERE DBL_Ngaybatdau =  DATEADD(YY,1, CONVERT(DATE,'" & obj.NAM & "' + '-'+'01',102)))"
        End If
        If obj.ChonBang = 9 Then
            strSQL = "SELECT * "
            strSQL = strSQL + " FROM IT_BANGLUONGTHANG0109 INNER JOIN ST_NHANVIEN ON IT_BANGLUONGTHANG0109.NV_Ma = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE T_MA = '" & obj.NAM & "' AND ST_NHANVIEN.DV_MA NOT LIKE 'B%'"
            strSQL = strSQL + " AND IT_BANGLUONGTHANG0109.NV_Ma  IN (SELECT NV_Ma FROM ST_DIENBIENLUONG WHERE DBL_Ngaybatdau =  DATEADD(YY,1, CONVERT(DATE,'" & obj.NAM & "' + '-'+'01',102)))"
        End If
        If obj.ChonBang = 10 Then
            strSQL = "SELECT * "
            strSQL = strSQL + " FROM IT_BANGLUONGTHANG0109 INNER JOIN ST_NHANVIEN ON IT_BANGLUONGTHANG0109.NV_Ma = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE T_MA = '" & obj.NAM & "' AND ST_NHANVIEN.DV_MA LIKE 'B%'"
            strSQL = strSQL + " AND IT_BANGLUONGTHANG0109.NV_Ma  IN (SELECT NV_Ma FROM ST_DIENBIENLUONG WHERE DBL_Ngaybatdau =  DATEADD(YY,1, CONVERT(DATE,'" & obj.NAM & "' + '-'+'01',102)))"
        End If
        If obj.ChonBang = 17 Then
            strSQL = "SELECT * FROM IT_BANGLUONGTHANG0109 WHERE NV_MA =  '" & obj.NV_MA & "' AND T_MA =  '" & obj.NAM & "'"
        End If
        If obj.ChonBang = 21 Then
            strSQL = " SELECT B_HSLUONG,B_MUCLUONG,B_PCCM ,BANGLUONG = BL_MA,NGACH = LEFT(N_MA,1),BAC = B_TEN FROM IT_BAC WHERE B_MA = '" & obj.BACLUONGMOI & "'"
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

    Public Function UpdateInfo(ByVal obj As objTangLuongThang2) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_BANGLUONGTHANG0109"
            strSQL = strSQL + " SET BACLUONGMOI = '" + obj.BACLUONGMOI + "',"
            strSQL = strSQL + "  HESOMOI =  '" + obj.HESOMOI + "',"
            strSQL = strSQL + "  LUONGCBMOI =  " + obj.LUONGCBMOI + ","
            strSQL = strSQL + " TCCMMOI =  " + obj.TCCMMOI + ","
            strSQL = strSQL + " TCCVMOI =  " + obj.TCCVMOI + ","
            strSQL = strSQL + " TCNNMOI =  " + obj.TCNNMOI + ","
            strSQL = strSQL + " TCUDMAYMOI =  " + obj.TCUDMAYMOI + ","
            strSQL = strSQL + " TCQAQIPMOI =  " + obj.TCQAQIPMOI + ","
            strSQL = strSQL + " TCTHORAPMOI =  " + obj.TCTHORAPMOI + ","
            strSQL = strSQL + " TCHSEMOI =  " + obj.TCHSEMOI + ","
            strSQL = strSQL + " TCCBVPMOI =  " + obj.TCCBVPMOI + ","
            strSQL = strSQL + " TCCBTSMOI =  " + obj.TCCBTSMOI + ","
            strSQL = strSQL + " TCKHACMOI =  " + obj.TCKHACMOI + ","
            strSQL = strSQL + " TCHMPTMOI =  " + obj.TCHMPTMOI + ","
            strSQL = strSQL + " TCHOTRODONGPHUCMOI =  " + obj.TCHOTRODONGPHUCMOI + ","
            strSQL = strSQL + " TCCHAMLOGIADINHMOI =  " + obj.TCCHAMLOGIADINHMOI + ","
            strSQL = strSQL + " TCBBTHANGMOI =  " + obj.TCBBTHANGMOI + ","
            strSQL = strSQL + " TCBBNMOI=  " + obj.TCBBNMOI + ","
            strSQL = strSQL + " TCMOITRUONGMOI =  " + obj.TCMOITRUONGMOI + ","
            strSQL = strSQL + "  TONGLUONGMOI =  " + obj.TONGLUONGMOI + ","

            strSQL = strSQL + " TCHTNGCU =  " + obj.TCHTNGCU + ","
            strSQL = strSQL + " TCHTNGMOI =  " + obj.TCHTNGMOI + ","
            strSQL = strSQL + " TCDQTVCU =  " + obj.TCDQTVCU + ","
            strSQL = strSQL + " TCDQTVMOI =  " + obj.TCDQTVMOI + ","
            strSQL = strSQL + " TCPCCCCU =  " + obj.TCPCCCCU + ","
            strSQL = strSQL + " TCPCCCMOI =  " + obj.TCPCCCMOI + ","

            strSQL = strSQL + " TONGCL = " + obj.TONGCL + ","
            strSQL = strSQL + " NGAYCN = '" + obj.NGAYCN + "',"
            strSQL = strSQL + " NGUOICN = '" + obj.NGUOICN + "'"
            strSQL = strSQL + " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NAM) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE IT_BANGLUONGTHANG0109 "
            strSQL = strSQL + " SET TONGLUONGCU = ISNULL(LUONGCBCU,0)+ISNULL(TCCMCU,0)+ ISNULL(TCCVCU,0)+ ISNULL(TCNNCU,0)+	ISNULL(TCUDMAYCU,0)+ ISNULL(TCQAQIPCU,0)+ISNULL(TCTHORAPCU,0)+ ISNULL(TCHSECU,0)+ ISNULL(TCCBVPCU,0)+ ISNULL(TCCBTSCU,0)+ ISNULL(TCKHACCU,0)+ ISNULL(TCHMPTCU,0)+ ISNULL(TCHOTRODONGPHUCCU,0)+ ISNULL(TCCHAMLOGIADINHCU,0)+ ISNULL(TCBBTHANGCU,0)+ ISNULL(TCBBNCU,0)+ISNULL(TCMOITRUONGCU,0)+ISNULL(TCHTNGCU,0)+ISNULL(TCDQTVCU,0)+ISNULL(TCPCCCCU,0),"
            strSQL = strSQL + " TONGLUONGMOI =  ISNULL(LUONGCBMOI,0)+ISNULL(TCCMMOI,0)+ISNULL(TCCVMOI,0)+ISNULL(TCNNMOI,0)+ISNULL(TCUDMAYMOI,0)+ISNULL(TCQAQIPMOI,0)+ISNULL(TCTHORAPMOI,0)+ISNULL(TCHSEMOI,0)+ISNULL(TCCBVPMOI,0)+ISNULL(TCCBTSMOI,0)+ISNULL(TCKHACMOI,0)+ISNULL(TCHMPTMOI,0)+ISNULL(TCHOTRODONGPHUCMOI,0)+ISNULL(TCCHAMLOGIADINHMOI,0)+ISNULL(TCBBTHANGMOI,0)+ISNULL(TCBBNMOI,0)+ISNULL(TCMOITRUONGMOI,0)+ISNULL(TCHTNGMOI,0)+ISNULL(TCDQTVMOI,0)+ISNULL(TCPCCCMOI,0),"
            strSQL = strSQL + " TONGLUONGBH =  ISNULL(LUONGCBMOI,0)+ISNULL(TCCMMOI,0)+ISNULL(TCCVMOI,0)+ISNULL(TCNNMOI,0)+ISNULL(TCUDMAYMOI,0)+ISNULL(TCQAQIPMOI,0)+ISNULL(TCTHORAPMOI,0)+ISNULL(TCHSEMOI,0)+ISNULL(TCCBVPMOI,0)+ISNULL(TCCBTSMOI,0)+ISNULL(TCMOITRUONGMOI,0)+ISNULL(TCHTNGMOI,0)+ISNULL(TCDQTVMOI,0)+ISNULL(TCPCCCMOI,0),"
            strSQL = strSQL + " TONGPHUCAPBH = ISNULL(TCCMMOI,0)+ISNULL(TCCVMOI,0)+ISNULL(TCNNMOI,0)+ISNULL(TCUDMAYMOI,0)+ISNULL(TCQAQIPMOI,0)+ISNULL(TCTHORAPMOI,0)+ISNULL(TCHSEMOI,0)+ISNULL(TCCBVPMOI,0)+ISNULL(TCCBTSMOI,0)+ISNULL(TCMOITRUONGMOI,0)+ISNULL(TCHTNGMOI,0)+ISNULL(TCDQTVMOI,0)+ISNULL(TCPCCCMOI,0),"
            strSQL = strSQL + "  TONGCL = TONGLUONGMOI - TONGLUONGCU"
            strSQL = strSQL + " WHERE T_MA = '" & Me.QuoteString(obj.NAM) & "'"
            strSQL = strSQL + " AND NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
        End If
        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function DeleteInfo(ByVal obj As objTangLuongThang2) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_BANGLUONGTHANG0109 WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND  T_MA = '" & Me.QuoteString(obj.THANGNAM) & "' "
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objTangLuongThang2) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            '''''''''''''''''
        End If
        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function GoiThuTucLoadDS(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
