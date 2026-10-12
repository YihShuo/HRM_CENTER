Public Class objPhepNam

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.IDTuan = ""
        Me.CauTruyVan = ""
        Me.Table = ""
        Me.ChonBang = 0
        Me.TinhTrangChonKhu = ""
      
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer, ByVal tinhtrangchonkhu As String, ByVal waitingkhu As String, ByVal nam As String) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.CauTruyVan = m_sTruyVan
        Me.ChonBang = m_sChonTable
        Me.TinhTrangChonKhu = tinhtrangchonkhu
        Me.WaitingKhu = waitingkhu
        Me.Nam = nam
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

    Public Property IDTuan() As String
        Get
            Return Me.m_sIDTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sIDTuan = Value
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

    Public Property TinhTrangChonKhu As String
        Get
            Return m_sTinhTrangChonKhu
        End Get
        Set(ByVal value As String)
            Me.m_sTinhTrangChonKhu = value
        End Set
    End Property
    Public Property WaitingKhu As String
        Get
            Return m_sWaitingKhu
        End Get
        Set(ByVal value As String)
            Me.m_sWaitingKhu = value
        End Set
    End Property
    Public Property Nam As String
        Get
            Return m_sNam
        End Get
        Set(ByVal value As String)
            Me.m_sNam = value
        End Set
    End Property
    ' Fields
    Public m_sID As String
    Public m_sTruyVan As String
    Public m_sIDTuan As String
    Public m_sTable As String
    Public m_sChonTable As Integer
    Public m_sTinhTrangChonKhu As String
    Public Shared m_sWaitingKhu As String
    Public Shared m_sNam As String

End Class
