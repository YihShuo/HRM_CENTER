Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ClsDReport
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objReport) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = (strSQL & " SELECT DV_MA , (DV_MA + ' -- ' + DV_TEN ) AS DV_TEN FROM ST_DONVI WHERE DV_LOCBB = 0 ORDER BY DV_MA, DV_TEN")
        End If

        If obj.ChonBang = 2 Then
            strSQL = (strSQL & " SELECT HV_MA , (HV_MA + ' -- ' + HV_TEN ) AS HV_TEN FROM ST_HOCVAN")
        End If

        If obj.ChonBang = 3 Then
            'strSQL = (strSQL & " SELECT DISTINCT X_MA_  FROM ST_DONVI WHERE X_MA_ NOT IN('BGD','CNM','DT','KB') AND DV_LOCBB = 0")
            strSQL = (strSQL & "SELECT X_MA_ FROM (SELECT  DISTINCT ST_NXUONG.THUTU,ST_NXUONG.X_MA_  FROM ST_DONVI INNER JOIN ST_NXUONG ON ST_DONVI.X_MA_ = ST_NXUONG.X_MA_")
            strSQL = strSQL + " WHERE ST_NXUONG.X_MA_ NOT IN('BGD','CNM','DT','KB') AND DV_LOCBB = 0"
            strSQL = strSQL + " UNION SELECT '1000' AS THUTU,'KHUA' AS X_MA_ UNION "
            strSQL = strSQL + " SELECT '1001' AS THUTU,'KHUB' AS X_MA_ ) AS K "
            strSQL = strSQL + " ORDER BY  THUTU,X_MA_"
        End If
        ''them de mo nam trong bang st_thang cho bao cao phep nam can bo cong nhan vien

        If obj.ChonBang = 4 Then
            strSQL = (strSQL & "SELECT DISTINCT RIGHT(T_MA,4) FROM ST_THANG ORDER BY RIGHT(T_MA,4) DESC ")
        End If
        If obj.ChonBang = 5 Then
            strSQL = (strSQL & "select a.x_ma_ from (select (case when X_MA_ = 'VP' then N'X_CL' when X_MA_ = 'R1' then N'R' else X_MA_ end) as x_ma_  from ST_DONVI where DV_TV <> 1 and DV_LocBB = 0 and X_MA_ not in ('A1A2','CNM','BGD','BP','BR1','BR2','BR3','GC','R2','R3') group by x_ma_ )a order by a.X_MA_ asc")
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
    ' Methods
    Public Function getPathReport(ByVal id As String) As String
        Dim str As String
        Dim strSQL As String = ("select * from SYS_BAOCAO where C_key=N'" & id & "'")
        Try
            str = StringType.FromObject(Me.getTableSQL(strSQL).Rows.Item(0).Item("Path"))
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            str = ""
            ProjectData.ClearProjectError()
        End Try
        Return str
    End Function
End Class

