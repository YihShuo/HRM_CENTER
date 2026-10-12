Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDKiemTraCMND
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objKiemTraCMND) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where NV_MA = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        If obj.ChonBang = 16 Then
            strSQL = ""
            If (StringType.StrCmp(obj.SoCMND, "", False) <> 0) Then
                strSQL = (strSQL & " where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
            End If
            strSQL = ("select ST_NHANVIEN.NV_Ma AS NV_MA , ST_NHANVIEN.NV_Ten AS NV_TEN, ST_NHANVIEN.NV_MaQL AS NV_MAQL, ST_NHANVIEN.DV_MA AS DV_MA, ST_NHANVIEN.NV_MaTu AS NV_MATU, ST_NHANVIEN.NV_GioiTinh AS NV_GIOITINH, ST_NHANVIEN.NV_Ngaysinh AS NV_NGAYSINH, ST_NHANVIEN.NV_NoiSinh AS NV_NOISINH, ST_NHANVIEN.NV_DiaChi AS NV_DIACHI, ST_NHANVIEN.TT_MA AS TT_MA, ST_NHANVIEN.QT_MA AS QT_MA, ST_NHANVIEN.DT_MA AS DT_MA, ST_NHANVIEN.TG_MA AS TG_MA, ST_NHANVIEN.NV_Thuongtru AS NV_THUONGTRU, ST_NHANVIEN.NV_Honnhan AS NV_HONNHAN, ST_NHANVIEN.NV_Socon AS NV_SOCON, ST_NHANVIEN.NV_CMND AS NV_CMND, ST_NHANVIEN.NV_NgayCapCMND AS NV_NGAYCAPCMND, ST_NHANVIEN.NV_NoiCapCMND AS NV_NOICAPCMND, ST_NHANVIEN.NV_DTNhaRieng AS NV_DTNHARIENG, ST_NHANVIEN.NV_DTDiDong AS NV_DTDIDONG, ST_NHANVIEN.NV_Ngayvao AS NV_NGAYVAO, ST_NHANVIEN.NV_Hinh AS NV_HINH, ST_NHANVIEN.HV_MA AS HV_MA, ST_NHANVIEN.TH_MA AS TH_MA, ST_NHANVIEN.NN_MA AS NN_MA, ST_NHANVIEN.CV_MA AS CV_MA, ST_NHANVIEN.CVU_MA AS CVU_MA, ST_NHANVIEN.NV_Ngaybonhiem AS NV_NGAYBONHIEM, ST_NHANVIEN.CM_MA AS CM_MA, ST_NHANVIEN.NV_Congdoan AS NV_CONGDOAN, ST_NHANVIEN.NV_NgayvaoCD AS NV_NGAYVAOCD, ST_NHANVIEN.NV_THOIVIEC AS NV_THOIVIEC, ST_NHANVIEN.NV_NgayTV AS NV_NGAYTV, ST_NHANVIEN.NV_NGAYKHD AS NV_NGAYKHD, ST_NHANVIEN.QH_MA AS QH_MA, ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA, ST_NHANVIEN.NV_DAKYHDLD AS NV_DAKYHDLD, ST_NHANVIEN.BSHS AS BSHS from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA where ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If

        If obj.ChonBang = 22 Then
            strSQL = ("select ST_NHANVIEN.NV_Ma AS NV_MA , ST_NHANVIEN.NV_Ten AS NV_TEN, ST_NHANVIEN.NV_MaQL AS NV_MAQL, ST_NHANVIEN.DV_MA AS DV_MA, ST_NHANVIEN.NV_MaTu AS NV_MATU, ST_NHANVIEN.NV_GioiTinh AS NV_GIOITINH, ST_NHANVIEN.NV_Ngaysinh AS NV_NGAYSINH, ST_NHANVIEN.NV_NoiSinh AS NV_NOISINH, ST_NHANVIEN.NV_DiaChi AS NV_DIACHI, ST_NHANVIEN.TT_MA AS TT_MA, ST_NHANVIEN.QT_MA AS QT_MA, ST_NHANVIEN.DT_MA AS DT_MA, ST_NHANVIEN.TG_MA AS TG_MA, ST_NHANVIEN.NV_Thuongtru AS NV_THUONGTRU, ST_NHANVIEN.NV_Honnhan AS NV_HONNHAN, ST_NHANVIEN.NV_Socon AS NV_SOCON, ST_NHANVIEN.NV_CMND AS NV_CMND, ST_NHANVIEN.NV_NgayCapCMND AS NV_NGAYCAPCMND, ST_NHANVIEN.NV_NoiCapCMND AS NV_NOICAPCMND, ST_NHANVIEN.NV_DTNhaRieng AS NV_DTNHARIENG, ST_NHANVIEN.NV_DTDiDong AS NV_DTDIDONG, ST_NHANVIEN.NV_Ngayvao AS NV_NGAYVAO, ST_NHANVIEN.NV_Hinh AS NV_HINH, ST_NHANVIEN.HV_MA AS HV_MA, ST_NHANVIEN.TH_MA AS TH_MA, ST_NHANVIEN.NN_MA AS NN_MA, ST_NHANVIEN.CV_MA AS CV_MA, ST_NHANVIEN.CVU_MA AS CVU_MA, ST_NHANVIEN.NV_Ngaybonhiem AS NV_NGAYBONHIEM, ST_NHANVIEN.CM_MA AS CM_MA, ST_NHANVIEN.NV_Congdoan AS NV_CONGDOAN, ST_NHANVIEN.NV_NgayvaoCD AS NV_NGAYVAOCD, ST_NHANVIEN.NV_THOIVIEC AS NV_THOIVIEC, DATEDIFF(MM,ST_NHANVIENTHOIVIEC.TV_NGAYTHOIVIEC,GETDATE()) AS SOTHANG, ST_NHANVIEN.NV_NGAYKHD AS NV_NGAYKHD, ST_NHANVIEN.QH_MA AS QH_MA, ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA, ST_NHANVIEN.NV_NGAYTV AS NV_NGAYTV , ST_NHANVIEN.NV_DAKYHDLD AS NV_DAKYHDLD, ST_NHANVIEN.BSHS AS BSHS  from ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA where NV_NGAYVAO = (SELECT MAX(NV_NGAYVAO)  FROM ST_NHANVIEN WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "') AND ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.SoCMND) & "'")
        End If

        If obj.ChonBang = 17 Then
            strSQL = ""
            strSQL = ("select * FROM ST_NHANVIENTHOIVIEC WHERE NV_MA = N'" & Me.QuoteString(obj.MaNV) & "' ")
        End If

        If obj.ChonBang = 23 Then
            strSQL = ("select MAX(CONVERT(INT,ST_NHANVIEN.NV_MA))+1 AS NV_MA from ST_NHANVIEN WHERE  (LEN(NV_MA )=5 AND LEN(NV_MA) <> 6)  ")
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
        If obj.ChonBang = 27 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,IT_NHANVIENQUANHE.TEN_QH AS NV_TEN,ST_NHANVIEN.DV_MA,IT_NHANVIENQUANHE.MA_QH,IT_NHANVIENQUANHE.STT,IT_NHANVIENQUANHE.NGAYSINH_QH,IT_NHANVIENQUANHE.TENTHUONGGOI,IT_NHANVIENQUANHE.NGHENGHIEP_QH,IT_NHANVIENQUANHE.NOICONGTAC,IT_NHANVIENQUANHE.DIACHI_QH,IT_NHANVIENQUANHE.SOCMND_QH,IT_NHANVIENQUANHE.NGAYCAP_QH,IT_NHANVIENQUANHE.TAI_QH,IT_NHANVIENQUANHE.SOTHE,IT_NHANVIENQUANHE.COLAMVIEC FROM ST_NHANVIEN INNER JOIN IT_NHANVIENQUANHE ON ST_NHANVIEN.NV_MA = IT_NHANVIENQUANHE.NV_MA ")
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
            strSQL = ("SELECT NV_MA FROM ST_NHANVIEN WHERE NV_MA =N'" & Me.QuoteString(obj.MaNVQH) & "' ")
        End If

        If obj.ChonBang = 32 Then
            strSQL = ("SELECT MA_QH FROM IT_NHANVIENQUANHE WHERE NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "' AND MA_QH = N'" & Me.QuoteString(obj.MaQH) & "'")
        End If
        If obj.ChonBang = 33 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,IT_NHANVIENQUANHE.TEN_QH AS NV_TEN,ST_NHANVIEN.DV_MA,IT_NHANVIENQUANHE.MA_QH,IT_NHANVIENQUANHE.STT,IT_NHANVIENQUANHE.NGAYSINH_QH,IT_NHANVIENQUANHE.TENTHUONGGOI,IT_NHANVIENQUANHE.NGHENGHIEP_QH,IT_NHANVIENQUANHE.NOICONGTAC,IT_NHANVIENQUANHE.DIACHI_QH,IT_NHANVIENQUANHE.SOCMND_QH,IT_NHANVIENQUANHE.NGAYCAP_QH,IT_NHANVIENQUANHE.TAI_QH,IT_NHANVIENQUANHE.SOTHE,IT_NHANVIENQUANHE.COLAMVIEC FROM ST_NHANVIEN INNER JOIN IT_NHANVIENQUANHE ON ST_NHANVIEN.NV_MA = IT_NHANVIENQUANHE.NV_MA WHERE IT_NHANVIENQUANHE.NV_MA = N'" & Me.QuoteString(obj.MaNVQH) & "'")
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
    Public Function InsertInfo(ByVal obj As objKiemTraCMND) As Boolean
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
    Public Function DeleteInfo(ByVal obj As objKiemTraCMND) As Boolean
        Dim strSQL As String
        'strSQL = "DELETE IT_NHANVIENQUANHE WHERE NV_MA = '" & Me.QuoteString(obj.MaNVQH) & "'AND MA_QH =N'" & Me.QuoteString(obj.MaQH) & "'AND STT =N'" & Me.QuoteString(obj.SoTT) & "'"
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objKiemTraCMND) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

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
