Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDITDienBienLuong
    Inherits DALSQL
    Public Shared obj_D As New objITDienBienLuong
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objITDienBienLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE DV_MA NOT LIKE 'NV%' AND DV_TV <> 1 AND DV_LOCBB = 0 UNION SELECT DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE DV_MA NOT LIKE 'NV%' AND DV_MA <> 'XXX' AND DV_TV =1 AND DV_LOCBB = 0  ORDER BY DV_MA ")
        End If
        If obj.ChonBang = 14 Then
            strSQL = ("SELECT DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE DV_MA NOT LIKE 'NV%' AND DV_MA NOT LIKE 'B%' AND DV_TV <> 1 AND DV_LOCBB = 0 ORDER BY DV_MA ")
        End If
        If obj.ChonBang = 81 Then
            strSQL = ("select convert(nvarchar(50),GETDATE(),20) as NGAY ")
        End If


        If obj.ChonBang = 15 Then
            strSQL = ("SELECT DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE DV_MA NOT LIKE 'NV%' AND DV_MA LIKE 'B%' AND DV_TV <> 1 AND DV_LOCBB = 0 ORDER BY DV_MA ")
        End If
        If obj.ChonBang = 20 Then
            strSQL = ("SELECT DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE DV_MA NOT LIKE 'NV%' AND DV_MA <> 'XXX' AND DV_TV =1 AND DV_LOCBB = 0  ORDER BY DV_MA")
        End If
        If obj.ChonBang = 4 Then
            strSQL = (" SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + "  ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "  ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Ngaybatdau AS NGAY,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Soquyetdinh AS SOQD,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Heso AS HESO,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_LuongCB AS LUONG,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PhuCap AS PHUCAP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.CV_MA AS CV_MA,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.CVU_MA AS CVU_MA,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DHNN AS DHNN,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.LDCM AS LDCM,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PhuCapKhac AS PhuCapKhac,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapCV AS TrocapCV,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapUDMAY AS TrocapUDMAY,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapCMNV AS TrocapCMNV,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapNN AS TrocapNN,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapHMPT AS TrocapHMPT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapMOITRUONG AS TCMT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapQLSX AS TroCapQLSX,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapCBVP AS TroCapCBVP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBNT AS TroCapBBNT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBHT AS TroCapBBHT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBTHANG AS TroCapBBTHANG,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapCLGD AS TroCapCLGD,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapHTDP AS TroCapHTDP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapQAQIP AS TroCapQAQIP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapThoRap AS TrocapThoRap,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapHSE AS TrocapHSE,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_KHONGHUONGCHUYENCAN AS DBL_KHONGHUONGCHUYENCAN,"

            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PHUCLOI AS PHUCLOI,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_HTNG AS HOTRONGOAIGIO,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_DQTV AS DQTV,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PCCC AS PCCC"


            strSQL = strSQL + "  FROM ST_NHANVIEN  LEFT JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + "  AND IT_DIENBIENLUONG.DBL_Ngaybatdau =  '" + obj.NGAY + "' "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
            strSQL = strSQL + "  WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            If obj.CHONDONVINGHIVIEC = 1 Then
                strSQL = strSQL + "  AND ST_NHANVIEN.DV_MA = '" + obj.DONVI + "' ORDER BY ST_NHANVIEN.NV_MA"
            Else
                strSQL = strSQL + "  AND ST_NHANVIEN.DV_MA_ = '" + obj.DONVI + "' ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            strSQL = (" INSERT INTO ST_DIENBIENLUONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM,DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_PHUCLOI, DBL_HTNG,DBL_DQTV, DBL_PCCC"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM, DBL_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "',"
            strSQL = strSQL + " DBL_PHUCLOI,"
            strSQL = strSQL + " DBL_HTNG,"
            strSQL = strSQL + " DBL_DQTV,"
            strSQL = strSQL + " DBL_PCCC"


            strSQL = strSQL + " FROM IT_DIENBIENLUONG"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU= '" + obj.NGAY + "'"
            strSQL = strSQL + " AND NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "')"
        End If

        If obj.ChonBang = 17 Then
            strSQL = (" INSERT INTO ST_DIENBIENLUONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM,DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_PHUCLOI, DBL_HTNG,DBL_DQTV, DBL_PCCC"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT IT_DIENBIENLUONG.NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM, DBL_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "',"
            strSQL = strSQL + " DBL_PHUCLOI,"
            strSQL = strSQL + " DBL_HTNG,"
            strSQL = strSQL + " DBL_DQTV,"
            strSQL = strSQL + " DBL_PCCC"

            strSQL = strSQL + " FROM IT_DIENBIENLUONG INNER JOIN ST_NHANVIEN ON IT_DIENBIENLUONG.NV_Ma = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU= '" + obj.NGAY + "'"
            strSQL = strSQL + " AND IT_DIENBIENLUONG.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA_ NOT LIKE 'B%'"
        End If
        If obj.ChonBang = 19 Then
            strSQL = (" INSERT INTO ST_DIENBIENLUONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM,DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_PHUCLOI, DBL_HTNG,DBL_DQTV, DBL_PCCC"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT IT_DIENBIENLUONG.NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM, DBL_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "',"
            strSQL = strSQL + " DBL_PHUCLOI,"
            strSQL = strSQL + " DBL_HTNG,"
            strSQL = strSQL + " DBL_DQTV,"
            strSQL = strSQL + " DBL_PCCC"

            strSQL = strSQL + " FROM IT_DIENBIENLUONG INNER JOIN ST_NHANVIEN ON IT_DIENBIENLUONG.NV_Ma = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU= '" + obj.NGAY + "'"
            strSQL = strSQL + " AND IT_DIENBIENLUONG.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA_ LIKE 'B%'"
        End If
        If obj.ChonBang = 5 Then
            strSQL = (" SELECT A.NV_MA,")
            strSQL = strSQL + " A.DBL_NGAYBATDAU,"
            strSQL = strSQL + " A.DBL_SOQUYETDINH,"
            strSQL = strSQL + " A.DBL_HESO,"
            strSQL = strSQL + " A.DBL_LUONGCB,"
            strSQL = strSQL + " A.DBL_PHUCAP,"
            strSQL = strSQL + " A.CV_MA,"
            strSQL = strSQL + " A.CVU_MA,"
            strSQL = strSQL + " A.DHNN,"
            strSQL = strSQL + " A.DBL_PhuCapKhac,"
            strSQL = strSQL + " A.DBL_TrocapCV,"
            strSQL = strSQL + " A.DBL_TrocapUDMAY,"
            strSQL = strSQL + " A.DBL_TrocapCMNV,"
            strSQL = strSQL + " A.DBL_TrocapNN,"
            strSQL = strSQL + " A.DBL_TrocapHMPT,"
            strSQL = strSQL + " A.DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " A.DBL_TroCapQLSX,"
            strSQL = strSQL + " A.DBL_TroCapCBVP,"
            strSQL = strSQL + " A.DBL_TroCapBBNT,"
            strSQL = strSQL + " A.DBL_TroCapBBHT,"
            strSQL = strSQL + " A.DBL_TroCapBBTHANG,"
            strSQL = strSQL + " A.DBL_TroCapCLGD,"
            strSQL = strSQL + " A.DBL_TroCapHTDP,"
            strSQL = strSQL + " A.DBL_TroCapQAQIP,"
            strSQL = strSQL + " A.DBL_TrocapThoRap,"
            strSQL = strSQL + " A.DBL_TrocapHSE, A.DBL_KHONGHUONGCHUYENCAN"
            strSQL = strSQL + " FROM ST_DIENBIENLUONG AS A INNER JOIN IT_DIENBIENLUONG AS B ON A.NV_MA = B.NV_MA "
            strSQL = strSQL + " WHERE A.NV_MA = B.NV_MA AND A.DBL_NGAYBATDAU= '" + obj.NGAY + "'"
        End If

        If obj.ChonBang = 6 Then
            strSQL = (" SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + "  ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "  ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Ngaybatdau AS NGAY,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Soquyetdinh AS SOQD,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_Heso AS HESO,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_LuongCB AS LUONG,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PhuCap AS PHUCAP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_PhuCapKhac AS PhuCapKhac,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapCV AS TrocapCV,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapUDMAY AS TrocapUDMAY,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapCMNV AS TrocapCMNV,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapNN AS TrocapNN,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapHMPT AS TrocapHMPT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapMOITRUONG AS TCMT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapQLSX AS TroCapQLSX,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapCBVP AS TroCapCBVP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBNT AS TroCapBBNT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBHT AS TroCapBBHT,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapBBTHANG AS TroCapBBTHANG,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapCLGD AS TroCapCLGD,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapHTDP AS TroCapHTDP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TroCapQAQIP AS TroCapQAQIP,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapThoRap AS TrocapThoRap,"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_TrocapHSE AS TrocapHSE"
            strSQL = strSQL + "  IT_DIENBIENLUONG.DBL_KHONGHUONGCHUYENCAN  AS DBL_KHONGHUONGCHUYENCAN"
            strSQL = strSQL + "  FROM ST_NHANVIEN  LEFT JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + "  AND IT_DIENBIENLUONG.DBL_Ngaybatdau =  '" + obj.NGAY + "' "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
            strSQL = strSQL + "  WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            'strSQL = strSQL + "  AND ST_DONVI.DV_TV <>1"
            strSQL = strSQL + "  AND ST_NHANVIEN.DV_MA = '" + obj.DONVI + "'"
        End If

        If obj.ChonBang = 3 Then
            strSQL = (" SELECT * ")
            strSQL = strSQL + "  FROM IT_DIENBIENLUONG"
            strSQL = strSQL + "  WHERE IT_DIENBIENLUONG.NV_MA ='" + obj.MANV + "'"
            strSQL = strSQL + "  AND IT_DIENBIENLUONG.DBL_Ngaybatdau = '" + obj.NGAY + "' "
        End If


        If obj.ChonBang = 9 Then
            strSQL = (" INSERT INTO ST_DIENBIENLUONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM, DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT NV_MA,"
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " CV_MA,"
            strSQL = strSQL + " CVU_MA,"
            strSQL = strSQL + " DHNN,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TrocapMOITRUONG,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE,"
            strSQL = strSQL + " LDCM, DBL_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "',"
            strSQL = strSQL + "  DBL_PHUCLOI,"
            strSQL = strSQL + "  DBL_HTNG,"
            strSQL = strSQL + "  DBL_DQTV,"
            strSQL = strSQL + "  DBL_PCCC"

            strSQL = strSQL + " FROM IT_DIENBIENLUONG"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU= '" + obj.NGAY + "'"
            strSQL = strSQL + " AND NV_MA = '" + obj.MANV + "'"
        End If

        If obj.ChonBang = 7 Then
            strSQL = (" SELECT NV_MA,")
            strSQL = strSQL + " DBL_NGAYBATDAU,"
            strSQL = strSQL + " DBL_SOQUYETDINH,"
            strSQL = strSQL + " DBL_HESO,"
            strSQL = strSQL + " DBL_LUONGCB,"
            strSQL = strSQL + " DBL_PHUCAP,"
            strSQL = strSQL + " DBL_PhuCapKhac,"
            strSQL = strSQL + " DBL_TrocapCV,"
            strSQL = strSQL + " DBL_TrocapUDMAY,"
            strSQL = strSQL + " DBL_TrocapCMNV,"
            strSQL = strSQL + " DBL_TrocapNN,"
            strSQL = strSQL + " DBL_TrocapHMPT,"
            strSQL = strSQL + " DBL_TroCapQLSX,"
            strSQL = strSQL + " DBL_TroCapCBVP,"
            strSQL = strSQL + " DBL_TroCapBBNT,"
            strSQL = strSQL + " DBL_TroCapBBHT,"
            strSQL = strSQL + " DBL_TroCapBBTHANG,"
            strSQL = strSQL + " DBL_TroCapCLGD,"
            strSQL = strSQL + " DBL_TroCapHTDP,"
            strSQL = strSQL + " DBL_TroCapQAQIP,"
            strSQL = strSQL + " DBL_TrocapThoRap,"
            strSQL = strSQL + " DBL_TrocapHSE, DBL_KHONGHUONGCHUYENCAN, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC"

            strSQL = strSQL + " FROM ST_DIENBIENLUONG"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU= '" + obj.NGAY + "'"
            strSQL = strSQL + " AND NV_MA = '" + obj.MANV + "'"
        End If


        If obj.ChonBang = 10 Then
            strSQL = (" SELECT ST_NHANVIEN.NV_MA, ")
            strSQL = strSQL + " CV_MA, "
            strSQL = strSQL + " CVU_MA ,"
            strSQL = strSQL + " DHNN = CASE WHEN ST_HOPDONGLAODONG.BANGL = 6 THEN 1 ELSE 0 END, "
            strSQL = strSQL + "  HD_PHUCLOI, HD_HTNG, HD_DQTV, HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = '" + obj.MANV + "'"
        End If

        If obj.ChonBang = 11 Then
            strSQL = (" UPDATE ST_NHANVIEN")
            strSQL = strSQL + " SET ST_NHANVIEN.CV_MA =  IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA = IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " ST_NHANVIEN.HD_CVNANGNHOCDH = IT_DIENBIENLUONG.DHNN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAY) & "')"
        End If


        If obj.ChonBang = 16 Then
            strSQL = (" UPDATE ST_NHANVIEN")
            strSQL = strSQL + " SET ST_NHANVIEN.CV_MA =  IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA = IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " ST_NHANVIEN.HD_CVNANGNHOCDH = IT_DIENBIENLUONG.DHNN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA_ NOT LIKE 'B%'"
        End If
        If obj.ChonBang = 18 Then
            strSQL = (" UPDATE ST_NHANVIEN")
            strSQL = strSQL + " SET ST_NHANVIEN.CV_MA =  IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA = IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " ST_NHANVIEN.HD_CVNANGNHOCDH = IT_DIENBIENLUONG.DHNN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA_ LIKE 'B%'"
        End If
        If obj.ChonBang = 12 Then
            strSQL = (" UPDATE ST_NHANVIEN")
            strSQL = strSQL + " SET ST_NHANVIEN.CV_MA =  IT_DIENBIENLUONG.CV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA = IT_DIENBIENLUONG.CVU_MA,"
            strSQL = strSQL + " ST_NHANVIEN.HD_CVNANGNHOCDH = IT_DIENBIENLUONG.DHNN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = IT_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + " WHERE DBL_NGAYBATDAU = '" + obj.NGAY + "'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_DIENBIENLUONG WHERE DBL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA = '" + obj.MANV + "'"
        End If
        If obj.ChonBang = 13 Then
            strSQL = "SELECT JELL_QUYENTRUYCAP.Ma_DM,KHUA = ISNULL(JELL_QUYENTRUYCAP.KHUA,0),KHUB = ISNULL(JELL_QUYENTRUYCAP.KHUB,0)  "
            strSQL = strSQL + " FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM "
            strSQL = strSQL + " WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.NGUOIDUNG + "' and JELL_DANHMUC.Ma_DM = '" + obj.MA_DM + "'"
        End If
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.Truyvan = strSQL
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
    Public Function InsertInfo(ByVal obj As objITDienBienLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into IT_DIENBIENLUONG([NV_MA],[DBL_Ngaybatdau],[DBL_Soquyetdinh],[DBL_Heso],[DBL_LuongCB],[DBL_PhuCap],[CV_MA],[CVU_MA],[DHNN],[LDCM],[DBL_PhuCapKhac],[DBL_TrocapCV],[DBL_TrocapUDMAY],[DBL_TrocapCMNV],[DBL_TrocapNN],[DBL_TrocapHMPT],[DBL_TrocapMOITRUONG],[DBL_TroCapQLSX],[DBL_TroCapCBVP],[DBL_TroCapBBNT],[DBL_TroCapBBHT],[DBL_TroCapBBTHANG],[DBL_TroCapCLGD],[DBL_TroCapHTDP],[DBL_TroCapQAQIP],[DBL_TrocapThoRap],[DBL_TrocapHSE],[DBL_KHONGHUONGCHUYENCAN],[DBL_NGAYTAO],[DBL_NGUOITAO],[DBL_PHUCLOI],[DBL_HTNG],[DBL_DQTV],[DBL_PCCC]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.NGAY) & "','" & Me.QuoteString(obj.SoQD) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.LUONG) & "',N'" & Me.QuoteString(obj.PhuCap) & "',N'" & Me.QuoteString(obj.CongViec) & "',N'" & Me.QuoteString(obj.ChucVu) & "'," & Me.QuoteString(obj.DHNN) & "," & Me.QuoteString(obj.LDCM) & ",N'" & Me.QuoteString(obj.PhuCapKhac) & "',N'" & Me.QuoteString(obj.TrocapCV) & "',N'" & Me.QuoteString(obj.TrocapUDMAY) & "',N'" & Me.QuoteString(obj.TrocapCMNV) & "',N'" & Me.QuoteString(obj.TrocapNN) & "',N'" & Me.QuoteString(obj.TrocapHMPT) & "',N'" & Me.QuoteString(obj.TrocapMT) & "',N'" & Me.QuoteString(obj.TroCapQLSX) & "',N'" & Me.QuoteString(obj.TroCapCBVP) & "',N'" & Me.QuoteString(obj.TroCapBBNT) & "',N'" & Me.QuoteString(obj.TroCapBBHT) & "',N'" & Me.QuoteString(obj.TroCapBBTHANG) & "',N'" & Me.QuoteString(obj.TroCapCLGD) & "',N'" & Me.QuoteString(obj.TroCapHTDP) & "',N'" & Me.QuoteString(obj.TroCapQAQIP) & "',N'" & Me.QuoteString(obj.TrocapThoRap) & "',N'" & Me.QuoteString(obj.TrocapHSE) & "',N'" & Me.QuoteString(obj.KHONGCC) & "','" & obj.NGAYTAO & "',N'" & Me.QuoteString(obj.NGUOITAO) & "',N'" & Me.QuoteString(obj.PHUCLOI) & "',N'" & Me.QuoteString(obj.HTNG) & "',N'" & Me.QuoteString(obj.DQTV) & "',N'" & Me.QuoteString(obj.PCCC) & "')")
            obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
            obj.Truyvan = strSQL
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
    Public Function DeleteInfo(ByVal obj As objITDienBienLuong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 1 Then
            strSQL = ("delete from IT_DIENBIENLUONG where NV_MA=N'" & Me.QuoteString(obj.MANV) & "' AND DBL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAY) & "'")
            obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
            obj.Truyvan = strSQL
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objITDienBienLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            strSQL = ("UPDATE IT_DIENBIENLUONG   SET [NV_Ma] = '" & Me.QuoteString(obj.MANV) & "' ,[DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'   ,[DBL_Soquyetdinh] = '" & Me.QuoteString(obj.SoQD) & "'  ,[DBL_Heso] = '" & Me.QuoteString(obj.HESO) & "'  ,[DBL_LuongCB] = '" & Me.QuoteString(obj.LUONG) & "'  ,[DBL_PHUCAP] = '" & Me.QuoteString(obj.PhuCap) & "'  ,[CV_MA] = N'" & Me.QuoteString(obj.CongViec) & "'  ,[CVU_MA] = N'" & Me.QuoteString(obj.ChucVu) & "' ,[DHNN] = " & Me.QuoteString(obj.DHNN) & ",[LDCM] = " & Me.QuoteString(obj.LDCM) & ",[DBL_PhuCapKhac] = '" & Me.QuoteString(obj.PhuCapKhac) & "'  ,[DBL_TrocapCV] = '" & Me.QuoteString(obj.TrocapCV) & "'  ,[DBL_TrocapUDMAY] = '" & Me.QuoteString(obj.TrocapUDMAY) & "'  ,[DBL_TrocapCMNV] = '" & Me.QuoteString(obj.TrocapCMNV) & "'  ,[DBL_TrocapNN] = '" & Me.QuoteString(obj.TrocapNN) & "'  ,[DBL_TrocapHMPT] = '" & Me.QuoteString(obj.TrocapHMPT) & "'  ,[DBL_TroCapQLSX] = '" & Me.QuoteString(obj.TroCapQLSX) & "'  ,[DBL_TroCapCBVP] = '" & Me.QuoteString(obj.TroCapCBVP) & "'  ,[DBL_TroCapBBNT] = '" & Me.QuoteString(obj.TroCapBBNT) & "'  ,[DBL_TroCapBBHT] = '" & Me.QuoteString(obj.TroCapBBHT) & "'  ,[DBL_TroCapBBTHANG] = '" & Me.QuoteString(obj.TroCapBBTHANG) & "'  ,[DBL_TroCapCLGD] = '" & Me.QuoteString(obj.TroCapCLGD) & "'  ,[DBL_TroCapHTDP] = '" & Me.QuoteString(obj.TroCapHTDP) & "'  ,[DBL_TroCapQAQIP] = '" & Me.QuoteString(obj.TroCapQAQIP) & "'  ,[DBL_TrocapThoRap] = '" & Me.QuoteString(obj.TrocapThoRap) & "'  ,[DBL_TrocapHSE] = '" & Me.QuoteString(obj.TrocapHSE) & "',[DBL_TrocapMOITRUONG] = '" & Me.QuoteString(obj.TrocapMT) & "',[DBL_KHONGHUONGCHUYENCAN] = '" & Me.QuoteString(obj.KHONGCC) & "',[DBL_NGAYCN] = '" & Me.QuoteString(obj.NGAYCN) & "',[DBL_NGUOICN] = '" & Me.QuoteString(obj.NGUOICN) & "',[DBL_PHUCLOI] = '" & Me.QuoteString(obj.PHUCLOI) & "',[DBL_HTNG] = '" & Me.QuoteString(obj.HTNG) & "',[DBL_DQTV] = '" & Me.QuoteString(obj.DQTV) & "',[DBL_PCCC] = '" & Me.QuoteString(obj.PCCC) & "'  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND [DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'")
            obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
            obj.Truyvan = strSQL
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
End Class
