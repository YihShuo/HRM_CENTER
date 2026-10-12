Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ObjBaoCaoGioCongNgay
    Public Function KTMa() As Boolean
        Return (StringType.StrCmp(Me.ID, "", False) <> 0)
    End Function

    Public Overridable Function Setnull() As Boolean
        Me.MADV = ""  'ma don vi
        Me.MANX = ""  'ma nha xuong
        Dim flag As Boolean
        Me.ID = ""
        Me.CauTruyVan = ""
        Me.ChonBang = 0
        Me.m_khu = ""
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sExSQL As String, ByVal m_sID As String, ByVal MADONVI As String, ByVal MAXUONG As String, ByVal m_ChonTable As Integer, ByVal khu As String) As Boolean
        Me.ID = m_sID
        Me.ChonBang = m_sChonTable
        Me.CauTruyVan = m_sExSQL

        Me.MADV = MADONVI
        Me.MANX = MAXUONG
        Me.KHU = khu
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

    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property

    Public Property CauTruyVan() As String
        Get
            Return Me.m_sExSQL
        End Get
        Set(ByVal Value As String)
            Me.m_sExSQL = Value
        End Set
    End Property
    Public Property MADV() As String
        Get
            Return Me.m_sMADV
        End Get
        Set(ByVal Value As String)
            Me.m_sMADV = Value
        End Set
    End Property
    'lay ra ngay,thang,nam trong datetime picker
    Public Property NGAY() As DateTime
        Get
            Return Me.m_dNgay
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dNgay = Value
        End Set
    End Property
    'lay ngay trong textbox (tuan)
    Public Property NGAY1() As DateTime
        Get
            Return Me.m_dNgay1
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dNgay1 = Value
        End Set
    End Property
    Public Property NGAY2() As DateTime
        Get
            Return Me.m_dNgay2
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dNgay2 = Value
        End Set
    End Property
    Public Property NGAYTHANGNAM() As DateTime
        Get
            Return Me.m_dNgaythangnam
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dNgaythangnam = Value
        End Set
    End Property

    Public Property MANX() As String
        Get
            Return Me.m_s_MANX
        End Get
        Set(ByVal Value As String)
            Me.m_s_MANX = Value
        End Set
    End Property
    Public Property KHU As String
        Get
            Return m_khu
        End Get
        Set(ByVal value As String)
            Me.m_khu = value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_sExSQL As String
    'Public m_sTable As String
    Public m_sChonTable As Integer
    Public m_sMADV As String
    Public m_s_MANX As String
    Public m_dNgay As DateTime
    Public m_dNgay1 As DateTime
    Public m_dNgay2 As DateTime
    Public m_dNgaythangnam As DateTime
    Public m_khu As String
End Class

