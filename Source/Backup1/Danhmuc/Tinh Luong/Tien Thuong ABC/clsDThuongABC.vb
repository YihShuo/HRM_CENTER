Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDThuongABC
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objThuongABC) As DataTable
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
                strSQL = strSQL + " ST_TAMUNG.T_MA,"
                strSQL = strSQL + " BB_TRUOC,"
                strSQL = strSQL + " HD_LUONGCB,"
                strSQL = strSQL + " TU_THUONGABC"
                strSQL = strSQL + " FROM ST_TAMUNG INNER JOIN ST_HOPDONGLAODONG ON ST_TAMUNG.NV_MA = ST_HOPDONGLAODONG.NV_MA"
                strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_TAMUNG.NV_MA = ST_NHANVIEN.NV_MA"
                strSQL = strSQL + " LEFT JOIN ST_BINHBAUTHANG ON ST_TAMUNG.NV_MA = ST_BINHBAUTHANG.NV_MA"
                strSQL = strSQL + " AND ST_TAMUNG.T_MA = ST_BINHBAUTHANG.T_MA"
                strSQL = strSQL + " AND ST_TAMUNG.T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
            Else
                strSQL = "  SELECT NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " ST_TAMUNG.T_MA,"
                strSQL = strSQL + " BB_TRUOC,"
                strSQL = strSQL + " HD_LUONGCB,"
                strSQL = strSQL + " TU_THUONGABC"
                strSQL = strSQL + " FROM ST_TAMUNG INNER JOIN ST_HOPDONGLAODONG ON ST_TAMUNG.NV_MA = ST_HOPDONGLAODONG.NV_MA"
                strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON ST_TAMUNG.NV_MA = ST_NHANVIEN.NV_MA"
                strSQL = strSQL + " INNER JOIN ST_BINHBAUTHANG ON ST_TAMUNG.NV_MA = ST_BINHBAUTHANG.NV_MA"
                strSQL = strSQL + " AND ST_TAMUNG.T_MA = ST_BINHBAUTHANG.T_MA"
                strSQL = strSQL + " AND ST_TAMUNG.T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DonVi + "'"
                strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            strSQL = "SELECT * FROM ST_THANG ORDER BY T_MA"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM ST_TAMUNG WHERE NV_MA = '" + obj.NV_MA + "' AND T_MA = '" + obj.NamThang + "'"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "SELECT NV_MA, L_LOAI FROM ST_LUONG WHERE NV_MA = '" + obj.NV_MA + "' AND T_MA = '" + obj.NamThang + "'"
        End If

        If obj.ChonBang = 4 Then

            If obj.DonVi = "TCT" Then
                strSQL = "SELECT * FROM ST_NHANVIEN WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            Else
                strSQL = "SELECT * FROM ST_NHANVIEN WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND DV_MA = '" + obj.DonVi + "'"
            End If
        End If
        If obj.ChonBang = 6 Then
            strSQL = "DECLARE @THANGNAY AS CHAR(7)"
            strSQL = strSQL + " SET @THANGNAY='" + obj.NamThang + "'"
            strSQL = strSQL + " SELECT THANGTRUOC=SUBSTRING (CONVERT(CHAR(10),DATEADD(M,-1,CONVERT (DATETIME,SUBSTRING(@THANGNAY,4,4) + '-'+ SUBSTRING(@THANGNAY,1,2) + '-01')),105),4,7)"
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

    Public Function UpdateInfo(ByVal obj As objThuongABC) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_TAMUNG  SET NGUOICAPNHAT= N'" & Me.QuoteString(obj.NGUOICN) & "',NGAYCAPNHAT=N'" & Me.QuoteString(obj.NGAYCN) & "',TU_THUONGABC = " & Me.QuoteString(obj.SoTien) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
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

    Public Function DeleteInfo(ByVal obj As objThuongABC) As Boolean
        Dim strSQL, strSQLThaoTac As String
        Dim flag As Boolean
        strSQL = "DELETE ST_TAMUNG WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.NamThang) & "' "

        strSQLThaoTac = "DELETE ST_TAMUNG WHERE NV_MA =''" & Me.QuoteString(obj.NV_MA) & "''AND T_MA = ''" & Me.QuoteString(obj.NamThang) & "'' "

        Dim strSQL1 As String
        strSQL1 = ("INSERT INTO jell_TacDong([ThoiDiem] ,[HanhDong],[Ten_DangNhap]) values(N'" & Me.QuoteString(obj.NGAYCN) & "',N'" & strSQLThaoTac & "',N'" & Me.QuoteString(obj.NGUOICN) & "')")
        flag = Me.execSQL(strSQL1)

        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objThuongABC) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = ("INSERT INTO ST_KHOANCONGKHAC([NV_MA],[T_MA],[SOTIEN]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NamThang) & "'," & Me.QuoteString(obj.SoTien) & ")")
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
