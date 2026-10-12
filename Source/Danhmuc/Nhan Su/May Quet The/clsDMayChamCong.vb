Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDMayChamCong
    Inherits DALSQL

    ' Methods
    Public Function DeleteInfo(ByVal obj As objMayChamCong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM ST_MAYCHAMCONG WHERE SOMAY = N'" & Me.QuoteString(obj.SoMay)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objMayChamCong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO ST_MAYCHAMCONG (SOMAY,TENMAY,IP,GIAOTHUC,SOCONG,VITRI,TINHTRANGSUDUNG,GHICHU) VALUES(N'", Me.QuoteString(obj.SoMay), "',N'", Me.QuoteString(obj.TenMay), "',N'", Me.QuoteString(obj.IP), "',", obj.GiaoThuc, ",N'", Me.QuoteString(obj.SoCong), "',N'", Me.QuoteString(obj.ViTri), "',N'", Me.QuoteString(obj.TinhTrang), "',N'", Me.QuoteString(obj.GhiChu), "')"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function IsDeleteOK(ByVal obj As objMayChamCong) As Boolean
        Dim strSQL As String = ("SELECT * FROM ST_DONVI WHERE QT_SOMAY1 = N'" & Me.QuoteString(obj.SoMay) & "' OR QT_SOMAY2 = N'" & Me.QuoteString(obj.SoMay) & "' ")
        If (Me.getTableSQL(strSQL).Rows.Count > 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function LoadDS(ByVal obj As objMayChamCong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("select * from ST_MAYCHAMCONG ")
        End If

        If obj.ChonBang = 2 Then
            If (StringType.StrCmp(obj.SoMay, "", False) <> 0) Then
                strSQL = (strSQL & " where SOMAY = N'" & Me.QuoteString(obj.SoMay) & "'")
            End If
            strSQL = ("select * from ST_MAYCHAMCONG " & strSQL & "")
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

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As objMayChamCong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_MAYCHAMCONG   SET TENMAY = N'", Me.QuoteString(obj.TenMay), "',IP = N'", Me.QuoteString(obj.IP), "',GIAOTHUC =", Me.QuoteString(obj.GiaoThuc), ",SOCONG = N'", Me.QuoteString(obj.SoCong), "',VITRI = N'", Me.QuoteString(obj.ViTri), "',TINHTRANGSUDUNG = N'", Me.QuoteString(obj.TinhTrang), "',GHICHU = N'", Me.QuoteString(obj.GhiChu), "' WHERE SOMAY = N'", Me.QuoteString(obj.SoMay)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update LS_DAYOFF set DayOff_Name=N'", Me.QuoteString(obj.LyDoNghi), "',Paid_By=N'", Me.QuoteString(obj.NoiTraLuong), "',Percentage=", StringType.FromInteger(obj.MucLuong), ",Note=N'", Me.QuoteString(obj.GhiChu), "' where DayOff_ID=N'", Me.QuoteString(obj.ID)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

