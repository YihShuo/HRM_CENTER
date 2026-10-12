Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTinhLuongChinh
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ID = ""
        Me.ChonBang = 0
        Me.Ngay = ""
        Me.DonVi = ""
        Me.Thang = ""
        Me.Nam = ""
        Return flag
    End Function

    Public Function setvalue(ByVal thang As String, ByVal ma As String, ByVal lluong As String) As Boolean
        Dim flag As Boolean
        Me.NamThang = thang
        Me.NV_MA = ma
        Me.LoaiLuong = lluong
        Return flag
    End Function
    Public m_sNGAYTAO As String

    Public m_sNGUOITAO As String


    Public Property NGAYTAO() As String
        Get
            Return Me.m_sNGAYTAO
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYTAO = Value
        End Set
    End Property
    Public Property NGUOITAO() As String
        Get
            Return Me.m_sNGUOITAO
        End Get
        Set(ByVal Value As String)
            Me.m_sNGUOITAO = Value
        End Set
    End Property
  
    '' Properties
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
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

    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property


    Public Property DonVi() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
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

    Public Property NamThang() As String
        Get
            Return Me.m_sNamThang
        End Get
        Set(ByVal Value As String)
            Me.m_sNamThang = Value
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

    Public Property NgayChamCong() As Date
        Get
            Return Me.m_dNgaychamcong
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaychamcong = Value
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


    Public Property FlagTinhLuong() As Boolean
        Get
            Return Me.m_bFlagTinhLuong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bFlagTinhLuong = Value
        End Set
    End Property

    Public Property ChamCom() As String
        Get
            Return Me.m_bChamCom
        End Get
        Set(ByVal Value As String)
            Me.m_bChamCom = Value
        End Set
    End Property
    Public Property LoaiLuong() As String
        Get
            Return Me.m_bLoaiLuong
        End Get
        Set(ByVal Value As String)
            Me.m_bLoaiLuong = Value
        End Set
    End Property

    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sNgay As String
    Public m_sDonvi As String
    Public m_sThang As String
    Public m_sNamThang As String
    Public m_sNam As String

    Public m_dNgaychamcong As Date
    Public m_sNvma As String
    Public m_bFlagTinhLuong As Boolean
    Public m_bCoChamCom As Boolean
    Public m_bChamCom As String
    Public m_bLoaiLuong As String
End Class
