Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDNhapDBLuong
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objNhapDBLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Cau truy van load chuc vu
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT CVU_MA FROM ST_CHUCVU WHERE CVU_MA <> ' ' ORDER BY CVU_TEN ASC ")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("select isnull(HD_LuongCB,0) as HD_LuongCB,isnull(HD_HeSo,0) as HD_HeSo,isnull(HD_So,0) as HD_So,isnull(HD_PhuCap,0) as HD_PhuCap,isnull(HD_PhuCapkhac,0) as HD_PhuCapkhac,isnull(HD_TrocapCV,0) as HD_TrocapCV,isnull(HD_TrocapNN,0) as HD_TrocapNN,isnull(HD_TrocapUD,0) as HD_TrocapUD,isnull(HD_TrocapCMNV,0) as HD_TrocapCMNV,isnull(TCCBVP,0) as TCCBVP,isnull(HD_TrocapHMPT,0) as HD_TrocapHMPT,isnull(HD_TrocapMOITRUONG,0) as HD_TrocapMOITRUONG,isnull(TCCBTS,0) as TCCBTS,isnull(TCBBTHANG,0) as TCBBTHANG,isnull(TCBBNT,0) as TCBBNT,isnull(TCBBHT,0) as TCBBHT,isnull(HD_TCHOTRODONGPHUC,0) as HD_TCHOTRODONGPHUC,isnull(HD_TCCHAMLOGIADINH,0) as HD_TCCHAMLOGIADINH,isnull(HD_TroCapQAQIP,0) as HD_TroCapQAQIP,isnull(HD_TrocapThoRap,0) as HD_TrocapThoRap,isnull(HD_TrocapHSE,0) as HD_TrocapHSE , HD_KHONGHUONGCHUYENCAN,isnull(HD_CONGVIECDH,0) AS HD_CONGVIECDH,HD_PHUCLOI= ISNULL(HD_PHUCLOI,0),HD_HTNG = ISNULL(HD_HTNG,0),DQTV= ISNULL(HD_DQTV,0),HD_PCCC = ISNULL(HD_PCCC,0) from ST_HOPDONGLAODONG where NV_Ma =N'" & Me.QuoteString(obj.MANV) & "'")
        End If
        'Cau truy van load cong viec
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT CV_MA , CV_TEN = CV_MA +'---' +CV_TEN FROM ST_CONGVIEC WHERE CV_MA <> ' ' ORDER BY CV_TEN ASC ")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT * FROM IT_dienbienluong where NV_Ma =N'" & Me.QuoteString(obj.MANV) & "' and  dbl_ngaybatdau =N'" & Me.QuoteString(obj.NGAY) & "'")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("SELECT * FROM ST_dienbienluong where NV_Ma =N'" & Me.QuoteString(obj.MANV) & "' and  dbl_ngaybatdau =N'" & Me.QuoteString(obj.NGAY) & "'")
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
    Public Function InsertInfo(ByVal obj As objNhapDBLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into IT_DIENBIENLUONG([NV_MA],[DBL_Ngaybatdau],[DBL_Soquyetdinh],[DBL_Heso],[DBL_LuongCB],[DBL_PhuCap]) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.NGAY) & "','" & Me.QuoteString(obj.SoQD) & "',N'" & Me.QuoteString(obj.HESO) & "',N'" & Me.QuoteString(obj.LUONG) & "',N'" & Me.QuoteString(obj.PhuCap) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objNhapDBLuong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from IT_DIENBIENLUONG where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "' AND DBL_NGAYBATDAU = '" & Me.QuoteString(jFunction.NGAY) & "'")
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objNhapDBLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            strSQL = ("UPDATE IT_DIENBIENLUONG   SET [NV_Ma] = '" & Me.QuoteString(obj.MANV) & "' ,[DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'   ,[DBL_Soquyetdinh] = '" & Me.QuoteString(obj.SoQD) & "'  ,[DBL_Heso] = '" & Me.QuoteString(obj.HESO) & "'  ,[DBL_LuongCB] = '" & Me.QuoteString(obj.LUONG) & "' ,[DBL_PhuCap] = '" & Me.QuoteString(obj.PhuCap) & "' WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "' AND [DBL_Ngaybatdau] = '" & Me.QuoteString(obj.NGAY) & "'")
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
