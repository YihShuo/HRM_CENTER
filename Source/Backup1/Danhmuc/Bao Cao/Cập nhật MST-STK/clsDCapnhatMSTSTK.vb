Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports TongHop.MAIN
Public Class clsDCapnhatMSTSTK
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objCapnhatMSTSTK) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        ''Cau truy van load Tuan len combo Tuan

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_MA, NV_TEN, DV_MA, NV_NGAYVAO, NV_NGAYTV, NV_CMND, MASOTHUE , SOTAIKHOAN  FROM ST_NHANVIEN WHERE NV_CMND= N'" & Me.QuoteString(obj.CMND) & "' ORDER BY NV_MA ASC ")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * FROM ST_NHANVIEN WHERE NV_CMND= N'" & Me.QuoteString(obj.CMND) & "' AND NV_MA =N'" & Me.QuoteString(obj.MaNV) & "'  ORDER BY DV_MA ASC ")
        End If

        'Thuc thi cau truy van331210346
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
    Public Function UpdateInfo(ByVal obj As objCapnhatMSTSTK) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 5 Then
            Dim day As DateTime = Now
            Dim ngay As String = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())
            strSQL = "UPDATE ST_NHANVIEN SET MASOTHUE = N'" & Me.QuoteString(obj.MASOTHUE) & "',  SOTAIKHOAN = N'" & Me.QuoteString(obj.SOTAIKHOAN) & "',NGUOICAPNHAT = N'" & Me.QuoteString(userclient) & "',NGAYCAPNHAT = N'" & Me.QuoteString(ngay) & "' WHERE NV_CMND = '" & Me.QuoteString(obj.CMND) & "' AND NV_MA = '" & Me.QuoteString(obj.MaNV) & "'"
            obj.SQL = strSQL.ToString
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
    Public Function UpdateThaoTac(ByVal obj As objCapnhatMSTSTK) As Boolean
        Dim flag As Boolean
        Dim strSQL1 As String = ""

        If obj.ChonBang = 6 Then
            Dim day As DateTime = Now
            Dim ngay As String = Now().ToString.Format("{0:yyyy-MM-dd HH:mm:ss}", Now())
            Dim s_SQL As String = obj.SQL
            s_SQL = Replace(s_SQL, "'", "''")
            Dim Use_client = userclient
            strSQL1 = "INSERT INTO jell_TacDong (ThoiDiem, HanhDong, GiaTri, Ten_DangNhap) VALUES (" & "'" & ngay & "'" & "," & "'" & s_SQL & "'" & ", '0', " & "'" & Use_client & "'" & " )"

        End If
        Try
            flag = Me.execSQL(strSQL1)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function InsertInfo(ByVal obj As objCapnhatMSTSTK) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        If obj.ChonBang = 4 Then
            'strSQL = ((String.Concat(New String() {strSQL, "insert into ST_NHANVIEN(NV_Ma, NV_Ten, DV_MA, NV_MaTu, NV_Ngayvao) values(N'", Me.QuoteString(obj.MaNV), "',N'", Me.QuoteString(obj.TenNV), "',N'", Me.QuoteString(obj.DonVi), "',N'", Me.QuoteString(obj.MaTu), "',N'", Me.QuoteString(obj.NgayVao)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
