Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKeSoNgayNghiOMCOTrongNam
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTuc_LoadBang(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataSet
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar)
    End Function
    Public Function LoadDS(ByVal obj As objThongKeSoNgayNghiOMCOTrongNam) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT X_MA_,(X_MA_+' ------------- '+X_TEN) AS X_TEN FROM ST_NXUONG WHERE X_MA_ NOT IN ('KB') ORDER BY X_MA_")
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
