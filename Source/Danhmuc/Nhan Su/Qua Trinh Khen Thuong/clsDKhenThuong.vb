Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDKhenThuong
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objKhenThuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = (" SELECT NV_TEN, DV_MA")
            strSQL = strSQL + "  FROM ST_NHANVIEN"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = (" SELECT * FROM ST_KHENTHUONG ORDER BY KT_MA")
           End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT NV_MA")
            strSQL = strSQL + ", KT_NGAYBATDAU "
            strSQL = strSQL + ", KT_MA "
            strSQL = strSQL + "  FROM ST_NHANVIENKHENTHUONG"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND KT_NGAYBATDAU = '" & Me.QuoteString(obj.NGAYBATDAU) & "' AND KT_MA = '" & Me.QuoteString(obj.MAKT) & "'"
        End If
        If obj.ChonBang = 4 Then
            strSQL = (" SELECT STT,ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_NHANVIENKHENTHUONG.KT_Ngaybatdau AS NGAYBATDAU,"
            strSQL = strSQL + " ST_NHANVIENKHENTHUONG.KT_Ngayketthuc AS NGAYKETTHUC,"
            strSQL = strSQL + " ST_KHENTHUONG.KT_TEN AS TENKT,"
            strSQL = strSQL + " ST_NHANVIENKHENTHUONG.KT_MA AS MAKT,"
            strSQL = strSQL + " ST_NHANVIENKHENTHUONG.KT_Lydo AS LYDO"
            strSQL = strSQL + " FROM ST_NHANVIENKHENTHUONG "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_NHANVIENKHENTHUONG.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_KHENTHUONG ON ST_NHANVIENKHENTHUONG.KT_MA = ST_KHENTHUONG.KT_MA"
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
    Public Function InsertInfo(ByVal obj As objKhenThuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into ST_NHANVIENKHENTHUONG(NV_Ma, DV_MA,KT_NGAYBATDAU, KT_NGAYKETTHUC, KT_MA, KT_LYDO) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.NGAYBATDAU) & "',N'" & Me.QuoteString(obj.NGAYKETTHUC) & "',N'" & Me.QuoteString(obj.MAKT) & "',N'" & Me.QuoteString(obj.GHICHU) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objKhenThuong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from ST_NHANVIENKHENTHUONG where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'AND KT_NGAYBATDAU = '" & Me.QuoteString(jFunction.NGAYBATDAU)) & "' AND KT_MA ='" & Me.QuoteString(jFunction.MAKT) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objKhenThuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 18 Then
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
