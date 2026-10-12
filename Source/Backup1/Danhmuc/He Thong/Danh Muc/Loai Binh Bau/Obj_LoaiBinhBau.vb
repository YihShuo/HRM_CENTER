Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_LoaiBinhBau
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MALOAIBINHBAU = ""
        Me.SOTIEN = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaLoaiBinhBau As String, ByVal SoTien As String, ByVal GhiChu As String) As Boolean
        Me.MALOAIBINHBAU = MaLoaiBinhBau
        Me.SOTIEN = SoTien
        Me.GHICHU = GhiChu
        Return False
    End Function

    Public Property MALOAIBINHBAU() As String
        Get
            Return Me.m_sMALOAIBINHBAU
        End Get
        Set(ByVal Value As String)
            Me.m_sMALOAIBINHBAU = Value
        End Set
    End Property

    Public Property SOTIEN() As String
        Get
            Return Me.m_sSOTIEN
        End Get
        Set(ByVal Value As String)
            Me.m_sSOTIEN = Value
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
        Return (StringType.StrCmp(Me.MALOAIBINHBAU, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.SOTIEN, "", False) <> 0)
    End Function

    Public m_sMALOAIBINHBAU As String
    Public m_sSOTIEN As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class
