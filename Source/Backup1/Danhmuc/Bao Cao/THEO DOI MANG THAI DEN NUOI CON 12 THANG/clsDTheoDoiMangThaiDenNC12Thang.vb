Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTheoDoiMangThaiDenNC12Thang
    Inherits DALSQL
    ' Methods
    Public Shared obj_D As New ObjTheoDoiMangThaiDenNC12Thang
    Public Function LoadDS(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = "SELECT  STT='',"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH"
            strSQL = strSQL + ",BDTHAIT7=IT_PNMT.NGAYVE15H30 ,KTTHAIT7=IT_PNMT.NGAYDUSINH"
            strSQL = strSQL + ",SONGAYT7=(DATEDIFF(DAY,NGAYVE15H30,NGAYDUSINH))"
            strSQL = strSQL + ",BDTS=TUNGAY,KTTS=DENNGAY,SONGAYTS=(DATEDIFF(DAY,TUNGAY,DENNGAY))"
            strSQL = strSQL + ",NGAYSANH"
            strSQL = strSQL + ",BDNC=(CASE WHEN NGAYSANH <> '' THEN (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,KTNC=(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,SONGAYNC=(DATEDIFF(DAY,(CASE WHEN NGAYSANH <> '' THEN "
            strSQL = strSQL + " (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END),(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END))) "
            strSQL = strSQL + "  FROM IT_NUOICONDUOI12THANG LEFT JOIN IT_PNMT "
            strSQL = strSQL + " ON (IT_NUOICONDUOI12THANG.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.SOLANMT = IT_NUOICONDUOI12THANG.SOLAN)"
            strSQL = strSQL + " LEFT JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI12THANG.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT.%' AND CHONSAYTHAI=0"  ''LOAI BO TRUONG HOP SAY THAI
            strSQL = strSQL + " AND (DATEDIFF(MONTH,NGAYMANGTHAI,TUNGAY)) > 0" ''BO NHUNG TRUONG HOP CHUA NHAP NGAY THAI SAN THI NO RA SO THANG TINH TU NGAY MANG THAI DEN THAI SAN LA AM
            ''THU 3 NGUOI
            'strSQL = strSQL + " AND ST_NHANVIEN.NV_MA IN ('00126','00150')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"

        End If
        ''ds tinh cac ngay kham thai sau khi goi thu tuc
        If obj.ChonBang = 2 Then
            ''TAO BANG TAM
            'strSQL = "IF OBJECT_ID(N'tempdb..#QTMANGTHAINC', N'U') IS NOT NULL DROP TABLE #QTMANGTHAINC"
            'strSQL = strSQL + " CREATE TABLE #QTMANGTHAINC( "
            'strSQL = strSQL + "NV_MA NVARCHAR(50)"
            'strSQL = strSQL + ",NV_TEN NVARCHAR(200)"
            'strSQL = strSQL + ",CV_TEN  NVARCHAR(200)"
            'strSQL = strSQL + ",DV_TEN  NVARCHAR(200)"
            'strSQL = strSQL + ",CVU_TEN  NVARCHAR(200)"
            'strSQL = strSQL + ",NV_NGAYVAO  DATETIME"
            'strSQL = strSQL + ",NGAYMANGTHAI DATETIME"
            'strSQL = strSQL + ",LAN1 DATETIME"
            'strSQL = strSQL + ",LAN2 DATETIME"
            'strSQL = strSQL + ",LAN3 DATETIME"
            'strSQL = strSQL + ",LAN4 DATETIME"
            'strSQL = strSQL + ",LAN5 DATETIME"
            'strSQL = strSQL + ",SLCHITRA INT "
            'strSQL = strSQL + ",NGAYVE15H30 DATETIME"
            'strSQL = strSQL + ",NGAYDUSINH  DATETIME"
            'strSQL = strSQL + ",BDTHAIT7 DATETIME"
            'strSQL = strSQL + ",KTTHAIT7 DATETIME"
            'strSQL = strSQL + ",SONGAYT7 INT"
            'strSQL = strSQL + ",BDTS DATETIME"
            'strSQL = strSQL + ",KTTS DATETIME"
            'strSQL = strSQL + ",SONGAYTS INT"
            'strSQL = strSQL + ",NGAYSANH CHAR(10)"
            'strSQL = strSQL + ",BDNC DATETIME"
            'strSQL = strSQL + ",KTNC DATETIME"
            'strSQL = strSQL + ",SONGAYNC INT "
            'strSQL = strSQL + ",LOAICV  NVARCHAR(200)"
            'strSQL = strSQL + ",CTLAN1 BIT DEFAULT 0"
            'strSQL = strSQL + ",CTLAN2 BIT DEFAULT 0"
            'strSQL = strSQL + ",CTLAN3 BIT DEFAULT 0"
            'strSQL = strSQL + ",CTLAN4 BIT DEFAULT 0"
            'strSQL = strSQL + ",CTLAN5 BIT DEFAULT 0"
            'strSQL = strSQL + ",BD_DUONGSUC DATETIME"
            'strSQL = strSQL + ",KT_DUONGSUC DATETIME,SNDS INT"
            'strSQL = strSQL + " ) "
            'strSQL = strSQL + " ON [PRIMARY]"
            'strSQL = strSQL + " INSERT INTO #QTMANGTHAINC "
            'strSQL = strSQL + " (NV_MA ,NV_TEN ,CV_TEN ,DV_TEN ,CVU_TEN  ,NV_NGAYVAO,NGAYMANGTHAI ,LAN1 ,LAN2 ,LAN3 ,LAN4 ,LAN5 ,SLCHITRA,NGAYVE15H30 "
            'strSQL = strSQL + " ,NGAYDUSINH  ,BDTHAIT7,KTTHAIT7,SONGAYT7 ,BDTS ,KTTS ,SONGAYTS ,NGAYSANH ,BDNC ,KTNC ,SONGAYNC ,LOAICV "
            'strSQL = strSQL + " ,CTLAN1 ,CTLAN2 ,CTLAN3 ,CTLAN4 ,CTLAN5  ,BD_DUONGSUC ,KT_DUONGSUC,SNDS ) "

            'strSQL = strSQL + " SELECT *  FROM ("
            'strSQL = strSQL + "SELECT  "
            'strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            'strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            'strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            'strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            'strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            'strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            'strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5,SLCHITRA=0,"
            'strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            'strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH"
            'strSQL = strSQL + ",BDTHAIT7=IT_PNMT.NGAYVE15H30 ,KTTHAIT7=IT_PNMT.NGAYDUSINH"
            'strSQL = strSQL + ",SONGAYT7=(DATEDIFF(DAY,NGAYVE15H30,NGAYDUSINH))"
            'strSQL = strSQL + ",BDTS=TUNGAY,KTTS=DENNGAY,SONGAYTS=(DATEDIFF(DAY,TUNGAY,DENNGAY))"
            'strSQL = strSQL + ",NGAYSANH"
            'strSQL = strSQL + ",BDNC=(CASE WHEN NGAYSANH <> '' THEN (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            'strSQL = strSQL + " ELSE NULL END)"
            'strSQL = strSQL + " ,KTNC=(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            'strSQL = strSQL + " ELSE NULL END)"
            'strSQL = strSQL + " ,SONGAYNC=(DATEDIFF(DAY,(CASE WHEN NGAYSANH <> '' THEN "
            'strSQL = strSQL + " (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            'strSQL = strSQL + " ELSE NULL END),(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            'strSQL = strSQL + " ELSE NULL END))) ,LOAICV=NULL "
            ''TO MAU CHI TRA
            'strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + "	,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "
            ' ''ngay ds
            'strSQL = strSQL + ",BD_DUONGSUC,KT_DUONGSUC,SNDS=(DATEDIFF(DAY,BD_DUONGSUC,KT_DUONGSUC)+1) "
            'strSQL = strSQL + "  FROM IT_NUOICONDUOI12THANG LEFT JOIN IT_PNMT "
            'strSQL = strSQL + " ON (IT_NUOICONDUOI12THANG.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.SOLANMT = IT_NUOICONDUOI12THANG.SOLAN)"
            'strSQL = strSQL + " LEFT JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI12THANG.NV_MA "
            'strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            'strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            'strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            'strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            'strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT.%' AND ISNULL(CHONSAYTHAI,0)=0"  ''LOAI BO TRUONG HOP SAY THAI
            'strSQL = strSQL + " AND (DATEDIFF(MONTH,IT_PNMT.NGAYMANGTHAI,TUNGAY)) > 0" ''BO NHUNG TRUONG HOP CHUA NHAP NGAY THAI SAN THI NO RA SO THANG TINH TU NGAY MANG THAI DEN THAI SAN LA AM
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"

            ' ''LAY VOI LAN MAX
            'strSQL = strSQL + " UNION "
            'strSQL = strSQL + " SELECT  "
            'strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            'strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            'strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            'strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            'strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            'strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            'strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5,SLCHITRA=0,"
            'strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            'strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH"
            'strSQL = strSQL + ",BDTHAIT7=IT_PNMT.NGAYVE15H30 ,KTTHAIT7=IT_PNMT.NGAYDUSINH"
            'strSQL = strSQL + ",SONGAYT7=(DATEDIFF(DAY,NGAYVE15H30,NGAYDUSINH))"
            'strSQL = strSQL + ",BDTS=TUNGAY,KTTS=DENNGAY,SONGAYTS=(DATEDIFF(DAY,TUNGAY,DENNGAY))"
            'strSQL = strSQL + ",NGAYSANH"
            'strSQL = strSQL + ",BDNC=(CASE WHEN NGAYSANH <> '' THEN (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            'strSQL = strSQL + " ELSE NULL END)"
            'strSQL = strSQL + " ,KTNC=(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            'strSQL = strSQL + " ELSE NULL END)"
            'strSQL = strSQL + " ,SONGAYNC=(DATEDIFF(DAY,(CASE WHEN NGAYSANH <> '' THEN "
            'strSQL = strSQL + " (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            'strSQL = strSQL + " ELSE NULL END),(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            'strSQL = strSQL + " ELSE NULL END))) ,LOAICV=NULL "
            ''TO MAU CHI TRA
            'strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + "	,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END)"
            'strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "
            ' ''ngay ds
            'strSQL = strSQL + ",BD_DUONGSUC,KT_DUONGSUC,SNDS=(DATEDIFF(DAY,BD_DUONGSUC,KT_DUONGSUC)+1) "
            'strSQL = strSQL + " FROM (SELECT IT_PNMT.NV_MA,NGAYMANGTHAI=MAX(NGAYMANGTHAI) FROM IT_PNMT  GROUP BY IT_PNMT.NV_MA) AS MT_MAX "
            'strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=MT_MAX.NV_MA "
            'strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            'strSQL = strSQL + " INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA=MT_MAX.NV_MA AND MT_MAX.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI) "
            'strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=MT_MAX.NV_MA AND MT_MAX.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            'strSQL = strSQL + " LEFT JOIN IT_NUOICONDUOI12THANG ON (IT_NUOICONDUOI12THANG.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.SOLANMT = IT_NUOICONDUOI12THANG.SOLAN) "
            'strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            'strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            'strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT.%' AND ISNULL(CHONSAYTHAI,0)=0"
            'strSQL = strSQL + " ) AS V "

            'strSQL = strSQL + " SELECT STT='',NV_MA AS MA,NV_TEN AS TEN,CV_TEN AS CONGVIEC"
            'strSQL = strSQL + " ,DV_TEN AS DONVI,CVU_TEN AS CHUCVU,NV_NGAYVAO AS NGAYVAO,NGAYMANGTHAI AS BDAU_MANGTHAI"
            'strSQL = strSQL + " ,LAN1,LAN2,LAN3,LAN4,LAN5,SLCHITRA,NGAYVE15H30 AS VE_15H30,NGAYDUSINH AS DUSINH"
            'strSQL = strSQL + " ,BDTHAIT7 ,KTTHAIT7,SONGAYT7,BDTS,KTTS,SONGAYTS,NGAYSANH,BDNC,KTNC ,SONGAYNC,LOAICV ,CTLAN1"
            'strSQL = strSQL + " ,CTLAN2,CTLAN3,CTLAN4,CTLAN5,BD_DUONGSUC,KT_DUONGSUC,SNDS FROM #QTMANGTHAINC"
            ''CHUYEN THANH THU TUC GOI SELECT

        End If
        ''lay ds mang thai hon 1 lan
        If obj.ChonBang = 3 Then
            strSQL = "SELECT B.NV_MA,B.NGAYMANGTHAI"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " (SELECT IT_PNMT.NV_MA,NGAYMANGTHAI=MAX(NGAYMANGTHAI) FROM IT_PNMT GROUP BY IT_PNMT.NV_MA) "
            strSQL = strSQL + " AS A INNER JOIN IT_PNMT AS B ON (A.NV_MA = B.NV_MA AND A.NGAYMANGTHAI <> B.NGAYMANGTHAI)"
            strSQL = strSQL + " ORDER BY B.NV_MA,B.NGAYMANGTHAI "
        End If

        ''lay say thai
        If obj.ChonBang = 4 Then
            strSQL = "SELECT B.NV_MA,B.NGAYMANGTHAI"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + ""
            strSQL = strSQL + " (SELECT IT_PNMT.NV_MA,NGAYMANGTHAI=MAX(NGAYMANGTHAI) FROM IT_PNMT GROUP BY IT_PNMT.NV_MA) "
            strSQL = strSQL + ""
            strSQL = strSQL + ""
            strSQL = strSQL + ""


        End If

        ''loc 1 dòng sau khi update de to mau cho no
        If obj.ChonBang = 5 Then
            strSQL = "SELECT NV_MA,NGAYMANGTHAI,CHITRAL1,CHITRAL2,CHITRAL3,CHITRAL4,CHITRAL5 FROM IT_PNMT"
            strSQL = +" WHERE NV_MA='" & obj.NV_MA & "' AND NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If
        ''KIEM TRA CAC TRUONG HOP CO NHAP TRONG NHANVIENNGHIPHEP MA TRONG IT_NUOICON12THANG KCO NHAP
        ''thong tin nhanvien
        If obj.ChonBang = 6 Then
            strSQL = "SELECT SLMT=V.SLMT,V.NV_MA,HOTEN=NV_TEN,DONVI=ST_NHANVIEN.DV_MA,XUONG=X_MA_"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " ( "
            strSQL = strSQL + " SELECT SLMT=COUNT(NV_MA),NV_MA FROM IT_PNMT WHERE NV_MA='" & obj.NV_MA & "' GROUP BY NV_MA"
            strSQL = strSQL + " ) AS V INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=V.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA WHERE ST_NHANVIEN.NV_MA='" & obj.NV_MA & "'"
        End If

        'lay ngay mang thai max sau do lay so lan kham thai
        If obj.ChonBang = 7 Then
            strSQL = "Select ngaymangthai_max=max(IT_PNMT.ngaymangthai) from it_pnmt"
            strSQL = strSQL + " where ngaymangthai in (select max(ngaymangthai) "
            strSQL = strSQL + " from it_pnmt where nv_ma='" & obj.NV_MA & "' and nv_ma='" & obj.NV_MA & "')"
        End If
        ''lay cac lan KHAM THAI
        If obj.ChonBang = 8 Then
            'strSQL = "select NV_MA=V2.nv_ma,lan1=max(V2.lan1),lan2=max(V2.lan2),lan3=max(V2.lan3),lan4=max(V2.lan4),lan5=max(V2.lan5) "
            'strSQL = strSQL + " from (select V1.nv_ma,lan1=case when V1.stt=1 then V1.NP_TUNGAY else null end,lan2=case when V1.stt=2 then V1.NP_TUNGAY else null end, "
            'strSQL = strSQL + " lan3=case when V1.stt=3 then V1.NP_TUNGAY else null end,lan4=case when V1.stt=4 then V1.NP_TUNGAY else null end,"
            'strSQL = strSQL + " lan5=case when V1.stt=5 then V1.NP_TUNGAY else null end "
            'strSQL = strSQL + " from (select stt=(select count(*) from ST_NHANVIENNGHIPHEP n1 where N1.nv_ma='" & obj.NV_MA & "'"
            'strSQL = strSQL + " and N1.np_ma='Kthai' and NP_TUNGAY > '" & obj.Ngaymangthai & "'"
            'strSQL = strSQL + " and n1.NP_TUNGAY<n2.NP_TUNGAY)+1,* from ST_NHANVIENNGHIPHEP n2 where N2.nv_ma='" & obj.NV_MA & "'"
            'strSQL = strSQL + " and N2.np_ma='Kthai' and n2.NP_TUNGAY > '" & obj.Ngaymangthai & "' ) v1 ) v2 group by V2.nv_ma"

            strSQL = "SELECT NV_MA,LAN1,LAN2,LAN3,LAN4,LAN5 FROM IT_PNMT_KHAMTHAI"
            strSQL = strSQL + " WHERE NV_MA='" & obj.NV_MA & "'"
            strSQL = strSQL + " AND NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If

        ''------------ su dung khi chon ngay mang thai de them chi tra: load ngay mang thai vo combo
        If obj.ChonBang = 12 Then
            strSQL = "SELECT NGAYMANGTHAI=CONVERT(CHAR(10),IT_PNMT.NGAYMANGTHAI,105) FROM IT_PNMT "
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA ='" & obj.NV_MA & "' ORDER BY NGAYMANGTHAI ASC"
        End If
        ''hien thi thong tin theo ngay mang thai chon
        ''------------ su dung khi chon ngay mang thai de them chi tra: load ngay mang thai vo combo
        If obj.ChonBang = 13 Then
            strSQL = "SELECT IT_PNMT.NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,X_MA_,IT_PNMT.NGAYMANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5"
            strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + "  FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA  "
            strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT.NV_MA=IT_PNMT_KHAMTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI)  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA= '" & obj.NV_MA & "' AND IT_PNMT_KHAMTHAI.NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If

        '' ============ add cac ngay mang thai vo
        ''loc danh sach chi tra co cac o chi tra de cap nhat chi tra
        If obj.ChonBang = 9 Then
            strSQL = "SELECT IT_PNMT.NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,X_MA_,NGAYMANGTHAI,NULL AS [CHITRAL1],NULL AS [CHITRAL2],NULL AS [CHITRAL3],NULL AS [CHITRAL4],NULL AS [CHITRAL5] "
            strSQL = strSQL + " FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
        End If
        ''CAP NHAT SO LAN CHI TRA SAU KHI TINH LAI
        If obj.ChonBang = 10 Then
            strSQL = "SELECT IT_PNMT.NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,X_MA_,NGAYMANGTHAI,NULL AS [CHITRAL1],NULL AS [CHITRAL2],NULL AS [CHITRAL3],NULL AS [CHITRAL4],NULL AS [CHITRAL5] "
            strSQL = strSQL + " FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
        End If
        ''kiem tra chi tra de to mau
        If obj.ChonBang = 11 Then
            strSQL = "SELECT STT='',IT_PNMT.NV_MA AS MA ,NV_TEN AS TEN,ST_NHANVIEN.DV_MA AS DONVI,X_MA_ AS XUONG,IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5"
            strSQL = strSQL + " ,CTLAN1=CONVERT (BIT,(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END)) "
            strSQL = strSQL + " ,CTLAN2=CONVERT (BIT,(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END)) "
            strSQL = strSQL + " ,CTLAN3=CONVERT (BIT,(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END)) "
            strSQL = strSQL + " ,CTLAN4=CONVERT (BIT,(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END)) "
            strSQL = strSQL + " ,CTLAN5=CONVERT (BIT,(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END)) "
            strSQL = strSQL + "  FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA  "
            strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT.NV_MA=IT_PNMT_KHAMTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI)  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
        End If
        If obj.ChonBang = 14 Then
            strSQL = "SELECT IT_PNMT.NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,X_MA_,IT_PNMT.NGAYMANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5"
            strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + "  FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA  "
            strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT.NV_MA=IT_PNMT_KHAMTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI)  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA= '" & obj.NV_MA & "' AND IT_PNMT_KHAMTHAI.NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If

        If obj.ChonBang = 15 Then
            strSQL = "SELECT NV_MA,NGAYMANGTHAI FROM IT_PNMT_SAYTHAI"
            strSQL = strSQL + " WHERE NV_MA= '" & obj.NV_MA & "' AND NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If
        ''thong tin chi tra
        If obj.ChonBang = 16 Then
            strSQL = "SELECT NV_MA,NGAYMANGTHAI,CHITRAL1,CHITRAL2,CHITRAL3,CHITRAL4,CHITRAL5 FROM IT_PNMT"
            strSQL = strSQL + " WHERE NV_MA= '" & obj.NV_MA & "' AND NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If
        ''load lai ds khi cap nhat 1 nguoi (tuong tu nhu bang 2 nhung chi lay dong cap nhat lai)
        If obj.ChonBang = 17 Then
            strSQL = "SELECT  STT='',"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5,SLCHITRA='',"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH"
            strSQL = strSQL + ",BDTHAIT7=IT_PNMT.NGAYVE15H30 ,KTTHAIT7=IT_PNMT.NGAYDUSINH"
            strSQL = strSQL + ",SONGAYT7=(DATEDIFF(DAY,NGAYVE15H30,NGAYDUSINH))"
            strSQL = strSQL + ",BDTS=TUNGAY,KTTS=DENNGAY,SONGAYTS=(DATEDIFF(DAY,TUNGAY,DENNGAY))"
            strSQL = strSQL + ",NGAYSANH"
            strSQL = strSQL + ",BDNC=(CASE WHEN NGAYSANH <> '' THEN (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,KTNC=(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,SONGAYNC=(DATEDIFF(DAY,(CASE WHEN NGAYSANH <> '' THEN "
            strSQL = strSQL + " (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END),(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END))) ,LOAICV='' "
            'TO MAU CHI TRA
            strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + "	,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "

            strSQL = strSQL + "  FROM IT_NUOICONDUOI12THANG LEFT JOIN IT_PNMT "
            strSQL = strSQL + " ON (IT_NUOICONDUOI12THANG.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.SOLANMT = IT_NUOICONDUOI12THANG.SOLAN)"
            strSQL = strSQL + " LEFT JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI12THANG.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT.%' AND ISNULL(CHONSAYTHAI,0)=0"  ''LOAI BO TRUONG HOP SAY THAI
            strSQL = strSQL + " AND (DATEDIFF(MONTH,IT_PNMT.NGAYMANGTHAI,TUNGAY)) > 0" ''BO NHUNG TRUONG HOP CHUA NHAP NGAY THAI SAN THI NO RA SO THANG TINH TU NGAY MANG THAI DEN THAI SAN LA AM
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA ='" & obj.NV_MA & "'"

            ''LAY VOI LAN MAX
            strSQL = strSQL + " UNION "
            strSQL = strSQL + " SELECT  STT='',"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,LAN1,LAN2,LAN3,LAN4,LAN5,SLCHITRA='',"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH"
            strSQL = strSQL + ",BDTHAIT7=IT_PNMT.NGAYVE15H30 ,KTTHAIT7=IT_PNMT.NGAYDUSINH"
            strSQL = strSQL + ",SONGAYT7=(DATEDIFF(DAY,NGAYVE15H30,NGAYDUSINH))"
            strSQL = strSQL + ",BDTS=TUNGAY,KTTS=DENNGAY,SONGAYTS=(DATEDIFF(DAY,TUNGAY,DENNGAY))"
            strSQL = strSQL + ",NGAYSANH"
            strSQL = strSQL + ",BDNC=(CASE WHEN NGAYSANH <> '' THEN (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,KTNC=(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END)"
            strSQL = strSQL + " ,SONGAYNC=(DATEDIFF(DAY,(CASE WHEN NGAYSANH <> '' THEN "
            strSQL = strSQL + " (CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2)))) "
            strSQL = strSQL + " ELSE NULL END),(CASE WHEN NGAYSANH <> '' THEN (DATEADD(MONTH,12,((CONVERT(DATETIME,(RIGHT(NGAYSANH,4) + '-' + SUBSTRING(NGAYSANH,4,2) +'-'+ LEFT(NGAYSANH,2))))))) "
            strSQL = strSQL + " ELSE NULL END))) ,LOAICV='' "
            'TO MAU CHI TRA
            strSQL = strSQL + " ,CTLAN1=(CASE WHEN LAN1 IS NOT NULL AND CHITRAL1=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN2=(CASE WHEN LAN2 IS NOT NULL AND CHITRAL2=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + "	,CTLAN3=(CASE WHEN LAN3 IS NOT NULL AND CHITRAL3=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN4=(CASE WHEN LAN4 IS NOT NULL AND CHITRAL4=1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " ,CTLAN5=(CASE WHEN LAN5 IS NOT NULL AND CHITRAL5=1 THEN 1 ELSE 0 END) "
            ''ngay ds
            strSQL = strSQL + ",BD_DUONGSUC,KT_DUONGSUC,SNDS=(DATEDIFF(DAY,BD_DUONGSUC,KT_DUONGSUC)+1) "
            strSQL = strSQL + " FROM (SELECT IT_PNMT.NV_MA,NGAYMANGTHAI=MAX(NGAYMANGTHAI) FROM IT_PNMT  GROUP BY IT_PNMT.NV_MA) AS MT_MAX "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=MT_MAX.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            strSQL = strSQL + " INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA=MT_MAX.NV_MA AND MT_MAX.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI) "
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=MT_MAX.NV_MA AND MT_MAX.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " LEFT JOIN IT_NUOICONDUOI12THANG ON (IT_NUOICONDUOI12THANG.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.SOLANMT = IT_NUOICONDUOI12THANG.SOLAN) "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT.%' AND ISNULL(CHONSAYTHAI,0)=0"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA ='" & obj.NV_MA & "'"
        End If
        ''thong tin chi tra tu file excel
        If obj.ChonBang = 18 Then
            strSQL = "SELECT Distinct STT='',IT_CHITRAPNMT.NV_MA,NV_TEN,DV_MA,NGAYKHAM,SOTIEN,NGAYKHAMDOILAI='' FROM IT_CHITRAPNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_CHITRAPNMT.NV_MA"
        End If

        If obj.ChonBang = 19 Then
            strSQL = "SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG WHERE X_MA_ IN (SELECT X_MA_ FROM ST_DONVI WHERE DV_LocBB = 0 AND DV_TV <> 1 AND X_MA_ NOT IN ('BGD','TAM','KB')GROUP BY X_MA_ ) ORDER BY X_MA_"
        End If

        If obj.ChonBang = 20 Then
            strSQL = "SELECT Distinct STT='',IT_CHITRAPNMT.NV_MA,NV_TEN,DV_MA,NGAYKHAM,SOTIEN,NGAYKHAMDOILAI=''  FROM IT_CHITRAPNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_CHITRAPNMT.NV_MA WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENNGHIPHEP WHERE NP_Ma ='KTHAI' AND ST_NHANVIENNGHIPHEP.NV_Ma = IT_CHITRAPNMT.nv_ma AND  ST_NHANVIENNGHIPHEP.NP_TuNgay   =IT_CHITRAPNMT.ngaykham) "
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
    Public Function UpdateInfo(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim strSQL1 As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim strSQL2 As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim strSQL3 As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim strSQL4 As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim strSQL5 As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        ''cap nhat chi tra
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_PNMT  "
            strSQL = strSQL + " SET CHITRAL1= " & obj.Chitra1 & ", CHITRAL2= " & obj.Chitra2 & ""
            strSQL = strSQL + ",CHITRAL3 = " & obj.Chitra3 & " ,CHITRAL4 = " & obj.Chitra4 & ",CHITRAL5 = " & obj.Chitra5 & ""
            strSQL = strSQL + " WHERE NV_MA='" & obj.NV_MA & "' AND NGAYMANGTHAI='" & obj.Ngaymangthai & "'"
        End If
        ''format 5 so
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE IT_CHITRAPNMT  "
            strSQL = strSQL + " SET NV_MA=('0'+ NV_MA) WHERE LEN(NV_MA)= 5 "
        End If

        If obj.ChonBang = 3 Then
            strSQL = "UPDATE IT_CHITRAPNMT  "
            strSQL = strSQL + " SET NV_MA=('00'+ NV_MA) WHERE LEN(NV_MA)= 4 "
        End If

        If obj.ChonBang = 4 Then
            strSQL = "UPDATE IT_CHITRAPNMT  "
            strSQL = strSQL + " SET NV_MA=('000'+ NV_MA) WHERE LEN(NV_MA)= 3"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "UPDATE IT_CHITRAPNMT  "
            strSQL = strSQL + " SET NV_MA=('0000'+ NV_MA)WHERE LEN(NV_MA)= 2 "
        End If

        If obj.ChonBang = 8 Then
            strSQL = "UPDATE IT_CHITRAPNMT  "
            strSQL = strSQL + " SET NV_MA=('00000'+ NV_MA)WHERE LEN(NV_MA)= 1 "
        End If

        If obj.ChonBang = 6 Then
            strSQL1 = "UPDATE IT_PNMT SET CHITRAL1 =1  "
            strSQL1 = strSQL1 + " FROM  "
            strSQL1 = strSQL1 + " (SELECT IT_PNMT_KHAMTHAI.NV_MA,NGAYMANGTHAI FROM IT_PNMT_KHAMTHAI   "
            strSQL1 = strSQL1 + " INNER JOIN IT_CHITRAPNMT ON IT_CHITRAPNMT.NV_MA = IT_PNMT_KHAMTHAI.NV_MA AND NGAYKHAM=LAN1 WHERE SOTIEN >0"
            strSQL1 = strSQL1 + " ) AS V INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA= V.NV_MA AND V.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI)"

            strSQL2 = "UPDATE IT_PNMT SET CHITRAL2 =1  "
            strSQL2 = strSQL2 + " FROM  "
            strSQL2 = strSQL2 + " (SELECT IT_PNMT_KHAMTHAI.NV_MA,NGAYMANGTHAI FROM IT_PNMT_KHAMTHAI   "
            strSQL2 = strSQL2 + " INNER JOIN IT_CHITRAPNMT ON IT_CHITRAPNMT.NV_MA = IT_PNMT_KHAMTHAI.NV_MA AND NGAYKHAM=LAN2 WHERE SOTIEN >0"
            strSQL2 = strSQL2 + " ) AS V INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA= V.NV_MA AND V.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI)"


            strSQL3 = "UPDATE IT_PNMT SET CHITRAL3 =1  "
            strSQL3 = strSQL3 + " FROM  "
            strSQL3 = strSQL3 + " (SELECT IT_PNMT_KHAMTHAI.NV_MA,NGAYMANGTHAI FROM IT_PNMT_KHAMTHAI   "
            strSQL3 = strSQL3 + " INNER JOIN IT_CHITRAPNMT ON IT_CHITRAPNMT.NV_MA = IT_PNMT_KHAMTHAI.NV_MA AND NGAYKHAM=LAN3 WHERE SOTIEN >0"
            strSQL3 = strSQL3 + " ) AS V INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA= V.NV_MA AND V.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI)"


            strSQL4 = "UPDATE IT_PNMT SET CHITRAL4 =1  "
            strSQL4 = strSQL4 + " FROM  "
            strSQL4 = strSQL4 + " (SELECT IT_PNMT_KHAMTHAI.NV_MA,NGAYMANGTHAI FROM IT_PNMT_KHAMTHAI   "
            strSQL4 = strSQL4 + " INNER JOIN IT_CHITRAPNMT ON IT_CHITRAPNMT.NV_MA = IT_PNMT_KHAMTHAI.NV_MA AND NGAYKHAM=LAN4 WHERE SOTIEN >0"
            strSQL4 = strSQL4 + " ) AS V INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA= V.NV_MA AND V.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI)"


            strSQL5 = "UPDATE IT_PNMT SET CHITRAL5 =1  "
            strSQL5 = strSQL5 + " FROM  "
            strSQL5 = strSQL5 + " (SELECT IT_PNMT_KHAMTHAI.NV_MA,NGAYMANGTHAI FROM IT_PNMT_KHAMTHAI   "
            strSQL5 = strSQL5 + " INNER JOIN IT_CHITRAPNMT ON IT_CHITRAPNMT.NV_MA = IT_PNMT_KHAMTHAI.NV_MA AND NGAYKHAM=LAN5 WHERE SOTIEN >0"
            strSQL5 = strSQL5 + " ) AS V INNER JOIN IT_PNMT ON (IT_PNMT.NV_MA= V.NV_MA AND V.NGAYMANGTHAI=IT_PNMT.NGAYMANGTHAI)"

        End If
        '' CAP NHAT TRANG THAI NGAY KHAM THAI KHOG TIM THAY TRONG BANG IT_CHITRAPNMT LA 0 
        If obj.ChonBang = 7 Then
            strSQL1 = "UPDATE IT_CHITRAPNMT SET FLAG_NKHAM = 0"
            strSQL1 = strSQL1 + " FROM IT_CHITRAPNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_CHITRAPNMT.NV_MA  "
            strSQL1 = strSQL1 + " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENNGHIPHEP WHERE NP_Ma ='KThai' AND ST_NHANVIENNGHIPHEP.NV_Ma = IT_CHITRAPNMT.nv_ma  "
            strSQL1 = strSQL1 + " AND  ST_NHANVIENNGHIPHEP.NP_TuNgay   =IT_CHITRAPNMT.ngaykham ) "
        End If

        Try
            flag = Me.execSQL(strSQL)
            flag = Me.execSQL(strSQL1)
            flag = Me.execSQL(strSQL2)
            flag = Me.execSQL(strSQL3)
            flag = Me.execSQL(strSQL4)
            flag = Me.execSQL(strSQL5)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function DeleteInfo(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_CHITRAPNMT  "
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
    Public Function InsertNgayKhamMoiSua(ByVal obj As ObjTheoDoiMangThaiDenNC12Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_CHITRAPNMT (NV_MA,NGAYKHAM,SOTIEN) VALUES ('" & obj.NV_MA & "','" & obj.NgayKhamThaiDoi & "',0)"
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
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function

    Public Function GoiThuTuc_XoaDuLieu(ByVal m_sSP_Name As String)
        Me.execProc(m_sSP_Name)
    End Function
    Public Function GoiThuTuc_Loaddulieu(ByVal m_sSP_Name As String) As DataTable
        Return Me.getTableProcedure(m_sSP_Name)
    End Function
    Public Function GoiThuTuc_LoaddulieuXuong(ByVal m_sSP_Name As String, ByVal m_listpar As SqlClient.SqlParameter) As DataTable
        'Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_QTMANGTHAINUOICON_XUONG", conn)

        Return Me.getTableProcedure(m_sSP_Name, m_listpar)
    End Function
    'getDatasetProcedure
    Public Function GoiThuTucLoadDS(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Dim tbl As DataTable
        tbl = Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
        Return tbl
    End Function
End Class
