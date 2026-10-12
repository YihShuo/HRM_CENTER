Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class clsBBaoCaoGioCongNgay
    Public Event _errorRaise As _errorRaiseEventHandler
    Public Sub New()
        Me.d = New ClsDBaoCaoGioCongNgay
    End Sub
    Public Function LoadDS(ByVal obj As ObjBaoCaoGioCongNgay, ByVal khu As String) As DataTable
        Return Me.d.LoadDS(obj, khu)
    End Function

    Public Function DeleteInfo(ByVal obj As ObjBaoCaoGioCongNgay) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As ObjBaoCaoGioCongNgay) As Boolean
        Return Me.d.InsertInfo(obj)
    End Function
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function
    Friend WithEvents d As ClsDBaoCaoGioCongNgay
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
