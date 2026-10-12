Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDKinhNghiemLamViec
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As objKinhNghiemLamViec) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""


        If obj.ChonBang = 1 Then
            strSQL = "SELECT TT_MA, TT_TEN FROM ST_TINHTHANH "
        End If
        If obj.ChonBang = 5 Then
            strSQL = "SELECT LTV_Ma, LTV_Ten  FROM ST_LOAITHOIVIEC "
        End If
        If obj.ChonBang = 2 Then
            strSQL = " SELECT "
            strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYVAO,"
            strSQL = strSQL + " NV_DIACHI,"
            strSQL = strSQL + " DV_MA,"
            strSQL = strSQL + " ST_CONGVIEC.CV_TEN,"
            strSQL = strSQL + " CVU_TEN,"
            strSQL = strSQL + " CM_TEN,"

            strSQL = strSQL + " NV_NAMSINH =ISNULL(NV_NAMSINH,0),"
            strSQL = strSQL + "(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,"
            strSQL = strSQL + " NV_NGAYKHD, HD_LUONGCB,NV_NGAYSINH as NV_NGAYSINHTT"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA =  ST_CHUCVU.CVU_MA"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA"
            strSQL = strSQL + " LEFT JOIN ST_HOPDONGLAODONG ON ST_NHANVIEN.NV_MA = ST_HOPDONGLAODONG.NV_MA"
            strSQL = strSQL + " LEFT JOIN ST_CHUYENMON ON ST_NHANVIEN.CM_MA = ST_CHUYENMON.CM_MA"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA = N'" & Me.QuoteString(obj.NV_MA) & "' "
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM IT_KINHNGHIEMLAMVIEC WHERE NV_MA = N'" & Me.QuoteString(obj.NV_MA) & "' "
        End If
        If obj.ChonBang = 4 Then
            strSQL = "SELECT ST_NHANVIEN.NV_Ma,"
            strSQL = strSQL + " ST_NHANVIEN.NV_Ten,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TENCONGTY1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TINH1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TUNAM1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_DENNAM1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_CV1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_LYDOTHOIVIEC1,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TENCONGTY2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TINH2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TUNAM2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_DENNAM2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_CV2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_LYDOTHOIVIEC2,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TENCONGTY3,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TINH3,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_TUNAM3,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_DENNAM3,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_CV3,"
            strSQL = strSQL + " IT_KINHNGHIEMLAMVIEC.KNLV_LYDOTHOIVIEC3"
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN IT_KINHNGHIEMLAMVIEC ON  ST_NHANVIEN.NV_Ma = IT_KINHNGHIEMLAMVIEC.NV_MA"
            'strSQL = strSQL + " WHERE ST_NHANVIEN.NV_Ma = N'" & Me.QuoteString(obj.NV_MA) & "' "
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
    Public Function InsertInfo(ByVal obj As objKinhNghiemLamViec) As Boolean
        Dim flag As Boolean
        Dim strSQL As String

        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_KINHNGHIEMLAMVIEC([NV_MA],[KNLV_TENCONGTY1],[KNLV_TINH1],[KNLV_TUNAM1],[KNLV_DENNAM1],[KNLV_CV1],[KNLV_LYDOTHOIVIEC1],[KNLV_TENCONGTY2],[KNLV_TINH2],[KNLV_TUNAM2],[KNLV_DENNAM2],[KNLV_CV2],[KNLV_LYDOTHOIVIEC2],[KNLV_TENCONGTY3],[KNLV_TINH3],[KNLV_TUNAM3],[KNLV_DENNAM3],[KNLV_CV3],[KNLV_LYDOTHOIVIEC3]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.KNLV_TENCONGTY1) & "',N'" & Me.QuoteString(obj.KNLV_TINH1) & "',N'" & Me.QuoteString(obj.KNLV_TUNAM1) & "',N'" & Me.QuoteString(obj.KNLV_DENNAM1) & "',N'" & Me.QuoteString(obj.KNLV_CV1) & "',N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC1) & "',N'" & Me.QuoteString(obj.KNLV_TENCONGTY2) & "',N'" & Me.QuoteString(obj.KNLV_TINH2) & "',N'" & Me.QuoteString(obj.KNLV_TUNAM2) & "',N'" & Me.QuoteString(obj.KNLV_DENNAM2) & "',N'" & Me.QuoteString(obj.KNLV_CV2) & "',N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC2) & "',N'" & Me.QuoteString(obj.KNLV_TENCONGTY3) & "',N'" & Me.QuoteString(obj.KNLV_TINH3) & "',N'" & Me.QuoteString(obj.KNLV_TUNAM3) & "',N'" & Me.QuoteString(obj.KNLV_DENNAM3) & "',N'" & Me.QuoteString(obj.KNLV_CV3) & "',N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC3) & "')"
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
    Public Function DeleteInfo(ByVal obj As objKinhNghiemLamViec) As Boolean
        Dim strSQL As String
        strSQL = "DELETE IT_KINHNGHIEMLAMVIEC WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objKinhNghiemLamViec) As Boolean
        Dim flag As Boolean
        Dim strSQL As String


        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_KINHNGHIEMLAMVIEC SET KNLV_TENCONGTY1=N'" & Me.QuoteString(obj.KNLV_TENCONGTY1) & "',KNLV_TINH1=N'" & Me.QuoteString(obj.KNLV_TINH1) & "',KNLV_TUNAM1=N'" & Me.QuoteString(obj.KNLV_TUNAM1) & "',KNLV_DENNAM1=N'" & Me.QuoteString(obj.KNLV_DENNAM1) & "',KNLV_CV1=N'" & Me.QuoteString(obj.KNLV_CV1) & "',KNLV_LYDOTHOIVIEC1=N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC1) & "',KNLV_TENCONGTY2=N'" & Me.QuoteString(obj.KNLV_TENCONGTY2) & "',KNLV_TINH2=N'" & Me.QuoteString(obj.KNLV_TINH2) & "',KNLV_TUNAM2=N'" & Me.QuoteString(obj.KNLV_TUNAM2) & "',KNLV_DENNAM2=N'" & Me.QuoteString(obj.KNLV_DENNAM2) & "',KNLV_CV2=N'" & Me.QuoteString(obj.KNLV_CV2) & "',KNLV_LYDOTHOIVIEC2=N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC2) & "',KNLV_TENCONGTY3=N'" & Me.QuoteString(obj.KNLV_TENCONGTY3) & "',KNLV_TINH3=N'" & Me.QuoteString(obj.KNLV_TINH3) & "',KNLV_TUNAM3=N'" & Me.QuoteString(obj.KNLV_TUNAM3) & "',KNLV_DENNAM3=N'" & Me.QuoteString(obj.KNLV_DENNAM3) & "',KNLV_CV3=N'" & Me.QuoteString(obj.KNLV_CV3) & "',KNLV_LYDOTHOIVIEC3=N'" & Me.QuoteString(obj.KNLV_LYDOTHOIVIEC3) & "' WHERE NV_MA=N'" & Me.QuoteString(obj.NV_MA) & "'"
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
End Class
