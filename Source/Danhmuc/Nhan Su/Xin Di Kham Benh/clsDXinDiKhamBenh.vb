Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class clsDXinDiKhamBenh
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objXinDiKhamBenh) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = "SELECT KCB_MA, KCB_TEN FROM IT_NOIDANGKYKCB"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "SELECT NV_MA, NV_TEN, DV_MA FROM ST_NHANVIEN WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT NV_MA FROM IT_KHAMCHUABENH WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND KCB_NGAY = '" & Me.QuoteString(obj.Ngay) & "'"
        End If
        If obj.ChonBang = 4 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA, ST_NHANVIEN.NV_TEN,IT_KHAMCHUABENH.DV_MA,KCB_NGAY,IT_NOIDANGKYKCB.KCB_TEN,KCB_CHANDOAN,KCB_GHICHU, IT_KHAMCHUABENH.KCB_NOIKCB"
            strSQL = strSQL + " FROM IT_KHAMCHUABENH INNER JOIN IT_NOIDANGKYKCB ON IT_KHAMCHUABENH.KCB_NOIKCB = IT_NOIDANGKYKCB.KCB_MA"
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON IT_KHAMCHUABENH.NV_MA = ST_NHANVIEN.NV_Ma "
            strSQL = strSQL + " WHERE KCB_NGAY = '" & Me.QuoteString(obj.Ngay) & "'"
        End If
        If obj.ChonBang = 5 Then
            strSQL = "SELECT  KCB_FLAG FROM IT_KHAMCHUABENH WHERE  KCB_NGAY = '" & Me.QuoteString(obj.Ngay) & "'"
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

    Public Function UpdateInfo(ByVal obj As objXinDiKhamBenh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_KHAMCHUABENH  SET  KCB_NOIKCB = N'" & Me.QuoteString(obj.NOIKHAM) & "',KCB_CHANDOAN = N'" & Me.QuoteString(obj.CHANDOAN) & "', KCB_GHICHU = N'" & Me.QuoteString(obj.GHICHU) & "', NGUOICN = N'" & Me.QuoteString(obj.NGUOICN) & "', NGAYCN = N'" & Me.QuoteString(obj.NGAYCN) & "' WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND KCB_NGAY = '" & Me.QuoteString(obj.Ngay) & "'"
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

    Public Function DeleteInfo(ByVal obj As objXinDiKhamBenh) As Boolean
        Dim strSQL, strSQLThaoTac As String
        Dim Flag As Boolean = False
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_KHAMCHUABENH WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "' AND KCB_NGAY ='" & Me.QuoteString(obj.Ngay) & "'"
        End If
        If Me.execSQL(strSQL) Then
            Flag = True
            strSQLThaoTac = "INSERT INTO jell_TacDong (NV_MA,TEN_DANGNHAP,THOIDIEM,HANHDONG,GIATRI) SELECT NV_MA='" & Me.QuoteString(obj.NV_MA) & "','" & Me.QuoteString(obj.TenDangNhap) & "','" & Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now()) & "','" & Me.QuoteString(strSQL) & "','0'"
            Me.execSQL(strSQLThaoTac)
        Else
            Flag = False
        End If
        Return Flag
    End Function

    Public Function InsertInfo(ByVal obj As objXinDiKhamBenh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_KHAMCHUABENH([NV_MA],[DV_MA],[KCB_NGAY],[KCB_NOIKCB],[KCB_CHANDOAN],[KCB_GHICHU],[NGUOITAO],[NGAYTAO]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.Ngay) & "',N'" & Me.QuoteString(obj.NOIKHAM) & "',N'" & Me.QuoteString(obj.CHANDOAN) & "',N'" & Me.QuoteString(obj.GHICHU) & "',N'" & Me.QuoteString(obj.NGUOITAO) & "',N'" & Me.QuoteString(obj.NGAYTAO) & "')"
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
