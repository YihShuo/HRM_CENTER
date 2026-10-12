Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

    Public Class ClsBReport
        ' Events
        Public Event _errorRaise As _errorRaiseEventHandler

        ' Methods
        Public Sub New()
            Me.d = New ClsDReport
    End Sub

    Public Function LoadDS(ByVal obj As objReport) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

   
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function InitReport(ByVal ID As String) As ReportDocument
        Dim document2 As New ReportDocument
        Dim path As String = (Application.StartupPath & Me.d.getPathReport(ID))
        If Not File.Exists(path) Then
            Throw New Exception("Không tìm thấy file report")
        End If
        document2.Load(path)
        Dim varEncrypt As String = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Server"))
        Dim str As String = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Database"))
        Dim str5 As String = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("UserID"))
        Dim str3 As String = clsTools.Decrypt1(ConfigurationSettings.AppSettings.Item("Password"))
        Dim table As Table
        For Each table In document2.Database.Tables
            Dim info As TableLogOnInfo = table.LogOnInfo
            Dim info2 As ConnectionInfo = info.ConnectionInfo
            info2.ServerName = varEncrypt
            info2.UserID = str5
            info2.Password = str3
            info2.DatabaseName = str
            info2 = Nothing
            table.ApplyLogOnInfo(info)
        Next
        Return document2
    End Function

    Public Function InitReport2(ByVal ID As String, ByVal sortDirection As String, ByVal sFieldName As String, ByVal sTableName As String) As ReportDocument
        Dim document2 As New ReportDocument
        Dim path As String = (Application.StartupPath & Me.d.getPathReport(ID))
        If Not File.Exists(path) Then
            Throw New Exception("Không tìm thấy file report")
        End If
        document2.Load(path)
        Dim varEncrypt As String = ConfigurationSettings.AppSettings.Item("Server")
        Dim str As String = ConfigurationSettings.AppSettings.Item("Database")
        Dim str5 As String = ConfigurationSettings.AppSettings.Item("UserID")
        Dim str3 As String = ConfigurationSettings.AppSettings.Item("Password")
        varEncrypt = clsTools.Decrypt1(varEncrypt)
        str = clsTools.Decrypt1(str)
        str5 = clsTools.Decrypt1(str5)
        str3 = clsTools.Decrypt1(str3)
        Dim table As Table
        For Each table In document2.Database.Tables
            Dim info As TableLogOnInfo = table.LogOnInfo
            Dim info2 As ConnectionInfo = info.ConnectionInfo
            info2.ServerName = varEncrypt
            info2.UserID = str5
            info2.Password = str3
            info2.DatabaseName = str
            info2 = Nothing
            table.ApplyLogOnInfo(info)
        Next
        Dim num As Integer = document2.DataDefinition.SortFields.Count
        document2.DataDefinition.SortFields.Item((num - 1)).Field = document2.Database.Tables.Item(sTableName).Fields.Item(sFieldName)
        If (StringType.StrCmp(sortDirection, "DESC", False) = 0) Then
            document2.DataDefinition.SortFields.Item((num - 1)).SortDirection = 0
            Return document2
        End If
        document2.DataDefinition.SortFields.Item((num - 1)).SortDirection = 1
        Return document2
    End Function

    Public Function SetParameter(ByVal rpt As ReportDocument, ByVal ParamArray lstPARA As Object()) As ReportDocument
        If (Not lstPARA Is Nothing) Then
            Dim num As Integer = 0
            Dim objArray As Object() = lstPARA
            Dim i As Integer
            For i = 0 To objArray.Length - 1
                Dim objectValue As Object = RuntimeHelpers.GetObjectValue(objArray(i))
                rpt.SetParameterValue(num, RuntimeHelpers.GetObjectValue(objectValue))
                num += 1
            Next i
        End If
        Return rpt
    End Function


    ' Fields
    Friend WithEvents d As ClsDReport

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    End Class


