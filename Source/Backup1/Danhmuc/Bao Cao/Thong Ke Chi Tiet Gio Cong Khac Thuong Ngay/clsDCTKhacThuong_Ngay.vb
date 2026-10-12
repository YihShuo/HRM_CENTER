Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDCTKhacThuong_Ngay
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

    Public Function LoadDS(ByVal obj As objCTKhacThuong_Ngay) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " where X_MA_ = N'" & Me.QuoteString(obj.IDNgay) & "'")
            End If
            strSQL = ("select * from ST_NXUONG" & strSQL & " order by THUTU")
        End If

        If obj.ChonBang = 2 Then
            strSQL = " SELECT "
            strSQL += " JELL_CHITIET_GIOCONGTANGCA_NGAY.NGAY,"
            strSQL += " JELL_CHITIET_GIOCONGTANGCA_NGAY.DV_MA, "
            strSQL += " JELL_CHITIET_GIOCONGTANGCA_NGAY.NV_MA,"
            strSQL += " JELL_CHITIET_GIOCONGTANGCA_NGAY.GC_TANGCA, "
            strSQL += " 8 AS GIOCONGCHINH, "
            strSQL += " 8 +JELL_CHITIET_GIOCONGTANGCA_NGAY.GC_TANGCA AS TONGGIOCONG, "
            strSQL += " JELL_CHITIET_GIOCONGTANGCA_NGAY.GC_TANGCA - 4 AS TONGGIOVUOTQUA,"
            strSQL += " ST_GIOQUETTHE.CA_MA,"
            strSQL += " CONVERT(CHAR(10),JELL_CHITIET_GIOCONGTANGCA_NGAY.NGAY,21) AS NGAYC"
            strSQL += " FROM JELL_CHITIET_GIOCONGTANGCA_NGAY INNER JOIN ST_GIOQUETTHE "
            strSQL += " ON (JELL_CHITIET_GIOCONGTANGCA_NGAY.NV_MA =ST_GIOQUETTHE.NV_MA "
            strSQL += " AND JELL_CHITIET_GIOCONGTANGCA_NGAY.NGAY =ST_GIOQUETTHE.QT_NGAY)"
            strSQL += " WHERE JELL_CHITIET_GIOCONGTANGCA_NGAY.GC_TANGCA > 4"
            strSQL += " AND YEAR(JELL_CHITIET_GIOCONGTANGCA_NGAY.NGAY) = 2010"
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

