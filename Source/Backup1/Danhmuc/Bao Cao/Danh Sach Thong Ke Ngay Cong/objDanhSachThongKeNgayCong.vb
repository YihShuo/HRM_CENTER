Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objDanhSachThongKeNgayCong
    Public m_sID As String
    Public m_sTUNGAY As String
    Public m_sDENNGAY As String
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

    Public Property TUNGAY() As String
        Get
            Return Me.m_sTUNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sTUNGAY = value
        End Set
    End Property


    Public Property DENNGAY() As String
        Get
            Return Me.m_sDENNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sDENNGAY = value
        End Set
    End Property

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.m_sID = ""
        Me.m_sTUNGAY = ""
        Me.m_sDENNGAY = ""
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal m_sID As String, ByVal TUNGAY_ As String, ByVal DENNGAY_ As String, ByVal m_iChonBang As Integer) As Boolean
        Me.ID = m_sID
        Me.TUNGAY = TUNGAY_
        Me.DENNGAY = DENNGAY_
        Me.ChonBang = m_iChonBang
        Return False
    End Function
End Class
