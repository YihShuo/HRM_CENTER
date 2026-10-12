Public Class objNhanVienKyLuatNghiKhongPhep
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.Nam = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal TEN As String, ByVal m_ChonTable As Integer) As Boolean
        Me.TENTAIWAN = TEN
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property TENTAIWAN() As String
        Get
            Return Me.m_sTENTW
        End Get
        Set(ByVal Value As String)
            Me.m_sTENTW = Value
        End Set
    End Property
    Public Property MA() As String
        Get
            Return Me.m_sMA
        End Get
        Set(ByVal Value As String)
            Me.m_sMA = Value
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

    Public Property NBDKL() As String
        Get
            Return Me.m_sNBDKL
        End Get
        Set(ByVal Value As String)
            Me.m_sNBDKL = Value
        End Set
    End Property
    Public Property NKTKL() As String
        Get
            Return Me.m_sNKTKL
        End Get
        Set(ByVal Value As String)
            Me.m_sNKTKL = Value
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
    Public m_sNBD As String
    Public m_sNKT As String
    Public m_sNBDKL As String
    Public m_sNKTKL As String
    Public m_sTENTW As String
    Public m_sMA As String
    Public m_sChonTable As Integer
End Class
