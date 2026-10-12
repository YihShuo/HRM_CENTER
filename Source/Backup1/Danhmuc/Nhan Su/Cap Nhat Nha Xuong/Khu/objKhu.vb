Public Class objKhu
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmakhu As String, ByVal ptenkhu As String, ByVal pstt As String, ByVal pghichu As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaKhu = pmakhu
        Me.TenKhu = ptenkhu
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
    Public Property MaKhu() As String
        Get
            Return Me.m_sMaKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sMaKhu = Value
        End Set
    End Property
    Public Property TenKhu() As String
        Get
            Return Me.m_sTenKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sTenKhu = Value
        End Set
    End Property
    Public Property SoThuTu() As Integer
        Get
            Return Me.m_sThuTu
        End Get
        Set(ByVal Value As Integer)
            Me.m_sThuTu = Value
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
    Public m_sMaKhu As String
    Public m_sTenKhu As String
    Public m_sThuTu As Integer
    Public m_sGhiChu As String
    Public m_sChonTable As Integer
End Class
