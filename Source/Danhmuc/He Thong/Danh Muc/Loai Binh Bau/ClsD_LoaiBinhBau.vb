Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Public Class ClsD_LoaiBinhBau
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As Obj_LoaiBinhBau) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.MALOAIBINHBAU, "", False) <> 0) Then
            strSQL = (strSQL & " where BB_MA = N'" & Me.QuoteString(obj.MALOAIBINHBAU) & "'")
        End If
        strSQL = (" select *  from ST_BINHBAU" & strSQL)
        'strSQL = ("select *  from ST_BINHBAU" & strSQL & " order by BB_HESO asc")

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

    Public Function DeleteInfo(ByVal obj As Obj_LoaiBinhBau) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_BINHBAU where BB_MA =N'" & Me.QuoteString(obj.MALOAIBINHBAU)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_LoaiBinhBau) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_BINHBAU (BB_MA,BB_HESO,BB_GHICHU) values(N'", Me.QuoteString(obj.MALOAIBINHBAU), "',N'", Me.QuoteString(obj.SOTIEN), "',N'", Me.QuoteString(obj.GHICHU)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
        Dim jloaibinhbau As New Obj_LoaiBinhBau
        Dim num As Integer = 0
        Dim flag As Boolean = False
        Do While Not flag
            If (num < 10) Then
                str = ("CV0" & StringType.FromInteger(num))
            Else
                str = ("CV" & StringType.FromInteger(num))
            End If
            jloaibinhbau.setnull()
            jloaibinhbau.MALOAIBINHBAU = str
            If (Me.LoadDS(jloaibinhbau).Rows.Count > 0) Then
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

    Public Function UpdateInfo(ByVal obj As Obj_LoaiBinhBau) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_BINHBAU set BB_HESO = N'", Me.QuoteString(obj.SOTIEN), "',BB_GHICHU = N'", Me.QuoteString(obj.GHICHU), "' where BB_MA=N'", Me.QuoteString(obj.MALOAIBINHBAU)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
