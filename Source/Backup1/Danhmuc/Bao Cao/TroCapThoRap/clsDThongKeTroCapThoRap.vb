Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Public Class clsDThongKeTroCapThoRap
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
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
    Public Function TinhsolieutrocapThoRap(ByVal obj As objThongKeTroCapThoRap) As Boolean
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = " UPDATE IT_THONGKETROCAPTHORAP "
            strSQL = strSQL + "SET IT_THONGKETROCAPTHORAP.[" + obj.Tencot + "] ="
            strSQL = strSQL + " (CASE WHEN IT_THONGKETROCAPTHORAP.X_MA_ NOT IN ('TONGKHUA','TONGKHUB','TCT') THEN TKXUONG.SL"
            strSQL = strSQL + " WHEN IT_THONGKETROCAPTHORAP.X_MA_  IN ('TONGKHUA') THEN TKKHUA.SL "
            strSQL = strSQL + " WHEN IT_THONGKETROCAPTHORAP.X_MA_ IN ('TONGKHUB') THEN TKKHUB.SL "
            strSQL = strSQL + " WHEN IT_THONGKETROCAPTHORAP.X_MA_  IN ('TCT') THEN TKTCT.SL "
            strSQL = strSQL + " ELSE 0 END)"
            strSQL = strSQL + " FROM IT_THONGKETROCAPTHORAP "
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " (SELECT X_MA_,COUNT(ST_NHANVIEN.NV_MA) AS SL "
            strSQL = strSQL + " FROM ST_HOPDONGLAODONG  "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma  = ST_DONVI.DV_Ma "
            strSQL = strSQL + " WHERE DV_TV <> 1 "
            strSQL = strSQL + " AND X_MA_ NOT IN ('KB','DT','TAM') AND ST_DONVI.DV_Ma  NOT LIKE '%CG%' AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%' "
            strSQL = strSQL + " AND HD_TrocapThoRap = N'" + Me.QuoteString(obj.HD_TrocapTR) + "' GROUP BY  X_MA_) AS TKXUONG ON IT_THONGKETROCAPTHORAP.X_MA_ = TKXUONG.X_MA_ "
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " (SELECT X_MA_='TONGKHUA',COUNT(ST_NHANVIEN.NV_MA) AS SL "
            strSQL = strSQL + " FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma  = ST_DONVI.DV_Ma "
            strSQL = strSQL + " WHERE DV_TV <> 1 AND X_MA_ NOT IN ('KB','DT','TAM','VP')"
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%' AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%' AND ST_DONVI.KHU =  'A' "
            strSQL = strSQL + " AND HD_TrocapThoRap =  N'" + Me.QuoteString(obj.HD_TrocapTR) + "') AS TKKHUA  ON IT_THONGKETROCAPTHORAP.X_MA_ = TKKHUA.X_MA_ "
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " (SELECT X_MA_='TONGKHUB',COUNT(ST_NHANVIEN.NV_MA) AS SL "
            strSQL = strSQL + " FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma  = ST_DONVI.DV_Ma "
            strSQL = strSQL + " WHERE DV_TV <> 1 AND X_MA_ NOT IN ('KB','DT','TAM','VP')"
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%' AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%' "
            strSQL = strSQL + " AND ST_DONVI.KHU = 'B' "
            strSQL = strSQL + " AND HD_TrocapThoRap = N'" + Me.QuoteString(obj.HD_TrocapTR) + "' ) AS TKKHUB  ON IT_THONGKETROCAPTHORAP.X_MA_ = TKKHUB.X_MA_ "
            strSQL = strSQL + " LEFT JOIN "
            strSQL = strSQL + " (SELECT X_MA_='TCT',COUNT(ST_NHANVIEN.NV_MA) AS SL "
            strSQL = strSQL + " FROM ST_HOPDONGLAODONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma  = ST_HOPDONGLAODONG.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_Ma  = ST_DONVI.DV_Ma "
            strSQL = strSQL + " WHERE DV_TV <> 1 AND X_MA_ NOT IN ('KB','DT','TAM') "
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%CG%'"
            strSQL = strSQL + " AND ST_DONVI.DV_Ma  NOT LIKE '%BGD%'"
            If obj.Khu = "KHUA" Then
                strSQL = strSQL + " AND ST_DONVI.KHU  = 'A' "
            End If
            If obj.Khu = "KHUB" Then
                strSQL = strSQL + " AND ST_DONVI.KHU  = 'B' "
            End If
            If obj.Khu = "DVC" Then
                strSQL = strSQL + " AND ST_DONVI.KHU  = 'DVC' "
            End If
            If obj.Khu = "TCT" Then

            End If
            strSQL = strSQL + " AND HD_TrocapThoRap = N'" + Me.QuoteString(obj.HD_TrocapTR) + "' ) AS TKTCT  ON  IT_THONGKETROCAPTHORAP.X_MA_  = TKTCT.X_MA_"
        End If
        If obj.ChonBang = 2 Then
            strSQL = " UPDATE IT_THONGKETROCAPTHORAP "
            strSQL = strSQL + " SET IT_THONGKETROCAPTHORAP.TONGCONG = TINHTONG.TONG  "
            strSQL = strSQL + " FROM IT_THONGKETROCAPTHORAP "
            strSQL = strSQL + " LEFT JOIN ( "
            strSQL = strSQL + " SELECT  X_MA_,TONG =  SUM(" + obj.Chuoitinhtong + ")"
            strSQL = strSQL + " FROM IT_THONGKETROCAPTHORAP GROUP BY X_MA_ "
            strSQL = strSQL + " ) AS TINHTONG ON IT_THONGKETROCAPTHORAP.X_MA_ = TINHTONG.X_MA_ "
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
