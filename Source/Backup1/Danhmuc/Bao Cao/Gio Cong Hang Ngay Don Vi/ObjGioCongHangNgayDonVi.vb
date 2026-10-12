Public Class ObjGioCongHangNgayDonVi
    Public Overridable Function setvalue(ByVal m_ChonTable As Integer, ByVal sThang As String, ByVal sNam As String, ByVal sT_MA As String, ByVal sDV As String) As Boolean
        Me.ChonBang = m_sChonTable
        Me.THANG = sThang
        Me.NAM = sNam
        Me.T_MA = sT_MA
        Me.DV = sDV
        Return False
    End Function
    Public Overridable Function Setnull() As Boolean
        Me.THANG = ""
        Me.NAM = ""
        Me.T_MA = ""
        Me.DV = ""
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
    Public Property THANG() As String
        Get
            Return Me.m_sThang
        End Get
        Set(ByVal Value As String)
            Me.m_sThang = Value
        End Set
    End Property
    Public Property NAM() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property
    Public Property T_MA() As String
        Get
            Return Me.m_sT_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sT_MA = Value
        End Set
    End Property
    Public Property DV() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property CHONKHU() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
    Public m_sChonTable As Integer
    Public m_sThang As String
    Public m_sKhu As String
    Public m_sNam As String
    Public m_sT_MA As String
    Public m_sDV As String

End Class
