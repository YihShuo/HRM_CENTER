
Public Class objGioCongTieuChuanThang
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.IDDonVi = ""
        Me.IDThang = ""
        Me.CauTruyVan = ""
        Me.Table = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sIDDonVi As String, ByVal m_sIDThang As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.IDDonVi = m_sIDDonVi
        Me.IDThang = m_sIDThang
        Me.Table = m_sTable
        Me.CauTruyVan = m_sTruyVan
        Me.ChonBang = m_sChonTable
        Return False
    End Function

    ' Properties
    Public Property IDDonVi() As String
        Get
            Return Me.m_sIDDonVi
        End Get
        Set(ByVal Value As String)
            Me.m_sIDDonVi = Value
        End Set
    End Property

    Public Property IDThang() As String
        Get
            Return Me.m_sIDThang
        End Get
        Set(ByVal Value As String)
            Me.m_sIDThang = Value
        End Set
    End Property

    Public Property CauTruyVan() As String
        Get
            Return Me.m_sTruyVan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyVan = Value
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

    ' Fields
    Public m_sIDDonVi As String
    Public m_sIDThang As String
    Public m_sTruyVan As String
    Public m_sTable As String
    Public m_sChonTable As Integer

End Class
