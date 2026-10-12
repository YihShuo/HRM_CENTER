Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsDChuyenDV
    Inherits DALSQL


    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objChuyenDV) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        ''==== kiểm tra số thẻ có trong nhân viên và đã nghi viẹc chua ========''
        If obj.ChonBang = 1 Then
            strSQL = (" SELECT ST_NHANVIEN.NV_TEN ,ST_NHANVIEN.NV_MA ,ST_NHANVIEN.DV_MA,ST_NHANVIEN.CVU_MA ,TV = CASE WHEN TV_NGAYTHOIVIEC IS NOT NULL THEN 1 ELSE 0 END ")
            strSQL = strSQL + ",DDNGHIVIEC = CASE WHEN ST_NHANVIEN.DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) THEN 1 ELSE 0 END"
            strSQL = strSQL + "  FROM ST_NHANVIEN LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA"
            strSQL = strSQL + "  WHERE ST_NHANVIEN.NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_MA, CDV_DONVIMOI, CDV_DONVICU, CDV_CHUCVUMOI, CDV_CHUCVUCU, ")
            strSQL = strSQL + " NGAY "
            strSQL = strSQL + "  FROM ST_CHUYENDONVI"
            'strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND NGAY = '" & Me.QuoteString(obj.NGAYCD) & "'"
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT  STT, ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "ST_CHUYENDONVI.NGAY AS NGAYCD,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_DONVICU AS DVCU,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_CHUCVUCU AS CVUCU, "
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_DONVIMOI AS DVMOI,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_CHUCVUMOI AS CVUMOI "
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA =ST_CHUYENDONVI.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA AND DV_LOCBB = 0 "
            strSQL = strSQL + " WHERE ST_CHUYENDONVI.NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If



        If obj.ChonBang = 4 Then
            strSQL = (" SELECT DV_MA")
            strSQL = strSQL + " FROM ST_DONVI WHERE DV_LOCBB = 0 ORDER BY DV_MA "
        End If

        If obj.ChonBang = 7 Then
            strSQL = (" SELECT CVU_MA")
            strSQL = strSQL + " FROM ST_CHUCVU "
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT	ST_NHANVIEN.NV_MA, ")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN,  "
            strSQL = strSQL + " ST_NHANVIEN.DV_MA,  "
            strSQL = strSQL + " ST_CHUYENDONVI.NGAY,  "
            strSQL = strSQL + " ST_CHUYENDONVI.CDV_DONVIMOI, "
            strSQL = strSQL + " ST_CHUYENDONVI.CDV_DONVICU "
            strSQL = strSQL + "  FROM	ST_NHANVIEN INNER JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA = ST_CHUYENDONVI.NV_MA "
            strSQL = strSQL + "  WHERE ST_NHANVIEN.NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND ST_CHUYENDONVI.NGAY = '" & Me.QuoteString(obj.NGAYCD) & "'"
        End If

        ''==== kiểm tra đơn vị gõ từ combo khong co trong đơn vị ========''
        If obj.ChonBang = 9 Then
            strSQL = (" SELECT * FROM ST_DONVI WHERE DV_LOCBB = 0 AND DV_MA =  '" & Me.QuoteString(obj.DONVICBX) & "'")
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

    Public Function InsertInfo(ByVal obj As objChuyenDV, ByVal sNguoiTao As String, ByVal sNgayTao As String, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_CHUYENDONVI(NV_MA,NGAY, CDV_DONVICU, CDV_CHUCVUCU, CDV_DONVIMOI, CDV_CHUCVUMOI,NGUOITAO,NGAYTAO,NGUOICAPNHAT,NGAYCAPNHAT)  values (N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.NGAYCD) & "',N'" & Me.QuoteString(obj.DVCU) & "',N'" & Me.QuoteString(obj.CVUCU) & "',N'" & Me.QuoteString(obj.DVMOI) & "',N'" & Me.QuoteString(obj.CVUMOI) & "',N'" & Me.QuoteString(sNguoiTao) & "',N'" & Me.QuoteString(sNgayTao) & "',N'" & Me.QuoteString(sNguoiCapNhat) & "',N'" & Me.QuoteString(sNgayCapNhat)}) & "' )" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function DeleteInfo(ByVal jFunction As objChuyenDV) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ("delete from ST_CHUYENDONVI where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'AND ngay = '" & Me.QuoteString(jFunction.NGAYCD)) & "'"
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objChuyenDV, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 2 Then
            ' strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_CHUYENDONVI set NGAY = N'", Me.QuoteString(obj.NGAYCD), "',CDV_Donvimoi = N'", Me.QuoteString(obj.DVMOI), "',CDV_chucvumoi = N'", Me.QuoteString(obj.CVUMOI), "' where NV_MA = N'", Me.QuoteString(obj.MANV), "' AND ST_CHUYENDONVI.NGAY = N'", Me.QuoteString(obj.NGAYCD_LUOI)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_CHUYENDONVI set NGAY = N'", Me.QuoteString(obj.NGAYCD), "',CDV_Donvimoi = N'", Me.QuoteString(obj.DVMOI), "',CDV_chucvumoi = N'", Me.QuoteString(obj.CVUMOI), "',NGUOICAPNHAT = N'", Me.QuoteString(sNguoiCapNhat), "',NGAYCAPNHAT = N'", Me.QuoteString(sNgayCapNhat), "' where NV_MA = N'", Me.QuoteString(obj.MANV), "' AND ST_CHUYENDONVI.NGAY = N'", Me.QuoteString(obj.NGAYCD_LUOI)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If
        If obj.ChonBang = 8 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_NHANVIEN  SET ST_NHANVIEN.DV_MA = ST_CHUYENDONVI.CDV_DONVIMOI FROM ST_NHANVIEN INNER JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA = ST_CHUYENDONVI.NV_MA WHERE ST_NHANVIEN.NV_MA = N'", Me.QuoteString(obj.MANV), "' AND ST_CHUYENDONVI.NGAY = N'", Me.QuoteString(obj.NGAYCD)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

