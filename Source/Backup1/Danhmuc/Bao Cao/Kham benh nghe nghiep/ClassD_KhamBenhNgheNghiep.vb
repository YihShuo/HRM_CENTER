Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.DataTable
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class ClassD_KhamBenhNgheNghiep
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As obj_KhamBenhNgheNghiep) As DataTable

        Dim table As DataTable
        Dim strSQL As String = ""
        'Load combo xuong
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG ORDER BY X_MA_")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT STT='',ST_NHANVIEN.NV_MA,NV_TEN ,ST_NHANVIEN.DV_MA,NV_GIOITINH = CASE WHEN NV_GIOITINH = 1 THEN 'NAM' ELSE N'NỮ' END,NV_Thuongtru ,NV_Ngayvao")
            strSQL = strSQL + " ,NGAY_KB = CONVERT(CHAR(10),NGAY_KB,105) ,THAMNIEN = (CASE WHEN YEAR(NV_NGAYVAO) = YEAR(NGAY_KB ) THEN CONVERT(NVARCHAR(50),YEAR(NV_NGAYVAO)) "
            strSQL = strSQL + " WHEN YEAR(NV_NGAYVAO) < YEAR(NGAY_KB) THEN CONVERT(NVARCHAR(50),YEAR(NGAY_KB) - YEAR(NV_NGAYVAO)) ELSE 0 END)"
            strSQL = strSQL + ",IT_KHAMBENHNGHENGHIEP.CV_HIENTAI ,ST_CONGVIEC.CV_TEN,ST_CHUCVU.CVU_TEN"
            strSQL = strSQL + ",NV_NGAYSINH=(CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),ST_NHANVIEN.NV_Ngaysinh,21),4)) END),NV_NAMSINH,NAMSINHNAM = (CASE WHEN NV_GIOITINH = 1 THEN YEAR(NV_NGAYSINH) ELSE NULL END)"
            strSQL = strSQL + ",NAMSINHNU = (CASE WHEN NV_GIOITINH = 0 THEN YEAR(NV_NGAYSINH) ELSE NULL END)"
            strSQL = strSQL + ",LD_CVBT ,LD_CNNNDH_L1 ,LD_CNNNDH_NGUYCO,LD_CNNNDH_L2 "
            strSQL = strSQL + ",TINHHINHBENH,HUONGDIEUTRI,CV_CHUYEN_KHAMSK"
            strSQL = strSQL + ",NGAYCHUYEN_SK,KL_KHAMSUCKHOE,PHANLOAI,KQ_HOHAP "
            strSQL = strSQL + ",KQ_THINHLUC ,NAM_PHATHIEN ,NGAYKHAMLAI,KQ_KHAMLAI,CV_CHUYEN_KHAMBNN,KL_KHAMNGHENGHIEP,IT_KHAMBENHNGHENGHIEP.GHICHU"
            ''========= thêm cột khám phụ khoa 
            strSQL = strSQL + " ,CHK_KHAMSAN = ISNULL(CHK_KHAMSAN ,0),IT_KHAMBENHNGHENGHIEP.TINHHINHBENH_SANKHOA ,IT_KHAMBENHNGHENGHIEP.KL_KHAMSAN,IT_KHAMBENHNGHENGHIEP.GHICHU_SANKHOA"

            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL = strSQL + " INNER JOIN IT_KHAMBENHNGHENGHIEP ON ST_NHANVIEN.NV_Ma = IT_KHAMBENHNGHENGHIEP.NV_MA "
            strSQL = strSQL + " LEFT JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL = strSQL + " LEFT JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA "

            strSQL = strSQL + " WHERE  NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_Ma = ST_NHANVIEN.NV_Ma )"
            If obj.CHONTONGQUAT = False And obj.CHONXUONG = True Then ''chon theo xuong
                strSQL = strSQL + " AND X_MA_ ='" & obj.XUONG & "'"
            End If
            '' ================== xem tong quat ===============''
            If obj.KHAMSUCKHOE = 1 Then
                If obj.KHONGBENH_SK = 1 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 0) AND (PHANLOAI IS NOT NULL OR PHANLOAI <> '') AND (TINHHINHBENH IS NULL OR TINHHINHBENH = '')"
                End If
                If obj.BENH_KHAMSK = 1 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 0) AND (TINHHINHBENH IS NOT NULL AND TINHHINHBENH <> '')"
                End If
                If obj.LV_NNDH = 1 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 0) AND (LD_CNNNDH_NGUYCO IS NOT NULL AND LD_CNNNDH_NGUYCO <> '')"
                End If
                ''==================== LAY TOAN BO DANH SACH KHAM SUC KHOE =============''
                If (obj.KHONGBENH_SK = 0) And (obj.BENH_KHAMSK = 0) And (obj.LV_NNDH = 0) Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 0)"
                End If
            End If
            If obj.KHAMBENHNGHENGHIEP = 1 Then
                If obj.KHONGBENH_NN = 1 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 1) AND ( (KQ_HOHAP LIKE LOWER(N'%bình thường%') OR  KQ_HOHAP  LIKE LOWER(N'%không%') OR KQ_HOHAP = '') AND (KQ_THINHLUC LIKE LOWER(N'%bình thường%') OR  KQ_THINHLUC  LIKE LOWER(N'%không%') OR KQ_THINHLUC = '') OR (NAM >= 2014 AND (TINHHINHBENH = '' AND TINHHINHBENH IS  NULL)) )"
                End If
                If obj.BENH_HOHAP = 1 And obj.BENH_THINHLUC = 0 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 1) AND ((KQ_HOHAP NOT LIKE LOWER(N'%bình thường%') AND KQ_HOHAP NOT LIKE LOWER(N'%không%') AND KQ_HOHAP <> '') OR (NAM >= 2014 AND (TINHHINHBENH <> '' AND TINHHINHBENH IS NOT NULL)))"
                End If
                If obj.BENH_THINHLUC = 1 And obj.BENH_HOHAP = 0 Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 1) AND ((KQ_THINHLUC NOT LIKE LOWER(N'%bình thường%') AND KQ_THINHLUC NOT LIKE LOWER(N'%không%') AND KQ_THINHLUC <> '') OR (NAM >= 2014 AND (TINHHINHBENH <> '' AND TINHHINHBENH IS NOT NULL)))"
                End If
                If obj.BENH_THINHLUC = 1 And obj.BENH_HOHAP = 1 Then
                    strSQL = strSQL + " AND ((KQ_HOHAP NOT LIKE LOWER(N'%bình thường%') AND KQ_HOHAP NOT LIKE LOWER(N'%không%') AND KQ_HOHAP <> '') OR (NAM >= 2014 AND (TINHHINHBENH <> '' AND TINHHINHBENH IS NOT NULL)))"
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 1) AND ((KQ_THINHLUC NOT LIKE LOWER(N'%bình thường%') AND KQ_THINHLUC NOT LIKE LOWER(N'%không%') AND KQ_THINHLUC <> '') OR (NAM >= 2014 AND (TINHHINHBENH <> '' AND TINHHINHBENH IS NOT NULL)))"
                End If
                ''==================== LAY TOAN BO DANH SACH BENH NGHE NGHIEP =============''
                If (obj.KHONGBENH_NN = 0) And (obj.BENH_HOHAP = 0) And (obj.BENH_THINHLUC = 0) Then
                    strSQL = strSQL + " AND (ISNULL(CHK_NGHENGHIEP,0) = 1)"
                End If
            End If

            If obj.KHAMSANKHOA = 1 Then
                ''==================== LAY TOAN BO DANH SACH CÓ KHÁM SẢN KHOA =============''
                If obj.KHONGBENH_PHUKHOA = 1 Then
                    strSQL = strSQL + " AND ISNULL(TINHHINHBENH_SANKHOA,'') = '' "
                Else
                    strSQL = strSQL + " AND (ISNULL(CHK_KHAMSAN,0) = 1)"
                End If
                strSQL = strSQL + " AND (ISNULL(CHK_KHAMSAN,0) = 1)"
            End If
            If obj.CHON_TUNAM And obj.CHON_DENNAM = False Then
                strSQL = strSQL + " AND NAM ='" & obj.TUNAM & "'"
            End If
            If obj.CHON_TUNAM And obj.CHON_DENNAM Then
                strSQL = strSQL + " AND NAM >='" & obj.TUNAM & "' AND NAM <='" & obj.DENNAM & "'"
            End If
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
    Public Function ThongKeTheoXuong(ByVal obj As obj_KhamBenhNgheNghiep, ByVal bChonDenNgay As Integer) As DataTable
        Dim table1 As DataTable
        Dim listpar As New ArrayList(1)
        Dim dataset As DataSet
        Try
            listpar.Add(New SqlParameter("@TuNam", obj.TUNAM))
            If bChonDenNgay = 1 Then
                listpar.Add(New SqlParameter("@DenNam", obj.DENNAM))
                dataset = Me.getDatasetProcedure("SP_TK_BENHNGHENGHIEP_TUNGXUONG_", listpar)
            Else
                dataset = Me.getDatasetProcedure("SP_TK_BENHNGHENGHIEP_TUNGXUONG", listpar)
            End If

            table1 = dataset.Tables(0)
            listpar.Clear()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            table1 = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return table1
    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

End Class
