Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDQTSaiQuiDinh
    Inherits DALSQL
    ' Methods

    Public Function LoadDS(ByVal obj As objQTSaiQuiDinh) As DataTable
        Dim table As DataTable
        Dim khu As String = obj.Khu
        Dim strSQL As String = ""
        Dim chuoiKhongTinhTangCa As String = " and giotangca_"
        Dim chuoiDaChamCong As String = " and giobinhthuong_"

        'If obj.ChonBang = 1 Then
        '    strSQL = ("SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")
        'End If
        If obj.ChonBang = 1 Then
            If obj.Khu <> "TCT" Then
                strSQL = ("SELECT X_MA_, X_MA_ AS X_TEN  FROM ST_NXUONG WHERE X_MA_ NOT IN ('KB') AND EXISTS  (SELECT ST_DONVI.X_MA_   FROM ST_DONVI  WHERE DV_LocBB = 0 and ST_DONVI .KHU = '" + khu + "' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ AND N_MA NOT IN ('BGD','CG')AND ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1) ORDER BY X_MA_")
            End If

        End If
        ''========= XEM CHI TIẾT TỪNG NGÀY TRONG THÁNG ===========
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

            strSQL = " SELECT NGAY = CONVERT(CHAR(10),CONVERT(DATETIME, " + obj.Ngay + "),105),"
            strSQL += "CA = CASE WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA HC' THEN 'CA HC'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 2' THEN 'CA 1'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 3' THEN 'CA 2'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 4' THEN 'CA 3'"
            strSQL += " ELSE '' END,"
            strSQL += " X_MA_ = ST_DONVI.X_MA_,"
            'strSQL += " KHU = CASE WHEN X_MA_ LIKE N'B%' THEN N'KHUB' ELSE N'KHUA' END,"
            strSQL += "KHU = ST_DONVI.KHU, "

            strSQL += " ST_NHANVIEN.DV_MA,"
            strSQL += " NV_MA = MANV,"
            strSQL += " NV_TEN,"
            strSQL += " GIO_VAO = CONVERT(CHAR(10),CONVERT(DATETIME, giovao_" + obj.D_Ngay.ToString() + "),14),"
            strSQL += " GIO_RA = CONVERT(CHAR(10),CONVERT(DATETIME, giora_" + obj.D_Ngay.ToString() + "),14),"

            '' dua vao gio binh thuong: loai quet the vao Ca 4, gio tang ca: tru ra nhung ng da cham cong tang ca
            If obj.VaoSom = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END)"
            End If
               
            If obj.RaTre = 1 Then
                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"
            End If

            If obj.VaoSomRaTre = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END),"
                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END ),"
                strSQL += " VAOSOMRATRE =(CASE WHEN ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 ELSE 0 END)) > 0 THEN 1 ELSE 0 END )"

            End If


            If obj.VaoTre = 1 Then
                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END) "
            End If

            If obj.RaSom = 1 Then
                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END)"
            End If

            If obj.VaoTreRaSom = 1 Then
                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END), "

                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END),"

                strSQL += " VAOTRERASOM = (CASE WHEN((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END)"
                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END)"
                strSQL += " ) > 0 THEN 1 ELSE 0 END)"
            End If

            ''====== tat ca = vao som + vao tre + ra som + ra tre cua tung nut => group by lại; neu co nguoi vưa vao tre vua ra som tinh la 1 dong
            If obj.Tatca = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END),"

                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END), "

                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END),"


                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"

                strSQL += " ,VAOSOMRATRE =(CASE WHEN ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 ELSE 0 END)) > 0 THEN 1 ELSE 0 END )"

                strSQL += " ,VAOTRERASOM = (CASE WHEN((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END)"
                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END)"
                strSQL += " ) > 0 THEN 1 ELSE 0 END)"
            End If

            strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA "
            ''========= chỉ quẹt thẻ sai mới lấy ==============''
            If obj.VaoSom = 1 Then
                strSQL += " AND ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END)"
                strSQL += " > 0) "
            End If

            If obj.RaTre = 1 Then
                strSQL += " AND (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"
                strSQL += " > 0 "
            End If

            If obj.VaoSomRaTre = 1 Then
                strSQL += " AND (CASE WHEN ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 ELSE 0 END)) > 0 THEN 1 ELSE 0 END )"
                strSQL += " > 0 "
            End If

            ''=========================
            If obj.VaoTre = 1 Then
                strSQL += " AND (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END) "
                strSQL += " > 0 "


            End If

            If obj.RaSom = 1 Then
                strSQL += " AND (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END) >0"




            End If

            If obj.VaoTreRaSom = 1 Then
                strSQL += " AND ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30)  OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1"
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1  ELSE 0 END) "

                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21)  "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5)   "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 ELSE 0 END)"

                strSQL += " ) > 0 "
            End If

            If obj.Tatca = 1 Then
                strSQL += " AND "
                strSQL += " ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1"
                strSQL += " ELSE 0 END)"

                strSQL += " + "
                ''--------------------------------
                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) "
                strSQL += " OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END) "
                strSQL += ") > 0 "
            End If
            strSQL += " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0 AND DV_TV <> 1 "
            'strSQL += " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG%' AND ST_NHANVIEN.DV_MA NOT LIKE '%BGD%'"
            ''========= các đơn vị ngoại lệ không thống kê ========''
            strSQL += " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM V_DONVINGOAILE_THONGKEQUETTHESQD )"

            Select Case obj.Khu
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
        End If

        ''========== HIỆN CỘT TỔNG SỐ LẦN VI PHẠM TRONG THÁNG CỦA TỪNG NGƯỜI ===================
        If obj.ChonBang = 3 Then
            strSQL = "SELECT THONGKEQUETTHESAIQUYDINH_THANG.NV_MA,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_THANG.NV_TEN,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_THANG.DV_MA ,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_THANG.XUONG ,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_THANG.KHU ,"
            strSQL = strSQL + "TONGVAOSOM = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOTRE = SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGRASOM =  SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGRATRE =  SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOSOMRATRE = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOTRERASOM = SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGSOLANVIPHAM = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + "+ SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " FROM THONGKEQUETTHESAIQUYDINH_THANG "
            strSQL = strSQL + " WHERE NGAY >='" + obj.Ngaydauthang + "'"
            strSQL = strSQL + " AND NGAY <= '" + obj.Ngaycuoithang + "'"

             Select obj.Khu
                Case "TCT"
                Case "A"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "' "
                    Else
                        strSQL += " AND KHU = 'A'"
                    End If


                Case "B"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "' "
                    Else
                        strSQL += " AND KHU = 'B'"
                    End If
                Case "DVC"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "' "
                    Else
                        strSQL += " AND KHU = 'DVC'"
                    End If
                Case Else
                    strSQL += " AND XUONG ='" + obj.ChonXuong + "' "
            End Select

            strSQL = strSQL + " GROUP BY THONGKEQUETTHESAIQUYDINH_THANG.KHU,THONGKEQUETTHESAIQUYDINH_THANG.XUONG"
            strSQL = strSQL + " ,THONGKEQUETTHESAIQUYDINH_THANG.DV_MA, THONGKEQUETTHESAIQUYDINH_THANG.NV_MA"
            strSQL = strSQL + " ,THONGKEQUETTHESAIQUYDINH_THANG.NV_TEN"
            strSQL = strSQL + " ORDER BY THONGKEQUETTHESAIQUYDINH_THANG.KHU,THONGKEQUETTHESAIQUYDINH_THANG.XUONG"
            strSQL = strSQL + ",THONGKEQUETTHESAIQUYDINH_THANG.DV_MA, THONGKEQUETTHESAIQUYDINH_THANG.NV_MA"
            strSQL = strSQL + ",THONGKEQUETTHESAIQUYDINH_THANG.NV_TEN"
        End If

        ''========== HIỆN CỘT TỔNG SỐ LẦN VI PHẠM TRONG TUẦN CỦA TỪNG NGƯỜI ===================
        If obj.ChonBang = 4 Then
            strSQL = "SELECT THONGKEQUETTHESAIQUYDINH_TUAN.NV_MA,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_TUAN.NV_TEN,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_TUAN.DV_MA ,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_TUAN.XUONG ,"
            strSQL = strSQL + "THONGKEQUETTHESAIQUYDINH_TUAN.KHU ,"
            strSQL = strSQL + "TONGVAOSOM = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOTRE = SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGRASOM =  SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGRATRE =  SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOSOMRATRE = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGVAOTRERASOM = SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END),"
            strSQL = strSQL + "TONGSOLANVIPHAM = SUM(CASE WHEN VAOSOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN VAOTRE = 1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + "+ SUM(CASE WHEN RASOM = 1 THEN 1 ELSE 0 END) + SUM(CASE WHEN RATRE = 1 THEN 1 ELSE 0 END)"
            strSQL = strSQL + " FROM THONGKEQUETTHESAIQUYDINH_TUAN "
            strSQL = strSQL + " WHERE NGAY >='" + obj.NgayDauTuan + "'"
            strSQL = strSQL + " AND NGAY <= '" + obj.NgayCuoiTuan + "'"

            Select Case obj.Khu
                Case "TCT"
                Case "A"
                    If obj.ChonXuong <> "TOANKHU" Then
                        strSQL += " AND XUONG = '" + obj.ChonXuong + "'"
                    Else
                        strSQL += " AND KHU = 'A'"
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
                    strSQL += " AND XUONG ='" + obj.ChonXuong + "'"
            End Select




            strSQL = strSQL + " GROUP BY THONGKEQUETTHESAIQUYDINH_TUAN.KHU,THONGKEQUETTHESAIQUYDINH_TUAN.XUONG"
            strSQL = strSQL + " ,THONGKEQUETTHESAIQUYDINH_TUAN.DV_MA, THONGKEQUETTHESAIQUYDINH_TUAN.NV_MA"
            strSQL = strSQL + " ,THONGKEQUETTHESAIQUYDINH_TUAN.NV_TEN"
            strSQL = strSQL + " ORDER BY THONGKEQUETTHESAIQUYDINH_TUAN.KHU,THONGKEQUETTHESAIQUYDINH_TUAN.XUONG"
            strSQL = strSQL + ",THONGKEQUETTHESAIQUYDINH_TUAN.DV_MA, THONGKEQUETTHESAIQUYDINH_TUAN.NV_MA"
            strSQL = strSQL + ",THONGKEQUETTHESAIQUYDINH_TUAN.NV_TEN"
        End If

        If obj.ChonBang = 5 Then 'Load khu
            strSQL = ("select KHU_MA, KHU_TEN from ST_KHU")
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
    Public Function ThongKeQuetTheSaiQuyDinh_TungNgay_Delete(ByVal obj As objQTSaiQuiDinh, ByVal bChonTuan As Boolean) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        ''===== bChonTuan =true: theo tuần, ngc lại theo tháng
        'Select Case obj.ChonXuong
        '    Case "TCT"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.NgayDauTuan + "' AND NGAY<= '" + obj.NgayCuoiTuan) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngaydauthang + "' AND NGAY<= '" + obj.Ngaycuoithang) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case "KHUA"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG NOT LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG NOT LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case "KHUB"
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG LIKE N'B%'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        '    Case Else
        '        If bChonTuan Then
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "' AND XUONG ='" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        Else
        '            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "' AND XUONG ='" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        '        End If
        'End Select
        Select Case obj.Khu
            Case "TCT"
                If bChonTuan Then
                    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.NgayDauTuan + "' AND NGAY<= '" + obj.NgayCuoiTuan) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                Else
                    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngaydauthang + "' AND NGAY<= '" + obj.Ngaycuoithang) + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                End If
            Case "A"
                 If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'A'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'A'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If


            Case "B"
                If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'B'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'B'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If
            Case "DVC"
                If obj.ChonXuong <> "TOANKHU" Then
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND XUONG = '" + obj.ChonXuong + "''" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                Else
                    If bChonTuan Then
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_TUAN WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'DVC'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    Else
                        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE THONGKEQUETTHESAIQUYDINH_THANG WHERE NGAY >= '" + obj.Ngay + "' AND NGAY<= '" + obj.Ngay) + "'  AND KHU = 'DVC'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
                    End If
                End If
            Case Else
                strSQL += " "
        End Select
        Return Me.execSQL(strSQL)
    End Function
    Public Function ThongKeQuetTheSaiQuyDinh_TungNgay_Insert(ByVal obj As objQTSaiQuiDinh, ByVal bChonTuan As Boolean) As Boolean
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

        If obj.ChonBang = 3 Then
            If bChonTuan Then
                strSQL = " INSERT INTO THONGKEQUETTHESAIQUYDINH_TUAN (NGAY,CA,XUONG,KHU,DV_MA,NV_MA,NV_TEN,GIO_VAO,GIO_RA"
            Else

                strSQL += "INSERT INTO THONGKEQUETTHESAIQUYDINH_THANG (NGAY,CA,XUONG,KHU,DV_MA,NV_MA,NV_TEN,GIO_VAO,GIO_RA"
            End If

            If obj.Tatca = 1 Then
                strSQL += ",VAOSOM,VAOTRE,RASOM,RATRE)"
            End If

            If obj.VaoSom = 1 Then
                strSQL += ",VAOSOM)"
            End If

            If obj.VaoTre = 1 Then
                strSQL += ",VAOTRE)"
            End If

            If obj.RaSom = 1 Then
                strSQL += ",RASOM)"
            End If

            If obj.RaTre = 1 Then
                strSQL += ",RATRE)"
            End If

            If obj.VaoSomRaTre Then
                strSQL += ",VAOSOM,RATRE,VAOSOMRATRE)"
            End If

            If obj.VaoTreRaSom Then
                strSQL += ",VAOTRE,RASOM,VAOTRERASOM)"
            End If

            strSQL += " SELECT NGAY = CONVERT(CHAR(10),CONVERT(DATETIME, " + obj.Ngay + "),21),"
            strSQL += "CA = CASE WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA HC' THEN 'CA HC'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 2' THEN 'CA 1'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 3' THEN 'CA 2'"
            strSQL += " WHEN LOAICA_" + obj.D_Ngay.ToString() + " = 'CA 4' THEN 'CA 3'"
            strSQL += " ELSE '' END,"
            strSQL += " X_MA_ = ST_DONVI.X_MA_,"
            'strSQL += " KHU = CASE WHEN X_MA_ LIKE N'B%' THEN N'KHUB' ELSE N'KHUA' END,"
            ' strSQL += " KHU = CASE WHEN X_MA_ LIKE N'B%' THEN N'B' ELSE N'A' END,"
            strSQL += " KHU = ST_DONVI.KHU, "
            strSQL += " ST_NHANVIEN.DV_MA,"
            strSQL += " NV_MA = MANV,"
            strSQL += " NV_TEN,"
            strSQL += " GIO_VAO = CONVERT(CHAR(10),CONVERT(DATETIME, giovao_" + obj.D_Ngay.ToString() + "),14),"
            strSQL += " GIO_RA = CONVERT(CHAR(10),CONVERT(DATETIME, giora_" + obj.D_Ngay.ToString() + "),14),"

            '' dua vao gio binh thuong: loai quet the vao Ca 4, gio tang ca: tru ra nhung ng da cham cong tang ca
            If obj.VaoSom = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END)"
            End If

            If obj.RaTre = 1 Then
                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"
            End If

            If obj.VaoSomRaTre = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END),"
                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END ),"
                strSQL += " VAOSOMRATRE =(CASE WHEN ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 ELSE 0 END)) > 0 THEN 1 ELSE 0 END )"

            End If


            If obj.VaoTre = 1 Then
                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END) "
            End If

            If obj.RaSom = 1 Then
                'strSQL += " RASOM = (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND (((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ' ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                'strSQL += " AND (NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + "  AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                'strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                'strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA ))) THEN 1"

                'strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) THEN 1 "

                'strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21  AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <=59) THEN 1 "

                'strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 05 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <=59) THEN 1 "
                'strSQL += " ELSE 0 END)"

                ''======== HET================

                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END)"
            End If

            If obj.VaoTreRaSom = 1 Then
                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END), "

                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                ''======== TRỪ 15H30 CA HÀNH CHÁNH: THAI THÁNG THỨ 7, NC 12 THÁNG
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END),"

                strSQL += " VAOTRERASOM = (CASE WHEN((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END)"
                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END)"
                strSQL += " ) > 0 THEN 1 ELSE 0 END)"

            End If

            ''====== tat ca = vao som + vao tre + ra som + ra tre cua tung nut => group by lại; neu co nguoi vưa vao tre vua ra som tinh la 1 dong
           
           
            If obj.Tatca = 1 Then
                strSQL += " VAOSOM =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END),"

                strSQL += " VAOTRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END), "

                strSQL += " RASOM = (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END),"


                strSQL += " RATRE =(CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"



            End If

            strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA "
            ''========= chỉ quẹt thẻ sai mới lấy ==============''
            If obj.VaoSom = 1 Then
                strSQL += " AND ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += "))) THEN 1  "

                strSQL += " ELSE 0 END)"
                strSQL += " > 0) "
            End If

            If obj.RaTre = 1 Then
                strSQL += " AND (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += ")) THEN 1  "

                strSQL += " ELSE 0 END )"
                strSQL += " > 0 "
            End If

            If obj.VaoSomRaTre = 1 Then
                strSQL += " AND (CASE WHEN ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1  "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 ELSE 0 END)) > 0 THEN 1 ELSE 0 END )"
                strSQL += " > 0 "
            End If

            ''=========================
            If obj.VaoTre = 1 Then
                strSQL += " AND (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) "
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1 "
                strSQL += " ELSE 0 END) "
                strSQL += " > 0 "
            End If

            If obj.RaSom = 1 Then
                strSQL += " AND (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END) >0"
            End If

            If obj.VaoTreRaSom = 1 Then
                strSQL += " AND ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30)  OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1 "
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1"
                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0) OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1  ELSE 0 END) "

                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21)  "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 "

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5)   "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1 ELSE 0 END)"

                strSQL += " ) > 0 "
            End If

            If obj.Tatca = 1 Then
                strSQL += " AND "
                strSQL += " ((CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE , giovao_" + obj.D_Ngay.ToString() + " ) <= 14) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 7 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 5 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 13 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) <= 44) OR ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) < 21 "
                strSQL += chuoiKhongTinhTangCa + chuoiDaChamCong
                strSQL += " ))) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 45) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 16 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 14 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 14 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 22 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) > 15) OR (DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) > 6 "
                strSQL += chuoiKhongTinhTangCa
                strSQL += " )) THEN 1 "
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 7 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 30)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 7) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 6 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 6) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 3' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 14  AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 14) THEN 1"

                strSQL += " WHEN loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' "
                strSQL += " AND ((DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) = 22 AND DATEPART(MINUTE  , giovao_" + obj.D_Ngay.ToString() + " ) > 0)"
                strSQL += " OR DATEPART(HOUR , giovao_" + obj.D_Ngay.ToString() + " ) > 22) THEN 1"
                strSQL += " ELSE 0 END)"

                strSQL += " + "

                strSQL += " (CASE WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA HC' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 16 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) < 30) "
                strSQL += " OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 16) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 2' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 13 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59)  OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 13)"
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 3'  AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 21 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 21) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " WHEN (loaica_" + obj.D_Ngay.ToString() + " = 'CA 4' AND  ((DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) = 5 AND DATEPART(MINUTE  , giora_" + obj.D_Ngay.ToString() + " ) <= 59) OR DATEPART(HOUR , giora_" + obj.D_Ngay.ToString() + " ) < 5) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_THAITHANGTHU7 WHERE BATDAUTU <=  " + obj.Ngay + "  AND DENNGAY >=  " + obj.Ngay + " AND MaNV = IT_THAITHANGTHU7.NV_MA ) "
                strSQL += " AND NOT exists (SELECT NV_MA FROM IT_NUOICONDUOI12THANG WHERE CONVERT(DATETIME,NGAYSANH,103) <=  " + obj.Ngay + "  AND DATEADD(YY,1,CONVERT(DATETIME,NGAYSANH,103)) >=  " + obj.Ngay + "  AND CHONNGAYSANH = 1 "
                strSQL += " AND MaNV = IT_NUOICONDUOI12THANG.NV_MA )) THEN 1"

                strSQL += " ELSE 0 END) "
                strSQL += ") > 0 "
            End If
            strSQL += " INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = ST_NHANVIEN.DV_MA AND DV_LOCBB = 0 AND DV_TV <> 1 "
            'Select Case obj.ChonXuong
            '    Case "TCT"
            '    Case "KHUA"
            '        strSQL += " AND ST_DONVI.X_MA_ NOT LIKE N'B%'"
            '    Case "KHUB"
            '        strSQL += " AND ST_DONVI.X_MA_ LIKE N'B%'"
            '    Case Else
            '        strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
            'End Select
            Select Case obj.Khu
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
            ''========= các đơn vị ngoại lệ không thống kê ========''
            strSQL += " AND ST_NHANVIEN.DV_MA NOT IN (SELECT DV_MA FROM V_DONVINGOAILE_THONGKEQUETTHESQD )"
            strSQL += " ORDER BY ST_DONVI.X_MA_ ,ST_DONVI.DV_MA ,loaica_" + obj.D_Ngay.ToString() + ""
        End If
        Return Me.execSQL(strSQL)
    End Function
    Public Function LoadThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Dim table As DataTable
        Try
            table = Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
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

End Class

