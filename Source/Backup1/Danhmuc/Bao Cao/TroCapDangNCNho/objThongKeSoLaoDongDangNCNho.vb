Public Class objThongKeSoLaoDongDangNCNho
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Property NgayDD() As String
        Get
            Return Me.m_sNgayDD
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayDD = Value
        End Set
    End Property
    Public Property Doi1USD() As String
        Get
            Return Me.m_sDoi1USD
        End Get
        Set(ByVal Value As String)
            Me.m_sDoi1USD = Value
        End Set
    End Property
    Public Property DongTongKhuA() As Integer
        Get
            Return Me.m_iDongTongKhuA
        End Get
        Set(ByVal Value As Integer)
            Me.m_iDongTongKhuA = Value
        End Set
    End Property
    Public Property DongTongKhuB() As Integer
        Get
            Return Me.m_iDongTongKhuB
        End Get
        Set(ByVal Value As Integer)
            Me.m_iDongTongKhuB = Value
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
    Public Property T_Ma() As String
        Get
            Return Me.m_sThangHienTai
        End Get
        Set(ByVal Value As String)
            Me.m_sThangHienTai = Value
        End Set
    End Property
    Public Property T_Ma_Truoc() As String
        Get
            Return Me.m_sThangTruoc
        End Get
        Set(ByVal Value As String)
            Me.m_sThangTruoc = Value
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


    Public m_sDV As String
    Public m_sXuong As String
    Public m_sNam As String
    Public m_sChonTable As Integer
    Public m_sThang As String
    Public m_sNgay As String
    Public m_iDongTongKhuA As Integer
    Public m_iDongTongKhuB As Integer
    Public m_iDongTCT As Integer
    Public m_sDoi1USD As String
    Public m_sThangTruoc As String
    Public m_sThangHienTai As String
    Public m_sNgayDD As String
End Class
