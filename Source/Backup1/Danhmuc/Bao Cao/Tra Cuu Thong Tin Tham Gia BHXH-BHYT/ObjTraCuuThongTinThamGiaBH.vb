Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ObjTraCuuThongTinThamGiaBH
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
    Public Property TUNGAY() As String
        Get
            Return Me.m_sTuNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sTuNgay = Value
        End Set
    End Property
    Public Property DENNGAY() As String
        Get
            Return Me.m_sDenNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sDenNgay = Value
        End Set
    End Property
    Public m_sMANV As String
    Public m_sDonvi As String
    Public m_sTuNgay As String
    Public m_sDenNgay As String
    Public m_sChonTable As Integer
End Class
