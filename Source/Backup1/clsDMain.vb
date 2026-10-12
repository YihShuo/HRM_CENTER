Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDMain
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As objMain) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT * FROM [JELL_USER] WHERE Ten_DangNhap = '" + obj.TenDangNhap + "' and MK_DN = '" + obj.MatKhau + "' ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT [Ma_DM] FROM [JELL_DANHMUC] ")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT JELL_DANHMUC.Nhom_DM FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.TenDangNhap + "' GROUP BY JELL_DANHMUC.Nhom_DM ")
        End If
        If obj.ChonBang = 22 Then
            strSQL = ("SELECT [Ma_DM] FROM [JELL_DANHMUC] where Nhom_DM='" + obj.NhomDM + "'")
        End If

        If obj.ChonBang = 33 Then
            strSQL = ("SELECT JELL_QUYENTRUYCAP.Ma_DM, JELL_QUYENTRUYCAP.KHUA, JELL_QUYENTRUYCAP.KHUB  FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.TenDangNhap + "' and JELL_DANHMUC.Nhom_DM ='" + obj.NhomDM + "'")
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

End Class
