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
                    strSQL = strSQL + " AND ST_DONVI.DV_MA LIKE 'HCM%'"
                Case Else
                    strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
            End Select
            strSQL = strSQL + " AND NOT exists (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_VAORA_MACHINE.MaNV )"
            strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_ ,ST_DONVI.DV_MA ,loaica_" + obj.D_Ngay.ToString() + " "
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")
        End If

        ' =========================================================================
        ' TRUY VẤN BÁO CÁO GIỜ QUẸT THẺ THEO THÁNG (GỘP CÔNG NGOÀI & TẤT CẢ GIỜ MF)
        ' =========================================================================
        If obj.ChonBang = 2 Then
            ' Sửa lỗi BC30616: Xóa chữ 'Dim' để tái sử dụng biến strSQL đã khai báo phía trên
            strSQL = ""

            ' 1. Khởi tạo CTE MF_Filtered (Sửa obj.Nam -> obj.Y_Ngay, obj.Thang -> obj.M_Ngay)
            strSQL &= "WITH MF_Filtered AS ( "
            strSQL &= "    SELECT "
            strSQL &= "        userno, "
            strSQL &= "        CONVERT(DATE, DATEADD(HOUR, -3, mattime)) AS QT_NGAY_LOGIC, "
            strSQL &= "        CONVERT(CHAR(8), mattime, 108) AS GIO_QUET, "
            strSQL &= "        mattime "
            strSQL &= "    FROM MF_RECORD WITH (NOLOCK) "
            strSQL &= "    WHERE mattime >= CAST(" & obj.Y_Ngay & " AS VARCHAR(4)) + '-' + RIGHT('0' + CAST(" & obj.M_Ngay & " AS VARCHAR(2)), 2) + '-01 03:00:00' "
            strSQL &= "      AND mattime < DATEADD(MONTH, 1, CAST(" & obj.Y_Ngay & " AS VARCHAR(4)) + '-' + RIGHT('0' + CAST(" & obj.M_Ngay & " AS VARCHAR(2)), 2) + '-01 03:00:00') "
            strSQL &= "), "

            ' 2. Khởi tạo CTE MF_Aggregated
            strSQL &= "MF_Aggregated AS ( "
            strSQL &= "    SELECT "
            strSQL &= "        userno, "
            strSQL &= "        QT_NGAY_LOGIC, "
            strSQL &= "        STRING_AGG(GIO_QUET, ' || ') WITHIN GROUP (ORDER BY mattime) AS MF_TATCAGIO "
            strSQL &= "    FROM MF_Filtered "
            strSQL &= "    GROUP BY userno, QT_NGAY_LOGIC "
            strSQL &= ") "

            ' 3. CÂU TRUY VẤN CHÍNH
            strSQL &= "SELECT "
            If obj.XemDonviDD = 1 Then
                strSQL &= "    ST_NHANVIEN.DV_MA_ AS DONVI, "
            Else
                strSQL &= "    ST_NHANVIEN.DV_MA AS DONVI, "
            End If

            strSQL &= "    ST_DONVI.DV_TEN, "
            strSQL &= "    ST_VAORA_MACHINE.MANV AS NV_MA, "
            strSQL &= "    ST_NHANVIEN.NV_TEN, "
            strSQL &= "    CONVERT(CHAR(10), NDate.NgayFull, 105) AS NGAY, "
            strSQL &= "    CONVERT(CHAR(8), D.giovao, 108) AS GIO_VAO, "
            strSQL &= "    CONVERT(CHAR(8), D.giora, 108) AS GIO_RA, "
            strSQL &= "    D.loaica AS MACA, "
            strSQL &= "    CONVERT(CHAR(8), D.giovaotay, 108) AS giovaotay, "
            strSQL &= "    CONVERT(CHAR(8), D.gioratay, 108) AS gioratay, "
            strSQL &= "    D.giobinhthuong AS GIOBINHTHUONG, "
            strSQL &= "    D.giotangca AS GIOTANGCA, "
            strSQL &= "    D.lamdem AS LAMDEM, "
            strSQL &= "    D.hesongaycong AS HESONGAYCONG, "
            strSQL &= "    D.MaNP AS MANP, "
            strSQL &= "    D.ditre AS ditre, "
            strSQL &= "    D.quenquetthe AS quenquetthe, "

            ' Tổng tăng ca cả tháng
            strSQL &= "    SUM(ISNULL(D.giotangca, 0) + ISNULL(QT_CN.CC_GIOTANGCA, 0)) "
            strSQL &= "        OVER (PARTITION BY ST_VAORA_MACHINE.MANV) AS TONGGIOTC, "

            strSQL &= "    CONVERT(CHAR(8), CN.QT_GIOVAO, 108) AS GIOVAO_CN, "
            strSQL &= "    CONVERT(CHAR(8), CN.QT_GIORA, 108) AS GIORA_CN, "
            strSQL &= "    CONVERT(CHAR(8), QT_CN.QT_GIOVAOTAY, 108) AS VAOTAY_CN, "
            strSQL &= "    CONVERT(CHAR(8), QT_CN.QT_GIORATAY, 108) AS RATAY_CN, "
            strSQL &= "    ISNULL(MF.MF_TATCAGIO, '') AS MF_TATCAGIO "

            ' FROM & JOIN
            strSQL &= "FROM ST_VAORA_MACHINE "
            strSQL &= "INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA "

            If obj.XemDonviDD = 1 Then
                strSQL &= "INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA_ "
            Else
                strSQL &= "INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA "
            End If

            strSQL &= "    AND ST_DONVI.DV_MA NOT LIKE '%CG%' "
            strSQL &= "    AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL &= "    AND ST_DONVI.DV_TV <> 1 "
            strSQL &= "    AND ISNULL(ST_DONVI.DV_LocBB, 0) = 0 "

            ' UNPIVOT 31 ngày (Dùng vòng lặp For để code ngắn gọn)
            strSQL &= "CROSS APPLY ( VALUES "
            For i As Integer = 1 To 30
                strSQL &= "    (" & i.ToString() & ", giovao_" & i.ToString() & ", giora_" & i.ToString() & ", loaica_" & i.ToString() & ", giovaotay_" & i.ToString() & ", gioratay_" & i.ToString() & ", giobinhthuong_" & i.ToString() & ", giotangca_" & i.ToString() & ", lamdem_" & i.ToString() & ", hesongaycong_" & i.ToString() & ", MaNP_" & i.ToString() & ", ditre_" & i.ToString() & ", quenquetthe_" & i.ToString() & "), "
            Next
            strSQL &= "    (31, giovao_31, giora_31, loaica_31, giovaotay_31, gioratay_31, giobinhthuong_31, giotangca_31, lamdem_31, hesongaycong_31, MaNP_31, ditre_31, quenquetthe_31) "
            strSQL &= ") D (NgaySo, giovao, giora, loaica, giovaotay, gioratay, giobinhthuong, giotangca, lamdem, hesongaycong, MaNP, ditre, quenquetthe) "

            ' TÍNH TOÁN NGÀY
            strSQL &= "CROSS APPLY ( SELECT StrDate = CAST(ST_VAORA_MACHINE.Nam AS VARCHAR(4)) + '-' + RIGHT('0' + CAST(ST_VAORA_MACHINE.THANG AS VARCHAR(2)), 2) + '-' + RIGHT('0' + CAST(D.NgaySo AS VARCHAR(2)), 2) ) StrD "
            strSQL &= "CROSS APPLY ( SELECT NgayFull = CASE WHEN ISDATE(StrD.StrDate) = 1 THEN CAST(StrD.StrDate AS DATETIME) ELSE NULL END ) NDate "

            ' OUTER APPLY: Công ngoài
            strSQL &= "OUTER APPLY ( "
            strSQL &= "    SELECT "
            strSQL &= "        MIN(QT_GIOVAO) AS QT_GIOVAO, "
            strSQL &= "        MAX(QT_GIORA) AS QT_GIORA "
            strSQL &= "    FROM ST_VAORA_ "
            strSQL &= "    WHERE NV_MA = ST_VAORA_MACHINE.MANV AND QT_NGAY = NDate.NgayFull "
            strSQL &= ") CN "

            ' OUTER APPLY: Quẹt tay/tăng ca ngoài
            strSQL &= "OUTER APPLY ( "
            strSQL &= "    SELECT "
            strSQL &= "        MIN(QT_GIOVAOTAY) AS QT_GIOVAOTAY, "
            strSQL &= "        MAX(QT_GIORATAY) AS QT_GIORATAY, "
            strSQL &= "        SUM(CC_GIOTANGCA) AS CC_GIOTANGCA "
            strSQL &= "    FROM ST_GIOQUETTHE_ "
            strSQL &= "    WHERE NV_MA = ST_VAORA_MACHINE.MANV AND QT_NGAY = NDate.NgayFull "
            strSQL &= ") QT_CN "

            ' JOIN MF_Aggregated
            strSQL &= "LEFT JOIN MF_Aggregated MF ON MF.userno = ST_VAORA_MACHINE.MANV AND MF.QT_NGAY_LOGIC = NDate.NgayFull "

            ' WHERE CLAUSE (Sửa obj.Thang -> obj.M_Ngay, obj.Nam -> obj.Y_Ngay)
            strSQL &= "WHERE ST_VAORA_MACHINE.THANG = " & obj.M_Ngay & " "
            strSQL &= "  AND ST_VAORA_MACHINE.Nam = " & obj.Y_Ngay & " "
            strSQL &= "  AND NDate.NgayFull IS NOT NULL "
            strSQL &= "  AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) "

            If obj.KHONGQTVAO = 1 Then
                strSQL &= "  AND D.giovao IS NULL "
            End If

            If obj.KHONGQTRA = 1 Then
                strSQL &= "  AND D.giora IS NULL "
            End If

            ' Lọc theo ChonXuong
            Dim chonXuongVal As String = If(obj.ChonXuong IsNot Nothing, obj.ChonXuong.ToString().Trim(), "")
            Select Case chonXuongVal
                Case "TCT"
                    ' Không thêm điều kiện gì (Lấy tất cả)
                Case "KHUA"
                    strSQL &= "  AND ST_DONVI.KHU = 'A' "
                Case "KHUB"
                    strSQL &= "  AND ST_DONVI.KHU = 'B' "
                Case "KHUDVC"
                    strSQL &= "  AND (ST_DONVI.DV_MA LIKE 'HCM%' OR ST_DONVI.KHU = 'DVC') "
                Case Else
                    strSQL &= "  AND ST_DONVI.X_MA_ = '" & chonXuongVal & "' "
            End Select

            ' Lọc nhân viên thôi việc
            strSQL &= "  AND NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_VAORA_MACHINE.MaNV) "

            ' SẮP XẾP
            strSQL &= "ORDER BY ST_DONVI.X_MA_, ST_DONVI.DV_MA, ST_VAORA_MACHINE.MANV, D.NgaySo;"
        End If

        ' Thực thi câu truy vấn
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