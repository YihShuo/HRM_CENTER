Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDQuaTrinhDieuDong
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objQuaTrinhDieuDong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = "select nv_ma,b.dv_ma +'--'+ dv_ten as dv_ten, c.cvu_ma +'--'+ cvu_ten as cvu_ten, nv_ten from st_nhanvien a inner join st_donvi b on a.dv_ma=b.dv_ma left join st_chucvu c on a.cvu_ma=c.cvu_ma where nv_ma='" + obj.MaNV + "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "select CONVERT(CHAR,NGAY,103) AS NGAY,CDV_DONVIMOI,CDV_CHUCVUMOI,CDV_DONVICU,CDV_CHUCVUCU from st_chuyendonvi where nv_ma='" + obj.MaNV + "'"
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
End Class
