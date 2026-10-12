Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDBangThongKeKyLuat
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objBangThongKeKyLuat) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT KL_MA, KL_TEN FROM ST_KYLUAT  ORDER BY KL_THUTU ")
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_TEN, DV_MA,DV_MA_,IT_DDNGHIVIEC FROM ST_NHANVIEN  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'")
        End If
        If obj.ChonBang = 3 Then
            ''hieu chinh: khong xet don vi
            strSQL = ("SELECT NV_MA, DV_MA, KL_MA, KL_NGAYBATDAU FROM ST_NHANVIENKYLUAT WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND KL_MA = '" & Me.QuoteString(obj.MAKYLUAT) & "' AND KL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAYBATDAU) & "'")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT ST_NHANVIEN.STT AS STT, ST_NHANVIEN.NV_MA AS MA, ST_NHANVIEN.NV_TEN AS TEN,ST_NHANVIEN.DV_MA AS DONVI,ST_NHANVIENKYLUAT.KL_Ngaybatdau AS NGAYBATDAU,ST_NHANVIENKYLUAT.KL_Ngayketthuc AS NGAYKETTHUC,ST_KYLUAT.KL_TEN AS TENKL,ST_KYLUAT.KL_MA AS MAKL,ST_NHANVIENKYLUAT.NNKL_MA,ST_NGUYENNHANKYLUAT.NNKL_Ten , ST_NHANVIENKYLUAT.KL_LYDO AS LYDO,KL_Ngayquyetdinh,KL_Soquyetdinh FROM ST_NHANVIEN INNER JOIN ST_NHANVIENKYLUAT ON ST_NHANVIEN.NV_MA = ST_NHANVIENKYLUAT.NV_MA INNER JOIN ST_KYLUAT ON ST_KYLUAT.KL_MA = ST_NHANVIENKYLUAT.KL_MA LEFT JOIN ST_NGUYENNHANKYLUAT ON  ST_NHANVIENKYLUAT.NNKL_MA = ST_NGUYENNHANKYLUAT.NNKL_MA")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("SELECT NV_MA, DV_MA, KL_MA, KL_NGAYBATDAU FROM ST_NHANVIENKYLUAT WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'")
        End If
        ''=========== NGAY QUYET DINH NAM TRONG KHOANG THOI GIAN KY LUAT KHONG? =======''
        If obj.ChonBang = 6 Then
            strSQL = ("SELECT NGAYQD=CASE WHEN ('" & obj.NGAYQUYETDINH & "' BETWEEN '" & obj.NGAYBATDAU & "' AND '" & obj.NGAYKETTHUC & "') THEN 1 ELSE 0 END")
        End If
        If obj.ChonBang = 7 Then
            ''kiem tra khi thuc hien thao tac sua 
            strSQL = ("SELECT NV_MA, DV_MA, KL_MA, KL_NGAYBATDAU FROM ST_NHANVIENKYLUAT WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND KL_MA = '" & Me.QuoteString(obj.MAKYLUATLUOI) & "' AND KL_NGAYBATDAU = '" & Me.QuoteString(obj.NGAYBATDAU) & "'")
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT ST_NGUYENNHANKYLUAT.NNKL_Ma ,ST_NGUYENNHANKYLUAT.NNKL_Ten FROM ST_NGUYENNHANKYLUAT  ORDER BY NNKL_THUTU ")
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
    Public Function InsertInfo(ByVal obj As objBangThongKeKyLuat) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.NGAYKETTHUC = "" Then
            strSQL = ("insert into ST_NHANVIENKYLUAT(NV_Ma,DV_MA, KL_MA,KL_NGAYBATDAU, KL_NGAYKETTHUC, KL_LYDO,KL_Ngayquyetdinh,KL_Soquyetdinh,NNKL_Ma) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.MAKYLUAT) & "',N'" & Me.QuoteString(obj.NGAYBATDAU) & "',NULL " & ",N'" & Me.QuoteString(obj.LYDO) & "',N'" & Me.QuoteString(obj.NGAYQUYETDINH) & "',N'" & Me.QuoteString(obj.SOQD) & "',N'" & Me.QuoteString(obj.NNKL_MA) & "')")
        Else
            strSQL = ("insert into ST_NHANVIENKYLUAT(NV_Ma,DV_MA, KL_MA,KL_NGAYBATDAU, KL_NGAYKETTHUC, KL_LYDO,KL_Ngayquyetdinh,KL_Soquyetdinh,NNKL_Ma) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.MAKYLUAT) & "',N'" & Me.QuoteString(obj.NGAYBATDAU) & "',N'" & Me.QuoteString(obj.NGAYKETTHUC) & "',N'" & Me.QuoteString(obj.LYDO) & "',N'" & Me.QuoteString(obj.NGAYQUYETDINH) & "',N'" & Me.QuoteString(obj.SOQD) & "',N'" & Me.QuoteString(obj.NNKL_MA) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objBangThongKeKyLuat) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from ST_NHANVIENKYLUAT where NV_MA=N'" & Me.QuoteString(jFunction.MANV)) & "'AND KL_MA = '" & Me.QuoteString(jFunction.MAKYLUAT) & "'AND KL_NGAYBATDAU = '" & Me.QuoteString(jFunction.NGAYBATDAU) & "'"
        End If
        If jFunction.ChonBang = 2 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_NHANVIENKYLUAT where NV_MA=N'" & Me.QuoteString(jFunction.MANV)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objBangThongKeKyLuat) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.NGAYKETTHUC = "" Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIENKYLUAT set DV_MA =N'", Me.QuoteString(obj.DONVI), "',KL_Ngayketthuc= NULL,KL_LyDo=N'", Me.QuoteString(obj.LYDO), "',KL_Ma =N'", Me.QuoteString(obj.MAKYLUAT), "',KL_Ngayquyetdinh=N'", Me.QuoteString(obj.NGAYQUYETDINH), "',KL_Soquyetdinh=N'", Me.QuoteString(obj.SOQD), "',NNKL_Ma=N'", Me.QuoteString(obj.NNKL_MA), "' where NV_MA=N'", Me.QuoteString(obj.MANV), "' AND KL_Ngaybatdau=N'", Me.QuoteString(obj.NGAYBATDAU), "' AND KL_Ma=N'", Me.QuoteString(obj.MAKYLUATLUOI)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Else
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIENKYLUAT set DV_MA =N'", Me.QuoteString(obj.DONVI), "',KL_Ngayketthuc=N'", Me.QuoteString(obj.NGAYKETTHUC), "',KL_Ma =N'", Me.QuoteString(obj.MAKYLUAT), "',KL_LyDo=N'", Me.QuoteString(obj.LYDO), "',KL_Ngayquyetdinh=N'", Me.QuoteString(obj.NGAYQUYETDINH), "',KL_Soquyetdinh=N'", Me.QuoteString(obj.SOQD), "',NNKL_Ma=N'", Me.QuoteString(obj.NNKL_MA), "' where NV_MA=N'", Me.QuoteString(obj.MANV), "' AND KL_Ngaybatdau=N'", Me.QuoteString(obj.NGAYBATDAU), "' AND KL_Ma=N'", Me.QuoteString(obj.MAKYLUATLUOI)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
