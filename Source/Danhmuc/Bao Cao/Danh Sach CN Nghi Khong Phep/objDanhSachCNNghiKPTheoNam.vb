Public Class objDanhSachCNNghiKPTheoNam
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_ChonTable As Integer) As Boolean
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property DONVI() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property XUONG() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property KHU() As String
        Get
            Return Me.m_skhu
        End Get
        Set(ByVal Value As String)
            Me.m_skhu = Value
        End Set
    End Property
    Public Property NBD() As String
        Get
            Return Me.m_sNBD
        End Get
        Set(ByVal Value As String)
            Me.m_sNBD = Value
        End Set
    End Property
    Public Property NKT() As String
        Get
            Return Me.m_sNKT
        End Get
        Set(ByVal Value As String)
            Me.m_sNKT = Value
        End Set
    End Property
    Public Property NAM() As String
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal Value As String)
            Me.m_sNAM = Value
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
    Public m_sDV As String
    Public m_sNBD As String
    Public m_sNKT As String
    Public m_sNAM As String
    Public m_skhu As String
    Public m_sXuong As String

    Public m_sChonTable As Integer
End Class
