Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class clsDCapNhatNVNgoaiNguPhienDich
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As objCapNhatNVNgoaiNguPhienDich) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            ''=========== tim theo so the ================''
            strSQL = ("SELECT ST_NHANVIEN.NV_Ma,NV_CMND,NV_Ten,NV_GioiTinh ,ST_NHANVIEN.DV_MA,DV_MA_ ,NV_Ngayvao,NV_NGOAINGU =ISNULL(NV_NGOAINGU,0),NV_PHIENDICH = ISNULL(NV_PHIENDICH,0),ST_CONGVIEC.CV_TEN,ST_CHUCVU.CVU_Ten")
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_Ma  "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_Ma =  N'" & Me.QuoteString(obj.NV_MA) & "'"
        End If

        ''=========== tim theo so the co thoi viec ================''
        If obj.ChonBang = 2 Then
            strSQL = strSQL + "SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE NV_MA = N'" & Me.QuoteString(obj.NV_MA) & "'"
        End If

        ''========== combo loai ngoai ngu cho cong viec nhanvien ngoai ngu ========''
        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM IT_NGOAINGU where ISNULL(NN_CHINH,0) = 0 and ISNULL(NN_PHIENDICH,0) = 0"
        End If
        ''========== combo loai ngoai ngu cho cong viec phien dich ========''
        If obj.ChonBang = 4 Then
            strSQL = "SELECT * FROM IT_NGOAINGU where  ISNULL(NN_PHIENDICH,0) = 1 order by THUTU "
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
    Public Function UpdateInfo(ByVal obj As objCapNhatNVNgoaiNguPhienDich) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If (obj.LOAINGOAINGU = "") Then  ''NHAN VIEN BINH THUONG
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_LOAINGOAINGU = NULL where NV_MA = N'", Me.QuoteString(obj.NV_MA)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Else
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_LOAINGOAINGU =N'", Me.QuoteString(obj.LOAINGOAINGU), "' where NV_MA = N'", Me.QuoteString(obj.NV_MA)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function TimNV(ByVal m_sSP_Name As String, ByVal NV_MA As String) As DataTable
        Dim tblSet As DataSet
        Dim tbl As DataTable
        Dim listpar As New ArrayList(1)
        listpar.Add(New SqlParameter("@NV_MA", NV_MA))
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name, listpar)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        listpar.Clear()
        Return tbl
    End Function
    Public Function DanhSachNNgu_HienTai(ByVal m_sSP_Name As String, ByVal stungay As String, ByVal sdenngay As String) As DataTable
        Dim tblSet As DataSet
        Dim tbl As DataTable
        Dim listpar As New ArrayList(2)
        listpar.Add(New SqlParameter("@TUNGAY", stungay))
        listpar.Add(New SqlParameter("@DENNGAY", sdenngay))
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name, listpar)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        listpar.Clear()
        Return tbl
    End Function
    Public Function DanhSachNNgu_ThoiViec(ByVal m_sSP_Name As String, ByVal stungay As String, ByVal sdenngay As String) As DataTable
        Dim tblSet As DataSet
        Dim tbl As DataTable
        Dim listpar As New ArrayList(2)
        listpar.Add(New SqlParameter("@TUNGAY", stungay))
        listpar.Add(New SqlParameter("@DENNGAY", sdenngay))
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name, listpar)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        listpar.Clear()
        Return tbl
    End Function
    Public Function ThongKeNNgu_Thang(ByVal m_sSP_Name As String, ByVal sLoaiNgoaiNgu As String, ByVal sNam As String) As DataTable
        Dim tblSet As DataSet
        Dim tbl As DataTable
        Dim listpar As New ArrayList(2)
        listpar.Add(New SqlParameter("@LOAINGOAINGU", sLoaiNgoaiNgu))
        listpar.Add(New SqlParameter("@NAM", sNam))
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name, listpar)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        listpar.Clear()
        Return tbl
    End Function
    Public Function LoadDS1(ByVal m_sSP_Name As String) As DataTable
        Dim tblSet As DataSet
        Dim tbl As DataTable
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        Return tbl
    End Function
    Public Function GoiThuTucThongKe(ByVal m_sSP_Name As String, ByVal listpar As ArrayList) As DataTable
        Dim tblSet As New DataSet
        Dim tbl As New DataTable
        Try
            tblSet = Me.getDatasetProcedure(m_sSP_Name, listpar)
            tbl = tblSet.Tables(0)
        Catch ex As Exception
            tbl = Nothing
        End Try
        Return tbl
    End Function
    Public Function GoiThuTuc_TinhNgoaiNguKhac(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function CapNhatTen_MaXuong(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function KhoiTaoDL(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function TinhSoLuongBangPhanBo(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
End Class
