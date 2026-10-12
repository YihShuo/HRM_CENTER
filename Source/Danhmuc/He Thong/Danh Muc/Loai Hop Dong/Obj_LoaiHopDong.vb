Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_LoaiHopDong
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MALOAIHOPDONG = ""
        Me.TENLOAIHOPDONG = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaLoaiHopDong As String, ByVal TenLoaiHopDong As String) As Boolean
        Me.MALOAIHOPDONG = MaLoaiHopDong
        Me.TENLOAIHOPDONG = TenLoaiHopDong
        Return False
    End Function

    Public Property MALOAIHOPDONG() As String
        Get
            Return Me.m_sMALOAIHOPDONG
        End Get
        Set(ByVal Value As String)
            Me.m_sMALOAIHOPDONG = Value
        End Set
    End Property

    Public Property TENLOAIHOPDONG() As String
        Get
            Return Me.m_sTENLOAIHOPDONG
        End Get
        Set(ByVal Value As String)
            Me.m_sTENLOAIHOPDONG = Value
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
        Return (StringType.StrCmp(Me.MALOAIHOPDONG, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENLOAIHOPDONG, "", False) <> 0)
    End Function

    Public m_sMALOAIHOPDONG As String
    Public m_sTENLOAIHOPDONG As String
    Public m_sChonTable As Integer
End Class
