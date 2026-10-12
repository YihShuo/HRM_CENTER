Public Class objTongHopComThang
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.NGAY = ""
        Me.Nam = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
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
    Public Property THANG() As String
        Get
            Return Me.m_sTHANG
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG = Value
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

    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public m_sNGAY As String
    Public m_sDV As String
    Public m_sNam As String
    Public m_sTHANG As String
    Public m_sChonTable As Integer
End Class
