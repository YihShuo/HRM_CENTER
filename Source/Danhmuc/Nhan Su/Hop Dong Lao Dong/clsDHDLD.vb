Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDHDLD
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objHDLD) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA_ AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TROCAPMOITRUONG AS TCMT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC1 AS BAC1,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC2 AS BAC2,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC3 AS BAC3,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_KHONGHUONGCHUYENCAN AS HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LocBB =0 "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) --and ST_NHANVIEN.DV_MA NOT LIKE N'T%'"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 26 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA_ AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TROCAPMOITRUONG AS TCMT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC1 AS BAC1,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC2 AS BAC2,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC3 AS BAC3,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_KHONGHUONGCHUYENCAN AS HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LocBB =0 "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ST_NHANVIEN.DV_MA_ NOT LIKE 'B%' --and ST_NHANVIEN.DV_MA NOT LIKE N'T%'"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 27 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA_ AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TROCAPMOITRUONG AS TCMT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC1 AS BAC1,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC2 AS BAC2,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC3 AS BAC3,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_KHONGHUONGCHUYENCAN AS HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LocBB =0 "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ST_NHANVIEN.DV_MA_ LIKE 'B%' --and ST_NHANVIEN.DV_MA NOT LIKE N'T%'"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If


        If obj.ChonBang = 111 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC1 AS BAC1,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC2 AS BAC2,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_BAC3 AS BAC3,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_KHONGHUONGCHUYENCAN AS HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND AND ST_HOPDONGLAODONG.NV_MA = '" & Me.QuoteString(obj.MANV) & "' "
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_GIAHAN AS GIAHAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYBATDAUGIAHAN AS NGAYBDGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYKETTHUCGIAHAN AS NGAYKTGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LYDOGIAHAN AS LYDO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.HD_NGAYHETHAN = (SELECT MAX(T.HD_NGAYHETHAN) FROM ST_HOPDONGLAODONG AS T WHERE T.NV_MA =ST_HOPDONGLAODONG.NV_MA)"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 22 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BANGL AS BANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.NGACH AS NGACH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BAC AS BAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.BL_MA AS BL,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_GIAHAN AS GIAHAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYBATDAUGIAHAN AS NGAYBDGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYKETTHUCGIAHAN AS NGAYKTGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LYDOGIAHAN AS LYDO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"

            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND ST_HOPDONGLAODONG.HD_NGAYKY = (SELECT MAX(ST_HOPDONGLAODONG.HD_NGAYKY) FROM ST_HOPDONGLAODONG WHERE ST_HOPDONGLAODONG.NV_MA = '" & Me.QuoteString(obj.MANV) & "')"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If
        
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA, ST_NHANVIEN.NV_TEN, ST_CHUCVU.CVU_TEN , ST_CONGVIEC.CV_TEN FROM ST_NHANVIEN  LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA  LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA WHERE ST_NHANVIEN.NV_MA = '" & Me.QuoteString(obj.MANV) & "'")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT B_MA FROM IT_BAC ORDER BY B_MA")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("SELECT IT_BAC.B_MA")
            strSQL = strSQL + ",BL_TEN+'" & "-" & "'+N_TEN+'" & "-" & "'+B_TEN AS TEN"
            strSQL = strSQL + ",IT_BAC.B_HSLUONG AS HESO"
            strSQL = strSQL + ",IT_BAC.B_MUCLUONG AS MUCLUONG"
            strSQL = strSQL + ",IT_BAC.B_PCCM AS PCCM"
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_NGACH ON IT_BAC.N_MA = IT_NGACH.N_MA"
            strSQL = strSQL + " LEFT JOIN IT_BANGLUONG ON IT_BAC.BL_MA = IT_BANGLUONG.BL_MA"
            strSQL = strSQL + " WHERE IT_BAC.B_MA = '" & Me.QuoteString(obj.MABAC) & "'"
        End If
        If obj.ChonBang = 6 Then
            strSQL = ("SELECT LUONGTOITHIEU FROM IT_LUONGTOITHIEU")
        End If
        If obj.ChonBang = 7 Then
            strSQL = ("SELECT * FROM ST_HOPDONG_LOAI ORDER BY L_MA")
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT NV_MA, HD_NGAYKY FROM ST_HOPDONGLAODONG WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND HD_NGAYKY = '" & Me.QuoteString(obj.NGAYKY) & "'")
        End If
        If obj.ChonBang = 9 Then
            strSQL = ("SELECT   STT = '',")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DVMA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_So AS SO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.L_Ma AS MALOAI,"
            strSQL = strSQL + " ST_HOPDONG_LOAI.L_TEN AS TENLOAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayKy AS NGAYKY,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NgayHetHan AS NGAYHH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LuongCB AS LUONGCB,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HeSo AS HESO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PhuCapkhac AS PCKHAC,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHXH AS BHXH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHYT AS BHYT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DongBHTN AS BHTN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_CongviecDH AS DOCHAI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCV AS TCCV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapUD AS TCUD,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TroCapQAQIP AS QAQIP,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapThoRap AS ThoRap,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHSE AS HSE,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapCMNV AS TCCM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapNN AS TCNN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TrocapHMPT AS TCHM,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_GIAHAN AS GIAHAN,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_Luongtoithieu AS LUONGTT,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYBATDAUGIAHAN AS NGAYBDGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_NGAYKETTHUCGIAHAN AS NGAYKTGH,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCM_VPX AS TCCM_VPX ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBVP AS CBVP ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCCBTS AS CBTS ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBNT AS BBNT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBHT AS BBHT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.TCBBTHANG AS BBT ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCCHAMLOGIADINH  ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_TCHOTRODONGPHUC ,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_LYDOGIAHAN AS LYDO,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PHUCLOI,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_HTNG,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_DQTV,"
            strSQL = strSQL + " ST_HOPDONGLAODONG.HD_PCCC"

            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_HOPDONGLAODONG.NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND ST_HOPDONGLAODONG.L_MA = '" & Me.QuoteString(obj.MAHD) & "'"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 10 Then
            strSQL = ("SELECT BANGLUONG = IT_BAC.BL_MA, ")
            strSQL = strSQL + " TENBANGLUONG = IT_BANGLUONG.BL_TEN"
            strSQL = strSQL + " FROM IT_BAC INNER JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA =IT_BAC.BL_MA "
            strSQL = strSQL + " WHERE B_HSLUONG = " & Me.QuoteString(obj.HESO) & " "
            strSQL = strSQL + " GROUP BY IT_BAC.BL_MA,"
            strSQL = strSQL + " IT_BANGLUONG.BL_TEN"
        End If

        If obj.ChonBang = 11 Then
            strSQL = ("SELECT NGACH = LEFT(IT_BAC.N_MA,1),")
            strSQL = strSQL + " TENNGACH = IT_NGACH.N_TEN"
            strSQL = strSQL + " FROM IT_BAC INNER JOIN IT_NGACH ON IT_BAC.N_MA = IT_NGACH.N_MA"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA = '" & Me.QuoteString(obj.MABAC) & "'"
        End If

        If obj.ChonBang = 12 Then
            strSQL = ("SELECT NGACH = LEFT(IT_BAC.N_MA,1),")
            strSQL = strSQL + " TENNGACH = IT_NGACH.N_TEN"
            strSQL = strSQL + " FROM IT_BAC INNER JOIN IT_NGACH ON IT_BAC.N_MA = IT_NGACH.N_MA"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA = '" & Me.QuoteString(obj.MABAC) & "'"
        End If
        If obj.ChonBang = 13 Then
            strSQL = (" SELECT * FROM IT_BANGLUONG WHERE BL_MA = '" & Me.QuoteString(obj.MABAC) & "'")
        End If
        If obj.ChonBang = 14 Then
            strSQL = (" SELECT *  FROM IT_NGACH  WHERE BL_MA = '" & Me.QuoteString(obj.MABAC) & "' AND LEFT(N_MA,1) ='" & Me.QuoteString(obj.NGACH) & "' ")
        End If
        If obj.ChonBang = 15 Then
            strSQL = (" SELECT BAC = IT_BAC.B_TEN")
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA = IT_BAC.B_MA "
            strSQL = strSQL + " AND IT_BANGLUONG.BL_TEN = IT_BAC.B_TEN"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA='" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND LEFT(IT_BAC.N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
        End If
        If obj.ChonBang = 16 Then
            strSQL = ("SELECT BAC = B_MA")
            strSQL = strSQL + " FROM IT_BAC"
            strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
            strSQL = strSQL + " AND BL_MA = '" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND B_TEN =N'" & Me.QuoteString(obj.BAC) & "'"
            strSQL = strSQL + " AND B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
        End If
        If obj.ChonBang = 17 Then
            strSQL = ("SELECT BAC = IT_BAC.B_TEN, B_PCCM, B_MUCLUONG, B_PCDONGPHUC")
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA = IT_BAC.B_MA "
            strSQL = strSQL + " AND IT_BANGLUONG.BL_TEN = IT_BAC.B_TEN"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA='" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND LEFT(IT_BAC.N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
        End If

        If obj.ChonBang = 18 Then
            strSQL = (" SELECT B_PCCM ")
            strSQL = strSQL + " FROM IT_BAC "
            strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
            strSQL = strSQL + " AND BL_MA = '" & Me.QuoteString(obj.MABAC) & "' ORDER BY B_PCCM"
        End If

        If obj.ChonBang = 19 Then
            If Me.QuoteString(obj.NGACH) <= 2 Then
                strSQL = (" SELECT B_PCCM ")
                strSQL = strSQL + " FROM IT_BAC"
                strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
                strSQL = strSQL + " AND BL_MA = '2'"
                strSQL = strSQL + " GROUP BY B_PCCM "
                strSQL = strSQL + " ORDER BY B_PCCM "
            Else
                strSQL = (" SELECT B_PCCM ")
                strSQL = strSQL + " FROM IT_BAC"
                strSQL = strSQL + " WHERE LEFT(N_MA,1) = '2'"
                strSQL = strSQL + " AND BL_MA = '2'"
                strSQL = strSQL + " GROUP BY B_PCCM "
                strSQL = strSQL + " ORDER BY B_PCCM "
            End If
        End If

        If obj.ChonBang = 20 Then
            If Me.QuoteString(obj.NGACH) <= 2 Then
                strSQL = (" SELECT B_PCCM ")
                strSQL = strSQL + " FROM IT_BAC"
                strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
                strSQL = strSQL + " AND BL_MA = '2'"
                strSQL = strSQL + " AND B_TEN = N'" & Me.QuoteString(obj.BAC) & "'"
                strSQL = strSQL + " GROUP BY B_PCCM "
                strSQL = strSQL + " ORDER BY B_PCCM "
            Else
                strSQL = (" SELECT B_PCCM ")
                strSQL = strSQL + " FROM IT_BAC"
                strSQL = strSQL + " WHERE LEFT(N_MA,1) = '2'"
                strSQL = strSQL + " AND BL_MA = '2'"
                strSQL = strSQL + " AND B_TEN = N'" & Me.QuoteString(obj.BAC) & "'"
                strSQL = strSQL + " GROUP BY B_PCCM "
                strSQL = strSQL + " ORDER BY B_PCCM "
            End If
        End If
        If obj.ChonBang = 21 Then
            strSQL = "SELECT JELL_QUYENTRUYCAP.Ma_DM,KHUA = ISNULL(JELL_QUYENTRUYCAP.KHUA,0),KHUB =  ISNULL(JELL_QUYENTRUYCAP.KHUB,0)  "
            strSQL = strSQL + " FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM "
            strSQL = strSQL + " WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.NGUOIDUNG + "' and JELL_DANHMUC.Ma_DM = '" + obj.MA_DM + "'"
        End If

        If obj.ChonBang = 222 Then
            strSQL = " EXEC SP_LOAD_OP_5NGAY_S '" & obj.tungay & "','" & obj.denngay & "'"
        End If

        If obj.ChonBang = 25 Then
            strSQL = " SELECT A.DV_MA,DV_MA_,A.NV_MA,NV_TEN,NV_NGAYVAO,NGAYBATDAUNGHI,SONGAYDANGHI  "
            strSQL = strSQL + " FROM ST_NHANVIEN AS A INNER JOIN  "
            strSQL = strSQL + " (  "
            strSQL = strSQL + " SELECT  NV_MA,MIN(QT_NGAY)AS NGAYBATDAUNGHI,ROUND(SUM(CC_SOGIONGHI)/8,1) AS  SONGAYDANGHI  "
            strSQL = strSQL + " FROM ST_GIOQUETTHE  "
            strSQL = strSQL + " WHERE QT_NGAY BETWEEN '" & obj.tungay & "' AND '" & obj.denngay & "'  "
            strSQL = strSQL + " AND NP_MA = 'O'  "
            strSQL = strSQL + " AND NV_MA IN(SELECT NV_MA FROM ST_NHANVIEN WHERE NV_NGAYVAO >= '" & obj.tungay & " ')  "
            strSQL = strSQL + " GROUP BY NV_MA  "
            strSQL = strSQL + " ) AS B ON A.NV_MA = B.NV_MA  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON A.DV_MA = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE A.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
            strSQL = strSQL + " AND A.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG WHERE HD_NGAYKY IS NOT NULL) "
            strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1 "
            strSQL = strSQL + " ORDER BY A.NV_MA   "
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
    Public Function InsertInfo(ByVal obj As objHDLD) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into ST_HOPDONGLAODONG([NV_Ma],[HD_So],[L_Ma],[HD_NgayKy],[HD_NgayHetHan],[BANGL],[TENBANGLUONG],[TENNGACH],[NGACH],[BAC],[BL_MA],[HD_LuongCB],[HD_HeSo],[HD_PhuCapkhac],[HD_DongBHYT],[HD_DongBHXH],[HD_DongBHTN],[HD_CongviecDH],[TCCM_VPX],[TCCBTS],[TCCBVP],[TCBBNT],[TCBBHT],[TCBBTHANG],[HD_TCCHAMLOGIADINH],[HD_TCHOTRODONGPHUC],[HD_TroCapQAQIP],[HD_TrocapThoRap],[HD_TrocapHSE],[HD_TrocapCV],[HD_TrocapUD],[HD_TrocapCMNV],[HD_TrocapNN],[HD_TrocapHMPT],[HD_TROCAPMOITRUONG], [HD_BAC1], [HD_BAC2], [HD_BAC3],[HD_KHONGHUONGCHUYENCAN],[HD_Luongtoithieu],[HD_PHUCLOI],[HD_HTNG],[HD_DQTV],[HD_PCCC]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.SOHD) & "',N'" & Me.QuoteString(obj.MAHD) & "',N'" & Me.QuoteString(obj.NGAYKY) & "'," + obj.NGAYHETHAN + ",N'" & Me.QuoteString(obj.MABAC) & "',N'" & Me.QuoteString(obj.TENBANGL) & "',N'" & Me.QuoteString(obj.TENNGACH) & "',N'" & Me.QuoteString(obj.NGACH) & "',N'" & Me.QuoteString(obj.BAC) & "',N'" & Me.QuoteString(obj.BACLUU) & "',N'" & Me.QuoteString(obj.LUONGCOBAN) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.PHUCAPKHAC) & "',N'" & Me.QuoteString(obj.BHYT) & "',N'" & Me.QuoteString(obj.BHXH) & "',N'" & Me.QuoteString(obj.BHTN) & "',N'" & Me.QuoteString(obj.DOCHAI) & "',N'" & Me.QuoteString(obj.TCCM_VPX) & "',N'" & Me.QuoteString(obj.CBTS) & "',N'" & Me.QuoteString(obj.CBVP) & "',N'" & Me.QuoteString(obj.BBNT) & "',N'" & Me.QuoteString(obj.BBHT) & "',N'" & Me.QuoteString(obj.BBT) & "',N'" & Me.QuoteString(obj.HD_TCCHAMLOGIADINH) & "',N'" & Me.QuoteString(obj.HD_TCHOTRODONGPHUC) & "',N'" & Me.QuoteString(obj.HD_TroCapQAQIP) & "',N'" & Me.QuoteString(obj.HD_TrocapThoRap) & "',N'" & Me.QuoteString(obj.HD_TrocapHSE) & "',N'" & Me.QuoteString(obj.TCCONGVIEC) & "',N'" & Me.QuoteString(obj.TCUUDAI) & "',N'" & Me.QuoteString(obj.TCCHUYENMON) & "',N'" & Me.QuoteString(obj.TCNN) & "',N'" & Me.QuoteString(obj.TCHAOMON) & "',N'" & Me.QuoteString(obj.TCMT) & "',N'" & Me.QuoteString(obj.BAC1) & "',N'" & Me.QuoteString(obj.BAC2) & "',N'" & Me.QuoteString(obj.BAC3) & "',N'" & Me.QuoteString(obj.KHONGHUONGCC) & "',N'" & Me.QuoteString(obj.LUONGTOITHIEU) & "',N'" & Me.QuoteString(obj.HD_PHUCLOI) & "',N'" & Me.QuoteString(obj.HD_HTNG) & "',N'" & Me.QuoteString(obj.HD_DQTV) & "',N'" & Me.QuoteString(obj.HD_PCCC) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objHDLD) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objHDLD) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            strSQL = ("update ST_HOPDONGLAODONG set HD_SO=N'" & Me.QuoteString(obj.SOHD) & "',L_Ma=N'" & Me.QuoteString(obj.MAHD) & "',HD_NgayKy=N'" & Me.QuoteString(obj.NGAYKY) & "',HD_NgayHetHan=" + obj.NGAYHETHAN + ",BANGL=N'" & Me.QuoteString(obj.MABAC) & "',TENBANGLUONG=N'" & Me.QuoteString(obj.TENBANGL) & "',TENNGACH=N'" & Me.QuoteString(obj.TENNGACH) & "',NGACH=N'" & Me.QuoteString(obj.NGACH) & "',BAC=N'" & Me.QuoteString(obj.BAC) & "',BL_MA=N'" & Me.QuoteString(obj.BACLUU) & "',HD_LuongCB=N'" & Me.QuoteString(obj.LUONGCOBAN) & "',HD_HeSo=N'" & Me.QuoteString(obj.HESO) & "',HD_PhuCapkhac=N'" & Me.QuoteString(obj.PHUCAPKHAC) & "',HD_DongBHYT=N'" & Me.QuoteString(obj.BHYT) & "',HD_DongBHXH=N'" & Me.QuoteString(obj.BHXH) & "',HD_DongBHTN=N'" & Me.QuoteString(obj.BHTN) & "',HD_CongviecDH=N'" & Me.QuoteString(obj.DOCHAI) & "',TCCM_VPX=N'" & Me.QuoteString(obj.TCCM_VPX) & "',TCCBTS=N'" & Me.QuoteString(obj.CBTS) & "',TCCBVP=N'" & Me.QuoteString(obj.CBVP) & "',TCBBNT=N'" & Me.QuoteString(obj.BBNT) & "',TCBBHT=N'" & Me.QuoteString(obj.BBHT) & "',TCBBTHANG=N'" & Me.QuoteString(obj.BBT) & "',HD_TCCHAMLOGIADINH=N'" & Me.QuoteString(obj.HD_TCCHAMLOGIADINH) & "',HD_TCHOTRODONGPHUC=N'" & Me.QuoteString(obj.HD_TCHOTRODONGPHUC) & "',HD_TroCapQAQIP=N'" & Me.QuoteString(obj.HD_TroCapQAQIP) & "',HD_TrocapThoRap=N'" & Me.QuoteString(obj.HD_TrocapThoRap) & "',HD_TrocapHSE=N'" & Me.QuoteString(obj.HD_TrocapHSE) & "',HD_TrocapCV=N'" & Me.QuoteString(obj.TCCONGVIEC) & "',HD_TrocapUD=N'" & Me.QuoteString(obj.TCUUDAI) & "',HD_TrocapCMNV=N'" & Me.QuoteString(obj.TCCHUYENMON) & "',HD_TrocapNN=N'" & Me.QuoteString(obj.TCNN) & "',HD_TrocapHMPT=N'" & Me.QuoteString(obj.TCHAOMON) & "',HD_TROCAPMOITRUONG=N'" & Me.QuoteString(obj.TCMT) & "',HD_BAC1=N'" & Me.QuoteString(obj.BAC1) & "',HD_BAC2=N'" & Me.QuoteString(obj.BAC2) & "',HD_BAC3=N'" & Me.QuoteString(obj.BAC3) & "',HD_KHONGHUONGCHUYENCAN=N'" & Me.QuoteString(obj.KHONGHUONGCC) & "',HD_Luongtoithieu=N'" & Me.QuoteString(obj.LUONGTOITHIEU) & "',HD_LYDOGIAHAN=N'" & Me.QuoteString(obj.LYDOGIAHAN) & "',HD_GIAHAN=N'" & Me.QuoteString(obj.GIAHAN) & "',HD_NGAYBATDAUGIAHAN=" + obj.NGAYBDGIAHAN + " ,HD_NGAYKETTHUCGIAHAN=" + obj.NGAYKTGIAHAN + ",HD_NGUOICAPNHAT= N'" & Me.QuoteString(obj.NGUOICN) & "',HD_NGAYCAPNHAT=N'" & Me.QuoteString(obj.NGAYCN) & "',HD_PHUCLOI=N'" & Me.QuoteString(obj.HD_PHUCLOI) & "',HD_HTNG=N'" & Me.QuoteString(obj.HD_HTNG) & "',HD_DQTV=N'" & Me.QuoteString(obj.HD_DQTV) & "',HD_PCCC=N'" & Me.QuoteString(obj.HD_PCCC) & "' where HD_NGAYKY = N'" & Me.QuoteString(obj.NGAYKYLUOI) & "' AND NV_MA=N'" & Me.QuoteString(obj.MANV) & "'")
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
