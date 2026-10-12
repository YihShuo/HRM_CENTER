Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class clsBQTSaiQuiDinh
    '' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDQTSaiQuiDinh
    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objQTSaiQuiDinh) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function LoadThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.LoadThuTuc(m_sSP_Name, m_listpar)
    End Function
    Public Function ThongKeQuetTheSaiQuyDinh_TungNgay_Insert(ByVal obj As objQTSaiQuiDinh, ByVal bChonTuan As Boolean) As Boolean
        Return Me.d.ThongKeQuetTheSaiQuyDinh_TungNgay_Insert(obj, bChonTuan)
    End Function
    Public Function ThongKeQuetTheSaiQuyDinh_TungNgay_Delete(ByVal obj As objQTSaiQuiDinh, ByVal bChonTuan As Boolean) As Boolean
        Return Me.d.ThongKeQuetTheSaiQuyDinh_TungNgay_Delete(obj, bChonTuan)
    End Function
   
    '' Fields
    Friend WithEvents d As clsDQTSaiQuiDinh

    '' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class

