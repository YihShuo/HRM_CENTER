Public Class obj_KhamBenhNgheNghiep

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.DONVI = ""
        Me.Table = ""
        Me.TUNAM = ""
        Me.DENNAM = ""
        Me.KHAMBENHNGHENGHIEP = 0
        Me.KHAMSUCKHOE = 0
        Me.KHONGBENH_SK = 0
        Me.KHONGBENH_NN = 0
        Me.LV_NNDH = 0
        Me.BENH_KHAMSK = 0
        Me.BENH_HOHAP = 0
        Me.BENH_THINHLUC = 0

        Me.ThamNien = 0
        Me.SoLanKham = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal donvi As String, ByVal m_ChonTable As Integer) As Boolean
        Me.DONVI = donvi
        Me.ChonBang = m_ChonTable
        Return False
    End Function

    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public Property DONVI() As String
        Get
            Return Me.m_sDONVI
        End Get
        Set(ByVal Value As String)
            Me.m_sDONVI = Value
        End Set
    End Property
    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal value As String)
            Me.m_sTable = value
        End Set
    End Property
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sNGAY = value
        End Set
    End Property
    Public Property TUNAM() As String
        Get
            Return Me.m_sTUNAM
        End Get
        Set(ByVal value As String)
            Me.m_sTUNAM = value
        End Set
    End Property
    Public Property DENNAM() As String
        Get
            Return Me.m_sDENNAM
        End Get
        Set(ByVal value As String)
            Me.m_sDENNAM = value
        End Set
    End Property
    Public Property XUONG() As String
        Get
            Return Me.m_sXUONG
        End Get
        Set(ByVal value As String)
            Me.m_sXUONG = value
        End Set
    End Property
    Public Property ThamNien() As Integer
        Get
            Return Me.m_sThamNien
        End Get
        Set(ByVal Value As Integer)
            Me.m_sThamNien = Value
        End Set
    End Property
    Public Property SoLanKham() As Integer
        Get
            Return Me.m_sSoLanKam
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSoLanKam = Value
        End Set
    End Property
    Public Property CHON_TUNAM() As Boolean
        Get
            Return Me.m_bTUNAM
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bTUNAM = Value
        End Set
    End Property
    Public Property CHON_DENNAM() As Boolean
        Get
            Return Me.m_bDENNAM
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bDENNAM = Value
        End Set
    End Property
    Public Property CHONXUONG() As Boolean
        Get
            Return Me.m_bXuong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bXuong = Value
        End Set
    End Property
    Public Property CHONTONGQUAT() As Boolean
        Get
            Return Me.m_bTongquat
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bTongquat = Value
        End Set
    End Property
    Public Property KHAMSUCKHOE() As Integer
        Get
            Return Me.m_bKhamSK
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhamSK = Value
        End Set
    End Property
    Public Property KHAMBENHNGHENGHIEP() As Integer
        Get
            Return Me.m_bKhamBenhNN
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhamBenhNN = Value
        End Set
    End Property
    Public Property KHAMSANKHOA() As Integer
        Get
            Return Me.m_bKhamSAN
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhamSAN = Value
        End Set
    End Property
    Public Property KHONGBENH_SK() As Integer
        Get
            Return Me.m_bKhongMacBenhSK
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhongMacBenhSK = Value
        End Set
    End Property
    Public Property KHONGBENH_NN() As Integer
        Get
            Return Me.m_bKhongMacBenhNN
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhongMacBenhNN = Value
        End Set
    End Property
    Public Property BENH_KHAMSK() As Integer
        Get
            Return Me.m_bMacBenhSK
        End Get
        Set(ByVal Value As Integer)
            Me.m_bMacBenhSK = Value
        End Set
    End Property
    Public Property LV_NNDH() As Integer
        Get
            Return Me.m_bLamViecNNDH
        End Get
        Set(ByVal Value As Integer)
            Me.m_bLamViecNNDH = Value
        End Set
    End Property
    Public Property BENH_HOHAP() As Integer
        Get
            Return Me.m_bBenhHoHap
        End Get
        Set(ByVal Value As Integer)
            Me.m_bBenhHoHap = Value
        End Set
    End Property
    Public Property BENH_THINHLUC() As Integer
        Get
            Return Me.m_bBenhThinhLuc
        End Get
        Set(ByVal Value As Integer)
            Me.m_bBenhThinhLuc = Value
        End Set
    End Property
    Public Property BENH_PHUKHOA() As Integer
        Get
            Return Me.m_bBenhPhuKhoa
        End Get
        Set(ByVal Value As Integer)
            Me.m_bBenhPhuKhoa = Value
        End Set
    End Property
    Public Property KHONGBENH_PHUKHOA() As Integer
        Get
            Return Me.m_bKhongMacBenhPK
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhongMacBenhPK = Value
        End Set
    End Property

    Public m_sDONVI As String
    Public m_sChonTable As Integer
    Public m_sTable As String
    Public m_sTUNAM As String
    Public m_sDENNAM As String
    Public m_bTUNAM As Boolean
    Public m_bDENNAM As Boolean
    Public m_sXUONG As String
    Public m_sCONGVIEC As String
    Public m_bCongViec As Boolean
    Public m_bXuong As Boolean
    Public m_bTongquat As Boolean
    Public m_sNGAY As String
    ''tuy chon kham benh hay kham suc khoe
    Public m_bKhamSK As Integer
    Public m_bKhamBenhNN As Integer
    Public m_bKhamSAN As Integer
    ''tuy chon khac
    Public m_bKhongMacBenhSK As Integer
    Public m_bKhongMacBenhNN As Integer
    Public m_bKhongMacBenhPK As Integer

    Public m_bMacBenhSK As Integer ''mắc bệnh khi khám sk
    Public m_bLamViecNNDH As Integer

    Public m_bBenhHoHap As Integer ''mac bệnh hô hấp
    Public m_bBenhThinhLuc As Integer
    Public m_bBenhPhuKhoa As Integer
    Public m_sThamNien As Integer
    Public m_sSoLanKam As Integer
    Public m_sKqHoHap As Integer
    Public m_sKqThinhLuc As Integer
    Public m_sKhongBenh As Integer

End Class
