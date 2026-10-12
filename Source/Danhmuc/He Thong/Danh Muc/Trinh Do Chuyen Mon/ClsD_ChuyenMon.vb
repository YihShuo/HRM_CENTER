Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsD_ChuyenMon
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As Obj_ChuyenMon) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.MACHUYENMON, "", False) <> 0) Then
            strSQL = (strSQL & " where CM_MA = N'" & Me.QuoteString(obj.MACHUYENMON) & "'")
        End If
        strSQL = ("select CM_MA, CM_TEN  from ST_CHUYENMON " & strSQL & " order by CM_TEN asc")


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

    Public Function DeleteInfo(ByVal obj As Obj_ChuyenMon) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_CHUYENMON where CM_MA =N'" & Me.QuoteString(obj.MACHUYENMON)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_ChuyenMon) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_CHUYENMON (CM_MA,CM_TEN) values(N'", Me.QuoteString(obj.MACHUYENMON), "',N'", Me.QuoteString(obj.TENCHUYENMON)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function PhatSinhMa() As String
        Dim str As String
        Dim jchuyenmon As New Obj_ChuyenMon
        Dim num As Integer = 0
        Dim flag As Boolean = False
        Do While Not flag
            If (num < 10) Then
                str = ("CV0" & StringType.FromInteger(num))
            Else
                str = ("CV" & StringType.FromInteger(num))
            End If
            jchuyenmon.setnull()
            jchuyenmon.MACHUYENMON = str
            If (Me.LoadDS(jchuyenmon).Rows.Count > 0) Then
                num += 1
            Else
                flag = True
            End If
        Loop
        Return str
    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("''", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As Obj_ChuyenMon) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_CHUYENMON set CM_TEN=N'", Me.QuoteString(obj.TENCHUYENMON), "' where CM_MA=N'", Me.QuoteString(obj.MACHUYENMON)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
