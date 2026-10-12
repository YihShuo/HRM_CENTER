Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objQTSaiQuiDinhBangTong
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.Ngay = ""
        Me.ID = ""

        Return flag
    End Function

    Public Function setvalue(ByVal ChonBang As Integer, ByVal Ngay As String) As Boolean
        Dim flag As Boolean

        Me.ChonBang = ChonBang
        Me.Ngay = Ngay

        Return flag
    End Function


    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property

    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonBang = Value
        End Set
    End Property
    Public Property NgayDauTuan() As String
        Get
            Return Me.m_sNgayDauTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayDauTuan = Value
        End Set
    End Property
    Public Property NgayCuoiTuan() As String
        Get
            Return Me.m_sNgayCuoiTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCuoiTuan = Value
        End Set
    End Property
    Public Property ChonXuong() As String
        Get
            Return Me.m_sChonXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sChonXuong = Value
        End Set
    End Property
    Public Property ChonKhu() As String
        Get
            Return Me.m_sChonKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sChonKhu = Value
        End Set
    End Property

    Public Property ChonMoBaoCao() As Integer
        Get
            Return Me.m_iChonMoBaoCao
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonMoBaoCao = Value
        End Set
    End Property
    Public Property KhongTinhTangCa() As Integer
        Get
            Return Me.m_iKhongTinhTangCa
        End Get
        Set(ByVal Value As Integer)
            Me.m_iKhongTinhTangCa = Value
        End Set
    End Property
    Public Property DaChamCong() As Integer
        Get
            Return Me.m_iDaChamCong
        End Get
        Set(ByVal Value As Integer)
            Me.m_iDaChamCong = Value
        End Set
    End Property
    Public Property D_Ngay() As Integer
        Get
            Return Me.m_idNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_idNgay = Value
        End Set
    End Property
    Public Property M_Ngay() As Integer
        Get
            Return Me.m_imNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_imNgay = Value
        End Set
    End Property
    Public Property Y_Ngay() As Integer
        Get
            Return Me.m_iyNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_iyNgay = Value
        End Set
    End Property


    '' Fields
    Public m_sID As String
    Public m_sNgay As String
    Public m_idNgay As Integer
    Public m_iChonBang As Integer
    Public m_iyNgay As Integer
    Public m_imNgay As Integer
    Public m_iChonMoBaoCao As Integer
    Public m_sNgayDauTuan As String
    Public m_sNgayCuoiTuan As String
    Public m_sChonXuong As String
    Public m_sChonKhu As String
    Public m_iKhongTinhTangCa As Integer
    Public m_iDaChamCong As Integer

End Class


