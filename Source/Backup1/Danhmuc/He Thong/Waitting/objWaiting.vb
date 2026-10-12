Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objWaiting
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Nam = ""
        Me.Thang = ""
        Me.Tuan = ""
        Me.ChonBang = 0

        Return flag
    End Function

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
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

    Public Property Tuan() As String
        Get
            Return Me.m_sTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sTuan = Value
        End Set
    End Property



    Public Property Thang() As String
        Get
            Return Me.m_sThang
        End Get
        Set(ByVal Value As String)
            Me.m_sThang = Value
        End Set
    End Property

    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property

    Public Property NamThangNgay() As String
        Get
            Return Me.m_sNamThangNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNamThangNgay = Value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property

    '' Fields
    Public m_iChonbang As Integer
    Public m_sID As String
    Public m_sNam As String
    Public m_sThang As String
    Public m_sNgay As String

    Public m_sNamThangNgay As String
    Public m_sTuan As String

End Class
