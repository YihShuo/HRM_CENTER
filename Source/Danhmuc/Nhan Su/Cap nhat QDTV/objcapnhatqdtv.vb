Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objcapnhatqdtv
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MANV = ""
        Me.SOQD = ""
        Me.NGAY = Now
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaNhanVien As String, ByVal NgayCD As String, ByVal soqd As String) As Boolean
        Me.MANV = MaNhanVien
        Me.NGAY = NgayCD
        Me.SOQD = soqd
        Return False
    End Function
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
        End Set
    End Property

    Public Property SOQD() As String
        Get
            Return Me.m_sSOQD
        End Get
        Set(ByVal Value As String)
            Me.m_sSOQD = Value
        End Set
    End Property

    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
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
    Public m_sMANV As String
    Public m_sSOQD As String
    Public m_sNGAY As String
    Public m_sChonTable As Integer
End Class
