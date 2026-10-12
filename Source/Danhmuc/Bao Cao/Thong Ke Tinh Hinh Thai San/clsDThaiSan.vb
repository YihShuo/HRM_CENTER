
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThaiSan
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objThaiSan) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
            strSQL = (strSQL & "where DV_MA = N'" & Me.QuoteString(obj.ID) & "'")
        End If

        If obj.ChonBang = 1 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " order by NV_Ma asc")
        End If

        'Cau truy van load Tuan len combo Tuan
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT DV_MA FROM ST_DONVI WHERE DV_MA <> ' ' ORDER BY DV_MA ASC ")
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
End Class
