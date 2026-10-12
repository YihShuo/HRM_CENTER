Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objGioiTinh

    Public m_sID As String
    Public m_sNGAY As String
    Public m_sXUONG As String
    Public m_sNGANH As String
    Public m_sTable As String
    Public m_iChonBang As Integer

    Public Property ChonBang() As String
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal value As String)
            Me.m_iChonBang = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal value As String)
            Me.m_sID = value
        End Set
    End Property

    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sNGAY = value
        End Set
    End Property


    Public Property XUONG() As String
        Get
            Return Me.m_sXUONG
        End Get
        Set(ByVal value As String)
            Me.m_sXUONG = value
        End Set
    End Property


    Public Property NGANH() As String
        Get
            Return Me.m_sNGANH
        End Get
        Set(ByVal value As String)
            Me.m_sNGANH = value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal value As String)
            Me.m_sTable = value
        End Set
    End Property

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.m_sID = ""
        Me.m_sNGAY = ""
        Me.m_sXUONG = ""
        Me.m_sNGANH = ""
        Me.m_sTable = ""
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sNGAY As String, ByVal m_sXUONG As String, ByVal m_sNGANH As String, ByVal m_sTable As String, ByVal m_iChonBang As Integer) As Boolean
        Me.ID = m_sID
        Me.NGAY = m_sNGAY
        Me.XUONG = m_sXUONG
        Me.NGANH = m_sNGANH
        Me.Table = m_sTable
        Me.ChonBang = m_iChonBang
        Return False
    End Function

End Class
