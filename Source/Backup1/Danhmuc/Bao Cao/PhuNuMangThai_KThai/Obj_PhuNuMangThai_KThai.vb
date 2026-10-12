Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class Obj_PhuNuMangThai_KThai
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
        Me.Batdautu = ""
        Me.DenNgay = ""
        Me.DachuyenTT7 = 0
        Return flag
    End Function
    Public Function setvalueThaiThangThu7(ByVal sDV_Ma As String, ByVal sMaNV As String, ByVal sTuNgay As String, ByVal sDenNgay As String) As Boolean
        Dim flag As Boolean = False
        Me.DV_MA = sDV_Ma
        Me.NV_MA = sMaNV
        Me.Batdautu = sTuNgay
        Me.DenNgay = sDenNgay
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
    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property
    Public Property NgayDauThang() As String
        Get
            Return Me.m_sNgaydauthang
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaydauthang = Value
        End Set
    End Property
    Public Property NgayCuoiThang() As String
        Get
            Return Me.m_sNgaycuoithang
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaycuoithang = Value
        End Set
    End Property
    Public Property NgayVe15H30() As Date
        Get
            Return Me.m_dNgayve15h30
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayve15h30 = Value
        End Set
    End Property
    Public Property NgayVe15H30Cu() As String
        Get
            Return Me.m_sNgayve15h30Cu
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayve15h30Cu = Value
        End Set
    End Property
    Public Property Batdautu() As String
        Get
            Return Me.m_sBatdauTT7
        End Get
        Set(ByVal Value As String)
            Me.m_sBatdauTT7 = Value
        End Set
    End Property
    Public Property DenNgay() As String
        Get
            Return Me.m_sKetthucTT7
        End Get
        Set(ByVal Value As String)
            Me.m_sKetthucTT7 = Value
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
    Public Property TuThang() As String
        Get
            Return Me.m_sTuThang
        End Get
        Set(ByVal Value As String)
            Me.m_sTuThang = Value
        End Set
    End Property
    Public Property DenThang() As String
        Get
            Return Me.m_sDenThang
        End Get
        Set(ByVal Value As String)
            Me.m_sDenThang = Value
        End Set
    End Property
    Public Property NgayMT() As String
        Get
            Return Me.m_sNgayMT
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayMT = Value
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
    Public Property GhiChu() As String
        Get
            Return Me.m_sGhiChu
        End Get
        Set(ByVal Value As String)
            Me.m_sGhiChu = Value
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
    Public Property NgayKhamThai() As Date
        Get
            Return Me.m_dNgaykhamthai
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaykhamthai = Value
        End Set
    End Property
    Public Property NgayDuSinh() As Date
        Get
            Return Me.m_dNgayDuSinh
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayDuSinh = Value
        End Set
    End Property
    Public Property NgayDuSinhCu() As String
        Get
            Return Me.m_sNgayDuSinhCu
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayDuSinhCu = Value
        End Set
    End Property
    ''giu lai ngay mang thai cu khi cap nhat lai ngay mang thai (khoa chinh nv_ma,ngaymangthai)
    Public Property NgayMangThaiCu() As Date
        Get
            Return Me.m_dNgaymangthaiCu
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaymangthaiCu = Value
        End Set
    End Property
    Public Property NgayMangThai() As Date
        Get
            Return Me.m_dNgaymangthai
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaymangthai = Value
        End Set
    End Property
    '--------Andrew----------
    Public Property NgayVeSom() As Date
        Get
            Return Me.m_dNgayVeSom
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayVeSom = Value
        End Set
    End Property
    '-----------------------
    ''flag cac lan kham thai
    Public Property Lan(ByVal i As Integer) As Integer
        Get
            Return Me.m_iCo_i
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo_i = Value
        End Set
    End Property
    Public Property Flag1() As Integer
        Get
            Return Me.m_iCo1
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo1 = Value
        End Set
    End Property
    Public Property Flag2() As Integer
        Get
            Return Me.m_iCo2
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo2 = Value
        End Set
    End Property
    Public Property Flag3() As Integer
        Get
            Return Me.m_iCo3
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo3 = Value
        End Set
    End Property
    Public Property Flag4() As Integer
        Get
            Return Me.m_iCo4
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo4 = Value
        End Set
    End Property
    Public Property Flag5() As Integer
        Get
            Return Me.m_iCo5
        End Get
        Set(ByVal Value As Integer)
            Me.m_iCo5 = Value
        End Set
    End Property
    ''cac lan kham thai
    Public Property Lan1() As DBNull
        Get
            Return Me.m_iLan1
        End Get
        Set(ByVal Value As DBNull)
            Me.m_iLan1 = Value
        End Set
    End Property
    Public Property Lan2() As DBNull
        Get
            Return Me.m_iLan2
        End Get
        Set(ByVal Value As DBNull)
            Me.m_iLan2 = Value
        End Set
    End Property
    Public Property Lan3() As DBNull
        Get
            Return Me.m_iLan3
        End Get
        Set(ByVal Value As DBNull)
            Me.m_iLan3 = Value
        End Set
    End Property
    Public Property Lan4() As DBNull
        Get
            Return Me.m_iLan4
        End Get
        Set(ByVal Value As DBNull)
            Me.m_iLan4 = Value
        End Set
    End Property
    Public Property Lan5() As DBNull
        Get
            Return Me.m_iLan5
        End Get
        Set(ByVal Value As DBNull)
            Me.m_iLan5 = Value
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
    Public Property NgayDau() As Date
        Get
            Return Me.m_dNgayDau
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayDau = Value
        End Set
    End Property
    Public Property NgayCuoi() As Date
        Get
            Return Me.m_dNgayCuoi
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayCuoi = Value
        End Set
    End Property
    Public Property NgayNhap() As String
        Get
            Return Me.m_sNgaynhap
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaynhap = Value
        End Set
    End Property
    Public Property NgayCapNhat() As String
        Get
            Return Me.m_sNgayCapNhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCapNhat = Value
        End Set
    End Property
    ' Fields
    Public Property DachuyenTT7() As Integer
        Get
            Return Me.m_iChuyenTT7
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChuyenTT7 = Value
        End Set
    End Property
    Public Property NguoiCapNhat() As String
        Get
            Return Me.m_sNguoiCapNhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoiCapNhat = Value
        End Set
    End Property

    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_iCo_i As Integer
    Public m_iCo1 As Integer
    Public m_iCo2 As Integer
    Public m_iCo3 As Integer
    Public m_iCo4 As Integer
    Public m_iCo5 As Integer
    Public m_bHanhDong As Integer

    Public m_iLan1 As DBNull
    Public m_iLan2 As DBNull
    Public m_iLan3 As DBNull
    Public m_iLan4 As DBNull
    Public m_iLan5 As DBNull

    Public m_sNgay As String
    Public m_sBatdauTT7 As String
    Public m_sKetthucTT7 As String
    Public m_iChuyenTT7 As Integer

    Public m_sNvma As String
    Public m_sDonvi As String
    Public m_sXuong As String
    Public m_sThang As String
    Public m_sNam As String
    Public m_sGhiChu As String
    Public m_sGhiChu_ST As String
    Public m_sNgayMT As String

    Public m_dNgayDau As Date
    Public m_dNgayCuoi As Date
    Public m_dNgaymangthai As Date
    Public m_dNgaymangthaiCu As Date
    Public m_dNgayVeSom As Date '---Andrew
    Public m_dNgayve15h30 As Date
    Public m_sNgayve15h30Cu As String
    Public m_dNgaykhamthai As Date
    Public m_dNgayDuSinh As Date
    Public m_sNgayDuSinhCu As String
    Public m_sTungay As Date
    Public m_sDenngay As Date
    Public m_sDvma As String
    Public m_dTgian As Date
    Public m_sTruyvan As String
    Public m_sTendangnhap As String
    Public m_sDenThang As String
    Public m_sTuThang As String
    Public m_sNgaydauthang As String
    Public m_sNgaycuoithang As String
    Public m_sNgaynhap As String
    Public m_sNgayCapNhat As String
    Public m_sNguoiCapNhat As String
End Class

