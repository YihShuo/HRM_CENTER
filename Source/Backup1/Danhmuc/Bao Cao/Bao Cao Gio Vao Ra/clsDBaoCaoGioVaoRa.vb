Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDBaoCaoGioVaoRa
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objBaoCaoGioVaoRa) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        Dim sChuoiKhongQTVao As String = ""
        Dim sChuoiKhongQTRa As String = ""

        If obj.ChonBang = 1 Then

            If obj.XemDonviDD = 1 Then
                strSQL = ("SELECT ST_NHANVIEN.DV_MA_ AS DONVI ")
            Else
                strSQL = ("SELECT ST_NHANVIEN.DV_MA AS DONVI ")
            End If
            strSQL = strSQL + ",ST_DONVI.DV_TEN "
            strSQL = strSQL + " ,X_MA_ = ST_DONVI.X_MA_ "
            strSQL = strSQL + ",KHU = CASE WHEN X_MA_ LIKE N'B%' THEN N'B' ELSE N'A' END "
            strSQL = strSQL + ",NV_MA = MANV"
            strSQL = strSQL + ",NV_TEN"
            strSQL = strSQL + ",NGAY = CONVERT(CHAR(10),CONVERT(DATETIME," + obj.NGAY + "),105) "
            strSQL = strSQL + ",GIO_VAO = CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) "
            strSQL = strSQL + ",GIO_RA =  CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) "
            strSQL = strSQL + ",MACA = loaica_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",giovaotay = CONVERT(CHAR(8),giovaotay_" + obj.D_Ngay.ToString() + ",108) "
            strSQL = strSQL + ",gioratay = CONVERT(CHAR(8),gioratay_" + obj.D_Ngay.ToString() + " ,108)"
            strSQL = strSQL + ",GIOBINHTHUONG =giobinhthuong_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",GIOTANGCA = giotangca_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",LAMDEM = lamdem_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",HESONGAYCONG = hesongaycong_" + obj.D_Ngay.ToString() + "  "
            strSQL = strSQL + ",MANP = MaNP_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",ditre= ditre_" + obj.D_Ngay.ToString() + " "
            strSQL = strSQL + ",quenquetthe = quenquetthe_" + obj.D_Ngay.ToString() + ""
            strSQL = strSQL + ",IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC "
            strSQL = strSQL + ",IT_TONGGIOCONG.CHENHLECH "
            ''============= thêm đk chọn trên lưới =====================''
            strSQL = strSQL + ",COQTTHEVAO = CASE WHEN  giovao_" + obj.D_Ngay.ToString() + " IS NOT NULL THEN 1 ELSE 0 END "
            strSQL = strSQL + ",COQTHERA = CASE WHEN  giora_" + obj.D_Ngay.ToString() + " IS NOT NULL THEN 1 ELSE 0 END "
            strSQL = strSQL + ",COQTVAOHOACRA = CASE WHEN (CASE WHEN  giovao_" + obj.D_Ngay.ToString() + " IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN  giora_" + obj.D_Ngay.ToString() + " IS NOT NULL THEN 1 ELSE 0 END ) > 0 then 1 else 0 end "
            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN  ON ST_VAORA_MACHINE.MANV= ST_NHANVIEN.NV_MA"

            ''========= láy hết =============''
            If obj.KHONGQTVAO = 0 And obj.KHONGQTRA = 0 Then
                strSQL = strSQL + " "
            End If

            ''========= không quẹt thẻ vào =============''
            If obj.KHONGQTVAO = 1 And obj.KHONGQTRA = 0 Then
                strSQL = strSQL + " AND (CASE WHEN  giovao_" + obj.D_Ngay.ToString() + " IS NULL THEN 1 ELSE 0 END) > 0 "
            End If

            ''========= không quẹt thẻ ra =============''
            If obj.KHONGQTVAO = 0 And obj.KHONGQTRA = 1 Then
                strSQL = strSQL + " AND (CASE WHEN  giora_" + obj.D_Ngay.ToString() + " IS NULL THEN 1 ELSE 0 END) > 0 "
            End If

            ''========= ko quet the vao hoac ra =============''
            If obj.KHONGQTVAO = 1 And obj.KHONGQTRA = 1 Then
                strSQL = strSQL + " AND (CASE WHEN giovao_" + obj.D_Ngay.ToString() + " IS NULL THEN 1 ELSE 0 END + CASE WHEN  giora_" + obj.D_Ngay.ToString() + " IS NULL THEN 1 ELSE 0 END ) > 0 "
            End If

            If obj.XemDonviDD = 1 Then
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA_ "
            Else
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA "
            End If

            strSQL = strSQL + " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL = strSQL + " AND DV_TV <> 1 AND ISNULL(DV_LocBB,0) = 0 "
            strSQL = strSQL + " LEFT JOIN IT_TONGGIOCONG ON ST_VAORA_MACHINE.MaNV =IT_TONGGIOCONG.NV_MA "
            strSQL = strSQL + " AND ST_VAORA_MACHINE.Nam  =IT_TONGGIOCONG.Nam "
            strSQL = strSQL + " AND ST_NHANVIEN.NV_NGAYVAO <=  " + obj.NGAY + ""
            strSQL = strSQL + " WHERE ST_VAORA_MACHINE.THANG= " + Me.QuoteString(obj.M_Ngay) + "  AND ST_VAORA_MACHINE.Nam = " + Me.QuoteString(obj.Y_Ngay) + ""
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1)"
            Select Case obj.ChonXuong
                Case "TCT"
                Case "KHUA"
                    strSQL = strSQL + " AND ST_DONVI.KHU = 'A'"
                Case "KHUB"
                    strSQL = strSQL + " AND ST_DONVI.KHU = 'B'"
                Case "KHUDVC"
                    strSQL = strSQL + " AND ST_DONVI.KHU = 'DVC'"
                Case Else
                    strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
            End Select
            strSQL = strSQL + " AND NOT exists (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_VAORA_MACHINE.MaNV )"
            strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_ ,ST_DONVI.DV_MA ,loaica_" + obj.D_Ngay.ToString() + " "
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")

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
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
