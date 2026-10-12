
Public Class objBangThongKeKyLuat
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal donv As String, ByVal makl As String, ByVal ngaybd As String, ByVal ngaykt As String, ByVal nnkyluat As String, ByVal ldo As String, ByVal ngayqd As String, ByVal soqd As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.DONVI = donv
        Me.MAKYLUAT = makl
        Me.NGAYBATDAU = ngaybd
        Me.NGAYKETTHUC = ngaykt
        Me.NNKL_MA = nnkyluat
        Me.LYDO = ldo
        Me.NGAYQUYETDINH = ngayqd
        Me.SOQD = soqd
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
            Return Me.m_sDONVI
        End Get
        Set(ByVal Value As String)
            Me.m_sDONVI = Value
        End Set
    End Property
    Public Property MAKYLUAT() As String
        Get
            Return Me.m_sMAKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sMAKYLUAT = Value
        End Set
    End Property
    Public Property MAKYLUATLUOI() As String
        Get
            Return Me.m_sMAKYLUATLUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sMAKYLUATLUOI = Value
        End Set
    End Property
    Public Property NGAYBATDAU() As String
        Get
            Return Me.m_sNGAYBATDAU
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYBATDAU = Value
        End Set
    End Property
    Public Property NGAYKETTHUC() As String
        Get
            Return Me.m_sNGAYKETTHUC
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYKETTHUC = Value
        End Set
    End Property

    Public Property LYDO() As String
        Get
            Return Me.m_sLYDO
        End Get
        Set(ByVal Value As String)
            Me.m_sLYDO = Value
        End Set
    End Property
    Public Property NGAYQUYETDINH() As String
        Get
            Return Me.m_sNGAYQUYETDINH
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYQUYETDINH = Value
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
    Public Property NNKL_MA() As String
        Get
            Return Me.m_sNNKL_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sNNKL_MA = Value
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
    Public m_sNGAYBATDAU As String
    Public m_sDONVI As String
    Public m_sNGAYKETTHUC As String
    Public m_sNGAYQUYETDINH As String
    Public m_sMAKYLUAT As String
    Public m_sMAKYLUATLUOI As String
    Public m_sNNKL_MA As String
    Public m_sSOQD As String
    Public m_sLYDO As String
    Public m_sChonTable As Integer
End Class
