Public Class objCapnhatMSTSTK
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal pcmnd As String, ByVal pmasothue As String, ByVal psotaikhoan As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaNV = pmanv
        Me.CMND = pcmnd
        Me.MASOTHUE = pmasothue
        Me.SOTAIKHOAN = psotaikhoan
        Me.ChonBang = m_sChonTable
        ' Me.SQL = sql
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
    Public Property CMND() As String
        Get
            Return Me.m_sCMND
        End Get
        Set(ByVal Value As String)
            Me.m_sCMND = Value
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
    Public Property MASOTHUE() As String
        Get
            Return Me.m_sMST
        End Get
        Set(ByVal Value As String)
            Me.m_sMST = Value
        End Set
    End Property

    Public Property SOTAIKHOAN() As String
        Get
            Return Me.m_sSTK
        End Get
        Set(ByVal Value As String)
            Me.m_sSTK = Value
        End Set
    End Property
    Public Property SQL As String
        Get
            Return Me.m_sSql
        End Get
        Set(ByVal value As String)
            Me.m_sSql = value
        End Set
    End Property

    Public m_sMaNV As String
    Public m_sCMND As String
    Public m_sDonVi As String
    Public m_sNgayVao As String
    Public m_sMST As String
    Public m_sSTK As String
    Public m_sChonTable As Integer
    Public m_sSql As String
End Class
