Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objNoiDangKyKCB
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal ngay_ As String, ByVal DV As String, ByVal NK As String, ByVal CD As String, ByVal GC As String, ByVal m_ChonTable As Integer) As Boolean
        Dim flag As Boolean

  
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

    Public Property MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property TEN() As String
        Get
            Return Me.m_bDV
        End Get
        Set(ByVal Value As String)
            Me.m_bDV = Value
        End Set
    End Property

    Public Property TenDangNhap() As String
        Get
            Return Me.m_sTendangnhap
        End Get
        Set(ByVal Value As String)
            Me.m_sTendangnhap = Value
        End Set
    End Property
    Public Property NGUOITAO() As String
        Get
            Return Me.m_sNguoitao
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoitao = Value
        End Set
    End Property
    Public Property NGAYTAO() As String
        Get
            Return Me.m_sNgaytao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaytao = Value
        End Set
    End Property
    Public Property NGUOICN() As String
        Get
            Return Me.m_sNguoicapnhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNguoicapnhat = Value
        End Set
    End Property
    Public Property NGAYCN() As String
        Get
            Return Me.m_sNgaycapnhat
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaycapnhat = Value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer

    Public m_sNvma As String
    Public m_sNK As String
    Public m_bNgay As String
    Public m_bDV As String
    Public m_bCD As String
    Public m_bChamcong As Boolean
    Public m_sTendangnhap As String
    Public m_sNgaycapnhat As String
    Public m_sNguoicapnhat As String
    Public m_sNgaytao As String
    Public m_sNguoitao As String
    Public m_sNgayxoa As String
    Public m_sNguoixoa As String
    Public m_bGC As String
End Class
