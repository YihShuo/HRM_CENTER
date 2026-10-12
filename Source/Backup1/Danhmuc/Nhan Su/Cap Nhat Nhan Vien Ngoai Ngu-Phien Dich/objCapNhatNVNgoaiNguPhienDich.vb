''' ===== Ngày tạo: 23/09/2014
''' ===== Ngày cập nhật: 
''' ===== Người cập nhật: Trân
''' ===== Nội dung: cập nhật trạng thái nhân viên ngoại ngữ hoặc phiên dịch
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Public Class objCapNhatNVNgoaiNguPhienDich
    Dim flag As Boolean
    Public Overridable Function setnull()
        Me.NV_MA = ""
        Me.NV_NGAYVAO = Now.Date
        Me.Thoiviec = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaNV As String, ByVal Ngayvao As String) As Boolean
        Me.NV_MA = MaNV
        Me.NV_NGAYVAO = Ngayvao
        Return False
    End Function
    Public Property NV_MA() As String
        Get
            Return Me.m_sManv
        End Get
        Set(ByVal Value As String)
            Me.m_sManv = Value
        End Set
    End Property
    Public Property NV_TEN() As String
        Get
            Return Me.m_sHoTen
        End Get
        Set(ByVal Value As String)
            Me.m_sHoTen = Value
        End Set
    End Property
    Public Property DV_MA() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property X_MA() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property NV_NGAYVAO() As Date
        Get
            Return Me.m_dNgayvao
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayvao = Value
        End Set
    End Property
    Public Property Thoiviec() As Boolean
        Get
            Return Me.m_bThoiviec
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bThoiviec = Value
        End Set
    End Property
    Public Property CongViec() As String
        Get
            Return Me.m_sCongviec
        End Get
        Set(ByVal Value As String)
            Me.m_sCongviec = Value
        End Set
    End Property
    Public Property ChucVu() As String
        Get
            Return Me.m_sChucvu
        End Get
        Set(ByVal Value As String)
            Me.m_sChucvu = Value
        End Set
    End Property
    ''============ phan loai nhan vien =========''
    Public Property NV_PhienDich() As Integer
        Get
            Return Me.m_bNVPhienDich
        End Get
        Set(ByVal Value As Integer)
            Me.m_bNVPhienDich = Value
        End Set
    End Property
    Public Property NV_NgoaiNgu_TA() As Integer
        Get
            Return Me.m_bNVNgoaiNguTA
        End Get
        Set(ByVal Value As Integer)
            Me.m_bNVNgoaiNguTA = Value
        End Set
    End Property
    Public Property NV_NgoaiNgu_TH() As Integer
        Get
            Return Me.m_bNVNgoaiNguTH
        End Get
        Set(ByVal Value As Integer)
            Me.m_bNVNgoaiNguTH = Value
        End Set
    End Property
    Public Property NV_NgoaiNgu_KH() As Integer
        Get
            Return Me.m_bNVNgoaiNguKh
        End Get
        Set(ByVal Value As Integer)
            Me.m_bNVNgoaiNguKh = Value
        End Set
    End Property
    Public Property NV_THOIVIEC() As Date
        Get
            Return Me.m_dNgaythoiviec
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaythoiviec = Value
        End Set
    End Property
    Public Property LOAITHOIVIEC() As String
        Get
            Return Me.m_sLoaithoiviec
        End Get
        Set(ByVal Value As String)
            Me.m_sLoaithoiviec = Value
        End Set
    End Property
    Public Property LOAINGOAINGU() As String
        Get
            Return Me.m_sLoaingoaingu
        End Get
        Set(ByVal Value As String)
            Me.m_sLoaingoaingu = Value
        End Set
    End Property
    Public Property LYDOTHOIVIEC() As String
        Get
            Return Me.m_sLydothoiviec
        End Get
        Set(ByVal Value As String)
            Me.m_sLydothoiviec = Value
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
    Public Property LoaiBaocao() As Integer
        Get
            Return Me.m_iLoaiBC
        End Get
        Set(ByVal Value As Integer)
            Me.m_iLoaiBC = Value
        End Set
    End Property
    Public Property Tungay() As String
        Get
            Return Me.m_dTungay
        End Get
        Set(ByVal Value As String)
            Me.m_dTungay = Value
        End Set
    End Property
    Public Property Denngay() As String
        Get
            Return Me.m_dDenngay
        End Get
        Set(ByVal Value As String)
            Me.m_dDenngay = Value
        End Set
    End Property
    Public Property Xemhinh() As Boolean
        Get
            Return Me.bXemhinh
        End Get
        Set(ByVal Value As Boolean)
            Me.bXemhinh = Value
        End Set
    End Property
    Public Property MABAOCAO() As String
        Get
            Return Me.m_sMaBaoCao
        End Get
        Set(ByVal Value As String)
            Me.m_sMaBaoCao = Value
        End Set
    End Property
    Public m_sManv As String
    Public m_sMaBaoCao As String
    Public m_sCMND As String
    Public m_sHoTen As String
    Public m_sDonvi As String
    Public m_dNgayvao As Date
    Public m_dNgaythoiviec As Date
    Public m_dTungay As String
    Public m_dDenngay As String
    Public m_sLoaithoiviec As String
    Public m_sLydothoiviec As String
    Public m_sCongviec As String
    Public m_sChucvu As String
    Public m_sXuong As String
    Public m_sLoaingoaingu As String
    Public m_bThoiviec As Boolean
    Public bXemhinh As Boolean
    Public m_bNVNgoaiNguTA As Integer
    Public m_bNVNgoaiNguTH As Integer
    Public m_bNVNgoaiNguKh As Integer
    Public m_bNVPhienDich As Integer
    Public m_iLoaiBC As Integer
    Public m_bChondonvi As Boolean
    Public m_sChonTable As Integer
End Class
