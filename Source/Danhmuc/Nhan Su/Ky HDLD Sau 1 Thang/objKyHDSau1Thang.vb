Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objKyHDSau1Thang
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.NamThang = ""
        Me.NV_MA = ""
        Me.ThuongABC = 0
        Me.SoTien = 0
        Me.DonVi = ""
        Me.m_sXuong = ""
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal thang As String, ByVal stien As Double, ByVal thuong As Double, ByVal dv As String) As Boolean
        Dim flag As Boolean
        Me.NamThang = thang
        Me.NV_MA = ma
        Me.ThuongABC = thuong
        Me.SoTien = stien
        Me.DonVi = dv
        Return flag
    End Function

    '' Properties
    Public m_sKhu As String
    Public Property ChonKhu() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
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
    Public Property Xuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
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

    Public Property TUNGAY() As String
        Get
            Return Me.m_sTN
        End Get
        Set(ByVal Value As String)
            Me.m_sTN = Value
        End Set
    End Property

    Public Property DENNGAY() As String
        Get
            Return Me.m_sDN
        End Get
        Set(ByVal Value As String)
            Me.m_sDN = Value
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

    Public Property ThuongABC() As Double
        Get
            Return Me.m_bChamCom
        End Get
        Set(ByVal Value As Double)
            Me.m_bChamCom = Value
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

    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sNgay As String
    Public m_sDonvi As String
    Public m_sXuong As String
    Public m_sThang As String
    Public m_sNamThang As String
    Public m_sTN As String
    Public m_sDN As String
    Public m_sNam As String

    Public m_dNgaychamcong As Date
    Public m_sNvma As String
    Public m_bFlagTinhLuong As Boolean
    Public m_bCoChamCom As Boolean
    Public m_bChamCom As Double
    Public m_bLoaiLuong As Double
End Class
