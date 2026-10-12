Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDChiTietBBCV
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objChiTietBBCV) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Cau truy van load chuc vu
        If obj.ChonBang = 4 Then
            strSQL = "SELECT BB_MA FROM ST_BINHBAU"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "SELECT CVU_MA FROM ST_CHUCVU"
        End If
        If obj.ChonBang = 6 Then
            'strSQL = "SELECT * FROM ST_NHANVIEN WHERE NV_MA ='" + obj.MANV + "'"
        End If
        If obj.ChonBang = 7 Then
            'strSQL = "SELECT NV_MA,TV_NGAYTHOIVIEC, TV_SOQUYETDINH, TV_LYDO,ST_NHANVIENTHOIVIEC.LTV_MA, LTV_TEN FROM ST_NHANVIENTHOIVIEC INNER JOIN ST_LOAITHOIVIEC ON  ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_MA WHERE NV_MA ='" + obj.MANV + "'"
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
    Public Function InsertInfo(ByVal obj As objChiTietBBCV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = ("insert into IT_DIENBIENLUONG([NV_MA],[DBL_Ngaybatdau],[DBL_Soquyetdinh],[DBL_Heso],[DBL_LuongCB],[DBL_PhuCap]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.NGAY) & "','" & Me.QuoteString(obj.SoQD) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.LUONG) & "',N'" & Me.QuoteString(obj.PhuCap) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objChiTietBBCV) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            'strSQL = ("delete from IT_DIENBIENLUONG where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "' AND DBL_NGAYBATDAU = '" & Me.QuoteString(jFunction.NGAY) & "'")
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objChiTietBBCV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            'strSQL = ("UPDATE IT_DIENBIENLUONG   SET [NV_Ma] = '" & Me.QuoteString(obj.MANV) & "' ,[DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'   ,[DBL_Soquyetdinh] = '" & Me.QuoteString(obj.SoQD) & "'  ,[DBL_Heso] = '" & Me.QuoteString(obj.HESO) & "'  ,[DBL_LuongCB] = '" & Me.QuoteString(obj.LUONG) & "' ,[DBL_PhuCap] = '" & Me.QuoteString(obj.PhuCap) & "' WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND [DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'")
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
