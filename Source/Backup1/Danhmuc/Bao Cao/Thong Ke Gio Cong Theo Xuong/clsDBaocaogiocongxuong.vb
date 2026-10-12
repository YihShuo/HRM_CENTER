Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDBaocaogiocongxuong
    Inherits DALSQL



    Public Function DeleteInfo(ByVal obj As objBaocaogiocongxuong) As Boolean
        'Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & Me.QuoteString(obj.CauTruyVan)) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objBaocaogiocongxuong) As Boolean
        'Dim flag As Boolean
        'Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        'strSQL = ((String.Concat(New String() {strSQL, Me.QuoteString(obj.CauTruyVan)}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'Try
        '    flag = Me.execSQL(strSQL)
        'Catch exception1 As Exception
        '    ProjectData.SetProjectError(exception1)
        '    Dim exception As Exception = exception1
        '    MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
        '    flag = False
        '    ProjectData.ClearProjectError()
        'End Try
        'Return flag
    End Function


    Public Function LoadDS(ByVal obj As objBaocaogiocongxuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where X_MA_ = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        'Cau truy van tren bang ngay
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT [NTN],[NGAY],[THANG],[NAM],[X_MA_],[SONGUOI],[SONGUOITHUCTE],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOCONG],[TONGGIOVUOTQUA],[SONGUOIVUOTQUA] FROM " & Me.QuoteString(obj.Table) & " ORDER BY NAM,THANG,NGAY ")
        End If
        'Cau truy van tren bang tuan
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT [TUAN],[NAM],[X_MA_],[SONGUOI],[SONGAYCHAMCONG],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOCONG],[TONGGIOVUOTQUA],[SONGUOIVUOTQUA] from " & Me.QuoteString(obj.Table) & " order by TUAN asc")
        End If
        'Cau truy van tren bang thang
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT [THANG],[NAM],[X_MA_],[SONGUOI],[SONGAYCHAMCONG],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOCONG],[TONGGIOVUOTQUA],[SONGUOIVUOTQUA] from " & Me.QuoteString(obj.Table) & " order by THANG asc")
        End If
        'Cau truy van tren bang nam
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT [NAM],[X_MA_],[SONGUOIDAUNAM],[SONGUOICUOINAM],[SONGAYCHAMCONG],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOCONG],[TONGGIOVUOTQUA],[SONGUOIVUOTQUA] from " & Me.QuoteString(obj.Table) & " order by NAM asc")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by thutu asc")
        End If

        'Thuc thi cau truy van
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
