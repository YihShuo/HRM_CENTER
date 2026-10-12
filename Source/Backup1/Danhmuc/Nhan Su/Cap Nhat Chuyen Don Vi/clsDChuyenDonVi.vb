Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class clsDChuyenDonVi
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objChuyenDonVi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Cau truy van load Tuan len combo Tuan
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT DV_MA FROM ST_DONVI WHERE DV_MA <> ' ' ORDER BY DV_MA ASC ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT * FROM ST_NHANVIEN WHERE NV_MA= N'" & Me.QuoteString(obj.MaNV) & "'  ORDER BY DV_MA ASC ")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT * FROM ST_NHANVIEN WHERE NV_MA= N'" & Me.QuoteString(obj.MaNV) & "'  ORDER BY DV_MA ASC ")
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
    Public Function UpdateInfo(ByVal obj As objChuyenDonVi) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 5 Then
            'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_Ten=N'", Me.QuoteString(obj.TenNV), "',NV_MaTu=N'", Me.QuoteString(obj.MaTu), "',NV_Ngayvao=N'", Me.QuoteString(obj.NgayVao), "' where nv_ma = N'", Me.QuoteString(obj.MaNV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_MaTu=N'", Me.QuoteString(obj.MaTu), "',NGUOICAPNHAT=N'", Me.QuoteString(obj.NguoiCapNhat), "',NGAYCAPNHAT = GETDATE()  where nv_ma = N'", Me.QuoteString(obj.MaNV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
    Public Function InsertInfo(ByVal obj As objChuyenDonVi) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        If obj.ChonBang = 4 Then
            strSQL = ((String.Concat(New String() {strSQL, "insert into ST_NHANVIEN(NV_Ma, NV_Ten, DV_MA, NV_MaTu, NV_Ngayvao) values(N'", Me.QuoteString(obj.MaNV), "',N'", Me.QuoteString(obj.TenNV), "',N'", Me.QuoteString(obj.DonVi), "',N'", Me.QuoteString(obj.MaTu), "',N'", Me.QuoteString(obj.NgayVao)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
