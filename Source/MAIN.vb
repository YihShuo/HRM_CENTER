Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Windows.Forms

<StandardModule()> _
    Public NotInheritable Class MAIN
    ' Methods

    'Public Shared Function bNoiKet() As Boolean
    '    Dim flag As Boolean
    '    Dim connection As New OleDbConnection
    '    connection.ConnectionString = String.Concat(New String() {"Provider=SQLOLEDB.1;driver={SQL Server};server=", SERVER, ";uid=", USERNAME, ";pwd=", PASSWORD, ";database=", DATABASE, ""})
    '    Try
    '        connection.Open()
    '        connection.Close()
    '        flag = True
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        MessageBox.Show("Không kết nối được đến cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function

    'Public Shared Function bSQLNoiKet() As Boolean
    '    Dim flag As Boolean
    '    Dim connection As New SqlConnection
    '    connection.ConnectionString = ConnectString()

    '    Try
    '        connection.Open()
    '        flag = True
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        MessageBox.Show(("N" & ChrW(7889) & "i k" & ChrW(7871) & "t kh" & ChrW(244) & "ng th" & ChrW(224) & "nh c" & ChrW(244) & "ng " & exception.Message))
    '        Application.Exit()
    '        flag = False
    '        ProjectData.ClearProjectError()
    '    End Try
    '    Return flag
    'End Function

    Public Shared Function ConnectString() As String
        'Return String.Concat(New String() {"Provider=SQLOLEDB.1;driver={SQL Server};server=", SERVER, ";uid=", USERNAME, ";pwd=", PASSWORD, ";database=", DATABASE, ""})
    End Function

    Public Shared Function IsLogin() As Boolean
        Return (StringType.StrCmp(UserLogin, "", False) <> 0)
    End Function

    Public Shared Function loadServerCurr() As Boolean

        Dim varEncrypt As String = ConfigurationSettings.AppSettings.Item("Server")
        Dim str As String = ConfigurationSettings.AppSettings.Item("Database")
        Dim str5 As String = ConfigurationSettings.AppSettings.Item("UserID")
        Dim str2 As String = ConfigurationSettings.AppSettings.Item("Password")
        varEncrypt = clsTools.Decrypt1(varEncrypt)
        str = clsTools.Decrypt1(str)
        str5 = clsTools.Decrypt1(str5)
        str2 = clsTools.Decrypt1(str2)
        If ((StringType.StrCmp(varEncrypt, "", False) = 0) Or (StringType.StrCmp(str, "", False) = 0)) Then
            Return False
        End If
        Return TestConnectionDB(varEncrypt, str5, str2, str)
        'Return TestConnectionDB(SERVER, USERNAME, PASSWORD, DATABASE)
    End Function

    <STAThread()> _
    Public Shared Sub Main()
        If Not loadServerCurr() Then
            Dim tdb As New FrmConnectDB
            tdb.ShowDialog()
            tdb = Nothing
            Interaction.MsgBox("Vui lòng khởi động lại chương trình", MsgBoxStyle.Information, "Thông báo")
            Application.Exit()
        Else
            Application.DoEvents()
            Application.Run(New frmMainMain)
        End If
    End Sub

    Public Shared Sub NEWConnect(ByVal sv As String, ByVal db As String, ByVal un As String, ByVal pw As String)
        'SERVER = sv
        'DATABASE = db
        'USERNAME = un
        'PASSWORD = pw
    End Sub

    Public Shared Function TestConnectionDB(ByVal Srv As String, ByVal User As String, ByVal Pass As String, ByVal DB As String) As Boolean
        Dim flag As Boolean
        Dim connection As New OleDbConnection(String.Concat(New String() {"Provider=SQLOLEDB.1;driver={SQL Server};server=", Strings.Trim(Srv), ";uid=", Strings.Trim(User), ";pwd=", Strings.Trim(Pass), ";database=", Strings.Trim(DB), ""}))
        Try
            connection.Open()
            connection.Close()
            flag = True
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function


    ' Fields
    Public Shared closeComplete As Boolean = True
    Public Shared frmStatus As frmStatus = New frmStatus
    Public Shared isAdmin As Boolean = False
    Public Shared LS_demo As Boolean = False
    Public Shared m_bChaToCon As Boolean = False
    Public Shared m_bKiemTraLuu As Boolean = False
    Public Shared m_bKiemTraNew As Boolean = False
    Public Shared m_bKiemTraThoat As Boolean = False
    Public Shared m_bKiemTraXoa As Boolean = False
    Public Shared m_dCountFile As Double = 9000000000
    Public Shared m_iCountRecord As Integer = 10
    Public Shared m_iLG As Short = 0
    Public Shared m_sFormat As String = "dd/MM/yyyy"
    Public Shared m_sFormatDate As String = "dd/MM/yyyy HH:mm:ss"
    Public Shared m_sHoTen As String = "IT Solution Software"
    Public Shared m_sServer As String = "."
    Public Shared m_sTextMenu As String = "hh"
    Public Shared m_sThuMuc As String = "."
    Public Shared m_StrApplication As String = "TYXUAN_NS"
    Public Shared m_strSerial As String
    Public Shared PassLogin As String = ""
    Public Shared Reg As Boolean = False
    Public Const SQL_CONNECTION_STRING As String = ""
    Public Shared UserID As String = ""
    Public Shared UserLogin As String = "01"
    Public Shared viewComplete As Boolean = True
    Public Shared USER_KT As Boolean = False
    Public Shared Lang As String = "vi-VN"
    Public Shared userclient As String
End Class



