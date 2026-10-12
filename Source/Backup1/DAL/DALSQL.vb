Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class DALSQL
    ' Events
    Public Event _error As _errorEventHandler

    ' Methods
    Protected Sub clearConnectionString()
        Me.strConn = ""
        Me.ser = ""
        Me.db = ""
        Me.uid = ""
        Me.pass = ""
    End Sub

    Public Function connectDB() As Boolean
        Try
            Me.getConnectString()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Throw New Exception(exception.Message)
        End Try
        Try
            Me.conn = New SqlConnection(Me.strConn)
            Me.conn.Open()
            Me.conn.Close()
        Catch exception3 As SqlException
            ProjectData.SetProjectError(exception3)
            Dim exception2 As SqlException = exception3
            Me.conn.Dispose()
            Throw New Exception(exception2.Message)
        End Try
        Return True
    End Function

    <Description("Thực thi một store procedure.")> _
    Protected Function execProc(ByVal storeName As String) As Boolean
        Dim flag As Boolean
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Try
            Me.cmd.ExecuteNonQuery()
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        Me.conn.Close()
        Return True
    End Function

    <Description("Thực thi một store procedure.")> _
    Protected Function execProc(ByVal storeName As String, ByVal listPar As ArrayList) As Boolean
        Dim flag As Boolean
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Me.cmd.CommandTimeout = 300
        Dim num2 As Integer = (listPar.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            Dim parameter As SqlParameter = DirectCast(listPar.Item(i), SqlParameter)
            Me.cmd.Parameters.Add(parameter)
            i += 1
        Loop
        Try
            Me.cmd.ExecuteNonQuery()
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        Me.conn.Close()
        Return True
    End Function

    <Description("Thực thi một câu lệnh SQL (Update hoặc Delete)")> _
    Protected Function execSQL(ByVal strSQL As String) As Boolean
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            ProjectData.ClearProjectError()
            Return False
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Try
            Me.cmd.ExecuteNonQuery()
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            Throw New Exception(Me.msgerr)
        End Try
        Me.conn.Close()
        Return True
    End Function

    <Description("Thực thi một lệnh SQL có sử dụng các tham số. Các lệnh SQL được viết riêng")> _
    Protected Function execSQL(ByVal strSQL As String, ByVal ParamArray listParameter As SqlParameter()) As Boolean
        Dim flag As Boolean
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Me.cmd.CommandTimeout = 300
        Dim parameter As SqlParameter
        For Each parameter In listParameter
            Me.cmd.Parameters.Add(parameter)
        Next
        Try
            Me.cmd.ExecuteNonQuery()
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            flag = False
            ProjectData.ClearProjectError()
            Return flag
        End Try
        Me.conn.Close()
        Return True
    End Function

    <Description("Lấy chuổi kết nối")> _
    Protected Function getConnectionStringChamcong() As String
        Dim params As New DParams
        Me.ser = params.getParameter("ServerChamcong").Item("ParamValue").ToString
        Me.db = params.getParameter("DatabaseChamcong").Item("ParamValue").ToString
        Me.uid = params.getParameter("UserIDChamcong").Item("ParamValue").ToString
        Me.pass = params.getParameter("PasswordChamcong").Item("ParamValue").ToString
        If ((StringType.StrCmp(Me.ser, "", False) = 0) Or (StringType.StrCmp(Me.db, "", False) = 0)) Then
            Throw New Exception(mError.getMSG(3))
        End If
        Me.strConn = String.Concat(New String() {"data source=", Me.ser, ";initial catalog=", Me.db, ";user id =", Me.uid, ";password=", Me.pass, ";"})
        Return Me.strConn
    End Function

    Protected Function getConnectString() As String
        If (StringType.StrCmp(Me.strConn.Trim, "", False) = 0) Then
            If ((StringType.StrCmp(Me.ser.Trim, "", False) = 0) Or (StringType.StrCmp(Me.db.Trim, "", False) = 0)) Then


                Me.ser = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Server"))
                Me.db = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Database"))
                Me.uid = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("UserID"))
                Me.pass = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Password"))

                If ((StringType.StrCmp(Me.ser, "", False) = 0) Or (StringType.StrCmp(Me.db, "", False) = 0)) Then
                    Throw New Exception(mError.getMSG(3))
                End If
            End If
            Me.strConn = String.Concat(New String() {"data source=", Me.ser, ";initial catalog=", Me.db, ";user id =", Me.uid, ";password=", Me.pass, ";"})
        End If
        Return Me.strConn
    End Function

    <Description("Thực thi một store procedure không đối số lấy dataset")> _
    Protected Function getDatasetProcedure(ByVal storeName As String) As DataSet
        Dim set2 As DataSet
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Me.cmd.CommandTimeout = 300
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataSet As New DataSet
        Try
            Me.da.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        Me.conn.Close()
        Return dataSet
    End Function

    <Description("Thực thi một store procedure lấy dataset, danh sách các đối số là một arraylist. Object là sqlParameter")> _
    Protected Function getDatasetProcedure(ByVal storeName As String, ByVal listPar As ArrayList) As DataSet
        Dim set2 As DataSet
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Me.cmd.CommandTimeout = 300
        Dim num2 As Integer = (listPar.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            Dim parameter As SqlParameter = DirectCast(listPar.Item(i), SqlParameter)
            Me.cmd.Parameters.Add(parameter)
            i += 1
        Loop
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataSet As New DataSet
        Try
            Me.da.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        Me.conn.Close()
        Return dataSet
    End Function

    <Description("Lấy dataset dữ liệu bằng lệnh SQL.")> _
    Protected Function getDatasetSQL(ByVal strSQL As String()) As DataSet
        Dim set2 As DataSet
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand
        Me.cmd.Connection = Me.conn
        Me.cmd.CommandType = CommandType.Text
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataSet As New DataSet
        Try
            Dim str As String
            For Each str In strSQL
                Dim strArray As String() = str.Split(New Char() {";"c})
                Me.cmd.CommandText = strArray(0).Trim
                Me.da.Fill(dataSet, strArray(1).Trim)
            Next
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        Me.conn.Close()
        Return dataSet
    End Function

    <Description("Lấy dataset dữ liệu bằng lệnh SQL.")> _
    Protected Function getDatasetSQL(ByVal strSQL As String) As DataSet
        Dim [set] As DataSet
        Dim set2 As DataSet
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Me.da = New SqlDataAdapter(Me.cmd)
        Try
            [set] = New DataSet
            Me.da.Fill([set])
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        Me.conn.Close()
        Return [set]
    End Function

    <Description("Lấy dataset = thực thi một lệnh SQL có sử dụng các tham số. Các lệnh SQL được viết riêng")> _
    Protected Function getDSwSQLpara(ByVal strSQL As String, ByVal ParamArray listParameter As SqlParameter()) As DataSet
        Dim set2 As DataSet
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Dim parameter As SqlParameter
        For Each parameter In listParameter
            Me.cmd.Parameters.Add(parameter)
        Next
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataSet As New DataSet
        Try
            Me.da.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            set2 = Nothing
            ProjectData.ClearProjectError()
            Return set2
        End Try
        Me.conn.Close()
        Return dataSet
    End Function

    <Description("Thực thi một store procedure không đối số, lấy table")> _
    Protected Function getTableProcedure(ByVal storeName As String) As DataTable
        Dim table As DataTable
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Me.cmd.CommandTimeout = 300
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataTable As New DataTable
        Try
            Me.da.Fill(dataTable)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        Me.conn.Close()
        Return dataTable
    End Function

    <Description("Thực thi một store procedure lấy table, danh sách các đối số là một arraylist. Object là sqlParameter.")> _
    Protected Function getTableProcedure(ByVal storeName As String, ByVal ParamArray listParameter As SqlParameter()) As DataTable
        Dim table As DataTable
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(storeName, Me.conn)
        Me.cmd.CommandType = CommandType.StoredProcedure
        Me.cmd.CommandTimeout = 300
        Dim parameter2 As SqlParameter
        For Each parameter2 In listParameter
            Me.cmd.Parameters.Add(parameter2)
        Next
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataTable As New DataTable
        Try
            Me.da.Fill(dataTable)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        Me.conn.Close()
        Return dataTable
    End Function

    <Description("Lấy datatable dữ liệu bằng SQL")> _
    Protected Function getTableSQL(ByVal strSQL As String) As DataTable
        Dim table As DataTable
        Dim table2 As DataTable
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Me.cmd.CommandTimeout = 500
        Me.da = New SqlDataAdapter(Me.cmd)
        Try
            table2 = New DataTable
            Me.da.Fill(table2)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        Me.conn.Close()
        Return table2
    End Function

    <Description("Lấy Table = thực thi một lệnh SQL có sử dụng các tham số. Các lệnh SQL được viết riêng")> _
    Protected Function getTBwSQLpara(ByVal strSQL As String, ByVal ParamArray listParameter As SqlParameter()) As DataTable
        Dim table As DataTable
        Try
            Me.connectDB()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Me.msgerr = exception.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        If (Me.conn.State = ConnectionState.Closed) Then
            Me.conn.Open()
        End If
        Me.cmd = New SqlCommand(strSQL, Me.conn)
        Me.cmd.CommandType = CommandType.Text
        Dim parameter As SqlParameter
        For Each parameter In listParameter
            Me.cmd.Parameters.Add(parameter)
        Next
        Me.da = New SqlDataAdapter(Me.cmd)
        Dim dataTable As New DataTable
        Try
            Me.da.Fill(dataTable)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Me.conn.Dispose()
            Me.msgerr = exception2.Message
            If (Not Me._errorEvent Is Nothing) Then
                Me._errorEvent.Invoke(exception2.Message)
            End If
            table = Nothing
            ProjectData.ClearProjectError()
            Return table
        End Try
        Me.conn.Close()
        Return dataTable
    End Function


    ' Properties
    <Description("Thiết lập chuổi kết nối theo cách của bạn")> _
    Public Property connectString() As String
        Get
            Return Me.strConn
        End Get
        Set(ByVal value As String)
            Me.strConn = value
        End Set
    End Property

    <Description("Thiết lập database sẽ sử dụng")> _
    Public Property Database() As String
        Get
            Return Me.db
        End Get
        Set(ByVal value As String)
            Me.db = value
        End Set
    End Property

    Public Property msgError() As String
        Get
            Return Me.msgerr
        End Get
        Set(ByVal Value As String)
            Me.msgerr = Value
        End Set
    End Property

    <Description("Password dùng để nối kết với Server")> _
    Public Property Password() As String
        Get
            Return Me.pass
        End Get
        Set(ByVal value As String)
            Me.pass = value
        End Set
    End Property

    <Description("Thiết lập tên Server mà bạn sẽ kết nối")> _
    Public Property Server() As String
        Get
            Return Me.ser
        End Get
        Set(ByVal value As String)
            Me.ser = value
        End Set
    End Property

    <Description("Tên dùng để kết nối đến Server")> _
    Public Property UserName() As String
        Get
            Return Me.uid
        End Get
        Set(ByVal value As String)
            Me.uid = value
        End Set
    End Property


    ' Fields
    Public cmd As SqlCommand
    Public conn As SqlConnection
    Public da As SqlDataAdapter
    Public db As String = ""
    Public msgerr As String = ""
    Public pass As String = ""
    Public ser As String = ""
    Public strConn As String = ""
    Public uid As String = ""
    'Public ChuoiThaoTac As String = ""
    ' Nested Types
    Public Delegate Sub _errorEventHandler(ByVal message As String)
End Class
