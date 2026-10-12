Public Class objNhapKT
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MaKT = ""
        Me.TenKT = ""
        Me.GhiChu = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmakt As String, ByVal ptenkt As String, ByVal pghichu As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaKT = pmakt
        Me.TenKT = ptenkt
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
    Public Property MaKT() As String
        Get
            Return Me.m_sMaKT
        End Get
        Set(ByVal Value As String)
            Me.m_sMaKT = Value
        End Set
    End Property
    Public Property TenKT() As String
        Get
            Return Me.m_sTenKT
        End Get
        Set(ByVal Value As String)
            Me.m_sTenKT = Value
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
    Public m_sMaKT As String
    Public m_sTenKT As String
    Public m_sGhiChu As String
    Public m_sChonTable As Integer
End Class
