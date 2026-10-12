
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThongKeNghiPhep

    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.IDTuan = ""
        Me.CauTruyVan = ""
        Me.Table = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.CauTruyVan = m_sTruyVan
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
    Public Property DonVi() As String
        Get
            Return Me.m_sdonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sdonvi = Value
        End Set
    End Property
    Public Property ChucVu() As String
        Get
            Return Me.m_scv
        End Get
        Set(ByVal Value As String)
            Me.m_scv = Value
        End Set
    End Property
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
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
    Public m_sID As String
    Public m_sTruyVan As String
    Public m_sIDTuan As String
    Public m_sTable As String
    Public m_sdonvi As String
    Public m_scv As String
    Public m_sNGAY As String
    Public m_sChonTable As Integer
End Class
