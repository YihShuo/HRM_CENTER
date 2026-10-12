Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDBaoCaoTongHop
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucThongke(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
    End Function
    Public Function GoiThuTucThongke(ByVal m_sSP_Name As String) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
    End Function
    Public Function GoiThuTucKhongThamSo(ByVal m_sSP_Name As String) As Boolean
        Return Me.execProc(m_sSP_Name)
    End Function
    Public Function Load(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Try
            Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function
    Public Function LoadDS(ByVal obj As objBaoCaoTongHop) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
     

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT * FROM ST_THANG WHERE RIGHT (T_MA,4) = '" + obj.Nam + "'")
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
