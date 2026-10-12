Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_NgoaiNgu
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MANGOAINGU = ""
        Me.TENNGOAINGU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaNgoaiNgu As String, ByVal TenNgoaiNgu As String) As Boolean
        Me.MANGOAINGU = MaNgoaiNgu
        Me.TENNGOAINGU = TenNgoaiNgu
        Return False
    End Function

    Public Property MANGOAINGU() As String
        Get
            Return Me.m_sMANGOAINGU
        End Get
        Set(ByVal Value As String)
            Me.m_sMANGOAINGU = Value
        End Set
    End Property

    Public Property TENNGOAINGU() As String
        Get
            Return Me.m_sTENNGOAINGU
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNGOAINGU = Value
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
        Return (StringType.StrCmp(Me.MANGOAINGU, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENNGOAINGU, "", False) <> 0)
    End Function

    Public m_sMANGOAINGU As String
    Public m_sTENNGOAINGU As String
    Public m_sChonTable As Integer
End Class
