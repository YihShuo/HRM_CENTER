Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System


Public Class Obj_TonGiao
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATONGIAO = ""
        Me.TENTONGIAO = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaTonGiao As String, ByVal TenTonGiao As String) As Boolean
        Me.MATONGIAO = MaTonGiao
        Me.TENTONGIAO = TenTonGiao
        Return False
    End Function

    Public Property MATONGIAO() As String
        Get
            Return Me.m_sMATONGIAO
        End Get
        Set(ByVal Value As String)
            Me.m_sMATONGIAO = Value
        End Set
    End Property

    Public Property TENTONGIAO() As String
        Get
            Return Me.m_sTENTONGIAO
        End Get
        Set(ByVal Value As String)
            Me.m_sTENTONGIAO = Value
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
        Return (StringType.StrCmp(Me.MATONGIAO, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENTONGIAO, "", False) <> 0)
    End Function

    Public m_sMATONGIAO As String
    Public m_sTENTONGIAO As String
    Public m_sChonTable As Integer
End Class
