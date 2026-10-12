Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThongKePNMTTheoThang
    Dim flag As Boolean
    Public Property NV_MA() As String
        Get
            Return Me.m_sNV_MA
        End Get
        Set(ByVal Value As String)
            Me.m_sNV_MA = Value
        End Set
    End Property
    Public Property NamTruoc() As Integer
        Get
            Return Me.m_iNamTruoc
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNamTruoc = Value
        End Set
    End Property
    Public Property NamSau() As Integer
        Get
            Return Me.m_iNamSau
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNamSau = Value
        End Set
    End Property
    Public Property NAM() As Integer
        Get
            Return Me.m_iNam
        End Get
        Set(ByVal Value As Integer)
            Me.m_iNam = Value
        End Set
    End Property
    Public Property THANG() As Integer
        Get
            Return Me.m_iThang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iThang = Value
        End Set
    End Property
    Public Property NGAYCUOITHANG() As String
        Get
            Return Me.m_sNgaycuoithang
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaycuoithang = Value
        End Set
    End Property
    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Me.NV_MA = ""
      
    End Function
    Public m_sNV_MA As String
    Public m_iNam As Integer
    Public m_iNamTruoc As Integer
    Public m_iNamSau As Integer
    Public m_iThang As Integer
    Public m_sChonTable As Integer
    Public m_sNgaycuoithang As String
End Class
