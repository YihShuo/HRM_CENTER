Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class clsBQTSaiQuiDinhBangTong
    '' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDQTSaiQuiDinhBangTong
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Insert(ByVal obj As objQTSaiQuiDinhBangTong, ByVal bChonTuan As Boolean) As Boolean
        Return Me.d.ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Insert(obj, bChonTuan)
    End Function
    Public Function ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Delete(ByVal obj As objQTSaiQuiDinhBangTong, ByVal bChonTuan As Boolean) As Boolean
        Return Me.d.ThongKeQuetTheSaiQuyDinhBangTong_TungNgay_Delete(obj, bChonTuan)
    End Function
    Public Function LoadDS(ByVal obj As objQTSaiQuiDinhBangTong) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    '' Fields
    Friend WithEvents d As clsDQTSaiQuiDinhBangTong

    '' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class

