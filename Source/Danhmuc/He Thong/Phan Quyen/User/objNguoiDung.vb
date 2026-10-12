Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objNguoiDung
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.TenDangNhap = ""
        Me.MatKhau = ""
        Me.MaNV = ""
        Me.TenNhanVien = ""
        Me.IP = ""
        Me.Admin = False

        Return flag
    End Function

    Public Function setvalue(ByVal Tendangnhap As String, ByVal Matkhau As String, ByVal Manv As String, ByVal TenNhanvien As String, ByVal Ip As String, ByVal Admin As Boolean) As Boolean
        Dim flag As Boolean

        Me.TenDangNhap = Tendangnhap
        Me.MatKhau = Matkhau
        Me.MaNV = Manv
        Me.TenNhanVien = TenNhanvien
        Me.IP = Ip
        Me.Admin = Admin

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

    Public Property MaNV() As String
        Get
            Return Me.m_sManv
        End Get
        Set(ByVal Value As String)
            Me.m_sManv = Value
        End Set
    End Property

    Public Property TenNhanVien() As String
        Get
            Return Me.m_sTenNhanvien
        End Get
        Set(ByVal Value As String)
            Me.m_sTenNhanvien = Value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return Me.m_sIp
        End Get
        Set(ByVal Value As String)
            Me.m_sIp = Value
        End Set
    End Property

    Public Property Admin() As Boolean
        Get
            Return Me.m_bAdmin
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bAdmin = Value
        End Set
    End Property
    '' Fields
    Public m_iChonbang As String
    Public m_sTendangnhap As String
    Public m_sMatkhau As String
    Public m_sManv As String
    Public m_sTenNhanvien As String
    Public m_sIp As String
    Public m_bAdmin As Boolean

End Class



