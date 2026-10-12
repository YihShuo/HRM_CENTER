
Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBThongKeGioTangCaXuongNam
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDThongKeGioTangCaXuongNam
    End Sub
    Public Function LoadDS(ByVal obj As objThongKeGioTangCaXuongNam) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTucTinhToan(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As Boolean
        Return Me.d.GoiThuTucTinhToan(m_sSP_Name, m_listpar)
    End Function
    Public Function GoiThuTucThongKe(ByVal m_sSP_Name As String, ByVal iThangbd As Integer, ByVal iThangkt As Integer, ByVal iNam As Integer) As DataTable
        Return Me.d.GoiThuTucThongKe(m_sSP_Name, iThangbd, iThangkt, iNam)
    End Function
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    ' Fields
    Friend WithEvents d As clsDThongKeGioTangCaXuongNam

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
