Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text

Public Class ClsSecurity
    Inherits DALSQL
    ' Methods
    Public Sub CreateUser(ByVal KeyName As String, ByVal Values As String)
        Dim num As Integer
        Dim lpSubKey As String = "SOFTWARE\VsoftHRM"
        Dim num2 As Integer = ClsSecurity.RegCreateKey(-2147483646, (lpSubKey), (num))
        Dim lpValue As String = Values
        num2 = ClsSecurity.RegSetValueExString(num, (KeyName), 0, 1, (lpValue), Strings.Len(lpValue))
        num2 = ClsSecurity.RegCloseKey(num)
    End Sub

    Public Function Encrypt(ByVal cleanString As String) As String
        Dim bytes As Byte() = New UnicodeEncoding().GetBytes(cleanString)
        Return BitConverter.ToString(DirectCast(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(bytes))
    End Function

    Public Function ExecuteSQL(ByVal sql As String) As Boolean
        Return Me.execSQL(sql)
    End Function

    Public Function GetlastUsername(ByVal KeyName As String) As String
        Dim num As Integer
        Dim lpSubKey As String = "SOFTWARE\VsoftHRM"
        If (ClsSecurity.RegOpenKeyEx(-2147483646, (lpSubKey), 0, 1, (num)) <> 0) Then
            Return ""
        End If
        Dim lpData As New String(" "c, &HFF)
        Dim lpType As Integer = 0
        Dim num3 As Integer = ClsSecurity.RegQueryValueEx(num, (KeyName), 0, (lpType), (lpData), (Strings.Len(lpData)))
        ClsSecurity.RegCloseKey(num)
        If (num3 <> 0) Then
            Return ""
        End If
        Return Strings.Trim(lpData)
    End Function


    Public Function OpenData(ByVal sql As String) As DataSet
        Return Me.getDatasetSQL(sql)
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegCloseKey(ByVal hKey As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegCreateKeyA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegCreateKey(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpSubKey As String, ByRef phkResult As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegDeleteKeyA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegDeleteKey(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpSubKey As String) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegDeleteValueA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegDeleteValue(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpValueName As String) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegOpenKeyExA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegOpenKeyEx(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegQueryValueExA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegQueryValueEx(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpData As String, ByRef lpcbData As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegSetValueExA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegSetValueExLong(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef lpValue As Integer, ByVal cbData As Integer) As Integer
    End Function

    <DllImport("advapi32.dll", EntryPoint:="RegSetValueExA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function RegSetValueExString(ByVal hKey As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpValue As String, ByVal cbData As Integer) As Integer
    End Function


    ' Fields
    Public Const ERROR_SUCCESS As Short = 0
    Public Const HKEY_CURRENT_USER As Integer = -2147483647
    Public Const HKEY_LOCAL_MACHINE As Integer = -2147483646
    Public Const KEY_QUERY_VALUE As Short = 1
    Public Const REG_DWORD As Short = 4
    Public Const REG_SZ As Short = 1
End Class


