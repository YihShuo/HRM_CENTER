Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDQTSaiQuiDinhBangTong
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As objQTSaiQuiDinhBangTong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        Dim khu As String = obj.ChonKhu
        Dim chuoiKhongTinhTangCa As String = " and giotangca_"
        Dim chuoiDaChamCong As String = " and giobinhthuong_"

        If obj.ChonBang = 1 Then 'Load xưởng
            ' strSQL = ("SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")
            If obj.ChonKhu <> "TCT" Then
                strSQL = ("SELECT X_MA_, X_MA_ AS X_TEN  FROM ST_NXUONG WHERE X_MA_ NOT IN ('KB') AND EXISTS  (SELECT ST_DONVI.X_MA_   FROM ST_DONVI  WHERE DV_LocBB = 0 and ST_DONVI .KHU = '" + khu + "' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ AND N_MA NOT IN ('BGD','CG')AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1) ORDER BY X_MA_")
            End If
        End If

        If obj.ChonBang = 4 Then 'Load khu
            strSQL = ("select KHU_MA, KHU_TEN from ST_KHU")
        End If
        If obj.ChonBang = 2 Then
            If obj.KhongTinhTangCa = 1 Then
                chuoiKhongTinhTangCa = chuoiKhongTinhTangCa + obj.D_Ngay.ToString() + " = 0 "
            Else
                chuoiKhongTinhTangCa = ""
            End If

            If obj.DaChamCong = 1 Then
                chuoiDaChamCong = chuoiDaChamCong + obj.D_Ngay.ToString() + " > 0 "
            Else
                chuoiDaChamCong = ""
            End If


            strSQL = "SELECT NGAY"
            strSQL += ",CA"
            strSQL += ",X_MA_ "
            strSQL += ",KHU "
            strSQL += ",DV_MA "
            strSQL += ",VAOSOM = SUM(VAOSOM)"
            strSQL += ",VAOTRE = SUM (VAOTRE )"
            strSQL += ",RASOM= SUM (RASOM )"
            strSQL += ",RATRE= SUM(RATRE) "
            strSQL += " FROM ("
            strSQL += " SELECT NGAY = CONVERT(CHAR(10),CONVERT(DATETIME, " + obj.Ngay + "),105),"
            strSQL += " CA = CASE WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA HC' THEN 'CA HC'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 2' THEN 'CA 1'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 3' THEN 'CA 2'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 4' THEN 'CA 3'"
            strSQL += " ELSE '' END,"
            strSQL += " X_MA_ = ST_DONVI.X_MA_,"
            ' strSQL += " KHU = CASE WHEN X_MA_ LIKE N'B%' THEN N'KHUB' ELSE N'KHUA' END,"
            strSQL += " KHU = ST_DONVI.KHU,"
            strSQL += " ST_DONVI.DV_MA,"

            strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'05:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'13:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'21:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

            strSQL += " ELSE 0 END ),"

            strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

            strSQL += " ELSE 0 END ),"

            strSQL += " RASOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + ""
            ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
            strSQL += " AND (NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=" + obj.Ngay + " AND DENNGAY >=" + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA )"
            strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=" + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=" + obj.Ngay + " AND CHONNGAYSANH = 1"
            strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"
            ''======== HET================
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

            strSQL += " ELSE 0 END ),"

            strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:50:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

            strSQL += " ELSE 0 END )"
            strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += " ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA "
            ''========= chỉ quẹt thẻ sai mới lấy ==============''
            strSQL += " AND (("
            strSQL += " CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'05:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'13:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'21:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

            strSQL += " ELSE 0  END )"
            strSQL += "  + "

            strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "


            strSQL += " ELSE 0 END )"
            strSQL += "  + "

            strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 "
            strSQL += " AND (NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE  BATDAUTU <= " + obj.Ngay + " AND  DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
            strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=" + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=" + obj.Ngay + " AND CHONNGAYSANH = 1"
            strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

            strSQL += " ELSE 0 END )"
            strSQL += "  + "

            strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:50:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
            strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

            strSQL += " ELSE 0 END )"
            strSQL += ") > 0 "
            strSQL += " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0 AND DV_TV <> 1 "
            strSQL += " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG%' AND ST_NHANVIEN.DV_MA NOT LIKE '%BGD%'"

            'Select Case obj.ChonXuong
            '    Case "TCT"
            '    Case "KHUA"
            '        strSQL += " AND ST_DONVI.X_MA_ NOT LIKE N'B%'"
            '    Case "KHUB"
            '        strSQL += " AND ST_DONVI.X_MA_ LIKE N'B%'"
            '    Case Else
            '        strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
            'End Select
            Select Case obj.ChonKhu
                Case "TCT"
                Case "A"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND ST_DONVI.KHU = 'A'"
                    End If


                Case "B"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND ST_DONVI.KHU = 'B'"
                    End If
                Case "DVC"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND ST_DONVI.KHU = 'DVC'"
                    End If
                Case Else
                    strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
            End Select
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= " + obj.Ngay + ""
            strSQL += " WHERE NAM= " + obj.Y_Ngay.ToString + ""
            strSQL += " AND THANG = " + obj.M_Ngay.ToString + ""
            strSQL += " AND NOT exists (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_VAORA_MACHINE.MaNV )"
            strSQL += " GROUP BY ST_DONVI.X_MA_ ,ST_DONVI.DV_MA ,ST_DONVI.KHU ,loaica_" + obj.D_Ngay.ToString() + ",ST_VAORA_MACHINE.MaNV,ST_VAORA_MACHINE.giora_" + obj.D_Ngay.ToString() + ",giovao_" + obj.D_Ngay.ToString() + ",giotangca_" + obj.D_Ngay.ToString() + ",giobinhthuong_" + obj.D_Ngay.ToString() + ""
            strSQL += " ) AS V"
            strSQL += " GROUP BY KHU,X_MA_ ,DV_MA,CA,NGAY "
            strSQL += " ORDER BY KHU,X_MA_ ,DV_MA,CA,NGAY"
        End If

        ''============ truy vấn tuần: đưa vào bảng tuần sau đó sum lại ===============''
        If obj.ChonBang = 3 Then
            strSQL = "SELECT CA,XUONG AS X_MA_,KHU,DV_MA  "
            strSQL += " ,VAOSOM = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END)"
            strSQL += " ,VAOTRE =SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END)"
            strSQL += " ,RASOM = SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END)"
            strSQL += " ,RATRE = SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END)"
            strSQL += " FROM THONGKEQUETTHESAIQUYDINH_TUAN "
            strSQL += " WHERE NGAY >= " + obj.NgayDauTuan + ""
            strSQL += " AND NGAY <= " + obj.NgayCuoiTuan + ""

            'Select Case obj.ChonXuong
            '    Case "TCT"
            '    Case "KHUA"
            '        strSQL += " AND XUONG NOT LIKE N'B%'"
            '    Case "KHUB"
            '        strSQL += " AND XUONG LIKE N'B%'"
            '    Case Else
            '        strSQL += " AND XUONG LIKE N'" + obj.ChonXuong + "'"
            'End Select
            Select Case obj.ChonKhu
                Case "TCT"
                Case "A"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += "AND XUONG = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += "AND KHU = 'A'"
                    End If


                Case "B"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND KHU = 'B'"
                    End If
                Case "DVC"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND KHU = 'DVC'"
                    End If
                Case Else
                    strSQL += " AND XUONG  ='" + obj.ChonXuong + "'"
            End Select
            strSQL += " GROUP BY KHU,XUONG,DV_MA ,CA "
            strSQL += " ORDER BY KHU,XUONG,DV_MA ,CA "
        End If




        If obj.ChonBang = 11 Then
            strSQL = "SELECT "
            strSQL += " NGAY = CONVERT(CHAR(10),CONVERT(DATETIME," + obj.Ngay + "),105),"
            strSQL += " CA = 'Ca HC',"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " DONVI = CASE	WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += "	WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " TENDV = CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " END,"
            '--Len ca---------------------------------------------
            '   --Quet the som-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END) AS QT_VAO_SOM,"
            '   --Khong quet the vao---------------
            strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_VAO,"
            '   --Quet the tre-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END) AS QT_VAO_TRE"
            ''--Xuong ca---------------------------
            ''   --Quet the som-----------------------------------
            'strSQL += " SUM(CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END) AS QT_RA_SOM,"
            ''   --Khong quet the ra---------------
            'strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_RA,"
            ''   --Quet the tre-----------------------------------
            'strSQL += " SUM(CASE WHEN DATEDIFF( MI,'17:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'17:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 23 THEN 1 ELSE 0 END) AS QT_RA_TRE"
            ''---------------------------------------------------------------------------------
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_VAORA "
            strSQL += " ON( ST_NHANVIEN.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_VAORA.CA_MA = 'Ca HC'"
            strSQL += " AND ST_VAORA.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " INNER JOIN JELL_DONVI ON ST_NHANVIEN.DV_MA = JELL_DONVI.DV_MA"
            strSQL += " INNER JOIN ST_NGANH ON JELL_DONVI.N_MA = ST_NGANH.N_MA"
            strSQL += " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE TV_NGAYTHOIVIEC<=" + obj.Ngay + ")"

            strSQL += " AND ST_NHANVIEN.NV_MA IN (SELECT ST_VAORA_MACHINE_NEW.NV_MA FROM ST_VAORA_MACHINE_NEW "
            strSQL += " INNER JOIN ST_GIOQUETTHE ON ST_VAORA_MACHINE_NEW.NV_MA = ST_GIOQUETTHE.NV_MA "
            strSQL += " AND ST_VAORA_MACHINE_NEW.QT_NGAY = ST_GIOQUETTHE.QT_NGAY WHERE ST_VAORA_MACHINE_NEW.QT_NGAY = " + obj.Ngay + " AND ST_GIOQUETTHE.CA_MA = 'Ca HC')"

            'strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_PHANCA WHERE CA_MA <> 'Ca HC' AND PC_NGAYBATDAU <= " + obj.Ngay + " AND PC_NGAYKETTHUC >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = convert(datetime,datediff(d,1," + obj.Ngay + ")))"

            strSQL += " AND ("
            strSQL += " CASE WHEN DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END+ "
            strSQL += " CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END +"
            strSQL += " CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END "
            'strSQL += " CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END  +"
            'strSQL += " CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END  +"
            'strSQL += " CASE WHEN DATEDIFF( MI,'17:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'17:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 23 THEN 1 ELSE 0 END  "
            strSQL += " )>0"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <= " + obj.Ngay + " AND DENNGAY >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <= " + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >= " + obj.Ngay + " AND CHONNGAYSANH = 1)"
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= " + obj.Ngay + ""

            strSQL += " GROUP BY"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " End"
        End If

        If obj.ChonBang = 22 Then
            strSQL = "SELECT "
            strSQL += " NGAY = CONVERT(CHAR(10),CONVERT(DATETIME," + obj.Ngay + "),105),"
            strSQL += " CA = 'Ca HC',"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " DONVI = CASE	WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += "	WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " TENDV = CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " END,"
            ''--Len ca---------------------------------------------
            ''   --Quet the som-----------------------------------
            'strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END) AS QT_VAO_SOM,"
            ''   --Khong quet the vao---------------
            'strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_VAO,"
            ''   --Quet the tre-----------------------------------
            'strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END) AS QT_VAO_TRE,"
            ''--Xuong ca---------------------------
            '   --Quet the som-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END) AS QT_RA_SOM,"
            '   --Khong quet the ra---------------
            strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_RA,"
            '   --Quet the tre-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) <= 39 THEN 1 ELSE 0 END) AS QT_RA_TRE"
            '---------------------------------------------------------------------------------
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_VAORA "
            strSQL += " ON( ST_NHANVIEN.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_VAORA.CA_MA = 'Ca HC'"
            strSQL += " AND ST_VAORA.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " INNER JOIN JELL_DONVI ON ST_NHANVIEN.DV_MA = JELL_DONVI.DV_MA"
            strSQL += " INNER JOIN ST_NGANH ON JELL_DONVI.N_MA = ST_NGANH.N_MA"
            strSQL += " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE TV_NGAYTHOIVIEC<=" + obj.Ngay + ")"

            strSQL += " AND ST_NHANVIEN.NV_MA IN (SELECT ST_VAORA_MACHINE_NEW.NV_MA FROM ST_VAORA_MACHINE_NEW "
            strSQL += " INNER JOIN ST_GIOQUETTHE ON ST_VAORA_MACHINE_NEW.NV_MA = ST_GIOQUETTHE.NV_MA "
            strSQL += " AND ST_VAORA_MACHINE_NEW.QT_NGAY = ST_GIOQUETTHE.QT_NGAY WHERE ST_VAORA_MACHINE_NEW.QT_NGAY = " + obj.Ngay + " AND ST_GIOQUETTHE.CA_MA = 'Ca HC')"

            'strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_PHANCA WHERE CA_MA <> 'Ca HC' AND PC_NGAYBATDAU <= " + obj.Ngay + " AND PC_NGAYKETTHUC >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = convert(datetime,datediff(d,1," + obj.Ngay + ")))"
            strSQL += " AND ("
            'strSQL += " CASE WHEN DATEDIFF( MI,'07:00:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END+ "
            'strSQL += " CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END +"
            'strSQL += " CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END +"
            strSQL += " CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END  +"
            strSQL += " CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END  +"
            strSQL += " CASE WHEN DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) <= 39 THEN 1 ELSE 0 END  "
            strSQL += " )>0"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <= " + obj.Ngay + " AND DENNGAY >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <= " + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >= " + obj.Ngay + " AND CHONNGAYSANH = 1)"
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= " + obj.Ngay + ""

            strSQL += " GROUP BY"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " End"
        End If

        If obj.ChonBang = 33 Then
            strSQL = "SELECT "
            strSQL += " NGAY = CONVERT(CHAR(10),CONVERT(DATETIME," + obj.Ngay + "),105),"
            strSQL += " CA = 'Ca HC',"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " DONVI = CASE	WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += "	WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " TENDV = CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " END,"
            '--Len ca---------------------------------------------
            '   --Quet the som-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END) AS QT_VAO_SOM,"
            '   --Khong quet the vao---------------
            strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_VAO,"
            '   --Quet the tre-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END) AS QT_VAO_TRE,"
            '--Xuong ca---------------------------
            '   --Quet the som-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END) AS QT_RA_SOM,"
            '   --Khong quet the ra---------------
            strSQL += " SUM(CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END) AS KHONG_QT_RA,"
            '   --Quet the tre-----------------------------------
            strSQL += " SUM(CASE WHEN DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) <= 39 THEN 1 ELSE 0 END) AS QT_RA_TRE"
            '---------------------------------------------------------------------------------
            strSQL += " FROM ST_NHANVIEN LEFT JOIN ST_VAORA "
            strSQL += " ON( ST_NHANVIEN.NV_MA = ST_VAORA.NV_MA"
            strSQL += " AND ST_VAORA.CA_MA = 'Ca HC'"
            strSQL += " AND ST_VAORA.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " INNER JOIN JELL_DONVI ON ST_NHANVIEN.DV_MA = JELL_DONVI.DV_MA"
            strSQL += " INNER JOIN ST_NGANH ON JELL_DONVI.N_MA = ST_NGANH.N_MA"
            strSQL += " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE TV_NGAYTHOIVIEC<=" + obj.Ngay + ")"

            strSQL += " AND ST_NHANVIEN.NV_MA IN (SELECT ST_VAORA_MACHINE_NEW.NV_MA FROM ST_VAORA_MACHINE_NEW "
            strSQL += " INNER JOIN ST_GIOQUETTHE ON ST_VAORA_MACHINE_NEW.NV_MA = ST_GIOQUETTHE.NV_MA "
            strSQL += " AND ST_VAORA_MACHINE_NEW.QT_NGAY = ST_GIOQUETTHE.QT_NGAY WHERE ST_VAORA_MACHINE_NEW.QT_NGAY = " + obj.Ngay + " AND ST_GIOQUETTHE.CA_MA = 'Ca HC')"

            'strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_PHANCA WHERE CA_MA <> 'Ca HC' AND PC_NGAYBATDAU <= " + obj.Ngay + " AND PC_NGAYKETTHUC >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_GIOQUETTHE WHERE CA_MA <> 'Ca HC' AND ST_GIOQUETTHE.QT_NGAY = convert(datetime,datediff(d,1," + obj.Ngay + ")))"
            strSQL += " AND ("
            strSQL += " CASE WHEN DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) < 0 THEN 1 ELSE 0 END+ "
            strSQL += " CASE WHEN ST_VAORA.QT_GIOVAO IS NULL THEN 1 ELSE 0 END +"
            strSQL += " CASE WHEN DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIOVAO,108) ) > 0 THEN 1 ELSE 0 END +"
            strSQL += " CASE WHEN DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) < 0 THEN 1 ELSE 0 END  +"
            strSQL += " CASE WHEN ST_VAORA.QT_GIORA IS NULL THEN 1 ELSE 0 END  +"
            strSQL += " CASE WHEN DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) > 0 AND DATEDIFF( MI,'16:45:00', CONVERT(CHAR(8),ST_VAORA.QT_GIORA,108) ) <=39 THEN 1 ELSE 0 END  "
            strSQL += " )>0"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <= " + obj.Ngay + " AND DENNGAY >= " + obj.Ngay + ")"
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <= " + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >= " + obj.Ngay + " AND CHONNGAYSANH = 1)"
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= " + obj.Ngay + ""

            strSQL += " GROUP BY"
            strSQL += " JELL_DONVI.X_MA_, "
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN JELL_DONVI.N_MA"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN JELL_DONVI.N_MA"
            strSQL += " Else 'DVGT'"
            strSQL += " END,"
            '--------------------------------------------------------------------------------------------------
            strSQL += " CASE WHEN (JELL_DONVI.X_MA_ = 'A1A2') THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " WHEN JELL_DONVI.N_MA IN ('CHAT','MAY','GO','CCS') AND JELL_DONVI.DV_MA NOT LIKE '%XV' THEN st_nganh.n_ten_taiwan+'-'+st_nganh.n_ten"
            strSQL += " Else N'間接單位-ĐV gián tiếp'"
            strSQL += " End"
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
    Public Function ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Insert(ByVal obj As objQTSaiQuiDinhBangTong, ByVal bChonTuan As Boolean) As Boolean
        'Dim strSQL As String = "BEGIN TRANSACTION " & ChrW(13) & ChrW(10)
        'strSQL = strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)
        Dim strSQL As String = ""
        Dim chuoiKhongTinhTangCa As String = " and giotangca_"
        Dim chuoiDaChamCong As String = " and giobinhthuong_"

        If obj.KhongTinhTangCa = 1 Then
            chuoiKhongTinhTangCa = chuoiKhongTinhTangCa + obj.D_Ngay.ToString() + " = 0 "
        Else
            chuoiKhongTinhTangCa = ""
        End If

        If obj.DaChamCong = 1 Then
            chuoiDaChamCong = chuoiDaChamCong + obj.D_Ngay.ToString() + " > 0 "
        Else
            chuoiDaChamCong = ""
        End If

        'If obj.ChonBang = 3 Then
        If bChonTuan Then
            strSQL = " INSERT INTO THONGKEQUETTHESAIQUYDINH_TUAN (NGAY,CA,XUONG,KHU,DV_MA,NV_MA,NV_TEN,GIO_VAO,GIO_RA,VAOSOM,VAOTRE,RASOM,RATRE)"
        Else
            strSQL = " INSERT INTO THONGKEQUETTHESAIQUYDINH_THANG (NGAY,CA,XUONG,KHU,DV_MA,NV_MA,NV_TEN,GIO_VAO,GIO_RA,VAOSOM,VAOTRE,RASOM,RATRE)"
        End If
        strSQL += " SELECT NGAY = CONVERT(CHAR(10),CONVERT(DATETIME, " + obj.Ngay + "),21),"
        strSQL += "CA = CASE WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA HC' THEN 'CA HC'"
        strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 2' THEN 'CA 1'"
        strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 3' THEN 'CA 2'"
        strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 4' THEN 'CA 3'"
        strSQL += " ELSE '' END,"
        strSQL += " X_MA_ = ST_DONVI.X_MA_,"
        strSQL += " KHU = ST_DONVI.KHU ," 'CASE WHEN X_MA_ LIKE N'B%' THEN N'KHUB' ELSE N'KHUA' END
        strSQL += " ST_NHANVIEN.DV_MA,"
        strSQL += " NV_MA = MANV,"
        strSQL += " NV_TEN,"
        strSQL += " GIO_VAO = CONVERT(CHAR(10),CONVERT(DATETIME, giovao_" + obj.D_Ngay.ToString() + "),14),"
        strSQL += " GIO_RA = CONVERT(CHAR(10),CONVERT(DATETIME, giora_" + obj.D_Ngay.ToString() + "),14),"

        strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'05:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'13:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'21:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

        strSQL += " ELSE 0 END ),"

        strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

        strSQL += " ELSE 0 END ),"

        strSQL += " RASOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + ""
        ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
        strSQL += " AND (NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=" + obj.Ngay + " AND DENNGAY >=" + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA )"
        strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=" + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=" + obj.Ngay + " AND CHONNGAYSANH = 1"
        strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"
        ''======== HET================
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

        strSQL += " ELSE 0 END ),"

        strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:50:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"

        strSQL += " ELSE 0 END )"
        strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
        strSQL += " ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA "
        ''========= chỉ quẹt thẻ sai mới lấy ==============''
        strSQL += " AND (("
        strSQL += " CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:15:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'05:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'13:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'21:45:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

        strSQL += " ELSE 0  END )"
        strSQL += "  + "

        strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'07:30:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giovao_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "


        strSQL += " ELSE 0 END )"
        strSQL += "  + "

        strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:30:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 "
        strSQL += " AND (NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE  BATDAUTU <= " + obj.Ngay + " AND  DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
        strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=" + obj.Ngay + " AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=" + obj.Ngay + " AND CHONNGAYSANH = 1"
        strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1"
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:00:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) < 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

        strSQL += " ELSE 0 END )"
        strSQL += "  + "

        strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND DATEDIFF( MI,'16:50:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND DATEDIFF( MI,'14:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND DATEDIFF( MI,'22:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "
        strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND DATEDIFF( MI,'06:15:00', CONVERT(CHAR(8),giora_" + obj.D_Ngay.ToString() + ",108) ) > 0 " + chuoiKhongTinhTangCa + chuoiDaChamCong + " THEN 1 "

        strSQL += " ELSE 0 END )"
        strSQL += ") > 0 "
        strSQL += " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0 AND DV_TV <> 1 "
        strSQL += " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG%' AND ST_NHANVIEN.DV_MA NOT LIKE '%BGD%'"

        'Select Case obj.ChonXuong
        '    Case "TCT"
        '    Case "KHUA"
        '        strSQL += " AND ST_DONVI.X_MA_ NOT LIKE N'B%'"
        '    Case "KHUB"
        '        strSQL += " AND ST_DONVI.X_MA_ LIKE N'B%'"
        '    Case Else
        '        strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
        'End Select
        Select Case obj.ChonKhu
            Case "TCT"
            Case "A"
                If obj.ChonXuong <> "TOANKHU" Then
                    strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                Else
                    strSQL += " AND ST_DONVI.KHU = 'A'"
                End If


            Case "B"
                If obj.ChonXuong <> "TOANKHU" Then
                    strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                Else
                    strSQL += " AND ST_DONVI.KHU = 'B'"
                End If
            Case "DVC"
                If obj.ChonXuong <> "TOANKHU" Then
                    strSQL += " AND ST_DONVI.X_MA_ = '" + obj.ChonXuong + "'"
                Else
                    strSQL += " AND ST_DONVI.KHU = 'DVC'"
                End If
            Case Else
                strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
        End Select
        strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= " + obj.Ngay + ""
        strSQL += " WHERE NAM= " + obj.Y_Ngay.ToString + ""
        strSQL += " AND THANG = " + obj.M_Ngay.ToString + ""
        strSQL += " AND NOT exists (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_VAORA_MACHINE.MaNV )"
        strSQL += " ORDER BY ST_DONVI.X_MA_ ,ST_DONVI.DV_MA ,loaica_" + obj.D_Ngay.ToString() + ""


        'End If


        Return Me.execSQL(strSQL)
    End Function
    Public Function ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Delete(ByVal obj As objQTSaiQuiDinhBangTong, ByVal bChonTuan As Boolean) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        ''===== bChonTuan =true: theo tuần, ngc lại theo tháng
        'Select Case obj.ChonXuong
        '    Case "TCT"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case "KHUA"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG NOT LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG NOT LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case "KHUB"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case Else
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + " AND XUONG ='" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + " AND XUONG ='" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        'End Select
        Select Case obj.ChonKhu
            Case "TCT"
                If bChonTuan Then
                    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                Else
                    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                End If
            Case "A"
                If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + " AND KHU = 'A'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + " AND KHU = 'A'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If


            Case "B"
                If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + " AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND KHU = 'B'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND KHU = 'B'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If
            Case "DVC"
                If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND KHU = 'DVC'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= " + obj.Ngay + " AND NGAY<= " + obj.Ngay) + "  AND KHU = 'DVC'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If
            Case Else
                strSQL += " "
        End Select
        Return Me.execSQL(strSQL)
    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

End Class

