Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDCapquyen
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objCapquyen) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM [JELL_QUYENTRUYCAP] WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objCapquyen) As Boolean
        Dim flag As Boolean

        Dim strSQL As String = ""
        'strSQL = "INSERT INTO [JELL_QUYENTRUYCAP]([Ma_DM],[Ten_DangNhap],[Allow],[Them],[Sua],[Xoa],[KHUA],[KHUB])VALUES(N'" & Me.QuoteString(obj.MaDanhMuc) & "',N'" & Me.QuoteString(obj.TenDangNhap) & "',1," & Me.QuoteString(obj.Them) & "," & Me.QuoteString(obj.Sua) & "," & Me.QuoteString(obj.Xoa) & "," & Me.QuoteString(obj.KHUA) & "," & Me.QuoteString(obj.KHUB) & ")"
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO [JELL_QUYENTRUYCAP]([Ma_DM],[Ten_DangNhap],[Allow],[Them],[Sua],[Xoa],[KHUA],[KHUB])VALUES(N'" & Me.QuoteString(obj.MaDanhMuc) & "',N'" & Me.QuoteString(obj.TenDangNhap) & "',1," & Me.QuoteString(obj.Them) & "," & Me.QuoteString(obj.Sua) & "," & Me.QuoteString(obj.Xoa) & "," & Me.QuoteString(obj.KHUA) & "," & Me.QuoteString(obj.KHUB) & ")"
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

   
    Public Function LoadDS(ByVal obj As objCapquyen) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = strSQL + " SELECT JELL_DANHMUC.Ma_DM,  JELL_DANHMUC.Ten_DM,"
            strSQL = strSQL + " convert(bit,CASE WHEN Allow = 1 THEN 1 ELSE 0 END) as Allow ,"
            strSQL = strSQL + " convert(bit,CASE WHEN Them = 1 THEN 1 ELSE 0 END) as Them ,"
            strSQL = strSQL + " convert(bit,CASE WHEN Sua = 1 THEN 1 ELSE 0 END) as Sua ,"
            strSQL = strSQL + " convert(bit,CASE WHEN Xoa = 1 THEN 1 ELSE 0 END) as Xoa, "
            strSQL = strSQL + " convert(bit,CASE WHEN KHUA = 1 THEN 1 ELSE 0 END) as KhuA ,"
            strSQL = strSQL + " convert(bit,CASE WHEN KHUB = 1 THEN 1 ELSE 0 END) as KhuB "
            strSQL = strSQL + " FROM JELL_DANHMUC LEFT JOIN JELL_QUYENTRUYCAP ON (JELL_DANHMUC.Ma_DM = JELL_QUYENTRUYCAP.Ma_DM AND JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "')"
        End If

        If obj.ChonBang = 2 Then
            strSQL = strSQL + " SELECT * "
            strSQL = strSQL + " FROM JELL_QUYENTRUYCAP "
            strSQL = strSQL + " WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap) & "' AND "
            strSQL = strSQL + " Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "'"
        End If

        If obj.ChonBang = 3 Then
            'strSQL = strSQL + " UPDATE JELL_QUYENTRUYCAP "
            'strSQL = strSQL + " SET Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "',"
            'strSQL = strSQL + " Allow = 1,"
            'strSQL = strSQL + " Them = " & Me.QuoteString(obj.Them) & ","
            'strSQL = strSQL + " Sua = " & Me.QuoteString(obj.Sua) & ","
            'strSQL = strSQL + " Xoa = " & Me.QuoteString(obj.Xoa) & ","
            'strSQL = strSQL + " KHUA = " & Me.QuoteString(obj.KHUA) & ","
            'strSQL = strSQL + " KHUB = " & Me.QuoteString(obj.KHUB) & ""
            'strSQL = strSQL + " WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap) & "' AND "
            'strSQL = strSQL + " Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "'"
            If obj.Xem = 1 Then
                strSQL = strSQL + " UPDATE JELL_QUYENTRUYCAP "
                strSQL = strSQL + " SET Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "',"
                strSQL = strSQL + " Allow = " & Me.QuoteString(obj.Xem) & ","
                strSQL = strSQL + " Them = " & Me.QuoteString(obj.Them) & ","
                strSQL = strSQL + " Sua = " & Me.QuoteString(obj.Sua) & ","
                strSQL = strSQL + " Xoa = " & Me.QuoteString(obj.Xoa) & ","
                strSQL = strSQL + " KHUA = " & Me.QuoteString(obj.KHUA) & ","
                strSQL = strSQL + " KHUB = " & Me.QuoteString(obj.KHUB) & " "
                strSQL = strSQL + " WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap) & "' AND "
                strSQL = strSQL + " Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "'"
            ElseIf obj.Xem = 0 Then
                strSQL = strSQL + " DELETE FROM JELL_QUYENTRUYCAP WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap) & "' AND Ma_DM = N'" & Me.QuoteString(obj.MaDanhMuc) & "'"
            End If
        End If

            Try
            table = Me.getTableSQL(strSQL)
            'If table.Columns.Count > 0 Then
            '    MessageBox.Show("true")
            'End If

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
