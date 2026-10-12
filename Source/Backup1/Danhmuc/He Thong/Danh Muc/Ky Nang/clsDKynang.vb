Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDKynang
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objKynang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.MAKYNANG, "", False) <> 0) Then
            strSQL = (strSQL & " where KN_MA = N'" & Me.QuoteString(obj.MAKYNANG) & "'")
        End If
        strSQL = ("select *  from IT_KYNANG" & strSQL & " order by KN_TEN asc")

        If obj.ChonBang = 1 Then
            strSQL = " SELECT MAHS FROM IT_TIEUCHISANLOC WHERE KN_MA=N'" & obj.MAKYNANG & "'"
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

    Public Function DeleteInfo(ByVal obj As objKynang) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from IT_KYNANG where KN_MA =N'" & Me.QuoteString(obj.MAKYNANG)) & "' AND KN_MA <> N''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objKynang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into IT_KYNANG (KN_MA,KN_TEN,KN_GHICHU) values(N'", Me.QuoteString(obj.MAKYNANG), "',N'", Me.QuoteString(obj.TENKYNANG) & "' ,N'", Me.QuoteString(obj.GHICHU)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    'Public Function PhatSinhMa() As String
    '    Dim str As String
    '    Dim jkhenthuong As New Obj_KhenThuongDM
    '    Dim num As Integer = 0
    '    Dim flag As Boolean = False
    '    Do While Not flag
    '        If (num < 10) Then
    '            str = ("CV0" & StringType.FromInteger(num))
    '        Else
    '            str = ("CV" & StringType.FromInteger(num))
    '        End If
    '        jkhenthuong.setnull()
    '        jkhenthuong.MAKHENTHUONG = str
    '        If (Me.LoadDS(jkhenthuong).Rows.Count > 0) Then
    '            num += 1
    '        Else
    '            flag = True
    '        End If
    '    Loop
    '    Return str
    'End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As objKynang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update IT_KYNANG set KN_TEN=N'", Me.QuoteString(obj.TENKYNANG), "',KN_GHICHU=N'", Me.QuoteString(obj.GHICHU) & "' where KN_MA=N'", Me.QuoteString(obj.MAKYNANG)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
