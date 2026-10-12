Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDNoiDangKyKCB
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objNoiDangKyKCB) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = "SELECT TOP 1 MA = LEFT(KCB_MA,3) FROM IT_NOIDANGKYKCB"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "SELECT MA = KCB_MA, TEN = KCB_TEN FROM IT_NOIDANGKYKCB"
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT  KCB_MA,  KCB_TEN FROM IT_NOIDANGKYKCB WHERE KCB_MA ='" & Me.QuoteString(obj.MA) & "'"
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

    Public Function UpdateInfo(ByVal obj As objNoiDangKyKCB) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_NOIDANGKYKCB  SET  KCB_TEN = N'" & Me.QuoteString(obj.TEN) & "', NGUOICN = N'" & Me.QuoteString(obj.NGUOICN) & "', NGAYCN = N'" & Me.QuoteString(obj.NGAYCN) & "' WHERE KCB_MA = '" & Me.QuoteString(obj.MA) & "'"
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

    Public Function DeleteInfo(ByVal obj As objNoiDangKyKCB) As Boolean
        Dim strSQL, strSQLThaoTac As String
        Dim Flag As Boolean = False
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_NOIDANGKYKCB WHERE KCB_MA ='" & Me.QuoteString(obj.MA) & "'"
        End If
        If Me.execSQL(strSQL) Then
            Flag = True
            strSQLThaoTac = "INSERT INTO JELL_TACDONG (NV_MA,TEN_DANGNHAP,THOIDIEM,HANHDONG,GIATRI) SELECT NV_MA='" & Me.QuoteString(obj.MA) & "','" & Me.QuoteString(obj.TenDangNhap) & "','" & Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now()) & "','" & Me.QuoteString(strSQL) & "','0'"
            Me.execSQL(strSQLThaoTac)
        Else
            Flag = False
        End If
        Return Flag
    End Function

    Public Function InsertInfo(ByVal obj As objNoiDangKyKCB) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_NOIDANGKYKCB([KCB_MA],[KCB_TEN],[NGUOITAO],[NGAYTAO]) values(N'" & Me.QuoteString(obj.MA) & "',N'" & Me.QuoteString(obj.TEN) & "',N'" & Me.QuoteString(obj.NGUOITAO) & "',N'" & Me.QuoteString(obj.NGAYTAO) & "')"
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
