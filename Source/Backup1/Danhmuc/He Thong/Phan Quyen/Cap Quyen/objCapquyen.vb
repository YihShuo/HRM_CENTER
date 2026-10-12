Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objCapquyen
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.TenDangNhap = ""
        Me.MaDanhMuc = ""
        Me.Them = 0
        Me.Sua = 0
        Me.Xoa = 0
        Return flag
    End Function

    Public Function setvalue(ByVal Tendangnhap As String, ByVal MaDM As String, ByVal Them As Integer, ByVal Sua As Integer, ByVal Xoa As Integer) As Boolean
        Dim flag As Boolean

        Me.TenDangNhap = Tendangnhap
        Me.MaDanhMuc = MaDM
        Me.Them = Them
        Me.Sua = Sua
        Me.Xoa = Xoa
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
    Public Property Xem() As Integer
        Get
            Return Me.m_bXem
        End Get
        Set(ByVal Value As Integer)
            Me.m_bXem = Value
        End Set
    End Property
    Public Property Them() As Integer
        Get
            Return Me.m_bThem
        End Get
        Set(ByVal Value As Integer)
            Me.m_bThem = Value
        End Set
    End Property
    Public Property Sua() As Integer
        Get
            Return Me.m_bSua
        End Get
        Set(ByVal Value As Integer)
            Me.m_bSua = Value
        End Set
    End Property
    Public Property Xoa() As Integer
        Get
            Return Me.m_bXoa
        End Get
        Set(ByVal Value As Integer)
            Me.m_bXoa = Value
        End Set
    End Property
    Public Property KHUA() As Integer
        Get
            Return Me.m_bKHUA
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKHUA = Value
        End Set
    End Property
    Public Property KHUB() As Integer
        Get
            Return Me.m_bKHUB
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKHUB = Value
        End Set
    End Property

    '' Fields
    Public m_iChonbang As String
    Public m_sTendangnhap As String
    Public m_sMaDM As String
    Public m_bXem As Integer
    Public m_bThem As Integer
    Public m_bSua As Integer
    Public m_bXoa As Integer
    Public m_bKHUA As Integer
    Public m_bKHUB As Integer
 
End Class
