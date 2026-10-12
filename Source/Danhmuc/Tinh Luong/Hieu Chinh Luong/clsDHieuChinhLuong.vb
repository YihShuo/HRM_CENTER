Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDHieuChinhLuong
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objHieuChinhLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            If obj.DonVi = "TCT" Then
                strSQL = " SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " T_MA,"
                strSQL = strSQL + " L_LUONGCHINH,"
                strSQL = strSQL + " L_PHUCAPKHAC,"
                strSQL = strSQL + " L_CONGHS1, "
                strSQL = strSQL + " L_CONGHS15,"
                strSQL = strSQL + " L_CONGHS2, "
                strSQL = strSQL + " L_CONGHS3,"
                strSQL = strSQL + " L_CONGCADEM,"
                strSQL = strSQL + " L_NGUNGVIEC,"
                strSQL = strSQL + " L_NGHIP,"
                strSQL = strSQL + " L_NGHIR,"
                strSQL = strSQL + " L_NGHIRO,"
                strSQL = strSQL + " L_NGHIOM,"
                strSQL = strSQL + " L_NGHITS,"
                strSQL = strSQL + " L_NGHIKHAMTHAI,"
                strSQL = strSQL + " L_TAMUNG,"
                strSQL = strSQL + " L_SOPHANCOM,"
                strSQL = strSQL + " L_BHYT = ISNULL(L_BHYT,0),"
                strSQL = strSQL + " L_BHXH = ISNULL(L_BHXH,0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_LUONG ON ST_NHANVIEN.NV_MA = ST_LUONG.NV_MA AND T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND ST_DONVI.DV_LOCBB = 0"
                strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
                strSQL = strSQL + " AND ST_DONVI.DV_TV <>1"
                strSQL = strSQL + " ORDER BY ST_NHANVIEN.NV_MA"
            Else
                strSQL = "  SELECT NULL AS [1],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " T_MA,"
                strSQL = strSQL + " L_LUONGCHINH,"
                strSQL = strSQL + " L_PHUCAPKHAC,"
                strSQL = strSQL + " L_CONGHS1, "
                strSQL = strSQL + " L_CONGHS15,"
                strSQL = strSQL + " L_CONGHS2, "
                strSQL = strSQL + " L_CONGHS3,"
                strSQL = strSQL + " L_CONGCADEM,"
                strSQL = strSQL + " L_NGUNGVIEC,"
                strSQL = strSQL + " L_NGHIP,"
                strSQL = strSQL + " L_NGHIR,"
                strSQL = strSQL + " L_NGHIRO,"
                strSQL = strSQL + " L_NGHIOM,"
                strSQL = strSQL + " L_NGHITS,"
                strSQL = strSQL + " L_NGHIKHAMTHAI,"
                strSQL = strSQL + " L_TAMUNG,"
                strSQL = strSQL + " L_SOPHANCOM,"

                strSQL = strSQL + " L_BHYT = ISNULL(L_BHYT,0),"
                strSQL = strSQL + " L_BHXH = ISNULL(L_BHXH,0)"
                strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_LUONG ON ST_NHANVIEN.NV_MA = ST_LUONG.NV_MA AND T_MA = '" + obj.NamThang + "'"
                strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA = '" + obj.DonVi + "' AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            strSQL = "SELECT * FROM ST_THANG ORDER BY T_MA"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM ST_LUONG WHERE NV_MA = '" + obj.NV_MA + "' AND T_MA = '" + obj.NamThang + "'"
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

    Public Function UpdateInfo(ByVal obj As objHieuChinhLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_LUONG  SET NGUOICAPNHAT= N'" & Me.QuoteString(obj.NGUOICN) & "',NGAYCAPNHAT=N'" & Me.QuoteString(obj.NGAYCN) & "',L_PHUCAPKHAC = " & Me.QuoteString(obj.SoTien) & ", L_BHYT = " & Me.QuoteString(obj.BHYT) & " , L_BHXH = " & Me.QuoteString(obj.BHXH) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE IT_BANGLUONGMOI  SET UUDAI = " & Me.QuoteString(obj.SoTien) & " WHERE SOTHE = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
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
    Public Function DeleteInfo(ByVal obj As objHieuChinhLuong) As Boolean
        Dim strSQL As String
        strSQL = "UPDATE ST_LUONG  SET NGUOICAPNHAT= N'" & Me.QuoteString(obj.NGUOICN) & "',NGAYCAPNHAT=N'" & Me.QuoteString(obj.NGAYCN) & "',L_THUETNCN = NULL WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objHieuChinhLuong) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = ("INSERT INTO ST_TAMUNG([NV_MA],[T_MA],[TU_SOTIEN],[TU_THUONGABC],[DV_MA]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NamThang) & "'," & Me.QuoteString(obj.SoTien) & "," & Me.QuoteString(obj.ThuongABC) & ",N'" & Me.QuoteString(obj.DonVi) & "')")
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
