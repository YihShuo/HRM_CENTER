Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objXinDiKhamBenh
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
        Me.Ngay = Now
        Me.DONVI = ""
        Me.NOIKHAM = ""
        Me.CHANDOAN = ""
        Me.GHICHU = ""
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal ngay_ As String, ByVal DV As String, ByVal NK As String, ByVal CD As String, ByVal GC As String, ByVal m_ChonTable As Integer) As Boolean
        Dim flag As Boolean
        Me.NV_MA = ma
        Me.Ngay = ngay_
        Me.DONVI = DV
        Me.NOIKHAM = NK
        Me.CHANDOAN = CD
        Me.GHICHU = GC
        Me.ChonBang = m_ChonTable
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

    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property Ngay() As String
        Get
            Return Me.m_bNgay
        End Get
        Set(ByVal Value As String)
            Me.m_bNgay = Value
        End Set
    End Property

    Public Property DONVI() As String
        Get
            Return Me.m_bDV
        End Get
        Set(ByVal Value As String)
            Me.m_bDV = Value
        End Set
    End Property

    Public Property CHANDOAN() As String
        Get
            Return Me.m_bCD
        End Get
        Set(ByVal Value As String)
            Me.m_bCD = Value
        End Set
    End Property
    Public Property GHICHU() As String
        Get
            Return Me.m_bGC
        End Get
        Set(ByVal Value As String)
            Me.m_bGC = Value
        End Set
    End Property
    Public Property NOIKHAM() As String
        Get
            Return Me.m_sNK
        End Get
        Set(ByVal Value As String)
            Me.m_sNK = Value
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
    Public Property NGUOITAO() As String
        Get
            Return Me.m_sNguoitao
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoitao = Value
        End Set
    End Property
    Public Property NGAYTAO() As String
        Get
            Return Me.m_sNgaytao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaytao = Value
        End Set
    End Property
    Public Property NGUOICN() As String
        Get
            Return Me.m_sNguoicapnhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoicapnhat = Value
        End Set
    End Property
    Public Property NGAYCN() As String
        Get
            Return Me.m_sNgaycapnhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaycapnhat = Value
        End Set
    End Property
    Public Property NGAYXOA() As String
        Get
            Return Me.m_sNgayxoa
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayxoa = Value
        End Set
    End Property
    Public Property NGUOIXOA() As String
        Get
            Return Me.m_sNguoiXoa
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoiXoa = Value
        End Set
    End Property

    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer

    Public m_sNvma As String
    Public m_sNK As String
    Public m_bNgay As String
    Public m_bDV As String
    Public m_bCD As String
    Public m_bChamcong As Boolean
    Public m_sTendangnhap As String
    Public m_sNgaycapnhat As String
    Public m_sNguoicapnhat As String
    Public m_sNgaytao As String
    Public m_sNguoitao As String
    Public m_sNgayxoa As String
    Public m_sNguoixoa As String
    Public m_bGC As String
End Class
