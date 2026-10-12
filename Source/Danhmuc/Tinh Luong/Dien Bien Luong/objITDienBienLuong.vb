Public Class objITDienBienLuong
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.LUONG = ""
        Me.FlagChamCong = False
        Me.SoQD = ""
        Me.PhuCap = ""
        Me.HESO = ""
        Me.ChucVu = ""
        Me.CongViec = ""
        Me.DHNN = 0
        Me.LDCM = 0
        Me.ChonBang = 0
        Me.PhuCapKhac = ""
        Me.TrocapCV = ""
        Me.TrocapUDMAY = ""
        Me.TrocapCMNV = ""
        Me.TrocapNN = ""
        Me.TrocapHMPT = ""
        Me.TrocapMT = ""
        Me.TroCapQLSX = ""
        Me.TroCapCBVP = ""
        Me.TroCapBBNT = ""
        Me.TroCapBBHT = ""
        Me.TroCapBBTHANG = ""
        Me.TroCapCLGD = ""
        Me.TroCapHTDP = ""
        Me.TroCapQAQIP = ""
        Me.TrocapThoRap = ""
        Me.TrocapHSE = ""
        Me.KHONGCC = 0
        Me.PHUCLOI = ""
        Me.HTNG = ""
        Me.DQTV = ""
        Me.PCCC = ""
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal ngay As String, ByVal so As String, ByVal hs As String, ByVal l As String, ByVal pc As String, ByVal cv As String, ByVal cvu As String, ByVal pDHNN As Integer, ByVal pLDCM As Integer, ByVal m_ChonTable As Integer, ByVal m_PhuCapKhac As String, ByVal m_TrocapCV As String, ByVal m_TrocapUDMAY As String, ByVal m_TrocapCMNV As String, ByVal m_TrocapNN As String, ByVal m_TrocapHMPT As String, ByVal m_TrocapMT As String, ByVal m_TroCapQLSX As String, ByVal m_TroCapCBVP As String, ByVal m_TroCapBBNT As String, ByVal m_TroCapBBHT As String, ByVal m_TroCapBBTHANG As String, ByVal m_TroCapCLGD As String, ByVal m_TroCapHTDP As String, ByVal m_TroCapQAQIP As String, ByVal m_TrocapThoRap As String, ByVal m_TrocapHSE As String, ByVal pKHONGCC As Integer, ByVal m_PHUCLOI As String, ByVal m_HTNG As String, ByVal m_DQTV As String, ByVal m_PCCC As String) As Boolean
        Me.MANV = manhanvien
        Me.NGAY = ngay
        Me.SoQD = so
        Me.HESO = hs
        Me.LUONG = l
        Me.PhuCap = pc
        Me.CongViec = cv
        Me.ChucVu = cvu
        Me.PhuCapKhac = m_PhuCapKhac
        Me.TrocapCV = m_TrocapCV
        Me.TrocapUDMAY = m_TrocapUDMAY
        Me.TrocapCMNV = m_TrocapCMNV
        Me.TrocapNN = m_TrocapNN
        Me.TrocapHMPT = m_TrocapHMPT
        Me.TrocapMT = m_TrocapMT
        Me.TroCapQLSX = m_TroCapQLSX
        Me.TroCapCBVP = m_TroCapCBVP
        Me.TroCapBBNT = m_TroCapBBNT
        Me.TroCapBBHT = m_TroCapBBHT
        Me.TroCapBBTHANG = m_TroCapBBTHANG
        Me.TroCapCLGD = m_TroCapCLGD
        Me.TroCapHTDP = m_TroCapHTDP
        Me.TroCapQAQIP = m_TroCapQAQIP
        Me.TrocapThoRap = m_TrocapThoRap
        Me.TrocapHSE = m_TrocapHSE
        If pDHNN = 1 Then
            m_sDHNN = 1
        Else
            m_sDHNN = 0
        End If
        If pKHONGCC = 1 Then
            m_sKHONGCC = 1
        Else
            m_sKHONGCC = 0
        End If
        Me.KHONGCC = m_sKHONGCC
        Me.PHUCLOI = m_PHUCLOI
        Me.HTNG = m_HTNG
        Me.DQTV = m_DQTV
        Me.PCCC = m_PCCC
        If pLDCM = 1 Then
            m_sLDCM = 1
        Else
            m_sLDCM = 0
        End If
        Me.LDCM = m_sLDCM
        Me.ChonBang = m_sChonTable
        Return False
    End Function


    Public m_sNGAYTAO As String

    Public m_sNGUOITAO As String
    Public m_sNGAYCN As String
    Public m_sNGUOICN As String

    Public Property NGAYTAO() As String
        Get
            Return Me.m_sNGAYTAO
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYTAO = Value
        End Set
    End Property
    Public Property NGUOITAO() As String
        Get
            Return Me.m_sNGUOITAO
        End Get
        Set(ByVal Value As String)
            Me.m_sNGUOITAO = Value
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
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
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
    Public Property NAM() As String
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal Value As String)
            Me.m_sNAM = Value
        End Set
    End Property
    
    Public Property HESO() As String
        Get
            Return Me.m_sHESO
        End Get
        Set(ByVal Value As String)
            Me.m_sHESO = Value
        End Set
    End Property
    Public Property LUONG() As String
        Get
            Return Me.m_sLUONGCB
        End Get
        Set(ByVal Value As String)
            Me.m_sLUONGCB = Value
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
    Public Property SoQD() As String
        Get
            Return Me.m_sSoQD
        End Get
        Set(ByVal Value As String)
            Me.m_sSoQD = Value
        End Set
    End Property
    Public Property PhuCap() As String
        Get
            Return Me.m_sPhuCap
        End Get
        Set(ByVal Value As String)
            Me.m_sPhuCap = Value
        End Set
    End Property
    Public Property CongViec() As String
        Get
            Return Me.m_sCongViec
        End Get
        Set(ByVal Value As String)
            Me.m_sCongViec = Value
        End Set
    End Property
    Public Property ChucVu() As String
        Get
            Return Me.m_sChucVu
        End Get
        Set(ByVal Value As String)
            Me.m_sChucVu = Value
        End Set
    End Property
    Public Property DHNN() As Integer
        Get
            Return Me.m_sDHNN
        End Get
        Set(ByVal Value As Integer)
            Me.m_sDHNN = Value
        End Set
    End Property
    Public Property KHONGCC() As Integer
        Get
            Return Me.m_sKHONGCC
        End Get
        Set(ByVal Value As Integer)
            Me.m_sKHONGCC = Value
        End Set
    End Property
    Public Property LDCM() As Integer
        Get
            Return Me.m_sLDCM
        End Get
        Set(ByVal Value As Integer)
            Me.m_sLDCM = Value
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
    Public Property ChonBang() As Integer
        Get
            Return Me.m_sChonTable
        End Get
        Set(ByVal Value As Integer)
            Me.m_sChonTable = Value
        End Set
    End Property
    Public Property PhuCapKhac() As String
        Get
            Return Me.m_sPhuCapKhac
        End Get
        Set(ByVal Value As String)
            Me.m_sPhuCapKhac = Value
        End Set
    End Property
    Public Property TrocapCV() As String
        Get
            Return Me.m_sTrocapCV
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapCV = Value
        End Set
    End Property
    Public Property TrocapUDMAY() As String
        Get
            Return Me.m_sTrocapUDMAY
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapUDMAY = Value
        End Set
    End Property
    Public Property TrocapMT() As String
        Get
            Return Me.m_sTrocapMT
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapMT = Value
        End Set
    End Property
    Public Property TrocapCMNV() As String
        Get
            Return Me.m_sTrocapCMNV
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapCMNV = Value
        End Set
    End Property
    Public Property TrocapNN() As String
        Get
            Return Me.m_sTrocapNN
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapNN = Value
        End Set
    End Property
    Public Property TrocapHMPT() As String
        Get
            Return Me.m_sTrocapHMPT
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapHMPT = Value
        End Set
    End Property
    Public Property TroCapQLSX() As String
        Get
            Return Me.m_sTroCapQLSX
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapQLSX = Value
        End Set
    End Property
    Public Property TroCapCBVP() As String
        Get
            Return Me.m_sTroCapCBVP
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapCBVP = Value
        End Set
    End Property
    Public Property TroCapBBNT() As String
        Get
            Return Me.m_sTroCapBBNT
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapBBNT = Value
        End Set
    End Property
    Public Property TroCapBBHT() As String
        Get
            Return Me.m_sTroCapBBHT
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapBBHT = Value
        End Set
    End Property
    Public Property TroCapBBTHANG() As String
        Get
            Return Me.m_sTroCapBBTHANG
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapBBTHANG = Value
        End Set
    End Property
    Public Property TroCapCLGD() As String
        Get
            Return Me.m_sTroCapCLGD
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapCLGD = Value
        End Set
    End Property
    Public Property TroCapHTDP() As String
        Get
            Return Me.m_sTroCapHTDP
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapHTDP = Value
        End Set
    End Property
    Public Property TroCapQAQIP() As String
        Get
            Return Me.m_sTroCapQAQIP
        End Get
        Set(ByVal Value As String)
            Me.m_sTroCapQAQIP = Value
        End Set
    End Property
    Public Property TrocapThoRap() As String
        Get
            Return Me.m_sTrocapThoRap
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapThoRap = Value
        End Set
    End Property
    Public Property PHUCLOI() As String
        Get
            Return Me.m_sPHUCLOI
        End Get
        Set(ByVal Value As String)
            Me.m_sPHUCLOI = Value
        End Set
    End Property
    Public Property HTNG() As String
        Get
            Return Me.m_sHTNG
        End Get
        Set(ByVal Value As String)
            Me.m_sHTNG = Value
        End Set
    End Property

    Public Property DQTV() As String
        Get
            Return Me.m_sDQTV
        End Get
        Set(ByVal Value As String)
            Me.m_sDQTV = Value
        End Set
    End Property
    Public Property PCCC() As String
        Get
            Return Me.m_sPCCC
        End Get
        Set(ByVal Value As String)
            Me.m_sPCCC = Value
        End Set
    End Property
    Public Property TrocapHSE() As String
        Get
            Return Me.m_sTrocapHSE
        End Get
        Set(ByVal Value As String)
            Me.m_sTrocapHSE = Value
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
    Public Property CHONDONVINGHIVIEC() As Integer
        Get
            Return Me.m_iChonDVNghiViec
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonDVNghiViec = Value
        End Set
    End Property
    Public Property TenDangNhap() As String
        Get
            Return Me.m_sTendangnhap
        End Get
        Set(ByVal Value As String)
            Me.m_sTendangnhap = Value
        End Set
    End Property
    Public Property Truyvan() As String
        Get
            Return Me.m_sTruyvan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyvan = Value
        End Set
    End Property
    Public Property Thoigian() As DateTime
        Get
            Return Me.m_dTgian
        End Get
        Set(ByVal Value As DateTime)
            Me.m_dTgian = Value
        End Set
    End Property
    Public m_sTendangnhap As String
    Public m_sTruyvan As String
    Public m_dTgian As DateTime
    Public m_sMA_DM As String
    Public m_snguoidung As String
    Public m_sMANV As String
    Public m_sLUONGCB As String
    Public m_sDV As String
    Public m_sSoQD As String
    Public m_sHESO As String
    Public m_sPhuCap As String
    Public m_sNGAY As String
    Public m_sNAM As String
    Public m_sChonTable As Integer
    Public m_bChamcong As Boolean
    Public m_sCongViec As String
    Public m_sDHNN As Integer
    Public m_sLDCM As Integer
    Public m_sKHONGCC As Integer
    Public m_sChucVu As String
    Public m_sPhuCapKhac As String
    Public m_sTrocapCV As String
    Public m_sTrocapUDMAY As String
    Public m_sTrocapCMNV As String
    Public m_sTrocapNN As String
    Public m_sTrocapHMPT As String
    Public m_sTroCapQLSX As String
    Public m_sTroCapCBVP As String
    Public m_sTroCapBBNT As String
    Public m_sTroCapBBHT As String
    Public m_sTroCapBBTHANG As String
    Public m_sTroCapCLGD As String
    Public m_sTroCapHTDP As String
    Public m_sTroCapQAQIP As String
    Public m_sTrocapThoRap As String
    Public m_sTrocapHSE As String
    Public m_sTrocapMT As String
    Public m_iChonDVNghiViec As Integer
    Public m_sPHUCLOI As String
    Public m_sHTNG As String
    Public m_sDQTV As String
    Public m_sPCCC As String

End Class
