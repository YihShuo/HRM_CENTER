Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Public Class clsDThongKeDanhSachCanBoThang
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As objThongKeDanhSachCanBoThang) As DataTable
        Dim table As DataTable
        Dim tabletam As DataTable = Nothing
        If obj.ChonBang = 1 Then
            tabletam = getTableProcedure("TK_DSCANBO_TCT")
            'strSQL = ("SELECT STT ='',DV_MA, DV_TEN , GHICHU FROM DM_XUONGDONVI WHERE DM_XUONGDONVI.XUONG_MA = N'ADIDAS' ORDER BY DV_MA ASC ")
        End If
        'Thuc thi cau truy van
        Try
            table = tabletam
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            table = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return table
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal listpar As SqlParameter()) As DataTable
        Dim tbl As DataTable
        Try
            tbl = Me.getTableProcedure(m_sSP_Name, listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            tbl = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return tbl
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

End Class
