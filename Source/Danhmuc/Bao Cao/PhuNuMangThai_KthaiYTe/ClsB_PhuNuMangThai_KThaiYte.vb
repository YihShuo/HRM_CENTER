Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class ClsB_PhuNuMangThai_KThaiYte
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New ClsD_PhuNuMangThai_KThaiYte
    End Sub
    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub
    Public Function InsertInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Dim table As DataTable = Me.LoadDS(obj)
        Return Me.d.InsertInfo(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Đã tồn tại mã nhân viên, Không thêm được.")
        End If
        Return False
    End Function
    'Public Function InsertThaiThangThu7(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
    '    ' Dim table As DataTable = Me.LoadDS(obj)
    '    Return Me.d.InsertThaiThangThu7(obj)
    '    If (Not Me._errorRaiseEvent Is Nothing) Then
    '        Me._errorRaiseEvent.Invoke("Số thẻ này đã được chuyển về 15h30, Không thêm được.")
    '    End If
    '    Return False
    'End Function
    Public Function LoadDS(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As DataTable
        Return Me.d.LoadDS(obj)
    End Function
    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
    End Function

    Public Function UpdateInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        obj.ChonBang = 85
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            'Return True
            Return False
        Else
            obj.ChonBang = 7
            Return Me.d.UpdateInfo(obj)

        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    Public Function CapNhatNgaydusinh(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        obj.ChonBang = 85
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            obj.ChonBang = 6
            Return Me.d.UpdateInfo(obj)
        Else
            ''======== đã có trong IT_THAITHANGTHU 7 =======
            Return False
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    'Public Function DeleteThaiThangThu7(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
    '    Return Me.d.DeleteThaiThangThu7(obj)
    '    If (Not Me._errorRaiseEvent Is Nothing) Then
    '        Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
    '    End If
    '    Return False
    'End Function
    'Public Function DeleteThaiThangThu7Cu(ByVal obj As Obj_PhuNuMangThai_KThaiYte, ByVal sNgayketthuccu As String) As Boolean
    '    Return Me.d.DeleteThaiThangThu7Cu(obj, sNgayketthuccu)
    '    If (Not Me._errorRaiseEvent Is Nothing) Then
    '        Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
    '    End If
    '    Return False
    'End Function
    'Public Function UpdateThaiThangThu7(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
    '    Return Me.d.UpdateThaiThangThu7(obj)
    '    If (Not Me._errorRaiseEvent Is Nothing) Then
    '        Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
    '    End If
    '    Return False
    'End Function
    Public Function CapNhatSayThaiNuoiConNho(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        Return Me.d.CapNhatSayThaiNuoiConNho(obj)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    Public Function GoiThuTuc_XoaDuLieu(ByVal m_sSP_Name As String)
        Me.d.GoiThuTuc_XoaDuLieu(m_sSP_Name)
    End Function
    Public Function LayThaiSanTrongNP(ByVal m_sSP_Name As String)
        Me.d.LayThaiSanTrongNP(m_sSP_Name)
    End Function
    Public Function DeleteInfo(ByVal obj As Obj_PhuNuMangThai_KThaiYte) As Boolean
        obj.ChonBang = 85 ''======= kiểm tra 1 dòng PNMT khi xóa có trong TTT7 không
        Dim table As DataTable = Me.LoadDS(obj)
        If ((table Is Nothing) OrElse (table.Rows.Count <= 0)) Then
            Return Me.d.DeleteInfo(obj)
        Else
            ''======== đã có trong IT_THAITHANGTHU 7 =======
            Return False
        End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function
    ' Fields
    Friend WithEvents d As ClsD_PhuNuMangThai_KThaiYte
    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
