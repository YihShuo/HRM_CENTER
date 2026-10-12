Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objTangLuongThang2
    'Public Overridable Function setvalue(ByVal p_MA As String, ByVal p_HOTEN As String, ByVal p_DONVI As String, ByVal p_NGAYVAO As String, ByVal p_THANG As String, ByVal p_BLCU As String, ByVal p_HSC As String, ByVal p_LCBCU As String, ByVal p_TCCMCU As String, ByVal p_TCCVCU As String, ByVal p_TCDHNNCU As String, ByVal p_TCUDCU As String, ByVal p_TCQAQIPCU As String, ByVal p_TCTHORAPCU As String, ByVal p_TCHSECU As String, ByVal p_TCCBVPCU As String, ByVal p_TCCBTSCU As String, ByVal p_TCKHACCU As String, ByVal p_TCHMPTCU As String, ByVal p_TCHOTRODONGPHUCCU As String, ByVal p_TCCHAMLOGIADINHCU As String, ByVal p_TCBBTHANGCU As String, ByVal p_THUONGABCCU As String, ByVal p_TCMOITRUONGCU As String, ByVal m_sTONGLUONGCU As String, ByVal p_BLM As String, ByVal p_HSM As String, ByVal p_LCBMOI As String, ByVal p_TCCMMOI As String, ByVal p_TCCVMOI As String, ByVal p_TCDHNNMOI As String, ByVal p_TCUDMOI As String, ByVal p_TCQAQIPMOI As String, ByVal p_TCTHORAPMOI As String, ByVal p_TCHSEMOI As String, ByVal p_TCCBVPMOI As String, ByVal p_TCCBTSMOI As String, ByVal p_TCKHACMOI As String, ByVal p_TCHMPTMOI As String, ByVal p_TCHOTRODONGPHUCMOI As String, ByVal p_TCCHAMLOGIADINHMOI As String, ByVal p_TCBBTHANGMOI As String, ByVal p_THUONGABCMOI As String, ByVal p_TCMOITRUONGMOI As String, ByVal p_TONGLUONGMOI As String, ByVal p_TONGCL As String, ByVal p_BANGLUONG As String, ByVal p_NGACH As String, ByVal p_TENBAC As String) As String
    Public Overridable Function setvalue(ByVal p_MA As String, ByVal p_HOTEN As String, ByVal p_DONVI As String, ByVal p_NGAYVAO As String, ByVal p_THANG As String, ByVal p_BLM As String, ByVal p_HSM As String, ByVal p_LCBMOI As String, ByVal p_TCCMMOI As String, ByVal p_TCCVMOI As String, ByVal p_TCDHNNMOI As String, ByVal p_TCUDMOI As String, ByVal p_TCQAQIPMOI As String, ByVal p_TCTHORAPMOI As String, ByVal p_TCHSEMOI As String, ByVal p_TCCBVPMOI As String, ByVal p_TCCBTSMOI As String, ByVal p_TCKHACMOI As String, ByVal p_TCHMPTMOI As String, ByVal p_TCHOTRODONGPHUCMOI As String, ByVal p_TCCHAMLOGIADINHMOI As String, ByVal p_TCBBTHANGMOI As String, ByVal p_THUONGABCMOI As String, ByVal p_TCMOITRUONGMOI As String, ByVal p_TONGLUONGMOI As String, ByVal p_TONGCL As String, ByVal p_BANGLUONG As String, ByVal p_NGACH As String, ByVal p_TENBAC As String, ByVal p_DHNN As Boolean, ByVal p_KHCC As Boolean, ByVal p_TCHTNGCU As String, ByVal p_TCHTNGMOI As String, ByVal p_TCDQTVCU As String, ByVal p_TCDQTVMOI As String, ByVal p_TCPCCCCU As String, ByVal p_TCPCCCMOI As String) As String
        Dim falg As Boolean
        Me.NV_MA = p_MA
        Me.HOTEN = p_HOTEN
        Me.DONVINV = p_DONVI
        Me.NGAYVAO = p_NGAYVAO
        Me.THANGNAM = p_THANG
        'Me.BACLUONGCU = p_BLCU
        'Me.HESOCU = p_HSC
        'Me.LUONGCBCU = p_LCBCU
        'Me.TCCMCU = p_TCCMCU
        'Me.TCCVCU = p_TCCVCU
        'Me.TCNNCU = p_TCDHNNCU
        'Me.TCUDMAYCU = p_TCUDCU
        'Me.TCQAQIPCU = p_TCQAQIPCU
        'Me.TCTHORAPCU = p_TCTHORAPCU
        'Me.TCHSECU = p_TCHSECU
        'Me.TCCBVPCU = p_TCCBVPCU
        'Me.TCCBTSCU = p_TCCBTSCU
        'Me.TCKHACCU = p_TCKHACCU
        'Me.TCHMPTCU = p_TCHMPTCU
        'Me.TCHOTRODONGPHUCCU = p_TCHOTRODONGPHUCCU
        'Me.TCCHAMLOGIADINHCU = p_TCCHAMLOGIADINHCU
        'Me.TCBBTHANGCU = p_TCBBTHANGCU
        'Me.TCBBNCU = p_THUONGABCCU
        'Me.TCMOITRUONGCU = p_TCMOITRUONGCU
        'Me.TONGLUONGCU = m_sTONGLUONGCU
        Me.BACLUONGMOI = p_BLM
        Me.HESOMOI = p_HSM
        Me.LUONGCBMOI = p_LCBMOI
        Me.TCCMMOI = p_TCCMMOI
        Me.TCCVMOI = p_TCCVMOI
        Me.TCNNMOI = p_TCDHNNMOI
        Me.TCUDMAYMOI = p_TCUDMOI
        Me.TCQAQIPMOI = p_TCQAQIPMOI
        Me.TCTHORAPMOI = p_TCTHORAPMOI
        Me.TCHSEMOI = p_TCHSEMOI
        Me.TCCBVPMOI = p_TCCBVPMOI
        Me.TCCBTSMOI = p_TCCBTSMOI
        Me.TCKHACMOI = p_TCKHACMOI
        Me.TCHMPTMOI = p_TCHMPTMOI
        Me.TCHOTRODONGPHUCCU = p_TCHOTRODONGPHUCMOI
        Me.TCCHAMLOGIADINHCU = p_TCCHAMLOGIADINHMOI
        Me.TCBBTHANGCU = p_TCBBTHANGMOI
        Me.TCBBNCU = p_THUONGABCMOI
        Me.TCMOITRUONGCU = p_TCMOITRUONGMOI
        Me.TONGLUONGMOI = p_TONGLUONGMOI
        Me.TONGCL = p_TONGCL
        Me.BANGLUONG = p_BANGLUONG
        Me.NGACH = p_NGACH
        Me.TENBAC = p_TENBAC
        Me.DHNN = p_DHNN
        Me.KHCC = p_KHCC
        Me.TCHTNGCU = p_TCHTNGCU
        Me.TCHTNGMOI = p_TCHTNGMOI
        Me.TCDQTVCU = p_TCDQTVCU
        Me.TCDQTVMOI = p_TCDQTVMOI
        Me.TCPCCCCU = p_TCPCCCCU
        Me.TCPCCCMOI = p_TCPCCCMOI
        Return False
    End Function

    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.NV_MA = ""
        Me.HOTEN = ""
        Me.DONVINV = ""
        Me.NGAYVAO = ""
        Me.THANGNAM = ""
        'Me.BACLUONGCU = ""
        'Me.HESOCU = ""
        'Me.LUONGCBCU = 0
        'Me.TCCMCU = 0
        'Me.TCCVCU = 0
        'Me.TCNNCU = 0
        'Me.TCUDMAYCU = 0
        'Me.TCQAQIPCU = 0
        'Me.TCTHORAPCU = 0
        'Me.TCHSECU = 0
        'Me.TCCBVPCU = 0
        'Me.TCCBTSCU = 0
        'Me.TCKHACCU = 0
        'Me.TCHMPTCU = 0
        'Me.TCHOTRODONGPHUCCU = 0
        'Me.TCCHAMLOGIADINHCU = 0
        'Me.TCBBTHANGCU = 0
        'Me.TCBBNCU = 0
        'Me.TCMOITRUONGCU = 0
        'Me.TONGLUONGCU = 0
        Me.BACLUONGMOI = ""
        Me.HESOMOI = ""
        Me.LUONGCBMOI = 0
        Me.TCCMMOI = 0
        Me.TCCVMOI = 0
        Me.TCNNMOI = 0
        Me.TCUDMAYMOI = 0
        Me.TCQAQIPMOI = 0
        Me.TCTHORAPMOI = 0
        Me.TCHSEMOI = 0
        Me.TCCBVPMOI = 0
        Me.TCCBTSMOI = 0
        Me.TCKHACMOI = 0
        Me.TCHMPTMOI = 0
        Me.TCHOTRODONGPHUCCU = 0
        Me.TCCHAMLOGIADINHCU = 0
        Me.TCBBTHANGCU = 0
        Me.TCBBNCU = 0
        Me.TCMOITRUONGCU = 0
        Me.TONGLUONGMOI = 0
        Me.TONGCL = 0
        Me.BANGLUONG = ""
        Me.NGACH = ""
        Me.TENBAC = ""
        Me.ChonBang = 0
        Return flag
    End Function

    '' Properties

    Public m_sNGAYTAO As String

    Public m_sNGUOITAO As String
    Public m_sNGAYCN As String
    Public m_sNGUOICN As String
    Public m_sLOAITL As String
    Public Property LOAITL() As String
        Get
            Return Me.m_sLOAITL
        End Get
        Set(ByVal Value As String)
            Me.m_sLOAITL = Value
        End Set
    End Property
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
    Public Property MA_DM() As String
        Get
            Return Me.m_sMA_DM
        End Get
        Set(ByVal Value As String)
            Me.m_sMA_DM = Value
        End Set
    End Property
    Public m_sMA_DM As String
    Public m_snguoidung As String
    Public Property NGUOIDUNG() As String
        Get
            Return Me.m_snguoidung
        End Get
        Set(ByVal Value As String)
            Me.m_snguoidung = Value
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
    Public Property NAM() As String
        Get
            Return Me.m_sDonvi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonvi = Value
        End Set
    End Property
    Public Property HOTEN() As String
        Get
            Return Me.m_sHT
        End Get
        Set(ByVal Value As String)
            Me.m_sHT = Value
        End Set
    End Property
    Public Property DONVINV() As String
        Get
            Return Me.m_sDonviNV
        End Get
        Set(ByVal Value As String)
            Me.m_sDonviNV = Value
        End Set
    End Property
    Public Property NGAYVAO() As String
        Get
            Return Me.m_sNVAO
        End Get
        Set(ByVal Value As String)
            Me.m_sNVAO = Value
        End Set
    End Property
    Public Property NGAY() As Date
        Get
            Return Me.m_sngay
        End Get
        Set(ByVal Value As Date)
            Me.m_sngay = Value
        End Set
    End Property
    Public Property THANGNAM() As String
        Get
            Return Me.m_sTN
        End Get
        Set(ByVal Value As String)
            Me.m_sTN = Value
        End Set
    End Property
    Public Property BACLUONGCU() As String
        Get
            Return Me.m_sBLC
        End Get
        Set(ByVal Value As String)
            Me.m_sBLC = Value
        End Set
    End Property
    Public Property HESOCU() As String
        Get
            Return Me.m_sHSC
        End Get
        Set(ByVal Value As String)
            Me.m_sHSC = Value
        End Set
    End Property
    Public Property BACLUONGMOI() As String
        Get
            Return Me.m_sBLM
        End Get
        Set(ByVal Value As String)
            Me.m_sBLM = Value
        End Set
    End Property
    Public Property HESOMOI() As String
        Get
            Return Me.m_sHSM
        End Get
        Set(ByVal Value As String)
            Me.m_sHSM = Value
        End Set
    End Property
    Public Property NV_MA() As String
        Get
            Return Me.m_sNV
        End Get
        Set(ByVal Value As String)
            Me.m_sNV = Value
        End Set
    End Property
    Public Property TUNGAY() As String
        Get
            Return Me.m_sNamThang
        End Get
        Set(ByVal Value As String)
            Me.m_sNamThang = Value
        End Set
    End Property

    Public Property LUONG() As String
        Get
            Return Me.m_sNvma
        End Get
        Set(ByVal Value As String)
            Me.m_sNvma = Value
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
    Public Property LUONGCBCU() As String
        Get
            Return Me.m_sLCBCU
        End Get
        Set(ByVal Value As String)
            Me.m_sLCBCU = Value
        End Set
    End Property
    Public Property TCCMCU() As String
        Get
            Return Me.m_sTCCMCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCMCU = Value
        End Set
    End Property
    Public Property TCUDMAYCU() As String
        Get
            Return Me.m_sTCUDMAYCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCUDMAYCU = Value
        End Set
    End Property
    Public Property TCQAQIPCU() As String
        Get
            Return Me.m_sTCQAQIPCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCQAQIPCU = Value
        End Set
    End Property
    Public Property TCTHORAPCU() As String
        Get
            Return Me.m_sTCTHORAPCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCTHORAPCU = Value
        End Set
    End Property
    Public Property TCHSECU() As String
        Get
            Return Me.m_sTCHSECU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHSECU = Value
        End Set
    End Property
    Public Property TCHOTRODONGPHUCCU() As String
        Get
            Return Me.m_sTCHOTRODONGPHUCCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHOTRODONGPHUCCU = Value
        End Set
    End Property
    Public Property TCCHAMLOGIADINHCU() As String
        Get
            Return Me.m_sTCCHAMLOGIADINHCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCHAMLOGIADINHCU = Value
        End Set
    End Property
    Public Property TCBBTHANGCU() As String
        Get
            Return Me.m_sTCBBTHANGCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBTHANGCU = Value
        End Set
    End Property

    Public Property TCKHACCU() As String
        Get
            Return Me.m_sTCKHACCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCKHACCU = Value
        End Set
    End Property
    Public Property TCNNCU() As String
        Get
            Return Me.m_sTCNNCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCNNCU = Value
        End Set
    End Property
    Public Property TCCVCU() As String
        Get
            Return Me.m_sTCCVCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCVCU = Value
        End Set
    End Property
    Public Property TCCBVPCU() As String
        Get
            Return Me.m_sTCCBVPCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBVPCU = Value
        End Set
    End Property
    Public Property TCCBTSCU() As String
        Get
            Return Me.m_sTCCBTSCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBTSCU = Value
        End Set
    End Property
    Public Property TCBBNCU() As String
        Get
            Return Me.m_sTCBBNCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBNCU = Value
        End Set
    End Property
    Public Property TCHMPTCU() As String
        Get
            Return Me.m_sTCHMPTCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHMPTCU = Value
        End Set
    End Property
    Public Property TCMOITRUONGCU() As String
        Get
            Return Me.m_sTCMOITRUONGCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCMOITRUONGCU = Value
        End Set
    End Property

    Public Property TONGLUONGCU() As String
        Get
            Return Me.m_sTONGLUONGCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTONGLUONGCU = Value
        End Set
    End Property

    Public Property LUONGCBMOI() As String
        Get
            Return Me.m_sLCBMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sLCBMOI = Value
        End Set
    End Property
    'Public Property TCHOTRODONGPHUCMOI() As String
    '    Get
    '        Return Me.m_sTCHOTRODONGPHUCMOI
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.m_sTCHOTRODONGPHUCMOI = Value
    '    End Set
    'End Property
    'Public Property TCCHAMLOGIADINHMOI() As String
    '    Get
    '        Return Me.m_sTCCHAMLOGIADINHMOI
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.m_sTCCHAMLOGIADINHMOI = Value
    '    End Set
    'End Property
    Public Property TCCMMOI() As String
        Get
            Return Me.m_sTCCMMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCMMOI = Value
        End Set
    End Property
    Public Property TCUDMAYMOI() As String
        Get
            Return Me.m_sTCUDMAYMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCUDMAYMOI = Value
        End Set
    End Property
    Public Property TCQAQIPMOI() As String
        Get
            Return Me.m_sTCQAQIPMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCQAQIPMOI = Value
        End Set
    End Property
    Public Property TCTHORAPMOI() As String
        Get
            Return Me.m_sTCTHORAPMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCTHORAPMOI = Value
        End Set
    End Property
    Public Property TCHSEMOI() As String
        Get
            Return Me.m_sTCHSEMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHSEMOI = Value
        End Set
    End Property
    Public Property TCHOTRODONGPHUCMOI() As String
        Get
            Return Me.m_sTCHOTRODONGPHUCMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHOTRODONGPHUCMOI = Value
        End Set
    End Property
    Public Property TCCHAMLOGIADINHMOI() As String
        Get
            Return Me.m_sTCCHAMLOGIADINHMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCHAMLOGIADINHMOI = Value
        End Set
    End Property
    Public Property TCBBTHANGMOI() As String
        Get
            Return Me.m_sTCBBTHANGMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBTHANGMOI = Value
        End Set
    End Property

    Public Property TCKHACMOI() As String
        Get
            Return Me.m_sTCKHACMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCKHACMOI = Value
        End Set
    End Property
    Public Property TCNNMOI() As String
        Get
            Return Me.m_sTCNNMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCNNMOI = Value
        End Set
    End Property
    Public Property TCCVMOI() As String
        Get
            Return Me.m_sTCCVMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCVMOI = Value
        End Set
    End Property
    Public Property TCCBVPMOI() As String
        Get
            Return Me.m_sTCCBVPMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBVPMOI = Value
        End Set
    End Property
    Public Property TCCBTSMOI() As String
        Get
            Return Me.m_sTCCBTSMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCCBTSMOI = Value
        End Set
    End Property
    Public Property TCBBNMOI() As String
        Get
            Return Me.m_sTCBBNMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCBBNMOI = Value
        End Set
    End Property
    Public Property TCHMPTMOI() As String
        Get
            Return Me.m_sTCHMPTMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHMPTMOI = Value
        End Set
    End Property
    Public Property TCMOITRUONGMOI() As String
        Get
            Return Me.m_sTCMOITRUONGMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCMOITRUONGMOI = Value
        End Set
    End Property
    Public Property TONGLUONGMOI() As String
        Get
            Return Me.m_sTONGLUONGMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTONGLUONGMOI = Value
        End Set
    End Property

    Public Property TONGCL() As String
        Get
            Return Me.m_sTONGCL
        End Get
        Set(ByVal Value As String)
            Me.m_sTONGCL = Value
        End Set
    End Property
    Public Property BANGLUONG() As String
        Get
            Return Me.m_sBL
        End Get
        Set(ByVal Value As String)
            Me.m_sBL = Value
        End Set
    End Property
    Public Property NGACH() As String
        Get
            Return Me.m_sN
        End Get
        Set(ByVal Value As String)
            Me.m_sN = Value
        End Set
    End Property
    Public Property TENBAC() As String
        Get
            Return Me.m_sTB
        End Get
        Set(ByVal Value As String)
            Me.m_sTB = Value
        End Set
    End Property
    Public Property DHNN() As Boolean
        Get
            Return Me.m_sDHNN
        End Get
        Set(ByVal Value As Boolean)
            Me.m_sDHNN = Value
        End Set
    End Property
    Public Property KHCC() As Boolean
        Get
            Return Me.m_sKHCC
        End Get
        Set(ByVal Value As Boolean)
            Me.m_sKHCC = Value
        End Set
    End Property
    Public Property TCHTNGMOI() As String
        Get
            Return Me.m_sTCHTNGMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHTNGMOI = Value
        End Set
    End Property
    Public Property TCHTNGCU() As String
        Get
            Return Me.m_sTCHTNGCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCHTNGCU = Value
        End Set
    End Property
    Public Property TCDQTVMOI() As String
        Get
            Return Me.m_sTCDQTVMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCDQTVMOI = Value
        End Set
    End Property
    Public Property TCDQTVCU() As String
        Get
            Return Me.m_sTCDQTVCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCDQTVCU = Value
        End Set
    End Property
    Public Property TCPCCCMOI() As String
        Get
            Return Me.m_sTCPCCCMOI
        End Get
        Set(ByVal Value As String)
            Me.m_sTCPCCCMOI = Value
        End Set
    End Property
    Public Property TCPCCCCU() As String
        Get
            Return Me.m_sTCPCCCCU
        End Get
        Set(ByVal Value As String)
            Me.m_sTCPCCCCU = Value
        End Set
    End Property
    ' Fields
    Public m_sID As String
    Public m_iChonbang As Integer
    Public m_sDonvi As String
    Public m_sNV As String
    Public m_sNamThang As String

    Public m_sNvma As String
    Public m_sDV As String
    Public m_bLoaiLuong As String

    Public m_sTCHMPTMOI As String
    Public m_sLCBCU As String
    Public m_sTCCMCU As String
    Public m_sTCUDMAYCU As String
    Public m_sTCKHACCU As String
    Public m_sTCNNCU As String
    Public m_sTCCVCU As String
    Public m_sTCCBVPCU As String
    Public m_sTCCBTSCU As String
    Public m_sTCBBNCU As String
    Public m_sTCQAQIPCU As String
    Public m_sTCTHORAPCU As String
    Public m_sTCHSECU As String
    Public m_sTCHMPTCU As String
    Public m_sTCHOTRODONGPHUCCU As String
    Public m_sTCCHAMLOGIADINHCU As String
    Public m_sTCBBTHANGCU As String
    Public m_sTCMOITRUONGCU As String
    Public m_sTONGLUONGCU As String

    Public m_sLCBMOI As String
    Public m_sTCCMMOI As String
    Public m_sTCUDMAYMOI As String
    Public m_sTCKHACMOI As String
    Public m_sTCNNMOI As String
    Public m_sTCCVMOI As String
    Public m_sTCCBVPMOI As String
    Public m_sTCCBTSMOI As String
    Public m_sTCBBNMOI As String
    Public m_sTCQAQIPMOI As String
    Public m_sTCTHORAPMOI As String
    Public m_sTCHSEMOI As String
    Public m_sTCHOTRODONGPHUCMOI As String
    Public m_sTCCHAMLOGIADINHMOI As String
    Public m_sTCBBTHANGMOI As String
    Public m_sTCMOITRUONGMOI As String
    Public m_sTONGLUONGMOI As String
    Public m_sTONGCL As String
    Public m_sHT As String
    Public m_sDonviNV As String
    Public m_sNVAO As String
    Public m_sngay As Date
    Public m_sTN As String
    Public m_sBLC As String
    Public m_sHSC As String
    Public m_sBLM As String
    Public m_sHSM As String

    Public m_sBL As String
    Public m_sN As String
    Public m_sTB As String

    Public m_sDHNN As Boolean
    Public m_sKHCC As Boolean
    Public m_sTCHTNGMOI As String
    Public m_sTCHTNGCU As String
    Public m_sTCDQTVMOI As String
    Public m_sTCDQTVCU As String
    Public m_sTCPCCCMOI As String
    Public m_sTCPCCCCU As String
End Class
