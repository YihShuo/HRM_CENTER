Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class clsDTongHopComThang
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objTongHopComThang) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            strSQL = ("SELECT X_MA_, DV_MA, THANG, NGAY1, NGAY2,NGAY3, NGAY4, NGAY5,NGAY6,NGAY7,NGAY8,NGAY9,NGAY10,NGAY11,NGAY12,NGAY13,NGAY14,NGAY15,NGAY16,NGAY17,NGAY18,NGAY19,NGAY20,NGAY21,NGAY22,NGAY23,NGAY24,NGAY25,NGAY26,NGAY27,NGAY28,NGAY29,NGAY30,NGAY31, TONGCONG FROM Q_TONGHOPCOMTHANG WHERE THANG ='" & Me.QuoteString(obj.NGAY) & "'GROUP BY X_MA_, DV_MA, THANG, NGAY1, NGAY2,NGAY3, NGAY4, NGAY5,NGAY6,NGAY7,NGAY8,NGAY9,NGAY10,NGAY11,NGAY12,NGAY13,NGAY14,NGAY15,NGAY16,NGAY17,NGAY18,NGAY19,NGAY20,NGAY21,NGAY22,NGAY23,NGAY24,NGAY25,NGAY26,NGAY27,NGAY28,NGAY29,NGAY30,NGAY31, TONGCONG")
        End If
        If obj.ChonBang = 2 Then
            strSQL = ("SELECT DV_MA FROM ST_DONVI WHERE DV_MA <> ' ' ORDER BY DV_MA ")
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("DELETE FROM Q_TONGHOPCOMTHANG WHERE THANG = N'" & Me.QuoteString(obj.THANG) & "'AND DV_MA = '" & Me.QuoteString(obj.DONVI) & "'")
        End If
        If obj.ChonBang = 4 Then
            strSQL = ("SELECT Q_BANGTONGHOPCOMTHANGVIEW.DV_MA, Q_BANGTONGHOPCOMTHANGVIEW.THANG FROM Q_BANGTONGHOPCOMTHANGVIEW WHERE THANG = N'" & Me.QuoteString(obj.THANG) & "'AND DV_MA = '" & Me.QuoteString(obj.DONVI) & "'")
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
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
