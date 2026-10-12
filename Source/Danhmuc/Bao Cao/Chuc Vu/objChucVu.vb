Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objChucVu

    Public m_sID As String
    Public m_sNGAY As String
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
        Me.m_sTable = ""
        Me.m_iChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sNGAY As String, ByVal m_sTable As String, ByVal m_iChonBang As Integer) As Boolean
        Me.ID = m_sID
        Me.NGAY = m_sNGAY
        Me.Table = m_sTable
        Me.ChonBang = m_iChonBang
        Return False
    End Function
End Class
