Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsD_Thang
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As Obj_Thang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("select *  from ST_THANG" & strSQL)
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("select *  from ST_LE" & strSQL)
        End If
        If obj.ChonBang = 3 Then
            strSQL = " DECLARE @SOCN INT "
            strSQL = strSQL + " EXEC SP_SONGAYCHUNHAT " + "'" + obj.TUNGAY + "','" + obj.DENNGAY + "',1 ,@SOCN OUTPUT "
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("select *  from ST_THANG where T_MA ='" + obj.MATHANG + "'")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("select *  from ST_LE where LE_NGAY ='" + obj.NGAY + "'")
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

    Public Function DeleteInfo(ByVal obj As Obj_Thang) As Boolean
        'Dim strSQL As String = ""
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_THANG where T_MA =N'" & Me.QuoteString(obj.MATHANG)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function DeleteInfo1(ByVal obj As Obj_Thang) As Boolean
        'Dim strSQL As String = ""
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_LE where LE_NGAY =N'" & Me.QuoteString(obj.NGAY)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function
    Public Function InsertInfo(ByVal obj As Obj_Thang) As Boolean
        Dim flag As Boolean
        'Dim ngaybt As String = Left(obj.TUNGAY, 2)
        ''Dim ngay As String = obj.TUNGAY

        'Dim thangbt As String = Left(Left(obj.TUNGAY, 4), 2)
        'Dim nambt As String = Right(obj.TUNGAY, 4)
        'obj.TUNGAY = nambt + "-" + thangbt + "-" + ngaybt

        'Dim ngaykt As String = Left(obj.DENNGAY, 2)
        'Dim thangkt As String = Right(Left(obj.DENNGAY, 4), 2)
        'Dim namkt As String = Right(obj.DENNGAY, 4)

        'obj.DENNGAY = namkt + "-" + thangkt + "-" + ngaykt
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE " & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_THANG (T_MA,T_TUNGAY,T_DENNGAY, T_SONGAYCONG) values(N'", Me.QuoteString(obj.MATHANG), "','", Me.QuoteString(obj.TUNGAY), "','", Me.QuoteString(obj.DENNGAY), "',", Me.QuoteString(obj.SONGAYCONG)}) & ")" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Thông báo")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function InsertInfo1(ByVal obj As Obj_Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE " & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_LE (LE_NGAY,LE_TEN) values(N'", Me.QuoteString(obj.NGAY), "',N'", Me.QuoteString(obj.TENNGAYLE)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Thông báo")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("''", "''")
    End Function


    Public Function UpdateInfo(ByVal obj As Obj_Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_THANG set T_TUNGAY = N'", Me.QuoteString(obj.TUNGAY), "',T_DENNGAY = '", Me.QuoteString(obj.DENNGAY), "',T_SONGAYCONG = N'", Me.QuoteString(obj.SONGAYCONG), "' where T_MA=N'", Me.QuoteString(obj.MATHANG)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

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


    Public Function UpdateInfo1(ByVal obj As Obj_Thang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_LE set LE_TEN = N'", Me.QuoteString(obj.TENNGAYLE), "' where LE_NGAY=N'", Me.QuoteString(obj.NGAY)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

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
