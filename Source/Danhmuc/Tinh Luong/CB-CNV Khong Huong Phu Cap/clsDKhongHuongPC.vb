Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDKhongHuongPC
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objKhongHuongPC) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If

        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            If obj.DonVi = "TCT" Then
                strSQL = " SELECT NULL AS [3],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " NV_PCChuyencan = ISNULL(NV_PCChuyencan,0),"
                strSQL = strSQL + " NV_PCMoitruong =  ISNULL(NV_PCMoitruong,0),"
                strSQL = strSQL + " NV_PCTrachnhiem = ISNULL(NV_PCTrachnhiem,0),"
                strSQL = strSQL + " NV_PCKhac = ISNULL(NV_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_NHANVIENKHONGPHUCAP ON ST_NHANVIEN.NV_MA = ST_NHANVIENKHONGPHUCAP.NV_MA"
                strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT IN ('T','T01','T02','NV','NV01','NV02','A1MDT','A2MDT')"
                strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ORDER BY ST_NHANVIEN.NV_MA"
            Else
                strSQL = " SELECT NULL AS [3],"
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " NV_TEN,"
                strSQL = strSQL + " NV_PCChuyencan = ISNULL(NV_PCChuyencan,0),"
                strSQL = strSQL + " NV_PCMoitruong =  ISNULL(NV_PCMoitruong,0),"
                strSQL = strSQL + " NV_PCTrachnhiem = ISNULL(NV_PCTrachnhiem,0),"
                strSQL = strSQL + " NV_PCKhac = ISNULL(NV_PCKhac, 0)"
                strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_NHANVIENKHONGPHUCAP ON ST_NHANVIEN.NV_MA = ST_NHANVIENKHONGPHUCAP.NV_MA"
                strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT IN ('T','T01','T02','NV','NV01','NV02','A1MDT','A2MDT')"
                strSQL = strSQL + " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DonVi + "' ORDER BY ST_NHANVIEN.NV_MA"
            End If
        End If

        If obj.ChonBang = 8 Then
            strSQL = "SELECT * FROM ST_THANG ORDER BY T_MA"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * FROM ST_NHANVIENKHONGPHUCAP WHERE NV_MA = '" + obj.NV_MA + "'"
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

    Public Function UpdateInfo(ByVal obj As objKhongHuongPC) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_NHANVIENKHONGPHUCAP  SET NV_PCMoitruong = " & Me.QuoteString(obj.MoiTruong) & ", NV_PCChuyencan = " & Me.QuoteString(obj.ChuyenCan) & " , NV_PCTrachnhiem = " & Me.QuoteString(obj.TrachNhiem) & " , NV_PCKhac = " & Me.QuoteString(obj.Khac) & "  WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
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

    Public Function DeleteInfo(ByVal obj As objKhongHuongPC) As Boolean
        Dim strSQL As String
        strSQL = "DELETE ST_NHANVIENKHONGPHUCAP WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'"
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objKhongHuongPC) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO ST_NHANVIENKHONGPHUCAP([NV_MA],[NV_PCMoitruong],[NV_PCChuyencan],[NV_PCTrachnhiem],[NV_PCKhac]) values(N'" & Me.QuoteString(obj.NV_MA) & "'," & Me.QuoteString(obj.MoiTruong) & "," & Me.QuoteString(obj.ChuyenCan) & "," & Me.QuoteString(obj.TrachNhiem) & "," & Me.QuoteString(obj.Khac) & ")")
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
