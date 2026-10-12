Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports VsHRM.VsHRM.VsDAL

Public Class clsDMayChamCongSo
    Inherits DALSQL
    ' Methods
    'Public Function DeleteInfo(ByVal obj As objMayChamCongSo) As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & "delete from ST_PHANCA where NV_MA =N'" & Me.QuoteString(obj.NV_MA)) & "'" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Return Me.execSQL(strSQL)
    'End Function

    'Public Function IsDeleteOK(ByVal obj As objMayChamCongSo) As Boolean
    '    'Dim strSQL As String = ("select * from PR_DayOff where DayOff_ID=N'" & Me.QuoteString(obj.ID) & "'")
    '    'If (Me.getTableSQL(strSQL).Rows.Count > 0) Then
    '    '    Return False
    '    'End If
    '    Return True
    'End Function

    'Public Function InsertInfo(ByVal obj As objMayChamCongSo) As Boolean
    '    Dim flag As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = (strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10))
    '    strSQL = ((String.Concat(New String() {strSQL, "INSERT INTO ST_PHANCA ([NV_MA],[CA_MA],[PC_NGAYBATDAU],[PC_NGAYKETTHUC],[CA_GIOBATDAU],[CA_GIOKETTHUC],[DV_MA]) VALUES (N'", Me.QuoteString(obj.NV_MA), "',N'", Me.QuoteString(obj.CA_MA), "',N'", Me.QuoteString(obj.NGAYBATDAU), "',N'", Me.QuoteString(obj.NGAYKETTHUC), "',N'", Me.QuoteString(obj.GIOBATDAU), "',N'", Me.QuoteString(obj.GIOKETTHUC), "',N'", Me.QuoteString(obj.DV_MA)}) & "')" & ChrW(13) & ChrW(10) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Try
    '        flag = Me.execSQL(strSQL)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function

    ''Public Function IsDeleteOK(ByVal obj As objNgayNghi) As Boolean
    ''    Dim strSQL As String = ("select * from PR_DayOff where DayOff_ID=N'" & Me.QuoteString(obj.ID) & "'")
    ''    If (Me.getTableSQL(strSQL).Rows.Count > 0) Then
    ''        Return False
    ''    End If
    ''    Return True
    ''End Function

    Public Function LoadDS(ByVal obj As objMayChamCongSo) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 1 Then
            If (StringType.StrCmp(obj.SoMay, "", False) <> 0) Then
                strSQL = (strSQL & " WHERE QT_SOMAY1 = N'" & Me.QuoteString(obj.SoMay) & "' or QT_SOMAY2 = N'" & Me.QuoteString(obj.SoMay) & "'")
            End If
            strSQL = (" SELECT X_MA_, DV_MA, DV_TEN, QT_SOMAY1, QT_SOMAY2 FROM ST_DONVI " & strSQL & " ")
        End If

        If obj.ChonBang = 2 Then
            If (StringType.StrCmp(obj.SoMay, "", False) <> 0) Then
                strSQL = (strSQL & " WHERE ISNULL(QT_SOMAY1,'A') <> N'" & Me.QuoteString(obj.SoMay) & "' and ISNULL(QT_SOMAY2,'A') <> N'" & Me.QuoteString(obj.SoMay) & "'")
            End If
            strSQL = (" SELECT DV_MA, DV_TEN, QT_SOMAY1, QT_SOMAY2 FROM ST_DONVI " & strSQL & " and DV_MA <> '' AND X_MA_ <> 'KB' ")
        End If

        If obj.ChonBang = 3 Then
            If (StringType.StrCmp(obj.SoMay, "", False) <> 0) Then
                strSQL = (strSQL & " WHERE QT_SOMAY1 = N'" & Me.QuoteString(obj.SoMay) & "' or QT_SOMAY2 = N'" & Me.QuoteString(obj.SoMay) & "'")
            End If
            strSQL = (" SELECT DV_MA, DV_TEN, QT_SOMAY1, QT_SOMAY2 FROM ST_DONVI " & strSQL & " ")
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

    ''Public Function PhatSinhMa() As String
    ''    Dim str As String
    ''    Dim nghi As New objNgayNghi
    ''    Dim num As Integer = 0
    ''    Dim flag As Boolean = False
    ''    Do While Not flag
    ''        If (num < 10) Then
    ''            str = ("NN0" & StringType.FromInteger(num))
    ''        Else
    ''            str = ("NN" & StringType.FromInteger(num))
    ''        End If
    ''        nghi.Setnull()
    ''        nghi.ID = str
    ''        If (Me.LoadDS(nghi).Rows.Count > 0) Then
    ''            num += 1
    ''        Else
    ''            flag = True
    ''        End If
    ''    Loop
    ''    Return str
    ''End Function

    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function

    Public Function UpdateInfoSoMay1(ByVal obj As objMayChamCongSo) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_DONVI set QT_SOMAY1='' where DV_MA = N'", Me.QuoteString(obj.DonVi)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If


        If obj.ChonBang = 2 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_DONVI set QT_SOMAY1= '", Me.QuoteString(obj.SoMay), "' where DV_MA = N'", Me.QuoteString(obj.DonVi)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    Public Function UpdateInfoSoMay2(ByVal obj As objMayChamCongSo) As Boolean
        Dim flag As Boolean
        Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)

        If obj.ChonBang = 1 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_DONVI set QT_SOMAY2='' where DV_MA = N'", Me.QuoteString(obj.DonVi)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
        End If

        If obj.ChonBang = 2 Then
            strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_DONVI set QT_SOMAY2='", Me.QuoteString(obj.SoMay), "' where DV_MA = N'", Me.QuoteString(obj.DonVi)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
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

    'Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
    '    Me.execProc(m_sSP_Name, m_listpar)
    'End Function


    'Public Function UpdateST_NHANVIEN(ByVal obj As objMayChamCongSo) As Boolean
    '    Dim flag As Boolean
    '    Dim strSQL As String = "BEGIN TRANSACTION" & ChrW(13) & ChrW(10)
    '    strSQL = ((((strSQL & "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE" & ChrW(13) & ChrW(10)) & String.Concat(New String() {"UPDATE ST_NHANVIEN set Ca_Truoc=N'", Me.QuoteString(obj.CA_MA), "'  where NV_MA = N'", Me.QuoteString(obj.NV_MA)}) & "'" & ChrW(13) & ChrW(10)) & "if(@@ERROR<>0)" & ChrW(13) & ChrW(10)) & "ROLLBACK TRANSACTION" & ChrW(13) & ChrW(10) & "COMMIT TRANSACTION")
    '    Try
    '        flag = Me.execSQL(strSQL)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        MessageBox.Show(exception.Message)
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function

End Class

