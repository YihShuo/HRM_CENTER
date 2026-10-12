Public Class objLyLichNhanVien
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.MaNV = ""
        Me.CongViec = ""
        Me.ChucVu = ""
        Me.DHNN = 0
        Me.ChonBang = 0
        Return flag
    End Function
    ' MOI QUAN HE
    Public Overridable Function setvalue(ByVal p_ma As String, ByVal p_congviec As String, ByVal p_chucvu As String, ByVal p_ngay As String, ByVal p_dhnn As Integer) As Boolean
        Me.ID = m_sID
        Me.MaNV = p_ma
        Me.CongViec = p_congviec
        Me.ChucVu = p_chucvu
        Me.NgayBoNhiem = p_ngay
        If p_dhnn = 0 Then
            m_sDHNN = 0
        Else
            m_sDHNN = 1
        End If
        Me.DHNN = m_sDHNN
        Return False
    End Function

    ' Properties HO SO NHAN VIEN
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
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
    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
        End Set
    End Property
   
    Public Property CongViec() As String
        Get
            Return Me.m_sCongViec
        End Get
        Set(ByVal Value As String)
            Me.m_sCongViec = Value
        End Set
    End Property
    Public Property ChucVu() As String
        Get
            Return Me.m_sChucVu
        End Get
        Set(ByVal Value As String)
            Me.m_sChucVu = Value
        End Set
    End Property
    Public Property NgayBoNhiem() As String
        Get
            Return Me.m_sNgayBoNhiem
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayBoNhiem = Value
        End Set
    End Property
    Public Property DHNN() As Integer
        Get
            Return Me.m_sDHNN
        End Get
        Set(ByVal Value As Integer)
            Me.m_sDHNN = Value
        End Set
    End Property

    Public Property SQL() As String
        Get
            Return Me.m_sSql
        End Get
        Set(ByVal value As String)
            Me.m_sSql = value
        End Set
    End Property

    ' Fields HO SO NHAN VIEN
    Public m_sID As String
    Public m_sMaNV As String
    Public m_sCongViec As String
    Public m_sChucVu As String
    Public m_sNgayBoNhiem As String
    Public m_sDHNN As Integer
    Public m_sChonTable As String
    Public m_sSql As String
End Class
