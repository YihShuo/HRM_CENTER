Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDPhuCapKhac
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objPhuCapKhac) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' AND DV_LOCBB = 0 ORDER BY DV_MA ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            If obj.DonVi = "TCT" Then
                strSQL = " SELECT NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " T_MA,"
                strSQL = strSQL + " ST_NHANVIENPHUCAP.LPC_MA,"
                strSQL = strSQL + " LPC_TEN,"
                strSQL = strSQL + " PC_SOTIEN"
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_NHANVIENPHUCAP ON ST_NHANVIEN.NV_MA = ST_NHANVIENPHUCAP.NV_MA AND T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " LEFT JOIN ST_LOAIPHUCAP ON ST_NHANVIENPHUCAP.LPC_MA = ST_LOAIPHUCAP.LPC_MA"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC )"
                strSQL = strSQL + " AND  ST_DONVI.DV_TV <>1"
                strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
            Else
                strSQL = " SELECT NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " T_MA,"
                strSQL = strSQL + " ST_NHANVIENPHUCAP.LPC_MA,"
                strSQL = strSQL + " LPC_TEN,"
                strSQL = strSQL + " PC_SOTIEN"
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_NHANVIENPHUCAP ON ST_NHANVIEN.NV_MA = ST_NHANVIENPHUCAP.NV_MA AND T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " LEFT JOIN ST_LOAIPHUCAP ON ST_NHANVIENPHUCAP.LPC_MA = ST_LOAIPHUCAP.LPC_MA"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC )"
                strSQL = strSQL + " AND  ST_DONVI.DV_TV <>1"
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DonVi + "'"
                strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            'strSQL = "SELECT * FROM ST_THANG WHERE YEAR(T_DENNGAY) = YEAR(GETDATE()) ORDER BY T_MA"
            strSQL = " SELECT THANGTRUOC=SUBSTRING (CONVERT(CHAR(10),DATEADD(M,-1,CONVERT (DATETIME,SUBSTRING('" + obj.NamThang + "',4,4) + '-'+ SUBSTRING('" + obj.NamThang + "',1,2) + '-01')),105),4,7),"
            strSQL = strSQL + " T_MA"
            strSQL = strSQL + " FROM ST_THANG"
            strSQL = strSQL + " WHERE YEAR(T_DENNGAY) = YEAR(GETDATE()) AND T_MA = '" + obj.NamThang + "'"
            strSQL = strSQL + " ORDER BY T_MA"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM ST_NHANVIENPHUCAP WHERE NV_MA = '" + obj.NV_MA + "' AND T_MA = '" + obj.NamThang + "' AND LPC_MA = '" + obj.LoaiPC + "'"
        End If

        If obj.ChonBang = 4 Then
            strSQL = "DECLARE @THANGNAY AS CHAR(7)"
            strSQL = strSQL + " SET @THANGNAY='" + obj.NamThang + "'"
            strSQL = strSQL + " SELECT THANGTRUOC=SUBSTRING (CONVERT(CHAR(10),DATEADD(M,-1,CONVERT (DATETIME,SUBSTRING(@THANGNAY,4,4) + '-'+ SUBSTRING(@THANGNAY,1,2) + '-01')),105),4,7)"
        End If
        If obj.ChonBang = 5 Then
            strSQL = "SELECT * FROM ST_NHANVIENPHUCAP WHERE T_MA = '" + obj.NamThang + "' AND LPC_MA = 'PCKH'"
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

    Public Function UpdateInfo(ByVal obj As objPhuCapKhac) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_NHANVIENPHUCAP  SET PC_SOTIEN = " & Me.QuoteString(obj.SoTien) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND T_MA =  '" & Me.QuoteString(obj.NamThang) & "'AND LPC_MA =  '" & Me.QuoteString(obj.LoaiPC) & "'"
        End If
        If obj.ChonBang = 2 Then
            'strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [CC_SUATAN] = " + obj.ChamCom + " WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
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

    Public Function DeleteInfo(ByVal obj As objPhuCapKhac) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_NHANVIENPHUCAP WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.NamThang) & "'  AND LPC_Ma='PCKH'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "DELETE ST_NHANVIENPHUCAP  WHERE T_Ma= '" & Me.QuoteString(obj.NamThang) & "' AND LPC_Ma='PCKH'"
        End If

        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objPhuCapKhac) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO ST_NHANVIENPHUCAP([NV_MA],[LPC_MA],[T_MA],[PC_SOTIEN]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.LoaiPC) & "',N'" & Me.QuoteString(obj.NamThang) & "'," & Me.QuoteString(obj.SoTien) & ")")
        End If

        If obj.ChonBang = 2 Then
            strSQL = "INSERT INTO ST_NHANVIENPHUCAP "
            strSQL = strSQL + " ("
            strSQL = strSQL + " NV_Ma,"
            strSQL = strSQL + " LPC_Ma,"
            strSQL = strSQL + " T_Ma,"
            strSQL = strSQL + " PC_Sotien"
            strSQL = strSQL + " )"
            strSQL = strSQL + " SELECT "
            strSQL = strSQL + " NV_Ma,"
            strSQL = strSQL + " 'PCKH',"
            strSQL = strSQL + " '" & Me.QuoteString(obj.NamThang) & "',"
            strSQL = strSQL + " PC_Sotien"
            strSQL = strSQL + " FROM ST_NHANVIENPHUCAP"
            strSQL = strSQL + " WHERE T_Ma = '" & Me.QuoteString(obj.Thang_T) & "'"
            strSQL = strSQL + " AND LPC_Ma='PCKH'"
        End If
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
End Class
