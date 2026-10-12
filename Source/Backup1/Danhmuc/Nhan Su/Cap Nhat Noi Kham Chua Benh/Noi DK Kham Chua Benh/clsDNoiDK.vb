Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDNoiDK
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objNoiDK) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT STT ='', MA_KCB, TEN_KCB FROM IT_NOIKHAMCHUABENH ORDER BY MA_KCB ASC ")
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT MA_KCB, TEN_KCB FROM IT_NOIKHAMCHUABENH WHERE MA_KCB ='" & Me.QuoteString(obj.MaKCB) & "'")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT MA_KCB FROM IT_DANGKYKHAMCHUABENH WHERE MA_KCB ='" & Me.QuoteString(obj.MaKCB) & "'")
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

    Public Function InsertInfo(ByVal obj As objNoiDK) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into IT_NOIKHAMCHUABENH(MA_KCB, TEN_KCB) values(N'" & Me.QuoteString(obj.MaKCB) & "',N'" & Me.QuoteString(obj.TenKCB) & "')")
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

    Public Function DeleteInfo(ByVal jFunction As objNoiDK) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from IT_NOIKHAMCHUABENH where MA_KCB=N'" & Me.QuoteString(jFunction.MaKCB) & "'")
        End If
        Return Me.execSQL(strSQL)
    End Function
End Class
