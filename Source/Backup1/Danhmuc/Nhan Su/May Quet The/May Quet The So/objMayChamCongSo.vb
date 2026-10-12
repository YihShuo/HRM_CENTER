Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objMayChamCongSo
    ' Methods
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean

        Me.SoMay = ""

        Return flag
    End Function

    'Public Overridable Function setvalue(ByVal m_sNV_MA As String, ByVal m_sCA_MA As String, ByVal m_sNGAYBATDAU As String, ByVal m_sNGAYKETTHUC As String, ByVal m_sGIOBATDAU As String, ByVal m_sGIOKETTHUC As String, ByVal m_sDV_MA As String) As Boolean
    '    Dim flag As Boolean

    '    Me.NV_MA = m_sNV_MA
    '    Me.CA_MA = m_sCA_MA
    '    Me.NGAYBATDAU = m_sNGAYBATDAU
    '    Me.NGAYKETTHUC = m_sNGAYKETTHUC
    '    Me.GIOBATDAU = m_sGIOBATDAU
    '    Me.GIOKETTHUC = m_sGIOKETTHUC
    '    Me.DV_MA = m_sDV_MA

    '    Return flag
    'End Function


    Public Property SoMay() As String
        Get
            Return Me.m_sSomay
        End Get
        Set(ByVal Value As String)
            Me.m_sSomay = Value
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

    Public m_sSomay As String
    Public m_sDonvi As String
    Public m_iChonbang As Integer


End Class


