Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDCongViecNNDH
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objCongViecNNDH) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 13 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' ORDER BY DV_MA ")
        End If
        'Cau truy van load Tuan len combo Tuan
        If obj.ChonBang = 14 Then
            strSQL = ("SELECT ")
            strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + " ST_NHANVIEN.NV_TEN ,"
            strSQL = strSQL + " NAM = YEAR(GETDATE()),"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG1,0) THANG1,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG2,0) THANG2,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG3,0) THANG3,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG4,0) THANG4,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG5,0) THANG5,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG6,0) THANG6,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG7,0) THANG7,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG8,0) THANG8,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG9,0) THANG9,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG10,0) THANG10,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG11,0) THANG11,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.THANG12,0) THANG12,"
            strSQL = strSQL + " ISNULL(IT_CONGVIECDHNN.FLAG,0) FLAG,"
            strSQL = strSQL + " TONGCONG = CASE WHEN ISNULL(THANG1 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG2 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG3 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG4 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG5 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG6 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG7 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG8 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG9 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG10 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG11 ,0)= 1 THEN 1 ELSE 0 END+"
            strSQL = strSQL + " CASE WHEN ISNULL(THANG12 ,0)= 1 THEN 1 ELSE 0 END"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN IT_CONGVIECDHNN ON ST_NHANVIEN.NV_MA = IT_CONGVIECDHNN.NV_MA AND NAM = YEAR(GETDATE())"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'DT%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('A1MDT','A2MDT')"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = N'" & Me.QuoteString(obj.DonVi) & "'"
            'strSQL = strSQL + " AND IT_CONGVIECDHNN.NAM = YEAR(GETDATE())"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA NOT IN ('BGD')"
        End If

        'If obj.ChonBang = 3 Then
        '    'strSQL = (" SELECT CV_MA FROM ST_CONGVIEC WHERE CV_MA <> ''")
        'End If


        If obj.ChonBang = 15 Then
            strSQL = (" SELECT NV_MA FROM IT_CONGVIECDHNN WHERE NV_MA ='" & Me.QuoteString(obj.MaNV) & "' AND NAM = YEAR(GETDATE())")
        End If

        If obj.ChonBang = 1 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG1
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 2 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG2
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 3 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG3
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "
        End If
        If obj.ChonBang = 4 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG4
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
     
        If obj.ChonBang = 5 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG5
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 6 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG6
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 7 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG7
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 8 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG8
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If

        If obj.ChonBang = 9 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG9
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 10 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG10
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 11 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG11
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

        End If
        If obj.ChonBang = 12 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG12
            nam = 2011
            'truy van
            strSQL = strSQL + "SELECT * FROM IT_CONGVIECDHNN WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1 "

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
    Public Function DeleteInfo(ByVal obj As objCongViecNNDH) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "DELETE [IT_CONGVIECDHNN] WHERE NV_MA = '" + obj.MaNV + "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
    Public Function UpdateInfo(ByVal obj As objCongViecNNDH) As Boolean
        Dim flag As Boolean
        Dim strSQL As String

        If obj.ChonBang = 0 Then
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " [THANG1] = N'" + obj.THANG1 + "'"
            strSQL = strSQL + " ,[THANG2] = N'" + obj.THANG2 + "'"
            strSQL = strSQL + " ,[THANG3] = N'" + obj.THANG3 + "'"
            strSQL = strSQL + " ,[THANG4] = N'" + obj.THANG4 + "'"
            strSQL = strSQL + " ,[THANG5] = N'" + obj.THANG5 + "'"
            strSQL = strSQL + " ,[THANG6] = N'" + obj.THANG6 + "'"
            strSQL = strSQL + " ,[THANG7] = N'" + obj.THANG7 + "'"
            strSQL = strSQL + " ,[THANG8] = N'" + obj.THANG8 + "'"
            strSQL = strSQL + " ,[THANG9] = N'" + obj.THANG9 + "'"
            strSQL = strSQL + " ,[THANG10] = N'" + obj.THANG10 + "'"
            strSQL = strSQL + " ,[THANG11] = N'" + obj.THANG11 + "'"
            strSQL = strSQL + " ,[THANG12] = N'" + obj.THANG12 + "'"
            strSQL = strSQL + " WHERE [NV_MA] =  '" + obj.MaNV + "' AND NAM = YEAR(GETDATE())"
        End If
        ' LAY DU LIEU THANG CAN CHON CAP NHAT CHO THANG KE TIEP
        If obj.ChonBang = 1 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG1
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG2 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 2 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG2
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG3 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If

        If obj.ChonBang = 3 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG3
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG4 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 4 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG4
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG5 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 5 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG5
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG6 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 6 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG6
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG7 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 7 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG7
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG8 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 8 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG8
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG9 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 9 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG9
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG10 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 10 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG10
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG11 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 11 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG11
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG12 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
        End If
        If obj.ChonBang = 12 Then
            Dim nam As Integer
            Dim thang As String
            'lay ngay thang nam trong form (datetimepicker)
            thang = obj.THANG12
            nam = 2011
            strSQL = "UPDATE [IT_CONGVIECDHNN] SET  "
            strSQL = strSQL + " THANG12 = " & Me.QuoteString(thang) & " "
            strSQL = strSQL + " WHERE NAM = 2011 AND " & Me.QuoteString(thang) & " =1"
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
    Public Function InsertInfo(ByVal obj As objCongViecNNDH) As Boolean
        Dim strSQL As String
        Dim flag As Boolean
        If obj.ChonBang = 0 Then
            strSQL = "INSERT INTO [IT_CONGVIECDHNN]"
            strSQL = strSQL + " ([NV_MA]"
            strSQL = strSQL + " ,[NAM]"
            strSQL = strSQL + " ,[THANG1]"
            strSQL = strSQL + " ,[THANG2]"
            strSQL = strSQL + " ,[THANG3]"
            strSQL = strSQL + " ,[THANG4]"
            strSQL = strSQL + " ,[THANG5]"
            strSQL = strSQL + " ,[THANG6]"
            strSQL = strSQL + " ,[THANG7]"
            strSQL = strSQL + " ,[THANG8]"
            strSQL = strSQL + " ,[THANG9]"
            strSQL = strSQL + " ,[THANG10]"
            strSQL = strSQL + " ,[THANG11]"
            strSQL = strSQL + " ,[THANG12])"
            strSQL = strSQL + " values("
            strSQL = strSQL + " N'" & Me.QuoteString(obj.MaNV) & "'"
            strSQL = strSQL + " ,N'" & Me.QuoteString(obj.NAM) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG1) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG2) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG3) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG4) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG5) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG6) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG7) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG8) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG9) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG10) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG11) & "'"
            strSQL = strSQL + " ,'" & Me.QuoteString(obj.THANG12) & "')"
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
End Class
