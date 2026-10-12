Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThoiViecKhongThamGiaBHTN
    Dim flag As Boolean
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
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
    Public Property Donvi() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property NGAYVAO() As String
        Get
            Return Me.m_sNgayvao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayvao = Value
        End Set
    End Property
    Public m_sMANV As String
    Public m_sDonvi As String
    Public m_sNgayvao As String
    Public m_sChonTable As Integer
End Class
