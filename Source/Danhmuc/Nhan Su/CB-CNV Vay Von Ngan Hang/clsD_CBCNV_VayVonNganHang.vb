Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsD_CBCNV_VayVonNganHang
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As Obj_CBCNV_VayVonNganHang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            ''=========== tim theo so the,so cmnd, so tai khoan =============''
            strSQL = ("SELECT ST_NHANVIEN.NV_Ma,NV_CMND,NV_Ten,NV_GioiTinh ,ST_NHANVIEN.DV_MA,DV_MA_ ,ST_DONVI.X_MA_,NV_Ngayvao,NGAYBDVAY,NGAYHOANVON = CASE WHEN HOANVON = 0 THEN NULL ELSE NGAYHOANVON END,HOANVON = ISNULL(HOANVON,0),DATHOIVIEC = (CASE WHEN TV_NGAYTHOIVIEC IS NULL THEN 0 ELSE 1 END),TV_NgayThoiViec = CONVERT (varchar(10),TV_NgayThoiViec,105) ,ST_LOAITHOIVIEC.LTV_Ten ,TV_LyDo,IT_DDNGHIVIEC = ISNULL (IT_DDNGHIVIEC,0) ,SOTAIKHOAN ")
            strSQL = strSQL + " FROM ST_NHANVIEN "
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_LOAITHOIVIEC ON ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL = strSQL + " LEFT JOIN IT_VAYVONNGANHANG ON ST_NHANVIEN.NV_MA = IT_VAYVONNGANHANG.NV_Ma"
            Select Case obj.TenCot
                Case "''NV_MA''"
                    strSQL += " WHERE ST_NHANVIEN.NV_Ma =  N'" & Me.QuoteString(obj.NV_MA) & "'"
                Case "''NV_CMND''"
                    strSQL += " WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.NV_CMND) & "'"
                Case "''SOTAIKHOAN''"
                    strSQL += " WHERE ST_NHANVIEN.SOTAIKHOAN  = N'" & Me.QuoteString(obj.SOTAIKHOAN) & "'"
                Case Else
                    Exit Function
            End Select
        End If
        ''loc du lieu
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_Ma,NV_CMND,NV_Ten,NV_GioiTinh ,ST_NHANVIEN.DV_MA,DV_MA_ ,ST_DONVI.X_MA_,NV_Ngayvao,NGAYBDVAY,NGAYHOANVON = CASE WHEN HOANVON = 0 THEN NULL ELSE NGAYHOANVON END,HOANVON = ISNULL(HOANVON,0),DATHOIVIEC = (CASE WHEN TV_NGAYTHOIVIEC IS NULL THEN 0 ELSE 1 END),TV_NgayThoiViec = CONVERT (varchar(10),TV_NgayThoiViec,105) ,ST_LOAITHOIVIEC.LTV_Ten ,TV_LyDo,IT_DDNGHIVIEC = ISNULL (IT_DDNGHIVIEC,0),SOTAIKHOAN  ")
            strSQL = strSQL + " FROM IT_VAYVONNGANHANG INNER JOIN ST_NHANVIEN ON IT_VAYVONNGANHANG.NV_MA = ST_NHANVIEN.NV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_LOAITHOIVIEC ON ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL = strSQL + " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA ASC"
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * FROM IT_VAYVONNGANHANG")
            strSQL = strSQL + " WHERE NV_MA='" & obj.NV_MA & "' AND NGAYBDVAY ='" & obj.NGAYBD & "'"

        End If
        ''=========== tinh so lan vay von ========''
        If obj.ChonBang = 4 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA,SOLANVAY=COUNT(IT_VAYVONNGANHANG.NV_MA) FROM ST_NHANVIEN LEFT JOIN IT_VAYVONNGANHANG ON ST_NHANVIEN.NV_Ma = IT_VAYVONNGANHANG.NV_Ma "
            Select Case obj.TenCot
                Case "''NV_MA''"
                    strSQL += " WHERE ST_NHANVIEN.NV_Ma =  N'" & Me.QuoteString(obj.NV_MA) & "'"
                Case "''NV_CMND''"
                    strSQL += " WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.NV_CMND) & "'"
                Case "''SOTAIKHOAN''"
                    strSQL += " WHERE ST_NHANVIEN.SOTAIKHOAN  = N'" & Me.QuoteString(obj.SOTAIKHOAN) & "'"
                Case Else
                    Exit Function
            End Select
            strSQL += " GROUP BY ST_NHANVIEN.NV_Ma "
        End If
        ''=========== hien thi cac ngay chua hoan von len combo ========''
        ''=========== chon =1 thì tim ngay hoan von,trang thai hoan von theo ngay vay len dieu khien ========''
        If obj.ChonBang = 5 Then
            strSQL = "SELECT ST_NHANVIEN.NV_MA, NGAYBDVAY = CONVERT(NVARCHAR(10),NGAYBDVAY,105),NGAYHOANVON = CASE WHEN HOANVON = 0 THEN NULL ELSE CONVERT(NVARCHAR(10),NGAYHOANVON,105) END,HOANVON = ISNULL(HOANVON,0) FROM ST_NHANVIEN  LEFT JOIN IT_VAYVONNGANHANG ON ST_NHANVIEN.NV_Ma = IT_VAYVONNGANHANG.NV_Ma"
            Select Case obj.TenCot
                Case "''NV_MA''"
                    strSQL += " WHERE ST_NHANVIEN.NV_Ma =  N'" & Me.QuoteString(obj.NV_MA) & "'"
                Case "''NV_CMND''"
                    strSQL += " WHERE ST_NHANVIEN.NV_CMND = N'" & Me.QuoteString(obj.NV_CMND) & "'"
                Case "''SOTAIKHOAN''"
                    strSQL += " WHERE ST_NHANVIEN.SOTAIKHOAN  = N'" & Me.QuoteString(obj.SOTAIKHOAN) & "'"
                Case Else
                    Exit Function
            End Select
            If obj.TimNgayHoanVon = 1 Then
                strSQL += " AND NGAYBDVAY = '" & Me.QuoteString(obj.NGAYBD) & "'"
            End If
        End If
        ''================= kiem tra co nhap thoi viec thi khong cho them =========''
        If obj.ChonBang = 6 Then
            strSQL = "SELECT * FROM ST_NHANVIENTHOIVIEC "
              Select obj.TenCot
                Case "''NV_MA''"
                    strSQL += " WHERE ST_NHANVIENTHOIVIEC.NV_Ma =  N'" & Me.QuoteString(obj.NV_MA) & "'"
                Case Else
                    Exit Function
            End Select
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
    Public Function InsertInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        If obj.NGAYHOANVON = "" Then
            strSQL = ((String.Concat(New String() {strSQL, "insert into IT_VAYVONNGANHANG (NV_MA,NGAYBDVAY,NGAYHOANVON,HOANVON) values(N'", Me.QuoteString(obj.NV_MA) & "','", Me.QuoteString(obj.NGAYBD) & "',NULL,", Me.QuoteString(obj.HoanVon)}) & ")" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Else
            strSQL = ((String.Concat(New String() {strSQL, "insert into IT_VAYVONNGANHANG (NV_MA,NGAYBDVAY,NGAYHOANVON,HOANVON) values(N'", Me.QuoteString(obj.NV_MA) & "','", Me.QuoteString(obj.NGAYBD) & "','", Me.QuoteString(obj.NGAYHOANVON) & "',", Me.QuoteString(obj.HoanVon)}) & ")" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function UpdateInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.HoanVon = 0 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update IT_VAYVONNGANHANG set NGAYHOANVON = NULL,HOANVON = ", Me.QuoteString(obj.HoanVon), " where NV_MA =N'", Me.QuoteString(obj.NV_MA), "' AND NGAYBDVAY =N'", Me.QuoteString(obj.NGAYBD)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Else
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update IT_VAYVONNGANHANG set NGAYHOANVON =N'", Me.QuoteString(obj.NGAYHOANVON), "',HOANVON = ", Me.QuoteString(obj.HoanVon), " where NV_MA = N'", Me.QuoteString(obj.NV_MA), "' AND NGAYBDVAY = N'", Me.QuoteString(obj.NGAYBD)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function DeleteInfo(ByVal obj As Obj_CBCNV_VayVonNganHang) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from IT_VAYVONNGANHANG where NV_MA =N'" & Me.QuoteString(obj.NV_MA) & "' AND NGAYBDVAY ='" & Me.QuoteString(obj.NGAYBD)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Dim tbl As DataTable
        tbl = Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
        Return tbl
    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
End Class
