Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL
Public Class clsDTieuChuan
    Inherits DALSQL
    ' Methods
    Public Function LoadDS(ByVal obj As objTieuChuan) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        'A
        If obj.ChonBang = 1 Then
            strSQL = " SELECT DV_MA, NV_TEN, NV_MA, NV_Ngayvao,TONGBBA,TONGBBB,TONGBBC,TONGBBOX FROM IT_TABLE_TIEUCHUAN1 WHERE NAM = '" & obj.NAM & "'"
        End If
        ' ANEW
        If obj.ChonBang = 2 Then
            strSQL = " SELECT DV_MA, NV_TEN, NV_MA, NV_Ngayvao, TONGBBA,"
            strSQL = strSQL + " TONGBBB,TONGBBC,TONGBBOX,SONGAYOO,SONGAYRO,"
            strSQL = strSQL + " SONGAYCO,SONGAYO,SONGAYOTC,SONGAYP,SONGAYKTHAI,SONGAYR,"
            strSQL = strSQL + " SONGAYS, SONGAYNO, SONGAYTSAN, [SONGAYTNLD]"
            strSQL = strSQL + " FROM IT_TABLE_TIEUCHUAN2 WHERE NAM = '" & obj.NAM & "'"
        End If
        ' C       
        If obj.ChonBang = 3 Then
            strSQL = " SELECT"
            strSQL = strSQL + " DV_MA,"
            strSQL = strSQL + " NV_TEN,"
            strSQL = strSQL + " NV_MA,"
            strSQL = strSQL + " NV_Ngayvao,"
            strSQL = strSQL + " TONGBBA,TONGBBB,TONGBBC,TONGBBOX,"
            strSQL = strSQL + " SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP,SONGAYKTHAI,SONGAYR,"
            strSQL = strSQL + " SONGAYS,SONGAYNO,SONGAYTSAN,[SONGAYTNLD]"
            strSQL = strSQL + " FROM IT_TABLE_TIEUCHUAN3 WHERE NAM = '" & obj.NAM & "'"
        End If
        ' CNEW       
        If obj.ChonBang = 4 Then
            strSQL = "SELECT "
            strSQL = strSQL + " DV_MA, "
            strSQL = strSQL + " NV_TEN, "
            strSQL = strSQL + " NV_MA, "
            strSQL = strSQL + " NV_Ngayvao, "
            strSQL = strSQL + " TONGBBA,TONGBBB,TONGBBC,TONGBBOX "
            strSQL = strSQL + " FROM IT_TABLE_TIEUCHUAN4 WHERE NAM = '" & obj.NAM & "'"
        End If
        'OX
        If obj.ChonBang = 5 Then
            strSQL = " SELECT "
            strSQL = strSQL + " DV_MA, "
            strSQL = strSQL + " NV_TEN, "
            strSQL = strSQL + " NV_MA, "
            strSQL = strSQL + " NV_Ngayvao, "
            strSQL = strSQL + " TONGBBA,TONGBBB,TONGBBC,TONGBBOX "
            strSQL = strSQL + " FROM IT_TABLE_TIEUCHUANXS WHERE NAM = '" & obj.NAM & "'"
        End If
        'B
        If obj.ChonBang = 6 Then
            strSQL = " SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA,"
            strSQL = strSQL + " NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO,"
            strSQL = strSQL + " SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN,"
            strSQL = strSQL + " SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST FROM IT_TABLE_BBB WHERE NAM = '" & obj.NAM & "'"
        End If
        'toan bo
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

    Public Function UpdateInfo(ByVal obj As objTieuChuan) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            'strSQL = "UPDATE ST_TAMUNG  SET TU_THUONGABC = " & Me.QuoteString(obj.SoTien) & " WHERE NV_MA = '" & Me.QuoteString(obj.NV_MA) & "' AND	T_MA =  '" & Me.QuoteString(obj.NamThang) & "'"
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

    Public Function DeleteInfo(ByVal obj As objTieuChuan) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE ST_BINHBAUNAM WHERE BB_NAM = '" & Me.QuoteString(obj.NAM) & "' "
        End If
        Return Me.execSQL(strSQL)
    End Function

    Public Function InsertInfo(ByVal obj As objTieuChuan) As Boolean
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function
End Class
