Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class clsDKiemTraPhepNam
    Inherits DALSQL
    Public Shared obj_Dangnhap As New frmDangNhap
    Public Shared obj_D As New objKiemTraPhepNam
    ' Methods
    Public Function DeleteInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        'Dim flag As Boolean
        'Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM [ST_NHANVIENNGHIPHEP] WHERE NV_Ma = '" + obj.MANV + "' AND NP_TuNgay = '" + obj.TuNgay) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'obj_D.TruyVan = strSQL
        'obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        'Try
        '    flag = Me.execSQL(strSQL)
        'Catch exception1 As Exception
        '    ProjectData.SetProjectError(exception1)
        '    Dim exception As Exception = exception1
        '    MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
        '    flag = False
        '    ProjectData.ClearProjectError()
        'End Try
        'Return flag


        Dim flag As Boolean
        Dim strSQL As String
        Dim transaction As SqlTransaction
        Dim command As New SqlCommand
        getConnectString()
        conn = New SqlConnection(Me.strConn)
        Me.conn.Open()
        command = conn.CreateCommand()
        transaction = conn.BeginTransaction("SampleTransaction")
        command.Transaction = transaction

        Try
            command.CommandText = "DELETE FROM [ST_NHANVIENNGHIPHEP] WHERE NV_Ma = @MANV AND NP_TuNgay = @TuNgay"
            command.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = obj.MANV
            command.Parameters.Add("@TuNgay", SqlDbType.Date).Value = obj.TuNgay
            command.ExecuteNonQuery()
            command.CommandText = "update [ST_GIOQUETTHE] set NP_MA = 'NULL' WHERE NV_Ma = @MANV AND QT_NGAY = @TuNgay"
            command.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            End Try
        End Try

        Return flag




    End Function
    ''' <summary>
    ''' xóa tự động khi không kết nối dl TS và mang thai
    ''' </summary>

    Public Function DeleteInfoAuto(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM [ST_NHANVIENNGHIPHEP] WHERE NV_Ma = '" + obj.MANV + "' AND NP_TuNgay = '" + obj.TuNgayCu) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function DeleteInfoDV(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE ST_NHANVIENNGHIPHEP FROM [ST_NHANVIEN] INNER JOIN ST_NHANVIENNGHIPHEP ON [ST_NHANVIEN].NV_MA = ST_NHANVIENNGHIPHEP.NV_MA  WHERE DV_MA_ = '" + obj.DonVi + "' AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1)  AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND NP_MA ='" + obj.LoaiPhep & "' AND NP_TuNgay = '" + obj.TuNgay) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function DeleteInfoNuoiCon(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM IT_NUOICONDUOI12THANG WHERE NV_Ma = '" + obj.MANV + "' AND TUNGAY = '" + obj.TuNgay) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function GoiThuTucHT(ByVal m_sSP_Name As String)
        Me.execProc(m_sSP_Name)
    End Function
    Public Function TinhphepCoOM(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataSet
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar)
    End Function
    Public Function CapNhatThongTin(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        ''GOI CAP NHAT NGAY NHAP PHEP
        strSQL = " UPDATE [ST_NHANVIENNGHIPHEP] SET NP_NGAYNHAPSUA='" & obj.NGAYNHAP & "' WHERE NV_MA='" & obj.MANV & "' AND NP_TUNGAY='" & obj.TuNgay & "' AND NP_DENNGAY='" & obj.DenNgay & "' AND NP_MA=N'" & obj.LoaiPhep & "'"
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function InsertInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        If obj.LoaiPhep = "OM" Then
            strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [ST_NHANVIENNGHIPHEP]([NV_Ma],[NP_TuNgay],[NP_DenNgay],[DV_Ma],[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI],TT_MA,QH_MA,XP_MA) VALUES('", Me.QuoteString(obj.MANV), "','", Me.QuoteString(obj.TuNgay), "','", Me.QuoteString(obj.DenNgay), "','", Me.QuoteString(obj.DonVi), "','", Me.QuoteString(obj.LoaiPhep), "',N'", Me.QuoteString(obj.GhiChu), "','", Me.QuoteString(obj.CONGTYDUYET) & "','", Me.QuoteString(obj.XINCONNUOI), "','", Me.QuoteString(obj.TTQQ), "','", Me.QuoteString(obj.QHQQ), "','", Me.QuoteString(obj.XAQQ)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Else
            strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [ST_NHANVIENNGHIPHEP]([NV_Ma],[NP_TuNgay],[NP_DenNgay],[DV_Ma],[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI]) VALUES('", Me.QuoteString(obj.MANV), "','", Me.QuoteString(obj.TuNgay), "','", Me.QuoteString(obj.DenNgay), "','", Me.QuoteString(obj.DonVi), "','", Me.QuoteString(obj.LoaiPhep), "',N'", Me.QuoteString(obj.GhiChu), "','", Me.QuoteString(obj.CONGTYDUYET) & "','", Me.QuoteString(obj.XINCONNUOI)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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

    Public Function InsertNuoiCon12Thang(ByVal obj As objKiemTraPhepNam) As Boolean
        ''==== ngày sửa: 22/08/2013
        ''==== người sửa: Trân
        ''==== nội dung: Thêm 1 cột ngày sanh giá trị mặc định là khoảng trắng (thay thế cho giá trị NULL)
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [IT_NUOICONDUOI12THANG]([NV_Ma],[TUNGAY],[DENNGAY],[DV_Ma],[NGAYSANH]) VALUES('", Me.QuoteString(obj.MANV), "','", Me.QuoteString(obj.TuNgay), "','", Me.QuoteString(obj.DenNgay), "','", Me.QuoteString(obj.DonVi)}) & "',' ')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function CapNhatDonvi(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [ST_NHANVIENNGHIPHEP]([NV_Ma],[NP_TuNgay],[NP_DenNgay],[DV_Ma],[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET]) SELECT  NV_MA,'" _
                                               , Me.QuoteString(obj.TuNgay), "','", Me.QuoteString(obj.DenNgay), "',DV_MA_ ='", Me.QuoteString(obj.DonVi), "','", Me.QuoteString(obj.LoaiPhep), "',N'", Me.QuoteString(obj.GhiChu), "','", Me.QuoteString(obj.CONGTYDUYET), "'  FROM ST_NHANVIEN WHERE DV_MA_ ='", Me.QuoteString(obj.DonVi), "' AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma]) AND DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND NOT EXISTS (SELECT ST_NHANVIEN.[NV_Ma],[NP_TuNgay],[NP_DenNgay],[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET] FROM ST_NHANVIENNGHIPHEP WHERE [ST_NHANVIENNGHIPHEP].NV_MA = ST_NHANVIEN.NV_MA AND (NP_TUNGAY='", Me.QuoteString(obj.TuNgay), "' OR '", Me.QuoteString(obj.TuNgay), "' BETWEEN NP_TUNGAY AND NP_DENNGAY OR '", Me.QuoteString(obj.DenNgay), "' BETWEEN NP_TuNgay AND NP_DenNgay))"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function CapNhatCongTy(ByVal obj As objKiemTraPhepNam) As Boolean
        ''NGAY SUA: 17/12/2013
        ''NGUOI SUA: TRAN
        ''NOI DUNG: xet moc thoi gian nghỉ lồng nhau của côt từ ngày và cột đến ngày
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [ST_NHANVIENNGHIPHEP]([NV_Ma],[NP_TuNgay],[NP_DenNgay],[DV_Ma],[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET]) SELECT  NV_MA,'" _
                                               , Me.QuoteString(obj.TuNgay), "','", Me.QuoteString(obj.DenNgay), "',DV_MA =( CASE WHEN (ST_NHANVIEN.DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(IT_DDNGHIVIEC,0) = 1 ) THEN ST_NHANVIEN.DV_MA ELSE ST_NHANVIEN.DV_MA_ END),'" _
                                               , Me.QuoteString(obj.LoaiPhep), "',N'", Me.QuoteString(obj.GhiChu), "'  FROM ST_NHANVIEN WHERE NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma]) AND (DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 )AND NOT EXISTS (SELECT ST_NHANVIEN.[NV_Ma] FROM ST_NHANVIENNGHIPHEP WHERE [ST_NHANVIENNGHIPHEP].NV_MA = ST_NHANVIEN.NV_MA AND (NP_TUNGAY='", Me.QuoteString(obj.TuNgay), "' OR '", Me.QuoteString(obj.TuNgay), "' BETWEEN NP_TUNGAY AND NP_DENNGAY  OR '", Me.QuoteString(obj.DenNgay), "' BETWEEN NP_TuNgay AND NP_DenNgay)) AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE 'DT%' AND DV_MA NOT IN ('BGD','BGDX','','A1MDT','A2MDT')"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function LoadDS(ByVal obj As objKiemTraPhepNam) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        ''tim trong phep nam
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT PN_Songaynamtruoc, PN_Songaynamnay, PN_NangnhocDH, PN_PhepTren5Nam,PN_Sothanglamnndh FROM ST_PHEPNAM WHERE NV_MA = '" + obj.MANV + "'AND PN_NAM = '" + obj.NAM + "'")
        End If
        ''tinh so ngay nghi P
        If obj.ChonBang = 2 Then
            'strSQL = ("SELECT SUM(DATEDIFF(DD,NP_TUNGAY,NP_DENNGAY)-GIOTT+1 - A.SN_CHUNHAT) AS SONGAYDANGHI FROM (SELECT NP_TUNGAY,NP_DENNGAY,SN_CHUNHAT, case when NP_GhiChu like N'%0.5%' then 0.5 else 0 end as GIOTT FROM ST_NHANVIENNGHIPHEP WHERE NV_MA = '" + obj.MANV + "' AND YEAR(NP_TUNGAY) = '" + obj.NAM + "' AND NP_MA = 'P') A")
            strSQL = "WITH DonNghiPhep AS ( " &
                        "    SELECT " &
                        "        ROW_NUMBER() OVER (ORDER BY np.NP_TuNgay) AS DonID, " &
                        "        np.NV_MA, " &
                        "        np.NP_TuNgay, " &
                        "        np.NP_DenNgay, " &
                        "        np.NP_GhiChu, " &
                        "        nv.DV_MA " &
                        "    FROM ST_NHANVIENNGHIPHEP np " &
                        "    LEFT JOIN ST_NHANVIEN nv ON nv.NV_MA = np.NV_MA " &
                        "    WHERE np.NV_MA = '" & obj.MANV & "' " &
                        "      AND np.NP_MA = 'P' " &
                        "      AND (YEAR(np.NP_TuNgay) = '" & obj.NAM & "' OR YEAR(np.NP_DenNgay) = '" & obj.NAM & "') " &
                        "), " &
                        "Calendar AS ( " &
                        "    SELECT DonID, NV_MA, DV_MA, NP_TuNgay AS Ngay, NP_DenNgay, NP_GhiChu " &
                        "    FROM DonNghiPhep " &
                        "    UNION ALL " &
                        "    SELECT DonID, NV_MA, DV_MA, DATEADD(DAY, 1, Ngay), NP_DenNgay, NP_GhiChu " &
                        "    FROM Calendar " &
                        "    WHERE Ngay < NP_DenNgay " &
                        "), " &
                        "ChiTietHopLe AS ( " &
                        "    SELECT " &
                        "        c.DonID, " &
                        "        c.NP_GhiChu, " &
                        "        SoNgayHopLe = CASE " &
                        "            WHEN c.DV_MA IN ('BV', 'TVKTX') THEN " &
                        "                CASE " &
                        "                    WHEN ISNULL(gqt.CC_HESONGAYCONG, 0) IN (2, 3) THEN 0 " &
                        "                    ELSE 1 " &
                        "                END " &
                        "            ELSE " &
                        "                CASE " &
                        "                    WHEN (DATEDIFF(DAY, 0, c.Ngay) % 7) = 6 OR ISNULL(gqt.CC_HESONGAYCONG, 0) = 3 OR ISNULL(gqt.CC_HESONGAYCONG, 0) = 2 THEN 0 " &
                        "                    ELSE 1 " &
                        "                END " &
                        "        END " &
                        "    FROM Calendar c " &
                        "    LEFT JOIN ST_GIOQUETTHE gqt " &
                        "        ON gqt.NV_MA = c.NV_MA " &
                        "       AND CONVERT(DATE, gqt.QT_NGAY) = CONVERT(DATE, c.Ngay) " &
                        "    WHERE YEAR(c.Ngay) = '" & obj.NAM & "' " &
                        "), " &
                        "TongHopTheoDon AS ( " &
                        "    SELECT " &
                        "        DonID, " &
                        "        TongNgayTrongDon = SUM(SoNgayHopLe), " &
                        "        GIOTT = CASE WHEN NP_GhiChu LIKE N'%0.5%' THEN 0.5 ELSE 0 END " &
                        "    FROM ChiTietHopLe " &
                        "    GROUP BY DonID, NP_GhiChu " &
                        ") " &
                        "SELECT " &
                        "    SONGAYDANGHI = ISNULL(SUM( " &
                        "        CASE WHEN TongNgayTrongDon > GIOTT THEN TongNgayTrongDon - GIOTT ELSE 0 END " &
                        "    ), 0) " &
                        "FROM TongHopTheoDon " &
                        "OPTION (MAXRECURSION 0);"
        End If
        ''thong tin nhan vien theo đơn vị điều động khi nhập số thẻ va thong tin nghi viec neu co
        '' neu da nhap thoi viec thi lay theo thoi viec; nguoc lai lay theo dv dieu dong
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT NV_TEN,DV_MA =( CASE WHEN (DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(IT_DDNGHIVIEC,0) = 1 ) THEN ST_NHANVIEN.DV_MA ELSE ST_NHANVIEN.DV_MA_")
            strSQL = strSQL + " END),NV_NGAYVAO=(CONVERT(NVARCHAR(10),NV_NGAYVAO,105)), TV_NGAYTHOIVIEC= NULL "
            strSQL = strSQL + "  FROM ST_NHANVIEN  WHERE ST_NHANVIEN.NV_MA = '" + obj.MANV + "'"
        End If
        ''neu co thoi viec thi chay bang nay de lay thong tin thoi viec va nv theo don vi DV_MA
        If obj.ChonBang = 25 Then
            strSQL = ("  SELECT NV_TEN,ST_NHANVIEN.DV_MA AS DV_MA,[ST_NHANVIEN].DV_MA_ AS DV_MA_LUOI,NV_NGAYVAO=(CONVERT(NVARCHAR(10),NV_NGAYVAO,105)) ,TV_NGAYTHOIVIEC=ISNULL((CONVERT(NVARCHAR(10),TV_NGAYTHOIVIEC,105)),'')")
            strSQL = strSQL + " FROM ST_NHANVIEN inner JOIN ST_NHANVIENTHOIVIEC  ON ST_NHANVIEN.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA WHERE ST_NHANVIEN.NV_MA ='" + obj.MANV + "'"
        End If

        If obj.ChonBang = 4 Then
            ''hieu chinh ngay 17/12/2013 cho loc du lieu theo don vi cong nhan moi
            strSQL = ("select DV_MA, (DV_MA+' -- '+DV_TEN) AS TEN_DV from st_donvi where dv_ma not like 'NV%' and dv_ma NOT IN('BGD','','BGDX','A1MDT','A2MDT','KB') AND dv_ma not like 'DT%' AND DV_LOCBB = 0 order by dv_ma ")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("SELECT [NP_Ma],[NP_Ma]+' ' AS NPTEN FROM [ST_NGHIPHEP] ORDER BY THUTU ASC")
        End If

        If obj.ChonBang = 51 Then
            strSQL = ("declare @i int set @i=0 SELECT @i += (DATEDIFF(DAY,NP_TuNgay,NP_DenNgay) + 1) ")
            strSQL = strSQL + " FROM ST_NHANVIENNGHIPHEP WHERE NP_Ma='OM' AND YEAR(NP_TuNgay)=YEAR(GETDATE()) "
            strSQL = strSQL + " AND NV_Ma='" + obj.MANV + "' select @i "
        End If

        ''thong tin nhan vien theo đơn vị điều động khi nhập số thẻ va thong tin nghi viec neu co
        '' neu da nhap thoi viec thi lay theo thoi viec; nguoc lai lay theo dv dieu dong
        If obj.ChonBang = 6 Then ' gam sua thêm cột xin con nuôi
            strSQL = ("SELECT ST_NHANVIEN.[NV_TEN],ST_NHANVIEN.[NV_Ma],[NP_TuNgay],[NP_DenNgay],DV_MA =( CASE WHEN (ST_NHANVIEN.DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(IT_DDNGHIVIEC,0) = 1 ) THEN ST_NHANVIEN.DV_MA ELSE ST_NHANVIEN.DV_MA_ END),[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],SN_CHUNHAT,ISNULL(NP_XINCONNUOI,0) AS NP_XINCONNUOI ,NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_ FROM [ST_NHANVIENNGHIPHEP] INNER JOIN ST_NHANVIEN ON [ST_NHANVIENNGHIPHEP].NV_MA = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA WHERE  ST_NHANVIEN.[NV_Ma] ='" + obj.MANV + "'")
        End If
        If obj.ChonBang = 666 Then ' gam sua thêm cột xin con nuôi
            strSQL = ("SELECT ST_NHANVIEN.[NV_TEN],ST_NHANVIEN.[NV_Ma],[NP_TuNgay],[NP_DenNgay],DV_MA =( CASE WHEN (ST_NHANVIEN.DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(IT_DDNGHIVIEC,0) = 1 ) THEN ST_NHANVIEN.DV_MA ELSE ST_NHANVIEN.DV_MA_ END),[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],ISNULL(NP_XINCONNUOI,0) AS NP_XINCONNUOI ,NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_,D.TT_Ten,B.QH_TEN,C.XP_Ten  FROM [ST_NHANVIENNGHIPHEP] INNER JOIN ST_NHANVIEN ON [ST_NHANVIENNGHIPHEP].NV_MA = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA LEFT JOIN ST_QUANHUYEN B ON [ST_NHANVIENNGHIPHEP].QH_MA=B.QH_MA AND [ST_NHANVIENNGHIPHEP].TT_MA=B.TT_MA LEFT JOIN ST_XAPHUONG C ON [ST_NHANVIENNGHIPHEP].XP_MA=C.XP_Ma AND [ST_NHANVIENNGHIPHEP].TT_MA=C.TT_MA AND [ST_NHANVIENNGHIPHEP].QH_MA=C.QH_MA LEFT JOIN ST_TINHTHANH D ON [ST_NHANVIENNGHIPHEP].TT_MA=D.TT_Ma WHERE NP_Ma='OM' AND ST_NHANVIEN.[NV_Ma] ='" + obj.MANV + "'")
        End If
        ''Load tinh thanh
        If obj.ChonBang = 61 Then
            strSQL = ("SELECT * FROM ST_TINHTHANH WHERE TT_MA <> ' ' ORDER BY TT_Ten ASC ")
        End If

        If obj.ChonBang = 611 Then
            strSQL = ""
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " where TT_MA = N'" & Me.QuoteString(obj.ID) & "'")
            End If
            strSQL = ("select * from ST_QUANHUYEN where TT_MA = N'" & Me.QuoteString(obj.ID) & " ' ORDER BY QH_TEN ASC")
        End If

        If obj.ChonBang = 612 Then
            strSQL = "select ST_XAPHUONG.XP_MA, ST_XAPHUONG.XP_TEN"
            strSQL = strSQL + " from ST_XAPHUONG "
            strSQL = strSQL + " where ST_XAPHUONG.QH_MA = N'" & Me.QuoteString(obj.ID) & "' AND ST_XAPHUONG.TT_Ma = N'" & Me.QuoteString(obj.TinhThanh) & "'"
            strSQL = strSQL + " ORDER BY ST_XAPHUONG.XP_TEN ASC"
        End If

        If obj.ChonBang = 613 Then
            strSQL = "SELECT A.TT_MA,A.QH_MA,A.XP_MA,D.TT_Ten,B.QH_TEN,C.XP_Ten"
            strSQL = strSQL + " FROM ST_NHANVIENNGHIPHEP A LEFT JOIN ST_QUANHUYEN B ON A.QH_MA=B.QH_MA AND A.TT_MA=B.TT_MA "
            strSQL = strSQL + " LEFT JOIN ST_XAPHUONG C ON A.XP_MA=C.XP_Ma AND A.TT_MA=C.TT_MA AND A.QH_MA=C.QH_MA "
            strSQL = strSQL + " LEFT JOIN ST_TINHTHANH D ON A.TT_MA=D.TT_Ma "
            strSQL = strSQL + " WHERE NV_Ma='' AND NP_Ma='OM' AND NP_TUNGAY='' AND A.TT_MA IS NOT NULL "
            'strSQL = strSQL + " where ST_XAPHUONG.QH_MA = N'" & Me.QuoteString(obj.ID) & "' AND ST_XAPHUONG.TT_Ma = N'" & Me.QuoteString(obj.TinhThanh) & "'"
            'strSQL = strSQL + " ORDER BY ST_XAPHUONG.XP_TEN ASC"
        End If

        If obj.ChonBang = 7 Then
            ''ngay sua: 21/01/2014
            ''nguoi sua: Tran
            ''noi dung: Kiem tra khoa chinh va ngay phep long nhau thay = thu tuc
            strSQL = ("SELECT [NV_Ma]  FROM [ST_NHANVIENNGHIPHEP] WHERE NV_MA = '" + obj.MANV + "' AND (NP_TuNgay = '" + obj.TuNgay + "' OR '" + obj.TuNgay + "' BETWEEN NP_TuNgay AND NP_DenNgay " + " OR '" + obj.DenNgay + "' BETWEEN NP_TuNgay AND NP_DenNgay OR ('" & obj.DenNgay & "' >= NP_DenNgay  AND NP_TuNgay >='" & obj.TuNgay & "'))")
        End If
        ''kiem tra co thoi viec hay khong
        '' Co: don vi (DV_MA) la NV hay T?
        '' Khong: da dieu dong sang T thi lay T, 
        If obj.ChonBang = 9 Then
            strSQL = (" SELECT NV_Ma, TV_NGAYTHOIVIEC=ISNULL((CONVERT(NVARCHAR(10),TV_NGAYTHOIVIEC,105)),''),* FROM [ST_NHANVIENTHOIVIEC] WHERE [NV_MA]  =  '" + obj.MANV + "'")
        End If

        If obj.ChonBang = 10 Then
            strSQL = " DECLARE @NGAY  NVARCHAR(10) "
            strSQL = strSQL + " EXEC SP_LAYNGAYHT @NGAY OUTPUT "
        End If

        If obj.ChonBang = 11 Then
            ''ngay sua : 11/7/2013
            ''nguoi sua: Tran
            ''lay so luong theo don vi dieu dong khi nhap don vi, nhung nguoi da nghi truoc do bo ra
            ''lay ten dang nhap 
            obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
            strSQL = ("SELECT [NV_Ma],DV_MA_,DV_MA  FROM [ST_NHANVIEN] WHERE DV_MA_ ='" + obj.DonVi + "' AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma]) AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0")
        End If

        If obj.ChonBang = 12 Then
            ''ngay sua : 11/7/2013
            ''nguoi sua: Tran, gam(thêm cột xin con nuôi)
            ''xem phep theo don vi DIEU DONG. N
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,ST_NHANVIEN.NV_TEN,[NP_TuNgay],[NP_DenNgay],ST_NHANVIEN.[DV_MA_] AS DV_MA,[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_ FROM [ST_NHANVIEN] LEFT JOIN  [ST_NHANVIENNGHIPHEP] ON ([ST_NHANVIEN].NV_Ma = [ST_NHANVIENNGHIPHEP].NV_MA ) LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA  WHERE ST_NHANVIEN.DV_MA_ =  '" + obj.DonVi + "' AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma])AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND YEAR(NP_TUNGAY) BETWEEN " & Now().Year - 1 & "  AND " & Now().Year & " order by [NP_TuNgay] ")
        End If

        If obj.ChonBang = 1222 Then
            ''ngay sua : 11/7/2013
            ''nguoi sua: Tran, gam(thêm cột xin con nuôi)
            ''xem phep theo don vi DIEU DONG. N
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,ST_NHANVIEN.NV_TEN,[NP_TuNgay],[NP_DenNgay],ST_NHANVIEN.[DV_MA_] AS DV_MA,[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_,D.TT_Ten,B.QH_TEN,C.XP_Ten FROM [ST_NHANVIEN] LEFT JOIN  [ST_NHANVIENNGHIPHEP] ON ([ST_NHANVIEN].NV_Ma = [ST_NHANVIENNGHIPHEP].NV_MA ) LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA LEFT JOIN ST_QUANHUYEN B ON [ST_NHANVIENNGHIPHEP].QH_MA=B.QH_MA AND [ST_NHANVIENNGHIPHEP].TT_MA=B.TT_MA LEFT JOIN ST_XAPHUONG C ON [ST_NHANVIENNGHIPHEP].XP_MA=C.XP_Ma AND [ST_NHANVIENNGHIPHEP].TT_MA=C.TT_MA AND [ST_NHANVIENNGHIPHEP].QH_MA=C.QH_MA LEFT JOIN ST_TINHTHANH D ON [ST_NHANVIENNGHIPHEP].TT_MA=D.TT_Ma WHERE ST_NHANVIENNGHIPHEP.NP_MA='OM' AND ST_NHANVIEN.DV_MA_ =  '" + obj.DonVi + "' AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma])AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND YEAR(NP_TUNGAY) BETWEEN " & Now().Year - 1 & "  AND " & Now().Year & " order by [NP_TuNgay] ")
        End If

        If obj.ChonBang = 122 Then ''toàn công ty
            ''ngay sua : 11/7/2013
            ''nguoi sua: Tran, gấm (thêm cột xin con nuôi)
            ''xem phep theo don vi DIEU DONG. N
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,ST_NHANVIEN.NV_TEN,[NP_TuNgay],[NP_DenNgay],ST_NHANVIEN.[DV_MA_] AS DV_MA,[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_ FROM [ST_NHANVIEN] LEFT JOIN  [ST_NHANVIENNGHIPHEP] ON ([ST_NHANVIEN].NV_Ma = [ST_NHANVIENNGHIPHEP].NV_MA ) LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA WHERE ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma])AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND NP_TUNGAY BETWEEN '" & obj.TuNgay & "'  AND '" & obj.DenNgay & "'  order by st_nhanvien.nv_ma")
        End If

        If obj.ChonBang = 1221 Then ''toàn công ty
            ''ngay sua : 11/7/2013
            ''nguoi sua: Tran, gấm (thêm cột xin con nuôi)
            ''xem phep theo don vi DIEU DONG. N
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,ST_NHANVIEN.NV_TEN,[NP_TuNgay],[NP_DenNgay],ST_NHANVIEN.[DV_MA_] AS DV_MA,[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],[NP_XINCONNUOI],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)),NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103)),ST_DONVI.X_MA_,D.TT_Ten,B.QH_TEN,C.XP_Ten FROM [ST_NHANVIEN] LEFT JOIN  [ST_NHANVIENNGHIPHEP] ON ([ST_NHANVIEN].NV_Ma = [ST_NHANVIENNGHIPHEP].NV_MA ) LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma INNER JOIN ST_DONVI ON  ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA LEFT JOIN ST_QUANHUYEN B ON [ST_NHANVIENNGHIPHEP].QH_MA=B.QH_MA AND [ST_NHANVIENNGHIPHEP].TT_MA=B.TT_MA LEFT JOIN ST_XAPHUONG C ON [ST_NHANVIENNGHIPHEP].XP_MA=C.XP_Ma AND [ST_NHANVIENNGHIPHEP].TT_MA=C.TT_MA AND [ST_NHANVIENNGHIPHEP].QH_MA=C.QH_MA LEFT JOIN ST_TINHTHANH D ON [ST_NHANVIENNGHIPHEP].TT_MA=D.TT_Ma WHERE ST_NHANVIENNGHIPHEP.NP_MA='OM' AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma])AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 AND NP_TUNGAY BETWEEN '" & obj.TuNgay & "'  AND '" & obj.DenNgay & "'  order by st_nhanvien.nv_ma")
        End If

        If obj.ChonBang = 13 Then
            ''cap nhat toan cong ty
            ''ngay sua : 21/01/2014
            ''nguoi sua: Tran
            ''loc so nguoi toan cong ty theo don vi dieu dong
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,DV_MA =( CASE WHEN (ST_NHANVIEN.DV_MA IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(IT_DDNGHIVIEC,0) = 1 ) THEN ST_NHANVIEN.DV_MA ELSE ST_NHANVIEN.DV_MA_ END)")
            strSQL = strSQL + " WHERE NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma])"
            strSQL = strSQL + " AND ([ST_NHANVIEN].DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1) AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 )"
            strSQL = strSQL + " AND EXISTS (SELECT * FROM ST_DONVI WHERE ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA AND N_MA NOT IN ('CG','BGD','') AND DV_LocBB = 0)"
        End If
        If obj.ChonBang = 14 Then
            ''xem du lieu toan cong ty
            strSQL = ("SELECT ST_NHANVIEN.NV_MA,[NP_TuNgay],[NP_DenNgay],ST_NHANVIEN.DV_MA,[NP_Ma],[NP_GhiChu],[NP_CONGTYDUYET],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,105)),NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,105)) FROM [ST_NHANVIENNGHIPHEP],[ST_NHANVIEN] WHERE  [ST_NHANVIENNGHIPHEP].NV_MA=[ST_NHANVIEN].NV_MA AND YEAR(NP_TUNGAY) = " & Now().Year & " AND ST_NHANVIEN.NV_MA  NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)")
        End If

        If obj.ChonBang = 15 Then
            ''kiem tra du lieu con nho co chua
            strSQL = ("SELECT TUNGAY,DENNGAY,NV_MA,DV_MA FROM IT_NUOICONDUOI12THANG WHERE NV_MA ='" & obj.MANV & "' AND TUNGAY='" & obj.TuNgay & "' AND DENNGAY ='" & obj.DenNgay & "'")
        End If

        If obj.ChonBang = 16 Then
            ''kiem tra tu ngay co trong du lieu con nho co chua
            strSQL = ("SELECT TUNGAY,DENNGAY,NV_MA,DV_MA FROM IT_NUOICONDUOI12THANG WHERE NV_MA ='" & obj.MANV & "' AND TUNGAY='" & obj.TuNgay & "'")
        End If

        If obj.ChonBang = 17 Then
            ''kiem tra dang cham cong nuoi con khong
            strSQL = ("select * FROM IT_NUOICONDUOI12THANG WHERE '" & obj.NGAYCHAMCONG & "' BETWEEN CONVERT(DATETIME,NGAYSANH,103) AND DATEADD(M,12,CONVERT(DATETIME,NGAYSANH,103)) AND NV_MA ='" & obj.MANV & "' AND CHONNGAYSANH= 1 ")
        End If
        If obj.ChonBang = 18 Then
            strSQL = ("select convert(nvarchar(50),GETDATE(),20) as NGAY ")
        End If
        ''================= kiem tra dl mang thai va so lan ts
        If obj.ChonBang = 19 Then
            ''xem du lieu toan cong ty
            strSQL = (" SELECT ST_NHANVIENNGHIPHEP.NV_MA,COUNT(NV_MA) AS SODONG")
            strSQL = strSQL + " FROM ST_NHANVIENNGHIPHEP WHERE ST_NHANVIENNGHIPHEP.NV_MA ='" & obj.MANV & "' AND NP_MA='TS'"
            strSQL = strSQL + " GROUP BY ST_NHANVIENNGHIPHEP.NV_MA "
            strSQL = strSQL + " HAVING COUNT(ST_NHANVIENNGHIPHEP.NV_MA) <= (SELECT COUNT(NV_MA) AS SOLANTS "
            strSQL = strSQL + " FROM IT_PNMT WHERE IT_PNMT.NV_MA ='" & obj.MANV & "'"
            strSQL = strSQL + " GROUP BY IT_PNMT.NV_MA)"
        End If
        If obj.ChonBang = 20 Then
            strSQL = ("SELECT [NV_Ma] FROM [ST_NHANVIENNGHIPHEP] WHERE NV_MA = '" + obj.MANV + "' AND NP_TuNgay = '" + obj.TuNgayCu + "'")
        End If
        ''kiem tra co ngay sanh chua luc xoa dong TS ra
        If obj.ChonBang = 21 Then
            ''xem du lieu toan cong ty
            strSQL = ("SELECT NVNP.NV_MA,TUNGAY,DENNGAY,NGAYSANH FROM ST_NHANVIENNGHIPHEP AS NVNP ")
            strSQL = strSQL + " INNER JOIN IT_NUOICONDUOI12THANG "
            strSQL = strSQL + " ON (IT_NUOICONDUOI12THANG.NV_MA = NVNP.NV_Ma "
            strSQL = strSQL + " AND NVNP.NP_TuNgay = IT_NUOICONDUOI12THANG.TUNGAY "
            strSQL = strSQL + " AND IT_NUOICONDUOI12THANG.DENNGAY = NVNP.NP_DenNgay "
            strSQL = strSQL + " AND IT_NUOICONDUOI12THANG.NV_MA = NVNP.NV_Ma) "
            strSQL = strSQL + " WHERE  ISNULL(NGAYSANH,'') <> '' AND NP_Ma ='TS'"
            strSQL = strSQL + " AND NVNP.NV_Ma ='" & obj.MANV & "' AND TUNGAY ='" & obj.TuNgay & "'"
        End If
        ''luu tru ngay sanh truoc khi xoa
        If obj.ChonBang = 22 Then
            strSQL = ("SELECT * FROM IT_NUOICONDUOI12THANG WHERE NV_MA ='" & obj.MANV & "' AND TUNGAY='" & obj.TuNgay & "' AND DENNGAY ='" & obj.DenNgay & "'")
        End If

        ''Xoa phep don vi: kiem tra phep cua don vi do co nhap khong
        If obj.ChonBang = 23 Then
            strSQL = ("SELECT * FROM ST_NHANVIENNGHIPHEP WHERE NV_MA IN (SELECT NV_MA FROM ST_NHANVIEN inner join ST_DONVI on ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA and ST_DONVI.DV_LocBB = 0 and ST_DONVI.DV_TV <> 1 WHERE ST_NHANVIEN.DV_MA_ = '" & obj.DonVi & "') AND NP_TuNgay='" & obj.TuNgay & "' AND NP_DenNgay='" & obj.DenNgay & "' AND NP_MA ='" & obj.LoaiPhep & "' ")
            obj_D.TruyVan = strSQL
            obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        End If

        ''hien thi tong so nguoi theo don vi dieu dong
        If obj.ChonBang = 24 Then
            If obj.DonVi <> "" And (obj.DonVi = "T" Or obj.DonVi = "T01" Or obj.DonVi = "T02" Or obj.DonVi = "T03" Or obj.DonVi = "TST" Or obj.DonVi = "T01ST" Or obj.DonVi = "T02ST" Or obj.DonVi = "T03ST" Or obj.DonVi = "B 01ST" Or obj.DonVi = "B 02ST" Or obj.DonVi = "B 03ST" Or obj.DonVi = "B ST" Or obj.DonVi = "B T" Or obj.DonVi = "B T01" Or obj.DonVi = "B T02" Or obj.DonVi = "B T03") Then
                ''so luong dieu dong theo T
                strSQL = ("SELECT COUNT(ST_NHANVIEN.NV_MA) AS SLNV FROM [ST_NHANVIEN] WHERE ST_NHANVIEN.DV_MA = '" & obj.DonVi & "'  AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma]) AND  ISNULL(IT_DDNGHIVIEC,0) = 1")
            Else
                ''so luong dieu dong theo dv_ma_
                strSQL = ("SELECT COUNT(ST_NHANVIEN.NV_MA) AS SLNV FROM [ST_NHANVIEN] WHERE ST_NHANVIEN.DV_MA_ = '" & obj.DonVi & "' AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM ST_DONVI WHERE DV_TV = 1 OR DV_MA LIKE 'NV%') AND NOT EXISTS (SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC TV WHERE TV.NV_Ma = ST_NHANVIEN.[NV_Ma]) AND  ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0")
            End If
        End If
        ''=================== PHAN QUYEN THEM XOA SUA FORM NHAP PHEP =================''
        If obj.ChonBang = 26 Then
            strSQL = ("SELECT * from JELL_USER WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
        End If
        If obj.ChonBang = 27 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "' AND (Ma_DM ='1frmKiemTraPhepNam' OR Ma_DM ='2frmKiemTraPhepNam') ")
        End If
        ''============ truy van thong tin tab2: kiem tra phep OM,CO ========''

        If obj.ChonBang = 29 Then
            strSQL = ("SELECT ST_NHANVIEN.NV_Ma,NV_Ten,ST_NHANVIEN.DV_MA,DV_MA_ ,NV_Ngayvao=(CONVERT(NVARCHAR(10),NV_NGAYVAO,105)),DATHOIVIEC = (CASE WHEN TV_NGAYTHOIVIEC IS NULL THEN 0 ELSE 1 END),TV_NgayThoiViec = CONVERT (varchar(10),TV_NgayThoiViec,105) ,ST_LOAITHOIVIEC.LTV_Ten ,TV_LyDo,IT_DDNGHIVIEC = ISNULL (IT_DDNGHIVIEC,0)  ")
            strSQL = strSQL + " FROM ST_NHANVIEN "
            strSQL = strSQL + " LEFT JOIN ST_NHANVIENTHOIVIEC ON ST_NHANVIEN.NV_Ma = ST_NHANVIENTHOIVIEC.NV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_LOAITHOIVIEC ON ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_Ma "
            strSQL = strSQL + " LEFT JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA='" + obj.MANV + "'"

        End If
     
 
        If obj.ChonBang = 32 Then
            Dim namtruoc, namsau As Integer
            namtruoc = CInt(obj.NAM) - 1
            namsau = CInt(obj.NAM) + 1

            strSQL = "SELECT ST_NHANVIEN.NV_MA,[NP_TuNgay] ,[NP_DenNgay],ST_NHANVIEN.[DV_MA_] AS DV_MA"
            strSQL = strSQL + " ,[ST_NHANVIENNGHIPHEP].DV_MA AS DV_MA_LUOI,[NP_Ma] "
            strSQL = strSQL + " ,[NP_GhiChu],[NP_CONGTYDUYET],NP_NGAYNHAPPHEP=(CONVERT(NVARCHAR(10),NP_NGAYNHAPPHEP,103)) "
            strSQL = strSQL + " ,NP_NGAYNHAPSUA=(CONVERT(NVARCHAR(10),NP_NGAYNHAPSUA,103)), NP_NGAYSUA_NS=(CONVERT(NVARCHAR(10),NP_NGAYSUA_NS,103))  "
            strSQL = strSQL + " FROM [ST_NHANVIEN] LEFT JOIN [ST_NHANVIENNGHIPHEP] ON ([ST_NHANVIEN].NV_Ma = [ST_NHANVIENNGHIPHEP].NV_MA )"
            strSQL = strSQL + " WHERE ST_NHANVIENNGHIPHEP.NP_Ma IN('OM','CO')"
            strSQL = strSQL + " AND [ST_NHANVIEN].NV_Ma  ='" & Me.QuoteString(obj.MANV) & "'"
            strSQL = strSQL + " AND ((YEAR(NP_TUNGAY) = '" & namtruoc & "' AND YEAR(NP_DenNgay) = '" & Me.QuoteString(obj.NAM) & "')"
            strSQL = strSQL + " OR (YEAR(NP_TUNGAY) = '" & Me.QuoteString(obj.NAM) & "' AND YEAR(NP_DenNgay) = '" & namsau & "')"
            strSQL = strSQL + " OR YEAR(NP_TUNGAY) = '" & Me.QuoteString(obj.NAM) & "' AND YEAR(NP_DENNGAY) = '" & Me.QuoteString(obj.NAM) & "')"
            strSQL = strSQL + " order by [NP_TuNgay] "
        End If
        ''======= cong viec hien tai theo dbl
        If obj.ChonBang = 33 Then
            strSQL = "SELECT DBL_MAX.NV_Ma,DBL_MAX.DBL_NGAYBATDAU,ST_DIENBIENLUONG.CV_MA,CV_DOCHAI = ISNULL(CV_DOCHAI,0),ST_CONGVIEC.CV_TEN"
            strSQL = strSQL + " FROM (	SELECT NV_MA,MAX(DBL_NGAYBATDAU) AS DBL_NGAYBATDAU FROM ST_DIENBIENLUONG  "
            strSQL = strSQL + " WHERE NV_Ma = '" & Me.QuoteString(obj.MANV) & "' AND YEAR(DBL_NGAYBATDAU)= '" & Me.QuoteString(obj.NAM) & "'"
            strSQL = strSQL + " GROUP BY NV_Ma )AS DBL_MAX INNER JOIN ST_DIENBIENLUONG ON  "
            strSQL = strSQL + " (ST_DIENBIENLUONG.NV_Ma =DBL_MAX.NV_Ma AND ST_DIENBIENLUONG.DBL_Ngaybatdau = DBL_MAX.DBL_NGAYBATDAU )"
            strSQL = strSQL + " LEFT JOIN ST_CONGVIEC ON ST_DIENBIENLUONG.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " WHERE DBL_MAX.NV_Ma = '" & Me.QuoteString(obj.MANV) & "' AND YEAR(DBL_MAX.DBL_NGAYBATDAU) = '" & Me.QuoteString(obj.NAM) & "'"

        End If

        If obj.ChonBang = 71 Then
            strSQL = " SELECT STT=0, ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_NGAYVAO ,NAM ,NU,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_NGAYSINH, ST_NHANVIEN.NV_SOTHANG,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM (SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBA "
            strSQL = strSQL + " UNION"
            strSQL = strSQL + " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBANEW"
            strSQL = strSQL + " UNION"
            strSQL = strSQL + " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBC"
            strSQL = strSQL + " UNION"
            strSQL = strSQL + " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBCNEW"
            strSQL = strSQL + " UNION"
            strSQL = strSQL + " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBOX"
            strSQL = strSQL + " UNION"
            strSQL = strSQL + " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBB) AS BB "
            strSQL = strSQL + " INNER JOIN ST_NHANVIEN ON BB.NV_MA = ST_NHANVIEN.NV_MA  "
            strSQL = strSQL + " WHERE ST_NHANVIEN.DV_MA NOT IN ('T','T01','T02','T03','T04')  AND BB.NAM = '2018'"
            strSQL = strSQL + " ORDER BY  ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 81 Then
            strSQL = "SELECT STT=0,[NV_MA]" & _
                     ",[Tháng năm]=[T_MA]" & _
                     ",[Mã BB]=ISNULL([BB_MA],0)" & _
                     ",[OO]=ISNULL([BB_SoNgayOO],0)" & _
                     ",[RO]=ISNULL([BB_SoNgayRO],0)" & _
                     ",[CO]=ISNULL([BB_SoNgayCO],0)" & _
                     ",[O]=ISNULL([BB_SoNgayO],0)" & _
                     ",[OTC]=ISNULL([BB_SoNgayOTC],0)" & _
                     ",[P]=ISNULL([BB_SoNgayP],0)" & _
                     ",[KT]=ISNULL([BB_SoNgayKThai],0)" & _
                     ",[R]=ISNULL([BB_SoNgayR],0)" & _
                     ",[S]=ISNULL([BB_SoNgayS],0)" & _
                     ",[NO]=ISNULL([BB_SoNgayNo],0)" & _
                     ",[KHHGD]=ISNULL([BB_SoNgayKHHGD],0)" & _
                     ",[QS]=ISNULL([BB_SoNgayQS],0)" & _
                     ",[TS]=ISNULL([BB_SoNgayTSan],0)" & _
                     ",[TNLD]=ISNULL([BB_SoNgayTNLD],0)" & _
                     ",[DQ]=ISNULL([BB_SoNgayDQ],0)" & _
                     ",[DS]=ISNULL([BB_SoNgayDS],0)" & _
                     ",[ST]=ISNULL([BB_SoNgayST],0)" & _
                     "FROM IT_TABLE_BBCT WHERE NAM = '2018' ORDER BY NV_MA"
        End If
        If obj.ChonBang = 82 Then
            strSQL = "select distinct Right(T_MA, 4) as Nam from st_thang"
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
    Public Function SoNgayNghiPhep(ByVal obj As objKiemTraPhepNam, ByVal sLoaiPhep As String) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 28 Then
            strSQL = "SELECT NV_Ma,SONGAY=SUM((DATEDIFF(DAY,NP_TuNgay ,NP_DenNgay ) + 1)),NAM = '" + obj.NAMBD + "' "
            strSQL += " FROM ST_NHANVIENNGHIPHEP WHERE NV_MA ='" + obj.MANV + "'"
            strSQL += " AND NP_Ma = '" + sLoaiPhep + "' AND YEAR(NP_TUNGAY)= YEAR(NP_DENNGAY) "
            strSQL += " AND YEAR(NP_TUNGAY) = '" + obj.NAMBD + "'"
            strSQL += " GROUP BY NV_Ma"
        End If
        If obj.ChonBang = 30 Then
            strSQL = "SELECT * FROM ST_NHANVIENNGHIPHEP "
            strSQL = strSQL + " WHERE NV_MA='" & Me.QuoteString(obj.MANV) & "' AND NP_MA = '" & sLoaiPhep & "'"
            strSQL = strSQL + " AND YEAR(NP_TUNGAY) = YEAR(NP_DENNGAY) "
            strSQL = strSQL + " AND YEAR(NP_TUNGAY) = '" & Me.QuoteString(obj.NAM) & "'"

        End If

        If obj.ChonBang = 31 Then
            strSQL = "SELECT NV_MA ,TONGCONG=((SUM(ISNULL(CC_SOGIONGHI,0)))/8) FROM ST_GIOQUETTHE"
            strSQL = strSQL + " WHERE NV_MA='" & Me.QuoteString(obj.MANV) & "' AND NP_MA = '" & sLoaiPhep & "' AND CC_HESONGAYCONG <> 3"
            strSQL = strSQL + " AND CC_GIOBINHTHUONG < 8"
            strSQL = strSQL + " AND YEAR(QT_NGAY) = '" & Me.QuoteString(obj.NAM) & "' AND DATEPART (DW,QT_NGAY) <> 1"
            strSQL = strSQL + " GROUP BY NV_MA "
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
    Public Function ThuTucKiemTraPhep(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
    End Function
    Public Function XoaPhep(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
    End Function
    Public Function SuaPhep(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
    End Function
    Public Function UpdateInfo(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIENNGHIPHEP set np_denngay =N'", Me.QuoteString(obj.DenNgay), "',dv_ma = N'", Me.QuoteString(obj.DonVi), "',np_ma = N'", Me.QuoteString(obj.LoaiPhep), "',np_ghichu = N'", Me.QuoteString(obj.GhiChu), "',NP_CONGTYDUYET = N'", Me.QuoteString(obj.CONGTYDUYET), "' where nv_ma = N'", Me.QuoteString(obj.MANV), "' and np_Tungay = N'", Me.QuoteString(obj.TuNgay)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
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
    Public Function UpdateInfoNuoiCon(ByVal obj As objKiemTraPhepNam) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update IT_NUOICONDUOI12THANG set DENNGAY =N'", Me.QuoteString(obj.DenNgay), "',dv_ma = N'", Me.QuoteString(obj.DonVi), "' where nv_ma = N'", Me.QuoteString(obj.MANV), "' and tungay = N'", Me.QuoteString(obj.TuNgay)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        obj_D.TruyVan = strSQL
        obj_D.TenDangNhap = frmDangNhap.txtTendangnhap.Text
        Try
            flag = Me.execSQL(strSQL)
            'MessageBox.Show("Đã cập nhật dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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


