Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTraCuuNhanhNV
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
    Public Property ChonThoiViec() As Integer
        Get
            Return Me.m_iChonTV
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonTV = Value
        End Set
    End Property
    Public Property ChonDiLam() As Integer
        Get
            Return Me.m_iChonDL
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonDL = Value
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
    Public Property LoaiDonViNghiViec() As Integer
        Get
            Return Me.m_iLoaiDonviNghiViec
        End Get
        Set(ByVal Value As Integer)
            Me.m_iLoaiDonviNghiViec = Value
        End Set
    End Property
    Public Property ChonDV_MA_() As Integer
        Get
            Return Me.m_iDV_MA_
        End Get
        Set(ByVal Value As Integer)
            Me.m_iDV_MA_ = Value
        End Set
    End Property
    Public Property ChonDV_MA() As Integer
        Get
            Return Me.m_iDV_MA
        End Get
        Set(ByVal Value As Integer)
            Me.m_iDV_MA = Value
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
    Public m_iLoaiDonviNghiViec As Integer
    Public m_iDV_MA As Integer
    Public m_iDV_MA_ As Integer
    Public m_iChonTV As Integer
    Public m_iChonDL As Integer

    Public m_sDonvi As String
    Public m_sNgayvao As String
    Public m_sChonTable As Integer
End Class
