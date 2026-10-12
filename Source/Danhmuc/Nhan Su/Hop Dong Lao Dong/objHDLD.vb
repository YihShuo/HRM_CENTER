Public Class objHDLD
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MANV = ""
        Me.SOHD = ""
        Me.MAHD = ""
        Me.NGAYKY = ""
        Me.NGAYHETHAN = ""
        Me.MABAC = ""
        Me.LUONGCOBAN = ""
        Me.HESO = ""
        Me.PHUCAPKHAC = ""
        Me.TCCONGVIEC = ""
        Me.TCUUDAI = ""
        Me.TCCHUYENMON = ""
        Me.TCNN = ""
        Me.TCHAOMON = ""
        Me.TCMT = ""
        Me.LUONGTOITHIEU = ""
        Me.NGAYBDGIAHAN = ""
        Me.NGAYKTGIAHAN = ""
        Me.LYDOGIAHAN = ""
        Me.CBVP = ""
        Me.CBTS = ""
        Me.BBNT = ""
        Me.BBHT = ""
        Me.BBT = ""
        Me.HD_TroCapQAQIP = ""
        Me.HD_TrocapThoRap = ""
        Me.HD_TrocapHSE = ""
        Me.HD_HTNG = ""
        Me.HD_PHUCLOI = ""
        Me.HD_DQTV = ""
        Me.HD_PCCC = ""

        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal manhanvien As String, ByVal sohopdong As String, ByVal loaihd As String, ByVal ngaykyhd As String, ByVal ngayhethanhd As String, ByVal MAB As String, ByVal TENBANGLUONG As String, ByVal TENNGA As String, ByVal NG As String, ByVal BC As String, ByVal BLUU As String, ByVal luongcb As String, ByVal hs As String, ByVal pckhac As String, ByVal baohiemyt As Integer, ByVal baohiemxh As Integer, ByVal baohiemtn As Integer, ByVal cvdochai As Integer, ByVal trocapVPX As Integer, ByVal canbovp As String, ByVal canbots As String, ByVal bbnamtruoc As String, ByVal bbhientai As String, ByVal bbthang As String, ByVal HD_TCCHAMLOGIADINH_ As String, ByVal HD_TCHOTRODONGPHUC_ As String, ByVal HD_TroCapQAQIP_ As String, ByVal HD_TrocapThoRap_ As String, ByVal HD_TrocapHSE_ As String, ByVal trocapcv As String, ByVal trocapud As String, ByVal trocapcm As String, ByVal trocapnn As String, ByVal trocaphaomon As String, ByVal trocapmoitruong As String, ByVal phucloi As String, ByVal hotrongoaigio As String, ByVal DQTV As String, ByVal PCCC As String, ByVal luongtt As String, ByVal ghan As Integer, ByVal ngaybdgh As String, ByVal ngayktgh As String, ByVal lydo As String, ByVal bac1_ As Integer, ByVal bac2_ As Integer, ByVal bac3_ As Integer, ByVal khongcc As Integer, ByVal m_ChonTable As Integer) As Boolean
        Me.MANV = manhanvien
        Me.SOHD = sohopdong
        Me.MAHD = loaihd
        Me.NGAYKY = ngaykyhd
        Me.NGAYHETHAN = ngayhethanhd
        Me.MABAC = MAB
        Me.TENBANGL = TENBANGLUONG
        Me.TENNGACH = TENNGA
        Me.NGACH = NG
        Me.BAC = BC
        Me.BACLUU = BLUU
        Me.LUONGCOBAN = luongcb
        Me.HESO = hs
        Me.PHUCAPKHAC = pckhac
        If baohiemyt = True Then
            m_sBHYT = 1
        Else
            m_sBHYT = 0
        End If

        Me.BHYT = m_sBHYT

        Me.TCCM_VPX = m_sTCVPX
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

        If trocapVPX = True Then
            m_sTCVPX = 1
        Else
            m_sTCVPX = 0
        End If

        Me.TCCONGVIEC = trocapcv
        Me.TCUUDAI = trocapud
        Me.TCCHUYENMON = trocapcm
        Me.TCNN = trocapnn
        Me.TCHAOMON = trocaphaomon
        Me.TCMT = trocapmoitruong
        Me.LUONGTOITHIEU = luongtt

        'MOI
        Me.CBVP = canbovp
        Me.CBTS = canbots
        Me.BBNT = bbnamtruoc
        Me.BBHT = bbhientai
        Me.BBT = bbthang
        Me.HD_TCCHAMLOGIADINH = HD_TCCHAMLOGIADINH_
        Me.HD_TCHOTRODONGPHUC = HD_TCHOTRODONGPHUC_
        Me.HD_TroCapQAQIP = HD_TroCapQAQIP_
        Me.HD_TrocapThoRap = HD_TrocapThoRap_
        Me.HD_TrocapHSE = HD_TrocapHSE_

        ''MOI 19/1/2018
        Me.HD_PHUCLOI = phucloi
        Me.HD_HTNG = hotrongoaigio
        ''MOI 21/8/2020
        Me.HD_DQTV = DQTV
        Me.HD_PCCC = PCCC

        ''-----------
        If ghan = True Then
            m_sGH = 1
        Else
            m_sGH = 0
        End If
        Me.GIAHAN = m_sGH
        Me.NGAYBDGIAHAN = ngaybdgh
        Me.NGAYKTGIAHAN = ngayktgh
        Me.LYDOGIAHAN = lydo
        'BAC 1
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

        If khongcc = True Then
            m_sKHONGHUONGCC = 1
        Else
            m_sKHONGHUONGCC = 0
        End If

        Me.ChonBang = m_sChonTable
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
    Public Property MANV() As String
        Get
            Return Me.m_sMANV
        End Get
        Set(ByVal Value As String)
            Me.m_sMANV = Value
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
    Public Property MAHD() As String
        Get
            Return Me.m_sMAHD
        End Get
        Set(ByVal Value As String)
            Me.m_sMAHD = Value
        End Set
    End Property
    Public Property MABAC() As String
        Get
            Return Me.m_sMABAC
        End Get
        Set(ByVal Value As String)
            Me.m_sMABAC = Value
        End Set
    End Property
    Public Property SOHD() As String
        Get
            Return Me.m_sSOHD
        End Get
        Set(ByVal Value As String)
            Me.m_sSOHD = Value
        End Set
    End Property
 
    Public Property NGAYKY() As String
        Get
            Return Me.m_sNGAYKY
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYKY = Value
        End Set
    End Property
    Public Property NGAYKYLUOI() As String
        Get
            Return Me.m_sNGAYKYLUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYKYLUOI = Value
        End Set
    End Property
    Public Property NGAYHETHAN() As String
        Get
            Return Me.m_sNGAYHETHAN
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYHETHAN = Value
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
    Public Property HESO() As String
        Get
            Return Me.m_sHESO
        End Get
        Set(ByVal Value As String)
            Me.m_sHESO = Value
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
    Public Property BHYT() As Integer
        Get
            Return Me.m_sBHYT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBHYT = Value
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
   

    Public Property TCCM_VPX() As Integer
        Get
            Return Me.m_sTCVPX
        End Get
        Set(ByVal Value As Integer)
            Me.m_sTCVPX = Value
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
    Public Property KHONGHUONGCC() As Integer
        Get
            Return Me.m_sKHONGHUONGCC
        End Get
        Set(ByVal Value As Integer)
            Me.m_sKHONGHUONGCC = Value
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
    ''-----------------------moi 19/1
    Public Property HD_HTNG() As String
        Get
            Return Me.m_sHoTroNgoaiGio
        End Get
        Set(ByVal Value As String)
            Me.m_sHoTroNgoaiGio = Value
        End Set
    End Property
    Public Property HD_PHUCLOI() As String
        Get
            Return Me.m_sPhucloi
        End Get
        Set(ByVal Value As String)
            Me.m_sPhucloi = Value
        End Set
    End Property
    ''-----------------------moi 21/8/2020
    Public Property HD_DQTV() As String
        Get
            Return Me.m_sDQTV
        End Get
        Set(ByVal Value As String)
            Me.m_sDQTV = Value
        End Set
    End Property
    Public Property HD_PCCC() As String
        Get
            Return Me.m_sPCCC
        End Get
        Set(ByVal Value As String)
            Me.m_sPCCC = Value
        End Set
    End Property

    ''-----------------------
    'moi
    Public Property CBVP() As String
        Get
            Return Me.m_sCBVP
        End Get
        Set(ByVal Value As String)
            Me.m_sCBVP = Value
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
    Public Property CBTS() As String
        Get
            Return Me.m_sCBTS
        End Get
        Set(ByVal Value As String)
            Me.m_sCBTS = Value
        End Set
    End Property
    Public Property BBNT() As String
        Get
            Return Me.m_sBBNT
        End Get
        Set(ByVal Value As String)
            Me.m_sBBNT = Value
        End Set
    End Property
    Public Property BBHT() As String
        Get
            Return Me.m_sBBHT
        End Get
        Set(ByVal Value As String)
            Me.m_sBBHT = Value
        End Set
    End Property
    Public Property BBT() As String
        Get
            Return Me.m_sBBT
        End Get
        Set(ByVal Value As String)
            Me.m_sBBT = Value
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
    '''
    Public Property TCCONGVIEC() As String
        Get
            Return Me.m_sTCCV
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCV = Value
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

    Public Property HD_TrocapHSE() As String
        Get
            Return Me.m_sHSE
        End Get
        Set(ByVal Value As String)
            Me.m_sHSE = Value
        End Set
    End Property
    Public Property TCHAOMON() As String
        Get
            Return Me.m_sTCHM
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHM = Value
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
    Public Property NGAYBDGIAHAN() As String
        Get
            Return Me.m_sNGAYBDGH
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYBDGH = Value
        End Set
    End Property
    Public Property GIAHAN() As Integer
        Get
            Return Me.m_sGH
        End Get
        Set(ByVal Value As Integer)
            Me.m_sGH = Value
        End Set
    End Property
    Public Property NGAYKTGIAHAN() As String
        Get
            Return Me.m_sNGAYKTGH
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYKTGH = Value
        End Set
    End Property
    Public Property LYDOGIAHAN() As String
        Get
            Return Me.m_sLYDO
        End Get
        Set(ByVal Value As String)
            Me.m_sLYDO = Value
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

    '----------------------------------tim nhung nhan vien nghi khong phep-------------------
    Public Property tungay() As String
        Get
            Return Me.m_sTUNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sTUNGAY = Value
        End Set
    End Property

    Public Property denngay() As String
        Get
            Return Me.m_sDENNGAY
        End Get
        Set(ByVal Value As String)
            Me.m_sDENNGAY = Value
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
    Public m_sTUNGAY As String
    Public m_sDENNGAY As String
    '----------------------------------tim nhung nhan vien nghi khong phep-------------------
    Public m_sHD_TCCHAMLOGIADINH As String
    Public m_sHD_TCHOTRODONGPHUC As String
    Public m_sMANV As String
    Public m_sSOHD As String
    Public m_sNGAYKY As String
    Public m_sNGAYKYLUOI As String
    Public m_sNGAYHETHAN As String
    Public m_sLUONGCB As String
    Public m_sBHYT As Integer
    Public m_sGH As Integer
    Public m_sHESO As String
    Public m_sPCKHAC As String
    Public m_sBHXH As Integer
    Public m_sBAC11 As Integer
    Public m_sBAC2 As Integer
    Public m_sBAC3 As Integer
    Public m_sHSE As String
    Public m_sThoRap As String
    Public m_sQAQIP As String
    Public m_sBHTN As Integer
    Public m_sTCVPX As Integer
    Public m_sDH As Integer
    Public m_sBT As Integer
    Public m_sTCCV As String
    Public m_sTCUD As String
    Public m_sTCCM As String
    Public m_sLUONGTT As String
    Public m_sTCMT As String
    Public m_sLYDO As String
    Public m_sTCHM As String
    Public m_sMABAC As String
    Public m_sTCNN As String
    Public m_sNGAYBDGH As String
    Public m_sMAHD As String
    Public m_sNGAYKTGH As String
    Public m_sNGACH As String
    Public m_sTENNG As String
    Public m_sTENBANGL As String
    Public m_sBAC1 As String
    Public m_sBACLUU As String
    '
    Public m_sCBVP As String
    Public m_sCBTS As String
    Public m_sBBNT As String
    Public m_sBBHT As String
    Public m_sBBT As String

    Public m_sPhucloi As String
    Public m_sHoTroNgoaiGio As String
    Public m_sDQTV As String
    Public m_sPCCC As String

    Public m_sBAC As String
    Public m_sChonTable As Integer
    Public m_sKHONGHUONGCC As Integer
End Class
