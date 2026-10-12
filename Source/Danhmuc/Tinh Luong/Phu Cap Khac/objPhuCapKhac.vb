Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objPhuCapKhac
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NamThang = ""
        Me.NV_MA = ""
        Me.LoaiPC = ""
        Me.SoTien = 0
        Me.DonVi = ""
        Me.Thang_T = ""
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal lpc As String, ByVal thang As String, ByVal stien As Double) As Boolean
        Dim flag As Boolean
        Me.NamThang = thang
        Me.NV_MA = ma
        Me.LoaiPC = lpc
        Me.SoTien = stien
        Return flag
    End Function

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
    Public Property LoaiPC() As String
        Get
            Return Me.m_sNLPC
        End Get
        Set(ByVal Value As String)
            Me.m_sNLPC = Value
        End Set
    End Property

    Public Property Thang_T() As String
        Get
            Return Me.m_sTT
        End Get
        Set(ByVal Value As String)
            Me.m_sTT = Value
        End Set
    End Property

    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sDonvi As String
    Public m_sNamThang As String
    Public m_sTT As String

    Public m_sNvma As String
    Public m_sNLPC As String
    Public m_bLoaiLuong As Double
End Class
