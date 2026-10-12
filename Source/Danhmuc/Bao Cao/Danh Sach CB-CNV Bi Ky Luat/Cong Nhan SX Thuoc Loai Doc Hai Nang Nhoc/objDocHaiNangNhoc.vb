Public Class objDocHaiNangNhoc

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Table = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ID = m_sID
        Me.MANV = m_sMA
        Me.Table = m_sTable
        Me.Xuong = m_sXuong
        Me.Khu = m_sKhu
        Me.Nganh = m_sNganh
        Me.DonVi = m_sDonVi
        Me.STT = m_sSTT
        Me.ChonBang = m_sChonTable
        Return False
    End Function

    ' Properties
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property
    Public Property MANV() As String
        Get
            Return Me.m_sMA
        End Get
        Set(ByVal Value As String)
            Me.m_sMA = Value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal Value As String)
            Me.m_sTable = Value
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

    Public Property Xuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property Khu() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
    Public Property Nganh() As String
        Get
            Return Me.m_sNganh
        End Get
        Set(ByVal Value As String)
            Me.m_sNganh = Value
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
    Public Property STT() As Integer
        Get
            Return Me.m_sSTT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSTT = Value
        End Set
    End Property

    ' Fields
    Public m_sID As String
    Public m_sTable As String
    Public m_sXuong As String
    Public m_sNganh As String
    Public m_sDonVi As String
    Public m_sMA As String
    Public m_sKhu As String
    Public m_sChonTable As Integer
    Public m_sSTT As Integer
End Class
