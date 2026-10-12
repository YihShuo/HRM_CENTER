Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports TongHop.MAIN
Public Class clsDLyLichNhanVien
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objLyLichNhanVien) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = "SELECT NV_MA,"
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + " NV_NGAYVAO,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " HV_TEN,"
            strSQL = strSQL + " ST_HOCVAN.HV_MA,"
            strSQL = strSQL + " NV_NGAYBONHIEM,"
            strSQL = strSQL + " NV_NAMSINH=ISNULL(NV_NAMSINH,0),"
            strSQL = strSQL + " NV_NGAYSINH = (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,103)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END),"
            strSQL = strSQL + " NV_GIOITINH= (CASE WHEN (ISNULL(NV_GIOITINH,0) = 1) THEN 'NAM ' ELSE N'NỮ' END),"
            strSQL = strSQL + " ST_NHANVIEN.CV_MA,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " ST_CHUCVU.CVU_MA,"
            strSQL = strSQL + " CM_TEN,"
            strSQL = strSQL + " ST_CHUYENMON.CM_MA,"
            strSQL = strSQL + " NV_CMND,"
            strSQL = strSQL + " NV_NoiCapCMND,"
            strSQL = strSQL + " NV_DTNhaRieng,"
            strSQL = strSQL + " NV_DTDiDong,NV_NGAYSINH as NV_NGAYSINHTT"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " LEFT JOIN ST_HOCVAN ON ST_NHANVIEN.HV_MA = ST_HOCVAN.HV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON ST_NHANVIEN.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LOCBB = 0"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = '" + obj.MaNV + "' and ST_NHANVIEN.NV_MA<>'001179'"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "SELECT NV_MA,"
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + " NV_NGAYVAO,"
            strSQL = strSQL + " NV_GIOITINH= (CASE WHEN (ISNULL(NV_GIOITINH,0) = 1) THEN 'NAM ' ELSE N'NỮ' END),"
            strSQL = strSQL + " NV_NAMSINH=ISNULL(NV_NAMSINH,0),"
            strSQL = strSQL + " NV_NGAYSINH = (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,103)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END),"
            strSQL = strSQL + " NV_DiaChi,"
            strSQL = strSQL + " NV_CMND,"
            strSQL = strSQL + " NV_NgayCapCMND,"
            strSQL = strSQL + " NV_NoiCapCMND,"
            strSQL = strSQL + " NV_DTNhaRieng,"
            strSQL = strSQL + " NV_DTDiDong,"
            strSQL = strSQL + " NV_NGAYBONHIEM,"
            strSQL = strSQL + " NV_NGAYKHD,"
            strSQL = strSQL + " ST_NHANVIEN.CV_MA,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " HD_CVNANGNHOCDH,"
            strSQL = strSQL + " ST_HOCVAN.HV_MA,"
            strSQL = strSQL + " HV_TEN,"
            strSQL = strSQL + " ST_CHUCVU.CVU_MA,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " ST_CHUYENMON.CM_MA,"
            strSQL = strSQL + " CM_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.TH_MA,"
            strSQL = strSQL + " TH_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.NN_MA,"
            strSQL = strSQL + " NN_TEN ,NV_THOIVIEC, NV_DAKYHDLD ,ISNULL(COFLAG,0) AS FLAG,"
            strSQL = strSQL + " NV_NGAYSINH AS NV_NGAYSINHTT"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " LEFT JOIN ST_HOCVAN ON ST_NHANVIEN.HV_MA = ST_HOCVAN.HV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON ST_NHANVIEN.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " LEFT JOIN ST_TINHOC ON ST_NHANVIEN.TH_MA = ST_TINHOC.TH_MA"
            strSQL = strSQL + " LEFT JOIN ST_NGOAINGU ON ST_NHANVIEN.NN_MA = ST_NGOAINGU.NN_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LOCBB = 0 WHERE ST_NHANVIEN.NV_MA<>'001179'"
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT CV_MA, CV_TEN FROM ST_CONGVIEC"
        End If
        If obj.ChonBang = 4 Then
            strSQL = "SELECT CVU_MA, CVU_TEN FROM ST_CHUCVU"
        End If

        If obj.ChonBang = 5 Then
            strSQL = " SELECT ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + "  ST_NHANVIEN.NV_TEN ,"
            strSQL = strSQL + "  ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.CV_MA ,ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + "  ST_CHUCVU.CVU_MA , CVU_TEN,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Ngaybatdau ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Soquyetdinh ,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_Heso AS HESO,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_LuongCB AS LUONG,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_PhuCap AS PHUCAP,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_PhuCapKhac AS PhuCapKhac,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapCV AS TrocapCV,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapUDMAY AS TrocapUDMAY,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapCMNV AS TrocapCMNV,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapNN AS TrocapNN,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapHMPT AS TrocapHMPT,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapMOITRUONG AS TCMT,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapQLSX AS TroCapQLSX,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapCBVP AS TroCapCBVP,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBNT AS TroCapBBNT,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBHT AS TroCapBBHT,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapBBTHANG AS TroCapBBTHANG,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapCLGD AS TroCapCLGD,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapHTDP AS TroCapHTDP,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TroCapQAQIP AS TroCapQAQIP,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapThoRap AS TrocapThoRap,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_TrocapHSE AS TrocapHSE,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_KHONGHUONGCHUYENCAN,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_PHUCLOI AS PHUCLOI,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_HTNG AS HTNG,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_DQTV AS DQTV,"
            strSQL = strSQL + "  ST_DIENBIENLUONG.DBL_PCCC AS PCCC"
            strSQL = strSQL + "  FROM ST_NHANVIEN  LEFT JOIN ST_DIENBIENLUONG ON ST_NHANVIEN.NV_MA = ST_DIENBIENLUONG.NV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CONGVIEC ON ST_DIENBIENLUONG.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + "  LEFT JOIN ST_CHUCVU ON ST_DIENBIENLUONG.CVU_MA = ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND DV_LOCBB = 0"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = '" & Me.QuoteString(obj.MaNV) & "'"
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
    Public Function InsertInfo(ByVal obj As objLyLichNhanVien) As Boolean
        Dim flag As Boolean
        Dim strSQL As String

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
    Public Function DeleteInfo(ByVal obj As objLyLichNhanVien) As Boolean
        Dim strSQL As String
        'strSQL = "DELETE IT_NHANVIENQUANHE WHERE NV_MA = '" & Me.QuoteString(obj.MaNVQH) & "'AND MA_QH =N'" & Me.QuoteString(obj.MaQH) & "'AND STT =N'" & Me.QuoteString(obj.SoTT) & "'"
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objLyLichNhanVien) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_NHANVIEN"
            strSQL = strSQL + " SET CV_MA = N'" + obj.CongViec + "',"
            strSQL = strSQL + " CVU_MA = N'" + obj.ChucVu + "',"
            strSQL = strSQL + " HD_CVNANGNHOCDH = N'" + Me.QuoteString(obj.DHNN) + "',"
            strSQL = strSQL + " NV_NGAYBONHIEM = '" + obj.NgayBoNhiem + "'"
            strSQL = strSQL + " WHERE NV_MA = '" + obj.MaNV + "'"
            obj.SQL = strSQL.ToString
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE ST_NHANVIEN SET ST_NHANVIEN.NV_DAKYHDLD = 0,ST_NHANVIEN.NV_NGAYKHD = NULL "
        End If
        If obj.ChonBang = 3 Then
            strSQL = "UPDATE ST_NHANVIEN  SET ST_NHANVIEN.NV_NGAYKHD = ST_HOPDONGLAODONG.HD_NgayKy , ST_NHANVIEN.NV_DAKYHDLD = 1 FROM ST_NHANVIEN INNER JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
        End If

        If obj.ChonBang = 4 Then
            strSQL = "UPDATE ST_NHANVIEN SET NV_THOIVIEC = 0"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "UPDATE ST_NHANVIEN SET NV_THOIVIEC = 1, ST_NHANVIEN.NV_NgayTV = ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC FROM ST_NHANVIEN INNER JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA "
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
    Public Function UpdateThaoTac(ByVal obj As objLyLichNhanVien) As Boolean
        Dim flag As Boolean
        Dim strSQL1 As String = ""

        If obj.ChonBang = 1 Then
            Dim day As DateTime = Now
            Dim ngay As String = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())
            Dim s_SQL As String = obj.SQL
            s_SQL = Replace(s_SQL, "'", "''")
            Dim Use_client = userclient
            strSQL1 = "INSERT INTO jell_TacDong (ThoiDiem, HanhDong, GiaTri, Ten_DangNhap) VALUES (" & "'" & ngay & "'" & "," & "'" & s_SQL & "'" & ", '0', " & "'" & Use_client & "'" & " )"

        End If
        Try
            flag = Me.execSQL(strSQL1)
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
