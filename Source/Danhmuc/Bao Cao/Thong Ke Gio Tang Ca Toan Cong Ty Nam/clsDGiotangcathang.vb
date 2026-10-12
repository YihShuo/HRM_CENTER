Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Imports System.Data.SqlClient

Public Class clsDGiotangcathang
    Inherits DALSQL
    ' Events
    Public Event _error As _errorEventHandler
    Public Function LoadDS(ByVal obj As objGiotangcathang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""


        If obj.ChonBang = 1 Then
            strSQL = ("SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT TOP 1 NV_MA FROM ST_NHANVIEN WHERE DV_MA ='" & Me.QuoteString(obj.DONVI) & "' ")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT DV_MA,DV_TEN FROM ST_DONVI ORDER BY DV_MA ")
        End If

        If obj.ChonBang = 4 Then
            strSQL = ("SELECT DV_MA,DV_TEN FROM ST_DONVI WHERE N_MA NOT IN ('BGD','CG') AND DV_MA NOT LIKE 'DT%' AND X_MA_ ='" & Me.QuoteString(obj.MANX) & "' ORDER BY DV_MA ")
        End If

        If obj.ChonBang = 5 Then
            strSQL = ("SELECT IT_DONVITHONGKE.DV_MA,DV_TEN FROM IT_DONVITHONGKE INNER JOIN ST_DONVI ON IT_DONVITHONGKE.DV_MA = ST_DONVI.DV_MA WHERE IT_DONVITHONGKE.DV_MA ='" & Me.QuoteString(obj.DONVITHONGKE) & "' ORDER BY IT_DONVITHONGKE.DV_MA ")
        End If

        If obj.ChonBang = 6 Then
            strSQL = ("SELECT IT_DONVITHONGKE.DV_MA ,DV_TEN,X_MA_  FROM IT_DONVITHONGKE INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = IT_DONVITHONGKE.DV_MA ORDER BY X_MA_,IT_DONVITHONGKE.DV_MA ")
        End If

        If obj.ChonBang = 7 Then
            strSQL = ("SELECT TOP 1 IT_DONVITHONGKE.DV_MA  FROM IT_DONVITHONGKE ")
        End If

        If obj.ChonBang = 8 Then
            strSQL = ("SELECT COUNT(*) SLXUONG FROM (select X_MA_ as SLXUONG from IT_DONVITHONGKE inner join ST_DONVI on IT_DONVITHONGKE.DV_MA = ST_DONVI.DV_MA  group by X_MA_ ) AS V ")
        End If

        If obj.ChonBang = 9 Then
            strSQL = ("SELECT TOP 1 IT_DONVITHONGKE.DV_MA  FROM IT_DONVITHONGKE INNER JOIN ST_DONVI ON ST_DONVI.DV_MA = IT_DONVITHONGKE.DV_MA WHERE X_MA_ ='" & obj.MANX & "'")
        End If


        If obj.ChonBang = 66 Then
            strSQL = ("SELECT TOP 1 NV_MA FROM IT_DIEMDANHHANGNGAY where  NGAY = N'" & Me.QuoteString(obj.Ngay) & "' ")
        End If
        ''=================== PHAN QUYEN THEM XOA SUA FORM NHAP PHEP =================''
        If obj.ChonBang = 67 Then
            strSQL = ("SELECT * from JELL_USER WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "'")
        End If

        If obj.ChonBang = 68 Then
            strSQL = ("SELECT * from JELL_QUYENTRUYCAP INNER JOIN JELL_USER ON JELL_QUYENTRUYCAP.Ten_DangNhap = JELL_USER.Ten_DangNhap WHERE JELL_QUYENTRUYCAP.Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap) & "' AND (Ma_DM ='1frmgiotangcathang' OR Ma_DM ='2frmgiotangcathang') ")
        End If
        ''======= load tat ca xuong
        If obj.ChonBang = 10 Then
            strSQL = ("SELECT X_MA_ FROM ST_DONVI WHERE ISNULL(DV_LocBB,0)= 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' GROUP BY X_MA_")
        End If
        ''========= load tat ca don vi ===========
        If obj.ChonBang = 11 Then
            strSQL = ("SELECT DV_MA  FROM  ST_DONVI " & " WHERE ISNULL(DV_LocBB,0)= 0 AND ISNULL(DV_TV,0) <> 1  AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%'  ORDER BY DV_MA  ")
        End If
        ''======= load don vi theo xương ==========
        If obj.ChonBang = 12 Then
            strSQL = ("  SELECT DV_MA  FROM  ST_DONVI  WHERE ISNULL(DV_LocBB,0)= 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%'  AND  X_MA_ = N'" & obj.DONVI & "'   ORDER BY DV_MA")
        End If

        If obj.ChonBang = 13 Then
            strSQL = ("  SELECT X_MA_ FROM V_DONVITHONGKECONGNGOAILE")
        End If

        If obj.ChonBang = 14 Then
            strSQL = ("  SELECT X_MA_  FROM  ST_DONVI  " & " WHERE  N_MA <> 'CG' AND X_MA_ <> 'KB'  AND N_MA <> 'BGD' AND X_MA_ = '" & obj.DONVI & "' group by x_ma_")
        End If
        ''========== KHU  
        If obj.ChonBang = 15 Then
            strSQL = ("SELECT X_MA_  FROM  ST_DONVI WHERE  DV_MA NOT LIKE '%CG%' AND  DV_MA NOT LIKE '%BGD%'  AND DV_LOCBB = 0 AND  KHU ='" & obj.KHU & "' AND X_MA_ <> 'TAM' GROUP BY X_MA_ ")
        End If
 
 
        If obj.ChonBang = 17 Then
            strSQL = ("  SELECT X_MA_  FROM  ST_NXUONG  WHERE   X_MA_ = N'" & obj.DONVI & "'")
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
    Public Function InsertDonvi(ByVal obj As objGiotangcathang) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into IT_DONVITHONGKE (DV_MA) SELECT DV_MA FROM ST_DONVI WHERE N_MA NOT IN ('BGD','CG') AND DV_MA NOT LIKE 'DT%'  AND X_MA_ ='", Me.QuoteString(obj.MANX)}) & "' ORDER BY DV_MA " & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")

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
    Public Function ThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)

    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)

    End Function
    Public Function ThuTucThongKeGioCong(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        'Return Me.getTableProcedure(m_sSP_Name, SqlParam)

        Dim table As DataTable
        'Thuc thi cau truy van
        Try
            table = Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table

    End Function

    Public Function ThongKeGioCong(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        'Return Me.getTableProcedure(m_sSP_Name, SqlParam)

        Dim table As DataTable
        'Thuc thi cau truy van
        Try
            table = Me.getTableProcedure(m_sSP_Name, SqlParam)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table

    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function LoadTruyVanThongKeGioCong(ByVal obj As objGiotangcathang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        Dim bienngay_Thangbd As Integer = 1
        Dim bienngay_Thangkt As Integer = 1
        ''======= khác tháng: ngày bd, ngày kt đều là 1
        If obj.ChonBang = 18 Then
            strSQL = "SELECT TEN,SOTHE,DONVI,NGAYVAO=NV_NGAYVAO,CV_TEN,XUONG"
            strSQL += " ,TONGBT = SUM(BT),TONGTC = SUM(TC) "
            strSQL += " FROM ("

            ''======= TINH CHO THANG BD
            strSQL += " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_DONVI.DV_TEN,XUONG=ST_DONVI.X_MA_ "
            strSQL += " ,NV_NGAYVAO,ST_CONGVIEC.CV_TEN ,BT=SUM("

            For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD    ''  For bienngay_Thangbd = 1 To obj.NGAYKT_THANGBD
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TC=SUM("
            For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD
                strSQL = strSQL + " ISNULL(GIOTANGCA_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI  "
            strSQL += " ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA AND ST_DONVI.DV_LOCBB = 0 AND DV_TV <> 1 "
            strSQL += " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL += " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL += " WHERE THANG >= " + Me.QuoteString(obj.THANGBD) + " AND THANG <=" + Me.QuoteString(Convert.ToInt32(obj.THANGKT) - 1) + ""
            strSQL += " AND NAM= " + Me.QuoteString(obj.Nam) + ""

            Select Case obj.ChonKhu
                Case 0
                    Select Case obj.ChonXuong
                        Case "TCT"
                        Case Else
                            strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                    End Select
                Case 1
                    Select Case obj.KHU
                        Case "A", "B", "DVC"
                            strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                    End Select
            End Select
         
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
            strSQL += " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma ,ST_DONVI.DV_TEN,ST_DONVI.X_MA_,NV_NGAYVAO,ST_CONGVIEC.CV_TEN "

            ''======= TINH CHO THANG KT
            strSQL += " UNION "

            strSQL += " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_DONVI.DV_TEN,XUONG=ST_DONVI.X_MA_ "
            strSQL += " ,NV_NGAYVAO,ST_CONGVIEC.CV_TEN ,BT=SUM("

            For bienngay_Thangkt = 1 To obj.NGAYKT_THANGKT
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(bienngay_Thangkt) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TC=SUM("
            For bienngay_Thangkt = 1 To obj.NGAYKT_THANGKT
                strSQL = strSQL + " ISNULL(GIOTANGCA_" & Me.QuoteString(bienngay_Thangkt) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI  "
            strSQL += " ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA AND ST_DONVI.DV_LOCBB = 0 AND DV_TV <> 1 "
            strSQL += " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL += " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL += " WHERE THANG = " + Me.QuoteString(obj.THANGKT) + ""
            strSQL += " AND NAM= " + Me.QuoteString(obj.Nam) + ""
            Select Case obj.ChonKhu
                Case 0
                    Select Case obj.ChonXuong
                        Case "TCT"
                        Case Else
                            strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                    End Select
                Case 1
                    Select Case obj.KHU
                        Case "A", "B", "DVC"
                            strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                    End Select
            End Select
            strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
            strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
            strSQL += " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma ,ST_DONVI.DV_TEN,ST_DONVI.X_MA_,NV_NGAYVAO,ST_CONGVIEC.CV_TEN "
            ''==== VONG SUM LON O NGOAI
            strSQL += " ) AS V "
            strSQL += " GROUP BY XUONG,DONVI,SOTHE,TEN,NV_NGAYVAO,CV_TEN  "
            strSQL += " ORDER BY XUONG,DONVI,SOTHE,TEN,NV_NGAYVAO,CV_TEN "
        End If

        ''========== theo tung thang: lap tung xuong ===============
        If obj.ChonBang = 19 Then
            strSQL = " SELECT TONGGIOBT.NV_TEN AS TEN"
            strSQL += " ,TONGGIOBT.NV_MA AS SOTHE"
            strSQL += " ,TONGGIOBT.DV_TEN AS DONVI"
            strSQL += " ,TONGGIOBT.DV_MA"
            strSQL += " ,TONGGIOBT.NV_NGAYVAO AS NGAYVAO"
            strSQL += " ,TONGGIOBT.CV_TEN"
            strSQL += " ,NV_GioiTinh = CASE WHEN ISNULL (NV_GIOITINH,0) = 1 THEN 'NAM' ELSE N'NỮ' END"
            strSQL += " ,TONGGIOBT.NAM"
            strSQL += " ,X_MA_ AS XUONG"
            strSQL += " ,ISNULL([1],0) AS [BT1]"
            strSQL += " ,[TC1]"
            strSQL += " ,ISNULL([2],0) AS [BT2]"
            strSQL += " ,[TC2]"
            strSQL += " ,ISNULL([3],0) AS [BT3]"
            strSQL += " ,[TC3]"
            strSQL += " ,ISNULL([4],0) AS [BT4]"
            strSQL += " ,[TC4]"
            strSQL += " ,ISNULL([5],0) AS [BT5]"
            strSQL += " ,[TC5]"
            strSQL += " ,ISNULL([6],0) AS [BT6]"
            strSQL += " ,[TC6]"
            strSQL += " ,ISNULL([7],0) AS [BT7]"
            strSQL += " ,[TC7]"
            strSQL += " ,ISNULL([8],0) AS [BT8]"
            strSQL += " ,[TC8]"
            strSQL += " ,ISNULL([9],0) AS [BT9]"
            strSQL += " ,[TC9]"
            strSQL += " ,ISNULL([10],0) AS [BT10]"
            strSQL += " ,[TC10]"
            strSQL += " ,ISNULL([11],0) AS [BT11]"
            strSQL += " ,[TC11]"
            strSQL += " ,ISNULL([12],0) AS [BT12]"
            strSQL += " ,[TC12]"
            strSQL += " ,TONGGBT = SUM(ISNULL([1],0)+ISNULL([2],0)+ISNULL([3],0) +ISNULL([4],0) +ISNULL([5],0)+ISNULL([6],0) +ISNULL([7],0)+ISNULL([8],0) +ISNULL([9],0) +ISNULL([10],0) +ISNULL([11],0) +ISNULL([12],0) )"
            strSQL += " ,TONGGTC = SUM([TC1]+[TC2]+[TC3]+[TC4]+[TC5]+[TC6]+[TC7]+[TC8]+[TC9]+[TC10]+[TC11]+[TC12] )"
            strSQL += " FROM ("
            strSQL += " SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_NGAYVAO,ST_NHANVIEN.NV_MA"
            strSQL += " ,ST_DONVI.DV_MA"
            strSQL += " ,ST_DONVI.DV_TEN,NAM,THANG,X_MA_ "
            strSQL += " ,ST_CONGVIEC.CV_TEN ,NV_GioiTinh"
            strSQL += " , SUM(ISNULL(GIOBINHTHUONG_1,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_2,0))"
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_3,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_4,0))"
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_5,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_6,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_7,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_8,0))"
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_9,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_10,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_11,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_12,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_13,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_14,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_15,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_16,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_17,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_18,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_19,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_20,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_21,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_22,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_23,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_24,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_25,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_26,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_27,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_28,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_29,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_30,0)) "
            strSQL += " + SUM(ISNULL(GIOBINHTHUONG_31,0)) AS TONGBT"

            strSQL += "  FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += "  ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA "
            strSQL += "  AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
            strSQL += "  INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL += "  AND ST_DONVI.DV_LOCBB = 0 AND ST_DONVI.DV_TV <> 1 "
            strSQL += "  AND ST_DONVI.DV_MA NOT LIKE '%CG%' "
            strSQL += "  AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL += "  LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL += " WHERE (NAM= " + Me.QuoteString(obj.Nam) + ""
            strSQL += " AND THANG >= " + Me.QuoteString(obj.THANGBD) + " AND THANG <=" + Me.QuoteString(obj.THANGKT) + ")"
            Select Case obj.ChonKhu
                Case 0
                    Select Case obj.ChonXuong
                        Case "TCT"
                        Case Else
                            strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                    End Select
                Case 1
                    Select Case obj.KHU
                        Case "A", "B", "DVC"
                            strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                    End Select
            End Select

            strSQL += "  GROUP BY ST_DONVI.DV_MA,ST_DONVI.DV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.NV_NGAYVAO,ST_CONGVIEC.CV_TEN,NV_Ten ,NAM,THANG,X_MA_ ,NV_GioiTinh) AS SOURE "
            strSQL += "  PIVOT(SUM(TONGBT)FOR  THANG IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])"
            strSQL += "  ) AS TONGGIOBT INNER JOIN "
            strSQL += "  ("
            strSQL += "  SELECT NV_TEN,NV_NGAYVAO,NV_MA,DV_MA,NAM"
            strSQL += "  ,ISNULL([1],0) AS [TC1]"
            strSQL += "  ,ISNULL([2],0) AS [TC2]"
            strSQL += "  ,ISNULL([3],0) AS [TC3]"
            strSQL += "  ,ISNULL([4],0) AS [TC4]"
            strSQL += "  ,ISNULL([5],0) AS [TC5]"
            strSQL += "  ,ISNULL([6],0) AS [TC6]"
            strSQL += "  ,ISNULL([7],0) AS [TC7]"
            strSQL += "  ,ISNULL([8],0) AS [TC8]"
            strSQL += "  ,ISNULL([9],0) AS [TC9]"
            strSQL += "  ,ISNULL([10],0) AS [TC10]"
            strSQL += "  ,ISNULL([11],0) AS [TC11]"
            strSQL += " ,ISNULL([12],0) AS [TC12] "
            strSQL += "  FROM ("
            strSQL += "  SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_NGAYVAO,ST_NHANVIEN.NV_MA"
            strSQL += "  ,ST_DONVI.DV_MA"
            strSQL += "  ,ST_DONVI.DV_TEN,NAM,THANG,X_MA_,NV_GioiTinh"

            strSQL += "  ,SUM(ISNULL(GIOTANGCA_1,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_2,0))"
            strSQL += "  + SUM(ISNULL(GIOTANGCA_3,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_4,0))"
            strSQL += "  + SUM(ISNULL(GIOTANGCA_5,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_6,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_7,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_8,0))"
            strSQL += "  + SUM(ISNULL(GIOTANGCA_9,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_10,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_11,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_12,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_13,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_14,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_15,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_16,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_17,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_18,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_19,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_20,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_21,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_22,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_23,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_24,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_25,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_26,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_27,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_28,0)) "
            strSQL += "  + SUM(ISNULL(GIOTANGCA_29,0)) "
            strSQL += " + SUM(ISNULL(GIOTANGCA_30,0)) "
            strSQL += " + SUM(ISNULL(GIOTANGCA_31,0))  AS TONG "

            strSQL += "  FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
            strSQL += "  ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA "
            strSQL += "  AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
            strSQL += "  INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI.DV_MA "
            strSQL += "  AND ST_DONVI.DV_LOCBB = 0 AND ST_DONVI.DV_TV <> 1 "
            strSQL += "  AND ST_DONVI.DV_MA NOT LIKE '%CG%' "
            strSQL += "  AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
            strSQL += "  INNER JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
            strSQL += "  WHERE (NAM= " + Me.QuoteString(obj.Nam) + ""
            strSQL += "  AND THANG >= " + Me.QuoteString(obj.THANGBD) + " AND THANG <=" + Me.QuoteString(obj.THANGKT) + ")"
            Select Case obj.ChonKhu
                Case 0
                    Select Case obj.ChonXuong
                        Case "TCT"
                        Case Else
                            strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                    End Select
                Case 1
                    Select Case obj.KHU
                        Case "A", "B", "DVC"
                            strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                    End Select
            End Select
            strSQL += "  GROUP BY ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_NGAYVAO,ST_NHANVIEN.NV_MA"
            strSQL += " ,ST_DONVI.DV_MA,ST_DONVI.DV_TEN,NAM,THANG,X_MA_ ,NV_GioiTinh) AS SOURE "
            strSQL += " PIVOT(SUM(TONG)FOR THANG IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])"
            strSQL += " ) AS TC"
            strSQL += " )AS TONGTANGCA ON TONGGIOBT.NV_Ma = TONGTANGCA .NV_Ma "
            strSQL += "  AND TONGGIOBT.DV_Ma = TONGTANGCA.DV_MA"
            strSQL += "  AND  TONGGIOBT.NV_Ngayvao  = TONGTANGCA .NV_Ngayvao"
            strSQL += "  WHERE  TONGGIOBT.NV_MA NOT IN(SELECT NV_Ma FROM ST_NHANVIENTHOIVIEC WHERE TONGGIOBT.NV_MA = ST_NHANVIENTHOIVIEC.NV_Ma )"

            strSQL += "  GROUP BY X_MA_ ,TONGGIOBT.DV_MA,TONGGIOBT.DV_TEN ,TONGGIOBT.NV_MA ,TONGGIOBT.NV_TEN ,TONGGIOBT.NV_NGAYVAO ,TONGGIOBT.CV_TEN"
            strSQL += "  ,TONGGIOBT.NAM,ISNULL([1],0),ISNULL([2],0) ,ISNULL([3],0) ,ISNULL([4],0) ,ISNULL([5],0) ,ISNULL([6],0) ,ISNULL([7],0) ,ISNULL([8],0) ,ISNULL([9],0) ,ISNULL([10],0),ISNULL([11],0) ,ISNULL([12],0) "
            strSQL += "  ,[TC1],[TC2],[TC3],[TC4],[TC5],[TC6],[TC7],[TC8],[TC9],[TC10],[TC11],[TC12] ,NV_GioiTinh"

            strSQL += "  ORDER BY X_MA_ ,TONGGIOBT.DV_MA,TONGGIOBT.DV_TEN ,TONGGIOBT.NV_MA ,TONGGIOBT.NV_TEN ,TONGGIOBT.NV_NGAYVAO ,TONGGIOBT.CV_TEN,TONGGIOBT.NAM"
            strSQL += "  ,ISNULL([1],0),ISNULL([2],0) ,ISNULL([3],0) ,ISNULL([4],0) ,ISNULL([5],0) ,ISNULL([6],0) ,ISNULL([7],0) ,ISNULL([8],0) ,ISNULL([9],0) ,ISNULL([10],0),ISNULL([11],0) ,ISNULL([12],0) "
            strSQL += " ,[TC1],[TC2],[TC3],[TC4],[TC5],[TC6],[TC7],[TC8],[TC9],[TC10],[TC11],[TC12] ,NV_GioiTinh"
        End If

        If obj.ChonBang = 20 Then
            Select Case obj.CHONCUNGTHANG
                Case 1
                    strSQL = "SELECT DONVI=ST_DONVI.DV_TEN ,XUONG=ST_DONVI.X_MA_"
                    strSQL += " ,TONGBT=SUM( "
                    For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD
                        strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + ",TONGTC=SUM("
                    For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD
                        strSQL = strSQL + " ISNULL(GIOTANGCA_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
                    strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI  "
                    strSQL += " ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA AND ST_DONVI.DV_LOCBB = 0 AND DV_TV <> 1 "
                    strSQL += " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
                    strSQL += " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
                    strSQL += " WHERE THANG = " + Me.QuoteString(obj.THANGBD) + ""
                    strSQL += " AND NAM= " + Me.QuoteString(obj.Nam) + ""

                    Select Case obj.ChonKhu
                        Case 0
                            Select Case obj.ChonXuong
                                Case "TCT"
                                Case Else
                                    strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                            End Select
                        Case 1
                            Select Case obj.KHU
                                Case "A", "B", "DVC"
                                    strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                            End Select
                    End Select
                    strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
                    strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
                    strSQL += " GROUP BY X_MA_,ST_DONVI.DV_MA,ST_DONVI.DV_TEN "
                    strSQL += " ORDER BY X_MA_,ST_DONVI.DV_MA,ST_DONVI.DV_TEN "

                Case 0
                    ''============= KHÁC THÁNG 
                    strSQL = "SELECT DONVI ,XUONG ,TONGBT = SUM(TONGBT),TONGTC= SUM(TONGTC)"
                    strSQL += " FROM ("
                    ''======= TINH CHO THANG BAT DAU

                    strSQL += "SELECT DONVI=ST_DONVI.DV_TEN ,XUONG=ST_DONVI.X_MA_"
                    strSQL += " ,TONGBT=SUM( "
                    For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD
                        strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + ",TONGTC=SUM("
                    For bienngay_Thangbd = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGBD
                        strSQL = strSQL + " ISNULL(GIOTANGCA_" & Me.QuoteString(bienngay_Thangbd) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
                    strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI  "
                    strSQL += " ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA AND ST_DONVI.DV_LOCBB = 0 AND DV_TV <> 1 "
                    strSQL += " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
                    strSQL += " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
                    strSQL += " WHERE THANG >= " + Me.QuoteString(obj.THANGBD) + " AND THANG <= " + Me.QuoteString(Convert.ToInt32(obj.THANGKT) - 1) + ""
                    strSQL += " AND NAM= " + Me.QuoteString(obj.Nam) + ""
                    Select Case obj.ChonKhu
                        Case 0
                            Select Case obj.ChonXuong
                                Case "TCT"
                                Case Else
                                    strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                            End Select
                        Case 1
                            Select Case obj.KHU
                                Case "A", "B", "DVC"
                                    strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                            End Select
                    End Select
                    strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
                    strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
                    strSQL += " GROUP BY X_MA_,ST_DONVI.DV_MA,ST_DONVI.DV_TEN "

                    ''======= TINH CHO THANG KET THUC
                    strSQL += " UNION "

                    strSQL += "SELECT DONVI=ST_DONVI.DV_TEN ,XUONG=ST_DONVI.X_MA_"
                    strSQL += " ,TONGBT=SUM( "
                    For bienngay_Thangkt = obj.NGAYBD_THANGKT To obj.NGAYKT_THANGKT
                        strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(bienngay_Thangkt) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + ",TONGTC=SUM("
                    For bienngay_Thangkt = obj.NGAYBD_THANGBD To obj.NGAYKT_THANGKT
                        strSQL = strSQL + " ISNULL(GIOTANGCA_" & Me.QuoteString(bienngay_Thangkt) & ",0)+"
                    Next
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL += " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN "
                    strSQL += " ON ST_VAORA_MACHINE.MANV = ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI  "
                    strSQL += " ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA AND ST_DONVI.DV_LOCBB = 0 AND DV_TV <> 1 "
                    strSQL += " AND ST_DONVI.DV_MA NOT LIKE '%CG%' AND ST_DONVI.DV_MA NOT LIKE '%BGD%' "
                    strSQL += " LEFT JOIN ST_CONGVIEC ON ST_NHANVIEN.CV_MA = ST_CONGVIEC.CV_MA "
                    strSQL += " WHERE THANG = " + Me.QuoteString(obj.THANGKT) + ""
                    strSQL += " AND NAM= " + Me.QuoteString(obj.Nam) + ""

                    Select Case obj.ChonKhu
                        Case 0
                            Select Case obj.ChonXuong
                                Case "TCT"
                                Case Else
                                    strSQL += " AND ST_DONVI.X_MA_ ='" + obj.ChonXuong + "'"
                            End Select
                        Case 1
                            Select Case obj.KHU
                                Case "A", "B", "DVC"
                                    strSQL += " AND ST_DONVI.KHU  ='" + obj.KHU + "'"
                            End Select
                    End Select
                    strSQL += " AND ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) "
                    strSQL += " AND ST_NHANVIEN.NV_NGAYVAO <= '" + obj.DENNGAY + "'"
                    strSQL += " GROUP BY X_MA_,ST_DONVI.DV_MA,ST_DONVI.DV_TEN "

                    strSQL += "  ) AS V "
                    strSQL += " GROUP BY XUONG ,DONVI"
                    strSQL += " ORDER BY XUONG ,DONVI"


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

End Class

