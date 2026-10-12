Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Public Class Obj_XaPhuong
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MATINHTHANH = ""
        Me.MAQUANHUYEN = ""
        Me.MAXAPHUONG = ""
        Me.TENXAPHUONG = ""
        Me.GHICHU = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaXaPhuong As String, ByVal MaTinhThanh As String, ByVal MaQuanHuyen As String, ByVal TenXaPhuong As String, ByVal Ghichu As String) As Boolean
        Me.MAXAPHUONG = MaXaPhuong
        Me.MATINHTHANH = MaTinhThanh
        Me.MAQUANHUYEN = MaQuanHuyen
        Me.TENXAPHUONG = TenXaPhuong
        Me.GHICHU = Ghichu
        Return False
    End Function
    Public Property MATINHTHANH() As String
        Get
            Return Me.m_sMATINHTHANH
        End Get
        Set(ByVal Value As String)
            Me.m_sMATINHTHANH = Value
        End Set
    End Property

    Public Property MAQUANHUYEN() As String
        Get
            Return Me.m_sMAQUANHUYEN
        End Get
        Set(ByVal Value As String)
            Me.m_sMAQUANHUYEN = Value
        End Set
    End Property
    Public Property MAXAPHUONG() As String
        Get
            Return Me.m_sMAXAPHUONG
        End Get
        Set(ByVal Value As String)
            Me.m_sMAXAPHUONG = Value
        End Set
    End Property
    Public Property TENXAPHUONG() As String
        Get
            Return Me.m_sTENXAPHUONG
        End Get
        Set(ByVal Value As String)
            Me.m_sTENXAPHUONG = Value
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
    Public Property TENTINHTHANH() As String
        Get
            Return Me.m_sTENTINHTHANH
        End Get
        Set(ByVal Value As String)
            Me.m_sTENTINHTHANH = Value
        End Set
    End Property

    Public Property TENQUANHUYEN() As String
        Get
            Return Me.m_sTENQUANHUYEN
        End Get
        Set(ByVal Value As String)
            Me.m_sTENQUANHUYEN = Value
        End Set
    End Property
    Public Function KtMaXaPhuong() As Boolean
        Return (StringType.StrCmp(Me.m_sMAXAPHUONG, "", False) <> 0)
    End Function

    Public Function KtTenXaPhuong() As Boolean
        Return (StringType.StrCmp(Me.m_sTENXAPHUONG, "", False) <> 0)
    End Function
    Public Function KtMaQuanHuyen() As Boolean
        Return (StringType.StrCmp(Me.m_sMAQUANHUYEN, "", False) <> 0)
    End Function
    Public Function KtMaTinhThanh() As Boolean
        Return (StringType.StrCmp(Me.m_sMATINHTHANH, "", False) <> 0)
    End Function
    Public m_sMATINHTHANH As String ''khoa ngoai tham chieu bang quan huyen

    Public m_sMAQUANHUYEN As String ''khoa ngoai tham chieu bang quan huyen
    Public m_sMAXAPHUONG As String
    Public m_sTENXAPHUONG As String
    Public m_sGHICHU As String
    Public m_sChonTable As Integer
    Public m_sTENTINHTHANH As String ''khoa ngoai tham chieu bang quan huyen

    Public m_sTENQUANHUYEN As String
End Class
