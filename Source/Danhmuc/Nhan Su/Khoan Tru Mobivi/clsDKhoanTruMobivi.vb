Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDKhoanTruMobivi
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objKhoanTruMobivi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        strSQL = "   SELECT STT,IT_MOBIVI.NV_Ma , NV_Ten, DV_TEN "
        strSQL = strSQL + ",  MB_SoTien - ISNULL(MB_Sotien_Vuot,0) as MB_SoTien,MB_Sotien_Vuot"
        strSQL = strSQL + " from IT_MOBIVI INNER JOIN ST_NHANVIEN ON IT_MOBIVI.NV_MA = ST_NHANVIEN.NV_MA"
        strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
        strSQL = strSQL + " WHERE T_Ma  ='" + obj.T_MA + "'"
        strSQL = strSQL + " ORDER BY IT_MOBIVI.NV_Ma"

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
    Public Function DeleteInfo(ByVal obj As objKhoanTruMobivi) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE IT_MOBIVI WHERE T_Ma  ='" & obj.T_MA) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function
End Class
