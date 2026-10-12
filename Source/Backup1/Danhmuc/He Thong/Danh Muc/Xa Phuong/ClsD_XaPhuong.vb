Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class ClsD_XaPhuong
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As Obj_XaPhuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("select *  from ST_XAPHUONG ")
            strSQL = strSQL + " where TT_MA = N'" & Me.QuoteString(obj.MATINHTHANH) & "'"
            strSQL = strSQL + " AND QH_MA=N'" & Me.QuoteString(obj.MAQUANHUYEN) & "' order by qh_ma,XP_Ma ,XP_TEN asc"
        End If
        ''=======cbo tinh thanh ========
        If obj.ChonBang = 2 Then
            strSQL = ("select TT_MA,TT_TEN  from ST_TINHTHANH WHERE TT_MA <> ''" & strSQL & " order by TT_TEN asc")
        End If

        ''=======cbo quan huyen ========
        If obj.ChonBang = 3 Then
            strSQL = ("select QH_MA,QH_TEN  from ST_QUANHUYEN WHERE QH_MA <> ''" & strSQL & " order by QH_TEN asc")
        End If
        ''=======cbo quan huyen theo tinh thanh ========
        If obj.ChonBang = 4 Then
            strSQL = ("select *  from ST_QUANHUYEN WHERE QH_MA <> '' AND TT_MA = N'" & Me.QuoteString(obj.MATINHTHANH) & strSQL & "' order by QH_TEN asc")
        End If
        ''======= tim quan huyen theo xã phường ==========''
        If obj.ChonBang = 5 Then
            strSQL = ("select *  from ST_TINHTHANH WHERE XP_MA = N'" & Me.QuoteString(obj.MAXAPHUONG) & strSQL & "' order by QH_TEN asc")
        End If
        ''======= Tim xa phuong theo ma xa phuong, ma quan huyen(them moi) =========
        If obj.ChonBang = 6 Then
            strSQL = "SELECT ST_XAPHUONG.XP_MA,ST_XAPHUONG.XP_TEN,QH_TEN,TT_Ten,ST_XAPHUONG.QH_MA, ST_TINHTHANH.TT_Ma,ST_XAPHUONG.XP_GHICHU FROM ST_XAPHUONG INNER JOIN ST_QUANHUYEN ON (ST_QUANHUYEN.QH_MA = ST_XAPHUONG.QH_MA  AND ST_QUANHUYEN.TT_MA = ST_XAPHUONG.TT_MA ) INNER JOIN ST_TINHTHANH ON ST_TINHTHANH.TT_Ma = ST_QUANHUYEN.TT_MA "
            strSQL = strSQL + " WHERE XP_MA ='" & Me.QuoteString(obj.MAXAPHUONG) & "'"
            strSQL = strSQL + " AND ST_TINHTHANH.TT_Ma ='" & Me.QuoteString(obj.MATINHTHANH) & "'"
            strSQL = strSQL + " AND ST_QUANHUYEN.QH_MA ='" & Me.QuoteString(obj.MAQUANHUYEN) & "'"
        End If
        ''========== Neu dang su dung khong duoc xoa du lieu phuong xa ==========''
        If obj.ChonBang = 7 Then
            strSQL = "SELECT TOP 1 NV_XaPhuongDC,NV_XaPhuongQQ,NV_MA,XP_Ma ,XP_Ten  FROM ST_NHANVIEN INNER JOIN  ST_XAPHUONG ON (NV_XaPhuongDC = ST_XAPHUONG.XP_Ma OR NV_XaPhuongQQ = ST_XAPHUONG.XP_Ma)"
            strSQL = strSQL + " WHERE XP_MA ='" & Me.QuoteString(obj.MAXAPHUONG) & "'"
        End If
        ''=========== tim ID max =========
        If obj.ChonBang = 8 Then
            strSQL = "SELECT  XP_MA=isnull(convert(char(100),MAX(CONVERT(INT,XP_MA))+1),0) FROM ST_XAPHUONG "
            strSQL = strSQL + " WHERE TT_Ma ='" & Me.QuoteString(obj.MATINHTHANH) & "'"
            strSQL = strSQL + " AND QH_MA ='" & Me.QuoteString(obj.MAQUANHUYEN) & "'"
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

    Public Function DeleteInfo(ByVal obj As Obj_XaPhuong) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_XAPHUONG where XP_MA =N'" & Me.QuoteString(obj.MAXAPHUONG)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As Obj_XaPhuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_XAPHUONG (XP_MA,QH_MA,TT_MA,XP_TEN,XP_GHICHU) values(N'", Me.QuoteString(obj.MAXAPHUONG), "',N'", Me.QuoteString(obj.MAQUANHUYEN), "',N'", Me.QuoteString(obj.MATINHTHANH), "',N'", Me.QuoteString(obj.TENXAPHUONG), "',N'", Me.QuoteString(obj.GHICHU)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function UpdateInfo(ByVal obj As Obj_XaPhuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_XAPHUONG set XP_TEN=N'", Me.QuoteString(obj.TENXAPHUONG), "',XP_GHICHU=N'", Me.QuoteString(obj.GHICHU), "' where XP_MA=N'", Me.QuoteString(obj.MAXAPHUONG), "' AND QH_MA=N'", Me.QuoteString(obj.MAQUANHUYEN), "' AND TT_MA=N'", Me.QuoteString(obj.MATINHTHANH)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
