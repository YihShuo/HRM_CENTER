Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsBKhamSK
    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New ClsDKhamSK
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function

    Public Function LoadDS(ByVal obj As objKhamSK) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objKhamSK, ByVal sNguoitao As String) As Boolean
        Return Me.d.InsertInfo(obj, sNguoitao)
    End Function

    Public Function DeleteInfo(ByVal obj As objKhamSK) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function UpdateInfo(ByVal obj As objKhamSK, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean
        Return Me.d.UpdateInfo(obj, sNguoiCapNhat, sNgayCapNhat)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function

    Friend WithEvents d As ClsDKhamSK

    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
