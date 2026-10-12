Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ObjPhuNuHanhKinh
    Dim flag As Boolean
    Public Property NV_MA() As String
        Get
            Return Me.m_sNV_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sNV_MA = Value
        End Set
    End Property
    Public Property NgayNghiHanhKinh() As String
        Get
            Return Me.m_sNgayNghiHanhKinh
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayNghiHanhKinh = Value
        End Set
    End Property
    Public Property ThangNam() As String
        Get
            Return Me.m_sThangNam
        End Get
        Set(ByVal Value As String)
            Me.m_sThangNam = Value
        End Set
    End Property
    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public Property Donvi() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property NGAYVAO() As String
        Get
            Return Me.m_sNgayvao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayvao = Value
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
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
        Me.DonVi = ""
        Me.NgayNghiHanhKinh = Now().Date
    End Function
    Public Function setvalue(ByVal sNV_Ma As String, ByVal sNgay As String) As Boolean
        Dim flag As Boolean
        Me.NV_MA = sNV_Ma
        Me.NgayNghiHanhKinh = sNgay
        Return flag
    End Function

    Public m_sNV_MA As String
    Public m_sDonvi As String
    Public m_sNgayvao As String
    Public m_sChonTable As Integer
    Public m_sNgayNghiHanhKinh As String
    Public m_sThangNam As String
    Public m_sTendangnhap As String
End Class
