Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTinhLuong13
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As objTinhLuong13) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.CHONBANG = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 ORDER BY DV_MA ")
        End If
        If obj.CHONBANG = 3 Then 'chọn xưởng
            strSQL = ("select  ST_DONVI.X_MA_ ,( ST_DONVI.X_MA_+' - '+X_TEN) AS X_TEN from st_donvi inner join ST_NXUONG on ST_DONVI.X_MA_ = ST_NXUONG.X_MA_ where dv_ma <> 'CNM' AND DV_LOCBB = 0 GROUP BY ST_DONVI.X_MA_,X_TEN ORDER BY X_MA_")
        End If
        If obj.CHONBANG = 2 Then
            If obj.DONVI = "TCT" Then
                strSQL = "select NULL AS [1],"
                strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                strSQL = strSQL + " NULL AS [3], "
                strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                strSQL = strSQL + " ST_NHANVIEN.NV_TEN, "
                strSQL = strSQL + " ST_NHANVIEN.DV_MA, "
                strSQL = strSQL + " ST_NHANVIEN.CVU_MA, "
                strSQL = strSQL + " L13_Sothang ,"
                strSQL = strSQL + " L13_Xeploai ,"
                strSQL = strSQL + " L13_Luong ,"
                strSQL = strSQL + " L13_Phucap ,"
                strSQL = strSQL + " L13_Heso ,"
                strSQL = strSQL + "  L13_ThuongThang13"
                strSQL = strSQL + " from ST_LUONG13 INNER JOIN ST_NHANVIEN on ST_LUONG13.NV_Ma = ST_NHANVIEN.NV_Ma "
                strSQL = strSQL + " WHERE Nam ='" + obj.NAM + "' ORDER BY DV_MA"

            Else
                If obj.LOAIBAOCAO = 1 Then
                    strSQL = "select NULL AS [1],"
                    strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                    strSQL = strSQL + " NULL AS [3], "
                    strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                    strSQL = strSQL + " ST_NHANVIEN.NV_TEN, "
                    strSQL = strSQL + " ST_NHANVIEN.DV_MA, "
                    strSQL = strSQL + " ST_NHANVIEN.CVU_MA, "
                    strSQL = strSQL + " L13_Sothang ,"
                    strSQL = strSQL + " L13_Xeploai ,"
                    strSQL = strSQL + " L13_Luong ,"
                    strSQL = strSQL + " L13_Phucap ,"
                    strSQL = strSQL + " L13_Heso ,"
                    strSQL = strSQL + "  L13_ThuongThang13"
                    strSQL = strSQL + " from ST_LUONG13 INNER JOIN ST_NHANVIEN on ST_LUONG13.NV_Ma = ST_NHANVIEN.NV_Ma "
                    strSQL = strSQL + " WHERE Nam ='" + obj.NAM + "'"
                    strSQL = strSQL + " AND DV_MA IN (SELECT DV_MA from st_donvi where dv_ma <> 'CNM' AND DV_LOCBB = 0 AND X_MA_ = '" + obj.DONVI + "' GROUP BY DV_MA ) ORDER BY DV_MA" 'OBI.DONVI xài chung biến cho xưởng ,đv
                    'strSQL = strSQL + " AND DV_MA ='" + obj.DONVI + "'"
                Else
                    strSQL = "select NULL AS [1],"
                    strSQL = strSQL + " CONVERT(BIT,'0') AS [2],"
                    strSQL = strSQL + " NULL AS [3], "
                    strSQL = strSQL + " ST_NHANVIEN.NV_MA,"
                    strSQL = strSQL + " ST_NHANVIEN.NV_TEN, "
                    strSQL = strSQL + " ST_NHANVIEN.DV_MA, "
                    strSQL = strSQL + " ST_NHANVIEN.CVU_MA, "
                    strSQL = strSQL + " L13_Sothang ,"
                    strSQL = strSQL + " L13_Xeploai ,"
                    strSQL = strSQL + " L13_Luong ,"
                    strSQL = strSQL + " L13_Phucap ,"
                    strSQL = strSQL + " L13_Heso ,"
                    strSQL = strSQL + "  L13_ThuongThang13"
                    strSQL = strSQL + " from ST_LUONG13 INNER JOIN ST_NHANVIEN on ST_LUONG13.NV_Ma = ST_NHANVIEN.NV_Ma "
                    strSQL = strSQL + " WHERE Nam ='" + obj.NAM + "'"
                    strSQL = strSQL + " AND DV_MA ='" + obj.DONVI + "'"
                End If
                
            End If
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
    Public Function UpdateInfo(ByVal obj As objTinhLuong13) As Boolean
        Dim flag As Boolean
        Dim strSQL As String

        strSQL = "update ST_LUONG13 "
        strSQL = strSQL + " SET L13_ThuongThang13 = null, L13_Heso =null "
        strSQL = strSQL + " where NV_Ma='" + obj.NV_MA + "'"
        strSQL = strSQL + " and Nam ='" + obj.NAM + "'"

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
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
