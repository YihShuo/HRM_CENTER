Imports System
Imports System.Data
Imports System.Runtime.CompilerServices
Public Class clsBChamcongMain
    ' Events
    Public Event _errorRaise As _errorRaiseEventHandler

    ' Methods
    Public Sub New()
        Me.d = New clsDChamcongMain
    End Sub

    Public Function CapNhat(ByVal obj As objChamcongMain, ByVal ThemSua As Integer) As Boolean
        If (ThemSua = 0) Then
            Return Me.InsertInfo(obj)
        End If
        Return Me.UpdateInfo(obj)
    End Function

    Public Sub d__error(ByVal message As String)
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(message)
        End If
    End Sub

    Public Function DeleteInfo(ByVal obj As objChamcongMain) As Boolean
        Return Me.d.DeleteInfo(obj)
    End Function

    Public Function InsertInfo(ByVal obj As objChamcongMain) As Boolean
        Return Me.d.InsertInfo(obj)
        'End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke(ChrW(272) & ChrW(227) & " t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng th" & ChrW(234) & "m " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function

    Public Function IsDeleteOK(ByVal maNgayNghi As String) As Boolean
        Dim nghi As New objChamcongMain
        nghi.ID = maNgayNghi
        Return Me.d.IsDeleteOK(nghi)
    End Function

    Public Function LoadDS(ByVal obj As objChamcongMain) As DataTable
        Return Me.d.LoadDS(obj)
    End Function

    Public Function PhatSinhMa() As String
        Return Me.d.PhatSinhMa
    End Function

    Public Function UpdateInfo(ByVal obj As objChamcongMain) As Boolean
        'Dim table As DataTable = Me.LoadDS(obj)
        'If ((Not table Is Nothing) AndAlso (table.Rows.Count <> 0)) Then
        Return Me.d.UpdateInfo(obj)
        'End If
        If (Not Me._errorRaiseEvent Is Nothing) Then
            Me._errorRaiseEvent.Invoke("Kh" & ChrW(244) & "ng t" & ChrW(7891) & "n t" & ChrW(7841) & "i m" & ChrW(227) & " ng" & ChrW(224) & "y ngh" & ChrW(7881) & " n" & ChrW(224) & "y. Kh" & ChrW(244) & "ng s" & ChrW(7917) & "a " & ChrW(273) & ChrW(432) & ChrW(7907) & "c.")
        End If
        Return False
    End Function

    Public Function GoiThuTuc(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList)
        Me.d.GoiThuTuc(m_sSP_Name, m_listpar)
        'd.ChuoiThaoTac = m_sSP_Name
    End Function
    Public Function Kiemtrasaythaive15h30(ByVal m_sSP_Name As String, ByVal m_listpar As ArrayList) As DataTable
        Return Me.d.Kiemtrasaythaive15h30(m_sSP_Name, m_listpar)
    End Function

    ' Fields
    Friend WithEvents d As clsDChamcongMain

    ' Nested Types
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class
