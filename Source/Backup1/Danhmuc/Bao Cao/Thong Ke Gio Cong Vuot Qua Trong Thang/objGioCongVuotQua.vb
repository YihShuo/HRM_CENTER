Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objGioCongVuotQua
    '' Methods
    'Public Function Setnull() As Boolean
    '    Dim flag As Boolean
    '    Me.ID = ""
    '    Me.NoiTraLuong = ""
    '    Me.MucLuong = 0
    '    Me.LyDoNghi = ""
    '    Me.GhiChu = ""
    '    Return flag
    'End Function

    'Public Function setvalue(ByVal m_sID As String, ByVal m_sPaidBy As String, ByVal m_sMucLuong As String, ByVal m_sLyDo As String, ByVal m_sNote As String) As Boolean
    '    Dim flag As Boolean
    '    Me.ID = m_sID
    '    Me.NoiTraLuong = m_sPaidBy
    '    If (m_sMucLuong.CompareTo("") = 0) Then
    '        Me.MucLuong = 0
    '    Else
    '        Me.MucLuong = Integer.Parse(m_sMucLuong)
    '    End If
    '    Me.LyDoNghi = m_sLyDo
    '    Me.GhiChu = m_sNote
    '    Return flag
    'End Function

    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property

    '' Properties
    Public Property Thang() As String
        Get
            Return Me.m_sThang
        End Get
        Set(ByVal Value As String)
            Me.m_sThang = Value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonBang = Value
        End Set
    End Property

    Public Property Nam() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property



    '' Fields
    Public m_iChonBang As Integer
    Public m_sThang As String
    Public m_sNam As String
    Public m_sNgay As String
End Class


