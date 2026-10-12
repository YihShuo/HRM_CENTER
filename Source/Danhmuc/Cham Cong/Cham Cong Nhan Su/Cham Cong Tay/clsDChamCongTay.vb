Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDChamCongTay
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objChamCongTay) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_GIOQUETTHE_ where NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND QT_NGAY='" & Me.QuoteString(obj.Ngay)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objChamCongTay) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [ST_GIOQUETTHE_] ([NV_MA] ,[QT_NGAY] ,[QT_GIOVAOTAY] ,[QT_GIORATAY] ,[CA_MA] ,[DV_MA]) SELECT '" + obj.NV_MA + "', '" + obj.Ngay + "', " + obj.GioVaoTay + ", " + obj.GioRaTay + ", '" + obj.CA_Ma + "', [DV_MA] FROM [ST_NHANVIEN] WHERE [NV_MA]='" + obj.NV_MA + "'"}) & " " & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function IsDeleteOK(ByVal obj As objChamCongTay) As Boolean

    End Function

    Public Function LoadDS(ByVal obj As objChamCongTay) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If
        If obj.ChonBang = 10 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 order by dv_ma ")
        End If
          If obj.ChonBang = 20 Then
            strSQL = ("SELECT * FROM ST_DONVI WHERE ISNULL(DV_TV,0) = 1 AND DV_MA= '" & obj.Donvi & "'")
        End If
        'If obj.ChonBang = 21 Then
        '    strSQL = "SELECT JELL_QUYENTRUYCAP.Ma_DM,JELL_QUYENTRUYCAP.KHUA,JELL_QUYENTRUYCAP.KHUB  "
        '    strSQL = strSQL + " FROM [JELL_QUYENTRUYCAP] LEFT JOIN JELL_DANHMUC ON JELL_QUYENTRUYCAP.Ma_DM = JELL_DANHMUC.Ma_DM "
        '    strSQL = strSQL + " WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" + obj.NGUOIDUNG + "' and JELL_DANHMUC.Ma_DM = '" + obj.MA_DM + "'"
        'End If
        'If obj.ChonBang = 22 Then
        '    strSQL = "select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV"
        '    strSQL = strSQL + " from st_donvi  WHERE dv_ma <> 'CNM' AND DV_LOCBB = 0 AND DV_MA NOT LIKE 'B%' order by dv_ma "
        'End If
        'If obj.ChonBang = 23 Then
        '    strSQL = "select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV"
        '    strSQL = strSQL + " from st_donvi  WHERE dv_ma <> 'CNM' AND DV_LOCBB = 0 AND DV_MA LIKE 'B%' order by dv_ma "
        'End If
        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            If obj.DonVi = "TCT" Then
               
                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA_,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "

            ElseIf obj.LoaiDonViNghiViec = 1  Then
                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA_ AS DV_MA_,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN,"
                strSQL += " IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC,"
                strSQL += " IT_TONGGIOCONG.CHENHLECH "
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN IT_TONGGIOCONG ON "
                strSQL += " ST_NHANVIEN.NV_MA=IT_TONGGIOCONG.NV_MA "
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                'strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0) <> 0"
                strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.Ngay + "'"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
            Else
                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA_,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.DonVi + "'"
                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
            End If
        End If

        If obj.ChonBang = 3 Then
          
            strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
            strSQL += " ST_NHANVIEN.DV_MA_,"

            strSQL += " ST_NHANVIEN.NV_MA,"
            strSQL += " ST_NHANVIEN.NV_TEN,"
            strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

            strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
            strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
            strSQL += " ST_GIOQUETTHE_.NP_Ma,"
            strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
            strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
            strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
            strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
            strSQL += " LEFT JOIN ST_VAORA_ ON "
            strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
            strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
            strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
            strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
            strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
            strSQL += " AND ST_NHANVIEN.NV_MA IS NULL"

        End If

        If obj.ChonBang = 4 Then
            strSQL = " select NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], ST_NHANVIEN.DV_MA_, ST_NHANVIENTHOIVIEC.NV_MA,NV_TEN,QT_NGAY, NULL AS GIOVAO, NULL AS GIORA, ST_GIOQUETTHE_.CA_MA AS MACA, CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY, CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIORATAY, NULL AS NGHIVAO, NULL AS NGHIRA, CC_GIOBINHTHUONG,CC_GIOTANGCA,CC_GIOLAMDEM,CC_HESONGAYCONG,NP_Ma,CC_DITRE,CC_QUENQUETTHE, CC_SUATAN"
            strSQL += " from ST_NHANVIENTHOIVIEC, ST_GIOQUETTHE_, ST_NHANVIEN"
            strSQL += " where ST_NHANVIENTHOIVIEC.NV_MA*=ST_GIOQUETTHE_.NV_MA"
            strSQL += " and ST_NHANVIENTHOIVIEC.NV_MA*=ST_NHANVIEN.NV_MA"
            strSQL += " and ST_GIOQUETTHE_.QT_NGAY='" + obj.Ngay + "'"
            strSQL += " and  exists (select * from ST_NHANVIEN where ST_NHANVIENTHOIVIEC.NV_MA=ST_NHANVIEN.NV_MA and month(TV_Ngaythoiviec)= '" + obj.Thang + "'  and year(TV_Ngaythoiviec)= '" + obj.Nam + "' )"
        End If

        If obj.ChonBang = 5 Then
            strSQL = " SELECT * FROM ST_GIOQUETTHE_ WHERE QT_NGAY = '" + obj.Ngay + "' AND NV_MA = '" + obj.NV_MA + "'"
        End If

        If obj.ChonBang = 6 Then
            strSQL = " select NX_MA from ST_NHAXUONG"
        End If

        If obj.ChonBang = 7 Then
            strSQL = " select N_MA, N_TEN from ST_NGANH"
        End If
        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 9 Then

            If obj.DonVi = "TCT" Then

                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                'strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0) <> 0"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "

              ElseIf obj.LoaiDonViNghiViec = 1  Then
                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA_ AS DV_MA_,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN,"
                strSQL += " IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC,"
                strSQL += " IT_TONGGIOCONG.CHENHLECH "
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN IT_TONGGIOCONG ON "
                strSQL += " ST_NHANVIEN.NV_MA=IT_TONGGIOCONG.NV_MA "
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                'strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0) <> 0"
                strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.Ngay + "'"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
             Else
                strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
                strSQL += " ST_NHANVIEN.DV_MA,"

                strSQL += " ST_NHANVIEN.NV_MA,"
                strSQL += " ST_NHANVIEN.NV_TEN,"
                strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

                strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
                strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
                strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
                strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
                strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
                strSQL += " ST_GIOQUETTHE_.NP_Ma,"
                strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
                strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
                strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
                strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
                strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
                strSQL += " LEFT JOIN ST_VAORA_ ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
                strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
                strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
                strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
                strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
                strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                'strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0) <> 0"
                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
            End If
        End If
        If obj.ChonBang = 3 Then

            strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
            strSQL += " ST_NHANVIEN.DV_MA,"

            strSQL += " ST_NHANVIEN.NV_MA,"
            strSQL += " ST_NHANVIEN.NV_TEN,"
            strSQL += " ST_GIOQUETTHE_.QT_NGAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIOVAO,108) AS GIOVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_.QT_GIORA,108) AS GIORA,"

            strSQL += " ST_GIOQUETTHE_.CA_MA AS MACA,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE_.QT_GIORATAY,108) AS GIORATAY,"

            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOBINHTHUONG,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOTANGCA,"
            strSQL += " ST_GIOQUETTHE_.CC_GIOLAMDEM,"
            strSQL += " ST_GIOQUETTHE_.CC_HESONGAYCONG,"
            strSQL += " ST_GIOQUETTHE_.NP_Ma,"
            strSQL += " ST_GIOQUETTHE_.CC_DITRE, "
            strSQL += " ST_GIOQUETTHE_.CC_QUENQUETTHE,"
            strSQL += " ST_GIOQUETTHE_.CC_SUATAN"
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE_ ON "
            strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE_.NV_MA "
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = '" + obj.Ngay + "')"
            strSQL += " LEFT JOIN ST_VAORA_ ON "
            strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_.NV_MA"
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_.QT_NGAY"
            strSQL += " AND ST_GIOQUETTHE_.CA_MA = ST_VAORA_.CA_MA)"
            strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
            strSQL += " (ST_GIOQUETTHE_.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
            strSQL += " AND ST_GIOQUETTHE_.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
            strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
            strSQL += " AND ST_NHANVIEN.NV_MA IS NULL"

        End If
        If obj.ChonBang = 12 Then
            Dim n, t, ng, i As Integer
            n = obj.Nam
            t = obj.Thang
            ng = obj.Ngay

            strSQL = "SELECT TONGGIOCONG=SUM(TONGGIOCONG),CHENHLECH=300-SUM(TONGGIOCONG) FROM(SELECT TONGGIOCONG=SUM("
            For i = 1 To 31
                strSQL = String.Format("{0}isnull(giotangca_{1},0)+", strSQL, i)
            Next
            strSQL = String.Format("{0} ", strSQL.Substring(0, strSQL.Length - 1))
            strSQL = strSQL + ") "
            strSQL = String.Format("{0}FROM ST_VAORA_MACHINE INNER JOIN   ST_NHANVIEN ", strSQL)
            strSQL = String.Format("{0}ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA ", strSQL)
            strSQL = String.Format("{0}WHERE DV_MA<>'VPCT' AND DV_MA = '{1}' AND NV_MA = '{2}' ", strSQL, obj.DonVi, obj.NV_MA)
            strSQL = String.Format("{0}AND NAM={1} AND THANG<{2} ", strSQL, n, t)
            strSQL = strSQL + " UNION SELECT TONGGIOCONG=SUM("
            For i = 1 To ng
                strSQL = String.Format("{0}isnull(giotangca_{1},0)+", strSQL, i)
            Next
            strSQL = String.Format("{0} ", strSQL.Substring(0, strSQL.Length - 1))
            strSQL = strSQL + ") "
            strSQL = String.Format("{0}FROM ST_VAORA_MACHINE INNER JOIN   ST_NHANVIEN ", strSQL)
            strSQL = String.Format("{0}ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA ", strSQL)
            strSQL = String.Format("{0}WHERE DV_MA<>'VPCT' AND DV_MA = '{1}' AND NV_MA = '{2}' ", strSQL, obj.DonVi, obj.NV_MA)
            strSQL = String.Format("{0}AND NAM={1} AND THANG={2}) AS V ", strSQL, n, t)
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

    Public Function PhatSinhMa() As String
        
    End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfo(ByVal obj As objChamCongTay) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [CC_SUATAN] = " + obj.ChamCom + " WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
        '= "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE [ST_GIOQUETTHE_]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"}) & " " & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
