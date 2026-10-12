Public Class objCongViecNNDH
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal PNAM As String, ByVal PTHANG1 As String, ByVal PTHANG2 As String, ByVal PTHANG3 As String, ByVal PTHANG4 As String, ByVal PTHANG5 As String, ByVal PTHANG6 As String, ByVal PTHANG7 As String, ByVal PTHANG8 As String, ByVal PTHANG9 As String, ByVal PTHANG10 As String, ByVal PTHANG11 As String, ByVal PTHANG12 As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaNV = pmanv
        Me.NAM = PNAM
        Me.THANG1 = PTHANG1
        Me.THANG2 = PTHANG2
        Me.THANG3 = PTHANG3
        Me.THANG4 = PTHANG4
        Me.THANG5 = PTHANG5
        Me.THANG6 = PTHANG6
        Me.THANG7 = PTHANG7
        Me.THANG8 = PTHANG8
        Me.THANG9 = PTHANG9
        Me.THANG10 = PTHANG10
        Me.THANG11 = PTHANG11
        Me.THANG12 = PTHANG12
        Me.ChonBang = m_sChonTable
        Return False
    End Function

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
    Public Property NAM() As String
        Get
            Return Me.m_sNAM
        End Get
        Set(ByVal Value As String)
            Me.m_sNAM = Value
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
    Public Property THANG1() As String
        Get
            Return Me.m_sTHANG1
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG1 = Value
        End Set
    End Property
    Public Property THANG2() As String
        Get
            Return Me.m_sTHANG2
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG2 = Value
        End Set
    End Property
    Public Property THANG3() As String
        Get
            Return Me.m_sTHANG3
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG3 = Value
        End Set
    End Property
    Public Property THANG4() As String
        Get
            Return Me.m_sTHANG4
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG4 = Value
        End Set
    End Property
    Public Property THANG5() As String
        Get
            Return Me.m_sTHANG5
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG5 = Value
        End Set
    End Property
    Public Property THANG6() As String
        Get
            Return Me.m_sTHANG6
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG6 = Value
        End Set
    End Property
    Public Property THANG7() As String
        Get
            Return Me.m_sTHANG7
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG7 = Value
        End Set
    End Property
    Public Property THANG8() As String
        Get
            Return Me.m_sTHANG8
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG8 = Value
        End Set
    End Property
    Public Property THANG9() As String
        Get
            Return Me.m_sTHANG9
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG9 = Value
        End Set
    End Property
    Public Property THANG10() As String
        Get
            Return Me.m_sTHANG10
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG10 = Value
        End Set
    End Property
    Public Property THANG11() As String
        Get
            Return Me.m_sTHANG11
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG11 = Value
        End Set
    End Property
    Public Property THANG12() As String
        Get
            Return Me.m_sTHANG12
        End Get
        Set(ByVal Value As String)
            Me.m_sTHANG12 = Value
        End Set
    End Property


    Public m_sMaNV As String
    Public m_sNAM As String
    Public m_sDonVi As String
    Public m_sTHANG1 As String
    Public m_sTHANG2 As String
    Public m_sTHANG3 As String
    Public m_sTHANG4 As String
    Public m_sTHANG5 As String
    Public m_sTHANG6 As String
    Public m_sTHANG7 As String
    Public m_sTHANG8 As String
    Public m_sTHANG9 As String
    Public m_sTHANG10 As String
    Public m_sTHANG11 As String
    Public m_sTHANG12 As String
    Public m_sChonTable As Integer
End Class
