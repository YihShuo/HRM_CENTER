Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objThongKeCoCongCoPhep
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.NGAY = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ChonBang = m_sChonTable
        Return False
    End Function

    Public Overridable Sub setvalueChonThamSo(ByVal m_bChonTCT_ As Boolean, ByVal m_bChonKhuA_ As Boolean, ByVal m_bChonKhuB_ As Boolean, ByVal m_bChonKhuDVC_ As Boolean, ByVal m_bChonXuong_ As Boolean, ByVal m_sXuong As String)
        Me.ChonKhu = 0
        Me.KHU = ""
        If m_bChonTCT_ Then
            Me.ChonTCT = 1
        Else
            Me.ChonTCT = 0
        End If

        If m_bChonKhuA_ Then
            Me.ChonKhu = 1
            Me.KHU = "A"
        End If

        If m_bChonKhuB_ Then
            Me.ChonKhu = 1
            Me.KHU = "B"
        End If

        If m_bChonKhuDVC_ Then
            Me.ChonKhu = 1
            Me.KHU = "DVC"
        End If


        If m_bChonXuong_ Then
            Me.ChonXuong = 1
            Me.XUONG = m_sXuong
        Else
            Me.ChonXuong = 0
            Me.XUONG = ""
        End If


    End Sub
    Public Property XemDonviDD() As Integer
        Get
            Return Me.m_iXemtheoDD
        End Get
        Set(ByVal Value As Integer)
            Me.m_iXemtheoDD = Value
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
    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAY = Value
        End Set
    End Property
    Public Property DONVI() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property XUONG() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property ChonXuong() As Integer
        Get
            Return Me.m_bChonXuong
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChonXuong = Value
        End Set
    End Property
    Public Property ChonKhu() As Integer
        Get
            Return Me.m_iChonKhu
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonKhu = Value
        End Set
    End Property
    Public Property ChonTCT() As Integer
        Get
            Return Me.m_bChonTCT
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChonTCT = Value
        End Set
    End Property
    Public Property ChonDonvi() As Integer
        Get
            Return Me.m_bChonDonvi
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChonDonvi = Value
        End Set
    End Property
    Public Property KHU() As String
        Get
            Return Me.m_sKHU
        End Get
        Set(ByVal Value As String)
            Me.m_sKHU = Value
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
    Public m_sNGAY As String
    Public m_sDV As String
    Public m_sXuong As String
    Public m_sKHU As String
    Public m_bChonXuong As Integer
    Public m_iChonKhu As Integer
    Public m_bChonTCT As Integer
    Public m_bChonDonvi As Integer


    Public m_sChonTable As Integer
    Public m_sNgayDauTuan As String
    Public m_sNgayCuoiTuan As String
    Public m_idNgay As Integer
    Public m_iyNgay As Integer
    Public m_imNgay As Integer
    Public m_iXemtheoDD As Integer
End Class
