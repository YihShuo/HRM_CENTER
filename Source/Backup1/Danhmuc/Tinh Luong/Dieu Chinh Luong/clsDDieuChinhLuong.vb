
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDDieuChinhLuong
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objDieuChinhLuong) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT ST_NHANVIEN.DV_MA,")
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.NV_Ten,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.NV_Ma,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.T_MA,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.NV_Ngayvao,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.CV_TEN,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.NgayDBL,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.HESOCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.LUONGCBCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCMCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCUDCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCKHACCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCHMPTCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCDHNNCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCVCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCBVPCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCBTSCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.THUONGABCCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TONGLUONGCU,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.BACLUONGMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.HESOMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.LUONGMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCMMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCUDMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCKHACMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCHMPTMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCDHNN,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCVMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCBVPMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TCCBTSMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.THUONGABCMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TONGLUONGMOI,"
            strSQL = strSQL + " IT_BANGLUONGTHANG0109.TONGCL"
            strSQL = strSQL + " FROM IT_BANGLUONGTHANG0109 INNER JOIN ST_NHANVIEN ON IT_BANGLUONGTHANG0109.NV_MA = ST_NHANVIEN.NV_MA"
            strSQL = strSQL + " WHERE IT_BANGLUONGTHANG0109.T_MA = '" & Me.QuoteString(obj.NamThang) & "' AND ST_NHANVIEN.DV_MA = '" & Me.QuoteString(obj.DonVi) & "' "
        End If

        ''Cau truy van load Tuan len combo Tuan
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT DV_MA FROM ST_DONVI WHERE DV_MA <> ' ' AND DV_LOCBB = 0 ORDER BY DV_MA ASC ")
        End If

        'Thuc thi cau truy van
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
