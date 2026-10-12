
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Public Class clsDDanhMucQLMTCV_PTCV
    Inherits DALSQL
    Public Function LoadDS(ByVal obj As objDanhMucQLMTCV_PTCV) As DataTable
        Dim table As DataTable
        Dim strSQL As String = ""

        If obj.ChonBang = 2 Then
            If obj.DONVI = "TCT" Then
                strSQL = "SELECT NHOMCV_MA,"
                strSQL = strSQL + " NHOMCV_TEN,"
                strSQL = strSQL + " NHOMCV_TT = ISNULL(NHOMCV_TT,0),"
                strSQL = strSQL + " NHOMCV_TINHTRANG = ISNULL(NHOMCV_TINHTRANG,0),"
                strSQL = strSQL + " GHICHU"
                strSQL = strSQL + " FROM IT_QUANLY_MTCV_PTCV"
                strSQL = strSQL + " WHERE ISNULL(NHOMCV_TINHTRANG,0) = 1"
            Else
                strSQL = "SELECT NHOMCV_MA,"
                strSQL = strSQL + " NHOMCV_TEN,"
                strSQL = strSQL + " NHOMCV_TT = ISNULL(NHOMCV_TT,0),"
                strSQL = strSQL + " NHOMCV_TINHTRANG = ISNULL(NHOMCV_TINHTRANG,0),"
                strSQL = strSQL + " GHICHU"
                strSQL = strSQL + " FROM IT_QUANLY_MTCV_PTCV"
                strSQL = strSQL + " WHERE ISNULL(NHOMCV_TINHTRANG,0) = 1"
            End If
           
        End If
        If obj.ChonBang = 3 Then
            strSQL = "SELECT NHOMCV_MA"
            strSQL = strSQL + " FROM IT_QUANLY_MTCV_PTCV"
            strSQL = strSQL + " WHERE NHOMCV_MA = N'" & obj.NHOMCV_MA & "'"
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
    Public Function InsertInfo(ByVal obj As objDanhMucQLMTCV_PTCV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "INSERT INTO IT_QUANLY_MTCV_PTCV"
            strSQL = strSQL + " ([NHOMCV_MA]"
            strSQL = strSQL + " ,[NHOMCV_TEN]"
            strSQL = strSQL + " ,[GHICHU]"
            strSQL = strSQL + " ,[NHOMCV_TT]"
            strSQL = strSQL + " ,[NHOMCV_TINHTRANG])"
            strSQL = strSQL + " VALUES(N'" & obj.NHOMCV_MA & "', N'" & obj.NHOMCV_TEN & "',N'" & obj.GHICHU & "','" & obj.NHOMCV_TT & "','" & obj.NHOMCV_TINHTRANG & "')"

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

    Public Function UpdateInfo(ByVal obj As objDanhMucQLMTCV_PTCV) As Boolean
        Dim flag As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "UPDATE IT_QUANLY_MTCV_PTCV"
            strSQL = strSQL + " SET NHOMCV_TEN = N'" & obj.NHOMCV_TEN & "',"
            strSQL = strSQL + " GHICHU = N'" & obj.GHICHU & "',"
            strSQL = strSQL + " NHOMCV_TT = '" & obj.NHOMCV_TT & "', NHOMCV_TINHTRANG = '" & obj.NHOMCV_TINHTRANG & "'"
            strSQL = strSQL + " WHERE NHOMCV_MA = N'" & obj.NHOMCV_MA & "'"
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

    Public Function DeleteInfo(ByVal obj As objDanhMucQLMTCV_PTCV) As Boolean
        Dim strSQL As String
        If obj.ChonBang = 1 Then
            strSQL = "DELETE IT_QUANLY_MTCV_PTCV WHERE NHOMCV_MA ='" & obj.NHOMCV_MA & "'"
        End If
        Return Me.execSQL(strSQL)
    End Function
End Class
