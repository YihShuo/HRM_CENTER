Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports Microsoft.VisualBasic

Public Class objDiemDanhHangNgay
    Public m_sTSBC As Integer
    Public m_sDV_TSBC As String

    Public m_sXUONG_TSBC As String
    Public m_iChonBang As Integer
    Public m_sID As String
    Public m_sXuong As String
    Public m_sNganh As String
    Public m_sTable As String
    Public m_sNGAY As String
    Public m_sDNGAY As String
    Public m_sNV_MA As String
    Public m_sDV_MA As String
    Public m_sDV_MA_ As String
    Public m_sGHICHU As String
    Public m_sDVDD_CU As String

    Public m_sDILAM As Integer
    Public m_sP As Integer
    Public m_sR As Integer
    Public m_sO As Integer
    Public m_sCO As Integer
    Public m_sRO As Integer
    Public m_sOP As Integer
    Public m_sNO As Integer
    Public m_sKT As Integer
    Public m_sTSAN As Integer
    Public m_sGIAM As Integer
    Public m_sTANG As Integer
    Public m_sGIOITINH As Integer
    Public m_sNAM As Integer
    Public m_sNU As Integer
    Public m_sNVG As Integer
    Public m_sOPKTRG As Integer
    Public m_sCNMT As Integer
    Public m_sDDT As Integer
    Public m_sDDG As Integer
    Public m_sTSV As Integer
    Public m_sTSG As Integer
    Public m_sTS As Integer
    Public m_sTSHDTT As Integer
    Public m_sTSTT As Integer
    Public m_sTSBC_1 As Integer
    Public m_sCONLAI As Integer

    Public m_sCOUNT_DILAM As Integer
    Public m_sCOUNT_P As Integer
    Public m_sCOUNT_R As Integer
    Public m_sCOUNT_O As Integer
    Public m_sCOUNT_CO As Integer
    Public m_sCOUNT_RO As Integer
    Public m_sCOUNT_OP As Integer
    Public m_sCOUNT_NO As Integer
    Public m_sCOUNT_KT As Integer
    Public m_sCOUNT_TSAN As Integer
    Public m_sCOUNT_GIAM As Integer
    Public m_sCOUNT_TANG As Integer
    Public m_sCOUNT_NAM As Integer
    Public m_sCOUNT_NU As Integer
    Public m_sDV_DIEUDONG As String

    Public m_sCOUNT_NVG As Integer
    Public m_sCOUNT_OPKTRG As Integer
    Public m_sCOUNT_CNMT As Integer
    Public m_sCHON As String
    Public Ngayvao As String

    Public m_sMonth As String
    Public m_sYear As String
    Public Property CHON() As String
        Get
            Return Me.m_sCHON
        End Get
        Set(ByVal value As String)
            Me.m_sCHON = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return Me.m_sMonth
        End Get
        Set(ByVal value As String)
            Me.m_sMonth = value
        End Set
    End Property

    Public Property Year() As String
        Get
            Return Me.m_sYear
        End Get
        Set(ByVal value As String)
            Me.m_sYear = value
        End Set
    End Property


    Public Property TSBC() As String
        Get
            Return Me.m_sTSBC
        End Get
        Set(ByVal value As String)
            Me.m_sTSBC = value
        End Set
    End Property

    Public Property DV_TSBC() As String
        Get
            Return Me.m_sDV_TSBC
        End Get
        Set(ByVal value As String)
            Me.m_sDV_TSBC = value
        End Set
    End Property

    Public Property XUONG_TSBC() As String
        Get
            Return Me.m_sXUONG_TSBC
        End Get
        Set(ByVal value As String)
            Me.m_sXUONG_TSBC = value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal value As Integer)
            Me.m_iChonBang = value
        End Set
    End Property

    Public Property Nam() As Integer
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sNAM = value
        End Set
    End Property

    Public Property Nu() As Integer
        Get
            Return Me.m_sNU
        End Get
        Set(ByVal value As Integer)
            Me.m_sNU = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal value As String)
            Me.m_sID = value
        End Set
    End Property

    Public Property Xuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal value As String)
            Me.m_sXuong = value
        End Set
    End Property

    Public Property Nganh() As String
        Get
            Return Me.m_sNganh
        End Get
        Set(ByVal value As String)
            Me.m_sNganh = value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal value As String)
            Me.m_sTable = value
        End Set
    End Property

    Public Property Ngay() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sNGAY = value
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

    Public Property NV_MA() As String
        Get
            Return Me.m_sNV_Ma
        End Get
        Set(ByVal value As String)
            Me.m_sNV_Ma = value
        End Set
    End Property

    Public Property DV_MA() As String
        Get
            Return Me.m_sDV_Ma
        End Get
        Set(ByVal value As String)
            Me.m_sDV_Ma = value
        End Set
    End Property


    Public Property DV_MA_() As String
        Get
            Return Me.m_sDV_MA_
        End Get
        Set(ByVal value As String)
            Me.m_sDV_MA_ = value
        End Set
    End Property

    Public Property DiLam() As Integer
        Get
            Return Me.m_sDILAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sDILAM = value
        End Set
    End Property

    Public Property COUNT_DILAM() As Integer
        Get
            Return Me.m_sCOUNT_DILAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_DILAM = value
        End Set
    End Property

    Public Property P() As Integer
        Get
            Return Me.m_sP
        End Get
        Set(ByVal value As Integer)
            Me.m_sP = value
        End Set
    End Property

    Public Property COUNT_P() As Integer
        Get
            Return Me.m_sCOUNT_P
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_P = value
        End Set
    End Property

    Public Property R() As Integer
        Get
            Return Me.m_sR
        End Get
        Set(ByVal value As Integer)
            Me.m_sR = value
        End Set
    End Property

    Public Property COUNT_R() As Integer
        Get
            Return Me.m_sCOUNT_R
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_R = value
        End Set
    End Property

    Public Property O() As Integer
        Get
            Return Me.m_sO
        End Get
        Set(ByVal value As Integer)
            Me.m_sO = value
        End Set
    End Property

    Public Property COUNT_O() As Integer
        Get
            Return Me.m_sCOUNT_O
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_O = value
        End Set
    End Property

    Public Property CO() As Integer
        Get
            Return Me.m_sCO
        End Get
        Set(ByVal value As Integer)
            Me.m_sCO = value
        End Set
    End Property

    Public Property COUNT_CO() As Integer
        Get
            Return Me.m_sCOUNT_CO
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_CO = value
        End Set
    End Property

    Public Property RO() As Integer
        Get
            Return Me.m_sRO
        End Get
        Set(ByVal value As Integer)
            Me.m_sRO = value
        End Set
    End Property

    Public Property COUNT_RO() As Integer
        Get
            Return Me.m_sCOUNT_RO
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_RO = value
        End Set
    End Property

    Public Property OP() As Integer
        Get
            Return Me.m_sOP
        End Get
        Set(ByVal value As Integer)
            Me.m_sOP = value
        End Set
    End Property

    Public Property COUNT_OP() As Integer
        Get
            Return Me.m_sCOUNT_OP
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_OP = value
        End Set
    End Property

    Public Property NO() As Integer
        Get
            Return Me.m_sNO
        End Get
        Set(ByVal value As Integer)
            Me.m_sNO = value
        End Set
    End Property

    Public Property COUNT_NO() As Integer
        Get
            Return Me.m_sCOUNT_NO
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_NO = value
        End Set
    End Property

    Public Property KT() As Integer
        Get
            Return Me.m_sKT
        End Get
        Set(ByVal value As Integer)
            Me.m_sKT = value
        End Set
    End Property

    Public Property COUNT_KT() As Integer
        Get
            Return Me.m_sCOUNT_KT
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_KT = value
        End Set
    End Property

    Public Property TSAN() As Integer
        Get
            Return Me.m_sTSAN
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSAN = value
        End Set
    End Property

    Public Property COUNT_TSAN() As Integer
        Get
            Return Me.m_sCOUNT_TSAN
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_TSAN = value
        End Set
    End Property

    Public Property GIAM() As Integer
        Get
            Return Me.m_sGIAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sGIAM = value
        End Set
    End Property

    Public Property COUNT_GIAM() As Integer
        Get
            Return Me.m_sCOUNT_GIAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_GIAM = value
        End Set
    End Property

    Public Property TANG() As Integer
        Get
            Return Me.m_sTANG
        End Get
        Set(ByVal value As Integer)
            Me.m_sTANG = value
        End Set
    End Property

    Public Property COUNT_TANG() As Integer
        Get
            Return Me.m_sCOUNT_TANG
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_TANG = value
        End Set
    End Property

    Public Property GIOITINH() As Integer
        Get
            Return Me.m_sGIOITINH
        End Get
        Set(ByVal value As Integer)
            Me.m_sGIOITINH = value
        End Set
    End Property

    Public Property COUNT_NAM() As Integer
        Get
            Return Me.m_sCOUNT_NAM
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_NAM = value
        End Set
    End Property

    Public Property COUNT_NU() As Integer
        Get
            Return Me.m_sCOUNT_NU
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_NU = value
        End Set
    End Property

    Public Property DV_DIEUDONG() As String
        Get
            Return Me.m_sDV_DIEUDONG
        End Get
        Set(ByVal value As String)
            Me.m_sDV_DIEUDONG = value
        End Set
    End Property

    Public Property GHICHU() As String
        Get
            Return Me.m_sGHICHU
        End Get
        Set(ByVal value As String)
            Me.m_sGHICHU = value
        End Set
    End Property

    Public Property DVDD_CU() As String
        Get
            Return Me.m_sDVDD_CU
        End Get
        Set(ByVal value As String)
            Me.m_sDVDD_CU = value
        End Set
    End Property

    Public Property NVG() As Integer
        Get
            Return Me.m_sNVG
        End Get
        Set(ByVal value As Integer)
            Me.m_sNVG = value
        End Set
    End Property

    Public Property COUNT_NVG() As Integer
        Get
            Return Me.m_sCOUNT_NVG
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_NVG = value
        End Set
    End Property

    Public Property OPKTRG() As Integer
        Get
            Return Me.m_sOPKTRG
        End Get
        Set(ByVal value As Integer)
            Me.m_sOPKTRG = value
        End Set
    End Property

    Public Property COUNT_OPKTRG() As Integer
        Get
            Return Me.m_sCOUNT_OPKTRG
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_OPKTRG = value
        End Set
    End Property

    Public Property CNMT() As Integer
        Get
            Return Me.m_sCNMT
        End Get
        Set(ByVal value As Integer)
            Me.m_sCNMT = value
        End Set
    End Property

    Public Property COUNT_CNMT() As Integer
        Get
            Return Me.m_sCOUNT_CNMT
        End Get
        Set(ByVal value As Integer)
            Me.m_sCOUNT_CNMT = value
        End Set
    End Property

    Public Property DDT() As Integer
        Get
            Return Me.m_sDDT
        End Get
        Set(ByVal value As Integer)
            Me.m_sDDT = value
        End Set
    End Property

    Public Property DDG() As Integer
        Get
            Return Me.m_sDDG
        End Get
        Set(ByVal value As Integer)
            Me.m_sDDG = value
        End Set
    End Property

    Public Property TSV() As Integer
        Get
            Return Me.m_sTSV
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSV = value
        End Set
    End Property

    Public Property TSG() As Integer
        Get
            Return Me.m_sTSG
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSG = value
        End Set
    End Property

    Public Property TS() As Integer
        Get
            Return Me.m_sTS
        End Get
        Set(ByVal value As Integer)
            Me.m_sTS = value
        End Set
    End Property

    Public Property TSHDTT() As Integer
        Get
            Return Me.m_sTSHDTT
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSHDTT = value
        End Set
    End Property

    Public Property TSTT() As Integer
        Get
            Return Me.m_sTSTT
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSTT = value
        End Set
    End Property

    Public Property TSBC_1() As Integer
        Get
            Return Me.m_sTSBC_1
        End Get
        Set(ByVal value As Integer)
            Me.m_sTSBC_1 = value
        End Set
    End Property

    Public Property CONLAI() As Integer
        Get
            Return Me.m_sCONLAI
        End Get
        Set(ByVal value As Integer)
            Me.m_sCONLAI = value
        End Set
    End Property

    Public Property Ngayvaobs() As String
        Get
            Return Me.Ngayvao
        End Get
        Set(ByVal value As String)
            Me.Ngayvao = value
        End Set
    End Property

    Public Overridable Function setvalue(ByVal ID As String, ByVal Table As String, ByVal NGAY As String, ByVal NV_MA As String, ByVal DV_MA As String, ByVal Xuong As String, ByVal Nganh As String, ByVal DILAM As Integer, ByVal P As Integer, ByVal R As Integer, ByVal O As Integer, ByVal CO As Integer, ByVal RO As Integer, ByVal OP As Integer, ByVal NO As Integer, ByVal KT As Integer, ByVal TSAN As Integer, ByVal GIAM As Integer, ByVal TANG As Integer, ByVal GIOITINH As Integer, ByVal DV_DIEUDONG As String, ByVal DVDD_CU As String, ByVal COUNT_DILAM As Integer, ByVal COUNT_P As Integer, ByVal COUNT_R As Integer, ByVal COUNT_O As Integer, ByVal COUNT_CO As Integer, ByVal COUNT_RO As Integer, ByVal COUNT_OP As Integer, ByVal COUNT_NO As Integer, ByVal COUNT_KT As Integer, ByVal COUNT_TSAN As Integer, ByVal COUNT_GIAM As Integer, ByVal COUNT_TANG As Integer, ByVal COUNT_NAM As Integer, ByVal COUNT_NU As Integer, ByVal COUNT_NVG As Integer, ByVal COUNT_OPKTRG As Integer, ByVal COUNT_CNMT As Integer, ByVal CNMT As Integer, ByVal OPKTRG As Integer, ByVal NVG As Integer, ByVal GHICHU As String, ByVal Ngayvao As String) As Boolean
        Dim falg As Boolean
        '-----------------------------------
        Me.ID = ID
        Me.Table = Table
        Me.Ngay = NGAY
        Me.NV_MA = NV_MA
        Me.DV_MA = DV_MA
        Me.Xuong = Xuong
        Me.Nganh = Nganh
        Me.GHICHU = GHICHU
        '-----------------------------------
        If DILAM = True Then
            Me.m_sDILAM = 1
        Else
            Me.m_sDILAM = 0
        End If
        Me.DiLam = m_sDILAM
        '-----------------------------------
        If P = True Then
            Me.m_sP = 1
        Else
            Me.m_sP = 0
        End If
        Me.P = m_sP
        '-----------------------------------
        If R = True Then
            Me.m_sR = 1
        Else
            Me.m_sR = 0
        End If
        Me.R = m_sR
        '-----------------------------------
        If O = True Then
            Me.m_sO = 1
        Else
            Me.m_sO = 0
        End If
        Me.O = m_sO
        '-----------------------------------
        If CO = True Then
            Me.m_sCO = 1
        Else
            Me.m_sCO = 0
        End If
        Me.CO = m_sCO
        '-----------------------------------
        If RO = True Then
            Me.m_sRO = 1
        Else
            Me.m_sRO = 0
        End If
        Me.RO = m_sRO
        '-----------------------------------
        If OP = True Then
            Me.m_sOP = 1
        Else
            Me.m_sOP = 0
        End If
        Me.OP = m_sOP
        '-----------------------------------
        If NO = True Then
            Me.m_sNO = 1
        Else
            Me.m_sNO = 0
        End If
        Me.NO = m_sNO
        '-----------------------------------
        If KT = True Then
            Me.m_sKT = 1
        Else
            Me.m_sKT = 0
        End If
        Me.KT = m_sKT
        '-----------------------------------
        If TSAN = True Then
            Me.m_sTSAN = 1
        Else
            Me.m_sTSAN = 0
        End If
        Me.TSAN = m_sTSAN
        '-----------------------------------
        If GIAM = True Then
            Me.m_sGIAM = 1
        Else
            Me.m_sGIAM = 0
        End If
        Me.GIAM = m_sGIAM
        '-----------------------------------
        If TANG = True Then
            Me.m_sTANG = 1
        Else
            Me.m_sTANG = 0
        End If
        Me.TANG = m_sTANG
        '-----------------------------------
        If GIOITINH = True Then
            Me.m_sGIOITINH = 1
        Else
            Me.m_sGIOITINH = 0
        End If
        Me.GIOITINH = m_sGIOITINH
        '-----------------------------------
        Me.DV_DIEUDONG = DV_DIEUDONG
        Me.DVDD_CU = DVDD_CU
        '-----------------------------------
        If NVG = True Then
            Me.m_sNVG = 1
        Else
            Me.m_sNVG = 0
        End If
        Me.NVG = m_sNVG
        '-----------------------------------
        If CNMT = True Then
            Me.m_sCNMT = 1
        Else
            Me.m_sCNMT = 0
        End If
        Me.CNMT = m_sCNMT
        '-----------------------------------
        If OPKTRG = True Then
            Me.m_sOPKTRG = 1
        Else
            Me.m_sOPKTRG = 0
        End If
        Me.OPKTRG = m_sOPKTRG
        '-----------------------------------
        Me.COUNT_DILAM = COUNT_DILAM
        Me.COUNT_P = COUNT_P
        Me.COUNT_R = COUNT_R
        Me.COUNT_O = COUNT_O
        Me.COUNT_CO = COUNT_CO
        Me.COUNT_RO = COUNT_RO
        Me.COUNT_OP = COUNT_OP
        Me.COUNT_NO = COUNT_NO
        Me.COUNT_KT = COUNT_KT
        Me.COUNT_TSAN = COUNT_TSAN
        Me.COUNT_GIAM = COUNT_GIAM
        Me.COUNT_TANG = COUNT_TANG
        Me.COUNT_NAM = COUNT_NAM
        Me.COUNT_NU = COUNT_NU
        Me.COUNT_CNMT = COUNT_CNMT
        Me.COUNT_NVG = COUNT_NVG
        Me.COUNT_OPKTRG = COUNT_OPKTRG
        Me.Ngayvaobs = Ngayvao
        '-----------------------------------
        Return False
    End Function


    Public Overridable Function setvalue_chon(ByVal m_sID As String, ByVal m_sTable As String, ByVal m_sNGAY As String, ByVal m_sNV_MA As String, ByVal m_sDV_MA As String, ByVal DILAM As Integer, ByVal P As Integer, ByVal R As Integer, ByVal O As Integer, ByVal CO As Integer, ByVal RO As Integer, ByVal OP As Integer, ByVal NO As Integer, ByVal KT As Integer, ByVal TSAN As Integer, ByVal GIAM As Integer, ByVal GIOITINH As Integer, ByVal m_sDV_DIEUDONG As String, ByVal m_sDVDD_CU As String, ByVal CNMT As Integer, ByVal OPKTRG As Integer, ByVal NVG As Integer, ByVal m_sGHICHU As String) As Boolean
        Dim falg As Boolean

        Me.ID = m_sID
        Me.Table = m_sTable
        Me.Ngay = m_sNGAY
        Me.Ngay = m_sNGAY
        Me.NV_MA = m_sNV_MA
        Me.DV_MA = m_sDV_MA
        Me.GHICHU = m_sGHICHU
        Me.DVDD_CU = m_sDVDD_CU

        If DILAM = True Then
            Me.m_sDILAM = 1
        Else
            Me.m_sDILAM = 0
        End If
        Me.DiLam = m_sDILAM
        If P = True Then
            Me.m_sP = 1
        Else
            Me.m_sP = 0
        End If
        Me.P = m_sP
        If R = True Then
            Me.m_sR = 1
        Else
            Me.m_sR = 0
        End If
        Me.R = m_sR
        If O = True Then
            Me.m_sO = 1
        Else
            Me.m_sO = 0
        End If
        Me.O = m_sO
        If CO = True Then
            Me.m_sCO = 1
        Else
            Me.m_sCO = 0
        End If
        Me.CO = m_sCO
        If RO = True Then
            Me.m_sRO = 1
        Else
            Me.m_sRO = 0
        End If
        Me.RO = m_sRO
        If OP = True Then
            Me.m_sOP = 1
        Else
            Me.m_sOP = 0
        End If
        Me.OP = m_sOP
        If NO = True Then
            Me.m_sNO = 1
        Else
            Me.m_sNO = 0
        End If
        Me.NO = m_sNO
        If KT = True Then
            Me.m_sKT = 1
        Else
            Me.m_sKT = 0
        End If
        Me.KT = m_sKT

        If TSAN = True Then
            Me.m_sTSAN = 1
        Else
            Me.m_sTSAN = 0
        End If
        Me.TSAN = m_sTSAN

        If GIAM = True Then
            Me.m_sGIAM = 1
        Else
            Me.m_sGIAM = 0
        End If
        Me.GIAM = m_sGIAM

        If GIOITINH = True Then
            Me.m_sGIOITINH = 1
        Else
            Me.m_sGIOITINH = 0
        End If
        Me.GIOITINH = m_sGIOITINH

        Me.DV_DIEUDONG = m_sDV_DIEUDONG

        If NVG = True Then
            Me.m_sNVG = 1
        Else
            Me.m_sNVG = 0
        End If
        Me.NVG = m_sNVG

        If CNMT = True Then
            Me.m_sCNMT = 1
        Else
            Me.m_sCNMT = 0
        End If
        Me.CNMT = m_sCNMT

        If OPKTRG = True Then
            Me.m_sOPKTRG = 1
        Else
            Me.m_sOPKTRG = 0
        End If
        Me.OPKTRG = m_sOPKTRG

        Return False

    End Function


    Public Overridable Function setvalue_TSBC(ByVal ID As String, ByVal Table As String, ByVal NGAY As String, ByVal DV_MA As String, ByVal TSBC As Integer) As Boolean
        Dim falg As Boolean

        Me.ID = ID
        Me.Table = Table
        Me.Ngay = Ngay
        Me.DV_MA = DV_MA
        Me.TSBC = TSBC

        Return False
    End Function

    Public Overridable Function setvalue_DDT(ByVal m_sTANG As Integer, ByVal m_sDV_MA As String, ByVal m_sXuong As String, ByVal m_sNganh As String) As String
        Dim falg As Boolean
        Me.ID = m_sID
        Me.TANG = m_sTANG
        Me.DV_MA = m_sDV_MA
        Me.Xuong = m_sXuong
        Me.Nganh = m_sNganh
        Return False
    End Function

    Public Function Setnull() As Boolean
        Dim flag As Boolean

        Me.ChonBang = 0
        Me.ID = ""
        Me.Table = ""
        Me.Ngay = "0/0/0"
        Me.NV_MA = ""

        Me.DV_MA = ""
        Me.DV_MA_ = ""
        Me.DV_DIEUDONG = ""
        Me.DVDD_CU = ""

        Me.DiLam = True
        Me.P = True
        Me.R = True
        Me.O = True
        Me.CO = True
        Me.RO = True
        Me.OP = True
        Me.NO = True
        Me.KT = True
        Me.TSAN = True
        Me.GIAM = True
        Me.GIOITINH = True
        Return flag
    End Function

End Class
