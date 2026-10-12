Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDNguyenNhanKyLuat
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As ObjNguyenNhanKyLuat) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'If (StringType.StrCmp(obj.MANNKYLUAT, "", False) <> 0) Then
        '    strSQL = (strSQL & " where NNKL_MA = N'" & Me.QuoteString(obj.MANNKYLUAT) & "'")
        'End If
        'strSQL = ("select *  from ST_NGUYENNHANKYLUAT" & strSQL & " order by NNKL_TEN asc")

        If obj.ChonBang = 1 Then
            strSQL = ("select *  from ST_NGUYENNHANKYLUAT order by NNKL_TEN asc ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("select *  from ST_NGUYENNHANKYLUAT where NNKL_MA = N'" & Me.QuoteString(obj.MANNKYLUAT) & "' order by NNKL_TEN asc ")
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

    Public Function DeleteInfo(ByVal obj As ObjNguyenNhanKyLuat) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_NGUYENNHANKYLUAT where NNKL_MA =N'" & Me.QuoteString(obj.MANNKYLUAT)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            'MessageBox.Show(exception.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function InsertInfo(ByVal obj As ObjNguyenNhanKyLuat) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_NGUYENNHANKYLUAT (NNKL_MA,NNKL_TEN,NNKL_GHICHU) values(N'", Me.QuoteString(obj.MANNKYLUAT), "',N'", Me.QuoteString(obj.TENNNKYLUAT), "',N'", Me.QuoteString(obj.GHICHUNNKYLUAT)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
        Dim jkyluat As New ObjNguyenNhanKyLuat
        Dim num As Integer = 0
        Dim flag As Boolean = False
        Do While Not flag
            If (num < 10) Then
                str = ("CV0" & StringType.FromInteger(num))
            Else
                str = ("CV" & StringType.FromInteger(num))
            End If
            jkyluat.setnull()
            jkyluat.MANNKYLUAT = str
            If (Me.LoadDS(jkyluat).Rows.Count > 0) Then
                num += 1
            Else
                flag = True
            End If
        Loop
        Return str
    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As ObjNguyenNhanKyLuat) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NGUYENNHANKYLUAT set NNKL_TEN=N'", Me.QuoteString(obj.TENNNKYLUAT), "', NNKL_GHICHU = N'", Me.QuoteString(obj.GHICHUNNKYLUAT), "' WHERE NNKL_MA=N'", Me.QuoteString(obj.MANNKYLUAT)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
