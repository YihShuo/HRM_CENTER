Public Class objKiemTraCMND
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Table = ""
        Me.MaNV = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function SetnullQH() As Boolean
        Dim flag As Boolean
        Me.ID = ""
        Me.Table = ""
        Me.MaNVQH = ""
        Me.MaQH = ""
        Me.HoTenQH = ""
        Me.TENTHUONGGOI = ""
        Me.NGHENGHIEP = ""
        Me.NOICONGTAC = ""
        Me.DiaChiQH = ""
        Me.SoCMNDQH = ""
        Me.SOTHE = ""

        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_sID As String, ByVal m_sTable As String, ByVal pmanv As String, ByVal pHoten As String, ByVal pmatu As String, ByVal pdonvi As String, ByVal pgioitinh As Integer, ByVal pngaysinh As String, ByVal psoCMND As String, ByVal pnoicap As String, ByVal pngaycap As String, ByVal pthuongtru As String, ByVal pnharieng As String, ByVal pdidong As String, ByVal pHonnhan As Integer, ByVal psocon As Integer, ByVal pbshs As Integer, ByVal pNDBS As String, ByVal pdiachi As String, ByVal pquoctich As String, ByVal pdantoc As String, ByVal ptongiao As String, ByVal phocvan As String, ByVal pngoaingu As String, ByVal pchuyenmon As String, ByVal ptinhoc As String, ByVal pcongviec As String, ByVal pchucvu As String, ByVal pngayvao As String, ByVal pngaybonhiem As String, ByVal ptinhthanh As String, ByVal pquanhuyen As String, ByVal pdangvien As Integer, ByVal pngayvaodang As String, ByVal pnoivao As String, ByVal ptnvn As Integer, ByVal ptdct As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.MaNV = pmanv
        Me.HoTen = pHoten
        Me.MaTu = pmatu
        Me.DonVi = pdonvi
        If pgioitinh = True Then
            m_sGioiTinh = 0
        Else
            m_sGioiTinh = 1
        End If
        Me.GioiTinh = m_sGioiTinh
        Me.NgaySinh = pngaysinh
        Me.SoCMND = psoCMND
        Me.NoiCap = pnoicap
        Me.NgayCap = pngaycap
        Me.ThuongTru = pthuongtru
        Me.DTNhaRieng = pnharieng
        Me.DTDD = pdidong
        If pHonnhan = True Then
            m_sHonNhan = 1
        Else
            m_sHonNhan = 0
        End If
        Me.HonNhan = m_sHonNhan
        Me.SoCon = psocon
        Me.BSHS = pbshs
        Me.NOIDUNGBS = pNDBS
        Me.DiaChi = pdiachi
        Me.QuocTich = pquoctich
        Me.DanToc = pdantoc
        Me.TonGiao = ptongiao
        Me.TDHocVan = phocvan
        Me.NgoaiNgu = pngoaingu
        Me.ChuyenMon = pchuyenmon
        Me.TinHoc = ptinhoc
        Me.CongViec = pcongviec
        Me.ChucVu = pchucvu
        Me.NgayVao = pngayvao
        Me.NgayBoNhiem = pngaybonhiem
        Me.TinhThanh = ptinhthanh
        Me.QuanHuyen = pquanhuyen

        If pdangvien = True Then
            m_sDV = 0
        Else
            m_sDV = 1
        End If
        Me.DANGVIEN = pdangvien
        Me.NgayVaoDang = pngayvaodang
        Me.NOIVAO = pnoivao
        If ptnvn = True Then
            m_sTNVN = 0
        Else
            m_sTNVN = 1
        End If
        Me.TNVN = ptnvn
        Me.TDCT = ptdct
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    ' MOI QUAN HE
    Public Overridable Function setvalueQH(ByVal m_sID As String, ByVal m_sTable As String, ByVal pmanvqh As String, ByVal pmaqh As String, ByVal psott As Integer, ByVal pHotenqh As String, ByVal pngaysinhqh As String, ByVal ptenthuonggoi As String, ByVal pnghenghiep As String, ByVal pnoicongtac As String, ByVal pdiachiqh As String, ByVal psocmndqh As String, ByVal pngaycapqh As String, ByVal pcaptai As String, ByVal psothe As String, ByVal pcolamviec As Integer, ByVal m_ChonTable As Integer) As Boolean
        Me.ID = m_sID
        Me.Table = m_sTable
        Me.MaNVQH = pmanvqh
        Me.MaQH = pmaqh
        Me.SoTT = psott
        Me.HoTenQH = pHotenqh
        Me.NgaySinhQH = pngaysinhqh
        Me.TENTHUONGGOI = ptenthuonggoi
        Me.NGHENGHIEP = pnghenghiep
        Me.NOICONGTAC = pnoicongtac
        Me.DiaChiQH = pdiachiqh
        Me.SoCMNDQH = psocmndqh
        Me.NgayCapQH = pngaycapqh
        Me.CAPTAI = pcaptai

        If pcolamviec = True Then
            m_sCLV = 0
        Else
            m_sCLV = 1
        End If
        Me.SOTHE = psothe
        Me.COLAMVIEC = pcolamviec
        Me.ChonBang = m_sChonTable
        Return False
    End Function

    ' Properties HO SO NHAN VIEN
    Public Property ID() As String
        Get
            Return Me.m_sID
        End Get
        Set(ByVal Value As String)
            Me.m_sID = Value
        End Set
    End Property
    Public Property CauTruyVan() As String
        Get
            Return Me.m_sTruyVan
        End Get
        Set(ByVal Value As String)
            Me.m_sTruyVan = Value
        End Set
    End Property
    Public Property Table() As String
        Get
            Return Me.m_sTable
        End Get
        Set(ByVal Value As String)
            Me.m_sTable = Value
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
    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
        End Set
    End Property
    Public Property HoTen() As String
        Get
            Return Me.m_sHoTen
        End Get
        Set(ByVal Value As String)
            Me.m_sHoTen = Value
        End Set
    End Property
    Public Property MaTu() As String
        Get
            Return Me.m_sMaTu
        End Get
        Set(ByVal Value As String)
            Me.m_sMaTu = Value
        End Set
    End Property
    Public Property DonVi() As String
        Get
            Return Me.m_sDonVi
        End Get
        Set(ByVal Value As String)
            Me.m_sDonVi = Value
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
    Public Property NgaySinh() As String
        Get
            Return Me.m_sNgaySinh
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaySinh = Value
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
    Public Property NoiCap() As String
        Get
            Return Me.m_sNoiCap
        End Get
        Set(ByVal Value As String)
            Me.m_sNoiCap = Value
        End Set
    End Property
    Public Property NgayCap() As String
        Get
            Return Me.m_sNgayCap
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCap = Value
        End Set
    End Property
    Public Property ThuongTru() As String
        Get
            Return Me.m_sThuongTru
        End Get
        Set(ByVal Value As String)
            Me.m_sThuongTru = Value
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
    Public Property DTDD() As String
        Get
            Return Me.m_sDTDD
        End Get
        Set(ByVal Value As String)
            Me.m_sDTDD = Value
        End Set
    End Property
    Public Property HonNhan() As Integer
        Get
            Return Me.m_sHonNhan
        End Get
        Set(ByVal Value As Integer)
            Me.m_sHonNhan = Value
        End Set
    End Property
    Public Property SoCon() As Integer
        Get
            Return Me.m_sSoCon
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSoCon = Value
        End Set
    End Property
    Public Property BSHS() As Integer
        Get
            Return Me.m_sBSHS
        End Get
        Set(ByVal Value As Integer)
            Me.m_sBSHS = Value
        End Set
    End Property
    Public Property NOIDUNGBS() As String
        Get
            Return Me.m_sNDBS
        End Get
        Set(ByVal Value As String)
            Me.m_sNDBS = Value
        End Set
    End Property
    Public Property DiaChi() As String
        Get
            Return Me.m_sDiachi
        End Get
        Set(ByVal Value As String)
            Me.m_sDiaChi = Value
        End Set
    End Property
    Public Property QuocTich() As String
        Get
            Return Me.m_sQuocTich
        End Get
        Set(ByVal Value As String)
            Me.m_sQuocTich = Value
        End Set
    End Property
    Public Property DanToc() As String
        Get
            Return Me.m_sDanToc
        End Get
        Set(ByVal Value As String)
            Me.m_sDanToc = Value
        End Set
    End Property
    Public Property TonGiao() As String
        Get
            Return Me.m_sTonGiao
        End Get
        Set(ByVal Value As String)
            Me.m_sTonGiao = Value
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
    Public Property NgoaiNgu() As String
        Get
            Return Me.m_sNgoaiNgu
        End Get
        Set(ByVal Value As String)
            Me.m_sNgoaiNgu = Value
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
    Public Property TinHoc() As String
        Get
            Return Me.m_sTinHoc
        End Get
        Set(ByVal Value As String)
            Me.m_sTinHoc = Value
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
    Public Property NgayVao() As String
        Get
            Return Me.m_sNgayVao
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayVao = Value
        End Set
    End Property
    Public Property NgayBoNhiem() As String
        Get
            Return Me.m_sNgayBoNhiem
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayBoNhiem = Value
        End Set
    End Property
    Public Property TinhThanh() As String
        Get
            Return Me.m_sTinhThanh
        End Get
        Set(ByVal Value As String)
            Me.m_sTinhThanh = Value
        End Set
    End Property
    Public Property QuanHuyen() As String
        Get
            Return Me.m_sQuanHuyen
        End Get
        Set(ByVal Value As String)
            Me.m_sQuanHuyen = Value
        End Set
    End Property

    Public Property DANGVIEN() As Integer
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As Integer)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property NgayVaoDang() As String
        Get
            Return Me.m_sNgayVD
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayVD = Value
        End Set
    End Property

    Public Property NOIVAO() As String
        Get
            Return Me.m_sNV
        End Get
        Set(ByVal Value As String)
            Me.m_sNV = Value
        End Set
    End Property
    Public Property TNVN() As Integer
        Get
            Return Me.m_sTNVN
        End Get
        Set(ByVal Value As Integer)
            Me.m_sTNVN = Value
        End Set
    End Property
    Public Property TDCT() As String
        Get
            Return Me.m_sTDCT
        End Get
        Set(ByVal Value As String)
            Me.m_sTDCT = Value
        End Set
    End Property
    '' Properties HO SO NHAN VIEN QUAN HE
    Public Property MaNVQH() As String
        Get
            Return Me.m_sMaNVQH
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNVQH = Value
        End Set
    End Property
    Public Property MaQH() As String
        Get
            Return Me.m_sMAQH
        End Get
        Set(ByVal Value As String)
            Me.m_sMaQH = Value
        End Set
    End Property
    Public Property MaQHLUOI() As String
        Get
            Return Me.m_sMaQHL
        End Get
        Set(ByVal Value As String)
            Me.m_sMaQHL = Value
        End Set
    End Property
    Public Property SoTT() As Integer
        Get
            Return Me.m_sSoTT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSoTT = Value
        End Set
    End Property
    Public Property SoTTLUOI() As Integer
        Get
            Return Me.m_sSoTTL
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSoTTL = Value
        End Set
    End Property
    Public Property HoTenQH() As String
        Get
            Return Me.m_sHoTenQH
        End Get
        Set(ByVal Value As String)
            Me.m_sHoTenQH = Value
        End Set
    End Property
    Public Property NgaySinhQH() As String
        Get
            Return Me.m_sNgaySinhQH
        End Get
        Set(ByVal Value As String)
            Me.m_sNgaySinhQH = Value
        End Set
    End Property
    Public Property TENTHUONGGOI() As String
        Get
            Return Me.m_sTTG
        End Get
        Set(ByVal Value As String)
            Me.m_sTTG = Value
        End Set
    End Property
    Public Property NGHENGHIEP() As String
        Get
            Return Me.m_sNN
        End Get
        Set(ByVal Value As String)
            Me.m_sNN = Value
        End Set
    End Property
    Public Property NOICONGTAC() As String
        Get
            Return Me.m_sNCT
        End Get
        Set(ByVal Value As String)
            Me.m_sNCT = Value
        End Set
    End Property
    Public Property DiaChiQH() As String
        Get
            Return Me.m_sDiaChiQH
        End Get
        Set(ByVal Value As String)
            Me.m_sDiaChiQH = Value
        End Set
    End Property
    Public Property SoCMNDQH() As String
        Get
            Return Me.m_sSoCMNDQH
        End Get
        Set(ByVal Value As String)
            Me.m_sSoCMNDQH = Value
        End Set
    End Property
    Public Property NgayCapQH() As String
        Get
            Return Me.m_sNgayCapQH
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCapQH = Value
        End Set
    End Property
    Public Property CAPTAI() As String
        Get
            Return Me.m_sCAPTAI
        End Get
        Set(ByVal Value As String)
            Me.m_sCAPTAI = Value
        End Set
    End Property

    Public Property SOTHE() As String
        Get
            Return Me.m_sST
        End Get
        Set(ByVal Value As String)
            Me.m_sST = Value
        End Set
    End Property
    Public Property COLAMVIEC() As Integer
        Get
            Return Me.m_sCLV
        End Get
        Set(ByVal Value As Integer)
            Me.m_sCLV = Value
        End Set
    End Property

    ' Fields HO SO NHAN VIEN
    Public m_sID As String
    Public m_sTruyVan As String
    Public m_sIDTuan As String
    Public m_sTable As String
    Public m_sMaNV As String
    Public m_sHoTen As String
    Public m_sMaTu As String
    Public m_sDonVi As String
    Public m_sGioiTinh As Integer
    Public m_sNgaySinh As String
    Public m_sSoCMND As String
    Public m_sNoiCap As String
    Public m_sNgayCap As String
    Public m_sThuongTru As String
    Public m_sDTNhaRieng As String
    Public m_sDTDD As String
    Public m_sHonNhan As Integer
    Public m_sSoCon As Integer
    Public m_sBSHS As Integer
    Public m_sNDBS As String
    Public m_sDiaChi As String
    Public m_sQuocTich As String
    Public m_sDanToc As String
    Public m_sTonGiao As String
    Public m_sHocVan As String
    Public m_sNgoaiNgu As String
    Public m_sChuyenMon As String
    Public m_sTinHoc As String
    Public m_sCongViec As String
    Public m_sChucVu As String
    Public m_sNgayVao As String
    Public m_sNgayBoNhiem As String
    Public m_sTinhThanh As String
    Public m_sQuanHuyen As String
    Public m_sDV As Integer
    Public m_sNgayVD As String
    Public m_sNV As String
    Public m_sTNVN As Integer
    Public m_sTDCT As String
    Public m_sChonTable As String

    ' Fields HO SO NHAN VIEN QUAN HE

    Public m_sMaNVQH As String
    Public m_sST As String
    Public m_sMaQH As String
    Public m_sSoTT As Integer
    Public m_sSoTTL As Integer
    Public m_sMaQHL As String
    Public m_sHoTenQH As String
    Public m_sNgaySinhQH As String
    Public m_sTTG As String
    Public m_sNN As String
    Public m_sNCT As String
    Public m_sDiaChiQH As String
    Public m_sSoCMNDQH As String
    Public m_sNgayCapQH As String
    Public m_sCAPTAI As String
    Public m_sCLV As Integer
End Class
