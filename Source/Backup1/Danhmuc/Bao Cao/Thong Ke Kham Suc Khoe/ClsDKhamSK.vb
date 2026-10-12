Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class ClsDKhamSK
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objKhamSK) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = "SELECT STT='',* from tam_KhamSK"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "SELECT top 1 SOTHE from tam_KhamSK"
        End If

        If obj.ChonBang = 3 Then
            'strSQL = "SELECT * from tam_KhamSK where sothe in (select NV_Ma from ST_KhamSK where DOT=MONTH(GETDATE()) and YEAR(ngay)=YEAR(GETDATE()))"
        End If

        If obj.ChonBang = 4 Then
            strSQL = ("SELECT  STT='',SOTHE,DOT ,NAM ,DINHKY ,THINHLUC ,HOHAP ,VISINH ,MATUY ,PHUKHOA ,KHAMNGAY ,LOAI ,GHICHU ,NguoiTao ,Ngaytao ,NGUOICAPNHAT ,NGAYCAPNHAT ")
            strSQL = strSQL + " FROM ST_KhamSK where SOTHE IN (SELECT SOTHE FROM TAM_KHAMSK) ORDER BY SOTHE"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "SELECT NV_MA FROM ST_CHUYENDONVI WHERE NV_Ma IN (SELECT SOTHE FROM tam_KhamSK) AND MONTH(NGAY)=MONTH(GETDATE()) AND YEAR(NGAY)=YEAR(GETDATE())"
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

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.execProc(m_sSP_Name, m_listpar)
    End Function

    Public Function InsertInfo(ByVal obj As objKhamSK, ByVal sNguoitao As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_KhamSK (SOTHE,DOT,NAM,DINHKY,THINHLUC,HOHAP,VISINH,MATUY,PHUKHOA,GHICHU,NGUOITAO,NGAYTAO) select SOTHE,DOT,NAM,DINHKY,THINHLUC,HOHAP,VISINH,MATUY,PHUKHOA,GHICHU,NGUOITAO=N'", Me.QuoteString(sNguoitao), "',NGAYTAO=convert(datetime,GETDATE(),21) from TAM_KhamSK  ORDER BY Sothe"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function DeleteInfo(ByVal jFunction As objKhamSK) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = "delete from tam_KhamSK"
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objKhamSK, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean

        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        If obj.ChonBang = 7 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_KhamSK SET LOAI ='", Me.QuoteString(obj.LOAI), "' WHERE DOT = '", Me.QuoteString(obj.DOT), "' AND NAM = ", Me.QuoteString(obj.NAM), " AND SOTHE ='", Me.QuoteString(obj.SOTHE), "'"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

End Class
