Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_HocVanDM
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MAHOCVAN = ""
        Me.TENHOCVAN = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaHocVan As String, ByVal TenHocVan As String) As Boolean
        Me.MAHOCVAN = MaHocVan
        Me.TENHOCVAN = TenHocVan
        Return False
    End Function
    Public Property MAHOCVAN() As String
        Get
            Return Me.m_sMAHOCVAN
        End Get
        Set(ByVal Value As String)
            Me.m_sMAHOCVAN = Value
        End Set
    End Property

    Public Property TENHOCVAN() As String
        Get
            Return Me.m_sTENHOCVAN
        End Get
        Set(ByVal Value As String)
            Me.m_sTENHOCVAN = Value
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
        Return (StringType.StrCmp(Me.MAHOCVAN, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENHOCVAN, "", False) <> 0)
    End Function

    Public m_sMAHOCVAN As String
    Public m_sTENHOCVAN As String
    Public m_sChonTable As Integer
End Class
