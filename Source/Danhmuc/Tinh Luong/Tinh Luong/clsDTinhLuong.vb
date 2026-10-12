Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTinhLuong
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objTinhLuong) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_LUONG_ WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.NamThang) & "' "
        End If
        If obj.ChonBang = 2 Then
            strSQL = "DELETE IT_BANGLUONGMOI_ WHERE SOTHE ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.NamThang) & "' "
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objTinhLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))

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

    Public Function IsDeleteOK(ByVal obj As objTinhLuong) As Boolean

    End Function

    Public Function LoadDS(ByVal obj As objTinhLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 ORDER BY DV_MA ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            If obj.DonVi = "TCT" Then
                strSQL = " DECLARE @THANG char(7),"
                strSQL = strSQL + " @THANGSAU CHAR(7),"
                strSQL = strSQL + " @NGAYTHANGNAM CHAR(10),"
                strSQL = strSQL + " @DONVI NVARCHAR(50)"

                strSQL = strSQL + " SET @THANG = '" + obj.NamThang + "' "
                strSQL = strSQL + " SET @NGAYTHANGNAM = SUBSTRING(@THANG,4,4) + '-'+ SUBSTRING(@THANG,1,2) + '-01'"
                strSQL = strSQL + " SET @THANGSAU = SUBSTRING (CONVERT(CHAR(10),DATEADD(M,1,CONVERT (DATETIME,@NGAYTHANGNAM)),105),4,7)"

                strSQL = strSQL + "  SELECT NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3], "
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " ST_NHANVIEN.NV_TEN,"
                strSQL = strSQL + " ST_LUONG_.T_MA AS THANG,"
                strSQL = strSQL + " ST_LUONG_.L_LUONGCHINH AS MUCLUONG,"
                strSQL = strSQL + " ST_LUONG_.L_CONGHS1 AS HS1,"
                strSQL = strSQL + " ST_LUONG_.L_CONGHS15 AS HS15,"
                strSQL = strSQL + " ST_LUONG_.L_SOLANDITRE AS DITRE,"
                strSQL = strSQL + " ST_LUONG_.L_SOLANQUENQT AS QUENQUETTHE ,"
                strSQL = strSQL + " DONVI = CASE WHEN CDV_DONVICU IS NULL OR CDV_DONVICU = 'CNM' THEN ST_NHANVIEN.DV_MA ELSE CDV_DONVICU END "
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_LUONG_ ON ST_NHANVIEN.NV_MA = ST_LUONG_.NV_MA "
                strSQL = strSQL + " AND  ST_LUONG_.T_MA = @THANG"
                strSQL = strSQL + " LEFT JOIN ST_THANG ON @THANG  = ST_THANG.T_MA"
                strSQL = strSQL + " LEFT JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA = ST_CHUYENDONVI.NV_MA"
                strSQL = strSQL + " AND SUBSTRING(CONVERT(CHAR(10),NGAY,105),4,7) = @THANGSAU"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_NGAYVAO <= ST_THANG.T_DENNGAY"
                strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ORDER BY ST_NHANVIEN.NV_MA"
            Else

                strSQL = " DECLARE @THANG char(7),"
                strSQL = strSQL + " @THANGSAU CHAR(7),"
                strSQL = strSQL + " @NGAYTHANGNAM CHAR(10),"
                strSQL = strSQL + " @DONVI NVARCHAR(50)"

                strSQL = strSQL + " SET @THANG = '" + obj.NamThang + "' "
                strSQL = strSQL + " SET @NGAYTHANGNAM = SUBSTRING(@THANG,4,4) + '-'+ SUBSTRING(@THANG,1,2) + '-01'"
                strSQL = strSQL + " SET @THANGSAU = SUBSTRING (CONVERT(CHAR(10),DATEADD(M,1,CONVERT (DATETIME,@NGAYTHANGNAM)),105),4,7)"
                strSQL = strSQL + " SET @DONVI = '" + obj.DonVi + "'"

                strSQL = strSQL + "  SELECT NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3], "
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " ST_NHANVIEN.NV_TEN,"
                strSQL = strSQL + " ST_LUONG_.T_MA AS THANG,"
                strSQL = strSQL + " ST_LUONG_.L_LUONGCHINH AS MUCLUONG,"
                strSQL = strSQL + " ST_LUONG_.L_CONGHS1 AS HS1,"
                strSQL = strSQL + " ST_LUONG_.L_CONGHS15 AS HS15,"
                strSQL = strSQL + " ST_LUONG_.L_SOLANDITRE AS DITRE,"
                strSQL = strSQL + " ST_LUONG_.L_SOLANQUENQT AS QUENQUETTHE ,"
                strSQL = strSQL + " DONVI = CASE WHEN CDV_DONVICU IS NULL OR CDV_DONVICU = 'CNM' THEN ST_NHANVIEN.DV_MA ELSE CDV_DONVICU END "
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_LUONG_ ON ST_NHANVIEN.NV_MA = ST_LUONG_.NV_MA "
                strSQL = strSQL + " AND  ST_LUONG_.T_MA = @THANG"
                strSQL = strSQL + " LEFT JOIN ST_THANG ON @THANG  = ST_THANG.T_MA"
                strSQL = strSQL + " LEFT JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA = ST_CHUYENDONVI.NV_MA"
                strSQL = strSQL + " AND SUBSTRING(CONVERT(CHAR(10),NGAY,105),4,7) = @THANGSAU"
                strSQL = strSQL + " WHERE(ST_NHANVIEN.NV_NGAYVAO <= ST_THANG.T_DENNGAY)"
                strSQL = strSQL + " AND CASE WHEN CDV_DONVICU IS NULL OR CDV_DONVICU = 'CNM' THEN ST_NHANVIEN.DV_MA ELSE CDV_DONVICU END  = @DONVI"
                strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            strSQL = "SELECT * FROM ST_THANG ORDER BY T_MA"
        End If

        If obj.ChonBang = 9 Then
            strSQL = "SELECT * FROM ST_THANG WHERE T_MA = '" + obj.namthang + "' ORDER BY T_MA"
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

    Public Function PhatSinhMa() As String

    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As objTinhLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
