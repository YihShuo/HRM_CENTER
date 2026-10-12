Public Class objDanhMucMoiQuanHeChuHo

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal pten As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaQHChuHo = pmanv
        Me.TenQHChuHo = pten
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
    Public Property MaQHChuHo() As String
        Get
            Return Me.m_sMaQHChuHo
        End Get
        Set(ByVal Value As String)
            Me.m_sMaQHChuHo = Value
        End Set
    End Property
    Public Property TenQHChuHo() As String
        Get
            Return Me.m_sTenQHChuHo
        End Get
        Set(ByVal Value As String)
            Me.m_sTenQHChuHo = Value
        End Set
    End Property

    Public m_sMaQHChuHo As String
    Public m_sTenQHChuHo As String
    Public m_sChonTable As Integer
End Class
