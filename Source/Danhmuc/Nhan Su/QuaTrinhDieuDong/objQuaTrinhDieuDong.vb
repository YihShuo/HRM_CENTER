Public Class objQuaTrinhDieuDong
    Public v_manv As String
    Public v_chonbang As Integer
    Public Property MaNV() As String
        Get
            Return Me.v_manv
        End Get
        Set(ByVal Value As String)
            Me.v_manv = Value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.v_chonbang
        End Get
        Set(ByVal Value As Integer)
            Me.v_chonbang = Value
        End Set
    End Property
    Public Overridable Function setvalue(ByVal v_manv As String, ByVal v_chonbang As Integer) As Boolean
        Me.MaNV = v_manv
        Me.ChonBang = v_chonbang
        Return False
    End Function
    Public Overridable Function Setnull() As Boolean
        Dim flag As Boolean
        Me.MaNV = ""
        Me.ChonBang = 0
        Return flag
    End Function

End Class
