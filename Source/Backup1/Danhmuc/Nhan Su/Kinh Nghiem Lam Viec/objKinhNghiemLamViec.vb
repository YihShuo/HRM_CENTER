Public Class objKinhNghiemLamViec
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.NV_MA = ""
        Me.KNLV_TENCONGTY1 = ""
        Me.KNLV_TINH1 = ""
        Me.KNLV_TUNAM1 = ""
        Me.KNLV_DENNAM1 = ""
        Me.KNLV_CV1 = ""
        Me.KNLV_LYDOTHOIVIEC1 = ""

        Me.KNLV_TENCONGTY2 = ""
        Me.KNLV_TINH2 = ""
        Me.KNLV_TUNAM2 = ""
        Me.KNLV_DENNAM2 = ""
        Me.KNLV_CV2 = ""
        Me.KNLV_LYDOTHOIVIEC2 = ""


        Me.KNLV_TENCONGTY3 = ""
        Me.KNLV_TINH3 = ""
        Me.KNLV_TUNAM3 = ""
        Me.KNLV_DENNAM3 = ""
        Me.KNLV_CV3 = ""
        Me.KNLV_LYDOTHOIVIEC3 = ""
        Me.ChonBang = 0
        Return flag
    End Function

    ' MOI QUAN HE
    Public Overridable Function setvalue(ByVal m_NV_MA As String, ByVal m_KNLV_TENCONGTY1 As String, ByVal m_KNLV_TINH1 As String, ByVal m_KNLV_TUNAM1 As String, ByVal m_KNLV_DENNAM1 As String, ByVal m_KNLV_CV1 As String, ByVal m_KNLV_LYDOTHOIVIEC1 As String, ByVal m_KNLV_TENCONGTY2 As String, ByVal m_KNLV_TINH2 As String, ByVal m_KNLV_TUNAM2 As String, ByVal m_KNLV_DENNAM2 As String, ByVal m_KNLV_CV2 As String, ByVal m_KNLV_LYDOTHOIVIEC2 As String, ByVal m_KNLV_TENCONGTY3 As String, ByVal m_KNLV_TINH3 As String, ByVal m_KNLV_TUNAM3 As String, ByVal m_KNLV_DENNAM3 As String, ByVal m_KNLV_CV3 As String, ByVal m_KNLV_LYDOTHOIVIEC3 As String, ByVal m_ChonTable As Integer) As Boolean
        Me.NV_MA = m_NV_MA
        Me.KNLV_TENCONGTY1 = m_KNLV_TENCONGTY1
        Me.KNLV_TINH1 = m_KNLV_TINH1
        Me.KNLV_TUNAM1 = m_KNLV_TUNAM1
        Me.KNLV_DENNAM1 = m_KNLV_DENNAM1
        Me.KNLV_CV1 = m_KNLV_CV1
        Me.KNLV_LYDOTHOIVIEC1 = m_KNLV_LYDOTHOIVIEC1

        Me.KNLV_TENCONGTY2 = m_KNLV_TENCONGTY2
        Me.KNLV_TINH2 = m_KNLV_TINH2
        Me.KNLV_TUNAM2 = m_KNLV_TUNAM2
        Me.KNLV_DENNAM2 = m_KNLV_DENNAM2
        Me.KNLV_CV2 = m_KNLV_CV2
        Me.KNLV_LYDOTHOIVIEC2 = m_KNLV_LYDOTHOIVIEC2


        Me.KNLV_TENCONGTY3 = m_KNLV_TENCONGTY3
        Me.KNLV_TINH3 = m_KNLV_TINH3
        Me.KNLV_TUNAM3 = m_KNLV_TUNAM3
        Me.KNLV_DENNAM3 = m_KNLV_DENNAM3
        Me.KNLV_CV3 = m_KNLV_CV3
        Me.KNLV_LYDOTHOIVIEC3 = m_KNLV_LYDOTHOIVIEC3

        Me.ChonBang = m_sChonTable
        Return False
    End Function

    ' Properties HO SO NHAN VIEN
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
    Public Property NV_MA() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal Value As String)
            Me.m_sMaNV = Value
        End Set
    End Property
    Public Property KNLV_TENCONGTY1() As String
        Get
            Return Me.m_sTenCTy1
        End Get
        Set(ByVal Value As String)
            Me.m_sTenCTy1 = Value
        End Set
    End Property
    Public Property KNLV_TINH1() As String
        Get
            Return Me.m_sKNLV_TINH1
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TINH1 = Value
        End Set
    End Property
    Public Property KNLV_TUNAM1() As String
        Get
            Return Me.m_sKNLV_TUNAM1
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TUNAM1 = Value
        End Set
    End Property
    Public Property KNLV_DENNAM1() As String
        Get
            Return Me.m_sKNLV_DENNAM1
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_DENNAM1 = Value
        End Set
    End Property

    Public Property KNLV_CV1() As String
        Get
            Return Me.m_sKNLV_CV1
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_CV1 = Value
        End Set
    End Property
    Public Property KNLV_LYDOTHOIVIEC1() As String
        Get
            Return Me.m_sKNLV_LYDOTHOIVIEC1
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_LYDOTHOIVIEC1 = Value
        End Set
    End Property


    Public Property KNLV_TENCONGTY2() As String
        Get
            Return Me.m_sTenCTy2
        End Get
        Set(ByVal Value As String)
            Me.m_sTenCTy2 = Value
        End Set
    End Property
    Public Property KNLV_TINH2() As String
        Get
            Return Me.m_sKNLV_TINH2
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TINH2 = Value
        End Set
    End Property
    Public Property KNLV_TUNAM2() As String
        Get
            Return Me.m_sKNLV_TUNAM2
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TUNAM2 = Value
        End Set
    End Property
    Public Property KNLV_DENNAM2() As String
        Get
            Return Me.m_sKNLV_DENNAM2
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_DENNAM2 = Value
        End Set
    End Property
    Public Property KNLV_CV2() As String
        Get
            Return Me.m_sKNLV_CV2
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_CV2 = Value
        End Set
    End Property
    Public Property KNLV_LYDOTHOIVIEC2() As String
        Get
            Return Me.m_sKNLV_LYDOTHOIVIEC2
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_LYDOTHOIVIEC2 = Value
        End Set
    End Property





    Public Property KNLV_TENCONGTY3() As String
        Get
            Return Me.m_sTenCTy3
        End Get
        Set(ByVal Value As String)
            Me.m_sTenCTy3 = Value
        End Set
    End Property
    Public Property KNLV_TINH3() As String
        Get
            Return Me.m_sKNLV_TINH3
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TINH3 = Value
        End Set
    End Property
    Public Property KNLV_TUNAM3() As String
        Get
            Return Me.m_sKNLV_TUNAM3
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_TUNAM3 = Value
        End Set
    End Property
    Public Property KNLV_DENNAM3() As String
        Get
            Return Me.m_sKNLV_DENNAM3
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_DENNAM3 = Value
        End Set
    End Property
    Public Property KNLV_CV3() As String
        Get
            Return Me.m_sKNLV_CV3
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_CV3 = Value
        End Set
    End Property
    Public Property KNLV_LYDOTHOIVIEC3() As String
        Get
            Return Me.m_sKNLV_LYDOTHOIVIEC3
        End Get
        Set(ByVal Value As String)
            Me.m_sKNLV_LYDOTHOIVIEC3 = Value
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


    Public Property Flag() As Boolean
        Get
            Return Me.m_bFlag
        End Get
        Set(ByVal Value As Boolean)
            Me.m_bFlag = Value
        End Set
    End Property

    ' Fields HO SO NHAN VIEN
    Public m_sKNLV_CV1 As String
    Public m_sKNLV_CV2 As String
    Public m_sKNLV_CV3 As String
    Public m_sTable As String
    Public m_sMaNV As String
    Public m_sTenCTy1 As String
    Public m_sKNLV_TINH1 As String
    Public m_sKNLV_TUNAM1 As String
    Public m_sKNLV_DENNAM1 As String
    Public m_sKNLV_LYDOTHOIVIEC1 As String
    Public m_sTenCTy2 As String
    Public m_sKNLV_TINH2 As String
    Public m_sKNLV_TUNAM2 As String
    Public m_sKNLV_DENNAM2 As String
    Public m_sKNLV_LYDOTHOIVIEC2 As String
    Public m_sTenCTy3 As String
    Public m_sKNLV_TINH3 As String
    Public m_sKNLV_TUNAM3 As String
    Public m_sKNLV_DENNAM3 As String
    Public m_sKNLV_LYDOTHOIVIEC3 As String
    Public m_sDonVi As String
    Public m_bFlag As Boolean
    Public m_sChonTable As String
End Class
