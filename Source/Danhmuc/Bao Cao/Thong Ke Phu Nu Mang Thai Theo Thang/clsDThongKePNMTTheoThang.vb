Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDThongKePNMTTheoThang
    Inherits DALSQL
    Public Function LoadDanhmucThang(ByVal m_sSP_Name As String) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
    End Function
    Public Function GoiThuTucThongKeKThamSo(ByVal m_sSP_Name As String) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name).Tables(0)
    End Function
    Public Function LoadDS(ByVal obj As objThongKePNMTTheoThang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = ("SELECT DV_MA,DV_TEN FROM ST_DONVI WHERE ISNULL(DV_LOCBB,0) = 0 AND ISNULL(DV_TV,0) <> 1 AND DV_MA NOT LIKE '%CG%'  AND DV_MA NOT LIKE 'BGD%' AND DV_MA NOT LIKE 'DT%' ORDER BY DV_MA")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ("SELECT NV_TEN,KHU= CASE WHEN DV_MA= 'VP.ITPM' THEN 'A' ELSE  'B' END,ST_NHANVIEN.DV_MA FROM ST_NHANVIEN WHERE DV_MA IN( 'VP.ITPM','VP.CD') ORDER BY ST_NHANVIEN.DV_MA")
        End If

        If obj.ChonBang = 3 Then
            strSQL = ("SELECT NV_TEN= N'BẢNG THỐNG KÊ TỔNG GiỜ TĂNG CA CÁC XƯỞNG THÁNG',KHU= N'BẢNG THỐNG KÊ TỔNG GiỜ TĂNG CA CÁC XƯỞNG THÁNG',DV_MA= N'BẢNG THỐNG KÊ TỔNG GiỜ TĂNG CA CÁC XƯỞNG THÁNG' ")
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
    Public Function GoiThuTucTinhToan(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Dim flag As Boolean
        Try
            flag = Me.execProc(m_sSP_Name, m_listpar)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function
    Public Function GoiThuTucThongKe(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.getDatasetProcedure(m_sSP_Name, m_listpar).Tables(0)
    End Function

End Class
