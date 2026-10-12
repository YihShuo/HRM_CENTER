Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objBinhBauThang
    Public Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0

        Return flag
    End Function

    Public Function setvalue(ByVal ma As String, ByVal th As String, ByVal dv As String, ByVal cong As Double, ByVal hs As Double, ByVal bbma As String, ByVal bbt As String, ByVal oo As String, ByVal ro As String, ByVal co As String, ByVal o As String, ByVal otc As String, ByVal p As String, ByVal kthai As String, ByVal r As String, ByVal s As String, ByVal no As String, ByVal tsan As String, ByVal tnld As String, ByVal dtre As String, ByVal dq As String, ByVal ds As String, ByVal st As String, ByVal khhgd As String, ByVal qs As String, ByVal co1 As String) As Boolean
        Dim flag As Boolean
        Me.NV_MA = ma
        Me.THANG = th
        Me.DV_MA = dv
        Me.CONGTT = cong
        Me.HESO2 = hs
        Me.Binhbau = bbma
        Me.BBTRUOC = bbt
        Me.SoNgayOO = oo
        Me.SoNgayRO = ro
        Me.SoNgayCO = co
        Me.SoNgayO = o
        Me.SoNgayOTC = otc
        Me.SoNgayP = p
        Me.SoNgayKTHAI = kthai
        Me.SoNgayR = r
        Me.SoNgayS = s
        Me.SoNgayNO = no
        Me.SoNgayTSAN = tsan
        Me.SoNgayTNLD = tnld
        Me.DITRE = dtre
        Me.SoNgayDQ = dq
        Me.SoNgayDS = ds
        Me.SoNgayKHHGD = khhgd
        Me.SoNgayQS = qs
        Me.SoNgayCO1 = co1
        Return flag
    End Function
    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonbang
        End Get
        Set(ByVal Value As Integer)
            Me.m_iChonbang = Value
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
    Public Property THANG() As String
        Get
            Return Me.m_sT
        End Get
        Set(ByVal Value As String)
            Me.m_sT = Value
        End Set
    End Property
    Public Property DV_MA() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property CONGTT() As Double
        Get
            Return Me.m_sCTT
        End Get
        Set(ByVal Value As Double)
            Me.m_sCTT = Value
        End Set
    End Property
    Public Property HESO2() As Double
        Get
            Return Me.m_sHS
        End Get
        Set(ByVal Value As Double)
            Me.m_sHS = Value
        End Set
    End Property
    Public Property Binhbau() As String
        Get
            Return Me.m_sBBM
        End Get
        Set(ByVal Value As String)
            Me.m_sBBM = Value
        End Set
    End Property
    Public Property BBTRUOC() As String
        Get
            Return Me.m_sBBT
        End Get
        Set(ByVal Value As String)
            Me.m_sBBT = Value
        End Set
    End Property
    Public Property SoNgayOO() As String
        Get
            Return Me.m_sOO
        End Get
        Set(ByVal Value As String)
            Me.m_sOO = Value
        End Set
    End Property
    Public Property SoNgayRO() As String
        Get
            Return Me.m_sRO
        End Get
        Set(ByVal Value As String)
            Me.m_sRO = Value
        End Set
    End Property
    Public Property SoNgayCO() As String
        Get
            Return Me.m_sCO
        End Get
        Set(ByVal Value As String)
            Me.m_sCO = Value
        End Set
    End Property
    Public Property SoNgayO() As String
        Get
            Return Me.m_sO
        End Get
        Set(ByVal Value As String)
            Me.m_sO = Value
        End Set
    End Property
    Public Property SoNgayOTC() As String
        Get
            Return Me.m_sOTC
        End Get
        Set(ByVal Value As String)
            Me.m_sOTC = Value
        End Set
    End Property
    Public Property SoNgayP() As String
        Get
            Return Me.m_sP
        End Get
        Set(ByVal Value As String)
            Me.m_sP = Value
        End Set
    End Property
    Public Property SoNgayKTHAI() As String
        Get
            Return Me.m_sKT
        End Get
        Set(ByVal Value As String)
            Me.m_sKT = Value
        End Set
    End Property
    Public Property SoNgayR() As String
        Get
            Return Me.m_sR
        End Get
        Set(ByVal Value As String)
            Me.m_sR = Value
        End Set
    End Property
    Public Property SoNgayS() As String
        Get
            Return Me.m_sS
        End Get
        Set(ByVal Value As String)
            Me.m_sS = Value
        End Set
    End Property
    Public Property SoNgayNO() As String
        Get
            Return Me.m_sNO
        End Get
        Set(ByVal Value As String)
            Me.m_sNO = Value
        End Set
    End Property
    Public Property SoNgayTSAN() As String
        Get
            Return Me.m_sTSAN
        End Get
        Set(ByVal Value As String)
            Me.m_sTSAN = Value
        End Set
    End Property
    Public Property SoNgayTNLD() As String
        Get
            Return Me.m_sTNLD
        End Get
        Set(ByVal Value As String)
            Me.m_sTNLD = Value
        End Set
    End Property
    Public Property DITRE() As String
        Get
            Return Me.m_sDT
        End Get
        Set(ByVal Value As String)
            Me.m_sDT = Value
        End Set
    End Property
    Public Property SoNgayDQ() As String
        Get
            Return Me.m_sDQ
        End Get
        Set(ByVal Value As String)
            Me.m_sDQ = Value
        End Set
    End Property
    Public Property SoNgayDS() As String
        Get
            Return Me.m_sDS
        End Get
        Set(ByVal Value As String)
            Me.m_sDS = Value
        End Set
    End Property
    Public Property SoNgayST() As String
        Get
            Return Me.m_sST
        End Get
        Set(ByVal Value As String)
            Me.m_sST = Value
        End Set
    End Property
    Public Property SoNgayKHHGD() As String
        Get
            Return Me.m_sKHHGD
        End Get
        Set(ByVal Value As String)
            Me.m_sKHHGD = Value
        End Set
    End Property
    Public Property SoNgayQS() As String
        Get
            Return Me.m_sQS
        End Get
        Set(ByVal Value As String)
            Me.m_sQS = Value
        End Set
    End Property
    Public Property FlagTinhBinhBau() As Boolean
        Get
            Return Me.m_bFlagTinhLuong
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bFlagTinhLuong = Value
        End Set
    End Property
    Public Property SoNgayCO1() As String
        Get
            Return Me.m_sCO1
        End Get
        Set(ByVal Value As String)
            Me.m_sCO1 = Value
        End Set
    End Property
    ' Fields
    Public m_iChonbang As Integer
    Public m_sCTT As Double
    Public m_sHS As Double
    Public m_sNV As String
    Public m_sT As String
    Public m_sDV As String
    Public m_sBBM As String
    Public m_sBBT As String
    Public m_sOO As String
    Public m_sRO As String
    Public m_sCO As String
    Public m_sO As String
    Public m_sOTC As String
    Public m_sP As String
    Public m_sKT As String
    Public m_sR As String
    Public m_sS As String
    Public m_sNO As String
    Public m_sTSAN As String
    Public m_sTNLD As String
    Public m_sDT As String
    Public m_sDQ As String
    Public m_sDS As String
    Public m_sST As String
    Public m_sKHHGD As String
    Public m_sQS As String
    Public m_bFlagTinhLuong As Boolean
    Public m_sCO1 As String
End Class
