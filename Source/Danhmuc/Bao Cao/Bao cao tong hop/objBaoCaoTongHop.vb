Public Class objBaoCaoTongHop
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public Property ThangMax() As Integer
        Get
            Return Me.m_iThangMax
        End Get
        Set(ByVal Value As Integer)
            Me.m_iThangMax = Value
        End Set
    End Property
    Public Property Nam() As String
        Get
            Return Me.m_iNam
        End Get
        Set(ByVal Value As String)
            Me.m_iNam = Value
        End Set
    End Property
    Public Property TinhCNM() As Integer
        Get
            Return Me.m_iTinhCNM
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTinhCNM = Value
        End Set
    End Property
    Public Property Chonkhu() As String
        Get
            Return Me.m_schonkhu
        End Get
        Set(ByVal Value As String)
            Me.m_schonkhu = Value
        End Set
    End Property
    Public m_sNGAY As String
    Public m_sDV As String
    Public m_sXuong As String
    Public m_iThangMax As Integer
    Public m_sChonTable As Integer
    Public m_iNam As String
    Public m_iTinhCNM As Integer
    Public m_schonkhu As String
End Class
