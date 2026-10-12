Public Class objKhamSK
    
    Public Property SOTHE() As String
        Get
            Return Me.m_sSOTHE
        End Get
        Set(ByVal Value As String)
            Me.m_sSOTHE = Value
        End Set
    End Property

    Public Property LOAI() As String
        Get
            Return Me.m_sLOAI
        End Get
        Set(ByVal Value As String)
            Me.m_sLOAI = Value
        End Set
    End Property

    Public Property DOT() As String
        Get
            Return Me.m_sDOT
        End Get
        Set(ByVal Value As String)
            Me.m_sDOT = Value
        End Set
    End Property

    Public Property NAM() As Integer
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNAM = Value
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

    Public m_sSOTHE As String
    Public m_sLOAI As String
    Public m_sDOT As String
    Public m_sNAM As String
    Public m_sChonTable As Integer
End Class
