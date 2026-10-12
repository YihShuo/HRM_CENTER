Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class ObjTheoDoiMangThaiDenNC12Thang
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.DV_MA = ""
        Me.DonVi = ""
        Me.NV_MA = ""
        Me.ChonBang = 0
        Me.TruyVan = ""
        m_sHoten = ""
        Me.Chitra1 = 0
        Me.Chitra2 = 0
        Me.Chitra3 = 0
        Me.Chitra4 = 0
        Me.Chitra5 = 0
        Return flag
    End Function
    '' Properties
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
        End Set
    End Property

    Public Property SoLanChiTra() As Integer
        Get
            Return Me.m_iSolanchitra
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSolanchitra = Value
        End Set
    End Property
    ''so the
    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property
    ''ho ten nhan vien
    Public Property HOTEN() As String
        Get
            Return Me.m_sHoten
        End Get
        Set(ByVal Value As String)
            Me.m_sHoten = Value
        End Set
    End Property
    'don vi
    Public Property DV_MA() As String
        Get
            Return Me.m_sDvma
        End Get
        Set(ByVal Value As String)
            Me.m_sDvma = Value
        End Set
    End Property
    Public Property Ngayvaocongty() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
        End Set
    End Property
    Public Property CONGVIEC() As String
        Get
            Return Me.m_scongviec
        End Get
        Set(ByVal Value As String)
            Me.m_scongviec = Value
        End Set
    End Property
    Public Property CHUCVU() As String
        Get
            Return Me.m_schucvu
        End Get
        Set(ByVal Value As String)
            Me.m_schucvu = Value
        End Set
    End Property
    Public Property TruyVan() As String
        Get
            Return Me.m_sTruyvan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyvan = Value
        End Set
    End Property
    ''NGAY MANG THAI
    Public Property Ngaymangthai() As String
        Get
            Return Me.m_sNgaymangthai
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaymangthai = Value
        End Set
    End Property
    've 15h30 va tu ngay trong thang thu 7
    Public Property NgayVe15H30() As Date
        Get
            Return Me.m_dNgayve15h30
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayve15h30 = Value
        End Set
    End Property

    Public Property DonVi() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property

    Public Property Tunam() As String
        Get
            Return Me.m_sTunam
        End Get
        Set(ByVal Value As String)
            Me.m_sTunam = Value
        End Set
    End Property
    Public Property Dennam() As String
        Get
            Return Me.m_sDennam
        End Get
        Set(ByVal Value As String)
            Me.m_sDennam = Value
        End Set
    End Property
    Public Property Xuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property Thang() As String
        Get
            Return Me.m_sThang
        End Get
        Set(ByVal Value As String)
            Me.m_sThang = Value
        End Set
    End Property
    Public Property Nam() As String
        Get
            Return Me.m_sNam
        End Get
        Set(ByVal Value As String)
            Me.m_sNam = Value
        End Set
    End Property
    Public Property NgayKhamThai() As Date
        Get
            Return Me.m_dNgaykhamthai
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaykhamthai = Value
        End Set
    End Property
    ''lan kham thai
    Public Property KThaiLan1() As Date
        Get
            Return Me.m_dNKthailan1
        End Get
        Set(ByVal Value As Date)
            Me.m_dNKthailan1 = Value
        End Set
    End Property
    Public Property KThaiLan2() As Date
        Get
            Return Me.m_dNKthailan2
        End Get
        Set(ByVal Value As Date)
            Me.m_dNKthailan2 = Value
        End Set
    End Property
    Public Property KThaiLan3() As Date
        Get
            Return Me.m_dNKthailan3
        End Get
        Set(ByVal Value As Date)
            Me.m_dNKthailan3 = Value
        End Set
    End Property
    Public Property KThaiLan4() As Date
        Get
            Return Me.m_dNKthailan4
        End Get
        Set(ByVal Value As Date)
            Me.m_dNKthailan4 = Value
        End Set
    End Property
    Public Property KThaiLan5() As Date
        Get
            Return Me.m_dNKthailan5
        End Get
        Set(ByVal Value As Date)
            Me.m_dNKthailan5 = Value
        End Set
    End Property
    ''ket thuc thai thang thu 7
    Public Property NgayDuSinh() As Date
        Get
            Return Me.m_dNgayDuSinh
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayDuSinh = Value
        End Set
    End Property
    Public Property SoNgayT7() As Integer
        Get
            Return Me.m_iSongaythaithangt7
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSongaythaithangt7 = Value
        End Set
    End Property
    ''bat dau nghi thai san
    Public Property NgayBDNghiTS() As Date
        Get
            Return Me.m_dNgayDuSinh
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayDuSinh = Value
        End Set
    End Property  ''
    Public Property NgayKTNghiTS() As Date
        Get
            Return Me.m_dNgayKTNghiTS
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayKTNghiTS = Value
        End Set
    End Property
    Public Property SoNgayTS() As Integer
        Get
            Return Me.m_iSongaythaisan
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSongaythaisan = Value
        End Set
    End Property
    Public Property Ngaysinhcon() As Date
        Get
            Return Me.m_dNgaysinhcon
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaysinhcon = Value
        End Set
    End Property
    ''nuoi con nho
    Public Property NgayBDNC() As Date
        Get
            Return Me.m_dNgayBDNC
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayBDNC = Value
        End Set
    End Property  ''
    Public Property NgayKTNC() As Date
        Get
            Return Me.m_dNgayKTNC
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayKTNC = Value
        End Set
    End Property
    Public Property SoNgayNC() As Integer
        Get
            Return Me.m_iSongaythaisan
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSongaythaisan = Value
        End Set
    End Property
    ''nghi duong suc
    Public Property NgayBDNDS() As Date
        Get
            Return Me.m_dNgayBDDS
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayBDDS = Value
        End Set
    End Property  ''
    Public Property NgayKTNDS() As Date
        Get
            Return Me.m_dNgayKTDS
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgayKTDS = Value
        End Set
    End Property
    Public Property SoNgayDS() As Integer
        Get
            Return Me.m_iSongayduongsuc
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSongayduongsuc = Value
        End Set
    End Property
    ''CHI TIET CAC LAN CHI TRA
    Public Property Chitra1() As Integer
        Get
            Return Me.m_bChitra1
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChitra1 = Value
        End Set
    End Property
    Public Property Chitra2() As Integer
        Get
            Return Me.m_bChitra2
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChitra2 = Value
        End Set
    End Property
    Public Property Chitra3() As Integer
        Get
            Return Me.m_bChitra3
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChitra3 = Value
        End Set
    End Property
    Public Property Chitra4() As Integer
        Get
            Return Me.m_bChitra4
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChitra4 = Value
        End Set
    End Property
    Public Property Chitra5() As Integer
        Get
            Return Me.m_bChitra5
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChitra5 = Value
        End Set
    End Property
    Public Property NgayKhamThaiDoi() As String
        Get
            Return Me.m_dNgaykhamthaiChiTra
        End Get
        Set(ByVal Value As String)
            Me.m_dNgaykhamthaiChiTra = Value
        End Set
    End Property
    Public Property SoTienCT_CN() As Integer
        Get
            Return Me.m_iSotien
        End Get
        Set(ByVal Value As Integer)
            Me.m_iSotien = Value
        End Set
    End Property
    Public m_sID As String
    Public m_iSotien As Integer
    Public m_iChonbang As Integer
    Public m_iSolanchitra As Integer
    Public m_iSongaythaithangt7 As Integer
    Public m_iSongaythaisan As Integer
    Public m_iSongayduongsuc As Integer
    Public m_sNgay As String
    Public m_sNvma As String
    Public m_sHoten As String
    Public m_sDonvi As String
    Public m_schucvu As String
    Public m_scongviec As String
    Public m_sXuong As String
    Public m_sThang As String
    Public m_sNam As String
    Public m_dNgaykhamthaiChiTra As string


    Public m_dNgaykhamthai As Date
    Public m_dNKthailan1 As Date
    Public m_dNKthailan2 As Date
    Public m_dNKthailan3 As Date
    Public m_dNKthailan4 As Date
    Public m_dNKthailan5 As Date
    Public m_dNgaysinhcon As Date

    Public m_dNgayve15h30 As Date

    Public m_sNgaymangthai As String
    Public m_dNgayDuSinh As Date
    Public m_dNgayBDNghiTS As Date
    Public m_dNgayKTNghiTS As Date
    Public m_dNgayBDNC As Date
    Public m_dNgayKTNC As Date
    Public m_dNgayBDDS As Date
    Public m_dNgayKTDS As Date

    Public m_sTungay As Date
    Public m_sDenngay As Date
    Public m_sDvma As String
    Public m_dTgian As Date
    Public m_sTruyvan As String
    Public m_sTendangnhap As String
    Public m_sTunam As String
    Public m_sDennam As String

    Public m_bChitra1 As Integer
    Public m_bChitra2 As Integer
    Public m_bChitra3 As Integer
    Public m_bChitra4 As Integer
    Public m_bChitra5 As Integer
End Class
