Public Class objThongKeDanhSachCanBoThang
   
    Public Overridable Function setvalue(ByVal m_ChonTable As Integer) As Boolean
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
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.ChonBang = 0
        Return flag
    End Function
    Public m_sChonTable As Integer
End Class
