Public Class objChiNhanh
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function

    Public Overridable Function setvalue(ByVal pmanv As String, ByVal pten As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaCN = pmanv
        Me.TenCN = pten
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
    Public Property MaCN() As String
        Get
            Return Me.m_sMaCN
        End Get
        Set(ByVal Value As String)
            Me.m_sMaCN = Value
        End Set
    End Property
    Public Property TenCN() As String
        Get
            Return Me.m_sTenCN
        End Get
        Set(ByVal Value As String)
            Me.m_sTenCN = Value
        End Set
    End Property

    Public m_sMaCN As String
    Public m_sTenCN As String
    Public m_sChonTable As Integer
End Class
