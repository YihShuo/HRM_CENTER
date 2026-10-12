Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThoiViecKhongThamGiaBHTN
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objThoiViecKhongThamGiaBHTN) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA,NV_TEN,NV_NGAYVAO = CONVERT(CHAR(11),NV_Ngayvao, 103) , NV_NGAYKYHD = CONVERT(CHAR(11),ST_HOPDONGLAODONG.HD_NgayKy , 103)FROM ST_NHANVIEN LEFT JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_Ma = ST_HOPDONGLAODONG.NV_Ma  WHERE ST_NHANVIEN.NV_MA = '" & obj.MANV & "'"
        End If

        'Bỏ do Tỷ Thạc Thành Lập Từ 1-9-2014
        ''If obj.ChonBang = 2 Then
        ''    strSQL = " SELECT ST_NHANVIEN.NV_Ma, "
        ''    strSQL = strSQL + " ST_NHANVIEN .NV_Ten ,"
        ''    strSQL = strSQL + " ST_NHANVIEN.NV_Ngayvao ,"
        ''    strSQL = strSQL + " IT_TROCAPTHOIVIEC.NAMTRUOC2008,"
        ''    strSQL = strSQL + " IT_TROCAPTHOIVIEC.THANGTRUOC2008,"


        ''    strSQL = strSQL + " SOTHANG = CASE WHEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008))=5 "
        ''    strSQL = strSQL + " THEN case when CHK_SANHDOI=1 then 7 else 6 end"
        ''    strSQL = strSQL + " ELSE case when CHK_SANHDOI=1 then IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008) + 1 "
        ''    strSQL = strSQL + " else IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008) end END,"

        ''    strSQL = strSQL + " TONGNAM = CASE WHEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 THEN SOTHANGSAU2008 ELSE 0 END))>= 12 "
        ''    strSQL = strSQL + " THEN IT_TROCAPTHOIVIEC.NAMTRUOC2008 + 1 ELSE IT_TROCAPTHOIVIEC.NAMTRUOC2008 END,"
        ''    strSQL = strSQL + " TONGTHANG = isnull(CASE WHEN ( "
        ''    strSQL = strSQL + " IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 "
        ''    strSQL = strSQL + " THEN SOTHANGSAU2008 ELSE 0 END))>= 12 "
        ''    strSQL = strSQL + " THEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 THEN SOTHANGSAU2008 ELSE 0 END)) - 12 "
        ''    strSQL = strSQL + " ELSE (CASE WHEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008))=5 THEN	"
        ''    strSQL = strSQL + " case when CHK_SANHDOI=1 then 7 else 6 end ELSE case when CHK_SANHDOI=1 then "
        ''    strSQL = strSQL + " IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008) + 1 else IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(SOTHANGSAU2008) end END )END , 0) "

        ''    'strSQL = strSQL + " TONGTHANG = CASE WHEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 THEN SOTHANGSAU2008 ELSE 0 END))>= 12 "
        ''    'strSQL = strSQL + " THEN (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 THEN SOTHANGSAU2008 ELSE 0 END)) - 12 ELSE"
        ''    'strSQL = strSQL + " (IT_TROCAPTHOIVIEC.THANGTRUOC2008 + SUM(CASE WHEN NAM > 2008 THEN SOTHANGSAU2008 ELSE 0 END)) END"

        ''    strSQL = strSQL + " FROM IT_TROCAPTHOIVIEC INNER JOIN ST_NHANVIEN ON IT_TROCAPTHOIVIEC.NV_MA = ST_NHANVIEN.NV_Ma "
        ''    ' BO SUNG
        ''    strSQL = strSQL + " LEFT JOIN (select MANV,MAX(NGAYSANHCON) as ngaysanh,CHK_SANHDOI from IT_NUOICONDUOI6TUOI where MANV='" & obj.MANV & "' group by MANV,CHK_SANHDOI "
        ''    strSQL = strSQL + " ) C ON C.MANV=ST_NHANVIEN.NV_Ma "
        ''    ' END BO SUNG
        ''    strSQL = strSQL + " WHERE ST_NHANVIEN.NV_Ma = '" & obj.MANV & "'"
        ''    strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_MA, ST_NHANVIEN.NV_Ten ,ST_NHANVIEN.NV_Ngayvao,"
        ''    strSQL = strSQL + " NAMTHANGTRUOC2008,NAMTRUOC2008,THANGTRUOC2008,TONGNAM,CHK_SANHDOI"
        ''End If

        If obj.ChonBang = 2 Then
            strSQL = " SELECT ST_NHANVIEN.NV_Ma, "
            strSQL = strSQL + " ST_NHANVIEN .NV_Ten ,"
            strSQL = strSQL + " ST_NHANVIEN.NV_Ngayvao ,"
            strSQL = strSQL + " TONGTHANG =	SUM(TONGTHANG) "
            strSQL = strSQL + " + "
            strSQL = strSQL + " CASE WHEN NV_Ngayvao >= '2014-09-01' AND  DATEDIFF(DAY,NV_Ngayvao,NV_NGAYKHD_) > 50 THEN 2 WHEN NV_Ngayvao >= '2014-09-01' AND  DATEDIFF(DAY,NV_Ngayvao,NV_NGAYKHD_) > 15 THEN 1 ELSE 0 END "

            strSQL = strSQL + " FROM IT_TROCAPTHOIVIEC INNER JOIN ST_NHANVIEN ON IT_TROCAPTHOIVIEC.NV_MA = ST_NHANVIEN.NV_Ma "            
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_Ma = '" & obj.MANV & "'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_MA, ST_NHANVIEN.NV_Ten ,ST_NHANVIEN.NV_Ngayvao,"
            strSQL = strSQL + " NV_NGAYKHD_"
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
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
