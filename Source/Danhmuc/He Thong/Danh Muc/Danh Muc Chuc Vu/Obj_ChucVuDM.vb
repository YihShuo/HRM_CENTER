Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_ChucVuDM
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MACHUCVU = ""
        Me.TENCHUCVU = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaChucVu As String, ByVal TenChucVu As String) As Boolean
        Me.MACHUCVU = MaChucVu
        Me.TENCHUCVU = TenChucVu
        Return False
    End Function
    Public Property MACHUCVU() As String
        Get
            Return Me.m_sMACHUCVU
        End Get
        Set(ByVal Value As String)
            Me.m_sMACHUCVU = Value
        End Set
    End Property

    Public Property TENCHUCVU() As String
        Get
            Return Me.m_sTENCHUCVU
        End Get
        Set(ByVal Value As String)
            Me.m_sTENCHUCVU = Value
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
        Return (StringType.StrCmp(Me.MACHUCVU, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENCHUCVU, "", False) <> 0)
    End Function

    Public m_sMACHUCVU As String
    Public m_sTENCHUCVU As String
    Public m_sChonTable As Integer
End Class
