Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDNguoiDung
    Inherits DALSQL
    ' Methods
    Public Function DeleteInfo(ByVal obj As objNguoiDung) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "DELETE FROM JELL_USER where Ten_DangNhap=N'" & Me.QuoteString(obj.TenDangNhap)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        Return Me.execSQL(strSQL)
    End Function

    Public Adm As Integer
    Public Function InsertInfo(ByVal obj As objNguoiDung) As Boolean
        Dim flag As Boolean
        Me.Adm = 0
        If obj.Admin = True Then
            Me.Adm = 1
        End If

        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO [JELL_USER]([Ten_DangNhap],[MK_DN],[Ma_NV],[Ten_NV],[IP_Address],[Admin]) VALUES(N'" & Me.QuoteString(obj.TenDangNhap) & "','" & Me.QuoteString(clsTools.Encrypt1(obj.MatKhau)) & "',N'" & Me.QuoteString(obj.MaNV) & "',N'" & Me.QuoteString(obj.TenNhanVien) & "',N'" & Me.QuoteString(obj.IP) & "','" & Me.Adm}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function IsDeleteOK(ByVal obj As objNguoiDung) As Boolean
        Dim strSQL As String = ("SELECT * FROM [JELL_QUYENTRUYCAP] WHERE Ten_DangNhap = N'" & Me.QuoteString(obj.TenDangNhap) & "'")
        If (Me.getTableSQL(strSQL).Rows.Count > 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function LoadDS(ByVal obj As objNguoiDung) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = (strSQL & " SELECT [Ten_DangNhap],[MK_DN],[Ma_NV],[Ten_NV],[IP_Address],[Admin] FROM [JELL_USER]")
        End If

        If obj.ChonBang = 2 Then
            strSQL = (strSQL & " SELECT NV_MA FROM ST_NHANVIEN")
        End If

        If obj.ChonBang = 3 Then
            strSQL = (strSQL & " SELECT NV_TEN FROM ST_NHANVIEN WHERE NV_MA = '" + obj.MaNV + "'")
        End If

        If obj.ChonBang = 4 Then
            strSQL = (strSQL & " SELECT * FROM JELL_USER WHERE Ten_DangNhap = '" + obj.TenDangNhap + "'")
        End If

        If obj.ChonBang = 5 Then
            strSQL = (strSQL & " SELECT * FROM [JELL_USER] WHERE Ten_DangNhap = '" + obj.TenDangNhap + "'")
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

    Public Function UpdateInfo(ByVal obj As objNguoiDung) As Boolean
        Dim flag As Boolean
        Me.Adm = 0
        If obj.Admin = True Then
            Me.Adm = 1
        End If
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE [JELL_USER] SET [MK_DN] = '" & Me.QuoteString(clsTools.Encrypt1(obj.MatKhau)) & "',[Ma_NV] = N'" & Me.QuoteString(obj.MaNV) & "',[Ten_NV] =N'" & Me.QuoteString(obj.TenNhanVien) & "' ,[IP_Address] = N'" & Me.QuoteString(obj.IP) & "',[Admin] = N'" & Me.Adm & "' WHERE Ten_DangNhap = '" & Me.QuoteString(obj.TenDangNhap)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

End Class

