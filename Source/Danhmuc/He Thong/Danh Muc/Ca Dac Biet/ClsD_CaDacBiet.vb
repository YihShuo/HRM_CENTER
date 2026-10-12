Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsD_CaDacBiet
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As Obj_CaDacBiet) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = "SELECT b.NV_Ten,a.*"
            strSQL = strSQL + " FROM IT_CHONCALAMVIEC a INNER JOIN ST_NHANVIEN b ON a.NV_MA = b.NV_Ma"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "SELECT *"
            strSQL = strSQL + " FROM IT_CHONCALAMVIEC"
            strSQL = strSQL + " WHERE NV_MA='" & Me.QuoteString(obj.MaNhanVien) & "'"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT NV_Ma, NV_Ten, DV_MA"
            strSQL = strSQL + " FROM ST_NHANVIEN"
            strSQL = strSQL + " WHERE NV_MA='" & Me.QuoteString(obj.MaNhanVien) & "'"
        End If
        'Thực thi câu truy vấn
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

    Public Function InsertInfo(ByVal obj As Obj_CaDacBiet) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            'strSQL = ("INSERT INTO IT_CHONCALAMVIEC(NV_MA, NGAY, CA_MA, DV_MA, NgayNhap) VALUES(N'" & Me.QuoteString(obj.MaNhanVien) & "', GETDATE(),N'" & Me.QuoteString(obj.CaMa) & "',N'" & Me.QuoteString(obj.DonVi) & "', GETDATE() )")
            strSQL = strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10) & "INSERT INTO IT_CHONCALAMVIEC(NV_MA, NGAY, CA_MA, DV_MA, NgayNhap) VALUES(N'" & Me.QuoteString(obj.MaNhanVien) & "', GETDATE(),N'" & Me.QuoteString(obj.CaMa) & "',N'" & Me.QuoteString(obj.DonVi) & "', GETDATE())" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION"
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

    Public Function UpdateInfo(ByVal obj As Obj_CaDacBiet) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            ' 2 lệnh dưới như nhau
            'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "UPDATE IT_CHONCALAMVIEC SET CA_MA='" & Me.QuoteString(obj.CaMa) & "' WHERE NV_MA='" & Me.QuoteString(obj.MaNhanVien) & "'") & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            strSQL = strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10) & "UPDATE IT_CHONCALAMVIEC SET CA_MA='" & Me.QuoteString(obj.CaMa) & "' WHERE NV_MA='" & Me.QuoteString(obj.MaNhanVien) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION"
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

    Public Function DeleteInfo(ByVal obj As Obj_CaDacBiet) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        Dim Flag As Boolean = False
        If obj.ChonBang = 1 Then
            ' 2 lệnh dưới như nhau
            'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from IT_CHONCALAMVIEC where NV_MA =N'" & obj.MaNhanVien) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from IT_CHONCALAMVIEC where NV_MA =N'" & Me.QuoteString(obj.MaNhanVien)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If
        Try
            Flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Flag = False
            ProjectData.ClearProjectError()
        End Try
        Return Flag
    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function


End Class
