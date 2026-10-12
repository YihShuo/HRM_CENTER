Public Class objNhaXuong
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanx As String, ByVal ptennx As String, ByVal pstt As String, ByVal pghichu As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaNX = pmanx
        Me.TenNX = ptennx
        Me.SoThuTu = pstt
        Me.GhiChu = pghichu
        Me.ChonBang = m_sChonTable
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
    Public Property MaNX() As String
        Get
            Return Me.m_sMaNX
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNX = Value
        End Set
    End Property
    Public Property TenNX() As String
        Get
            Return Me.m_sTenNX
        End Get
        Set(ByVal Value As String)
            Me.m_sTenNX = Value
        End Set
    End Property
    Public Property SoThuTu() As Integer
        Get
            Return Me.m_sSTT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSTT = Value
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
    Public m_sMaNX As String
    Public m_sTenNX As String
    Public m_sSTT As Integer
    Public m_sGhiChu As String
    Public m_sChonTable As Integer
End Class
