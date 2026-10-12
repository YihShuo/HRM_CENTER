Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System


Public Class Obj_CaLamViec
    Dim flag As Boolean

    Public Overridable Function setnull()
        Me.MACA = ""
        Me.GIOBATDAU = ""
        Me.GIOKETTHUC = ""
        Me.GIOGIAILAO = ""
        Me.PHUTGIAILAO = ""
        Me.SHIFT = ""
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal MaCa As String, ByVal GioBatDau As String, ByVal GioKetThuc As String, ByVal GioGiaiLao As String, ByVal PhutGiaiLao As String, ByVal Shift As String) As Boolean
        Me.MACA = MaCa
        Me.GIOBATDAU = GioBatDau
        Me.GIOKETTHUC = GioKetThuc
        Me.GIOGIAILAO = GioGiaiLao
        Me.PHUTGIAILAO = PhutGiaiLao
        Me.SHIFT = Shift
        Return False
    End Function

    Public Property MACA() As String
        Get
            Return Me.m_sMACA
        End Get
        Set(ByVal Value As String)
            Me.m_sMACA = Value
        End Set
    End Property

    Public Property GIOBATDAU() As String
        Get
            Return Me.m_sGIOBATDAU
        End Get
        Set(ByVal Value As String)
            Me.m_sGIOBATDAU = Value
        End Set
    End Property

    Public Property GIOKETTHUC() As String
        Get
            Return Me.m_sGIOKETTHUC
        End Get
        Set(ByVal Value As String)
            Me.m_sGIOKETTHUC = Value
        End Set
    End Property

    Public Property GIOGIAILAO() As String
        Get
            Return Me.m_sGIOGIAILAO
        End Get
        Set(ByVal Value As String)
            Me.m_sGIOGIAILAO = Value
        End Set
    End Property

    Public Property PHUTGIAILAO() As String
        Get
            Return Me.m_sPHUTGIAILAO
        End Get
        Set(ByVal Value As String)
            Me.m_sPHUTGIAILAO = Value
        End Set
    End Property

    Public Property SHIFT() As String
        Get
            Return Me.m_sSHIFT
        End Get
        Set(ByVal Value As String)
            Me.m_sSHIFT = Value
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
        Return (StringType.StrCmp(Me.MACA, "", False) <> 0)
    End Function

    Public m_sMACA As String
    Public m_sGIOBATDAU As String
    Public m_sGIOKETTHUC As String
    Public m_sGIOGIAILAO As String
    Public m_sPHUTGIAILAO As String
    Public m_sSHIFT As String

    Public m_sChonTable As Integer
End Class
