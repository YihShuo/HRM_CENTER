Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDWaiting
    Inherits DALSQL

    Public Function LoadDS(ByVal obj As objWaiting) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " where ST_DONVI.X_MA_ = N'" & Me.QuoteString(obj.ID) & "'")
            End If
            strSQL = ("SELECT ST_NHANVIEN.NV_MA AS MASO , ST_NHANVIEN.NV_TEN AS HOTEN , ST_NHANVIEN.DV_MA AS DONVI,ST_DONVI.X_MA_ AS XUONG  FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA  " & strSQL & " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%' AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("DELETE FROM JELL_CHITIET_GIOCONGTANGCA_NGAY WHERE NGAY = N'" & Me.QuoteString(obj.NamThangNgay) & "' ")
        End If

        If obj.ChonBang = 3 Then
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " WHERE X_MA_ = N'" & Me.QuoteString(obj.ID) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'")
            End If
            strSQL = ("DELETE FROM JELL_GIOTANGCATHANG_TRONGMOTNAM " & strSQL & " ")
        End If

        If obj.ChonBang = 33 Then
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " WHERE X_MA_ = N'" & Me.QuoteString(obj.ID) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'")
            End If
            strSQL = ("DELETE FROM JELL_GIOTANGCATHANG_TRONGMOTNAM_TAY " & strSQL & " ")
        End If

        If obj.ChonBang = 4 Then
            strSQL = ("DELETE FROM JELL_GIOCONGKHACTHUONGTUAN_TRONGTHANG WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' ")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("DELETE FROM JELL_CHITIET_GIOCONGKHACTHUONGTUAN_GTT_TABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND TUAN = N'" & Me.QuoteString(obj.Tuan) & "' ")
        End If

        If obj.ChonBang = 6 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONG_NGAYNHANVIENTABLE WHERE NGAY = N'" & Me.QuoteString(obj.Ngay) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 7 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONG_TUANNHANVIENTABLE WHERE TUAN = N'" & Me.QuoteString(obj.Tuan) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA AS MASO , ST_NHANVIEN.NV_TEN AS HOTEN , ST_NHANVIEN.DV_MA AS DONVI,ST_DONVI.X_MA_ AS XUONG  FROM ST_NHANVIEN INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA  WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ")
        End If

        If obj.ChonBang = 9 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONG_THANGNHANVIENTABLE WHERE THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 10 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONG_NAMNHANVIENTABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 11 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONGHANGNGAY_PHUONGNGANTABLE WHERE NGAY = N'" & Me.QuoteString(obj.Ngay) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 12 Then
            strSQL = ("SELECT ST_DONVI.DV_MA AS DONVI FROM ST_DONVI WHERE ST_DONVI.X_MA_ <> 'KB' AND NOT ST_DONVI.X_MA_ IS NULL AND ST_DONVI.N_MA NOT IN ('CG','BGD') ")
        End If

        If obj.ChonBang = 13 Then
            strSQL = ("DELETE FROM JELL_THONGKEGIOCONG_NGAYXUONGTABLE WHERE NGAY = N'" & Me.QuoteString(obj.Ngay) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 14 Then
            strSQL = ("SELECT JELL_NXUONG.X_MA_ AS XUONG FROM JELL_NXUONG ")
        End If

        If obj.ChonBang = 15 Then
            strSQL = ("DELETE FROM JELL_THONGKEGIOCONG_TUANXUONGTABLE WHERE TUAN = N'" & Me.QuoteString(obj.Tuan) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 16 Then
            strSQL = ("DELETE FROM JELL_THONGKEGIOCONG_THANGXUONGTABLE WHERE THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 17 Then
            strSQL = ("DELETE FROM JELL_THONGKEGIOCONG_NAMXUONGTABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "'  ")
        End If

        If obj.ChonBang = 18 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONGHANGTHANG_PHUONGNGANTABLE WHERE THANG = N'" & Me.QuoteString(obj.Thang) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 19 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONGHANGNAM_PHUONGNGANTABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 20 Then
            strSQL = ("DELETE FROM JELLTHONGKEGIOCONGHANGTUAN_PHUONGNGANTABLE WHERE TUAN = N'" & Me.QuoteString(obj.Tuan) & "' AND NAM = N'" & Me.QuoteString(obj.Nam) & "' ")
        End If

        If obj.ChonBang = 21 Then
            strSQL = ("DELETE FROM Q_GIOCONGTIEUCHUANTHANGTABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' ")
        End If

        If obj.ChonBang = 22 Then
            strSQL = ("SELECT Q_GIOCONGTIEUCHUANTHANGVIEW.NV_Ma ,Q_GIOCONGTIEUCHUANTHANGVIEW.THANG AS THANG FROM Q_GIOCONGTIEUCHUANTHANGVIEW WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' ")
        End If

        If obj.ChonBang = 23 Then
            strSQL = ("DELETE FROM Q_GIOCONGTTCVANTCTABLE WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND TUAN = N'" & Me.QuoteString(obj.Tuan) & "' ")
        End If

        If obj.ChonBang = 24 Then
            strSQL = ("SELECT Q_GIOCONGTTCVANTC.NV_Ma ,Q_GIOCONGTTCVANTC.TUAN AS TUAN FROM Q_GIOCONGTTCVANTC WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND TUAN = N'" & Me.QuoteString(obj.Tuan) & "' ")
        End If

        If obj.ChonBang = 25 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_MA AS MASO FROM ST_NHANVIEN WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ")
        End If

        If obj.ChonBang = 26 Then
            strSQL = ("DELETE FROM Q_BAOBIEUPTTKKHONGPHEPCUACACDONVITUANTableA WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND TUAN = N'" & Me.QuoteString(obj.Tuan) & "' ")
        End If

        If obj.ChonBang = 27 Then
            strSQL = ("SELECT Q_BAOBIEUPTTKKHONGPHEPCUACACDONVITUAN.X_Ma_ ,Q_BAOBIEUPTTKKHONGPHEPCUACACDONVITUAN.TUAN AS TUAN FROM Q_BAOBIEUPTTKKHONGPHEPCUACACDONVITUAN WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND TUAN = N'" & Me.QuoteString(obj.Tuan) & "' ")
        End If

        If obj.ChonBang = 28 Then
            strSQL = ("DELETE FROM Q_PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONGTable WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' ")
        End If

        If obj.ChonBang = 29 Then
            strSQL = ("SELECT Q_PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG.X_Ma_ ,Q_PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG.THANG AS THANG FROM Q_PHANTICHTHONGKEKHONGPHEPCUACACDONVITHEOXUONG WHERE NAM = N'" & Me.QuoteString(obj.Nam) & "' AND THANG = N'" & Me.QuoteString(obj.Thang) & "' ")
        End If
        If obj.ChonBang = 30 Then
            strSQL = ("SELECT NV_MA FROM ST_NHANVIEN WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) AND DV_MA NOT LIKE 'DT%' AND DV_MA NOT IN ('A1MDT','A2MDT')")
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function

End Class
