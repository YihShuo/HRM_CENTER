Public Class clsDQuyetdinhTV
    Private s_manv As String
    Private s_dtp As String
    Private s_soqd As String
    Public Property manv() As String
        Get
            Return s_manv
        End Get
        Set(ByVal value As String)
            Me.s_manv = value
        End Set
    End Property
    Public Property ngay() As DateTime
        Get
            Return s_dtp
        End Get
        Set(ByVal value As DateTime)
            Me.s_dtp = value
        End Set
    End Property

    Public Property soquyetdinh() As String
        Get
            Return s_soqd
        End Get
        Set(ByVal value As String)
            Me.s_soqd = value
        End Set
    End Property
End Class
