Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.CompilerServices
Public Class ClsDBaoCaoGioCongNgay
''============sdsdsdssds
    ''===== người tạo :Trân
    ''===== ngày tạo: 2011
    ''===== nội dung: thống kê giờ công vượt quá từ bảng vào ra machine
    ''===== người sửa: Trân
    ''===== ngày sửa: 29/05/2014
    ''===== nội dung: sửa tiêu chuẩn vượt quá lại theo ngày:4, tuần:12, tháng:30, năm:280
    Inherits DALSQL
    Public Function DeleteInfo(ByVal obj As ObjBaoCaoGioCongNgay) As Boolean
    End Function
    Public Function InsertInfo(ByVal obj As ObjBaoCaoGioCongNgay) As Boolean
    End Function
    Public Function LoadDS(ByVal obj As ObjBaoCaoGioCongNgay, ByVal khu As String) As DataTable
        Dim table As DataTable
        Dim sqlDK As String
        Dim s As String = obj.KHU

        If khu = "TCT" Then
            sqlDK = sqlDK
        ElseIf khu = "A" Then
            sqlDK = " and ST_DONVI .KHU = 'A' "
        ElseIf khu = "B" Then
            sqlDK = " and ST_DONVI .KHU = 'B' "
        ElseIf khu = "DVC" Then
            sqlDK = " and ST_DONVI .KHU = 'DVC' "
        End If


        Dim strSQL As String = ""
        ''load combo ma xuong

        If obj.ChonBang = 1 Then
            strSQL = strSQL + "SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ "
            strSQL = strSQL + sqlDK
            strSQL = strSQL + " GROUP BY X_MA_) "
            strSQL = strSQL + " ORDER BY X_MA_ "


        End If
        ''load combo ma donvi
        If obj.ChonBang = 2 Then
            strSQL = strSQL + "SELECT DV_MA FROM ST_DONVI WHERE ISNULL(DV_LocBB ,0) = 0 AND  ISNULL(DV_TV ,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%'  "
            strSQL = strSQL + sqlDK
            strSQL = strSQL + " ORDER BY DV_MA  "


        End If
        ''LAY NGAY CONG 
        If obj.ChonBang = 3 Then
            Dim nam As Integer
            Dim thang As Integer
            Dim ngay As Integer
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            ngay = obj.NGAY.Day
            thang = obj.NGAY.Month
            nam = obj.NGAY.Year
            madv = obj.MADV
            manx = obj.MANX
            'truy van
            strSQL = strSQL + "SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + "GIOBINHTHUONG=ISNULL(GIOBINHTHUONG_" & Me.QuoteString(ngay) & ",0)"
            strSQL = strSQL + ",GIOTANGCA=ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0),TONGGIOCONG = ISNULL(GIOBINHTHUONG_" & Me.QuoteString(ngay) & ",0)+ ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0)"
            strSQL = strSQL + ",GIOCCONGVUOTQUA= (CASE WHEN (ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0)<=4.0) THEN '0'"
            strSQL = strSQL + " ELSE (GIOTANGCA_" & Me.QuoteString(ngay) & "- 4.0) END)"
            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE THANG='" & Me.QuoteString(thang) & "'"
            strSQL = strSQL + " AND NAM='" & Me.QuoteString(nam) & "'"
            strSQL = strSQL + " AND isnull(DV_TV,0) <> 1 and isnull(DV_LocBB,0) = 0"
            strSQL = strSQL + " and ST_DONVI.DV_MA not like '%CG%' and ST_DONVI.DV_MA not like 'BGD%' AND NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_VAORA_MACHINE.MaNV = ST_NHANVIENTHOIVIEC.NV_MA )"
            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
            Else
                If manx = "" Then
                    strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                End If
            End If
            If madv <> "" And manx <> "" Then
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
            End If


        End If

        'dkhien combo donvi theo xuong
        If obj.ChonBang = 4 Then
            strSQL = strSQL + "select dv_ma from st_nxuong inner join st_donvi on st_donvi.x_ma_=st_nxuong.x_ma_"
            strSQL = strSQL + " where  st_donvi.x_ma_='" & Me.QuoteString(obj.MANX) & "' and ISNULL(DV_LocBB ,0) = 0 AND  ISNULL(DV_TV ,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%'"
        End If

        'TINH THEO TUAN
        If obj.ChonBang = 5 Then
            '''======DECLARE SQL
            Dim TUNGAY As DateTime
            Dim DENNGAY As DateTime
            Dim NAMTN As Integer
            Dim THANGTN As Integer
            Dim NGAYTN As Integer
            Dim NAMDN As Integer
            Dim THANGDN As Integer
            Dim NGAYDN As Integer
            'Dim LAYSONGAY As Integer
            Dim I As Integer
            Dim J As Integer
            '==============DIM BIEN CUA VB=============================
            Dim nam As Integer
            Dim thang As Integer
            Dim ngay As Integer
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            ngay = obj.NGAY.Day
            thang = obj.NGAY.Month
            nam = obj.NGAY.Year
            madv = obj.MADV
            manx = obj.MANX
            '=============la code GAN GIA TRI CUA SQL
            ''******TEXTBOX TU NGAY
            NAMTN = obj.NGAY1.Year   ''lay ra nam trong textbox tu ngay
            THANGTN = obj.NGAY1.Month
            NGAYTN = obj.NGAY1.Day
            ''*****TEXTBOX DEN NGAY
            NAMDN = obj.NGAY2.Year
            NGAYDN = obj.NGAY2.Day
            THANGDN = obj.NGAY2.Month
            '''=======trong nam
            If NAMTN = NAMDN Then
                If THANGTN < THANGDN Then

                    strSQL = strSQL + "SELECT TEN=NV_TEN,SOTHE=NV_MA,DONVI=DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA)"
                    strSQL = strSQL + ",TONGGIOCONG=SUM(GIOCONGCHINH)+SUM(GIOCONGTANGCA),GIOCONGVUOTQUA=(CASE WHEN(SUM(GIOCONGTANGCA)<=12.0) THEN '0'"
                    strSQL = strSQL + " ELSE (SUM(GIOCONGTANGCA)-12.0) END) FROM "
                    I = NGAYTN
                    strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("

                    While I <= Songay(NAMTN, THANGTN)
                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
                    I = NGAYTN
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While I <= Songay(NAMTN, THANGTN)
                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM= " & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

                    If madv = "" Then
                        strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                    Else
                        strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                    End If

                    ''====================TINH THANG HIEN TAI (2THANG KHAC NHAU NAM TRONG 1TUAN)
                    J = 1
                    strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    J = 1
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGDN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

                    If madv = "" Then
                        strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                        strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    Else
                        strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                        strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    End If
                    ''*******************************TRONG THANG******************************************

                Else
                    If THANGTN = THANGDN Then
                        I = NGAYTN
                        strSQL = "SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_NHANVIEN.DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM("
                        While I <= NGAYDN

                            strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                        While I <= NGAYDN


                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",TONGGIOCONG=SUM("

                        While I <= NGAYDN


                            strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("

                        While I <= NGAYDN
                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While
                        strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 12.0) THEN '0' ELSE("

                        I = NGAYTN
                        While I <= NGAYDN
                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While
                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")-12.0 END)"

                        strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                        strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                        strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

                        If madv = "" Then
                            strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                        Else
                            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                        End If
                        ''********HAVING TUAN(TRONG NAM)*********
                        'I = NGAYTN
                        'strSQL = strSQL + " HAVING SUM("
                        'While I <= NGAYDN
                        '    strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        '    I = I + 1
                        'End While
                        'strSQL = Left(strSQL, Len(strSQL) - 1) + ")>12"
                    End If 'cua else If THANGTN = THANGDN Then
                End If
            End If

            ''===========================***********************NAM MOI***********************************======================
            If NAMTN <> NAMDN Then

                If THANGTN > THANGDN Then

                    strSQL = "SELECT TEN=NV_TEN,SOTHE=NV_MA,DONVI=DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA)"
                    strSQL = strSQL + ",TONGGIOCONG=SUM(GIOCONGCHINH)+SUM(GIOCONGTANGCA),GIOCONGVUOTQUA=CASE WHEN(SUM(GIOCONGTANGCA)<= 12.0) THEN '0' "
                    strSQL = strSQL + " ELSE(SUM(GIOCONGTANGCA)-12.0) END FROM "
                    I = NGAYTN
                    strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While I <= Songay(NAMTN, THANGTN)


                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    I = NGAYTN
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While I <= Songay(NAMTN, THANGTN)


                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

                    If madv = "" Then
                        strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                    Else
                        strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                    End If
                    ''tinh nam moi********************************NAM MOI****************************

                    J = 1
                    strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    J = 1
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGDN) & " AND NAM=" & Me.QuoteString(NAMDN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

                    If madv = "" Then
                        strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                        strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    Else
                        strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                        strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    End If
                    'strSQL = strSQL + " HAVING SUM(GIOCONGTANGCA)>12"
                End If
            End If
        End If
        ''Load THANG
        If obj.ChonBang = 6 Then
            Dim NAM As Integer
            Dim THANG As Integer
            Dim I As Integer
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            THANG = obj.NGAY.Month
            NAM = obj.NGAY.Year
            madv = obj.MADV
            manx = obj.MANX

            strSQL = " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 30) THEN '0' ELSE ("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG=" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            Else
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            End If
        End If
        'dieu kien vuot qua thang
        'strSQL = strSQL + " HAVING SUM("
        'For I = 1 To 31
        '    strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
        'Next
        'strSQL = Left(strSQL, Len(strSQL) - 1) + ")>60"

        ''LOAD NAM
        If obj.ChonBang = 8 Then
            Dim NAM As Integer
            Dim THANG As Integer
            Dim ngay As Integer
            Dim I As Integer = 1
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            NAM = obj.NGAY.Year
            THANG = obj.NGAY.Month
            ngay = obj.NGAY.Day
            madv = obj.MADV
            manx = obj.MANX

            strSQL = " SELECT TEN=V.NV_TEN,SOTHE=V.MANV,NAM,DONVI=V.DV_MA,XUONG=V.X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA),TONGGIOCONG=SUM(TONGGIOCONG),GIOCONGVUOTQUA=(CASE WHEN (SUM(GIOCONGTANGCA)) <= 280.0 THEN '0' ELSE ( (SUM(GIOCONGTANGCA)) -280.0) END) FROM "
            strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next


            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"


            strSQL = strSQL + ",GIOCONGVUOTQUA=CASE WHEN(SUM("
            For I = 1 To 31

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")<=280.0) THEN '0' ELSE (SUM("
            For I = 1 To 31

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-280.0) END"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & ""
            strSQL = strSQL + " AND THANG<" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"


            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            Else
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            End If



            strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To ngay
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To ngay
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To ngay

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next


            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"


            strSQL = strSQL + ",GIOCONGVUOTQUA=CASE WHEN(SUM("
            For I = 1 To ngay

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")<=280.0) THEN '0' ELSE (SUM("
            For I = 1 To ngay

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-280.0) END"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & ""
            strSQL = strSQL + " AND THANG=" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            Else
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            End If
            strSQL = strSQL + ") AS V GROUP BY V.NV_TEN,V.MANV,NAM,V.DV_MA,V.X_MA_"
            '''
        End If
        ''*******************TOAN CONG TY*********************
        ''1.load ngay
        If obj.ChonBang = 9 Then
            Dim nam As Integer
            Dim thang As Integer
            Dim ngay As Integer
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            ngay = obj.NGAY.Day
            thang = obj.NGAY.Month
            nam = obj.NGAY.Year
            madv = obj.MADV
            manx = obj.MANX
            'truy van
            strSQL = strSQL + "SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_NHANVIEN.DV_MA,"
            strSQL = strSQL + "GIOBINHTHUONG=ISNULL(GIOBINHTHUONG_" & Me.QuoteString(ngay) & ",0)"
            strSQL = strSQL + ",GIOTANGCA=ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0),TONGGIOCONG = ISNULL(GIOBINHTHUONG_" & Me.QuoteString(ngay) & ",0)+ ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0)"
            strSQL = strSQL + ",GIOCCONGVUOTQUA= (CASE WHEN (ISNULL(GIOTANGCA_" & Me.QuoteString(ngay) & ",0)<= 4.0) THEN '0'"
            strSQL = strSQL + " ELSE (GIOTANGCA_" & Me.QuoteString(ngay) & "- 4.0) END)"
            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA"
            strSQL = strSQL + " WHERE THANG='" & Me.QuoteString(thang) & "'"
            strSQL = strSQL + " AND NAM='" & Me.QuoteString(nam) & "'"
            strSQL = strSQL + " AND isnull(DV_TV,0) <> 1 and isnull(DV_LocBB,0) = 0 "
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE '%CG%' AND ST_NHANVIEN.DV_MA NOT LIKE 'DT%' AND ST_NHANVIEN.DV_MA NOT LIKE 'BGD%'"
            strSQL = strSQL + " and ST_DONVI.DV_MA not like '%CG%' and ST_DONVI.DV_MA not like 'BGD%' AND NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_VAORA_MACHINE.MaNV = ST_NHANVIENTHOIVIEC.NV_MA )"

        End If

        '''LOAD TUAN
        If obj.ChonBang = 10 Then
            '''======DECLARE SQL
            Dim TUNGAY As DateTime
            Dim DENNGAY As DateTime
            Dim NAMTN As Integer
            Dim THANGTN As Integer
            Dim NGAYTN As Integer
            Dim NAMDN As Integer
            Dim THANGDN As Integer
            Dim NGAYDN As Integer
            'Dim LAYSONGAY As Integer
            Dim I As Integer
            Dim J As Integer
            '==============DIM BIEN CUA VB=============================
            Dim nam As Integer
            Dim thang As Integer
            Dim ngay As Integer
            Dim madv As String
            'lay ngay thang nam trong form (datetimepicker)
            ngay = obj.NGAY.Day
            thang = obj.NGAY.Month
            nam = obj.NGAY.Year
            madv = obj.MADV
            '=============la code GAN GIA TRI CUA SQL
            ''******TEXTBOX TU NGAY
            NAMTN = obj.NGAY1.Year   ''lay ra nam trong textbox tu ngay
            THANGTN = obj.NGAY1.Month
            NGAYTN = obj.NGAY1.Day
            ''*****TEXTBOX DEN NGAY
            NAMDN = obj.NGAY2.Year
            NGAYDN = obj.NGAY2.Day
            THANGDN = obj.NGAY2.Month
            '''=======trong nam
            If NAMTN = NAMDN Then
                If THANGTN < THANGDN Then

                    strSQL = strSQL + "SELECT TEN=NV_TEN,SOTHE=NV_MA,DONVI=DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA)"
                    strSQL = strSQL + ",TONGGIOCONG=SUM(GIOCONGCHINH)+SUM(GIOCONGTANGCA),GIOCONGVUOTQUA=(CASE WHEN(SUM(GIOCONGTANGCA)<=12.0) THEN '0'"
                    strSQL = strSQL + " ELSE (SUM(GIOCONGTANGCA)-12.0) END) FROM "
                    I = NGAYTN
                    strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("

                    While I <= Songay(NAMTN, THANGTN)
                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
                    I = NGAYTN
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While I <= Songay(NAMTN, THANGTN)
                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM= " & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                    strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"

                    ''====================TINH THANG HIEN TAI (2THANG KHAC NHAU NAM TRONG 1TUAN)
                    J = 1
                    strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    J = 1
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While J <= NGAYDN
                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGDN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                    strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                    strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    ' ''HAVING TUAN O DAY
                    'strSQL = strSQL + " HAVING SUM(GIOCONGTANGCA)>12"

                    ''*******************************TRONG THANG******************************************

                Else
                    If THANGTN = THANGDN Then
                        I = NGAYTN
                        strSQL = "SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_NHANVIEN.NV_MA,DONVI=ST_NHANVIEN.DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM("
                        While I <= NGAYDN

                            strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                        While I <= NGAYDN


                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",TONGGIOCONG=SUM("

                        While I <= NGAYDN


                            strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While

                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                        I = NGAYTN
                        strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("

                        While I <= NGAYDN
                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While
                        strSQL = Left(strSQL, Len(strSQL) - 1) + "<=12.0) THEN '0' ELSE("

                        I = NGAYTN
                        While I <= NGAYDN
                            strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                            I = I + 1
                        End While
                        strSQL = Left(strSQL, Len(strSQL) - 1) + ")-12.0 END)"


                        strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                        strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                        strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                        strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
                        ''********HAVING TUAN(TRONG NAM)*********
                        'I = NGAYTN
                        'strSQL = strSQL + " HAVING SUM("
                        'While I <= NGAYDN
                        '    strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        '    I = I + 1
                        'End While
                        'strSQL = Left(strSQL, Len(strSQL) - 1) + ")>12"
                    End If 'cua else If THANGTN = THANGDN Then
                End If
            End If

            ''===========================***********************NAM MOI***********************************======================
            If NAMTN <> NAMDN Then

                If THANGTN > THANGDN Then

                    strSQL = "SELECT TEN=NV_TEN,SOTHE=NV_MA,DONVI=DV_MA,XUONG=X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA)"
                    strSQL = strSQL + ",TONGGIOCONG=SUM(GIOCONGCHINH)+SUM(GIOCONGTANGCA),GIOCONGVUOTQUA=(CASE WHEN(SUM(GIOCONGTANGCA)<=12.0) THEN '0'"
                    strSQL = strSQL + " ELSE (SUM(GIOCONGTANGCA)-12.0) END) FROM"
                    I = NGAYTN
                    strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While I <= Songay(NAMTN, THANGTN)


                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    I = NGAYTN
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While I <= Songay(NAMTN, THANGTN)


                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
                        I = I + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGTN) & " AND NAM=" & Me.QuoteString(NAMTN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                    strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"

                    ''tinh nam moi********************************NAM MOI****************************

                    J = 1
                    strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
                    While J <= NGAYDN


                        strSQL = strSQL + "ISNULL(GIOBINHTHUONG_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While

                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    J = 1
                    strSQL = strSQL + ",GIOCONGTANGCA=SUM("

                    While J <= NGAYDN


                        strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(J) & ",0)+"
                        J = J + 1
                    End While
                    strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

                    strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
                    strSQL = strSQL + " WHERE THANG=" & Me.QuoteString(THANGDN) & " AND NAM=" & Me.QuoteString(NAMDN) & ""
                    strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
                    strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_Ten,ST_NHANVIEN.NV_Ma,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_) AS V "
                    strSQL = strSQL + " GROUP BY NV_TEN,NV_MA,DV_MA,X_MA_"
                    ''dieu kien having o day
                    'strSQL = strSQL + " HAVING SUM(GIOCONGTANGCA)>12"

                End If

            End If
        End If

        ''LOAD THANG
        If obj.ChonBang = 11 Then
            '''************************CACH KHAC**********************
            Dim NAM As Integer
            Dim THANG As Integer
            Dim I As Integer
            THANG = obj.NGAY.Month
            NAM = obj.NGAY.Year

            strSQL = " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("

            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<=30) THEN '0' ELSE ("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG=" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            'dieu kien vuot qua thang
            'strSQL = strSQL + " HAVING SUM("
            'For I = 1 To 31
            '    strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            'Next
            'strSQL = Left(strSQL, Len(strSQL) - 1) + ")>60"
        End If
        ''LOAD NAM
        If obj.ChonBang = 13 Then
            Dim NAM As Integer
            Dim THANG As Integer
            Dim ngay As Integer
            Dim I As Integer = 1
            Dim madv As String
            Dim manx As String
            'lay ngay thang nam trong form (datetimepicker)
            NAM = obj.NGAY.Year
            THANG = obj.NGAY.Month
            ngay = obj.NGAY.Day
            madv = obj.MADV
            manx = obj.MANX
            strSQL = " SELECT TEN=V.NV_TEN,SOTHE=V.MANV,NAM,DONVI=V.DV_MA,XUONG=V.X_MA_,GIOCONGCHINH=SUM(GIOCONGCHINH),GIOCONGTANGCA=SUM(GIOCONGTANGCA),TONGGIOCONG=SUM(TONGGIOCONG),GIOCONGVUOTQUA=(CASE WHEN (SUM(GIOCONGTANGCA)) <= 280.0 THEN '0' ELSE ( (SUM(GIOCONGTANGCA)) -280.0) END) FROM "
            strSQL = strSQL + " (SELECT ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next


            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"


            strSQL = strSQL + ",GIOCONGVUOTQUA=CASE WHEN(SUM("
            For I = 1 To 31

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")<=280.0) THEN '0' ELSE (SUM("
            For I = 1 To 31

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-280.0) END"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & ""
            strSQL = strSQL + " AND THANG<" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"

            strSQL = strSQL + " UNION ALL SELECT ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To ngay
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To ngay
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To ngay

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next


            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"


            strSQL = strSQL + ",GIOCONGVUOTQUA=CASE WHEN(SUM("
            For I = 1 To ngay

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")<=280.0) THEN '0' ELSE (SUM("
            For I = 1 To ngay

                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"

            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-280.0) END"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & ""
            strSQL = strSQL + " AND THANG=" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            strSQL = strSQL + ") AS V GROUP BY V.NV_TEN,V.MANV,NAM,V.DV_MA,V.X_MA_"
            ''DIEU KIEN HAVING
            'strSQL = strSQL + " HAVING (SUM("
            'For I = 1 To 31
            '    strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            'Next
            'strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            'strSQL = strSQL + ") > 300"
        End If
        ''=========== tang ca tu dau nam den ngay da chon==========
        If obj.ChonBang = 14 Then
            Dim NAM, THANG, NGAY, I As Integer
            Dim madv, manx As String
            THANG = obj.NGAY.Month
            NAM = obj.NGAY.Year
            NGAY = obj.NGAY.Day
            madv = obj.MADV
            manx = obj.MANX

            strSQL = "SELECT V.TEN,V.SOTHE,V.DONVI,V.XUONG,GIOCONGCHINH=SUM(V.GIOCONGCHINH),GIOCONGTANGCA=SUM(V.GIOCONGTANGCA),"
            strSQL = strSQL + "GIOCONGVUOTQUA=SUM(V.GIOCONGVUOTQUA),TONGGIOCONG=SUM(V.TONGGIOCONG)"
            strSQL = strSQL + " FROM ("

            strSQL = strSQL + " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 30) THEN '0' ELSE ("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG <" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            Else
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            End If
            ''======== thang hien tai chi lay den ngay da chon ===========''
            strSQL = strSQL + " UNION ALL "

            strSQL = strSQL + " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To NGAY
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To NGAY

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 30) THEN '0' ELSE ("
            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG =" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            If madv = "" Then
                strSQL = strSQL + " AND ST_DONVI.X_MA_=N'" & Me.QuoteString(manx) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            Else
                strSQL = strSQL + " AND ST_NHANVIEN.DV_MA=N'" & Me.QuoteString(madv) & "'"
                strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            End If
            strSQL = strSQL + " )AS V "
            strSQL = strSQL + " GROUP BY V.TEN,V.SOTHE,V.DONVI,V.XUONG "
        End If
        ''============== tang ca den 1 ngay nao do toan cong ty ==========''
        If obj.ChonBang = 15 Then
            Dim NAM, THANG, NGAY, I As Integer
            Dim madv, manx As String
            THANG = obj.NGAY.Month
            NAM = obj.NGAY.Year
            NGAY = obj.NGAY.Day
            madv = obj.MADV
            manx = obj.MANX

            strSQL = "SELECT V.TEN,V.SOTHE,V.DONVI,V.XUONG,GIOCONGCHINH=SUM(V.GIOCONGCHINH),GIOCONGTANGCA=SUM(V.GIOCONGTANGCA),"
            strSQL = strSQL + "GIOCONGVUOTQUA=SUM(V.GIOCONGVUOTQUA),TONGGIOCONG=SUM(V.TONGGIOCONG)"
            strSQL = strSQL + " FROM ("

            strSQL = strSQL + " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To 31
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To 31

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 30) THEN '0' ELSE ("
            For I = 1 To 31
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG <" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"

            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"

            ''======== thang hien tai chi lay den ngay da chon ===========''
            strSQL = strSQL + " UNION ALL "

            strSQL = strSQL + " SELECT TEN=ST_NHANVIEN.NV_TEN,SOTHE=ST_VAORA_MACHINE.MANV,NAM,THANG,DONVI=ST_NHANVIEN.DV_MA,XUONG=ST_DONVI.X_MA_,GIOCONGCHINH=SUM("
            For I = 1 To NGAY
                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"
            strSQL = strSQL + ",GIOCONGTANGCA=SUM("

            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next

            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",TONGGIOCONG=SUM("
            For I = 1 To NGAY

                strSQL = strSQL + " ISNULL(GIOBINHTHUONG_" & Me.QuoteString(I) & ",0) + ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")"

            strSQL = strSQL + ",GIOCONGVUOTQUA=SUM(CASE WHEN("
            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + "<= 30) THEN '0' ELSE ("
            For I = 1 To NGAY
                strSQL = strSQL + "ISNULL(GIOTANGCA_" & Me.QuoteString(I) & ",0)+"
            Next
            strSQL = Left(strSQL, Len(strSQL) - 1) + ")-30 END)"

            strSQL = strSQL + " FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA INNER JOIN ST_DONVI ON ST_DONVI.DV_MA=ST_NHANVIEN.DV_MA"
            strSQL = strSQL + " WHERE NAM=" & Me.QuoteString(NAM) & " AND THANG =" & Me.QuoteString(THANG) & ""
            strSQL = strSQL + " AND MANV NOT IN(SELECT NV_MA FROM ST_NHANVIENTHOIVIEC ) AND ISNULL(DV_TV,0) <> 1 AND ISNULL(DV_LocBB,0) = 0 AND ST_DONVI.DV_MA not like '%CG%' AND ST_DONVI.DV_MA not like 'BGD%'"
            strSQL = strSQL + " GROUP BY ST_NHANVIEN.NV_TEN,ST_VAORA_MACHINE.MANV,NAM,THANG,ST_NHANVIEN.DV_MA,ST_DONVI.X_MA_"
            strSQL = strSQL + " )AS V "
            strSQL = strSQL + " GROUP BY V.TEN,V.SOTHE,V.DONVI,V.XUONG "
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
    'ham lay ra so ngay trong thang
    Public Function Songay(ByVal Nam As Integer, ByVal Thang As Integer) As Integer
        Select Case Thang
            Case 1, 3, 5, 7, 8, 10, 12
                Songay = 31
            Case 4, 6, 9, 11
                Songay = 30
            Case 2
                If (Nam Mod 4) = 0 Then
                    Songay = 29
                Else
                    Songay = 28
                End If
        End Select
    End Function
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
End Class

