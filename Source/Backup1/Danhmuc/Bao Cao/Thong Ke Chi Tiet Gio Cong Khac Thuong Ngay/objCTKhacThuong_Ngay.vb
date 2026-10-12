Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objCTKhacThuong_Ngay
    ' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.IDXuong = ""
        Me.IDNgay = ""
        Return flag
    End Function

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

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonBang = Value
        End Set
    End Property

    Public Property IDXuong() As String
        Get
            Return Me.m_sIDXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sIDXuong = Value
        End Set
    End Property
    Public Property IDNgay() As String
        Get
            Return Me.m_sIDNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sIDNgay = Value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property


    '' Fields
    Public m_iChonBang As Integer
    Public m_sIDXuong As String
    Public m_sIDNgay As String
    Public m_sID As String
End Class


