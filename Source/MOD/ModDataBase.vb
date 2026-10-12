Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

<StandardModule()> _
    Friend NotInheritable Class ModDataBase
    ' Methods
    Public Shared Function ExecuteUpdateSQL(ByVal strSQL As String) As Boolean
        Dim flag As Boolean
        Dim connection As New OleDbConnection(MAIN.ConnectString)
        Dim command As New OleDbCommand(strSQL, connection)
        command.CommandType = CommandType.Text
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Try
            command.ExecuteNonQuery()
            flag = True
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Shared Sub ExportXML(ByVal FileName As String, ByVal DBName As String, ByVal TbName As String)
        Dim [set] As New DataSet
        [set] = ModDataBase.OpenDataSet(("Select * from " & Strings.Trim(TbName)))
        Try
            If ([set].Tables.Item(0).Rows.Count >= 1) Then
                Dim num2 As Integer = ([set].Tables.Item(0).Rows.Count - 1)
                Dim num As Integer = ([set].Tables.Item(0).Columns.Count - 1)
                Dim writer As New StreamWriter(FileName)
                writer.WriteLine("<?xml version=""1.0"" encoding=""ISO-8859-1"" ?>")
                writer.WriteLine(("<" & DBName & ">"))
                Dim num6 As Integer = num2
                Dim i As Integer = 0
                Do While (i <= num6)
                    writer.WriteLine(("  <" & TbName & ">"))
                    Dim num5 As Integer = num
                    Dim j As Integer = 0
                    Do While (j <= num5)
                        Try
                            writer.WriteLine(("      " & StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("<" & [set].Tables.Item(0).Columns.Item(j).ColumnName & ">"), [set].Tables.Item(0).Rows.Item(i).Item(j)), "</"), [set].Tables.Item(0).Columns.Item(j).ColumnName), ">"))))
                        Catch exception3 As Exception
                            ProjectData.SetProjectError(exception3)
                            Dim exception2 As Exception = exception3
                            writer.WriteLine("")
                            ProjectData.ClearProjectError()
                        End Try
                        j += 1
                    Loop
                    writer.WriteLine(("  </" & TbName & ">"))
                    i += 1
                Loop
                writer.WriteLine(("</" & DBName & ">"))
                writer.Close()
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Shared Sub ExportXML(ByVal FileName As String, ByVal DBName As String, ByVal TbName As String, ByVal TblData As DataTable)
        Dim num2 As Integer = (TblData.Rows.Count - 1)
        Dim num As Integer = (TblData.Columns.Count - 1)
        Dim writer As New StreamWriter(FileName)
        writer.WriteLine("<?xml version=""1.0"" encoding=""ISO-8859-1"" ?>")
        writer.WriteLine(("<" & DBName & ">"))
        Dim num6 As Integer = num2
        Dim i As Integer = 0
        Do While (i <= num6)
            writer.WriteLine(("  <" & TbName & ">"))
            Dim num5 As Integer = num
            Dim j As Integer = 0
            Do While (j <= num5)
                Try
                    writer.WriteLine(("      " & StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(ObjectType.StrCatObj(("<" & TblData.Columns.Item(j).ColumnName & ">"), TblData.Rows.Item(i).Item(j)), "</"), TblData.Columns.Item(j).ColumnName), ">"))))
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    writer.WriteLine("")
                    ProjectData.ClearProjectError()
                End Try
                j += 1
            Loop
            writer.WriteLine(("  </" & TbName & ">"))
            i += 1
        Loop
        writer.WriteLine(("</" & DBName & ">"))
        writer.Close()
    End Sub

    Public Shared Function GetListSheetName(ByVal fileName As String) As String()
        Dim strArray2 As String() = Nothing
        Dim connection As OleDbConnection = ModDataBase.ReturnConnection(fileName)
        Try
            Dim enumerator As IEnumerator
            connection.Open()
            Dim oleDbSchemaTable As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing})
            If (oleDbSchemaTable.Rows.Count <= 0) Then
                Return strArray2
            End If
            strArray2 = New String((oleDbSchemaTable.Rows.Count + 1) - 1) {}
            Dim index As Integer = 0
            Try
                enumerator = oleDbSchemaTable.Rows.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                    strArray2(index) = current.Item("TABLE_NAME").ToString
                    Math.Min(Interlocked.Increment((index)), (index - 1))
                Loop
                Return strArray2
            Finally
                If TypeOf enumerator Is IDisposable Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Trace.WriteLine(exception.StackTrace)
            ProjectData.ClearProjectError()
        Finally
            If ((Not connection Is Nothing) AndAlso (connection.State = ConnectionState.Open)) Then
                connection.Close()
                connection.Dispose()
            End If
        End Try
        Return strArray2
    End Function

    Public Shared Function ImportDataFromExcel(ByVal FileName As String) As DataTable
        Dim table2 As DataTable
        Dim table As New DataTable
        Try
            Dim str As String = ModDataBase.LoadSchemaFromFile(FileName)
            Dim strconn As String = ("select * from [" & str & "A1:Z65536]")
            table2 = ModDataBase.LoadSpecifiedSheet(FileName, strconn)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            table2 = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return table2
    End Function

    Public Shared Function ImportDataFromExcel(ByVal FileName As String, ByVal SheetName As String) As DataTable
        Dim table2 As DataTable
        Dim table As New DataTable
        Try
            Dim strconn As String = ("select * from [" & SheetName & "A1:Z65536]")
            table2 = ModDataBase.LoadSpecifiedSheet(FileName, strconn)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            table2 = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return table2
    End Function

    Public Shared Function LoadSchemaFromFile(ByVal fileName As String) As String
        Dim strArray As String() = Nothing
        Dim connection As OleDbConnection = ModDataBase.ReturnConnection(fileName)
        Try
            connection.Open()
            Dim oleDbSchemaTable As DataTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing})
            If (oleDbSchemaTable.Rows.Count > 0) Then
                Dim enumerator As IEnumerator
                strArray = New String((oleDbSchemaTable.Rows.Count + 1) - 1) {}
                Dim index As Integer = 0
                Try
                    enumerator = oleDbSchemaTable.Rows.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                        strArray(index) = current.Item("TABLE_NAME").ToString
                        Math.Min(Interlocked.Increment((index)), (index - 1))
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        DirectCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Trace.WriteLine(exception.StackTrace)
            ProjectData.ClearProjectError()
        Finally
            If ((Not connection Is Nothing) AndAlso (connection.State = ConnectionState.Open)) Then
                connection.Close()
                connection.Dispose()
            End If
        End Try
        Return strArray(0)
    End Function

    Public Shared Function LoadSpecifiedSheet(ByVal fileName As String, ByVal strconn As String) As DataTable
        Dim selectConnection As OleDbConnection = ModDataBase.ReturnConnection(fileName)
        Dim dataTable As DataTable = Nothing
        Try
            selectConnection.Open()
            Dim adapter As New OleDbDataAdapter(strconn, selectConnection)
            dataTable = New DataTable
            adapter.Fill(dataTable)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            Trace.WriteLine(exception.StackTrace)
            ProjectData.ClearProjectError()
        Finally
            If ((Not selectConnection Is Nothing) AndAlso (selectConnection.State = ConnectionState.Open)) Then
                selectConnection.Close()
                selectConnection.Dispose()
            End If
        End Try
        Return dataTable
    End Function

    Public Shared Function OpenDataApper(ByVal strSQL As String) As SqlDataAdapter
        Dim adapter As SqlDataAdapter
        Dim connection As New SqlConnection(MAIN.ConnectString)
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Try
            Dim command As New SqlCommand(strSQL, connection)
            command.CommandType = CommandType.Text
            adapter = New SqlDataAdapter
            adapter.SelectCommand = command
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        Dim adapter2 As SqlDataAdapter = adapter
        connection.Close()
        connection.Dispose()
        Return adapter2
    End Function

    Public Shared Function OpenDataReader(ByVal strSQL As String) As OleDbDataReader
        Dim reader As OleDbDataReader
        Dim connection As New OleDbConnection(MAIN.ConnectString)
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Try
            reader = New OleDbCommand(strSQL, connection).ExecuteReader(CommandBehavior.SequentialAccess)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        Dim reader2 As OleDbDataReader = reader
        connection.Close()
        connection.Dispose()
        Return reader2
    End Function

    Public Shared Function OpenDataSet(ByVal strSQL As String) As DataSet
        Dim selectConnection As New OleDbConnection(MAIN.ConnectString)
        Try
            selectConnection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Dim adapter As New OleDbDataAdapter(strSQL, selectConnection)
        adapter.SelectCommand.CommandType = CommandType.Text
        Dim dataSet As New DataSet
        Try
            adapter.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        selectConnection.Close()
        Dim set2 As DataSet = dataSet
        selectConnection.Dispose()
        Return set2
    End Function

    Public Shared Function OpenDataSet(ByVal strSQL As String, ByVal nameTable As String) As DataTable
        Dim selectConnection As New OleDbConnection(MAIN.ConnectString)
        Try
            selectConnection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Dim adapter As New OleDbDataAdapter(strSQL, selectConnection)
        adapter.SelectCommand.CommandType = CommandType.Text
        Dim dataTable As New DataTable(nameTable)
        Try
            adapter.Fill(dataTable)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        selectConnection.Close()
        selectConnection.Dispose()
        Return dataTable
    End Function

    Public Shared Function OpendatasetProc(ByVal Proc_Name As String) As DataSet
        Dim set2 As DataSet
        Dim connection As New OleDbConnection(MAIN.ConnectString)
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            ProjectData.ClearProjectError()
        End Try
        Dim selectCommand As New OleDbCommand(Proc_Name, connection)
        selectCommand.CommandType = CommandType.StoredProcedure
        Dim adapter As New OleDbDataAdapter(selectCommand)
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dataSet As New DataSet
        Try
            adapter.Fill(dataSet)
            connection.Close()
            connection.Dispose()
            set2 = dataSet
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, Nothing)
            set2 = Nothing
            ProjectData.ClearProjectError()
        End Try
        Return set2
    End Function

    Public Shared Function PExecuteUpdateSQL(ByVal strSQL As String) As Boolean
        Dim flag As Boolean
        Dim connection As New OleDbConnection(MAIN.ConnectString)
        Dim command As New OleDbCommand(strSQL, connection)
        command.CommandType = CommandType.StoredProcedure
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Try
            command.ExecuteNonQuery()
            flag = True
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Shared Function POpenDataApper(ByVal strSQL As String) As SqlDataAdapter
        Dim adapter As SqlDataAdapter
        Dim connection As New SqlConnection(MAIN.ConnectString)
        Try
            connection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Try
            Dim command As New SqlCommand(strSQL, connection)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter
            adapter.SelectCommand = command
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        Dim adapter2 As SqlDataAdapter = adapter
        connection.Close()
        connection.Dispose()
        Return adapter2
    End Function

    Public Shared Function POpenDataSet(ByVal strSQL As String) As DataSet
        Dim selectConnection As New OleDbConnection(MAIN.ConnectString)
        Try
            selectConnection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Dim adapter As New OleDbDataAdapter(strSQL, selectConnection)
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dataSet As New DataSet
        Try
            adapter.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        selectConnection.Close()
        selectConnection.Dispose()
        Return dataSet
    End Function

    Public Shared Function ReturnConnection(ByVal fileName As String) As OleDbConnection
        Return New OleDbConnection(("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileName & "; Jet OLEDB:Engine Type=5;" & "Extended Properties=Excel 8.0;"))
    End Function

    Public Shared Function UpOpenDataSet(ByVal strSQL As String) As DataSet
        Dim selectConnection As New OleDbConnection(MAIN.ConnectString)
        Try
            selectConnection.Open()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
            MessageBox.Show("Kh" & ChrW(244) & "ng k" & ChrW(7871) & "t n" & ChrW(244) & "i " & ChrW(273) & ChrW(432) & ChrW(7907) & "c")
            Application.Exit()
            ProjectData.ClearProjectError()
        End Try
        Dim adapter As New OleDbDataAdapter(strSQL, selectConnection)
        adapter.SelectCommand.CommandType = CommandType.Text
        Dim builder As New OleDbCommandBuilder(adapter)
        Dim dataSet As New DataSet
        Try
            adapter.Fill(dataSet)
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            MessageBox.Show(exception2.Message)
            ProjectData.ClearProjectError()
        End Try
        selectConnection.Close()
        selectConnection.Dispose()
        Return dataSet
    End Function

End Class

