Imports Infragistics.Win.Misc
Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports TongHop.frmDangNhap


Public Class FrmConnectDB
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.KeyUp, New KeyEventHandler(AddressOf Me.FrmConnectDB_KeyUp)
        Me._appS = (Application.StartupPath & "\")
        Me.InitializeComponent()
    End Sub

    Public Sub bntConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bntConnect.Click
        If MAIN.TestConnectionDB(Me.txtServer.Text, Me.txtUser.Text, Me.txtPass.Text, Me.txtDb.Text) Then
            Me.UpdateConfigSystem()
            MessageBox.Show("Vui Lòng Khởi Động Lại Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'Application.Exit()
            'TongHop.frmDangNhap.AppExit = True
            'Me.Close()
        Else
            Interaction.MsgBox("Không kế nối được cơ sở dữ liệu", MsgBoxStyle.Critical, Nothing)
        End If
    End Sub

    Public Sub bntExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bntExit.Click
        'Application.Exit()
        Me.Close()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Sub FrmConnectDB_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        If (e.KeyCode = Keys.Return) Then
            Me.bntConnect_Click(RuntimeHelpers.GetObjectValue(sender), e)
        End If
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtDb = New System.Windows.Forms.TextBox()
        Me.bntConnect = New Infragistics.Win.Misc.UltraButton()
        Me.bntExit = New Infragistics.Win.Misc.UltraButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên máy chủ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "User CSDL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mật khẩu"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tên CSDL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(118, 8)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(188, 22)
        Me.txtServer.TabIndex = 4
        Me.txtServer.Text = "192.168.71.5"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(118, 32)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(188, 22)
        Me.txtUser.TabIndex = 5
        Me.txtUser.Text = "sa"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(118, 56)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(188, 22)
        Me.txtPass.TabIndex = 6
        Me.txtPass.Text = "123456"
        '
        'txtDb
        '
        Me.txtDb.Location = New System.Drawing.Point(118, 80)
        Me.txtDb.Name = "txtDb"
        Me.txtDb.Size = New System.Drawing.Size(188, 22)
        Me.txtDb.TabIndex = 7
        Me.txtDb.Text = "P0104-TYTHAC"
        '
        'bntConnect
        '
        Me.bntConnect.Location = New System.Drawing.Point(125, 9)
        Me.bntConnect.Name = "bntConnect"
        Me.bntConnect.Size = New System.Drawing.Size(86, 26)
        Me.bntConnect.TabIndex = 8
        Me.bntConnect.Text = "Kết nối"
        '
        'bntExit
        '
        Me.bntExit.Location = New System.Drawing.Point(217, 10)
        Me.bntExit.Name = "bntExit"
        Me.bntExit.Size = New System.Drawing.Size(86, 26)
        Me.bntExit.TabIndex = 9
        Me.bntExit.Text = "Thoát"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 108)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bntConnect)
        Me.GroupBox2.Controls.Add(Me.bntExit)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 39)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'FrmConnectDB
        '
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(315, 150)
        Me.Controls.Add(Me.txtDb)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnectDB"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cấu hình thông số Máy chủ"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    <DllImport("shell32.dll", EntryPoint:="ShellExecuteA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function ShellExecute(ByVal hWnd As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpOperation As String, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpFile As String, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpParameters As String, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    End Function

    Public Sub UpdateConfigSystem()

        Dim newValue As String = clsTools.Encrypt1(Strings.Trim(Me.txtServer.Text))

        Dim str3 As String = clsTools.Encrypt1(Strings.Trim(Me.txtServer.Text))

        Dim str6 As String = clsTools.Encrypt1(Strings.Trim(Me.txtDb.Text))

        Dim str7 As String = clsTools.Encrypt1(Strings.Trim(Me.txtUser.Text))

        Dim str As String = clsTools.Encrypt1(Strings.Trim(Me.txtPass.Text))

        Dim reader As New StreamReader((Me._appS & "\Temp\HRM Solution.exe.config"))

        Dim str5 As String = ""

        str5 = reader.ReadToEnd

        reader.Close()

        If (str5.Length = 0) Then

            str5 = "<?xml version='1.0' encoding='utf-8' ?>" & ChrW(13) & ChrW(10)

            str5 = (((((((((str5 & "<configuration>" & ChrW(13) & ChrW(10) & ChrW(9) & "<appSettings>" & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='Server' value = '" & newValue & "'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='Database' value = '" & str6 & "'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='UserID' value = '" & str7 & "'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='Password' value = " & str & "/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='NVBH' value = '10'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='CTBH' value = '20'/> " & ChrW(13) & ChrW(10) & ChrW(9) & ChrW(9) & "<add key='SoCa' value = '26'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & ChrW(9) & "<add key='QDNgay' value = '2'/> " & ChrW(13) & ChrW(10) & ChrW(9) & ChrW(9) & "<add key='BeginCong' value = '24'/> " & ChrW(13) & ChrW(10)) & ChrW(9) & "</appSettings>" & ChrW(13) & ChrW(10) & "</configuration>")

        Else

            str5 = str5.Replace("[Server]", newValue).Replace("[Database]", str6).Replace("[UserID]", str7).Replace("[Password]", str)

        End If

        Dim writer As New StreamWriter((Me._appS & "\HRM Solution.exe.config"), False, Encoding.UTF8)

        writer.Write(str5)

        writer.Flush()

        writer.Close()

    End Sub

    Friend WithEvents appS As String
    Friend WithEvents bntConnect As UltraButton
    Friend WithEvents bntExit As UltraButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDb As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents components As IContainer

    Private Sub FrmConnectDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

