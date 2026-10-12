Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_QuocTich
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MAQUOCTICH = ""
        Me.TENQUOCTICH = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaQuocTich As String, ByVal TenQuocTich As String) As Boolean
        Me.MAQUOCTICH = MaQuocTich
        Me.TENQUOCTICH = TenQuocTich
        Return False
    End Function

    Public Property MAQUOCTICH() As String
        Get
            Return Me.m_sMAQUOCTICH
        End Get
        Set(ByVal Value As String)
            Me.m_sMAQUOCTICH = Value
        End Set
    End Property

    Public Property TENQUOCTICH() As String
        Get
            Return Me.m_sTENQUOCTICH
        End Get
        Set(ByVal Value As String)
            Me.m_sTENQUOCTICH = Value
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
        Return (StringType.StrCmp(Me.MAQUOCTICH, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENQUOCTICH, "", False) <> 0)
    End Function

    Public m_sMAQUOCTICH As String
    Public m_sTENQUOCTICH As String
    Public m_sChonTable As Integer
End Class
