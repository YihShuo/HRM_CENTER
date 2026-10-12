Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ObjNguyenNhanKyLuat
    Dim flag As Boolean
    Public Overridable Function setnull()
        Me.MANNKYLUAT = ""
        Me.TENNNKYLUAT = ""
        Me.GHICHUNNKYLUAT = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaNNKyLuat As String, ByVal TenNNKyLuat As String, ByVal GhichuNNKyLuat As String) As Boolean
        Me.MANNKYLUAT = MaNNKyLuat
        Me.TENNNKYLUAT = TenNNKyLuat
        Me.GHICHUNNKYLUAT = GhichuNNKyLuat
        Return False
    End Function

    Public Property MANNKYLUAT() As String
        Get
            Return Me.m_sMANNKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sMANNKYLUAT = Value
        End Set
    End Property

    Public Property TENNNKYLUAT() As String
        Get
            Return Me.m_sTENNNKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNNKYLUAT = Value
        End Set
    End Property
    Public Property GHICHUNNKYLUAT() As String
        Get
            Return Me.m_sGHICHUNNKYLUAT
        End Get
        Set(ByVal Value As String)
            Me.m_sGHICHUNNKYLUAT = Value
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
        Return (StringType.StrCmp(Me.MANNKYLUAT, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENNNKYLUAT, "", False) <> 0)
    End Function

    Public m_sMANNKYLUAT As String
    Public m_sTENNNKYLUAT As String
    Public m_sGHICHUNNKYLUAT As String
    Public m_sChonTable As Integer
End Class
