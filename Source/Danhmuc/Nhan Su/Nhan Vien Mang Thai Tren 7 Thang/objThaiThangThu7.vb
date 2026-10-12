
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThaiThangThu7
    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Table = ""
        Me.DonVi = ""
        Me.MaNV = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sTable As String, ByVal pdonvi As String, ByVal pmanv As String, ByVal pngay As String, ByVal pdenngay As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.DonVi = pdonvi
        Me.MaNV = pmanv
        Me.NGAY = pngay
        Me.DENNGAY = pdenngay
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

    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
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

    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
        End Set
    End Property

    Public Property NGAY() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property

    Public Property THANG() As String
        Get
            Return Me.m_sTHANG
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG = Value
        End Set
    End Property
    Public Property DENNGAY() As String
        Get
            Return Me.m_sDenNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgay = Value
        End Set
    End Property
    Public Property TUNGAYLUOI() As String
        Get
            Return Me.m_sTNLUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTNLUOI = Value
        End Set
    End Property
    Public Property DENNGAYLUOI() As String
        Get
            Return Me.m_sDNLUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sDNLUOI = Value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_sTruyVan As String
    Public m_sIDTuan As String
    Public m_sTable As String
    Public m_sDonVi As String
    Public m_sMaNV As String
    Public m_sNgay As String
    Public m_sDenNgay As String
    Public m_sTNLUOI As String
    Public m_sDNLUOI As String
    Public m_sTHANG As String
    Public m_sChonTable As Integer
End Class


