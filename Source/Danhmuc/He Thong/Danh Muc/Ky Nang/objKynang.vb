Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objKynang
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MAKYNANG = ""
        Me.TENKYNANG = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaKyNang As String, ByVal TenKyNang As String, ByVal ghichu As String) As Boolean
        Me.MAKYNANG = MaKyNang
        Me.TENKYNANG = TenKyNang
        Me.GHICHU = ghichu
        Return False
    End Function

    Public Property MAKYNANG() As String
        Get
            Return Me.m_sMAKYNANG
        End Get
        Set(ByVal Value As String)
            Me.m_sMAKYNANG = Value
        End Set
    End Property

    Public Property TENKYNANG() As String
        Get
            Return Me.m_sTENKYNANG
        End Get
        Set(ByVal Value As String)
            Me.m_sTENKYNANG = Value
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
        Return (StringType.StrCmp(Me.MAKYNANG, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENKYNANG, "", False) <> 0)
    End Function

    Public m_sMAKYNANG As String
    Public m_sTENKYNANG As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class
