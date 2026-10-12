Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTheoDoiLuongBB_NVTV
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
        Me.SoQD = ""
        Me.LoaiTV = ""
        Me.LyDO = ""
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal ngay As String, ByVal so As String, ByVal lydo As String, ByVal loai As String, ByVal m_ChonTable As Integer) As Boolean
        Dim flag As Boolean
        Me.NV_MA = ma
        Me.NgayTV = ngay
        Me.SoQD = so
        Me.LyDO = lydo
        Me.LoaiTV = loai
        Me.ChonBang = m_ChonTable
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

    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property NgayTV() As String
        Get
            Return Me.m_bNgay
        End Get
        Set(ByVal Value As String)
            Me.m_bNgay = Value
        End Set
    End Property

    Public Property SoQD() As String
        Get
            Return Me.m_bso
        End Get
        Set(ByVal Value As String)
            Me.m_bso = Value
        End Set
    End Property
    Public Property FlagChamCong() As Boolean
        Get
            Return Me.m_bChamcong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChamcong = Value
        End Set
    End Property

    Public Property LoaiTV() As String
        Get
            Return Me.m_bLoai
        End Get
        Set(ByVal Value As String)
            Me.m_bLoai = Value
        End Set
    End Property
    Public Property LyDO() As String
        Get
            Return Me.m_blydo
        End Get
        Set(ByVal Value As String)
            Me.m_blydo = Value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer

    Public m_sNvma As String
    Public m_bLoai As String
    Public m_bNgay As String
    Public m_bso As String
    Public m_blydo As String
    Public m_bChamcong As Boolean
End Class
