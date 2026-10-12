Public Class objChuyenDVExcel
    Public Property NGAYCD_LUOI() As String
        Get
            Return Me.m_sNGAYCD_LUOI
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCD_LUOI = Value
        End Set
    End Property

    Public Property NGAYCD() As String
        Get
            Return Me.m_sNGAYCD
        End Get
        Set(ByVal Value As String)
            Me.m_sNGAYCD = Value
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
    'Public Function KtMa() As Boolean
    '    Return (StringType.StrCmp(Me.MANV, "", False) <> 0)
    'End Function
    Public m_sMANV As String
    Public m_sNGAYCD As String
    Public m_sNGAYCD_LUOI As String
    Public m_sChonTable As Integer
End Class
