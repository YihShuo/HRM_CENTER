Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Public Class ClsDChuyenDVExcel
    Inherits DALSQL

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function LoadDS(ByVal obj As objChuyenDVExcel) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""
        If obj.ChonBang = 1 Then
            strSQL = "SELECT STT='',Hoten,Sothe,Ngaychuyen,DVDDcu,Donvi,Gioitinh,Ghichu from tam_chuyendonvi"
        End If

        If obj.ChonBang = 2 Then
            strSQL = "SELECT * from tam_chuyendonvi"
        End If

        If obj.ChonBang = 3 Then
            strSQL = "SELECT * from tam_chuyendonvi where sothe in (select NV_Ma from ST_CHUYENDONVI where MONTH(ngay)=MONTH(GETDATE()) and YEAR(ngay)=YEAR(GETDATE()))"
        End If

        If obj.ChonBang = 4 Then
            strSQL = ("SELECT  STT, ST_NHANVIEN.NV_MA AS MA,")
            strSQL = strSQL + "ST_NHANVIEN.NV_TEN AS TEN,"
            strSQL = strSQL + "ST_CHUYENDONVI.NGAY AS NGAYCD,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_DONVICU AS DVCU,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_CHUCVUCU AS CVUCU, "
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_DONVIMOI AS DVMOI,"
            strSQL = strSQL + "ST_CHUYENDONVI.CDV_CHUCVUMOI AS CVUMOI "
            strSQL = strSQL + " FROM ST_NHANVIEN INNER JOIN ST_CHUYENDONVI ON ST_NHANVIEN.NV_MA =ST_CHUYENDONVI.NV_MA "
            strSQL = strSQL + " INNER JOIN ST_CHUCVU ON ST_NHANVIEN.CVU_MA = ST_CHUCVU.CVU_MA "
            strSQL = strSQL + " INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA=ST_DONVI.DV_MA AND DV_LOCBB = 0 "
            strSQL = strSQL + " WHERE ST_CHUYENDONVI.NV_MA IN (SELECT SOTHE FROM TAM_CHUYENDONVI) and MONTH(ST_CHUYENDONVI.NGAY)=MONTH(GETDATE()) order by ST_NHANVIEN.NV_MA"
        End If

        If obj.ChonBang = 5 Then
            strSQL = "SELECT * FROM ST_CHUYENDONVI WHERE NV_Ma IN (SELECT SOTHE FROM tam_chuyendonvi) AND MONTH(NGAY)=MONTH(GETDATE()) AND YEAR(NGAY)=YEAR(GETDATE())"
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

    Public Function InsertInfo(ByVal obj As objChuyenDVExcel, ByVal sNguoiCapNhat As String) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
        strSQL = ((String.Concat(New String() {strSQL, "insert into ST_CHUYENDONVI (NV_Ma,NGAY,CDV_Donvimoi,CDV_donvicu,CDV_Chucvucu,CDV_Chucvumoi,HASHVALUE,NGAYTAO,NGUOITAO,NGAYCAPNHAT,NGUOICAPNHAT) select Sothe,case when MONTH(GETDATE())<=9 and MONTH(GETDATE())>0 then convert(nvarchar(20),YEAR(GETDATE()))+'-0'+convert(nvarchar(20),MONTH(GETDATE()))+'-01 00:00:00.000' else convert(nvarchar(20),YEAR(GETDATE()))+'-'+convert(nvarchar(20),MONTH(GETDATE()))+'-01 00:00:00.000' end,d.Donvi,d.DVDDcu,c.CDV_Chucvucu,c.CDV_Chucvumoi,HASHVALUE=NULL,convert(datetime,GETDATE(),21),'admin',convert(datetime,GETDATE(),21),NGUOICAPNHAT=N'", Me.QuoteString(sNguoiCapNhat), "' from TAM_CHUYENDONVI D LEFT JOIN ST_CHUYENDONVI C ON D.Sothe=C.NV_Ma AND D.Donvi=C.CDV_donvicu ORDER BY Sothe"}) & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function DeleteInfo(ByVal jFunction As objChuyenDVExcel) As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'strSQL = ("delete from ST_CHUYENDONVI where NV_MA=N'" & Me.QuoteString(jFunction.MANV) & "'AND ngay = '" & Me.QuoteString(jFunction.NGAYCD)) & "'"
        strSQL = "delete from tam_chuyendonvi"
        Return Me.execSQL(strSQL)
    End Function

    Public Function UpdateInfo(ByVal obj As objChuyenDVExcel, ByVal sNguoiCapNhat As String) As Boolean

        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
        'If obj.ChonBang = 1 Then
        '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_CHUYENDONVI SET NGAY= case when MONTH(GETDATE())<=9 and MONTH(GETDATE())>0 then convert(nvarchar(20),YEAR(GETDATE()))+'-0'+convert(nvarchar(20),MONTH(GETDATE()))+'-01' else convert(nvarchar(20),YEAR(GETDATE()))+'-'+convert(nvarchar(20),MONTH(GETDATE()))+'-01' end, CDV_Donvimoi=d.Donvi, CDV_donvicu=d.DVDDcu,NGAYCAPNHAT=convert(datetime,GETDATE(),21),NGUOICAPNHAT=N'", Me.QuoteString(sNguoiCapNhat), "' from TAM_CHUYENDONVI D LEFT JOIN ST_CHUYENDONVI C ON D.Sothe=C.NV_Ma where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        'End If
        If obj.ChonBang = 8 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_NHANVIEN SET ST_NHANVIEN.DV_MA = ST_CHUYENDONVI.CDV_DONVIMOI,ST_NHANVIEN.NGAYCAPNHAT=convert(datetime,GETDATE(),21),ST_NHANVIEN.NGUOICAPNHAT=N'", Me.QuoteString(sNguoiCapNhat), "' FROM ST_CHUYENDONVI INNER JOIN ST_NHANVIEN ON ST_CHUYENDONVI.NV_MA = ST_NHANVIEN.NV_MA WHERE ST_NHANVIEN.NV_MA IN (SELECT SOTHE FROM tam_chuyendonvi) and (YEAR(ST_CHUYENDONVI.ngay)=YEAR(GETDATE())) and MONTH(ST_CHUYENDONVI.Ngay)=MONTH(GETDATE())"}) & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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
