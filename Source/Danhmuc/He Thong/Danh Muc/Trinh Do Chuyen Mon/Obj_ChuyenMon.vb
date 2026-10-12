Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_ChuyenMon
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MACHUYENMON = ""
        Me.TENCHUYENMON = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaChuyenMon As String, ByVal TenChuyenMon As String) As Boolean
        Me.MACHUYENMON = MaChuyenMon
        Me.TENCHUYENMON = TenChuyenMon
        Return False
    End Function
    Public Property MACHUYENMON() As String
        Get
            Return Me.m_sMACHUYENMON
        End Get
        Set(ByVal Value As String)
            Me.m_sMACHUYENMON = Value
        End Set
    End Property

    Public Property TENCHUYENMON() As String
        Get
            Return Me.m_sTENCHUYENMON
        End Get
        Set(ByVal Value As String)
            Me.m_sTENCHUYENMON = Value
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
        Return (StringType.StrCmp(Me.MACHUYENMON, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENCHUYENMON, "", False) <> 0)
    End Function

    Public m_sMACHUYENMON As String
    Public m_sTENCHUYENMON As String
    Public m_sChonTable As Integer
End Class
