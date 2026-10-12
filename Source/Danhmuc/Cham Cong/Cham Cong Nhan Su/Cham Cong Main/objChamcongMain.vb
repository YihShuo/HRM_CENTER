Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objChamcongMain

    ' Methods
    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ID = ""
        Me.ChonBang = 0
        Me.Ngay = ""
        Me.DonVi = ""
        Me.Thang = ""
        Me.Nam = ""
        Me.FlagChamCong = False
        Me.FlagChamVaoRa = False

        Me.TuNgay = CDate("2001-01-01")
        Me.DenNgay = CDate("2001-01-01")
        Me.TinhTangCaSom = 0
        Me.LuonTinhDuCong = 0
        Me.TinhTangCa = 0
        Me.KhongTinhDiTre = 0
        Me.KhongTinhQuenQuetThe = 0
        Me.LuonTinhDiTre = 0
        Me.LuonTinhQuenQuetThe = 0
        Me.GioiHanTangCaToiDa = 0
        Me.GiaiLaoTangCa = 0
        Me.TinhLamDemTuLuc = 0
        Me.TinhDuCongKhiDiDu = 0
        Me.sGioiHanTangCaToiDa = ""
        Me.sGiaiLaoTangCa = ""
        Me.sTinhLamDemTuLuc = ""
        Me.sTinhDuCongKhiDiDu = ""
        Me.HeSoNgayCong = ""
        Me.CA_Ma = ""
        Me.GioVaoTay = ""
        Me.GioRaTay = ""


        Return flag
    End Function

    Public Function setvalue(ByVal sTungay As String, ByVal sDenngay As String, ByVal bTinhtangcasom As Boolean, ByVal bLuontinhducong As Boolean, ByVal bTinhtangca As Boolean, ByVal bKhongtinhditre As Boolean, ByVal bKhongtinhquenquetthe As Boolean, ByVal bLuontinhditre As Boolean, ByVal bLuontinhquenquetthe As Boolean, ByVal bGioihantangcatoida As Boolean, ByVal bGiailaotangca As Boolean, ByVal bTinhlamdemtuluc As Boolean, ByVal bTinhducongkhididu As Boolean, ByVal sGioihantangcatoida As String, ByVal sGiailaotangca As String, ByVal sTinhlamdemtuluc As String, ByVal sTinhducongkhididu As String, ByVal sHesongaycong As String) As Boolean
        Dim flag As Boolean

        Me.TuNgay = sTungay
        Me.DenNgay = sDenngay

        If bTinhtangcasom = True Then
            Me.TinhTangCaSom = 1
        Else
            Me.TinhTangCaSom = 0
        End If

        If bLuontinhducong = True Then
            Me.LuonTinhDuCong = 1
        Else
            Me.LuonTinhDuCong = 0
        End If

        If bTinhtangca = True Then
            Me.TinhTangCa = 1
        Else
            Me.TinhTangCa = 0
        End If
        
        If bKhongtinhditre = True Then
            Me.KhongTinhDiTre = 1
        Else
            Me.KhongTinhDiTre = 0
        End If

        If bKhongtinhquenquetthe = True Then
            Me.KhongTinhQuenQuetThe = 1
        Else
            Me.KhongTinhQuenQuetThe = 0
        End If

        If bLuontinhditre = True Then
            Me.LuonTinhDiTre = 1
        Else
            Me.LuonTinhDiTre = 0
        End If

        If bLuontinhquenquetthe = True Then
            Me.LuonTinhQuenQuetThe = 1
        Else
            Me.LuonTinhQuenQuetThe = 0
        End If

        If bGioihantangcatoida = True Then
            Me.GioiHanTangCaToiDa = 1
        Else
            Me.GioiHanTangCaToiDa = 0
        End If

        If bGiailaotangca = True Then
            Me.GiaiLaoTangCa = 1
        Else
            Me.GiaiLaoTangCa = 0
        End If

        If bTinhlamdemtuluc = True Then
            Me.TinhLamDemTuLuc = 1
        Else
            Me.TinhLamDemTuLuc = 0
        End If

        If bTinhducongkhididu = True Then
            Me.TinhDuCongKhiDiDu = 1
        Else
            Me.TinhDuCongKhiDiDu = 0
        End If

        Me.sGioiHanTangCaToiDa = sGioihantangcatoida
        Me.sGiaiLaoTangCa = sGiailaotangca
        Me.sTinhLamDemTuLuc = sTinhlamdemtuluc
        Me.sTinhDuCongKhiDiDu = sTinhducongkhididu
        Me.HeSoNgayCong = sHesongaycong

        Return flag
    End Function
    Public m_sNGAYCN As String
    Public m_sNGUOICN As String
    '' Properties
    Public Property ChonKhu() As String
        Get
            Return Me.m_sChonKhu
        End Get
        Set(ByVal Value As String)
            Me.m_sChonKhu = Value
        End Set
    End Property
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property
    Public Property DNgay() As String
        Get
            Return Me.m_sDNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sDNGAY = value
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

    Public Property Ngay() As String
        Get
            Return Me.m_sNgay
        End Get
        Set(ByVal Value As String)
            Me.m_sNgay = Value
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
    Public Property DonViPro() As String
        Get
            Return Me.m_sDonviPro
        End Get
        Set(ByVal Value As String)
            Me.m_sDonviPro = Value
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
    Public Property LoaiDonViNghiViec() As Integer
        Get
            Return Me.m_iLoaiDonviNghiViec
        End Get
        Set(ByVal Value As Integer)
            Me.m_iLoaiDonviNghiViec = Value
        End Set
    End Property
    Public Property NGAYCN() As String
        Get
            Return Me.m_sNGAYCN
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCN = Value
        End Set
    End Property
    Public Property NGUOICN() As String
        Get
            Return Me.m_sNGUOICN
        End Get
        Set(ByVal Value As String)
            Me.m_sNGUOICN = Value
        End Set
    End Property
    Public Property NgayChamCong() As Date
        Get
            Return Me.m_dNgaychamcong
        End Get
        Set(ByVal Value As Date)
            Me.m_dNgaychamcong = Value
        End Set
    End Property

    Public Property TuNgay() As Date
        Get
            Return Me.m_sTungay
        End Get
        Set(ByVal Value As Date)
            Me.m_sTungay = Value
        End Set
    End Property

    Public Property DenNgay() As Date
        Get
            Return Me.m_sDenngay
        End Get
        Set(ByVal Value As Date)
            Me.m_sDenngay = Value
        End Set
    End Property

    Public Property LuonTinhDuCong() As Integer
        Get
            Return Me.m_bLuontinhducong
        End Get
        Set(ByVal Value As Integer)
            Me.m_bLuontinhducong = Value
        End Set
    End Property

    Public Property TinhTangCa() As Integer
        Get
            Return Me.m_bTinhtangca
        End Get
        Set(ByVal Value As Integer)
            Me.m_bTinhtangca = Value
        End Set
    End Property
    Public Property TinhTangCaSom() As Integer
        Get
            Return Me.m_bTinhtangcasom
        End Get
        Set(ByVal Value As Integer)
            Me.m_bTinhtangcasom = Value
        End Set
    End Property

    Public Property KhongTinhDiTre() As Integer
        Get
            Return Me.m_bKhongtinhditre
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhongtinhditre = Value
        End Set
    End Property

    Public Property KhongTinhQuenQuetThe() As Integer
        Get
            Return Me.m_bKhongtinhquenquetthe
        End Get
        Set(ByVal Value As Integer)
            Me.m_bKhongtinhquenquetthe = Value
        End Set
    End Property

    Public Property LuonTinhDiTre() As Integer
        Get
            Return Me.m_bLuontinhditre
        End Get
        Set(ByVal Value As Integer)
            Me.m_bLuontinhditre = Value
        End Set
    End Property

    Public Property LuonTinhQuenQuetThe() As Integer
        Get
            Return Me.m_bLuontinhquenquetthe
        End Get
        Set(ByVal Value As Integer)
            Me.m_bLuontinhquenquetthe = Value
        End Set
    End Property

    Public Property GioiHanTangCaToiDa() As Integer
        Get
            Return Me.m_bGioihantangcatoida
        End Get
        Set(ByVal Value As Integer)
            Me.m_bGioihantangcatoida = Value
        End Set
    End Property

    Public Property GiaiLaoTangCa() As Integer
        Get
            Return Me.m_bGiailaotangca
        End Get
        Set(ByVal Value As Integer)
            Me.m_bGiailaotangca = Value
        End Set
    End Property

    Public Property TinhLamDemTuLuc() As Integer
        Get
            Return Me.m_bTinhlamdemtuluc
        End Get
        Set(ByVal Value As Integer)
            Me.m_bTinhlamdemtuluc = Value
        End Set
    End Property

    Public Property TinhDuCongKhiDiDu() As Integer
        Get
            Return Me.m_bTinhducongkhididu
        End Get
        Set(ByVal Value As Integer)
            Me.m_bTinhducongkhididu = Value
        End Set
    End Property

    Public Property sGioiHanTangCaToiDa() As String
        Get
            Return Me.m_sGioihantangcatoida
        End Get
        Set(ByVal Value As String)
            Me.m_sGioihantangcatoida = Value
        End Set
    End Property

    Public Property sGiaiLaoTangCa() As String
        Get
            Return Me.m_sGiailaotangca
        End Get
        Set(ByVal Value As String)
            Me.m_sGiailaotangca = Value
        End Set
    End Property

    Public Property sTinhLamDemTuLuc() As String
        Get
            Return Me.m_sTinhlamdemtuluc
        End Get
        Set(ByVal Value As String)
            Me.m_sTinhlamdemtuluc = Value
        End Set
    End Property

    Public Property sTinhDuCongKhiDiDu() As String
        Get
            Return Me.m_sTinhducongkhididu
        End Get
        Set(ByVal Value As String)
            Me.m_sTinhducongkhididu = Value
        End Set
    End Property

    Public Property HeSoNgayCong() As String
        Get
            Return Me.m_sHesongaycong
        End Get
        Set(ByVal Value As String)
            Me.m_sHesongaycong = Value
        End Set
    End Property

    Public Property NV_MA() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
        End Set
    End Property

    Public Property CA_Ma() As String
        Get
            Return Me.m_sCa
        End Get
        Set(ByVal Value As String)
            Me.m_sCa = Value
        End Set
    End Property

    Public Property GioVaoTay() As String
        Get
            Return Me.m_sGiovaotay
        End Get
        Set(ByVal Value As String)
            Me.m_sGiovaotay = Value
        End Set
    End Property

    Public Property GioRaTay() As String
        Get
            Return Me.m_sGioratay
        End Get
        Set(ByVal Value As String)
            Me.m_sGioratay = Value
        End Set
    End Property

    Public Property FlagChamCong() As Boolean
        Get
            Return Me.m_bChamcong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChamcong = Value
        End Set
    End Property

    Public Property FlagChamVaoRa() As Boolean
        Get
            Return Me.m_bChamvaora
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bChamvaora = Value
        End Set
    End Property
    Public Property TongGioCong() As String
        Get
            Return Me.m_sTongGioCong
        End Get
        Set(ByVal Value As String)
            Me.m_sTongGioCong = Value
        End Set
    End Property
    Public Property ChenhLech() As String
        Get
            Return Me.m_sChenhLech
        End Get
        Set(ByVal Value As String)
            Me.m_sChenhLech = Value
        End Set
    End Property
    Public Property ChamCom() As String
        Get
            Return Me.m_bChamCom
        End Get
        Set(ByVal Value As String)
            Me.m_bChamCom = Value
        End Set
    End Property
    Public Property FlagChamCom() As Boolean
        Get
            Return Me.m_bCoChamCom
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bCoChamCom = Value
        End Set
    End Property
    Public Property NGUOIDUNG() As String
        Get
            Return Me.m_snguoidung
        End Get
        Set(ByVal Value As String)
            Me.m_snguoidung = Value
        End Set
    End Property
    Public Property MA_DM() As String
        Get
            Return Me.m_sMA_DM
        End Get
        Set(ByVal Value As String)
            Me.m_sMA_DM = Value
        End Set
    End Property
    Public Property CHUOITHAOTAC() As String
        Get
            Return Me.m_sChuoiThaoTac
        End Get
        Set(ByVal Value As String)
            Me.m_sChuoiThaoTac = Value
        End Set
    End Property
    Public Property DITRE() As Integer
        Get
            Return Me.m_bDiTre
        End Get
        Set(ByVal Value As Integer)
            Me.m_bDiTre = Value
        End Set
    End Property
    Public Property SAIQD() As Integer
        Get
            Return Me.m_bSAIQD
        End Get
        Set(ByVal Value As Integer)
            Me.m_bSAIQD = Value
        End Set
    End Property
    Public m_bDiTre As Integer
    Public m_bSAIQD As Integer

    Public m_sMA_DM As String
    Public m_snguoidung As String
    Public m_sChuoiThaoTac As String
    ' Fields
    Public m_bCoChamCom As Boolean
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sNgay As String
    Public m_sDonvi As String
    Public m_sDonviPro As String
    Public m_sThang As String
    Public m_sNam As String
    PUBLIC m_iLoaiDonviNghiViec AS Integer 
    Public m_dNgaychamcong As Date
    Public m_sTungay As Date
    Public m_sDenngay As Date
    Public m_bLuontinhducong As Integer
    Public m_bTinhtangca As Integer
    Public m_bTinhtangcasom As Integer
    Public m_bKhongtinhditre As Integer
    Public m_bKhongtinhquenquetthe As Integer
    Public m_bLuontinhditre As Integer
    Public m_bLuontinhquenquetthe As Integer
    Public m_bGioihantangcatoida As Integer
    Public m_bGiailaotangca As Integer
    Public m_bTinhlamdemtuluc As Integer
    Public m_bTinhducongkhididu As Integer

    Public m_sGioihantangcatoida As String
    Public m_sGiailaotangca As String
    Public m_sTinhlamdemtuluc As String
    Public m_sTinhducongkhididu As String
    Public m_sHesongaycong As String
    Public m_sNvma As String
    Public m_bChamcong As Boolean
    Public m_bChamvaora As Boolean
    Public m_sCa As String
    Public m_sGiovaotay As String
    Public m_sTongGioCong As String
    Public m_sChenhLech As String
    Public m_sGioratay As String

    Public m_bChamCom As String
    Public m_sChonKhu As String
    Public m_sDNGAY As String
End Class


