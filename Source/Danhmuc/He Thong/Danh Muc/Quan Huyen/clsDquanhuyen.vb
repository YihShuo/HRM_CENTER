Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDquanhuyen
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objquanhuyen) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 5 Then
            strSQL = ("select TT_MA,QH_MA,QH_TEN,QH_LOAI,QH_TENLOAI  from ST_QUANHUYEN ")
            strSQL = strSQL + " where TT_MA = N'" & Me.QuoteString(obj.MATINHTHANH) & "' order by qh_ma,QH_TEN asc"
        End If
        ''=======cbo tinh thanh ========
        If obj.ChonBang = 1 Then
            strSQL = ("select TT_MA,TT_TEN  from ST_TINHTHANH WHERE TT_MA <> '' order by TT_TEN asc")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("select TOP 1 (CONVERT(INT,QH_MA)+1) AS QH_MA from ST_QUANHUYEN WHERE TT_MA = '" & obj.MATINHTHANH & "' order by QH_MA DESC")
        End If

        ''=======cbo quan huyen ========
        If obj.ChonBang = 3 Then
            strSQL = ("select distinct QH_LOAI from ST_QUANHUYEN WHERE QH_MA <> '' AND QH_LOAI IS NOT NULL")
        End If
        ''=======cbo quan huyen theo tinh thanh ========
        If obj.ChonBang = 4 Then
            strSQL = ("select *  from ST_QUANHUYEN WHERE QH_MA <> '' AND TT_MA = N'" & Me.QuoteString(obj.MATINHTHANH) & strSQL & "' order by QH_TEN asc")
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

    'Public Function DeleteInfo(ByVal obj As objquanhuyen) As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_XAPHUONG where XP_MA =N'" & Me.QuoteString(obj.MAXAPHUONG)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Return Me.execSQL(strSQL)
    'End Function

    Public Function InsertInfo(ByVal obj As objquanhuyen) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_QUANHUYEN (TT_MA,QH_MA,QH_TEN,QH_LOAI,QH_TENLOAI) values(N'", Me.QuoteString(obj.MATINHTHANH), "',N'", Me.QuoteString(obj.MAQUANHUYEN), "',N'", Me.QuoteString(obj.TENQUANHUYEN), "',N'", Me.QuoteString(obj.LOAIQUANHUYEN), "',N'", Me.QuoteString(obj.GHICHU)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As objquanhuyen) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_QUANHUYEN set QH_TEN=N'", Me.QuoteString(obj.TENQUANHUYEN), "',QH_TENLOAI=N'", Me.QuoteString(obj.GHICHU), "',QH_LOAI=N'", Me.QuoteString(obj.LOAIQUANHUYEN), "' where QH_MA=N'", Me.QuoteString(obj.MAQUANHUYEN), "' AND TT_MA=N'", Me.QuoteString(obj.MATINHTHANH)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
