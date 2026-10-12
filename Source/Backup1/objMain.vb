Imports Microsoft.VisualBasic.CompilerServices
Imports System


Public Class objMain

    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.TenDangNhap = ""
        Me.MatKhau = ""
        Me.NhomDM = ""

        Return flag
    End Function

    Public Function setvalue(ByVal m_sTendangnhap As String, ByVal m_sMatkhau As String, ByVal m_sNhomDM As String) As Boolean
        Dim flag As Boolean

        Me.TenDangNhap = m_sTendangnhap
        Me.MatKhau = m_sMatkhau
        Me.NhomDM = m_sNhomDM

        Return flag
    End Function

    '' Properties
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property

    Public Property TenDangNhap() As String
        Get
            Return Me.m_sTendangnhap
        End Get
        Set(ByVal Value As String)
            Me.m_sTendangnhap = Value
        End Set
    End Property

    Public Property MatKhau() As String
        Get
            Return Me.m_sMatkhau
        End Get
        Set(ByVal Value As String)
            Me.m_sMatkhau = Value
        End Set
    End Property
    Public Property NhomDM() As String
        Get
            Return Me.m_sNhomDM
        End Get
        Set(ByVal Value As String)
            Me.m_sNhomDM = Value
        End Set
    End Property




    Public m_iChonbang As String
    Public m_sTendangnhap As String
    Public m_sMatkhau As String
    Public m_sNhomDM As String

End Class
