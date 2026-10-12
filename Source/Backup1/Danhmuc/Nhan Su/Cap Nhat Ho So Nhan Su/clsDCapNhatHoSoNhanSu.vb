
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class clsDCapNhatHoSoNhanSu
    Inherits DALSQL
    Public Function getTable(ByVal m_sSP_Name As String)
        Dim table As DataTable
        'Thuc thi cau truy van
        Try
            table = Me.getTableProcedure(m_sSP_Name)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table
    End Function
    Public Function getTable_CoThamSo(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Dim table As DataTable
        'Thuc thi cau truy van
        Try
            table = Me.getTableProcedure(m_sSP_Name, SqlParam)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table
    End Function
    Public Function LoadDS(ByVal obj As objCapNhatHoSoNhanSu) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where NV_MA = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        'Cau truy van load don vi len combo donvi
        If obj.ChonBang = 2 Then
            strSQL = "SELECT DV_MA "
            strSQL = strSQL + " FROM ST_DONVI WHERE DV_MA <> ' ' "
            strSQL = strSQL + " AND DV_MA IN ('CNM','NX A1','NX A1A2','NX A2','NX B1','NX B2','NX GCIL','NX R1','NX R2','NX R3','NX VP')"
            strSQL = strSQL + " ORDER BY DV_MA ASC"
        End If

        'Cau truy van load quoc tich len combo quoc tich
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * FROM ST_QUOCTICH WHERE QT_MA <> ' ' ORDER BY QT_TEN ASC ")
        End If

        'Cau truy van load ton giao len combo ton giao
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT * FROM ST_TONGIAO WHERE TG_MA <> ' ' ORDER BY TG_TEN ASC ")
        End If

        'Cau truy van load dan toc len combo dan toc
        If obj.ChonBang = 5 Then
            strSQL = ("SELECT * FROM ST_DANTOC WHERE DT_MA <> ' ' ORDER BY DT_TEN ASC ")
        End If

        'Cau truy van load tinh thanh len combo tinh thanh
        If obj.ChonBang = 6 Then
            strSQL = ("SELECT * FROM ST_TINHTHANH WHERE TT_MA <> ' ' ORDER BY TT_Ten ASC ")
        End If

        'Cau truy van load ngoai ngu len combo ngoai ngu
        If obj.ChonBang = 7 Then
            strSQL = ("SELECT * FROM ST_NGOAINGU WHERE NN_MA <> ' ' ORDER BY NN_TEN ASC ")
        End If

        'Cau truy van load hoc van
        If obj.ChonBang = 8 Then
            strSQL = ("SELECT * FROM ST_HOCVAN WHERE HV_MA <> ' ' ORDER BY HV_TEN ASC ")
        End If

        'Cau truy van load chuyan mon len combo chuyen mon
        If obj.ChonBang = 9 Then
            strSQL = ("SELECT * FROM ST_CHUYENMON WHERE CM_MA <> ' ' ORDER BY CM_Ten ASC ")
        End If


        'Cau truy van load tin hoc len combo tin hoc
        If obj.ChonBang = 10 Then
            strSQL = ("SELECT * FROM ST_TINHOC WHERE TH_MA <> ' ' ORDER BY TH_TEN ASC ")
        End If


        'Cau truy van load chuc vu
        If obj.ChonBang = 11 Then
            strSQL = ("SELECT * FROM ST_CHUCVU WHERE CVU_MA <> ' ' ORDER BY CVU_TEN ASC ")
        End If

        'Cau truy van load cong viec
        If obj.ChonBang = 12 Then
            strSQL = ("SELECT * FROM ST_CONGVIEC WHERE CV_MA <> ' ' ORDER BY CV_TEN ASC ")
        End If

        'Cau truy van load tin hoc len combo tin hoc
        If obj.ChonBang = 13 Then
            strSQL = ""
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " where TT_MA = N'" & Me.QuoteString(obj.ID) & "'")
            End If
            strSQL = ("select * from ST_QUANHUYEN where TT_MA = N'" & Me.QuoteString(obj.ID) & " ' ORDER BY QH_TEN ASC")
        End If

        If obj.ChonBang = 133 Then
            strSQL = "select ST_XAPHUONG.XP_MA, ST_XAPHUONG.XP_TEN"
            strSQL = strSQL + " from ST_XAPHUONG "
            strSQL = strSQL + " where ST_XAPHUONG.QH_MA = N'" & Me.QuoteString(obj.ID) & "' AND ST_XAPHUONG.TT_Ma = N'" & Me.QuoteString(obj.TinhThanh) & "'"
            strSQL = strSQL + " ORDER BY ST_XAPHUONG.XP_TEN ASC"
        End If

        If obj.ChonBang = 15 Then
            strSQL = ""
            If (StringType.StrCmp(obj.MaNV, "", False) <> 0) Then
                strSQL = (strSQL & " where NV_MA = N'" & Me.QuoteString(obj.MaNV) & "'")
            End If
            strSQL = ("select * from ST_NHANVIEN where NV_MA = N'" & Me.QuoteString(obj.MaNV) & "' ORDER BY NV_MA ASC")
        End If


        If obj.ChonBang = 16 Then
            strSQL = ""
            If (StringType.StrCmp(obj.SoCMND, "", False) <> 0) Then
                strSQL = (strSQL & " where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
            End If
            strSQL = ("select ST_NHANVIEN.NV_Ma AS NV_MA , ST_NHANVIEN.NV_Ten AS NV_TEN, ST_NHANVIEN.NV_MaQL AS NV_MAQL, ST_NHANVIEN.DV_MA AS DV_MA, ST_NHANVIEN.NV_MaTu AS NV_MATU, ST_NHANVIEN.NV_GioiTinh AS NV_GIOITINH, ST_NHANVIEN.NV_Ngaysinh AS NV_NGAYSINH, ST_NHANVIEN.NV_NoiSinh AS NV_NOISINH, ST_NHANVIEN.NV_DiaChi AS NV_DIACHI, ST_NHANVIEN.TT_MA AS TT_MA, ST_NHANVIEN.QT_MA AS QT_MA, ST_NHANVIEN.DT_MA AS DT_MA, ST_NHANVIEN.TG_MA AS TG_MA, ST_NHANVIEN.NV_Thuongtru AS NV_THUONGTRU, ST_NHANVIEN.NV_Honnhan AS NV_HONNHAN, ST_NHANVIEN.NV_Socon AS NV_SOCON, ST_NHANVIEN.NV_CMND AS NV_CMND, ST_NHANVIEN.NV_NgayCapCMND AS NV_NGAYCAPCMND, ST_NHANVIEN.NV_NoiCapCMND AS NV_NOICAPCMND, ST_NHANVIEN.NV_DTNhaRieng AS NV_DTNHARIENG, ST_NHANVIEN.NV_DTDiDong AS NV_DTDIDONG, ST_NHANVIEN.NV_Ngayvao AS NV_NGAYVAO, ST_NHANVIEN.NV_Hinh AS NV_HINH, ST_NHANVIEN.HV_MA AS HV_MA, ST_NHANVIEN.TH_MA AS TH_MA, ST_NHANVIEN.NN_MA AS NN_MA, ST_CONGVIEC.CV_TEN AS CV_TEN, ST_NHANVIEN.CVU_MA AS CVU_MA, ST_NHANVIEN.NV_Ngaybonhiem AS NV_NGAYBONHIEM, ST_NHANVIEN.CM_MA AS CM_MA, ST_NHANVIEN.NV_Congdoan AS NV_CONGDOAN, ST_NHANVIEN.NV_NgayvaoCD AS NV_NGAYVAOCD, ST_NHANVIEN.NV_THOIVIEC AS NV_THOIVIEC, ST_NHANVIEN.NV_NgayTV AS NV_NGAYTV, ST_NHANVIEN.NV_NGAYKHD AS NV_NGAYKHD, ST_NHANVIEN.QH_MA AS QH_MA, ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA, ST_NHANVIEN.NV_DAKYHDLD AS NV_DAKYHDLD, ST_NHANVIEN.BSHS AS BSHS from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA LEFT JOIN ST_CONGVIEC ON ST_CONGVIEC.CV_MA = ST_NHANVIEN.CV_MA  where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If

        If obj.ChonBang = 22 Then
            strSQL = ("select ST_NHANVIEN.NV_Ma AS NV_MA , ST_NHANVIEN.NV_Ten AS NV_TEN, ST_NHANVIEN.NV_MaQL AS NV_MAQL, ST_NHANVIEN.DV_MA AS DV_MA, ST_NHANVIEN.NV_MaTu AS NV_MATU, ST_NHANVIEN.NV_GioiTinh AS NV_GIOITINH, ST_NHANVIEN.NV_Ngaysinh AS NV_NGAYSINH, ST_NHANVIEN.NV_NoiSinh AS NV_NOISINH, ST_NHANVIEN.NV_DiaChi AS NV_DIACHI, ST_NHANVIEN.TT_MA AS TT_MA, ST_NHANVIEN.QT_MA AS QT_MA, ST_NHANVIEN.DT_MA AS DT_MA, ST_NHANVIEN.TG_MA AS TG_MA, ST_NHANVIEN.NV_Thuongtru AS NV_THUONGTRU, ST_NHANVIEN.NV_Honnhan AS NV_HONNHAN, ST_NHANVIEN.NV_Socon AS NV_SOCON, ST_NHANVIEN.NV_CMND AS NV_CMND, ST_NHANVIEN.NV_NgayCapCMND AS NV_NGAYCAPCMND, ST_NHANVIEN.NV_NoiCapCMND AS NV_NOICAPCMND, ST_NHANVIEN.NV_DTNhaRieng AS NV_DTNHARIENG, ST_NHANVIEN.NV_DTDiDong AS NV_DTDIDONG, ST_NHANVIEN.NV_Ngayvao AS NV_NGAYVAO, ST_NHANVIEN.NV_Hinh AS NV_HINH, ST_NHANVIEN.HV_MA AS HV_MA, ST_NHANVIEN.TH_MA AS TH_MA, ST_NHANVIEN.NN_MA AS NN_MA,  ST_CONGVIEC.CV_TEN AS CV_TEN, ST_NHANVIEN.CVU_MA AS CVU_MA, ST_NHANVIEN.NV_Ngaybonhiem AS NV_NGAYBONHIEM, ST_NHANVIEN.CM_MA AS CM_MA, ST_NHANVIEN.NV_Congdoan AS NV_CONGDOAN, ST_NHANVIEN.NV_NgayvaoCD AS NV_NGAYVAOCD, ST_NHANVIEN.NV_THOIVIEC AS NV_THOIVIEC, DATEDIFF(MM,ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC,GETDATE()) AS SOTHANG, ST_NHANVIEN.NV_NGAYKHD AS NV_NGAYKHD, ST_NHANVIEN.QH_MA AS QH_MA, ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA, ST_NHANVIEN.NV_NGAYTV AS NV_NGAYTV , ST_NHANVIEN.NV_DAKYHDLD AS NV_DAKYHDLD, ST_NHANVIEN.BSHS AS BSHS  from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA LEFT JOIN ST_CONGVIEC ON ST_CONGVIEC.CV_MA = ST_NHANVIEN.CV_MA where NV_NGAYVAO = (SELECT MAX(NV_NGAYVAO)  FROM ST_NHANVIEN WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "') AND ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If

        If obj.ChonBang = 17 Then
            strSQL = ""
            strSQL = ("select * FROM ST_NHANVIENTHOIVIEC WHERE NV_MA = N'" & Me.QuoteString(obj.MaNV) & "' ")
        End If

        If obj.ChonBang = 23 Then
            strSQL = ("select MAX(CONVERT(INT,ST_NHANVIEN.NV_MA))+1 AS NV_MA from ST_NHANVIEN WHERE  (LEN(NV_MA )=5 AND LEN(NV_MA) <> 6)  ")
        End If
        'select manv+1，tăng tối đa đến 350000 để ko lập lại dãy mã của chuyên gia nước ngoài
        If obj.ChonBang = 233 Then
            strSQL = ("SELECT MAX(Convert(int,NV_Ma)) + 1 AS NV_MA FROM ST_NHANVIEN WHERE DV_MA_  NOT	LIKE 'CG%'  AND DV_MA_ NOT LIKE 'BGD' AND NV_Ma <'350000'")
        End If

        If obj.ChonBang = 24 Then

            strSQL = ("select  COUNT(ST_NHANVIENTHOIVIEC.LTV_MA) AS LTV_MA , ST_NHANVIENTHOIVIEC.LTV_MA as TV_LYDO  from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA  where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'GROUP BY ST_NHANVIENTHOIVIEC.LTV_MA ")
        End If

        If obj.ChonBang = 25 Then

            strSQL = ("select  COUNT(ST_NHANVIENTHOIVIEC.LTV_MA) AS LTV_MA , ST_NHANVIENTHOIVIEC.LTV_MA as TV_LYDO from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA  where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'GROUP BY ST_NHANVIENTHOIVIEC.LTV_MA ")
        End If

        If obj.ChonBang = 26 Then

            strSQL = ("select DATEDIFF(MM,ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC,GETDATE()) AS NV_NGAYTHOIVIEC from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA  where NV_NGAYVAO = (SELECT MAX(NV_NGAYVAO) FROM ST_NHANVIEN WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "') AND ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If
        If obj.ChonBang = 34 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '" & Me.QuoteString(obj.NGUOIDUNG) & "' AND Ma_DM ='1frmCapNhatHoSoNhanSu' ")
        End If
        If obj.ChonBang = 35 Then
            strSQL = ("SELECT QH_TENLOAI from ST_QUANHUYEN WHERE TT_MA = '" & Me.QuoteString(obj.Tinh) & "' AND QH_MA = '" & Me.QuoteString(obj.Huyen) & "'")
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
    Public Function InsertInfo(ByVal obj As objCapNhatHoSoNhanSu) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO ST_NHANVIEN(NV_Ma, NV_Ten, DV_MA, DV_MA_, NV_MaTu, NV_GioiTinh,NV_Ngaysinh, NV_NAMSINH, NV_NoiSinh, NV_DiaChi, TT_MA,QT_MA, DT_MA, TG_MA, NV_Thuongtru, NV_Honnhan, NV_Socon, NOIDUNGBS, BSHS, NV_CMND, NV_NgayCapCMND, NV_NoiCapCMND, NV_DTNhaRieng, NV_DTDiDong, NV_Ngayvao, HV_MA, TH_MA, NN_MA, CV_MA, CVU_MA, NV_Ngaybonhiem, CM_MA, QH_MA,DANGVIEN,NGAYVAODANG,NOIVAO, HLHTNVN, TRINHDOCHINHTRI, NV_TinhQQ, NV_QuanHuyenQQ, NV_XaPhuongQQ, NV_QueQuan, NV_TinhDC, NV_QuanHuyenDC, NV_XaPhuongDC, NV_SoNhaDC) values(N'" & Me.QuoteString(obj.MaNV) & "',N'" & Me.QuoteString(obj.HoTen) & "',N'" & Me.QuoteString(obj.DonVi) & "',N'" & Me.QuoteString(obj.DonVi) & "',N'" & Me.QuoteString(obj.MaTu) & "',N'" & Me.QuoteString(obj.GioiTinh) & "',N'" & Me.QuoteString(obj.NgaySinh) & "',N'" & Me.QuoteString(obj.ChonNamSinh) & "',N'" & Me.QuoteString(obj.TinhThanh) & "',N'" & Me.QuoteString(obj.DiaChi) & "',N'" & Me.QuoteString(obj.TinhThanh) & "',N'" & Me.QuoteString(obj.QuocTich) & "',N'" & Me.QuoteString(obj.DanToc) & "',N'" & Me.QuoteString(obj.TonGiao) & "',N'" & Me.QuoteString(obj.ThuongTru) & "',N'" & Me.QuoteString(obj.HonNhan) & "',N'" & Me.QuoteString(obj.SoCon) & "',N'" & Me.QuoteString(obj.NOIDUNGBS) & "',N'" & Me.QuoteString(obj.BSHS) & "',N'" & Me.QuoteString(obj.SoCMND) & "',N'" & Me.QuoteString(obj.NgayCap) & "',N'" & Me.QuoteString(obj.NoiCap) & "',N'" & Me.QuoteString(obj.DTNhaRieng) & "',N'" & Me.QuoteString(obj.DTDD) & "',N'" & Me.QuoteString(obj.NgayVao) & "',N'" & Me.QuoteString(obj.TDHocVan) & "',N'" & Me.QuoteString(obj.TinHoc) & "',N'" & Me.QuoteString(obj.NgoaiNgu) & "',N'" & Me.QuoteString(obj.CongViec) & "',N'" & Me.QuoteString(obj.ChucVu) & "',N'" & Me.QuoteString(obj.NgayBoNhiem) & "',N'" & Me.QuoteString(obj.ChuyenMon) & "',N'" & Me.QuoteString(obj.QuanHuyen) & "','" & Me.QuoteString(obj.DANGVIEN) & "'," + obj.NgayVaoDang + ",N'" & Me.QuoteString(obj.NOIVAO) & "',N'" & Me.QuoteString(obj.TNVN) & "',N'" & Me.QuoteString(obj.TDCT) & "',N'" & Me.QuoteString(obj.TTQQ) & "',N'" & Me.QuoteString(obj.QHQQ) & "',N'" & Me.QuoteString(obj.XAQQ) & "',N'" & Me.QuoteString(obj.QUEQUAN) & "',N'" & Me.QuoteString(obj.TTDC) & "',N'" & Me.QuoteString(obj.QHDC) & "',N'" & Me.QuoteString(obj.XADC) & "',N'" & Me.QuoteString(obj.SONHA) & "')")
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

    Public Function UpdateInfo(ByVal obj As objCapNhatHoSoNhanSu) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 18 Then
            strSQL = "UPDATE ST_NHANVIEN "
            strSQL = strSQL + " SET NV_Ten = N'" + Me.QuoteString(obj.HoTen) + "',"
            strSQL = strSQL + " NV_MaTu = N'" + Me.QuoteString(obj.MaTu) + "',"
            strSQL = strSQL + " DV_MA = N'" + Me.QuoteString(obj.DonVi) + "',"
            strSQL = strSQL + " NV_Ngaysinh = N'" + Me.QuoteString(obj.NgaySinh) + "',"
            strSQL = strSQL + " NV_CMND = N'" + Me.QuoteString(obj.SoCMND) + "',"
            strSQL = strSQL + " NV_NgayCapCMND = N'" + Me.QuoteString(obj.NgayCap) + "',"
            strSQL = strSQL + " NV_GioiTinh = N'" + Me.QuoteString(obj.GioiTinh) + "',"
            strSQL = strSQL + " NV_NoiCapCMND = N'" + Me.QuoteString(obj.NoiCap) + "',"
            strSQL = strSQL + " NV_NoiSinh = N'" + Me.QuoteString(obj.TinhThanh) + "',"
            strSQL = strSQL + " NV_DiaChi = N'" + Me.QuoteString(obj.DiaChi) + "',"
            strSQL = strSQL + " Mail = N'" + Me.QuoteString(obj.Mail) + "',"
            strSQL = strSQL + " NV_Thuongtru = N'" + Me.QuoteString(obj.ThuongTru) + "',"
            strSQL = strSQL + " NV_DTNhaRieng = N'" + Me.QuoteString(obj.DTNhaRieng) + "',"
            strSQL = strSQL + " NV_DTDiDong = N'" + Me.QuoteString(obj.DTDD) + "',"
            strSQL = strSQL + " NV_Honnhan = N'" + Me.QuoteString(obj.HonNhan) + "',"
            strSQL = strSQL + " NV_Socon = N'" + Me.QuoteString(obj.SoCon) + "',"
            strSQL = strSQL + " NOIDUNGBS = N'" + Me.QuoteString(obj.NOIDUNGBS) + "',"
            strSQL = strSQL + " BSHS = N'" + Me.QuoteString(obj.BSHS) + "',"
            strSQL = strSQL + " DANGVIEN = N'" + Me.QuoteString(obj.DANGVIEN) + "',"
            strSQL = strSQL + " NGAYVAODANG= " + obj.NgayVaoDang + ","
            strSQL = strSQL + " NOIVAO = N'" + Me.QuoteString(obj.NOIVAO) + "',"
            strSQL = strSQL + " HLHTNVN = N'" + Me.QuoteString(obj.TNVN) + "',"
            strSQL = strSQL + " TRINHDOCHINHTRI = N'" + Me.QuoteString(obj.TDCT) + "',"
            strSQL = strSQL + " QT_MA = N'" + Me.QuoteString(obj.QuocTich) + "',"
            strSQL = strSQL + " DT_MA = N'" + Me.QuoteString(obj.DanToc) + "',"
            strSQL = strSQL + " TG_MA = N'" + Me.QuoteString(obj.TonGiao) + "',"
            strSQL = strSQL + " TT_MA = N'" + Me.QuoteString(obj.TinhThanh) + "',"
            strSQL = strSQL + " HV_MA = N'" + Me.QuoteString(obj.TDHocVan) + "',"
            strSQL = strSQL + " QH_MA = N'" + Me.QuoteString(obj.QuanHuyen) + "',"
            strSQL = strSQL + " CM_MA = N'" + Me.QuoteString(obj.ChuyenMon) + "',"
            strSQL = strSQL + " NN_MA = N'" + Me.QuoteString(obj.NgoaiNgu) + "',"
            'strSQL = strSQL + " CV_MA = N'" + Me.QuoteString(obj.CongViec) + "',"
            strSQL = strSQL + " TH_MA = N'" + Me.QuoteString(obj.TinHoc) + "',"
            strSQL = strSQL + " NV_Ngayvao = N'" + Me.QuoteString(obj.NgayVao) + "',"
            strSQL = strSQL + " CVU_MA = N'" + Me.QuoteString(obj.ChucVu) + "',"
            strSQL = strSQL + " NV_Ngaybonhiem = N'" + Me.QuoteString(obj.NgayBoNhiem) + "',"
            strSQL = strSQL + " NV_NAMSINH = N'" + Me.QuoteString(obj.ChonNamSinh) + "',"
            strSQL = strSQL + " NV_TinhQQ = N'" + Me.QuoteString(obj.TTQQ) + "',"
            strSQL = strSQL + " NV_QuanHuyenQQ = N'" + Me.QuoteString(obj.QHQQ) + "',"
            strSQL = strSQL + " NV_XaPhuongQQ = N'" + Me.QuoteString(obj.XAQQ) + "',"
            strSQL = strSQL + " NV_QueQuan = N'" + Me.QuoteString(obj.QUEQUAN) + "',"
            strSQL = strSQL + " NV_TinhDC = N'" + Me.QuoteString(obj.TTDC) + "',"
            strSQL = strSQL + " NV_QuanHuyenDC = N'" + Me.QuoteString(obj.QHDC) + "',"
            strSQL = strSQL + " NV_XaPhuongDC = N'" + Me.QuoteString(obj.XADC) + "',"
            strSQL = strSQL + " NV_SoNhaDC = N'" + Me.QuoteString(obj.SONHA) + "',"
            strSQL = strSQL + " KHUA = N'" + Me.QuoteString(obj.A) + "',"
            strSQL = strSQL + " KHUB = N'" + Me.QuoteString(obj.B) + "',"
            strSQL = strSQL + " NGUOICAPNHAT = N'" + Me.QuoteString(obj.NGUOICAPNHAT) + "',"
            strSQL = strSQL + " NGAYCAPNHAT = N'" + Me.QuoteString(obj.NGAYCAPNHAT) + "',"
            strSQL = strSQL + " TenVaccine_1 = N'" + Me.QuoteString(obj.TENVACCINE_1) + "',"
            strSQL = strSQL + " NgayVaccine_1 = " + obj.NGAYVACCINE_1 + ","
            strSQL = strSQL + " TenVaccine_2 = N'" + Me.QuoteString(obj.TENVACCINE_2) + "',"
            strSQL = strSQL + " NgayVaccine_2 = " + obj.NGAYVACCINE_2 + ","
            strSQL = strSQL + " TenVaccine_3 = N'" + Me.QuoteString(obj.TENVACCINE_3) + "',"
            strSQL = strSQL + " NgayVaccine_3 = " + obj.NGAYVACCINE_3 + ","
            strSQL = strSQL + " TenVaccine_4 = N'" + Me.QuoteString(obj.TENVACCINE_4) + "',"
            strSQL = strSQL + " NgayVaccine_4 = " + obj.NGAYVACCINE_4 + ","
            strSQL = strSQL + " TenVaccine_5 = N'" + Me.QuoteString(obj.TENVACCINE_5) + "',"
            strSQL = strSQL + " NgayVaccine_5 = " + obj.NGAYVACCINE_5 + ","
            strSQL = strSQL + " TenVaccine_6 = N'" + Me.QuoteString(obj.TENVACCINE_6) + "',"
            strSQL = strSQL + " NgayVaccine_6 = " + obj.NGAYVACCINE_6
            strSQL = strSQL + " WHERE NV_MA = '" + obj.MaNV + "'"
        End If
        If obj.ChonBang = 19 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_THOIVIEC = 1, ST_NHANVIEN.NV_NgayTV = (SELECT ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = N'", Me.QuoteString(obj.MaNV), "') where  NV_MA = N'", Me.QuoteString(obj.MaNV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 20 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_THOIVIEC = 0"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 21 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_THOIVIEC = 1, ST_NHANVIEN.NV_NgayTV = ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC FROM ST_NHANVIEN INNER JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA "}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 28 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set ST_NHANVIEN.NV_DAKYHDLD = 0,ST_NHANVIEN.NV_NGAYKHD = NULL "}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If
        If obj.ChonBang = 27 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_NHANVIEN  SET ST_NHANVIEN.NV_NGAYKHD = ST_HOPDONGLAODONG.HD_NgayKy , ST_NHANVIEN.NV_DAKYHDLD = 1 FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If
        'If obj.ChonBang = 29 Then
        '    strSQL = () {"update IT_NHANVIENQUANHE set MA_QH=N'", Me.QuoteString(obj.MaQH), "',TEN_QH=N'", Me.QuoteString(obj.HoTenQH), "',NGAYSINH_QH=N'", Me.QuoteString(obj.NgaySinhQH), "',TENTHUONGGOI=N'", Me.QuoteString(obj.TENTHUONGGOI), "',NGHENGHIEP_QH=N'", Me.QuoteString(obj.NGHENGHIEP), "',NOICONGTAC=N'", Me.QuoteString(obj.NOICONGTAC), "',DIACHI_QH=N'", Me.QuoteString(obj.DiaChiQH), "',SOCMND_QH=N'", Me.QuoteString(obj.SoCMNDQH), "',NGAYCAP_QH=N'", Me.QuoteString(obj.NgayCapQH), "',TAI_QH=N'", Me.QuoteString(obj.CAPTAI), "',COLAMVIEC=N'", Me.QuoteString(obj.COLAMVIEC), "' where  MA_QH = N'",ME.QuoteString (OBJ.MaQHLUOI)"'AND NV_MA=N'", Me.QuoteString(obj.MaNVQH)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'End If

        If obj.ChonBang = 29 Then
            strSQL = ("update IT_NHANVIENQUANHE set MA_QH=N'" & Me.QuoteString(obj.MaQH) & "',STT=N'" & Me.QuoteString(obj.SoTT) & "',TEN_QH=N'" & Me.QuoteString(obj.HoTenQH) & "',NGAYSINH_QH=N'" & Me.QuoteString(obj.NgaySinhQH) & "',NVQH_NAMSINH=N'" & Me.QuoteString(obj.ChonNamSinhQH) & "',TENTHUONGGOI=N'" & Me.QuoteString(obj.TENTHUONGGOI) & "',NGHENGHIEP_QH=N'" & Me.QuoteString(obj.NGHENGHIEP) & "',NOICONGTAC=N'" & Me.QuoteString(obj.NOICONGTAC) & "',DIACHI_QH=N'" & Me.QuoteString(obj.DiaChiQH) & "',SOCMND_QH=N'" & Me.QuoteString(obj.SoCMNDQH) & "',NGAYCAP_QH= " + obj.NgayCapQH + ",TAI_QH=N'" & Me.QuoteString(obj.CAPTAI) & "',SOTHE=N'" & Me.QuoteString(obj.SOTHE) & "',COLAMVIEC=N'" & Me.QuoteString(obj.COLAMVIEC) & "'  where MA_QH = N'" & Me.QuoteString(obj.MaQHLUOI) & "'AND NV_MA=N'" & Me.QuoteString(obj.MaNVQH) & "'AND STT=N'" & Me.QuoteString(obj.SoTTLUOI) & "'")
        End If
        ''============ cap nhat danh sach doan vien vao cot NV_Congdoan ================
        If obj.ChonBang = 35 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_Congdoan = 0 WHERE NV_Ma NOT IN (SELECT SOTHE FROM IT_CONGDOAN)"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 36 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_Congdoan = 1 WHERE NV_Ma IN (SELECT SOTHE FROM IT_CONGDOAN)"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 37 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_TUOI = year(GETDATE()) - year(NV_NGAYSINH) FROM ST_NHANVIEN"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function ThemMoi_NhanVien(ByVal obj As objCapNhatHoSoNhanSu) As Boolean
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@MaNV", obj.MaNV))
        listpar.Add(New SqlParameter("@HoTen", obj.HoTen))
        listpar.Add(New SqlParameter("@DonVi", obj.DonVi))
        listpar.Add(New SqlParameter("@MaTu", obj.MaTu))
        listpar.Add(New SqlParameter("@GioiTinh", obj.GioiTinh))
        listpar.Add(New SqlParameter("@NgaySinh", obj.NgaySinh))
        listpar.Add(New SqlParameter("@TinhThanh", obj.TinhThanh))
        listpar.Add(New SqlParameter("@DiaChi", obj.DiaChi))
        listpar.Add(New SqlParameter("@Mail", obj.Mail))
        listpar.Add(New SqlParameter("@QuocTich", obj.QuocTich))
        listpar.Add(New SqlParameter("@DanToc", obj.DanToc))
        listpar.Add(New SqlParameter("@TonGiao", obj.TonGiao))
        listpar.Add(New SqlParameter("@ThuongTru", obj.ThuongTru))
        listpar.Add(New SqlParameter("@HonNhan", obj.HonNhan))
        listpar.Add(New SqlParameter("@SoCon", obj.SoCon))
        listpar.Add(New SqlParameter("@NOIDUNGBS", obj.NOIDUNGBS))
        listpar.Add(New SqlParameter("@BSHS", obj.BSHS))
        listpar.Add(New SqlParameter("@SoCMND", obj.SoCMND))
        listpar.Add(New SqlParameter("@NgayCap", obj.NgayCap))
        listpar.Add(New SqlParameter("@NoiCap", obj.NoiCap))
        listpar.Add(New SqlParameter("@DTNhaRieng", obj.DTNhaRieng))
        listpar.Add(New SqlParameter("@DTDD", obj.DTDD))
        listpar.Add(New SqlParameter("@NgayVao", obj.NgayVao))
        listpar.Add(New SqlParameter("@TDHocVan", obj.TDHocVan))
        listpar.Add(New SqlParameter("@TinHoc", obj.TinHoc))
        listpar.Add(New SqlParameter("@NgoaiNgu", obj.NgoaiNgu))
        listpar.Add(New SqlParameter("@CongViec", "A13-075"))
        listpar.Add(New SqlParameter("@ChucVu", obj.ChucVu))
        listpar.Add(New SqlParameter("@NgayBoNhiem", obj.NgayBoNhiem))
        listpar.Add(New SqlParameter("@ChuyenMon", obj.ChuyenMon))
        listpar.Add(New SqlParameter("@QuanHuyen", obj.QuanHuyen))
        listpar.Add(New SqlParameter("@DANGVIEN", obj.DANGVIEN))
        listpar.Add(New SqlParameter("@NgayVaoDang", obj.NgayVaoDang))
        listpar.Add(New SqlParameter("@NOIVAO", obj.NOIVAO))
        listpar.Add(New SqlParameter("@TNVN", obj.TNVN))
        listpar.Add(New SqlParameter("@TDCT", obj.TDCT))
        listpar.Add(New SqlParameter("@TTQQ", obj.TTQQ))
        listpar.Add(New SqlParameter("@QHQQ", obj.QHQQ))
        listpar.Add(New SqlParameter("@XAQQ", obj.XAQQ))
        listpar.Add(New SqlParameter("@QUEQUAN", obj.QUEQUAN))
        listpar.Add(New SqlParameter("@TTDC", obj.TTDC))
        listpar.Add(New SqlParameter("@QHDC", obj.QHDC))
        listpar.Add(New SqlParameter("@XADC", obj.XADC))
        listpar.Add(New SqlParameter("@SONHA", obj.SONHA))
        listpar.Add(New SqlParameter("@KHUA", obj.A))
        listpar.Add(New SqlParameter("@KHUB", obj.B))
        listpar.Add(New SqlParameter("@NAMSINH", obj.ChonNamSinh))
        listpar.Add(New SqlParameter("@NGUOITAO", obj.NGUOITAO))
        listpar.Add(New SqlParameter("@TenVaccine_1", obj.TENVACCINE_1))
        listpar.Add(New SqlParameter("@NgayVaccine_1", obj.NGAYVACCINE_1))
        listpar.Add(New SqlParameter("@TenVaccine_2", obj.TENVACCINE_2))
        listpar.Add(New SqlParameter("@NgayVaccine_2", obj.NGAYVACCINE_2))
        listpar.Add(New SqlParameter("@TenVaccine_3", obj.TENVACCINE_3))
        listpar.Add(New SqlParameter("@NgayVaccine_3", obj.NGAYVACCINE_3))
        listpar.Add(New SqlParameter("@TenVaccine_4", obj.TENVACCINE_4))
        listpar.Add(New SqlParameter("@NgayVaccine_4", obj.NGAYVACCINE_4))
        listpar.Add(New SqlParameter("@TenVaccine_5", obj.TENVACCINE_5))
        listpar.Add(New SqlParameter("@NgayVaccine_5", obj.NGAYVACCINE_5))
        listpar.Add(New SqlParameter("@TenVaccine_6", obj.TENVACCINE_6))
        listpar.Add(New SqlParameter("@NgayVaccine_6", obj.NGAYVACCINE_6))
        Return Me.execProc("SP_THEMMOI_NHANVIEN_S", listpar)
    End Function
End Class
