Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDTienVuotSanLuong
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objTienVuotSanLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.CHONBANG = 1 Then
            strSQL = "SELECT STT, ST_NHANVIEN.NV_Ma,"
            strSQL = strSQL + " ST_NHANVIEN.NV_Ten,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA ,"
            strSQL = strSQL + " IT_TIENVUOTSANLUONG.T_MA,"
            strSQL = strSQL + " IT_TIENVUOTSANLUONG.SOTIEN"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_TIENVUOTSANLUONG ON ST_NHANVIEN.NV_Ma = IT_TIENVUOTSANLUONG.NV_MA"
            strSQL = strSQL + " WHERE T_MA = '" + obj.T_MA + "'"
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
    Public Function DeleteInfo(ByVal obj As objTienVuotSanLuong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE IT_TIENVUOTSANLUONG WHERE T_Ma  ='" & obj.T_MA) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function
End Class
