Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objKhacThuongTuan
    ' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
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

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property

    Public Property Tuan() As Integer
        Get
            Return Me.m_iTuan
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTuan = Value
        End Set
    End Property

    Public Property Nam() As Integer
        Get
            Return Me.m_iNam
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNam = Value
        End Set
    End Property

  

    '' Fields
    Public m_sID As String
    Public m_iTuan As Integer
    Public m_iNam As Integer
    Public m_iChonBang As Integer

End Class



