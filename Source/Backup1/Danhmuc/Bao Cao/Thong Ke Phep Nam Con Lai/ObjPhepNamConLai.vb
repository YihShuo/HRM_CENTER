Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class ObjPhepNamConLai
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.NAM = ""
        Me.MANV = ""
        Me.TENNV = ""
        Me.XUONG = ""
        Me.NAMTRUOC = ""
        Me.NAMNAY = ""
        Me.DANGHI = ""
        Me.DHNN = ""
        Me.THAMNIEN = ""
        Me.CONLAI = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal Nam As String, ByVal MaNV As String, ByVal TenNV As String, ByVal Xuong As String, ByVal NamTruoc As String, ByVal NamNay As String, ByVal DaNghi As String, ByVal DocHaiNangNhoc As String, ByVal ThamNien As String, ByVal ConLai As String) As Boolean
        Me.NAM = Nam
        Me.MANV = MaNV
        Me.TENNV = TenNV
        Me.XUONG = Xuong
        Me.NAMTRUOC = NamTruoc
        Me.NAMNAY = NamNay
        Me.DANGHI = DaNghi
        Me.DHNN = DocHaiNangNhoc
        Me.THAMNIEN = ThamNien
        Me.CONLAI = ConLai
        Return False
    End Function

    Public Property NAM() As String
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal Value As String)
            Me.m_sNAM = Value
        End Set
    End Property

    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
        End Set
    End Property

    Public Property TENNV() As String
        Get
            Return Me.m_sTENNV
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNV = Value
        End Set
    End Property

    Public Property XUONG() As String
        Get
            Return Me.m_sXUONG
        End Get
        Set(ByVal Value As String)
            Me.m_sXUONG = Value
        End Set
    End Property

    Public Property NAMTRUOC() As String
        Get
            Return Me.m_sNAMTRUOC
        End Get
        Set(ByVal Value As String)
            Me.m_sNAMTRUOC = Value
        End Set
    End Property

    Public Property NAMNAY() As String
        Get
            Return Me.m_sNAMNAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNAMNAY = Value
        End Set
    End Property

    Public Property DANGHI() As String
        Get
            Return Me.m_sDANGHI
        End Get
        Set(ByVal Value As String)
            Me.m_sDANGHI = Value
        End Set
    End Property

    Public Property DHNN() As String
        Get
            Return Me.m_sDHNN
        End Get
        Set(ByVal Value As String)
            Me.m_sDHNN = Value
        End Set
    End Property

    Public Property THAMNIEN() As String
        Get
            Return Me.m_sTHAMNIEN
        End Get
        Set(ByVal Value As String)
            Me.m_sTHAMNIEN = Value
        End Set
    End Property

    Public Property CONLAI() As String
        Get
            Return Me.m_sCONLAI
        End Get
        Set(ByVal Value As String)
            Me.m_sCONLAI = Value
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

    Public Function KtMa() As Boolean
        Return (StringType.StrCmp(Me.MANV, "", False) <> 0)
    End Function

    Public m_sNAM As String
    Public m_sMANV As String
    Public m_sTENNV As String
    Public m_sXUONG As String
    Public m_sNAMTRUOC As String
    Public m_sNAMNAY As String
    Public m_sDANGHI As String
    Public m_sDHNN As String
    Public m_sTHAMNIEN As String
    Public m_sCONLAI As String
    Public m_sChonTable As Integer
End Class
