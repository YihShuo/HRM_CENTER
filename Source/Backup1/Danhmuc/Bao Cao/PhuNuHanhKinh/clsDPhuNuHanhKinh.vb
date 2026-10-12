Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDPhuNuHanhKinh
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As ObjPhuNuHanhKinh) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT DV_MA,DV_TEN FROM ST_DONVI WHERE ISNULL(DV_LOCBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA NOT LIKE '%CG%'  AND DV_MA NOT LIKE 'BGD%' AND DV_MA NOT LIKE 'DT%' ORDER BY DV_MA")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT DV_MA,DV_TEN FROM ST_DONVI WHERE ISNULL(DV_LOCBB,0) = 0 AND ISNULL(DV_TV,0) =1 AND DV_MA NOT LIKE '%CG%'  AND DV_MA NOT LIKE 'BGD%' AND DV_MA NOT LIKE 'DT%' ORDER BY DV_MA")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * from JELL_USER WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "' AND (Ma_DM ='1frmPhuNuHanhKinh' OR Ma_DM ='2frmPhuNuHanhKinh') ")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("SELECT * from V_QUYENCHUYENDULIEUHK WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")

        End If
        If obj.ChonBang = 6 Then
            strSQL = ("SELECT * from V_QUYENCHUYENDULIEUHKNV WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
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
    Public Function LoadDSNghiHanhKinh(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
    End Function
    Public Function LoadDanhmucThang(ByVal m_sSP_Name As String) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
    End Function
    Public Function GoiThuTucTinhToan(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function CapNhatSoGioNghiHanhKinh(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Dim flag As Boolean
        Try
            flag = Me.execProc(m_sSP_Name, m_listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function InsertInfo(ByVal obj As ObjPhuNuHanhKinh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO IT_PHUNUHANHKINH([NV_Ma],[Ngay]) VALUES('", Me.QuoteString(obj.NV_MA), "','", Me.QuoteString(obj.NgayNghiHanhKinh), "'"}) & ")" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function DeleteInfo(ByVal obj As ObjPhuNuHanhKinh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "DELETE IT_PHUNUHANHKINH WHERE NV_MA ='", Me.QuoteString(obj.NV_MA), "' AND NGAY = '", Me.QuoteString(obj.NgayNghiHanhKinh), "'"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
End Class
