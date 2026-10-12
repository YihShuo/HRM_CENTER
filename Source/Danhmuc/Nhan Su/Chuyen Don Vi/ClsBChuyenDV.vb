Imports System
Imports System.Data
Imports System.Runtime.CompilerServices

Public Class ClsBChuyenDV

    Public Event _errorRaise As _errorRaiseEventHandler
    ' Methods
    Public Sub New()
        Me.d = New ClsDChuyenDV

    End Sub

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function LoadDS(ByVal obj As objChuyenDV) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    'Public Function InsertInfo(ByVal obj As objChuyenDV) As Boolean
    '    Dim table As DataTable = Me.LoadDS(obj)
    '    If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
    '        Return Me.d.InsertInfo(obj)
    '    End If
    '    Return False
    'End Function
    Public Function InsertInfo(ByVal obj As objChuyenDV, ByVal sNguoiTao As String, ByVal sNgayTao As String, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.InsertInfo(obj, sNguoiTao, sNgayTao, sNguoiCapNhat, sNgayCapNhat)
        End If
        Return False
    End Function
    Public Function DeleteInfo(ByVal obj As objChuyenDV) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function
    'Public Function UpdateInfo(ByVal obj As objChuyenDV) As Boolean
    '    Return Me.d.UpdateInfo(obj)
    '    If (Not Me._errorRaiseEvent Is Nothing) Then
    '        Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
    '    End If
    '    Return False
    'End Function
    Public Function UpdateInfo(ByVal obj As objChuyenDV, ByVal sNguoiCapNhat As String, ByVal sNgayCapNhat As String) As Boolean
        Return Me.d.UpdateInfo(obj, sNguoiCapNhat, sNgayCapNhat)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    ''Public Function CapNhat(ByVal obj As objChuyenDV, ByVal ThemSua As Integer) As Boolean
    ''    If (ThemSua = 0) Then
    ''        Return Me.InsertInfo(obj)
    ''    End If
    ''    obj.ChonBang = 2
    ''    Return Me.UpdateInfo(obj)
    ''End Function


    ' Fields
    Friend WithEvents d As ClsDChuyenDV

    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
