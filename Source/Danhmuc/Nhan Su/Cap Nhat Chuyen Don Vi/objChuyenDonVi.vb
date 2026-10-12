Public Class objChuyenDonVi
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal pten As String, ByVal pdonvi As String, ByVal pngayvao As String, ByVal pmatu As String, ByVal m_ChonTable As Integer, ByVal p_sNguoicapnhat As String) As Boolean
        Me.MaNV = pmanv
        Me.TenNV = pten
        Me.DonVi = pdonvi
        Me.NgayVao = pngayvao
        Me.MaTu = pmatu
        Me.ChonBang = m_sChonTable
        Me.NguoiCapNhat = p_sNguoicapnhat
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
    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
        End Set
    End Property
    Public Property TenNV() As String
        Get
            Return Me.m_sTenNV
        End Get
        Set(ByVal Value As String)
            Me.m_sTenNV = Value
        End Set
    End Property
    Public Property DonVi() As String
        Get
            Return Me.m_sDonVi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonVi = Value
        End Set
    End Property
    Public Property NgayVao() As String
        Get
            Return Me.m_sNgayVao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayVao = Value
        End Set
    End Property
    Public Property MaTu() As String
        Get
            Return Me.m_sMaTu
        End Get
        Set(ByVal Value As String)
            Me.m_sMaTu = Value
        End Set
    End Property
   
    Public Property NguoiCapNhat() As String
        Get
            Return Me.m_sNguoiCapNhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoiCapNhat = Value
        End Set
    End Property

    Public m_sMaNV As String
    Public m_sTenNV As String
    Public m_sDonVi As String
    Public m_sNgayVao As String
    Public m_sMaTu As String
    Public m_sChonTable As Integer
    Public m_sNguoiCapNhat As String

End Class
