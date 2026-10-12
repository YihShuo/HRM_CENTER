Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsBChuyenDVExcel
    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New ClsDChuyenDVExcel
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function

    Public Function LoadDS(ByVal obj As objChuyenDVExcel) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objChuyenDVExcel, ByVal sNguoiCapNhat As String) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj, sNguoiCapNhat)
        End If
        Return False
    End Function

    Public Function DeleteInfo(ByVal obj As objChuyenDVExcel) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As objChuyenDVExcel, ByVal sNguoiCapNhat As String) As Boolean
        Return Me.d.UpdateInfo(obj, sNguoiCapNhat)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function

    Friend WithEvents d As ClsDChuyenDVExcel

    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
