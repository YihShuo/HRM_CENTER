Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class Obj_ConDuoi6Tuoi
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Get_HanhDong = 0
        Me.DV_MA = ""
        Me.Get_Now = Now()
        Me.DonVi = ""
        Me.NV_MA = ""
        Me.ChonBang = 0
        Me.TruyVan = ""
        Return flag
    End Function
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
    Public Property ChkSanhDoi() As Integer
        Get
            Return Me.m_iSanhDoi
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSanhDoi = Value
        End Set
    End Property
    Public Property SoThang() As Integer
        Get
            Return Me.m_iSoThang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSoThang = Value
        End Set
    End Property
    Public Property SoTienTC() As Double
        Get
            Return Me.m_dbSoTien
        End Get
        Set(ByVal Value As Double)
            Me.m_dbSoTien = Value
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
    Public Property XemNgayNhap() As String
        Get
            Return Me.m_sXemngaynhap
        End Get
        Set(ByVal Value As String)
            Me.m_sXemngaynhap = Value
        End Set
    End Property
    Public Property ThangNamTinhLuong() As String
        Get
            Return Me.m_sThangnamtl
        End Get
        Set(ByVal Value As String)
            Me.m_sThangnamtl = Value
        End Set
    End Property
    'dung de tinh toan
    Public Property NgayNhap() As Date
        Get
            Return Me.m_dNgayNhap
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayNhap = Value
        End Set
    End Property
    'dung luu tru
    Public Property NgayNhapTC() As String
        Get
            Return Me.m_sNgayNhaptc
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayNhaptc = Value
        End Set
    End Property
    Public Property GhichuSD() As String
        Get
            Return Me.m_sGhiChu
        End Get
        Set(ByVal Value As String)
            Me.m_sGhiChu = Value
        End Set
    End Property
    Public Property LayNgay() As String
        Get
            Return Me.m_sLayNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sLayNgay = Value
        End Set
    End Property
    ''lay ngay nhap lieu that su luu tru de backup
    Public Property LayNgayNhap() As String
        Get
            Return Me.m_sLayNgayNhap
        End Get
        Set(ByVal Value As String)
            Me.m_sLayNgayNhap = Value
        End Set
    End Property
    Public Property LayNgaySanh() As String
        Get
            Return Me.m_sLayNgaySanh
        End Get
        Set(ByVal Value As String)
            Me.m_sLayNgaySanh = Value
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
    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property
    Public Property TruyVan() As String
        Get
            Return Me.m_sTruyvan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyvan = Value
        End Set
    End Property
    Public Property DV_MA() As String
        Get
            Return Me.m_sDvma
        End Get
        Set(ByVal Value As String)
            Me.m_sDvma = Value
        End Set
    End Property
    Public Property Get_HanhDong() As Integer
        Get
            Return Me.m_bHanhDong
        End Get
        Set(ByVal Value As Integer)
            Me.m_bHanhDong = Value
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
    Public Property Xuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
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
    Public Property Nam() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property
    Public Property GhiChu_ST() As String
        Get
            Return Me.m_sGhiChu_ST
        End Get
        Set(ByVal Value As String)
            Me.m_sGhiChu_ST = Value
        End Set
    End Property
    Public Property Thangtinhluong() As String
        Get
            Return Me.m_sThangtinhluong
        End Get
        Set(ByVal Value As String)
            Me.m_sThangtinhluong = Value
        End Set
    End Property
    Public Property NgaySanh() As Date
        Get
            Return Me.m_dNgaysanh
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaysanh = Value
        End Set
    End Property
    Public Property SoconSD() As Integer
        Get
            Return Me.m_iSocon
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSocon = Value
        End Set
    End Property
    Public Property NgaySanhCu() As Date
        Get
            Return Me.m_dNgaysanhcu
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaysanhcu = Value
        End Set
    End Property
    Public Property Get_Now() As Date
        Get
            Return Me.m_dTgian
        End Get
        Set(ByVal Value As Date)
            Me.m_dTgian = Value
        End Set
    End Property

    Public Property NgayHetHan() As Date
        Get
            Return Me.m_sDenngay
        End Get
        Set(ByVal Value As Date)
            Me.m_sDenngay = Value
        End Set
    End Property
    ''lay thang nam hien tai
    Public Property MATHANG() As String
        Get
            Return Me.m_sMATHANG
        End Get
        Set(ByVal Value As String)
            Me.m_sMATHANG = Value
        End Set
    End Property
    Public Property NgayCuoiThang() As String
        Get
            Return Me.m_sNgayCuoi
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCuoi = Value
        End Set
    End Property
    Public Property Xemtruoc() As Integer
        Get
            Return Me.m_iXemtruoc
        End Get
        Set(ByVal Value As Integer)
            Me.m_iXemtruoc = Value
        End Set
    End Property
    Public Property Tuoi() As Integer
        Get
            Return Me.m_iTuoi
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTuoi = Value
        End Set
    End Property
    Public Property ThangTuoi() As Integer
        Get
            Return Me.m_iThangTuoi
        End Get
        Set(ByVal Value As Integer)
            Me.m_iThangTuoi = Value
        End Set
    End Property
    Public Property Ngay_HienTai() As String
        Get
            Return Me.m_sNgay_HienTai
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay_HienTai = Value
        End Set
    End Property
    Public Property ChonKhu() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
    Public Property bQuyenKhuA() As Integer
        Get
            Return Me.m_iQuyenkhuA
        End Get
        Set(ByVal Value As Integer)
            Me.m_iQuyenkhuA = Value
        End Set
    End Property
    Public Property bQuyenKhuB() As Integer
        Get
            Return Me.m_iQuyenkhuB
        End Get
        Set(ByVal Value As Integer)
            Me.m_iQuyenkhuB = Value
        End Set
    End Property
    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer

    Public m_bHanhDong As Integer
    Public m_iSoThang As Integer
    Public m_iSocon As Integer
    Public m_iXemtruoc As Integer
    Public m_iThangTuoi As Integer
    Public m_iTuoi As Integer

    Public m_iSanhDoi As Integer
    Public m_iQuyenkhuA As Integer
    Public m_iQuyenkhuB As Integer

    Public m_sNgay As String
    Public m_sLayNgaySanh As String
    Public m_sXemngaynhap As String
    Public m_sNvma As String
    Public m_sDonvi As String
    Public m_sNgayCuoi As String
    Public m_sXuong As String
    Public m_sThang As String
    Public m_sNam As String
    Public m_sGhiChu As String
    Public m_sGhiChu_ST As String
    Public m_sMATHANG As String
    Public m_sLayNgay As String
    Public m_sNgay_HienTai As String

    Public m_sTungay As Date
    Public m_sDenngay As Date
    Public m_dNgaysanhcu As Date
    Public m_dNgaysanh As Date

    Public m_sDvma As String
    Public m_dTgian As Date
    Public m_sTruyvan As String
    Public m_sTendangnhap As String
    Public m_dNgayNhap As Date
    Public m_sLayNgayNhap As String
    Public m_dbSoTien As Double
    Public m_sThangnamtl As String
    Public m_sThangtinhluong As String
    Public m_sNgayNhaptc As String

    Public m_sKhu As String
End Class
