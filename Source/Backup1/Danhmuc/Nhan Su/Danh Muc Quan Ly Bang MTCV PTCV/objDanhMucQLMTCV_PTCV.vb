Public Class objDanhMucQLMTCV_PTCV
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
            Return Me.m_sDV_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sDV_MA = Value
        End Set
    End Property
    Public Property NHOMCV_MA() As String
        Get
            Return Me.m_sNHOMCV_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sNHOMCV_MA = Value
        End Set
    End Property
    Public Property NHOMCV_TEN() As String
        Get
            Return Me.m_sNHOMCV_TEN
        End Get
        Set(ByVal Value As String)
            Me.m_sNHOMCV_TEN = Value
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
    Public Property NHOMCV_TT() As Integer
        Get
            Return Me.m_sNHOMCV_TT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNHOMCV_TT = Value
        End Set
    End Property
    Public Property NHOMCV_DOCHAI() As Integer
        Get
            Return Me.m_sNHOMCV_DOCHAI
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNHOMCV_DOCHAI = Value
        End Set
    End Property
    Public Property NHOMCV_TINHTRANG() As Integer
        Get
            Return Me.m_sNHOMCV_TINHTRANG
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNHOMCV_TINHTRANG = Value
        End Set
    End Property
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal NHOMCV_MA_ As String, ByVal NHOMCV_TEN_ As String, ByVal GHICHU_ As String, ByVal NHOMCV_TT_ As Integer, ByVal NHOMCV_TINHTRANG_ As Integer) As Boolean
        Me.NHOMCV_MA = NHOMCV_MA_
        Me.NHOMCV_TEN = NHOMCV_TEN_
        Me.GHICHU = GHICHU_
        Me.NHOMCV_TT = NHOMCV_TT_
        Me.NHOMCV_TINHTRANG = NHOMCV_TINHTRANG_
    End Function
    Public m_sChonTable As Integer
    Public m_sDV_MA As String
    Public m_sNHOMCV_MA As String
    Public m_sGHICHU As String
    Public m_sNHOMCV_TEN As String
    Public m_sNHOMCV_DOCHAI As Integer
    Public m_sNHOMCV_TT As Integer
    Public m_sNHOMCV_TINHTRANG As Integer

End Class
