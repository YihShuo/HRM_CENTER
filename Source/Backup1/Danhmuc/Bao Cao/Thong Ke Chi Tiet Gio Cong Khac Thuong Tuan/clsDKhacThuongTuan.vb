Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDKhacThuongTuan
    Inherits DALSQL
    ' Methods
    'Public Function DeleteInfo(ByVal obj As objNgayNghi) As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from LS_DAYOFF where DayOff_ID=N'" & Me.QuoteString(obj.ID)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Return Me.execSQL(strSQL)
    'End Function

    'Public Function InsertInfo(ByVal obj As objNgayNghi) As Boolean
    '    Dim flag As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
    '    strSQL = ((String.Concat(New String() {strSQL, "insert into LS_DAYOFF(DayOff_ID,DayOff_Name,Paid_By,Percentage,Using,Ordinal,Note) values(N'", Me.QuoteString(obj.ID), "',N'", Me.QuoteString(obj.LyDoNghi), "',N'", Me.QuoteString(obj.NoiTraLuong), "',", StringType.FromInteger(obj.MucLuong), ",0,0,N'", Me.QuoteString(obj.GhiChu)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    'End Function

    'Public Function IsDeleteOK(ByVal obj As objNgayNghi) As Boolean
    '    Dim strSQL As String = ("select * from PR_DayOff where DayOff_ID=N'" & Me.QuoteString(obj.ID) & "'")
    '    If (Me.getTableSQL(strSQL).Rows.Count > 0) Then
    '        Return False
    '    End If
    '    Return True
    'End Function

    Public Function LoadDS(ByVal obj As objKhacThuongTuan) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & " where DayOff_ID = N'" & Me.QuoteString(obj.ID) & "'")
        End If
        strSQL = ("SELECT [TUAN],[NAM],JELL_DONVI.[DV_MA],ST_NHANVIEN.[NV_MA],[CA_MA],[SO_NGAY],[GIOCONGCHINH],[GIOTANGCATUAN],[TONGGIOCONG],[GIOCONGVUOTQUA] FROM JELL_CHITIET_GIOCONGKHACTHUONGTUAN_GTT_TABLE inner join ST_NHANVIEN ON (JELL_CHITIET_GIOCONGKHACTHUONGTUAN_GTT_TABLE.NV_MA = ST_NHANVIEN.NV_MA) INNER JOIN JELL_DONVI ON (ST_NHANVIEN.DV_MA = JELL_DONVI.DV_MA) WHERE JELL_CHITIET_GIOCONGKHACTHUONGTUAN_GTT_TABLE.NAM = 2010 ORDER BY TUAN ")
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

    'Public Function PhatSinhMa() As String
    '    Dim str As String
    '    Dim nghi As New objNgayNghi
    '    Dim num As Integer = 0
    '    Dim flag As Boolean = False
    '    Do While Not flag
    '        If (num < 10) Then
    '            str = ("NN0" & StringType.FromInteger(num))
    '        Else
    '            str = ("NN" & StringType.FromInteger(num))
    '        End If
    '        nghi.Setnull()
    '        nghi.ID = str
    '        If (Me.LoadDS(nghi).Rows.Count > 0) Then
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

    'Public Function UpdateInfo(ByVal obj As objNgayNghi) As Boolean
    '    Dim flag As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update LS_DAYOFF set DayOff_Name=N'", Me.QuoteString(obj.LyDoNghi), "',Paid_By=N'", Me.QuoteString(obj.NoiTraLuong), "',Percentage=", StringType.FromInteger(obj.MucLuong), ",Note=N'", Me.QuoteString(obj.GhiChu), "' where DayOff_ID=N'", Me.QuoteString(obj.ID)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Try
    '        flag = Me.execSQL(strSQL)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        MessageBox.Show(exception.Message)
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function

End Class

