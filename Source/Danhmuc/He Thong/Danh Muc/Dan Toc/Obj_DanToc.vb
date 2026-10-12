Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_DanToc
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MADANTOC = ""
        Me.TENDANTOC = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaDanToc As String, ByVal TenDanToc As String) As Boolean
        Me.MADANTOC = MaDanToc
        Me.TENDANTOC = TenDanToc
        Return False
    End Function

    Public Property MADANTOC() As String
        Get
            Return Me.m_sMADANTOC
        End Get
        Set(ByVal Value As String)
            Me.m_sMADANTOC = Value
        End Set
    End Property

    Public Property TENDANTOC() As String
        Get
            Return Me.m_sTENDANTOC
        End Get
        Set(ByVal Value As String)
            Me.m_sTENDANTOC = Value
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
        Return (StringType.StrCmp(Me.MADANTOC, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENDANTOC, "", False) <> 0)
    End Function

    Public m_sMADANTOC As String
    Public m_sTENDANTOC As String
    Public m_sChonTable As Integer
End Class
