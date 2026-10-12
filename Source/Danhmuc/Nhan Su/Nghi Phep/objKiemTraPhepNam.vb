Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objKiemTraPhepNam
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NAM = ""
        Me.MANV = ""
        Me.DonVi = ""
        Me.MANV = ""
        Me.TuNgay = ""
        Me.DenNgay = ""
        Me.LoaiPhep = ""
        Me.GhiChu = ""
        Me.NGAYNHAP = ""
        Me.CONGTYDUYET = False
        Me.XINCONNUOI = False
        Return flag
    End Function

    Public Property MANV() As String
        Get
            Return Me.m_sManv
        End Get
        Set(ByVal Value As String)
            Me.m_sManv = Value
        End Set
    End Property

    Public Property NAM() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property
    Public Property NGAYNHAP() As String
        Get
            Return Me.m_sNgayNhap
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayNhap = Value
        End Set
    End Property
    ''NGAY CHAM CONG BANG NUOICON 12THANG
    Public Property NGAYCHAMCONG() As String
        Get
            Return Me.m_sNgayNhapCC
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayNhapCC = Value
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

    Public Property TuNgay() As String
        Get
            Return Me.m_sTuNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sTuNgay = Value
        End Set
    End Property

    Public Property DenNgay() As String
        Get
            Return Me.m_sDenNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgay = Value
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

    Public Property LoaiPhep() As String
        Get
            Return Me.m_sLoaiphep
        End Get
        Set(ByVal Value As String)
            Me.m_sLoaiphep = Value
        End Set
    End Property

    Public Property GhiChu() As String
        Get
            Return Me.m_sGhichu
        End Get
        Set(ByVal Value As String)
            Me.m_sGhichu = Value
        End Set
    End Property
    ''backup thao tac nguoi dung
    Public Property TruyVan() As String
        Get
            Return Me.m_sTruyvan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyvan = Value
        End Set
    End Property
    Public Property Thoigian() As DateTime
        Get
            Return Me.m_dTgian
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dTgian = Value
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
    Public Property TenDangNhap() As String
        Get
            Return Me.m_sTendangnhap
        End Get
        Set(ByVal Value As String)
            Me.m_sTendangnhap = Value
        End Set
    End Property
    ''bien luu cac gtri cu
    Public Property TuNgayCu() As String
        Get
            Return Me.m_sTuNgayCu
        End Get
        Set(ByVal Value As String)
            Me.m_sTuNgayCu = Value
        End Set
    End Property

    Public Property DenNgayCu() As String
        Get
            Return Me.m_sDenNgayCu
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgayCu = Value
        End Set
    End Property

    Public Property DonViCu() As String
        Get
            Return Me.m_sDonviCu
        End Get
        Set(ByVal Value As String)
            Me.m_sDonviCu = Value
        End Set
    End Property

    Public Property LoaiPhepCu() As String
        Get
            Return Me.m_sLoaiphepCu
        End Get
        Set(ByVal Value As String)
            Me.m_sLoaiphepCu = Value
        End Set
    End Property

    Public Property GhiChuCu() As String
        Get
            Return Me.m_sGhichuCu
        End Get
        Set(ByVal Value As String)
            Me.m_sGhichuCu = Value
        End Set
    End Property
    Public Property NAMBD() As String
        Get
            Return Me.m_sNamkt
        End Get
        Set(ByVal Value As String)
            Me.m_sNamkt = Value
        End Set
    End Property
    Public Property NAMKT() As String
        Get
            Return Me.m_sNambd
        End Get
        Set(ByVal Value As String)
            Me.m_sNambd = Value
        End Set
    End Property
    Public Property CONGTYDUYET() As Boolean
        Get
            Return Me.m_sCongTyDuyet
        End Get
        Set(ByVal Value As Boolean)
            Me.m_sCongTyDuyet = Value
        End Set
    End Property
    Public Property XINCONNUOI() As Boolean
        Get
            Return Me.m_sXinConNuoi
        End Get
        Set(ByVal Value As Boolean)
            Me.m_sXinConNuoi = Value
        End Set
    End Property

    Public Property TinhThanh() As String
        Get
            Return Me.m_sTinhThanh
        End Get
        Set(ByVal Value As String)
            Me.m_sTinhThanh = Value
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

    Public Property TTQQ() As String
        Get
            Return Me.m_sTTQQ
        End Get
        Set(ByVal Value As String)
            Me.m_sTTQQ = Value
        End Set
    End Property
    Public Property QHQQ() As String
        Get
            Return Me.m_sQHQQ
        End Get
        Set(ByVal Value As String)
            Me.m_sQHQQ = Value
        End Set
    End Property
    Public Property XAQQ() As String
        Get
            Return Me.m_sXAQQ
        End Get
        Set(ByVal Value As String)
            Me.m_sXAQQ = Value
        End Set
    End Property

    ''' <summary>
    ''' gán giá trị khi thao tác trên toàn đơn vị
    ''' </summary>
    Public Function setvalueDonVi(ByVal sDV As String, ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sDonvi As String, ByVal sLoaiPhep As String, ByVal sGhiChu As String, ByVal sCongTyDuyet As Boolean) As Boolean
        Dim flag As Boolean
        Me.DonVi = sDV
        Me.TuNgay = sTuNgay
        Me.DenNgay = sDenNgay
        Me.DonVi = sDonvi
        Me.LoaiPhep = sLoaiPhep
        Me.GhiChu = sGhiChu
        Me.CONGTYDUYET = sCongTyDuyet
        Return flag
    End Function
    Public Function setvalue(ByVal sMaNV As String, ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sDonvi As String, ByVal sLoaiPhep As String, ByVal sGhiChu As String, ByVal sCongTyDuyet As Boolean, ByVal sXinConNuoi As Boolean) As Boolean
        Dim flag As Boolean

        Me.MANV = sMaNV
        Me.TuNgay = sTuNgay
        Me.DenNgay = sDenNgay
        Me.DonVi = sDonvi
        Me.LoaiPhep = sLoaiPhep
        Me.GhiChu = sGhiChu
        Me.CONGTYDUYET = sCongTyDuyet
        Me.XINCONNUOI = sXinConNuoi
        Return flag
    End Function

    Public Function setvalueOM(ByVal sMaNV As String, ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sDonvi As String, ByVal sLoaiPhep As String, ByVal sGhiChu As String, ByVal sCongTyDuyet As Boolean, ByVal sXinConNuoi As Boolean, ByVal sTT As String, ByVal sQH As String, ByVal sXP As String) As Boolean
        Dim flag As Boolean

        Me.MANV = sMaNV
        Me.TuNgay = sTuNgay
        Me.DenNgay = sDenNgay
        Me.DonVi = sDonvi
        Me.LoaiPhep = sLoaiPhep
        Me.GhiChu = sGhiChu
        Me.CONGTYDUYET = sCongTyDuyet
        Me.XINCONNUOI = sXinConNuoi
        Me.TTQQ = sTT
        Me.QHQQ = sQH
        Me.XAQQ = sXP
        Return flag
    End Function

    Public Function setvalueOM2(ByVal sMaNV As String, ByVal sTuNgay As String, ByVal sDenNgay As String, ByVal sDonvi As String, ByVal sLoaiPhep As String, ByVal sGhiChu As String, ByVal sCongTyDuyet As Boolean, ByVal sXinConNuoi As Boolean) As Boolean
        Dim flag As Boolean

        Me.MANV = sMaNV
        Me.TuNgay = sTuNgay
        Me.DenNgay = sDenNgay
        Me.DonVi = sDonvi
        Me.LoaiPhep = sLoaiPhep
        Me.GhiChu = sGhiChu
        Me.CONGTYDUYET = sCongTyDuyet
        Me.XINCONNUOI = sXinConNuoi
        Return flag
    End Function


    ''' <summary>
    ''' hàm lấy giá trị cũ trước khi sửa/xóa (dòng đang active)
    ''' </summary>
    
    Public Function setbackvalue(ByVal sMaNV As String, ByVal sTuNgayCu As String, ByVal sDenNgayCu As String, ByVal sDonviCu As String, ByVal sLoaiPhepCu As String, ByVal sGhiChu As String, ByVal sCongTyDuyet As Boolean, ByVal sXinConNuoi As Boolean) As Boolean
        Dim flag As Boolean

        Me.MANV = sMaNV
        Me.TuNgayCu = sTuNgayCu
        Me.DenNgayCu = sDenNgayCu
        Me.DonViCu = sDonviCu
        Me.LoaiPhepCu = sLoaiPhepCu
        Me.GhiChuCu = sGhiChu
        Me.CONGTYDUYET = sCongTyDuyet
        Me.XINCONNUOI = sXinConNuoi
        Return flag
    End Function

    Public Function setvalueX(ByVal sMaNV As String, ByVal sTuNgay As String) As Boolean
        Dim flag As Boolean

        Me.MANV = sMaNV
        Me.TuNgay = sTuNgay

        Return flag
    End Function

    ' Fields
    Public m_sNam As String
    Public m_sManv As String
    Public m_sTuNgay As String
    Public m_sDenNgay As String
    Public m_sDonvi As String
    Public m_sLoaiphep As String
    Public m_sGhichu As String
    Public m_iChonbang As Integer
    Public m_sNgayNhap As String
    Public m_sNgayNhapCC As String
    Public m_sTruyvan As String
    Public m_sTendangnhap As String
    Public m_bHanhDong As Integer
    Public m_sCongTyDuyet As Boolean
    Public m_sXinConNuoi As Boolean
    Public m_dTgian As DateTime
    ''bien gia tri cu
    Public m_sTuNgayCu As String
    Public m_sDenNgayCu As String
    Public m_sDonviCu As String
    Public m_sLoaiphepCu As String
    Public m_sGhichuCu As String
    Public m_sNambd As String
    Public m_sNamkt As String

    Public m_sID As String
    Public m_sTinhThanh As String

    Public m_sTTQQ As String
    Public m_sQHQQ As String
    Public m_sXAQQ As String
End Class


