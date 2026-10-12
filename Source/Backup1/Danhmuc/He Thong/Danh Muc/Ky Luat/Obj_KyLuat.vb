Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_KyLuat
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MAKYLUAT = ""
        Me.TENKYLUAT = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaKyLuat As String, ByVal TenKyLuat As String) As Boolean
        Me.MAKYLUAT = MaKyLuat
        Me.TENKYLUAT = TenKyLuat
        Return False
    End Function

    Public Property MAKYLUAT() As String
        Get
            Return Me.m_sMAKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sMAKYLUAT = Value
        End Set
    End Property

    Public Property TENKYLUAT() As String
        Get
            Return Me.m_sTENKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sTENKYLUAT = Value
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
        Return (StringType.StrCmp(Me.MAKYLUAT, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENKYLUAT, "", False) <> 0)
    End Function

    Public m_sMAKYLUAT As String
    Public m_sTENKYLUAT As String
    Public m_sChonTable As Integer
End Class
