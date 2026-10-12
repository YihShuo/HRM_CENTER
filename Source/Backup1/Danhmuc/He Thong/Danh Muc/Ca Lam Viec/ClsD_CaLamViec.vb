Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices


Public Class ClsD_CaLamViec
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As Obj_CaLamViec) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.MACA, "", False) <> 0) Then
            strSQL = (strSQL & " where CA_MA = N'" & Me.QuoteString(obj.MACA) & "'")
        End If
        strSQL = ("select *  from ST_CALAMVIEC" & strSQL)
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

    Public Function DeleteInfo(ByVal obj As Obj_CaLamViec) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM ST_CALAMVIEC WHERE CA_MA =N'" & Me.QuoteString(obj.MACA)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_CaLamViec) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_CALAMVIEC (CA_MA,CA_GIOBATDAU,CA_GIOKETTHUC,CA_GIOGIAILAO, CA_SOPHUTGIAILAO, SHIFT) values(N'", Me.QuoteString(obj.MACA), "',N'", Me.QuoteString(obj.GIOBATDAU), "',N'", Me.QuoteString(obj.GIOKETTHUC), "',N'", Me.QuoteString(obj.GIOGIAILAO), "',N'", Me.QuoteString(obj.PHUTGIAILAO), "',N'", Me.QuoteString(obj.SHIFT)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
        Dim jcalamviec As New Obj_CaLamViec
        Dim num As Integer = 0
        Dim flag As Boolean = False
        Do While Not flag
            If (num < 10) Then
                str = ("CV0" & StringType.FromInteger(num))
            Else
                str = ("CV" & StringType.FromInteger(num))
            End If
            jcalamviec.setnull()
            jcalamviec.MACA = str
            If (Me.LoadDS(jcalamviec).Rows.Count > 0) Then
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

    Public Function UpdateInfo(ByVal obj As Obj_CaLamViec) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_CALAMVIEC set CA_GIOBATDAU=N'", Me.QuoteString(obj.GIOBATDAU), "',CA_GIOKETTHUC=N'", Me.QuoteString(obj.GIOKETTHUC), "',CA_GIOGIAILAO=N'", Me.QuoteString(obj.GIOGIAILAO), "',CA_SOPHUTGIAILAO=N'", Me.QuoteString(obj.PHUTGIAILAO), "',SHIFT=N'", Me.QuoteString(obj.SHIFT), "' where CA_MA=N'", Me.QuoteString(obj.MACA)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
