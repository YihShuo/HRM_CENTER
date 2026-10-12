Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDBinhBauChucVu
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objBinhBauChucVu) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi

        If obj.ChonBang = 1 Then
            strSQL = "SELECT NULL AS [1],NULL AS [2], BBCV_MA, CVU_MA, SOTIEN FROM ST_BINHBAUCHUCVU"
        End If
        If obj.ChonBang = 4 Then
            'strSQL = "SELECT * FROM ST_LOAITHOIVIEC"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "SELECT * FROM ST_BINHBAUCHUCVU WHERE BBCV_MA = '" + obj.BB_CVMA + "'AND CVU_MA = '" + obj.CVU_MA + "'"
        End If
        If obj.ChonBang = 6 Then
            'strSQL = "SELECT * FROM ST_NHANVIEN WHERE NV_MA ='" + obj.NV_MA + "'"
        End If
        If obj.ChonBang = 7 Then
            'strSQL = "SELECT NV_MA,TV_NGAYTHOIVIEC, TV_SOQUYETDINH, TV_LYDO,ST_NHANVIENTHOIVIEC.LTV_MA, LTV_TEN FROM ST_NHANVIENTHOIVIEC INNER JOIN ST_LOAITHOIVIEC ON  ST_NHANVIENTHOIVIEC.LTV_MA = ST_LOAITHOIVIEC.LTV_MA WHERE NV_MA ='" + obj.NV_MA + "'"
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

    Public Function UpdateInfo(ByVal obj As objBinhBauChucVu) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE ST_BINHBAUCHUCVU  SET  SOTIEN = " & Me.QuoteString(obj.SoTien) & " WHERE BBCV_MA = N'" & Me.QuoteString(obj.BB_CVMA) & "' AND CVU_MA = N'" & Me.QuoteString(obj.CVU_MA) & "'"
        End If
        If obj.ChonBang = 2 Then
            'strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [CC_SUATAN] = " + obj.ChamCom + " WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
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

    Public Function DeleteInfo(ByVal obj As objBinhBauChucVu) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_BINHBAUCHUCVU WHERE BBCV_MA ='" & Me.QuoteString(obj.BB_CVMA) & "' AND CVU_MA = '" & Me.QuoteString(obj.CVU_MA) & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objBinhBauChucVu) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = ("INSERT INTO ST_BINHBAUCHUCVU([BBCV_MA],[CVU_MA],[SOTIEN]) values(N'" & Me.QuoteString(obj.BB_CVMA) & "',N'" & Me.QuoteString(obj.CVU_MA) & "'," & Me.QuoteString(obj.SoTien) & ")")
        End If
        Try
            flag = Me.execSQL(strSQL)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
