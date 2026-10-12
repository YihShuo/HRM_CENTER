Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objChungChiK
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MACHUNGCHI = ""
        Me.TENCHUNGCHI = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaChungChi As String, ByVal TenChungChi As String, ByVal GhiChu As String) As Boolean
        Me.MACHUNGCHI = MaChungChi
        Me.TENCHUNGCHI = TenChungChi
        Me.GHICHU = GhiChu
        Return False
    End Function

    Public Property MACHUNGCHI() As String
        Get
            Return Me.m_sMACHUNGCHI
        End Get
        Set(ByVal Value As String)
            Me.m_sMACHUNGCHI = Value
        End Set
    End Property

    Public Property TENCHUNGCHI() As String
        Get
            Return Me.m_sTENCHUNGCHI
        End Get
        Set(ByVal Value As String)
            Me.m_sTENCHUNGCHI = Value
        End Set
    End Property
    Public Property GHICHU() As String
        Get
            Return Me.m_sGHICHU
        End Get
        Set(ByVal Value As String)
            Me.m_sGHICHU = Value
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
        Return (StringType.StrCmp(Me.MACHUNGCHI, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENCHUNGCHI, "", False) <> 0)
    End Function

    Public m_sMACHUNGCHI As String
    Public m_sTENCHUNGCHI As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class

