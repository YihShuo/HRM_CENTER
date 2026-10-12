Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDDaoTao
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objDaoTao) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = (" SELECT NV_TEN, DV_MA")
            strSQL = strSQL + "  FROM ST_NHANVIEN"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_MA")
            strSQL = strSQL + ", DT_NGAYBATDAU "
            strSQL = strSQL + "  FROM ST_QUATRINHDAOTAO"
            strSQL = strSQL + "  WHERE NV_MA = '" & Me.QuoteString(obj.MANV) & "'AND DT_NGAYBATDAU = '" & Me.QuoteString(obj.NGAYBATDAU) & "'"
        End If
        If obj.ChonBang = 3 Then
            strSQL = (" SELECT STT,ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DV_MA AS DONVIDT,"
            strSQL = strSQL + " IT_CHINHANH.CN_TEN AS TENCHINHANH,"
            strSQL = strSQL + " IT_CHINHANH.CN_MA AS MACHINHANH,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Ngaybatdau AS NGAYBATDAU,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Ngayketthuc AS NGAYKETTHUC,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Nganh AS NGANH,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_CapHoc AS CAPHOC,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_KetQua AS KETQUA,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Noi AS NOI"
            strSQL = strSQL + " FROM ST_QUATRINHDAOTAO INNER JOIN ST_NHANVIEN ON ST_QUATRINHDAOTAO.NV_MA = ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " INNER JOIN IT_CHINHANH ON ST_QUATRINHDAOTAO.DT_CHINHANH = IT_CHINHANH.CN_MA "
        End If
        If obj.ChonBang = 5 Then
            strSQL = (" SELECT STT,ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + " ST_NHANVIEN.DV_MA AS DONVI,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DV_MA AS DONVIDT,"
            strSQL = strSQL + " IT_CHINHANH.CN_TEN AS TENCHINHANH,"
            strSQL = strSQL + " IT_CHINHANH.CN_MA AS MACHINHANH,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Ngaybatdau AS NGAYBATDAU,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Ngayketthuc AS NGAYKETTHUC,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Nganh AS NGANH,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_CapHoc AS CAPHOC,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_KetQua AS KETQUA,"
            strSQL = strSQL + " ST_QUATRINHDAOTAO.DT_Noi AS NOI"
            strSQL = strSQL + " FROM ST_QUATRINHDAOTAO INNER JOIN ST_NHANVIEN ON ST_QUATRINHDAOTAO.NV_MA = ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " INNER JOIN IT_CHINHANH ON ST_QUATRINHDAOTAO.DT_CHINHANH = IT_CHINHANH.CN_MA "
            strSQL = strSQL + " WHERE ST_QUATRINHDAOTAO.NV_MA = '" & Me.QuoteString(obj.MANV) & "'"
        End If
        If obj.ChonBang = 4 Then
            strSQL = (" SELECT CN_TEN, CN_MA")
            strSQL = strSQL + "  FROM IT_CHINHANH"
        End If
        'Thuc thi cau truy van
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
    Public Function InsertInfo(ByVal obj As objDaoTao) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into ST_QUATRINHDAOTAO(NV_Ma, DV_MA,DT_CHINHANH,DT_NGAYBATDAU, DT_NGAYKETTHUC, DT_NGANH, DT_CAPHOC, DT_KETQUA, DT_NOI) values(N'" & Me.QuoteString(obj.MANV) & "',N'" & Me.QuoteString(obj.DONVI) & "',N'" & Me.QuoteString(obj.CHINHANH) & "',N'" & Me.QuoteString(obj.NGAYBATDAU) & "',N'" & Me.QuoteString(obj.NGAYKETTHUC) & "',N'" & Me.QuoteString(obj.NGANH) & "',N'" & Me.QuoteString(obj.CAPHOC) & "',N'" & Me.QuoteString(obj.KETQUA) & "',N'" & Me.QuoteString(obj.NOI) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objDaoTao) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from ST_QUATRINHDAOTAO where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'AND DT_NGAYBATDAU = '" & Me.QuoteString(jFunction.NGAYBATDAU)) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objDaoTao) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 18 Then
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
