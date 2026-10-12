Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class DParams
    Inherits DALSQL
    ' Methods
    Public Function getParameter(ByVal ParamID As String) As DataRow
        Dim strSQL As String = " SELECT * FROM tblParameters WHERE ParamID=@ParamID "
        Dim table As DataTable = Me.getTBwSQLpara(strSQL, New SqlParameter() {New SqlParameter("@ParamID", ParamID)})
        If (table.Rows.Count > 0) Then
            Return table.Rows.Item(0)
        End If
        Return Nothing
    End Function

    Public Function UpdateParameter(ByVal ParamID As String, ByVal ParamName As String, ByVal ParamValue As String) As Boolean
        Dim strSQL As String = " UPDATE tblParameters SET "
        strSQL = (strSQL & " ParamValue = @ParamValue " & " WHERE ParamID = @ParamID ")
        Dim listParameter As SqlParameter() = New SqlParameter() {New SqlParameter("@ParamID", ParamID), New SqlParameter("@ParamValue", ParamValue)}
        Return Me.execSQL(strSQL, listParameter)
    End Function


    Public Function UpdateServerChamcongParams(ByVal Server As String, ByVal UserName As String, ByVal Password As String, ByVal Database As String, ByVal IsUse As String) As Boolean
        Dim flag As Boolean = False
        flag = Me.UpdateParameter("ServerChamcong", "", Server)
        If flag Then
            flag = Me.UpdateParameter("UserIDChamcong", "", UserName)
        End If
        If flag Then
            flag = Me.UpdateParameter("PasswordChamcong", "", Password)
        End If
        If flag Then
            flag = Me.UpdateParameter("DatabaseChamcong", "", Database)
        End If
        If flag Then
            flag = Me.UpdateParameter("IsUseChamcong", "", IsUse)
        End If
        Return flag
    End Function

End Class


