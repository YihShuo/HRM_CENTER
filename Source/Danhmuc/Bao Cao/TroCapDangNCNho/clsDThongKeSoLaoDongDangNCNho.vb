Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKeSoLaoDongDangNCNho
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.execProc(m_sSP_Name, m_listpar)
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
    Public Function LoadKhongThamso(ByVal m_sSP_Name As String) As DataTable
        Try
            Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function
    Public Function TinhsolieutrocapUDMay(ByVal obj As objThongKeSoLaoDongDangNCNho) As Boolean
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            
        End If

        If obj.ChonBang = 2 Then
            
        End If
        Try
            Return Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Return False
            ProjectData.ClearProjectError()
        End Try
        Return False
    End Function
End Class
