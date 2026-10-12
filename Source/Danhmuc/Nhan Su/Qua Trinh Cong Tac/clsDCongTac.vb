Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDCongTac
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objCongTac) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
    
        If obj.ChonBang = 1 Then
            strSQL = (" SELECT NV_TEN")
            strSQL = strSQL + "  FROM ST_NHANVIEN"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = (" SELECT * FROM ST_DONVI WHERE DV_MA <> ' '  ORDER BY DV_MA")
        End If
        If obj.ChonBang = 3 Then
            strSQL = (" SELECT * FROM ST_CONGVIEC WHERE CV_MA <> ' ' ORDER BY CV_MA")
        End If
        If obj.ChonBang = 4 Then
            strSQL = (" SELECT * FROM ST_CHUCVU WHERE CVU_MA <> ' '  ORDER BY CVU_MA")
        End If
        If obj.ChonBang = 5 Then
            strSQL = ("SELECT NV_MA")
            strSQL = strSQL + ", CT_TUNGAY "
            strSQL = strSQL + "  FROM ST_QUATRINHCONGTAC"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND CT_TUNGAY = '" & Me.QuoteString(obj.NGAY) & "'"
        End If
        If obj.ChonBang = 6 Then
            strSQL = (" SELECT STT, ST_NHANVIEN.NV_TEN AS TEN,")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA AS MA,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_QUATRINHCONGTAC.CT_TUNGAY AS NGAY,"
            strSQL = strSQL + " ST_QUATRINHCONGTAC.CT_Soquyetdinh AS SOQUYETDINH,"
            strSQL = strSQL + " ST_QUATRINHCONGTAC.CT_DonVi AS DONVICT,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN AS CHUCVU,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN AS CONGVIEC,"
            strSQL = strSQL + " ST_QUATRINHCONGTAC.CT_GhiChu AS GHICHU "
            strSQL = strSQL + " FROM ST_QUATRINHCONGTAC INNER JOIN ST_NHANVIEN ON ST_QUATRINHCONGTAC.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " INNER JOIN ST_CONGVIEC ON ST_QUATRINHCONGTAC.CT_CongViec = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " INNER JOIN ST_CHUCVU ON ST_QUATRINHCONGTAC.CT_ChucVu = ST_CHUCVU.CVU_MA"
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
    Public Function InsertInfo(ByVal obj As objCongTac) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into ST_QUATRINHCONGTAC(NV_Ma,CT_TUNGAY, CT_SOQUYETDINH, CT_DONVI, CT_CHUCVU, CT_CONGVIEC, CT_GHICHU) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.NGAY) & "',N'" & Me.QuoteString(obj.SOQD) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.CHUCVU) & "',N'" & Me.QuoteString(obj.CONGVIEC) & "',N'" & Me.QuoteString(obj.GHICHU) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objCongTac) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from ST_QUATRINHCONGTAC where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'AND CT_TUNGAY = '" & Me.QuoteString(jFunction.NGAY)) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objCongTac) As Boolean
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
