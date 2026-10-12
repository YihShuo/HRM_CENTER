Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDcapnhatqdtv
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objcapnhatqdtv) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        ''load theo so the
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT NV_MA,SOQD,TV_NGAYQD FROM ST_NHANVIENTHOIVIEC_QD ")
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If
        ''load toan bo
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_MA,SOQD,TV_NGAYTHOIVIEC,TV_NGAYQD FROM ST_NHANVIENTHOIVIEC_QD ")
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

    Public Function UpdateInfo(ByVal obj As objcapnhatqdtv) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 2 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_NHANVIENTHOIVIEC_QD  SET SOQD='", Me.QuoteString(obj.SOQD), "',TV_NGAYQD='", Me.QuoteString(obj.NGAY), "' WHERE NV_MA = N'", Me.QuoteString(obj.MANV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
