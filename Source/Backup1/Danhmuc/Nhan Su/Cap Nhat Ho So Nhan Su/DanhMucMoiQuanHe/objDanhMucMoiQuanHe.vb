Public Class objDanhMucMoiQuanHe
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal pten As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaQH = pmanv
        Me.TenQH = pten
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
    Public Property MaQH() As String
        Get
            Return Me.m_sMaQH
        End Get
        Set(ByVal Value As String)
            Me.m_sMaQH = Value
        End Set
    End Property
    Public Property TenQH() As String
        Get
            Return Me.m_sTenQH
        End Get
        Set(ByVal Value As String)
            Me.m_sTenQH = Value
        End Set
    End Property

    Public m_sMaQH As String
    Public m_sTenQH As String
    Public m_sChonTable As Integer
End Class
