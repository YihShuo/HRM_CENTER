Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objBinhBauChucVu
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.BB_CVMA = ""
        Me.CVU_MA = ""
        Me.SoTien = 0
        Return flag
    End Function

    Public Function setvalue(ByVal mabb As String, ByVal cv As String, ByVal tien As Double, ByVal m_ChonTable As Integer) As Boolean
        Dim flag As Boolean
        Me.BB_CVMA = mabb
        Me.CVU_MA = cv
        Me.SoTien = tien
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

    Public Property BB_CVMA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property CVU_MA() As String
        Get
            Return Me.m_bNgay
        End Get
        Set(ByVal Value As String)
            Me.m_bNgay = Value
        End Set
    End Property
    Public Property SoTien() As Double
        Get
            Return Me.m_bLoaiLuong
        End Get
        Set(ByVal Value As Double)
            Me.m_bLoaiLuong = Value
        End Set
    End Property


    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer

    Public m_sNvma As String
    Public m_bLoai As String
    Public m_bNgay As String
    Public m_bso As String
    Public m_bLoaiLuong As Double
    Public m_bChamcong As Boolean
End Class
