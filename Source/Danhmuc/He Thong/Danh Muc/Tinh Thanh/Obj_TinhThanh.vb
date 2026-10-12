Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_TinhThanh
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATINHTHANH = ""
        Me.TENTINHTHANH = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaTinhThanh As String, ByVal TenTinhThanh As String) As Boolean
        Me.MATINHTHANH = MaTinhThanh
        Me.TENTINHTHANH = TenTinhThanh
        Return False
    End Function

    Public Property MATINHTHANH() As String
        Get
            Return Me.m_sMATINHTHANH
        End Get
        Set(ByVal Value As String)
            Me.m_sMATINHTHANH = Value
        End Set
    End Property

    Public Property TENTINHTHANH() As String
        Get
            Return Me.m_sTENTINHTHANH
        End Get
        Set(ByVal Value As String)
            Me.m_sTENTINHTHANH = Value
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
        Return (StringType.StrCmp(Me.MATINHTHANH, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENTINHTHANH, "", False) <> 0)
    End Function

    Public m_sMATINHTHANH As String
    Public m_sTENTINHTHANH As String
    Public m_sChonTable As Integer
End Class
