Public Class objThongKeCN_TT_GT
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.Table = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.Table = m_sTable
        Me.ChonBang = m_sChonTable
        Return False
    End Function

    ' Properties
    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal Value As String)
            Me.m_sTable = Value
        End Set
    End Property
    Public Property ChonKhu() As String
        Get
            Return Me.m_sChonKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sChonKhu = Value
        End Set
    End Property
    Public Property TinhCNM() As Integer
        Get
            Return Me.m_iTinhCNM
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTinhCNM = Value
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
    Public Property ThangNam() As String
        Get
            Return Me.m_sThangNam
        End Get
        Set(ByVal Value As String)
            Me.m_sThangNam = Value
        End Set
    End Property
    ' Fields
    Public m_sTable As String
    Public m_sChonTable As Integer
    Public m_sThangNam As String
    Public m_sChonKhu As String
    Public m_iTinhCNM As Integer
End Class
