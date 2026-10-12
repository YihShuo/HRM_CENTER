Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_TinHoc
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATINHOC = ""
        Me.TENTINHOC = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaTinHoc As String, ByVal TenTinHoc As String) As Boolean
        Me.MATINHOC = MaTinHoc
        Me.TENTINHOC = TenTinHoc
        Return False
    End Function

    Public Property MATINHOC() As String
        Get
            Return Me.m_sMATINHOC
        End Get
        Set(ByVal Value As String)
            Me.m_sMATINHOC = Value
        End Set
    End Property

    Public Property TENTINHOC() As String
        Get
            Return Me.m_sTENTINHOC
        End Get
        Set(ByVal Value As String)
            Me.m_sTENTINHOC = Value
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
        Return (StringType.StrCmp(Me.MATINHOC, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENTINHOC, "", False) <> 0)
    End Function

    Public m_sMATINHOC As String
    Public m_sTENTINHOC As String
    Public m_sChonTable As Integer
End Class
