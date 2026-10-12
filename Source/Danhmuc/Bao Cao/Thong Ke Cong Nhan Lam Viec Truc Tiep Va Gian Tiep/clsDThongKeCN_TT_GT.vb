Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKeCN_TT_GT
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Dim ds As New DataSet
        ds = Me.getDatasetProcedure(m_sSP_Name, m_listpar)
        Return ds.Tables(0)
    End Function
    Public Function DanhSachTTGT(ByVal m_sSP_Name As String) As DataTable
        Return Me.getTableProcedure(m_sSP_Name)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As DataTable
        Return Me.getTableProcedure(m_sSP_Name)
    End Function
    Public Function LoadDS(ByVal obj As objThongKeCN_TT_GT) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

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
