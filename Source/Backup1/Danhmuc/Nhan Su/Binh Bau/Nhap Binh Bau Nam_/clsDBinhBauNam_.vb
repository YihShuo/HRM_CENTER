Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDBinhBauNam_
    Inherits DALSQL
    ' Methods


    Public Function LoadDS(ByVal obj As objBinhBauNam_) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'Load danh sach don vi
        If obj.ChonBang = 1 Then
            strSQL = ("select DV_MA, (DV_MA+' - '+DV_TEN) AS TEN_DV FROM ST_DONVI WHERE  DV_MA <> 'CNM' order by dv_ma ")
        End If

        If obj.ChonBang = 2 Then
            strSQL = "SELECT NULL AS [1],CONVERT(BIT,'0') AS [2],NULL AS [3],ST_NHANVIEN.NV_MA,"
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " NV_Ngayvao,"
            strSQL = strSQL + " BB_NAM,"
            strSQL = strSQL + " BB_Ma,"
            strSQL = strSQL + " BB_Truoc,"
            strSQL = strSQL + " BB_SongayOO,"
            strSQL = strSQL + " BB_SongayRO,"
            strSQL = strSQL + " BB_SongayCO ,"
            strSQL = strSQL + " BB_SoNgayO,"
            strSQL = strSQL + " BB_SoNgayOTC,"
            strSQL = strSQL + " BB_SoNgayP,"
            strSQL = strSQL + " BB_SoNgayKThai,"
            strSQL = strSQL + " BB_SoNgayR,"
            strSQL = strSQL + " BB_SoNgayS,"
            strSQL = strSQL + " BB_SoNgayNo,"
            strSQL = strSQL + " BB_SoNgayTSan,"
            strSQL = strSQL + " BB_SoNgayTNLD,"
            strSQL = strSQL + " BB_Ditre,"
            strSQL = strSQL + " BB_SONGAYDQ,"
            strSQL = strSQL + " BB_SONGAYDS,"
            strSQL = strSQL + " BB_SONGAYST,"
            strSQL = strSQL + " BB_SONGAYKHHGD,"
            strSQL = strSQL + " BB_SONGAYQS"
            strSQL = strSQL + " FROM ST_NHANVIEN LEFT JOIN ST_BINHBAUNAM ON ST_NHANVIEN.NV_MA = ST_BINHBAUNAM.NV_MA AND ST_BINHBAUNAM.BB_NAM ='" + obj.NAM + "'"
            strSQL = strSQL + " WHERE ST_NHANVIEN.NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)"
            strSQL = strSQL + " AND ST_NHANVIEN.DV_MA = '" + obj.DV_MA + "'"
        End If
        If obj.ChonBang = 3 Then
            strSQL = ("SELECT BB_MA FROM ST_BINHBAU ")
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

    Public Function UpdateInfo(ByVal obj As objBinhBauNam_) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "UPDATE ST_KHOANCONGKHAC  SET SOTIEN = " & Me.QuoteString(obj.SoTien) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
        End If
        If obj.ChonBang = 2 Then
            'strSQL = "UPDATE [ST_GIOQUETTHE_]   SET [CC_SUATAN] = " + obj.ChamCom + " WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"
        End If
        '= "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE [ST_GIOQUETTHE_]   SET [QT_GIOVAOTAY] = " + obj.GioVaoTay + " ,[QT_GIORATAY] = " + obj.GioRaTay + " ,[CA_MA] = '" + obj.CA_Ma + "' WHERE [QT_NGAY] = '" + obj.Ngay + "' AND	[NV_MA] =  '" + obj.NV_MA + "'"}) & " " & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function DeleteInfo(ByVal obj As objBinhBauNam_) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "DELETE ST_BINHBAUTHANG WHERE NV_MA ='" & Me.QuoteString(obj.NV_MA) & "'AND T_MA = '" & Me.QuoteString(obj.NAM ) & "' "
        End If

        Return Me.execSQL(strSQL)
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
    Public Function InsertInfo(ByVal obj As objBinhBauNam_) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = ("INSERT INTO ST_KHOANCONGKHAC([NV_MA],[T_MA],[SOTIEN]) values(N'" & Me.QuoteString(obj.NV_MA) & "',N'" & Me.QuoteString(obj.NamThang) & "'," & Me.QuoteString(obj.SoTien) & ")")
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
End Class
