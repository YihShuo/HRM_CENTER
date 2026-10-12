''' ===== Ngày tạo: 
''' ===== Ngày cập nhật: 20/05/2014
''' ===== Người cập nhật: Trân
''' ===== Nội dung: bổ sung cột ngày hoàn vốn và check đã hoàn vốn
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Public Class Obj_CBCNV_VayVonNganHang
    Dim flag As Boolean
    Public Overridable Function setnull()
        Me.NV_MA = ""
        Me.NGAYBD = Now.Date
        Me.NGAYHOANVON = Now.Date
        Me.Thoiviec = 0
        Me.HoanVon = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal MaNV As String, ByVal Ngaybd As Date, ByVal bThoiviec As Boolean, ByVal bHoanVon As Boolean) As Boolean
        Me.NV_MA = MaNV
        Me.NGAYBD = Ngaybd
        Me.Thoiviec = bThoiviec
        Me.HoanVon = bHoanVon
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
    Public Property NV_MA_Luoi() As String
        Get
            Return Me.m_sManvLuoi
        End Get
        Set(ByVal Value As String)
            Me.m_sManvLuoi = Value
        End Set
    End Property
    Public Property NV_CMND() As String
        Get
            Return Me.m_sCMND
        End Get
        Set(ByVal Value As String)
            Me.m_sCMND = Value
        End Set
    End Property
    Public Property SOTAIKHOAN() As String
        Get
            Return Me.m_sSOTAIKHOAN
        End Get
        Set(ByVal Value As String)
            Me.m_sSOTAIKHOAN = Value
        End Set
    End Property
    Public Property NGAYBD() As String
        Get
            Return Me.m_sNgaybd
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaybd = Value
        End Set
    End Property
    Public Property NGAYHOANVON() As String
        Get
            Return Me.m_sNgayhoanvon
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayhoanvon = Value
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
    Public Property NV_NGAYVAO() As Date
        Get
            Return Me.m_dNgayvao
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayvao = Value
        End Set
    End Property
    Public Property VayVon() As Boolean
        Get
            Return Me.m_bVayvon
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bVayvon = Value
        End Set
    End Property
    Public Property HoanVon() As Integer
        Get
            Return Me.m_bHoanvon
        End Get
        Set(ByVal Value As Integer)
            Me.m_bHoanvon = Value
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
    Public Property ChonDonvi() As Boolean
        Get
            Return Me.m_bChondonvi
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChondonvi = Value
        End Set
    End Property
    Public Property TenCot() As String
        Get
            Return Me.m_sTenCot
        End Get
        Set(ByVal Value As String)
            Me.m_sTenCot = Value
        End Set
    End Property
    Public Property TimNgayHoanVon() As Integer
        Get
            Return Me.m_iTimNgayHV
        End Get
        Set(ByVal Value As Integer)
            Me.m_iTimNgayHV = Value
        End Set
    End Property
    Public Function KtMa() As Boolean
        Return (StringType.StrCmp(Me.m_sManv, "", False) <> 0)
    End Function
    Public Function KtTen() As Boolean
        Return (StringType.StrCmp(Me.m_sHoTen, "", False) <> 0)
    End Function

    Public m_sManv As String
    Public m_sCMND As String
    Public m_sHoTen As String
    Public m_sDonvi As String
    Public m_dNgayvao As Date
    Public m_dNgaythoiviec As Date
    Public m_sLoaithoiviec As String
    Public m_sLydothoiviec As String
    Public m_sSOTAIKHOAN As String
    Public m_sNgaybd As String
    Public m_sNgayhoanvon As String
    Public m_sTenCot As String
    Public m_sManvLuoi As String

    Public m_bVayvon As Boolean
    Public m_bHoanvon As Integer
    Public m_bThoiviec As Boolean
    Public m_bChondonvi As Boolean
    Public m_sChonTable As Integer
    Public m_iTimNgayHV As Integer
End Class
