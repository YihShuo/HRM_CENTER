Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objChuyenDV

    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MANV = ""
        Me.NGAYCD = ""
        Me.DVCU = ""
        Me.CVUCU = ""
        Me.DVMOI = ""
        Me.CVUMOI = ""
        Me.NGAYCD_LUOI = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaNhanVien As String, ByVal NgayCD As String, ByVal DVCu As String, ByVal CVuCu As String, ByVal DVMoi As String, ByVal CVuMoi As String) As Boolean
        Me.MANV = MaNhanVien
        Me.NGAYCD = NgayCD
        Me.DVCU = DVCu
        Me.CVUCU = CVuCu
        Me.DVMOI = DVMoi
        Me.CVUMOI = CVuMoi
        Return False
    End Function
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
        End Set
    End Property

    Public Property NGAYCD() As String
        Get
            Return Me.m_sNGAYCD
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCD = Value
        End Set
    End Property

    Public Property DVCU() As String
        Get
            Return Me.m_sDVCU
        End Get
        Set(ByVal Value As String)
            Me.m_sDVCU = Value
        End Set
    End Property
    Public Property DVMOI() As String
        Get
            Return Me.m_sDVMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sDVMOI = Value
        End Set
    End Property
    Public Property CVUCU() As String
        Get
            Return Me.m_sCVUCU
        End Get
        Set(ByVal Value As String)
            Me.m_sCVUCU = Value
        End Set
    End Property
    Public Property CVUMOI() As String
        Get
            Return Me.m_sCVUMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sCVUMOI = Value
        End Set
    End Property

    Public Property NGAYCD_LUOI() As String
        Get
            Return Me.m_sNGAYCD_LUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCD_LUOI = Value
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
    Public Property DONVICBX() As String
        Get
            Return Me.m_sDONVICBX
        End Get
        Set(ByVal Value As String)
            Me.m_sDONVICBX = Value
        End Set
    End Property
    Public Function KtMa() As Boolean
        Return (StringType.StrCmp(Me.MANV, "", False) <> 0)
    End Function


    Public m_sMANV As String
    Public m_sNGAYCD As String
    Public m_sDVCU As String
    Public m_sDVMOI As String
    Public m_sCVUCU As String
    Public m_sCVUMOI As String
    Public m_sDONVICBX As String
    Public m_sNGAYCD_LUOI As String
    Public m_sChonTable As Integer

End Class
