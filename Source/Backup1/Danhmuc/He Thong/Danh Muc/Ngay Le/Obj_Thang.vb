Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class Obj_Thang
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATHANG = ""
        Me.TUNGAY = ""
        Me.DENNGAY = ""
        Me.SONGAYCONG = ""
        'Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaThang As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal SoNgayCong As String) As Boolean
        Me.MATHANG = MaThang
        Me.TUNGAY = TuNgay
        Me.DENNGAY = DenNgay
        Me.SONGAYCONG = SoNgayCong
        Return False
    End Function
    Public Property MATHANG() As String
        Get
            Return Me.m_sMATHANG
        End Get
        Set(ByVal Value As String)
            Me.m_sMATHANG = Value
        End Set
    End Property

    Public Property TUNGAY() As String
        Get
            Return Me.m_sTUNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sTUNGAY = Value
        End Set
    End Property

    Public Property DENNGAY() As String
        Get
            Return Me.m_sDENNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sDENNGAY = Value
        End Set
    End Property

    Public Property SONGAYCONG() As String
        Get
            Return Me.m_sSONGAYCONG
        End Get
        Set(ByVal Value As String)
            Me.m_sSONGAYCONG = Value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonBang = Value
        End Set
    End Property

    Public Function KtMa() As Boolean
        Return (StringType.StrCmp(Me.MATHANG, "", False) <> 0)
    End Function
    Public Overridable Function setvalue_Ngay(ByVal Ngay As String, ByVal TenNgayLe As String) As Boolean
        Me.NGAY = Ngay
        Me.TENNGAYLE = TenNgayLe
        Return False
    End Function

    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
        End Set
    End Property
    Public Property TENNGAYLE() As String
        Get
            Return Me.m_sTENNGAYLE
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNGAYLE = Value
        End Set
    End Property

    Public Function KtNgay() As Boolean
        Return (StringType.StrCmp(Me.NGAY, "", False) <> 0)
    End Function

    Public m_sMATHANG As String
    Public m_sTUNGAY As String
    Public m_sDENNGAY As String
    Public m_sSONGAYCONG As String
    Public m_sNGAY As String
    Public m_sTENNGAYLE As String
    Public m_sChonBang As Integer
End Class
