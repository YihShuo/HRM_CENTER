Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDChuaKyHDLD
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objChuaKyHDLD) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT STT ='',ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS TENCV,"
            strSQL = strSQL + " ST_CONGVIEC.CV_MA AS MACV,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS TENCVU,"
            strSQL = strSQL + " BBTT = CASE WHEN ST_NHANVIEN.DV_MA LIKE 'VP%' THEN ST_BINHBAUTHANG.BB_TRUOC ELSE '' END,"
            strSQL = strSQL + " BBA = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'A' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBB = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'B' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBC = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'C' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BB_SoNgayRO AS RO,"
            strSQL = strSQL + " BB_SoNgayO AS OM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HESO AS HESO,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.L_COBAN AS LUONGCB,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.LUONGTOITHIEU AS LUONGTOITHIEU,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CV AS TCCV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBVP AS CBVP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBTS AS CBTS,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBNT AS BBNT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBHT AS BBHT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBTHANG AS BBTHANG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_KHAC AS TCKHAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CM AS TCCM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_HM AS TCHM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TroCapQAQIP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapThoRap,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapHSE,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_UD AS TCUD,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_NN AS TCNN,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PHUCLOI AS PHUCLOI,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_HTNG AS HTNG,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_DQTV AS DQTV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PCCC AS PCCC,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BANGL AS BANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NGACH AS NGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BAC AS BAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BL AS BL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CHONBL AS CHONBL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHXH AS BHXH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHYT AS BHYT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHTN AS BHTN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CV_DH AS CVDH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TUNGAY AS TUNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.DENNGAY AS DENNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC1 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC2 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC3 "
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_BINHBAUTHANG ON ST_NHANVIEN.NV_MA = ST_BINHBAUTHANG.NV_MA "
            strSQL = strSQL + " AND LEFT(ST_BINHBAUTHANG.T_MA, 2)= MONTH('" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " LEFT JOIN Q_CBCNVCHUAKYHDLD ON ST_NHANVIEN.NV_MA = Q_CBCNVCHUAKYHDLD.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE(ST_NHANVIEN.NV_DAKYHDLD = 0 OR ST_NHANVIEN.NV_DAKYHDLD IS NULL)"
            strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_NGAYVAO < '" & Me.QuoteString(obj.NGAY) & "'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)"
        End If

        If obj.ChonBang = 19 Then
            strSQL = ("SELECT STT ='',ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS TENCV,"
            strSQL = strSQL + " ST_CONGVIEC.CV_MA AS MACV,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS TENCVU,"
            strSQL = strSQL + " BBTT = CASE WHEN ST_NHANVIEN.DV_MA LIKE 'VP%' THEN ST_BINHBAUTHANG.BB_TRUOC ELSE '' END,"
            strSQL = strSQL + " BBA = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'A' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBB = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'B' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBC = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'C' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BB_SoNgayRO AS RO,"
            strSQL = strSQL + " BB_SoNgayO AS OM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HESO AS HESO,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.L_COBAN AS LUONGCB,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.LUONGTOITHIEU AS LUONGTOITHIEU,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CV AS TCCV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBVP AS CBVP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBTS AS CBTS,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBNT AS BBNT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBHT AS BBHT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBTHANG AS BBTHANG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_KHAC AS TCKHAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CM AS TCCM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_HM AS TCHM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TroCapQAQIP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapThoRap,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapHSE,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_UD AS TCUD,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_NN AS TCNN,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PHUCLOI AS PHUCLOI,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_HTNG AS HTNG,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_DQTV AS DQTV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PCCC AS PCCC,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BANGL AS BANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NGACH AS NGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BAC AS BAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BL AS BL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CHONBL AS CHONBL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHXH AS BHXH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHYT AS BHYT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHTN AS BHTN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CV_DH AS CVDH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TUNGAY AS TUNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.DENNGAY AS DENNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC1 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC2 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC3 "
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_BINHBAUTHANG ON ST_NHANVIEN.NV_MA = ST_BINHBAUTHANG.NV_MA "
            strSQL = strSQL + " AND LEFT(ST_BINHBAUTHANG.T_MA, 2)= MONTH('" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " LEFT JOIN Q_CBCNVCHUAKYHDLD ON ST_NHANVIEN.NV_MA = Q_CBCNVCHUAKYHDLD.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE(ST_NHANVIEN.NV_DAKYHDLD = 0 OR ST_NHANVIEN.NV_DAKYHDLD IS NULL)"
            strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_NGAYVAO < '" & Me.QuoteString(obj.NGAY) & "'"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('CONGDOAN')"
            strSQL = strSQL + " AND ST_DONVI.KHU = 'A'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)"
        End If
        If obj.ChonBang = 20 Then
            strSQL = ("SELECT STT ='',ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS TENCV,"
            strSQL = strSQL + " ST_CONGVIEC.CV_MA AS MACV,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS TENCVU,"
            strSQL = strSQL + " BBTT = CASE WHEN ST_NHANVIEN.DV_MA LIKE 'VP%' THEN ST_BINHBAUTHANG.BB_TRUOC ELSE '' END,"
            strSQL = strSQL + " BBA = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'A' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBB = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'B' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BBC = CASE WHEN ST_BINHBAUTHANG.BB_MA = 'C' THEN ST_BINHBAUTHANG.BB_MA ELSE '' END,"
            strSQL = strSQL + " BB_SoNgayRO AS RO,"
            strSQL = strSQL + " BB_SoNgayO AS OM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HESO AS HESO,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.L_COBAN AS LUONGCB,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.LUONGTOITHIEU AS LUONGTOITHIEU,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CV AS TCCV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBVP AS CBVP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCCBTS AS CBTS,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBNT AS BBNT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBHT AS BBHT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TCBBTHANG AS BBTHANG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_KHAC AS TCKHAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_CM AS TCCM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_HM AS TCHM,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TroCapQAQIP,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapThoRap,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TrocapHSE,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_UD AS TCUD,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TC_NN AS TCNN,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PHUCLOI AS PHUCLOI,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_HTNG AS HTNG,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_DQTV AS DQTV,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_PCCC AS PCCC,"

            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BANGL AS BANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENBANGLUONG AS TENBANGL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TENNGACH AS TENNGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NGACH AS NGACH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BAC AS BAC,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BL AS BL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CHONBL AS CHONBL,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHXH AS BHXH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHYT AS BHYT,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.BHTN AS BHTN,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.CV_DH AS CVDH,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.TUNGAY AS TUNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.DENNGAY AS DENNGAY,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC1 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC2 ,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.HD_BAC3 "
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_BINHBAUTHANG ON ST_NHANVIEN.NV_MA = ST_BINHBAUTHANG.NV_MA "
            strSQL = strSQL + " AND LEFT(ST_BINHBAUTHANG.T_MA, 2)= MONTH('" & Me.QuoteString(obj.NGAY) & "')"
            strSQL = strSQL + " LEFT JOIN Q_CBCNVCHUAKYHDLD ON ST_NHANVIEN.NV_MA = Q_CBCNVCHUAKYHDLD.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE(ST_NHANVIEN.NV_DAKYHDLD = 0 OR ST_NHANVIEN.NV_DAKYHDLD IS NULL)"
            strSQL = strSQL + " AND ST_DONVI.DV_TV <> 1"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_NGAYVAO < '" & Me.QuoteString(obj.NGAY) & "'"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('CONGDOAN')"
            strSQL = strSQL + " AND ST_DONVI.KHU = 'B'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)"
        End If


        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_MA FROM Q_CBCNVCHUAKYHDLD WHERE NV_MA ='" & Me.QuoteString(obj.MANV) & "'")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("INSERT INTO ST_HOPDONGLAODONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " HD_So,"
            strSQL = strSQL + " L_MA,"
            strSQL = strSQL + " HD_NgayKy,"
            strSQL = strSQL + " HD_NgayHetHan,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL_MA,"
            strSQL = strSQL + " HD_LuongCB,"
            strSQL = strSQL + " HD_HeSo,"
            strSQL = strSQL + " HD_PhuCapkhac,"
            strSQL = strSQL + " HD_DongBHXH,"
            strSQL = strSQL + " HD_DongBHYT,"
            strSQL = strSQL + " HD_DongBHTN,"
            strSQL = strSQL + " HD_CongviecDH,"
            strSQL = strSQL + " HD_TrocapCV,"
            strSQL = strSQL + " HD_TrocapUD,"
            strSQL = strSQL + " HD_TrocapCMNV,"
            strSQL = strSQL + " HD_TrocapNN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " HD_TrocapHMPT,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " HD_Luongtoithieu,"
            strSQL = strSQL + " HD_PHUCLOI,"
            strSQL = strSQL + " HD_HTNG,"
            strSQL = strSQL + " HD_DQTV,"
            strSQL = strSQL + " HD_PCCC"

            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT "
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " L_MA='1',"
            strSQL = strSQL + " TUNGAY,"
            strSQL = strSQL + " DENNGAY,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL,"
            strSQL = strSQL + " L_COBAN,"
            strSQL = strSQL + " HESO,"
            strSQL = strSQL + " TC_KHAC,"
            strSQL = strSQL + " BHXH,"
            strSQL = strSQL + " BHYT,"
            strSQL = strSQL + " BHTN,"
            strSQL = strSQL + " CV_DH,"
            strSQL = strSQL + " TC_CV,"
            strSQL = strSQL + " TC_UD,"
            strSQL = strSQL + " TC_CM,"
            strSQL = strSQL + " TC_NN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " TC_HM,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " LUONGTOITHIEU,"
            strSQL = strSQL + " HD_PHUCLOI,"
            strSQL = strSQL + " HD_HTNG,"
            strSQL = strSQL + " HD_DQTV,"
            strSQL = strSQL + " HD_PCCC"
            strSQL = strSQL + " FROM Q_CBCNVCHUAKYHDLD"
            strSQL = strSQL + " WHERE Q_CBCNVCHUAKYHDLD.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)"
        End If
        If obj.ChonBang = 34 Then
            strSQL = ("INSERT INTO ST_HOPDONGLAODONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " HD_So,"
            strSQL = strSQL + " L_MA,"
            strSQL = strSQL + " HD_NgayKy,"
            strSQL = strSQL + " HD_NgayHetHan,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL_MA,"
            strSQL = strSQL + " HD_LuongCB,"
            strSQL = strSQL + " HD_HeSo,"
            strSQL = strSQL + " HD_PhuCapkhac,"
            strSQL = strSQL + " HD_DongBHXH,"
            strSQL = strSQL + " HD_DongBHYT,"
            strSQL = strSQL + " HD_DongBHTN,"
            strSQL = strSQL + " HD_CongviecDH,"
            strSQL = strSQL + " HD_TrocapCV,"
            strSQL = strSQL + " HD_TrocapUD,"
            strSQL = strSQL + " HD_TrocapCMNV,"
            strSQL = strSQL + " HD_TrocapNN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " HD_TrocapHMPT,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " HD_Luongtoithieu, HD_PHUCLOI,HD_HTNG,HD_DQTV,HD_PCCC,HD_NGAYTAO, HD_NGUOITAO"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT "
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NV_MA,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NV_MA,"
            strSQL = strSQL + " L_MA='1',"
            strSQL = strSQL + " TUNGAY,"
            strSQL = strSQL + " DENNGAY,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL,"
            strSQL = strSQL + " L_COBAN,"
            strSQL = strSQL + " HESO,"
            strSQL = strSQL + " TC_KHAC,"
            strSQL = strSQL + " BHXH,"
            strSQL = strSQL + " BHYT,"
            strSQL = strSQL + " BHTN,"
            strSQL = strSQL + " CV_DH,"
            strSQL = strSQL + " TC_CV,"
            strSQL = strSQL + " TC_UD,"
            strSQL = strSQL + " TC_CM,"
            strSQL = strSQL + " TC_NN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " TC_HM,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " LUONGTOITHIEU,"
            strSQL = strSQL + " HD_PHUCLOI, "
            strSQL = strSQL + " HD_HTNG, "
            strSQL = strSQL + " HD_DQTV, "
            strSQL = strSQL + " HD_PCCC, "
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "'"
            strSQL = strSQL + " FROM Q_CBCNVCHUAKYHDLD  INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma = Q_CBCNVCHUAKYHDLD.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE Q_CBCNVCHUAKYHDLD.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG) AND ST_DONVI.KHU = 'A'"
        End If
        If obj.ChonBang = 35 Then
            strSQL = ("INSERT INTO ST_HOPDONGLAODONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " HD_So,"
            strSQL = strSQL + " L_MA,"
            strSQL = strSQL + " HD_NgayKy,"
            strSQL = strSQL + " HD_NgayHetHan,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL_MA,"
            strSQL = strSQL + " HD_LuongCB,"
            strSQL = strSQL + " HD_HeSo,"
            strSQL = strSQL + " HD_PhuCapkhac,"
            strSQL = strSQL + " HD_DongBHXH,"
            strSQL = strSQL + " HD_DongBHYT,"
            strSQL = strSQL + " HD_DongBHTN,"
            strSQL = strSQL + " HD_CongviecDH,"
            strSQL = strSQL + " HD_TrocapCV,"
            strSQL = strSQL + " HD_TrocapUD,"
            strSQL = strSQL + " HD_TrocapCMNV,"
            strSQL = strSQL + " HD_TrocapNN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " HD_TrocapHMPT,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " HD_Luongtoithieu,HD_PHUCLOI,HD_HTNG,HD_DQTV,HD_PCCC, HD_NGAYTAO, HD_NGUOITAO"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT "
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NV_MA,"
            strSQL = strSQL + " Q_CBCNVCHUAKYHDLD.NV_MA,"
            strSQL = strSQL + " L_MA='1',"
            strSQL = strSQL + " TUNGAY,"
            strSQL = strSQL + " DENNGAY,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL,"
            strSQL = strSQL + " L_COBAN,"
            strSQL = strSQL + " HESO,"
            strSQL = strSQL + " TC_KHAC,"
            strSQL = strSQL + " BHXH,"
            strSQL = strSQL + " BHYT,"
            strSQL = strSQL + " BHTN,"
            strSQL = strSQL + " CV_DH,"
            strSQL = strSQL + " TC_CV,"
            strSQL = strSQL + " TC_UD,"
            strSQL = strSQL + " TC_CM,"
            strSQL = strSQL + " TC_NN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " TC_HM,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " LUONGTOITHIEU,"
            strSQL = strSQL + " HD_PHUCLOI, "
            strSQL = strSQL + " HD_HTNG, "
            strSQL = strSQL + " HD_DQTV, "
            strSQL = strSQL + " HD_PCCC, "
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "'"
            strSQL = strSQL + " FROM Q_CBCNVCHUAKYHDLD  INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma = Q_CBCNVCHUAKYHDLD.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA AND DV_LocBB = 0 "
            strSQL = strSQL + " WHERE Q_CBCNVCHUAKYHDLD.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG) AND ST_DONVI.KHU = 'B'"
        End If
        If obj.ChonBang = 33 Then
            strSQL = ("INSERT INTO ST_HOPDONGLAODONG")
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " HD_So,"
            strSQL = strSQL + " L_MA,"
            strSQL = strSQL + " HD_NgayKy,"
            strSQL = strSQL + " HD_NgayHetHan,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL_MA,"
            strSQL = strSQL + " HD_LuongCB,"
            strSQL = strSQL + " HD_HeSo,"
            strSQL = strSQL + " HD_PhuCapkhac,"
            strSQL = strSQL + " HD_DongBHXH,"
            strSQL = strSQL + " HD_DongBHYT,"
            strSQL = strSQL + " HD_DongBHTN,"
            strSQL = strSQL + " HD_CongviecDH,"
            strSQL = strSQL + " HD_TrocapCV,"
            strSQL = strSQL + " HD_TrocapUD,"
            strSQL = strSQL + " HD_TrocapCMNV,"
            strSQL = strSQL + " HD_TrocapNN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " HD_TrocapHMPT,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " HD_Luongtoithieu,HD_PHUCLOI, HD_HTNG,HD_DQTV,HD_PCCC, HD_NGAYTAO, HD_NGUOITAO"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT "
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " L_MA='1',"
            strSQL = strSQL + " TUNGAY,"
            strSQL = strSQL + " DENNGAY,"
            strSQL = strSQL + " BB_TT,"
            strSQL = strSQL + " BB_A,"
            strSQL = strSQL + " BB_B,"
            strSQL = strSQL + " BB_C,"
            strSQL = strSQL + " RO,"
            strSQL = strSQL + " OM,"
            strSQL = strSQL + " BANGL,"
            strSQL = strSQL + " TENBANGLUONG,"
            strSQL = strSQL + " TENNGACH,"
            strSQL = strSQL + " NGACH,"
            strSQL = strSQL + " BAC,"
            strSQL = strSQL + " BL,"
            strSQL = strSQL + " L_COBAN,"
            strSQL = strSQL + " HESO,"
            strSQL = strSQL + " TC_KHAC,"
            strSQL = strSQL + " BHXH,"
            strSQL = strSQL + " BHYT,"
            strSQL = strSQL + " BHTN,"
            strSQL = strSQL + " CV_DH,"
            strSQL = strSQL + " TC_CV,"
            strSQL = strSQL + " TC_UD,"
            strSQL = strSQL + " TC_CM,"
            strSQL = strSQL + " TC_NN,"
            strSQL = strSQL + " TCCBVP,"
            strSQL = strSQL + " TCCBTS,"
            strSQL = strSQL + " TCBBNT,"
            strSQL = strSQL + " TCBBHT,"
            strSQL = strSQL + " TCBBTHANG,"
            strSQL = strSQL + " TC_HM,"
            strSQL = strSQL + " HD_TroCapQAQIP,"
            strSQL = strSQL + " HD_TrocapThoRap,"
            strSQL = strSQL + " HD_TrocapHSE,"
            strSQL = strSQL + " HD_TCHOTRODONGPHUC,"
            strSQL = strSQL + " HD_TCCHAMLOGIADINH,"
            strSQL = strSQL + " HD_TROCAPMOITRUONG,"
            strSQL = strSQL + " HD_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + " HD_BAC1,"
            strSQL = strSQL + " HD_BAC2,"
            strSQL = strSQL + " HD_BAC3,"
            strSQL = strSQL + " LUONGTOITHIEU,"
            strSQL = strSQL + " HD_PHUCLOI,"
            strSQL = strSQL + " HD_HTNG,"
            strSQL = strSQL + " HD_DQTV, "
            strSQL = strSQL + " HD_PCCC, "
            strSQL = strSQL + "'" + obj.NGAYTAO + "',"
            strSQL = strSQL + "N'" + obj.NGUOITAO + "'"
            strSQL = strSQL + " FROM Q_CBCNVCHUAKYHDLD"
            strSQL = strSQL + " WHERE Q_CBCNVCHUAKYHDLD.NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)"
            strSQL = strSQL + " AND Q_CBCNVCHUAKYHDLD.NV_MA = '" & Me.QuoteString(obj.MANV) & "' "
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
            strSQL = (" SELECT BAC = IT_BAC.B_TEN, B_PCCM, B_MUCLUONG, B_PCDONGPHUC")
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA = IT_BAC.B_MA "
            strSQL = strSQL + " AND IT_BANGLUONG.BL_TEN = IT_BAC.B_TEN"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA='" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND LEFT(IT_BAC.N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT BANGLUONG = IT_BAC.BL_MA, ")
            strSQL = strSQL + " TENBANGLUONG = IT_BANGLUONG.BL_TEN"
            strSQL = strSQL + " FROM IT_BAC INNER JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA =IT_BAC.BL_MA "
            strSQL = strSQL + " WHERE B_HSLUONG = " & Me.QuoteString(obj.HESO) & " "
            strSQL = strSQL + " GROUP BY IT_BAC.BL_MA,"
            strSQL = strSQL + " IT_BANGLUONG.BL_TEN"
        End If

        If obj.ChonBang = 9 Then
            strSQL = ("SELECT NGACH = LEFT(IT_BAC.N_MA,1),")
            strSQL = strSQL + " TENNGACH = IT_NGACH.N_TEN"
            strSQL = strSQL + " FROM IT_BAC INNER JOIN IT_NGACH ON IT_BAC.N_MA = IT_NGACH.N_MA"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA = '" & Me.QuoteString(obj.MABAC) & "'"
        End If

        If obj.ChonBang = 10 Then
            strSQL = (" SELECT BAC = IT_BAC.B_TEN")
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA = IT_BAC.B_MA "
            strSQL = strSQL + " AND IT_BANGLUONG.BL_TEN = IT_BAC.B_TEN"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA='" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND LEFT(IT_BAC.N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
        End If

        If obj.ChonBang = 11 Then
            strSQL = (" SELECT * FROM IT_BANGLUONG WHERE BL_MA = '" & Me.QuoteString(obj.MABAC) & "'")
        End If

        If obj.ChonBang = 12 Then
            strSQL = (" SELECT *  FROM IT_NGACH  WHERE BL_MA = '" & Me.QuoteString(obj.MABAC) & "' AND LEFT(N_MA,1) ='" & Me.QuoteString(obj.NGACH) & "' ")
        End If

        If obj.ChonBang = 13 Then
            strSQL = ("SELECT BAC = B_MA")
            strSQL = strSQL + " FROM IT_BAC"
            strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
            strSQL = strSQL + " AND BL_MA = '" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND B_TEN =N'" & Me.QuoteString(obj.BAC) & "'"
            strSQL = strSQL + " AND B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
        End If
        'he so
        If obj.ChonBang = 14 Then
            strSQL = (" SELECT NV_MA ")
            strSQL = strSQL + "  FROM Q_CBCNVCHUAKYHDLD "
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
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
            strSQL = (" SELECT BAC = IT_BAC.B_TEN, B_PCCM, B_MUCLUONG, B_PCDONGPHUC")
            strSQL = strSQL + " FROM IT_BAC LEFT JOIN IT_BANGLUONG ON IT_BANGLUONG.BL_MA = IT_BAC.B_MA "
            strSQL = strSQL + " AND IT_BANGLUONG.BL_TEN = IT_BAC.B_TEN"
            strSQL = strSQL + " WHERE B_HSLUONG =" & Me.QuoteString(obj.HESO) & ""
            strSQL = strSQL + " AND IT_BAC.BL_MA='" & Me.QuoteString(obj.MABAC) & "'"
            strSQL = strSQL + " AND LEFT(IT_BAC.N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
        End If
        'he so

        If obj.ChonBang = 18 Then
            strSQL = (" SELECT B_PCCM ")
            strSQL = strSQL + " FROM IT_BAC "
            strSQL = strSQL + " WHERE LEFT(N_MA,1) = '" & Me.QuoteString(obj.NGACH) & "'"
            strSQL = strSQL + " AND BL_MA = '" & Me.QuoteString(obj.MABAC) & "' ORDER BY B_PCCM"
        End If
        If obj.ChonBang = 21 Then
            strSQL = "SELECT JELL_QUYENTRUYCAP.Ma_DM,JELL_QUYENTRUYCAP.KHUA,JELL_QUYENTRUYCAP.KHUB  "
            strSQL = strSQL + " FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM "
            strSQL = strSQL + " WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.NGUOIDUNG + "' and JELL_DANHMUC.Ma_DM = '" + obj.MA_DM + "'"
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
    Public Function InsertInfo(ByVal obj As objChuaKyHDLD) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into Q_CBCNVCHUAKYHDLD([NV_MA],[NV_TEN],[NV_NGAYVAO],[CV_MA],[BB_TT],[BB_A],[BB_B],[BB_C],[RO],[OM],[HESO],[L_COBAN],[LUONGTOITHIEU],[TCCBVP],[TCCBTS],[TCBBNT],[TCBBHT],[TCBBTHANG],[TC_CV],[TC_KHAC],[TC_CM],[TC_HM],[HD_TroCapQAQIP],[HD_TrocapThoRap],[HD_TrocapHSE],[HD_TCHOTRODONGPHUC],[HD_TCCHAMLOGIADINH],[HD_TROCAPMOITRUONG],[HD_KHONGHUONGCHUYENCAN],[TC_UD],[TC_NN],[BANGL],[TENBANGLUONG],[TENNGACH],[NGACH],[BAC],[BL],[BHXH],[BHYT], [BHTN],[CV_DH],[TUNGAY],[DENNGAY],[HD_BAC1],[HD_BAC2],[HD_BAC3],[HD_NGUOITAO],[HD_NGAYTAO],[HD_PHUCLOI],[HD_HTNG],[HD_DQTV],[HD_PCCC]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.TENNV) & "','" & Me.QuoteString(obj.NGAYVAO) & "',N'" & Me.QuoteString(obj.CV) & "',N'" & Me.QuoteString(obj.BB_TT) & "',N'" & Me.QuoteString(obj.BB_A) & "',N'" & Me.QuoteString(obj.BB_B) & "',N'" & Me.QuoteString(obj.BB_C) & "',N'" & Me.QuoteString(obj.RO) & "',N'" & Me.QuoteString(obj.OM) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.LUONGCOBAN) & "',N'" & Me.QuoteString(obj.LUONGTOITHIEU) & "',N'" & Me.QuoteString(obj.CBVP) & "',N'" & Me.QuoteString(obj.CBTS) & "',N'" & Me.QuoteString(obj.BBNT) & "',N'" & Me.QuoteString(obj.BBHT) & "',N'" & Me.QuoteString(obj.BBTh) & "',N'" & Me.QuoteString(obj.TCCONGVIEC) & "',N'" & Me.QuoteString(obj.PHUCAPKHAC) & "',N'" & Me.QuoteString(obj.TCCHUYENMON) & "',N'" & Me.QuoteString(obj.TCHAOMON) & "',N'" & Me.QuoteString(obj.HD_TroCapQAQIP) & "',N'" & Me.QuoteString(obj.HD_TrocapThoRap) & "',N'" & Me.QuoteString(obj.HD_TrocapHSE) & "',N'" & Me.QuoteString(obj.HD_TCHOTRODONGPHUC) & "',N'" & Me.QuoteString(obj.HD_TCCHAMLOGIADINH) & "',N'" & Me.QuoteString(obj.TCMT) & "',N'" & Me.QuoteString(obj.KHONGHUONGCC) & "',N'" & Me.QuoteString(obj.TCUUDAI) & "',N'" & Me.QuoteString(obj.TCNN) & "',N'" & Me.QuoteString(obj.MABAC) & "',N'" & Me.QuoteString(obj.TENBANGL) & "',N'" & Me.QuoteString(obj.TENNGACH) & "',N'" & Me.QuoteString(obj.NGACH) & "',N'" & Me.QuoteString(obj.BAC) & "',N'" & Me.QuoteString(obj.BACLUU) & "',N'" & Me.QuoteString(obj.BHXH) & "',N'" & Me.QuoteString(obj.BHYT) & "',N'" & Me.QuoteString(obj.BHTN) & "',N'" & Me.QuoteString(obj.DOCHAI) & "','" & Me.QuoteString(obj.TUNGAY) & "','" & Me.QuoteString(obj.DENNGAY) & "',N'" & Me.QuoteString(obj.BAC1) & "',N'" & Me.QuoteString(obj.BAC2) & "',N'" & Me.QuoteString(obj.BAC3) & "',N'" & Me.QuoteString(obj.NGUOITAO) & "',N'" & Me.QuoteString(obj.NGAYTAO) & "',N'" & Me.QuoteString(obj.PHUCLOI) & "',N'" & Me.QuoteString(obj.HTNG) & "',N'" & Me.QuoteString(obj.DQTV) & "',N'" & Me.QuoteString(obj.PCCC) & "')")
            'strSQL = ("insert into Q_CBCNVCHUAKYHDLD([NV_MA],[NV_TEN],[NV_NGAYVAO],[CV_MA],[BB_TT],[BB_A],[BB_B],[BB_C],[RO],[OM],[HESO],[L_COBAN],[LUONGTOITHIEU],[TCCBVP],[TCCBTS],[TCBBNT],[TCBBHT],[TCBBTHANG],[TC_CV],[TC_KHAC],[TC_CM],[TC_HM],[HD_TroCapQAQIP],[HD_TrocapThoRap],[HD_TrocapHSE],[HD_TCHOTRODONGPHUC],[HD_TCCHAMLOGIADINH],[HD_TROCAPMOITRUONG],[HD_KHONGHUONGCHUYENCAN],[TC_UD],[TC_NN],[BANGL],[TENBANGLUONG],[TENNGACH],[NGACH],[BAC],[BL],[BHXH],[BHYT], [BHTN],[CV_DH],[TUNGAY],[DENNGAY],[HD_BAC1],[HD_BAC2],[HD_BAC3],[HD_NGUOITAO],[HD_NGAYTAO],[HD_PHUCLOI],[HD_HTNG]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.TENNV) & "','" & Me.QuoteString(obj.NGAYVAO) & "',N'" & Me.QuoteString(obj.CV) & "',N'" & Me.QuoteString(obj.BB_TT) & "',N'" & Me.QuoteString(obj.BB_A) & "',N'" & Me.QuoteString(obj.BB_B) & "',N'" & Me.QuoteString(obj.BB_C) & "',N'" & Me.QuoteString(obj.RO) & "',N'" & Me.QuoteString(obj.OM) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.LUONGCOBAN) & "',N'" & Me.QuoteString(obj.LUONGTOITHIEU) & "',N'" & Me.QuoteString(obj.CBVP) & "',N'" & Me.QuoteString(obj.CBTS) & "',N'" & Me.QuoteString(obj.BBNT) & "',N'" & Me.QuoteString(obj.BBHT) & "',N'" & Me.QuoteString(obj.BBTh) & "',N'" & Me.QuoteString(obj.TCCONGVIEC) & "',N'" & Me.QuoteString(obj.PHUCAPKHAC) & "',N'" & Me.QuoteString(obj.TCCHUYENMON) & "',N'" & Me.QuoteString(obj.TCHAOMON) & "',N'" & Me.QuoteString(obj.HD_TroCapQAQIP) & "',N'" & Me.QuoteString(obj.HD_TrocapThoRap) & "',N'" & Me.QuoteString(obj.HD_TrocapHSE) & "',N'" & Me.QuoteString(obj.HD_TCHOTRODONGPHUC) & "',N'" & Me.QuoteString(obj.HD_TCCHAMLOGIADINH) & "',N'" & Me.QuoteString(obj.TCMT) & "',N'" & Me.QuoteString(obj.KHONGHUONGCC) & "',N'" & Me.QuoteString(obj.TCUUDAI) & "',N'" & Me.QuoteString(obj.TCNN) & "',N'" & Me.QuoteString(obj.MABAC) & "',N'" & Me.QuoteString(obj.TENBANGL) & "',N'" & Me.QuoteString(obj.TENNGACH) & "',N'" & Me.QuoteString(obj.NGACH) & "',N'" & Me.QuoteString(obj.BAC) & "',N'" & Me.QuoteString(obj.BACLUU) & "',N'" & Me.QuoteString(obj.BHXH) & "',N'" & Me.QuoteString(obj.BHYT) & "',N'" & Me.QuoteString(obj.BHTN) & "',N'" & Me.QuoteString(obj.DOCHAI) & "','" & Me.QuoteString(obj.TUNGAY) & "','" & Me.QuoteString(obj.DENNGAY) & "',N'" & Me.QuoteString(obj.BAC1) & "',N'" & Me.QuoteString(obj.BAC2) & "',N'" & Me.QuoteString(obj.BAC3) & "',N'" & Me.QuoteString(obj.NGUOITAO) & "',N'" & Me.QuoteString(obj.NGAYTAO) & "',N'" & Me.QuoteString(obj.PHUCLOI) & "',N'" & Me.QuoteString(obj.HTNG) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objChuaKyHDLD) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from Q_CBCNVCHUAKYHDLD where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'")
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objChuaKyHDLD) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)


        If obj.ChonBang = 1 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update Q_CBCNVCHUAKYHDLD set NV_TEN=N'", Me.QuoteString(obj.TENNV), "',NV_NGAYVAO='", Me.QuoteString(obj.NGAYVAO), "',CV_MA=N'", Me.QuoteString(obj.CV), "',BB_TT=N'", Me.QuoteString(obj.BB_TT), "',BB_A=N'", Me.QuoteString(obj.BB_A), "',BB_B=N'", Me.QuoteString(obj.BB_B), "',BB_C=N'", Me.QuoteString(obj.BB_C), "',RO=N'", Me.QuoteString(obj.RO), "',OM=N'", Me.QuoteString(obj.OM), "',HESO=N'", Me.QuoteString(obj.HESO), "',L_COBAN=N'", Me.QuoteString(obj.LUONGCOBAN), "',LUONGTOITHIEU=N'", Me.QuoteString(obj.LUONGTOITHIEU), "',TCCBVP=N'", Me.QuoteString(obj.CBVP), "',TCCBTS=N'", Me.QuoteString(obj.CBTS), "',TCBBNT=N'", Me.QuoteString(obj.BBNT), "',TCBBHT=N'", Me.QuoteString(obj.BBHT), "',TCBBTHANG=N'", Me.QuoteString(obj.BBTh), "',TC_CV=N'", Me.QuoteString(obj.TCCONGVIEC), "',TC_KHAC=N'", Me.QuoteString(obj.PHUCAPKHAC), "',TC_CM=N'", Me.QuoteString(obj.TCCHUYENMON), "',TC_HM=N'", Me.QuoteString(obj.TCHAOMON), "',HD_TroCapQAQIP=N'", Me.QuoteString(obj.HD_TroCapQAQIP), "',HD_TrocapThoRap=N'", Me.QuoteString(obj.HD_TrocapThoRap), "',HD_TrocapHSE=N'", Me.QuoteString(obj.HD_TrocapHSE), "',HD_TCHOTRODONGPHUC=N'", Me.QuoteString(obj.HD_TCHOTRODONGPHUC), "',HD_TCCHAMLOGIADINH=N'", Me.QuoteString(obj.HD_TCCHAMLOGIADINH), "',HD_TROCAPMOITRUONG = N'", Me.QuoteString(obj.TCMT), "',HD_KHONGHUONGCHUYENCAN = ", Me.QuoteString(obj.KHONGHUONGCC), ",TC_UD=N'", Me.QuoteString(obj.TCUUDAI), "',TC_NN=N'", Me.QuoteString(obj.TCNN), "',HD_PHUCLOI=N'", Me.QuoteString(obj.PHUCLOI), "',HD_HTNG=N'", Me.QuoteString(obj.HTNG), "',HD_DQTV=N'", Me.QuoteString(obj.DQTV), "',HD_PCCC=N'", Me.QuoteString(obj.PCCC), "',BANGL=N'", Me.QuoteString(obj.MABAC), "',TENBANGLUONG=N'", Me.QuoteString(obj.TENBANGL), "',TENNGACH=N'", Me.QuoteString(obj.TENNGACH), "',NGACH=N'", Me.QuoteString(obj.NGACH), "',BAC=N'", Me.QuoteString(obj.BAC), "',BL=N'", Me.QuoteString(obj.BACLUU), "',BHXH=N'", Me.QuoteString(obj.BHXH), "',BHYT=N'", Me.QuoteString(obj.BHYT), "',BHTN=N'", Me.QuoteString(obj.BHTN), "',CV_DH=N'", Me.QuoteString(obj.DOCHAI), "',TUNGAY='", Me.QuoteString(obj.TUNGAY), "',DENNGAY='", Me.QuoteString(obj.DENNGAY), "',HD_BAC1='", Me.QuoteString(obj.BAC1), "',HD_BAC2='", Me.QuoteString(obj.BAC2), "',HD_BAC3='", Me.QuoteString(obj.BAC3), "',HD_NGUOICN='", Me.QuoteString(obj.NGUOICN), "',HD_NGAYCN='", Me.QuoteString(obj.NGAYCN), "'  where NV_MA=N'", Me.QuoteString(obj.MANV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
