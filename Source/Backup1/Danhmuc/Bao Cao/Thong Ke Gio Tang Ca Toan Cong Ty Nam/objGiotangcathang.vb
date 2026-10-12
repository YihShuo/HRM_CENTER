Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objGiotangcathang
    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.ChonBang = 0
        Me.MANX = ""
        Me.CauTruyVan = ""
        Me.TUNGAY = ""
        Me.DENNGAY = ""
        Me.TenBang = ""
        Return flag
    End Function
    Public Property ChonXuong() As String
        Get
            Return Me.m_sChonXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sChonXuong = Value
        End Set
    End Property
    Public Property KHU() As String
        Get
            Return Me.m_sKHU
        End Get
        Set(ByVal Value As String)
            Me.m_sKHU = Value
        End Set
    End Property
    Public Property ChonKhu() As Integer
        Get
            Return Me.m_iChonKhu
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonKhu = Value
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
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property

    Public Property Nam() As Integer
        Get
            Return Me.m_iNam
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNam = Value
        End Set
    End Property
    Public Property TinhDieuDongGiam() As Integer
        Get
            Return Me.m_iTinhDieuDongGiam
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTinhDieuDongGiam = Value
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
    Public Property TrongQuyDinh() As Boolean
        Get
            Return Me.m_iChonTrongQD
        End Get
        Set(ByVal Value As Boolean)
            Me.m_iChonTrongQD = Value
        End Set
    End Property
    Public Property TenBang() As String
        Get
            Return Me.m_sTenBang
        End Get
        Set(ByVal Value As String)
            Me.m_sTenBang = Value
        End Set
    End Property
    Public Property MANX() As String
        Get
            Return Me.m_s_MANX
        End Get
        Set(ByVal Value As String)
            Me.m_s_MANX = Value
        End Set
    End Property
    Public Property CauTruyVan() As String
        Get
            Return Me.m_sExSQL
        End Get
        Set(ByVal Value As String)
            Me.m_sExSQL = Value
        End Set
    End Property
    Public Property TUNGAY() As String
        Get
            Return Me.m_sTuNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sTuNgay = Value
        End Set
    End Property
    Public Property DENNGAY() As String
        Get
            Return Me.m_sDenNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgay = Value
        End Set
    End Property
    Public Property DONVI() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property DONVITHONGKE() As String
        Get
            Return Me.m_sDonvithongke
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvithongke = Value
        End Set
    End Property
    Public Property CONGIVECTHONGKE() As String
        Get
            Return Me.m_sCongviecthongke
        End Get
        Set(ByVal Value As String)
            Me.m_sCongviecthongke = Value
        End Set
    End Property
    ''NGAY DIEM DANH
    Public Property Ngay() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sNGAY = value
        End Set
    End Property

    Public Property THANGBD() As String
        Get
            Return Me.m_sThangbd
        End Get
        Set(ByVal Value As String)
            Me.m_sThangbd = Value
        End Set
    End Property
    Public Property THANGKT() As String
        Get
            Return Me.m_sThangkt
        End Get
        Set(ByVal Value As String)
            Me.m_sThangkt = Value
        End Set
    End Property
    Public Property CHONCUNGTHANG() As Integer
        Get
            Return Me.m_iCHONCUNGTHANG
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCHONCUNGTHANG = Value
        End Set
    End Property
    Public Property NGAYBD_THANGBD() As Integer
        Get
            Return Me.m_iNGAYBDTHANGBD
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNGAYBDTHANGBD = Value
        End Set
    End Property
    Public Property NGAYKT_THANGBD() As Integer
        Get
            Return Me.m_iNGAYKTTHANGBD
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNGAYKTTHANGBD = Value
        End Set
    End Property
    Public Property NGAYBD_THANGKT() As Integer
        Get
            Return Me.m_iNGAYBDTHANGKT
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNGAYBDTHANGKT = Value
        End Set
    End Property
    Public Property NGAYKT_THANGKT() As Integer
        Get
            Return Me.m_iNGAYKTTHANGKT
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNGAYKTTHANGKT = Value
        End Set
    End Property
    '' Fields
    Public m_sTuNgay As String
    Public m_sThangbd As String
    Public m_sThangkt As String
    Public m_sDenNgay As String
    Public m_sDonvi As String
    Public m_iChonbang As Integer
    Public m_iChonTrongQD As Boolean
    Public m_iChonTungThang As Boolean
    Public m_sID As String
    Public m_iNam As Integer
    Public m_s_MANX As String
    Public m_sExSQL As String
    Public m_sNGAY As String
    Public m_sTendangnhap As String
    Public m_sTenBang As String
    Public m_sDonvithongke As String
    Public m_sCongviecthongke As String
    Public m_iNGAYKTTHANGKT As Integer
    Public m_iNGAYKTTHANGBD As Integer
    Public m_iNGAYBDTHANGBD As Integer
    Public m_iNGAYBDTHANGKT As Integer
    Public m_iCHONCUNGTHANG As Integer
    Public m_sChonXuong As String
    Public m_iTinhDieuDongGiam As Integer
    Public m_iChonKhu As Integer
    Public m_sKHU As String
End Class


