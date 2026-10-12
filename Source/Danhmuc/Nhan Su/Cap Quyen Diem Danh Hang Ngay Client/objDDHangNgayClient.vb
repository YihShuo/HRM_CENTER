Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objDDHangNgayClient
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.TenDangNhap = ""
        Me.MaDanhMuc = ""

        Return flag
    End Function

    Public Function setvalue(ByVal Tendangnhap As String, ByVal MaDM As String) As Boolean
        Dim flag As Boolean

        Me.TenDangNhap = Tendangnhap
        Me.MaDanhMuc = MaDM

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

    Public Property MaDanhMuc() As String
        Get
            Return Me.m_sMaDM
        End Get
        Set(ByVal Value As String)
            Me.m_sMaDM = Value
        End Set
    End Property

    '' Fields
    Public m_iChonbang As String
    Public m_sTendangnhap As String
    Public m_sMaDM As String
End Class
