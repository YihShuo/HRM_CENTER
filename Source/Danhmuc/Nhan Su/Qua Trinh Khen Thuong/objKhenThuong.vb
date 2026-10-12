Public Class objKhenThuong
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.DONVI = ""
        Me.NGAYBATDAU = ""
        Me.NGAYKETTHUC = ""
        Me.MAKT = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal DV As String, ByVal ngaybd As String, ByVal ngaykt As String, ByVal makhent As String, ByVal ghic As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.DONVI = DV
        Me.NGAYBATDAU = ngaybd
        Me.NGAYKETTHUC = ngaykt
        Me.MAKT = makhent
        Me.GHICHU = ghic
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
    Public Property MAKT() As String
        Get
            Return Me.m_sKT
        End Get
        Set(ByVal Value As String)
            Me.m_sKT = Value
        End Set
    End Property
    Public Property GHICHU() As String
        Get
            Return Me.m_sGHICHU
        End Get
        Set(ByVal Value As String)
            Me.m_sGHICHU = Value
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
    Public m_sNGAYBD As String
    Public m_sNGAYKT As String
    Public m_sKT As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class
