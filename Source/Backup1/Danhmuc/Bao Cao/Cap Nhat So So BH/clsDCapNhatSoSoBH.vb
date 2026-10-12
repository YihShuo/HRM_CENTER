Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDCapNhatSoSoBH
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objCapNhatSoSoBH) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT * FROM ST_NHANVIEN WHERE NV_MA= N'" & Me.QuoteString(obj.MaNV) & "' AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC) ORDER BY DV_MA ASC ")
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
    Public Function UpdateInfo(ByVal obj As objCapNhatSoSoBH) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 5 Then
            strSQL = "UPDATE ST_NHANVIEN SET NV_SoSoBH = N'" & Me.QuoteString(obj.SOSOBAOHIEM) & "' WHERE NV_MA= '" & Me.QuoteString(obj.MaNV) & "'"
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
End Class
