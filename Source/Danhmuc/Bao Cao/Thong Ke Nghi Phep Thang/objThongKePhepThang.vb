Public Class objThongKePhepThang
    Private s_Ngay As String
    Public Property Ngay() As String
        Get
            Return s_Ngay
        End Get
        Set(ByVal value As String)
            Me.s_Ngay = value
        End Set
    End Property
End Class
