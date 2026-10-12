Imports Microsoft.VisualBasic.CompilerServices
Imports System

Public Class objQTSaiQuiDinh
    '' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.Ngay = ""
        Me.ChonBang = 0

        Return flag
    End Function

    Public Function setvalue(ByVal ChonBang As Integer, ByVal Ngay As String) As Boolean
        Dim flag As Boolean

        Me.ChonBang = ChonBang
        Me.Ngay = Ngay

        Return flag
    End Function


    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
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
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonBang = Value
        End Set
    End Property
    Public Property Ngaydauthang() As String
        Get
            Return Me.m_sNgaydauthang
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaydauthang = Value
        End Set
    End Property
    Public Property Ngaycuoithang() As String
        Get
            Return Me.m_sNgaycuoithang
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaycuoithang = Value
        End Set
    End Property
    Public Property ChonXemTongSoLan() As Integer
        Get
            Return Me.m_iChonXemTSLan
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonXemTSLan = Value
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
    Public Property VaoSom() As Integer
        Get
            Return Me.m_iVaoSom
        End Get
        Set(ByVal Value As Integer)
            Me.m_iVaoSom = Value
        End Set
    End Property
    Public Property VaoTre() As Integer
        Get
            Return Me.m_iVaoTre
        End Get
        Set(ByVal Value As Integer)
            Me.m_iVaoTre = Value
        End Set
    End Property

    Public Property RaSom() As Integer
        Get
            Return Me.m_iRaSom
        End Get
        Set(ByVal Value As Integer)
            Me.m_iRaSom = Value
        End Set
    End Property

    Public Property RaTre() As Integer
        Get
            Return Me.m_iRaTre
        End Get
        Set(ByVal Value As Integer)
            Me.m_iRaTre = Value
        End Set
    End Property

    Public Property VaoTreRaSom() As Integer
        Get
            Return Me.m_iVaoTreRaSom
        End Get
        Set(ByVal Value As Integer)
            Me.m_iVaoTreRaSom = Value
        End Set
    End Property
    Public Property VaoSomRaTre() As Integer
        Get
            Return Me.m_iVaoSomRaTre
        End Get
        Set(ByVal Value As Integer)
            Me.m_iVaoSomRaTre = Value
        End Set
    End Property
    Public Property Tatca() As Integer
        Get
            Return Me.m_iTatCa
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTatCa = Value
        End Set
    End Property
    Public Property Khu() As String
        Get
            Return Me.m_sKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sKhu = Value
        End Set
    End Property
    '' Fields
    Public m_sID As String
    Public m_sNgay As String
    Public m_iChonBang As Integer
    Public m_idNgay As Integer
    Public m_iyNgay As Integer
    Public m_imNgay As Integer
    Public m_iChonMoBaoCao As Integer
    Public m_sNgayDauTuan As String
    Public m_sNgayCuoiTuan As String
    Public m_sChonXuong As String
    Public m_iKhongTinhTangCa As Integer
    Public m_iDaChamCong As Integer
    Public m_iVaoSom As Integer
    Public m_iVaoTre As Integer
    Public m_iRaSom As Integer
    Public m_iRaTre As Integer
    Public m_iVaoTreRaSom As Integer
    Public m_iVaoSomRaTre As Integer
    Public m_iTatCa As Integer
    Public m_iChonXemTSLan As Integer
    Public m_sNgaycuoithang As String
    Public m_sNgaydauthang As String
    Public m_sKhu As String
End Class


