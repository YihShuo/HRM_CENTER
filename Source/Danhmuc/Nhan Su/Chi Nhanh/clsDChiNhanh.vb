Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDChiNhanh
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objChiNhanh) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Cau truy van load Tuan len combo Tuan
      
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT STT ='', CN_MA, CN_TEN FROM IT_CHINHANH ORDER BY CN_MA ASC ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT CN_MA, CN_TEN FROM IT_CHINHANH WHERE CN_MA ='" & Me.QuoteString(obj.MaCN) & "'")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT DT_CHINHANH FROM ST_QUATRINHDAOTAO WHERE DT_CHINHANH ='" & Me.QuoteString(obj.MaCN) & "'")
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
    Public Function UpdateInfo(ByVal obj As objChiNhanh) As Boolean
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
    Public Function InsertInfo(ByVal obj As objChiNhanh) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("insert into IT_CHINHANH(CN_MA, CN_TEN) values(N'" & Me.QuoteString(obj.MaCN) & "',N'" & Me.QuoteString(obj.TenCN) & "')")
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
    Public Function DeleteInfo(ByVal jFunction As objChiNhanh) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If jFunction.ChonBang = 1 Then
            strSQL = ("delete from IT_CHINHANH where CN_MA=N'" & Me.QuoteString(jFunction.MaCN) & "'")
        End If
        Return Me.execSQL(strSQL)
    End Function
End Class
