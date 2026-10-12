Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System


Public Class Obj_NghiPhep
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MANGHIPHEP = ""
        Me.TENNGHIPHEP = ""
        Me.TILEHL = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaNghiPhep As String, ByVal TenNghiPhep As String, ByVal TiLeHL As String) As Boolean
        Me.MANGHIPHEP = MaNghiPhep
        Me.TENNGHIPHEP = TenNghiPhep
        Me.TILEHL = TiLeHL
        Return False
    End Function

    Public Property MANGHIPHEP() As String
        Get
            Return Me.m_sMANGHIPHEP
        End Get
        Set(ByVal Value As String)
            Me.m_sMANGHIPHEP = Value
        End Set
    End Property

    Public Property TENNGHIPHEP() As String
        Get
            Return Me.m_sTENNGHIPHEP
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNGHIPHEP = Value
        End Set
    End Property

    Public Property TILEHL() As String
        Get
            Return Me.m_sTILEHL
        End Get
        Set(ByVal Value As String)
            Me.m_sTILEHL = Value
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
        Return (StringType.StrCmp(Me.MANGHIPHEP, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENNGHIPHEP, "", False) <> 0)
    End Function

    Public m_sMANGHIPHEP As String
    Public m_sTENNGHIPHEP As String
    Public m_sTILEHL As String
    Public m_sChonTable As Integer
End Class
