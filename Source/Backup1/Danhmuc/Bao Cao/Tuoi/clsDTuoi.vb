Imports Microsoft.VisualBasic.CompilerSerVices
Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class clsDTuoi
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objTuoi) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("select X_MA_ from " & Me.QuoteString(obj.Table))
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " WHERE NGAY = '" + obj.NGAY + "' ORDER BY NGAY")
        End If

        If obj.ChonBang = 3 Then
            If (StringType.StrCmp(obj.ID, "", False) <> 0) Then
                strSQL = (strSQL & " where JELL_DONVI.X_MA_=N'" & Me.QuoteString(obj.ID) & "'")
            End If
            strSQL = ("select ST_NGANH.N_MA from " & Me.QuoteString(obj.Table) & " INNER JOIN ST_NGANH ON JELL_DONVI.N_MA = ST_NGANH.N_MA " & strSQL & " ORDER BY NGAY ")
        End If

        If obj.ChonBang = 4 Then
            strSQL = (" SELECT DISTINCT X_MA_ ")
            strSQL = strSQL + "FROM JELL_DONVI "
        End If

        If obj.ChonBang = 5 Then
            strSQL = (" SELECT DISTINCT N_MA ")
            strSQL = strSQL + "FROM JELL_DONVI WHERE X_MA_ = '" + obj.XUONG + "'"
        End If

        If obj.ChonBang = 6 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " WHERE NGAY = '" + obj.NGAY + "' AND X_MA_ = '" + obj.XUONG + "' ORDER BY NGAY ")
        End If

        If obj.ChonBang = 7 Then
            strSQL = ("select * from " & Me.QuoteString(obj.Table) & " " & strSQL & " WHERE NGAY = '" + obj.NGAY + "' AND X_MA_ = '" + obj.XUONG + "' AND N_MA = '" + obj.NGANH + "' ORDER BY NGAY ")
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

End Class
