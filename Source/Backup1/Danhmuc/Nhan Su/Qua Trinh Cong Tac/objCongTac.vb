Public Class objCongTac
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.SOQD = ""
        Me.DONVI = ""
        Me.CHUCVU = ""
        Me.CONGVIEC = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal ngayct As String, ByVal sqd As String, ByVal donv As String, ByVal cvu As String, ByVal cviec As String, ByVal gchu As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.NGAY = ngayct
        Me.SOQD = sqd
        Me.DONVI = donv
        Me.CHUCVU = cvu
        Me.CONGVIEC = cviec
        Me.GHICHU = gchu
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
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
        End Set
    End Property
    Public Property SOQD() As String
        Get
            Return Me.m_sSOQD
        End Get
        Set(ByVal Value As String)
            Me.m_sSOQD = Value
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
    Public Property CHUCVU() As String
        Get
            Return Me.m_sCHUCVU
        End Get
        Set(ByVal Value As String)
            Me.m_sCHUCVU = Value
        End Set
    End Property
    Public Property CONGVIEC() As String
        Get
            Return Me.m_sCONGVIEC
        End Get
        Set(ByVal Value As String)
            Me.m_sCONGVIEC = Value
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
    Public m_sNGAY As String
    Public m_sDONVI As String
    Public m_sSOQD As String
    Public m_sCHUCVU As String
    Public m_sCONGVIEC As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class
