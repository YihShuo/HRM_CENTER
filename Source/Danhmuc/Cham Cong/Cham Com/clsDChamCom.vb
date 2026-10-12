Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDChamCom
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objChamCom) As Boolean
        Dim strSQL As String
            If obj.ChonBang = 1 Then
            strSQL = "delete from ST_GIOQUETTHE where NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND QT_NGAY='" & Me.QuoteString(obj.Ngay) & "'"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "delete from IT_TONGGIOCONG where NV_MA = '" & Me.QuoteString(obj.NV_MA) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objChamCom) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO [ST_GIOQUETTHE] ([NV_MA] ,[QT_NGAY] ,[QT_GIOVAOTAY] ,[QT_GIORATAY] ,[CA_MA] ,[DV_MA]) SELECT '" + obj.NV_MA + "', '" + obj.Ngay + "', " + obj.GioVaoTay + ", " + obj.GioRaTay + ", '" + obj.CA_Ma + "', [DV_MA] FROM [ST_NHANVIEN] WHERE [NV_MA]='" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "INSERT INTO [IT_TONGGIOCONG] ([NV_MA] ,[NAM] ,[TONGGIOCONG] ,[CHENHLECH]) VALUES ('" + obj.NV_MA + "', '" + obj.Nam + "', '" + obj.TongGioCong + "', '" + obj.ChenhLech + "'" + ")" + ""
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

    Public Function IsDeleteOK(ByVal obj As objChamCom) As Boolean

    End Function

    Public Function LoadDS(ByVal obj As objChamCom) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = "select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV"
            strSQL = strSQL + " from st_donvi  WHERE dv_ma <> 'CNM' and DV_LOCBB = 0 order by dv_ma "
        End If

        If obj.ChonBang = 10 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' and DV_LOCBB = 0 order by dv_ma ")
        End If
        If obj.ChonBang = 20 Then
            strSQL = ("SELECT * FROM ST_DONVI WHERE ISNULL(DV_TV,0) = 1 AND DV_MA= '" & obj.DonVi & "'")
        End If

        ''load don vi khu A
        If obj.ChonBang = 21 Then

            strSQL = ("SELECT DV_MA,TEN_DV FROM ")
            strSQL += " ("
            strSQL += " SELECT TT=1,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI"
            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'A'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV <> 1"
            strSQL += " UNION "
            strSQL += " SELECT TT=2,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI "

            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'A'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV = 1"
            strSQL += " ) AS DV"
            strSQL += " ORDER BY  TT,DV.DV_MA "

        End If
        ''load don vi khu B
        If obj.ChonBang = 22 Then
            strSQL = ("SELECT DV_MA,TEN_DV FROM ")
            strSQL += " ("
            strSQL += " SELECT TT=1,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI"
            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'B'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV <> 1"
            strSQL += " UNION "
            strSQL += " SELECT TT=2,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI "

            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'B'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV = 1"
            strSQL += " ) AS DV"
            strSQL += " ORDER BY  TT,DV.DV_MA "
        End If
        If obj.ChonBang = 23 Then
            strSQL = ("SELECT DV_MA,TEN_DV FROM ")
            strSQL += " ("
            strSQL += " SELECT TT=1,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI"
            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'DVC'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV <> 1"
            strSQL += " UNION "
            strSQL += " SELECT TT=2,DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI "

            strSQL += " WHERE DV_MA NOT LIKE 'NV%' AND KHU = 'DVC'"
            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%' AND DV_LocBB = 0 AND DV_TV = 1"
            strSQL += " ) AS DV"
            strSQL += " ORDER BY  TT,DV.DV_MA "
        End If
        'Load danh sach nhan vien theo don vi
        If obj.ChonBang = 2 Then

            ''-----------------------------
            strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "

           
            strSQL += " ST_NHANVIEN.DV_MA_ ,"
            strSQL += " ST_NHANVIEN.NV_MA,"
            strSQL += " ST_NHANVIEN.NV_TEN,"
            strSQL += " ST_GIOQUETTHE.QT_NGAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) AS GIOVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) AS GIORA,"

            strSQL += " ST_GIOQUETTHE.CA_MA AS MACA,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIORATAY,108) AS GIORATAY,"

            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOBINHTHUONG,"
            strSQL += " ST_GIOQUETTHE.CC_GIOTANGCA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOLAMDEM,"
            strSQL += " ST_GIOQUETTHE.CC_HESONGAYCONG,"
            strSQL += " ST_GIOQUETTHE.NP_Ma,"
            strSQL += " ST_GIOQUETTHE.CC_DITRE, "
            strSQL += " ST_GIOQUETTHE.CC_QUENQUETTHE,"
            strSQL += " ST_GIOQUETTHE.CC_SUATAN,"
            strSQL += " IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC,"
            strSQL += " IT_TONGGIOCONG.CHENHLECH "
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE ON "
            strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE.NV_MA "

            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = '" + obj.Ngay + "'"
            ''---------------------
            strSQL += " AND QT_NGAY >= ST_NHANVIEN.NV_Ngayvao )"

            strSQL += " LEFT JOIN IT_TONGGIOCONG ON "
            strSQL += " ST_NHANVIEN.NV_MA=IT_TONGGIOCONG.NV_MA AND NAM = '" + obj.Nam + "'"

            strSQL += " LEFT JOIN ST_VAORA ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA.QT_NGAY"
            strSQL += " AND ST_GIOQUETTHE.CA_MA = ST_VAORA.CA_MA"
            ''---------------------
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY >= '" + obj.Ngay + "'"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY <= '" + obj.Ngay + "')"
            ''---------------------
            strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
            strSQL += " WHERE NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "'"
            strSQL += " AND TV_NgayThoiViec >= NV_Ngayvao)"
            strSQL += " AND ST_NHANVIEN.NV_MA IS NOT NULL"
            strSQL += " AND ST_NHANVIEN.NV_Ngayvao <='" + obj.Ngay + "'"

            ''-----------------------------

            Select Case obj.ChonKhu ''RADIO
                Case "CHONRADIOTCT"

                    Select Case obj.DonVi   ''----COMBO 
                        Case "TCT"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"

                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"

                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "


                        Case "KHUA"  '' TOÀN BỘ KHU A

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "

                        Case "KHUB" '' TOÀN BỘ KHU B

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                        Case "KHUDVC" '' TOÀN BỘ KHU DVC

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "

                                End If
                            End If

                          
                    End Select

                Case "CHONRADIOKHUA"
                    Select Case obj.DonVi   ''----COMBO 
                        Case "KHUA"  '' TOÀN BỘ KHU A

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0 "
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If

                            End If

                    End Select


                Case "CHONRADIOKHUB"
                    Select Case obj.DonVi   ''----COMBO 

                        Case "KHUB" '' TOÀN BỘ KHU B

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select
                Case "CHONRADIODVC"
                    Select Case obj.DonVi   ''----COMBO 

                        Case "KHUDVC" '' TOÀN BỘ KHU B

                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select
            End Select
        End If


        If obj.ChonBang = 4 Then
            ''-----------------------------
            strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "

            If obj.LoaiDonViNghiViec = 1 Then
                strSQL += " ST_NHANVIEN.DV_MA as DV_MA_ ,"
            Else
                strSQL += " ST_NHANVIEN.DV_MA_ ,"
            End If

            strSQL += " ST_NHANVIEN.NV_MA,"
            strSQL += " ST_NHANVIEN.NV_TEN,"
            strSQL += " ST_GIOQUETTHE.QT_NGAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) AS GIOVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) AS GIORA,"

            strSQL += " ST_GIOQUETTHE.CA_MA AS MACA,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIORATAY,108) AS GIORATAY,"

            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOBINHTHUONG,"
            strSQL += " ST_GIOQUETTHE.CC_GIOTANGCA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOLAMDEM,"
            strSQL += " ST_GIOQUETTHE.CC_HESONGAYCONG,"
            strSQL += " ST_GIOQUETTHE.NP_Ma,"
            strSQL += " ST_GIOQUETTHE.CC_DITRE, "
            strSQL += " ST_GIOQUETTHE.CC_QUENQUETTHE,"
            strSQL += " ST_GIOQUETTHE.CC_SUATAN,"
            strSQL += " IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC,"
            strSQL += " IT_TONGGIOCONG.CHENHLECH "

            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE ON "
            strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE.NV_MA "
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = '" + obj.Ngay + "'"

            ''---------------------
            strSQL += " AND QT_NGAY >= ST_NHANVIEN.NV_Ngayvao )"

            strSQL += " LEFT JOIN IT_TONGGIOCONG ON "
            strSQL += " ST_NHANVIEN.NV_MA=IT_TONGGIOCONG.NV_MA AND NAM = '" + obj.Nam + "'"

            strSQL += " LEFT JOIN ST_VAORA ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA.QT_NGAY"
            strSQL += " AND ST_GIOQUETTHE.CA_MA = ST_VAORA.CA_MA"
            ''---------------------
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY >= '" + obj.Ngay + "'"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY <= '" + obj.Ngay + "')"
            ''---------------------
            strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
            strSQL += " WHERE NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "'"
            strSQL += " AND TV_NgayThoiViec >= NV_Ngayvao)"
            strSQL += " AND ST_NHANVIEN.NV_MA IS NOT NULL"
            strSQL += " AND ST_NHANVIEN.NV_Ngayvao <='" + obj.Ngay + "'"

            ''-----------------------------

            Select Case obj.ChonKhu ''RADIO
                Case "CHONRADIOTCT"

                    Select Case obj.DonVi   ''----COMBO 
                        Case "TCT"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "


                        Case "KHUA"  '' TOÀN BỘ KHU A
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "


                        Case "KHUB" '' TOÀN BỘ KHU B
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "
                        Case "KHUDVC" '' TOÀN BỘ KHU DVC
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select

                Case "CHONRADIOKHUA"
                    Select Case obj.DonVi   ''----COMBO 
                        Case "KHUA"  '' TOÀN BỘ KHU A
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "
                          

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select
                Case "CHONRADIODVC"
                    Select Case obj.DonVi   ''----COMBO 
                        Case "KHUDVC"  '' TOÀN BỘ KHU A
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "


                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select


                Case "CHONRADIOKHUB"
                    Select Case obj.DonVi   ''----COMBO 

                        Case "KHUB" '' TOÀN BỘ KHU B
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_MA "

                        Case Else ''CHỌN ĐƠN VỊ <> tct, TB A, TB B

                            If obj.LoaiDonViNghiViec = 1 Then ''đơn vị nghỉ việc
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.DV_MA_,ST_NHANVIEN.NV_MA "
                            Else
                                If obj.DonVi = "CNM" Then  ''đơn vị CNM
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                Else
                                    strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.DonVi + "'"
                                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                                End If
                            End If
                    End Select
            End Select

        End If


        If obj.ChonBang = 3 Then
            strSQL = " SELECT NULL AS [1], CONVERT(BIT,'0') AS [2], NULL AS [3], "
            strSQL += " ST_NHANVIEN.DV_MA_,"
            strSQL += " ST_NHANVIEN.NV_MA,"
            strSQL += " ST_NHANVIEN.NV_TEN,"
            strSQL += " ST_GIOQUETTHE.QT_NGAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) AS GIOVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) AS GIORA,"
            strSQL += " ST_GIOQUETTHE.CA_MA AS MACA,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIOVAOTAY,108) AS GIOVAOTAY,"
            strSQL += " CONVERT(CHAR(8),ST_GIOQUETTHE.QT_GIORATAY,108) AS GIORATAY,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIVAO,108) AS NGHIVAO,"
            strSQL += " CONVERT(CHAR(8),ST_VAORA_MACHINE_NEW.QT_NGHIRA,108) AS NGHIRA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOBINHTHUONG,"
            strSQL += " ST_GIOQUETTHE.CC_GIOTANGCA,"
            strSQL += " ST_GIOQUETTHE.CC_GIOLAMDEM,"
            strSQL += " ST_GIOQUETTHE.CC_HESONGAYCONG,"
            strSQL += " ST_GIOQUETTHE.NP_Ma,"
            strSQL += " ST_GIOQUETTHE.CC_DITRE, "
            strSQL += " ST_GIOQUETTHE.CC_QUENQUETTHE,"
            strSQL += " ST_GIOQUETTHE.CC_SUATAN,"
            strSQL += " IT_TONGGIOCONG.TONGGIOCONG AS TONGGIOTC,"
            strSQL += " IT_TONGGIOCONG.CHENHLECH "
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_GIOQUETTHE ON "
            strSQL += " (ST_NHANVIEN.NV_MA=ST_GIOQUETTHE.NV_MA "
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = '" + obj.Ngay + "')"
            strSQL += " LEFT JOIN IT_TONGGIOCONG ON "
            strSQL += " ST_NHANVIEN.NV_MA=IT_TONGGIOCONG.NV_MA "
            strSQL += " LEFT JOIN ST_VAORA ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA.QT_NGAY"
            strSQL += " AND ST_GIOQUETTHE.CA_MA = ST_VAORA.CA_MA)"
            strSQL += " LEFT JOIN ST_VAORA_MACHINE_NEW ON "
            strSQL += " (ST_GIOQUETTHE.NV_MA = ST_VAORA_MACHINE_NEW.NV_MA"
            strSQL += " AND ST_GIOQUETTHE.QT_NGAY = ST_VAORA_MACHINE_NEW.QT_NGAY)"
            strSQL += " WHERE NOT EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA AND TV_NGAYTHOIVIEC < '" + obj.Ngay + "')"
            strSQL += " AND ST_NHANVIEN.NV_MA IS NULL"
        End If

        If obj.ChonBang = 5 Then
            strSQL = " select * from st_gioquetthe where qt_ngay = '" + obj.Ngay + "' and nv_ma = '" + obj.NV_MA + "' AND CC_GIOBINHTHUONG > 0"
        End If
        If obj.ChonBang = 16 Then
            strSQL = "SELECT * FROM ST_THANG WHERE T_MA = '" + obj.Thang + "'"
        End If
        If obj.ChonBang = 17 Then
            strSQL = "SELECT IT_DANGKYCOM.NV_MA,"
            strSQL += " DK_KHONGANCOM,"
            strSQL += " CC_GIOBINHTHUONG"
            strSQL += " FROM IT_DANGKYCOM INNER JOIN ST_GIOQUETTHE ON  IT_DANGKYCOM.NV_MA = ST_GIOQUETTHE.NV_MA"
            strSQL += " AND IT_DANGKYCOM.DK_NGAY = ST_GIOQUETTHE.QT_NGAY"
            strSQL += " INNER JOIN ST_NHANVIEN ON IT_DANGKYCOM.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL += " INNER JOIN ST_DONVI  ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA_ AND DV_LocBB = 0 AND DV_TV <> 1"
            strSQL += " WHERE DK_NGAY = '" + obj.Ngay + "' AND DK_KHONGANCOM = 1 AND CC_SUATAN > 0"
            strSQL += " AND ST_GIOQUETTHE.CC_GIOBINHTHUONG > 0 AND ST_DONVI.KHU = '" + obj.ChonKhu + "'"
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

    Public Function UpdateInfo(ByVal obj As objChamCom) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE [ST_GIOQUETTHE]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 2 Then
            strSQL = "UPDATE [ST_GIOQUETTHE]   SET [CC_SUATAN] = " + obj.ChamCom + ",[QT_NGAYCAPNHAT] = '" + obj.NGAYCN + "', [QT_NGUOICAPNHAT] = '" + obj.NGUOICN + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "' AND CC_GIOBINHTHUONG > 0"
        End If
        If obj.ChonBang = 4 Then
            strSQL = "UPDATE [ST_GIOQUETTHE]   SET  [QT_NGAYCAPNHAT] = '" + obj.NGAYCN + "', [QT_NGUOICAPNHAT] = '" + obj.NGUOICN + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 3 Then
            strSQL = "  UPDATE ST_GIOQUETTHE "
            strSQL += " SET CC_SUATAN = 0, QT_NGAYCAPNHAT = '" + obj.NGAYCN + "', QT_NGUOICAPNHAT = '" + obj.NGUOICN + "'"
            strSQL += " FROM IT_DANGKYCOM INNER JOIN ST_GIOQUETTHE ON  IT_DANGKYCOM.NV_MA = ST_GIOQUETTHE.NV_MA"
            strSQL += " AND IT_DANGKYCOM.DK_NGAY = ST_GIOQUETTHE.QT_NGAY"
            strSQL += "  INNER JOIN ST_NHANVIEN ON IT_DANGKYCOM.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL += " INNER JOIN ST_DONVI  ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA_ AND DV_LocBB = 0 AND DV_TV <> 1"
            strSQL += " WHERE DK_NGAY =  '" + obj.Ngay + "' AND DK_KHONGANCOM = 1"
            strSQL += " AND ST_GIOQUETTHE.CC_GIOBINHTHUONG > 0 and CC_SUATAN > 0 AND ST_DONVI.KHU = '" + obj.ChonKhu + "'"
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
