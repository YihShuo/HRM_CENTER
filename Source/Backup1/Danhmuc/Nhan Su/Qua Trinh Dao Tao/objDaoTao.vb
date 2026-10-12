Public Class objDaoTao
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.DONVI = ""
        Me.NGAYBATDAU = ""
        Me.NGAYKETTHUC = ""
        Me.NGANH = ""
        Me.CAPHOC = ""
        Me.KETQUA = ""
        Me.NOI = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal DV As String, ByVal cnhanh As String, ByVal ngaybd As String, ByVal ngaykt As String, ByVal nganhdt As String, ByVal caphocdt As String, ByVal kqua As String, ByVal noidt As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.DONVI = DV
        Me.CHINHANH = cnhanh
        Me.NGAYBATDAU = ngaybd
        Me.NGAYKETTHUC = ngaykt
        Me.NGANH = nganhdt
        Me.CAPHOC = caphocdt
        Me.KETQUA = kqua
        Me.NOI = noidt
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
        End Set
    End Property
    Public Property DONVI() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property CHINHANH() As String
        Get
            Return Me.m_sCN
        End Get
        Set(ByVal Value As String)
            Me.m_sCN = Value
        End Set
    End Property
    Public Property NGAYBATDAU() As String
        Get
            Return Me.m_sNGAYBD
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYBD = Value
        End Set
    End Property
    Public Property NGAYKETTHUC() As String
        Get
            Return Me.m_sNGAYKT
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYKT = Value
        End Set
    End Property
    Public Property NGANH() As String
        Get
            Return Me.m_sNGANH
        End Get
        Set(ByVal Value As String)
            Me.m_sNGANH = Value
        End Set
    End Property
    Public Property CAPHOC() As String
        Get
            Return Me.m_sCAPHOC
        End Get
        Set(ByVal Value As String)
            Me.m_sCAPHOC = Value
        End Set
    End Property
    Public Property KETQUA() As String
        Get
            Return Me.m_sKQ
        End Get
        Set(ByVal Value As String)
            Me.m_sKQ = Value
        End Set
    End Property
    Public Property NOI() As String
        Get
            Return Me.m_sNOI
        End Get
        Set(ByVal Value As String)
            Me.m_sNOI = Value
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
    Public m_sMANV As String
    Public m_sDV As String
    Public m_sCN As String
    Public m_sNGAYBD As String
    Public m_sNGAYKT As String
    Public m_sNGANH As String
    Public m_sCAPHOC As String
    Public m_sKQ As String
    Public m_sNOI As String
    Public m_sChonTable As Integer
End Class
