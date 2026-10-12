Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class ClsDThongKeTheomqh
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As ObjThongKeTheomqh) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = strSQL + "  SELECT DISTINCT MA_QH   "
            strSQL = strSQL + "  FROM IT_NHANVIENQUANHE   "
            strSQL = strSQL + "  ORDER BY MA_QH   "
        End If

        If obj.ChonBang = 2 Then
            strSQL = strSQL + " SELECT '', "
            strSQL = strSQL + " A.NV_MA AS SOTHE, "
            strSQL = strSQL + " B.NV_TEN AS HOTEN, "
            strSQL = strSQL + " C.DV_TEN AS DONVI, "
            strSQL = strSQL + " (CASE WHEN B.NV_GIOITINH = 1 THEN 'NAM' ELSE 'NU' END) AS GIOITINH, "
            strSQL = strSQL + " B.NV_NGAYSINH AS NGAYSINH, "
            strSQL = strSQL + " A.MA_QH AS QUANHE, "
            strSQL = strSQL + " A.STT AS STT, "
            strSQL = strSQL + " A.TEN_QH AS TENQUANHE, "
            strSQL = strSQL + " A.NGAYSINH_QH AS NGAYSINH_QH, "
            strSQL = strSQL + " A.TENTHUONGGOI AS TENTHUONGGOI, "
            strSQL = strSQL + " A.NGHENGHIEP_QH   AS  NGHENGHIEP_QH, "
            strSQL = strSQL + " A.NOICONGTAC   AS  NOICONGTAC, "
            strSQL = strSQL + " A.DIACHI_QH   AS  DIACHI_QH, "
            strSQL = strSQL + " A.SOCMND_QH   AS  SOCMND_QH, "
            strSQL = strSQL + " A.NGAYCAP_QH   AS  NGAYCAP_QH, "
            strSQL = strSQL + " A.TAI_QH   AS  NOICAP_QH, "
            strSQL = strSQL + " A.SOTHE   AS  SOTHE_QH, "
            strSQL = strSQL + " A.COLAMVIEC   AS  QH_COLAMVIEC, "
            strSQL = strSQL + " (DATEDIFF(YEAR,A.NGAYSINH_QH,GETDATE()))AS TUOI_QH "
            strSQL = strSQL + " FROM IT_NHANVIENQUANHE AS A INNER JOIN ST_NHANVIEN AS B ON A.NV_MA = B.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI AS C ON B.DV_MA = C.DV_MA "
            strSQL = strSQL + " WHERE MA_QH = N'" & obj.MQH & "'"
            strSQL = strSQL + " ORDER BY B.DV_MA "
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
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function

End Class
