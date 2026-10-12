Public Class objBaoCaoGioVaoRa
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.NGAY = ""
        Me.ChonBang = 0
        Return flag
    End Function
    Public Overridable Function setvalue(ByVal m_sTruyVan As String, ByVal m_sID As String, ByVal m_sTable As String, ByVal m_ChonTable As Integer) As Boolean
        Me.ChonBang = m_sChonTable
        Return False
    End Function
    Public Property XemDonviDD() As Integer
        Get
            Return Me.m_iXemtheoDD
        End Get
        Set(ByVal Value As Integer)
            Me.m_iXemtheoDD = Value
        End Set
    End Property
    Public Property NgayDauTuan() As String
        Get
            Return Me.m_sNgayDauTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayDauTuan = Value
        End Set
    End Property
    Public Property NgayCuoiTuan() As String
        Get
            Return Me.m_sNgayCuoiTuan
        End Get
        Set(ByVal Value As String)
            Me.m_sNgayCuoiTuan = Value
        End Set
    End Property
    Public Property D_Ngay() As Integer
        Get
            Return Me.m_idNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_idNgay = Value
        End Set
    End Property
    Public Property M_Ngay() As Integer
        Get
            Return Me.m_imNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_imNgay = Value
        End Set
    End Property
    Public Property Y_Ngay() As Integer
        Get
            Return Me.m_iyNgay
        End Get
        Set(ByVal Value As Integer)
            Me.m_iyNgay = Value
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
    Public Property DONVI() As String
        Get
            Return Me.m_sDV
        End Get
        Set(ByVal Value As String)
            Me.m_sDV = Value
        End Set
    End Property
    Public Property ChonXuong() As String
        Get
            Return Me.m_sXuong
        End Get
        Set(ByVal Value As String)
            Me.m_sXuong = Value
        End Set
    End Property
    Public Property KHONGQTVAO() As Integer
        Get
            Return Me.m_iKhongQuetTheVao
        End Get
        Set(ByVal Value As Integer)
            Me.m_iKhongQuetTheVao = Value
        End Set
    End Property
    Public Property KHONGQTRA() As Integer
        Get
            Return Me.m_iKhongQuetTheRa
        End Get
        Set(ByVal Value As Integer)
            Me.m_iKhongQuetTheRa = Value
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
    Public m_sNGAY As String
    Public m_sDV As String
    Public m_sXuong As String
    Public m_iKhongQuetTheVao As Integer
    Public m_iKhongQuetTheRa As Integer
    Public m_sChonTable As Integer
    Public m_sNgayDauTuan As String
    Public m_sNgayCuoiTuan As String
    Public m_idNgay As Integer
    Public m_iyNgay As Integer
    Public m_imNgay As Integer
    Public m_iXemtheoDD As Integer
End Class
