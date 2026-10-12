Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Imports System.Globalization

Public Class ClsD_ConDuoi6Tuoi
    Inherits DALSQL
    ' Methods
    Public Shared obj_Dangnhap As New frmDangNhap
    Public Shared obj_D As New Obj_ConDuoi6Tuoi
    Public Function LoadDS(ByVal obj As Obj_ConDuoi6Tuoi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        ''kiem tra trung khoa
        If obj.ChonBang = 1 Then
            Dim Ngaysanh_tim As String = obj.NgaySanh.Year.ToString() + "/" + obj.NgaySanh.Month.ToString() + "/" + obj.NgaySanh.Day.ToString()
            strSQL = "declare @kt int"
            strSQL = strSQL + " IF EXISTS (SELECT manv FROM it_nuoiconduoi6tuoi WHERE manv = '" & obj.NV_MA & "' and NGAYSANHCON='" & Ngaysanh_tim & "')"
            strSQL = strSQL + "  select @kt=1"
            strSQL = strSQL + " else "
            strSQL = strSQL + "  select @kt=0"
            strSQL = strSQL + " select KT=@kt"
        End If

        ''TINH NGAY HET HAN : ,NGAYHETHAN=(DATEADD(YEAR,5,(DATEADD(MONTH,11,NGAYSANHCON))))
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT STT='', NULL AS [2],")
            strSQL = strSQL + "MANV,NV_TEN,ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + "NV_NGAYKHD,NGAYSANHCON,NGAYHETHAN,NULL AS GHICHU"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " IT_NUOICONDUOI6TUOI INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"

            strSQL = strSQL + " WHERE MONTH(NGAYHETHAN)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(NGAYHETHAN) =" & obj.Nam & ""

            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " ORDER BY ST_DONVI.X_MA_,ST_NHANVIEN.DV_MA,MANV"
        End If


        If obj.ChonBang = 3 Then
            ''tim kiem thong tin ve nhan vien:TEN,DONVI,XUONG,NGAYVAO tu bang NhanVien
            strSQL = "SELECT ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_DONVI.DV_TEN AS DONVI,ST_NHANVIEN.DV_MA AS MADV,"
            strSQL = strSQL + " CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_NGAYKHD,105) AS NGAYKYHD,ST_DONVI.X_MA_ AS XUONG,"
            strSQL = strSQL + " NV_GIOITINH =(CASE WHEN ISNULL(NV_GIOITINH,0)=0 THEN 0 ELSE NV_GIOITINH END)"
            strSQL = strSQL + " FROM"
            strSQL = strSQL + " ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA='" & obj.NV_MA & "'"

        End If

        If obj.ChonBang = 4 Then
            ''tim kiem thong tin ve NGAY SANH CON MAX NUOI CON NHO DUOI 6TUOI
            strSQL = "SELECT IT_NUOICONDUOI6TUOI.MANV,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_TEN,NGAYSANHCON=IT_NUOICONDUOI6TUOI.NGAYSANHCON,IT_NUOICONDUOI6TUOI.NGAYHETHAN"
            strSQL = strSQL + " FROM  "
            strSQL = strSQL + " (SELECT IT_NUOICONDUOI6TUOI.MANV,NGAYSANHCON=MAX(NGAYSANHCON) "
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI GROUP BY IT_NUOICONDUOI6TUOI.MANV) AS MT_MAX "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=MT_MAX.MANV"
            strSQL = strSQL + " INNER JOIN IT_NUOICONDUOI6TUOI ON (IT_NUOICONDUOI6TUOI.MANV=MT_MAX.MANV AND MT_MAX.NGAYSANHCON=IT_NUOICONDUOI6TUOI.NGAYSANHCON) "
            strSQL = strSQL + " WHERE IT_NUOICONDUOI6TUOI.MANV='" & obj.NV_MA & "'"
        End If

        ''tinh tuổi con từ ngày sanh -ngày hiện tại (chưa dc trơ cap lan nao)
        If obj.ChonBang = 5 Then
            Dim Ngaysanh_lay As String = obj.NgaySanh.Year.ToString() + "/" + obj.NgaySanh.Month.ToString() + "/" + obj.NgaySanh.Day.ToString()
            Dim ngaychon As String = obj.NgayNhapTC.ToString()
            strSQL = "SELECT SOTHANG=DATEDIFF(MONTH,'" & Ngaysanh_lay & "','" & ngaychon & "'),TUOI=(DATEDIFF(MONTH,'" & Ngaysanh_lay & "','" & ngaychon & "')/12),THANGTUOI=(DATEDIFF(MONTH,'" & Ngaysanh_lay & "','" & ngaychon & "')%12)"
        End If

        If obj.ChonBang = 6 Then
            strSQL = "SELECT * FROM IT_NUOICONDUOI6TUOI WHERE MANV = '" & obj.NV_MA & "'"
        End If

        ''tinh tuổi con từ ngày sanh -ngày hiện tại (theo ngay sanh con max)
        If obj.ChonBang = 7 Then
            strSQL = "SELECT MANV,NGAYSANHCON,SOTHANG=DATEDIFF(MONTH,NGAYSANHCON,'" & obj.NgayNhapTC & "')"
            strSQL = strSQL + " ,TUOI=(DATEDIFF(MONTH,NGAYSANHCON ,'" & obj.NgayNhapTC & "')/12)"
            strSQL = strSQL + " ,THANGTUOI=(DATEDIFF(MONTH,NGAYSANHCON,'" & obj.NgayNhapTC & "')%12)"
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI "
            strSQL = strSQL + " WHERE MANV = '" & obj.NV_MA & "'"
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT * from JELL_USER WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
        End If
        If obj.ChonBang = 9 Then
            'strSQL = ("SELECT * from JELL_QUYENTRUYCAP INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "' AND (Ma_DM ='1frmNuoiConDuoi6Tuoi' OR Ma_DM ='2frmNuoiConDuoi6Tuoi') ")
            strSQL = " SELECT JELL_QUYENTRUYCAP.Ma_DM ,JELL_QUYENTRUYCAP.Ten_DangNhap "
            strSQL = strSQL + " ,[Admin]= isnull(JELL_USER.[Admin] ,0)"
            strSQL = strSQL + " ,[USER_KT]= isnull(JELL_USER.[USER_KT],0)"
            strSQL = strSQL + " ,Allow = isnull(JELL_QUYENTRUYCAP.Allow ,0)"
            strSQL = strSQL + " ,Them = isnull(JELL_QUYENTRUYCAP.Them  ,0)"
            strSQL = strSQL + " ,Sua = isnull(JELL_QUYENTRUYCAP.Sua  ,0)"
            strSQL = strSQL + " ,Xoa = isnull(JELL_QUYENTRUYCAP.Xoa  ,0)"
            strSQL = strSQL + " ,KHUA = isnull(JELL_QUYENTRUYCAP.KHUA  ,0)"
            strSQL = strSQL + " ,KHUB = isnull(JELL_QUYENTRUYCAP.KHUB  ,0)"
            strSQL = strSQL + ",JELL_QUYENTRUYCAP.Ten_DangNhap ,MK_DN ,Ma_NV,Ten_NV ,IP_Address"
            strSQL = strSQL + " from JELL_QUYENTRUYCAP  INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap"
            strSQL = strSQL + " WHERE (Ma_DM ='1frmNuoiConDuoi6Tuoi' OR Ma_DM ='2frmNuoiConDuoi6Tuoi') AND JELL_QUYENTRUYCAP.Ten_DangNhap ='" & Me.QuoteString(obj.TenDangNhap) & "'"
        End If

        'kiem tra ky hop dong
        If obj.ChonBang = 11 Then
            strSQL = "SELECT * FROM ST_HOPDONGLAODONG WHERE NV_MA = '" & obj.NV_MA & "'"
        End If
        'Load combo xuong
        If obj.ChonBang = 13 Then
            strSQL = ("SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")

        End If

        ''tinh tuoi, thang tuoi cua nhan vien nhap tu text lay theo ngay sanh max den ngay hien tai
        If obj.ChonBang = 14 Then
            strSQL = "SELECT TAM.MANV,TAM.DV_MA,TAM.NV_TEN,TAM.NGAYSANHCON"
            strSQL = strSQL + ",TAM.NGAYHETHAN,TAM.SOTHANG,TUOI=((TAM.SOTHANG)/12),THANGTUOI=((TAM.SOTHANG)%12)"
            strSQL = strSQL + " FROM("
            strSQL = strSQL + " SELECT IT_NUOICONDUOI6TUOI.MANV,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_TEN,NGAYSANHCON=IT_NUOICONDUOI6TUOI.NGAYSANHCON"
            strSQL = strSQL + ",NGAYHETHAN,SOTHANG=DATEDIFF(MONTH,MT_MAX.NGAYSANHCON,GETDATE())"
            strSQL = strSQL + " FROM( "
            strSQL = strSQL + " SELECT IT_NUOICONDUOI6TUOI.MANV,NGAYSANHCON=MAX(NGAYSANHCON) "
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI GROUP BY IT_NUOICONDUOI6TUOI.MANV) AS MT_MAX "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=MT_MAX.MANV"
            strSQL = strSQL + " INNER JOIN IT_NUOICONDUOI6TUOI ON (IT_NUOICONDUOI6TUOI.MANV=MT_MAX.MANV AND MT_MAX.NGAYSANHCON=IT_NUOICONDUOI6TUOI.NGAYSANHCON)"
            strSQL = strSQL + ") AS TAM "
            strSQL = strSQL + " WHERE TAM.MANV='" & obj.NV_MA & "'"

        End If

        ''ds tro cap ma da nghi viec toàn bộ
        If obj.ChonBang = 17 Then
            strSQL = ("SELECT STT='',IT_NUOICONDUOI6TUOI.MANV,NV_TEN,NGAYSANHCON,NV_NGAYVAO,NV_NGAYKHD,ST_NHANVIEN.DV_MA,ST_NHANVIEN.DV_MA_")
            strSQL = strSQL + ",ST_DONVI.X_MA_,TUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN))/12,THANGTUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN))%12"
            strSQL = strSQL + ",NGAYHETHAN,TV_NGAYTHOIVIEC,TIENTC=((CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END)),SOCON=(ISNULL(SOCON_SD,0))"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_NUOICONDUOI6TUOI ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI .MANV  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIENTHOIVIEC.NV_MA=ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " WHERE  ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.DV_MA_,IT_NUOICONDUOI6TUOI.MANV,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ , NV_TEN,NGAYSANHCON,NV_NGAYVAO,NV_NGAYKHD,NGAYHETHAN,TV_NGAYTHOIVIEC,SOCON_SD"
        End If

        ''ds tro cap ma da nghi viec theo năm
        If obj.ChonBang = 18 Then
            strSQL = ("SELECT STT='',IT_NUOICONDUOI6TUOI.MANV,NV_TEN,NGAYSANHCON,NV_NGAYVAO,NV_NGAYKHD,ST_NHANVIEN.DV_MA,ST_NHANVIEN.DV_MA_")
            strSQL = strSQL + ",ST_DONVI.X_MA_,TUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN))/12,THANGTUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN))%12"
            strSQL = strSQL + ",NGAYHETHAN,TV_NGAYTHOIVIEC,TIENTC=((CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END)),SOCON=(ISNULL(SOCON_SD,0))"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_NUOICONDUOI6TUOI ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI .MANV  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIENTHOIVIEC.NV_MA=ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " WHERE ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            strSQL = strSQL + " AND YEAR(TV_NGAYTHOIVIEC)= " & obj.Nam & ""
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.DV_MA_,IT_NUOICONDUOI6TUOI.MANV,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_ , NV_TEN,NGAYSANHCON,NV_NGAYVAO,NV_NGAYKHD,NGAYHETHAN,TV_NGAYTHOIVIEC,SOCON_SD"
        End If

        ''tro cap theo bảng IT_NUOICONDUOI6TUOI het han nam: bo thoi viec
        If obj.ChonBang = 20 Then
            strSQL = "SELECT STT='',IT_NUOICONDUOI6TUOI.MANV "
            strSQL = strSQL + ",THANGHETHAN = (CONVERT (NVARCHAR(2),MONTH(NGAYHETHAN))+ '-' +CONVERT (NVARCHAR(10),YEAR(NGAYHETHAN)))"
            strSQL = strSQL + ",ST_NHANVIEN.DV_MA ,DV_TEN "
            strSQL = strSQL + ",NV_Ten "
            strSQL = strSQL + ",IT_NUOICONDUOI6TUOI.NGAYSANHCON "
            strSQL = strSQL + ",IT_NUOICONDUOI6TUOI.NGAYHETHAN "
            strSQL = strSQL + ",TUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN)/12)"
            strSQL = strSQL + ",THANGTUOI = (DATEDIFF(MONTH,NGAYSANHCON,NGAYHETHAN)%12)"
            strSQL = strSQL + ",X_MA_ "
            strSQL = strSQL + ",NV_Ngayvao "
            strSQL = strSQL + ",NV_NGAYKHD "
            strSQL = strSQL + ",TIENTC = (CASE WHEN ISNULL(CHK_SANHDOI,0) = 1 THEN (SOCON_SD * 100) ELSE 100 END)"
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI"
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON IT_NUOICONDUOI6TUOI.MANV  = ST_NHANVIEN.NV_Ma "
            strSQL = strSQL + " INNER JOIN ST_DONVI  ON ST_NHANVIEN.DV_MA  = ST_DONVI.DV_MA "
            strSQL = strSQL + " WHERE YEAR(NGAYHETHAN) =  '" & obj.Nam & "'"
            Select Case obj.Xuong
                Case "TCT"
                Case "A"
                    strSQL = strSQL + " AND ST_DONVI.DV_MA  NOT LIKE 'B%'"
                Case "B"
                    strSQL = strSQL + " AND ST_DONVI.DV_MA LIKE 'B%'"
                Case Else
                    strSQL = strSQL + " AND ST_DONVI.X_MA_ = '" & obj.Xuong & "'"
            End Select
            strSQL = strSQL + " AND IT_NUOICONDUOI6TUOI.MANV NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " ORDER BY X_MA_,ST_NHANVIEN.DV_MA,IT_NUOICONDUOI6TUOI.MANV"
        End If


        ''loc ds toan bo du lieu da nhap
        If obj.ChonBang = 26 Then
            strSQL = ("SELECT STT='', NULL AS [2], MANV,NGAY=DAY(NGAYNHAP),THANGNAM=(CONVERT (NVARCHAR(2),MONTH(NGAYNHAP))+ '-' +CONVERT (NVARCHAR(10),YEAR(NGAYNHAP))),NV_TEN,NGAYSANHCON,NV_NGAYVAO,ST_NHANVIEN.DV_MA ,X_MA_,HD_NGAYKY ,NGAYHETHAN,TUOI=(DATEDIFF(MONTH,NGAYSANHCON,GETDATE())/12),THANGTUOI=(DATEDIFF(MONTH,NGAYSANHCON,GETDATE())%12)")
            strSQL = strSQL + ",SOTIENTC=(CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END),SOCON=(ISNULL(SOCON_SD,0)),CHK_SANHDOI=ISNULL(CHK_SANHDOI,0),GHICHU"
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_HOPDONGLAODONG ON ST_HOPDONGLAODONG.NV_MA=ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE IT_NUOICONDUOI6TUOI.MANV NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            'Andrew - Sửa lại cho phép hiển thị cả nam và nữ
            'strSQL = strSQL + " AND ST_NHANVIEN.NV_GIOITINH =0 "
            Select Case obj.ChonKhu
                Case "A"
                    strSQL = strSQL + " AND ST_DONVI.DV_MA NOT LIKE 'B%'"
                Case "B"
                    strSQL = strSQL + "  AND ST_DONVI.DV_MA LIKE 'B%' "
                Case "TCT"
                Case Else

            End Select

            strSQL = strSQL + " ORDER BY X_MA_,ST_NHANVIEN.DV_MA,MANV"
        End If

        ''DEM SO CON
        If obj.ChonBang = 29 Then
            strSQL = " SELECT MANV ,SOCON = SUM (V.SOCON ) "
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " ( "
            strSQL = strSQL + " SELECT MANV,COUNT(MANV) AS SOCON FROM IT_NUOICONDUOI6TUOI "
            strSQL = strSQL + " WHERE  ISNULL(CHK_SANHDOI,0)=  0 "
            strSQL = strSQL + " AND MANV= '" & obj.NV_MA & "'"
            strSQL = strSQL + " GROUP BY MANV  "
            strSQL = strSQL + " UNION "
            strSQL = strSQL + " SELECT MANV,(ISNULL(SOCON_SD,0)) AS SOCON FROM IT_NUOICONDUOI6TUOI "
            strSQL = strSQL + " WHERE  ISNULL(CHK_SANHDOI,0)=  1 "
            strSQL = strSQL + " AND MANV= '" & obj.NV_MA & "'"
            strSQL = strSQL + " ) AS V  GROUP BY MANV "
        End If
        ''DEM SO CON
        If obj.ChonBang = 30 Then
            strSQL = " DECLARE @NGAY  NVARCHAR(10) "
            strSQL = strSQL + " EXEC SP_LAYNGAYHT @NGAY OUTPUT "
        End If

        If obj.ChonBang = 32 Then
            If obj.Xemtruoc = 0 Then
                ''==== xem theo bang IT_QT_TROCAPCONDUOI6TUOI: neu thang cu ma da thoi viec thi hien ngay thoi viec ===========''
                strSQL = "SELECT STT=''"
                strSQL = strSQL + ",IT_QT_TROCAPCONDUOI6TUOI.MANV"
                strSQL = strSQL + ",NGAYNHAP=NGAYNHAP"
                strSQL = strSQL + ",THANGNAM= IT_QT_TROCAPCONDUOI6TUOI.T_MA "
                strSQL = strSQL + ",NV_TEN,NV_NGAYVAO,ST_NHANVIEN.DV_MA,X_MA_,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON "
                strSQL = strSQL + ",IT_QT_TROCAPCONDUOI6TUOI.NGAYHETHAN,HD_NGAYKY "
                strSQL = strSQL + ",TUOI=(DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')/12) "
                strSQL = strSQL + ",THANGTUOI=(DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')%12) "
                strSQL = strSQL + ",SOTIENTC= IT_QT_TROCAPCONDUOI6TUOI.SOTIEN "
                strSQL = strSQL + ",SOCON_SD=(ISNULL(IT_QT_TROCAPCONDUOI6TUOI.SOCON,0))"
                strSQL = strSQL + ",CHK_SANHDOI=CASE WHEN (ISNULL(IT_QT_TROCAPCONDUOI6TUOI.CHK_SANHDOI,0)=1) THEN N'SANH ĐÔI' ELSE '' END "
                strSQL = strSQL + ",TS=(CASE WHEN IT_QT_TROCAPCONDUOI6TUOI.MANV IN (SELECT NV_MA FROM ST_NHANVIENNGHIPHEP "
                strSQL = strSQL + " WHERE NV_MA IN (select NV_MA from ST_NHANVIEN where NV_MA in (select MANV from IT_NUOICONDUOI6TUOI)) "
                strSQL = strSQL + " AND NP_Ma ='TS' AND '" & obj.NgayCuoiThang & "' BETWEEN NP_TUNGAY AND NP_DENNGAY) THEN  1 ELSE 0 END)"
                strSQL = strSQL + " ,V.NP_TuNgay,V.NP_DenNgay,GHICHU ,TV_NgayThoiViec "
                strSQL = strSQL + " FROM IT_QT_TROCAPCONDUOI6TUOI LEFT JOIN IT_NUOICONDUOI6TUOI "
                strSQL = strSQL + " ON (IT_QT_TROCAPCONDUOI6TUOI.MANV =IT_NUOICONDUOI6TUOI.MANV AND IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON=IT_NUOICONDUOI6TUOI.NGAYSANHCON) "
                strSQL = strSQL + " INNER JOIN ST_HOPDONGLAODONG ON ST_HOPDONGLAODONG.NV_MA=IT_QT_TROCAPCONDUOI6TUOI.MANV"
                strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_QT_TROCAPCONDUOI6TUOI.MANV"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON IT_QT_TROCAPCONDUOI6TUOI.MANV = ST_NHANVIENTHOIVIEC.NV_Ma"
                strSQL = strSQL + " LEFT JOIN (SELECT NV_MA,NP_TuNgay ,NP_DenNgay FROM ST_NHANVIENNGHIPHEP WHERE NV_MA in (select MANV from IT_NUOICONDUOI6TUOI) AND NP_Ma ='TS' "
                strSQL = strSQL + " AND '" & obj.NgayCuoiThang & "' BETWEEN NP_TUNGAY AND NP_DENNGAY ) AS V ON V.NV_Ma = IT_QT_TROCAPCONDUOI6TUOI.MANV"
                strSQL = strSQL + " WHERE IT_QT_TROCAPCONDUOI6TUOI.T_MA = '" & obj.ThangNamTinhLuong & "'"
                strSQL = strSQL + " AND ((DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')/12) <6"
                strSQL = strSQL + " OR ((DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')/12)=6 AND ((DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')%12))BETWEEN 0 AND 0))"

                strSQL = strSQL + " AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                Select Case obj.Xuong
                    Case "TCT"
                    Case "A"
                        strSQL = strSQL + " AND ST_DONVI.DV_MA  NOT LIKE 'B%'"
                    Case "B"
                        strSQL = strSQL + " AND ST_DONVI.DV_MA LIKE 'B%'"
                    Case Else
                        strSQL = strSQL + " AND ST_DONVI.X_MA_ = '" & obj.Xuong & "'"
                End Select
                strSQL = strSQL + " ORDER BY (DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')/12),(DATEDIFF(MONTH,IT_QT_TROCAPCONDUOI6TUOI.NGAYSANHCON,'" & obj.NgayCuoiThang & "')%12),ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA"
            End If
            If obj.Xemtruoc = 1 Then
                ''==== xem theo bang IT_NUOICONDUOI6TUOI: loai thoi viec ===========''
                strSQL = "SELECT STT=''"
                strSQL = strSQL + ",IT_NUOICONDUOI6TUOI.MANV "
                strSQL = strSQL + ",NGAYNHAP=DAY(NGAYNHAP) "
                strSQL = strSQL + ",THANGNAM=(CONVERT (NVARCHAR(2),MONTH(NGAYNHAP))+ '-' +CONVERT (NVARCHAR(10),YEAR(NGAYNHAP))) "
                strSQL = strSQL + ",NV_TEN,NV_NGAYVAO,ST_NHANVIEN.DV_MA,X_MA_,IT_NUOICONDUOI6TUOI.NGAYSANHCON "
                strSQL = strSQL + ",IT_NUOICONDUOI6TUOI.NGAYHETHAN,HD_NGAYKY "
                strSQL = strSQL + ",TUOI=(DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')/12) "
                strSQL = strSQL + ",THANGTUOI=(DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')%12) "
                strSQL = strSQL + ",SOTIENTC=(CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END) "
                strSQL = strSQL + ",SOCON_SD=(ISNULL(IT_NUOICONDUOI6TUOI.SOCON_SD ,0))"
                strSQL = strSQL + ",CHK_SANHDOI=CASE WHEN (ISNULL(IT_NUOICONDUOI6TUOI.CHK_SANHDOI,0)=1) THEN N'SANH ĐÔI' ELSE '' END "
                strSQL = strSQL + ",TS=(CASE WHEN IT_NUOICONDUOI6TUOI.MANV IN (SELECT NV_MA FROM ST_NHANVIENNGHIPHEP WHERE NV_MA IN (select NV_MA from ST_NHANVIEN where NV_MA in (select MANV from IT_NUOICONDUOI6TUOI)) "
                strSQL = strSQL + " AND NP_Ma ='TS' AND '" & obj.Ngay_HienTai & "' BETWEEN NP_TUNGAY AND NP_DENNGAY) THEN  1 ELSE 0 END) "
                strSQL = strSQL + " ,V.NP_TuNgay,V.NP_DenNgay,GHICHU ,TV_NgayThoiViec =''"
                strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI INNER JOIN ST_HOPDONGLAODONG ON ST_HOPDONGLAODONG.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
                strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
                strSQL = strSQL + " LEFT JOIN (SELECT NV_MA,NP_TuNgay ,NP_DenNgay FROM ST_NHANVIENNGHIPHEP WHERE NV_MA in (select MANV from IT_NUOICONDUOI6TUOI) AND NP_Ma ='TS' "
                strSQL = strSQL + " AND '" & obj.Ngay_HienTai & "' BETWEEN NP_TUNGAY AND NP_DENNGAY  AND NV_Ma NOT IN (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC)) AS V ON V.NV_Ma = IT_NUOICONDUOI6TUOI.MANV "
                strSQL = strSQL + " WHERE((DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')/12) <6 "
                strSQL = strSQL + " OR ((DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')/12)=6 AND ((DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')%12))BETWEEN 0 AND 0)) "

                strSQL = strSQL + " AND IT_NUOICONDUOI6TUOI.MANV NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                If obj.Xuong <> "TCT" Then
                    strSQL = strSQL + " AND ST_DONVI.X_MA_ = '" & obj.Xuong & "'"
                End If
                strSQL = strSQL + "  ORDER BY (DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')/12),(DATEDIFF(MONTH,IT_NUOICONDUOI6TUOI.NGAYSANHCON,'" & obj.Ngay_HienTai & "')%12),ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA"
            End If
        End If

        ''loc theo thang nam nhap
        If obj.ChonBang = 35 Then
            strSQL = ("SELECT STT='', NULL AS [2], MANV,NGAY=DAY(NGAYNHAP),THANGNAM=(CONVERT (NVARCHAR(2),MONTH(NGAYNHAP))+ '-' +CONVERT (NVARCHAR(10),YEAR(NGAYNHAP))),NV_TEN,NGAYSANHCON,NV_NGAYVAO,ST_NHANVIEN.DV_MA ,X_MA_,HD_NGAYKY ,NGAYHETHAN,TUOI=(DATEDIFF(MONTH,NGAYSANHCON,GETDATE())/12),THANGTUOI=(DATEDIFF(MONTH,NGAYSANHCON,GETDATE())%12)")
            strSQL = strSQL + ",SOTIENTC=(CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END),SOCON=(ISNULL(SOCON_SD,0) ),CHK_SANHDOI=ISNULL(CHK_SANHDOI,0),GHICHU"
            strSQL = strSQL + " FROM IT_NUOICONDUOI6TUOI INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_HOPDONGLAODONG ON ST_HOPDONGLAODONG.NV_MA=ST_NHANVIEN.NV_MA"

            strSQL = strSQL + " WHERE NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE IT_NUOICONDUOI6TUOI.MANV = ST_NHANVIENTHOIVIEC.NV_MA) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND SUBSTRING(CONVERT(CHAR(10),NGAYNHAP,105),4,7)= '" & obj.ThangNamTinhLuong & "'"
            Select Case obj.ChonKhu
                Case "A"
                    strSQL = strSQL + " AND ST_DONVI.DV_MA NOT LIKE 'B%'"
                Case "B"
                    strSQL = strSQL + "  AND ST_DONVI.DV_MA LIKE 'B%' "
                Case "TCT"
                Case Else

            End Select
            strSQL = strSQL + " ORDER BY X_MA_,ST_NHANVIEN.DV_MA,MANV"
        End If

        'TINH SO thang cho truong hop nhap moi
        If obj.ChonBang = 114 Then
            ''LAY NGAY HIEN TAI DUNG
            Dim ngayn As String = obj.NgayNhap.Year.ToString() + "-" + obj.NgayNhap.Month.ToString() + "-" + obj.NgayNhap.Day.ToString()
            Dim ngays As String = obj.NgaySanh.Year.ToString() + "-" + obj.NgaySanh.Month.ToString() + "-" + obj.NgaySanh.Day.ToString()

            strSQL = "SELECT NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,DV_TEN,TUOI=((DATEDIFF(MONTH,'" & ngays & "',GETDATE()))/12)"
            strSQL = strSQL + ",THANGTUOI=((DATEDIFF(MONTH,'" & ngays & "','" & ngayn & "'))%12),SOTHANG=DATEDIFF(MONTH,'" & ngays & "','" & ngayn & "')  "
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA WHERE NV_MA='" & obj.NV_MA & "'"
        End If

        If obj.ChonBang = 115 Then
            ''Loc theo ngay thang nam nhap lieu
            strSQL = "SELECT NV_MA,NV_TEN,ST_NHANVIEN.DV_MA,DV_TEN,TUOI=((DATEDIFF(MONTH,'" & obj.NgaySanh & "',GETDATE()))/12)"
            strSQL = strSQL + ",THANGTUOI=((DATEDIFF(MONTH,'" & obj.NgaySanh & "','" & obj.NgayNhap & "'))%12),SOTHANG=DATEDIFF(MONTH,'" & obj.NgaySanh & "','" & obj.NgayNhap & "')  "
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA WHERE NV_MA='" & obj.NV_MA & "'"
        End If
        ''loc theo 1 ngay nhap da chon
        If obj.ChonBang = 116 Then
            strSQL = ("SELECT STT='', NULL AS [2],")
            strSQL = strSQL + "TAM.MANV,NGAY,TAM.THANGNAM,TAM.NV_TEN,TAM.NGAYSANHCON,TAM.NV_NGAYVAO"
            strSQL = strSQL + ",TAM.DV_MA ,TAM.X_MA_,TAM.NV_NGAYKHD,TAM.NGAYHETHAN,TUOI=(SOTHANG/12),THANGTUOI=(SOTHANG%12),SOTIENTC=(CASE WHEN (ISNULL(CHK_SANHDOI,0)=1) THEN (ISNULL(SOCON_SD,0) * 100.000) ELSE 100.000 END),SOCON=(ISNULL(SOCON_SD,0)),GHICHU"
            strSQL = strSQL + " FROM (SELECT "
            strSQL = strSQL + "IT_NUOICONDUOI6TUOI.MANV,NGAY=DAY(NGAYNHAP),THANGNAM=(CONVERT (NVARCHAR(2),MONTH(NGAYNHAP))+ '-' +CONVERT (NVARCHAR(10),YEAR(NGAYNHAP))),NV_TEN,NGAYSANHCON,ST_NHANVIEN.NV_NGAYVAO"
            strSQL = strSQL + ",ST_DONVI.DV_MA ,ST_DONVI.X_MA_,NV_NGAYKHD,NGAYHETHAN,SOTHANG=DATEDIFF(MONTH,NGAYSANHCON,GETDATE()),CHK_SANHDOI,SOCON_SD"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " IT_NUOICONDUOI6TUOI INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_NUOICONDUOI6TUOI.MANV "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"

            strSQL = strSQL + " WHERE IT_NUOICONDUOI6TUOI.MANV NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            'strSQL = strSQL + " )AS TAM WHERE LEFT(TAM.THANGNAM,1)='" & thangnhap & "'"
            'strSQL = strSQL + " AND RIGHT(TAM.THANGNAM,4)='" & namnhap & "'"
            strSQL = strSQL + "  ORDER BY TAM.X_MA_,TAM.DV_MA,TAM.MANV,NGAY "
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
    Public Function InsertInfo(ByVal obj As Obj_ConDuoi6Tuoi) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim ci As CultureInfo = CultureInfo.InvariantCulture

        Dim Ngaysanh_moi As String = obj.NgaySanh.Year.ToString() + "/" + obj.NgaySanh.Month.ToString() + "/" + obj.NgaySanh.Day.ToString()
        Dim Ngayhethan_moi As String = obj.NgayHetHan.Year.ToString() + "/" + obj.NgayHetHan.Month.ToString() + "/" + obj.NgayHetHan.Day.ToString()
        Dim Ngaynhap_moi As String = obj.NgayNhap.Year.ToString() + "/" + obj.NgayNhap.Month.ToString() + "/" + obj.NgayNhap.Day.ToString()
        Dim ngaytao As Date = Now()
        Dim sngaytao As String
        sngaytao = ngaytao.ToString("yyyy-MM-dd HH:mm:ss.FFF", ci)
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text


        strSQL = "INSERT INTO IT_NUOICONDUOI6TUOI (MANV,NGAYSANHCON,NGAYHETHAN,NGAYNHAP,CHK_SANHDOI,SOCON_SD,GHICHU,NCD6T_NGUOITAO,NCD6T_NGAYTAO) "
        strSQL = strSQL + " VALUES(" & "'" & Me.QuoteString(obj.NV_MA) & "',"
        strSQL = strSQL + "'" & Me.QuoteString(Ngaysanh_moi) & "',"
        strSQL = strSQL + "'" & Me.QuoteString(Ngayhethan_moi) & "','" & Me.QuoteString(Ngaynhap_moi) & "'," & Me.QuoteString(obj.ChkSanhDoi) & "," & Me.QuoteString(obj.SoconSD) & ",N'" & Me.QuoteString(obj.GhichuSD) & "'" & ",N'" & Me.QuoteString(obj.TenDangNhap) & "','" & sngaytao & "')"

        obj.TruyVan = strSQL

        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    'Public Function TrangThaiKhoaTroCap(ByVal obj As Obj_ConDuoi6Tuoi) As Boolean
    '    Dim flag As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

    '    If obj.ChonBang = 1 Then
    '        strSQL = "INSERT INTO IT_KHOABANGNUOICOND6T (TRANGTHAI) VALUES (1)"
    '    End If
    '    '' KHỞI TẠO
    '    If obj.ChonBang = 2 Then
    '        strSQL = "UPDATE IT_KHOABANGNUOICOND6T SET TRANGTHAI = 0"
    '    End If
    '    ''ĐÓNG LẠI NẾU THÀNH CÔNG
    '    If obj.ChonBang = 3 Then
    '        strSQL = "UPDATE IT_KHOABANGNUOICOND6T SET TRANGTHAI = 1"
    '    End If

    '    Try
    '        flag = Me.execSQL(strSQL)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function
    Public Function KiemTraTrangThaiKhoaTroCapThang(ByVal obj As Obj_ConDuoi6Tuoi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = "SELECT * FROM IT_KHOABANGNUOICOND6T WHERE T_MA = '" & obj.ThangNamTinhLuong & "'"
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

    Public Function DeleteInfo(ByVal obj As Obj_ConDuoi6Tuoi) As Boolean
        Dim strSQL2 As String = ""
        Dim chuoi As String = ""
        Dim Ngaysanh_xoa As String = obj.NgaySanh.Year.ToString() + "/" + obj.NgaySanh.Month.ToString() + "/" + obj.NgaySanh.Day.ToString()
        strSQL2 = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL2 = ((((strSQL2 & " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE " & ChrW(13) & ChrW(10)) & "delete from IT_NUOICONDUOI6TUOI where MANV = '" & obj.NV_MA & "' AND NGAYSANHCON='" & Ngaysanh_xoa & "'" & ChrW(13) & ChrW(10) & " if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & " ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION"))
        obj_D.TruyVan = strSQL2
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj_D.Get_HanhDong = 3
        Return Me.execSQL(strSQL2)
    End Function
    Public Function UpdateInfo(ByVal obj As Obj_ConDuoi6Tuoi) As Boolean
        Dim flag As Boolean
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim Ngaysanh As String = obj.NgaySanh.Year.ToString() + "/" + obj.NgaySanh.Month.ToString() + "/" + obj.NgaySanh.Day.ToString()
        Dim ngaycapnhat As Date = Now()
        Dim sngaycapnhat As String
        sngaycapnhat = ngaycapnhat.ToString("yyyy-MM-dd HH:mm:ss.FFF", ci)
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text

        strSQL = "UPDATE IT_NUOICONDUOI6TUOI SET "
        strSQL = strSQL + "CHK_SANHDOI=" & obj.ChkSanhDoi & ""
        strSQL = strSQL + ",SOCON_SD=" & obj.SoconSD & ""
        strSQL = strSQL + ",GHICHU=N'" & obj.GhichuSD & "'"
        strSQL = strSQL + ",NCD6T_NGUOICAPNHAT = N'" + obj.TenDangNhap + "'"
        strSQL = strSQL + ",NCD6T_NGAYCAPNHAT = N'" + sngaycapnhat + "'"
        strSQL = strSQL + " WHERE MANV='" & obj.NV_MA & "' AND NGAYSANHCON='" & Ngaysanh & "'"
        obj.TruyVan = strSQL & " CHK_SANHDOIcu=" & obj.ChkSanhDoi & ",SOCON_SDCU=" & obj.SoconSD & ",GHICHUCU=" & obj.GhichuSD
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
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function ChuyenTroCap(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucHT(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function LoadThuTuc(ByVal m_sSP_Name As String) As DataSet
        Return Me.getDatasetProcedure(m_sSP_Name)
    End Function
    Public Function LoadThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataSet
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar)
    End Function
End Class
