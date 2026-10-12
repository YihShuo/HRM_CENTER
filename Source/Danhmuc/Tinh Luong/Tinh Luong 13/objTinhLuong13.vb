Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTinhLuong13
   
    Public iChonbang As Integer
    Public sNam As String
    Public sDonvi As String
    Public sNV_MA As String
    Public dLuong As Double
    Public dPhuCap As Double
    Public iSothang As Double
    Public dHeSo As Double
    Public m_bFlagTinhLuong As Boolean
    Public iLoaiBaoCao As Integer
    Public iLoaicombo As Integer ' đk chọn đv hay xưởng
    Public Property CHONBANG() As Integer
        Get
            Return Me.iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.iChonbang = Value
        End Set
    End Property
    Public Property NAM() As String
        Get
            Return Me.sNam
        End Get
        Set(ByVal Value As String)
            Me.sNam = Value
        End Set
    End Property
    Public Property DONVI() As String
        Get
            Return Me.sDonvi
        End Get
        Set(ByVal Value As String)
            Me.sDonvi = Value
        End Set
    End Property
    Public Property NV_MA() As String
        Get
            Return Me.sNV_MA
        End Get
        Set(ByVal Value As String)
            Me.sNV_MA = Value
        End Set
    End Property
    Public Property LUONG() As Double
        Get
            Return Me.dLuong
        End Get
        Set(ByVal Value As Double)
            Me.dLuong = Value
        End Set
    End Property
    Public Property PHUCAP() As Double
        Get
            Return Me.dPhuCap
        End Get
        Set(ByVal Value As Double)
            Me.dPhuCap = Value
        End Set
    End Property
    Public Property SOTHANG() As Double
        Get
            Return Me.iSothang
        End Get
        Set(ByVal Value As Double)
            Me.iSothang = Value
        End Set
    End Property
    Public Property HESO() As Double
        Get
            Return Me.dHeSo
        End Get
        Set(ByVal Value As Double)
            Me.dHeSo = Value
        End Set
    End Property
    Public Property FLAGTINHLUONG() As Boolean
        Get
            Return Me.m_bFlagTinhLuong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bFlagTinhLuong = Value
        End Set
    End Property
    Public Property LOAIBAOCAO() As Integer
        Get
            Return Me.iLoaiBaoCao
        End Get
        Set(ByVal Value As Integer)
            Me.iLoaiBaoCao = Value
        End Set
    End Property
    Public Property LOAICOMBO() As Integer
        Get
            Return Me.iLoaicombo
        End Get
        Set(ByVal Value As Integer)
            Me.iLoaicombo = Value
        End Set
    End Property
End Class
