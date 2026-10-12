Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDCapNhatHoSoQuanHe
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As objCapNhatHoSoQuanHe) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where NV_MA = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        ''================= truy van load cua tab quan he =========''
        'Cau truy van load don vi len combo donvi
        If obj.ChonBang = 2 Then
            strSQL = "SELECT DV_MA "
            strSQL = strSQL + " FROM ST_DONVI WHERE DV_MA <> ' ' "
            strSQL = strSQL + " AND DV_MA IN ('CNM','NX A1','NX A1A2','NX A2','NX B1','NX B2','NX GCIL','NX R1','NX R2','NX R3','NX VP')"
            strSQL = strSQL + " ORDER BY DV_MA ASC"
        End If

        If obj.ChonBang = 27 Then
            'strSQL = ("SELECT ST_NHANVIEN.NV_MA,IT_NHANVIENQUANHE.TEN_QH AS NV_TEN,ST_NHANVIEN.DV_MA,IT_NHANVIENQUANHE.MA_QH,IT_NHANVIENQUANHE.STT,IT_NHANVIENQUANHE.NGAYSINH_QH,IT_NHANVIENQUANHE.TENTHUONGGOI,IT_NHANVIENQUANHE.NGHENGHIEP_QH,IT_NHANVIENQUANHE.NOICONGTAC,IT_NHANVIENQUANHE.DIACHI_QH,IT_NHANVIENQUANHE.SOCMND_QH,IT_NHANVIENQUANHE.NGAYCAP_QH,IT_NHANVIENQUANHE.TAI_QH,IT_NHANVIENQUANHE.SOTHE,IT_NHANVIENQUANHE.COLAMVIEC FROM ST_NHANVIEN INNER JOIN IT_NHANVIENQUANHE ON ST_NHANVIEN.NV_MA = IT_NHANVIENQUANHE.NV_MA ")
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,IT_NHANVIENQUANHE.TEN_QH AS NV_TEN,ST_NHANVIEN.DV_MA,IT_NHANVIENQUANHE.MA_QH,IT_NHANVIENQUANHE.STT,(CASE WHEN ISNULL(NVQH_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),IT_NHANVIENQUANHE.NGAYSINH_QH,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),IT_NHANVIENQUANHE.NGAYSINH_QH,21),4)) END) AS NGAYSINH_QH,IT_NHANVIENQUANHE.TENTHUONGGOI,IT_NHANVIENQUANHE.NGHENGHIEP_QH,IT_NHANVIENQUANHE.NOICONGTAC,IT_NHANVIENQUANHE.DIACHI_QH,IT_NHANVIENQUANHE.SOCMND_QH,IT_NHANVIENQUANHE.NGAYCAP_QH,IT_NHANVIENQUANHE.TAI_QH,IT_NHANVIENQUANHE.SOTHE,IT_NHANVIENQUANHE.COLAMVIEC ,NVQH_NAMSINH = ISNULL(NVQH_NAMSINH,0),NGAYSINH_QHTT = IT_NHANVIENQUANHE.NGAYSINH_QH FROM ST_NHANVIEN INNER JOIN IT_NHANVIENQUANHE ON ST_NHANVIEN.NV_MA = IT_NHANVIENQUANHE.NV_MA ")
        End If
        If obj.ChonBang = 28 Then
            strSQL = ("SELECT * FROM IT_NHANVIENQUANHE WHERE NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' AND MA_QH = N'" & Me.QuoteString(obj.MaQH) & "' AND STT = N'" & Me.QuoteString(obj.SoTT) & "' ORDER BY NV_MA ASC")
        End If

        If obj.ChonBang = 29 Then
            strSQL = ("SELECT NV_MA,MA_QH FROM IT_NHANVIENQUANHE WHERE NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' AND MA_QH = N'" & Me.QuoteString(obj.MaQH) & "' ORDER BY NV_MA ASC")
        End If

        If obj.ChonBang = 30 Then
            strSQL = ("SELECT MA_QH, TEN_QH FROM IT_DANHMUCQUANHE  ORDER BY MA_QH ASC ")
        End If

        If obj.ChonBang = 31 Then
            strSQL = " SELECT "
            strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO,"
            strSQL = strSQL + " NV_DIACHI,"
            strSQL = strSQL + " DV_MA,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " CM_TEN,"
            'strSQL = strSQL + " NV_NGAYSINH,"
            strSQL = strSQL + " NV_NAMSINH =ISNULL(NV_NAMSINH,0),"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,"
            strSQL = strSQL + " NV_NGAYKHD, HD_LUONGCB,NV_NGAYSINH as NV_NGAYSINHTT, NV_CMND, NV_GioiTinh, NV_NoiCapCMND, NV_NgayCapCMND ,NV_DTDiDong,NV_Quequan"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA =  ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON ST_NHANVIEN.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' "
        End If

        If obj.ChonBang = 32 Then
            strSQL = ("SELECT MA_QH FROM IT_NHANVIENQUANHE WHERE NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' AND MA_QH = N'" & Me.QuoteString(obj.MaQH) & "'")
        End If

        If obj.ChonBang = 33 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,IT_NHANVIENQUANHE.TEN_QH AS NV_TEN,ST_NHANVIEN.DV_MA,IT_NHANVIENQUANHE.MA_QH,IT_NHANVIENQUANHE.STT,(CASE WHEN ISNULL(NVQH_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),IT_NHANVIENQUANHE.NGAYSINH_QH,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),IT_NHANVIENQUANHE.NGAYSINH_QH,21),4)) END) AS NGAYSINH_QH,IT_NHANVIENQUANHE.TENTHUONGGOI,IT_NHANVIENQUANHE.NGHENGHIEP_QH,IT_NHANVIENQUANHE.NOICONGTAC,IT_NHANVIENQUANHE.DIACHI_QH,IT_NHANVIENQUANHE.SOCMND_QH,IT_NHANVIENQUANHE.NGAYCAP_QH,IT_NHANVIENQUANHE.TAI_QH,IT_NHANVIENQUANHE.SOTHE,IT_NHANVIENQUANHE.COLAMVIEC ,NVQH_NAMSINH = ISNULL(NVQH_NAMSINH,0),NGAYSINH_QHTT = IT_NHANVIENQUANHE.NGAYSINH_QH , IT_NHANVIENQUANHE.SOSOHK_QH, IT_NHANVIENQUANHE.GIOITINH_QH,IT_NHANVIENQUANHE.MA_QHCHUHO, NOICAPKHAISINH_QH, SDT_QH FROM ST_NHANVIEN INNER JOIN IT_NHANVIENQUANHE ON ST_NHANVIEN.NV_MA = IT_NHANVIENQUANHE.NV_MA WHERE IT_NHANVIENQUANHE.NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "'")
        End If
        ''=============== PHAN QUYEN THEM XOA SUA ==========''
        If obj.ChonBang = 34 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '" & Me.QuoteString(obj.NGUOIDUNG) & "' AND Ma_DM ='1frmCapNhatHoSoNhanSu' ")
        End If
        If obj.ChonBang = 35 Then
            strSQL = ("SELECT MAQH_CHUHO, TENQH_CHUHO FROM IT_DANHMUCQUANHECHUHO  ORDER BY MAQH_CHUHO ASC ")
        End If
        If obj.ChonBang = 36 Then
            strSQL = ("SELECT * FROM IT_NHANVIENQUANHE WHERE NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' AND MA_QHCHUHO = 'CHUHO' ")
        End If

        If obj.ChonBang = 37 Then
            strSQL = ("SELECT C.XP_Ten+', '+B.QH_TEN+', '+A.TT_Ten AS NOIKHAISINH FROM ST_TINHTHANH A INNER JOIN ST_QUANHUYEN B ON A.TT_Ma=B.TT_MA INNER JOIN ST_XAPHUONG C ON A.TT_Ma=C.TT_MA AND B.QH_MA=C.QH_MA AND B.TT_MA=C.TT_MA INNER JOIN ST_NHANVIEN D ON A.TT_Ma=D.NV_TinhDC AND B.QH_MA=D.NV_QuanHuyenDC AND C.XP_Ma=D.NV_XaPhuongDC WHERE A.TT_MA=D.NV_TinhDC AND B.QH_MA=D.NV_QuanHuyenDC AND C.XP_Ma=D.NV_XaPhuongDC AND NV_Ma=N'" & Me.QuoteString(obj.MaNVQH) & "'")
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
    Public Function InsertInfo(ByVal obj As objCapNhatHoSoQuanHe) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        'If obj.ChonBang = 1 Then
        '    strSQL = ("INSERT INTO ST_NHANVIEN(NV_Ma, NV_Ten, DV_MA, DV_MA_, NV_MaTu, NV_GioiTinh,NV_Ngaysinh, NV_NAMSINH, NV_NoiSinh, NV_DiaChi, TT_MA,QT_MA, DT_MA, TG_MA, NV_Thuongtru, NV_Honnhan, NV_Socon, NOIDUNGBS, BSHS, NV_CMND, NV_NgayCapCMND, NV_NoiCapCMND, NV_DTNhaRieng, NV_DTDiDong, NV_Ngayvao, HV_MA, TH_MA, NN_MA, CV_MA, CVU_MA, NV_Ngaybonhiem, CM_MA, QH_MA,DANGVIEN,NGAYVAODANG,NOIVAO, HLHTNVN, TRINHDOCHINHTRI, NV_TinhQQ, NV_QuanHuyenQQ, NV_XaPhuongQQ, NV_QueQuan, NV_TinhDC, NV_QuanHuyenDC, NV_XaPhuongDC, NV_SoNhaDC) values(N'" & Me.QuoteString(obj.MaNV) & "',N'" & Me.QuoteString(obj.HoTen) & "',N'" & Me.QuoteString(obj.DonVi) & "',N'" & Me.QuoteString(obj.DonVi) & "',N'" & Me.QuoteString(obj.MaTu) & "',N'" & Me.QuoteString(obj.GioiTinh) & "',N'" & Me.QuoteString(obj.NgaySinh) & "',N'" & Me.QuoteString(obj.ChonNamSinh) & "',N'" & Me.QuoteString(obj.TinhThanh) & "',N'" & Me.QuoteString(obj.DiaChi) & "',N'" & Me.QuoteString(obj.TinhThanh) & "',N'" & Me.QuoteString(obj.QuocTich) & "',N'" & Me.QuoteString(obj.DanToc) & "',N'" & Me.QuoteString(obj.TonGiao) & "',N'" & Me.QuoteString(obj.ThuongTru) & "',N'" & Me.QuoteString(obj.HonNhan) & "',N'" & Me.QuoteString(obj.SoCon) & "',N'" & Me.QuoteString(obj.NOIDUNGBS) & "',N'" & Me.QuoteString(obj.BSHS) & "',N'" & Me.QuoteString(obj.SoCMND) & "',N'" & Me.QuoteString(obj.NgayCap) & "',N'" & Me.QuoteString(obj.NoiCap) & "',N'" & Me.QuoteString(obj.DTNhaRieng) & "',N'" & Me.QuoteString(obj.DTDD) & "',N'" & Me.QuoteString(obj.NgayVao) & "',N'" & Me.QuoteString(obj.TDHocVan) & "',N'" & Me.QuoteString(obj.TinHoc) & "',N'" & Me.QuoteString(obj.NgoaiNgu) & "',N'" & Me.QuoteString(obj.CongViec) & "',N'" & Me.QuoteString(obj.ChucVu) & "',N'" & Me.QuoteString(obj.NgayBoNhiem) & "',N'" & Me.QuoteString(obj.ChuyenMon) & "',N'" & Me.QuoteString(obj.QuanHuyen) & "','" & Me.QuoteString(obj.DANGVIEN) & "'," + obj.NgayVaoDang + ",N'" & Me.QuoteString(obj.NOIVAO) & "',N'" & Me.QuoteString(obj.TNVN) & "',N'" & Me.QuoteString(obj.TDCT) & "',N'" & Me.QuoteString(obj.TTQQ) & "',N'" & Me.QuoteString(obj.QHQQ) & "',N'" & Me.QuoteString(obj.XAQQ) & "',N'" & Me.QuoteString(obj.QUEQUAN) & "',N'" & Me.QuoteString(obj.TTDC) & "',N'" & Me.QuoteString(obj.QHDC) & "',N'" & Me.QuoteString(obj.XADC) & "',N'" & Me.QuoteString(obj.SONHA) & "')")
        'End If
        If obj.ChonBang = 2 Then
            strSQL = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
            strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
            strSQL = ((String.Concat(New String() {strSQL, "insert into IT_NHANVIENQUANHE([NV_MA],[MA_QH],[STT],[TEN_QH],[NGAYSINH_QH],[NVQH_NAMSINH],[TENTHUONGGOI],[NGHENGHIEP_QH],[NOICONGTAC],[DIACHI_QH],[SOCMND_QH],[NGAYCAP_QH],[TAI_QH], [SOTHE],[COLAMVIEC],[SOSOHK_QH],[GIOITINH_QH],[MA_QHCHUHO],[NOICAPKHAISINH_QH], [SDT_QH] ) values(N'", Me.QuoteString(obj.MaNVQH), "',N'", Me.QuoteString(obj.MaQH), "',N'", Me.QuoteString(obj.SoTT), "',N'", Me.QuoteString(obj.HoTenQH), "',N'", Me.QuoteString(obj.NgaySinhQH), "',N'", Me.QuoteString(obj.ChonNamSinhQH), "',N'", Me.QuoteString(obj.TENTHUONGGOI), "',N'", Me.QuoteString(obj.NGHENGHIEP), "',N'", Me.QuoteString(obj.NOICONGTAC), "',N'", Me.QuoteString(obj.DiaChiQH), "',N'", Me.QuoteString(obj.SoCMNDQH), "'," + obj.NgayCapQH + ",N'", Me.QuoteString(obj.CAPTAI), "',N'", Me.QuoteString(obj.SOTHE), "','", Me.QuoteString(obj.COLAMVIEC), "',N'", Me.QuoteString(obj.SoSoHK), "',N'", Me.QuoteString(obj.GioiTinhqh), "',N'", Me.QuoteString(obj.MaQHCHUHO), "',N'", Me.QuoteString(obj.NOICAPKHAISINH), "',N'", Me.QuoteString(obj.SDT)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function DeleteInfo(ByVal obj As objCapNhatHoSoQuanHe) As Boolean
        Dim strSQL As String
        strSQL = "DELETE IT_NHANVIENQUANHE WHERE NV_MA = '" & Me.QuoteString(obj.MaNVQH) & "'AND MA_QH =N'" & Me.QuoteString(obj.MaQH) & "'AND STT =N'" & Me.QuoteString(obj.SoTT) & "'"
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objCapNhatHoSoQuanHe) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)


        If obj.ChonBang = 29 Then
            strSQL = ("update IT_NHANVIENQUANHE set MA_QH=N'" & Me.QuoteString(obj.MaQH) & "',STT=N'" & Me.QuoteString(obj.SoTT) & "',TEN_QH=N'" & Me.QuoteString(obj.HoTenQH) & "',NGAYSINH_QH=N'" & Me.QuoteString(obj.NgaySinhQH) & "',NVQH_NAMSINH=N'" & Me.QuoteString(obj.ChonNamSinhQH) & "',TENTHUONGGOI=N'" & Me.QuoteString(obj.TENTHUONGGOI) & "',NGHENGHIEP_QH=N'" & Me.QuoteString(obj.NGHENGHIEP) & "',NOICONGTAC=N'" & Me.QuoteString(obj.NOICONGTAC) & "',DIACHI_QH=N'" & Me.QuoteString(obj.DiaChiQH) & "',SOCMND_QH=N'" & Me.QuoteString(obj.SoCMNDQH) & "',NGAYCAP_QH= " + obj.NgayCapQH + ",TAI_QH=N'" & Me.QuoteString(obj.CAPTAI) & "',SOTHE=N'" & Me.QuoteString(obj.SOTHE) & "',COLAMVIEC=N'" & Me.QuoteString(obj.COLAMVIEC) & "',GIOITINH_QH=N'" & Me.QuoteString(obj.GioiTinhqh) & "',SOSOHK_QH=N'" & Me.QuoteString(obj.SoSoHK) & "',NOICAPKHAISINH_QH=N'" & Me.QuoteString(obj.NOICAPKHAISINH) & "',SDT_QH=N'" & Me.QuoteString(obj.SDT) & "'  where MA_QH = N'" & Me.QuoteString(obj.MaQHLUOI) & "'AND NV_MA=N'" & Me.QuoteString(obj.MaNVQH) & "'AND STT=N'" & Me.QuoteString(obj.SoTTLUOI) & "'")
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
