Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTieuChuan
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal thang As String, ByVal stien As Double) As Boolean
        Dim flag As Boolean
        'Me.NamThang = thang
        'Me.NV_MA = ma
        'Me.SoTien = stien
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
    Public Property NAM() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property TUNGAY() As String
        Get
            Return Me.m_sNamThang
        End Get
        Set(ByVal Value As String)
            Me.m_sNamThang = Value
        End Set
    End Property

    Public Property DENNGAY() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property
    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sDonvi As String
    Public m_sNamThang As String

    Public m_sNvma As String
    Public m_bLoaiLuong As String
End Class
