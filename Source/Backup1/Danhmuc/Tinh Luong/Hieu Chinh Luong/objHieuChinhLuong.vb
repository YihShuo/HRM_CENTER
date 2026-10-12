Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objHieuChinhLuong
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NamThang = ""
        Me.NV_MA = ""
        Me.SoTien = 0
        Me.DonVi = ""
        Return flag
    End Function
    Public m_sNGAYCN As String
    Public m_sNGUOICN As String

    Public Property NGAYCN() As String
        Get
            Return Me.m_sNGAYCN
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCN = Value
        End Set
    End Property
    Public Property NGUOICN() As String
        Get
            Return Me.m_sNGUOICN
        End Get
        Set(ByVal Value As String)
            Me.m_sNGUOICN = Value
        End Set
    End Property
    '' Properties

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property

    Public Property DonVi() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property NamThang() As String
        Get
            Return Me.m_sNamThang
        End Get
        Set(ByVal Value As String)
            Me.m_sNamThang = Value
        End Set
    End Property

    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property
    Public Property SoTien() As Double
        Get
            Return Me.m_bLoaiLuong
        End Get
        Set(ByVal Value As Double)
            Me.m_bLoaiLuong = Value
        End Set
    End Property
    Public Property BHYT() As Integer
        Get
            Return Me.m_iBHYT
        End Get
        Set(ByVal Value As Integer)
            Me.m_iBHYT = Value
        End Set
    End Property
    Public Property BHXH() As Integer
        Get
            Return Me.m_iBHXH
        End Get
        Set(ByVal Value As Integer)
            Me.m_iBHXH = Value
        End Set
    End Property

    ' Fields
    Public m_iChonbang As Integer
    Public m_iBHYT As Integer
    Public m_iBHXH As Integer
    Public m_sDonvi As String
    Public m_sNamThang As String

    Public m_sNvma As String
    Public m_bLoaiLuong As Double
End Class
