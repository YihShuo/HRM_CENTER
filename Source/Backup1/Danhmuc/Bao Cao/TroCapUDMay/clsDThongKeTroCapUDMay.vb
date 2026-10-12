Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKeTroCapUDMay
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function

    Public Function Load(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Try
            Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function
    Public Function LoadKhongThamso(ByVal m_sSP_Name As String) As DataTable
        Try
            Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function
    Public Function TinhsolieutrocapUDMay(ByVal obj As objThongKeTroCapUDMay) As Boolean
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = " UPDATE IT_THONGKETROCAPUDMAY "
            strSQL = strSQL + "SET IT_THONGKETROCAPUDMAY.[" + obj.Tencot + "] ="
            strSQL = strSQL + " (CASE WHEN IT_THONGKETROCAPUDMAY.X_MA_ NOT IN ('TONGKHUA','TONGKHUB','TCT','TONGCONGKHUA') THEN TKXUONG.SL"
            strSQL = strSQL + " WHEN IT_THONGKETROCAPUDMAY.X_MA_  IN ('TONGKHUA') THEN TKKHUA.SL "
            strSQL = strSQL + " WHEN IT_THONGKETROCAPUDMAY.X_MA_ IN ('TONGKHUB') THEN TKKHUB.SL "
            ''======= cộng khu A + VP
            strSQL = strSQL + " WHEN IT_THONGKETROCAPUDMAY.X_MA_ IN ('TONGCONGKHUA') THEN TKKHUA_TINHVP.SL "
            ''=======  
            strSQL = strSQL + " WHEN IT_THONGKETROCAPUDMAY.X_MA_  IN ('TCT') THEN TKTCT.SL "
            strSQL = strSQL + " ELSE 0 END)"
            strSQL = strSQL + " FROM IT_THONGKETROCAPUDMAY "
            ''======= TỔNG THEO XƯỞNG
            strSQL = strSQL + " SELECT X_MA_  ,COUNT(ST_NHANVIEN.NV_MA) AS SL  FROM ST_HOPDONGLAODONG "

            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma_  = ST_DONVI.DV_Ma "
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE (DV_TV = 1 OR X_MA_ IN ('KB','DT','TAM')))"
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'  AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%CG%' AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%BGD%' "

            If obj.Tencot = "0" Then
                strSQL = strSQL + " AND ST_NHANVIEN.CV_MA IN (SELECT CV_MA FROM V_THONGKETROCAPMAY_MUC0 ) GROUP BY  X_MA_) AS TKXUONG ON IT_THONGKETROCAPUDMAY.X_MA_ = TKXUONG.X_MA_"
            Else
                strSQL = strSQL + " AND HD_TrocapUD = N'" + Me.QuoteString(obj.HD_TrocapUD) + "' GROUP BY  X_MA_) AS TKXUONG ON IT_THONGKETROCAPUDMAY.X_MA_ = TKXUONG.X_MA_ "
            End If
            ''======= TỔNG THEO KHU A: KHÔNG TINH VĂN PHÒNG
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " SELECT X_MA_='TONGKHUA' ,COUNT(ST_NHANVIEN.NV_MA) AS SL  FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma_  = ST_DONVI.DV_Ma"
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE (DV_TV = 1 OR X_MA_ IN ('KB','DT','TAM'))) "
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'  AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%CG%' AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND (X_MA_ NOT LIKE 'B%')"

            If obj.Tencot = "0" Then
                strSQL = strSQL + " AND ST_NHANVIEN.CV_MA IN (SELECT CV_MA FROM V_THONGKETROCAPMAY_MUC0 )" + ") AS TKKHUA  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUA.X_MA_ "
            Else
                strSQL = strSQL + " AND HD_TrocapUD =  N'" + Me.QuoteString(obj.HD_TrocapUD) + "') AS TKKHUA  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUA.X_MA_ "
            End If
            ''======= TỔNG THEO KHU A: + VĂN PHÒNG
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " SELECT X_MA_='TONGCONGKHUA' ,COUNT(ST_NHANVIEN.NV_MA) AS SL  FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma_  = ST_DONVI.DV_Ma"
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE (DV_TV = 1 OR X_MA_ IN ('KB','DT','TAM'))) "
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'  AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%CG%' AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND (X_MA_ NOT LIKE 'B%' OR X_MA_ LIKE 'VP%')"

            If obj.Tencot = "0" Then
                strSQL = strSQL + " AND ST_NHANVIEN.CV_MA IN (SELECT CV_MA FROM V_THONGKETROCAPMAY_MUC0 )" + ") AS TKKHUA_TINHVP  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUA_TINHVP.X_MA_ "
            Else
                strSQL = strSQL + " AND HD_TrocapUD =  N'" + Me.QuoteString(obj.HD_TrocapUD) + "') AS TKKHUA_TINHVP  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUA_TINHVP.X_MA_ "
            End If

            ''======= TỔNG THEO KHU B:
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " SELECT X_MA_='TONGKHUB' ,COUNT(ST_NHANVIEN.NV_MA) AS SL  FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma_  = ST_DONVI.DV_Ma"
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE (DV_TV = 1 OR X_MA_ IN ('KB','DT','TAM'))) "
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'  AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%CG%' AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND (X_MA_ LIKE 'B%')"

            If obj.Tencot = "0" Then
                strSQL = strSQL + " AND ST_NHANVIEN.CV_MA IN (SELECT CV_MA FROM V_THONGKETROCAPMAY_MUC0 )" + ") AS TKKHUB  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUB.X_MA_ "
            Else
                strSQL = strSQL + " AND HD_TrocapUD = N'" + Me.QuoteString(obj.HD_TrocapUD) + "' ) AS TKKHUB  ON IT_THONGKETROCAPUDMAY.X_MA_ = TKKHUB.X_MA_ "
            End If
            ''======= TỔNG THEO TOÀN CÔNG TY:
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " SELECT X_MA_='TCT' ,COUNT(ST_NHANVIEN.NV_MA) AS SL  FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma_  = ST_DONVI.DV_Ma"
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE (DV_TV = 1 OR X_MA_ IN ('KB','DT','TAM'))) "
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'  AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%CG%' AND ST_NHANVIEN.DV_Ma_  NOT LIKE '%BGD%'"

            If obj.Tencot = "0" Then
                strSQL = strSQL + " AND ST_NHANVIEN.CV_MA IN (SELECT CV_MA FROM V_THONGKETROCAPMAY_MUC0 )" + ") AS TKTCT  ON  IT_THONGKETROCAPUDMAY.X_MA_  = TKTCT.X_MA_"
            Else
                strSQL = strSQL + " AND HD_TrocapUD = N'" + Me.QuoteString(obj.HD_TrocapUD) + "' ) AS TKTCT  ON  IT_THONGKETROCAPUDMAY.X_MA_  = TKTCT.X_MA_"
            End If
        End If

        If obj.ChonBang = 2 Then
            strSQL = " UPDATE IT_THONGKETROCAPUDMAY "
            strSQL = strSQL + " SET IT_THONGKETROCAPUDMAY.TONGCONG = TINHTONG.TONG  "
            strSQL = strSQL + " FROM IT_THONGKETROCAPUDMAY "
            strSQL = strSQL + " LEFT JOIN ( "
            strSQL = strSQL + " SELECT  X_MA_,TONG =  SUM(" + obj.Chuoitinhtong + ")"
            strSQL = strSQL + " FROM IT_THONGKETROCAPUDMAY GROUP BY X_MA_ "
            strSQL = strSQL + " ) AS TINHTONG ON IT_THONGKETROCAPUDMAY.X_MA_ = TINHTONG.X_MA_ "
        End If

        Try
            Return Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Return False
            ProjectData.ClearProjectError()
        End Try
        Return False
    End Function
End Class
