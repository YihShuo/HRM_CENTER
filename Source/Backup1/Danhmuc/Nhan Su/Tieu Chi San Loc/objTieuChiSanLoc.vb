Public Class objTieuChiSanLoc
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MAHS = ""
        Me.NgayNop = ""
        Me.MucLuongMM = ""
        Me.NgoaiNgu = ""
        Me.QuanHe1 = ""
        Me.QuanHe2 = ""
        Me.SoCMND = ""
        Me.TDHocVan = ""
        Me.TinHoc = ""
        Me.ToChat = ""
        Me.ViTri = ""
        Me.KyNang = ""
        Me.KinhNghiem = ""
        Me.HOTEN2 = ""
        Me.HOTEN1 = ""
        Me.HOTEN = ""
        Me.HoatDong = ""
        Me.FACE = ""
        Me.GioiTinh = 0
        Me.EMAIL = ""
        Me.DVGioiThieu = ""
        Me.DTNhaRieng = ""
        Me.DTDD = ""
        Me.DienThoai2 = ""
        Me.DienThoai1 = ""
        Me.DIACHI = ""
        Me.ChuyenMon = ""
        Me.ChungChiK = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal nvcm As Integer, ByVal ldpt As Integer, ByVal mhs As String, ByVal mngaynop As String, ByVal hten As String, ByVal pgioitinh As Integer, ByVal ns As String, ByVal chonnamsinh As Integer, ByVal dtdd As String, ByVal dtnr As String, ByVal dc As String, ByVal e As String, ByVal fa As String, ByVal cmnd As String, ByVal hv As String, ByVal cm As String, ByVal cck As String, ByVal kn As String, ByVal knang As String, ByVal tc As String, ByVal hd As String, ByVal nn As String, ByVal th As String, ByVal ketq As Integer, ByVal chuaphongvan As Integer, ByVal sodiem As String, ByVal hten1 As String, ByVal qh1 As String, ByVal dt1 As String, ByVal hten2 As String, ByVal qh2 As String, ByVal dt2 As String, ByVal dvgt As String, ByVal ml As String, ByVal vt As String, ByVal m_ChonTable As Integer) As Boolean
        If nvcm = True Then
            m_sNVCM = 1
        Else
            m_sNVCM = 0
        End If
        Me.NVCM = m_sNVCM
        If ldpt = True Then
            m_sLDPT = 1
        Else
            m_sLDPT = 0
        End If
        Me.LDPT = m_sLDPT
        Me.MAHS = mhs
        Me.NgayNop = mngaynop
        Me.HOTEN = hten
        If pgioitinh = True Then
            m_sGioiTinh = 0
        Else
            m_sGioiTinh = 1
        End If
        Me.GioiTinh = m_sGioiTinh

        Me.NgaySinh = ns
        If chonnamsinh = 1 Then
            m_bChonNamSinh = 1
        Else
            m_bChonNamSinh = 0
        End If
        Me.ChonNamSinh = m_bChonNamSinh
        Me.DTDD = dtdd
        Me.DTNhaRieng = dtnr
        Me.DIACHI = dc
        Me.EMAIL = e
        Me.FACE = fa
        Me.SoCMND = cmnd
        Me.TDHocVan = hv
        Me.ChuyenMon = cm
        Me.ChungChiK = cck
        Me.KinhNghiem = kn
        Me.KyNang = knang
        Me.ToChat = tc
        Me.HoatDong = hd
        Me.NgoaiNgu = nn
        Me.TinHoc = th
        If ketq = True Then
            m_sKQ = 1
        Else
            m_sKQ = 0
        End If
        Me.KetQua = m_sKQ
        If chuaphongvan = True Then
            m_sCPV = 1
        Else
            m_sCPV = 0
        End If
        Me.ChuaPV = m_sCPV
        Me.SoDiemDat = sodiem
        Me.HOTEN1 = hten1
        Me.QuanHe1 = qh1
        Me.DienThoai1 = dt1
        Me.HOTEN2 = hten2
        Me.QuanHe2 = qh2
        Me.DienThoai2 = dt2
        Me.DVGioiThieu = dvgt
        Me.MucLuongMM = ml
        Me.ViTri = vt
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property NVCM() As Integer
        Get
            Return Me.m_sNVCM
        End Get
        Set(ByVal Value As Integer)
            Me.m_sNVCM = Value
        End Set
    End Property
    Public Property LDPT() As Integer
        Get
            Return Me.m_sLDPT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sLDPT = Value
        End Set
    End Property
    Public Property MAHS() As String
        Get
            Return Me.m_sMAHS
        End Get
        Set(ByVal Value As String)
            Me.m_sMAHS = Value
        End Set
    End Property
    Public Property NgayNop() As String
        Get
            Return Me.m_sNgayNop
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayNop = Value
        End Set
    End Property
    Public Property HOTEN() As String
        Get
            Return Me.m_sHOTEN
        End Get
        Set(ByVal Value As String)
            Me.m_sHOTEN = Value
        End Set
    End Property
    Public Property GioiTinh() As Integer
        Get
            Return Me.m_sGioiTinh
        End Get
        Set(ByVal Value As Integer)
            Me.m_sGioiTinh = Value
        End Set
    End Property
    Public Property KetQua() As Integer
        Get
            Return Me.m_sKQ
        End Get
        Set(ByVal Value As Integer)
            Me.m_sKQ = Value
        End Set
    End Property
    Public Property ChuaPV() As Integer
        Get
            Return Me.m_sCPV
        End Get
        Set(ByVal Value As Integer)
            Me.m_sCPV = Value
        End Set
    End Property
    Public Property SoDiemDat() As String
        Get
            Return Me.m_sSD
        End Get
        Set(ByVal Value As String)
            Me.m_sSD = Value
        End Set
    End Property
    Public Property NgaySinh() As String
        Get
            Return Me.m_sNgaySinh
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaySinh = Value
        End Set
    End Property
    Public Property ChonNamSinh() As Integer
        Get
            Return Me.m_bChonNamSinh
        End Get
        Set(ByVal Value As Integer)
            Me.m_bChonNamSinh = Value
        End Set
    End Property
    Public Property DTDD() As String
        Get
            Return Me.m_sDTDD
        End Get
        Set(ByVal Value As String)
            Me.m_sDTDD = Value
        End Set
    End Property
    Public Property DTNhaRieng() As String
        Get
            Return Me.m_sDTNhaRieng
        End Get
        Set(ByVal Value As String)
            Me.m_sDTNhaRieng = Value
        End Set
    End Property
    Public Property DIACHI() As String
        Get
            Return Me.m_sDIACHI
        End Get
        Set(ByVal Value As String)
            Me.m_sDIACHI = Value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return Me.m_sEMAIL
        End Get
        Set(ByVal Value As String)
            Me.m_sEMAIL = Value
        End Set
    End Property
    Public Property FACE() As String
        Get
            Return Me.m_sFACE
        End Get
        Set(ByVal Value As String)
            Me.m_sFACE = Value
        End Set
    End Property
    Public Property SoCMND() As String
        Get
            Return Me.m_sSoCMND
        End Get
        Set(ByVal Value As String)
            Me.m_sSoCMND = Value
        End Set
    End Property
    Public Property TDHocVan() As String
        Get
            Return Me.m_sHocVan
        End Get
        Set(ByVal Value As String)
            Me.m_sHocVan = Value
        End Set
    End Property
    Public Property ChuyenMon() As String
        Get
            Return Me.m_sChuyenMon
        End Get
        Set(ByVal Value As String)
            Me.m_sChuyenMon = Value
        End Set
    End Property
    Public Property ChungChiK() As String
        Get
            Return Me.m_sCCK
        End Get
        Set(ByVal Value As String)
            Me.m_sCCK = Value
        End Set
    End Property
    Public Property KinhNghiem() As String
        Get
            Return Me.m_sKN
        End Get
        Set(ByVal Value As String)
            Me.m_sKN = Value
        End Set
    End Property
    Public Property KyNang() As String
        Get
            Return Me.m_sKNang
        End Get
        Set(ByVal Value As String)
            Me.m_sKNang = Value
        End Set
    End Property
    Public Property ToChat() As String
        Get
            Return Me.m_sTC
        End Get
        Set(ByVal Value As String)
            Me.m_sTC = Value
        End Set
    End Property
    Public Property HoatDong() As String
        Get
            Return Me.m_sHDXH
        End Get
        Set(ByVal Value As String)
            Me.m_sHDXH = Value
        End Set
    End Property
    Public Property NgoaiNgu() As String
        Get
            Return Me.m_sNgoaiNgu
        End Get
        Set(ByVal Value As String)
            Me.m_sNgoaiNgu = Value
        End Set
    End Property
    Public Property TinHoc() As String
        Get
            Return Me.m_sTinHoc
        End Get
        Set(ByVal Value As String)
            Me.m_sTinHoc = Value
        End Set
    End Property
    Public Property HOTEN1() As String
        Get
            Return Me.m_sHOTEN1
        End Get
        Set(ByVal Value As String)
            Me.m_sHOTEN1 = Value
        End Set
    End Property
    Public Property QuanHe1() As String
        Get
            Return Me.m_sQH1
        End Get
        Set(ByVal Value As String)
            Me.m_sQH1 = Value
        End Set
    End Property
    Public Property DienThoai1() As String
        Get
            Return Me.m_sDT1
        End Get
        Set(ByVal Value As String)
            Me.m_sDT1 = Value
        End Set
    End Property
    Public Property HOTEN2() As String
        Get
            Return Me.m_sHOTEN2
        End Get
        Set(ByVal Value As String)
            Me.m_sHOTEN2 = Value
        End Set
    End Property
    Public Property QuanHe2() As String
        Get
            Return Me.m_sQH2
        End Get
        Set(ByVal Value As String)
            Me.m_sQH2 = Value
        End Set
    End Property
    Public Property DienThoai2() As String
        Get
            Return Me.m_sDT2
        End Get
        Set(ByVal Value As String)
            Me.m_sDT2 = Value
        End Set
    End Property
    Public Property DVGioiThieu() As String
        Get
            Return Me.m_sDVGT
        End Get
        Set(ByVal Value As String)
            Me.m_sDVGT = Value
        End Set
    End Property
    Public Property MucLuongMM() As String
        Get
            Return Me.m_sML
        End Get
        Set(ByVal Value As String)
            Me.m_sML = Value
        End Set
    End Property
    Public Property ViTri() As String
        Get
            Return Me.m_sVT
        End Get
        Set(ByVal Value As String)
            Me.m_sVT = Value
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
    Public m_sDTDD As String
    Public m_sNgaySinh As String
    Public m_sNgayNop As String
    Public m_sGioiTinh As Integer
    Public m_sLDPT As Integer
    Public m_sNVCM As Integer
    Public m_sKQ As Integer
    Public m_sCPV As Integer
    'moi
    Public m_sHOTEN As String
    Public m_sMAHS As String
    Public m_sChonTable As Integer
    Public m_sMANV As String
    Public m_sTEN As String
    Public m_sVT As String
    Public m_sML As String
    Public m_sDVGT As String
    Public m_sDT2 As String
    Public m_sQH1 As String
    Public m_sQH2 As String
    Public m_sHOTEN2 As String
    Public m_sDT1 As String
    Public m_sHOTEN1 As String
    Public m_sTinHoc As String
    Public m_sNgoaiNgu As String
    Public m_sHDXH As String
    Public m_sTC As String
    Public m_sKNang As String
    Public m_sKN As String
    Public m_sCCK As String
    Public m_sHocVan As String
    Public m_sSoCMND As String
    Public m_sFACE As String
    Public m_sEMAIL As String
    Public m_sDIACHI As String
    Public m_sDTNhaRieng As String
    Public m_sSD As String
    Public m_sChuyenMon As String
    Public m_bChonNamSinh As Integer
End Class
