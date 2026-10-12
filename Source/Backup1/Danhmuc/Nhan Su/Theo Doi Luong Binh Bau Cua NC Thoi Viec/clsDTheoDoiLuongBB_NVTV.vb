Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTheoDoiLuongBB_NVTV
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objTheoDoiLuongBB_NVTV) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = "SELECT NV_MA,"
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " DV_MA_,"
            strSQL = strSQL + " NV_NGAYVAO,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " HV_TEN,"
            strSQL = strSQL + " ST_HOCVAN.HV_MA,"
            strSQL = strSQL + " NV_NGAYBONHIEM,"
            strSQL = strSQL + " NV_NGAYSINH,"
            strSQL = strSQL + " ST_NHANVIEN.CV_MA,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " ST_CHUCVU.CVU_MA,"
            strSQL = strSQL + " CM_TEN,"
            strSQL = strSQL + " ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " LEFT JOIN ST_HOCVAN ON ST_NHANVIEN.HV_MA = ST_HOCVAN.HV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON ST_NHANVIEN.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT LIKE 'DT%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA = '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA, "
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " DV_MA_,"
            strSQL = strSQL + " NV_NGAYVAO,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA,"
            strSQL = strSQL + " TV_NGAYTHOIVIEC,"
            strSQL = strSQL + " TV_LYDO,"
            strSQL = strSQL + " ST_LOAITHOIVIEC.LTV_MA, LTV_TEN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_LOAITHOIVIEC ON ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA,NV_TEN,NV_NGAYVAO,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYTV,"
            strSQL = strSQL + " T_MA,BB_MA ,"
            strSQL = strSQL + " BB_SoNgayOO,"
            strSQL = strSQL + " BB_SoNgayRO,"
            strSQL = strSQL + " BB_SoNgayCO,"
            strSQL = strSQL + " BB_SoNgayO,"
            strSQL = strSQL + " BB_SoNgayOTC,"
            strSQL = strSQL + " BB_SoNgayP,"
            strSQL = strSQL + " BB_SoNgayKThai,"
            strSQL = strSQL + " BB_SoNgayR,"
            strSQL = strSQL + " BB_SoNgayS,"
            strSQL = strSQL + " BB_SoNgayNo,"
            strSQL = strSQL + " BB_SoNgayTSan,"
            strSQL = strSQL + " BB_SoNgayTNLD,"
            strSQL = strSQL + " BB_Ditre,"
            strSQL = strSQL + " BB_SONGAYDQ,"
            strSQL = strSQL + " BB_SONGAYDS,"
            strSQL = strSQL + " BB_SONGAYST,"
            strSQL = strSQL + " BB_SONGAYKHHGD,"
            strSQL = strSQL + " BB_SONGAYQS"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_BINHBAUTHANG ON ST_NHANVIEN.NV_MA = ST_BINHBAUTHANG.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma "
            strSQL = strSQL + " AND RIGHT(T_MA,4) = YEAR(ST_NHANVIENTHOIVIEC.TV_NgayThoiViec )"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 4 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA,NV_TEN,NV_NGAYVAO,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYTV,"
            strSQL = strSQL + " T_MA,"
            strSQL = strSQL + " L_LUONGCHINH,"
            strSQL = strSQL + " L_PCTRACHNHIEM,"
            strSQL = strSQL + " L_PHUCAPKHAC"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_LUONG ON ST_NHANVIEN.NV_MA = ST_LUONG.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma "
            strSQL = strSQL + " AND RIGHT(T_MA,4) = YEAR(ST_NHANVIENTHOIVIEC.TV_NgayThoiViec )"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA =  '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 5 Then
            strSQL = " SELECT ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + "  ST_NHANVIEN.NV_TEN ,"
            strSQL = strSQL + "  ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.CV_MA ,ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + "  ST_CHUCVU.CVU_MA , CVU_TEN,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DHNN AS DHNN,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.LDCM AS LDCM,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Ngaybatdau ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Soquyetdinh ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Heso ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_LuongCB ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_PhuCapKhac as PHUCAP_CBPCM,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapCV ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapUDMAY ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapNN ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapHMPT ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapQLSX ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapCBVP ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBNT ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBHT ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBTHANG ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapCLGD ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapHTDP ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapQAQIP ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapThoRap, "
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapHSE ,"
            strSQL = strSQL + "  TONGPHUCAPKHAC = [DBL_TroCapCBVP] + [DBL_TrocapUDMAY] + [DBL_TrocapHSE]+[DBL_TrocapThoRap]+[DBL_TroCapQAQIP] "

            strSQL = strSQL + "  FROM ST_NHANVIEN  LEFT JOIN ST_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = ST_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CONGVIEC ON ST_DIENBIENLUONG.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CHUCVU ON ST_DIENBIENLUONG.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + "  WHERE ST_NHANVIEN.NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
            strSQL = strSQL + "  ORDER BY ST_NHANVIEN.NV_MA,DBL_Ngaybatdau,DBL_LuongCB"


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

    Public Function UpdateInfo(ByVal obj As objTheoDoiLuongBB_NVTV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_NHANVIENTHOIVIEC  SET TV_NGAYTHOIVIEC = N'" & Me.QuoteString(obj.NgayTV) & "', TV_SOQUYETDINH = N'" & Me.QuoteString(obj.SoQD) & "', TV_LYDO = N'" & Me.QuoteString(obj.LyDO) & "', LTV_MA = N'" & Me.QuoteString(obj.LoaiTV) & "' WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
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

    Public Function DeleteInfo(ByVal obj As objTheoDoiLuongBB_NVTV) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_NHANVIENTHOIVIEC WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objTheoDoiLuongBB_NVTV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO ST_NHANVIENTHOIVIEC([NV_MA],[TV_NGAYTHOIVIEC],[TV_SOQUYETDINH], TV_LYDO, LTV_MA) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NgayTV) & "',N'" & Me.QuoteString(obj.SoQD) & "',N'" & Me.QuoteString(obj.LyDO) & "',N'" & Me.QuoteString(obj.LoaiTV) & "')")
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
