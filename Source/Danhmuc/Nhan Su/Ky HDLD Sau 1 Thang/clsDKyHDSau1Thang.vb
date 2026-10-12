Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDKyHDSau1Thang
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objKyHDSau1Thang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' and DV_LOCBB = 0 order by dv_ma ")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' and DV_LOCBB = 0 AND KHU = 'A' order by dv_ma ")
        End If
        If obj.ChonBang = 6 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' and DV_LOCBB = 0 AND KHU = 'B' order by dv_ma ")
        End If
        If obj.ChonBang = 7 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' and DV_LOCBB = 0 AND KHU = 'DVC' order by dv_ma ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then
            If obj.DonVi = "TCT" Then
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB =0 "
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
             Else
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB =0 "
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DonVi + "'"
            End If
        End If
            'Load cbo xuong
            If obj.ChonBang = 3 Then
            strSQL = ("select ST_NXUONG.X_MA_,(ST_NXUONG.X_MA_+' - '+X_TEN) AS TEN_XUONG from ST_NXUONG INNER JOIN ST_DONVI ON ST_NXUONG.X_MA_ = ST_DONVI.X_MA_ WHERE ST_NXUONG.X_MA_ NOT IN ('KB','CNM') and DV_LOCBB = 0 GROUP BY  ST_NXUONG.X_MA_,X_TEN,ST_NXUONG.THUTU order by ST_NXUONG.THUTU ")
            End If

            'Load danh sach nhan vien theo xuong
        If obj.ChonBang = 4 Then
            If obj.Xuong = "TCT" Then
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0"
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
                strSQL = strSQL + " AND ST_DONVI.X_MA_ NOT IN ('KB','CNM')"
                strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "

            Else
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0"
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
                strSQL = strSQL + " AND ST_DONVI.X_MA_ NOT IN ('KB','CNM')"
                strSQL = strSQL + " AND ST_DONVI.X_MA_ = '" + obj.Xuong + "'"
                strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "
            End If
        End If
        If obj.ChonBang = 5 Then
            If obj.ChonKhu = "TCT" Then
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0"
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
                strSQL = strSQL + " AND ST_DONVI.X_MA_ NOT IN ('KB','CNM')"
                strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "

            Else
                strSQL = "SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ ,"
                strSQL = strSQL + " XNL_LuongCB = ISNULL(XNL_LuongCB,0),"
                strSQL = strSQL + " XNL_PCTrN = ISNULL(XNL_PCTrN,0),"
                strSQL = strSQL + " XNL_PCKhac = ISNULL(XNL_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_XETNANGLUONG1THANG ON ST_NHANVIEN.NV_MA = ST_XETNANGLUONG1THANG.NV_MA"
                strSQL = strSQL + " AND XNL_TuNgay >= '" + obj.TUNGAY + "' AND XNL_DENNGAY <= '" + obj.DENNGAY + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0"
                strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_   = ST_DONVI.X_MA_ "
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
                strSQL = strSQL + " AND ST_DONVI.X_MA_ NOT IN ('KB','CNM')"
                strSQL = strSQL + " AND ST_DONVI.KHU = '" + obj.ChonKhu + "'"
                strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "
            End If
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

    Public Function UpdateInfo(ByVal obj As objKyHDSau1Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "UPDATE ST_TAMUNG  SET TU_SOTIEN = " & Me.QuoteString(obj.SoTien) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
        End If
        If obj.ChonBang = 2 Then
            'strSQL = "UPDATE ST_TAMUNG  SET TU_SOTIEN = NULL, TU_THUONGABC = NULL WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
        End If
        '= "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE [ST_GIOQUETTHE_]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"}) & " " & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function DeleteInfo(ByVal obj As objKyHDSau1Thang) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_XETNANGLUONG1THANG WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objKyHDSau1Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = ("INSERT INTO ST_TAMUNG([NV_MA],[T_MA],[TU_SOTIEN],[TU_THUONGABC],[DV_MA]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NamThang) & "'," & Me.QuoteString(obj.SoTien) & "," & Me.QuoteString(obj.ThuongABC) & ",N'" & Me.QuoteString(obj.DonVi) & "')")
        End If
        If obj.ChonBang = 2 Then
            'strSQL = ("INSERT INTO ST_TAMUNG([NV_MA],[T_MA],[TU_SOTIEN],[TU_THUONGABC],[DV_MA]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NamThang) & "',NULL, NULL ,N'" & Me.QuoteString(obj.DonVi) & "')")
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
