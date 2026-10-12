''===== người tạo :Gấm
''===== ngày tạo: 13-02-2017
''===== nội dung: Tạo mới lớp ClsDGioCongHangNgayDonVi
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class ClsDGioCongHangNgayDonVi
    Inherits DALSQL
    Public Function QuoteString(ByVal s As String) As String
        Return s.Replace("'", "''")
    End Function
    Public Function LoadDS(ByVal obj As ObjGioCongHangNgayDonVi) As DataTable
        Dim table As DataTable
        Dim tabletam As DataTable = Nothing
        If obj.ChonBang = 1 Then
            If obj.CHONKHU = "TCT" Then
                Dim SqlParam1 As SqlParameter() = {New SqlParameter("@THANG", SqlDbType.NVarChar, 50), _
                                           New SqlParameter("@NAM", SqlDbType.NVarChar, 50), _
                                           New SqlParameter("@T_MA", SqlDbType.NVarChar, 50)}
                SqlParam1(0).Value = obj.THANG
                SqlParam1(1).Value = obj.NAM
                SqlParam1(2).Value = obj.T_MA

                tabletam = getTableProcedure("SP_GIOCONGHANGNGAY_TCT_S_LUOI_THUNGHIEM_2", SqlParam1)
            Else
                Dim SqlParam As SqlParameter() = {New SqlParameter("@THANG", SqlDbType.NVarChar, 50), _
                                           New SqlParameter("@NAM", SqlDbType.NVarChar, 50), _
                                           New SqlParameter("@T_MA", SqlDbType.NVarChar, 50), _
                                            New SqlParameter("@KHU", SqlDbType.NVarChar, 50)}
                SqlParam(0).Value = obj.THANG
                SqlParam(1).Value = obj.NAM
                SqlParam(2).Value = obj.T_MA
                SqlParam(3).Value = obj.CHONKHU
                tabletam = getTableProcedure("SP_GIOCONGHANGNGAY_TCT_S_KHU", SqlParam)
            End If

        End If
        If obj.ChonBang = 2 Then
            tabletam = getTableProcedure("SP_DONVI_TINHGIOCONGHANGNGAY")
        End If
        Try
            table = tabletam
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
