Public Class objNhapDBLuong
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.LUONG = ""
        Me.FlagChamCong = False
        Me.SoQD = ""
        Me.PhuCap = ""
        Me.HESO = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal l As String, ByVal so As String, ByVal pc As String, ByVal hs As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.LUONG = l
        Me.SoQD = so
        Me.PhuCap = pc
        Me.HESO = hs
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
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
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

    Public Property HESO() As String
        Get
            Return Me.m_sHESO
        End Get
        Set(ByVal Value As String)
            Me.m_sHESO = Value
        End Set
    End Property
    Public Property LUONG() As String
        Get
            Return Me.m_sLUONGCB
        End Get
        Set(ByVal Value As String)
            Me.m_sLUONGCB = Value
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
    Public Property SoQD() As String
        Get
            Return Me.m_sSoQD
        End Get
        Set(ByVal Value As String)
            Me.m_sSoQD = Value
        End Set
    End Property
    Public Property PhuCap() As String
        Get
            Return Me.m_sPhuCap
        End Get
        Set(ByVal Value As String)
            Me.m_sPhuCap = Value
        End Set
    End Property

    Public Property FlagChamCong() As Boolean
        Get
            Return Me.m_bChamcong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChamcong = Value
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
    Public m_sLUONGCB As String
    Public m_sDV As String
    Public m_sSoQD As String
    Public m_sHESO As String
    Public m_sPhuCap As String
    Public m_sNGAY As String
    Public m_sNAM As String
    Public m_sChonTable As Integer
    Public m_bChamcong As Boolean
End Class
