Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDDangNhap
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As objDangNhap) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT * FROM [JELL_USER] WHERE Ten_DangNhap = '" + obj.TenDangNhap + "' and MK_DN = '" + obj.MatKhau + "' ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT [Ma_DM] FROM [JELL_DANHMUC] ")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT [Ma_DM] FROM [JELL_QUYENTRUYCAP] WHERE Ten_DangNhap = '" + obj.TenDangNhap + "' ")
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

    Public Function KiemTraThoiviec(ByVal obj As objDangNhap) As DataTable

        Dim strSQL As String =
        "SELECT A.NV_MA, " &
        "       A.NV_THOIVIEC, " &
        "       B.Ten_DangNhap " &
        "FROM ST_NHANVIEN A " &
        "LEFT JOIN JELL_USER B " &
        "       ON A.NV_MA = B.Ten_DangNhap " &
        "WHERE A.NV_MA = '" & obj.TenDangNhap & "'"

        Return Me.getTableSQL(strSQL)

    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

End Class
