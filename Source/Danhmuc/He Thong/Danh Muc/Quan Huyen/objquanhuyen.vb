Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Public Class objquanhuyen
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATINHTHANH = ""
        Me.MAQUANHUYEN = ""
        Me.TENQUANHUYEN = ""
        Me.LOAIQUANHUYEN = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MATINHTHANH As String, ByVal MAQUANHUYEN As String, ByVal TENQUANHUYEN As String, ByVal LOAIQUANHUYEN As String, ByVal GHICHU As String) As Boolean
        Me.MATINHTHANH = MATINHTHANH
        Me.MAQUANHUYEN = MAQUANHUYEN
        Me.TENQUANHUYEN = TENQUANHUYEN
        Me.LOAIQUANHUYEN = LOAIQUANHUYEN
        Me.GHICHU = GHICHU
        Return False
    End Function
    Public Property MATINHTHANH() As String
        Get
            Return Me.m_tinhthanh
        End Get
        Set(ByVal Value As String)
            Me.m_tinhthanh = Value
        End Set
    End Property

    Public Property MAQUANHUYEN() As String
        Get
            Return Me.m_maquanhuyen
        End Get
        Set(ByVal Value As String)
            Me.m_maquanhuyen = Value
        End Set
    End Property
    Public Property TENQUANHUYEN() As String
        Get
            Return Me.m_tenquanhuyen
        End Get
        Set(ByVal Value As String)
            Me.m_tenquanhuyen = Value
        End Set
    End Property
    Public Property LOAIQUANHUYEN() As String
        Get
            Return Me.m_loaiquanhuyen
        End Get
        Set(ByVal Value As String)
            Me.m_loaiquanhuyen = Value
        End Set
    End Property
    Public Property GHICHU() As String
        Get
            Return Me.m_ghichu
        End Get
        Set(ByVal Value As String)
            Me.m_ghichu = Value
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

    Public m_tinhthanh As String ''khoa ngoai tham chieu bang quan huyen
    Public m_maquanhuyen As String ''khoa ngoai tham chieu bang quan huyen
    Public m_tenquanhuyen As String
    Public m_loaiquanhuyen As String
    Public m_ghichu As String
    Public m_sChonTable As Integer
End Class
