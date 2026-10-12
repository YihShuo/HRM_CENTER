Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objKhongHuongPC
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
        Me.ChuyenCan = 0
        Me.MoiTruong = 0
        Me.TrachNhiem = 0
        Me.Khac = 0
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal mt As Integer, ByVal cc As Integer, ByVal tn As Integer, ByVal kh As Integer) As Boolean
        Dim flag As Boolean

        Me.NV_MA = ma
        If mt = True Then
            m_sNvMT = 1
        Else
            m_sNvMT = 0
        End If
        Me.MoiTruong = m_sNvMT

        If tn = True Then
            m_sNvCC = 1
        Else
            m_sNvCC = 0
        End If
        Me.ChuyenCan = m_sNvCC


        If cc = True Then
            m_sNvTN = 1
        Else
            m_sNvTN = 0
        End If
        Me.TrachNhiem = m_sNvTN


        If kh = True Then
            m_sNK = 1
        Else
            m_sNK = 0
        End If
        Me.Khac = m_sNK
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
    Public Property ChuyenCan() As Integer
        Get
            Return Me.m_sNvCC
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNvCC = Value
        End Set
    End Property
    Public Property MoiTruong() As Integer
        Get
            Return Me.m_sNvMT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNvMT = Value
        End Set
    End Property
    Public Property TrachNhiem() As Integer
        Get
            Return Me.m_sNvTN
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNvTN = Value
        End Set
    End Property
    Public Property Khac() As Integer
        Get
            Return Me.m_sNK
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNK = Value
        End Set
    End Property

    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sDonvi As String
    Public m_sNamThang As String

    Public m_sNvma As String
    Public m_sNvCC As Integer
    Public m_sNvMT As Integer
    Public m_sNvTN As Integer
    Public m_sNK As Integer
    Public m_bLoaiLuong As Double
End Class
