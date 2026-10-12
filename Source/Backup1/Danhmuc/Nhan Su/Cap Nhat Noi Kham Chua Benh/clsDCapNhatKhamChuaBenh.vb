Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDCapNhatKhamChuaBenh
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objCapNhatKhamChuaBenh) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        'Load Nơi DKKCB
        If obj.ChonBang = 1 Then
            strSQL = "Select MA_KCB,(MA_KCB + '-' + TEN_KCB) as TEN_KCB from IT_NOIKHAMCHUABENH"
        End If
        'Load Đơn Vị
        If obj.ChonBang = 2 Then
            strSQL = "select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV"
            strSQL = strSQL + " from st_donvi  WHERE dv_ma <> 'CNM' and DV_LOCBB = 0 order by dv_ma "
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' and DV_LOCBB = 0 order by dv_ma ")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT * FROM ST_DONVI WHERE ISNULL(DV_TV,0) = 1 AND DV_MA= '" & obj.MaDV & "'")
        End If
        'Load Đơn Vị Khu A
        If obj.ChonBang = 5 Then

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
        'Load Đơn Vị Khu B
        If obj.ChonBang = 6 Then
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
        'Load Đơn Vị Khu DVC
        If obj.ChonBang = 7 Then
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
        'Load Ds Theo Đơn Vị
        If obj.ChonBang = 8 Then
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY (ST_NHANVIEN.NV_MA)) AS STT, NULL AS [1],CONVERT(BIT,'0') AS [2],NULL AS [3],ST_NHANVIEN.NV_Ma, "
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN, "
            strSQL = strSQL + " ST_NHANVIEN.DV_MA, "
            strSQL = strSQL + " NV_DiaChi,"
            strSQL = strSQL + " IT_DANGKYKHAMCHUABENH.MA_KCB,"
            strSQL = strSQL + " IT_NOIKHAMCHUABENH.TEN_KCB"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN IT_DANGKYKHAMCHUABENH ON ST_NHANVIEN.NV_Ma = IT_DANGKYKHAMCHUABENH.NV_Ma "
            strSQL = strSQL + " LEFT JOIN IT_NOIKHAMCHUABENH ON IT_DANGKYKHAMCHUABENH.MA_KCB = IT_NOIKHAMCHUABENH.MA_KCB"
            strSQL = strSQL + " WHERE NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA)"
            'strSQL = strSQL + " AND IT_DANGKYKHAMCHUABENH.MA_KCB = '" + obj.MaKCB + "'"
            'strSQL = strSQL + " AND ST_nhanvien.NV_Ngayvao = '" + obj.NGAY + "'"

            Select Case obj.ChonKhu
                Case "TCT"

                    Select Case obj.MaDV
                        Case "TCT"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.NV_MA"
                            'strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.MaDV + "' ORDER BY ST_NHANVIEN.NV_MA"
                        Case Else
                            If obj.MaDV = "CNM" Then  ''đơn vị CNM
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.MaDV + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.MaDV + "'"
                                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            End If
                    End Select
                Case "A"

                    Select Case obj.MaDV
                        Case "KHUA"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.NV_MA"
                        Case Else
                            If obj.MaDV = "CNM" Then  ''đơn vị CNM
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.MaDV + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.MaDV + "'"
                                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            End If
                    End Select
                Case "B"

                    Select Case obj.MaDV
                        Case "KHUB"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                        Case Else
                            If obj.MaDV = "CNM" Then  ''đơn vị CNM
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.MaDV + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.MaDV + "'"
                                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            End If
                    End Select
                Case "DVC"

                    Select Case obj.MaDV
                        Case "KHUDVC"
                            strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                            strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                            strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                            strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                            strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                        Case Else
                            If obj.MaDV = "CNM" Then  ''đơn vị CNM
                                strSQL += " AND ST_NHANVIEN.DV_MA = N'" + obj.MaDV + "'"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            Else
                                strSQL += " AND ST_NHANVIEN.DV_MA_ = N'" + obj.MaDV + "'"
                                strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                                strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                            End If
                    End Select
            End Select
        End If
        'Load Ds Theo Đơn Vị Và Ngày Vào Công Ty
        If obj.ChonBang = 9 Then
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY (ST_NHANVIEN.NV_MA)) AS STT, NULL AS [1],CONVERT(BIT,'0') AS [2],NULL AS [3],ST_NHANVIEN.NV_Ma, "
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN, "
            strSQL = strSQL + " ST_NHANVIEN.DV_MA, "
            strSQL = strSQL + " NV_DiaChi,"
            strSQL = strSQL + " IT_DANGKYKHAMCHUABENH.MA_KCB,"
            strSQL = strSQL + " IT_NOIKHAMCHUABENH.TEN_KCB"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN IT_DANGKYKHAMCHUABENH ON ST_NHANVIEN.NV_Ma = IT_DANGKYKHAMCHUABENH.NV_Ma "
            strSQL = strSQL + " LEFT JOIN IT_NOIKHAMCHUABENH ON IT_DANGKYKHAMCHUABENH.MA_KCB = IT_NOIKHAMCHUABENH.MA_KCB"
            strSQL = strSQL + " WHERE NOT EXISTS (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC WHERE ST_NHANVIENTHOIVIEC.NV_MA = ST_NHANVIEN.NV_MA)"
            'strSQL = strSQL + " AND IT_DANGKYKHAMCHUABENH.MA_KCB = '" + obj.MaKCB + "'"
            strSQL = strSQL + " AND ST_nhanvien.NV_Ngayvao = '" + obj.NGAY + "'"

            Select Case obj.ChonKhu
                Case "TCT"
                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)=0"
                    strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                    strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                    strSQL += " AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA"
                Case "A"
                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                    strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                    strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                    strSQL += " AND KHU = 'A' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA"
                Case "B"
                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                    strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                    strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                    strSQL += " AND KHU = 'B' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
                Case "DVC"
                    strSQL += " AND ISNULL(ST_NHANVIEN.IT_DDNGHIVIEC,0)= 0"
                    strSQL += " AND  EXISTS (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0 "
                    strSQL += " AND DV_MA NOT LIKE '%CG%' AND DV_MA NOT LIKE '%BGD%'"
                    strSQL += " AND KHU = 'DVC' AND ST_NHANVIEN.DV_MA_ = ST_DONVI.DV_MA )"
                    strSQL += " ORDER BY ST_NHANVIEN.NV_MA "
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

    Public Function InsertInfo(ByVal obj As objCapNhatKhamChuaBenh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO IT_DANGKYKHAMCHUABENH([NV_Ma],[MA_KCB]) values(N'" & Me.QuoteString(obj.MaNV) & "',N'" & Me.QuoteString(obj.MaKCB) & "')")
        End If
        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            'MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function UpdateInfo(ByVal obj As objCapNhatKhamChuaBenh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_DANGKYKHAMCHUABENH  SET MA_KCB = N'" + obj.MaKCB + "',NGAYCAPNHAT = N'" + obj.NgayCapNhat + "',NGUOICAPNHAT = N'" + obj.NguoiCapNhat + "' WHERE NV_MA = '" + obj.MaNV + "'"
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

    Public Function DeleteInfo(ByVal obj As objCapNhatKhamChuaBenh) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_DANGKYKHAMCHUABENH WHERE NV_Ma ='" & Me.QuoteString(obj.MaNV) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
End Class
