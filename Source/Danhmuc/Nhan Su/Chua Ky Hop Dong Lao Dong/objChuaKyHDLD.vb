<System.Serializable()> Public Class objChuaKyHDLD
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.TENNV = ""
        Me.NGAYVAO = ""
        Me.CV = ""
        Me.BB_TT = ""
        Me.BB_A = ""
        Me.BB_B = ""
        Me.BB_C = ""
        Me.RO = ""
        Me.OM = ""
        Me.TUNGAY = ""
        Me.DENNGAY = ""
        Me.LUONGCOBAN = ""
        Me.HESO = ""
        Me.PHUCAPKHAC = ""
        Me.TCCONGVIEC = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal ten As String, ByVal ngayv As String, ByVal congviec As String, ByVal bbtruoc As String, ByVal bba As String, ByVal bbb As String, ByVal bbc As String, ByVal r As String, ByVal o As String, ByVal hs As String, ByVal luongcb As String, ByVal luongtt As String, ByVal canbovp As String, ByVal canbots As String, ByVal bbnamtruoc As String, ByVal bbhientai As String, ByVal bbthang As String, ByVal trocapcv As String, ByVal pckhac As String, ByVal trocapcm As String, ByVal trocaphaomon As String, ByVal m_sQAQIP_ As String, ByVal m_sThoRap_ As String, ByVal m_sHSE_ As String, ByVal m_sHD_TCHOTRODONGPHUC_ As String, ByVal m_sHD_TCCHAMLOGIADINH_ As String, ByVal m_sTCMT_ As String, ByVal m_sKHONGHUONGCC_ As Integer, ByVal trocapud As String, ByVal trocapnn As String, ByVal MAB As String, ByVal TENBANGLUONG As String, ByVal TENNGA As String, ByVal NG As String, ByVal BC As String, ByVal BLUU As String, ByVal baohiemxh As Integer, ByVal baohiemyt As Integer, ByVal baohiemtn As Integer, ByVal cvdochai As Integer, ByVal tngay As String, ByVal dngay As String, ByVal bac1_ As Integer, ByVal bac2_ As Integer, ByVal bac3_ As Integer, ByVal m_ChonTable As Integer, ByVal m_HTNG As String, ByVal m_PHUCLOI As String, ByVal m_DQTV As String, ByVal m_PCCC As String) As Boolean

        Me.MANV = manhanvien
        Me.TENNV = ten
        Me.NGAYVAO = ngayv
        Me.CV = congviec
        Me.BB_TT = bbtruoc
        Me.BB_A = bba
        Me.BB_B = bbb
        Me.BB_C = bbc
        Me.RO = r
        Me.OM = o
        Me.HESO = hs
        Me.LUONGCOBAN = luongcb
        Me.LUONGTOITHIEU = luongtt
        Me.TCCONGVIEC = trocapcv
        Me.PHUCAPKHAC = pckhac
        'MOI
        Me.CBVP = canbovp
        Me.CBTS = canbots
        Me.BBNT = bbnamtruoc
        Me.BBHT = bbhientai
        Me.BBTh = bbthang

        Me.TCUUDAI = trocapud
        Me.TCCHUYENMON = trocapcm
        Me.TCNN = trocapnn
        Me.TCHAOMON = trocaphaomon
        Me.HD_TroCapQAQIP = m_sQAQIP_
        Me.HD_TrocapThoRap = m_sThoRap_
        Me.HD_TrocapHSE = m_sHSE_
        Me.HD_TCHOTRODONGPHUC = m_sHD_TCHOTRODONGPHUC_
        Me.HD_TCCHAMLOGIADINH = m_sHD_TCCHAMLOGIADINH_
        Me.TCMT = m_sTCMT_

        If m_sKHONGHUONGCC_ = True Then
            m_sKHONGHUONGCC = 1
        Else
            m_sKHONGHUONGCC = 0
        End If
        Me.KHONGHUONGCC = m_sKHONGHUONGCC
        Me.MABAC = MAB
        Me.TENBANGL = TENBANGLUONG
        Me.TENNGACH = TENNGA
        Me.NGACH = NG
        Me.BAC = BC
        Me.BACLUU = BLUU
        If bac1_ = True Then
            m_sBAC11 = 1
        Else
            m_sBAC11 = 0
        End If
        Me.BAC1 = m_sBAC11
        'BAC 2
        If bac2_ = True Then
            m_sBAC2 = 1
        Else
            m_sBAC2 = 0
        End If
        Me.BAC2 = m_sBAC2
        'BAC 3
        If bac3_ = True Then
            m_sBAC3 = 1
        Else
            m_sBAC3 = 0
        End If
        Me.BAC3 = m_sBAC3

        If baohiemyt = True Then
            m_sBHYT = 1
        Else
            m_sBHYT = 0
        End If
        Me.BHYT = m_sBHYT
        If baohiemxh = True Then
            m_sBHXH = 1
        Else
            m_sBHXH = 0
        End If
        Me.BHXH = m_sBHXH

        If baohiemtn = True Then
            m_sBHTN = 1
        Else
            m_sBHTN = 0
        End If
        Me.BHTN = m_sBHTN

        If cvdochai = True Then
            m_sDH = 1
        Else
            m_sDH = 0
        End If
        Me.DOCHAI = m_sDH


        Me.TUNGAY = tngay
        Me.DENNGAY = dngay
        Me.ChonBang = m_sChonTable
        Me.HTNG = m_HTNG
        Me.PHUCLOI = m_PHUCLOI
        Me.DQTV = m_DQTV
        Me.PCCC = m_PCCC

        Return False
    End Function
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

    Public Property BAC1() As Integer
        Get
            Return Me.m_sBAC11
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBAC11 = Value
        End Set
    End Property
    Public Property BAC2() As Integer
        Get
            Return Me.m_sBAC2
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBAC2 = Value
        End Set
    End Property
    Public Property BAC3() As Integer
        Get
            Return Me.m_sBAC3
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBAC3 = Value
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
    Public Property TENNV() As String
        Get
            Return Me.m_sTEN
        End Get
        Set(ByVal Value As String)
            Me.m_sTEN = Value
        End Set
    End Property

    Public Property TENBANGL() As String
        Get
            Return Me.m_sTENBANGL
        End Get
        Set(ByVal Value As String)
            Me.m_sTENBANGL = Value
        End Set
    End Property

    Public Property TENNGACH() As String
        Get
            Return Me.m_sTENNG
        End Get
        Set(ByVal Value As String)
            Me.m_sTENNG = Value
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
    Public Property NGAYVAO() As String
        Get
            Return Me.m_sNGAYV
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYV = Value
        End Set
    End Property

    Public Property CV() As String
        Get
            Return Me.m_sCV
        End Get
        Set(ByVal Value As String)
            Me.m_sCV = Value
        End Set
    End Property
    Public Property BB_TT() As String
        Get
            Return Me.m_sBBT
        End Get
        Set(ByVal Value As String)
            Me.m_sBBT = Value
        End Set
    End Property
    Public Property BB_A() As String
        Get
            Return Me.m_sBBA
        End Get
        Set(ByVal Value As String)
            Me.m_sBBA = Value
        End Set
    End Property
    Public Property BB_B() As String
        Get
            Return Me.m_sBBB
        End Get
        Set(ByVal Value As String)
            Me.m_sBBB = Value
        End Set
    End Property
    Public Property HD_TCCHAMLOGIADINH() As String
        Get
            Return Me.m_sHD_TCCHAMLOGIADINH
        End Get
        Set(ByVal Value As String)
            Me.m_sHD_TCCHAMLOGIADINH = Value
        End Set
    End Property

    Public Property HD_TCHOTRODONGPHUC() As String
        Get
            Return Me.m_sHD_TCHOTRODONGPHUC
        End Get
        Set(ByVal Value As String)
            Me.m_sHD_TCHOTRODONGPHUC = Value
        End Set
    End Property
   
    Public Property HD_TroCapQAQIP() As String
        Get
            Return Me.m_sQAQIP
        End Get
        Set(ByVal Value As String)
            Me.m_sQAQIP = Value
        End Set
    End Property

    Public Property HD_TrocapThoRap() As String
        Get
            Return Me.m_sThoRap
        End Get
        Set(ByVal Value As String)
            Me.m_sThoRap = Value
        End Set
    End Property
   
    Public Property KHONGHUONGCC() As Integer
        Get
            Return Me.m_sKHONGHUONGCC
        End Get
        Set(ByVal Value As Integer)
            Me.m_sKHONGHUONGCC = Value
        End Set
    End Property
  
    Public Property TCMT() As String
        Get
            Return Me.m_sTCMT
        End Get
        Set(ByVal Value As String)
            Me.m_sTCMT = Value
        End Set
    End Property
   
    Public Property HD_TrocapHSE() As String
        Get
            Return Me.m_sHSE
        End Get
        Set(ByVal Value As String)
            Me.m_sHSE = Value
        End Set
    End Property

    Public Property BB_C() As String
        Get
            Return Me.m_sBBC
        End Get
        Set(ByVal Value As String)
            Me.m_sBBC = Value
        End Set
    End Property
    Public Property RO() As String
        Get
            Return Me.m_sRO
        End Get
        Set(ByVal Value As String)
            Me.m_sRO = Value
        End Set
    End Property
    Public Property OM() As String
        Get
            Return Me.m_sOM
        End Get
        Set(ByVal Value As String)
            Me.m_sOM = Value
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
    Public Property LUONGCOBAN() As String
        Get
            Return Me.m_sLUONGCB
        End Get
        Set(ByVal Value As String)
            Me.m_sLUONGCB = Value
        End Set
    End Property
    Public Property LUONGTOITHIEU() As String
        Get
            Return Me.m_sLUONGTT
        End Get
        Set(ByVal Value As String)
            Me.m_sLUONGTT = Value
        End Set
    End Property

    Public Property BHYT() As Integer
        Get
            Return Me.m_sBHYT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBHYT = Value
        End Set
    End Property
    Public Property BHXH() As Integer
        Get
            Return Me.m_sBHXH
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBHXH = Value
        End Set
    End Property
    Public Property BHTN() As Integer
        Get
            Return Me.m_sBHTN
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBHTN = Value
        End Set
    End Property
    Public Property DOCHAI() As Integer
        Get
            Return Me.m_sDH
        End Get
        Set(ByVal Value As Integer)
            Me.m_sDH = Value
        End Set
    End Property
    Public Property BINHTHUONG() As Integer
        Get
            Return Me.m_sBT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBT = Value
        End Set
    End Property
    Public Property TCUUDAI() As String
        Get
            Return Me.m_sTCUD
        End Get
        Set(ByVal Value As String)
            Me.m_sTCUD = Value
        End Set
    End Property
    Public Property TCCHUYENMON() As String
        Get
            Return Me.m_sTCCM
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCM = Value
        End Set
    End Property
    Public Property TCNN() As String
        Get
            Return Me.m_sTCNN
        End Get
        Set(ByVal Value As String)
            Me.m_sTCNN = Value
        End Set
    End Property
    'moi

    Public Property CBVP() As String
        Get
            Return Me.m_sTCCBVP
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBVP = Value
        End Set
    End Property
    Public Property CBTS() As String
        Get
            Return Me.m_sTCCBTS
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBTS = Value
        End Set
    End Property
    Public Property BBNT() As String
        Get
            Return Me.m_sTCBBNT
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBNT = Value
        End Set
    End Property
    Public Property BBHT() As String
        Get
            Return Me.m_sTCBBHT
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBHT = Value
        End Set
    End Property
    Public Property BBTh() As String
        Get
            Return Me.m_sTCBBT
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBT = Value
        End Set
    End Property

    'moi
    Public Property TCHAOMON() As String
        Get
            Return Me.m_sTCHM
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHM = Value
        End Set
    End Property

    Public Property TCCONGVIEC() As String
        Get
            Return Me.m_sTCCV
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCV = Value
        End Set
    End Property

    Public Property PHUCAPKHAC() As String
        Get
            Return Me.m_sPCKHAC
        End Get
        Set(ByVal Value As String)
            Me.m_sPCKHAC = Value
        End Set
    End Property
    Public m_QA As String
    Public m_thorap As String
    Public m_hse As String
    Public m_tcmt As String
    Public m_giadinh As String
    Public m_dongphuc As String
    Public Property HTDP() As String
        Get
            Return Me.m_dongphuc
        End Get
        Set(ByVal Value As String)
            Me.m_dongphuc = Value
        End Set
    End Property
    Public Property CLGD() As String
        Get
            Return Me.m_giadinh
        End Get
        Set(ByVal Value As String)
            Me.m_giadinh = Value
        End Set
    End Property
    Public Property TCCM() As String
        Get
            Return Me.m_tcmt
        End Get
        Set(ByVal Value As String)
            Me.m_tcmt = Value
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
    Public Property PHUCLOI() As String
        Get
            Return Me.m_sPHUCLOI
        End Get
        Set(ByVal Value As String)
            Me.m_sPHUCLOI = Value
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

    Public Property HSE() As String
        Get
            Return Me.m_hse
        End Get
        Set(ByVal Value As String)
            Me.m_hse = Value
        End Set
    End Property
    Public Property THORAP() As String
        Get
            Return Me.m_thorap
        End Get
        Set(ByVal Value As String)
            Me.m_thorap = Value
        End Set
    End Property
    Public Property QIP() As String
        Get
            Return Me.m_QA
        End Get
        Set(ByVal Value As String)
            Me.m_QA = Value
        End Set
    End Property

    Public Property MABAC() As String
        Get
            Return Me.m_sBAC
        End Get
        Set(ByVal Value As String)
            Me.m_sBAC = Value
        End Set
    End Property
    Public Property NGACH() As String
        Get
            Return Me.m_sNGACH
        End Get
        Set(ByVal Value As String)
            Me.m_sNGACH = Value
        End Set
    End Property

    Public Property BAC() As String
        Get
            Return Me.m_sBAC1
        End Get
        Set(ByVal Value As String)
            Me.m_sBAC1 = Value
        End Set
    End Property

    Public Property BACLUU() As String
        Get
            Return Me.m_sBACLUU
        End Get
        Set(ByVal Value As String)
            Me.m_sBACLUU = Value
        End Set
    End Property

    Public Property TUNGAY() As String
        Get
            Return Me.m_sTUNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sTUNGAY = Value
        End Set
    End Property

    Public Property DENNGAY() As String
        Get
            Return Me.m_sDENNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sDENNGAY = Value
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
    Public m_sNGAYTAO As String

    Public m_sNGUOITAO As String
    Public m_sNGAYCN As String
    Public m_sNGUOICN As String
    Public m_sMA_DM As String
    Public m_snguoidung As String
    Public m_sBAC11 As Integer
    Public m_sBAC2 As Integer
    Public m_sBAC3 As Integer
    Public m_sMANV As String
    Public m_sTEN As String
    Public m_sLUONGCB As String
    Public m_sLUONGTT As String
    Public m_sHESO As String
    Public m_sPCKHAC As String
    Public m_sNGAYV As String
    Public m_sNGAY As String
    Public m_sTUNGAY As String
    Public m_sDENNGAY As String
    Public m_sBBA As String
    Public m_sBBB As String
    Public m_sBBC As String
    Public m_sBBT As String
    Public m_sRO As String
    Public m_sOM As String
    Public m_sNGACH As String
    Public m_sTENNG As String
    Public m_sTENBANGL As String
    Public m_sBAC1 As String
    Public m_sBACLUU As String
    Public m_sBAC As String
    Public m_sCV As String
    Public m_sBHYT As Integer
    Public m_sTCNN As String
    Public m_sTCUD As String
    Public m_sTCCM As String
    Public m_sTCHM As String
    Public m_sBHXH As Integer
    Public m_sBHTN As Integer
    Public m_sDH As Integer
    Public m_sBT As Integer
    'moi
    Public m_sQAQIP As String
    Public m_sThoRap As String
    Public m_sHSE As String
    Public m_sHD_TCHOTRODONGPHUC As String
    Public m_sHD_TCCHAMLOGIADINH As String
    Public m_sTCMT As String
    Public m_sKHONGHUONGCC As Integer
    Public m_sPHUCLOI As String
    Public m_sHTNG As String
    Public m_sDQTV As String
    Public m_sPCCC As String




    Public m_sTCCBVP As String
    Public m_sTCCBTS As String
    Public m_sTCBBNT As String
    Public m_sTCBBHT As String
    Public m_sTCBBT As String
    Public m_sTCCV As String
    Public m_sChonTable As Integer
End Class
