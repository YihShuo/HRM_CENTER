Public Class objThongKeTroCapUDMay
    Public Overridable Function Setnull() As Boolean
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
    Public Property Tencot() As String
        Get
            Return Me.m_sTencot
        End Get
        Set(ByVal Value As String)
            Me.m_sTencot = Value
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
    Public Property Chuoitinhtong() As String
        Get
            Return Me.m_sChuoitinhtong
        End Get
        Set(ByVal Value As String)
            Me.m_sChuoitinhtong = Value
        End Set
    End Property
    Public Property HD_TrocapUD() As String
        Get
            Return Me.m_dHD_TrocapUDMay
        End Get
        Set(ByVal Value As String)
            Me.m_dHD_TrocapUDMay = Value
        End Set
    End Property


    Public m_sDV As String
    Public m_sXuong As String
    Public m_dHD_TrocapUDMay As String
    Public m_sChonTable As Integer
    Public m_sTencot As String
    Public m_sChuoitinhtong As String
    Public m_sChonKhu As String
End Class
