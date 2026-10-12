Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_CongViec
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MACONGVIEC = ""
        Me.TENCONGVIEC = ""
        Me.DOCHAI = 0
        Me.TRUCTIEP = 0
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaCongViec As String, ByVal TenCongViec As String, ByVal DH As Boolean, ByVal TT As Boolean) As Boolean
        Me.MACONGVIEC = MaCongViec
        Me.TENCONGVIEC = TenCongViec
        If DH = True Then
            m_sDOCHAI = 1
        Else
            m_sDOCHAI = 0
        End If
        If TT = True Then
            m_sTRUCTIEP = 1
        Else
            m_sTRUCTIEP = 0
        End If
        Return False
    End Function
    Public Property MACONGVIEC() As String
        Get
            Return Me.m_sMACONGVIEC
        End Get
        Set(ByVal Value As String)
            Me.m_sMACONGVIEC = Value
        End Set
    End Property

    Public Property TENCONGVIEC() As String
        Get
            Return Me.m_sTENCONGVIEC
        End Get
        Set(ByVal Value As String)
            Me.m_sTENCONGVIEC = Value
        End Set
    End Property
    Public Property DOCHAI() As Integer
        Get
            Return Me.m_sDOCHAI
        End Get
        Set(ByVal Value As Integer)
            Me.m_sDOCHAI = Value
        End Set
    End Property
    Public Property TRUCTIEP() As Integer
        Get
            Return Me.m_sTRUCTIEP
        End Get
        Set(ByVal Value As Integer)
            Me.m_sTRUCTIEP = Value
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
        Return (StringType.StrCmp(Me.MACONGVIEC, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENCONGVIEC, "", False) <> 0)
    End Function

    Public m_sMACONGVIEC As String
    Public m_sDOCHAI As Integer
    Public m_sTRUCTIEP As Integer
    Public m_sTENCONGVIEC As String
    Public m_sChonTable As Integer
End Class
