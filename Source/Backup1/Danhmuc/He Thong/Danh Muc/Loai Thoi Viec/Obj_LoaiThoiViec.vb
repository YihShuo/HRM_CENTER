Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_LoaiThoiViec
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MALOAITHOIVIEC = ""
        Me.TENLOAITHOIVIEC = ""
        Me.TILEHL = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaLoaiThoiViec As String, ByVal TenLoaiThoiViec As String, ByVal TiLeHL As String, ByVal GhiChu As String) As Boolean
        Me.MALOAITHOIVIEC = MaLoaiThoiViec
        Me.TENLOAITHOIVIEC = TenLoaiThoiViec
        Me.TILEHL = TiLeHL
        Me.GHICHU = GhiChu
        Return False
    End Function

    Public Property MALOAITHOIVIEC() As String
        Get
            Return Me.m_sMALOAITHOIVIEC
        End Get
        Set(ByVal Value As String)
            Me.m_sMALOAITHOIVIEC = Value
        End Set
    End Property

    Public Property TENLOAITHOIVIEC() As String
        Get
            Return Me.m_sTENLOAITHOIVIEC
        End Get
        Set(ByVal Value As String)
            Me.m_sTENLOAITHOIVIEC = Value
        End Set
    End Property

    Public Property TILEHL() As String
        Get
            Return Me.m_sTILEHL
        End Get
        Set(ByVal Value As String)
            Me.m_sTILEHL = Value
        End Set
    End Property

    Public Property GHICHU() As String
        Get
            Return Me.m_sGHICHU
        End Get
        Set(ByVal Value As String)
            Me.m_sGHICHU = Value
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

    Public Function KtMa() As Boolean
        Return (StringType.StrCmp(Me.MALOAITHOIVIEC, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENLOAITHOIVIEC, "", False) <> 0)
    End Function

    Public m_sMALOAITHOIVIEC As String
    Public m_sTENLOAITHOIVIEC As String
    Public m_sTILEHL As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
End Class
