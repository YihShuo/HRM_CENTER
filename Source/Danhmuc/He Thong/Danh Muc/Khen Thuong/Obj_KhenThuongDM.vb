Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_KhenThuongDM
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MAKHENTHUONG = ""
        Me.TENKHENTHUONG = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaKhenThuong As String, ByVal TenKhenThuong As String) As Boolean
        Me.MAKHENTHUONG = MaKhenThuong
        Me.TENKHENTHUONG = TenKhenThuong
        Return False
    End Function

    Public Property MAKHENTHUONG() As String
        Get
            Return Me.m_sMAKHENTHUONG
        End Get
        Set(ByVal Value As String)
            Me.m_sMAKHENTHUONG = Value
        End Set
    End Property

    Public Property TENKHENTHUONG() As String
        Get
            Return Me.m_sTENKHENTHUONG
        End Get
        Set(ByVal Value As String)
            Me.m_sTENKHENTHUONG = Value
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
        Return (StringType.StrCmp(Me.MAKHENTHUONG, "", False) <> 0)
    End Function

    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.TENKHENTHUONG, "", False) <> 0)
    End Function

    Public m_sMAKHENTHUONG As String
    Public m_sTENKHENTHUONG As String
    Public m_sChonTable As Integer
End Class
