Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDDanhMucMoiQuanHe
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objDanhMucMoiQuanHe) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Cau truy van load Tuan len combo Tuan

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT STT = '', MA_QH, TEN_QH FROM IT_DANHMUCQUANHE ORDER BY MA_QH ASC ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT  MA_QH, TEN_QH FROM IT_DANHMUCQUANHE WHERE MA_QH ='" & Me.QuoteString(obj.MaQH) & "'")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT MA_QH FROM IT_NHANVIENQUANHE  WHERE MA_QH ='" & Me.QuoteString(obj.MaQH) & "'")
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
    Public Function UpdateInfo(ByVal obj As objDanhMucMoiQuanHe) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        'If obj.ChonBang = 5 Then
        '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"update ST_NHANVIEN set NV_Ten=N'", Me.QuoteString(obj.TenNV), "',DV_MA=N'", Me.QuoteString(obj.DonVi), "',NV_Ngayvao=N'", Me.QuoteString(obj.NgayVao), "',CV_MA_=N'", Me.QuoteString(obj.CongViec), "' where nv_ma = N'", Me.QuoteString(obj.MaNV)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'End If
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
    Public Function InsertInfo(ByVal obj As objDanhMucMoiQuanHe) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into IT_DANHMUCQUANHE(MA_QH, TEN_QH) values(N'" & Me.QuoteString(obj.MaQH) & "',N'" & Me.QuoteString(obj.TenQH) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objDanhMucMoiQuanHe) As Boolean
        Dim strSQL As String

        strSQL = ("delete from IT_DANHMUCQUANHE where MA_QH=N'" & Me.QuoteString(jFunction.MaQH) & "'")

        Return Me.execSQL(strSQL)
    End Function
End Class
