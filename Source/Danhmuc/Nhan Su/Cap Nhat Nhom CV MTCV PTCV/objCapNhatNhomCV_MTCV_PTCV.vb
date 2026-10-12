Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objCapNhatNhomCV_MTCV_PTCV
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0

        Return flag
    End Function
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
            Return Me.m_sNV
        End Get
        Set(ByVal Value As String)
            Me.m_sNV = Value
        End Set
    End Property
    Public Property DV_MA() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    
    Public Property NHOMCV_MA() As String
        Get
            Return Me.m_sNHOMCV_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sNHOMCV_MA = Value
        End Set
    End Property
    Public Property FlagTinhBinhBau() As Boolean
        Get
            Return Me.m_bFlagTinhLuong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bFlagTinhLuong = Value
        End Set
    End Property
    Public Function setvalue(ByVal ma As String, ByVal th As String, ByVal dv As String, ByVal cong As Double, ByVal hs As Double, ByVal bbma As String, ByVal bbt As String, ByVal oo As String, ByVal ro As String, ByVal co As String, ByVal o As String, ByVal otc As String, ByVal p As String, ByVal kthai As String, ByVal r As String, ByVal s As String, ByVal no As String, ByVal tsan As String, ByVal tnld As String, ByVal dtre As String, ByVal dq As String, ByVal ds As String, ByVal st As String, ByVal khhgd As String, ByVal qs As String) As Boolean
        Dim flag As Boolean
        Me.NV_MA = ma
     
        Return flag
    End Function
    ' Fields
    Public m_iChonbang As Integer
    Public m_sNV As String
    Public m_sDV As String
    Public m_sNHOMCV_MA As String
    Public m_bFlagTinhLuong As Boolean
End Class
