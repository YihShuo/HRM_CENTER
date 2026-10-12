Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class ClsD_PhuNuMangThai_KThaiYte
    Inherits DALSQL
    ' Methods
    Public Shared obj_Dangnhap As New frmDangNhap
    Public Shared obj_D As New Obj_PhuNuMangThai_KThaiYte
    Public Function LoadDS(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load combo xuong
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")
        End If

        'If obj.ChonBang = 2 Then
        '    strSQL = "SELECT STT='', NULL AS [2],CONVERT(BIT,'0') AS [3],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "CVU_TEN AS CHUCVU,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "B.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "B.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "B.NGAYDUSINH AS DUSINH"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT B ON ST_NHANVIEN.NV_MA=B.NV_MA"

        '    strSQL = strSQL + " INNER JOIN ST_CONGVIEC ON ST_CONGVIEC.CV_MA=ST_NHANVIEN.CV_MA "
        '    strSQL = strSQL + " INNER JOIN ST_CHUCVU ON ST_CHUCVU.CVU_MA=ST_NHANVIEN.CVU_MA "
        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    ''loai trong ccap nhat say thai
        '    'strSQL = strSQL + " AND GHICHU_ST IS NULL"  ---  bỏ ra ngày 30/5/2015 (không sử dụng nữa)
        '    ''loai nhung nhan vien da say thai trong nghi phep "say thai"
        '    strSQL = strSQL + " AND (NOT EXISTS (SELECT * FROM IT_PNMT_SAYTHAI C WHERE B.NV_MA=C.NV_MA AND B.NGAYMANGTHAI=C.NGAYMANGTHAI))"
        '    strSQL = strSQL + " AND MONTH(B.NGAYVE15H30)=" & obj.Thang & ""
        '    strSQL = strSQL + " AND YEAR(B.NGAYVE15H30)=" & obj.Nam & ""
        '    strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        'End If

        If obj.ChonBang = 3 Then
            strSQL = " SELECT distinct STT='', NULL AS [2],ST_NHANVIEN.NV_MA AS MA,ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH"
            strSQL = strSQL + " ,ST_CONGVIEC.CV_TEN AS CONGVIEC,ST_DONVI.DV_TEN AS DONVI ,ST_CHUCVU.CVU_TEN AS CHUCVU,ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO"
            strSQL = strSQL + " ,IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,IT_PNMT.NGAYVE15H30 AS VE_15H30 ,IT_PNMT_KHAMTHAI.LAN1 AS LAN1,IT_PNMT_KHAMTHAI.LAN2 "
            strSQL = strSQL + " AS LAN2,IT_PNMT_KHAMTHAI.LAN3 AS LAN3,IT_PNMT_KHAMTHAI.LAN4 AS LAN4  "
            strSQL = strSQL + ",IT_PNMT_KHAMTHAI.LAN5 AS LAN5,IT_PNMT.NGAYDUSINH AS DUSINH,IT_PNMT.GHICHU AS GHICHU , DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END), BDTS_NP, KTTS_NP "
            strSQL = strSQL + " FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI)"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_PNMT_SAYTHAI WHERE MONTH(NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(NGAYMANGTHAI)=" & obj.Nam & ") AND IT_PNMT_KHAMTHAI.FLAG_ST <> 1"
            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        End If

        ' ''TINH NGAYKHAMTHAI=NGAYSANH (NEU CO) - 9THANG10NGAY
        'If obj.ChonBang = 5 Then
        '    strSQL = "SELECT distinct STT='', NULL AS [2],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG1=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN1,103) END AS LAN1,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG2=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN2,103) END AS LAN2,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG3=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN3,103) END AS LAN3,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG4=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN4,103) END AS LAN4,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG5=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN5,103) END AS LAN5,"

        '    strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
        '    strSQL = strSQL + "IT_PNMT.GHICHU AS GHICHU"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON IT_PNMT_KHAMTHAI.NV_MA=ST_NHANVIEN.NV_MA"

        '    strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
        '    strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
        '    strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
        '    strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"

        'End If

        If obj.ChonBang = 7 Then
            ''tim kiem thong tin ve nhan vien:TEN,DONVI,XUONG,NGAYVAO tu bang NhanVien
            strSQL = "SELECT ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,ST_NHANVIEN.DV_MA AS MADV,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,ST_NXUONG.X_MA_ AS XUONG,THOIVIEC = (CASE WHEN TV_NGAYTHOIVIEC IS NULL THEN 0 ELSE 1 END),DV_NGHIVIEC =ISNULL(DV_TV,0 ),NV_GIOITINH = (CASE WHEN ISNULL(NV_GIOITINH,0)= 1 THEN 1 ELSE 0 END) "
            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA=ST_NHANVIENTHOIVIEC.NV_MA"
            strSQL = strSQL + " WHERE ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA='" & obj.NV_MA & "'"

        End If

        If obj.ChonBang = 8 Then
            ''tim kiem thong tin ve IT_PNMT:DUA VAO COT NGAYMANGTHAI VA SOTHE;1 NGUOI CO THE CO NHIEU NGAY MANG THAI
            Dim Ngaymangthai_tim As String = obj.NgayMangThai.Year.ToString() + "/" + obj.NgayMangThai.Month.ToString() + "/" + obj.NgayMangThai.Day.ToString()
            strSQL = "SELECT NGAYMANGTHAI=MAX(NGAYMANGTHAI),NGAYVE15H30 AS NGAYVE15H30,NGAYDUSINH AS NGAYDUSINH "
            strSQL = strSQL + ",(CASE WHEN NOT GHICHU_ST IS NULL THEN 1 ELSE 0 END) AS SAYTHAI "
            strSQL = strSQL + " FROM IT_PNMT"
            strSQL = strSQL + " WHERE NGAYMANGTHAI IN (SELECT MAX(NGAYMANGTHAI) FROM IT_PNMT WHERE NV_MA='" & obj.NV_MA & "')"
            strSQL = strSQL + " AND IT_PNMT.NV_MA='" & obj.NV_MA & "'"
            strSQL = strSQL + " GROUP BY NGAYVE15H30,NGAYDUSINH,GHICHU_ST"
        End If

        If obj.ChonBang = 9 Then
            ''hiển thị các lần khám thai theo ngày mt max (ưu tiên bảng IT_PNMT), lấy số lần nếu có
            strSQL = "SELECT it_pnmt_khamthai.ngaymangthai,it_pnmt_khamthai.NV_MA,LAN1,LAN2,LAN3,LAN4,LAN5"
            strSQL = strSQL + " from it_pnmt_khamthai LEFT JOIN IT_PNMT ON it_pnmt_khamthai.NV_MA=it_pnmt.NV_MA"
            strSQL = strSQL + " where it_pnmt_khamthai.nv_ma='" & obj.NV_MA & "'"
            strSQL = strSQL + " and it_pnmt_khamthai.ngaymangthai in (select max(ngaymangthai) from IT_PNMT where nv_ma='" & obj.NV_MA & "')"
        End If

        ' ''toan cong ty
        'If obj.ChonBang = 10 Then
        '    strSQL = "SELECT STT='', NULL AS [2],CONVERT(BIT,'0') AS [3],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "CVU_TEN AS CHUCVU,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "B.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "B.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "B.NGAYDUSINH AS DUSINH"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT B ON ST_NHANVIEN.NV_MA=B.NV_MA"

        '    strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_CONGVIEC.CV_MA=ST_NHANVIEN.CV_MA "
        '    strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_CHUCVU.CVU_MA=ST_NHANVIEN.CVU_MA "
        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    ''loai trong ccap nhat say thai
        '    'strSQL = strSQL + " AND GHICHU_ST IS NULL" ---  bỏ ra ngày 30/5/2015 (không sử dụng nữa)
        '    ''loai nhung nhan vien da say thai trong nghi phep "say thai"
        '    strSQL = strSQL + " AND (NOT EXISTS (SELECT * FROM IT_PNMT_SAYTHAI C WHERE B.NV_MA=C.NV_MA AND B.NGAYMANGTHAI=C.NGAYMANGTHAI))"
        '    strSQL = strSQL + " AND MONTH(B.NGAYVE15H30)=" & obj.Thang & ""
        '    strSQL = strSQL + " AND YEAR(B.NGAYVE15H30)=" & obj.Nam & ""
        'End If

        If obj.ChonBang = 11 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        End If
        ' ''toan cong ty
        If obj.ChonBang = 12 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
        End If

        If obj.ChonBang = 14 Then
            strSQL = " SELECT distinct STT='', NULL AS [2],ST_NHANVIEN.NV_MA AS MA,ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH"
            strSQL = strSQL + " ,ST_CONGVIEC.CV_TEN AS CONGVIEC,ST_DONVI.DV_TEN AS DONVI ,ST_CHUCVU.CVU_TEN AS CHUCVU,ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO"
            strSQL = strSQL + " ,IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,IT_PNMT.NGAYVE15H30 AS VE_15H30 ,IT_PNMT_KHAMTHAI.LAN1 AS LAN1,IT_PNMT_KHAMTHAI.LAN2 "
            strSQL = strSQL + " AS LAN2,IT_PNMT_KHAMTHAI.LAN3 AS LAN3,IT_PNMT_KHAMTHAI.LAN4 AS LAN4  "
            strSQL = strSQL + ",IT_PNMT_KHAMTHAI.LAN5 AS LAN5,IT_PNMT.NGAYDUSINH AS DUSINH,IT_PNMT.GHICHU AS GHICHU  , DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP,KTTS_NP  "
            strSQL = strSQL + " FROM IT_PNMT INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI)"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_PNMT_SAYTHAI WHERE MONTH(NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(NGAYMANGTHAI)=" & obj.Nam & ") AND IT_PNMT_KHAMTHAI.FLAG_ST <> 1"
            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
        End If



        ' ''tim ngay say thai dau tien cua 1 nguoi;sau do lay nghi ST den ngay
        'If obj.ChonBang = 16 Then
        '    strSQL = "Declare @ngaymangthai datetime "
        '    strSQL = strSQL + ",@STlan_gannhat datetime"
        '    strSQL = strSQL + ",@NP_DENNGAY datetime"
        '    strSQL = strSQL + " select @ngaymangthai=max(IT_PNMT.ngaymangthai) from it_pnmt "
        '    strSQL = strSQL + " where ngaymangthai in (select max(ngaymangthai) from it_pnmt where nv_ma='" & obj.NV_MA & "'"
        '    strSQL = strSQL + ") and nv_ma='" & obj.NV_MA & "'"
        '    strSQL = strSQL + " SELECT "
        '    strSQL = strSQL + "@STlan_gannhat=max(V2.lanST)"
        '    strSQL = strSQL + " from (select V1.nv_ma,"
        '    strSQL = strSQL + "lanST=case when V1.stt=1 then V1.np_tungay else null end"
        '    strSQL = strSQL + " from (select stt=(select count(*) from st_nhanviennghiphep n1 "
        '    strSQL = strSQL + " where N1.nv_ma='" & obj.NV_MA & "'"
        '    strSQL = strSQL + " and N1.np_ma='ST' and n1.np_tungay > @ngaymangthai and n1.np_tungay<n2.np_tungay)+1,* from st_nhanviennghiphep n2"
        '    strSQL = strSQL + " where N2.nv_ma='" & obj.NV_MA & "'"
        '    strSQL = strSQL + " and N2.np_ma='ST' and n2.np_tungay > @ngaymangthai)v1) v2"
        '    strSQL = strSQL + " group by V2.nv_ma"
        '    strSQL = strSQL + " SELECT @NP_DENNGAY=ST_NHANVIENNGHIPHEP.NP_DENNGAY"
        '    strSQL = strSQL + " FROM ST_NHANVIENNGHIPHEP WHERE NV_MA='" & obj.NV_MA & "'"
        '    strSQL = strSQL + " AND NP_TUNGAY=@STlan_gannhat"
        '    strSQL = strSQL + " Select STlan_gannhat=@STlan_gannhat,ST_denngay=@NP_DENNGAY,mangthai_max=@ngaymangthai"
        'End If

        'If obj.ChonBang = 17 Then
        '    strSQL = "Select ngaymangthai_max=max(IT_PNMT.ngaymangthai)"
        '    strSQL = strSQL + " from it_pnmt"
        '    strSQL = strSQL + " where ngaymangthai in (select max(ngaymangthai) from it_pnmt where nv_ma='" & obj.NV_MA & "'"
        '    strSQL = strSQL + ") and nv_ma='" & obj.NV_MA & "'"
        'End If

        'If obj.ChonBang = 18 Then
        '    strSQL = ("SELECT DV_MA ,(DV_MA + '-------------------'+DV_TEN) AS DV_TEN FROM  ST_DONVI WHERE ISNULL(DV_LocBB,0)= 0 AND ISNULL(DV_TV,0) <> 1  AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%'  ORDER BY DV_MA  ")

        'End If

        'If obj.ChonBang = 19 Then
        '    strSQL = "SELECT distinct STT='', NULL AS [2],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG1=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN1,103) END AS LAN1,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG2=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN2,103) END AS LAN2,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG3=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN3,103) END AS LAN3,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG4=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN4,103) END AS LAN4,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG5=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN5,103) END AS LAN5,"

        '    strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
        '    strSQL = strSQL + "IT_PNMT.GHICHU AS GHICHU"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON IT_PNMT_KHAMTHAI.NV_MA=ST_NHANVIEN.NV_MA"

        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " AND ST_NHANVIEN.DV_MA ='" & obj.DonVi & "'"
        '    ' strSQL = strSQL + " AND (NOT IT_PNMT.GHICHU_ST IS NULL)"
        'End If

        'If obj.ChonBang = 20 Then
        '    strSQL = "SELECT distinct STT='', NULL AS [2],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG1=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN1,103) END AS LAN1,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG2=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN2,103) END AS LAN2,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG3=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN3,103) END AS LAN3,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG4=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN4,103) END AS LAN4,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG5=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN5,103) END AS LAN5,"

        '    strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
        '    strSQL = strSQL + "IT_PNMT.GHICHU AS GHICHU"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON IT_PNMT_KHAMTHAI.NV_MA=ST_NHANVIEN.NV_MA"

        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    '  strSQL = strSQL + " AND (NOT IT_PNMT.GHICHU_ST IS NULL)"
        'End If

        'If obj.ChonBang = 21 Then
        '    strSQL = "SELECT distinct STT='', NULL AS [2],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG1=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN1,103) END AS LAN1,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG2=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN2,103) END AS LAN2,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG3=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN3,103) END AS LAN3,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG4=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN4,103) END AS LAN4,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG5=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN5,103) END AS LAN5,"

        '    strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
        '    strSQL = strSQL + "IT_PNMT.GHICHU AS GHICHU"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON IT_PNMT_KHAMTHAI.NV_MA=ST_NHANVIEN.NV_MA"

        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        '    ' strSQL = strSQL + " AND (NOT IT_PNMT.GHICHU_ST IS NULL)"
        'End If


        'If obj.ChonBang = 22 Then
        '    strSQL = "SELECT distinct STT='', NULL AS [2],"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
        '    strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
        '    strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG1=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN1,103) END AS LAN1,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG2=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN2,103) END AS LAN2,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG3=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN3,103) END AS LAN3,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG4=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN4,103) END AS LAN4,"
        '    strSQL = strSQL + "CASE WHEN (NOT IT_PNMT.GHICHU_ST IS NULL AND FLAG5=1) THEN IT_PNMT.GHICHU_ST ELSE CONVERT(NVARCHAR(10),IT_PNMT_KHAMTHAI.LAN5,103) END AS LAN5,"

        '    strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
        '    strSQL = strSQL + "IT_PNMT.GHICHU AS GHICHU"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI ON IT_PNMT_KHAMTHAI.NV_MA=ST_NHANVIEN.NV_MA"

        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    'strSQL = strSQL + " AND (NOT IT_PNMT.GHICHU_ST IS NULL)"
        'End If

        'If obj.ChonBang = 23 Then
        '    strSQL = "SELECT STT='',NULL AS [2],THANG=RIGHT(CONVERT(NVARCHAR(10),IT_PNMT_SAYTHAI.NGAYSAYTHAI,103),7),"
        '    strSQL = strSQL + "IT_PNMT.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYMANGTHAI AS MANGTHAI_MAX,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYSAYTHAI AS SAYTHAI_TUNGAY,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYKTSAYTHAI AS SAYTHAI_DENNGAY"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT_SAYTHAI ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI)"

        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " AND ST_DONVI.X_MA_='" & obj.Xuong & "'"
        '    strSQL = strSQL + " ORDER BY ST_DONVI.DV_TEN"
        'End If

        'If obj.ChonBang = 24 Then
        '    strSQL = "SELECT STT='',NULL AS [2],THANG=RIGHT(CONVERT(NVARCHAR(10),IT_PNMT_SAYTHAI.NGAYSAYTHAI,103),7),"
        '    strSQL = strSQL + "IT_PNMT.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYMANGTHAI AS MANGTHAI_MAX,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYSAYTHAI AS SAYTHAI_TUNGAY,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYKTSAYTHAI AS SAYTHAI_DENNGAY"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT_SAYTHAI ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI)"
        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " AND ST_NHANVIEN.DV_MA='" & obj.DonVi & "'"
        '    strSQL = strSQL + " ORDER BY ST_DONVI.DV_TEN"
        'End If

        'If obj.ChonBang = 25 Then
        '    strSQL = "SELECT STT='',NULL AS [2],THANG=RIGHT(CONVERT(NVARCHAR(10),IT_PNMT_SAYTHAI.NGAYSAYTHAI,103),7),"
        '    strSQL = strSQL + "IT_PNMT.NV_MA AS MA,"
        '    strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
        '    strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"

        '    strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYMANGTHAI AS MANGTHAI_MAX,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYSAYTHAI AS SAYTHAI_TUNGAY,"
        '    strSQL = strSQL + "IT_PNMT_SAYTHAI.NGAYKTSAYTHAI AS SAYTHAI_DENNGAY"
        '    strSQL = strSQL + " FROM "
        '    strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
        '    strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
        '    strSQL = strSQL + " INNER JOIN IT_PNMT_SAYTHAI ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI)"
        '    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    strSQL = strSQL + " ORDER BY ST_DONVI.DV_TEN"
        'End If
        'If obj.ChonBang = 26 Then
        '    strSQL = "SELECT dem = count(IT_THAITHANGTHU7.NV_MA )"
        '    strSQL = strSQL + " FROM IT_THAITHANGTHU7 INNER JOIN ST_NHANVIEN ON IT_THAITHANGTHU7.NV_MA = ST_NHANVIEN.NV_MA "
        '    strSQL = strSQL + " AND IT_THAITHANGTHU7.DENNGAY = (SELECT MAX(T.DENNGAY) FROM IT_THAITHANGTHU7 AS T WHERE T.NV_MA =IT_THAITHANGTHU7.NV_MA)"
        '    strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
        '    strSQL = strSQL + " WHERE "
        '    strSQL = strSQL + " IT_THAITHANGTHU7.NV_MA NOT IN (SELECT NV_MA FROM IT_NUOICONDUOI12THANG "
        '    strSQL = strSQL + " WHERE IT_NUOICONDUOI12THANG.TUNGAY > IT_THAITHANGTHU7.BATDAUTU "
        '    strSQL = strSQL + " AND IT_NUOICONDUOI12THANG.DENNGAY > IT_THAITHANGTHU7.DENNGAY) "

        '    strSQL = strSQL + " AND IT_NUOICONDUOI12THANG.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
        '    If obj.Xuong <> Nothing AndAlso obj.Xuong = "TCT" Then
        '        strSQL = strSQL + " AND MONTH(IT_THAITHANGTHU7.BATDAUTU)=" & obj.Thang
        '        strSQL = strSQL + " AND YEAR(IT_THAITHANGTHU7.BATDAUTU)=" & obj.Nam
        '    Else
        '        strSQL = strSQL + " AND ST_DONVI.X_MA_='" & obj.Xuong & "'"
        '        strSQL = strSQL + " AND MONTH(IT_THAITHANGTHU7.BATDAUTU)=" & obj.Thang
        '        strSQL = strSQL + " AND YEAR(IT_THAITHANGTHU7.BATDAUTU)=" & obj.Nam
        '    End If
        'End If

        '***************** danh sach mang thai tu thang den thang ************
        If obj.ChonBang = 27 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"

            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"

            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        End If
        ' ''toan cong ty
        If obj.ChonBang = 28 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"

        End If
        ''loai nhung nguoi say thai tu thang den thang
        If obj.ChonBang = 29 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"

            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NV_MA NOT IN (SELECT IT_PNMT.NV_MA FROM IT_PNMT INNER JOIN IT_PNMT_SAYTHAI "
            strSQL = strSQL + " ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI)"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "')"
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        End If
        ' ''toan cong ty
        If obj.ChonBang = 30 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"

            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NV_MA NOT IN (SELECT IT_PNMT.NV_MA FROM IT_PNMT INNER JOIN IT_PNMT_SAYTHAI "
            strSQL = strSQL + " ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI)"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "')"
        End If

        '' ******************** HIEN THI CAC LAN KHAM THAI TU THANG DEN THANG  *******************************
        ''------------- ------------- theo tung xuong ---------------
        If obj.ChonBang = 31 Then
            strSQL = " SELECT distinct STT='', NULL AS [2],ST_NHANVIEN.NV_MA AS MA,ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH"
            strSQL = strSQL + ",ST_CONGVIEC.CV_TEN AS CONGVIEC,ST_DONVI.DV_TEN AS DONVI"
            strSQL = strSQL + " ,ST_CHUCVU.CVU_TEN AS CHUCVU,ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,IT_PNMT.NGAYVE15H30 AS VE_15H30"
            strSQL = strSQL + " ,IT_PNMT_KHAMTHAI.LAN1 AS LAN1,IT_PNMT_KHAMTHAI.LAN2 AS LAN2,IT_PNMT_KHAMTHAI.LAN3 AS LAN3,IT_PNMT_KHAMTHAI.LAN4 AS LAN4"
            strSQL = strSQL + " ,IT_PNMT_KHAMTHAI.LAN5 AS LAN5,IT_PNMT.NGAYDUSINH AS DUSINH,IT_PNMT.GHICHU AS GHICHU  , DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP,KTTS_NP "
            strSQL = strSQL + "  FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT_KHAMTHAI.FLAG_ST <> 1"
            strSQL = strSQL + " AND IT_PNMT.NV_MA NOT IN (SELECT IT_PNMT.NV_MA FROM IT_PNMT INNER JOIN IT_PNMT_SAYTHAI "
            strSQL = strSQL + " ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "')"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"

        End If
        ''-------------theo toan cong ty-------------------------
        If obj.ChonBang = 32 Then
            strSQL = " SELECT distinct STT='', NULL AS [2],ST_NHANVIEN.NV_MA AS MA,ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH"
            strSQL = strSQL + ",ST_CONGVIEC.CV_TEN AS CONGVIEC,ST_DONVI.DV_TEN AS DONVI"
            strSQL = strSQL + " ,ST_CHUCVU.CVU_TEN AS CHUCVU,ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,IT_PNMT.NGAYVE15H30 AS VE_15H30"
            strSQL = strSQL + " ,IT_PNMT_KHAMTHAI.LAN1 AS LAN1,IT_PNMT_KHAMTHAI.LAN2 AS LAN2,IT_PNMT_KHAMTHAI.LAN3 AS LAN3,IT_PNMT_KHAMTHAI.LAN4 AS LAN4"
            strSQL = strSQL + " ,IT_PNMT_KHAMTHAI.LAN5 AS LAN5,IT_PNMT.NGAYDUSINH AS DUSINH,IT_PNMT.GHICHU AS GHICHU , DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP,KTTS_NP "
            strSQL = strSQL + "  FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_ "
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA "
            strSQL = strSQL + " INNER JOIN IT_PNMT_KHAMTHAI ON (IT_PNMT_KHAMTHAI.NV_MA=IT_PNMT.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_KHAMTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT_KHAMTHAI.FLAG_ST <> 1"
            strSQL = strSQL + " AND IT_PNMT.NV_MA NOT IN (SELECT IT_PNMT.NV_MA FROM IT_PNMT INNER JOIN IT_PNMT_SAYTHAI "
            strSQL = strSQL + " ON (IT_PNMT.NV_MA=IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI=IT_PNMT_SAYTHAI.NGAYMANGTHAI) "
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "')"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYMANGTHAI <='" & obj.NgayCuoiThang & "'"
        End If

        If obj.ChonBang = 37 Then

            strSQL = "SELECT STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"

            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"

            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND NGAYLOAD='" & obj.NgayNhap & "'"
        End If

        If obj.ChonBang = 38 Then
            strSQL = "SELECT NV_MA,NGAYMANGTHAI,SOLANMT = ISNULL(SOLANMT,0)"
            strSQL = strSQL + " FROM IT_PNMT"
            strSQL = strSQL + " WHERE NV_MA = '" & obj.NV_MA & "'"
            strSQL = strSQL + " AND NGAYMANGTHAI IN (SELECT MAX(NGAYMANGTHAI) AS NGAYMANGTHAI FROM IT_PNMT WHERE NV_MA = '" & obj.NV_MA & "')"
        End If

        ''kiem tra trung khoa
        If obj.ChonBang = 81 Then
            Dim Ngaymangthai_tim As String = obj.NgayMangThai.Year.ToString() + "/" + obj.NgayMangThai.Month.ToString() + "/" + obj.NgayMangThai.Day.ToString()
            strSQL = "declare @kt int"
            strSQL = strSQL + " IF EXISTS (SELECT nv_ma ,ngaymangthai FROM IT_PNMT WHERE nv_ma = '" & obj.NV_MA & "'"
            strSQL = strSQL + " and ngaymangthai = '" & Ngaymangthai_tim & "')"
            strSQL = strSQL + "  select @kt=1"
            strSQL = strSQL + " else "
            strSQL = strSQL + "  select @kt=0"
            strSQL = strSQL + " select KT=@kt"
        End If

        If obj.ChonBang = 83 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.DV_MA AS MADV,"
            strSQL = strSQL + "IT_THAITHANGTHU7.BATDAUTU AS TUNGAY,IT_THAITHANGTHU7.DENNGAY AS DENNGAY"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN LEFT JOIN IT_THAITHANGTHU7 ON ST_NHANVIEN.NV_MA=IT_THAITHANGTHU7.NV_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.NV_MA='" & obj.NV_MA & "'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.BATDAUTU='" & obj.Batdautu & "'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.DENNGAY='" & obj.DenNgay & "'"
        End If



        ''loai nhung nguoi say thai cua thang do thoi (tinh truong hop nguoi do say thai,mang thai lai)
        If obj.ChonBang = 111 Then
            strSQL = "SELECT STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_PNMT_SAYTHAI WHERE MONTH(NGAYMANGTHAI)=" & obj.Thang & " AND YEAR(NGAYMANGTHAI)=" & obj.Nam & " )"
            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
            strSQL = strSQL + " AND ST_DONVI.X_MA_ ='" & obj.Xuong & "'"
        End If

        If obj.ChonBang = 112 Then
            strSQL = "SELECT STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"

            strSQL = strSQL + " FROM "
            strSQL = strSQL + "ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_PNMT_SAYTHAI WHERE MONTH(NGAYMANGTHAI)=" & obj.Thang & " AND YEAR(NGAYMANGTHAI)=" & obj.Nam & " )"
            strSQL = strSQL + " AND MONTH(IT_PNMT.NGAYMANGTHAI)=" & obj.Thang & ""
            strSQL = strSQL + " AND YEAR(IT_PNMT.NGAYMANGTHAI)=" & obj.Nam & ""
        End If
        ' ''=========== kiem tra tháng về 15h30 đã chuyển dữ liệu chưa===========''
        'If obj.ChonBang = 84 Then
        '    strSQL = "SELECT TOP 1 * FROM IT_THAITHANGTHU7"
        '    strSQL = strSQL + " WHERE BATDAUTU >= '" & obj.NgayDauThang & "'"
        '    strSQL = strSQL + " AND BATDAUTU <='" & obj.NgayCuoiThang & "'"
        'End If
        ''===========  truy vấn kiểm tra người bất kỳ đã chuyển về 15h30 chưa =====''
        If obj.ChonBang = 85 Then
            strSQL = "SELECT * FROM IT_THAITHANGTHU7"
            strSQL = strSQL + " WHERE BATDAUTU = '" & obj.Batdautu & "'"
            strSQL = strSQL + " AND DENNGAY ='" & obj.DenNgay & "'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.NV_MA ='" & obj.NV_MA & "'"
        End If

        ''===========  truy vấn kiểm tra có thay đổi ngày dự sinh bảng PNMT sau khi đã chuyển về 15h30 ========''
        If obj.ChonBang = 86 Then
            strSQL = "SELECT IT_PNMT.NV_MA,IT_PNMT.NGAYMANGTHAI,IT_PNMT.NGAYVE15H30,IT_PNMT.NGAYDUSINH,SOLANMT,IT_THAITHANGTHU7.BATDAUTU,IT_THAITHANGTHU7.DENNGAY   "
            strSQL = strSQL + " FROM IT_PNMT LEFT JOIN IT_THAITHANGTHU7 ON (IT_PNMT.NV_MA = IT_THAITHANGTHU7.NV_MA AND IT_PNMT.NGAYVE15H30 = IT_THAITHANGTHU7.BATDAUTU AND IT_PNMT.NGAYDUSINH  <> IT_THAITHANGTHU7.DENNGAY)"
            strSQL = strSQL + " WHERE IT_THAITHANGTHU7.BATDAUTU  IS NOT NULL "
            strSQL = strSQL + " AND IT_PNMT.NV_MA ='" & obj.NV_MA & "'"
        End If
        ''=========== truy vấn ds đã chuyển vào thai tháng thứ 7 mà bị sảy thai ========''
        If obj.ChonBang = 87 Then
            strSQL = "SELECT distinct STT='', NULL AS [2],"
            strSQL = strSQL + "ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,NV_NAMSINH,"
            strSQL = strSQL + "ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + "ST_DONVI.DV_TEN AS DONVI,"
            strSQL = strSQL + "ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + "ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO,"
            strSQL = strSQL + "IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI,"
            strSQL = strSQL + "IT_PNMT.NGAYVE15H30 AS VE_15H30,"
            strSQL = strSQL + "IT_PNMT.NGAYDUSINH AS DUSINH,"
            strSQL = strSQL + "DA_NGHITS=(CASE WHEN (ISNULL(IT_PNMT.DANGNC,0)=1) THEN N'ĐANG NUÔI CON NHỎ' ELSE (CASE WHEN (ISNULL(IT_PNMT.DANGTS,0)=1)  THEN N'ĐANG NGHỈ TS' ELSE '' END)END),BDTS_NP AS BDTS_NP,KTTS_NP AS KTTS_NP"
            strSQL = strSQL + " FROM "
            strSQL = strSQL + " ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_"
            strSQL = strSQL + " INNER JOIN IT_PNMT ON ST_NHANVIEN.NV_MA=IT_PNMT.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_PNMT.NGAYVE15H30 >='" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_PNMT.NGAYVE15H30 <='" & obj.NgayCuoiThang & "'"
        End If

        ''=========== truy vấn ds đã chuyển vào thai tháng thứ 7 mà bị sảy thai ========''
        If obj.ChonBang = 88 Then
            strSQL = "Select STT='', NULL AS [2],CONVERT(BIT,'0') AS [3]"
            strSQL = strSQL + ",IT_PNMT.NV_MA AS MA"
            strSQL = strSQL + ",ST_NHANVIEN.NV_TEN AS TEN"
            strSQL = strSQL + ",NV_NGAYSINH= (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END)"
            strSQL = strSQL + ",NV_NAMSINH"
            strSQL = strSQL + ",ST_CONGVIEC.CV_TEN AS CONGVIEC"
            strSQL = strSQL + ",ST_DONVI.DV_TEN AS DONVI"
            strSQL = strSQL + ",CVU_TEN AS CHUCVU"
            strSQL = strSQL + ",ST_NHANVIEN.NV_NGAYVAO AS NGAYVAO"
            strSQL = strSQL + ",IT_PNMT.NGAYMANGTHAI AS BDAU_MANGTHAI "
            strSQL = strSQL + ",SOLANMT "
            strSQL = strSQL + ",IT_PNMT.NGAYVE15H30 AS VE_15H30"
            strSQL = strSQL + ",IT_PNMT.NGAYDUSINH AS DUSINH"
            strSQL = strSQL + ",IT_THAITHANGTHU7.BATDAUTU AS NGAYBD_TT7"
            strSQL = strSQL + ",IT_THAITHANGTHU7.DENNGAY  AS NGAYKT_TT7"
            strSQL = strSQL + ",IT_PNMT_SAYTHAI.NGAYSAYTHAI AS NGAYBDST"
            strSQL = strSQL + ",IT_PNMT_SAYTHAI.NGAYKTSAYTHAI AS NGAYKTST"

            strSQL = strSQL + " FROM IT_PNMT INNER JOIN IT_THAITHANGTHU7  "
            strSQL = strSQL + " ON (IT_PNMT.NV_MA = IT_THAITHANGTHU7.NV_MA AND IT_PNMT.NGAYVE15H30 = IT_THAITHANGTHU7.BATDAUTU  "
            strSQL = strSQL + " AND (IT_PNMT.NGAYDUSINH  = IT_THAITHANGTHU7.DENNGAY OR (IT_PNMT.NGAYDUSINH  <> IT_THAITHANGTHU7.DENNGAY)))"
            strSQL = strSQL + " INNER JOIN IT_PNMT_SAYTHAI ON (IT_PNMT.NV_MA = IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT_SAYTHAI.NGAYMANGTHAI = IT_PNMT.NGAYMANGTHAI )"
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIEN.NV_Ma = IT_PNMT.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA=ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.BATDAUTU >=N'" & obj.NgayDauThang & "'"
            strSQL = strSQL + " AND IT_THAITHANGTHU7.BATDAUTU <=N'" & obj.NgayCuoiThang & "'"
            If obj.Xuong = "TCT" Then
                strSQL = strSQL + ""
            Else
                strSQL = strSQL + " AND ST_DONVI.X_MA_ = '" & obj.Xuong & "'"
            End If
        End If

        ''=================== PHAN QUYEN THEM XOA SUA FORM NHAP PHEP =================''
        If obj.ChonBang = 89 Then
            strSQL = ("SELECT * from JELL_USER WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
        End If
        If obj.ChonBang = 90 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "' AND (Ma_DM ='1frmPhuNuMangThaiKThaiYte' OR Ma_DM ='2frmPhuNuMangThaiKThaiYte') ")
        End If

        If obj.ChonBang = 94 Then
            ''tu hien thi ngay mang thai,ve15h30,dusinh
            strSQL = "SELECT NV_MA AS MA,NGAYMANGTHAI =CONVERT(NVARCHAR(10),NGAYMANGTHAI,105),NGAYVE15H30 AS VE15H30,NGAYDUSINH AS DUSINH "
            strSQL = strSQL + ",(CASE WHEN NOT GHICHU_ST IS NULL THEN 1 ELSE 0 END) AS SAYTHAI "
            strSQL = strSQL + " FROM IT_PNMT"
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA='" & obj.NV_MA & "'"
        End If

        If obj.ChonBang = 95 Then
            strSQL = "SELECT (CASE WHEN (COUNT(IT_PNMT.NV_MA))=1 THEN 1 "
            strSQL = strSQL + " ELSE "
            strSQL = strSQL + " (CASE WHEN (COUNT (IT_PNMT.NV_MA))>1 THEN COUNT (IT_PNMT.NV_MA)"
            strSQL = strSQL + " ELSE 0 END) END) AS SOLAN_MT,IT_PNMT.NV_MA AS MA FROM IT_PNMT "
            strSQL = strSQL + " WHERE IT_PNMT.NV_MA='" & obj.NV_MA & "'"
            strSQL = strSQL + " GROUP BY IT_PNMT.NV_MA"

        End If

        If obj.ChonBang = 96 Then
            ''tim kiem thong tin ve cac lan mang thai dua vao sothe: CHINH SUA NGAY 09-08-2013
            ''============== hieu chinh ngay 23/07/2014 thay doi thu tu join giua cac bang ==================''
            Dim Ngaymangthai_tim As String = obj.NgayMangThai.Year.ToString() + "/" + obj.NgayMangThai.Month.ToString() + "/" + obj.NgayMangThai.Day.ToString()

            strSQL = "SELECT ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_TEN,IT_PNMT.NGAYMANGTHAI,IT_PNMT.NGAYVE15H30 as VE15H30 ,NGAYDUSINH as DUSINH"
            strSQL = strSQL + ",NGAYSANH = (CASE WHEN ISNULL(NGAYSANH,'') <> '' THEN NGAYSANH ELSE '' END),TUNGAY=CONVERT(CHAR(10),TUNGAY,105),DENNGAY=CONVERT(CHAR(10),DENNGAY,105),CHONNGAYSANH,NGAYGIAHAN,CHONSAYTHAI"
            strSQL = strSQL + ",BATDAU_NC = CASE WHEN NGAYSANH <> '' THEN convert (datetime,NGAYSANH,103) ELSE NULL END "
            strSQL = strSQL + ",KETTHUC_NC = CASE WHEN NGAYSANH <> '' THEN DATEADD (YEAR,1,convert (datetime,NGAYSANH,103)) ELSE NULL END "
            strSQL = strSQL + ",SONGAYNUOICON=DATEDIFF(D,CONVERT(DATETIME,IT_NUOICONDUOI12THANG.NGAYSANH,105),DATEADD(M,12,CONVERT(DATETIME,IT_NUOICONDUOI12THANG.NGAYSANH,103)))  "
            strSQL = strSQL + " ,NGAYBD_DS = IT_PNMT.BD_DUONGSUC,NGAYKT_DS=IT_PNMT .KT_DUONGSUC,LAN1 ,LAN2 ,LAN3 ,LAN4 ,LAN5   ,NGAYSAYTHAI ,NGAYKTSAYTHAI "

            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN  IT_PNMT  ON ST_NHANVIEN.NV_MA = IT_PNMT.NV_MA  "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA "
            strSQL = strSQL + " INNER JOIN ST_NXUONG ON ST_NXUONG.X_MA_=ST_DONVI.X_MA_  LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA=ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN IT_NUOICONDUOI12THANG ON (IT_PNMT.NV_MA=IT_NUOICONDUOI12THANG.NV_MA and SOLAN = SOLANMT ) "
            strSQL = strSQL + " LEFT JOIN IT_PNMT_KHAMTHAI  ON (IT_PNMT.NV_MA=IT_PNMT_KHAMTHAI.NV_MA and IT_PNMT.NGAYMANGTHAI  = IT_PNMT_KHAMTHAI.NGAYMANGTHAI  ) "
            strSQL = strSQL + " LEFT JOIN IT_PNMT_SAYTHAI ON (IT_PNMT.NV_MA = IT_PNMT_SAYTHAI.NV_MA AND IT_PNMT.NGAYMANGTHAI = IT_PNMT_SAYTHAI .NGAYMANGTHAI )"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA='" & obj.NV_MA & "' AND IT_PNMT.NGAYMANGTHAI ='" & Ngaymangthai_tim & "'"
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


    Public Function InsertInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Dim flag As Boolean
        Dim strSQL As String

        Dim strSQL1 As String
        ''doi dinh dang ngay thang nam chen vao he thong
        Dim Ngaymangthai_moi As String = obj.NgayMangThai.Year.ToString() + "/" + obj.NgayMangThai.Month.ToString() + "/" + obj.NgayMangThai.Day.ToString()
        Dim ve15h30_moi As String = obj.NgayVe15H30.Year.ToString() + "/" + obj.NgayVe15H30.Month.ToString() + "/" + obj.NgayVe15H30.Day.ToString()
        Dim Ngaydusinh_moi As String = obj.NgayDuSinh.Year.ToString() + "/" + obj.NgayDuSinh.Month.ToString() + "/" + obj.NgayDuSinh.Day.ToString()

        strSQL = "INSERT INTO IT_PNMT"
        strSQL = strSQL + " (NV_MA"
        strSQL = strSQL + ",NGAYMANGTHAI"
        strSQL = strSQL + ",NGAYVE15H30"
        strSQL = strSQL + ",NGAYDUSINH,NGAYLOAD"
        strSQL = strSQL + ")"
        strSQL = strSQL + " VALUES(" & "'" & obj.NV_MA & "',"
        strSQL = strSQL + "'" & Ngaymangthai_moi & "',"
        strSQL = strSQL + "'" & ve15h30_moi & "',"
        strSQL = strSQL + "'" & Ngaydusinh_moi & "','" & obj.NgayNhap & "')"

        obj.TruyVan = strSQL
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.Get_HanhDong = 0
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
    Public Function UpdateInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = ""
        Dim Ngaydusinh_moi As String = Date.Parse(obj.NgayDuSinh).Year.ToString() + "/" + Date.Parse(obj.NgayDuSinh).Month.ToString() + "/" + Date.Parse(obj.NgayDuSinh).Day.ToString()
        Dim Ngayve15h30 As String = Date.Parse(obj.NgayVe15H30).Year.ToString() + "/" + Date.Parse(obj.NgayVe15H30).Month.ToString() + "/" + Date.Parse(obj.NgayVe15H30).Day.ToString()
        If obj.ChonBang = 6 Then
            strSQL = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE IT_PNMT SET NGAYDUSINH= N'", Me.QuoteString(Ngaydusinh_moi), "' where NV_MA = N'", Me.QuoteString(obj.NV_MA), "' AND NGAYMANGTHAI = N'", Me.QuoteString(obj.NgayMT)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            obj.TruyVan = strSQL & " ngayve15h30cu = '" & obj.NgayVe15H30Cu & "',ngaydusinhcu='" & obj.NgayDuSinhCu & "'"
            obj.Get_HanhDong = 1
        End If

        ''======== CẬP NHẬT CỘT DACHYENTT7 trong bảng PNMT 
        If obj.ChonBang = 7 Then
            strSQL = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE IT_PNMT SET DACHUYEN_TT7 = ", obj.DachuyenTT7, " where NV_MA = N'", Me.QuoteString(obj.NV_MA), "' AND NGAYVE15H30 = N'", Me.QuoteString(Ngayve15h30)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            obj.Get_HanhDong = 1
        End If



        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text

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
    Public Function CapNhatSayThaiNuoiConNho(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = ""
        strSQL = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE IT_NUOICONDUOI12THANG SET CHONSAYTHAI = 1 WHERE NV_MA = N'", Me.QuoteString(obj.NV_MA), " ' AND TUNGAY = N'", Me.QuoteString(obj.Batdautu), "' AND DENNGAY = N'", Me.QuoteString(obj.DenNgay)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj.Get_HanhDong = 7
        obj.TruyVan = strSQL
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function DeleteInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Dim strSQL2 As String = ""
        Dim chuoi As String = ""
        Dim Ngaymangthai_xoa As String = obj.NgayMangThai.Year.ToString() + "/" + obj.NgayMangThai.Month.ToString() + "/" + obj.NgayMangThai.Day.ToString()
        strSQL2 = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL2 = ((((strSQL2 & " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE " & ChrW(13) & ChrW(10)) & "delete from IT_PNMT where NV_MA = '" & obj.NV_MA & "' AND NGAYMANGTHAI='" & Ngaymangthai_xoa & "'" & ChrW(13) & ChrW(10) & " if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & " ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION"))
        obj.TruyVan = strSQL2
        obj.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        obj.Get_HanhDong = 2
        Return Me.execSQL(strSQL2)
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
    Public Function LayThaiSanTrongNP(ByVal m_sSP_Name As String)
        Me.execProc(m_sSP_Name)
    End Function
End Class
