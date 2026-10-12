Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDBaocaochitietgiocong
    Inherits DALSQL



    Public Function DeleteInfo(ByVal obj As objBaocaochitietgiocong) As Boolean
        '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)        
        '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & Me.QuoteString(obj.CauTruyVan)) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '    Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objBaocaochitietgiocong) As Boolean
        '    Dim flag As Boolean
        '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        '    strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        '    strSQL = ((String.Concat(New String() {strSQL, Me.QuoteString(obj.CauTruyVan)}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '    Try
        '        flag = Me.execSQL(strSQL)
        '    Catch exception1 As Exception
        '        ProjectData.SetProjectError(exception1)
        '        Dim exception As Exception = exception1
        '        MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
        '        flag = False
        '        ProjectData.ClearProjectError()
        '    End Try
        '    Return flag
    End Function

    Public Function LoadDS(ByVal obj As objBaocaochitietgiocong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where X_MA_ = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        'Cau truy van tren bang ngay
        If obj.ChonBang = 1 Then
            strSQL = ("select [X_MA_],[NV_TEN],[NV_MA],[DV_MA],[NGAY],[THANG],[NAM],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOVUOTQUA], TONGGIOCONG = GIOCONGTANGCA + GIOCONGCHINH from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by X_MA_ asc")
        End If
        'Cau truy van tren bang tuan
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT [NAM],[TUAN],[X_MA_],[DV_MA],[NV_MA],[NV_TEN],[SONGAY],[GIOCONGCHINH],[GIOCONGTANGCA],[TONGGIOVUOTQUA],[GHICHU], TONGGIOCONG = GIOCONGTANGCA + GIOCONGCHINH from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by X_MA_ asc")
        End If
        'Cau truy van tren bang thang
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT [NAM],[THANG],[X_MA_],[N_MA],[DV_MA],[NV_TEN],[NV_MA],[SO_NGAY],[SO_NGAY_THUC_TE],[GIO_BINH_THUONG],[GIO_TANG_CA],[GIO_CONG_KHAC_THUONG],[SO_NGAY_KHAC_THUONG],[GHICHU],TONGGIOCONG = GIO_TANG_CA + GIO_BINH_THUONG from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by X_MA_ asc")
        End If
        'Cau truy van tren bang nam
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT [NAM],[X_MA_],[DV_MA],[NV_TEN],[NV_MA],[THANG1],[THANG2],[THANG3],[THANG4],[THANG5],[THANG6],[THANG7],[THANG8],[THANG9],[THANG10],[THANG11],[THANG12],[TONG],[TONGGIOVUOTQUA] from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by X_MA_ asc")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by THUTU asc")
        End If

        If obj.ChonBang = 6 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " ")
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
