Public Class objNoiDK

    Public m_sMaKCB As String
    Public m_sTenKCB As String
    Public m_iChonTable As Integer

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonTable
        End Get
        Set(ByVal value As Integer)
            Me.m_iChonTable = value
        End Set
    End Property

    Public Property MaKCB() As String
        Get
            Return Me.m_sMaKCB
        End Get
        Set(ByVal value As String)
            Me.m_sMaKCB = value
        End Set
    End Property

    Public Property TenKCB() As String
        Get
            Return Me.m_sTenKCB
        End Get
        Set(ByVal value As String)
            Me.m_sTenKCB = value
        End Set
    End Property

    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function


    Public Overridable Function setvalue(ByVal pmakcb As String, ByVal ptenkcb As String, ByVal m_ChonTable As Integer) As Boolean
        Me.MaKCB = pmakcb
        Me.TenKCB = ptenkcb
        Return False
    End Function

End Class
