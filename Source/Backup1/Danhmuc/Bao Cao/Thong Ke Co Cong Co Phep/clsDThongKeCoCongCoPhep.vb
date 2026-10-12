Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient

Public Class clsDThongKeCoCongCoPhep
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objThongKeCoCongCoPhep) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""


        If obj.ChonBang = 3 Then
            strSQL = ("SELECT X_MA_ FROM ST_NXUONG WHERE EXISTS (SELECT X_MA_ FROM ST_DONVI WHERE  ISNULL(DV_LocBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA not like '%CG%' AND DV_MA not like 'BGD%' AND ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ GROUP BY X_MA_) ORDER BY X_MA_")

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
    Public Function ThongKe(ByVal m_sSP_Name As String, ByVal ParamArray SqlParam As SqlParameter()) As DataTable
        Dim table As DataTable
        Try
            table = Me.getTableProcedure(m_sSP_Name, SqlParam)
        Catch ex As Exception
            table = Nothing
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table

    End Function
    Public Function ThongKe(ByVal m_sSP_Name As String) As DataTable
        Dim table As DataTable
        Try
            table = Me.getDatasetProcedure(m_sSP_Name).Tables(0)
        Catch ex As Exception
            table = Nothing
            MessageBox.Show(ex.ToString, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return table

    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function

End Class
