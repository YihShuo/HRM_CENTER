Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDCapNhatNhomCV_MTCV_PTCV
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objCapNhatNhomCV_MTCV_PTCV) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If
        If obj.ChonBang = 2 Then
            strSQL = (" SELECT NHOMCV_MA, (NHOMCV_MA+' - '+ NHOMCV_TEN) AS TEN_NHOM FROM IT_QUANLY_MTCV_PTCV  WHERE NHOMCV_TINHTRANG = 1")
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT  NULL AS [1],CONVERT(BIT,'0') AS [2],NULL AS [3],ST_NHANVIEN.NV_Ma, "
            strSQL = strSQL + " NV_Ten,"
            strSQL = strSQL + " NV_Ngayvao,"
            strSQL = strSQL + " ST_NHANVIEN.CV_MA, "
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.CVU_MA,"
            strSQL = strSQL + " ST_CHUCVU.CVU_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.NHOMCV_MA,"
            strSQL = strSQL + " IT_QUANLY_MTCV_PTCV.NHOMCV_TEN"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " LEFT JOIN IT_QUANLY_MTCV_PTCV   ON ST_NHANVIEN.NHOMCV_MA = IT_QUANLY_MTCV_PTCV.NHOMCV_MA  AND NHOMCV_TINHTRANG = 1"
            strSQL = strSQL + " WHERE IT_DDNGHIVIEC = 0"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DV_MA + "' ORDER BY ST_NHANVIEN.NV_MA"
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

    Public Function UpdateInfo(ByVal obj As objCapNhatNhomCV_MTCV_PTCV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_NHANVIEN  SET NHOMCV_MA = N'" & Me.QuoteString(obj.NHOMCV_MA) & "' WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE ST_NHANVIEN  SET NHOMCV_MA = N'" & Me.QuoteString(obj.NHOMCV_MA) & "' WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
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

    Public Function DeleteInfo(ByVal obj As objCapNhatNhomCV_MTCV_PTCV) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "DELETE ST_BINHBAUTHANG WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.THANG) & "' "
        End If

        Return Me.execSQL(strSQL)
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function InsertInfo(ByVal obj As objCapNhatNhomCV_MTCV_PTCV) As Boolean
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
End Class
