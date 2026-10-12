Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class Obj_CaDacBiet

    Public Overridable Function setnull()
        Dim flag As Boolean
        Me.MaNhanVien = ""
        Me.DonVi = ""
        Me.CaMa = ""
        Me.ChonBang = 0
        Return flag
    End Function

    'Các hàm nhận giá trị từ các box

    Public Property ChonBang() As String
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As String)
            Me.m_iChonbang = Value
        End Set
    End Property

    Public Property MaNhanVien() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property DonVi() As String
        Get
            Return Me.m_sDonVi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonVi = Value
        End Set
    End Property

    Public Property CaMa() As String
        Get
            Return Me.m_sCaMa
        End Get
        Set(ByVal Value As String)
            Me.m_sCaMa = Value
        End Set
    End Property

    'Hàm gáng giá trị
    Public Overridable Function setvalue(ByVal Nvma As String, ByVal DonVi As String, ByVal CaMa As String) As Boolean
        Me.MaNhanVien = Nvma
        Me.DonVi = DonVi
        Me.CaMa = CaMa
        Return False
    End Function

    Public m_iChonbang As String
    Public m_sNvma As String
    Public m_sTenNV As String
    Public m_sDonVi As String
    Public m_sCaMa As String

End Class
