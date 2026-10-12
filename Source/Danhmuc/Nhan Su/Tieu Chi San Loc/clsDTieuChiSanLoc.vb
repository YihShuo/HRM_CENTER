Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Imports System.IO
Public Class clsDTieuChiSanLoc
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objTieuChiSanLoc) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = "SELECT "
            strSQL = strSQL + " NV_CM,"
            strSQL = strSQL + " LDPT,"
            strSQL = strSQL + " MAHS,"
            strSQL = strSQL + " NGAYNOP,"
            strSQL = strSQL + " TEN,"
            strSQL = strSQL + " GIOITINH = CASE WHEN GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END,"
            strSQL = strSQL + " NGAYSINH as NGAYSINHTT,"
            strSQL = strSQL + " (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),IT_TIEUCHISANLOC.NGAYSINH,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),IT_TIEUCHISANLOC.NGAYSINH,21),4)) END) AS NGAYSINH,"
            strSQL = strSQL + " DTDD,"
            strSQL = strSQL + " DTNR,"
            strSQL = strSQL + " DIACHI,"
            strSQL = strSQL + " EMAIL,"
            strSQL = strSQL + " FACE,"
            strSQL = strSQL + " CMND,"
            strSQL = strSQL + " ST_HOCVAN.HV_MA,"
            strSQL = strSQL + " HV_TEN,"
            strSQL = strSQL + " ST_CHUYENMON.CM_MA,"
            strSQL = strSQL + " CM_TEN,"
            strSQL = strSQL + " IT_CHUNGCHIKHAC.CC_MA,"
            strSQL = strSQL + " CC_TEN,"
            strSQL = strSQL + " KINHNGHIEM,"
            strSQL = strSQL + " IT_KYNANG.KN_MA,"
            strSQL = strSQL + " KN_TEN,"
            strSQL = strSQL + " TOCHAT,"
            strSQL = strSQL + " HOATDONGXH,"
            strSQL = strSQL + " ST_NGOAINGU.NN_MA,"
            strSQL = strSQL + " NN_TEN,"
            strSQL = strSQL + " ST_TINHOC.TH_MA,"
            strSQL = strSQL + " TH_TEN,"
            strSQL = strSQL + " KETQUA ,"
            strSQL = strSQL + " CHUAPV,"
            strSQL = strSQL + " SODIEMDAT,"
            strSQL = strSQL + " HOTEN1,"
            strSQL = strSQL + " QUANHE1,"
            strSQL = strSQL + " DIENTHOAI1,"
            strSQL = strSQL + " HOTEN2,"
            strSQL = strSQL + " QUANHE2,"
            strSQL = strSQL + " DIENTHOAI2,"
            strSQL = strSQL + " DVGIOITHIEU,"
            strSQL = strSQL + " MUCLUONGMM,"
            strSQL = strSQL + " VITRI,NV_NAMSINH=ISNULL(NV_NAMSINH,0),"
            strSQL = strSQL + " FILE_CV1,"
            strSQL = strSQL + " FILE_CV2,"
            strSQL = strSQL + " FILE_CV3"
            strSQL = strSQL + " FROM IT_TIEUCHISANLOC LEFT JOIN ST_HOCVAN ON IT_TIEUCHISANLOC.HV_MA = ST_HOCVAN.HV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON IT_TIEUCHISANLOC.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " LEFT JOIN IT_CHUNGCHIKHAC ON IT_TIEUCHISANLOC.CC_MA = IT_CHUNGCHIKHAC.CC_MA"
            strSQL = strSQL + " LEFT JOIN IT_KYNANG ON IT_TIEUCHISANLOC.KN_MA = IT_KYNANG.KN_MA"
            strSQL = strSQL + " LEFT JOIN ST_NGOAINGU ON IT_TIEUCHISANLOC.NN_MA = ST_NGOAINGU.NN_MA"
            strSQL = strSQL + " LEFT JOIN ST_TINHOC ON IT_TIEUCHISANLOC.TH_MA = ST_TINHOC.TH_MA "
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT * FROM ST_HOCVAN")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * FROM ST_CHUYENMON")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT * FROM IT_CHUNGCHIKHAC")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("SELECT * FROM IT_KYNANG")
        End If
        If obj.ChonBang = 6 Then
            strSQL = ("SELECT * FROM ST_NGOAINGU")
        End If
        If obj.ChonBang = 7 Then
            strSQL = ("SELECT * FROM ST_TINHOC")
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT * FROM IT_TIEUCHISANLOC WHERE (MAHS =  '" & Me.QuoteString(obj.MAHS) & "' OR CMND = '" & Me.QuoteString(obj.SoCMND) & "')")
        End If
        If obj.ChonBang = 9 Then
            strSQL = ("SELECT MAX(CONVERT(INT,IT_TIEUCHISANLOC.MAHS))+1 AS MAHS from IT_TIEUCHISANLOC WHERE  LEN(MAHS )= 4")
        End If
        If obj.ChonBang = 10 Then
            strSQL = (" select ST_NHANVIEN.NV_Ma AS NV_MA , ST_NHANVIEN.NV_Ten AS NV_TEN, ST_NHANVIEN.NV_MaQL AS NV_MAQL, ST_NHANVIEN.DV_MA AS DV_MA, ST_NHANVIEN.NV_MaTu AS NV_MATU, ST_NHANVIEN.NV_GioiTinh AS NV_GIOITINH, ST_NHANVIEN.NV_Ngaysinh AS NV_NGAYSINH, ST_NHANVIEN.NV_NoiSinh AS NV_NOISINH, ST_NHANVIEN.NV_DiaChi AS NV_DIACHI, ST_NHANVIEN.TT_MA AS TT_MA, ST_NHANVIEN.QT_MA AS QT_MA, ST_NHANVIEN.DT_MA AS DT_MA, ST_NHANVIEN.TG_MA AS TG_MA, ST_NHANVIEN.NV_Thuongtru AS NV_THUONGTRU, ST_NHANVIEN.NV_Honnhan AS NV_HONNHAN, ST_NHANVIEN.NV_Socon AS NV_SOCON, ST_NHANVIEN.NV_CMND AS NV_CMND, ST_NHANVIEN.NV_NgayCapCMND AS NV_NGAYCAPCMND, ST_NHANVIEN.NV_NoiCapCMND AS NV_NOICAPCMND, ST_NHANVIEN.NV_DTNhaRieng AS NV_DTNHARIENG, ST_NHANVIEN.NV_DTDiDong AS NV_DTDIDONG, ST_NHANVIEN.NV_Ngayvao AS NV_NGAYVAO, ST_NHANVIEN.NV_Hinh AS NV_HINH, ST_NHANVIEN.HV_MA AS HV_MA, ST_NHANVIEN.TH_MA AS TH_MA, ST_NHANVIEN.NN_MA AS NN_MA, ST_NHANVIEN.CV_MA AS CV_MA, ST_NHANVIEN.CVU_MA AS CVU_MA, ST_NHANVIEN.NV_Ngaybonhiem AS NV_NGAYBONHIEM, ST_NHANVIEN.CM_MA AS CM_MA, ST_NHANVIEN.NV_Congdoan AS NV_CONGDOAN, ST_NHANVIEN.NV_NgayvaoCD AS NV_NGAYVAOCD, ST_NHANVIEN.NV_THOIVIEC AS NV_THOIVIEC, ST_NHANVIEN.NV_NgayTV AS NV_NGAYTV, ST_NHANVIEN.NV_NGAYKHD AS NV_NGAYKHD, ST_NHANVIEN.QH_MA AS QH_MA, ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA, ST_NHANVIEN.NV_DAKYHDLD AS NV_DAKYHDLD, ST_NHANVIEN.BSHS AS BSHS from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If
        If obj.ChonBang = 11 Then
            strSQL = (" SELECT NV_MA, NV_NGAYVAO, NV_THOIVIEC  FROM ST_NHANVIEN where NV_NGAYVAO = (SELECT MAX(NV_NGAYVAO)  FROM ST_NHANVIEN WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "' ) AND ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "' ")
        End If
        If obj.ChonBang = 12 Then
            strSQL = (" select NV_CMND , COUNT(NV_CMND) AS SOLAN FROM ST_NHANVIEN WHERE NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "' GROUP BY NV_CMND")
        End If

        If obj.ChonBang = 13 Then
            strSQL = "DROP TABLE IT_LOCTCSL"
            strSQL = strSQL + " SELECT CMND = ST_NHANVIEN.NV_CMND  INTO IT_LOCTCSL"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN "
            strSQL = strSQL + " (SELECT *"
            strSQL = strSQL + " FROM IT_TIEUCHISANLOC INNER JOIN "
            strSQL = strSQL + " (SELECT NV_CMND  , NV_Ngayvao = MAX(NV_Ngayvao)"
            strSQL = strSQL + " FROM ST_NHANVIEN"
            strSQL = strSQL + " GROUP BY NV_CMND) AS B"
            strSQL = strSQL + " ON IT_TIEUCHISANLOC .CMND = B.NV_CMND "
            strSQL = strSQL + " WHERE CMND <> '') AS A"
            strSQL = strSQL + " ON ST_NHANVIEN.NV_CMND = A.CMND AND ST_NHANVIEN.NV_Ngayvao = A.NV_Ngayvao"
            strSQL = strSQL + " WHERE(NV_THOIVIEC = 0)"
            strSQL = strSQL + " SELECT NV_CM,"
            strSQL = strSQL + " LDPT,"
            strSQL = strSQL + " MAHS,"
            strSQL = strSQL + " NGAYNOP,"
            strSQL = strSQL + " TEN,"
            strSQL = strSQL + " GIOITINH = CASE WHEN GIOITINH = 1 THEN N'Nam' ELSE N'Nữ' END,"
            strSQL = strSQL + " NGAYSINH as NGAYSINHTT ,"
            strSQL = strSQL + " (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),IT_TIEUCHISANLOC.NGAYSINH,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),IT_TIEUCHISANLOC.NGAYSINH,21),4)) END) AS NGAYSINH,"
            strSQL = strSQL + " DTDD,"
            strSQL = strSQL + " DTNR,"
            strSQL = strSQL + " DIACHI,"
            strSQL = strSQL + " EMAIL,"
            strSQL = strSQL + " FACE,"
            strSQL = strSQL + " CMND,"
            strSQL = strSQL + " ST_HOCVAN.HV_MA,"
            strSQL = strSQL + " HV_TEN,"
            strSQL = strSQL + " ST_CHUYENMON.CM_MA,"
            strSQL = strSQL + " CM_TEN,"
            strSQL = strSQL + " IT_CHUNGCHIKHAC.CC_MA,"
            strSQL = strSQL + " CC_TEN,"
            strSQL = strSQL + " KINHNGHIEM,"
            strSQL = strSQL + " IT_KYNANG.KN_MA,"
            strSQL = strSQL + " KN_TEN,"
            strSQL = strSQL + " TOCHAT,"
            strSQL = strSQL + " HOATDONGXH,"
            strSQL = strSQL + " ST_NGOAINGU.NN_MA,"
            strSQL = strSQL + " NN_TEN,"
            strSQL = strSQL + " ST_TINHOC.TH_MA,"
            strSQL = strSQL + " TH_TEN,"
            strSQL = strSQL + " KETQUA ,"
            strSQL = strSQL + " CHUAPV,"
            strSQL = strSQL + " SODIEMDAT,"
            strSQL = strSQL + " HOTEN1,"
            strSQL = strSQL + " QUANHE1,"
            strSQL = strSQL + " DIENTHOAI1,"
            strSQL = strSQL + " HOTEN2,"
            strSQL = strSQL + " QUANHE2,"
            strSQL = strSQL + " DIENTHOAI2,"
            strSQL = strSQL + " DVGIOITHIEU,"
            strSQL = strSQL + " MUCLUONGMM,"
            strSQL = strSQL + " VITRI,"
            strSQL = strSQL + " NV_NAMSINH=ISNULL(NV_NAMSINH,0)"
            strSQL = strSQL + " FROM IT_TIEUCHISANLOC LEFT JOIN ST_HOCVAN ON IT_TIEUCHISANLOC.HV_MA = ST_HOCVAN.HV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON IT_TIEUCHISANLOC.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " LEFT JOIN IT_CHUNGCHIKHAC ON IT_TIEUCHISANLOC.CC_MA = IT_CHUNGCHIKHAC.CC_MA"
            strSQL = strSQL + " LEFT JOIN IT_KYNANG ON IT_TIEUCHISANLOC.KN_MA = IT_KYNANG.KN_MA"
            strSQL = strSQL + " LEFT JOIN ST_NGOAINGU ON IT_TIEUCHISANLOC.NN_MA = ST_NGOAINGU.NN_MA"
            strSQL = strSQL + " LEFT JOIN ST_TINHOC ON IT_TIEUCHISANLOC.TH_MA = ST_TINHOC.TH_MA"
            strSQL = strSQL + " WHERE CMND NOT IN (SELECT CMND FROM IT_LOCTCSL)"
            strSQL = strSQL + " AND CMND <> ''"
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
    Public Function FileStoreToDataBase(ByVal obj As objTieuChiSanLoc, ByVal content As Byte(), ByVal fileName As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        Dim parameter As SqlParameter
        Try
            If Me.conn.State = ConnectionState.Closed Then
                Me.conn.Open()
            End If
            ''cap nhat lai ten file va noi dung file : sau khi da insert hoac update xong
            Dim update As New SqlCommand("UPDATE IT_TIEUCHISANLOC SET FILE_CV1= @FILE_CV1, NOIDUNGFILE_CV1 = @NOIDUNGFILE_CV1 WHERE MAHS = @MAHS", Me.conn)
            Dim fileNameParameter As SqlParameter = update.Parameters.Add("@FILE_CV1", SqlDbType.NVarChar, 300)
            Dim imageParameter As SqlParameter = update.Parameters.Add("@NOIDUNGFILE_CV1", SqlDbType.Binary)
            Dim MAHS As SqlParameter = update.Parameters.Add("@MAHS", SqlDbType.NVarChar, 50) '' ma chuong trinh dao tao

            fileNameParameter.Value = fileName
            imageParameter.Value = content
            imageParameter.Size = content.Length
            MAHS.Value = obj.MAHS
            'VBCC_SO.Value = obj.VBCC_SO

            If update.ExecuteNonQuery() > 0 Then
                flag = True
            Else
                flag = False
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function FileStoreToDataBase2(ByVal obj As objTieuChiSanLoc, ByVal content As Byte(), ByVal fileName As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        Dim parameter As SqlParameter
        Try
            If Me.conn.State = ConnectionState.Closed Then
                Me.conn.Open()
            End If
            ''cap nhat lai ten file va noi dung file : sau khi da insert hoac update xong
            Dim update As New SqlCommand("UPDATE IT_TIEUCHISANLOC SET FILE_CV2= @FILE_CV2, NOIDUNGFILE_CV2 = @NOIDUNGFILE_CV2 WHERE MAHS = @MAHS", Me.conn)
            Dim fileNameParameter As SqlParameter = update.Parameters.Add("@FILE_CV2", SqlDbType.NVarChar, 300)
            Dim imageParameter As SqlParameter = update.Parameters.Add("@NOIDUNGFILE_CV2", SqlDbType.Binary)
            Dim MAHS As SqlParameter = update.Parameters.Add("@MAHS", SqlDbType.NVarChar, 50) '' ma chuong trinh dao tao

            fileNameParameter.Value = fileName
            imageParameter.Value = content
            imageParameter.Size = content.Length
            MAHS.Value = obj.MAHS
            'VBCC_SO.Value = obj.VBCC_SO

            If update.ExecuteNonQuery() > 0 Then
                flag = True
            Else
                flag = False
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function FileStoreToDataBase3(ByVal obj As objTieuChiSanLoc, ByVal content As Byte(), ByVal fileName As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        Dim parameter As SqlParameter
        Try
            If Me.conn.State = ConnectionState.Closed Then
                Me.conn.Open()
            End If
            ''cap nhat lai ten file va noi dung file : sau khi da insert hoac update xong
            Dim update As New SqlCommand("UPDATE IT_TIEUCHISANLOC SET FILE_CV3= @FILE_CV3, NOIDUNGFILE_CV3 = @NOIDUNGFILE_CV3 WHERE MAHS = @MAHS", Me.conn)
            Dim fileNameParameter As SqlParameter = update.Parameters.Add("@FILE_CV3", SqlDbType.NVarChar, 300)
            Dim imageParameter As SqlParameter = update.Parameters.Add("@NOIDUNGFILE_CV3", SqlDbType.Binary)
            Dim MAHS As SqlParameter = update.Parameters.Add("@MAHS", SqlDbType.NVarChar, 50) '' ma chuong trinh dao tao

            fileNameParameter.Value = fileName
            imageParameter.Value = content
            imageParameter.Size = content.Length
            MAHS.Value = obj.MAHS
            'VBCC_SO.Value = obj.VBCC_SO

            If update.ExecuteNonQuery() > 0 Then
                flag = True
            Else
                flag = False
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function InsertInfo(ByVal obj As objTieuChiSanLoc) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_TIEUCHISANLOC"
            strSQL = strSQL + " ([NV_CM] ,"
            strSQL = strSQL + " [LDPT] ,"
            strSQL = strSQL + " [MAHS] ,"
            strSQL = strSQL + " [NGAYNOP] ,"
            strSQL = strSQL + " [TEN] ,"
            strSQL = strSQL + " [GIOITINH] ,"
            strSQL = strSQL + " [NGAYSINH] ,"
            strSQL = strSQL + " [DTDD] ,"
            strSQL = strSQL + " [DTNR] ,"
            strSQL = strSQL + " [DIACHI] ,"
            strSQL = strSQL + " [EMAIL] ,"
            strSQL = strSQL + " [FACE],"
            strSQL = strSQL + " [CMND] ,"
            strSQL = strSQL + " [HV_MA] ,"
            strSQL = strSQL + " [CM_MA] ,"
            strSQL = strSQL + " [CC_MA] ,"
            strSQL = strSQL + " [KINHNGHIEM] ,"
            strSQL = strSQL + " [KN_MA],"
            strSQL = strSQL + " [TOCHAT],"
            strSQL = strSQL + " [HOATDONGXH] ,"
            strSQL = strSQL + " [NN_MA] ,"
            strSQL = strSQL + " [TH_MA],"
            strSQL = strSQL + " [KETQUA],"
            strSQL = strSQL + " [CHUAPV],"
            strSQL = strSQL + " [SODIEMDAT],"
            strSQL = strSQL + " [HOTEN1] ,"
            strSQL = strSQL + " [QUANHE1],"
            strSQL = strSQL + " [DIENTHOAI1] ,"
            strSQL = strSQL + " [HOTEN2] ,"
            strSQL = strSQL + " [QUANHE2],"
            strSQL = strSQL + " [DIENTHOAI2],"
            strSQL = strSQL + " [DVGIOITHIEU] ,"
            strSQL = strSQL + " [MUCLUONGMM] ,"
            strSQL = strSQL + " [VITRI] ,"
            strSQL = strSQL + " [NV_NAMSINH]) "
            strSQL = strSQL + " values(" & Me.QuoteString(obj.NVCM) & "," & Me.QuoteString(obj.LDPT) & ",N'" & Me.QuoteString(obj.MAHS) & "',N'" & Me.QuoteString(obj.NgayNop) & "',N'" & Me.QuoteString(obj.HOTEN) & "',N'" & Me.QuoteString(obj.GioiTinh) & "',N'" & Me.QuoteString(obj.NgaySinh) & "',N'" & Me.QuoteString(obj.DTDD) & "',N'" & Me.QuoteString(obj.DTNhaRieng) & "',N'" & Me.QuoteString(obj.DIACHI) & "',N'" & Me.QuoteString(obj.EMAIL) & "',N'" & Me.QuoteString(obj.FACE) & "',N'" & Me.QuoteString(obj.SoCMND) & "',N'" & Me.QuoteString(obj.TDHocVan) & "',N'" & Me.QuoteString(obj.ChuyenMon) & "',N'" & Me.QuoteString(obj.ChungChiK) & "',N'" & Me.QuoteString(obj.KinhNghiem) & "',N'" & Me.QuoteString(obj.KyNang) & "',N'" & Me.QuoteString(obj.ToChat) & "',N'" & Me.QuoteString(obj.HoatDong) & "',N'" & Me.QuoteString(obj.NgoaiNgu) & "',N'" & Me.QuoteString(obj.TinHoc) & "',N'" & Me.QuoteString(obj.KetQua) & "',N'" & Me.QuoteString(obj.ChuaPV) & "',N'" & Me.QuoteString(obj.SoDiemDat) & "',N'" & Me.QuoteString(obj.HOTEN1) & "',N'" & Me.QuoteString(obj.QuanHe1) & "',N'" & Me.QuoteString(obj.DienThoai1) & "',N'" & Me.QuoteString(obj.HOTEN2) & "',N'" & Me.QuoteString(obj.QuanHe2) & "',N'" & Me.QuoteString(obj.DienThoai2) & "',N'" & Me.QuoteString(obj.DVGioiThieu) & "'," & Me.QuoteString(obj.MucLuongMM) & ",N'" & Me.QuoteString(obj.ViTri) & "',N'" & Me.QuoteString(obj.ChonNamSinh) & "')"

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
    Public Function DeleteInfo(ByVal jFunction As objTieuChiSanLoc) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        strSQL = ("DELETE FROM IT_TIEUCHISANLOC WHERE MAHS=N'" & Me.QuoteString(jFunction.MAHS) & "'")

        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objTieuChiSanLoc) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 1 Then
            strSQL = ("UPDATE IT_TIEUCHISANLOC SET NV_CM = N'" & Me.QuoteString(obj.NVCM) & "',LDPT = N'" & Me.QuoteString(obj.LDPT) & "' ,TEN = N'" & Me.QuoteString(obj.HOTEN) & "' ,GIOITINH = N'" & Me.QuoteString(obj.GioiTinh) & "',NGAYSINH = N'" & Me.QuoteString(obj.NgaySinh) & "',NV_NAMSINH = N'" & Me.QuoteString(obj.ChonNamSinh) & "',DTDD = N'" & Me.QuoteString(obj.DTDD) & "',DTNR = N'" & Me.QuoteString(obj.DTNhaRieng) & "',DIACHI = N'" & Me.QuoteString(obj.DIACHI) & "',EMAIL = N'" & Me.QuoteString(obj.EMAIL) & "',FACE = N'" & Me.QuoteString(obj.FACE) & "',CMND = N'" & Me.QuoteString(obj.SoCMND) & "',HV_MA = N'" & Me.QuoteString(obj.TDHocVan) & "',CM_MA = N'" & Me.QuoteString(obj.ChuyenMon) & "',CC_MA  = N'" & Me.QuoteString(obj.ChungChiK) & "',KINHNGHIEM = N'" & Me.QuoteString(obj.KinhNghiem) & "',KN_MA = N'" & Me.QuoteString(obj.KyNang) & "',TOCHAT = N'" & Me.QuoteString(obj.ToChat) & "',HOATDONGXH = N'" & Me.QuoteString(obj.HoatDong) & "',NN_MA = N'" & Me.QuoteString(obj.NgoaiNgu) & "',TH_MA = N'" & Me.QuoteString(obj.TinHoc) & "',KETQUA = N'" & Me.QuoteString(obj.KetQua) & "',CHUAPV = N'" & Me.QuoteString(obj.ChuaPV) & "',SODIEMDAT = N'" & Me.QuoteString(obj.SoDiemDat) & "',HOTEN1 = N'" & Me.QuoteString(obj.HOTEN1) & "',QUANHE1 = N'" & Me.QuoteString(obj.QuanHe1) & "',DIENTHOAI1 = N'" & Me.QuoteString(obj.DienThoai1) & "',HOTEN2 = N'" & Me.QuoteString(obj.HOTEN2) & "',QUANHE2 = N'" & Me.QuoteString(obj.QuanHe2) & "',DIENTHOAI2 = N'" & Me.QuoteString(obj.DienThoai2) & "',DVGIOITHIEU = N'" & Me.QuoteString(obj.DVGioiThieu) & "',MUCLUONGMM = " & Me.QuoteString(obj.MucLuongMM) & ",VITRI = N'" & Me.QuoteString(obj.ViTri) & "' WHERE MAHS=N'" & Me.QuoteString(obj.MAHS) & "'")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("UPDATE IT_TIEUCHISANLOC SET FILE_CV1 = NULL ,NOIDUNGFILE_CV1 = NULL WHERE MAHS=N'" & Me.QuoteString(obj.MAHS) & "'")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("UPDATE IT_TIEUCHISANLOC SET FILE_CV2 = NULL ,NOIDUNGFILE_CV2 = NULL WHERE MAHS=N'" & Me.QuoteString(obj.MAHS) & "'")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("UPDATE IT_TIEUCHISANLOC SET FILE_CV3 = NULL ,NOIDUNGFILE_CV3 = NULL WHERE MAHS=N'" & Me.QuoteString(obj.MAHS) & "'")
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
