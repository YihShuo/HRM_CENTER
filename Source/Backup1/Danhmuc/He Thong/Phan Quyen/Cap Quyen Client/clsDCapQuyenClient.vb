Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDCapQuyenClient
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objCapQuyenClient) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM [QUYEN_QUYENTRUYCAP] WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objCapQuyenClient) As Boolean
        Dim flag As Boolean

        Dim strSQL As String = ""
        strSQL = "INSERT INTO [QUYEN_QUYENTRUYCAP]([Ma_DM],[Ten_DangNhap],[Allow])VALUES(N'" & Me.QuoteString(obj.MaDanhMuc) & "',N'" & Me.QuoteString(obj.TenDangNhap) & "',1)"
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

    Public Function LoadDS(ByVal obj As objCapQuyenClient) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = (strSQL & " SELECT QUYEN_DANHMUC.Ma_DM,QUYEN_DANHMUC.Ten_DM,convert(bit,CASE WHEN NOT QUYEN_QUYENTRUYCAP.Ten_DangNhap IS NULL THEN 1 ELSE 0 END) as Allow FROM QUYEN_DANHMUC LEFT JOIN QUYEN_QUYENTRUYCAP ON (QUYEN_DANHMUC.Ma_DM = QUYEN_QUYENTRUYCAP.Ma_DM AND QUYEN_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "')")
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
