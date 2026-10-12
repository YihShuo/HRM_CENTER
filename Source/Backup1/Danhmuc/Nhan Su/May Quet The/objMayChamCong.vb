Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objMayChamCong
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.SoMay = ""
        Me.TenMay = ""
        Me.ViTri = ""
        Me.TinhTrang = ""
        Me.IP = ""
        Me.SoCong = ""
        Me.GhiChu = ""
        Me.GiaoThuc = 0
        Me.ChonBang = 0

        Return flag
    End Function

    Public Function setvalue(ByVal m_sSomay As String, ByVal m_sTenmay As String, ByVal m_sTinhtrang As String, ByVal m_sVitri As String, ByVal m_sGhichu As String, ByVal m_sIp As String, ByVal m_sSocong As String, ByVal m_iGtip As Boolean, ByVal m_iGtudp As Boolean) As Boolean
        Dim flag As Boolean

        Me.SoMay = m_sSomay
        Me.TenMay = m_sTenmay
        Me.TinhTrang = m_sTinhtrang
        Me.ViTri = m_sVitri
        Me.GhiChu = m_sGhichu
        Me.IP = m_sIp
        Me.SoCong = m_sSocong

        If m_iGtip = True Then
            Me.GiaoThuc = 1
        ElseIf m_iGtudp = True Then
            Me.GiaoThuc = 0
        End If

        Return flag
    End Function


    ' Properties
    Public Property GhiChu() As String
        Get
            Return Me.m_sGhichu
        End Get
        Set(ByVal Value As String)
            Me.m_sGhichu = Value
        End Set
    End Property

    Public Property SoMay() As String
        Get
            Return Me.m_sSomay
        End Get
        Set(ByVal Value As String)
            Me.m_sSomay = Value
        End Set
    End Property

    Public Property TenMay() As String
        Get
            Return Me.m_sTenmay
        End Get
        Set(ByVal Value As String)
            Me.m_sTenmay = Value
        End Set
    End Property

    Public Property TinhTrang() As String
        Get
            Return Me.m_sTinhtrang
        End Get
        Set(ByVal Value As String)
            Me.m_sTinhtrang = Value
        End Set
    End Property

    Public Property ViTri() As String
        Get
            Return Me.m_sVitri
        End Get
        Set(ByVal Value As String)
            Me.m_sVitri = Value
        End Set
    End Property

    Public Property IP() As String
        Get
            Return Me.m_sIp
        End Get
        Set(ByVal Value As String)
            Me.m_sIp = Value
        End Set
    End Property

    Public Property SoCong() As String
        Get
            Return Me.m_sSocong
        End Get
        Set(ByVal Value As String)
            Me.m_sSocong = Value
        End Set
    End Property

    Public Property GiaoThuc() As Integer
        Get
            Return Me.m_iGiaothuc
        End Get
        Set(ByVal Value As Integer)
            Me.m_iGiaothuc = Value
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


    ' Fields
    Public m_sSomay As String
    Public m_sTenmay As String
    Public m_sTinhtrang As String
    Public m_sVitri As String
    Public m_sGhichu As String
    Public m_sIp As String
    Public m_sSocong As String
    Public m_iGiaothuc As Integer
    Public m_iChonbang As Integer

End Class


