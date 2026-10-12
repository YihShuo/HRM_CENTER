Public Class objNganh
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pman As String, ByVal ptenn As String, ByVal ptentw As String, ByVal pstt As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaN = pman
        Me.TenN = ptenn
        Me.TenTW = ptentw
        Me.SoThuTu = pstt
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
    Public Property MaN() As String
        Get
            Return Me.m_sMaN
        End Get
        Set(ByVal Value As String)
            Me.m_sMaN = Value
        End Set
    End Property
    Public Property TenN() As String
        Get
            Return Me.m_sTenN
        End Get
        Set(ByVal Value As String)
            Me.m_sTenN = Value
        End Set
    End Property
    Public Property TenTW() As String
        Get
            Return Me.m_sTenTW
        End Get
        Set(ByVal Value As String)
            Me.m_sTenTW = Value
        End Set
    End Property
    Public Property SoThuTu() As Integer
        Get
            Return Me.m_sSTT
        End Get
        Set(ByVal Value As Integer)
            Me.m_sSTT = Value
        End Set
    End Property
   
    Public m_sMaN As String
    Public m_sTenN As String
    Public m_sSTT As Integer
    Public m_sTenTW As String
    Public m_sChonTable As Integer
End Class
