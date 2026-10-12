Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThoiViec
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
        Me.SoQD = ""
        Me.LoaiTV = ""
        Me.LyDO = ""
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal ngay As String, ByVal so As String, ByVal lydo As String, ByVal loai As String, ByVal m_ChonTable As Integer) As Boolean
        Dim flag As Boolean
        Me.NV_MA = ma
        Me.NgayTV = ngay
        Me.SoQD = so
        Me.LyDO = lydo
        Me.LoaiTV = loai
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

    Public Property NgayTV() As String
        Get
            Return Me.m_bNgay
        End Get
        Set(ByVal Value As String)
            Me.m_bNgay = Value
        End Set
    End Property

    Public Property SoQD() As String
        Get
            Return Me.m_bso
        End Get
        Set(ByVal Value As String)
            Me.m_bso = Value
        End Set
    End Property
    Public Property FlagChamCong() As Boolean
        Get
            Return Me.m_bChamcong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChamcong = Value
        End Set
    End Property

    Public Property LoaiTV() As String
        Get
            Return Me.m_bLoai
        End Get
        Set(ByVal Value As String)
            Me.m_bLoai = Value
        End Set
    End Property
    Public Property LyDO() As String
        Get
            Return Me.m_blydo
        End Get
        Set(ByVal Value As String)
            Me.m_blydo = Value
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
    Public Property NGUOICAPNHAT() As String
        Get
            Return Me.m_sNguoicapnhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoicapnhat = Value
        End Set
    End Property
    Public Property NGAYCAPNHAT() As String
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
    Public m_bLoai As String
    Public m_bNgay As String
    Public m_bso As String
    Public m_blydo As String
    Public m_bChamcong As Boolean
    Public m_sTendangnhap As String
    Public m_sNgaycapnhat As String
    Public m_sNguoicapnhat As String
    Public m_sNgaytao As String
    Public m_sNguoitao As String
    Public m_sNgayxoa As String
    Public m_sNguoixoa As String
    Public m_sNam As String
End Class
