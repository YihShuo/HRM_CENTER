Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class Obj_TheoDoiNVNghiTS
    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Table = ""
        Me.DonVi = ""
        Me.MaNV = ""
        Me.ChonBang = 0
        Me.ChonKhu = ""
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sTable As String, ByVal pdonvi As String, ByVal pmanv As String, ByVal tungay As String, ByVal denngay As String, ByVal ngaysanh As String, ByVal chonngaysanh As String, ByVal ngaygh As String, ByVal saythai As String, ByVal m_ChonTable As Integer, ByVal chonkhu As String) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.DonVi = pdonvi
        Me.MaNV = pmanv
        Me.TUNGAY = tungay
        Me.DENNGAY = denngay
        Me.NGAYSANH = ngaysanh
        Me.CHONNGAYSANH = chonngaysanh
        Me.NGAYGIAHAN = ngaygh
        Me.CHONSAYTHAI = saythai
        Me.ChonBang = m_sChonTable
        Me.ChonKhu = chonkhu
        Return False
    End Function

    ' Properties
    Public Property Get_Now() As Date
        Get
            Return Me.m_dTgian
        End Get
        Set(ByVal Value As Date)
            Me.m_dTgian = Value
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
    Public Property IDTuan() As String
        Get
            Return Me.m_sIDTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sIDTuan = Value
        End Set
    End Property
    Public Property CauTruyVan() As String
        Get
            Return Me.m_sTruyVan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyVan = Value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal Value As String)
            Me.m_sTable = Value
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

    Public Property DonVi() As String
        Get
            Return Me.m_sDonVi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonVi = Value
        End Set
    End Property
    Public Property KHU() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
    Public Property Xinconnuoi() As Integer
        Get
            Return Me.m_iXinconnuoi
        End Get
        Set(ByVal Value As Integer)
            Me.m_iXinconnuoi = Value
        End Set
    End Property
    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
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

    Public Property NGAY() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property
    Public Property NGAYMT_Tim() As String
        Get
            Return Me.m_sNgaymtTim
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaymtTim = Value
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
    Public Property TUNGAYLUOI() As String
        Get
            Return Me.m_sTuNgayluoi
        End Get
        Set(ByVal Value As String)
            Me.m_sTuNgayluoi = Value
        End Set
    End Property
    Public Property DENNGAYLUOI() As String
        Get
            Return Me.m_sDenNgayluoi
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgayluoi = Value
        End Set
    End Property
    Public Property NGAYSANH() As String
        Get
            Return Me.m_sNgaySanh
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaySanh = Value
        End Set
    End Property
    Public Property chon() As String
        Get
            Return Me.m_sChonSTM
        End Get
        Set(ByVal value As String)
            Me.m_sChonSTM = value
        End Set
    End Property
    Public Property DENHETNGAY() As String
        Get
            Return Me.m_sDenHetNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sDenHetNgay = Value
        End Set
    End Property
    Public Property NGAYGIAHAN() As String
        Get
            Return Me.m_sNgayGiaHan
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayGiaHan = Value
        End Set
    End Property
    Public Property CHONNGAYSANH() As Integer
        Get
            Return Me.m_sChonNgaySanh
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonNgaySanh = Value
        End Set
    End Property
    Public Property CHONSAYTHAI() As Integer
        Get
            Return Me.m_sChonST
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonST = Value
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
    Public Property NgayVe15H30() As Date
        Get
            Return Me.m_dNgayve15h30
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayve15h30 = Value
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
    ''ngay du sinh thay doi theo nguoi dung chon
    Public Property NgayDuSinhTD() As Date
        Get
            Return Me.m_dNgayDuSinh
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayDuSinh = Value
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
    Public Property NgayMangThai() As String
        Get
            Return Me.m_sNgaymangthai
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaymangthai = Value
        End Set
    End Property
    Public Property NgayBD() As String
        Get
            Return Me.m_sNgaybd
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaybd = Value
        End Set
    End Property
    Public Property NgayKT() As String
        Get
            Return Me.m_sNgaykt
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaykt = Value
        End Set
    End Property
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
    Public Property Get_HanhDong() As Integer
        Get
            Return Me.m_bHanhDong
        End Get
        Set(ByVal Value As Integer)
            Me.m_bHanhDong = Value
        End Set
    End Property
    Public Property TruyVan() As String
        Get
            Return Me.m_sTruyVan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyVan = Value
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
    Public Property NAMBD() As String
        Get
            Return Me.m_sNambd
        End Get
        Set(ByVal Value As String)
            Me.m_sNambd = Value
        End Set
    End Property
    Public Property NAMKT() As String
        Get
            Return Me.m_sNamkt
        End Get
        Set(ByVal Value As String)
            Me.m_sNamkt = Value
        End Set
    End Property
    Public Property ChonKhu As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal value As String)
            Me.m_sKhu = value
        End Set
    End Property
    ' Fields
    Public m_sID As String
    Public m_sTruyVan As String
    Public m_sIDTuan As String
    Public m_sTable As String
    Public m_sDonVi As String
    Public m_sXuong As String
    Public m_sDenThang As String
    Public m_sTuThang As String
    Public m_sThang As String
    Public m_sNam As String
    Public m_sNambd As String
    Public m_sNamkt As String
    Public m_sKhu As String
    Public m_sMaNV As String
    Public m_sTuNgay As String
    Public m_sNgay As String
    Public m_sDenNgay As String
    Public m_sTuNgayluoi As String
    Public m_sDenNgayluoi As String
    Public m_sNgaySanh As String
    Public m_sChonNgaySanh As String
    Public m_sChonST As String
    Public m_sChonSTM As String
    Public m_sNgayGiaHan As String
    Public m_sDenHetNgay As String
    Public m_sChonTable As Integer

    Public m_iChonbang As Integer
    Public m_iCo_i As Integer
    Public m_iCo1 As Integer
    Public m_iCo2 As Integer
    Public m_iCo3 As Integer
    Public m_iCo4 As Integer
    Public m_iCo5 As Integer

    Public m_iLan1 As DBNull
    Public m_iLan2 As DBNull
    Public m_iLan3 As DBNull
    Public m_iLan4 As DBNull
    Public m_iLan5 As DBNull

    Public m_sGhiChu As String
    Public m_sGhiChu_ST As String

    Public m_bHanhDong As Integer

    Public m_sNgaymangthai As String
    Public m_dNgaymangthaiCu As Date
    Public m_dNgayve15h30 As Date
    Public m_dNgaykhamthai As Date
    Public m_dNgayDuSinh As Date
    Public m_sNgaybd As String
    Public m_sNgaykt As String
    Public m_dTgian As Date
    Public m_sTendangnhap As String
    Public m_sNgaymtTim As String
    Public m_iXinconnuoi As Integer

End Class
